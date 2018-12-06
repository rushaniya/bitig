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

        private const string dataFolder = @"TestData\";
        private readonly string alifbaPath = dataFolder + "Alphabets.xml";
        private readonly string preparedFile = dataFolder + @"Prepared\Direction777.xml";
        private readonly string testFilePath = dataFolder + "Directions.xml";

        private DirectionRepository InitTestRepo(string preparedFilePath = null)
        {
            if (preparedFilePath != null)
                File.Copy(preparedFilePath, testFilePath);
            var _xmlContext = new XmlContext(alifbaPath, testFilePath);
            var _dirRepo = _xmlContext.DirectionRepository;
            return _dirRepo;
        }

        private DirectionRepository InitCheckRepo()
        {
            if (!File.Exists(testFilePath))
                throw new Exception("File not created.");
            var _xmlContext = new XmlContext(alifbaPath, testFilePath);
            var _dirRepo = _xmlContext.DirectionRepository;
            return _dirRepo;
        }

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
            var _testRepo = InitTestRepo(preparedFile);
            var _list = _testRepo.GetList();
            Assert.AreEqual(9, _list.Count);
        }

        [TestMethod]
        public void GetList_CreateDefault()
        {
            var _testRepo = InitTestRepo();
            var _builtInList = DefaultConfiguration.BuiltInDirections;
            Assert.AreNotEqual(0, _builtInList.Count);
            var _defaultList = _testRepo.GetList();
            foreach (var _item in _builtInList)
            {
                Assert.IsNotNull(_defaultList.Single(_dir =>
                _dir.BuiltIn.ID == _item.ID && 
                _dir.Source.BuiltIn == _item.Source && _dir.Target.BuiltIn == _item.Target));
            }
        }

        [TestMethod]
        public void Get()
        {
            var _testRepo = InitTestRepo(preparedFile);
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
            var _testRepo = InitTestRepo();
            _testRepo.Get(0);

            var _checkRepo = InitCheckRepo();
            var _count = _checkRepo.GetList().Count;
            Assert.AreEqual(DefaultConfiguration.BuiltInDirections.Count, _count);
        }

        [TestMethod]
        public void Insert()
        {
            var _testRepo = InitTestRepo();
            var _source = new Alifba(1, "alifba1");
            var _target = new Alifba(0, "alifba2");
            var _assemblyName = "TestAssembly" + Guid.NewGuid();
            var _typeName = "TestType" + Guid.NewGuid();
            var _direction = new Direction(-1, _source, _target, null, _assemblyName, _typeName);
            _testRepo.Insert(_direction);
            _testRepo.DataContext.SaveChanges();

            var _checkRepo = InitCheckRepo();
            var _list = _checkRepo.GetList();
            Assert.IsTrue(_list.Count > 0);
            var _inserted = _checkRepo.GetList().Find(x =>
                x.AssemblyFileName == _assemblyName && x.TypeName == _typeName);
            Assert.IsNotNull(_inserted);
            Assert.AreNotEqual(-1, _inserted.ID);
            Assert.AreEqual(_source, _inserted.Source);
            Assert.AreEqual(_target, _inserted.Target);
        }

        [TestMethod]
        public void Insert_AssignID()
        {
            var _testRepo = InitTestRepo();
            var _source1 = new Alifba(1, "alifba1");
            var _target = new Alifba(0, "alifba2");
            var _source2 = new Alifba(2, "alifba3");
            const int _id = -1;
            var _dir1 = new Direction(_id, _source1, _target, null);
            _testRepo.Insert(_dir1);
            var _dir2 = new Direction(_id, _source2, _target, null);
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
            var _testRepo = InitTestRepo();
            var _source = new Alifba(1, "alifba1");
            var _target = new Alifba(0, "alifba2");
            var _assemblyName = "TestAssembly" + Guid.NewGuid();
            var _typeName = "TestType" + Guid.NewGuid();
            var _direction = new Direction(-1, _source, _target, null, _assemblyName, _typeName);
            _testRepo.Insert(_direction);
            _testRepo.DataContext.SaveChanges();

            var _checkRepo = InitCheckRepo();
            var _count = _checkRepo.GetList().Count;
            Assert.AreEqual(DefaultConfiguration.BuiltInDirections.Count + 1, _count);
        }

        [TestMethod]
        public void Insert_SameAlifbaIDs()
        {
            var _testRepo = InitTestRepo();
            var _source = new Alifba(0, "alifba1");
            var _target = new Alifba(1, "alifba2");
            var _assemblyName = "TestAssembly" + Guid.NewGuid();
            var _typeName = "TestType" + Guid.NewGuid();
            var _direction = new Direction(-1, _source, _target, null, _assemblyName, _typeName);
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
            var _testRepo = InitTestRepo(preparedFile);
            var _alifbaRepo = _testRepo.DataContext.AlifbaRepository;
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
            _testRepo.DataContext.SaveChanges();

            var _checkRepo = InitCheckRepo();
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
            var _testRepo = InitTestRepo();
            var _alifbaRepo = _testRepo.DataContext.AlifbaRepository;
            var _assembly = "TestAssembly " + Guid.NewGuid();
            var _source = _alifbaRepo.Get(2);
            var _target = _alifbaRepo.Get(3);
            var _direction = new Direction(0, _source, _target, null, _assembly);
            _testRepo.Update(_direction);
            _testRepo.DataContext.SaveChanges();

            var _checkRepo = InitCheckRepo();
            var _list = _checkRepo.GetList();
            Assert.AreEqual(DefaultConfiguration.BuiltInDirections.Count, _list.Count);
        }

        [TestMethod]
        public void Delete()
        {
            var _testRepo = InitTestRepo(preparedFile);
            var _direction = _testRepo.Get(777);
            Assert.IsNotNull(_direction);
            _testRepo.Delete(_direction.ID);
            _testRepo.DataContext.SaveChanges();

            var _checkRepo = InitCheckRepo();
            var _deleted = _checkRepo.Get(777);
            Assert.IsNull(_deleted);
        }

        [TestMethod]
        public void Delete_CreateDefault()
        {
            var _testRepo = InitTestRepo();
            var _direction = new Direction(0, null, null, null);
            _testRepo.Delete(_direction.ID);
            _testRepo.DataContext.SaveChanges();

            var _checkRepo = InitCheckRepo();
            var _list = _checkRepo.GetList();
            Assert.AreEqual(DefaultConfiguration.BuiltInDirections.Count - 1, _list.Count);
        }

      /*  [TestMethod]
        public void GenerateID()
        {
            var _testRepo = new XmlDirectionRepository(null);
            var _IDs = new int[] { 0, 1, 3, 4, 6 };
            var _newID = _testRepo.GenerateID(_IDs);
            Assert.IsFalse(_IDs.Any(_id => _id == _newID));
        }*/

        [TestMethod]
        public void GetByAlifbaIDs()
        {
            var _testRepo = InitTestRepo();
            var _cyrZam = _testRepo.GetByAlifbaIDs(0, 2);
            Assert.IsNotNull(_cyrZam);
            Assert.AreEqual(0, _cyrZam.Source.ID);
            Assert.AreEqual(2, _cyrZam.Target.ID);
        }

        [TestMethod]
        public void GetTargets()
        {
            var _testRepo = InitTestRepo();
            var _targets = _testRepo.GetTargets(0);
            Assert.AreEqual(3, _targets.Count);
            var _expectedIDs = new List<int> { 1, 2, 3 };
            Assert.IsTrue(_expectedIDs.All(_id => _targets.Exists(_t => _t.ID == _id)));
        }

        [TestMethod]
        public void GetExclusions()
        {
            var _testRepo = InitTestRepo(preparedFile);
            var _direction = _testRepo.Get(777);
            Assert.IsNotNull(_direction.Exclusions);
            Assert.AreEqual(1, _direction.Exclusions.Count);
            var _checkExcl = _direction.Exclusions[0];
            Assert.AreEqual(true, _checkExcl.AnyPosition);
            Assert.AreEqual("1", _checkExcl.SourceWord);
            Assert.AreEqual("2", _checkExcl.TargetWord);
        }

        [TestMethod]
        public void SaveExclusions()
        {
            var _testRepo = InitTestRepo();
            var _exclusion = new Exclusion(SourceWord: "1", TargetWord: "2", MatchCase: false, MatchBeginning: false, AnyPosition: true);
            var _direction = _testRepo.Get(0);
            _direction.Exclusions = new List<Exclusion> { _exclusion };
            _testRepo.Update(_direction);
            _testRepo.DataContext.SaveChanges();

            var _checkRepo = InitCheckRepo();
            var _updated = _checkRepo.Get(0);
            Assert.IsNotNull(_updated.Exclusions);
            Assert.AreEqual(1, _updated.Exclusions.Count);
            var _checkExcl = _updated.Exclusions[0];
            Assert.AreEqual(true, _checkExcl.AnyPosition);
            Assert.AreEqual("1", _checkExcl.SourceWord);
            Assert.AreEqual("2", _checkExcl.TargetWord);
        }

        [TestMethod]
        public void InvalidConfig()
        {
            var _invalidFile = dataFolder + @"corrupted\InvalidDirections.xml";
            var _testRepo = InitTestRepo(_invalidFile);
            var _list = _testRepo.GetList();
            Assert.AreEqual(DefaultConfiguration.BuiltInDirections.Count, _list.Count);
        }

        [TestMethod]
        public void ObsoleteConfig()
        {
            var _invalidFile = dataFolder + @"corrupted\ObsoleteDirections.xml";
            var _testRepo = InitTestRepo(_invalidFile);
            var _list = _testRepo.GetList();
            Assert.AreEqual(DefaultConfiguration.BuiltInDirections.Count, _list.Count);
        }
    }
}
