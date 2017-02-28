using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bitig.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BitigTranslitTests
{
    public class GenericTranslitCommandTester<T> where T : TranslitCommand, new()
    {
        protected Dictionary<string, string> testPairs = new Dictionary<string, string>();
        protected ExclusionCollection exclusions = new ExclusionCollection();

        protected void TestTranslit()
        {
            var translitCommand = new T();
            foreach (var excl in exclusions)
            {
                translitCommand.Exclusions.Add(excl);
            }
            foreach (var pair in testPairs)
            {
                var result = translitCommand.Convert(pair.Key);
                Assert.AreEqual(pair.Value, result);
            }
        }
    }
}
