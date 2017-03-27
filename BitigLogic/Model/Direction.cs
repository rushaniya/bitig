using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using Bitig.Base;
using System.Collections.Specialized;
using System.Xml.Serialization;
using Bitig.Logic.Repository;

namespace Bitig.Logic.Model
{
    public class Direction : EquatableByID<int>, IDeepCloneable<Direction>
    {
        private int id = -1;

        public override int ID
        {
            get { return id; }
            set
            {
                id = value; 
            }
        }

      
        private TranslitCommand translitCommand;

        //private int sourceAlifbaID = -1;

        //public int SourceAlifbaID
        //{
        //    get { return sourceAlifbaID; }
        //    set { sourceAlifbaID = value; }
        //}

        //private int targetAlifbaID = -1;

        //public int TargetAlifbaID
        //{
        //    get { return targetAlifbaID; }
        //    set { targetAlifbaID = value; }
        //}

        //private int builtInID = -1;

        //public int BuiltInID
        //{
        //    get { return builtInID; }
        //    set
        //    {
        //        builtInID = value;
        //        translitCommand = null;
        //        friendlyName = null;
        //    }
        //}

            public Alifba Source { get; set; }

        public Alifba Target { get; set; }

        public BuiltInDirection BuiltIn { get; set; }

        private string friendlyName;
        [XmlIgnore]
        public string FriendlyName
        {
            get
            {
                return string.Format("{0} - {1}", Source.FriendlyName, Target.FriendlyName);
            }
        }

        public string AssemblyPath
        {
            get;
            set;
        }

        public string TypeName
        {
            get;
            set;
        }

        private bool exclusionsSet;

        public Direction(int ID, Alifba Source, Alifba Target, string AssemblyPath = null, string TypeName = null, BuiltInDirection BuiltIn = null)
        {
            this.AssemblyPath = AssemblyPath;
            this.TypeName = TypeName;
            this.id = ID;
            this.Source = Source;
            this.Target = Target;
            this.BuiltIn = BuiltIn;
        }

        public Direction()
        {
            
        }

        public bool IsBuiltIn()
        {
            if (Source == null || Target == null)
                throw new InvalidOperationException("Source or target alphabet is not defined.");
            return string.IsNullOrEmpty(AssemblyPath) && BuiltIn != null &&
                BuiltIn.ID == DefaultConfiguration.GetBuiltInID(Source.ID, Target.ID);
        }

        private void InitializeTranslitCommand()
        {
            if (IsBuiltIn() || string.IsNullOrEmpty(AssemblyPath)) 
            {
                translitCommand = DefaultConfiguration.GetTranslitCommand(BuiltIn.ID);
            }
            else
            {
                Assembly assembly = Assembly.LoadFrom(AssemblyPath);
                Type _t = assembly.GetType(TypeName);
                if (_t == null)
                    throw new InvalidOperationException(string.Format("Type {0} not found in assembly {1}", TypeName, AssemblyPath));
                translitCommand = (TranslitCommand)Activator.CreateInstance(_t);
            }
        }

        public string Transliterate(string Text)
        {
            if (translitCommand == null) InitializeTranslitCommand();
            if (!exclusionsSet && ExclusionManager.ReloadExclusions)
            {
                translitCommand.Exclusions = LoadExclusions();
                exclusionsSet = true;
            }
            return translitCommand.Convert(Text);
        }

              
        private ExclusionCollection LoadExclusions()
        {
            ExclusionCollection _resultDict = new ExclusionCollection();
            foreach (Exclusion _excl in ExclusionManager.GetExclusions(this.id))
            {
                _resultDict.Add(_excl.SourceWord, _excl.TargetWord, _excl.MatchCase, _excl.MatchBeginning, _excl.MatchMiddle);
            }
            return _resultDict;
        }

        //public string GetFriendlyName()
        //{
        //    string _friendlyName, _source, _target, _prefix;
        //    if (IsBuiltIn())
        //    {
        //        _source = DefaultConfiguration.GetBuiltInSourceID(BuiltIn.ID);
        //        _target = AlifbaManager.GetAlifbaNameByID(DirectionManager.GetBuiltInTargetID(BuiltInID));
        //        _prefix = "Built-in ";
        //    }
        //    else
        //    {
        //        _source = Source.FriendlyName;
        //        _target = Target.FriendlyName;
        //        _prefix = string.Empty;
        //    }
        //    if (string.IsNullOrEmpty(_source)) _source = "(none)"; //loc
        //    if (string.IsNullOrEmpty(_target)) _target = "(none)";
        //    _friendlyName = string.Format("{0}{1} - {2}", _prefix, _source, _target);
        //    return _friendlyName;
        //}

        public override string ToString()
        {
            return this.FriendlyName;
        }

        public Direction Clone()
        {
            //repo: clone BuiltIn?
            return new Direction(ID, Source.Clone(), Target.Clone(), AssemblyPath, TypeName, BuiltIn);
        }
    }
}
