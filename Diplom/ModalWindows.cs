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

            GroupsDGV.ColumnCount = 3;
        }

        private void ReadAuditorys()
        {

            TeachersDGV.Visible = false;
            GroupsDGV.Visible = false;
            AuditorysDVG.Visible = true;

            AuditorysDVG.ColumnCount = 3;
        }

        private void Choice_Click(object sender, EventArgs e)
        {
            var g = data.nagr[row];

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
            this.Hide();

        }
    }
}
