using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using Bitig.Data.Storage;
using Bitig.Logic.Model;
using System.Drawing;
using Bitig.Base;

namespace BitigDataTests
{
    [TestClass]
    public class XmlAlphabetRepoTests
    {
        public XmlAlphabetRepoTests()
        {
        }

        private const string currentDataFolder = @"AlphabetRepoTestData\";
        private readonly string preparedFile = currentDataFolder + @"Alphabet1025.xml";
        private readonly string directionsPath = currentDataFolder + "Direction777.xml";

        [TestInitialize]
        [TestCleanup]
        public void DeleteTestFile()
        {
            if (Directory.Exists(currentDataFolder))
                Directory.Delete(currentDataFolder, true);
            Directory.CreateDirectory(currentDataFolder);
            TestUtils.CopyDirectory("TestData", currentDataFolder);
        }

        [TestMethod]
        public void Insert()
        {
            var _xmlContext = new XmlContext(preparedFile, null);
            var _testRepo = _xmlContext.AlphabetRepository;
            var _name = "Test alphabet " + Guid.NewGuid();
            var _symbolText = Guid.NewGuid().ToString();
            var _symbolDisplayText = Guid.NewGuid().ToString();
            var _symbols = new List<AlphabetSymbol>
            {
                new AlphabetSymbol(_symbolText, DisplayText:_symbolDisplayText)
            };
            var _keyboardLayout = new KeyboardLayout { ID = 444 };
            var _alphabet = new Alphabet(-1, _name, true, new AlphabetFont("Arial", 16), KeyboardLayout: _keyboardLayout, CustomSymbols: _symbols);
            _testRepo.Insert(_alphabet);
            _xmlContext.SaveChanges();

            var _checkContext = new XmlContext(preparedFile, null);
            var _checkRepo = _checkContext.AlphabetRepository;
            var _list = _checkRepo.GetList();
            Assert.IsTrue(_list.Count > 0);
            var _insertedSummary = _list.Find(_item => _item.FriendlyName == _name);
            var _inserted = _testRepo.Get(_insertedSummary.ID);
            Assert.IsNotNull(_inserted);
            Assert.AreNotEqual(-1, _inserted.ID);
            Assert.IsTrue(_inserted.RightToLeft);
            Assert.IsNotNull(_inserted.DefaultFont);
            using (var _font = (Font)_inserted.DefaultFont)
            {
                Assert.AreEqual("Arial", _font.OriginalFontName);
                Assert.AreEqual(16, _font.Size);
            }
            Assert.IsNotNull(_inserted.CustomSymbols);
            Assert.AreEqual(1, _inserted.CustomSymbols.Count);
            Assert.AreEqual(_symbolText, _inserted.CustomSymbols[0].ActualText);
            Assert.AreEqual(_symbolDisplayText, _inserted.CustomSymbols[0].DisplayText);
            Assert.IsNotNull(_inserted.KeyboardLayout);
            Assert.AreEqual(_alphabet.KeyboardLayout.ID, _inserted.KeyboardLayout.ID);
        }

        [TestMethod]
        public void Insert_AssignID()
        {
            var _xmlContext = new XmlContext(preparedFile, directionsPath);
            var _testRepo = _xmlContext.AlphabetRepository;
            var _name1 = "Test alphabet " + Guid.NewGuid();
            var _name2 = "Test alphabet " + Guid.NewGuid();
            const int _id = -1;
            var _alphabet1 = new Alphabet(_id, _name1);
            _testRepo.Insert(_alphabet1);
            var _alphabet2 = new Alphabet(_id, _name2);
            _testRepo.Insert(_alphabet2);
            //Assert.AreNotEqual(-1, _alphabet1.ID);
            //Assert.AreNotEqual(-1, _alphabet2.ID);
            Assert.AreEqual(1026, _alphabet1.ID);
            Assert.AreEqual(1027, _alphabet2.ID);
        }

        [TestMethod]
        public void GetList()
        {
            var _xmlContext = new XmlContext(preparedFile, directionsPath);
            var _testRepo = _xmlContext.AlphabetRepository;
            var _list = _testRepo.GetList();
            Assert.AreEqual(5, _list.Count);
        }

        [TestMethod]
        public void Get()
        {
            var _xmlContext = new XmlContext(preparedFile, directionsPath);
            var _testRepo = _xmlContext.AlphabetRepository;
            var _alphabet = _testRepo.Get(1025);
            Assert.IsNotNull(_alphabet);
            Assert.IsNotNull(_alphabet.KeyboardLayout);
            Assert.AreEqual(333, _alphabet.KeyboardLayout.ID);
        }

        [TestMethod]
        public void Update()
        {
            var _xmlContext = new XmlContext(preparedFile, directionsPath);
            var _testRepo = _xmlContext.AlphabetRepository;
            var _alphabet = _testRepo.Get(1025);
            var _name2 = "Test name " + Guid.NewGuid();
            var _layout2 = new MagicKeyboardLayout { ID = 444 };
            var _symbolText2 = Guid.NewGuid().ToString();
            var _symbolText3 = Guid.NewGuid().ToString();
            _alphabet.FriendlyName = _name2;
            _alphabet.KeyboardLayout = _layout2;
            _alphabet.RightToLeft = true;
            _alphabet.DefaultFont = new AlphabetFont("Courier New", 24);
            _alphabet.CustomSymbols[0].ActualText = _symbolText2;
            _alphabet.CustomSymbols.Add(new AlphabetSymbol(_symbolText3));
            _testRepo.Update(_alphabet);
            _xmlContext.SaveChanges();

            var _checkContext = new XmlContext(preparedFile, directionsPath);
            var _checkRepo = _checkContext.AlphabetRepository;
            var _checkAlphabet = _checkRepo.Get(1025);
            Assert.IsNotNull(_checkAlphabet);
            Assert.AreEqual(_name2, _checkAlphabet.FriendlyName);
            Assert.AreEqual(_layout2.ID, _checkAlphabet.KeyboardLayout.ID);
            Assert.IsTrue(_checkAlphabet.RightToLeft);
            using (var _font = (Font)_checkAlphabet.DefaultFont)
            {
                Assert.AreEqual("Courier New", _font.OriginalFontName);
                Assert.AreEqual(24, _font.Size);
            }
            Assert.AreEqual(2, _checkAlphabet.CustomSymbols.Count);
            Assert.AreEqual(_symbolText2, _checkAlphabet.CustomSymbols[0].ActualText);
            Assert.AreEqual(_symbolText3, _checkAlphabet.CustomSymbols[1].ActualText);
        }

        [TestMethod]
        public void Delete()
        {
            var _xmlContext = new XmlContext(preparedFile, directionsPath);
            var _testRepo = _xmlContext.AlphabetRepository;
            var _testAlphabet = _testRepo.Get(1025);
            Assert.IsNotNull(_testAlphabet);
            _testRepo.Delete(_testAlphabet.ID);
            _xmlContext.SaveChanges();

            var _checkContext = new XmlContext(preparedFile, directionsPath);
            var _checkRepo = _checkContext.AlphabetRepository;
            var _checkAlphabet = _checkRepo.Get(1025);
            Assert.IsNull(_checkAlphabet);
        }

        [TestMethod]
        public void Delete_InUse()
        {
            var _xmlContext = new XmlContext(preparedFile, currentDataFolder + "DirectionCyrYan.xml");
            var _testRepo = _xmlContext.AlphabetRepository;
            var _testAlphabet = _testRepo.Get(0); 
            try
            {
                _testRepo.Delete(_testAlphabet.ID);
                Assert.Fail("Shouldn't have deleted");
            }
            catch (Exception ex)
            {
                Assert.AreEqual("Cannot delete alphabet in use.", ex.Message);
            }            
        }

        [TestMethod]
        public void InvalidConfig()
        {
            var _invalidFile = currentDataFolder + "InvalidAlphabets.xml";
            var _xmlContext = new XmlContext(_invalidFile, directionsPath);
            var _testRepo = _xmlContext.AlphabetRepository;
            var _list = _testRepo.GetList();

            Assert.AreEqual(0, _list.Count);
        }

        [TestMethod]
        public void Delete_CustomSymbols()
        {
            var _symbolsPath = currentDataFolder + @"Symbols\1025.xml";
            var _xmlContext = new XmlContext(preparedFile, directionsPath);
            var _testRepo = _xmlContext.AlphabetRepository;
            var _alphabet = _testRepo.Get(1025);
            Assert.AreNotEqual(0, _alphabet.CustomSymbols.Count);
            Assert.IsTrue(File.Exists(_symbolsPath));
            _testRepo.Delete(1025);
            _testRepo.DataContext.SaveChanges();
            Assert.IsFalse(File.Exists(_symbolsPath));
        }
    }
}
