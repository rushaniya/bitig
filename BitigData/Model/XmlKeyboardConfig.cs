using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bitig.Base;
using Bitig.Logic.Model;
using Bitig.Logic.Repository;

namespace Bitig.Data.Model
{
    public class XmlKeyCombinationCollection : EquatableByID<int>, IDeepCloneable<XmlKeyCombinationCollection>
    {
        public override int ID
        {
            get; set;
        }

        public List<XmlKeyCombination> KeyCombinations { get; set; }

        public XmlKeyCombinationCollection Clone()
        {
            return new XmlKeyCombinationCollection { ID = ID, KeyCombinations = KeyCombinations.Select(x => x.Clone()).ToList() };
        }
    }

    public class XmlKeyCombination : IDeepCloneable<XmlKeyCombination>
    {
        public string Combination { get; set; }
        public string Result { get; set; }
        public string Capital { get; set; }

        public XmlKeyCombination()
        {

        }

        public XmlKeyCombination(KeyCombination Model)
        {
            Result = Model.Result;
            Capital = Model.Capital;
            var _combination = new StringBuilder();
            if (Model.WithCtrl)
                _combination.Append("Ctrl+");
            if (Model.WithShift)
                _combination.Append("Shift+");
            if (Model.WithAlt) 
                _combination.Append("Alt+");
            if (Model.WithAltGr)
                _combination.Append("AltGr+");
            _combination.Append(Model.MainKey);
            Combination = _combination.ToString();
        }

        public XmlKeyCombination Clone()
        {
            return new XmlKeyCombination { Combination = Combination, Result = Result, Capital = Capital };
        }

        public KeyCombination ToModel()
        {
            var _model = new KeyCombination();
            _model.Result = Result;
            _model.Capital = Capital;
            var _combinationUpper = Combination.ToUpperInvariant();
                var _splitted = _combinationUpper.Split(new[] { '+' }, StringSplitOptions.RemoveEmptyEntries);
            if (_splitted.Length == 1)
                _model.MainKey = _splitted[0];
            else
            {
                foreach (var _part in _splitted)
                {
                    switch (_part)
                    {
                        case "ALT":
                            _model.WithAlt = true;
                            break;
                        case "ALTGR":
                            _model.WithAltGr = true;
                            break;
                        case "CTRL":
                            _model.WithCtrl = true;
                            break;
                        case "SHIFT":
                            _model.WithShift = true;
                            break;
                        default:
                            _model.MainKey = _part;
                            break;
                    }
                }
            }
            return _model;
        }
    }

    public class XmlKeyboardSummary : EquatableByID<int>, IDeepCloneable<XmlKeyboardSummary>
    {
        public override int ID
        {
            get; set;
        }

        public string FriendlyName { get; set; }

        public XmlKeyboardSummary Clone()
        {
            return new XmlKeyboardSummary { ID = ID, FriendlyName = FriendlyName };
        }

        internal KeyboardLayoutSummary ToModel()
        {
            return new KeyboardLayoutSummary { FriendlyName = FriendlyName, ID = ID };
        }
    }
}
