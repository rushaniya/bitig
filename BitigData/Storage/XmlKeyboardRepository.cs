using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Bitig.Base;
using Bitig.Logic.Model;
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

        public override KeyboardLayoutBase GetKeyboardConfig(int KeyboardID)
        {
            var _summary = xmlContext.KeyboardSummaries.Get(KeyboardID);
            if (_summary == null)
                return null;
            var _keyboard = _summary.Type == KeyboardLayoutType.Full ? xmlContext.Keyboards.Get(KeyboardID) : null;
            var _magicKeyboard = _summary.Type == KeyboardLayoutType.Magic ? xmlContext.MagicKeyboards.Get(KeyboardID) : null;
            if (_keyboard == null && _magicKeyboard == null)
                return null;
            if (_summary.Type == KeyboardLayoutType.Full)
            {
                return new KeyboardLayout
                {
                    FriendlyName = _summary.FriendlyName,
                    ID = _keyboard.ID,
                    KeyCombinations = _keyboard.Collection.Select(x => x.ToModel()).ToList()
                };
            }
            if (_summary.Type == KeyboardLayoutType.Magic)
            {
                return new MagicKeyboardLayout
                {
                    FriendlyName = _summary.FriendlyName,
                    ID = _magicKeyboard.ID,
                    MagicKey = (Keys)Enum.Parse(typeof(Keys), _magicKeyboard.MagicKey),
                    KeyCombinations = _magicKeyboard.Collection.Select(x => x.ToModel()).ToList()
                };
            }
            throw new NotSupportedException("Keyboard layout type is not supported");
        }

        public override KeyboardLayoutSummary GetSummary(int KeyboardID)
        {
            var _keyboard = xmlContext.KeyboardSummaries.Get(KeyboardID);
            if (_keyboard == null)
                return null;
            return _keyboard.ToModel();
        }

        public override List<KeyboardLayoutSummary> GetSummaryList()
        {
            var _keyboards = xmlContext.KeyboardSummaries.GetList().Select(x => x.ToModel()).ToList();
            return _keyboards;
        }
    }
}
