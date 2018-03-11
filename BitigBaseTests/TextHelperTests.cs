using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bitig.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BitigBaseTests
{
    [TestClass]
    public class TextHelperTests
    {
        [TestMethod]
        public void ToUpper()
        {
            var _customPairs = new Dictionary<char, char> { { 'a', 'b' }, { 'c', 'd' } };
            var _upper = TextHelper.ToUpper("abcdeF", _customPairs);
            Assert.AreEqual("aaccEF", _upper);
        }

        [TestMethod]
        public void ToLower()
        {
            var _customPairs = new Dictionary<char, char> { { 'a', 'b' }, { 'c', 'd' } };
            var _lower = TextHelper.ToLower("abcdeF", _customPairs);
            Assert.AreEqual("bbddef", _lower);
        }

        [TestMethod]
        public void CharToUpper()
        {
            var _customPairs = new Dictionary<char, char> { { 'a', 'b' }, { 'c', 'd' } };
            var _upper = TextHelper.ToUpper('a', _customPairs);
            Assert.AreEqual('a', _upper);
            _upper = TextHelper.ToUpper('b', _customPairs);
            Assert.AreEqual('a', _upper);
            _upper = TextHelper.ToUpper('z', _customPairs);
            Assert.AreEqual('Z', _upper);
        }

        [TestMethod]
        public void CharToLower()
        {
            var _customPairs = new Dictionary<char, char> { { 'a', 'b' }, { 'c', 'd' } };
            var _lower = TextHelper.ToLower('a', _customPairs);
            Assert.AreEqual('b', _lower);
            _lower = TextHelper.ToLower('b', _customPairs);
            Assert.AreEqual('b', _lower);
            _lower = TextHelper.ToLower('Z', _customPairs);
            Assert.AreEqual('z', _lower);
        }
    }
}
