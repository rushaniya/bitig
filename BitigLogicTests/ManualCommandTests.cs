using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bitig.Logic.Commands;
using Bitig.Logic.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BitigLogicTests
{
    [TestClass]
    public class ManualCommandTests
    {
        [TestMethod]
        public void BasicTransliteration()
        {
            var _translitDictionary = new Dictionary<AlifbaSymbol, AlifbaSymbol>
            {
                { new AlifbaSymbol("1"), new AlifbaSymbol("a") },
                { new AlifbaSymbol("2"), new AlifbaSymbol("b") },
                { new AlifbaSymbol("3"), new AlifbaSymbol("c") }
            };
            var _command = new ConfigurableTranslitCommand(_translitDictionary);
            var _translitResult = _command.Convert("2132");
            Assert.AreEqual("bacb", _translitResult);
        }

        [TestMethod]
        public void Transliteration_UpperLower()
        {
            var _translitDictionary = new Dictionary<AlifbaSymbol, AlifbaSymbol>
            {
                { new AlifbaSymbol("1", "2"), new AlifbaSymbol("a", "A") },
                { new AlifbaSymbol("3", "4"), new AlifbaSymbol("b", "B") },
                { new AlifbaSymbol("5", "6"), new AlifbaSymbol("c", "C") }
            };
            var _command = new ConfigurableTranslitCommand(_translitDictionary);
            var _translitResult = _command.Convert("2132");
            Assert.AreEqual("AabA", _translitResult);
        }

        [TestMethod]
        public void Transliteration_ChangeCase()
        {
            var _translitDictionary = new Dictionary<AlifbaSymbol, AlifbaSymbol>
            {
                { new AlifbaSymbol("a", "b"), new AlifbaSymbol("1", "2") },
                { new AlifbaSymbol("c", "d"), new AlifbaSymbol("3", "4") },
                { new AlifbaSymbol("e", "f"), new AlifbaSymbol("13") }
            };
            var _command = new ConfigurableTranslitCommand(_translitDictionary);
            var _firstCapital = _command.Convert("fe");
            Assert.AreEqual("2313", _firstCapital);            
            var _allCapitals = _command.Convert("fd");
            Assert.AreEqual("244", _allCapitals);            
        }

        [TestMethod]
        public void AlphabetPattern()
        {
            var _translitDictionary = new Dictionary<AlifbaSymbol, AlifbaSymbol>
            {
                { new AlifbaSymbol("1", "!"), new AlifbaSymbol("a") },
                { new AlifbaSymbol("2", "@"), new AlifbaSymbol("b") },
                { new AlifbaSymbol("3", "."), new AlifbaSymbol("c") }
            };
            var _command = new ConfigurableTranslitCommand(_translitDictionary);
            Assert.IsTrue(_command.IsAlphabetic("123!@."));
            Assert.IsFalse(_command.IsAlphabetic("abc"));
        }

        [TestMethod]
        public void Unicode()
        {
            var _translitDictionary = new Dictionary<AlifbaSymbol, AlifbaSymbol>
            {
                { new AlifbaSymbol("\u0627"), new AlifbaSymbol("a") },
                { new AlifbaSymbol("\uFE8F"), new AlifbaSymbol("b") }
            };
            var _command = new ConfigurableTranslitCommand(_translitDictionary);
            Assert.IsTrue(_command.IsAlphabetic("\u0627\ufe8f"));
        }
    }
}
