using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bitig.Logic.Model;
using Bitig.Logic.Repository;

namespace Bitig.UI.ViewModel
{
    public static class DirectionExtensions
    {
        public static string GetFriendlyName(this Direction Direction, IRepository<Alifba, int> AlifbaRepository)
        {
            string _friendlyName, _source, _target, _prefix;
            if (Direction.IsBuiltIn())
            {
                _source = AlifbaRepository.Get(DefaultConfiguration.GetBuiltInSourceID(Direction.BuiltIn.ID)).FriendlyName;
                _target = AlifbaRepository.Get(DefaultConfiguration.GetBuiltInTargetID(Direction.BuiltIn.ID)).FriendlyName;
                _prefix = "Built-in ";
            }
            else
            {
                _source = Direction.Source.FriendlyName;
                _target = Direction.Target.FriendlyName;
                _prefix = string.Empty;
            }
            if (string.IsNullOrEmpty(_source)) _source = "(none)"; //loc
            if (string.IsNullOrEmpty(_target)) _target = "(none)";
            _friendlyName = string.Format("{0}{1} - {2}", _prefix, _source, _target);
            return _friendlyName;
        }

        public static string GetAssemblyFileName(this Direction Direction)
        {
            if (string.IsNullOrEmpty(Direction.AssemblyPath))
                return "(Built-in)"; // loc
            return System.IO.Path.GetFileName(Direction.AssemblyPath);
        }
    }
}
