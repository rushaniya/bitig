using System;
using System.Collections.Generic;
using Bitig.Logic.Repository;
using Bitig.Data.Model;
using Bitig.Logic.Model;
using System.Drawing;

namespace Bitig.Data.Storage
{
    public class XmlAlifbaRepository : AlifbaRepository
    {
        private readonly string path;

        private List<XmlAlifba> xmlList;

        public XmlAlifbaRepository(string Path)
        {
            IsFlushable = true;
            path = Path;
        }

        private void ReadListFromFile()
        {
            xmlList = AlifbaSerializer.ReadFromFile(path);
            if (xmlList == null)
                xmlList = new List<XmlAlifba>();
            //if (xmlList.Count == 0)
            //{
            //    CreateDefaultConfiguration();
            //}
            //var xmlYanalif = xmlList.Find(_alif => _alif.ID == DefaultConfiguration.YANALIF);
            //if (xmlYanalif == null) //repo: in base (abstract) class?
            //{
            //    CreateYanalif();
            //}
        }

        private Alifba MapToModel(XmlAlifba StoredAlifba)
        {
            var _customSymbols = new List<AlifbaSymbol>();
            if(StoredAlifba.CustomSymbols != null)
            {
                foreach (var _symbol in StoredAlifba.CustomSymbols)
                {
                    _customSymbols.Add(MapToModel(_symbol));
                }
            }

            var _alifba = new Alifba(StoredAlifba.ID, StoredAlifba.FriendlyName,
                _customSymbols, StoredAlifba.RightToLeft, MapToModel(StoredAlifba.DefaultFont));
            return _alifba;
        }

        private AlifbaFont MapToModel(XmlFont StoredFont)
        {
            if (StoredFont == null)
                return null;
            return new AlifbaFont(StoredFont.Description);
        }

        private AlifbaSymbol MapToModel(XmlAlifbaSymbol StoredSymbol)
        {
            return new AlifbaSymbol(StoredSymbol.ActualText, StoredSymbol.DisplayText,
                StoredSymbol.CapitalizedText, StoredSymbol.CapitalizedDisplayText);
        }

        private XmlAlifba MapToStorage(Alifba ModelAlifba)
        {
            var _customSymbols = new List<XmlAlifbaSymbol>();
            if (ModelAlifba.CustomSymbols != null)
            {
                foreach (var _symbol in ModelAlifba.CustomSymbols)
                {
                    _customSymbols.Add(MapToStorage(_symbol));
                }
            }
            var _xmlAlifba = new XmlAlifba(ModelAlifba.ID, ModelAlifba.FriendlyName, _customSymbols,
                ModelAlifba.RightToLeft, MapToStorage(ModelAlifba.DefaultFont));
           
            return _xmlAlifba;
        }

        private XmlFont MapToStorage(AlifbaFont ModelFont)
        {
            if (ModelFont == null)
                return null;
            return new XmlFont { Description = ModelFont.Description };
        }

        private XmlAlifbaSymbol MapToStorage(AlifbaSymbol ModelSymbol)
        {
            return new XmlAlifbaSymbol
            {
                ActualText = ModelSymbol.ActualText,
                DisplayText = ModelSymbol.DisplayText,
                CapitalizedText = ModelSymbol.CapitalizedText,
                CapitalizedDisplayText = ModelSymbol.CapitalizedDisplayText
            };
        }

        protected override List<Alifba> GetListNoCreate()
        {
            if (xmlList == null) 
                ReadListFromFile();
            var _result = new List<Alifba>();
            foreach (var _xmlAlifba in xmlList)
            {
                _result.Add(MapToModel(_xmlAlifba));
            }
            return _result;
        }

        protected override void InsertExactID(Alifba Item)
        {
            if (GetNoCreate(Item.ID) != null)
                throw new Exception("Same ID exists.");
            xmlList.Add(MapToStorage(Item));
        }

        public override void Update(Alifba Item)
        {
            if (Item == null)
                throw new ArgumentNullException("Item");
            if (xmlList == null)
            {
                ReadListFromFile();
            }
            var _alifba = xmlList.Find(_item => _item.ID == Item.ID);
            if (_alifba == null)
                throw new InvalidOperationException("Alifba does not exist.");
            xmlList.Remove(_alifba);
            xmlList.Add(MapToStorage(Item));
        }

        protected override Alifba GetNoCreate(int ID)
        {
            if (xmlList == null)
            {
                ReadListFromFile();
            }
            var _alifba = xmlList.Find(_item => _item.ID == ID);
            if (_alifba == null)
                return null;
            return MapToModel(_alifba);
        }


        public override void Delete(Alifba Item)
        {
            if (Item == null)
                throw new ArgumentNullException("Item");
            if (xmlList == null)
            {
                ReadListFromFile();
            }
            var _alifba = xmlList.Find(_item => _item.ID == Item.ID);
            if (_alifba != null)
                xmlList.Remove(_alifba);
        }

        protected override void FlushChanges()
        {
            AlifbaSerializer.SaveToFile(path, xmlList);
        }
    }
}
