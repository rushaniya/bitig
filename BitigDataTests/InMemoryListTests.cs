using System.Collections.Generic;
using System.Linq;
using Bitig.Data.Model;
using Bitig.Logic.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BitigDataTests
{
    [TestClass]
    public class InMemoryListTests
    {
        [TestMethod]
        public void ApplyChanges()
        {
            var _persistentList = new List<XmlAlphabet>
            {
                new XmlAlphabet (0, "Unmodified"),
                new XmlAlphabet (1, "Deleted"),
                new XmlAlphabet (2, "Updated")
            };
            var _inMemoryList = new InMemoryList<XmlAlphabet>(_persistentList);
            _inMemoryList.Insert(new XmlAlphabet(-1, "Added"));
            _inMemoryList.Delete(1);
            _inMemoryList.Update(new XmlAlphabet(2, "Updated1"));
            var _mergeResult = _inMemoryList.ApplyChanges(_persistentList);
            Assert.AreEqual(3, _mergeResult.Count);
            var _unmodified = _mergeResult.Single(x => x.ID == 0 && x.FriendlyName == "Unmodified");
            var _updated = _mergeResult.Single(x => x.ID == 2 && x.FriendlyName == "Updated1");
            var _added = _mergeResult.Single(x => x.FriendlyName == "Added");
        }
    }
}