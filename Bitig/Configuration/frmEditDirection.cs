using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using Bitig.Logic;
using System.Reflection;
using Bitig.Logic.Model;
using Bitig.Logic.Repository;
using Bitig.UI.ViewModel;

namespace Bitig.UI.Configuration
{
    public partial class frmEditDirection : Form
    {
        private Direction x_Direction;

        public Direction X_Direction
        {
            get { return x_Direction; }
            set
            {
                x_Direction = value;
                if (x_Direction != null)
                {
                    if (x_Direction.IsBuiltIn())
                    {
                        cmbSource.Enabled = false;
                        cmbTarget.Enabled = false;
                        x_AssemblyComboSelectedItem = x_BuiltInAssemblyItem;
                        x_TypeComboSelectedItem = DefaultConfiguration.GetBuiltInDirection(x_Direction.ID);
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(x_Direction.AssemblyPath))
                        {
                            x_AssemblyComboSelectedItem = x_BuiltInAssemblyItem;
                            x_TypeComboSelectedItem = DefaultConfiguration.GetBuiltInDirection(x_Direction.ID);
                        }
                        else
                        {
                            x_SelectedAssemblyPath = x_Direction.AssemblyPath;
                            x_CurrentDisplayedAssembly = x_Direction.GetAssemblyFileName(); 
                            x_AssemblyComboSelectedItem = x_Direction.GetAssemblyFileName();
                            x_TypeComboSelectedItem = x_Direction.TypeName;
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
        private IRepository<Direction, int> x_DirectionRepository;
        private IRepository<Alifba, int> x_AlifbaRepository;

        public frmEditDirection(IRepository<Direction, int> DirectionsRepo, IRepository<Alifba, int> AlifbaRepo)
        {
            InitializeComponent();
            x_DirectionRepository = DirectionsRepo;
            x_AlifbaRepository = AlifbaRepo;
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
            var _source = cmbSource.SelectedItem as Alifba;
            if (_source == null)
            {
                MessageBox.Show("Source is empty", "!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);//loc
                return;
            }
            var _target = cmbTarget.SelectedItem as Alifba;
            if (_target == null)
            {
                MessageBox.Show("Target is empty", "!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);//loc
                return;
            }
            if (_target.Equals(_source))
            {
                MessageBox.Show("Source and target are the same", "!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);//loc
                return;
            }
            Direction _duplicate = null;
            if (x_Direction == null)
            {
                _duplicate = x_DirectionRepository.GetList().Find(_dir => 
                _source.Equals(_dir.Source) && _target.Equals(_dir.Target));
            }
            else
            {
                _duplicate = x_DirectionRepository.GetList().Find(_dir => !_dir.Equals(x_Direction) &&
                _source.Equals(_dir.Source) && _target.Equals(_dir.Target));
            }
            if (_duplicate != null)
            {
                if (MessageBox.Show("Transliteration direction already exists. Replace?", "?",  //loc
                    MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
                    return;
            }
            //int _builtInID = -1;
            BuiltInDirection _builtIn = null;
            if (cmbType.SelectedItem is BuiltInDirection)
            {
                if (DefaultConfiguration.IsBuiltIn(_source.ID) &&
                    _source.ID != (cmbType.SelectedItem as BuiltInDirection).Source.ID)
                {
                    MessageBox.Show("Transliteration source mismatch", "!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                if (DefaultConfiguration.IsBuiltIn(_target.ID) &&
                    _target.ID != (cmbType.SelectedItem as BuiltInDirection).Target.ID)
                {
                    MessageBox.Show("Transliteration target mismatch", "!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                _builtIn = (cmbType.SelectedItem as BuiltInDirection);
               // _builtInID = (cmbType.SelectedItem as BuiltInDirection).ID;
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
                x_DirectionRepository.Delete(_duplicate);
            }
            string _assembly, _type;
            if (_builtIn == null)
            {
                _assembly = x_SelectedAssemblyPath;
                _type = cmbType.Text.Trim();
            }
            else
            {
                _assembly = string.Empty;
                _type = string.Empty;
            }
            if (x_Direction == null)
            {
                x_Direction = new Direction(-1, _source, _target, null,
                x_SelectedAssemblyPath, _type, _builtIn); //repo: , cmbType.Text.Trim() ?
                x_DirectionRepository.Insert(x_Direction);
            }
            else
            {

                x_Direction.AssemblyPath = _assembly;
                x_Direction.TypeName = _type;
                //repo: needed? x_Direction.DisplayedTypeName = cmbType.Text.Trim();
                x_Direction.Source = _source;
                x_Direction.Target = _target;
                x_Direction.BuiltIn = _builtIn;
                x_DirectionRepository.Update(x_Direction);
            }
            this.DialogResult = DialogResult.OK;
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
            if (x_Direction != null)
                _builtIn = DefaultConfiguration.GetBuiltInDirection(x_Direction.Source.ID, x_Direction.Target.ID); //repo: null reference?
            if (_builtIn == null)
            {
                DefaultConfiguration.BuiltInDirections.ForEach(_dir => x_BuiltInTypes.Add(_dir));
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

        private void FillAlifbaCombos()
        {
            int _sourceIndex = -1, _targetIndex = -1;
            var _alifbaList = x_AlifbaRepository.GetList();
            for (int i = 0; i < _alifbaList.Count; i++)
            {
                var _alifba = _alifbaList[i];
                cmbSource.Items.Add(_alifba);
                cmbTarget.Items.Add(_alifba);
                if (x_Direction != null)
                {
                    if (x_Direction.Source.Equals(_alifba))
                        _sourceIndex = i;
                    if (x_Direction.Target.Equals(_alifba))
                        _targetIndex = i;
                }
            }
            cmbSource.SelectedIndex = _sourceIndex;
            cmbTarget.SelectedIndex = _targetIndex;
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
