using System;
using System.Runtime.InteropServices;
using System.Drawing;
using Bitig.RtbControl.Utilities;
using System.ComponentModel;

namespace Bitig.RtbControl
{
    public class CRichTextBox : System.Windows.Forms.RichTextBox
    {
        [StructLayout(LayoutKind.Sequential)]
        private struct STRUCT_RECT
        {
            public Int32 left;
            public Int32 top;
            public Int32 right;
            public Int32 bottom;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct STRUCT_CHARRANGE
        {
            public Int32 cpMin;
            public Int32 cpMax;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct STRUCT_FORMATRANGE
        {
            public IntPtr hdc;
            public IntPtr hdcTarget;
            public STRUCT_RECT rc;
            public STRUCT_RECT rcPage;
            public STRUCT_CHARRANGE chrg;
        }

       /* [StructLayout(LayoutKind.Sequential)]
        private struct STRUCT_CHARFORMAT
        {
            public int cbSize;
            public UInt32 dwMask;
            public UInt32 dwEffects;
            public Int32 yHeight;
            public Int32 yOffset;
            public Int32 crTextColor;
            public byte bCharSet;
            public byte bPitchAndFamily;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
            public char[] szFaceName;
        }*/

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        public struct STRUCT_CHARFORMAT2
        {
            const int LF_FACESIZE = 32;

            public int cbSize;
            public uint dwMask;
            public int dwEffects;
            public int yHeight;
            public int yOffset;            // > 0 for superscript, < 0 for subscript 
            public int crTextColor;
            public byte bCharSet;
            public byte bPitchAndFamily;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = LF_FACESIZE)]
            public string szFaceName;
            public short wWeight;            // Font weight (LOGFONT value)        
            public short sSpacing;            // Amount to space between letters    
            public int crBackColor;        // Background color                    
            public int lcid;                // Locale ID                        
            public int dwReserved;            // Reserved. Must be 0                
            public short sStyle;                // Style handle                        
            public short wKerning;            // Twip size above which to kern char pair
            public byte bUnderlineType;        // Underline type                    
            public byte bAnimation;            // Animated text like marching ants    
            public byte bRevAuthor;            // Revision author index            
            public byte bReserved1;
        }

        [StructLayout(LayoutKind.Sequential)] 
        public struct STRUCT_PARAFORMAT2
        {
            public int cbSize;
            public uint dwMask;
            public ushort wNumbering;
            public short wReserved;
            public int dxStartIndent;
            public int dxRightIndent;
            public int dxOffset;
            public ushort wAlignment;
            public short cTabCount;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
            public int[] rgxTabs;
            public int dySpaceBefore;
            public int dySpaceAfter;
            public int dyLineSpacing;
            public short sStyle;
            public byte bLineSpacingRule;
            public byte bOutlineLevel;
            public ushort wShadingWeight;
            public ushort wShadingStyle;
            public ushort wNumberingStart;
            public ushort wNumberingStyle;
            public ushort wNumberingTab;
            public ushort wBorderSpace;
            public ushort wBorderWidth;
            public ushort wBorders; 
        }

        [DllImport("user32.dll")]
        private static extern Int32 SendMessage(IntPtr hWnd, Int32 msg, Int32 wParam, IntPtr lParam);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int SendMessage(IntPtr hWnd, int msg, int wParam, int lParam);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int SendMessage(IntPtr hWnd, int msg, int wParam, ref STRUCT_CHARFORMAT2 cf);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int SendMessage(IntPtr hWnd, int msg, int wParam, ref STRUCT_PARAFORMAT2 cf);

        private const Int32 WM_USER = 0x400;
        private const Int32 EM_FORMATRANGE = WM_USER + 57;
        private const int SCF_SELECTION = 0x0001;

        private const int EM_GETPARAFORMAT = WM_USER + 61;
        private const int EM_SETPARAFORMAT = WM_USER + 71;

        private const int PFM_ALIGNMENT = 0x00000008;
        internal const int PFA_LEFT = 1;
        internal const int PFA_RIGHT = 2;
        internal const int PFA_CENTER = 3;
        internal const int PFA_JUSTIFY = 4;

        private const int PFM_NUMBERINGSTYLE = 0x00002000;
        private const int PFM_NUMBERING = 0x00000020;
        private const int PFM_NUMBERINGSTART = 0x00008000;
        private const int PFM_NUMBERINGTAB = 0x00004000;
        // PARAFORMAT2 wNumbering options 
        internal const ushort PFN_BULLET = 1;	// Bullet
        internal const ushort PFN_ARABIC = 2;	// 0, 1, 2,	...
        internal const ushort PFN_LCLETTER = 3;	// a, b, c,	...
        internal const ushort PFN_UCLETTER = 4;	// A, B, C,	...
        internal const ushort PFN_LCROMAN = 5;	// i, ii, iii,	...
        internal const ushort PFN_UCROMAN = 6;	// I, II, III,	...
        // PARAFORMAT2 wNumberingStyle options 
        internal const ushort PFNS_PAREN = 0x000;	// default, 1)	
        internal const ushort PFNS_PARENS = 0x100;	//  (1)	
        internal const ushort PFNS_PERIOD = 0x200;  //   1.	
        internal const ushort PFNS_PLAIN = 0x300;	//   1		
        internal const ushort PFNS_NONUMBER = 0x400;	// Used for continuation w/o number
        internal const ushort PFNS_NEWNUMBER = 0x8000;// Start new number with wNumberingStart	(can be combined with other PFNS_xxx)

        private const int PFM_LINESPACING = 0x00000100;

        private const int EM_GETCHARFORMAT = WM_USER + 58; 
        private const int EM_SETCHARFORMAT = WM_USER + 68;

        private const Int32 CFM_BOLD = 0x00000001;
        private const Int32 CFM_ITALIC = 0x00000002;
        private const Int32 CFM_UNDERLINE = 0x00000004;
        private const Int32 CFM_STRIKEOUT = 0x00000008;
        private const Int32 CFE_BOLD = 0x00000001;
        private const Int32 CFE_ITALIC = 0x00000002;
        private const Int32 CFE_UNDERLINE = 0x00000004;
        private const Int32 CFE_STRIKEOUT = 0x00000008;

        private const Int32 CFM_PROTECTED = 0x00000010;
        private const Int32 CFM_LINK = 0x00000020;
        private const UInt32 CFM_SIZE = 0x80000000;
        private const Int32 CFM_COLOR = 0x40000000;
        private const Int32 CFM_FACE = 0x20000000;
        private const Int32 CFM_CHARSET = 0x08000000;
        private const Int32 CFM_OFFSET = 0x10000000;
        private const UInt32 CFM_SUBSCRIPT = CFE_SUBSCRIPT | CFE_SUPERSCRIPT;
        private const UInt32 CFM_SUPERSCRIPT = CFM_SUBSCRIPT;
        private const Int32 CFE_PROTECTED = 0x00000010;
        private const Int32 CFE_LINK = 0x00000020;
        private const Int32 CFE_AUTOCOLOR = 0x40000000;
        private const Int32 CFE_SUBSCRIPT = 0x00010000;
        private const Int32 CFE_SUPERSCRIPT = 0x00020000;

        private const Int32 EM_GETLANGOPTIONS = WM_USER + 121;
        private const Int32 EM_SETLANGOPTIONS = WM_USER + 120;
        private const Int32 IMF_AUTOFONT = 0x0002;

        private const int EM_SETTYPOGRAPHYOPTIONS = WM_USER + 202;
        private const int TO_ADVANCEDTYPOGRAPHY = 0x0001;

        private STRUCT_CHARFORMAT2 x_CurrentCharFormat;
        private STRUCT_PARAFORMAT2 x_CurrentParaFormat;

        #region Properties

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        internal ENumericListFormat SelectionListFormat
        {
            get {
                if ((x_CurrentParaFormat.wNumberingStyle & PFNS_NEWNUMBER) == PFNS_NEWNUMBER)
                    return (ENumericListFormat)(x_CurrentParaFormat.wNumberingStyle ^ PFNS_NEWNUMBER);
                return (ENumericListFormat)x_CurrentParaFormat.wNumberingStyle;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        internal ENumericListType SelectionListType
        {
            get { return (ENumericListType)x_CurrentParaFormat.wNumbering; }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        internal ushort SelectionListStart
        {
            get { return x_CurrentParaFormat.wNumberingStart; }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        internal ushort SelectionListIndent
        {
            get { return x_CurrentParaFormat.wNumberingTab; }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        internal bool SelectionNumericList
        {
            //STRUCT_PARAFORMAT2 fmt = new STRUCT_PARAFORMAT2();
            //fmt.cbSize = Marshal.SizeOf(fmt);
            //int res = SendMessage(Handle, EM_GETPARAFORMAT, 0, ref fmt);
            get { return x_CurrentParaFormat.wNumbering > 1; }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        internal double SelectionLineSpacing
        {
            //STRUCT_PARAFORMAT2 fmt = new STRUCT_PARAFORMAT2();
            //fmt.cbSize = Marshal.SizeOf(fmt);
            //int res = SendMessage(Handle, EM_GETPARAFORMAT, 0, ref fmt);
            //switch (fmt.bLineSpacingRule)
            get
            {
                switch (x_CurrentParaFormat.bLineSpacingRule)
                {
                    case 0:
                        return 1;
                    case 1:
                        return 1.5;
                    case 2:
                        return 2;
                    case 3:
                    case 4:
                        return x_CurrentParaFormat.dyLineSpacing;
                    case 5:
                        return (double)x_CurrentParaFormat.dyLineSpacing / 20;
                    default:
                        return 1;
                }
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        internal EAlignment SelectionAlignmentWJustify
        {
            //STRUCT_PARAFORMAT2 fmt = new STRUCT_PARAFORMAT2();
            //fmt.cbSize = Marshal.SizeOf(fmt);
            //int res = SendMessage(Handle, EM_GETPARAFORMAT, 0, ref fmt);
            get
            {
                switch (x_CurrentParaFormat.wAlignment)
                {
                    case PFA_CENTER:
                        return EAlignment.Center;
                    case PFA_JUSTIFY:
                        return EAlignment.Justified;
                    case PFA_RIGHT:
                        return EAlignment.Right;
                    default:
                        return EAlignment.Left;
                }
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        internal int SelectionFontSize
        {
            //STRUCT_CHARFORMAT2 cf2 = new STRUCT_CHARFORMAT2();
            //cf2.cbSize = Marshal.SizeOf(typeof(STRUCT_CHARFORMAT2));
            //int _res = SendMessage(this.Handle, EM_GETCHARFORMAT, SCF_SELECTION, ref cf2);
            //int _size = 12;
            //if (_res != 0)
            //{
            //    _size = (int) (cf2.yHeight / 20);
            //}
            //return _size;
            get { return (int)(x_CurrentCharFormat.yHeight / 20); }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        internal FontStyle SelectionStyle
        {
            //STRUCT_CHARFORMAT2 cf2 = new STRUCT_CHARFORMAT2();
            //cf2.cbSize = Marshal.SizeOf(typeof(STRUCT_CHARFORMAT2));
            //int _res = SendMessage(this.Handle, EM_GETCHARFORMAT, SCF_SELECTION, ref cf2);
            get
            {
                FontStyle _style = FontStyle.Regular;
                if ((x_CurrentCharFormat.dwMask & CFM_BOLD) == CFM_BOLD && (x_CurrentCharFormat.dwEffects & CFE_BOLD) == CFE_BOLD) _style |= FontStyle.Bold;
                if ((x_CurrentCharFormat.dwMask & CFM_ITALIC) == CFM_ITALIC && (x_CurrentCharFormat.dwEffects & CFE_ITALIC) == CFE_ITALIC) _style |= FontStyle.Italic;
                if ((x_CurrentCharFormat.dwMask & CFM_STRIKEOUT) == CFM_STRIKEOUT && (x_CurrentCharFormat.dwEffects & CFE_STRIKEOUT) == CFE_STRIKEOUT) _style |= FontStyle.Strikeout;
                if ((x_CurrentCharFormat.dwMask & CFM_UNDERLINE) == CFM_UNDERLINE && (x_CurrentCharFormat.dwEffects & CFE_UNDERLINE) == CFE_UNDERLINE) _style |= FontStyle.Underline;
                return _style;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        internal string SelectionFontFace
        {
            //string FaceName = string.Empty;
            //STRUCT_CHARFORMAT2 cf2 = new STRUCT_CHARFORMAT2();
            //cf2.cbSize = Marshal.SizeOf(typeof(STRUCT_CHARFORMAT2));
            //int _res = SendMessage(this.Handle, EM_GETCHARFORMAT, SCF_SELECTION, ref cf2);
            //if (_res != 0)
            //{
            //    FaceName = cf2.szFaceName;
            //}
            //return FaceName;
            get
            {
                return x_CurrentCharFormat.szFaceName;
            }
        }
        #endregion

        public CRichTextBox()
        {
            x_CurrentCharFormat = new STRUCT_CHARFORMAT2();
            x_CurrentCharFormat.cbSize = Marshal.SizeOf(typeof(STRUCT_CHARFORMAT2));
            x_CurrentParaFormat = new STRUCT_PARAFORMAT2();
            x_CurrentParaFormat.cbSize = Marshal.SizeOf(typeof(STRUCT_PARAFORMAT2));
            EnableJustify();
            DisableAutoFont();
        }

        protected override void OnSelectionChanged(EventArgs e)
        {
            SendMessage(Handle, EM_GETPARAFORMAT, 0, ref x_CurrentParaFormat);
            SendMessage(Handle, EM_GETCHARFORMAT, SCF_SELECTION, ref x_CurrentCharFormat);
            base.OnSelectionChanged(e);
        }

        internal void RefreshCurrentParaFormat()
        {
            SendMessage(Handle, EM_GETPARAFORMAT, 0, ref x_CurrentParaFormat);
        }

        internal void RefreshCurrentCharFormat()
        {
            SendMessage(Handle, EM_GETCHARFORMAT, SCF_SELECTION, ref x_CurrentCharFormat);
        }

        internal void EnableJustify()
        {
            SendMessage(Handle, EM_SETTYPOGRAPHYOPTIONS, TO_ADVANCEDTYPOGRAPHY, TO_ADVANCEDTYPOGRAPHY);
        }

        internal void DisableAutoFont()
        {/*
            IntPtr lparam = new IntPtr(0);
            int lres = SendMessage(Handle, EM_GETLANGOPTIONS, 0, lparam);
            lres &= ~IMF_AUTOFONT;
            int res = SendMessage(Handle, EM_SETLANGOPTIONS, 0, lres);*/
            this.LanguageOption = System.Windows.Forms.RichTextBoxLanguageOptions.DualFont;
        }

        #region Setting Paragraph Format

        internal void Justify()
        {
            STRUCT_PARAFORMAT2 fmt = new STRUCT_PARAFORMAT2();
            fmt.cbSize = Marshal.SizeOf(fmt);
            fmt.dwMask = PFM_ALIGNMENT;
            fmt.wAlignment = PFA_JUSTIFY;
            SendMessage(Handle, EM_SETPARAFORMAT, SCF_SELECTION, ref fmt);
            RefreshCurrentParaFormat();
        }

        internal void SetNumericList(ENumericListType Type, ENumericListFormat Format, ushort StartWith, ushort Indent)
        {
            STRUCT_PARAFORMAT2 fmt = new STRUCT_PARAFORMAT2();
            fmt.cbSize = Marshal.SizeOf(fmt);
            fmt.dwMask = PFM_NUMBERING | PFM_NUMBERINGSTART | PFM_NUMBERINGSTYLE | PFM_NUMBERINGTAB;
            fmt.wNumbering = (ushort) Type;
            fmt.wNumberingStyle = (ushort) ((ushort) Format | PFNS_NEWNUMBER);
            fmt.wNumberingStart = StartWith;
            fmt.wNumberingTab = Indent;

            SendMessage(Handle, EM_SETPARAFORMAT, SCF_SELECTION, ref fmt);
            RefreshCurrentParaFormat();
        }

        internal void ClearNumericList()
        {
            STRUCT_PARAFORMAT2 fmt = new STRUCT_PARAFORMAT2();
            fmt.cbSize = Marshal.SizeOf(fmt);
            fmt.dwMask = PFM_NUMBERING;
            fmt.wNumbering = 0;//no numbering

            SendMessage(Handle, EM_SETPARAFORMAT, SCF_SELECTION, ref fmt);
            RefreshCurrentParaFormat();
        }

        internal void SetLineSpacing(double Value)
        {
            byte _spacing = (byte) (Value * 20);
            STRUCT_PARAFORMAT2 fmt = new STRUCT_PARAFORMAT2();
            fmt.cbSize = Marshal.SizeOf(fmt);
            fmt.dwMask = PFM_LINESPACING;
            fmt.bLineSpacingRule = 5; //The value of dyLineSpacing / 20 is the spacing, in lines, from one line to the next. 
            fmt.dyLineSpacing = _spacing;
            SendMessage(Handle, EM_SETPARAFORMAT, 0, ref fmt);
            RefreshCurrentParaFormat();
        }

        #endregion

        #region  Setting Character Format

        public void SetSelectionStyle(FontStyle Style)
        {
            STRUCT_CHARFORMAT2 cf2 = new STRUCT_CHARFORMAT2();
            cf2.cbSize = Marshal.SizeOf(typeof(STRUCT_CHARFORMAT2));
            if ((Style & FontStyle.Bold) == FontStyle.Bold)
            {
                cf2.dwEffects |= CFE_BOLD;
                cf2.dwMask |= CFM_BOLD;
            }
            if ((Style & FontStyle.Italic) == FontStyle.Italic)
            {
                cf2.dwEffects |= CFE_ITALIC;
                cf2.dwMask |= CFM_ITALIC;
            }
            if ((Style & FontStyle.Strikeout) == FontStyle.Strikeout)
            {
                cf2.dwEffects |= CFE_STRIKEOUT;
                cf2.dwMask |= CFM_STRIKEOUT;
            }
            if ((Style & FontStyle.Underline) == FontStyle.Underline)
            {
                cf2.dwEffects |= CFE_UNDERLINE;
                cf2.dwMask |= CFM_UNDERLINE;
            }
            SendMessage(this.Handle, EM_SETCHARFORMAT, SCF_SELECTION, ref cf2);
            RefreshCurrentCharFormat();
        }

        public void ClearSelectionStyle(FontStyle Style)
        {
            STRUCT_CHARFORMAT2 cf2 = new STRUCT_CHARFORMAT2();
            cf2.cbSize = Marshal.SizeOf(typeof(STRUCT_CHARFORMAT2));
            cf2.dwEffects = 0;
            if ((Style & FontStyle.Bold) == FontStyle.Bold)
            {
                cf2.dwMask |= CFM_BOLD;
            }
            if ((Style & FontStyle.Italic) == FontStyle.Italic)
            {
                cf2.dwMask |= CFM_ITALIC;
            }
            if ((Style & FontStyle.Strikeout) == FontStyle.Strikeout)
            {
                cf2.dwMask |= CFM_STRIKEOUT;
            }
            if ((Style & FontStyle.Underline) == FontStyle.Underline)
            {
                cf2.dwMask |= CFM_UNDERLINE;
            }
            SendMessage(this.Handle, EM_SETCHARFORMAT, SCF_SELECTION, ref cf2);
            RefreshCurrentCharFormat();
        }

        public void SetSelectionFontSize(int FontSize)
        {
            STRUCT_CHARFORMAT2 cf2 = new STRUCT_CHARFORMAT2();
            cf2.cbSize = Marshal.SizeOf(typeof(STRUCT_CHARFORMAT2));

            cf2.dwMask = CFM_SIZE;
            cf2.yHeight = FontSize * 20;

            SendMessage(this.Handle, EM_SETCHARFORMAT, SCF_SELECTION, ref cf2);
            RefreshCurrentCharFormat();
        }

        public void SetSelectionFontFace(string FaceName)
        {
            STRUCT_CHARFORMAT2 cf2 = new STRUCT_CHARFORMAT2();
            cf2.cbSize = Marshal.SizeOf(typeof(STRUCT_CHARFORMAT2));

            cf2.dwMask = CFM_FACE;
            cf2.szFaceName = FaceName;

            SendMessage(this.Handle, EM_SETCHARFORMAT, SCF_SELECTION, ref cf2);
            RefreshCurrentCharFormat();
        }

        #endregion

        #region Printing (not implemented)

        /// <summary>
        /// Calculate or render the contents of our RichTextBox for printing
        /// </summary>
        /// <param name="measureOnly">If true, only the calculation is performed,
        /// otherwise the text is rendered as well</param>
        /// <param name="e">The PrintPageEventArgs object from the
        /// PrintPage event</param>
        /// <param name="charFrom">Index of first character to be printed</param>
        /// <param name="charTo">Index of last character to be printed</param>
        /// <returns>(Index of last character that fitted on the
        /// page) + 1</returns>
        public int FormatRange(bool measureOnly, System.Drawing.Printing.PrintPageEventArgs e,
                               int charFrom, int charTo)
        {
            // Specify which characters to print
            STRUCT_CHARRANGE cr;
            cr.cpMin = charFrom;
            cr.cpMax = charTo;

            // Specify the area inside page margins
            STRUCT_RECT rc;
            rc.top = HundredthInchToTwips(e.MarginBounds.Top);
            rc.bottom = HundredthInchToTwips(e.MarginBounds.Bottom);
            rc.left = HundredthInchToTwips(e.MarginBounds.Left);
            rc.right = HundredthInchToTwips(e.MarginBounds.Right);

            // Specify the page area
            STRUCT_RECT rcPage;
            rcPage.top = HundredthInchToTwips(e.PageBounds.Top);
            rcPage.bottom = HundredthInchToTwips(e.PageBounds.Bottom);
            rcPage.left = HundredthInchToTwips(e.PageBounds.Left);
            rcPage.right = HundredthInchToTwips(e.PageBounds.Right);

            // Get device context of output device
            IntPtr hdc = e.Graphics.GetHdc();

            // Fill in the FORMATRANGE struct
            STRUCT_FORMATRANGE fr;
            fr.chrg = cr;
            fr.hdc = hdc;
            fr.hdcTarget = hdc;
            fr.rc = rc;
            fr.rcPage = rcPage;

            // Non-Zero wParam means render, Zero means measure
            Int32 wParam = (measureOnly ? 0 : 1);

            // Allocate memory for the FORMATRANGE struct and
            // copy the contents of our struct to this memory
            IntPtr lParam = Marshal.AllocCoTaskMem(Marshal.SizeOf(fr));
            Marshal.StructureToPtr(fr, lParam, false);

            // Send the actual Win32 message
            int res = SendMessage(Handle, EM_FORMATRANGE, wParam, lParam);

            // Free allocated memory
            Marshal.FreeCoTaskMem(lParam);

            // and release the device context
            e.Graphics.ReleaseHdc(hdc);

            return res;
        }

        /// <summary>
        /// Convert between 1/100 inch (unit used by the .NET framework)
        /// and twips (1/1440 inch, used by Win32 API calls)
        /// </summary>
        /// <param name="n">Value in 1/100 inch</param>
        /// <returns>Value in twips</returns>
        private Int32 HundredthInchToTwips(int n)
        {
            return (Int32)(n * 14.4);
        }

        /// <summary>
        /// Free cached data from rich edit control after printing
        /// </summary>
        public void FormatRangeDone()
        {
            IntPtr lParam = new IntPtr(0);
            SendMessage(Handle, EM_FORMATRANGE, 0, lParam);
        }


        // variable to trace text to print for pagination
        private int m_nFirstCharOnPage;

        private void printDoc_BeginPrint(object sender,
            System.Drawing.Printing.PrintEventArgs e)
        {
            // Start at the beginning of the text
            m_nFirstCharOnPage = 0;
        }

        private void printDoc_PrintPage(object sender,
            System.Drawing.Printing.PrintPageEventArgs e)
        {
            // To print the boundaries of the current page margins
            // uncomment the next line:
            // e.Graphics.DrawRectangle(System.Drawing.Pens.Blue, e.MarginBounds);

            // make the RichTextBoxEx calculate and render as much text as will
            // fit on the page and remember the last character printed for the
            // beginning of the next page
            m_nFirstCharOnPage = this.FormatRange(false,
                                                    e,
                                                    m_nFirstCharOnPage,
                                                    this.TextLength);

            // check if there are more pages to print
            if (m_nFirstCharOnPage < this.TextLength)
                e.HasMorePages = true;
            else
                e.HasMorePages = false;
        }

        private void printDoc_EndPrint(object sender,
            System.Drawing.Printing.PrintEventArgs e)
        {
            // Clean up cached information
            this.FormatRangeDone();
        }

        #endregion
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // CRichTextBox
            // 
            this.ResumeLayout(false);

        }


    }
}
