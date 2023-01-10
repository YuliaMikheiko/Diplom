using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        private ScheduleDataModel activeScheduleDataModel;
        public ScheduleRow[] nagr;
        string path;
        Dictionary<int, Teacher> DTeachers;
        Dictionary<int, Auditory> DAuditories;
        Dictionary<int, SubGroup> DSub_groups;

        public Form1()
        {
            InitializeComponent();

            DataGridViewColumn HColumn = new DataGridViewTextBoxColumn();
            DataGridViewColumn NtColumn = new DataGridViewComboBoxColumn();
            DataGridViewColumn TeachersColumn = new DataGridViewTextBoxColumn();
            DataGridViewColumn GroupsColumn = new DataGridViewTextBoxColumn();
            DataGridViewColumn AuditoriesColumn = new DataGridViewTextBoxColumn();
            DataGridViewColumn DisciplineColumn = new DataGridViewTextBoxColumn();
            DataGridViewColumn OnlineColumn = new DataGridViewCheckBoxColumn();

            HColumn.DataPropertyName = "H";
            NtColumn.DataPropertyName = "NT";
            TeachersColumn.DataPropertyName = "Teachers";
            GroupsColumn.DataPropertyName = "Sub_groups";
            AuditoriesColumn.DataPropertyName = "Auds";
            DisciplineColumn.DataPropertyName = "Discipline";
            OnlineColumn.DataPropertyName = "Is_online";

            path = Properties.Settings.Default.path.ToString();

            if (path.Length > 0)
                ReadData();
        }

        private void ReadData()
        {
            activeScheduleDataModel = new JsonScheduleDataModel(path);
            activeScheduleDataModel.Load();
            nagr = activeScheduleDataModel.GetNagruzka();
            DTeachers = activeScheduleDataModel.GetTeachers();
            DAuditories = activeScheduleDataModel.GetAuditories();
            DSub_groups = activeScheduleDataModel.GetGroups();

            InformationDGV.DataSource = nagr.Select(x => new ScheduleRowDataGridRowItem
            {
                H = x.h,
                NT = NtColumn.Items[x.nt - 1],
                Teachers = String.Join(
                ", ",
                x.teachers
                .Where(y => y.HasValue && DTeachers.ContainsKey(y.Value))
                .Select(y => DTeachers[y.Value].name)
                ),

                Sub_groups = String.Join(
                ", ",
                x.sub_groups
                .Where(y => y.HasValue && DSub_groups.ContainsKey(y.Value))
                .Select(y => DSub_groups[y.Value].title)
                ),

                Auds = String.Join(
                ", ",
                x.auds
                .Where(y => y.HasValue && DAuditories.ContainsKey(y.Value))
                .Select(y => DAuditories[y.Value].title)
                ),

                Discipline = x.discipline,
                Is_online = x.is_online.Equals(1),
            }).ToList();
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
                for (int i = 0; i < nagr.Length; i++)
                {
                    nagr[i].h = (int)InformationDGV.Rows[i].Cells[0].Value;

                    //nagr[i].nt = (int)InformationDGV.Rows[i].Cells[1].Value;
                   
                    nagr[i].discipline = (string)InformationDGV.Rows[i].Cells[8].Value;

                    if (InformationDGV.Rows[i].Cells[9].Value.Equals(true))
                        nagr[i].is_online = 1;
                    else
                        nagr[i].is_online = 0;
                }

                activeScheduleDataModel.Save();

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
                    ItemsSelectorModalWindow teachers = new ItemsSelectorModalWindow(type, nagr[e.RowIndex], activeScheduleDataModel);

                    if (teachers.ShowDialog() == DialogResult.OK)
                    {
                        List<int?> idsList = teachers.idsList;
                        List<string> TitleList = teachers.TitleList;
                        if (idsList.Count > 0)
                        {
                            nagr[e.RowIndex].teachers = idsList.ToArray();

                            var value = "";
                            foreach (var name in TitleList)
                            {
                                value += name + ", ";
                            }
                            InformationDGV.Rows[e.RowIndex].Cells[2].Value = value;
                        }
                        else
                        {
                            Array.Clear(nagr[e.RowIndex].teachers, 0, nagr[e.RowIndex].teachers.Length);
                            InformationDGV.Rows[e.RowIndex].Cells[2].Value = "";
                        }
                    }
                }

                if (InformationDGV.Columns[e.ColumnIndex].Name == "GColumn")
                {
                    int type = 2;
                    ItemsSelectorModalWindow groups = new ItemsSelectorModalWindow(type, nagr[e.RowIndex], activeScheduleDataModel);

                    if (groups.ShowDialog() == DialogResult.OK)
                    {
                        List<int?> idsList = groups.idsList;
                        List<string> TitleList = groups.TitleList;

                        if (idsList.Count > 0)
                        {
                            nagr[e.RowIndex].sub_groups = idsList.ToArray();

                            var value = "";
                            foreach (var title in TitleList)
                            {
                                value += title + ", ";
                            }
                            InformationDGV.Rows[e.RowIndex].Cells[4].Value = value;
                        }
                        else
                        {
                            Array.Clear(nagr[e.RowIndex].sub_groups, 0, nagr[e.RowIndex].sub_groups.Length);
                            InformationDGV.Rows[e.RowIndex].Cells[4].Value = "";
                        }
                    }
                }

                if (InformationDGV.Columns[e.ColumnIndex].Name == "AColumn")
                {
                    int type = 3;
                    ItemsSelectorModalWindow auditorys = new ItemsSelectorModalWindow(type, nagr[e.RowIndex], activeScheduleDataModel);

                    if (auditorys.ShowDialog() == DialogResult.OK)
                    {
                        List<int?> idsList = auditorys.idsList;
                        List<string> TitleList = auditorys.TitleList;

                        if (idsList.Count > 0)
                        {
                            nagr[e.RowIndex].auds = idsList.ToArray();

                            var value = "";
                            foreach (var title in TitleList)
                            {
                                value += title + ", ";
                            }
                            InformationDGV.Rows[e.RowIndex].Cells[6].Value = value;
                        }
                        else
                        {
                            Array.Clear(nagr[e.RowIndex].auds, 0, nagr[e.RowIndex].auds.Length);
                            InformationDGV.Rows[e.RowIndex].Cells[6].Value = "";
                        }
                    }
                }
            }
        }

        private void OpenMenuItem_Click(object sender, EventArgs e)
        {
            InformationDGV.DataSource = null;
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.Cancel)
                return;
            path = openFileDialog.FileName;
            Properties.Settings.Default.path = path;
            Properties.Settings.Default.Save();

            ReadData();
        }

        private void SaveMenuItem_Click(object sender, EventArgs e)
        {
            SaveData();
        }
    }

    public class ScheduleRowDataGridRowItem
    {
        public int H { get; set; }
        public object NT { get; set; }
        public string Teachers { get; set; }
        public string Sub_groups { get; set; }
        public string Auds { get; set; }
        public string Discipline { get; set; }
        public bool Is_online { get; set; }
    }
}
