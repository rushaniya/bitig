namespace Bitig.Data.Model
{
    public class XmlFont
    {

        /* [System.Xml.Serialization.XmlAttribute]
         public string FamilyName { get; set; }

         [System.Xml.Serialization.XmlAttribute]
         public float Size { get; set; }

         [System.Xml.Serialization.XmlAttribute]
         public FontStyle Style { get; set; }*/

        [System.Xml.Serialization.XmlAttribute]
        public string Description { get; set; }

        public XmlFont() { }
    }
}
