using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Bitig.RtbControl.Utilities;
using System.Text.RegularExpressions;

namespace Bitig.RtbControl
{
    public partial class ctlMultiRtb : UserControl
    {
        private bool x_ApplyFontFormat = true;
        private int x_TlsAdditionalLength;
        private int x_TlsBasicLength;
        private bool x_Loaded = false;
        private string x_CurrentFilePath = string.Empty;
        private string x_CurrentFileName = string.Empty;
        private string x_DummyFileName = "New file";//loc
        private RichTextBoxStreamType x_CurrentFileFormat = RichTextBoxStreamType.RichText;
        //private bool allowChangeEncoding;

        private frmNumericList x_frmNumeric;

        public delegate void CtlMessage(object sender,MessageArgs e);
        public event CtlMessage MessageSent;

        public CRichTextBox RtbMain
        {
            get { return rtbMain; }
        }

        public ctlMultiRtb()
        {
            InitializeComponent();
            FillCmbFont();
            FillCmbFontSize();
            this.MessageSent += new CtlMessage(ctlMultiRtb_MessageSent);
            dlgOpenFile.FileName = string.Empty;
        }

        #region Control Events

        private void  ctlMultiRtb_MessageSent(object sender, MessageArgs e)
        {
 	        
        }

        private void ctlMultiRtb_Load(object sender, EventArgs e)
        {
            x_TlsAdditionalLength = btnBullet.Height * 10 + btnLineSpacing.Width * 2 + 5;
            x_TlsBasicLength = btnItalic.Width * 12 + cmbFont.Width + cmbFontSize.Width + 7;
            x_Loaded = true;
            ArrangeToolStrips();
            //rtbMain.Select(); //rtbMain.Focus();
            this.MessageSent(this, new MessageArgs(string.Format("{0} - Bitig", x_DummyFileName), MessageArgs.EMessageTypes.FileNameChanged));
            rtbMain.Modified = false;
        }

        private void ctlMultiRtb_SizeChanged(object sender, EventArgs e)
        {
            if (x_Loaded)
            {
                ArrangeToolStrips();
            }
        }

        #endregion

        #region RTB events

        private void rtbMain_Enter(object sender, EventArgs e)
        {

        }

        private void rtbMain_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {//move cursor to click location
                if (rtbMain.SelectionLength == 0)
                {
                    int _charIndex = rtbMain.GetCharIndexFromPosition(e.Location);
                    if (_charIndex == rtbMain.Text.Length - 1)//last character
                    {
                        //determine whether click is in front of or behind last character
                        Point _lastCharEdge = rtbMain.GetPositionFromCharIndex(_charIndex + 1);
                        rtbMain.SelectionStart = e.Location.X >= _lastCharEdge.X ? _charIndex + 1 : _charIndex;
                    }
                    else rtbMain.SelectionStart = _charIndex;
                }
                ctxiNumericList.Visible = rtbMain.SelectionNumericList;
            }
        }


        private void rtbMain_SelectionChanged(object sender, EventArgs e)
        {
            DisplayFormat();
        }


        #endregion

        #region Common Methods

        private void ArrangeToolStrips()
        {
            if (tlsBasic.OverflowButton.HasDropDownItems)
            {
                int _lastItem = tlsBasic.Items.Count - 1;
                while (tlsBasic.OverflowButton.HasDropDownItems)
                {
                    tlsAdditional.Items.Insert(0, tlsBasic.Items[_lastItem]);
                    _lastItem--;
                }
                tlsAdditional.Visible = true;
            }
            else if (tlsAdditional.Items.Count > 0)
            {
                int _space = this.Width - tlsBasic.Right;
                int _nextElement = tlsAdditional.Items[0] is ToolStripButton ? tlsAdditional.Items[0].Height : tlsAdditional.Items[0].Width;

                while (_space > _nextElement && tlsAdditional.Items.Count > 0)
                {
                    tlsBasic.Items.Add(tlsAdditional.Items[0]);
                    _space = _space - _nextElement;
                    if (tlsAdditional.Items.Count > 0) _nextElement = tlsAdditional.Items[0] is ToolStripButton ? tlsAdditional.Items[0].Height : tlsAdditional.Items[0].Width;
                    else tlsAdditional.Visible = false;
                }
            }
        }

        private void FillCmbFontSize()
        {
            cmbFontSize.Items.Clear();
            cmbFontSize.Items.AddRange(new object[18] { 4, 6, 8, 9, 10, 11, 12, 14, 16, 18, 20, 22, 24, 26, 28, 36, 48, 72 });
            cmbFontSize.Text = rtbMain.Font.Size.ToString();
        }

        private void FillCmbFont()
        {
            cmbFont.Items.Clear();
            foreach (FontFamily oneFontFamily in FontFamily.Families)
            {
                cmbFont.Items.Add(oneFontFamily.Name);
            }
            cmbFont.SelectedItem = rtbMain.Font.FontFamily.Name;
        }

        #endregion

        #region Text Formatting

        private Regex x_OrdinaryTextRegexFontSize;

        private Regex x_SizeControlWordsRegex;

        private Regex x_FontControlWordsRegex;

        private Regex x_FontNameRegex, x_FontItemRegex;

        private Regex x_OrdinaryTextRegexFontFace;

        private Regex x_FontTableRegex1, x_FontTableRegex2;

        private void DisplayFormat()
        {
            x_ApplyFontFormat = false;
            DisplayFontStyle();
            DisplayFontFace();
            DisplayFontSize();
            DisplayAlignment();
            DisplayBullets();
            x_ApplyFontFormat = true;
        }

        private void RefreshFormat()
        {
            rtbMain.RefreshCurrentCharFormat();
            rtbMain.RefreshCurrentParaFormat();
            DisplayFormat();
        }

        #region Font & Style

        private void cmbFont_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (x_ApplyFontFormat)
            {
                rtbMain.SetSelectionFontFace(cmbFont.Text);
                rtbMain.Select();
            }
        }

        private void cmbFontSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChangeFontSize();
        }

        private void ChangeFontSize()
        {
            if (x_ApplyFontFormat)
            {
                rtbMain.SetSelectionFontSize(Convert.ToInt32(cmbFontSize.Text));
                rtbMain.Select();
            }
        }


        private void cmbFontSize_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.ToString() == "\r")
                ChangeFontSize();
            else
            {
                uint _tempUint;
                if (!uint.TryParse(e.KeyChar.ToString(), out _tempUint) && e.KeyChar.ToString() != "\b")
                    e.Handled = true;
            }
        }


        private void btnItalic_CheckedChanged(object sender, EventArgs e)
        {            
            if (x_ApplyFontFormat)
            {
                if (btnItalic.Checked)
                    rtbMain.SetSelectionStyle(FontStyle.Italic);
                else
                    rtbMain.ClearSelectionStyle(FontStyle.Italic);
            }
        }

        private void btnBold_CheckedChanged(object sender, EventArgs e)
        {
            if (x_ApplyFontFormat)
            {
                if (btnBold.Checked)
                    rtbMain.SetSelectionStyle(FontStyle.Bold);
                else
                    rtbMain.ClearSelectionStyle(FontStyle.Bold);
            }
        }


        private void btnStrikeout_CheckedChanged(object sender, EventArgs e)
        {
            if (x_ApplyFontFormat)
            {
                if (btnStrikeout.Checked)
                    rtbMain.SetSelectionStyle(FontStyle.Strikeout);
                else
                    rtbMain.ClearSelectionStyle(FontStyle.Strikeout);
            }
        }

        private void btnUnderline_CheckedChanged(object sender, EventArgs e)
        {
            if (x_ApplyFontFormat)
            {
                if (btnUnderline.Checked)
                    rtbMain.SetSelectionStyle(FontStyle.Underline);
                else
                    rtbMain.ClearSelectionStyle(FontStyle.Underline);
            }
        }


        private void DisplayAlignment()
        {
            if (AlignmentsDiffer())
            {
                btnAlignCenter.Checked = false;
                btnAlignJustified.Checked = false;
                btnAlignLeft.Checked = false;
                btnAlignRight.Checked = false;
            }
            else switch (rtbMain.SelectionAlignmentWJustify)
                {
                    case EAlignment.Left:
                        btnAlignLeft.Checked = true;
                        break;
                    case EAlignment.Right:
                        btnAlignRight.Checked = true;
                        break;
                    case EAlignment.Center:
                        btnAlignCenter.Checked = true;
                        break;
                    case EAlignment.Justified:
                        btnAlignJustified.Checked = true;
                        break;
                }
        }

        private void DisplayFontSize()
        {
            if (FontSizesDiffer())
                cmbFontSize.Text = string.Empty;
            else
                cmbFontSize.Text = rtbMain.SelectionFontSize.ToString();
        }

        private void DisplayFontFace()
        {
            if (FontFacesDiffer())
            {
                cmbFont.Text = string.Empty;
            }
            else
            {
                cmbFont.Text = rtbMain.SelectionFontFace;
            }
        }

        private void DisplayFontStyle()
        {
            FontStyle _style = rtbMain.SelectionStyle;
            btnItalic.Checked = (_style & FontStyle.Italic) == FontStyle.Italic;
            btnBold.Checked = (_style & FontStyle.Bold) == FontStyle.Bold;
            btnUnderline.Checked = (_style & FontStyle.Underline) == FontStyle.Underline;
            btnStrikeout.Checked = (_style & FontStyle.Strikeout) == FontStyle.Strikeout;
        }
        private bool FontSizesDiffer()
        {
            /* explanation for regular expressions
             * [^\}\{]* match any number of symbols not containing } and {
             * \\fs[0-9]+ match \fsN (font size control word)
             * (?<=\})[^\}\{]*(?<!\\)\\fs[0-9]+[^\}\{]* match text witn fsN after }
             * (?=\{) match text before {
             * | OR
             * (?<=\})[^\}\{]*\\fs[0-9]+[^\}\{]*((?=\{)|(?=\})) match text witn fsN 
             *      between }{ (to exclude bullet font sizes) and }} (for the last incomplete paragraph)
             */
            if (rtbMain.SelectionLength <= 1) return false;
            if (x_OrdinaryTextRegexFontSize == null) x_OrdinaryTextRegexFontSize = new Regex(@"(?<=\})[^\}\{]*\\fs[0-9]+[^\}\{]*((?=\{)|(?=\}))");
            if (x_SizeControlWordsRegex == null) x_SizeControlWordsRegex = new Regex(@"\\fs(?<size>[0-9]+)");
            string _clearInput = ClearInput();
            MatchCollection _matches = x_OrdinaryTextRegexFontSize.Matches(_clearInput);
            List<string> _sizes = new List<string>();
            foreach (Match _match in _matches)
            {
                MatchCollection _sizeMatches = x_SizeControlWordsRegex.Matches(_match.Value);
                foreach (Match _sizeMatch in _sizeMatches)
                {
                    if (!string.IsNullOrEmpty(_sizeMatch.Groups["size"].Value) && !_sizes.Contains(_sizeMatch.Groups["size"].Value))
                        _sizes.Add(_sizeMatch.Groups["size"].Value);
                }
            }
            return (_sizes.Count() > 1);
        }

        private bool FontFacesDiffer()
        {
            /* explanation for regular expressions
             * \\fonttbl\b matches \fonttbl control word
             * [^\}\{]* matches any number of symbols not containing } and {
             * \{([^\{\}]*(\{\\\*[^\{\}]*\})?)+;\} matches sequence enclosed in {} optionally including text in {\*}
             * \\f[0-9]+ matches \fN (font face control word)
             * \\f(?<index>[0-9]+).*?\s+(?<name>[^\\\{\};]*).*?; matches font description group
             * \\f(?<index>[0-9]+)(?:(?!\\f[0-9]).)* matches the nearest preceding fN control word
             * \\f(?<index>[0-9]+)(?:(?!\\f[0-9]).)*\{\\\*\\fname\s+(?<name>[^\\\{\};]*);\} matches font group with \*\fname control word (font name to display)
             * (?<=\})[^\}\{]*\\f[0-9]+[^\}\{]*((?=\{)|(?=\})) match text witn fN 
             *      between }{ (to exclude bullet font sizes and font tables) and }} (for the last incomplete paragraph)
             * | OR
             */
            if (rtbMain.SelectionLength <= 1) return false;
            string _clearInput = ClearInput();
            string _table = string.Empty;
            if (x_FontTableRegex1 == null) x_FontTableRegex1 = new Regex(@"\{\\fonttbl(?<table>(\{([^\{\}]*(\{\\\*[^\{\}]*\})?)+;\})+\})");
            Match _fontTableContents = x_FontTableRegex1.Match(_clearInput);
            if (_fontTableContents.Success)
            {
                _table = _fontTableContents.Groups["table"].Value;
            }
            else
            {
                if (x_FontTableRegex2 == null) x_FontTableRegex2 = new Regex(@"\{\\fonttbl\b(?<table>([^\{\}]*(\{\\\*[^\{\}]*\})?)+;)+\}");
                _fontTableContents = x_FontTableRegex2.Match(_clearInput);
                if (_fontTableContents.Success) _table = _fontTableContents.Groups["table"].Value;
            }
            System.Collections.Specialized.StringDictionary _dict = new System.Collections.Specialized.StringDictionary();
            if (!string.IsNullOrEmpty(_table))
            {
                if (x_FontNameRegex == null) x_FontNameRegex = new Regex(@"\\f(?<index>[0-9]+)(?:(?!\\f[0-9]).)*\{\\\*\\fname\s+(?<name>[^\\\{\};]*);\}");
                if (x_FontItemRegex == null) x_FontItemRegex = new Regex(@"\\f(?<index>[0-9]+).*?\s+(?<name>[^\\\{\};]*).*?;");
                foreach (Match _fname in x_FontNameRegex.Matches(_table))
                {
                    if (!string.IsNullOrEmpty(_fname.Groups["name"].Value) && !string.IsNullOrEmpty(_fname.Groups["index"].Value))
                        _dict.Add(_fname.Groups["index"].Value, _fname.Groups["name"].Value.Trim());
                }
                foreach (Match _fontItem in x_FontItemRegex.Matches(_table))
                {
                    if (!string.IsNullOrEmpty(_fontItem.Groups["name"].Value) && !string.IsNullOrEmpty(_fontItem.Groups["index"].Value)
                        && !_dict.ContainsKey(_fontItem.Groups["index"].Value))
                        _dict.Add(_fontItem.Groups["index"].Value, _fontItem.Groups["name"].Value.Trim());
                }
            }
            if (x_OrdinaryTextRegexFontFace == null) x_OrdinaryTextRegexFontFace = new Regex(@"(?<=\})[^\}\{]*\\f[0-9]+[^\}\{]*((?=\{)|(?=\}))");
            MatchCollection _ordinaryMatches = x_OrdinaryTextRegexFontFace.Matches(_clearInput);
            List<string> _fonts = new List<string>();
            if (x_FontControlWordsRegex == null) x_FontControlWordsRegex = new Regex(@"\\f(?<face>[0-9]+)");
            foreach (Match _match in _ordinaryMatches)
            {
                MatchCollection _fontMatches = x_FontControlWordsRegex.Matches(_match.Value);
                foreach (Match _fontMatch in _fontMatches)
                {
                    if (!string.IsNullOrEmpty(_fontMatch.Groups["face"].Value))
                    {
                        if (_dict.ContainsKey(_fontMatch.Groups["face"].Value))
                        {
                            if (!_fonts.Contains(_dict[_fontMatch.Groups["face"].Value]))
                                _fonts.Add(_dict[_fontMatch.Groups["face"].Value]);
                        }
                        else if (!_fonts.Contains(_fontMatch.Groups["face"].Value))
                            _fonts.Add(_fontMatch.Groups["face"].Value);
                    }
                }
            }
            return _fonts.Count > 1;
        }

        /// <summary>
        ///Strip escaped control symbols from selected text
        /// </summary>
        /// <returns></returns>
        private string ClearInput()
        {
            string _clearInput = rtbMain.SelectedRtf.Replace(@"\\\\", "");
            _clearInput = _clearInput.Replace(@"\\{", "");
            _clearInput = _clearInput.Replace(@"\\}", "");
            return _clearInput;
        }

        private bool GetAvailableFontStyle(FontFamily TargetFamily, out FontStyle SupportedStyle)
        {
            SupportedStyle = FontStyle.Regular;
            if (TargetFamily.IsStyleAvailable(FontStyle.Regular))
                return true;
            if (TargetFamily.IsStyleAvailable(FontStyle.Italic))
            {
                SupportedStyle = FontStyle.Italic;
                return true;
            }
            if (TargetFamily.IsStyleAvailable(FontStyle.Bold))
            {
                SupportedStyle = FontStyle.Bold;
                return true;
            }
            if (TargetFamily.IsStyleAvailable(FontStyle.Underline))
            {
                SupportedStyle = FontStyle.Underline;
                return true;
            }
            if (TargetFamily.IsStyleAvailable(FontStyle.Strikeout))
            {
                SupportedStyle = FontStyle.Strikeout;
                return true;
            }
            return false;
        }

        #endregion

        #region Alignment

        private void btnAlignLeft_Click(object sender, EventArgs e)
        {
            if (x_ApplyFontFormat)
            {
                rtbMain.SelectionAlignment = HorizontalAlignment.Left;
                rtbMain.RefreshCurrentParaFormat();
                btnAlignLeft.Checked = true;
            }
        }

        private void btnAlignRight_Click(object sender, EventArgs e)
        {
            if (x_ApplyFontFormat)
            {
                rtbMain.SelectionAlignment = HorizontalAlignment.Right;
                rtbMain.RefreshCurrentParaFormat();
                btnAlignRight.Checked = true;
            }
        }

        private void btnAlignCenter_Click(object sender, EventArgs e)
        {
            if (x_ApplyFontFormat)
            {
                rtbMain.SelectionAlignment = HorizontalAlignment.Center;
                rtbMain.RefreshCurrentParaFormat();
                btnAlignCenter.Checked = true;
            }
        }

        private void btnAlignJustified_Click(object sender, EventArgs e)
        {
            if (x_ApplyFontFormat)
            {
                rtbMain.Justify();
                btnAlignJustified.Checked = true;
            }
        }

        private void btnAlignLeft_CheckedChanged(object sender, EventArgs e)
        {
            if (btnAlignLeft.Checked)
            {
                btnAlignCenter.Checked = false;
                btnAlignJustified.Checked = false;
                btnAlignRight.Checked = false;
            }
        }

        private void btnAlignRight_CheckedChanged(object sender, EventArgs e)
        {
            if (btnAlignRight.Checked)
            {
                btnAlignCenter.Checked = false;
                btnAlignJustified.Checked = false;
                btnAlignLeft.Checked = false;
            }
        }

        private void btnAlignCenter_CheckedChanged(object sender, EventArgs e)
        {
            if (btnAlignCenter.Checked)
            {
                btnAlignJustified.Checked = false;
                btnAlignLeft.Checked = false;
                btnAlignRight.Checked = false;
            }
        }

        private void btnAlignJustified_CheckedChanged(object sender, EventArgs e)
        {
            if (btnAlignJustified.Checked)
            {
                btnAlignLeft.Checked = false;
                btnAlignRight.Checked = false;
                btnAlignCenter.Checked = false;
            }
        }


        private bool AlignmentsDiffer()
        {
            if (rtbMain.SelectionLength <= 1) return false;
            bool _result = false;
            /* explanation for regular expressions
             * (?<!\\) match expression not preceded by \
             * (?:\\{2})* match even number of \ (noncapturing group)
             * \\par match \par (paragraph delimiter)
             * q[r,c,j] match qr (right alignment), qc (center), qj (justify)
             */
            Regex _paragraph = new Regex(@"(?<!\\)(?:\\{2})*\\par\b");
            if (_paragraph.IsMatch(rtbMain.SelectedRtf))
            {
                Regex _rcjAlignment = new Regex(@"(?<!\\)(?:\\{2})*\\q(?<align>[r,c,j])\b");
                Regex _resetParagraph = new Regex(@"(?<!\\)(?:\\{2})*\\pard\b");
                if (_rcjAlignment.IsMatch(rtbMain.SelectedRtf))
                {
                    MatchCollection _alignmentMatches = _rcjAlignment.Matches(rtbMain.SelectedRtf);
                    List<string> _alignmentValues = new List<string>();
                    foreach (Match _match in _alignmentMatches)
                    {
                        _alignmentValues.Add(_match.Groups["align"].Value);
                    }
                    _result = _alignmentValues.GroupBy(_value => _value).Count() > 1;
                    if (!_result)
                    {
                        Regex _parseParagraphs = new Regex(@"(?<group1>.*?(?<!\\)(?:\\{2})*)\\par\b", RegexOptions.Singleline);
                        Regex _lastParagraph = new Regex(@".*(?<!\\)(?:\\{2})*\\par\b(?<group2>.*)", RegexOptions.Singleline);
                        foreach (Match _m in _parseParagraphs.Matches(rtbMain.SelectedRtf))
                        {
                            if (!_rcjAlignment.IsMatch(_m.Groups["group1"].Value) && _resetParagraph.IsMatch(_m.Groups["group1"].Value))
                            {
                                _result = true;
                                break;
                            }
                        }
                        if (!_result)
                        {
                            foreach (Match _m in _lastParagraph.Matches(rtbMain.SelectedRtf))
                            {
                                if (!_rcjAlignment.IsMatch(_m.Groups["group2"].Value) && _resetParagraph.IsMatch(_m.Groups["group2"].Value))
                                {
                                    _result = true;
                                    break;
                                }
                            }
                        }
                    }
                }
                else
                {
                    _result = false;
                }
            }
            else
            {
                _result = false;
            }
            return _result;
        }
        
        #endregion


        #region Numeric List & Bullets

        private void btnBullet_Click(object sender, EventArgs e)
        {
            if (x_ApplyFontFormat)
            {
                rtbMain.SelectionBullet = btnBullet.Checked;
                rtbMain.RefreshCurrentParaFormat();
                DisplayBullets();
            }
        }

        private void DisplayBullets()
        {
            btnBullet.Checked = rtbMain.SelectionBullet;
            btnNumericList.Checked = rtbMain.SelectionNumericList;
        }
        private void btnNumericList_Click(object sender, EventArgs e)
        {
            if (x_ApplyFontFormat)
            {
                if (btnNumericList.Checked)
                {
                    if (x_frmNumeric == null || x_frmNumeric.X_ListType == ENumericListType.Bullet || x_frmNumeric.X_ListType == ENumericListType.None)
                        rtbMain.SetNumericList(ENumericListType.Arabic, ENumericListFormat.Parenthesis, 1, 280);
                    else
                        rtbMain.SetNumericList(x_frmNumeric.X_ListType, x_frmNumeric.X_ListFormat, 1, x_frmNumeric.X_IndentTwips);
                }
                else
                    rtbMain.ClearNumericList();
                DisplayBullets();
            }
        }

        private void ctxiNumericList_Click(object sender, EventArgs e)
        {
            DisplayNumericListForm();
        }

        private void mniNumericList_Click(object sender, EventArgs e)
        {
            DisplayNumericListForm();
        }

        private void DisplayNumericListForm()
        {
            if (x_frmNumeric == null)
                x_frmNumeric = new frmNumericList(rtbMain.SelectionListType, rtbMain.SelectionListFormat);
            else x_frmNumeric.SetSelectedList(rtbMain.SelectionListType, rtbMain.SelectionListFormat);
            if (rtbMain.SelectionNumericList)
            {
               // x_frmNumeric.SetSelectedList(rtbMain.SelectionListType, rtbMain.SelectionListFormat);
                x_frmNumeric.X_IndentTwips = rtbMain.SelectionListIndent;
                x_frmNumeric.X_StartWith = rtbMain.SelectionListStart;
            }
            if (x_frmNumeric.ShowDialog() == DialogResult.OK)
            {
                rtbMain.SetNumericList(x_frmNumeric.X_ListType, x_frmNumeric.X_ListFormat, x_frmNumeric.X_StartWith, x_frmNumeric.X_IndentTwips);
                DisplayBullets();
            }
        }

        #endregion

        #region Text Colors

        private void btnForecolor_Click(object sender, EventArgs e)
        {
            if (dlgColor.ShowDialog() == DialogResult.OK)
            {
                rtbMain.SelectionColor = dlgColor.Color;
            }
        }

        private void btnBackcolor_Click(object sender, EventArgs e)
        {
            if (dlgColor.ShowDialog() == DialogResult.OK)
            {
                rtbMain.SelectionBackColor = dlgColor.Color;
            }
        }

        #endregion

        #region Image

        private void btnImage_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(rtbMain.SelectedRtf);
            //AlignmentsDiffer();        
            //FontFacesDiffer();
            //FontSizesDiffer();
            //            rtbMain.Rtf = @"{\rtf1\fbidis\ansi\ansicpg1251\deff0\deflang1049\deflangfe1049\deftab708{\fonttbl{\f0\froman\fprq2\fcharset204{\*\fname Times New Roman;}Times New Roman CYR;}{\f1\fnil\fcharset2 Symbol;}}
            //\uc1\pard{\pntext\f1\'2A\tab}{\*\pn\pnlvlblt\pnf1\pnindent0{\pntxtb\'2A}}\ltrpar\fi-12000\li12360\f0\fs24 testtext}";
        }

        #endregion

        #region Subscripts & Superscripts

        private void btnSubscript_Click(object sender, EventArgs e)
        {
            rtbMain.SelectionCharOffset = -1;
            rtbMain.RefreshCurrentCharFormat();
        }

        private void btnSuperscript_Click(object sender, EventArgs e)
        {
            rtbMain.SelectionCharOffset = 1;
            rtbMain.RefreshCurrentCharFormat();
        }

        #endregion

        #region Line Spacing

        private void mniSpacing10_Click(object sender, EventArgs e)
        {
            mniSpacing115.Checked = false;
            mniSpacing15.Checked = false;
            mniSpacing20.Checked = false;
            rtbMain.SetLineSpacing(1);
        }

        private void mniSpacing115_Click(object sender, EventArgs e)
        {
            mniSpacing10.Checked = false;
            mniSpacing15.Checked = false;
            mniSpacing20.Checked = false;
            rtbMain.SetLineSpacing(1.15);
        }

        private void mniSpacing15_Click(object sender, EventArgs e)
        {
            mniSpacing115.Checked = false;
            mniSpacing10.Checked = false;
            mniSpacing20.Checked = false;
            rtbMain.SetLineSpacing(1.5);
        }

        private void mniSpacing20_Click(object sender, EventArgs e)
        {
            mniSpacing115.Checked = false;
            mniSpacing15.Checked = false;
            mniSpacing10.Checked = false;
            rtbMain.SetLineSpacing(2);
        }


        #endregion

        #region Indents

        private void btnIndent_Click(object sender, EventArgs e)
        {

        }


        private void btnRemoveIndent_Click(object sender, EventArgs e)
        {

        }

        #endregion

        #region Paragraph Properties

        private void btnParagraph_Click(object sender, EventArgs e)
        {

        }

        #endregion

        #endregion

        #region File IO


        private void btnOpen_Click(object sender, EventArgs e)
        {
            OpenFile();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveFile();
        }

        private void mniNew_Click(object sender, EventArgs e)
        {
            NewFile();
        }

        private void mniOpen_Click(object sender, EventArgs e)
        {
            OpenFile();
        }

        private void mniSave_Click(object sender, EventArgs e)
        {
            SaveFile();
        }

        private void mniSaveAs_Click(object sender, EventArgs e)
        {
            SaveFileAs();
        }

        private void mniUtf8_Click(object sender, EventArgs e)
        {
            Reopen(Encoding.UTF8);
        }

        private void mniUtf16_Click(object sender, EventArgs e)
        {
            Reopen(Encoding.Unicode);
        }

        private void mniUtf7_Click(object sender, EventArgs e)
        {
            Reopen(Encoding.UTF7);
        }

        private void mniUtf32_Click(object sender, EventArgs e)
        {
            Reopen(Encoding.UTF32);
        }

        private void mniBigEndian_Click(object sender, EventArgs e)
        {
            Reopen(Encoding.BigEndianUnicode);
        }

        private void mniAnsi_Click(object sender, EventArgs e)
        {
            Reopen(Encoding.Default);
        }
        private void mniAscii_Click(object sender, EventArgs e)
        {
            Reopen(Encoding.ASCII);
        }

        public void Reopen(Encoding TargetEncoding)
        {
            Font _currentFont = rtbMain.Font;
            if (x_CurrentFileFormat == RichTextBoxStreamType.RichText || string.IsNullOrEmpty(x_CurrentFilePath) ||
                rtbMain.Modified && MessageBox.Show("All changes will be lost. Proceed?", "!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                return;//loc
            rtbMain.SelectionFont = _currentFont;
            rtbMain.Text = File.ReadAllText(x_CurrentFilePath, TargetEncoding);
            //todo:rtbMain.Font = _currentFont;
            rtbMain.Modified = false;
        }


        /// <summary>
        /// If returns true, you can proceed with your action (e.g. creating a new file)
        /// </summary>
        public bool PromptSave()
        {
            if (!rtbMain.Modified) return true;
            bool _result = false;
            switch (MessageBox.Show(string.Format("Save changes to {0}?", string.IsNullOrEmpty(x_CurrentFileName) ?
            x_DummyFileName : x_CurrentFileName), "?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))//loc
            {
                case DialogResult.Cancel:
                    _result = false;
                    break;
                case DialogResult.No:
                    _result = true;
                    break;
                case DialogResult.Yes:
                    _result = SaveFile();
                    break;
            }
            return _result;
        }

        public void OpenFile()
        {
            if (PromptSave())
            {
                dlgOpenFile.Filter = "Text files (*.txt, *.rtf)|*.txt;*.rtf|All files|*";
                dlgOpenFile.FileName = string.Empty;
                if (dlgOpenFile.ShowDialog() == DialogResult.OK && dlgOpenFile.FileName.Length > 0)
                {
                    OpenFile(dlgOpenFile.FileName);
                }
            }
        }

        public void OpenFile(string FilePath)
        {
            x_CurrentFilePath = FilePath;
            x_CurrentFileName = Path.GetFileName(x_CurrentFilePath);
            this.MessageSent(this, new MessageArgs(x_CurrentFileName + " - Bitig", MessageArgs.EMessageTypes.FileNameChanged));
            try
            {
                rtbMain.LoadFile(FilePath, RichTextBoxStreamType.RichText);
                x_CurrentFileFormat = RichTextBoxStreamType.RichText;
                mniReopen.Enabled = false;
            }
            catch (ArgumentException)
            {
                //using (FileStream fs = File.OpenRead(dlgOpenFile.FileName))
                //{
                //    ICharsetDetector _cdet = new CharsetDetector();
                //    _cdet.Feed(fs);
                //    _cdet.DataEnd();
                //    if (_cdet.Charset != null)
                //    {
                //        Encoding _encoding = Encoding.GetEncoding(_cdet.Charset);
                //        string _text = File.ReadAllText(dlgOpenFile.FileName, _encoding);
                //        rtbMain.Text = _text;
                //    }
                //}
                rtbMain.Clear();
                rtbMain.Text = File.ReadAllText(dlgOpenFile.FileName, Encoding.Default);
                x_CurrentFileFormat = RichTextBoxStreamType.PlainText;
                mniReopen.Enabled = true;
            }
            RefreshFormat();
            rtbMain.Modified = false;
        }


        public bool SaveFile()
        {
            if (x_CurrentFilePath != string.Empty)
            {
                try
                {
                    if (x_CurrentFileFormat == RichTextBoxStreamType.RichText)
                        rtbMain.SaveFile(x_CurrentFilePath, RichTextBoxStreamType.RichText);
                    else
                        File.WriteAllLines(x_CurrentFilePath, rtbMain.Lines, Encoding.Unicode);
                    rtbMain.Modified = false;
                    mniReopen.Enabled = false;
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error saving file: " + ex.Message);
                }
            }
            return SaveFileAs();

        }

        public bool SaveFileAs()
        {
            try
            {
                dlgSaveFile.Filter = "RTF files (*.rtf)|*.rtf|Text files (*.txt)|*.txt";
                dlgSaveFile.FilterIndex = x_CurrentFileFormat == RichTextBoxStreamType.RichText ? 1 : 2;
                dlgSaveFile.FileName = x_CurrentFileName;
                if (dlgSaveFile.ShowDialog() == DialogResult.OK && dlgSaveFile.FileName.Length > 0)
                {
                    x_CurrentFilePath = dlgSaveFile.FileName;
                    x_CurrentFileName = Path.GetFileName(x_CurrentFilePath);
                    switch (dlgSaveFile.FilterIndex)
                    {
                        case 1:
                            x_CurrentFileFormat = RichTextBoxStreamType.RichText;
                            break;
                        case 2:
                            x_CurrentFileFormat = RichTextBoxStreamType.PlainText;
                            break;
                    }
                    SaveFile();
                    this.MessageSent(this, new MessageArgs(x_CurrentFileName + " - Bitig", MessageArgs.EMessageTypes.FileNameChanged));
                    mniReopen.Enabled = false;
                    return true;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving file: " + ex.Message);//loc
                x_CurrentFilePath = string.Empty;
                return false;
            }

        }

        public void NewFile()
        {
            if (PromptSave())
            {
                x_CurrentFilePath = x_CurrentFileName = string.Empty;
                rtbMain.Clear();
                rtbMain.Modified = false;
                this.MessageSent(this, new MessageArgs(string.Format("{0} - Bitig", x_DummyFileName), MessageArgs.EMessageTypes.FileNameChanged));
            }
        }

        #endregion

        #region Public Methods

        public void SaveSettings()
        {
            //Properties.Settings.Default.k_TlsParagraphLocation = tlsAdditional.Location;
            //Properties.Settings.Default.k_TlsTextLocation = tlsBasic.Location;
        }

        public void ResetFormatDisplay()
        {
            rtbMain.RefreshCurrentCharFormat();
            rtbMain.RefreshCurrentParaFormat();
            DisplayFormat();
        }

        #endregion
    }
}
