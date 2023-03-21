using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Diplom
{
    internal class JsonScheduleDataModel : ScheduleDataModel
    {
        private ScheduleRow[] _nagruzka;
        public ScheduleRow[] nagruzka
        {
            set
            {
                _nagruzka = value;
                data.nagr = value;
            }
            get
            {
                return _nagruzka;
            }
        }
        private Dictionary<int, Teacher> _teacher;
        public Dictionary<int, Teacher> teacher
        {
            set
            {
                _teacher = value;
                data.teachers = value;
            }
            get
            {
                return _teacher;
            }
        }

        public Dictionary<int, Auditory> auditory;
        public Dictionary<int, SubGroup> subGroup;
        public Dictionary<int, int[]> zanlist;

        string _filePath = "";
        public Data data { get; set; }

        public JsonScheduleDataModel(string filePath)
        {
            this._filePath = filePath;
        }

        public override void Load() 
        {
            this.data = JsonSerializer.Deserialize<Data>(File.ReadAllText(this._filePath));
        }

        public override void Save()
        {
            var jsonTextData = JsonSerializer.Serialize(data);
            File.WriteAllText(this._filePath, jsonTextData);
        }

        public override Dictionary<int, Teacher> GetTeachers()
        {
            teacher = data.teachers;
            return teacher;
        }

        public override Dictionary<int, Auditory> GetAuditories()
        {
            auditory = data.auditories;
            return auditory;
        }

        public override Dictionary<int, SubGroup> GetGroups()
        {
            subGroup = data.sub_groups_info;
            return subGroup;
        }

        public override Dictionary<int, int[]> GetZanlist()
        {
            zanlist = data.zanlist;
            return zanlist;
        }

        public override ScheduleRow[] GetNagruzka()
        {
            nagruzka = data.nagr;
            return nagruzka;
        }
    }
}
