using System;
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

        public int BuiltInID
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

        public XmlDirection()
        {
            if (!DirectionSerializer.Deserializing)
                throw new InvalidOperationException("XmlDirection instances cannot be created with default constructor.");
            BuiltInID = -1;
        }

        public XmlDirection(int ID, int SourceAlifbaID, int TargetAlifbaID,
            string AssemblyPath = null, string TypeName = null, int BuiltInID = -1)
        {
            this.AssemblyPath = AssemblyPath;
            this.BuiltInID = BuiltInID;
            this.id = ID;
            this.SourceAlifbaID = SourceAlifbaID;
            this.TargetAlifbaID = TargetAlifbaID;
            this.TypeName = TypeName;
        }

        public override bool Equals(object obj)
        {
            XmlDirection _cast = obj as XmlDirection;
            if (_cast == null) return false;
            return _cast.id == this.id;
        }
    }
}
