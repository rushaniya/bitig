using System;
using System.Collections.Generic;
using Bitig.Data.Storage;
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

        public bool UseManualCommand { get; set; } //custom: when false, ManualCommand property is ignored

        public XmlManualCommand ManualCommand { get; set; }

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
            this.ID = ID;
            this.SourceAlifbaID = SourceAlifbaID;
            this.TargetAlifbaID = TargetAlifbaID;
            this.TypeName = TypeName;
            this.Exclusions = Exclusions;
        }

        public XmlDirection(Direction ModelDirection)
        {
            if (ModelDirection.Source == null)
                throw new InvalidOperationException("Source alphabet is required.");//loc
            if (ModelDirection.Target == null)
                throw new InvalidOperationException("Target alphabet is required.");//loc

            var _builtInID = ModelDirection.BuiltIn == null ? BuiltInDirectionType.None :
                ModelDirection.BuiltIn.ID;

            var _exclusions = new List<XmlExclusion>();
            if (ModelDirection.Exclusions != null)
                ModelDirection.Exclusions.ForEach(_excl => _exclusions.Add(new XmlExclusion(_excl)));


            ID = ModelDirection.ID;
            SourceAlifbaID = ModelDirection.Source.ID;
            TargetAlifbaID = ModelDirection.Target.ID;
            AssemblyPath = ModelDirection.AssemblyPath;
            TypeName = ModelDirection.TypeName;
            BuiltInID = _builtInID;
            Exclusions = _exclusions;
            
        }

        public override bool Equals(object obj)
        {
            XmlDirection _cast = obj as XmlDirection;
            if (_cast == null) return false;
            return _cast.ID == ID;
        }

        public XmlDirection Clone()
        {
            var _exclusions = new List<XmlExclusion>();
            if (Exclusions != null)
            {
                foreach (var _item in Exclusions)
                {
                    _exclusions.Add(_item.Clone());
                }
            }
            return new XmlDirection(ID, SourceAlifbaID, TargetAlifbaID, _exclusions, AssemblyPath, TypeName, BuiltInID);
        }
    }
}
