using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using Bitig.Data.Storage;
using Bitig.Logic.Model;
using Bitig.Logic.Repository;
using System.Collections.Generic;

namespace BitigDataTests
{
    [TestClass]
    public class XmlDirectionRepoTests
    {
        public XmlDirectionRepoTests()
        {
        }

        private const string dataFolder = @"..\..\..\BitigDataTests\TestData\";
        private readonly string alifbaPath = dataFolder + "Alphabets.xml";
        private readonly string preparedFile = dataFolder + @"Prepared\Direction777.xml";
        private readonly string testFilePath = dataFolder + "Directions.xml";

        [TestInitialize]
        [TestCleanup]
        public void DeleteTestFile()
        {
            if (File.Exists(testFilePath))
                File.Delete(testFilePath);
            if (File.Exists(alifbaPath))
                File.Delete(alifbaPath);
        }

        [TestMethod]
        public void GetList()
        {
            File.Copy(preparedFile, testFilePath);
            var _alifbaRepo = new XmlAlifbaRepository(alifbaPath);
            var _testRepo = new XmlDirectionRepository(testFilePath, _alifbaRepo);
            var _list = _testRepo.GetList();
            Assert.AreEqual(9, _list.Count);
        }

        [TestMethod]
        public void GetList_CreateDefault()
        {
            var _alifbaRepo = new XmlAlifbaRepository(alifbaPath);
            var _testRepo = new BitigDirectionRepository(
                new XmlDirectionRepository(testFilePath, _alifbaRepo));
            var _builtInList = DefaultConfiguration.BuiltInDirections;
            Assert.AreNotEqual(0, _builtInList.Count);
            var _defaultList = _testRepo.GetList();
            foreach (var _item in _builtInList)
            {
                Assert.IsNotNull(_defaultList.Single(_dir => _item.Equals(_dir.BuiltIn)));
            }
        }

        [TestMethod]
        public void Get()
        {
            File.Copy(preparedFile, testFilePath);
            var _alifbaRepo = new BitigAlifbaRepository(new XmlAlifbaRepository(alifbaPath));
            var _testRepo = new XmlDirectionRepository(testFilePath, _alifbaRepo);
            var _direction777 = _testRepo.Get(777);
            Assert.IsNotNull(_direction777);
            Assert.IsNotNull(_direction777.Source);
            Assert.IsNotNull(_direction777.Target);

            var _direction778 = _testRepo.Get(778);
            Assert.IsNotNull(_direction778);
            Assert.IsNotNull(_direction778.Source);
            Assert.IsNotNull(_direction778.Target);
            Assert.IsNotNull(_direction778.BuiltIn);
        }

        [TestMethod]
        public void Get_CreateDefault()
        {
            var _alifbaRepo = new XmlAlifbaRepository(alifbaPath);
            var _xmlRepo = new XmlDirectionRepository(testFilePath, _alifbaRepo);
            var _testRepo = new BitigDirectionRepository(_xmlRepo);
            _testRepo.Get(0);

            var _count = _xmlRepo.GetList().Count;
            Assert.AreEqual(DefaultConfiguration.BuiltInDirections.Count, _count);
        }

        [TestMethod]
        public void Insert()
        {
            var _alifbaRepo = new BitigAlifbaRepository(new XmlAlifbaRepository(alifbaPath));
            var _testRepo = new BitigDirectionRepository(
                new XmlDirectionRepository(testFilePath, _alifbaRepo));
            var _source = new Alifba(1, "alifba1");
            var _target = new Alifba(0, "alifba2");
            var _assemblyName = "TestAssembly" + Guid.NewGuid();
            var _direction = new Direction(-1, _source, _target, _assemblyName, "TestType");
            _testRepo.Insert(_direction);
            var _insertedID = _direction.ID;
            _testRepo.SaveChanges();

            var _checkRepo = new XmlDirectionRepository(testFilePath, _alifbaRepo);
            var _list = _checkRepo.GetList();
            Assert.IsTrue(_list.Count > 0);
            var _inserted = _checkRepo.Get(_insertedID);
            Assert.IsNotNull(_inserted);
            Assert.AreNotEqual(-1, _inserted.ID);
            Assert.AreEqual(_source, _inserted.Source);
            Assert.AreEqual(_target, _inserted.Target);
            Assert.AreEqual(_assemblyName, _inserted.AssemblyPath);
            Assert.AreEqual("TestType", _inserted.TypeName);
        }

        [TestMethod]
        public void Insert_AssignID()
        {
            var _alifbaRepo = new BitigAlifbaRepository(new XmlAlifbaRepository(alifbaPath));
            var _testRepo = new BitigDirectionRepository(
                new XmlDirectionRepository(testFilePath, _alifbaRepo));
            var _source1 = new Alifba(1, "alifba1");
            var _target = new Alifba(0, "alifba2");
            var _source2 = new Alifba(2, "alifba3");
            const int _id = -1;
            var _dir1 = new Direction(_id, _source1, _target);
            _testRepo.Insert(_dir1);
            var _dir2 = new Direction(_id, _source2, _target);
            _testRepo.Insert(_dir2);
            Assert.AreNotEqual(-1, _dir1.ID);
            Assert.AreNotEqual(-1, _dir2.ID);

            var _list = _testRepo.GetList();
            Assert.IsNotNull(_list);
            foreach (var _direction in _list)
            {
                Assert.AreEqual(1, _list.Count(_dir => _dir.ID == _direction.ID));
            }
        }

        [TestMethod]
        public void Insert_CreateDefault()
        {
            var _alifbaRepo = new BitigAlifbaRepository(new XmlAlifbaRepository(alifbaPath));
            var _xmlRepo = new XmlDirectionRepository(testFilePath, _alifbaRepo);
            var _testRepo = new BitigDirectionRepository(_xmlRepo);
            var _source = new Alifba(1, "alifba1");
            var _target = new Alifba(0, "alifba2");
            var _assemblyName = "TestAssembly" + Guid.NewGuid();
            var _direction = new Direction(-1, _source, _target, _assemblyName, "TestType");
            _testRepo.Insert(_direction);
            _testRepo.SaveChanges();

            var _count = _xmlRepo.GetList().Count;
            Assert.AreEqual(DefaultConfiguration.BuiltInDirections.Count + 1, _count);
        }

        [TestMethod]
        public void Insert_SameAlifbaIDs()
        {
            var _alifbaRepo = new BitigAlifbaRepository(new XmlAlifbaRepository(alifbaPath));
            var _testRepo = new BitigDirectionRepository(
                new XmlDirectionRepository(testFilePath, _alifbaRepo));
            var _source = new Alifba(0, "alifba1");
            var _target = new Alifba(1, "alifba2");
            var _assemblyName = "TestAssembly" + Guid.NewGuid();
            var _direction = new Direction(-1, _source, _target, _assemblyName, "TestType");
            try
            {
                _testRepo.Insert(_direction);
                Assert.Fail("Shouldn't have inserted");
            }
            catch (Exception ex)
            {
                Assert.AreEqual("Direction with same source and target exists.", ex.Message);
            }            
        }

        [TestMethod]
        public void Update()
        {
            File.Copy(preparedFile, testFilePath);
            var _alifbaRepo = new BitigAlifbaRepository(new XmlAlifbaRepository(alifbaPath));
            var _testRepo = new BitigDirectionRepository(
                new XmlDirectionRepository(testFilePath, _alifbaRepo));
            var _direction = _testRepo.Get(777);
            Assert.AreEqual(null, _direction.BuiltIn);
            Assert.AreEqual(0, _direction.Source.ID);
            Assert.AreEqual(1, _direction.Target.ID);

            var _assembly = "NewAssembly" + Guid.NewGuid();
            var _type = "NewType" + Guid.NewGuid();
            var _builtIn = DefaultConfiguration.BuiltInDirections[0];
            var _newSource = _alifbaRepo.Get(2);
            var _newTarget = _alifbaRepo.Get(3);
            _direction.Source = _newSource;
            _direction.Target = _newTarget;
            _direction.BuiltIn = _builtIn;
            _direction.AssemblyPath = _assembly;
            _direction.TypeName = _type;
            _testRepo.Update(_direction);
            _testRepo.SaveChanges();

            var _checkRepo = new XmlDirectionRepository(testFilePath, _alifbaRepo);
            var _updated = _checkRepo.Get(777);
            Assert.IsNotNull(_updated);
            Assert.AreEqual(_assembly, _updated.AssemblyPath);
            Assert.AreEqual(_type, _updated.TypeName);
            Assert.AreEqual(_updated.Source, _newSource);
            Assert.AreEqual(_updated.Target, _newTarget);
            Assert.AreEqual(_updated.BuiltIn, _builtIn);
        }

        [TestMethod]
        public void Update_CreateDefault()
        {
            var _alifbaRepo = new BitigAlifbaRepository(new XmlAlifbaRepository(alifbaPath));
            var _xmlRepo = new XmlDirectionRepository(testFilePath, _alifbaRepo);
            var _testRepo = new BitigDirectionRepository(_xmlRepo);
            var _assembly = "TestAssembly " + Guid.NewGuid();
            var _source = _alifbaRepo.Get(2);
            var _target = _alifbaRepo.Get(3);
            var _direction = new Direction(0, _source, _target, _assembly);
            _testRepo.Update(_direction);
            _testRepo.SaveChanges();
            var _list = _xmlRepo.GetList();
            Assert.AreEqual(DefaultConfiguration.BuiltInDirections.Count, _list.Count);
        }

        [TestMethod]
        public void Delete()
        {
            File.Copy(preparedFile, testFilePath);
            var _alifbaRepo = new XmlAlifbaRepository(alifbaPath);
            var _testRepo = new XmlDirectionRepository(testFilePath, _alifbaRepo);
            var _direction = _testRepo.Get(777);
            Assert.IsNotNull(_direction);
            _testRepo.Delete(_direction);
            _testRepo.SaveChanges();

            var _checkRepo = new XmlDirectionRepository(testFilePath, _alifbaRepo);
            var _deleted = _checkRepo.Get(777);
            Assert.IsNull(_deleted);
        }

        [TestMethod]
        public void Delete_CreateDefault()
        {
            var _alifbaRepo = new XmlAlifbaRepository(alifbaPath);
            var _xmlRepo = new XmlDirectionRepository(testFilePath, _alifbaRepo);
            var _testRepo = new BitigDirectionRepository(_xmlRepo);
            var _direction = new Direction(0, null, null); //repo: Repo.FirstID? (together with Repo.DefaultID)
            _testRepo.Delete(_direction);
            _testRepo.SaveChanges();
            var _list = _xmlRepo.GetList();
            Assert.AreEqual(DefaultConfiguration.BuiltInDirections.Count - 1, _list.Count);
        }

        [TestMethod]
        public void GenerateID()
        {
            var _testRepo = new XmlDirectionRepository(null, null);
            var _IDs = new int[] { 0, 1, 3, 4, 6 };
            var _newID = _testRepo.GenerateID(_IDs);
            Assert.IsFalse(_IDs.Any(_id => _id == _newID));
        }

        [TestMethod]
        public void GetByAlifbaIDs()
        {
            var _alifbaRepo = new BitigAlifbaRepository(new XmlAlifbaRepository(alifbaPath));
            var _xmlRepo = new XmlDirectionRepository(testFilePath, _alifbaRepo);
            var _testRepo = new BitigDirectionRepository(_xmlRepo);
            var _cyrZam = _testRepo.GetByAlifbaIDs(0, 2);
            Assert.IsNotNull(_cyrZam);
            Assert.AreEqual(0, _cyrZam.Source.ID);
            Assert.AreEqual(2, _cyrZam.Target.ID);
        }

        [TestMethod]
        public void GetTargets()
        {
            var _alifbaRepo = new BitigAlifbaRepository(new XmlAlifbaRepository(alifbaPath));
            var _xmlRepo = new XmlDirectionRepository(testFilePath, _alifbaRepo);
            var _testRepo = new BitigDirectionRepository(_xmlRepo);
            var _targets = _testRepo.GetTargets(0);
            Assert.AreEqual(3, _targets.Count);
            var _expectedIDs = new List<int> { 1, 2, 3 };
            Assert.IsTrue(_expectedIDs.All(_id => _targets.Exists(_t => _t.ID == _id)));
        }
    }
}
