using System;
using System.Collections.Generic;
using Bitig.Logic.Repository;
using Bitig.Logic.Model;
using System.Linq;
using Bitig.Data.Model;

namespace Bitig.Data.Storage
{
    public class XmlAlifbaRepository : AlifbaRepository
    {
        private XmlContext xmlContext;

        public override IDataContext DataContext
        {
            get
            {
                return xmlContext;
            }
        }

        public XmlAlifbaRepository(XmlContext XmlContext)
        {
            xmlContext = XmlContext;
        }

        public override List<Alifba> GetList()
        {
            var _xmlList = xmlContext.Alphabets.GetList();
            return _xmlList.Select(_item => _item.ToShallowModel()).ToList();
        }

        public override Alifba Get(int ID)
        {
            var _xmlItem = xmlContext.Alphabets.Get(ID);
            return _xmlItem == null ? null : MapWithReferences(_xmlItem);
        }

        public override Alifba GetBuiltIn(BuiltInAlifbaType BuiltIn)
        {
            var _xmlItem = xmlContext.Alphabets.GetList().Find(x => x.BuiltIn == BuiltIn);
            return _xmlItem.ToShallowModel();
        }

        public override void Insert(Alifba Item)
        {
            var _xmlItem = new XmlAlifba(Item);
            xmlContext.Alphabets.Insert(_xmlItem);
            Item.ID = _xmlItem.ID;
            if (Item.CustomSymbols != null)
            {
                var _symbolList = new XmlSymbolCollection(Item.ID, Item.CustomSymbols);
                xmlContext.CustomSymbols.InsertOrUpdate(_symbolList);
            }
        }

        public override void Delete(int ID)
        {
            var _xmlItem = xmlContext.Alphabets.Get(ID);
            if (_xmlItem == null)
                return;
            if (_xmlItem.BuiltIn == BuiltInAlifbaType.Yanalif)
                throw new InvalidOperationException("Cannot delete Yanalif.");
            if (xmlContext.Directions.GetList().Any(x => x.SourceAlifbaID == ID || x.TargetAlifbaID == ID))
                throw new InvalidOperationException("Cannot delete alphabet in use.");
            xmlContext.Alphabets.Delete(ID);
            xmlContext.CustomSymbols.Delete(ID);
        }

        public override void Update(Alifba Item)
        {
            xmlContext.Alphabets.Update(new XmlAlifba(Item));
            if (Item.CustomSymbols != null)
            {
                var _symbolList = new XmlSymbolCollection(Item.ID, Item.CustomSymbols);
                xmlContext.CustomSymbols.InsertOrUpdate(_symbolList);
            }
        }

        public override Alifba GetYanalif()
        {
            var _yanalif = xmlContext.Alphabets.GetList().Find(x => x.BuiltIn == BuiltInAlifbaType.Yanalif);
            return _yanalif == null ? null : MapWithReferences(_yanalif);
        }

        private Alifba MapWithReferences(XmlAlifba StoredAlifba)
        {
            List<AlifbaSymbol> _customSymbols = null;
            var _xmlSymbols = xmlContext.CustomSymbols.Get(StoredAlifba.ID);
            if (_xmlSymbols != null)
            {
                _customSymbols = _xmlSymbols.Symbols.Select(x => x.ToModel()).ToList();
            }
            var _defaultFont =StoredAlifba.DefaultFont == null ? null : new AlifbaFont(StoredAlifba.DefaultFont.Description);
            return new Alifba(StoredAlifba.ID, StoredAlifba.FriendlyName, _customSymbols, StoredAlifba.RightToLeft, _defaultFont, StoredAlifba.BuiltIn, StoredAlifba.KeyboardLayoutID);
        }
    }
}
