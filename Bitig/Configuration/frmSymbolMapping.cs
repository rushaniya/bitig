using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using Bitig.Logic.Model;
using Bitig.Logic.Repository;
using Bitig.UI.Configuration.Model;

namespace Bitig.UI.Configuration
{
    public partial class frmSymbolMapping : Form
    {
        public Dictionary<TextSymbol, TextSymbol> SymbolMapping { get; private set; }

        private BindingList<SymbolPair> x_Symbols = new BindingList<SymbolPair>();

        private Alifba x_Source;

        private Alifba x_Target;

        private DirectionRepository x_DirectionRepository;

        public frmSymbolMapping(Alifba Source, Alifba Target, DirectionRepository DirectionRepository, 
            Dictionary<TextSymbol, TextSymbol> SymbolMapping, List<AlifbaSymbol> DefaultSourceSymbols)
        {
            InitializeComponent();
            if (Source == null || Target == null)
            {
                btnFlip.Enabled = false;
            }                
            else if (DirectionRepository == null)
                throw new ArgumentNullException(nameof(DirectionRepository));
            x_DirectionRepository = DirectionRepository;
            x_Source = Source;
            x_Target = Target;
            this.SymbolMapping = new Dictionary<TextSymbol, TextSymbol>();
            bndSymbols.DataSource = x_Symbols;
            if (SymbolMapping == null)
            {
                //pre-fill with symbols of the source alphabet
                if (DefaultSourceSymbols != null)
                {
                    foreach (var _symbol in DefaultSourceSymbols)
                    {
                        x_Symbols.Add(new SymbolPair
                        {
                            SourceLower = _symbol.ActualText,
                            SourceUpper = _symbol.CapitalizedText,
                            TargetLower = string.Empty,
                            TargetUpper = string.Empty
                        });
                    }
                }
            }
            else
            {
                foreach (var _symbol in SymbolMapping)
                {
                    x_Symbols.Add(new SymbolPair
                    {
                        SourceLower = _symbol.Key.ActualText,
                        SourceUpper = _symbol.Key.CapitalizedText,
                        TargetLower = _symbol.Value.ActualText,
                        TargetUpper = _symbol.Value.CapitalizedText
                    });
                }
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            SymbolMapping.Clear();
            foreach (var _symbolPair in x_Symbols)
            {
                if (string.IsNullOrEmpty(_symbolPair.SourceLower))
                    continue;
                var _key = new TextSymbol(_symbolPair.SourceLower, _symbolPair.SourceUpper);
                if (SymbolMapping.ContainsKey(_key))
                {
                    //loc
                    MessageBox.Show("Duplicate key: " + _key.ActualText, "!");
                    return;
                }
                SymbolMapping.Add(_key,
                    new TextSymbol(_symbolPair.TargetLower, _symbolPair.TargetUpper));
            }
            DialogResult = DialogResult.OK;
        }

        private void btnFlip_Click(object sender, EventArgs e)
        {
            if (x_Symbols.Count == 0)
            {
                //loc
                MessageBox.Show("Symbol map is empty.", "!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            var _existingDirection = x_DirectionRepository.GetByAlifbaIDs(x_Target.ID, x_Source.ID);
            if (_existingDirection != null)
            {
                //loc
                MessageBox.Show("Opposite direction already exists.", "!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            var _oppositeMapping = new Dictionary<TextSymbol, TextSymbol>();
            var _duplicatesExist = false;
            foreach (var _symbolPair in x_Symbols)
            {
                if (string.IsNullOrEmpty(_symbolPair.TargetLower))
                    continue;
                var _key = new TextSymbol(_symbolPair.TargetLower, _symbolPair.TargetUpper);
                if (_oppositeMapping.ContainsKey(_key))
                    _duplicatesExist = true;
                else
                    _oppositeMapping.Add(_key, new TextSymbol(_symbolPair.SourceLower, _symbolPair.SourceUpper));
            }
            if (_oppositeMapping.Count == 0)
            {
                //loc
                MessageBox.Show("Fill in target symbols.", "!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (_duplicatesExist)
            {
                //loc
                if (MessageBox.Show("Duplicate symbols will be removed. Continue?", "?", MessageBoxButtons.YesNo) == DialogResult.No)
                    return;
            }
            x_DirectionRepository.Insert(new Direction(-1, x_Target, x_Source, ManualCommand: new ManualCommand(_oppositeMapping)));
            MessageBox.Show("Opposite direction created.");
        }
    }
}
