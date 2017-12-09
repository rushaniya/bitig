using Bitig.Logic.Commands;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BitigTranslitTests
{
    [TestClass]
    public class YanalifRasmalifTester : GenericTranslitCommandTester<YanalifRasmalif>
    {
        public YanalifRasmalifTester()
        {
            //test translit table & mimic capitals
            testPairs.Add("s\u0259lam", "s\u00e4lam");
            testPairs.Add("İ\u0259", "İ\u00e4");
            testPairs.Add("QARIYBIZ", "QARIYBIZ");
            testPairs.Add("mo\ua791su...", "mo\u00f1su...");
            testPairs.Add("Dulqın-dulqın qara ç\u0259çe\ua791ne z\u0259\ua791g\u0259r tasma bel\u0259n ürm\u0259dem",
                "Dulqın-dulqın qara çäçeñne zäñgär tasma belän \u00fcrmädem");
            testPairs.Add("qɵr’\u0259n", "qör'än");
            testPairs.Add("Mİ\ua790A", "Mİ\u00d1A");
            testPairs.Add("k\u0275nyaq", "k\u00f6nyaq");
            testPairs.Add("\u018fg\u0259r d\u0259...", "\u00c4g\u00e4r d\u00e4...");
            testPairs.Add("Ürdək", "\u00dcrdäk");

            //test exclusions
            exclusions.Add("", "gotcha!", false, false, true);
            exclusions.Add("Kɵym\u0259", "qayıq", false, false, true);
            testPairs.Add("kɵym\u0259", "qayıq");

            exclusions.Add("gitara", "dumbıra", false, true, false);
            testPairs.Add("Gitara", "Dumbıra");
            testPairs.Add("gitaram", "dumbıram");
            testPairs.Add("xgitara", "xgitara");
            testPairs.Add("gitar", "gitar");
            testPairs.Add("Aldım qulğa gitara!..", "Aldım qulğa dumbıra!..");

            exclusions.Add("Aleksandr", "İskändär", true, false, false);
            testPairs.Add("Aleksandr", "İskändär");
            testPairs.Add("aleksandr", "aleksandr");
            testPairs.Add("Aleksandrovsk", "Aleksandrovsk");
            testPairs.Add("xAleksandr", "xAleksandr");

            exclusions.Add("ç\u0259ç\u0259k", "g\u00f6l", false, false, true);
            testPairs.Add("ç\u0259ç\u0259kl\u0259r", "g\u00f6ll\u00e4r");
            testPairs.Add("g\u0275lç\u0259ç\u0259k", "g\u00f6lg\u00f6l");
            testPairs.Add("SARIÇƏÇƏK", "SARIG\u00D6L");

            //test normalize
            exclusions.Add("üsk\u0259nem", "maturım", false, false, false);
            testPairs.Add("u\u0308sk\u0259nem", "maturım");
            testPairs.Add("U\u0308sk\u0259nem", "Maturım");
            testPairs.Add("xüsk\u0259nem", "x\u00fcskänem");
            testPairs.Add("üsk\u0259nemne", "\u00fcskänemne");
            testPairs.Add("ku\u0308l", "k\u00fcl");
            testPairs.Add("KU\u0308L", "K\u00dcL");
            exclusions.Add("u\u0308gi", "bertuğan", false, false, false);
            testPairs.Add("ügi", "bertuğan");
            testPairs.Add("Ügi", "Bertuğan");

            //test altogether
            testPairs.Add("Üsk\u0259nem! Ç\u0259ç\u0259kl\u0259rg\u0259 su sibep tor, y\u0259me?",
                "Maturım! G\u00f6llärgä su sibep tor, y\u00e4me?");
        }

        [TestMethod]
        public void RunYanalifRasmalifTest()
        {
            base.TestTranslit();
        }
    }
}
