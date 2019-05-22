using System;
using System.Collections.Generic;
using System.Linq;
using Bitig.Base;
using Bitig.Data.Model;
using Bitig.Data.Serialization;
using Bitig.KeyboardManagement;
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

        public override KeyboardLayoutBase Get(int KeyboardID)
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
                    MagicKey = KeysParser.ConvertToKeysEnum(_magicKeyboard.MagicKey),// (Keys)Enum.Parse(typeof(Keys), _magicKeyboard.MagicKey), 
                    KeyCombinations = _magicKeyboard.Collection.Select(x => x.ToModel()).ToList()
                };
            }
            throw new NotSupportedException("Keyboard layout type is not supported.");
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

        public override void Insert(KeyboardLayoutBase KeyboardConfig)
        {
            var _summary = new XmlKeyboardSummary(KeyboardConfig);
            xmlContext.KeyboardSummaries.Insert(_summary);
            KeyboardConfig.ID = _summary.ID;
            InsertOrUpdateKeyCombinations(KeyboardConfig);
        }

        public override void Update(KeyboardLayoutBase KeyboardConfig)
        {
            var _summary = new XmlKeyboardSummary(KeyboardConfig);
            xmlContext.KeyboardSummaries.Update(_summary);
            InsertOrUpdateKeyCombinations(KeyboardConfig);
        }

        private void InsertOrUpdateKeyCombinations(KeyboardLayoutBase KeyboardConfig)
        {
            var _keyboard = KeyboardConfig as KeyboardLayout;
            if (_keyboard != null)
            {
                var _combinations = new XmlCollectionConfig<XmlKeyCombination>
                {
                    ID = KeyboardConfig.ID,
                    Collection = _keyboard.KeyCombinations.Select(x => new XmlKeyCombination(x)).ToList()
                };
                xmlContext.Keyboards.InsertOrUpdate(_combinations);
                return;
            }
            var _magicKeyboard = KeyboardConfig as MagicKeyboardLayout;
            if (_magicKeyboard != null)
            {
                var _combinations = _magicKeyboard.KeyCombinations.Select(x => new XmlMagicKeyCombination(x)).ToList();
                var _xmlModel = new XmlMagicKeyboard
                {
                    ID = KeyboardConfig.ID,
                    Collection = _combinations,
                    MagicKey = KeysParser.ConvertKeysToString(_magicKeyboard.MagicKey) //_magicKeyboard.MagicKey.ToString()
                };
                xmlContext.MagicKeyboards.InsertOrUpdate(_xmlModel);
                return;
            }
            throw new NotSupportedException("Keyboard layout type is not supported.");
        }

        public override void Delete(int KeyboardID)
        {
            if (xmlContext.Alphabets.GetList().Any(x => x.KeyboardLayoutID == KeyboardID))
                throw new InvalidOperationException("Cannot delete keyboard layout in use.");
            xmlContext.KeyboardSummaries.Delete(KeyboardID);
            xmlContext.Keyboards.Delete(KeyboardID);
            xmlContext.MagicKeyboards.Delete(KeyboardID);
        }
    }
}
