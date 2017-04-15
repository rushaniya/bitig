using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bitig.Logic.Commands;

namespace BitigTranslitTests
{
    [TestClass]
    public class CyrillicRasmalifTester : GenericTranslitCommandTester<CyrillicRasmalif>
    {
        public CyrillicRasmalifTester()
        {
            testPairs.Add("сәлам", "sälam");
            testPairs.Add("зыян", "zıyan");
            testPairs.Add("ЗЫЯН", "ZIYAN");
            testPairs.Add("Щи ашы", "Şçi aşı");
            testPairs.Add("щи Ашы", "şçi Aşı");
            testPairs.Add("ЩИ АШЫ", "ŞÇİ AŞI");
            testPairs.Add("Ия", "İä");
            testPairs.Add("\u04d8г\u04d9р д\u04d9...", "Ägär dä...");
            testPairs.Add("КАРЫЙБЫЗ", "QARIYBIZ");
            testPairs.Add("корьән", "qör'än");
            testPairs.Add("сөю", "söyü");
            testPairs.Add("сөюе", "söyüe");
            testPairs.Add("көньяк", "könyaq");
            testPairs.Add("көньякка", "könyaqqa");
            testPairs.Add("көньякта", "könyaqta");
            testPairs.Add("маэмай", "ma'may");
            testPairs.Add("дәрья", "därya");
            testPairs.Add("килограмм", "kilogramm");
            testPairs.Add("Ереван", "Yerevan");
            testPairs.Add("консерватория", "konservatoriä");
            testPairs.Add("КОНСЕРВАТОРИЯНЕ", "KONSERVATORİÄNE");
            testPairs.Add("декабрь", "dekäber");
            testPairs.Add("Рамилевна", "Ramilevna");
            testPairs.Add("шагыйрь", "şağir");
            testPairs.Add("Сәгыйть", "Säğit");
            testPairs.Add("Наилевич", "Naileviç");
            testPairs.Add("Гали Галиевич", "Ğali Ğalieviç");
            testPairs.Add("Галиевна", "Ğalievna");
            testPairs.Add("канәгать", "qänäğät");
            testPairs.Add("мәгълүм", "mäğlüm");
            testPairs.Add("пакь хыяллар", "pak xıyallar");
            testPairs.Add("без яшь әле", "bez yäş äle");
            testPairs.Add("ап-ак карлар ява", "ap-aq qarlar yawa");
            testPairs.Add("Камал театры ачыла...", "Kamal teatrı açıla...");
            testPairs.Add("Камалга", "Kamalğa");
            testPairs.Add("Камалгали абзый!", "Kamalğali abzıy!");
            testPairs.Add("Мәэюс", "Mä'yüs");
            testPairs.Add("игътибар", "iğtibar");
            testPairs.Add("кыяфәт", "qiäfät");

            exclusions.Add("Ветеринар", "Baytar", false, true, false);
            testPairs.Add("Ветеринар килде", "Baytar kilde");
            testPairs.Add("ветеринар килде", "baytar kilde");
            testPairs.Add("Ветеринарны чакыр", "Baytarnı çaqır");
            testPairs.Add("аВетеринарны чакыр", "aWeterinarnı çaqır");

            exclusions.Add("Пушкин", "Tuqay", true, true, false);
            testPairs.Add("Пушкин Шәп!", "Tuqay Şäp!");
            testPairs.Add("ПуШкин шәп!", "PuŞkin şäp!");
            testPairs.Add("Пушкинны укы", "Tuqaynı uqı");
            testPairs.Add("аПушкинны укы", "aPuşkinnı uqı");

            exclusions.Add("Мостафа", "İbrahim", false, false, true);
            testPairs.Add("Мостафага", "İbrahimğa");
            testPairs.Add("Мостафа", "İbrahim");
            testPairs.Add("мостафа", "ibrahim");
            testPairs.Add("әймостафа", "äyibrahim");

            exclusions.Add("ов", "off", true, false, true);
            testPairs.Add("овра", "offra");
            testPairs.Add("Мөхәммәтгарифов", "Möxämmätğärifoff");
            testPairs.Add("Мөхәммәтгарифовка", "Möxämmätğärifoffqa");
            testPairs.Add("МөхәммәтгарифОВка", "MöxämmätğärifOWqa");
            testPairs.Add("ов", "off");

            exclusions.Add("сәдәф", "töymä", false, false, false);
            testPairs.Add("сәдәф", "töymä");
            testPairs.Add("Сәдәф", "Töymä");
            testPairs.Add("өсәдәф", "ösädäf");
            testPairs.Add("сәдәфне", "sädäfne");
            testPairs.Add("өсәдәфне", "ösädäfne");

            exclusions.Add("Хәсән", "Tufan", true, false, false);
            testPairs.Add("Хәсән Туфан", "Tufan Tufan");
            testPairs.Add("хәсән Туфан", "xäsän Tufan");
            testPairs.Add("Хәсәнне ярата", "Xäsänne yarata");
            testPairs.Add("әйХәсән", "äyXäsän");

            testPairs.Add("Ий син Мостафа! Пушкинны вә Хәсән Туфанны яратып укы.",
                "İ sin İbrahim! Tuqaynı wä Tufan Tufannı yaratıp uqı.");

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
        public void RunCyrillicRasmalifTest()
        {
            base.TestTranslit();
        }
    }
}
