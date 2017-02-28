using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Bitig.Logic;
using System.Reflection;
using Bitig.Logic.Model;

namespace Bitig.UI.Configuration
{
    public partial class frmEditDirection : Form
    {
        private DirectionConfig x_DirectionConfig;

        public DirectionConfig X_DirectionConfig
        {
            get { return x_DirectionConfig; }
            set
            {
                x_DirectionConfig = value;
                if (x_DirectionConfig != null)
                {
                    if (x_DirectionConfig.IsBuiltIn)
                    {
                        cmbSource.Enabled = false;
                        cmbTarget.Enabled = false;
                        //x_AssemblyComboSelectedItem = x_DirectionConfig.GetBuiltInDirectionObject();
                        x_AssemblyComboSelectedItem = x_BuiltInAssemblyItem;
                        x_TypeComboSelectedItem = x_DirectionConfig.GetBuiltInDirectionObject();
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(x_DirectionConfig.AssemblyPath))
                        {
                            //x_AssemblyComboSelectedItem = x_DirectionConfig.GetBuiltInDirectionObject();
                            x_AssemblyComboSelectedItem = x_BuiltInAssemblyItem;
                            x_TypeComboSelectedItem = x_DirectionConfig.GetBuiltInDirectionObject();
                        }
                        else
                        {
                            x_SelectedAssemblyPath = x_DirectionConfig.AssemblyPath;
                            x_CurrentDisplayedAssembly = x_DirectionConfig.AssemblyFileName;
                            x_AssemblyComboSelectedItem = x_DirectionConfig.AssemblyFileName;
                            //cmbType.Text = x_DirectionConfig.TypeName;
                            x_TypeComboSelectedItem = x_DirectionConfig.TypeName;
                        }
                    }
                }
            }
        }

        private int x_BrowseAssemblyIndex = -1;
        private string x_SelectedAssemblyPath, x_CurrentDisplayedAssembly, x_BitigLogicPath;
        private bool x_FillingAssemblyCombo;
        private List<BuiltInDirection> x_BuiltInTypes;
        private object x_AssemblyComboSelectedItem;
        private object x_TypeComboSelectedItem;
        private string x_BuiltInAssemblyItem = "Built-in directions";//loc

        public frmEditDirection()
        {
            InitializeComponent();
            try
            {
                string _exePath = Application.StartupPath;
                dlgBrowseAssembly.InitialDirectory = _exePath;
                x_BitigLogicPath = System.IO.Path.Combine(_exePath, "BitigLogic.dll");
                x_BitigLogicPath = System.IO.Path.GetFullPath(x_BitigLogicPath).ToUpperInvariant();
            }
            catch { }
            dlgBrowseAssembly.Filter = "Assembly files (*.dll, *.exe)|*.dll;*.exe|All files|*";
        }

        private void frmEditDirection_Load(object sender, EventArgs e)
        {
            FillAlifbaCombos();
            PrepareBuiltInItems();
            FillAssemblyCombo();
            if (x_TypeComboSelectedItem != null)
            {
                cmbType.SelectedItem = x_TypeComboSelectedItem;
                if (cmbType.SelectedItem == null) //no such item in drop-down list
                    cmbType.Text = x_TypeComboSelectedItem.ToString();
            }
        }

        //repo
        private void btnOK_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
           /* AlifbaConfig _source = cmbSource.SelectedItem as AlifbaConfig;
            if (_source == null)
            {
                MessageBox.Show("Source is empty", "!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);//loc
                return;
            }
            AlifbaConfig _target = cmbTarget.SelectedItem as AlifbaConfig;
            if (_target == null)
            {
                MessageBox.Show("Target is empty", "!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);//loc
                return;
            }
            if (_target.AlifbaID == _source.AlifbaID)
            {
                MessageBox.Show("Source and target are the same", "!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);//loc
                return;
            }
            DirectionConfig _duplicate = null;
            if (x_DirectionConfig == null)
            {
                _duplicate = BitigConfigManager.DirectionConfigurations.Find(_dir => _dir.SourceID == _source.AlifbaID && _dir.TargetID == _target.AlifbaID);
            }
            else
            {
                _duplicate = BitigConfigManager.DirectionConfigurations.Find(_dir => _dir.DirectionID != x_DirectionConfig.DirectionID &&
                    _dir.SourceID == _source.AlifbaID && _dir.TargetID == _target.AlifbaID);
            }
            if (_duplicate != null)
            {
                if (MessageBox.Show("Transliteration direction already exists. Replace?", "?", 
                    MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
                    return;
            }
            int _builtInID = -1;
            if (cmbType.SelectedItem is BuiltInDirection)
            {
                if (AlifbaManager.IsBuiltIn(_source.AlifbaID) &&
                    _source.AlifbaID != (cmbType.SelectedItem as BuiltInDirection).SourceAlifbaID)
                {
                    MessageBox.Show("Transliteration source mismatch", "!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                if (AlifbaManager.IsBuiltIn(_target.AlifbaID) &&
                    _target.AlifbaID != (cmbType.SelectedItem as BuiltInDirection).TargetAlifbaID)
                {
                    MessageBox.Show("Transliteration target mismatch", "!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                _builtInID = (cmbType.SelectedItem as BuiltInDirection).ID;
            }
            else
            {
                if (string.IsNullOrEmpty(x_SelectedAssemblyPath))
                {
                    MessageBox.Show("Library is empty", "!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);//loc
                    return;
                }
                if (cmbType.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Type name is empty", "!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);//loc
                    return;
                }
            }
            if (_duplicate != null)
            {
                BitigConfigManager.DeleteDirectionConfig(_duplicate);
            }
            string _assembly, _type;
            if (_builtInID == -1)
            {
                _assembly = x_SelectedAssemblyPath;
                _type = cmbType.Text.Trim();
            }
            else
            {
                _assembly = string.Empty;
                _type = string.Empty;
            }
            if (x_DirectionConfig == null) x_DirectionConfig = BitigConfigManager.CreateDirectionConfig(_source.AlifbaID, _target.AlifbaID, 
                x_SelectedAssemblyPath, _type, cmbType.Text.Trim(), _builtInID);
            else
            {
                
                x_DirectionConfig.AssemblyPath = _assembly;
                x_DirectionConfig.TypeName = _type;
                x_DirectionConfig.DisplayedTypeName = cmbType.Text.Trim();
                x_DirectionConfig.SourceID = _source.AlifbaID;
                x_DirectionConfig.TargetID = _target.AlifbaID;
                x_DirectionConfig.BuiltInID = _builtInID;
            }
            this.DialogResult = DialogResult.OK;*/
        }

        private void cmbAssembly_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbType.Items.Clear();
            cmbType.Text = string.Empty;
            if (!string.IsNullOrEmpty(x_CurrentDisplayedAssembly) && cmbAssembly.Text == x_CurrentDisplayedAssembly)
            {
                //if (System.IO.Path.GetFullPath(x_SelectedAssemblyPath).ToUpperInvariant() == x_BitigLogicPath)
                //    cmbAssembly.SelectedIndex = 0;
                //else
                tipAssembly.SetToolTip(cmbAssembly, x_SelectedAssemblyPath);
                FillAssemblyTypes();
            }
            else
            {
                if (cmbAssembly.SelectedIndex == 0) //built-in
                {
                    FillBuiltInTypes();
                }
                tipAssembly.SetToolTip(cmbAssembly, string.Empty);
            }
        }

        private void cmbAssembly_SelectedIndexChanging(object sender, CancelEventArgs e)
        {
            if (x_FillingAssemblyCombo) return;
            if (cmbAssembly.SelectedIndex == x_BrowseAssemblyIndex)
            {
                if (!string.IsNullOrEmpty(x_SelectedAssemblyPath)) dlgBrowseAssembly.FileName = x_SelectedAssemblyPath;
                if (dlgBrowseAssembly.ShowDialog() == DialogResult.OK)
                {
                    if (System.IO.Path.GetFullPath(dlgBrowseAssembly.FileName).ToUpperInvariant() == x_BitigLogicPath)
                    {
                        e.Cancel = true;
                        cmbAssembly.SelectedIndex = 0;//built-in
                    }
                    else
                    {
                        x_SelectedAssemblyPath = dlgBrowseAssembly.FileName;
                        x_CurrentDisplayedAssembly = System.IO.Path.GetFileName(x_SelectedAssemblyPath);
                        x_AssemblyComboSelectedItem = System.IO.Path.GetFileName(x_SelectedAssemblyPath);
                        FillAssemblyCombo();
                    }
                }
                else e.Cancel = true;
            }
        }

        private void PrepareBuiltInItems()
        {
            x_BuiltInTypes = new List<BuiltInDirection>();
            BuiltInDirection _builtIn = null;
            if (x_DirectionConfig != null)
                _builtIn = DirectionManager.GetBuiltInDirection(x_DirectionConfig.SourceID, x_DirectionConfig.TargetID);
            if (_builtIn == null)
            {
                DirectionManager.BuiltInDirections.ForEach(_dir => x_BuiltInTypes.Add(_dir));
            }
            else
            {
                x_BuiltInTypes.Add(_builtIn);
            }
        }

        private void FillAssemblyCombo()
        {
            x_FillingAssemblyCombo = true;
            cmbAssembly.Items.Clear();
            //x_AssemblyComboItems.ForEach(_item => cmbAssembly.Items.Add(_item));
            cmbAssembly.Items.Add(x_BuiltInAssemblyItem);
            if (!string.IsNullOrEmpty(x_SelectedAssemblyPath))
            {
                cmbAssembly.Items.Add(x_CurrentDisplayedAssembly);
            }
            cmbAssembly.Items.Add("Browse...");//loc
            x_BrowseAssemblyIndex = cmbAssembly.Items.Count - 1;
            //if (cmbAssembly.Items.Count == 1) cmbAssembly.Text = string.Empty;else 
            cmbAssembly.SelectedItem = x_AssemblyComboSelectedItem;
            x_FillingAssemblyCombo = false;
        }

        //repo
        private void FillAlifbaCombos()
        {
            throw new NotImplementedException();
            //int _sourceIndex = -1, _targetIndex = -1;
            //for (int i = 0; i < BitigConfigManager.AlifbaConfigurations.Count; i++)
            //{
            //    cmbSource.Items.Add(BitigConfigManager.AlifbaConfigurations[i]);
            //    cmbTarget.Items.Add(BitigConfigManager.AlifbaConfigurations[i]);
            //    if (x_DirectionConfig != null)
            //    {
            //        if (x_DirectionConfig.SourceID == BitigConfigManager.AlifbaConfigurations[i].AlifbaID)
            //            _sourceIndex = i;
            //        if (x_DirectionConfig.TargetID == BitigConfigManager.AlifbaConfigurations[i].AlifbaID)
            //            _targetIndex = i;
            //    }
            //}
            //cmbSource.SelectedIndex = _sourceIndex;
            //cmbTarget.SelectedIndex = _targetIndex;
        }

        private void FillAssemblyTypes()
        {
            cmbType.DropDownStyle = ComboBoxStyle.DropDown;
            this.Cursor = Cursors.WaitCursor;
            try
            {
                Assembly _lib = Assembly.ReflectionOnlyLoadFrom(x_SelectedAssemblyPath);
                Type[] _types = _lib.GetTypes();
                foreach (Type _t in _types)
                {
                    Type _base = _t.BaseType;
                    bool _inherited = false;
                    while (_base != null && _base != typeof(object) && !_base.IsPrimitive)
                    {
                        if (_base.FullName == "Bitig.Base.TranslitCommand")
                        {
                            _inherited = true;
                            break;
                        }
                        _base = _base.BaseType;
                    }
                    if (_inherited && !_t.IsAbstract)
                        cmbType.Items.Add(_t.FullName);
                }
            }
            catch
            {
                if (x_TypeComboSelectedItem is string)//type name
                    cmbType.Text = x_TypeComboSelectedItem.ToString();
            }
            this.Cursor = Cursors.Default;
        }

        private void FillBuiltInTypes()
        {
            cmbType.DropDownStyle = ComboBoxStyle.DropDownList;
            x_BuiltInTypes.ForEach(_type => cmbType.Items.Add(_type));
            //cmbType.SelectedItem = x_TypeComboSelectedItem;
            if (cmbType.Items.Count == 1) cmbType.SelectedIndex = 0;
        }
    }
}
