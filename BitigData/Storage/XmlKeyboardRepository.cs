using System.Linq;
using Bitig.Base;
using Bitig.Logic.Repository;

namespace Bitig.Data.Storage
{
    public class XmlKeyboardRepository : KeyboardRepository
    {
        private XmlContext xmlContext;

        public override IDataContext DataContext
        {
            get
            {
                return xmlContext;
            }
        }

        public XmlKeyboardRepository(XmlContext XmlContext)
        {
            xmlContext = XmlContext;
        }

        public override KeyboardConfig GetKeyboardConfig(int AlifbaID)
        {
            var _keyCollection = xmlContext.KeyBoards.Get(AlifbaID);
            if (_keyCollection == null)
                return null;
            return new KeyboardConfig { KeyCombinations = _keyCollection.KeyCombinations.Select(x => x.ToModel()).ToList() };
        }
    }
}
