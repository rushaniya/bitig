using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bitig.Logic.Model;

namespace Bitig.Logic
{
    //repo: remove
    /// <summary>
    /// Class that represents transliteration direction settings editable by user
    /// </summary>
    public class DirectionConfig
    {
        private int directionID = -1;

        public int DirectionID
        {
            get { return directionID; }
            //set { directionID = value; }
        }

        private int sourceID = -1;

        public int SourceID
        {
            get { return sourceID; }
            set
            {
                sourceID = value;
                sourceName = BitigConfigManager.GetAlifbaFriendlyName(value);
                isBuiltIn = null;
            }
        }

        private int targetID = -1;

        public int TargetID
        {
            get { return targetID; }
            set
            {
                targetID = value;
                targetName = BitigConfigManager.GetAlifbaFriendlyName(value);
                isBuiltIn = null;
            }
        }

        private string sourceName = string.Empty;

        public string SourceName
        {
            get { return sourceName; }
            //set { sourceName = value; }
        }

        private string targetName = string.Empty;

        public string TargetName
        {
            get { return targetName; }
            //set { targetName = value; }
        }

        private string assemblyPath = string.Empty;

        public string AssemblyPath
        {
            get { return assemblyPath; }
            set
            {
                assemblyPath = value;
                SetAssemblyFileName();
                isBuiltIn = null;
            }
        }

        private string assemblyFileName = string.Empty;

        public string AssemblyFileName
        {
            get { return assemblyFileName; }
        }

        private string typeName = string.Empty;

        public string TypeName
        {
            get { return typeName; }
            set { typeName = value; }
        }

        private string displayedTypeName;

        public string DisplayedTypeName
        {
            get { return displayedTypeName; }
            set { displayedTypeName = value; }
        }

        private int builtInID = -1;

        public int BuiltInID
        {
            get { return builtInID; }
            set
            {
                builtInID = value;
                isBuiltIn = null;
            }
        }

        private bool? isBuiltIn;

        public bool IsBuiltIn
        {
            get
            {
                if (isBuiltIn == null) SetIsBuiltIn();
                return isBuiltIn.Value;
            }
        }

        internal DirectionConfig(Direction DirectionObject)
        {
            this.directionID = DirectionObject.ID;
            this.sourceID = DirectionObject.SourceAlifbaID;
            this.targetID = DirectionObject.TargetAlifbaID;
            this.assemblyPath = DirectionObject.AssemblyPath ?? string.Empty;
            SetAssemblyFileName();
            this.isBuiltIn = DirectionObject.IsBuiltIn;
            this.builtInID = DirectionObject.BuiltInID;
            //repo this.sourceName = AlifbaManager.GetAlifbaNameByID(DirectionObject.SourceAlifbaID);
            //repo this.targetName = AlifbaManager.GetAlifbaNameByID(DirectionObject.TargetAlifbaID);
            this.typeName = DirectionObject.TypeName ?? string.Empty;
            if (isBuiltIn.Value) this.displayedTypeName = DirectionObject.FriendlyName;
            else this.displayedTypeName = typeName;
        }

        internal DirectionConfig(int DirectionID, int SourceID, int TargetID, string AssemblyPath, string TypeName, string DisplayedTypeName, int BuiltInDirectionID)
        {
            this.directionID = DirectionID;
            this.sourceID = SourceID;
            this.targetID = TargetID;
            this.assemblyPath = AssemblyPath ?? string.Empty;
            SetAssemblyFileName();
            this.sourceName = BitigConfigManager.GetAlifbaFriendlyName(SourceID);
            this.targetName = BitigConfigManager.GetAlifbaFriendlyName(TargetID);
            this.builtInID = BuiltInDirectionID;
            SetIsBuiltIn();
            this.typeName = TypeName ?? string.Empty;
            this.displayedTypeName = DisplayedTypeName;
        }

        private void SetAssemblyFileName()
        {
            if (string.IsNullOrEmpty(assemblyPath)) assemblyFileName = "(Built-in)"; // loc
            else assemblyFileName = System.IO.Path.GetFileName(assemblyPath);
        }

        public Direction GetDirectionObject()
        {
            return DirectionManager.DirectionsList.Find(_dir => _dir.ID == this.directionID);
        }

        public BuiltInDirection GetBuiltInDirectionObject()
        {
            return DirectionManager.BuiltInDirections.Find(_dir => _dir.ID == this.builtInID);
        }

        public override bool Equals(object obj)
        {
            DirectionConfig _cast = obj as DirectionConfig;
            if (_cast == null) return false;
            return _cast.directionID == this.directionID;
        }

        private void SetIsBuiltIn()
        {
            this.isBuiltIn = string.IsNullOrEmpty(this.assemblyPath) && this.builtInID != -1 &&
                DirectionManager.GetBuiltInID(this.sourceID, this.targetID) == this.builtInID;
        }
    }
}
