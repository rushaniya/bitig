using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bitig.Logic.Commands;
using Bitig.Base;

namespace BitigTranslitTests
{
    [TestClass]
    public class ZamanalifYanalifTester
    {
        private Dictionary<string, string> testPairs = new Dictionary<string, string>();
        private ExclusionCollection exclusions = new ExclusionCollection();

        public ZamanalifYanalifTester()
        {
            testPairs.Add("Ä", "Ə");
            testPairs.Add("ä", "ə");
            testPairs.Add("í", "ıy");
            testPairs.Add("Í", "IY");
            testPairs.Add("sälam", "s\u0259lam");
            testPairs.Add("baríq", "barıyq");
            testPairs.Add("BARÍQ", "BARIYQ");
            testPairs.Add("Baríq", "Barıyq");
            testPairs.Add("Íqla", "Iyqla");
            testPairs.Add("Baríyq iYä", "Barıyq i\u0259");
            testPairs.Add("QARÍBIZ", "QARIYBIZ");

            exclusions.Add("Veterinar", "Baytar", false, true, false);
            testPairs.Add("Veterinar kilde", "Baytar kilde");
            testPairs.Add("veterinar kilde", "baytar kilde");
            testPairs.Add("Veterinarnı çaqır", "Baytarnı çaqır");
            testPairs.Add("aVeterinarnı çaqır", "aVeterinarnı çaqır");

            exclusions.Add("Tuqay", "Şağir", true, true, false);
            testPairs.Add("Tuqay Şäp!", "Şağir Şəp!");
            testPairs.Add("TuQay şäp!", "TuQay şəp!");
            testPairs.Add("Tuqaynı uqı", "Şağirnı uqı");
            testPairs.Add("aTuqaynı uqı", "aTuqaynı uqı");

            exclusions.Add("Mostafa", "İbrahim", false, false, true);
            testPairs.Add("Mostafaní", "İbrahimnıy");
            testPairs.Add("Mostafa", "İbrahim");
            testPairs.Add("mostafa", "ibrahim");
            testPairs.Add("äymostafa", "əyibrahim");

            exclusions.Add("ov", "off", true, false, true);
            testPairs.Add("ovra", "offra");
            testPairs.Add("Möxämmätğärifov", "Mɵxəmmətğərifoff");
            testPairs.Add("Möxämmätğärifovqa", "Mɵxəmmətğərifoffqa");
            testPairs.Add("MöxämmätğärifOVqa", "MɵxəmmətğərifOVqa");
            testPairs.Add("ov", "off");

            exclusions.Add("sädäf", "tɵymə", false, false, false);
            testPairs.Add("sädäf", "tɵymə");
            testPairs.Add("Sädäf", "Tɵymə");
            testPairs.Add("ösädäf", "ɵsədəf");
            testPairs.Add("sädäfne", "sədəfne");
            testPairs.Add("ösädäfne", "ɵsədəfne");

            exclusions.Add("Xäsän", "Tufan", true, false, false);
            testPairs.Add("Xäsän Tufan", "Tufan Tufan");
            testPairs.Add("xäsän Tufan", "xəsən Tufan");
            testPairs.Add("Xäsänne yarata", "Xəsənne yarata");
            testPairs.Add("äyXäsän", "əyXəsən");

            testPairs.Add("İy sin Mostafa! Tuqaynı wä Xäsän Tufannı yaratıp uqı.",
                "İ sin İbrahim! Şağirnı wə Tufan Tufannı yaratıp uqı.");
        }

        [TestMethod]
        public void ZamanalifYanalifTestTranslit()
        {
            var translitCommand = new ZamanalifYanalif();
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
