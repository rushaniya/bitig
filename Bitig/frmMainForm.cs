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
using System.IO;

namespace Bitig.UI
{
    public partial class frmMainForm : Form
    {
        #region Fields & Properties

        private bool x_SplitterShown1stTime = true;

        private string x_FilePath;

        internal string X_FilePath
        {
            get { return x_FilePath; }
            set { x_FilePath = value; }
        }

        private bool x_ProcessingTranslitArea;

        private IDataContext x_DataContext;
        private AlphabetRepository x_AlphabetRepository;
        private DirectionRepository x_DirectionRepository;

        private KeyboardManager x_MainKeyManager = new KeyboardManager();
        private KeyboardManager x_TranslitKeyManager = new KeyboardManager();

        #endregion


        #region Form Constructor and Events

        public frmMainForm()
        {
            InitializeComponent();

            InitializeRepositories();

            FillAlphabets(false);

            ctlMultiRtb1.MessageSent += new ctlMultiRtb.CtlMessage(ctlMultiRtb1_MessageSent);
            ctlMultiRtb1.ResetFormatDisplay();
            //config
            mniTranslitPanel.Checked = false;
            btnShowTranslit.Checked = false;
            spltMain.Panel1Collapsed = true;
            btnMainKeyboard.Checked = false;
            mniMainKeyboard.Checked = false;
        }

        private void InitializeRepositories()
        {
            var _configFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Bitig"); //config
            x_DataContext = new XmlContext(_configFolder);
            x_AlphabetRepository = x_DataContext.AlphabetRepository;
            x_DirectionRepository = x_DataContext.DirectionRepository;
        }

        private void ctlMultiRtb1_MessageSent(object sender, Bitig.RtbControl.Utilities.MessageArgs e)
        {
            switch (e.MessageType)
            {
                case Bitig.RtbControl.Utilities.MessageArgs.EMessageTypes.FileNameChanged:
                    this.Text = string.Format("{0} - Bitig", e.Message);
                    break;
            }
        }


        private void frmMainForm_Load(object sender, EventArgs e)
        {
            if (!spltMain.Panel1Collapsed)
            {
                //config:spltMain.SplitterDistance = Properties.Settings.Default.k_SplitterDistance;
                x_SplitterShown1stTime = false;
            }
            ctlMultiRtb1.RtbMain.Select();
            ToolStripManager.Merge(ctlMultiRtb1.mnuMultiRTB, mnuMain);
            if (!string.IsNullOrEmpty(x_FilePath))
                ctlMultiRtb1.OpenFile(x_FilePath);
        }


        private void frmMainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing && !ctlMultiRtb1.PromptSave())
            {
                e.Cancel = true;
                return;
            }
            //config:Properties.Settings.Default.k_SplitterDistance = spltMain.SplitterDistance;
            //Properties.Settings.Default.k_AlphabetLocation = tlsAlphabet.Location;
            //Properties.Settings.Default.k_Panel1Collapsed = spltMain.Panel1Collapsed;
            //Properties.Settings.Default.k_TlsMainLocation = tlsMain.Location;
            //ctlMultiRtb1.SaveSettings();
            //Properties.Settings.Default.Save();
        }

        #endregion


        #region Text Processing Methods

        private string InsertTextboxLineBreaks(string SourceText)
        {
            var _lineBreaksFinder = new Regex("(?<!\r)\n");
            return _lineBreaksFinder.Replace(SourceText, "\r\n");
        }

        #endregion

        #region Form Layout

        private void btnMainKeyboard_CheckedChanged(object sender, EventArgs e)
        {
            mniMainKeyboard.Checked = btnMainKeyboard.Checked;
        }


        private void mniAlphabet_CheckedChanged(object sender, EventArgs e)
        {
            if (mniMainKeyboard.Checked)
                LoadOnscreenKeyboard(x_MainAlphabet, pnlMainKeyboard, ctlMultiRtb1.RtbMain);
            else pnlMainKeyboard.Visible = false;
        }

        private void HideTranslitArea()
        {
            x_ProcessingTranslitArea = true;
            btnShowTranslit.Checked = false;
            mniTranslitPanel.Checked = false;
            spltMain.Panel1Collapsed = true;
            cmbTranslit.Visible = false;
            x_ProcessingTranslitArea = false;
        }

        private void ShowTranslitArea()
        {
            x_ProcessingTranslitArea = true;
            btnShowTranslit.Checked = true;
            mniTranslitPanel.Checked = true;
            spltMain.Panel1Collapsed = false;
            cmbTranslit.Visible = true;
            if (x_SplitterShown1stTime)
            {
                //config:spltMain.SplitterDistance = Properties.Settings.Default.k_SplitterDistance;
                x_SplitterShown1stTime = false;
            }
            x_ProcessingTranslitArea = false;
        }

        private void btnShowTranslit_CheckedChanged(object sender, EventArgs e)
        {
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
                int _optimalHeight = (TargetPanel.Controls[0] as ctlAlphabet).CalculateHeight();
                TargetPanel.Height = _optimalHeight;
            }
        }

        private void pnlTranslit_SizeChanged(object sender, EventArgs e)
        {
            AdjustKeyboardPanel(pnlTranslitKeyboard);
        }

        private void pnlMain_SizeChanged(object sender, EventArgs e)
        {
            AdjustKeyboardPanel(pnlMainKeyboard);
        }

        #endregion

        #region Alphabets Handling

        private AlphabetSummary x_TranslitAlphabet;

        private AlphabetSummary x_MainAlphabet;

        private List<AlphabetSummary> x_AlphabetList;

        private bool x_FillingAlphabets;

        private void FillAlphabets(bool RestoreSelectedItems)
        {
            x_FillingAlphabets = true;

            var _prevTranslit = cmbTranslit.SelectedItem as AlphabetSummary;
            var _prevMain = cmbMainAlphabet.SelectedItem as AlphabetSummary;
            x_AlphabetList = x_AlphabetRepository.GetList();
            if (!RestoreSelectedItems)
            {
                var _mainID = 1; //config
                var _translitID = 0; //config
                _prevMain = x_AlphabetList.Find(x => x.ID == _mainID);
                _prevTranslit = x_AlphabetList.Find(x => x.ID == _translitID);
            }
            cmbTranslit.Items.Clear();
            cmbMainAlphabet.Items.Clear();
            foreach (var _alphabet in x_AlphabetList)
            {
                cmbTranslit.Items.Add(_alphabet);
                cmbMainAlphabet.Items.Add(_alphabet);
            }
            if (x_AlphabetList.Count < 2)
            {
                btnShowTranslit.Checked = false;
                btnShowTranslit.Enabled = false;
                mniTranslitPanel.Enabled = false;
            }
            else
            {
                btnShowTranslit.Enabled = true;
                mniTranslitPanel.Enabled = false;
            }
            x_FillingAlphabets = false;
            if (_prevTranslit != null && cmbTranslit.Items.Contains(_prevTranslit))
            {
                cmbTranslit.SelectedItem = _prevTranslit;
            }
            else if (cmbTranslit.Items.Count > 0)
                cmbTranslit.SelectedIndex = 0;
            if (_prevMain != null && cmbMainAlphabet.Items.Contains(_prevMain))
            {
                cmbMainAlphabet.SelectedItem = _prevMain;
            }
            else if (cmbMainAlphabet.Items.Count > 0)
                cmbMainAlphabet.SelectedIndex = 0;

            if (cmbMainAlphabet.SelectedItem == null) //SelectedIndex_Changed was not triggered
                GetMainAlphabet();
            if (cmbTranslit.SelectedItem == null) 
                GetTranslitAlphabet();
        }

        private void cmbMainAlphabet_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!x_FillingAlphabets) GetMainAlphabet();
        }

        private void cmbTranslit_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!x_FillingAlphabets) GetTranslitAlphabet();
        }

        private void GetTranslitAlphabet()
        {
            var _prevTranslit = x_TranslitAlphabet;
            x_TranslitAlphabet = cmbTranslit.SelectedItem as AlphabetSummary;
            AssignAlphabetProperties(x_TranslitAlphabet, txtTranslit);
            if (x_TranslitAlphabet != null && OnscreenSymbolsAvailable(x_TranslitAlphabet.ID))
            {
                btnTranslitKeyboard.Enabled = true;
                if (btnTranslitKeyboard.Checked)
                {
                    LoadOnscreenKeyboard(x_TranslitAlphabet, pnlTranslitKeyboard, txtTranslit);
                }
            }
            else
            {
                btnTranslitKeyboard.Enabled = false;
                btnTranslitKeyboard.Checked = false;
                pnlTranslitKeyboard.Visible = false;
            }
            if (x_TranslitAlphabet != null && KeyboardLayoutAvailable(x_TranslitAlphabet.ID))
            {
                if (!x_TranslitKeyManager.IsAttached)
                    x_TranslitKeyManager.AttachTo(txtTranslit);
                x_TranslitKeyManager.SetKeyboardLayout(x_KeyboardLayouts[x_TranslitAlphabet.ID]);
            }
            else
            {
                if (x_TranslitKeyManager.IsAttached)
                    x_TranslitKeyManager.Detach();
            }
            if (x_TranslitAlphabet == null)
            {
                btnTranslitConfig.Enabled = false;
            }
            else
            {
                btnTranslitConfig.Enabled = true;
                if (x_TranslitAlphabet.Equals(x_MainAlphabet))
                {
                    if (_prevTranslit != null && !_prevTranslit.Equals(x_MainAlphabet))
                        cmbMainAlphabet.SelectedItem = _prevTranslit;
                    else
                    {
                        var _anyOtherAlphabet = x_AlphabetList.Find(x => !x.Equals(x_TranslitAlphabet));
                        cmbMainAlphabet.SelectedItem = _anyOtherAlphabet;
                    }
                }
            }
            GetCurrentDirection();
        }

        private void GetMainAlphabet()
        {
            var _prevMain = x_MainAlphabet;
            x_MainAlphabet = cmbMainAlphabet.SelectedItem as AlphabetSummary;
            AssignAlphabetProperties(x_MainAlphabet, ctlMultiRtb1.RtbMain);
            if (x_MainAlphabet != null && OnscreenSymbolsAvailable(x_MainAlphabet.ID))
            {
                btnMainKeyboard.Enabled = true;
                if (btnMainKeyboard.Checked)
                {
                    LoadOnscreenKeyboard(x_MainAlphabet, pnlMainKeyboard, ctlMultiRtb1.RtbMain);
                }
            }
            else
            {
                btnMainKeyboard.Enabled = false;
                btnMainKeyboard.Checked = false;
                pnlMainKeyboard.Visible = false;
            }
            if (x_MainAlphabet != null && KeyboardLayoutAvailable(x_MainAlphabet.ID))
            {
                if (!x_MainKeyManager.IsAttached)
                    x_MainKeyManager.AttachTo(ctlMultiRtb1.RtbMain);
                x_MainKeyManager.SetKeyboardLayout(x_KeyboardLayouts[x_MainAlphabet.ID]);
            }
            else
            {
                if (x_MainKeyManager.IsAttached)
                    x_MainKeyManager.Detach();
            }
            if (x_MainAlphabet == null)
            {
                btnMainConfig.Enabled = false;
            }
            else
            {
                btnMainConfig.Enabled = true;
                if (x_MainAlphabet.Equals(x_TranslitAlphabet))
                {
                    if (_prevMain != null && !_prevMain.Equals(x_TranslitAlphabet))
                        cmbTranslit.SelectedItem = _prevMain;
                    else
                    {
                        var _anyOtherAlphabet = x_AlphabetList.Find(x => !x.Equals(x_MainAlphabet));
                        cmbTranslit.SelectedItem = _anyOtherAlphabet;
                    }
                }
            }
            GetCurrentDirection();
        }

        private void AssignAlphabetProperties(AlphabetSummary Alphabet, RichTextBox TargetTextBox)
        {
            if (Alphabet == null)
            {
                TargetTextBox.SelectionFont = SystemFonts.DefaultFont;//config
                TargetTextBox.RightToLeft = RightToLeft.No;
            }
            else
            {
                TargetTextBox.SelectionFont = GetDefaultFont(Alphabet);
                TargetTextBox.RightToLeft = Alphabet.RightToLeft ? RightToLeft.Yes : RightToLeft.No;
            }
        }

        private Font GetDefaultFont(AlphabetSummary Alphabet)
        {
            Font _result = SystemFonts.DefaultFont;//config
            if (Alphabet != null)
            {
                _result = (Font)Alphabet.DefaultFont;
                if (_result == null) return SystemFonts.DefaultFont;
            }
            return _result;
        }

        #endregion

        #region Transliteration

        private Direction x_DirectionToMain;
        private Direction x_DirectionFromMain;

        private void GetCurrentDirection()
        {
            if (x_TranslitAlphabet != null && x_MainAlphabet != null)
            {
                x_DirectionToMain = x_DirectionRepository.GetByAlphabetIDs(x_TranslitAlphabet.ID, x_MainAlphabet.ID);
                x_DirectionFromMain = x_DirectionRepository.GetByAlphabetIDs(x_MainAlphabet.ID, x_TranslitAlphabet.ID);
            }
            else
            {
                x_DirectionToMain = null;
                x_DirectionFromMain = null;
            }
            if (x_DirectionToMain == null)
            {
                btnToMain.Enabled = false;
                mniCurrentMapping.Enabled = false;
            }
            else
            {
                var _toMainToolTip = string.Format("Convert from {0} to {1}", x_TranslitAlphabet.FriendlyName, x_MainAlphabet.FriendlyName);
                btnToMain.Enabled = true;
                btnToMain.ToolTipText = _toMainToolTip;
                mniCurrentMapping.Enabled = x_DirectionToMain.ManualCommand != null;
            }
            if (x_DirectionFromMain == null)
            {
                btnFromMain.Enabled = false;
            }
            else
            {
                btnFromMain.Enabled = true;
                var _fromMainToolTip = string.Format("Convert from {0} to {1}", x_MainAlphabet.FriendlyName, x_TranslitAlphabet.FriendlyName);
                btnFromMain.ToolTipText = _fromMainToolTip;
            }
        }

        private void btnToMain_Click(object sender, EventArgs e)
        {
            if (x_DirectionToMain == null)
                return;
            ctlMultiRtb1.RtbMain.SelectedText = x_DirectionToMain.Transliterate(txtTranslit.Text);
            ctlMultiRtb1.RtbMain.Select(ctlMultiRtb1.RtbMain.TextLength, 0);
            ctlMultiRtb1.RtbMain.ScrollToCaret();
        }

        private void btnFromMain_Click(object sender, EventArgs e)
        {
            if (x_DirectionFromMain == null)
                return;
            string _translitted = x_DirectionFromMain.Transliterate(ctlMultiRtb1.RtbMain.Text);
            txtTranslit.SelectedText = InsertTextboxLineBreaks(_translitted);
        }

        #endregion


        #region Text Input

        #region On-Screen Keyboards

        private Dictionary<int, ctlAlphabet> x_OnscreenKeyboards = new Dictionary<int, ctlAlphabet>();
        private Dictionary<int, List<AlphabetSymbol>> x_OnscreenSymbols = new Dictionary<int, List<AlphabetSymbol>>();
        private Dictionary<int, KeyboardLayoutBase> x_KeyboardLayouts = new Dictionary<int, KeyboardLayoutBase>();

        private void btnTranslitKeyboard_CheckedChanged(object sender, EventArgs e)
        {
            if (btnTranslitKeyboard.Checked)
                LoadOnscreenKeyboard(x_TranslitAlphabet, pnlTranslitKeyboard, txtTranslit);
            else pnlTranslitKeyboard.Visible = false;
        }

        private bool OnscreenSymbolsAvailable(int AlphabetID)
        {
            if (!x_OnscreenSymbols.ContainsKey(AlphabetID))
            {
                var _config = x_AlphabetRepository.Get(AlphabetID);
                if (_config != null && _config.CustomSymbols != null && _config.CustomSymbols.Count(x => x.IsOnScreen) > 0)
                {
                    x_OnscreenSymbols.Add(AlphabetID, _config.CustomSymbols.Where(x => x.IsOnScreen).ToList());
                }
                else x_OnscreenSymbols.Add(AlphabetID, null);
            }
            return x_OnscreenSymbols[AlphabetID] != null;
        }

        private void LoadOnscreenKeyboard(AlphabetSummary Alphabet, Panel KeyboardPanel, TextBoxBase Target)
        {
            var _keyboard = GetOnscreenKeyboard(Alphabet, Target);
            DisplayOnscreenKeyboard(_keyboard, KeyboardPanel);
        }

        private ctlAlphabet GetOnscreenKeyboard(AlphabetSummary Alphabet, TextBoxBase Target)
        {
            InitOnscreenKeyboard(Alphabet, Target);
            return x_OnscreenKeyboards[Alphabet.ID];
        }

        private void InitOnscreenKeyboard(AlphabetSummary Alphabet, TextBoxBase Target)
        {
            if (!OnscreenSymbolsAvailable(Alphabet.ID))
                throw new InvalidOperationException("No on-screen symbols available for alphabet.");
            if (x_OnscreenKeyboards.ContainsKey(Alphabet.ID))
                return;
            ctlAlphabet _keyboard = new ctlAlphabet(x_OnscreenSymbols[Alphabet.ID]);
            _keyboard.Font = new Font(GetDefaultFont(Alphabet).FontFamily, SystemFonts.DefaultFont.SizeInPoints);
            _keyboard.SymbolPressed += (sender, e) => OnscreenKeyboard_SymbolPressed(e, Target);
            x_OnscreenKeyboards.Add(Alphabet.ID, _keyboard);
            _keyboard.Dock = DockStyle.Fill;
        }

        private void OnscreenKeyboard_SymbolPressed(SymbolEventArgs e, TextBoxBase Target)
        {
            int _currentSelection = Target.SelectionStart;
            Target.SelectedText = e.Text;
            Target.SelectionStart = _currentSelection + e.Text.Length;
            Target.Focus();
        }

        private void DisplayOnscreenKeyboard(ctlAlphabet KeyboardControl, Panel KeyboardPanel)
        {
            KeyboardPanel.Controls.Clear();
            KeyboardPanel.Controls.Add(KeyboardControl);
            KeyboardPanel.Visible = true;
            AdjustKeyboardPanel(KeyboardPanel);
        }

        private void ReloadAlphabets()
        {
            ResetOnscreenKeyboards();
            ResetKeyboardLayouts();
            FillAlphabets(true);
        }

        private void ResetOnscreenKeyboards()
        {
            pnlTranslitKeyboard.Controls.Clear();
            pnlMainKeyboard.Controls.Clear();
            foreach (int _key in x_OnscreenKeyboards.Keys)
            {
                if (x_OnscreenKeyboards[_key] != null)
                {
                    x_OnscreenKeyboards[_key].Dispose();
                }
            }
            x_OnscreenKeyboards.Clear();
            x_OnscreenSymbols.Clear();
        }

        #endregion

        #region Keyboard Layouts 

        private bool KeyboardLayoutAvailable(int AlphabetID)
        {
            if (!x_KeyboardLayouts.ContainsKey(AlphabetID))
            {
                var _config = x_AlphabetRepository.Get(AlphabetID);
                if (_config.KeyboardLayout != null)
                {
                    x_KeyboardLayouts.Add(AlphabetID, _config.KeyboardLayout);
                }
                else x_KeyboardLayouts.Add(AlphabetID, null);
            }
            return x_KeyboardLayouts[AlphabetID] != null;
        }

        private void ResetKeyboardLayouts()
        {
            x_KeyboardLayouts.Clear();
        }

        #endregion

        #endregion

        #region Configuration

        private void mniExclusions_Click(object sender, EventArgs e)
        {
            using (var _configForm = new frmExclusions(x_DirectionToMain, x_DataContext, true))
            {
                _configForm.ShowDialog();
            }
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
                    if (_configForm.X_AlphabetsModified || _configForm.X_DirectionsModified)
                    {
                        ReloadAlphabets();
                    }
                }
            }
        }

        private void mniCurrentMapping_Click(object sender, EventArgs e)
        {
            if (x_DirectionToMain == null || x_DirectionToMain.ManualCommand == null)
                return;
            using (var _mappingForm = new frmSymbolMapping(x_DirectionToMain.Source, x_DirectionToMain.Target, x_DirectionRepository, x_DirectionToMain.ManualCommand.SymbolMapping, null))
            {
                if (_mappingForm.ShowDialog() == DialogResult.OK)
                {
                    x_DirectionToMain.ManualCommand = new ManualCommand(_mappingForm.SymbolMapping);
                    x_DirectionRepository.Update(x_DirectionToMain);
                    x_DataContext.SaveChanges();
                }
            }
        }

        private void btnTranslitConfig_Click(object sender, EventArgs e)
        {
            EditAlphabetConfig(x_TranslitAlphabet);
        }

        private void btnMainConfig_Click(object sender, EventArgs e)
        {
            EditAlphabetConfig(x_MainAlphabet);
        }

        private void EditAlphabetConfig(AlphabetSummary AlphabetConfig)
        {
            if (AlphabetConfig == null)
                return;
            using (var _alphabetForm = new frmEditAlphabet(x_DataContext.KeyboardRepository.GetSummaryList()))
            {
                var _alphabet = x_AlphabetRepository.Get(AlphabetConfig.ID);
                _alphabetForm.X_AlphabetConfig = _alphabet;
                if (_alphabetForm.ShowDialog() == DialogResult.OK)
                {
                    x_AlphabetRepository.Update(_alphabetForm.X_AlphabetConfig);
                    x_DataContext.SaveChanges();
                    ReloadAlphabets();
                }
            }
        }

        #endregion
    }
}