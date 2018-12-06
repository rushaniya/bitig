using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Bitig.Data.Storage;
using Bitig.Logic.Model;
using Bitig.Logic.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BitigDataTests
{
    [TestClass]
    public class XmlContextTests
    {
        private const string dataFolder = @"TestData\";
        private readonly string testAlifbaPath = dataFolder + "Alphabets.xml";
        private readonly string testDirectionPath = dataFolder + "Directions.xml";
        private readonly string preparedAlifbaFile = dataFolder + @"Prepared\Alifba1025.xml";
        private readonly string preparedDirectionFile = dataFolder + @"Prepared\Direction777.xml";

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
            var _xmlContext = new XmlContext(testAlifbaPath, testDirectionPath);
            var _alifbaRepo = _xmlContext.AlifbaRepository;
            var _name1 = "Test name " + Guid.NewGuid();
            var _newItem = new Alifba(-1, _name1);
            _alifbaRepo.Insert(_newItem);
            var _name2 = "New name " + Guid.NewGuid();
            _newItem.FriendlyName = _name2;
            _alifbaRepo.Update(_newItem);
            _xmlContext.SaveChanges();
            var _saved = _alifbaRepo.GetList().Find(_item => _item.FriendlyName == _name2);
            Assert.IsNotNull(_saved);
        }


        [TestMethod]
        public void Update()
        {
            File.Copy(preparedAlifbaFile, testAlifbaPath);
            var _xmlContext = new XmlContext(testAlifbaPath, testDirectionPath);
            var _alifbaRepo = _xmlContext.AlifbaRepository;
            var _alifba = _alifbaRepo.Get(1025);
            var _oldname = _alifba.FriendlyName;
            Assert.IsNotNull(_alifba);
            var _newName = "New name " + Guid.NewGuid();
            _alifba.FriendlyName = _newName;
            var _inMemory = _alifbaRepo.Get(1025);
            Assert.AreEqual(_oldname, _inMemory.FriendlyName);
            _alifbaRepo.Update(_alifba);
            _inMemory = _alifbaRepo.Get(1025);
            Assert.AreEqual(_newName, _inMemory.FriendlyName);
            //not written to file until SaveChanges is called
            var _staleRepo = new XmlContext(testAlifbaPath, testDirectionPath).AlifbaRepository;
            var _persistent = _staleRepo.Get(1025);
            Assert.AreEqual(_oldname, _persistent.FriendlyName);
            _xmlContext.SaveChanges();
            _inMemory = _alifbaRepo.Get(1025);
            Assert.AreEqual(_newName, _inMemory.FriendlyName);
            _staleRepo = new XmlContext(testAlifbaPath, testDirectionPath).AlifbaRepository;
            _persistent = _staleRepo.Get(1025);
            Assert.AreEqual(_newName, _persistent.FriendlyName);
        }

        [TestMethod]
        public void Insert()
        {
            var _xmlContext = new XmlContext(testAlifbaPath, testDirectionPath);
            var _alifbaRepo = _xmlContext.AlifbaRepository;
            var _name = "Test name " + Guid.NewGuid();
            var _newItem = new Alifba(-1, _name);
            _alifbaRepo.Insert(_newItem);
            var _inMemoryList = _alifbaRepo.GetList();
            var _added = _inMemoryList.Find(_item => _item.FriendlyName == _name);
            Assert.IsNotNull(_added);
            //not written to file until SaveChanges is called
            var _staleRepo = new XmlContext(testAlifbaPath, testDirectionPath).AlifbaRepository;
            var _persistent = _staleRepo.GetList().Find(_item => _item.FriendlyName == _name);
            Assert.IsNull(_persistent);
            _xmlContext.SaveChanges();
            _staleRepo = new XmlContext(testAlifbaPath, testDirectionPath).AlifbaRepository;
            _persistent = _staleRepo.GetList().Find(_item => _item.FriendlyName == _name);
            Assert.IsNotNull(_persistent);
            Assert.AreNotEqual(-1, _persistent.ID);
        }

        [TestMethod]
        public void Insert_SameAlphabets()
        {
            var _xmlContext = new XmlContext(testAlifbaPath, testDirectionPath);
            var _alifbaRepo = _xmlContext.AlifbaRepository;
            var _directionRepo = _xmlContext.DirectionRepository;
            var _name1 = "Test name " + Guid.NewGuid();
            var _newAlif1 = new Alifba(-1, _name1);
            _alifbaRepo.Insert(_newAlif1);
            var _name2 = "Test name " + Guid.NewGuid();
            var _newAlif2 = new Alifba(-1, _name2);
            _alifbaRepo.Insert(_newAlif2);
            var _assembly = "Assembly " + Guid.NewGuid();
            var _newDir = new Direction(-1, _newAlif1, _newAlif2, null, _assembly);
            _directionRepo.Insert(_newDir);
            var _newDirSameAlphabets = new Direction(-1, _newAlif1, _newAlif2, null, _assembly);
            try
            {
                _directionRepo.Insert(_newDirSameAlphabets);
                Assert.Fail("Shouldn't have inserted");
            }
            catch (Exception ex)
            {
                Assert.AreEqual("Direction with same source and target exists.", ex.Message);
            }
        }

        [TestMethod]
        public void Insert_Replace()
        {
            var _xmlContext = new XmlContext(testAlifbaPath, testDirectionPath);
            var _alifbaRepo = _xmlContext.AlifbaRepository;
            var _directionRepo = _xmlContext.DirectionRepository;
            var _name1 = "Test name " + Guid.NewGuid();
            var _newAlif1 = new Alifba(-1, _name1);
            _alifbaRepo.Insert(_newAlif1);
            var _name2 = "Test name " + Guid.NewGuid();
            var _newAlif2 = new Alifba(-1, _name2);
            _alifbaRepo.Insert(_newAlif2);
            var _assembly = "Assembly " + Guid.NewGuid();
            var _newDir = new Direction(-1, _newAlif1, _newAlif2, null, _assembly);
            _directionRepo.Insert(_newDir);
            var _newDirSameAlphabets = new Direction(-1, _newAlif1, _newAlif2, null, _assembly);
            _directionRepo.Delete(_newDir.ID);
            _directionRepo.Insert(_newDirSameAlphabets);
        }

        [TestMethod]
        public void Insert_AssignID()
        {
            var _xmlContext = new XmlContext(testAlifbaPath, testDirectionPath);
            var _alifbaRepo = _xmlContext.AlifbaRepository;
            var _name = "Test name " + Guid.NewGuid();
            var _newItem = new Alifba(-1, _name);
            _alifbaRepo.Insert(_newItem);
            var _name2 = "Test name " + Guid.NewGuid();
            var _newItem2 = new Alifba(-1, _name2);
            _alifbaRepo.Insert(_newItem2);
            Assert.AreNotEqual(-1, _newItem2.ID);
            _alifbaRepo.Delete(_newItem.ID);
            _xmlContext.SaveChanges();

            var _staleRepo = new XmlContext(testAlifbaPath, testDirectionPath).AlifbaRepository;
            var _persistent = _staleRepo.GetList().Find(_item => _item.FriendlyName == _name2);
            Assert.IsNotNull(_persistent);
            Assert.AreNotEqual(-1, _persistent.ID);
        }

        [TestMethod]
        public void Insert_Two()
        {
            var _xmlContext = new XmlContext(testAlifbaPath, testDirectionPath);
            var _alifbaRepo = _xmlContext.AlifbaRepository;
            var _name1 = "Test name " + Guid.NewGuid();
            var _newItem1 = new Alifba(-1, _name1);
            _alifbaRepo.Insert(_newItem1);
            var _name2 = "Test name " + Guid.NewGuid();
            var _newItem2 = new Alifba(-1, _name2);
            _alifbaRepo.Insert(_newItem2);
            Assert.AreNotEqual(-1, _newItem1.ID);
            Assert.AreNotEqual(-1, _newItem2.ID);
            Assert.AreNotEqual(_newItem1.ID, _newItem2.ID);

            _xmlContext.SaveChanges();
            var _staleRepo = new XmlContext(testAlifbaPath, testDirectionPath).AlifbaRepository;
            var _saved1 = _staleRepo.GetList().Find(_item => _item.FriendlyName == _name1);
            var _saved2 = _staleRepo.GetList().Find(_item => _item.FriendlyName == _name2);
            Assert.IsNotNull(_saved1);
            Assert.IsNotNull(_saved2);
            Assert.AreNotEqual(_saved1.ID, _saved2.ID);
        }

        [TestMethod]
        public void Delete()
        {
            File.Copy(preparedAlifbaFile, testAlifbaPath);
            var _xmlContext = new XmlContext(testAlifbaPath, testDirectionPath);
            var _alifbaRepo = _xmlContext.AlifbaRepository;
            var _alifba = _alifbaRepo.Get(1025);
            _alifbaRepo.Delete(_alifba.ID);
            var _staleRepo = new XmlContext(testAlifbaPath, testDirectionPath).AlifbaRepository;
            var _persistent = _staleRepo.Get(1025);
            Assert.IsNotNull(_persistent);
            _xmlContext.SaveChanges();
            _staleRepo = new XmlContext(testAlifbaPath, testDirectionPath).AlifbaRepository;
            _persistent = _staleRepo.Get(1025);
            Assert.IsNull(_persistent);
        }

        [TestMethod]
        public void Delete_New()
        {
            var _xmlContext = new XmlContext(testAlifbaPath, testDirectionPath);
            var _alifbaRepo = _xmlContext.AlifbaRepository;
            var _initialCount = _alifbaRepo.GetList().Count;
            var _name = "Test name " + Guid.NewGuid();
            var _newItem = new Alifba(-1, _name);
            _alifbaRepo.Insert(_newItem);
            _alifbaRepo.Delete(_newItem.ID);
            _xmlContext.SaveChanges();
            var _staleRepo = new XmlContext(testAlifbaPath, testDirectionPath).AlifbaRepository;
            var _persistentList = _staleRepo.GetList();
            Assert.AreEqual(_initialCount, _persistentList.Count);
            var _deleted = _persistentList.Find(_item => _item.FriendlyName == _name);
            Assert.IsNull(_deleted);
        }

        [TestMethod]
        public void Delete_InUse()
        {
            var _xmlContext = new XmlContext(testAlifbaPath, testDirectionPath);
            var _alifbaRepo = _xmlContext.AlifbaRepository;
            var _directionRepo = _xmlContext.DirectionRepository;
            var _name1 = "Test name " + Guid.NewGuid();
            var _newAlif1 = new Alifba(-1, _name1);
            _alifbaRepo.Insert(_newAlif1);
            var _name2 = "Test name " + Guid.NewGuid();
            var _newAlif2 = new Alifba(-1, _name2);
            _alifbaRepo.Insert(_newAlif2);
            var _assembly = "Assembly " + Guid.NewGuid();
            var _newDir = new Direction(-1, _newAlif1, _newAlif2, null, _assembly);
            _directionRepo.Insert(_newDir);
            try
            {
                _alifbaRepo.Delete(_newAlif1.ID);
                Assert.Fail("Shouldn't have deleted");
            }
            catch (Exception ex)
            {
                Assert.AreEqual("Cannot delete alphabet in use.", ex.Message);
            }
        }

        [TestMethod]
        public void Delete_NoMoreInUse()
        {
            var _xmlContext = new XmlContext(testAlifbaPath, testDirectionPath);
            var _alifbaRepo = _xmlContext.AlifbaRepository;
            var _directionRepo = _xmlContext.DirectionRepository;
            var _directions = _directionRepo.GetList();
            foreach (var _dir in _directions)
            {
                if (_dir.Source.ID == 0 || _dir.Target.ID == 0)
                    _directionRepo.Delete(_dir.ID);
            }
            var _testAlifba = _alifbaRepo.Get(0);
            _alifbaRepo.Delete(_testAlifba.ID);
        }

        [TestMethod]
        public void DirectionWithNewAlphabets()
        {
            var _xmlContext = new XmlContext(testAlifbaPath, testDirectionPath);
            var _alifbaRepo = _xmlContext.AlifbaRepository;
            var _directionRepo = _xmlContext.DirectionRepository;
            var _name1 = "Test name " + Guid.NewGuid();
            var _newAlif1 = new Alifba(-1, _name1);
            _alifbaRepo.Insert(_newAlif1);
            var _name2 = "Test name " + Guid.NewGuid();
            var _newAlif2 = new Alifba(-1, _name2);
            _alifbaRepo.Insert(_newAlif2);
            var _assembly = "Assembly " + Guid.NewGuid();
            var _newDir = new Direction(-1, _newAlif1, _newAlif2, null, _assembly);
            _directionRepo.Insert(_newDir);
            _xmlContext.SaveChanges();

            var _staleContext = new XmlContext(testAlifbaPath, testDirectionPath);
            var _alifbaSaved = _staleContext.AlifbaRepository.GetList();
            var _alif1 = _alifbaSaved.Find(_alif => _alif.FriendlyName == _name1);
            var _alif2 = _alifbaSaved.Find(_alif => _alif.FriendlyName == _name2);
            var _directionSaved = _staleContext.DirectionRepository.GetList();
            var _direction = _directionSaved.Find(_dir =>
              _dir.Source.ID == _alif1.ID && _dir.Target.ID == _alif2.ID
              && _dir.AssemblyPath == _assembly);
            Assert.IsNotNull(_direction);
        }

        [TestMethod]
        public void Initialization()
        {
            var _xmlContext = new XmlContext(testAlifbaPath, testDirectionPath);
            var _alifbaRepo = _xmlContext.AlifbaRepository;
            var _directionRepo = _xmlContext.DirectionRepository;
            var _dirList = _directionRepo.GetList();
            Assert.AreEqual(DefaultConfiguration.BuiltInDirections.Count, _dirList.Count);
            var _alifList = _alifbaRepo.GetList();
            Assert.AreEqual(DefaultConfiguration.BuiltInAlifbaList.Count, _alifList.Count);
            Assert.IsTrue(_alifList.All(_alif => DefaultConfiguration.BuiltInAlifbaList.Any(_b => _b.ID == _alif.BuiltIn)));
        }

        [TestMethod]
        public void Initialization_FillList()
        {
            File.Copy(preparedDirectionFile, testDirectionPath);
            var _xmlContext = new XmlContext(testAlifbaPath, testDirectionPath);
            var _directionRepo = _xmlContext.DirectionRepository;
            var _dirList = _directionRepo.GetList();
            Assert.AreEqual(9, _dirList.Count);
        }

        [TestMethod]
        public void Get_AlifbaNameChanged()
        {
            var _xmlContext = new XmlContext(testAlifbaPath, testDirectionPath);
            var _alifbaRepo = _xmlContext.AlifbaRepository;
            var _directionRepo = _xmlContext.DirectionRepository;
            var _testAlifba = _alifbaRepo.Get(0);
            var _newName = "Alifba" + Guid.NewGuid();
            var _testDirection = _directionRepo.GetList().Find(_dir => _dir.Source.ID == 0);
            _testAlifba.FriendlyName = _newName;
            _alifbaRepo.Update(_testAlifba);
            _testDirection = _directionRepo.Get(_testDirection.ID);
            Assert.AreEqual(_newName, _testDirection.Source.FriendlyName);
        }

        [TestMethod]
        public void Update_AlphabetAndDirection()
        {
            var _xmlContext = new XmlContext(testAlifbaPath, testDirectionPath);
            var _alifbaRepo = _xmlContext.AlifbaRepository;
            var _directionRepo = _xmlContext.DirectionRepository;
            var _testAlifba = _alifbaRepo.Get(0);
            var _testDirection = _directionRepo.GetList().Find(_dir => _dir.Source.ID != 0);
            var _newName = "Alifba" + Guid.NewGuid();
            var _newPath = "Path" + Guid.NewGuid();
            _testAlifba.FriendlyName = _newName;
            _alifbaRepo.Update(_testAlifba);
            _testDirection.AssemblyPath = _newPath;
            _directionRepo.Update(_testDirection);
            var _updatedAlifba = _alifbaRepo.Get(_testAlifba.ID);
            Assert.AreEqual(_newName, _updatedAlifba.FriendlyName);
            var _updatedDirection = _directionRepo.Get(_testDirection.ID);
            Assert.AreEqual(_newPath, _updatedDirection.AssemblyPath);
        }

        [TestMethod]
        public void SaveChanges_Twice()
        {
            var _xmlContext = new XmlContext(testAlifbaPath, testDirectionPath);
            var _alifbaRepo = _xmlContext.AlifbaRepository;
            var _count = _alifbaRepo.GetList().Count;
            var _newAlif = new Alifba(-1, "Alifba1");
            _alifbaRepo.Insert(_newAlif);
            _xmlContext.SaveChanges();
            Assert.AreEqual(_count + 1, _alifbaRepo.GetList().Count);
            _xmlContext.SaveChanges();
            var _checkRepo = new XmlContext(testAlifbaPath, testDirectionPath).AlifbaRepository;
            Assert.AreEqual(_count + 1, _checkRepo.GetList().Count);
        }
    }
}
