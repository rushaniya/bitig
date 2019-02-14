using System;
using System.Collections.Generic;
using System.Reflection;
using Bitig.Base;
using Bitig.Logic.Commands;
using Bitig.Logic.Repository;

namespace Bitig.Logic.Model
{
    public class Direction : EquatableByID<int>
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

        public ManualCommand ManualCommand { get; set; }

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

        private List<Exclusion> exclusions;

        public List<Exclusion> Exclusions
        {
            get
            {
                return exclusions;
            }
            set
            {
                exclusions = value;
                if (translitCommand != null)
                    translitCommand.Exclusions = LoadExclusions();
            }
        }    

        public Direction(int ID, Alifba Source, Alifba Target, List<Exclusion> Exclusions, string AssemblyPath = null, string TypeName = null, BuiltInDirection BuiltIn = null, ManualCommand ManualCommand = null)
        {
            this.AssemblyPath = AssemblyPath;
            this.TypeName = TypeName;
            this.id = ID;
            this.Source = Source;
            this.Target = Target;
            this.BuiltIn = BuiltIn;
            this.Exclusions = Exclusions ?? new List<Exclusion>();
            this.ManualCommand = ManualCommand;
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
            if (ManualCommand == null)
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
            else
            {
               translitCommand = new ConfigurableTranslitCommand(ManualCommand.SymbolMapping);
            }
            translitCommand.Exclusions = LoadExclusions();
        }

        public string Transliterate(string Text)
        {
            if (translitCommand == null)
                InitializeTranslitCommand();
            return translitCommand.Convert(Text);
        }

        public bool IsValidExclusion(Exclusion Exclusion, out List<string> Errors, out List<string> Warnings)
        {
            if (translitCommand == null)
                InitializeTranslitCommand();
            return translitCommand.IsValidExclusion(Exclusion, out Errors, out Warnings);
        }


        private ExclusionCollection LoadExclusions()
        {
            ExclusionCollection _resultDict = new ExclusionCollection();
            foreach (Exclusion _excl in Exclusions)
            {
                _resultDict.Add(_excl.SourceWord, _excl.TargetWord, _excl.MatchCase, _excl.MatchBeginning, _excl.AnyPosition);
            }
            return _resultDict;
        }

        public string AssemblyFileName
        {
            get
            {
                // loc
                if (!string.IsNullOrEmpty(AssemblyPath))
                    return System.IO.Path.GetFileName(AssemblyPath);
                if (BuiltIn != null)
                    return ("(Built-in)");
                return "(Manual)";
            }
        }

        public override string ToString()
        {
            return FriendlyName;
        }
    }
}
