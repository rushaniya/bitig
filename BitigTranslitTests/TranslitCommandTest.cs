using Bitig.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace BitigTranslitTests
{
    [TestClass()]
    public class TranslitCommandTest
    {
        class NonAlphabetTranslitCommand : SubstituteTranslitCommand
        {
            private Dictionary<string, string> translitTable;
            private void FillTranslitTable()
            {
                translitTable = new Dictionary<string, string>();
                translitTable.Add("A", "1");
                translitTable.Add("B", "2");
                translitTable.Add("z", "26");
                translitTable.Add("!", "?");
                translitTable.Add("(", ")");
                translitTable.Add("-", "_");
            }

            protected override Dictionary<string, string> TranslitTable
            {
                get { return translitTable; }
            }

            public NonAlphabetTranslitCommand()
            {
                AlphabetPattern = @"A-Za-z,()-";
                FillTranslitTable();
                IgnoreCase = true;
            }
        }

        class MultiSymbolTranslitCommand : SubstituteTranslitCommand
        {
            private Dictionary<string, string> translitTable;
            private void FillTranslitTable()
            {
                translitTable = new Dictionary<string, string>();
                translitTable.Add("11", "A");
                translitTable.Add("22", "B");
                translitTable.Add("33", "CD");
                translitTable.Add("45", "E");
                translitTable.Add("6", "F");
            }

            protected override Dictionary<string, string> TranslitTable
            {
                get { return translitTable; }
            }

            public MultiSymbolTranslitCommand()
            {
                AlphabetPattern = @"123456";
                FillTranslitTable();
                IgnoreCase = true;
            }
        }

        class MultiSymbolTranslitCommand_NoLengthOfOne : SubstituteTranslitCommand
        {
            private Dictionary<string, string> translitTable;
            private void FillTranslitTable()
            {
                translitTable = new Dictionary<string, string>();
                translitTable.Add("11", "A");
                translitTable.Add("22", "B");
                translitTable.Add("33", "CD");
                translitTable.Add("45", "E");
            }

            protected override Dictionary<string, string> TranslitTable
            {
                get { return translitTable; }
            }

            public MultiSymbolTranslitCommand_NoLengthOfOne()
            {
                AlphabetPattern = @"12345";
                FillTranslitTable();
                IgnoreCase = true;
            }
        }

        class NonAlphabeticChainedCommand : TranslitCommand
        {
            public NonAlphabeticChainedCommand()
            {
                AlphabetPattern = @"A-Za-z,()-";
                ChainedCommands = new List<TranslitCommand> { new NonAlphabetTranslitCommand(), new ChainCommand1() };
            }
        }

        class ChainCommand1 : SubstituteTranslitCommand
        {
            private Dictionary<string, string> translitTable;
            private void FillTranslitTable()
            {
                translitTable = new Dictionary<string, string>();
                translitTable.Add("1", "!");
                translitTable.Add("2", "@");
                translitTable.Add("6", "^");
                translitTable.Add("?", "&");
                translitTable.Add("!", "%");
                translitTable.Add("D", "$");
            }

            protected override Dictionary<string, string> TranslitTable
            {
                get { return translitTable; }
            }

            public ChainCommand1()
            {
                AlphabetPattern = @"126?Dd,)";
                FillTranslitTable();
                this.Exclusions.Add("226", "337", false, false, false);
            }
        }

        [TestMethod()]
        public void ChainConvertTest()
        {
            var target = new NonAlphabeticChainedCommand();

            var testPairs = new Dictionary<string, string>();

            testPairs.Add("AB ab Zz dD, () !.", "!@ !@ @^@^ d$, )) !.");

            target.Exclusions.Add("Dd", "?", true, false, false);
            testPairs.Add(" Dd,", " $d,");
            testPairs.Add(" Dd ", " ? ");

            testPairs.Add(" BZ ", " 337 ");
            testPairs.Add(" (BZ ", " )@@^ ");

            foreach (var item in testPairs)
            {
                var result = target.Convert(item.Key);
                Assert.AreEqual(item.Value, result);
            }
        }

        [TestMethod()]
        public void ConvertTest()
        {
            var target = new NonAlphabetTranslitCommand();

            var testPairs = new Dictionary<string, string>();

            testPairs.Add("AB ab Zz d, !.-", "12 12 2626 d, ?._");

            target.Exclusions.Add("ABB", "case,whole", true, false, false);
            testPairs.Add("ABB", "case,whole");
            testPairs.Add("abb", "122");
            testPairs.Add("AB", "12");
            testPairs.Add("DABB", "D122");
            testPairs.Add(",ABB", ",122");
            testPairs.Add(".ABB", ".case,whole");
            testPairs.Add("!ABB", "?case,whole");
            testPairs.Add("ABBD", "122D");
            testPairs.Add("ABB,", "122,");
            testPairs.Add("ABB.", "case,whole.");
            testPairs.Add("ABB!", "case,whole?");

            //todo: chain commands

            foreach (var item in testPairs)
            {
                var result = target.Convert(item.Key);
                Assert.AreEqual(item.Value, result);
            }
        }

        [TestMethod]
        public void NotTranslittedSymbols()
        {
            var _command = new NonAlphabetTranslitCommand();
            var _testPairs = new Dictionary<string, string>();
            _testPairs.Add("CD.", "CD."); //symbols C and D are within AlphabetPattern
            _testPairs.Add("@$.", "@$."); //symbols @ and $ are not within AlphabetPattern
            _testPairs.Add("z!C", "26?C");
            _testPairs.Add("z!$", "26?$");

            foreach (var _pair in _testPairs)
            {
                var result = _command.Convert(_pair.Key);
                Assert.AreEqual(_pair.Value, result);
            }
        }

        [TestMethod]
        public void MultiSymbolConvertTest()
        {
            var _command = new MultiSymbolTranslitCommand();
            var _testPairs = new Dictionary<string, string>();
            _testPairs.Add("221133", "BACD");
            _testPairs.Add("2211332", "BACD2");
            _testPairs.Add("221133!", "BACD!");
            _testPairs.Add("22112456", "BA2EF");

            foreach (var _pair in _testPairs)
            {
                var result = _command.Convert(_pair.Key);
                Assert.AreEqual(_pair.Value, result);
            }
        }

        [TestMethod]
        public void MultiSymbolConvertTest_NoLengthOfOne()
        {
            var _command = new MultiSymbolTranslitCommand_NoLengthOfOne();
            var _testPairs = new Dictionary<string, string>();
            _testPairs.Add("221133", "BACD");
            _testPairs.Add("2211332", "BACD2");
            _testPairs.Add("221133!", "BACD!");
            _testPairs.Add("22112456", "BA2E6");

            foreach (var _pair in _testPairs)
            {
                var result = _command.Convert(_pair.Key);
                Assert.AreEqual(_pair.Value, result);
            }
        }
    }
}
