using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Bitig.Data.Storage;
using Bitig.Logic.Model;
using Bitig.Logic.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BitigDataTests
{
    [TestClass]
    public class XmlContextTests
    {
        private const string currentDataFolder = @"XmlContextTestData\";
        private readonly string testAlphabetPath = currentDataFolder + "Alphabets.xml";
        private readonly string preparedAlphabetFile = currentDataFolder + @"Prepared\Alphabet1025.xml";
        private readonly string testDirectionPath = currentDataFolder + "Directions.xml";
        private readonly string preparedDirectionFile = currentDataFolder + @"Prepared\Direction777.xml";

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
        public void Update_New()
        {
            var _xmlContext = new XmlContext(testAlphabetPath, testDirectionPath);
            var _alphabetRepo = _xmlContext.AlphabetRepository;
            var _name1 = "Test name " + Guid.NewGuid();
            var _newItem = new Alphabet(-1, _name1);
            _alphabetRepo.Insert(_newItem);
            var _name2 = "New name " + Guid.NewGuid();
            _newItem.FriendlyName = _name2;
            _alphabetRepo.Update(_newItem);
            _xmlContext.SaveChanges();
            var _saved = _alphabetRepo.GetList().Find(_item => _item.FriendlyName == _name2);
            Assert.IsNotNull(_saved);
        }


        [TestMethod]
        public void Update()
        {
            File.Copy(preparedAlphabetFile, testAlphabetPath);
            var _xmlContext = new XmlContext(testAlphabetPath, testDirectionPath);
            var _alphabetRepo = _xmlContext.AlphabetRepository;
            var _alphabet = _alphabetRepo.Get(1025);
            var _oldname = _alphabet.FriendlyName;
            Assert.IsNotNull(_alphabet);
            var _newName = "New name " + Guid.NewGuid();
            _alphabet.FriendlyName = _newName;
            var _inMemory = _alphabetRepo.Get(1025);
            Assert.AreEqual(_oldname, _inMemory.FriendlyName);
            _alphabetRepo.Update(_alphabet);
            _inMemory = _alphabetRepo.Get(1025);
            Assert.AreEqual(_newName, _inMemory.FriendlyName);
            //not written to file until SaveChanges is called
            var _staleRepo = new XmlContext(testAlphabetPath, testDirectionPath).AlphabetRepository;
            var _persistent = _staleRepo.Get(1025);
            Assert.AreEqual(_oldname, _persistent.FriendlyName);
            _xmlContext.SaveChanges();
            _inMemory = _alphabetRepo.Get(1025);
            Assert.AreEqual(_newName, _inMemory.FriendlyName);
            _staleRepo = new XmlContext(testAlphabetPath, testDirectionPath).AlphabetRepository;
            _persistent = _staleRepo.Get(1025);
            Assert.AreEqual(_newName, _persistent.FriendlyName);
        }

        [TestMethod]
        public void Insert()
        {
            var _xmlContext = new XmlContext(testAlphabetPath, testDirectionPath);
            var _alphabetRepo = _xmlContext.AlphabetRepository;
            var _name = "Test name " + Guid.NewGuid();
            var _newItem = new Alphabet(-1, _name);
            _alphabetRepo.Insert(_newItem);
            var _inMemoryList = _alphabetRepo.GetList();
            var _added = _inMemoryList.Find(_item => _item.FriendlyName == _name);
            Assert.IsNotNull(_added);
            //not written to file until SaveChanges is called
            var _staleRepo = new XmlContext(testAlphabetPath, testDirectionPath).AlphabetRepository;
            var _persistent = _staleRepo.GetList().Find(_item => _item.FriendlyName == _name);
            Assert.IsNull(_persistent);
            _xmlContext.SaveChanges();
            _staleRepo = new XmlContext(testAlphabetPath, testDirectionPath).AlphabetRepository;
            _persistent = _staleRepo.GetList().Find(_item => _item.FriendlyName == _name);
            Assert.IsNotNull(_persistent);
            Assert.AreNotEqual(-1, _persistent.ID);
        }

        [TestMethod]
        public void Insert_SameAlphabets()
        {
            var _xmlContext = new XmlContext(testAlphabetPath, testDirectionPath);
            var _alphabetRepo = _xmlContext.AlphabetRepository;
            var _directionRepo = _xmlContext.DirectionRepository;
            var _name1 = "Test name " + Guid.NewGuid();
            var _newAlif1 = new Alphabet(-1, _name1);
            _alphabetRepo.Insert(_newAlif1);
            var _name2 = "Test name " + Guid.NewGuid();
            var _newAlif2 = new Alphabet(-1, _name2);
            _alphabetRepo.Insert(_newAlif2);
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
            var _xmlContext = new XmlContext(testAlphabetPath, testDirectionPath);
            var _alphabetRepo = _xmlContext.AlphabetRepository;
            var _directionRepo = _xmlContext.DirectionRepository;
            var _name1 = "Test name " + Guid.NewGuid();
            var _newAlif1 = new Alphabet(-1, _name1);
            _alphabetRepo.Insert(_newAlif1);
            var _name2 = "Test name " + Guid.NewGuid();
            var _newAlif2 = new Alphabet(-1, _name2);
            _alphabetRepo.Insert(_newAlif2);
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
            var _xmlContext = new XmlContext(testAlphabetPath, testDirectionPath);
            var _alphabetRepo = _xmlContext.AlphabetRepository;
            var _name = "Test name " + Guid.NewGuid();
            var _newItem = new Alphabet(-1, _name);
            _alphabetRepo.Insert(_newItem);
            var _name2 = "Test name " + Guid.NewGuid();
            var _newItem2 = new Alphabet(-1, _name2);
            _alphabetRepo.Insert(_newItem2);
            Assert.AreNotEqual(-1, _newItem2.ID);
            _alphabetRepo.Delete(_newItem.ID);
            _xmlContext.SaveChanges();

            var _staleRepo = new XmlContext(testAlphabetPath, testDirectionPath).AlphabetRepository;
            var _persistent = _staleRepo.GetList().Find(_item => _item.FriendlyName == _name2);
            Assert.IsNotNull(_persistent);
            Assert.AreNotEqual(-1, _persistent.ID);
        }

        [TestMethod]
        public void Insert_Two()
        {
            var _xmlContext = new XmlContext(testAlphabetPath, testDirectionPath);
            var _alphabetRepo = _xmlContext.AlphabetRepository;
            var _name1 = "Test name " + Guid.NewGuid();
            var _newItem1 = new Alphabet(-1, _name1);
            _alphabetRepo.Insert(_newItem1);
            var _name2 = "Test name " + Guid.NewGuid();
            var _newItem2 = new Alphabet(-1, _name2);
            _alphabetRepo.Insert(_newItem2);
            Assert.AreNotEqual(-1, _newItem1.ID);
            Assert.AreNotEqual(-1, _newItem2.ID);
            Assert.AreNotEqual(_newItem1.ID, _newItem2.ID);

            _xmlContext.SaveChanges();
            var _staleRepo = new XmlContext(testAlphabetPath, testDirectionPath).AlphabetRepository;
            var _saved1 = _staleRepo.GetList().Find(_item => _item.FriendlyName == _name1);
            var _saved2 = _staleRepo.GetList().Find(_item => _item.FriendlyName == _name2);
            Assert.IsNotNull(_saved1);
            Assert.IsNotNull(_saved2);
            Assert.AreNotEqual(_saved1.ID, _saved2.ID);
        }

        [TestMethod]
        public void Delete()
        {
            File.Copy(preparedAlphabetFile, testAlphabetPath);
            var _xmlContext = new XmlContext(testAlphabetPath, testDirectionPath);
            var _alphabetRepo = _xmlContext.AlphabetRepository;
            var _alphabet = _alphabetRepo.Get(1025);
            _alphabetRepo.Delete(_alphabet.ID);
            var _staleRepo = new XmlContext(testAlphabetPath, testDirectionPath).AlphabetRepository;
            var _persistent = _staleRepo.Get(1025);
            Assert.IsNotNull(_persistent);
            _xmlContext.SaveChanges();
            _staleRepo = new XmlContext(testAlphabetPath, testDirectionPath).AlphabetRepository;
            _persistent = _staleRepo.Get(1025);
            Assert.IsNull(_persistent);
        }

        [TestMethod]
        public void Delete_New()
        {
            var _xmlContext = new XmlContext(testAlphabetPath, testDirectionPath);
            var _alphabetRepo = _xmlContext.AlphabetRepository;
            var _initialCount = _alphabetRepo.GetList().Count;
            var _name = "Test name " + Guid.NewGuid();
            var _newItem = new Alphabet(-1, _name);
            _alphabetRepo.Insert(_newItem);
            _alphabetRepo.Delete(_newItem.ID);
            _xmlContext.SaveChanges();
            var _staleRepo = new XmlContext(testAlphabetPath, testDirectionPath).AlphabetRepository;
            var _persistentList = _staleRepo.GetList();
            Assert.AreEqual(_initialCount, _persistentList.Count);
            var _deleted = _persistentList.Find(_item => _item.FriendlyName == _name);
            Assert.IsNull(_deleted);
        }

        [TestMethod]
        public void Delete_InUse()
        {
            var _xmlContext = new XmlContext(testAlphabetPath, testDirectionPath);
            var _alphabetRepo = _xmlContext.AlphabetRepository;
            var _directionRepo = _xmlContext.DirectionRepository;
            var _name1 = "Test name " + Guid.NewGuid();
            var _newAlif1 = new Alphabet(-1, _name1);
            _alphabetRepo.Insert(_newAlif1);
            var _name2 = "Test name " + Guid.NewGuid();
            var _newAlif2 = new Alphabet(-1, _name2);
            _alphabetRepo.Insert(_newAlif2);
            var _assembly = "Assembly " + Guid.NewGuid();
            var _newDir = new Direction(-1, _newAlif1, _newAlif2, null, _assembly);
            _directionRepo.Insert(_newDir);
            try
            {
                _alphabetRepo.Delete(_newAlif1.ID);
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
            var _xmlContext = new XmlContext(testAlphabetPath, testDirectionPath);
            var _alphabetRepo = _xmlContext.AlphabetRepository;
            var _directionRepo = _xmlContext.DirectionRepository;
            var _directions = _directionRepo.GetList();
            foreach (var _dir in _directions)
            {
                if (_dir.Source.ID == 0 || _dir.Target.ID == 0)
                    _directionRepo.Delete(_dir.ID);
            }
            var _testAlphabet = _alphabetRepo.Get(0);
            _alphabetRepo.Delete(_testAlphabet.ID);
        }

        [TestMethod]
        public void DirectionWithNewAlphabets()
        {
            var _xmlContext = new XmlContext(testAlphabetPath, testDirectionPath);
            var _alphabetRepo = _xmlContext.AlphabetRepository;
            var _directionRepo = _xmlContext.DirectionRepository;
            var _name1 = "Test name " + Guid.NewGuid();
            var _newAlif1 = new Alphabet(-1, _name1);
            _alphabetRepo.Insert(_newAlif1);
            var _name2 = "Test name " + Guid.NewGuid();
            var _newAlif2 = new Alphabet(-1, _name2);
            _alphabetRepo.Insert(_newAlif2);
            var _assembly = "Assembly " + Guid.NewGuid();
            var _newDir = new Direction(-1, _newAlif1, _newAlif2, null, _assembly);
            _directionRepo.Insert(_newDir);
            _xmlContext.SaveChanges();

            var _staleContext = new XmlContext(testAlphabetPath, testDirectionPath);
            var _alphabetSaved = _staleContext.AlphabetRepository.GetList();
            var _alif1 = _alphabetSaved.Find(_alif => _alif.FriendlyName == _name1);
            var _alif2 = _alphabetSaved.Find(_alif => _alif.FriendlyName == _name2);
            var _directionSaved = _staleContext.DirectionRepository.GetList();
            var _direction = _directionSaved.Find(_dir =>
              _dir.Source.ID == _alif1.ID && _dir.Target.ID == _alif2.ID
              && _dir.AssemblyPath == _assembly);
            Assert.IsNotNull(_direction);
        }

        [TestMethod]
        public void Initialization_FillList()
        {
            File.Copy(preparedDirectionFile, testDirectionPath);
            var _xmlContext = new XmlContext(testAlphabetPath, testDirectionPath);
            var _directionRepo = _xmlContext.DirectionRepository;
            var _dirList = _directionRepo.GetList();
            Assert.AreEqual(9, _dirList.Count);
        }

        [TestMethod]
        public void Get_AlphabetNameChanged()
        {
            var _xmlContext = new XmlContext(testAlphabetPath, testDirectionPath);
            var _alphabetRepo = _xmlContext.AlphabetRepository;
            var _directionRepo = _xmlContext.DirectionRepository;
            var _testAlphabet = _alphabetRepo.Get(0);
            var _newName = "Alphabet" + Guid.NewGuid();
            var _testDirection = _directionRepo.GetList().Find(_dir => _dir.Source.ID == 0);
            _testAlphabet.FriendlyName = _newName;
            _alphabetRepo.Update(_testAlphabet);
            _testDirection = _directionRepo.Get(_testDirection.ID);
            Assert.AreEqual(_newName, _testDirection.Source.FriendlyName);
        }

        [TestMethod]
        public void Update_AlphabetAndDirection()
        {
            var _xmlContext = new XmlContext(testAlphabetPath, testDirectionPath);
            var _alphabetRepo = _xmlContext.AlphabetRepository;
            var _directionRepo = _xmlContext.DirectionRepository;
            var _testAlphabet = _alphabetRepo.Get(0);
            var _testDirection = _directionRepo.GetList().Find(_dir => _dir.Source.ID != 0);
            var _newName = "Alphabet" + Guid.NewGuid();
            var _newPath = "Path" + Guid.NewGuid();
            _testAlphabet.FriendlyName = _newName;
            _alphabetRepo.Update(_testAlphabet);
            _testDirection.AssemblyPath = _newPath;
            _directionRepo.Update(_testDirection);
            var _updatedAlphabet = _alphabetRepo.Get(_testAlphabet.ID);
            Assert.AreEqual(_newName, _updatedAlphabet.FriendlyName);
            var _updatedDirection = _directionRepo.Get(_testDirection.ID);
            Assert.AreEqual(_newPath, _updatedDirection.AssemblyPath);
        }

        [TestMethod]
        public void SaveChanges_Twice()
        {
            var _xmlContext = new XmlContext(testAlphabetPath, testDirectionPath);
            var _alphabetRepo = _xmlContext.AlphabetRepository;
            var _count = _alphabetRepo.GetList().Count;
            var _newAlif = new Alphabet(-1, "Alphabet1");
            _alphabetRepo.Insert(_newAlif);
            _xmlContext.SaveChanges();
            Assert.AreEqual(_count + 1, _alphabetRepo.GetList().Count);
            _xmlContext.SaveChanges();
            var _checkRepo = new XmlContext(testAlphabetPath, testDirectionPath).AlphabetRepository;
            Assert.AreEqual(_count + 1, _checkRepo.GetList().Count);
        }

        [TestMethod]
        public void SaveChanges_ChangeID_Symbols()
        {
            var _instance1 = new XmlContext(currentDataFolder);
            var _name1 = "Alphabet1:" + Guid.NewGuid();
            var _symbol1 = new AlphabetSymbol("Symbol1:" + Guid.NewGuid());
            var _newAlif1 = new Alphabet(-1, _name1, CustomSymbols: new List<AlphabetSymbol> { _symbol1 });
            _instance1.AlphabetRepository.Insert(_newAlif1);
            var _id1 = _newAlif1.ID;
            var _instance2 = new XmlContext(currentDataFolder);
            var _checkAlif1 = _instance2.AlphabetRepository.Get(_id1);
            Assert.IsNull(_checkAlif1);
            _instance1.SaveChanges();
            var _name2 = "Alphabet2:" + Guid.NewGuid();
            var _symbol2 = new AlphabetSymbol("Symbol2:" + Guid.NewGuid());
            var _newAlif2 = new Alphabet(-1, _name2, CustomSymbols: new List<AlphabetSymbol> { _symbol2 });
            _instance2.AlphabetRepository.Insert(_newAlif2);
            var _id2 = _newAlif2.ID;
            Assert.AreEqual(_id1, _id2);
            _instance2.SaveChanges();

            var _checkInstance = new XmlContext(currentDataFolder);
            var _savedList = _checkInstance.AlphabetRepository.GetList();
            var _savedAlif1 = _savedList.Single(x => x.FriendlyName == _name1);
            var _savedAlif2 = _savedList.Single(x => x.FriendlyName == _name2);
            Assert.AreNotEqual(_savedAlif1.ID, _savedAlif2.ID);
            var _fullAlif1 = _checkInstance.AlphabetRepository.Get(_savedAlif1.ID);
            Assert.AreEqual(_symbol1.ActualText, _fullAlif1.CustomSymbols.Single().ActualText);
            var _fullAlif2 = _checkInstance.AlphabetRepository.Get(_savedAlif2.ID);
            Assert.AreEqual(_symbol2.ActualText, _fullAlif2.CustomSymbols.Single().ActualText);
        }

        [TestMethod]
        public void SaveChanges_ChangeID_Directions()
        {
            var _instance1 = new XmlContext(currentDataFolder);
            var _name1 = "Alphabet1:" + Guid.NewGuid();
            var _newAlif1 = new Alphabet(-1, _name1);
            _instance1.AlphabetRepository.Insert(_newAlif1);
            var _assembly1 = "Assembly1:" + Guid.NewGuid();
            var _direction1 = new Direction(-1, _newAlif1, _instance1.AlphabetRepository.Get(0), null, _assembly1);
            _instance1.DirectionRepository.Insert(_direction1);
            var _instance2 = new XmlContext(currentDataFolder);
            var _name2 = "Alphabet2:" + Guid.NewGuid();
            var _newAlif2 = new Alphabet(-1, _name2);
            _instance2.AlphabetRepository.Insert(_newAlif2);
            var _assembly2 = "Assembly2:" + Guid.NewGuid();
            var _direction2 = new Direction(-1, _newAlif2, _instance2.AlphabetRepository.Get(0), null, _assembly2);
            _instance2.DirectionRepository.Insert(_direction2);
            _instance1.SaveChanges();
            _instance2.SaveChanges();

            var _checkInstance = new XmlContext(currentDataFolder);
            var _savedList = _checkInstance.DirectionRepository.GetList();
            var _savedDirection1 = _savedList.Single(x => x.AssemblyPath == _assembly1);
            var _savedDirection2 = _savedList.Single(x => x.AssemblyPath == _assembly2);
            Assert.AreNotEqual(_savedDirection1.ID, _savedDirection2.ID);
            Assert.AreEqual(_name1, _savedDirection1.Source.FriendlyName);
            Assert.AreEqual(_name2, _savedDirection2.Source.FriendlyName);
        }

        [TestMethod]
        public void SaveChanges_ChangeID_Exclusions()
        {
            var _instance1 = new XmlContext(currentDataFolder);
            var _assembly1 = "Assembly1:" + Guid.NewGuid();
            var _exclusion1 = new Exclusion(Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), false, false, false);
            var _direction1 = new Direction(-1, _instance1.AlphabetRepository.Get(1), _instance1.AlphabetRepository.Get(0), new List<Exclusion> { _exclusion1 }, _assembly1);
            _instance1.DirectionRepository.Insert(_direction1);

            var _instance2 = new XmlContext(currentDataFolder);
            var _assembly2 = "Assembly2:" + Guid.NewGuid();
            var _exclusion2 = new Exclusion(Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), false, false, false);
            var _direction2 = new Direction(-1, _instance2.AlphabetRepository.Get(2), _instance2.AlphabetRepository.Get(0),  new List<Exclusion> { _exclusion2 }, _assembly2);
            _instance2.DirectionRepository.Insert(_direction2);

            _instance1.SaveChanges();
            _instance2.SaveChanges();

            var _checkInstance = new XmlContext(currentDataFolder);
            var _savedList = _checkInstance.DirectionRepository.GetList();
            var _savedDirection1 = _savedList.Single(x => x.AssemblyPath == _assembly1);
            var _savedDirection2 = _savedList.Single(x => x.AssemblyPath == _assembly2);
            var _fullDirection1 = _checkInstance.DirectionRepository.Get(_savedDirection1.ID);
            var _fullDirection2 = _checkInstance.DirectionRepository.Get(_savedDirection2.ID);
            Assert.AreEqual(_exclusion1, _fullDirection1.Exclusions.Single());
            Assert.AreEqual(_exclusion2, _fullDirection2.Exclusions.Single());
        }
    }
}
