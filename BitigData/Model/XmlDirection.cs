using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using Bitig.Base;
using System.Collections.Specialized;
using System.Xml.Serialization;
using Bitig.Logic;
using Bitig.Data.Storage;

namespace Bitig.Data.Model
{
    public class XmlDirection
    {
        private int id = -1;

        public int ID
        {
            get { return id; }
            set
            {
                if (DirectionSerializer.Deserializing) id = value; 
                else System.Diagnostics.Debug.Fail("Direction.ID set");
            }
        }

      
        private TranslitCommand translitCommand;

        private int sourceAlifbaID = -1;

        public int SourceAlifbaID
        {
            get { return sourceAlifbaID; }
            set { sourceAlifbaID = value; }
        }

        private int targetAlifbaID = -1;

        public int TargetAlifbaID
        {
            get { return targetAlifbaID; }
            set { targetAlifbaID = value; }
        }

        private int builtInID = -1;

        public int BuiltInID
        {
            get { return builtInID; }
            set
            {
                builtInID = value;
                translitCommand = null;
                friendlyName = null;
            }
        }

        private string friendlyName;
        [XmlIgnore]
        public string FriendlyName
        {
            get
            {
                if (string.IsNullOrEmpty(friendlyName))
                {
                    friendlyName = GetFriendlyName(this.isBuiltIn || string.IsNullOrEmpty(assemblyPath), this.builtInID, this.sourceAlifbaID, this.targetAlifbaID);
                }
                return friendlyName;
            }
        }

        private string assemblyPath;

        public string AssemblyPath
        {
            get { return assemblyPath; }
            set { assemblyPath = value; }
        }

        private string typeName;

        public string TypeName
        {
            get { return typeName; }
            set { typeName = value; }
        }

        private bool isBuiltIn;
        [XmlIgnore]
        public bool IsBuiltIn
        {
            get { return isBuiltIn; }
        }

        private bool exclusionsSet;

        //internal Direction(int DirectionID, int SourceID, int TargetID, string AssemblyPath, string TypeName, int BuiltInID)
        //{
        //    this.assemblyPath = AssemblyPath;
        //    this.typeName = TypeName;
        //    this.id = DirectionID;
        //    this.sourceAlifbaID = SourceID;
        //    this.targetAlifbaID = TargetID;
        //    this.builtInID = BuiltInID;
        //    this.isBuiltIn = string.IsNullOrEmpty(assemblyPath) && this.builtInID != -1 &&
        //        this.builtInID == DirectionManager.GetBuiltInID(sourceAlifbaID, targetAlifbaID);
        //}

        internal XmlDirection(int DirectionID)
        {
            this.id = DirectionID;
            SetIsBuiltIn();
        }

        public XmlDirection()
        {
            if (!DirectionSerializer.Deserializing)
                throw new InvalidOperationException("Direction instances cannot be created with default constructor.");
            SetIsBuiltIn();
        }

        //repo
        private void InitializeTranslitCommand()
        {
            //throw new NotImplementedException();
            //if (isBuiltIn || string.IsNullOrEmpty(assemblyPath)) 
            //{
            //    translitCommand = DirectionManager.GetTranslitCommand(this.builtInID);
            //}
            //else
            //{
            //    Assembly assembly = Assembly.LoadFrom(assemblyPath);
            //    Type _t = assembly.GetType(typeName);
            //    translitCommand = (TranslitCommand)Activator.CreateInstance(_t);//exc: ArgumentNullException if type does not exist
            //}
        }

        //repo
        public string Transliterate(string Text)
        {
            throw new NotImplementedException();
            //if (translitCommand == null) InitializeTranslitCommand();
            //if (!exclusionsSet && ExclusionManager.ReloadExclusions)
            //{
            //    translitCommand.Exclusions = LoadExclusions();
            //    exclusionsSet = true;
            //}
            //return translitCommand.Convert(Text);
        }

        //repo      
        private ExclusionCollection LoadExclusions()
        {
            throw new NotImplementedException();
            //ExclusionCollection _resultDict = new ExclusionCollection();
            //foreach (Exclusion _excl in ExclusionManager.GetExclusions(this.id))
            //{
            //    _resultDict.Add(_excl.SourceWord, _excl.TargetWord, _excl.MatchCase, _excl.MatchBeginning, _excl.MatchMiddle);
            //}
            //return _resultDict;
        }

        internal void AssignConfig(DirectionConfig ConfigObject)
        {
            this.sourceAlifbaID = ConfigObject.SourceID;
            this.targetAlifbaID = ConfigObject.TargetID;
            this.builtInID = ConfigObject.BuiltInID;
            this.assemblyPath = ConfigObject.AssemblyPath;
            this.typeName = ConfigObject.TypeName;
            this.friendlyName = null;
            this.translitCommand = null;
            this.isBuiltIn = ConfigObject.IsBuiltIn;
        }

        //repo 
        private void SetIsBuiltIn()
        {
            throw new NotImplementedException();
            //this.isBuiltIn = string.IsNullOrEmpty(assemblyPath) && this.builtInID != -1 &&
            //   this.builtInID == DirectionManager.GetBuiltInID(sourceAlifbaID, targetAlifbaID);
        }

        //repo 
        internal static string GetFriendlyName(bool IsBuiltIn, int BuiltInID, int SourceID, int TargetID)
        {
            throw new NotImplementedException();
            //string _friendlyName, _source, _target, _prefix;
            //if (IsBuiltIn)
            //{
            //    _source = AlifbaManager.GetAlifbaNameByID(DirectionManager.GetBuiltInSourceID(BuiltInID));
            //    _target = AlifbaManager.GetAlifbaNameByID(DirectionManager.GetBuiltInTargetID(BuiltInID));
            //    _prefix = "Built-in ";
            //}
            //else
            //{
            //    _source = AlifbaManager.GetAlifbaNameByID(SourceID);
            //    _target = AlifbaManager.GetAlifbaNameByID(TargetID);
            //    _prefix = string.Empty;
            //}
            //if (string.IsNullOrEmpty(_source)) _source = "(none)";
            //if (string.IsNullOrEmpty(_target)) _target = "(none)";
            //_friendlyName = string.Format("{0}{1} - {2}", _prefix, _source, _target);
            //return _friendlyName;
        }

        public override bool Equals(object obj)
        {
            XmlDirection _cast = obj as XmlDirection;
            if (_cast == null) return false;
            return _cast.id == this.id;
        }

        public override string ToString()
        {
            return this.FriendlyName;
        }
    }
}
