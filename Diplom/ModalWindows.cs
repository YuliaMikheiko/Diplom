using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.Json;
using System.IO;

namespace WindowsFormsApp2
{
    public partial class ModalWindows : Form
    {
        int type;
        Data data;
        Form1 f1;
        int row;
        public ModalWindows(int a, Form1 f1, int row)
        {
            InitializeComponent();
            type = a;
            data = f1.data;
            this.f1 = f1;
            this.row = row;
            if (a == 1)
            {
                ReadTeachers();
            }
            else if (a == 2)
                ReadGroups();
            else
                ReadAuditorys();
        }

        private void ReadTeachers()
        {

            TeachersDGV.Visible = true;
            GroupsDGV.Visible = false;
            AuditorysDVG.Visible = false;

            TeachersDGV.RowCount = data.teachers.Count;
            TeachersDGV.ColumnCount = 3;
            var i = 0;
            foreach(var teacher in data.teachers)
            {
                
                TeachersDGV.Rows[i].Cells[1].Value = teacher.Value.id;
                TeachersDGV.Rows[i].Cells[2].Value = teacher.Value.name;
                for(int j = 0; j < data.nagr[row].teachers.Length; j++)
                {
                    if (data.nagr[row].teachers[j] == teacher.Value.id)
                    {
                        TeachersDGV.Rows[i].Cells[0].Value = true;
                    }
                }
                i++;
            }
            
        }

        private void ReadGroups()
        {
            TeachersDGV.Visible = false;
            GroupsDGV.Visible = true;
            AuditorysDVG.Visible = false;

            GroupsDGV.RowCount = data.sub_groups_info.Count;
            GroupsDGV.ColumnCount = 3;
            var i = 0;
            foreach (var groups in data.sub_groups_info)
            {
                GroupsDGV.Rows[i].Cells[1].Value = groups.Value.id;
                GroupsDGV.Rows[i].Cells[2].Value = groups.Value.title;
                for (int j = 0; j < data.nagr[row].sub_groups.Length; j++)
                {
                    if (data.nagr[row].sub_groups[j] == groups.Value.id)
                    {
                        GroupsDGV.Rows[i].Cells[0].Value = true;
                    }
                }
                i++;
            }
        }

        private void ReadAuditorys()
        {
            TeachersDGV.Visible = false;
            GroupsDGV.Visible = false;
            AuditorysDVG.Visible = true;

            AuditorysDVG.RowCount = data.auditories.Count;
            AuditorysDVG.ColumnCount = 3;
            var i = 0;
            foreach (var auditorys in data.auditories)
            {
                AuditorysDVG.Rows[i].Cells[1].Value = auditorys.Value.id;
                AuditorysDVG.Rows[i].Cells[2].Value = auditorys.Value.title;
                for (int j = 0; j < data.nagr[row].auds.Length; j++)
                {
                    if (data.nagr[row].auds[j] == auditorys.Value.id)
                    {
                        AuditorysDVG.Rows[i].Cells[0].Value = true;
                    }
                }
                i++;
            }
        }

        private void Choice_Click(object sender, EventArgs e)
        {
            if (type == 1)
            {
                List<int?> list = new List<int?>();
                foreach (DataGridViewRow rows in TeachersDGV.Rows)
                {
                    if (rows.Cells[0].Value != null)
                    {
                        if ((bool)rows.Cells[0].Value)
                        {
                            list.Add((int)rows.Cells[1].Value);
                        }
                    }
                    
                }
                if(list.Count > 0)
                {
                    data.nagr[row].teachers = list.ToArray();
                    var value = "";
                    foreach(var l in list)
                    {
                        value += l.ToString() + " ";
                    }
                    f1.dataGridView1.Rows[row].Cells[2].Value = value;
                }
            }

            if (type == 2)
            {
                List<int> list = new List<int>();
                foreach (DataGridViewRow rows in GroupsDGV.Rows)
                {
                    if (rows.Cells[0].Value != null)
                    {
                        if ((bool)rows.Cells[0].Value)
                        {
                            list.Add((int)rows.Cells[1].Value);
                        }
                    }

                }
                if (list.Count > 0)
                {
                    data.nagr[row].sub_groups = list.ToArray();
                    var value = "";
                    foreach (var l in list)
                    {
                        value += l.ToString() + " ";
                    }
                    f1.dataGridView1.Rows[row].Cells[4].Value = value;
                }
            }

            if (type == 3)
            {
                List<int?> list = new List<int?>();
                foreach (DataGridViewRow rows in AuditorysDVG.Rows)
                {
                    if (rows.Cells[0].Value != null)
                    {
                        if ((bool)rows.Cells[0].Value)
                        {
                            list.Add((int)rows.Cells[1].Value);
                        }
                    }
                }
                if (list.Count > 0)
                {
                    data.nagr[row].auds = list.ToArray();
                    var value = "";
                    foreach (var l in list)
                    {
                        value += l.ToString() + " ";
                    }
                    f1.dataGridView1.Rows[row].Cells[6].Value = value;
                }
            }

            this.Hide();
        }
    }
}
