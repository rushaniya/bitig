using System;
using System.Collections.Generic;
using System.IO;
using Bitig.Logic.Commands;
using Bitig.Logic.Model;
using Bitig.Logic.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace BitigLogicTests
{
    [TestClass]
    public class TranslitCommandTests
    {
        private const string dataFolder = @"..\..\..\BitigLogicTests\TestData\";

        [TestMethod]
        public void Init_BuiltIn()
        {
            var _source = new Alphabet(-1, "test");
            var _target = new Alphabet(-2, "test");
            var _builtIn = BuiltInTransliteration.GetBuiltInDirection(BuiltInAlphabetType.Cyrillic, BuiltInAlphabetType.Rasmalif);
            var _cyrRasm = new Direction(-1, _source, _target, null, BuiltInType: _builtIn.Type);
            Assert.IsInstanceOfType(_cyrRasm.TranslitCommand, typeof(CyrillicRasmalif));
            var _result = _cyrRasm.Transliterate("сәлам");
            Assert.AreEqual("sälam", _result);
        }

        [TestMethod]
        public void Init_External()
        {
            var _source = new Alphabet(-1, "test");
            var _target = new Alphabet(-2, "test");
            var _assembly = Path.Combine(dataFolder, "KupiSlona.dll");
            var _type = "KupiSlona.KupiSlona";
            var _direction = new Direction(-1, _source, _target, null, _assembly, _type);
            Assert.IsNotNull(_direction.TranslitCommand);
            var _result = _direction.Transliterate("hello");
            Assert.AreEqual("Все говорят hello, а ты купи слона", _result);
        }

        [TestMethod]
        public void Exclusions_BuiltIn()
        {
            var _source = new Alphabet(-1, "test");
            var _target = new Alphabet(-2, "test");
            var _builtIn = BuiltInTransliteration.GetBuiltInDirection(BuiltInAlphabetType.Cyrillic, BuiltInAlphabetType.Rasmalif);
            var _word1 = "Source word " + Guid.NewGuid();
            var _word2 = "Target word " + Guid.NewGuid();
            var _exclusions = new List<Exclusion>
            {
                new Exclusion {MatchCase = true, SourceWord = _word1, TargetWord = _word2 }
            };
            var _cyrRasm = new Direction(-1, _source, _target, _exclusions, BuiltInType: _builtIn.Type);
            var _commandExclusions = _cyrRasm.TranslitCommand.Exclusions;
            Assert.IsNotNull(_commandExclusions);
            Assert.IsTrue(_commandExclusions.Any(_excl => 
                _excl.MatchCase && _excl.SourceWord == _word1 && _excl.TargetWord == _word2));
        }

        [TestMethod]
        public void Exclusions_External()
        {
            var _source = new Alphabet(-1, "test");
            var _target = new Alphabet(-2, "test");
            var _assembly = Path.Combine(dataFolder, "KupiSlona.dll");
            var _type = "KupiSlona.KupiSlona";
            var _word1 = "Source word " + Guid.NewGuid();
            var _word2 = "Target word " + Guid.NewGuid();
            var _exclusions = new List<Exclusion>
            {
                new Exclusion {MatchCase = true, SourceWord = _word1, TargetWord = _word2 }
            };
            var _direction = new Direction(-1, _source, _target, _exclusions, _assembly, _type);
            var _commandExclusions = _direction.TranslitCommand.Exclusions;
            Assert.IsNotNull(_commandExclusions);
            Assert.IsTrue(_commandExclusions.Any(_excl =>
                _excl.MatchCase && _excl.SourceWord == _word1 && _excl.TargetWord == _word2));
        }
    }
}
