using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using Bitig.Data.Storage;
using Bitig.Logic.Model;
using Bitig.Logic.Repository;

namespace BitigDataTests
{
    [TestClass]
    public class XmlDirectionRepoTests
    {
        public XmlDirectionRepoTests()
        {
        }

        private readonly string testFilePath = @"..\..\TestData\Directions.xml";
        private readonly string alifbaPath = @"..\..\TestData\Alphabets.xml";
        private readonly string preparedFile = @"..\..\TestData\Prepared\Direction777.xml";

        [TestInitialize]
        [TestCleanup]
        public void DeleteTestFile()
        {
            File.Delete(testFilePath);
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
            var _testRepo = new XmlDirectionRepository(testFilePath, _alifbaRepo);
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
            var _alifbaRepo = new XmlAlifbaRepository(alifbaPath);
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
            var _testRepo = new XmlDirectionRepository(testFilePath, _alifbaRepo);
            _testRepo.Get(0);

            var _count = _testRepo.GetListNoCreateDefaults().Count;
            Assert.AreEqual(DefaultConfiguration.BuiltInDirections.Count, _count);
        }

        [TestMethod]
        public void Insert()
        {
            var _alifbaRepo = new XmlAlifbaRepository(alifbaPath);
            var _testRepo = new XmlDirectionRepository(testFilePath, _alifbaRepo);
            var _source = new Alifba(0, "alifba1");
            var _target = new Alifba(1, "alifba2");
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
            var _alifbaRepo = new XmlAlifbaRepository(alifbaPath);
            var _testRepo = new XmlDirectionRepository(testFilePath, _alifbaRepo);
            var _source = new Alifba(0, "alifba1");
            var _target = new Alifba(1, "alifba2");
            const int _id = -1;
            var _dir1 = new Direction(_id, _source, _target);
            _testRepo.Insert(_dir1);
            var _dir2 = new Direction(_id, _target, _source);
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
            var _alifbaRepo = new XmlAlifbaRepository(alifbaPath);
            var _testRepo = new XmlDirectionRepository(testFilePath, _alifbaRepo);
            var _source = new Alifba(0, "alifba1");
            var _target = new Alifba(1, "alifba2");
            var _assemblyName = "TestAssembly" + Guid.NewGuid();
            var _direction = new Direction(-1, _source, _target, _assemblyName, "TestType");
            _testRepo.Insert(_direction);
            _testRepo.SaveChanges();

            var _count = _testRepo.GetListNoCreateDefaults().Count;
            Assert.AreEqual(DefaultConfiguration.BuiltInDirections.Count + 1, _count);
        }

        [TestMethod]
        public void Update()
        {
            File.Copy(preparedFile, testFilePath);
            var _alifbaRepo = new XmlAlifbaRepository(alifbaPath);
            var _testRepo = new XmlDirectionRepository(testFilePath, _alifbaRepo);
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
            var _alifbaRepo = new XmlAlifbaRepository(alifbaPath);
            var _testRepo = new XmlDirectionRepository(testFilePath, _alifbaRepo);
            var _assembly = "TestAssembly " + Guid.NewGuid();
            var _source = _alifbaRepo.Get(2);
            var _target = _alifbaRepo.Get(3);
            var _direction = new Direction(0, _source, _target, _assembly);
            _testRepo.Update(_direction);
            _testRepo.SaveChanges();
            var _list = _testRepo.GetListNoCreateDefaults();
            Assert.AreEqual(DefaultConfiguration.BuiltInAlifbaList.Count, _list.Count);
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
            var _testRepo = new XmlDirectionRepository(testFilePath, _alifbaRepo);
            //var _source = _alifbaRepo.Get(2);
            //var _target = _alifbaRepo.Get(3);
            var _direction = new Direction(0, null, null); //repo: Repo.FirstID? (together with Repo.DefaultID)
            _testRepo.Delete(_direction);
            _testRepo.SaveChanges();
            var _list = _testRepo.GetListNoCreateDefaults();
            Assert.AreEqual(DefaultConfiguration.BuiltInAlifbaList.Count - 1, _list.Count);
        }

        [TestMethod]
        public void GenerateID()
        {
            var _testRepo = new XmlDirectionRepository(null, null);
            var _IDs = new int[] { 0, 1, 3, 4, 6 };
            var _newID = _testRepo.GenerateID(_IDs);
            Assert.IsFalse(_IDs.Any(_id => _id == _newID));
        }
    }
}
