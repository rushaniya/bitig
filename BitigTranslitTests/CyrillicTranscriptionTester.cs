using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bitig.Logic.Commands;
using System;

namespace BitigTranslitTests
{
    /// <summary>
    /// Summary description for CyrillicTranscriptionTester
    /// </summary>
    [TestClass]
    public class CyrillicTranscriptionTester : GenericTranslitCommandTester<CyrillicTranscription>
    {
        public CyrillicTranscriptionTester()
        {
            testPairs.Add("зыян", "zi:ya:n");
            testPairs.Add("Щапов урамы", "S'a:po:v u:ra:me:");
            testPairs.Add("ЩАПОВ УРАМЫ", "S'A:PO:V U:RA:ME:");
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

        [TestMethod]
        public void RunCyrillicTranscriptionTest()
        {
            base.TestTranslit();
        }

        [TestMethod]
        public void ExclusionPriority()
        {
            var _translitCommand = new CyrillicYanalif();
            var _targetWord = "target word " + Guid.NewGuid();
            _translitCommand.Exclusions.Add("колхоз", _targetWord, false, true, false);
            var _result = _translitCommand.Convert("колхоз");
            Assert.AreEqual(_targetWord, _result);
        }
    }
}
