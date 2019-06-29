using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Bitig.Base;
using Bitig.Data.Storage;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BitigDataTests
{
    [TestClass]
    public class XmlKeyboardRepoTests
    {
        private const string preparedDataFolder = @"TestData\Prepared\";
        private const string currentDataFolder = @"KeyboardsTestData\";
        private readonly string preparedFile1 = @"Keyboards\333.xml";
        private readonly string preparedFile2 = @"Keyboards\444.xml";
        private readonly string preparedSummaryFile = @"KeyboardSummaries.xml";

        [TestInitialize]
        [TestCleanup]
        public void PrepareFiles()
        {
            if (Directory.Exists(currentDataFolder))
                Directory.Delete(currentDataFolder, true);
            Directory.CreateDirectory(currentDataFolder);
            Directory.CreateDirectory(currentDataFolder + "Keyboards");
            File.Copy(preparedDataFolder + preparedFile1, currentDataFolder + preparedFile1);
            File.Copy(preparedDataFolder + preparedFile2, currentDataFolder + preparedFile2);
            File.Copy(preparedDataFolder + preparedSummaryFile, currentDataFolder + preparedSummaryFile);
        }

        [TestMethod]
        public void Get()
        {
            var _context = new XmlContext(currentDataFolder);
            var _repository = new XmlKeyboardRepository(_context);
            var _keyboard = _repository.Get(333) as KeyboardLayout;
            Assert.IsNotNull(_keyboard);
            Assert.AreEqual("TestConfig333", _keyboard.FriendlyName);
            Assert.AreEqual(333, _keyboard.ID);
            Assert.AreEqual(3, _keyboard.KeyCombinations.Count);

            var _combination1 = _keyboard.KeyCombinations[0];
            Assert.AreEqual(Keys.D1, _combination1.MainKey);
            Assert.AreEqual("!", _combination1.Result);
            Assert.IsTrue(_combination1.WithAlt);
            Assert.IsFalse(_combination1.WithAltGr);
            Assert.IsFalse(_combination1.WithCtrl);
            Assert.IsTrue(_combination1.WithShift);

            var _combination2 = _keyboard.KeyCombinations[1];
            Assert.AreEqual(Keys.C, _combination2.MainKey);
            Assert.AreEqual("ç", _combination2.Result);
            Assert.AreEqual("Ç", _combination2.Capital);
            Assert.IsFalse(_combination2.WithAlt);
            Assert.IsTrue(_combination2.WithAltGr);
            Assert.IsFalse(_combination2.WithCtrl);
            Assert.IsFalse(_combination2.WithShift);

            var _combination3 = _keyboard.KeyCombinations[2];
            Assert.AreEqual(Keys.R, _combination3.MainKey);
            Assert.AreEqual("Enter", _combination3.Result);
            Assert.IsFalse(_combination3.WithAlt);
            Assert.IsFalse(_combination3.WithAltGr);
            Assert.IsFalse(_combination3.WithCtrl);
            Assert.IsFalse(_combination3.WithShift);
        }

        [TestMethod]
        public void GetSummary()
        {
            var _context = new XmlContext(currentDataFolder);
            var _repository = new XmlKeyboardRepository(_context);
            var _summary = _repository.GetSummary(444);
            Assert.IsNotNull(_summary);
            Assert.AreEqual("TestConfig444", _summary.FriendlyName);
        }

        [TestMethod]
        public void GetSummaryList()
        {
            var _context = new XmlContext(currentDataFolder);
            var _repository = new XmlKeyboardRepository(_context);
            var _summaries = _repository.GetSummaryList();
            Assert.AreEqual(2, _summaries.Count);
            Assert.AreEqual(333, _summaries[0].ID);
            Assert.AreEqual(KeyboardLayoutType.Full, _summaries[0].Type);
            Assert.AreEqual(444, _summaries[1].ID);
            Assert.AreEqual(KeyboardLayoutType.Magic, _summaries[1].Type);
        }

        [TestMethod]
        public void Get_MagicKeyboard()
        {
            var _context = new XmlContext(currentDataFolder);
            var _repository = new XmlKeyboardRepository(_context);
            var _keyboard = _repository.Get(444) as MagicKeyboardLayout;
            Assert.IsNotNull(_keyboard);
            Assert.AreEqual(Keys.Enter, _keyboard.MagicKey);
            Assert.AreEqual(2, _keyboard.KeyCombinations.Count);
            Assert.AreEqual('s', _keyboard.KeyCombinations[0].Symbol);
            Assert.AreEqual("ş", _keyboard.KeyCombinations[0].WithMagic);
            Assert.AreEqual('u', _keyboard.KeyCombinations[1].Symbol);
            Assert.AreEqual("ü", _keyboard.KeyCombinations[1].WithMagic);
        }

        [TestMethod]
        public void Insert_FullKeyboard()
        {
            var _context = new XmlContext(currentDataFolder);
            var _repository = new XmlKeyboardRepository(_context);
            var _newKeyboard = new KeyboardLayout
            {
                FriendlyName = "keyboard_" + Guid.NewGuid(),
                KeyCombinations = new List<KeyCombination>
                {
                    new KeyCombination
                    {
                        MainKey = Keys.A,
                        WithAltGr = true,
                        Result = "ä",
                        Capital = "Ä"
                    },
                    new KeyCombination
                    {
                        MainKey = Keys.Oemplus,
                        Result = "_",
                        WithShift = true
                    }
                }
            };
            _repository.Insert(_newKeyboard);
            _context.SaveChanges();

            var _checkContext = new XmlContext(currentDataFolder);
            var _checkRepo = _checkContext.KeyboardRepository;
            var _keyboards = _checkRepo.GetSummaryList();
            var _addedSummary = _keyboards.Single(x => x.FriendlyName == _newKeyboard.FriendlyName);
            var _addedKeyboard = _checkRepo.Get(_addedSummary.ID);
            var _addedFullKeyboard = _addedKeyboard as KeyboardLayout;
            Assert.IsNotNull(_addedFullKeyboard);
            Assert.AreEqual(2, _addedFullKeyboard.KeyCombinations.Count);
            var _combination1 = _addedFullKeyboard.KeyCombinations[0];
            Assert.AreEqual(Keys.A, _combination1.MainKey);
            Assert.AreEqual("ä", _combination1.Result);
            Assert.AreEqual("Ä", _combination1.Capital);
            Assert.IsTrue(_combination1.WithAltGr);
            Assert.IsFalse(_combination1.WithAlt);
            Assert.IsFalse(_combination1.WithCtrl);
            Assert.IsFalse(_combination1.WithShift);
        }


        [TestMethod]
        public void Insert_MagicKeyboard()
        {
            var _context = new XmlContext(currentDataFolder);
            var _repository = new XmlKeyboardRepository(_context);
            var _newKeyboard = new MagicKeyboardLayout
            {
                FriendlyName = "magic_keyboard_" + Guid.NewGuid(),
                MagicKey = Keys.Back,
                KeyCombinations = new List<MagicKeyCombination>
                {
                    new MagicKeyCombination
                    {
                        Symbol = 'i',
                        WithMagic = "latin letter i"
                    },
                    new MagicKeyCombination
                    {
                        Symbol = 'I',
                        WithMagic = "latin letter I"
                    }
                }
            };
            _repository.Insert(_newKeyboard);
            _context.SaveChanges();

            var _checkContext = new XmlContext(currentDataFolder);
            var _checkRepo = _checkContext.KeyboardRepository;
            var _keyboards = _checkRepo.GetSummaryList();
            var _addedSummary = _keyboards.Single(x => x.FriendlyName == _newKeyboard.FriendlyName);
            var _addedKeyboard = _checkRepo.Get(_addedSummary.ID);
            var _addedMagicKeyboard = _addedKeyboard as MagicKeyboardLayout;
            Assert.IsNotNull(_addedMagicKeyboard);
            Assert.AreEqual(2, _addedMagicKeyboard.KeyCombinations.Count);
            var _combination1 = _addedMagicKeyboard.KeyCombinations[0];
            Assert.AreEqual('i', _combination1.Symbol);
            Assert.AreEqual("latin letter i", _combination1.WithMagic);
        }

        [TestMethod]
        public void Update_FullKeyboard()
        {
            var _context = new XmlContext(currentDataFolder);
            var _repository = new XmlKeyboardRepository(_context);
            var _keyboard333 = _repository.Get(333);
            var _newName = "new_name_" + Guid.NewGuid();
            _keyboard333.FriendlyName = _newName;
            var _newCombination =
                new KeyCombination
                {
                    MainKey = Keys.A,
                    WithAltGr = true,
                    Result = "ä",
                    Capital = "Ä"
                };
            (_keyboard333 as KeyboardLayout).KeyCombinations.Add(_newCombination);
            _repository.Update(_keyboard333);
            _context.SaveChanges();

            var _checkContext = new XmlContext(currentDataFolder);
            var _checkRepo = _checkContext.KeyboardRepository;
            var _editedKeyboard = _checkRepo.Get(333);
            var _editedFullKeyboard = _editedKeyboard as KeyboardLayout;
            Assert.IsNotNull(_editedFullKeyboard);
            Assert.AreEqual(_newName, _editedFullKeyboard.FriendlyName);
            Assert.AreEqual(4, _editedFullKeyboard.KeyCombinations.Count);
            var _addedCombination = _editedFullKeyboard.KeyCombinations.Single(x => x.MainKey == Keys.A);
            Assert.AreEqual("ä", _addedCombination.Result);
            Assert.AreEqual("Ä", _addedCombination.Capital);
            Assert.IsTrue(_addedCombination.WithAltGr);
            Assert.IsFalse(_addedCombination.WithAlt);
            Assert.IsFalse(_addedCombination.WithCtrl);
            Assert.IsFalse(_addedCombination.WithShift);
        }


        [TestMethod]
        public void Update_MagicKeyboard()
        {
            var _context = new XmlContext(currentDataFolder);
            var _repository = new XmlKeyboardRepository(_context);
            var _keyboard444 = _repository.Get(444) as MagicKeyboardLayout;
            var _newName = "new_name_" + Guid.NewGuid();
            _keyboard444.FriendlyName = _newName;
            var _newCombination =
                new MagicKeyCombination
                {
                    Symbol = 'a',
                    WithMagic = "ä"
                };
            _keyboard444.KeyCombinations.Add(_newCombination);
            _keyboard444.MagicKey = Keys.OemSemicolon;
            _repository.Update(_keyboard444);
            _context.SaveChanges();

            var _checkContext = new XmlContext(currentDataFolder);
            var _checkRepo = _checkContext.KeyboardRepository;
            var _editedKeyboard = _checkRepo.Get(444);
            var _editedFullKeyboard = _editedKeyboard as MagicKeyboardLayout;
            Assert.IsNotNull(_editedFullKeyboard);
            Assert.AreEqual(_newName, _editedFullKeyboard.FriendlyName);
            Assert.AreEqual(Keys.OemSemicolon, _editedFullKeyboard.MagicKey);
            Assert.AreEqual(3, _editedFullKeyboard.KeyCombinations.Count);
            var _addedCombination = _editedFullKeyboard.KeyCombinations.Single(x => x.Symbol == 'a');
            Assert.AreEqual("ä", _addedCombination.WithMagic);
        }

        [TestMethod]
        public void Delete()
        {
            var _context = new XmlContext(currentDataFolder);
            var _repository = new XmlKeyboardRepository(_context);
            _repository.Delete(333);
            _context.SaveChanges();

            var _checkContext = new XmlContext(currentDataFolder);
            var _checkRepo = _checkContext.KeyboardRepository;
            Assert.IsNull(_checkRepo.Get(333));
            Assert.IsFalse(File.Exists(currentDataFolder + preparedFile1));
        }

        [TestMethod]
        public void Delete_Magic()
        {
            var _context = new XmlContext(currentDataFolder);
            var _repository = new XmlKeyboardRepository(_context);
            _repository.Delete(444);
            _context.SaveChanges();

            var _checkContext = new XmlContext(currentDataFolder);
            var _checkRepo = _checkContext.KeyboardRepository;
            Assert.IsNull(_checkRepo.Get(444));
            Assert.IsFalse(File.Exists(currentDataFolder + preparedFile2));
        }

        [TestMethod]
        public void Delete_InUse()
        {
            File.Copy(preparedDataFolder + @"Alphabet1025.xml", currentDataFolder + "Alphabets.xml");
            var _context = new XmlContext(currentDataFolder);
            var _repository = new XmlKeyboardRepository(_context);
            try
            {
                _repository.Delete(333);
                Assert.Fail("Shouldn't have deleted");
            }
            catch (Exception ex)
            {
                Assert.AreEqual("Cannot delete keyboard layout in use.", ex.Message);
            }
        }
    }
}
