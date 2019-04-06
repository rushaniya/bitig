using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Bitig.Base;
using Bitig.Data.Storage;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BitigDataTests
{
    [TestClass]
    public class XmlKeyboardRepoTests
    {
        private const string preparedDataFolder = @"TestData\Prepared\";
        private const string currentDataFolder = @"KeyboardsTestData\";
        private readonly string preparedFile = @"Keyboards\333.xml";
        private readonly string preparedSummaryFile = @"KeyboardSummaries.xml";

        [TestInitialize]
        [TestCleanup]
        public void PrepareFiles()
        {
            if (Directory.Exists(currentDataFolder))
                Directory.Delete(currentDataFolder, true);
            Directory.CreateDirectory(currentDataFolder);
            Directory.CreateDirectory(currentDataFolder + "Keyboards");
            File.Copy(preparedDataFolder + preparedFile, currentDataFolder + preparedFile);
            File.Copy(preparedDataFolder + preparedSummaryFile, currentDataFolder + preparedSummaryFile);
        }

        [TestMethod]
        public void GetKeyboardConfig()
        {
            var _context = new XmlContext(currentDataFolder);
            var _repository = new XmlKeyboardRepository(_context);
            var _keyboard = _repository.GetKeyboardConfig(333) as KeyboardLayout;
            Assert.IsNotNull(_keyboard);
            Assert.AreEqual("TestConfig333", _keyboard.FriendlyName);
            Assert.AreEqual(333, _keyboard.ID);
            Assert.AreEqual(3, _keyboard.KeyCombinations.Count);

            var _combination1 = _keyboard.KeyCombinations[0];
            Assert.AreEqual("1", _combination1.MainKey);
            Assert.AreEqual("!", _combination1.Result);
            Assert.IsTrue(_combination1.WithAlt);
            Assert.IsFalse(_combination1.WithAltGr);
            Assert.IsFalse(_combination1.WithCtrl);
            Assert.IsTrue(_combination1.WithShift);

            var _combination2 = _keyboard.KeyCombinations[1];
            Assert.AreEqual("C", _combination2.MainKey);
            Assert.AreEqual("ç", _combination2.Result);
            Assert.AreEqual("Ç", _combination2.Capital);
            Assert.IsFalse(_combination2.WithAlt);
            Assert.IsTrue(_combination2.WithAltGr);
            Assert.IsFalse(_combination2.WithCtrl);
            Assert.IsFalse(_combination2.WithShift);

            var _combination3 = _keyboard.KeyCombinations[2];
            Assert.AreEqual("R", _combination3.MainKey);
            Assert.AreEqual("Enter", _combination3.Result);
            Assert.IsFalse(_combination3.WithAlt);
            Assert.IsFalse(_combination3.WithAltGr);
            Assert.IsFalse(_combination3.WithCtrl);
            Assert.IsFalse(_combination3.WithShift);
        }

        [TestMethod]
        public void GetSummary()
        {
            var _context = new XmlContext(currentDataFolder);
            var _repository = new XmlKeyboardRepository(_context);
            var _summary = _repository.GetSummary(444);
            Assert.IsNotNull(_summary);
            Assert.AreEqual("TestConfig444", _summary.FriendlyName);
        }

        [TestMethod]
        public void GetSummaryList()
        {
            var _context = new XmlContext(currentDataFolder);
            var _repository = new XmlKeyboardRepository(_context);
            var _summaries = _repository.GetSummaryList();
            Assert.AreEqual(2, _summaries.Count);
            Assert.AreEqual(333, _summaries[0].ID);
            Assert.AreEqual(444, _summaries[1].ID);
        }
    }
}
