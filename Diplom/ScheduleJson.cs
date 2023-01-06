using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{
    public static class Utils
    {
        public static T[] Populate<T>(this T[] array, Func<T> provider)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = provider();
            }
            return array;
        }

        public static T[,,] Populate<T>(this T[,,] array, Func<T> provider)
        {
            for (int i = 0; i < array.GetLength(0); i++)
                for (int j = 0; j < array.GetLength(1); j++)
                    for (int k = 0; k < array.GetLength(2); k++)
                        array[i, j, k] = provider();
            return array;
        }

        public static String ArrayToString<T>(T[] array)
        {
            return $"[{String.Join(", ", array)}]";
        }
    }

    public class ScheduleRow
    {
        public int id { get; set; }
        public int h { get; set; }
        public int nt { get; set; }
        public int?[] auds { get; set; }
        [JsonPropertyName("preps")] public int?[] teachers { get; set; }
        [JsonPropertyName("sub-groups")] public int[] sub_groups { get; set; }
        public int[] fac { get; set; }
        public String[] owners { get; set; }
        public int smena { get; set; }
        public int students { get; set; }
        public bool semi_week { get; set; }
        public string discipline { get; set; }
        public int kurs { get; set; }
        public string kaf { get; set; }
        public int pairs_count { get; set; }
        public string verbose_konts { get; set; }
        public bool in_list { get; set; }
        public int? nagr_list { get; set; }
        public bool? set_in_one_aud { get; set; }
        public int is_online { get; set; }
        public bool is_zaoch { get; set; }
        public int afobuch { get; set; }

        [JsonIgnore] public ScheduleRow[] relatedItems;

        // [JsonIgnore]
        // public int real_id = -1;
        // [JsonIgnore]
        // public int complexity = 0;
        [JsonIgnore] public int hSet = 0; // сколько часов поставленно
        // [JsonIgnore]
        // public Object schedule = null;

        public override string ToString()
        {
            return $@"{{
    {nameof(id)}: {id},
    {nameof(h)}: {h},
    {nameof(nt)}: {nt},
    {nameof(auds)}: {Utils.ArrayToString(auds)},
    {nameof(teachers)}: {Utils.ArrayToString(teachers)},
    {nameof(sub_groups)}: {Utils.ArrayToString(sub_groups)},
    {nameof(fac)}: {Utils.ArrayToString(fac)},
    {nameof(owners)}: {Utils.ArrayToString(owners)},
    {nameof(smena)}: {smena},
    {nameof(students)}: {students},
    {nameof(semi_week)}: {semi_week},
    {nameof(discipline)}: {discipline},
    {nameof(kurs)}: {kurs},
    {nameof(kaf)}: {kaf},
    {nameof(pairs_count)}: {pairs_count},
    {nameof(verbose_konts)}: {verbose_konts},
    {nameof(in_list)}: {in_list},
    {nameof(nagr_list)}: {nagr_list},
    {nameof(set_in_one_aud)}: {set_in_one_aud},
    {nameof(is_online)}: {is_online},
    {nameof(is_zaoch)}: {is_zaoch},
    {nameof(afobuch)}: {afobuch}
}}";
        }
    }

    public interface IHasTitle
    {
        String GetTitle();
    }

    public interface IHasId
    {
        int GetId();
    }

    public class WishItems : Dictionary<String, Dictionary<String, Dictionary<String, int[]>>>
    {
        public int[] this[int day, int pair, int week]
        {
            get
            {
                String key = null;
                if (this.ContainsKey(day.ToString()))
                    key = day.ToString();
                else if (this.ContainsKey("all"))
                    key = "all";

                if (key == null)
                    return null;

                var dayWish = this[key];
                key = null;
                if (dayWish.ContainsKey(pair.ToString()))
                    key = pair.ToString();
                else if (dayWish.ContainsKey("all"))
                    key = "all";

                if (key == null)
                    return null;

                var pairWish = dayWish[key];
                key = null;
                if (pairWish.ContainsKey(week.ToString()))
                    key = week.ToString();
                else if (pairWish.ContainsKey("all"))
                    key = "all";

                if (key == null)
                    return null;

                return pairWish[key];
            }
        }
    }

    public class WishMixin
    {
        public WishItems wishes { get; set; }
    }

    public class SubGroup : WishMixin, IHasId, IHasTitle
    {
        public int id { get; set; }
        public int students { get; set; }
        public int smena { get; set; }
        public bool is_zaoch { get; set; }
        public int fac { get; set; }
        public int kurs { get; set; }
        public String title { get; set; }
        public String owner { get; set; }

        public String TitleShort => title.Replace("(И,О)", "").Trim();

        public override string ToString()
        {
            return $"{nameof(id)}: {id}, {nameof(students)}: {students}, {nameof(smena)}: {smena}, {nameof(is_zaoch)}: {is_zaoch}, {nameof(fac)}: {fac}, {nameof(kurs)}: {kurs}, {nameof(title)}: {title}, {nameof(owner)}: {owner}";
        }

        public string GetTitle()
        {
            return this.title;
        }

        public int GetId()
        {
            return this.id;
        }
    }

    public class Auditory : WishMixin, IHasId, IHasTitle
    {
        public int id { get; set; }
        public String title { get; set; }
        public String korpus { get; set; }
        public String type { get; set; }
        public int maxstud { get; set; }

        public override string ToString()
        {
            return $"{nameof(id)}: {id}, {nameof(title)}: {title}, {nameof(korpus)}: {korpus}, {nameof(type)}: {type}, {nameof(maxstud)}: {maxstud}";
        }

        public string GetTitle()
        {
            return this.title;
        }

        public int GetId()
        {
            return this.id;
        }
    }

    public class Teacher : WishMixin, IHasId, IHasTitle
    {
        public int id { get; set; }
        public String name { get; set; }
        public String full_name { get; set; }

        public override string ToString()
        {
            return $"{nameof(id)}: {id}, {nameof(name)}: {name}, {nameof(full_name)}: {full_name}";
        }

        public string GetTitle()
        {
            return this.full_name;
        }

        public int GetId()
        {
            return this.id;
        }
    }

    public class Raspis
    {
        public int raspnagr_id { get; set; }
        public int day { get; set; }
        public int pair { get; set; }
        public int everyweek { get; set; }
        public int pair_count { get; set; }
        public int?[] auds { get; set; }

        public override string ToString()
        {
            return $"{nameof(raspnagr_id)}: {raspnagr_id}, {nameof(day)}: {day}, {nameof(pair)}: {pair}, {nameof(everyweek)}: {everyweek}, {nameof(pair_count)}: {pair_count}, {nameof(auds)}: {auds}";
        }
    }

    public class Data
    {
        public ScheduleRow[] nagr { get; set; }
        public Dictionary<int, int[]> zanlist { get; set; }
        public Dictionary<int, SubGroup> sub_groups_info { get; set; }
        public Dictionary<int, Auditory> auditories { get; set; }
        public Dictionary<int, Teacher> teachers { get; set; }
        public JsonElement raspis { get; set; }
        public JsonElement classifier { get; set; }
    }
}
