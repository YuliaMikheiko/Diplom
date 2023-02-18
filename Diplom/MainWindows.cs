using Equin.ApplicationFramework;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
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

        List<int?> idsList = new List<int?>();
        List<string> titleList = new List<string>();

        public enum Type : int
        {
            Teachers,
            Groups,
            Auditorys
        }

        List<string> titleListGroups = new List<string>();
        List<string> titleListKafedra = new List<string>();
        List<string> titleListTeacher = new List<string>();
        List<string> titleListAuditorys = new List<string>();
        List<string> titleListDiscipline = new List<string>();
        List<string> titleListKurs = new List<string>();
        List<string> idListNt = new List<string>();
        List<string> titleListNt = new List<string>();
        List<string> titleListOwners = new List<string>();
        List<string> titleListFac = new List<string>();

        bool ownersCheck;
        bool auditoryCheck;
        bool groupCheck;
        bool teacherCheck;
        bool kafedraCheck;
        bool disciplineCheck;
        bool kursCheck;
        bool ntCheck;
        bool facCheck;
        bool zaochCheck;
        bool ochCheck;

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

            KeyPreview = true;
            KeyDown += new KeyEventHandler(Reset_KeyDown);

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
                    Is_online = x.is_online.Equals(1)
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

        public string ModalWindow(int row, Type type, string columnName)
        {
            object dataItem = (InformationDGV.Rows[row].DataBoundItem as ObjectView<ScheduleRowDataGridRowItem>).Object;

            List<string> columnItem = new List<string>();
            columnItem.AddRange(dataItem.ToString().Split('%')[(int)type].Split(';').ToList().Where(title => title != "").Select(title => title.Trim()));

            ItemsSelectorModalWindow modalWindow = new ItemsSelectorModalWindow((int)type, activeScheduleDataModel, columnItem);

            string value = null;

            if (modalWindow.ShowDialog() == DialogResult.OK)
            {
                idsList = modalWindow.idsList;
                titleList = modalWindow.titleList;

                value = String.Join("; ", titleList);

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
            FilterWindow filter = new FilterWindow(activeScheduleDataModel, nagr, titleListGroups, titleListKafedra, titleListTeacher, titleListAuditorys, titleListDiscipline, titleListKurs, titleListOwners, idListNt, titleListNt, titleListFac, auditoryCheck, groupCheck, teacherCheck, kafedraCheck, disciplineCheck, kursCheck, ntCheck, ownersCheck, facCheck, zaochCheck, ochCheck);
            
            if (filter.ShowDialog() == DialogResult.OK)
            {
                titleListFac = filter.titleListFac;
                titleListOwners = filter.titleListOwners;
                titleListAuditorys = filter.titleListAuditorys;
                titleListGroups = filter.titleListGroups;
                titleListTeacher = filter.titleListTeacher;
                titleListKafedra = filter.titleListKafedra;
                titleListDiscipline = filter.titleListDiscipline;
                titleListKurs = filter.titleListKurs;
                idListNt = filter.idListNt;
                titleListNt = filter.titleListNt;

                facCheck = filter.facCheck;
                ownersCheck = filter.ownersCheck;
                auditoryCheck = filter.auditoryCheck;
                groupCheck = filter.groupCheck;
                teacherCheck = filter.teacherCheck;
                kafedraCheck = filter.kafedraCheck;
                disciplineCheck = filter.disciplineCheck;
                kursCheck = filter.kursCheck;
                ntCheck = filter.ntCheck;
                zaochCheck = filter.zaochCheck;
                ochCheck = filter.ochCheck;

                FilterData(filter);
            }
        }

        private void FilterData(FilterWindow filter)
        {
            (InformationDGV.DataSource as BindingListView<ScheduleRowDataGridRowItem>).ApplyFilter(x =>
            {
                List<(bool, List<string>, string)> list = new List<(bool, List<string>, string)>
                {
                    (auditoryCheck, titleListAuditorys, x.Auds),
                    (groupCheck, filter.titleShortListGroups, x.Sub_groups),
                    (teacherCheck, titleListTeacher, x.Teachers),
                    (kafedraCheck, titleListKafedra, x.Kaf),
                    (disciplineCheck, titleListDiscipline, x.Discipline),
                    (kursCheck, titleListKurs, x.Kurs),
                    (ntCheck, idListNt, x.NT.ToString()),
                    (ownersCheck, titleListOwners, x.Owners)
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

                bool resultFac = false;

                if (facCheck)
                {
                    resultFac = true;

                    if (titleListFac.Count() > 0)
                        foreach (var _ in x.Fac.Split(';').Where(item => titleListFac.Contains(item.Trim())).Select(item => new { }))
                            resultFac = false;
                    else
                        resultFac = false;
                }
                else
                {
                    if (titleListFac.Count() > 0)
                        foreach (var _ in x.Fac.Split(';').Where(item => titleListFac.Contains(item.Trim())).Select(item => new { }))
                            resultFac = true;
                    else
                        resultFac = true;
                }

                bool resultZaoch = false;

                if (zaochCheck)
                {
                    if (x.Sub_groups.Contains("(И,З)"))
                        resultZaoch = true;
                }
                else
                    resultZaoch = true;

                bool resultOch = false;

                if (ochCheck)
                {
                    if (x.Sub_groups.Contains("(И,О)"))
                        resultOch = true;
                }
                else
                    resultOch = true;

                return allResult & resultFac & resultZaoch & resultOch;
            });
        }

        private void TeacherWishMenuItem_Click(object sender, EventArgs e)
        {
            ItemsSelectorModalWindow modalWindow = new ItemsSelectorModalWindow((int)Type.Teachers, activeScheduleDataModel, new List<string>());
            
            if (modalWindow.ShowDialog() == DialogResult.OK)
            {
                idsList = modalWindow.idsList;

                if (idsList.Count > 0 & idsList.Count < 2)
                {
                    WishWindow wish = new WishWindow((int)Type.Teachers, activeScheduleDataModel, idsList);

                    wish.ShowDialog();
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show(
                    "Выберете одного преподавателя",
                    "Сообщение",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                }
            }
        }

        private void GroupWishMenuItem_Click(object sender, EventArgs e)
        {
            ItemsSelectorModalWindow modalWindow = new ItemsSelectorModalWindow((int)Type.Groups, activeScheduleDataModel, new List<string>());

            if (modalWindow.ShowDialog() == DialogResult.OK)
            {
                idsList = modalWindow.idsList;

                if (idsList.Count > 0 & idsList.Count < 2)
                {
                    WishWindow wish = new WishWindow((int)Type.Groups, activeScheduleDataModel, idsList);

                    wish.ShowDialog();
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show(
                    "Выберете одну группу",
                    "Сообщение",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                }
            }
        }

        private void AudsWishToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ItemsSelectorModalWindow modalWindow = new ItemsSelectorModalWindow((int)Type.Auditorys, activeScheduleDataModel, new List<string>());

            if (modalWindow.ShowDialog() == DialogResult.OK)
            {
                idsList = modalWindow.idsList;

                if (idsList.Count > 0 & idsList.Count < 2)
                {
                    WishWindow wish = new WishWindow((int)Type.Auditorys, activeScheduleDataModel, idsList);

                    wish.ShowDialog();
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show(
                    "Выберете одну аудиторию",
                    "Сообщение",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                }
            }
        }

        private void InformationDGV_ColumnHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (InformationDGV.Columns[e.ColumnIndex].Name == "TeachersColumn")
            {
                (InformationDGV.DataSource as BindingListView<ScheduleRowDataGridRowItem>).ApplyFilter(x =>
                {
                    bool resultTeach = false;

                    foreach (var _ in taech.Where(i => x.Teachers.Contains(i)).Select(i => new { }))
                        resultTeach = true;

                    return resultTeach;
                });
            }

            if (InformationDGV.Columns[e.ColumnIndex].Name == "GroupsColumn")
            {
                (InformationDGV.DataSource as BindingListView<ScheduleRowDataGridRowItem>).ApplyFilter(x =>
                {
                    bool resultGroups = false;

                    foreach (var _ in group.Where(i => x.Sub_groups.Contains(i)).Select(i => new { }))
                        resultGroups = true;

                    return resultGroups;
                });
            }

            if (InformationDGV.Columns[e.ColumnIndex].Name == "AuditoriesColumn")
            {
                (InformationDGV.DataSource as BindingListView<ScheduleRowDataGridRowItem>).ApplyFilter(x =>
                {
                    bool resultAud = false;

                    foreach (var _ in x.Auds.Split(';').Where(item => aud.Contains(item.Trim())).Select(item => new { }))
                        resultAud = true;

                    return resultAud;
                });
            }

            if (InformationDGV.Columns[e.ColumnIndex].Name == "DisciplineColumn")
            {
                (InformationDGV.DataSource as BindingListView<ScheduleRowDataGridRowItem>).ApplyFilter(x =>
                {
                    bool resultDis = false;

                    foreach (var _ in x.Discipline.Split(';').Where(item => dis.Contains(item.Trim())).Select(item => new { }))
                        resultDis = true;

                    return resultDis;
                });
            }

            if (InformationDGV.Columns[e.ColumnIndex].Name == "KafColumn")
            {
                (InformationDGV.DataSource as BindingListView<ScheduleRowDataGridRowItem>).ApplyFilter(x =>
                {
                    bool resultKaf = false;

                    foreach (var _ in x.Kaf.Split(';').Where(item => kaf.Contains(item.Trim())).Select(item => new { }))
                        resultKaf = true;

                    return resultKaf;
                });
            }

            if (InformationDGV.Columns[e.ColumnIndex].Name == "OwnersColumn")
            {
                (InformationDGV.DataSource as BindingListView<ScheduleRowDataGridRowItem>).ApplyFilter(x =>
                {
                    bool resultOwn = false;

                    foreach (var _ in x.Owners.Split(';').Where(item => own.Contains(item.Trim())).Select(item => new { }))
                        resultOwn = true;

                    return resultOwn;
                });
            }

            if (InformationDGV.Columns[e.ColumnIndex].Name == "NtColumn")
            {
                (InformationDGV.DataSource as BindingListView<ScheduleRowDataGridRowItem>).ApplyFilter(x =>
                {
                    bool resultNt = false;

                    if (nt.Contains(x.NT))
                        resultNt = true;

                    return resultNt;
                });
            }

            taech = new List<string>();
            group = new List<string>();
            aud = new List<string>();
            dis = new List<string>();
            kaf = new List<string>();
            own = new List<string>();
            nt = new List<int>();
        }

        List<string> taech = new List<string>();
        List<string> group = new List<string>();
        List<string> aud = new List<string>();
        List<string> dis = new List<string>();
        List<string> kaf = new List<string>();
        List<string> own = new List<string>();
        List<int> nt = new List<int>();

        private void InformationDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (InformationDGV.Columns[e.ColumnIndex].Name == "TeachersColumn")
            {
                if (e.RowIndex > -1)
                    taech.Add((string)InformationDGV[e.ColumnIndex, e.RowIndex].Value);
            }

            if (InformationDGV.Columns[e.ColumnIndex].Name == "GroupsColumn")
            {
                if (e.RowIndex > -1)
                    group.Add((string)InformationDGV[e.ColumnIndex, e.RowIndex].Value);
            }

            if (InformationDGV.Columns[e.ColumnIndex].Name == "AuditoriesColumn")
            {
                if (e.RowIndex > -1)
                    aud.Add((string)InformationDGV[e.ColumnIndex, e.RowIndex].Value);
            }

            if (InformationDGV.Columns[e.ColumnIndex].Name == "DisciplineColumn")
            {
                if (e.RowIndex > -1)
                    dis.Add((string)InformationDGV[e.ColumnIndex, e.RowIndex].Value);
            }

            if (InformationDGV.Columns[e.ColumnIndex].Name == "KafColumn")
            {
                if (e.RowIndex > -1)
                    kaf.Add((string)InformationDGV[e.ColumnIndex, e.RowIndex].Value);
            }

            if (InformationDGV.Columns[e.ColumnIndex].Name == "KafColumn")
            {
                if (e.RowIndex > -1)
                    kaf.Add((string)InformationDGV[e.ColumnIndex, e.RowIndex].Value);
            }

            if (InformationDGV.Columns[e.ColumnIndex].Name == "OwnersColumn")
            {
                if (e.RowIndex > -1)
                    own.Add((string)InformationDGV[e.ColumnIndex, e.RowIndex].Value);
            }

            if (InformationDGV.Columns[e.ColumnIndex].Name == "NtColumn")
            {
                if (e.RowIndex > -1)
                    nt.Add((int)InformationDGV[e.ColumnIndex, e.RowIndex].Value);
            }
        }

        private void Reset_Click(object sender, EventArgs e)
        {
            (InformationDGV.DataSource as BindingListView<ScheduleRowDataGridRowItem>).RemoveFilter();
        }

        private void Reset_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.Z)
            {
                (InformationDGV.DataSource as BindingListView<ScheduleRowDataGridRowItem>).RemoveFilter();
            }
        }
    }
}