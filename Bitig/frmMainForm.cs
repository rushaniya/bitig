using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using Bitig.RtbControl;
using Bitig.UI.Controls;
using Bitig.KeyboardManagement;
using Bitig.Logic.Model;
using Bitig.Logic.Repository;
using Bitig.UI.Configuration;
using Bitig.Data.Storage;
using Bitig.UI.Logic;
using System.Linq;
using Bitig.Base;

namespace Bitig.UI
{
    public partial class frmMainForm : Form
    {
        #region Fields & Properties

        //private EKeyboardLayout x_CurrentLayout;

        private bool x_SplitterShown1stTime = true;

        private EActiveTextControl x_ActiveTextControl = EActiveTextControl.RTB;


        private int x_TlsAlifbaLength;
        private int x_TlsMainLength;

        private string x_FilePath;

        internal string X_FilePath
        {
            get { return x_FilePath; }
            set { x_FilePath = value; }
        }

        private bool x_ProcessingTranslitArea;

        private Regex x_LineBreaksFinder;

        private IDataContext x_DataContext;
        private AlifbaRepository x_AlifbaRepository;
        private DirectionRepository x_DirectionRepository;

        private KeyboardManager x_YanalifKeyManager = new KeyboardManager();
        private KeyboardManager x_Txt1KeyManager = new KeyboardManager();
        private KeyboardManager x_Txt2KeyManager = new KeyboardManager();

        #endregion


        #region Form Constructor and Events

        public frmMainForm()
        {
            InitializeComponent();

            InitializeRepositories();

            FillSourceCmb();
            if (cmbSource.Items.Count > 0)
                cmbSource.SelectedIndex = 0;

            ctlMultiRtb1.MessageSent += new ctlMultiRtb.CtlMessage(ctlMultiRtb1_MessageSent);
            ctlMultiRtb1.RtbMain.Enter += new EventHandler(RtbMain_Enter);
            SetYanalifFont();
            ctlMultiRtb1.ResetFormatDisplay();
            ctlYanalif1.SymbolPressed += new EventHandler<SymbolEventArgs>(ctlYanalif1_SymbolPressed);
            //this returns hexadeciaml value equal to 04090409
            //int _ptr =  (int) LoadKeyboardLayoutW("00000409", KLF_ACTIVATE);
            //and this returns hexadecimal value equal to FXXX0444 where XXX is layout id
            //int _ptr =  (int) LoadKeyboardLayoutW(LAYOUT_YANALIF, KLF_ACTIVATE);
            mniTranslitPanel.Checked = false;
            //config:bind setting to menuitem.checked property for it is always visible and can be changed either programmatically or by user
            mniAlifba.Checked = false;//config
            //uni:re-read when configuration changes
            var _yanalif = x_AlifbaRepository.GetYanalif();
            ctlYanalif1.X_CustomSymbols = _yanalif.CustomSymbols;
            LoadYanalifKeyboardLayout();
        }

        private void InitializeRepositories()
        {
            x_DataContext = new XmlContext(DefaultConfiguration.LocalFolder);
            x_AlifbaRepository = x_DataContext.AlifbaRepository;
            x_DirectionRepository = x_DataContext.DirectionRepository;
        }

        private void RtbMain_Enter(object sender, EventArgs e)
        {
            x_ActiveTextControl = EActiveTextControl.RTB;
        }

        private void ctlMultiRtb1_MessageSent(object sender, Bitig.RtbControl.Utilities.MessageArgs e)
        {
            switch (e.MessageType)
            {
                case Bitig.RtbControl.Utilities.MessageArgs.EMessageTypes.FileNameChanged:
                    this.Text = e.Message;
                    break;
            }
        }


        private void frmMainForm_Load(object sender, EventArgs e)
        {
            //config:hide translit area and alifba by default
            btnShowTranslit.Checked = !spltMain.Panel1Collapsed;
            btnShowAlifba.Checked = ctlYanalif1.Visible;
            if (!spltMain.Panel1Collapsed)
            {
                //config:spltMain.SplitterDistance = Properties.Settings.Default.k_SplitterDistance;
                x_SplitterShown1stTime = false;
            }
            //x_TlsAlifbaLength = 3 + btnAlifA.Width * (19 + Convert.ToInt32(Properties.Settings.Default.k_AlifUser1Visible) + Convert.ToInt32(Properties.Settings.Default.k_AlifUser2Visible) + Convert.ToInt32(Properties.Settings.Default.k_AlifUser3Visisble));
            //x_TlsMainLength = btnShowAlifba.Width * 8 + toolStripSeparator2.Width * 2 + 3;
            //ArrangeToolStrips();
            ctlMultiRtb1.RtbMain.Select(); //ctlMultiRtb1.RtbMain.Focus();
            RtbMain_Enter(null, null);
            ToolStripManager.Merge(ctlMultiRtb1.mnuMultiRTB, mnuMain);
            if (!string.IsNullOrEmpty(x_FilePath))
                ctlMultiRtb1.OpenFile(x_FilePath);
        }

        private void frmMainForm_Shown(object sender, EventArgs e)
        {

        }


        private void frmMainForm_SizeChanged(object sender, EventArgs e)
        {
            //ArrangeToolStrips();
        }


        private void frmMainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing && !ctlMultiRtb1.PromptSave())
            {
                e.Cancel = true;
                return;
            }
            //config:Properties.Settings.Default.k_SplitterDistance = spltMain.SplitterDistance;
            //Properties.Settings.Default.k_AlifbaLocation = tlsAlifba.Location;
            //Properties.Settings.Default.k_Panel1Collapsed = spltMain.Panel1Collapsed;
            //Properties.Settings.Default.k_TlsMainLocation = tlsMain.Location;
            //ctlMultiRtb1.SaveSettings();
            //Properties.Settings.Default.Save();
        }

        #endregion


        #region Additional Methods

        private string InsertTextboxLineBreaks(string SourceText)
        {
            if (x_LineBreaksFinder == null) x_LineBreaksFinder = new Regex("(?<!\r)\n");
            return x_LineBreaksFinder.Replace(SourceText, "\r\n");
        }

        #endregion

        #region File IO




        #endregion


        #region Text Formatting

        private void SetYanalifFont()
        {
            var _font = (Font)x_AlifbaRepository.GetYanalif().DefaultFont;
            if (_font == null)
                _font = new Font("DejaVu Sans", 12, FontStyle.Regular);
            ctlMultiRtb1.RtbMain.Font = _font;
        }

        #endregion

        #region Form Layout

        private void btnShowAlifba_CheckedChanged(object sender, EventArgs e)
        {
            mniAlifba.Checked = btnShowAlifba.Checked;
        }


        private void mniAlifba_CheckedChanged(object sender, EventArgs e)
        {
            if (mniAlifba.Checked)
            {
                btnShowAlifba.Checked = true;
                ctlYanalif1.Visible = true;
                AdjustAlifbaPanel();
            }
            else
            {
                btnShowAlifba.Checked = false;
                ctlYanalif1.Visible = false;
            }
        }

        private void HideTranslitArea()
        {
            x_ProcessingTranslitArea = true;
            btnShowTranslit.Checked = false;
            mniTranslitPanel.Checked = false;
            spltMain.Panel1Collapsed = true;
            cmbSource.Visible = false;
            lblTo.Visible = false;
            cmbTarget.Visible = false;
            x_ProcessingTranslitArea = false;
        }

        private void ShowTranslitArea()
        {
            x_ProcessingTranslitArea = true;
            btnShowTranslit.Checked = true;
            mniTranslitPanel.Checked = true;
            spltMain.Panel1Collapsed = false;
            cmbSource.Visible = true;
            lblTo.Visible = true;
            cmbTarget.Visible = true;
            if (x_SplitterShown1stTime)
            {
                //config:spltMain.SplitterDistance = Properties.Settings.Default.k_SplitterDistance;
                x_SplitterShown1stTime = false;
            }
            x_ProcessingTranslitArea = false;
        }

        private void btnShowTranslit_CheckedChanged(object sender, EventArgs e)
        {
            //if (x_ProcessingTranslitArea) return;
            //if (btnShowTranslit.Checked)
            //{
            //    ShowTranslitArea();
            //}
            //else
            //{
            //    HideTranslitArea();
            //}
            mniTranslitPanel.Checked = btnShowTranslit.Checked;
        }

        private void mniTranslitPanel_CheckedChanged(object sender, EventArgs e)
        {
            if (x_ProcessingTranslitArea) return;
            if (mniTranslitPanel.Checked)
            {
                ShowTranslitArea();
            }
            else
            {
                HideTranslitArea();
            }
        }


        private void AdjustKeyboardPanel(Panel TargetPanel)
        {
            if (TargetPanel.Visible && TargetPanel.Controls.Count > 0)
            {
                int _optimalHeight = (TargetPanel.Controls[0] as ctlAlifba).CalculateHeight();
                TargetPanel.Height = _optimalHeight;
            }
        }

        private void AdjustAlifbaPanel()
        {
            ctlYanalif1.Height = ctlYanalif1.CalculateHeight();
        }

        private void pnlTranslit2_SizeChanged(object sender, EventArgs e)
        {
            AdjustKeyboardPanel(pnlTranslit2Bottom);
        }

        private void pnlTranslit1_SizeChanged(object sender, EventArgs e)
        {
            AdjustKeyboardPanel(pnlTranslit1Bottom);
        }

        private void pnlYanalif_SizeChanged(object sender, EventArgs e)
        {
            AdjustAlifbaPanel();
        }

        private void ctlYanalif1_VisibleChanged(object sender, EventArgs e)
        {
            //if (ctlYanalif1.Visible) AdjustAlifbaPanel();
        }

        #endregion

        #region Transliteration

        private Direction x_CurrentDirection;

        private Alifba x_CurrentTranslitSource;

        private Alifba x_CurrentTranslitTarget;

        private bool x_FillingCombos;

        private void FillSourceCmb()
        {
            x_FillingCombos = true;
            cmbSource.Items.Clear();
            foreach (Alifba _alifba in x_AlifbaRepository.GetList())
            {
                cmbSource.Items.Add(_alifba);
            }
            x_FillingCombos = false;
        }

        private void cmbSource_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!x_FillingCombos) GetCurrentSource();
        }

        private void cmbTarget_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetCurrentDirection();
        }

        private void GetCurrentDirection()
        {
            if (x_CurrentTranslitSource != null)
            {
                lblSource.Text = x_CurrentTranslitSource.FriendlyName;
                GetCurrentTarget();
                if (x_CurrentTranslitTarget == null)
                {
                    //disable transliteration, allow input from on-screen keyboard
                    btnToYanalif.Enabled = false;
                    btnFromYanalif.Enabled = false;
                    btnTranslitAux.Enabled = false;
                    if (x_CurrentTranslitSource.IsYanalif)
                    {
                        spltTranslitArea.Panel1Collapsed = true;
                    }
                    else
                    {
                        spltTranslitArea.Panel2Collapsed = true;
                    }
                }
                else
                {
                    lblTarget.Text = x_CurrentTranslitTarget.FriendlyName;
                    x_CurrentDirection = x_DirectionRepository.GetByAlifbaIDs(x_CurrentTranslitSource.ID, x_CurrentTranslitTarget.ID);
                    string _toolTip = string.Format("Convert from {0} to {1}", x_CurrentTranslitSource.FriendlyName, x_CurrentTranslitTarget.FriendlyName);
                    if (x_CurrentDirection == null)
                    {
                        btnToYanalif.Enabled = false;
                        btnFromYanalif.Enabled = false;
                        btnTranslitAux.Enabled = false;
                    }
                    else
                    {
                        if (x_CurrentTranslitTarget.IsYanalif)
                        {
                            btnToYanalif.Enabled = true;
                            btnToYanalif.ToolTipText = _toolTip;
                            btnFromYanalif.Enabled = false;
                            btnFromYanalif.ToolTipText = "";
                            btnTranslitAux.Enabled = false;
                            btnTranslitAux.ToolTipText = "";
                            spltTranslitArea.Panel2Collapsed = true;
                        }
                        else if (x_CurrentTranslitSource.IsYanalif)
                        {
                            btnToYanalif.Enabled = false;
                            btnToYanalif.ToolTipText = "";
                            btnFromYanalif.Enabled = true;
                            btnFromYanalif.ToolTipText = _toolTip;
                            btnTranslitAux.Enabled = false;
                            btnTranslitAux.ToolTipText = "";
                            spltTranslitArea.Panel1Collapsed = true;
                        }
                        else
                        {
                            btnToYanalif.Enabled = false;
                            btnToYanalif.ToolTipText = "";
                            btnFromYanalif.Enabled = false;
                            btnFromYanalif.ToolTipText = "";
                            btnTranslitAux.Enabled = true;
                            btnTranslitAux.ToolTipText = _toolTip;
                            spltTranslitArea.Panel1Collapsed = false;
                            spltTranslitArea.Panel2Collapsed = false;
                        }
                        mniCurrentMapping.Enabled = x_CurrentDirection.ManualCommand != null;
                    }
                }
            }
        }

        private void GetCurrentSource()
        {
            x_CurrentTranslitSource = cmbSource.SelectedItem as Alifba;
            AssignAlphabetProperties(x_CurrentTranslitSource, txtTranslit1);
            Alifba _previousTarget = cmbTarget.SelectedItem as Alifba;
            cmbTarget.Items.Clear();
            if (x_CurrentTranslitSource != null)
            {
                foreach (Alifba _target in x_DirectionRepository.GetTargets(x_CurrentTranslitSource.ID))
                {
                    cmbTarget.Items.Add(_target);
                }
                if (cmbTarget.Items.Count == 0)
                {
                    cmbTarget.Items.Add("(none)");//loc
                    cmbTarget.SelectedIndex = 0;
                }
                else
                {
                    if (_previousTarget != null && cmbTarget.Items.Contains(_previousTarget))
                        cmbTarget.SelectedItem = _previousTarget;
                    else cmbTarget.SelectedIndex = 0;
                }
            }
            GetCurrentDirection();
            if (OnscreenKeyboardAvailable(x_CurrentTranslitSource))
            {
                btnT1Keyboard.Enabled = true;
                if (btnT1Keyboard.Checked) LoadOnscreenKeyboard(x_CurrentTranslitSource, true);
            }
            else
            {
                btnT1Keyboard.Enabled = false;
                btnT1Keyboard.Checked = false;
            }
            if (KeyboardLayoutAvailable(x_CurrentTranslitSource)) //kbl:and button checked
            {
                if (!x_Txt1KeyManager.IsAttached)
                    x_Txt1KeyManager.AttachTo(txtTranslit1);
                x_Txt1KeyManager.SetKeyboardLayout(x_KeyboardLayouts[x_CurrentTranslitSource.KeyboardLayoutID.Value]);
            }
            else
            {
                if (x_Txt1KeyManager.IsAttached)
                    x_Txt1KeyManager.DetachFrom(txtTranslit1);
            }
        }

        private void GetCurrentTarget()
        {
            x_CurrentTranslitTarget = cmbTarget.SelectedItem as Alifba;
            AssignAlphabetProperties(x_CurrentTranslitTarget, txtTranslit2);
            if (OnscreenKeyboardAvailable(x_CurrentTranslitTarget))
            {
                btnT2Keyboard.Enabled = true;
                if (btnT2Keyboard.Checked) LoadOnscreenKeyboard(x_CurrentTranslitTarget, false);
            }
            else
            {
                btnT2Keyboard.Enabled = false;
                btnT2Keyboard.Checked = false;
            }
            if (KeyboardLayoutAvailable(x_CurrentTranslitTarget)) //kbl:and button checked
            {
                if (!x_Txt2KeyManager.IsAttached)
                    x_Txt2KeyManager.AttachTo(txtTranslit2);
                x_Txt2KeyManager.SetKeyboardLayout(x_KeyboardLayouts[x_CurrentTranslitTarget.KeyboardLayoutID.Value]);
            }
            else
            {
                if (x_Txt2KeyManager.IsAttached)
                    x_Txt2KeyManager.DetachFrom(txtTranslit2);
            }
        }

        private Font GetDefaultFont(Alifba Alphabet)
        {
            Font _result = SystemFonts.DefaultFont;//config
            if (Alphabet != null)
            {
                _result = (Font)Alphabet.DefaultFont;
                if (_result == null) return SystemFonts.DefaultFont;
            }
            return _result;
        }

        private void AssignAlphabetProperties(Alifba Alphabet, RichTextBox TargetTextBox)
        {
            if (Alphabet == null)
            {
                TargetTextBox.Font = SystemFonts.DefaultFont;//config
                TargetTextBox.RightToLeft = RightToLeft.No;
            }
            else if (!Alphabet.IsYanalif)
            {
                TargetTextBox.Font = Alphabet.DefaultFont == null ? SystemFonts.DefaultFont : (Font)Alphabet.DefaultFont;//config
                TargetTextBox.RightToLeft = Alphabet.RightToLeft ? RightToLeft.Yes : RightToLeft.No;
            }
        }

        private void btnToYanalif_Click(object sender, EventArgs e)
        {
            if (txtTranslit1.TextLength > 50000) Cursor.Current = Cursors.WaitCursor;
            try
            {
                GetCurrentDirection();
                if (x_CurrentDirection != null)
                {
                    ctlMultiRtb1.RtbMain.SelectedText = x_CurrentDirection.Transliterate(txtTranslit1.Text);
                }
                ctlMultiRtb1.RtbMain.Select(ctlMultiRtb1.RtbMain.TextLength, 0);
                ctlMultiRtb1.RtbMain.ScrollToCaret();
            }
            finally
            {
                Cursor.Current = Cursors.Arrow;
            }
        }

        private void btnTranslitAux_Click(object sender, EventArgs e)
        {
            GetCurrentDirection();
            if (x_CurrentDirection != null)
            {
                string _translitted = x_CurrentDirection.Transliterate(txtTranslit1.Text);
                txtTranslit2.SelectedText = InsertTextboxLineBreaks(_translitted);
            }
        }

        private void btnFromYanalif_Click(object sender, EventArgs e)
        {
            GetCurrentDirection();
            if (x_CurrentDirection != null)
            {
                string _translitted = x_CurrentDirection.Transliterate(ctlMultiRtb1.RtbMain.Text);
                txtTranslit2.SelectedText = InsertTextboxLineBreaks(_translitted);
            }
        }

        #endregion


        #region Text Input

        #region On-Screen Keyboards

        private Dictionary<int, ctlAlifba> x_OnscreenKeyboards = new Dictionary<int, ctlAlifba>();
        private Dictionary<int, List<AlifbaSymbol>> x_OnscreenSymbols = new Dictionary<int, List<AlifbaSymbol>>();
        private Dictionary<int, KeyboardLayoutBase> x_KeyboardLayouts = new Dictionary<int, KeyboardLayoutBase>();


        private void ctlYanalif1_SymbolPressed(object sender, SymbolEventArgs e)
        {
            ctlMultiRtb1.RtbMain.SelectedText = e.Text;
            ctlMultiRtb1.RtbMain.Select();
        }

        /*  private void SetAlifbaLetters()
          {
              btnAlifA.Tag = "\u0259";
              btnAlifAzur.Tag = "\u018f";
              btnAlifC.Tag = "\u00e7";
              btnAlifCzur.Tag = "\u00c7";
              btnAlifG.Tag = "\u011f";
              btnAlifGzur.Tag = "\u011e";
              btnAlifI.Tag = "\u0131";
              btnAlifIzur.Tag = "\u0130";
              btnAlifN.Tag = "\ua791";
              btnAlifNzur.Tag = "\ua790";
              btnAlifO.Tag = "\u0275";
              btnAlifOzur.Tag = "\u019f";
              btnAlifS.Tag = "\u015f";
              btnAlifSzur.Tag = "\u015e";
              btnAlifU.Tag = "\u00fc";
              btnAlifUzur.Tag = "\u00dc";
              btnAlifQuotClose.Tag = "\u00bb";
              btnAlifQuotOpen.Tag = "\u00ab";
              btnAlifDash.Tag = "\u2014";
              SetCustomAlifbaLetters();
          }

          private void SetCustomAlifbaLetters()
          {
              btnAlifUser1.Visible = false;
              btnAlifUser2.Visible = false;
              btnAlifUser3.Visible = false;
              if (BitigDataManager.Yanalif != null)
              {
                  //config:remove 'user button visible' settings
                  AlifbaConfig _yanalifConfig = BitigDataManager.GetAlifbaConfig(BitigDataManager.Yanalif.ID);
                  if (_yanalifConfig != null && _yanalifConfig.CustomSymbols != null)
                  {
                      if (_yanalifConfig.CustomSymbols.Count > 0)
                      {
                          btnAlifUser1.Visible = true;
                          btnAlifUser1.Text = _yanalifConfig.CustomSymbols[0].DisplayText;
                          btnAlifUser1.Tag = _yanalifConfig.CustomSymbols[0].ActualText;
                          if (_yanalifConfig.CustomSymbols.Count > 1)
                          {
                              btnAlifUser2.Visible = true;
                              btnAlifUser2.Text = _yanalifConfig.CustomSymbols[1].DisplayText;
                              btnAlifUser2.Tag = _yanalifConfig.CustomSymbols[1].ActualText;
                              if (_yanalifConfig.CustomSymbols.Count > 2)
                              {
                                  btnAlifUser3.Visible = true;
                                  btnAlifUser3.Text = _yanalifConfig.CustomSymbols[2].DisplayText;
                                  btnAlifUser3.Tag = _yanalifConfig.CustomSymbols[2].ActualText;
                              }
                          }
                      }
                  }
              }
          }*/


        private void btnT1Keyboard_CheckedChanged(object sender, EventArgs e)
        {
            if (btnT1Keyboard.Checked && x_CurrentTranslitSource != null) LoadOnscreenKeyboard(x_CurrentTranslitSource, true);
            else HideOnscreenKeyboard(true);
        }

        private void btnT2Keyboard_CheckedChanged(object sender, EventArgs e)
        {
            if (btnT2Keyboard.Checked && x_CurrentTranslitTarget != null) LoadOnscreenKeyboard(x_CurrentTranslitTarget, false);
            else HideOnscreenKeyboard(false);
        }

        private bool OnscreenKeyboardAvailable(Alifba Alphabet)
        {
            if (Alphabet == null || Alphabet.IsYanalif) return false;
            return OnscreenKeyboardAvailable(Alphabet.ID);
        }

        private bool OnscreenKeyboardAvailable(int AlphabetID)
        {
            if (!x_OnscreenSymbols.ContainsKey(AlphabetID))
            {
                var _config = x_AlifbaRepository.Get(AlphabetID);
                if (_config != null && _config.CustomSymbols != null && _config.CustomSymbols.Count(x => x.IsOnScreen) > 0)
                {
                    x_OnscreenSymbols.Add(AlphabetID, _config.CustomSymbols.Where(x => x.IsOnScreen).ToList());
                }
                else x_OnscreenSymbols.Add(AlphabetID, null);
            }
            return x_OnscreenSymbols[AlphabetID] != null;
        }

        private void LoadOnscreenKeyboard(Alifba Alphabet, bool TranslitBox1)
        {
            if (!x_OnscreenKeyboards.ContainsKey(Alphabet.ID))
            {
                InitOnscreenKeyboard(Alphabet);
            }
            DisplayOnscreenKeyboard(x_OnscreenKeyboards[Alphabet.ID], TranslitBox1);
        }

        private void InitOnscreenKeyboard(Alifba Alphabet)
        {
            if (OnscreenKeyboardAvailable(Alphabet))
            {
                ctlAlifba _keyboard = new ctlAlifba(x_OnscreenSymbols[Alphabet.ID]);
                _keyboard.Font = new Font(GetDefaultFont(Alphabet).FontFamily, SystemFonts.DefaultFont.SizeInPoints);
                _keyboard.SymbolPressed += new EventHandler<SymbolEventArgs>(OnscreenKeyboard_SymbolPressed);
                x_OnscreenKeyboards.Add(Alphabet.ID, _keyboard);
                _keyboard.Dock = DockStyle.Fill;
            }
            else
            {
                x_OnscreenKeyboards.Add(Alphabet.ID, null);
            }
        }

        private void OnscreenKeyboard_SymbolPressed(object sender, SymbolEventArgs e)
        {
            if ((sender as Control).Parent == pnlTranslit1Bottom)
            {
                int _currentSelection = txtTranslit1.SelectionStart;
                txtTranslit1.SelectedText = e.Text;
                txtTranslit1.SelectionStart = _currentSelection + e.Text.Length;
                txtTranslit1.Focus();
            }
            else
            {
                int _currentSelection = txtTranslit2.SelectionStart;
                txtTranslit2.SelectedText = e.Text;
                txtTranslit2.SelectionStart = _currentSelection + e.Text.Length;
                txtTranslit2.Focus();
            }
        }

        private void DisplayOnscreenKeyboard(ctlAlifba KeyboardControl, bool TranslitBox1)
        {
            if (KeyboardControl == null)
            {
                HideOnscreenKeyboard(TranslitBox1);
            }
            else
            {
                Panel _panel = TranslitBox1 ? pnlTranslit1Bottom : pnlTranslit2Bottom;
                if (KeyboardControl.Parent != _panel)
                {
                    if (KeyboardControl.Parent != null)
                        KeyboardControl.Parent.Controls.Remove(KeyboardControl);
                    _panel.Controls.Clear();
                    _panel.Controls.Add(KeyboardControl);
                }
                _panel.Visible = true;
                AdjustKeyboardPanel(_panel);
            }
        }

        private void HideOnscreenKeyboard(bool TranslitBox1)
        {
            if (TranslitBox1)
            {
                pnlTranslit1Bottom.Visible = false;
                btnT1Keyboard.Checked = false;
            }
            else
            {
                pnlTranslit2Bottom.Visible = false;
                btnT2Keyboard.Checked = false;
            }
        }

        private void ReloadAlphabets()
        {
            bool _osk1 = btnT1Keyboard.Checked;
            bool _osk2 = btnT2Keyboard.Checked;
            ResetOnscreenKeyboards();
            ResetKeyboardLayouts();
            ctlYanalif1.ResetLetters();
            AdjustAlifbaPanel();
            ReloadDirections();
            btnT1Keyboard.Checked = btnT1Keyboard.Enabled && _osk1;
            btnT2Keyboard.Checked = btnT2Keyboard.Enabled && _osk2;
        }

        private void ReloadDirections()
        {
            Alifba _prevSource = cmbSource.SelectedItem as Alifba;
            Alifba _prevTarget = cmbTarget.SelectedItem as Alifba;
            FillSourceCmb();
            if (_prevSource != null && cmbSource.Items.Contains(_prevSource))
            {
                cmbSource.SelectedItem = _prevSource;
            }
            if (_prevTarget != null && cmbTarget.Items.Contains(_prevTarget))
            {
                cmbTarget.SelectedItem = _prevTarget;
            }
        }

        private void ResetOnscreenKeyboards()
        {
            pnlTranslit1Bottom.Controls.Clear();
            pnlTranslit2Bottom.Controls.Clear();
            if (pnlTranslit1Bottom.Visible)
            {
                pnlTranslit1Bottom.Visible = false;
                btnT1Keyboard.Checked = false;
            }
            if (pnlTranslit2Bottom.Visible)
            {
                pnlTranslit2Bottom.Visible = false;
                btnT2Keyboard.Checked = false;
            }
            foreach (int _key in x_OnscreenKeyboards.Keys)
            {
                if (x_OnscreenKeyboards[_key] != null)
                {
                    //x_OnscreenKeyboards[_key].SymbolPressed -= new EventHandler<SymbolEventArgs>(OnscreenKeyboard_SymbolPressed);
                    x_OnscreenKeyboards[_key].Dispose();
                }
            }
            x_OnscreenKeyboards.Clear();
            x_OnscreenSymbols.Clear();
        }

        #endregion

        #region Keyboard Layouts 

        private void LoadYanalifKeyboardLayout()
        {
            var _yanalif = x_AlifbaRepository.GetYanalif();
            if (_yanalif.KeyboardLayoutID != null)
            {
                var _yanalifKbl = x_DataContext.KeyboardRepository.Get(_yanalif.KeyboardLayoutID.Value);
                if (_yanalifKbl != null)
                {
                    x_YanalifKeyManager.SetKeyboardLayout(_yanalifKbl);
                    if (!x_YanalifKeyManager.IsAttached)
                        x_YanalifKeyManager.AttachTo(ctlMultiRtb1.RtbMain);
                    return;
                }
            }
            if (x_YanalifKeyManager.IsAttached)
                x_YanalifKeyManager.DetachFrom(ctlMultiRtb1.RtbMain);
        }

        private bool KeyboardLayoutAvailable(Alifba Alifba)
        {
            if (Alifba.KeyboardLayoutID == null || Alifba.IsYanalif)
                return false;
            if (x_KeyboardLayouts.ContainsKey(Alifba.KeyboardLayoutID.Value))
                return true;
            var _keyboard = x_DataContext.KeyboardRepository.Get(Alifba.KeyboardLayoutID.Value);
            if (_keyboard == null)
                return false;
            x_KeyboardLayouts[Alifba.KeyboardLayoutID.Value] = _keyboard;
            return true;
        }

        private void ResetKeyboardLayouts()
        {
            x_KeyboardLayouts.Clear();
            LoadYanalifKeyboardLayout();
        }

        #endregion

        #endregion

        private void mniExclusions_Click(object sender, EventArgs e)
        {
            using (var _configForm = new frmExclusions(x_CurrentDirection, x_DataContext, true))
            {
                _configForm.ShowDialog();
            }
        }

        private void txtTranslit1_Enter(object sender, EventArgs e)
        { 
            x_ActiveTextControl = EActiveTextControl.Translit1;
        }


        private enum EActiveTextControl
        {
            RTB,
            Translit1,
            Translit2
        }

        private void btnTranslit1Clear_Click(object sender, EventArgs e)
        {
            txtTranslit1.Clear();
            txtTranslit1.Focus();
        }

        private void btnTranslit2Clear_Click(object sender, EventArgs e)
        {
            txtTranslit2.Clear();
            txtTranslit2.Focus();
        }

        private void txtTranslit2_Enter(object sender, EventArgs e)
        {
            x_ActiveTextControl = EActiveTextControl.Translit2;
        }

        private void mniAbout_Click(object sender, EventArgs e)
        {
            (new Utilities.frmAbout()).ShowDialog();
        }

        private void mniConfiguration_Click(object sender, EventArgs e)
        {
            using (frmConfig _configForm = new frmConfig(x_DataContext))
            {
                if (_configForm.ShowDialog() == DialogResult.OK)
                {
                    if (_configForm.X_AlphabetsModified)
                    {
                        //kbl: set this flag if kbl is modified
                        ReloadAlphabets();//this calls ReloadDirections()
                    }
                    else if (_configForm.X_DirectionsModified)
                    {
                        ReloadDirections();
                    }
                }
            }
        }

        private void mniCurrentMapping_Click(object sender, EventArgs e)
        {
            if (x_CurrentDirection == null || x_CurrentDirection.ManualCommand == null)
                return;
            using (var _mappingForm = new frmSymbolMapping(x_CurrentDirection.Source, x_CurrentDirection.Target, x_DirectionRepository, x_CurrentDirection.ManualCommand.SymbolMapping, null))
            {
                if (_mappingForm.ShowDialog() == DialogResult.OK)
                {
                    x_CurrentDirection.ManualCommand = new ManualCommand(_mappingForm.SymbolMapping);
                    x_DirectionRepository.Update(x_CurrentDirection);
                    x_DataContext.SaveChanges();
                }
            }
        }
    }
}
//todo: check what needs to be public/internal/private