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
            dataGridView1.RowCount = nagr.Length;
            dataGridView1.ColumnCount = 10;

            for (int i = 0; i < nagr.Length; i++)
            {
                dataGridView1.Rows[i].Cells[0].Value = nagr[i].h.ToString();

                if (nagr[i].nt == 1)
                    dataGridView1.Rows[i].Cells[1].Value = Column2.Items[0];
                else if (nagr[i].nt == 2)
                    dataGridView1.Rows[i].Cells[1].Value = Column2.Items[1];
                else
                    dataGridView1.Rows[i].Cells[1].Value = Column2.Items[2];

                for (int k = 0; k < nagr[i].teachers.Length; k++)
                {
                    foreach (var teacher in data.teachers)
                    {
                        if (nagr[i].teachers[k] == teacher.Value.id)
                            dataGridView1.Rows[i].Cells[2].Value += teacher.Value.name.ToString() + " ";
                    }
                }

                for (int k = 0; k < nagr[i].sub_groups.Length; k++)
                {
                    foreach (var groups in data.sub_groups_info)
                    {
                        if (nagr[i].sub_groups[k] == groups.Value.id)
                            dataGridView1.Rows[i].Cells[4].Value += groups.Value.title + " ";
                    }
                }

                for (int k = 0; k < nagr[i].auds.Length; k++)
                {
                    foreach (var auditori in data.auditories)
                    {
                        if (nagr[i].auds[k] == auditori.Value.id)
                            dataGridView1.Rows[i].Cells[6].Value += auditori.Value.title + " ";
                    }
                }

                dataGridView1.Rows[i].Cells[8].Value = nagr[i].discipline.ToString();

                if (nagr[i].is_online == 1)
                    dataGridView1.Rows[i].Cells[9].Value = true;
                else
                    dataGridView1.Rows[i].Cells[9].Value = false;                
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
                    nagr[i].h = Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value);
                    if (dataGridView1.Rows[i].Cells[1].Value.Equals("Лекционное занятие"))
                        nagr[i].nt = 1;
                    else if (dataGridView1.Rows[i].Cells[1].Value.Equals("Практическое занятие"))
                        nagr[i].nt = 2;
                    else
                        nagr[i].nt = 3;

                    if (dataGridView1.Rows[i].Cells[2].Value != null)
                    {
                        for (int j = 0; j < dataGridView1.Rows[i].Cells[2].Value.ToString().Split().Length; j++)
                        {
                            if (dataGridView1.Rows[i].Cells[2].Value.ToString().Split()[j] != "")
                            {
                                foreach (var teacher in data.teachers)
                                {
                                    if (dataGridView1.Rows[i].Cells[2].Value.Equals(teacher.Value.name))
                                        nagr[i].teachers[j] = teacher.Value.id;
                                }
                            }
                            else break;
                        }
                    }


                    if (dataGridView1.Rows[i].Cells[4].Value != null)
                    {
                        for (int j = 0; j < dataGridView1.Rows[i].Cells[4].Value.ToString().Split().Length; j++)
                        {
                            if (dataGridView1.Rows[i].Cells[4].Value.ToString().Split()[j] != "")
                            {
                                foreach (var group in data.sub_groups_info)
                                {
                                    if (dataGridView1.Rows[i].Cells[4].Value.Equals(group.Value.title))
                                        nagr[i].sub_groups[j] = group.Value.id;
                                }
                            }
                            else break;
                        }
                    }

                    if (dataGridView1.Rows[i].Cells[6].Value != null)
                    {
                        for (int j = 0; j < dataGridView1.Rows[i].Cells[6].Value.ToString().Split().Length; j++)
                        {
                            if (dataGridView1.Rows[i].Cells[6].Value.ToString().Split()[j] != "")
                            {
                                foreach (var auditori in data.auditories)
                                {
                                    if (dataGridView1.Rows[i].Cells[6].Value.Equals(auditori.Value.title))
                                        nagr[i].auds[j] = auditori.Value.id;
                                }
                            }
                            else break;
                        }
                    }

                    nagr[i].discipline = (string)dataGridView1.Rows[i].Cells[8].Value;
                   
                    if (dataGridView1.Rows[i].Cells[9].Value.Equals(true))
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
                if (dataGridView1.Columns[e.ColumnIndex].Name== "Column9")
            {
                int type = 1; 
                ModalWindows teachers = new ModalWindows(type, this, e.RowIndex);
                teachers.Show();
            }

            if (dataGridView1.Columns[e.ColumnIndex].Name == "Column10")
            {
                int type = 2;
                ModalWindows groups = new ModalWindows(type, this, e.RowIndex);
                groups.Show();
            }

            if (dataGridView1.Columns[e.ColumnIndex].Name == "Column11")
            {
                int type = 3;
                ModalWindows auditorys = new ModalWindows(type, this, e.RowIndex);
                auditorys.Show();
            }
            }
        }

        private void Open_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
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
