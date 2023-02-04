using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Diplom
{
    public partial class WishWindow : Form
    {
        string text;
        Color color;
        List<int?> idList;

        Dictionary<int, Teacher> teachers;
        Dictionary<int, Auditory> auditories;
        Dictionary<int, SubGroup> sub_groups_info;

        internal WishWindow(int type, ScheduleDataModel scheduleDataModel, List<int?> idList)
        {
            InitializeComponent();

            this.idList = idList;

            teachers = scheduleDataModel.GetTeachers();
            auditories = scheduleDataModel.GetAuditories();
            sub_groups_info = scheduleDataModel.GetGroups();

            if (type == 0)
                WishTeacher();
            if (type == 1)
                WishGroups();
            if (type == 2)
                WishAuditorys();
        }

        public void WishTeacher()
        {
            int h = 0;
            foreach (var teacher in teachers)
            {
                foreach (var id in idList)
                {
                    if (teacher.Value.id == id)
                    {
                        Dictionary<String, Dictionary<String, Dictionary<String, int[]>>> wishesDay = teacher.Value.wishes;

                        if (wishesDay != null)
                        {
                            foreach (var wishDay in wishesDay)
                            {
                                int[] day = new int[7];

                                if (wishDay.Key != "all")
                                    day[0] = Int32.Parse(wishDay.Key) + 1;
                                else
                                    for (int o = 0; o < 7; o++)
                                        day[o] = o + 1;

                                Dictionary<String, Dictionary<String, int[]>> wishesPair = wishDay.Value;

                                foreach (var wishPair in wishesPair)
                                {
                                    int[] pair = new int[8];

                                    if (wishPair.Key != "all")
                                        pair[0] = Int32.Parse(wishPair.Key) + 1;
                                    else
                                        for (int o = 0; o < 8; o++)
                                            pair[o] = o + 1;

                                    Dictionary<String, int[]> wishesWeek = wishPair.Value;

                                    foreach (var wishWeek in wishesWeek)
                                    {
                                        int[] week = new int[2];

                                        if (wishWeek.Key != "all")
                                            week[0] = Int32.Parse(wishWeek.Key) + 1;
                                        else
                                            for (int o = 0; o < 2; o++)
                                                week[o] = o + 1;

                                        int r = wishWeek.Value[0];

                                        if (r == 1)
                                        {
                                            color = Color.LightGreen;
                                            text = "О";
                                        }
                                        else if (r == 11)
                                        {
                                            color = Color.LightCoral;
                                            text = "Д";
                                        }
                                        else if (r == 12)
                                        {
                                            color = Color.Turquoise;
                                            text = "И";
                                        }
                                        else if (r == 14)
                                        {
                                            color = Color.HotPink;
                                            text = "Ф";
                                        }
                                        else if (r == 15)
                                        {
                                            color = Color.CornflowerBlue;
                                            text = "С";
                                        }
                                        else if (r == 16)
                                        {
                                            color = Color.Plum;
                                            text = "К";
                                        }
                                        else if (r == 20)
                                        {
                                            color = Color.Gold;
                                            text = "В";
                                        }
                                        else
                                        {
                                            color = Color.PowderBlue;
                                            text = "";
                                        }

                                        for (int k = 0; k < day.Length; k++)
                                        {
                                            if (day[k] != 0)
                                            {
                                                for (int y = 0; y < pair.Length; y++)
                                                {
                                                    if (pair[y] != 0)
                                                    {
                                                        for (int f = 0; f < week.Length; f++)
                                                        {
                                                            if (week[f] != 0)
                                                            {
                                                                System.Windows.Forms.Label label = new System.Windows.Forms.Label
                                                                {
                                                                    Size = new Size(40, 35),
                                                                    TextAlign = ContentAlignment.MiddleCenter,
                                                                    BackColor = color,
                                                                    Text = text
                                                                };
                                                                label.Click += Label_Click;

                                                                if (week[f] % 2 == 1)
                                                                {
                                                                    tableLayoutPanel1.Controls.Add(label, day[k] * 2 - 2, pair[y] - 1);
                                                                    h++;
                                                                }
                                                                else
                                                                {
                                                                    tableLayoutPanel1.Controls.Add(label, day[k] * 2 - 1, pair[y] - 1);
                                                                    h++;
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }                        
                    }
                }
            }

            color = Color.PowderBlue;
            text = "";
            for (int i = 0; i < 112 - h; i++)
            {
                System.Windows.Forms.Label label2 = new System.Windows.Forms.Label
                {
                    Size = new Size(40, 35),
                    BackColor = color,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Text = text
                };
                label2.Click += Label_Click;

                tableLayoutPanel1.Controls.Add(label2);
            }
        }

        public void WishGroups()
        {
            int h = 0;
            foreach (var groups in sub_groups_info)
            {
                foreach (var id in idList)
                {
                    if (groups.Value.id == id)
                    {
                        Dictionary<String, Dictionary<String, Dictionary<String, int[]>>> wishesDay = groups.Value.wishes;

                        if (wishesDay != null)
                        {
                            foreach (var wishDay in wishesDay)
                            {
                                int[] day = new int[7];

                                if (wishDay.Key != "all")
                                    day[0] = Int32.Parse(wishDay.Key) + 1;
                                else
                                    for (int o = 0; o < 7; o++)
                                        day[o] = o + 1;

                                Dictionary<String, Dictionary<String, int[]>> wishesPair = wishDay.Value;

                                foreach (var wishPair in wishesPair)
                                {
                                    int[] pair = new int[8];

                                    if (wishPair.Key != "all")
                                        pair[0] = Int32.Parse(wishPair.Key) + 1;
                                    else
                                        for (int o = 0; o < 8; o++)
                                            pair[o] = o + 1;

                                    Dictionary<String, int[]> wishesWeek = wishPair.Value;

                                    foreach (var wishWeek in wishesWeek)
                                    {
                                        int[] week = new int[2];

                                        if (wishWeek.Key != "all")
                                            week[0] = Int32.Parse(wishWeek.Key) + 1;
                                        else
                                            for (int o = 0; o < 2; o++)
                                                week[o] = o + 1;

                                        int r = wishWeek.Value[0];

                                        if (r == 1)
                                        {
                                            color = Color.LightGreen;
                                            text = "О";
                                        }
                                        else if (r == 11)
                                        {
                                            color = Color.LightCoral;
                                            text = "Д";
                                        }
                                        else if (r == 12)
                                        {
                                            color = Color.Turquoise;
                                            text = "И";
                                        }
                                        else if (r == 14)
                                        {
                                            color = Color.HotPink;
                                            text = "Ф";
                                        }
                                        else if (r == 15)
                                        {
                                            color = Color.CornflowerBlue;
                                            text = "С";
                                        }
                                        else if (r == 16)
                                        {
                                            color = Color.Plum;
                                            text = "К";
                                        }
                                        else if (r == 20)
                                        {
                                            color = Color.Gold;
                                            text = "В";
                                        }
                                        else
                                        {
                                            color = Color.PowderBlue;
                                            text = "";
                                        }

                                        for (int k = 0; k < day.Length; k++)
                                        {
                                            if (day[k] != 0)
                                            {
                                                for (int y = 0; y < pair.Length; y++)
                                                {
                                                    if (pair[y] != 0)
                                                    {
                                                        for (int f = 0; f < week.Length; f++)
                                                        {
                                                            if (week[f] != 0)
                                                            {
                                                                System.Windows.Forms.Label label = new System.Windows.Forms.Label
                                                                {
                                                                    Size = new Size(40, 35),
                                                                    TextAlign = ContentAlignment.MiddleCenter,
                                                                    BackColor = color,
                                                                    Text = text
                                                                };
                                                                label.Click += Label_Click;

                                                                if (week[f] % 2 == 1)
                                                                {
                                                                    tableLayoutPanel1.Controls.Add(label, day[k] * 2 - 2, pair[y] - 1);
                                                                    h++;
                                                                }
                                                                else
                                                                {
                                                                    tableLayoutPanel1.Controls.Add(label, day[k] * 2 - 1, pair[y] - 1);
                                                                    h++;
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            color = Color.PowderBlue;
            text = "";
            for (int i = 0; i < 112 - h; i++)
            {
                System.Windows.Forms.Label label2 = new System.Windows.Forms.Label
                {
                    Size = new Size(40, 35),
                    BackColor = color,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Text = text
                };
                label2.Click += Label_Click;

                tableLayoutPanel1.Controls.Add(label2);
            }
        }

        public void WishAuditorys()
        {
            int h = 0;
            foreach (var auditori in auditories)
            {
                foreach (var id in idList)
                {
                    if (auditori.Value.id == id)
                    {
                        Dictionary<String, Dictionary<String, Dictionary<String, int[]>>> wishesDay = auditori.Value.wishes;

                        if (wishesDay != null)
                        {
                            foreach (var wishDay in wishesDay)
                            {
                                int[] day = new int[7];

                                if (wishDay.Key != "all")
                                    day[0] = Int32.Parse(wishDay.Key) + 1;
                                else
                                    for (int o = 0; o < 7; o++)
                                        day[o] = o + 1;

                                Dictionary<String, Dictionary<String, int[]>> wishesPair = wishDay.Value;

                                foreach (var wishPair in wishesPair)
                                {
                                    int[] pair = new int[8];

                                    if (wishPair.Key != "all")
                                        pair[0] = Int32.Parse(wishPair.Key) + 1;
                                    else
                                        for (int o = 0; o < 8; o++)
                                            pair[o] = o + 1;

                                    Dictionary<String, int[]> wishesWeek = wishPair.Value;

                                    foreach (var wishWeek in wishesWeek)
                                    {
                                        int[] week = new int[2];

                                        if (wishWeek.Key != "all")
                                            week[0] = Int32.Parse(wishWeek.Key) + 1;
                                        else
                                            for (int o = 0; o < 2; o++)
                                                week[o] = o + 1;

                                        int r = wishWeek.Value[0];

                                        if (r == 1)
                                        {
                                            color = Color.LightGreen;
                                            text = "О";
                                        }
                                        else if (r == 11)
                                        {
                                            color = Color.LightCoral;
                                            text = "Д";
                                        }
                                        else if (r == 12)
                                        {
                                            color = Color.Turquoise;
                                            text = "И";
                                        }
                                        else if (r == 14)
                                        {
                                            color = Color.HotPink;
                                            text = "Ф";
                                        }
                                        else if (r == 15)
                                        {
                                            color = Color.CornflowerBlue;
                                            text = "С";
                                        }
                                        else if (r == 16)
                                        {
                                            color = Color.Plum;
                                            text = "К";
                                        }
                                        else if (r == 20)
                                        {
                                            color = Color.Gold;
                                            text = "В";
                                        }
                                        else
                                        {
                                            color = Color.PowderBlue;
                                            text = "";
                                        }

                                        for (int k = 0; k < day.Length; k++)
                                        {
                                            if (day[k] != 0)
                                            {
                                                for (int y = 0; y < pair.Length; y++)
                                                {
                                                    if (pair[y] != 0)
                                                    {
                                                        for (int f = 0; f < week.Length; f++)
                                                        {
                                                            if (week[f] != 0)
                                                            {
                                                                System.Windows.Forms.Label label = new System.Windows.Forms.Label
                                                                {
                                                                    Size = new Size(40, 35),
                                                                    TextAlign = ContentAlignment.MiddleCenter,
                                                                    BackColor = color,
                                                                    Text = text
                                                                };
                                                                label.Click += Label_Click;

                                                                if (week[f] % 2 == 1)
                                                                {
                                                                    tableLayoutPanel1.Controls.Add(label, day[k] * 2 - 2, pair[y] - 1);
                                                                    h++;
                                                                }
                                                                else
                                                                {
                                                                    tableLayoutPanel1.Controls.Add(label, day[k] * 2 - 1, pair[y] - 1);
                                                                    h++;
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            color = Color.PowderBlue;
            text = "";
            for (int i = 0; i < 112 - h; i++)
            {
                System.Windows.Forms.Label label2 = new System.Windows.Forms.Label
                {
                    Size = new Size(40, 35),
                    BackColor = color,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Text = text
                };
                label2.Click += Label_Click;

                tableLayoutPanel1.Controls.Add(label2);
            }
        }

        private void Label_Click(object sender, EventArgs e)
        {
            if (text != null)
            {
                var label = sender as System.Windows.Forms.Label;
                label.Text = text;
                label.BackColor = color;
            }
        }

        private void Choice_Click(object sender, EventArgs e)
        {
            var button = sender as Button;
            text = button.Text;
            color = button.BackColor;
        }

        private void Accept_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void Release_MouseMove(object sender, MouseEventArgs e)
        {
            ToolTip toolTip = new ToolTip();
            toolTip.SetToolTip(sender as Button, "Освободить");
        }

        private void Kafedra_MouseMove(object sender, MouseEventArgs e)
        {
            ToolTip toolTip = new ToolTip();
            toolTip.SetToolTip(sender as Button, "Кафедра");
        }

        private void Sovet_MouseMove(object sender, MouseEventArgs e)
        {
            ToolTip toolTip = new ToolTip();
            toolTip.SetToolTip(sender as Button, "Совет");
        }

        private void Dovuzovskoye_MouseMove(object sender, MouseEventArgs e)
        {
            ToolTip toolTip = new ToolTip();
            toolTip.SetToolTip(sender as Button, "Довузовское образование");
        }

        private void Voyennaya_MouseMove(object sender, MouseEventArgs e)
        {
            ToolTip toolTip = new ToolTip();
            toolTip.SetToolTip(sender as Button, "Военная кафедра");
        }

        private void Language_MouseMove(object sender, MouseEventArgs e)
        {
            ToolTip toolTip = new ToolTip();
            toolTip.SetToolTip(sender as Button, "Иностранный язык");
        }

        private void PhysicalCulture_MouseMove(object sender, MouseEventArgs e)
        {
            ToolTip toolTip = new ToolTip();
            toolTip.SetToolTip(sender as Button, "Физическая культура");
        }

        private void Empty_MouseMove(object sender, MouseEventArgs e)
        {
            ToolTip toolTip = new ToolTip();
            toolTip.SetToolTip(sender as Button, "Пусто");
        }
    }
}
