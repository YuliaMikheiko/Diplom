using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Diplom
{
    internal class ScheduleDataModel
    {
        public virtual void Load() 
        {
            throw new NotImplementedException();
        }

        public virtual void Save()
        {
            throw new NotImplementedException();
        }

        public virtual Dictionary<int, Teacher> GetTeachers()
        {
            throw new NotImplementedException();
        }

        public virtual Dictionary<int, Auditory> GetAuditories()
        {
            throw new NotImplementedException();
        }

        public virtual Dictionary<int, SubGroup> GetGroups()
        {
            throw new NotImplementedException();
        }

        public virtual ScheduleRow[] GetNagruzka()
        {
            throw new NotImplementedException();
        }
    }
}
