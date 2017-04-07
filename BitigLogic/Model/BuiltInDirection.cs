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
        }

        public Alifba Source { get; private set; }

        public Alifba Target { get; private set; }

        private string friendlyName;

        //repo
        internal BuiltInDirection(int ID, Alifba Source, Alifba Target)
        {
            this.id = ID;
            this.Source = Source;
            this.Target = Target;
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
