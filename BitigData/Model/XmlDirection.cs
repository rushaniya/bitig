using System;
using Bitig.Logic.Model;
using Bitig.Logic.Repository;

namespace Bitig.Data.Model
{
    public class XmlDirection : EquatableByID<int>, IDeepCloneable<XmlDirection>
    {
        public override int ID
        {
            get;
            set;
        }

        public int SourceAlphabetID
        {
            get;
            set;
        }

        public int TargetAlphabetID
        {
            get;
            set;
        }

        public BuiltInDirectionType BuiltInType
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

        public bool UseManualCommand { get; set; } 

        [Obsolete("For XML serialization only")]
        public XmlDirection()
        {
        }

        public XmlDirection(int ID, int SourceAlphabetID, int TargetAlphabetID, 
            string AssemblyPath = null, string TypeName = null, BuiltInDirectionType BuiltInID = BuiltInDirectionType.None,
            bool UseManualCommand = false)
        {
            this.AssemblyPath = AssemblyPath;
            this.BuiltInType = BuiltInID;
            this.ID = ID;
            this.SourceAlphabetID = SourceAlphabetID;
            this.TargetAlphabetID = TargetAlphabetID;
            this.TypeName = TypeName;
            this.UseManualCommand = UseManualCommand;
        }

        public XmlDirection(Direction ModelDirection)
        {
            if (ModelDirection.Source == null)
                throw new InvalidOperationException("Source alphabet is required.");//loc
            if (ModelDirection.Target == null)
                throw new InvalidOperationException("Target alphabet is required.");//loc

            ID = ModelDirection.ID;
            SourceAlphabetID = ModelDirection.Source.ID;
            TargetAlphabetID = ModelDirection.Target.ID;
            AssemblyPath = ModelDirection.AssemblyPath;
            TypeName = ModelDirection.TypeName;
            BuiltInType = ModelDirection.BuiltInType;
            UseManualCommand = ModelDirection.ManualCommand != null;
        }

        public XmlDirection Clone()
        {
            return new XmlDirection(ID, SourceAlphabetID, TargetAlphabetID, AssemblyPath, TypeName, BuiltInType, UseManualCommand);
        }
    }
}
