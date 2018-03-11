using System;
using System.Collections.Generic;
using Bitig.Logic.Repository;
using Bitig.Data.Model;
using Bitig.Logic.Model;
using System.Linq;

namespace Bitig.Data.Storage
{
    public class XmlAlifbaRepository : IRepository<Alifba, int>
    {
        private readonly string path;

        private List<XmlAlifba> xmlList;

        public RepositoryProvider RepositoryProvider
        {
            get;
            set;
        }

        public bool IsFlushable
        {
            get
            {
                return true;
            }
        }

        public XmlAlifbaRepository(string Path)
        {
            path = Path;
        }

        private void ReadListFromFile()
        {
            xmlList = AlifbaSerializer.ReadFromFile(path);
            if (xmlList == null)
                xmlList = new List<XmlAlifba>();
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
                _customSymbols, StoredAlifba.RightToLeft, MapToModel(StoredAlifba.DefaultFont), StoredAlifba.BuiltIn);
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
            return new AlifbaSymbol(StoredSymbol.ActualText, StoredSymbol.CapitalizedText,
                StoredSymbol.DisplayText, StoredSymbol.CapitalizedDisplayText);
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
                ModelAlifba.RightToLeft, MapToStorage(ModelAlifba.DefaultFont), ModelAlifba.BuiltIn);
           
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

        public List<Alifba> GetList()
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

        public void Insert(Alifba Item)
        {
            if (xmlList == null)
            {
                ReadListFromFile();
            }
            xmlList.Add(MapToStorage(Item));
        }

        public void Update(Alifba Item)
        {
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

        public Alifba Get(int ID)
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


        public void Delete(Alifba Item)
        {
            //if (RepositoryProvider == null)
            //    throw new Exception("RepositoryProvider is null. Cannot access DirectionRepository.");
            //if (RepositoryProvider.DirectionRepository.IsInUse(Item))
            //    throw new Exception("Cannot delete alphabet in use.");
            if (xmlList == null)
            {
                ReadListFromFile();
            }
            var _alifba = xmlList.Find(_item => _item.ID == Item.ID);
            if (_alifba != null)
                xmlList.Remove(_alifba);
        }

        public void SaveChanges()
        {
            AlifbaSerializer.SaveToFile(path, xmlList);
        }

        public int GenerateID(IEnumerable<int> ExistingIDs)
        {
            int _result = -1;
            for (int i = 0; i < int.MaxValue; i++)
            {
                if (ExistingIDs.All(_id => _id != i))
                {
                    _result = i;
                    break;
                }
            }
            return _result;
        }
    }
}
