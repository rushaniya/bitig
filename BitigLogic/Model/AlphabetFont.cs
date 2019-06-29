using System.ComponentModel;
using System.Drawing;

namespace Bitig.Logic.Model
{
    public class AlphabetFont
    {
        /* public string FamilyName { get; set; }
         public float Size { get; set; }
         public FontStyle Style { get; set; }

         public AlphabetFont(string FamilyName, float Size, FontStyle Style = FontStyle.Regular)
         {
             this.FamilyName = FamilyName;
             this.Size = Size;
             this.Style = Style;
         }*/

        //private Font font;// = SystemFonts.DefaultFont;

        //public Font Font
        //{
        //    get { return font; }
        //}

        private string description;

        public string Description
        {
            get { return description; }
        }

        public AlphabetFont(string Description)
        {
            description = Description;
        }

        public AlphabetFont(string FamilyName, float Size, FontStyle Style = FontStyle.Regular)
        {
            using (var _font = new Font(FamilyName, Size, Style))
            {
                description = TypeDescriptor.GetConverter(typeof(Font)).ConvertToString(_font);
            }
        }

        public AlphabetFont(Font Font)
        {
            description= TypeDescriptor.GetConverter(typeof(Font)).ConvertToString(Font);
        }

        public static explicit operator Font(AlphabetFont AlphabetFont)
        {
            if (AlphabetFont == null || AlphabetFont.description == null)
                return null;
            return (Font)(TypeDescriptor.GetConverter(typeof(Font)).ConvertFromString(AlphabetFont.description));
        }

        public static explicit operator AlphabetFont(Font Font)
        {
            return new AlphabetFont(Font);
        }

        public override string ToString()//loc
        {
            return description;
            //config
           /* string _result = string.Empty;
            if (font != null)
            {
                StringBuilder _style = new StringBuilder();
                if (font.Italic) _style.Append(", italic");
                if (font.Bold) _style.Append(", bold");
                if (font.Underline) _style.Append(", underlined");
                if (font.Strikeout) _style.Append(", striked out");
                if (_style.Length > 0)
                {
                    _style.Append(".");
                    _style.Remove(0, 1);
                    _style.Insert(0, ";");
                }
                _result = string.Format("{0}; {1} pt.{2}", font.Name, font.Size, _style);
            }
            return _result;*/
        }
    }
}
