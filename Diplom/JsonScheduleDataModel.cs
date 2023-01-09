﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{
    internal class JsonScheduleDataModel : ScheduleDataModel
    {
        public ScheduleRow[] nagruzka;
        public Dictionary<int, Teacher> teacher;
        public Dictionary<int, Auditory> auditory;
        public Dictionary<int, SubGroup> subGroup;


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
            Form1 f1 = new Form1();
            data.nagr = f1.nagr;
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

        public override ScheduleRow[] GetNagruzka()
        {
            nagruzka = data.nagr;

            return nagruzka;
        }
    }
}
