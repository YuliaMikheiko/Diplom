using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        string path;
        public Data data { get; set; }
        public Form1()
        {
            InitializeComponent();
        }

        private void ReadData()
        {
            data = JsonSerializer.Deserialize<Data>(File.ReadAllText(path));
            var nagr = data.nagr;
            InformationDGV.RowCount = nagr.Length;
            InformationDGV.ColumnCount = 10;

            for (int i = 0; i < nagr.Length; i++)
            {
                InformationDGV.Rows[i].Cells[0].Value = nagr[i].h.ToString();

                if (nagr[i].nt == 1)
                    InformationDGV.Rows[i].Cells[1].Value = NtColumn.Items[0];
                else if (nagr[i].nt == 2)
                    InformationDGV.Rows[i].Cells[1].Value = NtColumn.Items[1];
                else
                    InformationDGV.Rows[i].Cells[1].Value = NtColumn.Items[2];

                for (int k = 0; k < nagr[i].teachers.Length; k++)
                {
                    foreach (var teacher in data.teachers)
                    {
                        if (nagr[i].teachers[k] == teacher.Value.id)
                            InformationDGV.Rows[i].Cells[2].Value += teacher.Value.name.ToString() + " ";
                    }
                }

                for (int k = 0; k < nagr[i].sub_groups.Length; k++)
                {
                    foreach (var groups in data.sub_groups_info)
                    {
                        if (nagr[i].sub_groups[k] == groups.Value.id)
                            InformationDGV.Rows[i].Cells[4].Value += groups.Value.title + " ";
                    }
                }

                for (int k = 0; k < nagr[i].auds.Length; k++)
                {
                    foreach (var auditori in data.auditories)
                    {
                        if (nagr[i].auds[k] == auditori.Value.id)
                            InformationDGV.Rows[i].Cells[6].Value += auditori.Value.title + " ";
                    }
                }

                InformationDGV.Rows[i].Cells[8].Value = nagr[i].discipline.ToString();

                if (nagr[i].is_online == 1)
                    InformationDGV.Rows[i].Cells[9].Value = true;
                else
                    InformationDGV.Rows[i].Cells[9].Value = false;                
            }
        }

        private void SaveData()
        {
            if (path == null)
            {
                MessageBox.Show(
                "Откройте файл",
                "Сообщение",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            }
            else
            {
                var nagr = data.nagr;

                for (int i = 0; i < nagr.Length; i++)
                {
                    nagr[i].h = Convert.ToInt32(InformationDGV.Rows[i].Cells[0].Value);
                    if (InformationDGV.Rows[i].Cells[1].Value.Equals("Лекционное занятие"))
                        nagr[i].nt = 1;
                    else if (InformationDGV.Rows[i].Cells[1].Value.Equals("Практическое занятие"))
                        nagr[i].nt = 2;
                    else
                        nagr[i].nt = 3;

                    nagr[i].discipline = (string)InformationDGV.Rows[i].Cells[8].Value;
                   
                    if (InformationDGV.Rows[i].Cells[9].Value.Equals(true))
                        nagr[i].is_online = 1;
                    else
                        nagr[i].is_online = 0;
                }

                var jsonTextData = JsonSerializer.Serialize(data);
                File.WriteAllText("base_data_out.schjson", jsonTextData);

                MessageBox.Show(
                "Сохранено",
                "Сообщение",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (path == null)
            {
                MessageBox.Show(
                "Откройте файл",
                "Сообщение",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            }
            else
            {
                if (InformationDGV.Columns[e.ColumnIndex].Name == "TColumn")
                {
                    int type = 1;
                    ModalWindows teachers = new ModalWindows(type, this, e.RowIndex);
                    teachers.Show();
                }

                if (InformationDGV.Columns[e.ColumnIndex].Name == "GColumn")
                {
                    int type = 2;
                    ModalWindows groups = new ModalWindows(type, this, e.RowIndex);
                    groups.Show();
                }

                if (InformationDGV.Columns[e.ColumnIndex].Name == "AColumn")
                {
                    int type = 3;
                    ModalWindows auditorys = new ModalWindows(type, this, e.RowIndex);
                    auditorys.Show();
                }
            }
        }

        private void Open_Click(object sender, EventArgs e)
        {
            InformationDGV.Rows.Clear();
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.Cancel)
                return;
            path = openFileDialog.FileName;

            ReadData();
        }

        private void Save_Click(object sender, EventArgs e)
        {
            SaveData();
        }
    }
}
