using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Bitig.Base;
using Bitig.Logic.Model;

namespace Bitig.Logic.Repository
{
    public class Seed
    {
        private readonly IDataContext dataContext;
        private static AlphabetFont yanalifFont = new AlphabetFont("DejaVu Sans", 12, FontStyle.Regular);
        public Seed(IDataContext DataContext)
        {
            dataContext = DataContext;
        }

        public void Create()
        {
            var _yanalif = CreateAlphabet(BuiltInAlphabetType.Yanalif);
            var _yanalifKbl = GetYanalifKeyboard();
            dataContext.KeyboardRepository.Insert(_yanalifKbl);
            _yanalif.KeyboardLayout = _yanalifKbl;
            dataContext.AlphabetRepository.Insert(_yanalif);
            var _cyrillic = CreateAlphabet(BuiltInAlphabetType.Cyrillic);
            var _cyrillicKbl = GetCyrillicKeyboard();
            dataContext.KeyboardRepository.Insert(_cyrillicKbl);
            _cyrillic.KeyboardLayout = _cyrillicKbl;
            dataContext.AlphabetRepository.Insert(_cyrillic);
            var _rasmalif = CreateAlphabet(BuiltInAlphabetType.Rasmalif);
            dataContext.AlphabetRepository.Insert(_rasmalif);
            var _zamanalif = CreateAlphabet(BuiltInAlphabetType.Zamanalif);
            dataContext.AlphabetRepository.Insert(_zamanalif);

            var _cyrillicYanalif = new Direction(-1, _cyrillic, _yanalif, BuiltInType: BuiltInDirectionType.CyrillicYanalif);
            dataContext.DirectionRepository.Insert(_cyrillicYanalif);
            var _cyrillicRasmalif = new Direction(-1, _cyrillic, _rasmalif, BuiltInType: BuiltInDirectionType.CyrillicRasmalif);
            dataContext.DirectionRepository.Insert(_cyrillicRasmalif);
            var _cyrillicZamanalif = new Direction(-1, _cyrillic, _zamanalif, BuiltInType: BuiltInDirectionType.CyrillicZamanalif);
            dataContext.DirectionRepository.Insert(_cyrillicZamanalif);
            var _yanalifRasmalif = new Direction(-1, _yanalif, _rasmalif, BuiltInType: BuiltInDirectionType.YanalifRasmalif);
            dataContext.DirectionRepository.Insert(_yanalifRasmalif);
            var _yanalifZamanalif = new Direction(-1, _yanalif, _zamanalif, BuiltInType: BuiltInDirectionType.YanalifZamanalif);
            dataContext.DirectionRepository.Insert(_yanalifZamanalif);
            var _rasmalifYanalif = new Direction(-1, _rasmalif, _yanalif, BuiltInType: BuiltInDirectionType.RasmalifYanalif);
            dataContext.DirectionRepository.Insert(_rasmalifYanalif);
            var _zamanalifYanalif = new Direction(-1, _zamanalif, _yanalif, BuiltInType: BuiltInDirectionType.ZamanalifYanalif);
            dataContext.DirectionRepository.Insert(_zamanalifYanalif);

            dataContext.KeyboardRepository.Insert(GetYanalifMagicKeyboard());

            if (dataContext.IsFlushable)
                dataContext.SaveChanges();
        }

        private static List<AlphabetSymbol> GetSymbols(BuiltInAlphabetType AlifbaType)
        {
            List<AlphabetSymbol> _result = new List<AlphabetSymbol>();
            switch (AlifbaType)
            {
                case BuiltInAlphabetType.Cyrillic:
                    _result.Add(new AlphabetSymbol("\u04d9", "\u04d8", "\u04d9", "\u04d8"));//Ә
                    _result.Add(new AlphabetSymbol("\u04e9", "\u04e8", "\u04e9", "\u04e8"));//Ө
                    _result.Add(new AlphabetSymbol("\u04af", "\u04ae", "\u04af", "\u04ae"));//Ү
                    _result.Add(new AlphabetSymbol("\u0497", "\u0496", "\u0497", "\u0496"));//Җ
                    _result.Add(new AlphabetSymbol("\u04a3", "\u04a2", "\u04a3", "\u04a2"));//Ң
                    _result.Add(new AlphabetSymbol("\u04bb", "\u04ba", "\u04bb", "\u04ba"));//Һ
                    break;
                case BuiltInAlphabetType.Zamanalif:
                    _result.Add(new AlphabetSymbol("\u00e4", "\u00c4", "\u00e4", "\u00c4"));//Ä
                    _result.Add(new AlphabetSymbol("\u00e2", "\u00c2", "\u00e2", "\u00c2"));//Â
                    _result.Add(new AlphabetSymbol("\u00e1", "\u00c1", "\u00e1", "\u00c1"));//Á
                    _result.Add(new AlphabetSymbol("\u00e7", "\u00c7", "\u00e7", "\u00c7"));//Ç
                    _result.Add(new AlphabetSymbol("\u00e9", "\u00c9", "\u00e9", "\u00c9"));//É
                    _result.Add(new AlphabetSymbol("\u011f", "\u011e", "\u011f", "\u011e"));//Ğ
                    _result.Add(new AlphabetSymbol("\u0131", "\u0130", "\u0131", "\u0130"));//İı
                    _result.Add(new AlphabetSymbol("\u00ed", "\u00cd", "\u00ed", "\u00cd"));//Í
                    _result.Add(new AlphabetSymbol("\u00f1", "\u00d1", "\u00f1", "\u00d1"));//Ñ
                    _result.Add(new AlphabetSymbol("\u00f6", "\u00d6", "\u00f6", "\u00d6"));//Ö
                    _result.Add(new AlphabetSymbol("\u00f3", "\u00d3", "\u00f3", "\u00d3"));//Ó
                    _result.Add(new AlphabetSymbol("\u015f", "\u015e", "\u015f", "\u015e"));//Ş
                    _result.Add(new AlphabetSymbol("\u00fc", "\u00dc", "\u00fc", "\u00dc"));//Ü
                    _result.Add(new AlphabetSymbol("\u00fa", "\u00da", "\u00fa", "\u00da"));//Ú
                    break;
                case BuiltInAlphabetType.Rasmalif:
                    _result.Add(new AlphabetSymbol("\u00e4", "\u00c4", "\u00e4", "\u00c4"));//Ä
                    _result.Add(new AlphabetSymbol("\u00e7", "\u00c7", "\u00e7", "\u00c7"));//Ç
                    _result.Add(new AlphabetSymbol("\u0131", "\u0130", "\u0131", "\u0130"));//İı
                    _result.Add(new AlphabetSymbol("\u00f1", "\u00d1", "\u00f1", "\u00d1"));//Ñ
                    _result.Add(new AlphabetSymbol("\u00f6", "\u00d6", "\u00f6", "\u00d6"));//Ö
                    _result.Add(new AlphabetSymbol("\u015f", "\u015e", "\u015f", "\u015e"));//Ş
                    _result.Add(new AlphabetSymbol("\u00fc", "\u00dc", "\u00fc", "\u00dc"));//Ü
                    break;
                case BuiltInAlphabetType.Yanalif:
                    _result.Add(new AlphabetSymbol("\u0259", "\u018f")); //Ə
                    _result.Add(new AlphabetSymbol("\u00e7", "\u00c7")); //Ç
                    _result.Add(new AlphabetSymbol("\u011f", "\u011e")); //Ğ
                    _result.Add(new AlphabetSymbol("\u0131", "\u0130")); //İı
                    _result.Add(new AlphabetSymbol("\ua791", "\ua790")); //N with descender
                    _result.Add(new AlphabetSymbol("\u0275", "\u019f")); //Ɵ
                    _result.Add(new AlphabetSymbol("\u015f", "\u015e")); //Ş
                    _result.Add(new AlphabetSymbol("\u00fc", "\u00dc")); //Ü
                    break;
            }
            return _result;
        }

        private Alphabet CreateAlphabet(BuiltInAlphabetType AlphabetType)
        {
            return new Alphabet(
                -1,
                BuiltInTransliteration.GetAlphabetName(AlphabetType),
                false,
                GetFont(AlphabetType),
                KeyboardLayout: null,
                CustomSymbols: GetSymbols(AlphabetType));
        }

        private KeyboardLayout GetYanalifKeyboard()
        {
            var _kbl = new KeyboardLayout();
            _kbl.FriendlyName = "Yanalif Keyboard";
            _kbl.KeyCombinations = new List<KeyCombination>();
            _kbl.KeyCombinations.Add(new KeyCombination
            {
                MainKey = Keys.Oemtilde,
                Result = "v",
                Capital = "V"
            });
            _kbl.KeyCombinations.Add(new KeyCombination
            {
                MainKey = Keys.OemOpenBrackets,
                Result = "\u0275",
                Capital = "\u019f"
            });
            _kbl.KeyCombinations.Add(new KeyCombination
            {
                MainKey = Keys.OemCloseBrackets,
                Result = "\u00fc",
                Capital = "\u00dc"
            });
            _kbl.KeyCombinations.Add(new KeyCombination
            {
                MainKey = Keys.J,
                Result = "\u0131",
                Capital = "I"
            });
            _kbl.KeyCombinations.Add(new KeyCombination
            {
                MainKey = Keys.I,
                Result = "i",
                Capital = "\u0130"
            });
            _kbl.KeyCombinations.Add(new KeyCombination
            {
                MainKey = Keys.OemSemicolon,
                Result = "\u00e7",
                Capital = "\u00c7"
            });
            _kbl.KeyCombinations.Add(new KeyCombination
            {
                MainKey = Keys.OemQuotes,
                Result = "\u015f",
                Capital = "\u015e"
            });
            _kbl.KeyCombinations.Add(new KeyCombination
            {
                MainKey = Keys.Oem5,
                Result = "\ua791",
                Capital = "\ua790"
            });
            _kbl.KeyCombinations.Add(new KeyCombination
            {
                MainKey = Keys.V,
                Result = "\u0259",
                Capital = "\u018f"
            });
            _kbl.KeyCombinations.Add(new KeyCombination
            {
                MainKey = Keys.OemQuestion,
                Result = "\u011f",
                Capital = "\u011e"
            });
            _kbl.KeyCombinations.Add(new KeyCombination
            {
                MainKey = Keys.D3,
                WithShift = true,
                Result = "№"
            });
            _kbl.KeyCombinations.Add(new KeyCombination
            {
                MainKey = Keys.D4,
                WithShift = true,
                Result = ";"
            });
            _kbl.KeyCombinations.Add(new KeyCombination
            {
                MainKey = Keys.D6,
                WithShift = true,
                Result = ":"
            });
            _kbl.KeyCombinations.Add(new KeyCombination
            {
                MainKey = Keys.D7,
                WithShift = true,
                Result = "?"
            });
            _kbl.KeyCombinations.Add(new KeyCombination
            {
                MainKey = Keys.D8,
                WithShift = true,
                Result = "’"
            });
            _kbl.KeyCombinations.Add(new KeyCombination
            {
                MainKey = Keys.OemMinus,
                WithShift = true,
                Result = "—"
            });
            _kbl.KeyCombinations.Add(new KeyCombination
            {
                MainKey = Keys.Oemcomma,
                WithShift = true,
                Result = "«"
            });
            _kbl.KeyCombinations.Add(new KeyCombination
            {
                MainKey = Keys.OemPeriod,
                WithShift = true,
                Result = "»"
            });
            _kbl.KeyCombinations.Add(new KeyCombination
            {
                MainKey = Keys.Oemtilde,
                WithAltGr = true,
                Result = "'"
            });
            _kbl.KeyCombinations.Add(new KeyCombination
            {
                MainKey = Keys.D2,
                WithAltGr = true,
                Result = "@"
            });
            _kbl.KeyCombinations.Add(new KeyCombination
            {
                MainKey = Keys.D3,
                WithAltGr = true,
                Result = "#"
            });
            _kbl.KeyCombinations.Add(new KeyCombination
            {
                MainKey = Keys.D4,
                WithAltGr = true,
                Result = "$"
            });
            _kbl.KeyCombinations.Add(new KeyCombination
            {
                MainKey = Keys.D6,
                WithAltGr = true,
                Result = "^"
            });
            _kbl.KeyCombinations.Add(new KeyCombination
            {
                MainKey = Keys.D7,
                WithAltGr = true,
                Result = "&"
            });
            _kbl.KeyCombinations.Add(new KeyCombination
            {
                MainKey = Keys.D8,
                WithAltGr = true,
                Result = "*"
            });
            _kbl.KeyCombinations.Add(new KeyCombination
            {
                MainKey = Keys.OemMinus,
                WithAltGr = true,
                Result = "_"
            });
            _kbl.KeyCombinations.Add(new KeyCombination
            {
                MainKey = Keys.OemOpenBrackets,
                WithAltGr = true,
                Result = "["
            });
            _kbl.KeyCombinations.Add(new KeyCombination
            {
                MainKey = Keys.OemCloseBrackets,
                WithAltGr = true,
                Result = "]"
            });
            _kbl.KeyCombinations.Add(new KeyCombination
            {
                MainKey = Keys.Oemcomma,
                WithAltGr = true,
                Result = "<"
            });
            _kbl.KeyCombinations.Add(new KeyCombination
            {
                MainKey = Keys.OemPeriod,
                WithAltGr = true,
                Result = ">"
            });
            _kbl.KeyCombinations.Add(new KeyCombination
            {
                MainKey = Keys.Oem5,
                WithAltGr = true,
                Result = "\\"
            });
            _kbl.KeyCombinations.Add(new KeyCombination
            {
                MainKey = Keys.OemQuestion,
                WithAltGr = true,
                Result = "/"
            });
            _kbl.KeyCombinations.Add(new KeyCombination
            {
                MainKey = Keys.J,
                WithAltGr = true,
                Result = "j",
                Capital = "J"
            });
            _kbl.KeyCombinations.Add(new KeyCombination
            {
                MainKey = Keys.Oemtilde,
                WithAltGr = true,
                WithShift = true,
                Result = "~"
            });
            _kbl.KeyCombinations.Add(new KeyCombination
            {
                MainKey = Keys.OemOpenBrackets,
                WithAltGr = true,
                WithShift = true,
                Result = "{"
            });
            _kbl.KeyCombinations.Add(new KeyCombination
            {
                MainKey = Keys.OemCloseBrackets,
                WithAltGr = true,
                WithShift = true,
                Result = "}"
            });
            _kbl.KeyCombinations.Add(new KeyCombination
            {
                MainKey = Keys.Oem5,
                WithAltGr = true,
                WithShift = true,
                Result = "|"
            });

            return _kbl;
        }

        private MagicKeyboardLayout GetYanalifMagicKeyboard()
        {
            var _kbl = new MagicKeyboardLayout();
            _kbl.FriendlyName = "Easy Yanalif Keyboard";
            _kbl.MagicKey = Keys.Oem5;
            _kbl.KeyCombinations = new List<MagicKeyCombination>();
            _kbl.KeyCombinations.Add(new MagicKeyCombination
            {
                Symbol = 'a',
                WithMagic = "\u0259"
            });
            _kbl.KeyCombinations.Add(new MagicKeyCombination
            {
                Symbol = 'A',
                WithMagic = "\u018f"
            });
            _kbl.KeyCombinations.Add(new MagicKeyCombination
            {
                Symbol = 'c',
                WithMagic = "\u00e7"
            });
            _kbl.KeyCombinations.Add(new MagicKeyCombination
            {
                Symbol = 'C',
                WithMagic = "\u00c7"
            });
            _kbl.KeyCombinations.Add(new MagicKeyCombination
            {
                Symbol = 'g',
                WithMagic = "\u011f"
            });
            _kbl.KeyCombinations.Add(new MagicKeyCombination
            {
                Symbol = 'G',
                WithMagic = "\u011e"
            });
            _kbl.KeyCombinations.Add(new MagicKeyCombination
            {
                Symbol = 'i',
                WithMagic = "\u0131"
            });
            _kbl.KeyCombinations.Add(new MagicKeyCombination
            {
                Symbol = 'I',
                WithMagic = "\u0130"
            });
            _kbl.KeyCombinations.Add(new MagicKeyCombination
            {
                Symbol = 'n',
                WithMagic = "\ua791"
            });
            _kbl.KeyCombinations.Add(new MagicKeyCombination
            {
                Symbol = 'N',
                WithMagic = "\ua790"
            });
            _kbl.KeyCombinations.Add(new MagicKeyCombination
            {
                Symbol = 'o',
                WithMagic = "\u0275"
            });
            _kbl.KeyCombinations.Add(new MagicKeyCombination
            {
                Symbol = 'O',
                WithMagic = "\u019f"
            });
            _kbl.KeyCombinations.Add(new MagicKeyCombination
            {
                Symbol = 's',
                WithMagic = "\u015f"
            });
            _kbl.KeyCombinations.Add(new MagicKeyCombination
            {
                Symbol = 'S',
                WithMagic = "\u015e"
            });
            _kbl.KeyCombinations.Add(new MagicKeyCombination
            {
                Symbol = 'u',
                WithMagic = "\u00fc"
            });
            _kbl.KeyCombinations.Add(new MagicKeyCombination
            {
                Symbol = 'U',
                WithMagic = "\u00dc"
            });
            return _kbl;
        }

        private KeyboardLayout GetCyrillicKeyboard()
        {
            var _kbl = new KeyboardLayout();
            _kbl.FriendlyName = "Tatar Cyrillic";
            _kbl.KeyCombinations = new List<KeyCombination>();
            _kbl.KeyCombinations.Add(new KeyCombination
            {
                MainKey = Keys.O,
                Result = "\u04d9",
                Capital = "\u04d8"
            });
            _kbl.KeyCombinations.Add(new KeyCombination
            {
                MainKey = Keys.O,
                WithAltGr = true,
                Result = "щ",
                Capital = "Щ"
            });
            _kbl.KeyCombinations.Add(new KeyCombination
            {
                MainKey = Keys.W,
                Result = "\u04e9",
                Capital = "\u04e8"
            });
            _kbl.KeyCombinations.Add(new KeyCombination
            {
                MainKey = Keys.W,
                WithAltGr = true,
                Result = "ц",
                Capital = "Ц"
            });
            _kbl.KeyCombinations.Add(new KeyCombination
            {
                MainKey = Keys.OemCloseBrackets,
                Result = "\u04af",
                Capital = "\u04ae"
            });
            _kbl.KeyCombinations.Add(new KeyCombination
            {
                MainKey = Keys.OemCloseBrackets,
                WithAltGr = true,
                Result = "ъ",
                Capital = "Ъ"
            });
            _kbl.KeyCombinations.Add(new KeyCombination
            {
                MainKey = Keys.M,
                Result = "\u0497",
                Capital = "\u0496"
            });
            _kbl.KeyCombinations.Add(new KeyCombination
            {
                MainKey = Keys.M,
                WithAltGr = true,
                Result = "ь",
                Capital = "Ь"
            });
            _kbl.KeyCombinations.Add(new KeyCombination
            {
                MainKey = Keys.OemSemicolon,
                Result = "\u04a3",
                Capital = "\u04a2"
            });
            _kbl.KeyCombinations.Add(new KeyCombination
            {
                MainKey = Keys.OemSemicolon,
                WithAltGr = true,
                Result = "ж",
                Capital = "Ж"
            });
            _kbl.KeyCombinations.Add(new KeyCombination
            {
                MainKey = Keys.Oemtilde,
                Result = "\u04bb",
                Capital = "\u04ba"
            });
            _kbl.KeyCombinations.Add(new KeyCombination
            {
                MainKey = Keys.Oemtilde,
                WithAltGr = true,
                Result = "ё",
                Capital = "Ё"
            });
            return _kbl;
        }

        private AlphabetFont GetFont(BuiltInAlphabetType AlphabetType)
        {
            if (AlphabetType == BuiltInAlphabetType.Yanalif)
                return yanalifFont;
            return null;
        }
    }

}
