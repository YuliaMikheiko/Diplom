using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{
    internal class JsonScheduleDataModel : ScheduleDataModel
    {
        string _filePath = "";
        public Data data { get; set; }

        public JsonScheduleDataModel(string filePath)
        {
            this._filePath = filePath;
        }

        public virtual void Load()
        {
            this.data = JsonSerializer.Deserialize<Data>(File.ReadAllText(this._filePath));
        }


        public virtual void Save()
        {
            var jsonTextData = JsonSerializer.Serialize(data);
            File.WriteAllText(this._filePath, jsonTextData);
        }

        // ну и все остальные методы переопределяешь чтобы они данные отдавали
    }
}
