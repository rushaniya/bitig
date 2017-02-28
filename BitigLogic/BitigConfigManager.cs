using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Bitig.Logic.Model;

namespace Bitig.Logic
{
    //repo: delete
    public class BitigConfigManager
    {
       

        /// <summary>
        /// Save changes to alphabets and directions
        /// </summary>
        public static void SaveChanges()
        {
            SaveDirectionConfigurations();
        }

        public static void DiscardChanges()
        {
            directionWrappers = null;
        }

        #region Directions

        public static List<Direction> Directions
        {
            get
            {
                return DirectionManager.DirectionsList;
            }
        }

        public static List<Alifba> GetTranslitTargets(int SourceID)
        {//repo
            List<Alifba> _list = new List<Alifba>();
            var _query = from _dir in DirectionManager.DirectionsList
                         where _dir.SourceAlifbaID == SourceID
                         select _dir.TargetAlifbaID;
            if (_query.Count() > 0)
            {
                foreach (int id in _query)
                {
                   // Alifba _alif = AlifbaManager.GetAlifbaByID(id);
                   // if (_alif != null) _list.Add(_alif);
                }
            }
            return _list;
        }

        internal static string GetAlifbaFriendlyName(int value)
        {
            throw new NotImplementedException();
        }

        private static List<DirectionConfig> directionWrappers;

        public static List<DirectionConfig> DirectionConfigurations
        {
            get
            {
                if (directionWrappers == null) FillDirectionWrappers();
                return directionWrappers;
            }
        }

        private static void FillDirectionWrappers()
        {
            directionWrappers = new List<DirectionConfig>();
            foreach (Direction _dir in DirectionManager.DirectionsList)
            {
                DirectionConfig _copy = new DirectionConfig(_dir);
                directionWrappers.Add(_copy);
            }
        }

        public static DirectionConfig GetDirectionConfig(int DirectionID)
        {
            if (directionWrappers == null) FillDirectionWrappers();
            return directionWrappers.Find(_wrapper => _wrapper.DirectionID == DirectionID);
        }

        private static void SaveDirectionConfigurations()
        {
            if (directionWrappers != null)
            {
                var _removed =
                    from _dir in DirectionManager.DirectionsList
                    where !directionWrappers.Exists(_wrapper => _wrapper.DirectionID == _dir.ID)
                    select _dir;
                foreach (Direction _dir in _removed.ToList())
                {
                    DirectionManager.DirectionsList.Remove(_dir);
                }
                foreach (DirectionConfig _wrapper in directionWrappers)
                {
                    Direction _dir = DirectionManager.GetDirectionByID(_wrapper.DirectionID);
                    if (_dir == null)
                    {
                        _dir = new Direction(_wrapper.DirectionID);
                        DirectionManager.DirectionsList.Add(_dir);
                    }
                      
                        _dir.AssignConfig(_wrapper);
                }
                //repo DirectionSerializer.SaveToFile(DirectionManager.DirectionsList);
                directionWrappers = null;
            }
        }

        public static DirectionConfig CreateDirectionConfig(int SourceID, int TargetID, string AssemblyPath, string TypeName, string DisplayedTypeName, int BuiltInID)
        {
            int _id = DirectionManager.GenerateNewDirectionID();
            if (_id == -1) return null;
            DirectionConfig _dir = new DirectionConfig(_id, SourceID, TargetID, AssemblyPath, TypeName, DisplayedTypeName, BuiltInID);
            if (directionWrappers == null) FillDirectionWrappers();
            directionWrappers.Add(_dir);
            return _dir;
        }

        public static void DeleteDirectionConfig(DirectionConfig DirectionWrapper)
        {
            if (directionWrappers == null) FillDirectionWrappers();
            directionWrappers.Remove(DirectionWrapper);
        }

        #endregion
    }
}
