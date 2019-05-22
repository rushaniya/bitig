using System;
using System.Text;
using Bitig.Base;
using Bitig.KeyboardManagement;
using Bitig.Logic.Repository;

namespace Bitig.Data.Model
{
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
            _combination.Append(KeysParser.ConvertKeysToString(Model.MainKey));
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
            var _keyStroke = KeysParser.ParseKeyStroke(Combination);
            _model.MainKey = _keyStroke.MainKey;
            _model.WithAlt = _keyStroke.WithAlt;
            _model.WithAltGr = _keyStroke.WithAltGr;
            _model.WithCtrl = _keyStroke.WithCtrl;
            _model.WithShift = _keyStroke.WithShift;
            return _model;
        }
    }    
   
}
