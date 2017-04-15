using System;
using System.IO;
using System.Linq;
using Bitig.Data.Storage;
using Bitig.Logic.Model;
using Bitig.Logic.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BitigDataTests
{
    [TestClass]
    public class InMemoryRepoTests
    {
        private const string dataFolder = @"..\..\..\BitigDataTests\TestData\";
        private readonly string testAlifbaPath = dataFolder + "Alphabets.xml";
        private readonly string testDirectionPath = dataFolder + "Directions.xml";
        private readonly string preparedFile = dataFolder + @"Prepared\Alifba1025.xml";

        [TestInitialize]
        [TestCleanup]
        public void DeleteTestFile()
        {
            if (File.Exists(testAlifbaPath))
                File.Delete(testAlifbaPath);
            if (File.Exists(testDirectionPath))
                File.Delete(testDirectionPath);
        }
        

        [TestMethod]
        public void Update_New()
        {
            var _xmlRepo = new XmlAlifbaRepository(testAlifbaPath);
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
            File.Copy(preparedFile, testAlifbaPath);
            var _xmlRepo = new XmlAlifbaRepository(testAlifbaPath);
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
            var _xmlRepo = new XmlAlifbaRepository(testAlifbaPath);
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
        public void Insert_AssignID()
        {
            var _xmlRepo = new XmlAlifbaRepository(testAlifbaPath);
            var _testRepo = new InMemoryRepository<Alifba, int>(_xmlRepo);
            var _name = "Test name " + Guid.NewGuid();
            var _newItem = new Alifba(-1, _name);
            _testRepo.Insert(_newItem);
            var _name2 = "Test name " + Guid.NewGuid();
            var _newItem2 = new Alifba(-1, _name2);
            _testRepo.Insert(_newItem2);
            var _id = _newItem2.ID;
            Assert.AreNotEqual(-1, _id);
            _testRepo.Delete(_newItem);
            _testRepo.SaveChanges();

            var _persistentList = _xmlRepo.GetList();
            var _saved = _persistentList.Find(_item => _item.FriendlyName == _name2);
            Assert.IsNotNull(_saved);
            Assert.AreEqual(_id, _saved.ID);
        }

        [TestMethod]
        public void Insert_Two()
        {
            var _xmlRepo = new XmlAlifbaRepository(testAlifbaPath);
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
            File.Copy(preparedFile, testAlifbaPath);
            var _xmlRepo = new XmlAlifbaRepository(testAlifbaPath);
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
            var _xmlRepo = new XmlAlifbaRepository(testAlifbaPath);
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

        [TestMethod]
        public void Delete_InUse()
        {
            var _alifbaRepo = new XmlAlifbaRepository(testAlifbaPath);
            var _directionRepo = new XmlDirectionRepository(testDirectionPath);
            var _repoProvider = new InMemoryRepoProvider(_alifbaRepo, _directionRepo);
            var _alifbaInMemory = _repoProvider.AlifbaRepository;
            var _directionInMemory = _repoProvider.DirectionRepository;
            var _name1 = "Test name " + Guid.NewGuid();
            var _newAlif1 = new Alifba(-1, _name1);
            _alifbaInMemory.Insert(_newAlif1);
            var _name2 = "Test name " + Guid.NewGuid();
            var _newAlif2 = new Alifba(-1, _name2);
            _alifbaInMemory.Insert(_newAlif2);
            var _assembly = "Assembly " + Guid.NewGuid();
            var _newDir = new Direction(-1, _newAlif1, _newAlif2, null, _assembly);
            _directionInMemory.Insert(_newDir);
            try
            {
                _alifbaInMemory.Delete(_newAlif1);
                Assert.Fail("Shouldn't have deleted");
            }
            catch (Exception ex)
            {
                Assert.AreEqual("Cannot delete alphabet in use.", ex.Message);
            }
        }

        [TestMethod]
        public void DirectionWithNewAlphabets()
        {
            var _alifbaRepo= new XmlAlifbaRepository(testAlifbaPath);
            var _directionRepo = new XmlDirectionRepository(testDirectionPath);
            var _repoProvider = new RepositoryProvider(_alifbaRepo, _directionRepo);
            var _alifbaInMemory = new InMemoryRepository<Alifba, int>(_repoProvider.AlifbaRepository);
            var _directionInMemory = new InMemoryRepository<Direction, int>(_repoProvider.DirectionRepository);
            var _name1 = "Test name " + Guid.NewGuid();
            var _newAlif1 = new Alifba(-1, _name1);
            _alifbaInMemory.Insert(_newAlif1);
            var _name2 = "Test name " + Guid.NewGuid();
            var _newAlif2 = new Alifba(-1, _name2);
            _alifbaInMemory.Insert(_newAlif2);
            var _assembly = "Assembly " + Guid.NewGuid();
            var _newDir = new Direction(-1, _newAlif1, _newAlif2, null, _assembly);
            _directionInMemory.Insert(_newDir);
            _alifbaInMemory.SaveChanges();
            _directionInMemory.SaveChanges();

            var _alifbaSaved = _alifbaRepo.GetList();
            var _alif1 = _alifbaSaved.Find(_alif => _alif.FriendlyName == _name1);
            var _alif2 = _alifbaSaved.Find(_alif => _alif.FriendlyName == _name2);
            var _directionSaved = _directionRepo.GetList();
            var _direction = _directionSaved.Find(_dir =>
              _dir.Source.ID == _alif1.ID && _dir.Target.ID == _alif2.ID
              && _dir.AssemblyPath == _assembly);
            Assert.IsNotNull(_direction);
        }

        [TestMethod]
        public void Initialization()
        {
            var _xmlAlifRepo = new XmlAlifbaRepository(testAlifbaPath);
            var _xmlDirRepo = new XmlDirectionRepository(testDirectionPath);
            var _configRepoProvider = new InMemoryRepoProvider(_xmlAlifRepo, _xmlDirRepo);
            var _configAlifbaRepository = _configRepoProvider.AlifbaRepository;
            var _configDirectionRepository = _configRepoProvider.DirectionRepository;
            var _dirList = _configDirectionRepository.GetList();
            Assert.AreEqual(DefaultConfiguration.BuiltInDirections.Count, _dirList.Count);
            var _alifList = _configAlifbaRepository.GetList();
            Assert.AreEqual(DefaultConfiguration.BuiltInAlifbaList.Count, _alifList.Count);
            Assert.IsTrue(_alifList.All(_alif => DefaultConfiguration.BuiltInAlifbaList.Any(_b => _b.ID == _alif.BuiltIn)));
        }
    }
}