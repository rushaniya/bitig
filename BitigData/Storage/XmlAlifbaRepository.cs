using System;
using System.Collections.Generic;
using Bitig.Logic.Repository;
using Bitig.Logic.Model;
using System.Linq;
using Bitig.Data.Model;
using Bitig.Data.Serialization;
using Bitig.Base;

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

        public override List<AlifbaSummary> GetList()
        {
            var _xmlList = xmlContext.Alphabets.GetList();
            return _xmlList.Select(_item => _item.ToSummary()).ToList();
        }

        public override Alifba Get(int ID)
        {
            var _xmlItem = xmlContext.Alphabets.Get(ID);
            return _xmlItem == null ? null : MapWithReferences(_xmlItem);
        }

        public override void Insert(AlifbaSummary Item)
        {
            var _xmlItem = new XmlAlifba(Item);
            xmlContext.Alphabets.Insert(_xmlItem);
            Item.ID = _xmlItem.ID;
            var _fullModel = Item as Alifba;
            if (_fullModel != null && _fullModel.CustomSymbols != null)
            {
                var _symbolList = new XmlCollectionConfig<XmlAlifbaSymbol> { ID = _xmlItem.ID, Collection = _fullModel.CustomSymbols.Select(x => new XmlAlifbaSymbol(x)).ToList() };
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

        public override void Update(AlifbaSummary Item)
        {
            xmlContext.Alphabets.Update(new XmlAlifba(Item));
            var _fullModel = Item as Alifba;
            if (_fullModel != null && _fullModel.CustomSymbols != null)
            {
                var _symbolList = new XmlCollectionConfig<XmlAlifbaSymbol> { ID = Item.ID, Collection = _fullModel.CustomSymbols.Select(x => new XmlAlifbaSymbol(x)).ToList() };
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
            if (_xmlSymbols != null && _xmlSymbols.Collection != null)
            {
                _customSymbols = _xmlSymbols.Collection.Select(x => x.ToModel()).ToList();
            }
            var _defaultFont =StoredAlifba.DefaultFont == null ? null : new AlifbaFont(StoredAlifba.DefaultFont.Description);
            KeyboardLayoutBase _keyboardLayout = null;
            if (StoredAlifba.KeyboardLayoutID != null)
            {
                _keyboardLayout = xmlContext.KeyboardRepository.Get(StoredAlifba.KeyboardLayoutID.Value);                
            }
            return new Alifba(StoredAlifba.ID, StoredAlifba.FriendlyName, StoredAlifba.RightToLeft, _defaultFont, StoredAlifba.BuiltIn, _keyboardLayout, _customSymbols);
        }
    }
}
