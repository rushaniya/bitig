using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Bitig.RtbControl.Utilities
{
    public partial class frmNumericList : Form
    {

        internal ushort X_IndentTwips
        {
            get { return UtilityFinctions.CentimetersToTwips((double)nudIndent.Value); }
            set { nudIndent.Value = (decimal)UtilityFinctions.TwipsToCentimeters(value); }
        }

        internal ushort X_StartWith
        {
            get { return (ushort)nudStart.Value; }
            set { nudStart.Value = value; }
        }

        private ENumericListFormat x_InitialFormat = ENumericListFormat.Parenthesis;

        private ENumericListFormat x_ListFormat;
        internal ENumericListFormat X_ListFormat
        {
            get
            {
                return x_ListFormat;
            }
            //set
            //{
            //    x_ListFormat = value;
            //    x_InitialFormat = value;
            //}
        }

        private ENumericListType x_InitialType = ENumericListType.None;

        private ENumericListType x_ListType;
        internal ENumericListType X_ListType
        {
            get
            {
                return x_ListType;
            }
            //set
            //{
            //    x_InitialType = value;
            //    x_ListType = value;
            //}
        }

        private ENumericListFormat x_FirstExtraFormat = ENumericListFormat.Period;
        private ENumericListFormat x_SecondExtraFormat = ENumericListFormat.Parentheses;
        private ENumericListFormat x_ThirdExtraFormat = ENumericListFormat.Plain;

        private int x_CurrentTabIndex = -1;

        private Dictionary<SampleTextKey, string> x_SampleTexts = new Dictionary<SampleTextKey, string>();

        public frmNumericList(ENumericListType ListType, ENumericListFormat Format)
        {
            InitializeComponent();
            SetSelectedList(ListType, Format);
        }

        public frmNumericList()
        {
            InitializeComponent();
            SetSelectedList(ENumericListType.None, ENumericListFormat.Parenthesis);
        }

        private void NotPanel_Enter(object sender, EventArgs e)
        {
            if (sender is Control)
            {
                UnfocusPanel(false);
                x_CurrentTabIndex = (sender as Control).TabIndex;
            }
        }

        private void Bullet_Click(object sender, EventArgs e)
        {
            SetCurrentListByTabIndex(pnlBullet.TabIndex);
            SelectPanel(pnlBullet.TabIndex);
            x_CurrentTabIndex = pnlBullet.TabIndex;
        }


        private void Arabic_Click(object sender, EventArgs e)
        {
            SetCurrentListByTabIndex(pnlArabic.TabIndex);
            SelectPanel(pnlArabic.TabIndex);
            x_CurrentTabIndex = pnlArabic.TabIndex;
        }

        private void LCLetter_Click(object sender, EventArgs e)
        {
            SetCurrentListByTabIndex(pnlLCLetter.TabIndex);
            SelectPanel(pnlLCLetter.TabIndex);
            x_CurrentTabIndex = pnlLCLetter.TabIndex;
        }

        private void UCLetter_Click(object sender, EventArgs e)
        {
            SetCurrentListByTabIndex(pnlUCLetter.TabIndex);
            SelectPanel(pnlUCLetter.TabIndex);
            x_CurrentTabIndex = pnlUCLetter.TabIndex;
        }

        private void LCRoman_Click(object sender, EventArgs e)
        {
            SetCurrentListByTabIndex(pnlLCRoman.TabIndex);
            SelectPanel(pnlLCRoman.TabIndex);
            x_CurrentTabIndex = pnlLCRoman.TabIndex;
        }

        private void UCRoman_Click(object sender, EventArgs e)
        {
            SetCurrentListByTabIndex(pnlUCRoman.TabIndex);
            SelectPanel(pnlUCRoman.TabIndex);
            x_CurrentTabIndex = pnlUCRoman.TabIndex;
        }

        private void No_Click(object sender, EventArgs e)
        {
            SetCurrentListByTabIndex(pnlNo.TabIndex);
            SelectPanel(pnlNo.TabIndex);
            x_CurrentTabIndex = pnlNo.TabIndex;
        }

        private void Paren_Click(object sender, EventArgs e)
        {
            SetCurrentListByTabIndex(pnlFirstExtra.TabIndex);
            SelectPanel(pnlFirstExtra.TabIndex);
            x_CurrentTabIndex = pnlFirstExtra.TabIndex;
        }

        private void Parens_Click(object sender, EventArgs e)
        {
            SetCurrentListByTabIndex(pnlSecondExtra.TabIndex);
            SelectPanel(pnlSecondExtra.TabIndex);
            x_CurrentTabIndex = pnlSecondExtra.TabIndex;
        }

        private void Plain_Click(object sender, EventArgs e)
        {
            SetCurrentListByTabIndex(pnlThirdExtra.TabIndex);
            SelectPanel(pnlThirdExtra.TabIndex);
            x_CurrentTabIndex = pnlThirdExtra.TabIndex;
        }

        private void NoNumber_Click(object sender, EventArgs e)
        {
            SetCurrentListByTabIndex(pnlNoNumber.TabIndex);
            SelectPanel(pnlNoNumber.TabIndex);
            x_CurrentTabIndex = pnlNoNumber.TabIndex;
        }


        private void btnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        internal void SetSelectedList(ENumericListType ListType, ENumericListFormat Format)
        {
            x_InitialFormat = Format;
            x_InitialType = ListType;
            x_ListFormat = Format;
            x_ListType = ListType;
            switch (Format)
            {
                case ENumericListFormat.Parentheses:
                    x_FirstExtraFormat = ENumericListFormat.Parenthesis;
                    x_SecondExtraFormat = ENumericListFormat.Period;
                    x_ThirdExtraFormat = ENumericListFormat.Plain;
                    break;
                case ENumericListFormat.NoNumber:
                case ENumericListFormat.Parenthesis://default
                    x_FirstExtraFormat = ENumericListFormat.Period;
                    x_SecondExtraFormat = ENumericListFormat.Parentheses;
                    x_ThirdExtraFormat = ENumericListFormat.Plain;
                    break;
                case ENumericListFormat.Plain:
                    x_FirstExtraFormat = ENumericListFormat.Parenthesis;
                    x_SecondExtraFormat = ENumericListFormat.Parentheses;
                    x_ThirdExtraFormat = ENumericListFormat.Period;
                    break;
                case ENumericListFormat.Period:
                    x_FirstExtraFormat = ENumericListFormat.Parenthesis;
                    x_SecondExtraFormat = ENumericListFormat.Parentheses;
                    x_ThirdExtraFormat = ENumericListFormat.Plain;
                    break;

            }
            int _index = GetTabIndexByList();
            SelectPanel(_index);
            x_CurrentTabIndex = _index;
        }

        private int GetTabIndexByList()
        {
            int _index = pnlNo.TabIndex;
            switch (x_ListType)
            {
                case ENumericListType.None:
                    _index = pnlNo.TabIndex;
                    break;
                case ENumericListType.Bullet:
                    _index = pnlBullet.TabIndex;
                    break;
                default:
                    if (x_ListFormat == x_InitialFormat)
                        _index = GetTabIndexOnCurrentStyles();
                    else if (x_ListFormat == x_FirstExtraFormat)
                        _index = pnlFirstExtra.TabIndex;
                    else if (x_ListFormat == x_SecondExtraFormat)
                        _index = pnlSecondExtra.TabIndex;
                    else if (x_ListFormat == x_ThirdExtraFormat)
                        _index = pnlThirdExtra.TabIndex;
                    break;

            }
            return _index;
        }

        private int GetTabIndexOnCurrentStyles()
        {
            int _index = 6;
            switch (x_ListType)
            {
                case ENumericListType.Arabic:
                    _index = pnlArabic.TabIndex;
                    break;
                case ENumericListType.LCLetter:
                    _index = pnlLCLetter.TabIndex;
                    break;
                case ENumericListType.LCRoman:
                    _index = pnlLCRoman.TabIndex;
                    break;
                case ENumericListType.UCLetter:
                    _index = pnlUCLetter.TabIndex;
                    break;
                case ENumericListType.UCRoman:
                    _index = pnlUCRoman.TabIndex;
                    break;
            }
            return _index;
        }

        private void DisplayListOptions()
        {
            if (x_ListType == ENumericListType.Bullet)
            {
                pnlNumericParams.Visible = false;
                lblIndent.Visible = true;
                nudIndent.Visible = true;
            }
            else if (x_ListType == ENumericListType.None)
            {
                pnlNumericParams.Visible = false;
                lblIndent.Visible = false;
                nudIndent.Visible = false;
            }
            else
            {
                SetSampleTexts();
                pnlNumericParams.Visible = true;
                lblIndent.Visible = true;
                nudIndent.Visible = true;
            }
        }

        private void SetSampleTexts()
        {
            lblFirstExtra1.Text = GetSampleString(x_ListType, x_FirstExtraFormat, 1);
            lblFirstExtra2.Text = GetSampleString(x_ListType, x_FirstExtraFormat, 2);
            lblFirstExtra3.Text = GetSampleString(x_ListType, x_FirstExtraFormat, 3);
            lblSecondExtra1.Text = GetSampleString(x_ListType, x_SecondExtraFormat, 1);
            lblSecondExtra2.Text = GetSampleString(x_ListType, x_SecondExtraFormat, 2);
            lblSecondExtra3.Text = GetSampleString(x_ListType, x_SecondExtraFormat, 3);
            lblThirdExtra1.Text = GetSampleString(x_ListType, x_ThirdExtraFormat, 1);
            lblThirdExtra2.Text = GetSampleString(x_ListType, x_ThirdExtraFormat, 2);
            lblThirdExtra3.Text = GetSampleString(x_ListType, x_ThirdExtraFormat, 3);
            lblArabic1.Text = GetSampleString(ENumericListType.Arabic, x_InitialFormat, 1);
            lblArabic2.Text = GetSampleString(ENumericListType.Arabic, x_InitialFormat, 2);
            lblArabic3.Text = GetSampleString(ENumericListType.Arabic, x_InitialFormat, 3);
            lblLCLetter1.Text = GetSampleString(ENumericListType.LCLetter, x_InitialFormat, 1);
            lblLCLetter2.Text = GetSampleString(ENumericListType.LCLetter, x_InitialFormat, 2);
            lblLCLetter3.Text = GetSampleString(ENumericListType.LCLetter, x_InitialFormat, 3);
            lblLCRoman1.Text = GetSampleString(ENumericListType.LCRoman, x_InitialFormat, 1);
            lblLCRoman2.Text = GetSampleString(ENumericListType.LCRoman, x_InitialFormat, 2);
            lblLCRoman3.Text = GetSampleString(ENumericListType.LCRoman, x_InitialFormat, 3);
            lblUCLetter1.Text = GetSampleString(ENumericListType.UCLetter, x_InitialFormat, 1);
            lblUCLetter2.Text = GetSampleString(ENumericListType.UCLetter, x_InitialFormat, 2);
            lblUCLetter3.Text = GetSampleString(ENumericListType.UCLetter, x_InitialFormat, 3);
            lblUCRoman1.Text = GetSampleString(ENumericListType.UCRoman, x_InitialFormat, 1);
            lblUCRoman2.Text = GetSampleString(ENumericListType.UCRoman, x_InitialFormat, 2);
            lblUCRoman3.Text = GetSampleString(ENumericListType.UCRoman, x_InitialFormat, 3);
        }

        private string GetSampleString(ENumericListType ListType, ENumericListFormat ListFormat, ushort LabelIndex)
        {
            SampleTextKey _key = new SampleTextKey(ListType, ListFormat, LabelIndex);
            if (x_SampleTexts.ContainsKey(_key))
            {
                return x_SampleTexts[_key];
            }
            string _result = string.Empty; ;
            string _marker = string.Empty;
            switch (ListFormat)
            {
                case ENumericListFormat.Period:
                    _marker = "{0}. ";
                    break;
                case ENumericListFormat.Plain:
                    _marker = "{0} ";
                    break;
                case ENumericListFormat.Parentheses:
                    _marker = "({0}) ";
                    break;
                case ENumericListFormat.Parenthesis:
                    _marker = "{0}) ";
                    break;
                case ENumericListFormat.NoNumber:
                    if (LabelIndex == 2) _result = "No marker";
                    x_SampleTexts.Add(_key, _result);
                    return _result;
            }
            string _number = string.Empty;
            switch (ListType)
            {
                case ENumericListType.Arabic:
                    _number = LabelIndex.ToString();
                    break;
                case ENumericListType.LCLetter:
                    switch (LabelIndex)
                    {
                        case 1:
                            _number = "a";
                            break;
                        case 2:
                            _number = "b";
                            break;
                        case 3:
                            _number = "c";
                            break;
                    }
                    break;
                case ENumericListType.UCLetter:
                    switch (LabelIndex)
                    {
                        case 1:
                            _number = "A";
                            break;
                        case 2:
                            _number = "B";
                            break;
                        case 3:
                            _number = "C";
                            break;
                    }
                    break;
                case ENumericListType.LCRoman:
                    switch (LabelIndex)
                    {
                        case 1:
                            _number = "i";
                            break;
                        case 2:
                            _number = "ii";
                            break;
                        case 3:
                            _number = "iii";
                            break;
                    }
                    break;
                case ENumericListType.UCRoman:
                    switch (LabelIndex)
                    {
                        case 1:
                            _number = "I";
                            break;
                        case 2:
                            _number = "II";
                            break;
                        case 3:
                            _number = "III";
                            break;
                    }
                    break;
            }
            _marker = string.Format(_marker, _number);
            int _underscoreLength = 8 - _marker.Length;
            StringBuilder _underscore = new StringBuilder();
            for (int i = 0; i < _underscoreLength; i++)
            {
                _underscore.Append("_");
            }
            _result = _marker + _underscore.ToString();
            x_SampleTexts.Add(_key, _result);
            return _result;
        }


        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            int _newTabIndex = -1;
            if (keyData == Keys.Tab || keyData == Keys.Left || keyData == Keys.Right || keyData == Keys.Up || keyData == Keys.Down)
            {
                if (x_CurrentTabIndex >= 0 && x_CurrentTabIndex <= 6 || x_CurrentTabIndex >= 9 && x_CurrentTabIndex <= 12)
                {
                    if (keyData == Keys.Left)
                    {
                        if (x_CurrentTabIndex > 0 && x_CurrentTabIndex <= 6 || x_CurrentTabIndex > 9)
                            _newTabIndex = x_CurrentTabIndex - 1;
                        else _newTabIndex = x_CurrentTabIndex;
                    }
                    else if (keyData == Keys.Right)
                    {
                        if (x_CurrentTabIndex < 6 || x_CurrentTabIndex >= 9 && x_CurrentTabIndex < 12)
                            _newTabIndex = x_CurrentTabIndex + 1;
                        else _newTabIndex = x_CurrentTabIndex;
                    }
                    else if (keyData == Keys.Down)
                    {
                        if (x_CurrentTabIndex >= 0 && x_CurrentTabIndex <= 2)
                            _newTabIndex = x_CurrentTabIndex + 4;
                        else _newTabIndex = x_CurrentTabIndex;
                    }
                    else if (keyData == Keys.Up)
                    {
                        if (x_CurrentTabIndex >= 4 && x_CurrentTabIndex <= 6)
                            _newTabIndex = x_CurrentTabIndex - 4;
                        else _newTabIndex = x_CurrentTabIndex;
                    }
                    else if (keyData == Keys.Tab)
                    {
                        if (x_CurrentTabIndex >= 0 && x_CurrentTabIndex <= 6)
                        {
                            _newTabIndex = nudIndent.Visible ? 7 : 13; //nudIndent : btnOK
                        }
                        else if (x_CurrentTabIndex >= 9 && x_CurrentTabIndex <= 12)
                        {
                            _newTabIndex = 13;
                        }
                    }
                    if (keyData != Keys.Tab)
                    {
                        SetCurrentListByTabIndex(_newTabIndex);
                        SelectPanel(_newTabIndex);
                    }
                }
                else if (keyData == Keys.Tab)
                {
                    _newTabIndex = (x_CurrentTabIndex + 1) % 15;
                }
                switch (_newTabIndex)
                {
                    case 0:
                    case 9:
                        SetCurrentListByTabIndex(_newTabIndex);
                        SelectPanel(_newTabIndex);
                        break;
                    case 7:
                        nudIndent.Focus();
                        break;
                    case 8:
                        if (pnlNumericParams.Visible) nudStart.Focus();
                        else
                        {
                            _newTabIndex = 13;
                            btnOK.Focus();
                        }
                        break;
                    case 13:
                        btnOK.Focus();
                        break;
                    case 14:
                        btnCancel.Focus();
                        break;
                }

                if (_newTabIndex > -1) x_CurrentTabIndex = _newTabIndex;
            }

            return _newTabIndex > -1 ? true : base.ProcessCmdKey(ref msg, keyData);
        }


        private void SelectPanel(int NewTabIndex)
        {
            if (NewTabIndex == x_CurrentTabIndex) return;
            DisplayListOptions();
            UnfocusPanel(true);
            if (NewTabIndex >= 0 && NewTabIndex <= 6)
            {
                foreach (Control _child in tblCurrentStyles.Controls)
                {
                    if (_child is Panel && _child.TabIndex == NewTabIndex)
                    {
                        _child.BackColor = Color.LightCyan;
                        (_child as Panel).BorderStyle = BorderStyle.Fixed3D;
                    }
                }
            }
            else if (NewTabIndex >= 9 && NewTabIndex <= 12)
            {
                foreach (Control _child in tblOtherStyles.Controls)
                {
                    if (_child is Panel && _child.TabIndex == NewTabIndex)
                    {
                        _child.BackColor = Color.LightCyan;
                        (_child as Panel).BorderStyle = BorderStyle.Fixed3D;
                    }
                }
            }
        }

        private void UnfocusPanel(bool Deselect)
        {
            foreach (Control _child in tblCurrentStyles.Controls)
            {
                if (_child is Panel)
                {
                    if (Deselect && _child.BackColor == Color.LightCyan) _child.BackColor = SystemColors.Window;
                    if ((_child as Panel).BorderStyle == BorderStyle.Fixed3D) (_child as Panel).BorderStyle = BorderStyle.FixedSingle;
                }
            }
            foreach (Control _child in tblOtherStyles.Controls)
            {
                if (_child is Panel)
                {
                    if (Deselect && _child.BackColor == Color.LightCyan) _child.BackColor = SystemColors.Window;
                    if ((_child as Panel).BorderStyle == BorderStyle.Fixed3D) (_child as Panel).BorderStyle = BorderStyle.FixedSingle;
                }
            }
        }

        private void SetCurrentListByTabIndex(int TabIndex)
        {
            switch (TabIndex)
            {
                case 0:
                    x_ListFormat = ENumericListFormat.Plain;
                    x_ListType = ENumericListType.Bullet;
                    break;
                case 1:
                    x_ListType = ENumericListType.Arabic;
                    x_ListFormat = x_InitialFormat;
                    break;
                case 2:
                    x_ListType = ENumericListType.LCLetter;
                    x_ListFormat = x_InitialFormat;
                    break;
                case 3:
                    x_ListType = ENumericListType.UCLetter;
                    x_ListFormat = x_InitialFormat;
                    break;
                case 4:
                    x_ListType = ENumericListType.LCRoman;
                    x_ListFormat = x_InitialFormat;
                    break;
                case 5:
                    x_ListType = ENumericListType.UCRoman;
                    x_ListFormat = x_InitialFormat;
                    break;
                case 6:
                    x_ListType = ENumericListType.None;
                    x_ListFormat = ENumericListFormat.Plain;
                    break;
                case 9:
                    x_ListFormat = x_FirstExtraFormat;
                    break;
                case 10:
                    x_ListFormat = x_SecondExtraFormat;
                    break;
                case 11:
                    x_ListFormat = x_ThirdExtraFormat;
                    break;
                case 12:
                    x_ListFormat = ENumericListFormat.NoNumber;
                    break;
            }
        }
    }

    struct SampleTextKey
    {
        internal ENumericListFormat ListFormat;
        internal ENumericListType ListType;
        internal ushort LabelIndex;

        internal SampleTextKey(ENumericListType ListType, ENumericListFormat ListFormat, ushort LabelIndex)
        {
            this.LabelIndex = LabelIndex;
            this.ListFormat = ListFormat;
            this.ListType = ListType;
        }
    }
}
