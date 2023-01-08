﻿using System;
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
        private ScheduleDataModel activeScheduleDataModel;
        public static ScheduleRow[] nagr;
        string path;
        Dictionary<int, Teacher> DTeachers;
        Dictionary<int, Auditory> DAuditories;
        Dictionary<int, SubGroup> DSub_groups;
        public Form1()
        {
            path = Properties.Settings.Default.path.ToString();
            InitializeComponent();
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

            InformationDGV.RowCount = nagr.Length;
            InformationDGV.ColumnCount = 10;
            InformationDGV.Rows[0].Cells[0].Selected = false;

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
                    foreach (var teacher in DTeachers)
                    {
                        if (nagr[i].teachers[k] == teacher.Value.id)
                            InformationDGV.Rows[i].Cells[2].Value += teacher.Value.name.ToString() + " ";
                    }
                }

                for (int k = 0; k < nagr[i].sub_groups.Length; k++)
                {
                    foreach (var groups in DSub_groups)
                    {
                        if (nagr[i].sub_groups[k] == groups.Value.id)
                            InformationDGV.Rows[i].Cells[4].Value += groups.Value.title + " ";
                    }
                }

                for (int k = 0; k < nagr[i].auds.Length; k++)
                {
                    foreach (var auditori in DAuditories)
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
                    ItemsSelectorModalWindow teachers = new ItemsSelectorModalWindow(type, e.RowIndex, nagr, activeScheduleDataModel);

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
                                value += name + " ";
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
                    ItemsSelectorModalWindow groups = new ItemsSelectorModalWindow(type, e.RowIndex, nagr, activeScheduleDataModel);

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
                                value += title + " ";
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
                    ItemsSelectorModalWindow auditorys = new ItemsSelectorModalWindow(type, e.RowIndex, nagr, activeScheduleDataModel);

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
                                value += title + " ";
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
            InformationDGV.Rows.Clear();
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
}
