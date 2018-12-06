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
            return _xmlList.Select(_item => _item.ToModel()).ToList();
        }

        public override Alifba Get(int ID)
        {
            var _xmlItem = xmlContext.Alphabets.Get(ID);
            return _xmlItem == null ? null : _xmlItem.ToModel();
        }

        public override Alifba GetBuiltIn(BuiltInAlifbaType BuiltIn)
        {
            var _xmlItem = xmlContext.Alphabets.GetList().Find(x => x.BuiltIn == BuiltIn);
            return _xmlItem.ToModel();
        }

        public override void Insert(Alifba Item)
        {
            var _xmlItem = new XmlAlifba(Item);
            xmlContext.Alphabets.Insert(_xmlItem);
            Item.ID = _xmlItem.ID;
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
        }

        public override void Update(Alifba Item)
        {
            xmlContext.Alphabets.Update(new XmlAlifba(Item));
        }

        public override Alifba GetYanalif()
        {
            var _yanalif = xmlContext.Alphabets.GetList().Find(x => x.BuiltIn == BuiltInAlifbaType.Yanalif);
            return _yanalif == null ? null : _yanalif.ToModel();
        }
    }
}
