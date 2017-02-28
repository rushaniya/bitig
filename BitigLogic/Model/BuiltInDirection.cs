using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bitig.Logic.Model
{
    public class BuiltInDirection
    {
        private int id = -1;

        public int ID
        {
            get { return id; }
            //set { id = value; }
        }

        private int sourceID = -1;

        public int SourceAlifbaID
        {
            get { return sourceID; }
            //set { sourceID = value; }
        }

        private int targetID = -1;

        public int TargetAlifbaID
        {
            get { return targetID; }
           // set { targetID = value; }
        }

        private bool isInUse;

        public bool IsInUse
        {
            get { return isInUse; }
            set { isInUse = value; }
        }

        private string friendlyName;

        //repo
        internal BuiltInDirection(int ID, int SourceID, int TargetID)
        {
            throw new NotImplementedException();
            //this.id = ID;
            //this.sourceID = SourceID;
            //this.targetID = TargetID;
            //string _source = AlifbaManager.GetAlifbaNameByID(this.sourceID);
            //string _target = AlifbaManager.GetAlifbaNameByID(this.targetID);
            //if (string.IsNullOrEmpty(_source)) _source = "(none)";
            //if (string.IsNullOrEmpty(_target)) _target = "(none)";
            //this.friendlyName = string.Format("Built-in {0} - {1}", _source, _target);
        }

        public override string ToString()
        {
            return friendlyName;
        }
    }
}
