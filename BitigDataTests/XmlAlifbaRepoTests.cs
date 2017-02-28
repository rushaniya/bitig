using System;
using System.Text;
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

        private readonly string testFilePath = @"..\..\TestData\Alphabets.xml";

        [TestInitialize]
        [TestCleanup]
        public void DeleteTestFile()
        {
            File.Delete(testFilePath);
        }

        [TestMethod]
        public void Insert()
        {
            var _testRepo = new XmlAlifbaRepository(testFilePath);
            var _name = "Test alifba " + Guid.NewGuid();
            var _symbolText = Guid.NewGuid().ToString();
            var _symbolDisplayText = Guid.NewGuid().ToString();
            var _symbols = new List<AlifbaSymbol>
            {
                new AlifbaSymbol(_symbolText, _symbolDisplayText)
            };
            var _alifba = new Alifba(-1, _name, _symbols, true, new AlifbaFont("Arial", 16));
            _testRepo.Insert(_alifba);
            _testRepo.SaveChanges();

            var _checkRepo = new XmlAlifbaRepository(testFilePath);
            var _list = _checkRepo.GetList();
            Assert.IsTrue(_list.Count > 0);
            var _inserted = _list.Find(_item => _item.FriendlyName == _name);
            Assert.IsNotNull(_inserted);
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
            var _testRepo = new XmlAlifbaRepository(testFilePath);
            var _name1 = "Test alifba " + Guid.NewGuid();
            var _name2 = "Test alifba " + Guid.NewGuid();
            var _id = -1;
            var _alifba1 = new Alifba(_id, _name1);
            _testRepo.Insert(_alifba1);
            var _alifba2 = new Alifba(_id, _name2);
                _testRepo.Insert(_alifba2);
            Assert.AreNotEqual(-1, _alifba1.ID);
            Assert.AreNotEqual(-1, _alifba2.ID);
            Assert.AreEqual(DefaultConfiguration.MIN_CUSTOM_ID, _alifba1.ID);
            Assert.AreEqual(DefaultConfiguration.MIN_CUSTOM_ID + 1, _alifba2.ID);
        }

        [TestMethod]
        public void GetList_BuiltIn()
        {
            var _testRepo = new XmlAlifbaRepository(testFilePath);
            Assert.IsNotNull(_testRepo.Yanalif);

            var _yanalif = DefaultConfiguration.Yanalif;
            Assert.AreNotEqual(0, _yanalif.CustomSymbols.Count);
            Assert.AreEqual(_yanalif.CustomSymbols.Count, _testRepo.Yanalif.CustomSymbols.Count);

            var _list = _testRepo.GetList();
            Assert.AreEqual(DefaultConfiguration.BuiltInAlifbaList.Count, _list.Count);
        }

        [TestMethod]
        public void Update()
        {
            var _preparedFile = @"..\..\TestData\Prepared\1025.xml";
            File.Copy(_preparedFile, testFilePath);

            var _testRepo = new XmlAlifbaRepository(testFilePath);
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
            _testRepo.SaveChanges();

            var _checkRepo = new XmlAlifbaRepository(testFilePath);
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
        public void Delete()
        {
            var _preparedFile = @"..\..\TestData\Prepared\1025.xml";
            File.Copy(_preparedFile, testFilePath);

            var _testRepo = new XmlAlifbaRepository(testFilePath);
            var _testAlifba = _testRepo.Get(1025);
            Assert.IsNotNull(_testAlifba);
            _testRepo.Delete(_testAlifba);
            _testRepo.SaveChanges();

            var _checkRepo = new XmlAlifbaRepository(testFilePath);
            var _checkAlifba = _checkRepo.Get(1025);
            Assert.IsNull(_checkAlifba);
        }

        [TestMethod]
        public void GenerateAlifbaID()
        {
            var _testRepo = new XmlAlifbaRepository(testFilePath);
            var _name1 = "Test alifba " + Guid.NewGuid();
            var _name2 = "Test alifba " + Guid.NewGuid();
            var _alifba1 = new Alifba(-1, _name1);
            _testRepo.Insert(_alifba1);
            var _alifba2 = new Alifba(-1, _name2);
            _testRepo.Insert(_alifba2);
            Assert.AreEqual(DefaultConfiguration.MIN_CUSTOM_ID, _alifba1.ID);
            Assert.AreEqual(DefaultConfiguration.MIN_CUSTOM_ID + 1, _alifba2.ID);
        }

        [TestMethod]
        public void CreateYanalif()
        {
            File.Copy(@"..\..\TestData\Corrupted\NoYanalif.xml", testFilePath);

            var _testRepo = new XmlAlifbaRepository(testFilePath);
            var _newYanalif = _testRepo.Yanalif;
            var _builtIn = DefaultConfiguration.BuiltInAlifbaList.Find(_item => _item.IsYanalif);
            Assert.IsNotNull(_newYanalif);
            Assert.AreNotEqual(0, _builtIn.CustomSymbols.Count);
            Assert.AreEqual(_builtIn.CustomSymbols.Count, _newYanalif.CustomSymbols.Count);
        }
    }
}
