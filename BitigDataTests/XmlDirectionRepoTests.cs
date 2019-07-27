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

        private const string sourceDataFolder = @"TestData\";
        private const string currentDataFolder = @"DirectionRepoTestData\";
        private readonly string currentDirectionsPath = currentDataFolder + "Directions.xml";
        private readonly string currentALphabetsPath = currentDataFolder + "Alphabets.xml";
        private readonly string preparedFile = sourceDataFolder + @"Direction777.xml";
        private readonly string preparedAlphabetsFile = sourceDataFolder + @"Alphabet1025.xml";

        private DirectionRepository InitTestRepo()
        {
            File.Copy(preparedFile, currentDirectionsPath);
            File.Copy(preparedAlphabetsFile, currentALphabetsPath);
            TestUtils.CopyDirectory(sourceDataFolder + "Exclusions", currentDataFolder + "Exclusions");
            TestUtils.CopyDirectory(sourceDataFolder + "Mappings", currentDataFolder + "Mappings");
            var _xmlContext = new XmlContext(currentALphabetsPath, currentDirectionsPath);
            var _dirRepo = _xmlContext.DirectionRepository;
            return _dirRepo;
        }

        private DirectionRepository InitCheckRepo()
        {
            if (!File.Exists(currentDirectionsPath))
                throw new Exception("File not created.");
            var _xmlContext = new XmlContext(currentALphabetsPath, currentDirectionsPath);
            var _dirRepo = _xmlContext.DirectionRepository;
            return _dirRepo;
        }

        [TestInitialize]
        [TestCleanup]
        public void DeleteTestFile()
        {
            if (Directory.Exists(currentDataFolder))
                Directory.Delete(currentDataFolder, true);
            Directory.CreateDirectory(currentDataFolder);
        }

       [TestMethod]
        public void GetList()
        {
            var _testRepo = InitTestRepo();
            var _list = _testRepo.GetList();
            Assert.AreEqual(8, _list.Count);
        }

        [TestMethod]
        public void Get()
        {
            var _testRepo = InitTestRepo();
            var _direction777 = _testRepo.Get(777);
            Assert.IsNotNull(_direction777);
            Assert.IsNotNull(_direction777.Source);
            Assert.IsNotNull(_direction777.Target);

            var _direction778 = _testRepo.Get(778);
            Assert.IsNotNull(_direction778);
            Assert.IsNotNull(_direction778.Source);
            Assert.IsNotNull(_direction778.Target);
            Assert.IsNotNull(_direction778.BuiltInType);
        }

        [TestMethod]
        public void Insert()
        {
            var _testRepo = InitTestRepo();
            var _source = new AlphabetSummary(1, "alphabet1");
            var _target = new AlphabetSummary(0, "alphabet2");
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
            var _source1 = new AlphabetSummary(1, "alphabet1");
            var _target = new AlphabetSummary(0, "alphabet2");
            var _source2 = new AlphabetSummary(2, "alphabet3");
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
        public void Insert_SameAlphabetIDs()
        {
            var _testRepo = InitTestRepo();
            var _source = new AlphabetSummary(0, "alphabet1");
            var _target = new AlphabetSummary(1, "alphabet2");
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
            var _testRepo = InitTestRepo();
            var _alphabetRepo = _testRepo.DataContext.AlphabetRepository;
            var _direction = _testRepo.Get(777);
            Assert.AreEqual(BuiltInDirectionType.None, _direction.BuiltInType);
            Assert.AreEqual(0, _direction.Source.ID);
            Assert.AreEqual(1, _direction.Target.ID);

            var _assembly = "NewAssembly" + Guid.NewGuid();
            var _type = "NewType" + Guid.NewGuid();
            var _newSource = _alphabetRepo.Get(2);
            var _newTarget = _alphabetRepo.Get(3);
            _direction.Source = _newSource;
            _direction.Target = _newTarget;
            _direction.BuiltInType = BuiltInDirectionType.CyrillicYanalif;
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
            Assert.AreEqual(_updated.BuiltInType, BuiltInDirectionType.CyrillicYanalif);
        }

        [TestMethod]
        public void Delete()
        {
            var _testRepo = InitTestRepo();
            var _direction = _testRepo.Get(777);
            Assert.IsNotNull(_direction);
            _testRepo.Delete(_direction.ID);
            _testRepo.DataContext.SaveChanges();

            var _checkRepo = InitCheckRepo();
            var _deleted = _checkRepo.Get(777);
            Assert.IsNull(_deleted);
        }

        [TestMethod]
        public void GetByAlphabetIDs()
        {
            var _testRepo = InitTestRepo();
            var _cyrZam = _testRepo.GetByAlphabetIDs(0, 2);
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
            var _testRepo = InitTestRepo();
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
        public void Insert_ManualCommand()
        {
            var _testRepo = InitTestRepo();
            var _source = _testRepo.DataContext.AlphabetRepository.Get(1);
            var _target = _testRepo.DataContext.AlphabetRepository.Get(0);
            var _direction = new Direction(-1, _source, _target, null, 
                ManualCommand: new ManualCommand(new Dictionary<TextSymbol, TextSymbol>
                {
                    { new TextSymbol("1"), new TextSymbol("2") }
                }));
            _testRepo.Insert(_direction);
            _testRepo.DataContext.SaveChanges();
            var _checkRepo = InitCheckRepo();
            var _savedDirection = _testRepo.GetByAlphabetIDs(_source.ID, _target.ID);
            Assert.IsNotNull(_savedDirection);
            Assert.IsNotNull(_savedDirection.ManualCommand);
            Assert.AreEqual(1, _savedDirection.ManualCommand.SymbolMapping.Count);
            Assert.AreEqual(new TextSymbol("2"), _savedDirection.ManualCommand.SymbolMapping[new TextSymbol("1")]);
        }

        [TestMethod]
        public void Update_ManualCommand()
        {
            var _testRepo = InitTestRepo();
            var _direction = _testRepo.Get(777);
            _direction.ManualCommand = new ManualCommand(new Dictionary<TextSymbol, TextSymbol>
                {
                    { new TextSymbol("1"), new TextSymbol("2") }
                });
            _testRepo.Update(_direction);
            _testRepo.DataContext.SaveChanges();
            var _checkRepo = InitCheckRepo();
            var _savedDirection = _testRepo.Get(777);
            Assert.IsNotNull(_savedDirection.ManualCommand);
            Assert.AreEqual(1, _savedDirection.ManualCommand.SymbolMapping.Count);
            Assert.AreEqual(new TextSymbol("2"), _savedDirection.ManualCommand.SymbolMapping[new TextSymbol("1")]);
        }

        [TestMethod]
        public void DeserializeSymbolMapping()
        {
            var _testRepo = InitTestRepo();
            var _mapping = _testRepo.GetSymbolMapping(1);
            Assert.IsNotNull(_mapping);
            Assert.AreEqual(2, _mapping.Count);
            var _key1 = new TextSymbol("1", DisplayText: "A");
            var _value1 = new TextSymbol("2", DisplayText: "B");
            Assert.AreEqual(_value1, _mapping[_key1]);
            var _key2 = new TextSymbol("c", "C");
            var _value2 = new TextSymbol("d", "D");
            Assert.AreEqual(_value2, _mapping[_key2]);
        }

        [TestMethod]
        public void Delete_Exclusions()
        {
            var _testRepo = InitTestRepo();
            var _direction777 = _testRepo.Get(777);
            Assert.AreNotEqual(0, _direction777.Exclusions.Count);
            var _exclusionsPath = currentDataFolder + @"Exclusions\777.xml";
            Assert.IsTrue(File.Exists(_exclusionsPath));
            _testRepo.Delete(777);
            _testRepo.DataContext.SaveChanges();
            Assert.IsFalse(File.Exists(_exclusionsPath));
        }

        [TestMethod]
        public void Update_DeleteExclusions()
        {
            var _testRepo = InitTestRepo();
            var _direction777 = _testRepo.Get(777);
            Assert.AreNotEqual(0, _direction777.Exclusions.Count);
            var _exclusionsPath = currentDataFolder + @"Exclusions\777.xml";
            Assert.IsTrue(File.Exists(_exclusionsPath));
            _direction777.Exclusions = null;
            _testRepo.Update(_direction777);
            _testRepo.DataContext.SaveChanges();
            Assert.IsFalse(File.Exists(_exclusionsPath));
        }
    }
}
