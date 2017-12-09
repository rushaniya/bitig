using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bitig.Logic.Commands;

namespace BitigTranslitTests
{
    [TestClass]
    public class YanalifZamanalifTester
    {
        private Dictionary<string, string> testPairs = new Dictionary<string, string>();

        public YanalifZamanalifTester()
        {
            testPairs.Add("s\u0259lam", "sälam");
            testPairs.Add("barıyq", "baríq");
            testPairs.Add("BARIYQ", "BARÍQ");
            testPairs.Add("Barıyq", "Baríq");
            testPairs.Add("Iyqla", "Íqla");
            testPairs.Add("Barıyq iy\u0259", "Baríq iä");
            testPairs.Add("QARIYBIZ", "QARÍBIZ");
        }

        [TestMethod]
        public void YanalifZamanalifTestTranslit()
        {
            var translitCommand = new YanalifZamanalif();
            foreach (var pair in testPairs)
            {
                var result = translitCommand.Convert(pair.Key);
                Assert.AreEqual(pair.Value, result);
            }
        }
    }
}
