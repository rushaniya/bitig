using System;
using System.Collections.Generic;
using System.Drawing;
using Bitig.Logic.Model;
using Bitig.Logic.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BitigDataTests
{
    [TestClass]
    public class AlifbaTests
    {
        [TestMethod]
        public void EqualsByID()
        {
            var _name1 = "Test name " + Guid.NewGuid();
            var _alifba1 = new Alifba(1, _name1, null, false, new AlifbaFont("Times", 20));
            var _alifba2 = _alifba1.Clone();
            var _alifba3 = new Alifba(2, _name1, null, false, new AlifbaFont("Times", 20));
            var _alifba4 = new Alifba(1, "Another name", null, true, new AlifbaFont("Arial", 24));
            Assert.AreEqual(_alifba1, _alifba2);
            Assert.AreEqual(_alifba1, _alifba4);
            Assert.AreEqual(_alifba2, _alifba4);
            Assert.AreNotEqual(_alifba1, _alifba3);
            Assert.AreNotEqual(_alifba2, _alifba3);
            Assert.AreNotEqual(_alifba3, _alifba4);
        }

        [TestMethod]
        public void Clone()
        {
            var _name1 = "Test name " + Guid.NewGuid();
            var _symbolText1 = Guid.NewGuid().ToString();
            var _symbols = new List<AlifbaSymbol>
            {
                new AlifbaSymbol(_symbolText1)
            };
            var _alifba1 = new Alifba(1, _name1, _symbols, false, new AlifbaFont("Times", 20));
            var _alifba2 = _alifba1.Clone();
            _alifba1.ID = 2;
            _alifba1.FriendlyName = "New name";
            _alifba1.RightToLeft = true;
            _alifba1.CustomSymbols[0] = new AlifbaSymbol("New symbol");
            _alifba1.CustomSymbols.Add(new AlifbaSymbol("Second symbol"));
            _alifba1.DefaultFont = new AlifbaFont("Arial", 36);
            Assert.AreEqual(1, _alifba2.ID);
            Assert.AreEqual(_name1, _alifba2.FriendlyName);
            Assert.AreEqual(1, _alifba2.CustomSymbols.Count);
            Assert.AreEqual(_symbolText1, _alifba2.CustomSymbols[0].ActualText);
            using (var _font = (Font)_alifba2.DefaultFont)
            {
                Assert.IsTrue(_font.OriginalFontName.StartsWith("Times"));
                Assert.AreEqual(20, _font.Size);
            }
        }
    }
}
