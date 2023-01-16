using Equin.ApplicationFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Diplom
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

            NtColumn.DataSource = new List<KeyValuePair<int, string>>
            {
            new KeyValuePair<int, string>(1, "Лекция"),
            new KeyValuePair<int, string>(2, "Практика"),
            new KeyValuePair<int, string>(3, "Лаба"),
            new KeyValuePair<int, string>(4, "Консультация"),
            new KeyValuePair<int, string>(5, "Экзамен консультация"),
            new KeyValuePair<int, string>(6, "Экзамен"),
            new KeyValuePair<int, string>(7, "Зачет"),
            };
            NtColumn.DisplayMember = "Value";
            NtColumn.ValueMember = "Key";

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

            InformationDGV.DataSource = nagr.Select(x => new ScheduleRowDataGridRowItem(x, DTeachers, DAuditories, DSub_groups)
            {
                H = x.h,
                NT = x.nt,
                Kaf = x.kaf,
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
                InformationDGV.EndEdit();
                for (int i = 0; i < nagr.Length; i++)
                {
                    foreach (DataGridViewColumn column in InformationDGV.Columns)
                    {
                        if (column.Name == "HColumn")
                            nagr[i].h = (int)InformationDGV[column.Index, i].Value;

                        if (column.Name == "NtColumn")
                            nagr[i].nt = (int)InformationDGV[column.Index, i].Value;

                        if (column.Name == "DisciplineColumn")
                            nagr[i].discipline = (string)InformationDGV[column.Index, i].Value;

                        if (column.Name == "OnlineColumn")
                        {
                            if (InformationDGV[column.Index, i].Value.Equals(true))
                                nagr[i].is_online = 1;
                            else
                                nagr[i].is_online = 0;

                        }
                    }
                }

                (activeScheduleDataModel as JsonScheduleDataModel).nagruzka = nagr;
                activeScheduleDataModel.Save();

                MessageBox.Show(
                "Сохранено",
                "Сообщение",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            }
        }

        private void InformationDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
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
                        var value = " ";

                        if (idsList.Count > 0)
                        {
                            nagr[e.RowIndex].teachers = idsList.ToArray();

                            value = "";
                            foreach (var name in TitleList)
                                value += name + " ";
                        }
                        else
                            Array.Clear(nagr[e.RowIndex].teachers, 0, nagr[e.RowIndex].teachers.Length);

                        foreach (DataGridViewColumn column in InformationDGV.Columns)
                            if (column.Name == "TeachersColumn")
                                InformationDGV[column.Index, e.RowIndex].Value = value;
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
                        var value = " ";

                        if (idsList.Count > 0)
                        {
                            nagr[e.RowIndex].sub_groups = idsList.ToArray();

                            value = "";
                            foreach (var title in TitleList)
                                value += title + " ";
                        }
                        else
                            Array.Clear(nagr[e.RowIndex].sub_groups, 0, nagr[e.RowIndex].sub_groups.Length);

                        foreach (DataGridViewColumn column in InformationDGV.Columns)
                            if (column.Name == "GroupsColumn")
                                InformationDGV[column.Index, e.RowIndex].Value = value;
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
                        var value = " ";

                        if (idsList.Count > 0)
                        {
                            nagr[e.RowIndex].auds = idsList.ToArray();

                            value = "";
                            foreach (var title in TitleList)
                                value += title + " ";
                        }
                        else
                            Array.Clear(nagr[e.RowIndex].auds, 0, nagr[e.RowIndex].auds.Length);

                        foreach (DataGridViewColumn column in InformationDGV.Columns)
                            if (column.Name == "AuditoriesColumn")
                                InformationDGV[column.Index, e.RowIndex].Value = value;
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

        private void FilterMenuItem_Click(object sender, EventArgs e)
        {
            FilterWindow filter = new FilterWindow(activeScheduleDataModel);
            if (filter.ShowDialog() == DialogResult.OK)
            {
                
            }
        }
    }
}
