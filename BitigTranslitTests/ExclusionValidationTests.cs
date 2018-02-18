using System;
using System.Collections.Generic;
using Bitig.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BitigLogicTests
{
    [TestClass]
    public class ExclusionValidationTests
    {
        class TestTranslitCommand : TranslitCommand
        {
        }

        [TestMethod]
        public void ConflictsWithExistingExclusions_MatchCase_WholeWord_Conflict()
        {
            var _word1 = "Source_word_" + Guid.NewGuid().ToString("N");
            var _word2 = "Target_word_" + Guid.NewGuid().ToString("N");
            var _exclusions = new List<Exclusion>
            {
                new Exclusion (_word1,_word2,true,false,false)
            };
            var _translitCommand = new TestTranslitCommand();
            _translitCommand.Exclusions = new ExclusionCollection(_exclusions);
            List<Exclusion> _conflicts;
            var _newExclusion = new Exclusion(_word1, null, true, false, false);
            var _hasConflicts = _translitCommand.ConflictsWithExistingExclusions(_newExclusion, out _conflicts);
            Assert.IsTrue(_hasConflicts);
            Assert.AreEqual(1, _conflicts.Count);
            Assert.AreEqual(_word1, _conflicts[0].SourceWord);
        }

        [TestMethod]
        public void ConflictsWithExistingExclusions_MatchCase_WholeWord_NoConflict()
        {
            var _word1 = "Source_word_" + Guid.NewGuid().ToString("N").ToUpperInvariant();
            var _word2 = "Target_word_" + Guid.NewGuid().ToString("N");
            var _exclusions = new List<Exclusion>
            {
                new Exclusion (_word1,_word2,true,false,false)
            };
            var _conflicting1 = _word1 + Guid.NewGuid().ToString("N");
            var _conflictingExcl1 = new Exclusion(_conflicting1, null, true, false, false);
            var _conflicting2 = _word1.ToLowerInvariant();
            var _conflictingExcl2 = new Exclusion(_conflicting2, null, true, false, false);
            var _translitCommand = new TestTranslitCommand();
            _translitCommand.Exclusions = new ExclusionCollection(_exclusions);
            List<Exclusion> _conflicts;
            var _hasConflicts = _translitCommand.ConflictsWithExistingExclusions(_conflictingExcl1,  out _conflicts);
            Assert.IsFalse(_hasConflicts);
            _hasConflicts = _translitCommand.ConflictsWithExistingExclusions(_conflictingExcl2, out _conflicts);
            Assert.IsFalse(_hasConflicts);
        }

        [TestMethod]
        public void ConflictsWithExistingExclusions_IgnoreCase_WholeWord_Conflict()
        {
            var _word1 = "Source_word_" + Guid.NewGuid().ToString("N").ToUpperInvariant();
            var _word2 = "Target_word_" + Guid.NewGuid().ToString("N");
            var _exclusions = new List<Exclusion>
            {
                new Exclusion (_word1,_word2,false,false,false)
            };
            var _translitCommand = new TestTranslitCommand();
            _translitCommand.Exclusions = new ExclusionCollection(_exclusions);
            var _conflicting = _word1.ToLowerInvariant();
            var _conflictingExcl = new Exclusion(_conflicting, null, false, false, false);
            List<Exclusion> _conflicts;
            var _hasConflicts = _translitCommand.ConflictsWithExistingExclusions(_conflictingExcl, out _conflicts);
            Assert.IsTrue(_hasConflicts);
            Assert.AreEqual(1, _conflicts.Count);
            Assert.AreEqual(_word1, _conflicts[0].SourceWord);
        }

        [TestMethod]
        public void ConflictsWithExistingExclusions_MatchCase_WordStart_Conflict()
        {
            var _word1 = "Source_word_" + Guid.NewGuid().ToString("N");
            var _word2 = "Target_word_" + Guid.NewGuid().ToString("N");
            var _exclusions = new List<Exclusion>
            {
                new Exclusion (_word1,_word2,true,true,false)
            };
            var _conflicting = _word1 + Guid.NewGuid().ToString("N");
            var _conflictingExcl = new Exclusion(_conflicting, null, true, true, false);
            var _translitCommand = new TestTranslitCommand();
            _translitCommand.Exclusions = new ExclusionCollection(_exclusions);
            List<Exclusion> _conflicts;
            var _hasConflicts = _translitCommand.ConflictsWithExistingExclusions(_conflictingExcl, out _conflicts);
            Assert.IsTrue(_hasConflicts);
            Assert.AreEqual(1, _conflicts.Count);
            Assert.AreEqual(_word1, _conflicts[0].SourceWord);
        }

        [TestMethod]
        public void ConflictsWithExistingExclusions_MatchCase_WordStart_NoConflict()
        {
            var _word1 = "Source_word_" + Guid.NewGuid().ToString("N");
            var _word2 = "Target_word_" + Guid.NewGuid().ToString("N");
            var _exclusions = new List<Exclusion>
            {
                new Exclusion (_word1,_word2,true,true,false)
            };
            var _conflicting =  Guid.NewGuid().ToString("N") + _word1;
            var _conflictingExcl = new Exclusion(_conflicting, null, true, true, false);
            var _translitCommand = new TestTranslitCommand();
            _translitCommand.Exclusions = new ExclusionCollection(_exclusions);
            List<Exclusion> _conflicts;
            var _hasConflicts = _translitCommand.ConflictsWithExistingExclusions(_conflictingExcl, out _conflicts);
            Assert.IsFalse(_hasConflicts);
        }

        [TestMethod]
        public void ConflictsWithExistingExclusions_IgnoreCase_AnyPosition_Conflict()
        {
            var _word1 = "Source_word_" + Guid.NewGuid().ToString("N").ToUpperInvariant();
            var _word2 = "Target_word_" + Guid.NewGuid().ToString("N");
            var _exclusions = new List<Exclusion>
            {
                new Exclusion (_word1,_word2,false,false,true)
            };
            var _conflicting = Guid.NewGuid().ToString("N") + _word1.ToLowerInvariant() + Guid.NewGuid().ToString("N");
            var _conflictingExcl = new Exclusion(_conflicting, null, false, false, true);
            var _translitCommand = new TestTranslitCommand();
            _translitCommand.Exclusions = new ExclusionCollection(_exclusions);
            List<Exclusion> _conflicts;
            var _hasConflicts = _translitCommand.ConflictsWithExistingExclusions(_conflictingExcl, out _conflicts);
            Assert.IsTrue(_hasConflicts);
            Assert.AreEqual(1, _conflicts.Count);
            Assert.AreEqual(_word1, _conflicts[0].SourceWord);
        }

        [TestMethod]
        public void ConflictsWithExisitngExclusion_IgnoreCase_WordStart_Conflict()
        {
            var _word1 = "sss";
            var _word2 = "target1";
            var _exclusions = new List<Exclusion>
            {
                new Exclusion (_word1,_word2,true,true,false)
            };
            var _conflicting = "sss1";
            var _conflictingExcl = new Exclusion(_conflicting, "target2", false, true, false);
            var _translitCommand = new TestTranslitCommand();
            _translitCommand.Exclusions = new ExclusionCollection(_exclusions);
            List<Exclusion> _conflicts;
            var _hasConflicts = _translitCommand.ConflictsWithExistingExclusions(_conflictingExcl, out _conflicts);
            Assert.IsTrue(_hasConflicts);
            Assert.AreEqual(1, _conflicts.Count);
            Assert.AreEqual(_word1, _conflicts[0].SourceWord);
        }
    }
}
