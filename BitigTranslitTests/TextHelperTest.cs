using Bitig.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace BitigTranslitTests
{
    
    
    /// <summary>
    ///This is a test class for TextHelperTest and is intended
    ///to contain all TextHelperTest Unit Tests
    ///</summary>
    [TestClass()]
    public class TextHelperTest
    {
        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for DefineCapitals
        ///</summary>
        [TestMethod()]
        public void DefineCapitalsTestCustomPairs()
        {
            IEnumerable<char> UpperChars = new List<char> { 'a', 'b', 'c', '\u0793', ':' }; //THAANA LETTER TAVIYANI
            IEnumerable<char> LowerChars = new List<char> { 'X', 'Y', 'Z', '\u0792', ';' }; //THAANA LETTER ZAVIYANI
            bool LowerCase = false; 
            bool AllCapitals = false; 
            bool FirstCapital = false; 

            var Word = "abracadabra";
            bool FirstCapitalExpected = true; 
            bool LowerCaseExpected = false; 
            bool AllCapitalsExpected = false; 
            TextHelper.DefineCapitals(Word, UpperChars, LowerChars, out LowerCase, out FirstCapital, out AllCapitals);
            Assert.AreEqual(LowerCaseExpected, LowerCase, Word + "1");
            Assert.AreEqual(FirstCapitalExpected, FirstCapital, Word + "2");
            Assert.AreEqual(AllCapitalsExpected, AllCapitals, Word + "3");

            Word = "abb a \u0793DF, !";
            FirstCapitalExpected = true;
            LowerCaseExpected = false;
            AllCapitalsExpected = true;
            TextHelper.DefineCapitals(Word, UpperChars, LowerChars, out LowerCase, out FirstCapital, out AllCapitals);
            Assert.AreEqual(LowerCaseExpected, LowerCase, Word + "1");
            Assert.AreEqual(FirstCapitalExpected, FirstCapital, Word + "2");
            Assert.AreEqual(AllCapitalsExpected, AllCapitals, Word + "3");

            Word = "Xabb a \u0793DF, !";
            FirstCapitalExpected = false;
            LowerCaseExpected = true;
            AllCapitalsExpected = false;
            TextHelper.DefineCapitals(Word, UpperChars, LowerChars, out LowerCase, out FirstCapital, out AllCapitals);
            Assert.AreEqual(LowerCaseExpected, LowerCase, Word + "1");
            Assert.AreEqual(FirstCapitalExpected, FirstCapital, Word + "2");
            Assert.AreEqual(AllCapitalsExpected, AllCapitals);

            Word = "XY?Z \u0792";
            FirstCapitalExpected = false;
            LowerCaseExpected = true;
            AllCapitalsExpected = false;
            TextHelper.DefineCapitals(Word, UpperChars, LowerChars, out LowerCase, out FirstCapital, out AllCapitals);
            Assert.AreEqual(LowerCaseExpected, LowerCase, Word + "1");
            Assert.AreEqual(FirstCapitalExpected, FirstCapital, Word + "2");
            Assert.AreEqual(AllCapitalsExpected, AllCapitals, Word + "3");

            Word = "aXY?Z \u0792";
            FirstCapitalExpected = true;
            LowerCaseExpected = false;
            AllCapitalsExpected = false;
            TextHelper.DefineCapitals(Word, UpperChars, LowerChars, out LowerCase, out FirstCapital, out AllCapitals);
            Assert.AreEqual(LowerCaseExpected, LowerCase, Word + "1");
            Assert.AreEqual(FirstCapitalExpected, FirstCapital, Word + "2");
            Assert.AreEqual(AllCapitalsExpected, AllCapitals, Word + "3");

            Word = ":ab;";
            FirstCapitalExpected = true;
            LowerCaseExpected = false;
            AllCapitalsExpected = false;
            TextHelper.DefineCapitals(Word, UpperChars, LowerChars, out LowerCase, out FirstCapital, out AllCapitals);
            Assert.AreEqual(LowerCaseExpected, LowerCase, Word + "1");
            Assert.AreEqual(FirstCapitalExpected, FirstCapital, Word + "2");
            Assert.AreEqual(AllCapitalsExpected, AllCapitals, Word + "3");
        }

        /// <summary>
        ///A test for DefineCapitals
        ///</summary>
        [TestMethod()]
        public void DefineCapitalsTest()
        {
            bool LowerCase = false;  
            bool AllCapitals = false; 
            bool FirstCapital = false; 

            string Word = "A LITTLE PARTY NEVER KILLED NOBODY"; 

            bool FirstCapitalExpected = true;
            bool LowerCaseExpected = false; 
            bool AllCapitalsExpected = true; 

            TextHelper.DefineCapitals(Word, out LowerCase, out FirstCapital, out AllCapitals);
            Assert.AreEqual(LowerCaseExpected, LowerCase);
            Assert.AreEqual(FirstCapitalExpected, FirstCapital);
            Assert.AreEqual(AllCapitalsExpected, AllCapitals);

            Word = "A litt?!le party never etc.???";
            LowerCaseExpected = false;
            FirstCapitalExpected = true;
            AllCapitalsExpected = false;

            TextHelper.DefineCapitals(Word, out LowerCase, out FirstCapital, out AllCapitals);
            Assert.AreEqual(LowerCaseExpected, LowerCase);
            Assert.AreEqual(FirstCapitalExpected, FirstCapital);
            Assert.AreEqual(AllCapitalsExpected, AllCapitals);

            Word = "?a litt?!le party never etc.???";
            LowerCaseExpected = true;
            FirstCapitalExpected = false;
            AllCapitalsExpected = false;

            TextHelper.DefineCapitals(Word, out LowerCase, out FirstCapital, out AllCapitals);
            Assert.AreEqual(LowerCaseExpected, LowerCase);
            Assert.AreEqual(FirstCapitalExpected, FirstCapital);
            Assert.AreEqual(AllCapitalsExpected, AllCapitals);

            Word = "?A litt?!le party never etc.???";
            LowerCaseExpected = true;
            FirstCapitalExpected = false;
            AllCapitalsExpected = false;

            TextHelper.DefineCapitals(Word, out LowerCase, out FirstCapital, out AllCapitals);
            Assert.AreEqual(LowerCaseExpected, LowerCase);
            Assert.AreEqual(FirstCapitalExpected, FirstCapital);
            Assert.AreEqual(AllCapitalsExpected, AllCapitals);
        }
    }
}
