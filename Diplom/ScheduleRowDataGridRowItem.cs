using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplom
{
    public class ScheduleRowDataGridRowItem
    {
        public ScheduleRow x;
        Dictionary<int, Teacher> DTeachers;
        Dictionary<int, Auditory> DAuditories;
        Dictionary<int, SubGroup> DSub_groups;

        public ScheduleRowDataGridRowItem(ScheduleRow x, Dictionary<int, Teacher> DTeachers, Dictionary<int, Auditory> DAuditories, Dictionary<int, SubGroup> DSub_groups)
        {
            this.x = x;
            this.DTeachers = DTeachers;
            this.DAuditories = DAuditories;
            this.DSub_groups = DSub_groups;
        }

        public int H { get; set; }
        public object NT { get; set; }
        public string Teachers
        {
            get
            {
                return String.Join(
                "; ",
                x.teachers
                .Where(y => y.HasValue && DTeachers.ContainsKey(y.Value))
                .Select(y => DTeachers[y.Value].name)
                );
            }
            set
            {
            }
        }
        public string Sub_groups
        {
            get
            {
                return String.Join(
                "; ",
                x.sub_groups
                .Where(y => y.HasValue && DSub_groups.ContainsKey(y.Value))
                .Select(y => DSub_groups[y.Value].title)
                );
            }
            set
            {
            }
        }
        public string Kurs
        {
            get
            {
                return String.Join(
                "; ",
                x.sub_groups
                .Where(y => y.HasValue && DSub_groups.ContainsKey(y.Value))
                .Select(y => DSub_groups[y.Value].kurs)
                );
            }
            set
            {
            }
        }
        public string Kaf { get; set; }
        public string Auds
        {
            get
            {
                return String.Join(
                "; ",
                x.auds
                .Where(y => y.HasValue && DAuditories.ContainsKey(y.Value))
                .Select(y => DAuditories[y.Value].title)
                );
            }
            set
            {

            }
        }
        public string Discipline { get; set; }
        public bool Is_online { get; set; }

        public override string ToString()
        {
            return $"{Teachers}%{Sub_groups}%{Auds}";
        }
    }
}
