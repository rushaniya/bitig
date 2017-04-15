using System;
using System.Collections.Generic;
using System.Reflection;
using Bitig.Base;
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

        public TranslitCommand TranslitCommand
        {
            get
            {
                if (translitCommand == null)
                    InitializeTranslitCommand();
                return translitCommand;
            }
        }

        public Alifba Source { get; set; }

        public Alifba Target { get; set; }

        public BuiltInDirection BuiltIn { get; set; }

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

        public List<Exclusion> Exclusions { get; set; }

        private bool exclusionsSet;

        public Direction(int ID, Alifba Source, Alifba Target, List<Exclusion> Exclusions, string AssemblyPath = null, string TypeName = null, BuiltInDirection BuiltIn = null)
        {
            this.AssemblyPath = AssemblyPath;
            this.TypeName = TypeName;
            this.id = ID;
            this.Source = Source;
            this.Target = Target;
            this.BuiltIn = BuiltIn;
            this.Exclusions = Exclusions;
        }

        public bool IsBuiltIn()
        {
            if (Source == null || Target == null)
                throw new InvalidOperationException("Source or target alphabet is not defined.");
            return string.IsNullOrEmpty(AssemblyPath) && BuiltIn != null &&
                BuiltIn.ID == DefaultConfiguration.GetBuiltInID(Source.BuiltIn, Target.BuiltIn);
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
            translitCommand.Exclusions = LoadExclusions();
        }

        public string Transliterate(string Text)
        {
            if (translitCommand == null)
                InitializeTranslitCommand();
            return translitCommand.Convert(Text);
        }

              
        private ExclusionCollection LoadExclusions()
        {
            ExclusionCollection _resultDict = new ExclusionCollection();
            if (Exclusions != null)
            {
                foreach (Exclusion _excl in Exclusions)
                {
                    _resultDict.Add(_excl.SourceWord, _excl.TargetWord, _excl.MatchCase, _excl.MatchBeginning, _excl.AnyPosition);
                }
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

        public string AssemblyFileName
        {
            get
            {
                if (string.IsNullOrEmpty(AssemblyPath))
                    return "(Built-in)"; // loc
                return System.IO.Path.GetFileName(AssemblyPath);
            }
        }

        public override string ToString()
        {
            return this.FriendlyName;
        }

        public Direction Clone()
        {
            var _exclusions = new List<Exclusion>();
            if (Exclusions != null)
            {
                foreach (var _item in Exclusions)
                {
                    _exclusions.Add(_item.Clone());
                }
            }
            //repo: clone BuiltIn?
            return new Direction(ID, Source.Clone(), Target.Clone(), _exclusions, AssemblyPath, TypeName, BuiltIn);
        }
    }
}
