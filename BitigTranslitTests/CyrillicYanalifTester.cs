using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bitig.Logic.Commands;
using Bitig.Base;

namespace BitigTranslitTests
{
    [TestClass]
    public class CyrillicYanalifTester
    {
        private Dictionary<string, string> testPairs = new Dictionary<string, string>();
        private ExclusionCollection exclusions = new ExclusionCollection();

        public CyrillicYanalifTester()
        {
            testPairs.Add("сәлам", "s\u0259lam");
            testPairs.Add("Ия", "İ\u0259");
            testPairs.Add("Щи ашы", "Şçi aşı");
            testPairs.Add("щи Ашы", "şçi Aşı");
            testPairs.Add("ЩИ АШЫ", "ŞÇİ AŞI");
            testPairs.Add("\u04d8г\u04d9р д\u04d9...", "\u018fg\u0259r d\u0259...");
            testPairs.Add("КАРЫЙБЫЗ", "QARIYBIZ");
            testPairs.Add("корьән", "qɵr’\u0259n");
            testPairs.Add("сөю", "sɵyü");
            testPairs.Add("сөюе", "sɵyüe");
            testPairs.Add("көньяк", "kɵnyaq");
            testPairs.Add("көньякка", "kɵnyaqqa");
            testPairs.Add("көньякта", "kɵnyaqta");
            testPairs.Add("маэмай", "ma’may");
            testPairs.Add("зыян", "zıyan");
            testPairs.Add("ЗЫЯН", "ZIYAN");
            testPairs.Add("дәрья", "d\u0259rya");
            testPairs.Add("килограмм", "kilogramm");
            testPairs.Add("Ереван", "Yerevan");
            testPairs.Add("консерватория", "konservatori\u0259");
            testPairs.Add("КОНСЕРВАТОРИЯНЕ", "KONSERVATORİƏNE");
            testPairs.Add("декабрь", "dek\u0259ber");
            testPairs.Add("Рамилевна", "Ramilevna");
            testPairs.Add("шагыйрь", "şağir");
            testPairs.Add("Сәгыйть", "S\u0259ğit");
            testPairs.Add("Наилевич", "Naileviç");
            testPairs.Add("Гали Галиевич", "Ğali Ğalieviç");
            testPairs.Add("Галиевна", "Ğalievna");
            testPairs.Add("канәгать", "q\u0259n\u0259ğ\u0259t");
            testPairs.Add("мәгълүм", "m\u0259ğlüm");
            testPairs.Add("пакь хыяллар", "pak xıyallar");
            testPairs.Add("без яшь әле", "bez y\u0259ş \u0259le");
            testPairs.Add("ап-ак карлар ява", "ap-aq qarlar yawa");
            testPairs.Add("Камал театры ачыла...", "Kamal teatrı açıla...");
            testPairs.Add("Камалга", "Kamalğa");
            testPairs.Add("Камалгали абзый!", "Kamalğali abzıy!");
            testPairs.Add("Мәэюс", "M\u0259’yüs");
            testPairs.Add("игътибар", "iğtibar");
            testPairs.Add("кыяфәт", "qi\u0259f\u0259t");

            exclusions.Add("Ветеринар", "Baytar", false, true, false);
            testPairs.Add("Ветеринар килде", "Baytar kilde");
            testPairs.Add("ветеринар килде", "baytar kilde");
            testPairs.Add("Ветеринарны чакыр", "Baytarnı çaqır");
            testPairs.Add("аВетеринарны чакыр", "aWeterinarnı çaqır");

            exclusions.Add("Пушкин", "Tuqay", true, true, false);
            testPairs.Add("Пушкин Шәп!", "Tuqay Şəp!");
            testPairs.Add("ПуШкин шәп!", "PuŞkin şəp!");
            testPairs.Add("Пушкинны укы", "Tuqaynı uqı");
            testPairs.Add("аПушкинны укы", "aPuşkinnı uqı");

            exclusions.Add("Мостафа", "İbrahim", false, false, true);
            testPairs.Add("Мостафага", "İbrahimğa");
            testPairs.Add("Мостафа", "İbrahim");
            testPairs.Add("мостафа", "ibrahim");
            testPairs.Add("әймостафа", "əyibrahim");

            exclusions.Add("ов", "off", true, false, true);
            testPairs.Add("овра", "offra");
            testPairs.Add("Мөхәммәтгарифов", "Mɵxəmmətğərifoff");
            testPairs.Add("Мөхәммәтгарифовка", "Mɵxəmmətğərifoffqa");
            testPairs.Add("МөхәммәтгарифОВка", "MɵxəmmətğərifOWqa");
            testPairs.Add("ов", "off");

            exclusions.Add("сәдәф", "tɵymə", false, false, false);
            testPairs.Add("сәдәф", "tɵymə");
            testPairs.Add("Сәдәф", "Tɵymə");
            testPairs.Add("өсәдәф", "ɵsədəf");
            testPairs.Add("сәдәфне", "sədəfne");
            testPairs.Add("өсәдәфне", "ɵsədəfne");

            exclusions.Add("Хәсән", "Tufan", true, false, false);
            testPairs.Add("Хәсән Туфан", "Tufan Tufan");
            testPairs.Add("хәсән Туфан", "xəsən Tufan");
            testPairs.Add("Хәсәнне ярата", "Xəsənne yarata");
            testPairs.Add("әйХәсән", "əyXəsən");

            testPairs.Add("Ий син Мостафа! Пушкинны вә Хәсән Туфанны яратып укы.",
                "İ sin İbrahim! Tuqaynı wə Tufan Tufannı yaratıp uqı.");

            exclusions.Add("казанга", "bawlığa", false, false, true);
            exclusions.Add("ангар", "angar", false, false, true);
            testPairs.Add("казангар", "bawlığar");
            testPairs.Add("ангарказанга", "angarbawlığa");
            testPairs.Add("казангаангар", "bawlığaangar");
            testPairs.Add("ангарМказанга", "angarMbawlığa");
            testPairs.Add("казангаМангар", "bawlığaMangar");

            exclusions.Add("", "gotcha!", false, false, true);
        }

        [TestMethod]
        public void CyrillicYanalifTestTranslit()
        {
            var translitCommand = new CyrillicYanalif();
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
