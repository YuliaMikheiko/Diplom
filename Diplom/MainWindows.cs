using Equin.ApplicationFramework;
using System;
using System.Collections;
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
    public partial class MainWindows : Form
    {
        private ScheduleDataModel activeScheduleDataModel;
        public ScheduleRow[] nagr;
        string path;
        Dictionary<int, Teacher> dTeachers;
        Dictionary<int, Auditory> dAuditories;
        Dictionary<int, SubGroup> dSub_groups;

        public MainWindows()
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

            dTeachers = activeScheduleDataModel.GetTeachers();
            dAuditories = activeScheduleDataModel.GetAuditories();
            dSub_groups = activeScheduleDataModel.GetGroups();

            InformationDGV.DataSource = new BindingListView<ScheduleRowDataGridRowItem>(
                nagr.Select(x => new ScheduleRowDataGridRowItem(x, dTeachers, dAuditories, dSub_groups)
                {
                    H = x.h,
                    NT = x.nt,
                    Kaf = x.kaf,
                    Discipline = x.discipline,
                    Is_online = x.is_online.Equals(1),
                }).ToList()
            );
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

                        if (column.Name == "KafColumn")
                            nagr[i].kaf= (string)InformationDGV[column.Index, i].Value;

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

        public enum Type : int
        {
            Teachers,
            Groups,
            Auditorys
        }

        List<int?> idsList = new List<int?>();
        List<string> titleList = new List<string>();

        public string ModalWindow(int row, Type type, string columnName)
        {
            object dataItem = (InformationDGV.Rows[row].DataBoundItem as ObjectView<ScheduleRowDataGridRowItem>).Object;

            List<string> columnItem = new List<string>();
            columnItem.AddRange(dataItem.ToString().Split('%')[(int)type].Split(';').ToList().Where(title => title != " ").Select(title => title.Trim()));

            ItemsSelectorModalWindow modalWindow = new ItemsSelectorModalWindow((int)type, activeScheduleDataModel, columnItem);

            string value = null;

            if (modalWindow.ShowDialog() == DialogResult.OK)
            {
                idsList = modalWindow.idsList;
                titleList = modalWindow.titleList;
                value = " ";

                if (idsList.Count > 0)
                {
                    value = "";
                    foreach (var name in titleList)
                        value += name + "; ";
                }

                foreach (DataGridViewColumn column in InformationDGV.Columns)
                    if (column.Name == columnName)
                        InformationDGV[column.Index, row].Value = value;
            }
            return value;
        }
        private void InformationDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (InformationDGV.Columns[e.ColumnIndex].Name == "TColumn")
            {              
                if (ModalWindow(e.RowIndex, Type.Teachers, "TeachersColumn") != null)
                {
                    if (idsList.Count > 0)
                        nagr[e.RowIndex].teachers = idsList.ToArray();
                    else
                        Array.Clear(nagr[e.RowIndex].teachers, 0, nagr[e.RowIndex].teachers.Length);
                }
            }

            if (InformationDGV.Columns[e.ColumnIndex].Name == "GColumn")
            {
                if (ModalWindow(e.RowIndex, Type.Groups, "GroupsColumn") != null)
                {
                    if (idsList.Count > 0)
                        nagr[e.RowIndex].sub_groups = idsList.ToArray();
                    else
                        Array.Clear(nagr[e.RowIndex].sub_groups, 0, nagr[e.RowIndex].sub_groups.Length);
                }
            }

            if (InformationDGV.Columns[e.ColumnIndex].Name == "AColumn")
            {
                if (ModalWindow(e.RowIndex, Type.Auditorys, "AuditoriesColumn") != null)
                {
                    if (idsList.Count > 0)
                        nagr[e.RowIndex].auds = idsList.ToArray();
                    else
                        Array.Clear(nagr[e.RowIndex].auds, 0, nagr[e.RowIndex].auds.Length);
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
            (InformationDGV.DataSource as BindingListView<ScheduleRowDataGridRowItem>).RemoveFilter();
            SaveData();
        }

        private void FilterMenuItem_Click(object sender, EventArgs e)
        {
            FilterWindow filter = new FilterWindow(activeScheduleDataModel, nagr);
            if (filter.ShowDialog() == DialogResult.OK)
                FilterData(filter);
        }

        private void FilterData(FilterWindow filter)
        {
            (InformationDGV.DataSource as BindingListView<ScheduleRowDataGridRowItem>).ApplyFilter(x =>
            {
                List<(bool, List<string>, string)> list = new List<(bool, List<string>, string)>
                {
                    (filter.auditoryCheck, filter.titleListAuditorys, x.Auds),
                    (filter.groupCheck, filter.titleListGroups, x.Sub_groups),
                    (filter.teacherCheck, filter.titleListTeacher, x.Teachers),
                    (filter.kafedraCheck, filter.titleListKafedra, x.Kaf),
                    (filter.disciplineCheck, filter.titleListDiscipline, x.Discipline),
                    (filter.kursCheck, filter.titleListKurs, x.Kurs)
                };

                bool allResult = true;

                foreach (var item in list)
                {
                    bool result = false;

                    if (item.Item1)
                    {
                        result = true;

                        if (item.Item2.Count() > 0)
                            foreach (var _ in item.Item2.Where(i => item.Item3.Contains(i)).Select(i => new { }))
                                result = false;
                        else
                            result = false;
                    }
                    else
                    {
                        if (item.Item2.Count() > 0)
                            foreach (var _ in item.Item2.Where(i => item.Item3.Contains(i)).Select(i => new { }))
                                result = true;
                        else
                            result = true;
                    }
                    allResult &= result;
                }
                return allResult;
            });
        }

        private void TeacherWishMenuItem_Click(object sender, EventArgs e)
        {
            WishWindow wish = new WishWindow();
            if (wish.ShowDialog() == DialogResult.OK)
            {

            }
        }
    }
}