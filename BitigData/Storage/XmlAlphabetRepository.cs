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
    public class XmlAlphabetRepository : AlphabetRepository
    {
        private XmlContext xmlContext;

        public override IDataContext DataContext
        {
            get
            {
                return xmlContext;
            }
        }

        public XmlAlphabetRepository(XmlContext XmlContext)
        {
            xmlContext = XmlContext;
        }

        public override List<AlphabetSummary> GetList()
        {
            var _xmlList = xmlContext.Alphabets.GetList();
            return _xmlList.Select(_item => _item.ToSummary()).ToList();
        }

        public override Alphabet Get(int ID)
        {
            var _xmlItem = xmlContext.Alphabets.Get(ID);
            return _xmlItem == null ? null : MapWithReferences(_xmlItem);
        }

        public override void Insert(AlphabetSummary Item)
        {
            var _xmlItem = new XmlAlphabet(Item);
            xmlContext.Alphabets.Insert(_xmlItem);
            Item.ID = _xmlItem.ID;
            var _fullModel = Item as Alphabet;
            if (_fullModel != null && _fullModel.CustomSymbols != null)
            {
                var _symbolList = new XmlCollectionConfig<XmlAlphabetSymbol> { ID = _xmlItem.ID, Collection = _fullModel.CustomSymbols.Select(x => new XmlAlphabetSymbol(x)).ToList() };
                xmlContext.CustomSymbols.InsertOrUpdate(_symbolList);
            }
        }

        public override void Delete(int ID)
        {
            var _xmlItem = xmlContext.Alphabets.Get(ID);
            if (_xmlItem == null)
                return;
            if (xmlContext.Directions.GetList().Any(x => x.SourceAlphabetID == ID || x.TargetAlphabetID == ID))
                throw new InvalidOperationException("Cannot delete alphabet in use.");
            xmlContext.Alphabets.Delete(ID);
            xmlContext.CustomSymbols.Delete(ID);
        }

        public override void Update(AlphabetSummary Item)
        {
            xmlContext.Alphabets.Update(new XmlAlphabet(Item));
            var _fullModel = Item as Alphabet;
            if (_fullModel != null && _fullModel.CustomSymbols != null)
            {
                var _symbolList = new XmlCollectionConfig<XmlAlphabetSymbol> { ID = Item.ID, Collection = _fullModel.CustomSymbols.Select(x => new XmlAlphabetSymbol(x)).ToList() };
                xmlContext.CustomSymbols.InsertOrUpdate(_symbolList);
            }
        }

        private Alphabet MapWithReferences(XmlAlphabet StoredAlphabet)
        {
            List<AlphabetSymbol> _customSymbols = null;
            var _xmlSymbols = xmlContext.CustomSymbols.Get(StoredAlphabet.ID);
            if (_xmlSymbols != null && _xmlSymbols.Collection != null)
            {
                _customSymbols = _xmlSymbols.Collection.Select(x => x.ToModel()).ToList();
            }
            var _defaultFont =StoredAlphabet.DefaultFont == null ? null : new AlphabetFont(StoredAlphabet.DefaultFont.Description);
            KeyboardLayoutBase _keyboardLayout = null;
            if (StoredAlphabet.KeyboardLayoutID != null)
            {
                _keyboardLayout = xmlContext.KeyboardRepository.Get(StoredAlphabet.KeyboardLayoutID.Value);                
            }
            return new Alphabet(StoredAlphabet.ID, StoredAlphabet.FriendlyName, StoredAlphabet.RightToLeft, _defaultFont, _keyboardLayout, _customSymbols);
        }
    }
}
