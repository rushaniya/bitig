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
            var _translitDictionary = new Dictionary<TextSymbol, TextSymbol>
            {
                { new TextSymbol("1"), new TextSymbol("a") },
                { new TextSymbol("2"), new TextSymbol("b") },
                { new TextSymbol("3"), new TextSymbol("c") }
            };
            var _command = new ConfigurableTranslitCommand(_translitDictionary);
            var _translitResult = _command.Convert("2132");
            Assert.AreEqual("bacb", _translitResult);
        }

        [TestMethod]
        public void Transliteration_UpperLower()
        {
            var _translitDictionary = new Dictionary<TextSymbol, TextSymbol>
            {
                { new TextSymbol("1", "2"), new TextSymbol("a", "A") },
                { new TextSymbol("3", "4"), new TextSymbol("b", "B") },
                { new TextSymbol("5", "6"), new TextSymbol("c", "C") }
            };
            var _command = new ConfigurableTranslitCommand(_translitDictionary);
            var _translitResult = _command.Convert("2132");
            //not AabA because of MimicCapitals
            Assert.AreEqual("Aaba", _translitResult);
        }

        [TestMethod]
        public void Transliteration_ChangeCase()
        {
            var _translitDictionary = new Dictionary<TextSymbol, TextSymbol>
            {
                { new TextSymbol("a", "b"), new TextSymbol("1", "2") },
                { new TextSymbol("c", "d"), new TextSymbol("3", "4") },
                { new TextSymbol("e", "f"), new TextSymbol("13") }
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
            var _translitDictionary = new Dictionary<TextSymbol, TextSymbol>
            {
                { new TextSymbol("1", "!"), new TextSymbol("a") },
                { new TextSymbol("2", "@"), new TextSymbol("b") },
                { new TextSymbol("3", "."), new TextSymbol("c") }
            };
            var _command = new ConfigurableTranslitCommand(_translitDictionary);
            Assert.IsTrue(_command.IsAlphabetic("123!@."));
            Assert.IsFalse(_command.IsAlphabetic("abc"));
        }

        [TestMethod]
        public void Unicode()
        {
            var _translitDictionary = new Dictionary<TextSymbol, TextSymbol>
            {
                { new TextSymbol("\u0627"), new TextSymbol("a") },
                { new TextSymbol("\uFE8F"), new TextSymbol("b") }
            };
            var _command = new ConfigurableTranslitCommand(_translitDictionary);
            Assert.IsTrue(_command.IsAlphabetic("\u0627\ufe8f"));
        }

        [TestMethod]
        public void InitFromDirection()
        {
            var _translitDictionary = new Dictionary<TextSymbol, TextSymbol>
            {
                { new TextSymbol("1"), new TextSymbol("a") },
                { new TextSymbol("2"), new TextSymbol("b") },
                { new TextSymbol("3"), new TextSymbol("c") }
            };
            var _command = new ManualCommand(_translitDictionary);
            var _direction = new Direction(-1, null, null, null, ManualCommand: _command);
            var _translitResult = _direction.Transliterate("2132");
            Assert.AreEqual("bacb", _translitResult);
        }

        [TestMethod]
        public void MultiLetterKeys_DifferentLengths()
        {
            var _translitDictionary = new Dictionary<TextSymbol, TextSymbol>
            {
                { new TextSymbol("11"), new TextSymbol("A") },
                { new TextSymbol("22"), new TextSymbol("B") },
                { new TextSymbol("33"), new TextSymbol("C") },
                { new TextSymbol("45"), new TextSymbol("D") },
                { new TextSymbol("6"), new TextSymbol("E") },
                { new TextSymbol("777"), new TextSymbol("F") },
            };
            var _command = new ConfigurableTranslitCommand(_translitDictionary);
            var _translitResult = _command.Convert("22113324567773");
            Assert.AreEqual("BAC2DEF3", _translitResult);
        }

        [TestMethod]
        public void MultiLetterKeys_SameLengths()
        {
            var _translitDictionary = new Dictionary<TextSymbol, TextSymbol>
            {
                { new TextSymbol("11"), new TextSymbol("A") },
                { new TextSymbol("22"), new TextSymbol("B") },
                { new TextSymbol("33"), new TextSymbol("C") },
                { new TextSymbol("45"), new TextSymbol("D") },
            };
            var _command = new ConfigurableTranslitCommand(_translitDictionary);
            var _translitResult = _command.Convert("2211332453");
            Assert.AreEqual("BAC2D3", _translitResult);
        }
    }
}
