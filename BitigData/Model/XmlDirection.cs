using System;
using System.Collections.Generic;
using Bitig.Data.Storage;
using Bitig.Logic.Model;

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
                else System.Diagnostics.Debug.Fail("XmlDirection.ID set");
            }
        }

        public int SourceAlifbaID
        {
            get;
            set;
        }

        public int TargetAlifbaID
        {
            get;
            set;
        }

        public BuiltInDirectionType BuiltInID
        {
            get;
            set;
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

        public List<XmlExclusion> Exclusions { get; set; }

        public XmlDirection()
        {
            if (!DirectionSerializer.Deserializing)
                throw new InvalidOperationException("XmlDirection instances cannot be created with default constructor.");            
        }

        public XmlDirection(int ID, int SourceAlifbaID, int TargetAlifbaID, List<XmlExclusion> Exclusions,
            string AssemblyPath = null, string TypeName = null, BuiltInDirectionType BuiltInID = BuiltInDirectionType.None)
        {
            this.AssemblyPath = AssemblyPath;
            this.BuiltInID = BuiltInID;
            this.id = ID;
            this.SourceAlifbaID = SourceAlifbaID;
            this.TargetAlifbaID = TargetAlifbaID;
            this.TypeName = TypeName;
            this.Exclusions = Exclusions;
        }

        public override bool Equals(object obj)
        {
            XmlDirection _cast = obj as XmlDirection;
            if (_cast == null) return false;
            return _cast.id == this.id;
        }
    }
}
