using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bitig.Base;
using System.Globalization;
using System.Diagnostics;

namespace Bitig.Logic.Commands
{
    public class CyrillicTranscription : TranslitCommand
    {
        protected override string Translit(string Fragment, bool WordStart, bool WholeWord)
        {
            if (!IsAlphabetic(Fragment))
                return Fragment;
            bool _isEnding = !WordStart;
            if (string.IsNullOrEmpty(Fragment)) return string.Empty;
            bool _russianWord = Fragment.IndexOfAny(russianLetters) > -1;
            bool _doubleLetters = false;
            StringBuilder _resultBuilder = new StringBuilder();
            string _resultWord = string.Empty;
            List<Syllable> _syllables = DetermineSyllables(Fragment);
            if (_syllables.Count > 0)
            {
                int _vIndex = -1;
                bool _containsV = _russianWord || HasRussianEnding(_syllables, out _vIndex);
                for (int i = 0; i < _syllables.Count; i++)
                {
                    //for words like корьән
                    if (i > 0 && hamzaVowelsLow.Contains(_syllables[i].LowerString[0]) &&
                        (_syllables[i - 1].LowerString.EndsWith("ь") || _syllables[i - 1].LowerString.EndsWith("ъ")))
                        _resultBuilder.Append("~");
                    Syllable _nextSyl = i + 1 < _syllables.Count ? _syllables[i + 1] : null;
                    string _translittedSyl = TranslitSyllable(_syllables[i], i, _russianWord || _containsV && i == _vIndex, _isEnding, _nextSyl, ref _russianWord, ref _doubleLetters);
                    _resultBuilder.Append(_translittedSyl);
                }
                _resultWord = TrimYots(_resultBuilder.ToString(), 0);
                if (_doubleLetters && AllCapitals(Fragment))
                    return _resultWord.ToUpperInvariant();
            }
            return _resultWord;
        }

        protected override string AlphabetPattern
        {
            get { return @"А-яЁёӘәӨөҮүҖҗҢңҺһ"; }
        }

        private CultureInfo cyrillicCulture;
        private void InitiateCulture()
        {
            try
            {
                cyrillicCulture = CultureInfo.GetCultureInfo(0x0444);//Tatar(Russia)
            }
            catch
            {
                try
                {
                    cyrillicCulture = CultureInfo.GetCultureInfo(0x0019);//Russian
                }
                catch
                {
                    cyrillicCulture = CultureInfo.InvariantCulture;
                }
            }
        }

        private Dictionary<string,string> translitTable;
        private void FillTranslitTable()
        {
            translitTable = new Dictionary<string, string>();
            translitTable.Add("А", "A");
            translitTable.Add("а", "a");
            translitTable.Add("А:", "A:");
            translitTable.Add("а:", "a:");
            translitTable.Add("Б", "B");
            translitTable.Add("б", "b");
            translitTable.Add("В", "W");
            translitTable.Add("в", "w");
            translitTable.Add("В_rus", "V");
            translitTable.Add("в_rus", "v");
            translitTable.Add("Г", "G");
            translitTable.Add("г", "g");
            translitTable.Add("Г:", "G:");
            translitTable.Add("г:", "g:");
            translitTable.Add("Д", "D");
            translitTable.Add("д", "d");
            translitTable.Add("Е", "Ye");
            translitTable.Add("е", "ye");
            translitTable.Add("Е:", "Ye:");
            translitTable.Add("е:", "ye:");
            translitTable.Add("Е_mid", "E");
            translitTable.Add("е_mid", "e");
            translitTable.Add("Ё", "Yo:");
            translitTable.Add("ё", "yo:");
            translitTable.Add("Ё_mid", "o'");
            translitTable.Add("ё_mid", "o'");
            translitTable.Add("Ж", "J");
            translitTable.Add("ж", "j");
            translitTable.Add("З", "Z");
            translitTable.Add("з", "z");
            translitTable.Add("И", "I");
            translitTable.Add("и", "i");
            translitTable.Add("Й", "Y");
            translitTable.Add("й", "y");
            translitTable.Add("К", "K");
            translitTable.Add("к", "k");
            translitTable.Add("К:", "Q");
            translitTable.Add("к:", "q");
            translitTable.Add("Л", "L");
            translitTable.Add("л", "l");
            translitTable.Add("М", "M");
            translitTable.Add("м", "m");
            translitTable.Add("Н", "N");
            translitTable.Add("н", "n");
            translitTable.Add("О", "O");
            translitTable.Add("о", "o");
            translitTable.Add("О:", "O:");
            translitTable.Add("о:", "o:");
            translitTable.Add("П", "P");
            translitTable.Add("п", "p");
            translitTable.Add("Р", "R");
            translitTable.Add("р", "r");
            translitTable.Add("С", "S");
            translitTable.Add("с", "s");
            translitTable.Add("Т", "T");
            translitTable.Add("т", "t");
            translitTable.Add("У", "U");
            translitTable.Add("у", "u");
            translitTable.Add("У:", "U:");
            translitTable.Add("у:", "u:");
            translitTable.Add("Ф", "F");
            translitTable.Add("ф", "f");
            translitTable.Add("Х", "X");
            translitTable.Add("х", "x");
            translitTable.Add("Ц", "Ts");
            translitTable.Add("ц", "ts");
            translitTable.Add("Ц_s", "S");
            translitTable.Add("ц_s", "s");
            translitTable.Add("Ч", "C$");
            translitTable.Add("ч", "c$");
            translitTable.Add("Ш", "S$");
            translitTable.Add("ш", "s$");
            translitTable.Add("Щ", "S'");
            translitTable.Add("щ", "s'");
            translitTable.Add("Ъ", "");
            translitTable.Add("ъ", "");
            translitTable.Add("Ы", "E");
            translitTable.Add("ы", "e");
            translitTable.Add("Ы:", "E:");
            translitTable.Add("ы:", "e:");
            translitTable.Add("Ь", "");
            translitTable.Add("ь", "");
            translitTable.Add("Э", "E");
            translitTable.Add("э", "e");
            translitTable.Add("Э_mid", "E");
            translitTable.Add("э_mid", "e");
            translitTable.Add("Ю", "Yu");
            translitTable.Add("ю", "yu");
            translitTable.Add("Ю:", "Yu:");
            translitTable.Add("ю:", "yu:");
            translitTable.Add("Ю_mid", "U'");
            translitTable.Add("ю_mid", "u'");
            translitTable.Add("Я", "Ya");
            translitTable.Add("я", "ya");
            translitTable.Add("Я:", "Ya:");
            translitTable.Add("я:", "ya:");
            translitTable.Add("Я_a", "A:");
            translitTable.Add("я_a", "a:");
            translitTable.Add("Я^", "A^");
            translitTable.Add("я^", "a^");
            translitTable.Add("Я_mid", "A'");
            translitTable.Add("я_mid", "a'");
            translitTable.Add("Ә", "A");
            translitTable.Add("ә", "a");
            translitTable.Add("Ө", "O");
            translitTable.Add("ө", "o");
            translitTable.Add("Ү", "U");
            translitTable.Add("ү", "u");
            translitTable.Add("Җ", "C");
            translitTable.Add("җ", "c");
            translitTable.Add("Ң", "N$");
            translitTable.Add("ң", "n$");
            translitTable.Add("Һ", "H");
            translitTable.Add("һ", "h");
        }

        private char[] russianLetters;
        private void FillRussianLetters()
        {
            russianLetters = new char[] { 'Ё', 'ё', 'Ц', 'ц', 'Щ', 'щ' };
        }

        private char[] vowels;
        private void FillVowels()
        {
            vowels = new char[] { 'А', 'Е', 'Ё', 'И', 'О', 'У', 'Ы', 'Э', 'Ю', 'Я', 'Ә', 'Ө', 'Ү', 'а', 'е', 'ё', 'и', 'о', 'у', 'ы', 'э', 'ю', 'я', 'ә', 'ө', 'ү' };
        }

        private char[] consonants;
        private void FillConsonants()
        {
            consonants = new char[]{
            'Б',
            'В',
            'Г',
            'Д',
            'Ж',
            'З',
            'Й',
            'К',
            'Л',
            'М',
            'Н',
            'П',
            'Р',
            'С',
            'Т',
            'У',
            'Ф',
            'Х',
            'Ц',
            'Ч',
            'Ш',
            'Щ',
            'Җ',
            'Ң',
            'Һ',
            'б',
            'в',
            'г',
            'д',
            'ж',
            'з',
            'к',
            'л',
            'м',
            'н',
            'п',
            'р',
            'с',
            'т',
            'ф',
            'х',
            'ц',
            'ч',
            'ш',
            'щ',
            'җ',
            'ң',
            'һ'};
        }

        private char[] vowelsLow;
        private void FillVowelsLow()
        {
            vowelsLow = new char[] { 'а', 'е', 'ё', 'и', 'о', 'у', 'ы', 'э', 'ю', 'я', 'ә', 'ө', 'ү' };
        }

        private char[] hamzaVowelsLow;
        private void FillHamzaVowels()
        {
            hamzaVowelsLow = new char[] { 'ә', 'ө', 'ү', 'и', 'а', 'о', 'у', 'ы', 'э' };
        }

        private char[] yotatedVowelsLow;
        private void FillYotatedVowels()
        {
            yotatedVowelsLow = new char[] { 'я', 'ю', 'е' };
        }

        private char[] softVowelsLow;
        private void FillSoftVowels()
        {
            softVowelsLow = new char[] { 'ә', 'ө', 'ү', 'и' };
        }

        private char[] hardVowelsLow;
        private void FillHardVowels()
        {
            hardVowelsLow = new char[] { 'а', 'о', 'у', 'ы' };
        }

        private char[] hardLettersLow;
        private void FillHardLetters()
        {
            hardLettersLow = new char[] { 'а', 'о', 'у', 'ы', 'ъ' };
        }

        private char[] gkLettersLow;
        private void FillGKLetters()
        {
            gkLettersLow = new char[] { 'г', 'к' };
        }

        private List<string> ambigCombinationsLow;
        private void FillAmbigCombinations()
        {
            ambigCombinationsLow = new List<string>();
            foreach (char gk in gkLettersLow)
            {
                foreach (char hw in hardVowelsLow)
                {
                    ambigCombinationsLow.Add(gk.ToString() + hw.ToString());
                }
            }
        }

        private void FillExclusions()
        {
            Exclusions = new ExclusionCollection();
            Exclusions.Add("дәрья", "darya:", false, true, false);
            Exclusions.Add("дөнья", "donya:", false, true, false);
            Exclusions.Add("әдәбият", "adabia:t", false, true, false);
            Exclusions.Add("югыйсә", "yu:g:isa", false, true, false);
            Exclusions.Add("гади", "g:a:di", false, true, false);
            Exclusions.Add("гали", "g:a:li", false, true, true);
            Exclusions.Add("галия", "g:a:lia", false, true, false);
            Exclusions.Add("гафил", "g:a:fil", false, true, false);
            Exclusions.Add("гаилә", "g:a:ila", false, true, false);
            Exclusions.Add("әфган", "afg:a:n", false, true, false);
            Exclusions.Add("фәрганә", "farg:a:na", false, true, false);
            Exclusions.Add("сәлам", "sala^m", false, true, false);
            Exclusions.Add("имла", "imla^", false, true, false);
            Exclusions.Add("имля", "imla^", false, true, false);
            Exclusions.Add("адәм", "a^dam", false, true, false);
            Exclusions.Add("һәлак", "hala^k", false, true, false);
            Exclusions.Add("хакимият", "xa^kimiat", false, true, false);
			Exclusions.Add("ханә", "xa^na", false, false, true);
            Exclusions.Add("көньяк", "konya:q", false, true, false);
            Exclusions.Add("төньяк", "tonya:q", false, true, false);
            Exclusions.Add("блок", "blo:k", false, true, false);
            Exclusions.Add("голланд", "go:lla:nd", false, true, false);
            //Exclusions.Add("градус", "gra:du:s", false, true, false);
            //Exclusions.Add("график", "gra:fik", false, true, false);
            //Exclusions.Add("граждан", "gra:jda:n", false, true, false);
            Exclusions.Add("грамм", "gra:mm", false, true, true);
            Exclusions.Add("програм", "pro:gra:m", false, true, false);
            Exclusions.Add("килограм", "kilo:gra:m", false, true, false);
            //Exclusions.Add("гранит", "gra:nit", false, true, false);
            //Exclusions.Add("груп", "gru:p", false, true, false);
            Exclusions.Add("губерна", "gu:berna:", false, true, false);
            Exclusions.Add("гумани", "gu:ma:ni", false, true, false);
            Exclusions.Add("ереван", "yereva:n", false, true, false);
            Exclusions.Add("камал", "ka:ma:l", false, true, true);
            Exclusions.Add("камил", "ka:mil", false, true, false);
            Exclusions.Add("карандаш", "ka:ra:nda:s$", false, true, false);
            Exclusions.Add("карта", "ka:rta:", false, true, false);
            Exclusions.Add("кафер", "ka:fer", false, true, false);
            Exclusions.Add("кафир", "ka:fir", false, true, false);
            Exclusions.Add("кг", "kg", false, false, false);
            Exclusions.Add("кобальт", "ko:ba:lt", false, true, false);
            Exclusions.Add("колхоз", "ko:lxo:z", false, true, false);
            Exclusions.Add("конве", "ko:nve", false, true, false);
            Exclusions.Add("комбайн", "ko:mba:yn", false, true, false);
            Exclusions.Add("комедия", "ko:media", false, true, false);
            Exclusions.Add("комиссар", "ko:missa:r", false, true, false);
            Exclusions.Add("комитет", "ko:mitet", false, true, false);
            Exclusions.Add("комплекс", "ko:mpleks", false, true, false);
            Exclusions.Add("компози", "ko:mpo:zi", false, true, false);
            Exclusions.Add("кондуктор", "ko:ndu:kto:r", false, true, false);
            Exclusions.Add("конгресс", "ko:ngress", false, true, false);
            Exclusions.Add("конкрет", "ko:nkret", false, true, false);
            Exclusions.Add("консерва", "ko:nserva:", false, true, false);
            Exclusions.Add("конституци", "ko:nstitu:si", false, true, false);
            Exclusions.Add("конструк", "ko:nstru:k", false, true, false);
            Exclusions.Add("консул", "ko:nsu:l", false, true, false);
            Exclusions.Add("контакт", "ko:nta:kt", false, true, false);
            Exclusions.Add("контор", "ko:nto:r", false, true, false);
            Exclusions.Add("контр", "ko:ntr", false, true, false);
            Exclusions.Add("конфлик", "ko:nflikt", false, true, false);
            Exclusions.Add("конце", "ko:nse", false, true, false);
            Exclusions.Add("коорди", "ko:o:rdi", false, true, false);
            Exclusions.Add("коридор", "ko:rido:r", false, true, false);
            Exclusions.Add("косинус", "ko:sinu:s", false, true, false);
            Exclusions.Add("косметик", "ko:smetik", false, true, false);
            Exclusions.Add("костюм", "ko:stu'm", false, true, false);
            Exclusions.Add("кәгазь", "qag:az", false, true, false);
            Exclusions.Add("код", "ko:d", false, false, false);
            Exclusions.Add("рак", "ra:k", false, false, false);
            Exclusions.Add("совет", "so:vet", false, true, false);
            Exclusions.Add("состав", "so:sta:v", false, true, false);
            Exclusions.Add("украин", "u:kra:in", false, true, false);
            Exclusions.Add("устав", "u:sta:v", false, true, false);
            Exclusions.Add("февраль", "fevral", false, true, false);
            Exclusions.Add("август", "avgu:st", false, true, false);
            Exclusions.Add("сентябр", "sentaber", false, true, false);
            Exclusions.Add("октябр", "oktaber", false, true, false);
            Exclusions.Add("ноябр", "no:yaber", false, true, false);
            Exclusions.Add("декабр", "dekaber", false, true, false);
        }

        public CyrillicTranscription()
        {
            InitiateCulture();
            FillConsonants();
            FillGKLetters();
            FillHamzaVowels();
            FillHardLetters();
            FillHardVowels();
            FillRussianLetters();
            FillSoftVowels();
            FillTranslitTable();
            FillVowels();
            FillVowelsLow();
            FillYotatedVowels();
            FillAmbigCombinations();
            FillExclusions();
        }

        protected override string AppendTranslittedFragment(string Previous, string Current)
        {
            if (Previous.Length > 0)
                return TrimYots(string.Concat(Previous, Current), Previous.Length - 1);//trim yots at the boundary
            else
                return Current;
        }

        private bool AllCapitals(string Word)
        {
            if (Word.Length < 2) return false;
            foreach (char _letter in Word)
            {
                if (char.IsLower(_letter)) return false;
            }
            return true;
        }

        //semantics:consider case/plural endings after russian ones
        private bool HasRussianEnding(List<Syllable> WordSyllables, out int VSyllableIndex)
        {
            bool _result = false;
            VSyllableIndex = -1;
            if (WordSyllables.Count > 1 && (WordSyllables[WordSyllables.Count - 1].LowerString.EndsWith("ов") ||
                WordSyllables[WordSyllables.Count - 1].LowerString.EndsWith("ев")))//male surname
            {
                _result = true;
                VSyllableIndex = WordSyllables.Count - 1;
            }
            else if (WordSyllables.Count > 1)
            {
                string _ending = WordSyllables[WordSyllables.Count - 2].LowerString + WordSyllables[WordSyllables.Count - 1].LowerString;
                //female/neutral possessive ending, male patronym
                if (_ending.EndsWith("евич") || _ending.EndsWith("ович") || _ending.EndsWith("ева") || _ending.EndsWith("ова"))
                {
                    _result = true;
                    VSyllableIndex = WordSyllables.Count - 1;
                    //determine ending's softness/hardness by previous syllable
                    if (WordSyllables.Count > 2 && WordSyllables[WordSyllables.Count - 2].LowerString == "е")
                        WordSyllables[WordSyllables.Count - 2].SyllableType = WordSyllables[WordSyllables.Count - 3].SyllableType;
                }
                else if (_ending.EndsWith("евна") || _ending.EndsWith("овна")) //female patronym
                {
                    _result = true;
                    VSyllableIndex = WordSyllables.Count - 2;
                    //determine ending's softness/hardness by previous syllable
                    if (WordSyllables.Count > 2 && WordSyllables[WordSyllables.Count - 2].LowerString == "ев")
                        WordSyllables[WordSyllables.Count - 2].SyllableType = WordSyllables[WordSyllables.Count - 3].SyllableType;
                }
            }
            return _result;
        }

        private string TranslitSyllable(Syllable Syl, int Position, bool RussianV, bool IsEnding, Syllable NextSyl, ref bool RussianWord, ref bool DoubleUpperLetter)
        {
            if (Syl.LowerString == "э" && Position > 0 && !RussianWord)
            {
                return "~";
            }
            if (Position > 0 && (Syl.SyllableString == "У" || Syl.SyllableString == "Ү"))
            {
                return "W";
            }
            if (Position > 0 && (Syl.SyllableString == "у" || Syl.SyllableString == "ү"))
            {
                return "w";
            }
            StringBuilder _result = new StringBuilder();
            for (int i = 0; i < Syl.SyllableString.Length; i++)
            {
                string _letterKey = Syl.SyllableString[i].ToString();
                if (Syl.LowerString[i] == 'в')
                {
                    if (i + 1 < Syl.LowerString.Length && Syl.LowerString[i + 1] == 'э')
                    {
                        RussianV = true;
                        RussianWord = true;
                    }
                    if (RussianV)
                    {
                        _letterKey += "_rus";
                        _result.Append(translitTable[_letterKey]);
                        continue;
                    }
                }
                if (Syl.LowerString[i] == 'ц')
                {
                    if (i + 1 < Syl.LowerString.Length && (Syl.LowerString[i + 1] == 'и' || Syl.LowerString[i + 1] == 'е'))
                    {
                        _letterKey += "_s";
                        _result.Append(translitTable[_letterKey]);
                        continue;
                    }
                    if (_letterKey == "Ц") 
                        DoubleUpperLetter = true;
                }
                if (Syl.LowerString[i] == 'я')
                {
                    if (i == 0)
                    {
                        if (_letterKey == "Я") 
                            DoubleUpperLetter = true;
                        _letterKey += Syl.SylTypeString;
                    }
                    else
                    {
                        if (gkLettersLow.Contains(Syl.LowerString[i - 1])) 
                            _letterKey += "_a";
                        else _letterKey += "_mid";
                    }
                    _result.Append(translitTable[_letterKey]);
                    continue;
                }
                if (Syl.LowerString[i] == 'е')
                {
                    if (i == 0 && !IsEnding) //this letter often occurs in Tatar endings where it is not yotated
                    {
                        if (_letterKey == "Е") 
                            DoubleUpperLetter = true;
                        _letterKey += Syl.SylTypeString;
                    }
                    else
                        _letterKey += "_mid";
                    _result.Append(translitTable[_letterKey]);
                    continue;
                }
                if (Syl.LowerString[i] == 'ё')
                {
                    if (i > 0)
                        _letterKey += "_mid";
                    if (_letterKey == "Ё") DoubleUpperLetter = true;
                    _result.Append(translitTable[_letterKey]);
                    continue;
                }
                if (Syl.LowerString[i] == 'ю')
                {
                    if (i == 0)
                    {
                        if (_letterKey == "Ю") 
                            DoubleUpperLetter = true;
                        _letterKey += Syl.SylTypeString;
                    }
                    else
                        _letterKey += "_mid";
                    _result.Append(translitTable[_letterKey]);
                    continue;
                }
                if (Syl.LowerString[i] == 'ы')
                {                    
                    if ((i + 1 < Syl.SyllableString.Length && Syl.LowerString[i + 1] == 'й') || //for words like гыйззәт
                        (i + 1 == Syl.SyllableString.Length && NextSyl != null && 
                        (yotatedVowelsLow.Contains(NextSyl.LowerString[0]) || NextSyl.LowerString[0] == 'й')))//for words like кыяфәт
                    {
                        if (Syl.SyllableString[i] == 'Ы') 
                            _result.Append("I");
                        else 
                            _result.Append("i");
                        _result.Append(Syl.SylTypeString);
                        if (Syl.SyllableType == ESyllableTypes.Soft && i + 1 < Syl.SyllableString.Length) 
                            i++; //skip next letter (Й)
                        continue;
                    }
                }
                if (Syl.LowerString[i] == 'э' && i > 0)
                {
                    RussianWord = true;
                    _letterKey += "_mid";
                    _result.Append(translitTable[_letterKey]);
                    continue;
                }
                if (vowelsLow.Contains(Syl.LowerString[i]))
                {
                    string _hard = _letterKey + Syl.SylTypeString;
                    if (translitTable.ContainsKey(_hard)) _result.Append(translitTable[_hard]);
                    else _result.Append(translitTable[_letterKey]);
                    continue;
                }
                if (gkLettersLow.Contains(Syl.LowerString[i]))
                {
                    if (i + 1 < Syl.SyllableString.Length)
                    {
                        if (hardLettersLow.Contains(Syl.LowerString[i + 1]))
                        {
                            _letterKey += ":";
                        }
                    }
                    else
                    {
                        _letterKey += Syl.SylTypeString;
                    }
                    _result.Append(translitTable[_letterKey]);
                    continue;

                }
                Debug.Assert(translitTable.ContainsKey(_letterKey), "Missing key: " + _letterKey);
                if (translitTable.ContainsKey(_letterKey))
                    _result.Append(translitTable[_letterKey]);
                else 
                    _result.Append(_letterKey);
            }
            return _result.ToString();
        }

        private string TrimYots(string Fragment, int StartIndex)
        {
            if (StartIndex >= Fragment.Length) 
                return Fragment;
            int _YPosition = Fragment.IndexOf('Y', StartIndex);
            int _yPosition = Fragment.IndexOf('y', StartIndex);
            int _firstPosition;
            if (_YPosition == -1)
            {
                if (_yPosition == -1)
                    return Fragment;
                _firstPosition = _yPosition;
            }
            else if (_yPosition == -1)
            {
                _firstPosition = _YPosition;
            }
            else
                _firstPosition = Math.Min(_YPosition, _yPosition);
            if (_firstPosition > 0 &&
                ((Fragment[_firstPosition - 1] == 'I' || Fragment[_firstPosition - 1] == 'i')//for words like ия, remove yot after i
                //|| (_firstPosition > 1 && (Fragment.Substring(_firstPosition - 2, 2) == "i:" || Fragment.Substring(_firstPosition - 2, 2) == "I:")) //for words like зыян, remove yot after I:
                || ((Fragment[_firstPosition - 1] == 'U' || Fragment[_firstPosition - 1] == 'u') && //for words like сөюе, remove yot between ю and е
                (_firstPosition + 1 < Fragment.Length && (Fragment[_firstPosition + 1] == 'E' || Fragment[_firstPosition + 1] == 'e')
                    && (_firstPosition + 2 == Fragment.Length || Fragment[_firstPosition + 2] != ':')))))
            {
                Fragment = Fragment.Remove(_firstPosition, 1);
                StartIndex = _firstPosition;
            }
            else
                StartIndex = _firstPosition + 1;
            Fragment = TrimYots(Fragment, StartIndex);
            return Fragment;
        }

        /// <summary>
        /// Split the word into a list of syllables
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        private List<Syllable> GetSyllables(string word)
        {
            List<Syllable> _syllables = new List<Syllable>();
            char[] _letters = word.ToCharArray();
            string _sylString = string.Empty;
            for (int i = 0; i < _letters.Length; i++)
            {
                if (i + 1 == _letters.Length //word's last letter
                    || (vowels.Contains(_letters[i]) || _sylString.IndexOfAny(vowels) > -1) //this is vowel or current string contains vowel
                    && (_letters[i] == 'ь' || _letters[i] == 'ъ' || _letters[i] == 'Ь' || _letters[i] == 'Ъ' //this is hard/soft sign
                        || (i + 1 < _letters.Length && vowels.Contains(_letters[i]) && vowels.Contains(_letters[i + 1]) //this is vowel and next letter is vowel
                        || i + 2 < _letters.Length && consonants.Contains(_letters[i + 1]) && vowels.Contains(_letters[i + 2])))) //next letter is consonant followed by vowel
                {
                    //syllable is complete
                    _sylString += _letters[i].ToString();
                    _syllables.Add(new Syllable(_sylString, cyrillicCulture));
                    _sylString = string.Empty;
                }
                else
                {
                    //add next letter and continue
                    _sylString += _letters[i].ToString();
                }
            }
            return _syllables;
        }

        private List<Syllable> DetermineSyllables(string word)
        {            
            List<Syllable> _syls = GetSyllables(word);
            for (int i = 0; i < _syls.Count; i++)
            {
                SetSyllableType(_syls[i], i == _syls.Count - 1);
            }
            int _cycleCounter = 0;//to prevent stack overflow
            while (_syls.Exists(_syl => _syl.IsIndeterminate))
            {
                if (_cycleCounter == _syls.Count)
                {
                    for (int i = 0; i < _syls.Count; i++)
                    {
                        if (_syls[i].IsIndeterminate) 
                            _syls[i].SyllableType = ESyllableTypes.Hard;
                    }
                    break;
                }
                for (int i = _syls.Count - 1; i >= 0; i--) //reverse order for next syllable to prevail over previous one
                {
                    if (_syls[i].IsIndeterminate)
                    {
                        if (i > 0)
                        {
                            //ый is more likely to be soft if any syllable near is soft
                            if (_syls[i].LowerString.Contains("ый"))
                            {
                                if (_syls[i - 1].SyllableType == ESyllableTypes.Soft
                                    || i + 1 < _syls.Count && _syls[i + 1].SyllableType == ESyllableTypes.Soft) 
                                    _syls[i].SyllableType = ESyllableTypes.Soft;
                            }
                            if (_syls[i].IsIndeterminate) //otherwise, judge by next syllable, then by previous
                            { 
                                //if next syllable exists and is determined, take its type
                                if (i + 1 < _syls.Count && !_syls[i + 1].IsIndeterminate) 
                                    _syls[i].SyllableType = _syls[i + 1].SyllableType;
                                //otherwise, if previous syllable is determined, take its type
                                else if (!_syls[i - 1].IsIndeterminate)
                                    _syls[i].SyllableType = _syls[i - 1].SyllableType;
                                //otherwise leave indeterminate for this time
                                //else 
                                //    _syls[i].SyllableType = ESyllableTypes.Hard;
                            }
                        }
                        else //this is first syllable
                        {
                            //if there is only one syllable in the word, it is considered hard
                            //otherwise it is the same type as next syllable
                            _syls[i].SyllableType = i + 1 < _syls.Count ? _syls[i + 1].SyllableType : ESyllableTypes.Hard;
                        }
                    }
                }
                _cycleCounter++;
            }
            return _syls;
        }


            private void SetSyllableType(Syllable Syllable, bool LastSyllable)
            {
                if (softVowelsLow.Any(_vowel => Syllable.LowerString.Contains(_vowel)) //syllable containes definitely soft vowels 
                    || (ambigCombinationsLow.Any(_comb => Syllable.LowerString.Contains(_comb))
                    || yotatedVowelsLow.Any(_vowel => Syllable.LowerString.Contains(_vowel)))
                        && Syllable.LowerString.EndsWith("ь")
                        && !Syllable.LowerString.EndsWith("кь")
                        && !Syllable.LowerString.EndsWith("гь")//кь and гь don't make syllable soft
                    || Syllable.LowerString.Contains("е") && !Syllable.LowerString.StartsWith("е")
                    || Syllable.LowerString.StartsWith("э"))
                    Syllable.SyllableType = ESyllableTypes.Soft;

                else if (ambigCombinationsLow.Any(_comb => Syllable.LowerString.Contains(_comb)) 
                    && LastSyllable && !Syllable.LowerString.Contains("ый")) //this is the last syllable and it is like га or гат
                    Syllable.SyllableType = ESyllableTypes.Hard; //ый is more likely to be soft in disharmonic words

                else if (hardVowelsLow.Any(_vowel => Syllable.LowerString.Contains(_vowel)) 
                    && !ambigCombinationsLow.Any(_comb => Syllable.LowerString.Contains(_comb)) //contains definitely hard letters and does not contain ambiguous combinations
                        || (ambigCombinationsLow.Any(_comb => Syllable.LowerString.Contains(_comb)) || yotatedVowelsLow.Contains(Syllable.LowerString[0]))
                            && Syllable.LowerString.EndsWith("ъ") && !Syllable.LowerString.EndsWith("къ") && !Syllable.LowerString.EndsWith("гъ")//къ and гъ don't make syllable hard
                        || Syllable.LowerString.Contains("ой") || Syllable.LowerString.Contains("уй") //these diphthongs never read soft
                        || Syllable.LowerString.Contains("гя") || Syllable.LowerString.Contains("кя")) //гя, кя are hard syllables
                    Syllable.SyllableType = ESyllableTypes.Hard;

                else 
                    Syllable.SyllableType = ESyllableTypes.Ambiguous;
            }


        private enum ESyllableTypes { Ambiguous, Soft, Hard };

        private class Syllable
        {
            private string syllableString;
            public string SyllableString
            {
                get { return syllableString; }
            }

            private ESyllableTypes syllableType;
            internal ESyllableTypes SyllableType
            {
                get
                {
                    return syllableType;
                }
                set { syllableType = value; }
            }

            private string lowerString;

            public string LowerString
            {
                get { return lowerString; }
            }

            internal string SylTypeString
            {
                get
                {
                    if (this.syllableType == ESyllableTypes.Hard) 
                        return ":";
                    return string.Empty;
                }
            }

            internal bool IsIndeterminate
            {
                get
                {
                    return this.SyllableType == ESyllableTypes.Ambiguous;
                }
            }

            internal Syllable(string syl, CultureInfo culture)
            {
                this.syllableString = syl;
                this.lowerString = syl.ToLower(culture);
            }

            public override string ToString()
            {
                return this.syllableString;
            }

            internal bool IsContainedLower(char letter)
            {
                return lowerString.Contains(letter.ToString());
            }

            internal bool IsContainedLower(string part)
            {
                return lowerString.Contains(part);
            }
        }
    }
}
