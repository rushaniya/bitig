using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using Bitig.Data.Storage;
using Bitig.Logic.Model;
using System.Drawing;
using Bitig.Logic.Repository;

namespace BitigDataTests
{
    [TestClass]
    public class XmlAlifbaRepoTests
    {
        public XmlAlifbaRepoTests()
        {
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        private const string dataFolder = @"TestData\";
        private readonly string testFilePath = dataFolder + "Alphabets.xml";
        private readonly string preparedFile = dataFolder + @"Prepared\Alifba1025.xml";
        private readonly string corruptedFile = dataFolder + @"Corrupted\NoYanalif.xml";
        private readonly string directionsPath = dataFolder + "Directions.xml";

        [TestInitialize]
        [TestCleanup]
        public void DeleteTestFile()
        {
            if (File.Exists(testFilePath))
                File.Delete(testFilePath);
            if (File.Exists(directionsPath))
                File.Delete(directionsPath);
        }

        [TestMethod]
        public void Insert()
        {
            var _xmlContext = new XmlContext(testFilePath, null);
            var _testRepo = _xmlContext.AlifbaRepository;
            var _name = "Test alifba " + Guid.NewGuid();
            var _symbolText = Guid.NewGuid().ToString();
            var _symbolDisplayText = Guid.NewGuid().ToString();
            var _symbols = new List<AlifbaSymbol>
            {
                new AlifbaSymbol(_symbolText, DisplayText:_symbolDisplayText)
            };
            var _alifba = new Alifba(-1, _name, _symbols, true, new AlifbaFont("Arial", 16));
            _testRepo.Insert(_alifba);
            _xmlContext.SaveChanges();

            var _checkContext = new XmlContext(testFilePath, null);
            var _checkRepo = _checkContext.AlifbaRepository;
            var _list = _checkRepo.GetList();
            Assert.IsTrue(_list.Count > 0);
            var _inserted = _list.Find(_item => _item.FriendlyName == _name);
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
        }

        [TestMethod]
        public void Insert_AssignID()
        {
            var _xmlContext = new XmlContext(testFilePath, directionsPath);
            var _testRepo = _xmlContext.AlifbaRepository;
            var _name1 = "Test alifba " + Guid.NewGuid();
            var _name2 = "Test alifba " + Guid.NewGuid();
            const int _id = -1;
            var _alifba1 = new Alifba(_id, _name1);
            _testRepo.Insert(_alifba1);
            var _alifba2 = new Alifba(_id, _name2);
            _testRepo.Insert(_alifba2);
            Assert.AreNotEqual(-1, _alifba1.ID);
            Assert.AreNotEqual(-1, _alifba2.ID);
            Assert.AreEqual(DefaultConfiguration.BuiltInAlifbaList.Count, _alifba1.ID);
            Assert.AreEqual(DefaultConfiguration.BuiltInAlifbaList.Count + 1, _alifba2.ID);
        }

        [TestMethod]
        public void Insert_CreateDefault()
        {
            var _xmlContext = new XmlContext(testFilePath, directionsPath);
            var _testRepo = _xmlContext.AlifbaRepository;
            var _name1 = "Test alifba " + Guid.NewGuid();
            var _alifba1 = new Alifba(-1, _name1);
            _testRepo.Insert(_alifba1);
            _xmlContext.SaveChanges();
            var _list = _testRepo.GetList();
            Assert.AreEqual(DefaultConfiguration.BuiltInAlifbaList.Count + 1, _list.Count);
        }

        [TestMethod]
        public void GetList()
        {
            File.Copy(preparedFile, testFilePath);

            var _xmlContext = new XmlContext(testFilePath, directionsPath);
            var _testRepo = _xmlContext.AlifbaRepository;
            var _list = _testRepo.GetList();
            Assert.AreEqual(2, _list.Count);
        }

        [TestMethod]
        public void GetList_CreateDefault()
        {
            var _xmlContext = new XmlContext(testFilePath, directionsPath);
            var _testRepo = _xmlContext.AlifbaRepository;
            var _repoYanalif = _testRepo.GetYanalif();
            Assert.IsNotNull(_repoYanalif);

            var _yanalif = DefaultConfiguration.Yanalif;
            Assert.AreNotEqual(0, _yanalif.CustomSymbols.Count);
            Assert.AreEqual(_yanalif.CustomSymbols.Count, _repoYanalif.CustomSymbols.Count);

            var _list = _testRepo.GetList();
            Assert.AreEqual(DefaultConfiguration.BuiltInAlifbaList.Count, _list.Count);
        }

        [TestMethod]
        public void Get()
        {
            File.Copy(preparedFile, testFilePath);

            var _xmlContext = new XmlContext(testFilePath, directionsPath);
            var _testRepo = _xmlContext.AlifbaRepository;
            var _alifba = _testRepo.Get(1025);
            Assert.IsNotNull(_alifba);
        }

        [TestMethod]
        public void Get_CreateDefault()
        {
            var _xmlContext = new XmlContext(testFilePath, directionsPath);
            var _testRepo = _xmlContext.AlifbaRepository;
            var _alifba = _testRepo.Get(0); //Cyrillic
            Assert.IsNotNull(_alifba);
        }

        [TestMethod]
        public void Update()
        {
            File.Copy(preparedFile, testFilePath);

            var _xmlContext = new XmlContext(testFilePath, directionsPath);
            var _testRepo = _xmlContext.AlifbaRepository;
            var _alifba = _testRepo.Get(1025);
            var _name2 = "Test name " + Guid.NewGuid();
            var _symbolText2 = Guid.NewGuid().ToString();
            var _symbolText3 = Guid.NewGuid().ToString();
            _alifba.FriendlyName = _name2;
            _alifba.RightToLeft = true;
            _alifba.DefaultFont = new AlifbaFont("Courier New", 24);
            _alifba.CustomSymbols[0].ActualText = _symbolText2;
            _alifba.CustomSymbols.Add(new AlifbaSymbol(_symbolText3));
            _testRepo.Update(_alifba);
            _xmlContext.SaveChanges();

            var _checkContext = new XmlContext(testFilePath, directionsPath);
            var _checkRepo = _checkContext.AlifbaRepository;
            var _checkAlifba = _checkRepo.Get(1025);
            Assert.IsNotNull(_checkAlifba);
            Assert.AreEqual(_checkAlifba.FriendlyName, _name2);
            Assert.IsTrue(_checkAlifba.RightToLeft);
            using (var _font = (Font)_checkAlifba.DefaultFont)
            {
                Assert.AreEqual("Courier New", _font.OriginalFontName);
                Assert.AreEqual(24, _font.Size);
            }
            Assert.AreEqual(2, _checkAlifba.CustomSymbols.Count);
            Assert.AreEqual(_symbolText2, _checkAlifba.CustomSymbols[0].ActualText);
            Assert.AreEqual(_symbolText3, _checkAlifba.CustomSymbols[1].ActualText);
        }

        [TestMethod]
        public void Update_CreateDefault()
        {
            var _xmlContext = new XmlContext(testFilePath, directionsPath);
            var _testRepo = _xmlContext.AlifbaRepository;
            var _name = "Test alifba " + Guid.NewGuid();
            var _alifba = new Alifba(0, _name);
            _testRepo.Update(_alifba);
            _xmlContext.SaveChanges();
            var _list = _testRepo.GetList();
            Assert.AreEqual(DefaultConfiguration.BuiltInAlifbaList.Count, _list.Count);
        }

        [TestMethod]
        public void Delete()
        {
            File.Copy(preparedFile, testFilePath);

            var _xmlContext = new XmlContext(testFilePath, directionsPath);
            var _testRepo = _xmlContext.AlifbaRepository;
            var _testAlifba = _testRepo.Get(1025);
            Assert.IsNotNull(_testAlifba);
            _testRepo.Delete(_testAlifba.ID);
            _xmlContext.SaveChanges();

            var _checkContext = new XmlContext(testFilePath, directionsPath);
            var _checkRepo = _checkContext.AlifbaRepository;
            var _checkAlifba = _checkRepo.Get(1025);
            Assert.IsNull(_checkAlifba);
        }

        [TestMethod]
        public void Delete_CreateDefault()
        {
            File.Copy(dataFolder + @"Prepared\DirectionNoCyr.xml", directionsPath);

            var _xmlContext = new XmlContext(testFilePath, directionsPath);
            var _testRepo = _xmlContext.AlifbaRepository;
            var _name = "Test alifba " + Guid.NewGuid();
            var _alifba = new Alifba(0, _name);
            _testRepo.Delete(_alifba.ID);
            _xmlContext.SaveChanges();
            //todo re-read from file
            var _list = _testRepo.GetList();
            Assert.AreEqual(DefaultConfiguration.BuiltInAlifbaList.Count - 1, _list.Count);
        }

        [TestMethod]
        public void Delete_InUse()
        {
            var _xmlContext = new XmlContext(testFilePath, directionsPath);
            var _testRepo = _xmlContext.AlifbaRepository;
            var _testAlifba = _testRepo.Get(0); //Cyrillic
            try
            {
                _testRepo.Delete(_testAlifba.ID);
                Assert.Fail("Shouldn't have deleted");
            }
            catch (Exception ex)
            {
                Assert.AreEqual("Cannot delete alphabet in use.", ex.Message);
            }            
        }

        [TestMethod]
        public void Delete_Yanalif()
        {
            var _xmlContext = new XmlContext(testFilePath, directionsPath);
            var _testRepo = _xmlContext.AlifbaRepository;
            var _yanalif = _testRepo.GetYanalif();
            Assert.IsNotNull(_yanalif);
            try
            {
                _testRepo.Delete(_yanalif.ID);
                Assert.Fail("Shouldn't have deleted");
            }
            catch (Exception ex)
            {
                Assert.AreEqual("Cannot delete Yanalif.", ex.Message);
            }
        }

        //no longer relevant
       /* [TestMethod]
        public void GenerateAlifbaID()
        {
            var _xmlContext = new XmlContext(testFilePath, directionsPath);
            var _testRepo = _xmlContext.AlifbaRepository;
            var _name1 = "Test alifba " + Guid.NewGuid();
            var _name2 = "Test alifba " + Guid.NewGuid();
            var _alifba1 = new Alifba(-1, _name1);
            _testRepo.Insert(_alifba1);
            var _alifba2 = new Alifba(-1, _name2);
            _testRepo.Insert(_alifba2);
            Assert.AreEqual(DefaultConfiguration.BuiltInAlifbaList.Count, _alifba1.ID);
            Assert.AreEqual(DefaultConfiguration.BuiltInAlifbaList.Count + 1, _alifba2.ID);
        }*/

        [TestMethod]
        public void CreateYanalif()
        {
            File.Copy(corruptedFile, testFilePath);

            var _xmlContext = new XmlContext(testFilePath, directionsPath);
            var _testRepo = _xmlContext.AlifbaRepository;
            var _newYanalif = _testRepo.GetYanalif();
            var _builtIn = DefaultConfiguration.BuiltInAlifbaList.Find(_item => _item.ID == BuiltInAlifbaType.Yanalif);
            Assert.IsNotNull(_newYanalif);
            Assert.AreNotEqual(0, _builtIn.CustomSymbols.Count);
            Assert.AreEqual(_builtIn.CustomSymbols.Count, _newYanalif.CustomSymbols.Count);
        }

        [TestMethod]
        public void InvalidConfig()
        {
            var _invalidFile = dataFolder + @"corrupted\InvalidAlphabets.xml";
            File.Copy(_invalidFile, testFilePath);

            var _xmlContext = new XmlContext(testFilePath, directionsPath);
            var _testRepo = _xmlContext.AlifbaRepository;
            var _list = _testRepo.GetList();

            Assert.AreEqual(DefaultConfiguration.BuiltInAlifbaList.Count, _list.Count);
        }
    }
}
