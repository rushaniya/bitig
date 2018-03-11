using System;
using System.Collections.Generic;
using Bitig.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BitigBaseTests
{
    [TestClass]
    public class IgnoreCaseComparerTests
    {
        [TestMethod]
        public void IgnoreCaseDictionary()
        {
            var _customPairs = new Dictionary<char, char> { { 'a', 'b' }, { 'c', 'd' } };
            var _comparer = new IgnoreCaseComparer(_customPairs);
            var _dictionary = new Dictionary<string, string>(_comparer);
            _dictionary.Add("b", "1");
            _dictionary.Add("c", "2");
            Assert.IsTrue(_dictionary.ContainsKey("a"));
            Assert.AreEqual("1", _dictionary["a"]);
            Assert.IsTrue(_dictionary.ContainsKey("b"));
            Assert.AreEqual("1", _dictionary["b"]);
            Assert.IsTrue(_dictionary.ContainsKey("d"));
            Assert.AreEqual("2", _dictionary["d"]);
            Assert.IsTrue(_dictionary.ContainsKey("c"));
            Assert.AreEqual("2", _dictionary["c"]);
        }
    }
}
