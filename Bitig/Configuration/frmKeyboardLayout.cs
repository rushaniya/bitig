using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Bitig.Base;
using Bitig.KeyboardManagement;
using Bitig.Logic.Repository;
using Bitig.UI.Configuration.Model;

namespace Bitig.UI.Configuration
{
    public partial class frmKeyboardLayout : Form
    {
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern short GetAsyncKeyState(Keys vKey);

        private const string FULL_KEYBOARD = "Full"; //loc
        private const string MAGIC_KEYBOARD = "Magic"; //loc

        private KeyboardLayoutBase x_KeyboardLayout;

        public KeyboardLayoutBase X_KeyboardLayout
        {
            get { return x_KeyboardLayout; }
            set
            {
                x_KeyboardLayout = value;
                if (x_KeyboardLayout == null)
                {
                    x_KeyCombinations = new BindingList<KeyCombinationConfig>();
                    x_MagicKeyCombinations = new BindingList<MagicKeyCombination>();
                }
                else
                {
                    cmbKeyboardType.Enabled = false;
                    txtFriendlyName.Text = x_KeyboardLayout.FriendlyName;
                    if (x_KeyboardLayout.Type == KeyboardLayoutType.Full)
                    {
                        cmbKeyboardType.SelectedIndex = 0;
                        pnlFullKeyboard.Visible = true;
                        pnlMagicKeyboard.Visible = false;
                        var _fullKeyboard = x_KeyboardLayout as KeyboardLayout;
                        x_KeyCombinations = new BindingList<KeyCombinationConfig>(
                            _fullKeyboard.KeyCombinations
                            .Select(x =>
                                 new KeyCombinationConfig
                                 {
                                     Capital = x.Capital,
                                     Combination = KeysParser.KeyStrokeToString(new KeyStroke
                                     {
                                         MainKey = x.MainKey,
                                         WithShift = x.WithShift,
                                         WithCtrl = x.WithCtrl,
                                         WithAlt = x.WithAlt,
                                         WithAltGr = x.WithAltGr
                                     }),
                                     Symbol = x.Result
                                 })
                         .ToList());
                    }
                    else
                    {
                        cmbKeyboardType.SelectedIndex = 1;
                        pnlFullKeyboard.Visible = false;
                        pnlMagicKeyboard.Visible = true;
                        var _magicKeyboard = x_KeyboardLayout as MagicKeyboardLayout;
                        bndMagicKeyCombinations.DataSource = _magicKeyboard.KeyCombinations;
                        txtMagicKey.Text = KeysParser.ConvertKeysToString(_magicKeyboard.MagicKey);
                        x_MagicKeyCombinations = new BindingList<MagicKeyCombination>(
                            _magicKeyboard.KeyCombinations
                            .Select(x =>
                            new MagicKeyCombination
                            {
                                Symbol = x.Symbol,
                                WithMagic = x.WithMagic
                            })
                            .ToList());
                    }
                }
            }
        }

        private BindingList<KeyCombinationConfig> x_KeyCombinations;
        private BindingList<MagicKeyCombination> x_MagicKeyCombinations;

        private KeyboardRepository x_KeyboardRepository;

        public frmKeyboardLayout(IDataContext DataContext)
        {
            InitializeComponent();
            x_KeyboardRepository = DataContext.KeyboardRepository;
            cmbKeyboardType.Items.Add(FULL_KEYBOARD);
            cmbKeyboardType.Items.Add(MAGIC_KEYBOARD);
            cmbKeyboardType.SelectedIndex = 0;
            pnlMagicKeyboard.Visible = false;
            bndKeyCombinations.DataSource = x_KeyCombinations;
            bndMagicKeyCombinations.DataSource = x_MagicKeyCombinations;
        }

        private void cmbKeyboardType_SelectedIndexChanged(object sender, EventArgs e)
        {
            var _isFull = cmbKeyboardType.SelectedIndex == 0;
            pnlFullKeyboard.Visible = _isFull;
            pnlMagicKeyboard.Visible = !_isFull;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            var _friendlyName = txtFriendlyName.Text.Trim();
            if (_friendlyName == string.Empty)
            {
                MessageBox.Show("Name is empty", "!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);//loc
                return;
            }
            if (cmbKeyboardType.SelectedIndex == 0)
            {
                if (x_KeyCombinations.Count == 0)
                {
                    MessageBox.Show("Key combination list is empty", "!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);//loc
                    return;
                }
                var _keyCombinations = new List<KeyCombination>();
                foreach (var _keyCombination in x_KeyCombinations)
                {
                    if (_keyCombination.Combination == null || _keyCombination.Combination.Trim() == string.Empty)
                    {
                        MessageBox.Show("Key combination is empty", "!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);//loc
                        return;
                    }
                    KeyStroke _keyStroke;
                    try
                    {
                        _keyStroke = KeysParser.ParseKeyStroke(_keyCombination.Combination);
                    }
                    catch (ArgumentException)
                    {
                        MessageBox.Show(string.Format("{0} is not a valid key combination", _keyCombination.Combination), "!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);//loc
                        return;
                    }
                    if (_keyCombinations.Any(x => x.MainKey == _keyStroke.MainKey &&
                         x.WithAlt == _keyStroke.WithAlt &&
                         x.WithAltGr == _keyStroke.WithAltGr &&
                         x.WithCtrl == _keyStroke.WithCtrl &&
                         x.WithShift == _keyStroke.WithShift))
                    {
                        MessageBox.Show(string.Format("Duplicate key combination {0}", _keyCombination.Combination), "!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);//loc
                        return;
                    }
                    if (string.IsNullOrEmpty(_keyCombination.Symbol))
                    {
                        MessageBox.Show(string.Format("Empty symbol for combination {0}", _keyCombination.Combination), "!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);//loc
                        return;
                    }
                    _keyCombinations.Add(new KeyCombination
                    {
                        Capital = _keyCombination.Capital,
                        MainKey = _keyStroke.MainKey,
                        Result = _keyCombination.Symbol,
                        WithAlt = _keyStroke.WithAlt,
                        WithAltGr = _keyStroke.WithAltGr,
                        WithCtrl = _keyStroke.WithCtrl,
                        WithShift = _keyStroke.WithShift
                    });
                }
                if (x_KeyboardLayout == null)
                {
                    var _newLayout = new KeyboardLayout
                    {
                        FriendlyName = _friendlyName,
                        KeyCombinations = _keyCombinations
                    };
                    x_KeyboardRepository.Insert(_newLayout);
                }
                else
                {
                    x_KeyboardLayout.FriendlyName = _friendlyName;
                    (x_KeyboardLayout as KeyboardLayout).KeyCombinations = _keyCombinations;
                    x_KeyboardRepository.Update(x_KeyboardLayout);
                }
                DialogResult = DialogResult.OK;
                return;
            }
            if (cmbKeyboardType.SelectedIndex == 1)
            {
                var _magicKey = txtMagicKey.Text.Trim();
                if (_magicKey == string.Empty)
                {
                    MessageBox.Show("Magic key is empty", "!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);//loc
                    return;
                }
                Keys key;
                try
                {
                    key = KeysParser.ConvertToKeysEnum(_magicKey);
                }
                catch (ArgumentException)
                {
                    MessageBox.Show("Magic key is not a valid key", "!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);//loc
                    return;
                }
                if (x_MagicKeyCombinations.Count == 0)
                {
                    MessageBox.Show("Key combination list is empty", "!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);//loc
                    return;
                }
                var _keyCombinations = new List<MagicKeyCombination>();
                foreach (var _keyCombination in x_MagicKeyCombinations)
                {
                    if (_keyCombination.Symbol == 0) //kbl: this way?
                    {
                        MessageBox.Show("Source symbol is empty", "!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);//loc
                        return;
                    }
                    if (_keyCombinations.Any(x => x.Symbol == _keyCombination.Symbol))
                    {
                        MessageBox.Show(string.Format("Duplicate source symbol {0}", _keyCombination.Symbol), "!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);//loc
                        return;
                    }
                    if (string.IsNullOrEmpty(_keyCombination.WithMagic))
                    {
                        MessageBox.Show(string.Format("Empty result with magic for source symbol {0}", _keyCombination.Symbol), "!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);//loc
                        return;
                    }
                    _keyCombinations.Add(new MagicKeyCombination
                    {
                        Symbol = _keyCombination.Symbol,
                        WithMagic = _keyCombination.WithMagic
                    });
                }
                if (x_KeyboardLayout == null)
                {
                    var _newLayout = new MagicKeyboardLayout
                    {
                        FriendlyName = _friendlyName,
                        KeyCombinations = _keyCombinations
                    };
                    x_KeyboardRepository.Insert(_newLayout);
                }
                else
                {
                    x_KeyboardLayout.FriendlyName = _friendlyName;
                    (x_KeyboardLayout as MagicKeyboardLayout).KeyCombinations = _keyCombinations;
                    x_KeyboardRepository.Update(x_KeyboardLayout);
                }
                DialogResult = DialogResult.OK;
                return;
            }
            throw new NotSupportedException("Unknown keyboard layout type."); //loc
        }

        private string GetCombinationName(Keys keyCode)
        {
            var keyNames = new List<string>();
            if (Convert.ToBoolean(GetAsyncKeyState(Keys.LControlKey)) || Convert.ToBoolean(GetAsyncKeyState(Keys.RControlKey)))
                keyNames.Add("Ctrl");
            if (Convert.ToBoolean(GetAsyncKeyState(Keys.LShiftKey)) || Convert.ToBoolean(GetAsyncKeyState(Keys.RShiftKey)))
                keyNames.Add("Shift");
            if (Convert.ToBoolean(GetAsyncKeyState(Keys.LMenu)))
            {
                keyNames.Add("Alt");
            }
            if (Convert.ToBoolean(GetAsyncKeyState(Keys.RMenu)))
            {
                keyNames.Add("AltGr");
            }
            keyNames.Add(keyCode.ToString());
            var description = string.Join("+", keyNames.ToArray());
            return description;
        }
    }
}
