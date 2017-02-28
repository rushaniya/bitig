using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using Bitig.Data.Storage;
using Bitig.Logic.Model;
using Bitig.Logic.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BitigDataTests
{
    [TestClass]
    public class InMemoryRepoTests
    {
        private readonly string testFilePath = @"..\..\TestData\Alphabets.xml";

        [TestInitialize]
        [TestCleanup]
        public void DeleteTestFile()
        {
            File.Delete(testFilePath);
        }
        

        [TestMethod]
        public void Update_New()
        {
            var _xmlRepo = new XmlAlifbaRepository(testFilePath);
            var _testRepo = new InMemoryRepository<Alifba, int>(_xmlRepo);
            var _name1 = "Test name " + Guid.NewGuid();
            var _newItem = new Alifba(-1, _name1);
            _testRepo.Insert(_newItem);
            var _name2 = "New name " + Guid.NewGuid();
            _newItem.FriendlyName = _name2;
            _testRepo.Update(_newItem);
            _testRepo.SaveChanges();
            var _saved = _xmlRepo.GetList().Find(_item => _item.FriendlyName == _name2);
            Assert.IsNotNull(_saved);
        }
        

        [TestMethod]
        public void Update()
        {
            var _preparedFile = @"..\..\TestData\Prepared\1025.xml";
            File.Copy(_preparedFile, testFilePath);
            var _xmlRepo = new XmlAlifbaRepository(testFilePath);
            var _testRepo = new InMemoryRepository<Alifba, int>(_xmlRepo);
            var _alifba = _testRepo.Get(1025);
            var _oldname = _alifba.FriendlyName;
            Assert.IsNotNull(_alifba);
            var _newName = "New name " + Guid.NewGuid();
            _alifba.FriendlyName = _newName;
            var _inMemory = _testRepo.Get(1025);
            Assert.AreEqual(_oldname, _inMemory.FriendlyName);
            var _persistent = _xmlRepo.Get(1025);
            Assert.AreEqual(_oldname, _persistent.FriendlyName);
            _testRepo.Update(_alifba);
            _inMemory = _testRepo.Get(1025);
            Assert.AreEqual(_newName, _inMemory.FriendlyName);
            _persistent = _xmlRepo.Get(1025);
            Assert.AreEqual(_oldname, _persistent.FriendlyName);
            _testRepo.SaveChanges();
            _inMemory = _testRepo.Get(1025);
            Assert.AreEqual(_newName, _inMemory.FriendlyName);
            _persistent = _xmlRepo.Get(1025);
            Assert.AreEqual(_newName, _persistent.FriendlyName);
        }

        [TestMethod]
        public void Insert()
        {
            var _xmlRepo = new XmlAlifbaRepository(testFilePath);
            var _testRepo = new InMemoryRepository<Alifba, int>(_xmlRepo);
            var _name = "Test name " + Guid.NewGuid();
            var _newItem = new Alifba(-1, _name);
            _testRepo.Insert(_newItem);

            var _inMemoryList = _testRepo.GetList();
            var _persistentList = _xmlRepo.GetList();
            var _added = _inMemoryList.Find(_item => _item.FriendlyName == _name);
            Assert.IsNotNull(_added);
            var _saved = _persistentList.Find(_item => _item.FriendlyName == _name);
            Assert.IsNull(_saved);
            _testRepo.SaveChanges();
            _persistentList = _xmlRepo.GetList();
            _saved = _persistentList.Find(_item => _item.FriendlyName == _name);
            Assert.IsNotNull(_saved);
            Assert.AreNotEqual(-1, _saved.ID);
        }

        [TestMethod]
        public void Insert_Two()
        {
            var _xmlRepo = new XmlAlifbaRepository(testFilePath);
            var _testRepo = new InMemoryRepository<Alifba, int>(_xmlRepo);
            var _name1 = "Test name " + Guid.NewGuid();
            var _newItem1 = new Alifba(-1, _name1);
            _testRepo.Insert(_newItem1);
            var _name2 = "Test name " + Guid.NewGuid();
            var _newItem2 = new Alifba(-1, _name2);
            _testRepo.Insert(_newItem2);
            Assert.AreNotEqual(_newItem1, _newItem2);
            Assert.AreNotEqual(-1, _newItem1);
            Assert.AreNotEqual(-1, _newItem2);
            Assert.AreNotEqual(_newItem1.ID, _newItem2.ID);

            _testRepo.SaveChanges();
            var _saved1 = _xmlRepo.GetList().Find(_item => _item.FriendlyName == _name1);
            var _saved2 = _xmlRepo.GetList().Find(_item => _item.FriendlyName == _name2);
            Assert.IsNotNull(_saved1);
            Assert.IsNotNull(_saved2);
            Assert.AreNotEqual(_saved1.ID, _saved2.ID);
        }

        [TestMethod]
        public void Delete()
        {
            var _preparedFile = @"..\..\TestData\Prepared\1025.xml";
            File.Copy(_preparedFile, testFilePath);
            var _xmlRepo = new XmlAlifbaRepository(testFilePath);
            var _testRepo = new InMemoryRepository<Alifba, int>(_xmlRepo);
            var _alifba = _testRepo.Get(1025);
            _testRepo.Delete(_alifba);
            var _persistent = _xmlRepo.Get(1025);
            Assert.IsNotNull(_persistent);
            _testRepo.SaveChanges();
            _persistent = _xmlRepo.Get(1025);
            Assert.IsNull(_persistent);
        }

        [TestMethod]
        public void Delete_New()
        {
            var _xmlRepo = new XmlAlifbaRepository(testFilePath);
            var _initialCount = _xmlRepo.GetList().Count;
            var _testRepo = new InMemoryRepository<Alifba, int>(_xmlRepo);
            var _name = "Test name " + Guid.NewGuid();
            var _newItem = new Alifba(-1, _name);
            _testRepo.Insert(_newItem);
            _testRepo.Delete(_newItem);
            _testRepo.SaveChanges();
            var _persistentList = _xmlRepo.GetList();
            Assert.AreEqual(_initialCount, _persistentList.Count);
            var _deleted = _persistentList.Find(_item => _item.FriendlyName == _name);
            Assert.IsNull(_deleted);
        }
    }
}
