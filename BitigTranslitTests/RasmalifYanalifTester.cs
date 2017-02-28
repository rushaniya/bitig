using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bitig.Logic.Commands;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BitigTranslitTests
{
    [TestClass]
    public class RasmalifYanalifTester : GenericTranslitCommandTester<RasmalifYanalif>
    {
        public RasmalifYanalifTester()
        {
            testPairs.Add("Ä", "Ə");
            testPairs.Add("ä", "ə");
            testPairs.Add("sälam", "s\u0259lam");
            testPairs.Add("iYä", "i\u0259");
            testPairs.Add("kürüwe", "kürüe");

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
            testPairs.Add("Mostafanıy", "İbrahimnıy");
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
        public void RunRasmalifYanalifTest()
        {
            base.TestTranslit();
        }
    }
}
