using Equin.ApplicationFramework;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using static System.Runtime.CompilerServices.RuntimeHelpers;

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
        Dictionary<int, int[]> dZanlist;

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
        List<string> titleShortListGroups = new List<string>();

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

        List<string> taech = new List<string>();
        List<string> group = new List<string>();
        List<string> aud = new List<string>();
        List<string> dis = new List<string>();
        List<string> kaf = new List<string>();
        List<string> own = new List<string>();
        List<string> nt = new List<string>();

        List<string> titleT = null;
        List<string> titleG = null;
        List<string> titleA = null;

        List<int?> idT = new List<int?>();
        List<int?> idG = new List<int?>();
        List<int?> idA = new List<int?>();

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
            dZanlist = activeScheduleDataModel.GetZanlist();

            InformationDGV.DataSource = new BindingListView<ScheduleRowDataGridRowItem>(
                nagr.Select(x => new ScheduleRowDataGridRowItem(x, dTeachers, dAuditories, dSub_groups)
                {
                    Id = x.id,
                    H = x.h,
                    NT = x.nt,
                    Kaf = x.kaf,
                    Discipline = x.discipline,
                    Is_online = x.is_online.Equals(1),
                    Owners = String.Join("; ", x.owners)
                }).ToList()
            );

            //for(int u=0; u< InformationDGV.RowCount; u++)
            //{
            //    foreach (var i in dZanlist)
            //    {
            //        foreach (var t in i.Value)
            //        {
            //            if ((int)InformationDGV[0, u].Value == t)
            //            {
            //                InformationDGV[13, u].Value = true;
            //            }
            //        }
            //    }
            //}
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

                        //if (column.Name == "OwnersColumn")
                        //{
                        //    var y = (string)InformationDGV[column.Index, i].Value;
                        //    nagr[i].owners = y.Split(';');
                            
                        //}
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
            if (e.RowIndex > -1)
            {
                if (InformationDGV.Columns[e.ColumnIndex].Name == "TColumn" && ModalWindow(e.RowIndex, Type.Teachers, "TeachersColumn") != null)
                {
                    foreach (var item in nagr.Where(item => item.id == (int)InformationDGV["IdColumn", e.RowIndex].Value))
                    {
                        if (idsList.Count > 0)
                            item.teachers = idsList.ToArray();
                        else
                            Array.Clear(item.teachers, 0, item.teachers.Length);
                    }
                    idT = idsList;
                    titleT = titleList;
                }

                if (InformationDGV.Columns[e.ColumnIndex].Name == "GColumn" && ModalWindow(e.RowIndex, Type.Groups, "GroupsColumn") != null)
                {
                    foreach (var item in nagr.Where(item => item.id == (int)InformationDGV["IdColumn", e.RowIndex].Value))
                    {
                        if (idsList.Count > 0)
                            item.sub_groups = idsList.ToArray();
                        else
                            Array.Clear(item.sub_groups, 0, item.sub_groups.Length);
                    }
                    idG = idsList;
                    titleG = titleList;
                }

                if (InformationDGV.Columns[e.ColumnIndex].Name == "AColumn" && ModalWindow(e.RowIndex, Type.Auditorys, "AuditoriesColumn") != null)
                {
                    foreach (var item in nagr.Where(item => item.id == (int)InformationDGV["IdColumn", e.RowIndex].Value))
                    {
                        if (idsList.Count > 0)
                            item.auds = idsList.ToArray();
                        else
                            Array.Clear(item.auds, 0, item.auds.Length);
                    }
                    idA = idsList;
                    titleA = titleList;
                }
            }
        }

        public string ModalWindow(int row, Type type, string columnName)
        {
            object dataItem = (InformationDGV.Rows[row].DataBoundItem as ObjectView<ScheduleRowDataGridRowItem>).Object;

            List<string> columnItem = new List<string>();
            columnItem.AddRange(dataItem.ToString().Split('%')[(int)type].Split(';').ToList().Where(title => title != "").Select(title => title.Trim()));

            ItemsSelectorModalWindow modalWindow = new ItemsSelectorModalWindow((int)type, activeScheduleDataModel, columnItem, 1);

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

            titleListGroups = new List<string>();
            titleListKafedra = new List<string>();
            titleListTeacher = new List<string>();
            titleListAuditorys = new List<string>();
            titleListDiscipline = new List<string>();
            titleListKurs = new List<string>();
            idListNt = new List<string>();
            titleListNt = new List<string>();
            titleListOwners = new List<string>();
            titleListFac = new List<string>();
            titleShortListGroups = new List<string>();

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

                titleShortListGroups = filter.titleShortListGroups;

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

                FilterData();
            }
        }

        private void FilterData()
        {
            (InformationDGV.DataSource as BindingListView<ScheduleRowDataGridRowItem>).ApplyFilter(x =>
            {
                List<(bool, List<string>, string)> list = new List<(bool, List<string>, string)>
                {
                    (auditoryCheck, titleListAuditorys, x.Auds),
                    (teacherCheck, titleListTeacher, x.Teachers),
                    (kafedraCheck, titleListKafedra, x.Kaf),
                    (disciplineCheck, titleListDiscipline, x.Discipline),
                    (kursCheck, titleListKurs, x.Kurs),
                    (ntCheck, idListNt, x.NT.ToString()),
                    (ownersCheck, titleListOwners, x.Owners),
                    (facCheck, titleListFac, x.Fac)
                };

                bool allResult = true;

                foreach (var item in list)
                {
                    bool result = false;

                    if (item.Item1)
                    {
                        result = true;

                        if (item.Item2.Count() > 0)
                            foreach (var _ in item.Item3.Split(';').Where(i => item.Item2.Contains(i.Trim())).Select(i => new { }))
                                result = false;
                        else
                            result = false;
                    }
                    else
                    {
                        if (item.Item2.Count() > 0)
                            foreach (var _ in item.Item3.Split(';').Where(i => item.Item2.Contains(i.Trim())).Select(i => new { }))
                                result = true;
                        else
                            result = true;
                    }
                    allResult &= result;
                }

                bool resultGroup = false;

                if (groupCheck)
                {
                    resultGroup = true;

                    if (titleShortListGroups.Count() > 0)
                        foreach (var _ in titleShortListGroups.Where(i => x.Sub_groups.Contains(i)).Select(i => new { }))
                            resultGroup = false;
                    else
                        resultGroup = false;
                }
                else
                {
                    if (titleShortListGroups.Count() > 0)
                        foreach (var _ in titleShortListGroups.Where(i => x.Sub_groups.Contains(i)).Select(i => new { }))
                            resultGroup = true;
                    else
                        resultGroup = true;
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

                return allResult & resultGroup & resultZaoch & resultOch;
            });
        }

        private void TeacherWishMenuItem_Click(object sender, EventArgs e)
        {
            ItemsSelectorModalWindow modalWindow = new ItemsSelectorModalWindow((int)Type.Teachers, activeScheduleDataModel, new List<string>(), 2);
            
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
            ItemsSelectorModalWindow modalWindow = new ItemsSelectorModalWindow((int)Type.Groups, activeScheduleDataModel, new List<string>(), 2);

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
            ItemsSelectorModalWindow modalWindow = new ItemsSelectorModalWindow((int)Type.Auditorys, activeScheduleDataModel, new List<string>(), 2);

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

        private void InformationDGV_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (e.RowIndex > -1)
                {
                    InformationDGV.ClearSelection();

                    InformationDGV[e.ColumnIndex, e.RowIndex].Selected = true;

                    if (InformationDGV.Columns[e.ColumnIndex].Name == "TeachersColumn")
                        taech.AddRange(InformationDGV[e.ColumnIndex, e.RowIndex].Value.ToString().Split(';').Select(t => t.Trim()));

                    if (InformationDGV.Columns[e.ColumnIndex].Name == "GroupsColumn")
                        group.AddRange(InformationDGV[e.ColumnIndex, e.RowIndex].Value.ToString().Split(';').Select(g => g.Trim()));

                    if (InformationDGV.Columns[e.ColumnIndex].Name == "AuditoriesColumn")
                        aud.AddRange(InformationDGV[e.ColumnIndex, e.RowIndex].Value.ToString().Split(';').Select(a => a.Trim()));

                    if (InformationDGV.Columns[e.ColumnIndex].Name == "DisciplineColumn")
                        dis.Add((string)InformationDGV[e.ColumnIndex, e.RowIndex].Value);

                    if (InformationDGV.Columns[e.ColumnIndex].Name == "KafColumn")
                        kaf.Add((string)InformationDGV[e.ColumnIndex, e.RowIndex].Value);

                    if (InformationDGV.Columns[e.ColumnIndex].Name == "OwnersColumn")
                        own.AddRange(InformationDGV[e.ColumnIndex, e.RowIndex].Value.ToString().Split(';').Select(o => o.Trim()));

                    if (InformationDGV.Columns[e.ColumnIndex].Name == "NtColumn")
                        nt.Add(((int)InformationDGV[e.ColumnIndex, e.RowIndex].Value).ToString());
                }
            }
            else
            {
                taech = new List<string>();
                group = new List<string>();
                aud = new List<string>();
                dis = new List<string>();
                kaf = new List<string>();
                own = new List<string>();
                nt = new List<string>();
            }
        }

        private void Reset_Click(object sender, EventArgs e)
        {
            taech = new List<string>();
            group = new List<string>();
            aud = new List<string>();
            dis = new List<string>();
            kaf = new List<string>();
            own = new List<string>();
            nt = new List<string>();

            titleListGroups = new List<string>();
            titleListKafedra = new List<string>();
            titleListTeacher = new List<string>();
            titleListAuditorys = new List<string>();
            titleListDiscipline = new List<string>();
            titleListKurs = new List<string>();
            idListNt = new List<string>();
            titleListNt = new List<string>();
            titleListOwners = new List<string>();
            titleListFac = new List<string>();
            titleShortListGroups = new List<string>();

            (InformationDGV.DataSource as BindingListView<ScheduleRowDataGridRowItem>).RemoveFilter();
        }

        private void Reset_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control & e.KeyCode == Keys.Z)
            {
                taech = new List<string>();
                group = new List<string>();
                aud = new List<string>();
                dis = new List<string>();
                kaf = new List<string>();
                own = new List<string>();
                nt = new List<string>();

                titleListGroups = new List<string>();
                titleListKafedra = new List<string>();
                titleListTeacher = new List<string>();
                titleListAuditorys = new List<string>();
                titleListDiscipline = new List<string>();
                titleListKurs = new List<string>();
                idListNt = new List<string>();
                titleListNt = new List<string>();
                titleListOwners = new List<string>();
                titleListFac = new List<string>();
                titleShortListGroups = new List<string>();

                (InformationDGV.DataSource as BindingListView<ScheduleRowDataGridRowItem>).RemoveFilter();
            }
        }

        private void Distribute_Click(object sender, EventArgs e)
        {
            string value;

            foreach (DataGridViewColumn column in InformationDGV.Columns)
            {
                if (column.Name == "TeachersColumn")
                {
                    if (titleT != null)
                    {
                        value = String.Join("; ", titleT);

                        foreach (DataGridViewRow row in InformationDGV.Rows)
                        {
                            InformationDGV[column.Index, row.Index].Value = value;

                            foreach (var item in nagr.Where(item => item.id == (int)InformationDGV["IdColumn", row.Index].Value))
                            {
                                if (idT.Count > 0)
                                    item.teachers = idT.ToArray();
                                else
                                    Array.Clear(item.teachers, 0, item.teachers.Length);
                            }
                        }
                    }
                }
                if (column.Name == "AuditoriesColumn")
                {
                    if (titleA != null)
                    {
                        value = String.Join("; ", titleA);

                        foreach (DataGridViewRow row in InformationDGV.Rows)
                        {
                            InformationDGV[column.Index, row.Index].Value = value;

                            foreach (var item in nagr.Where(item => item.id == (int)InformationDGV["IdColumn", row.Index].Value))
                            {
                                if (idA.Count > 0)
                                    item.auds = idA.ToArray();
                                else
                                    Array.Clear(item.auds, 0, item.auds.Length);
                            }
                        }
                    }
                }
                if (column.Name == "GroupsColumn")
                {
                    if (titleG != null)
                    {
                        value = String.Join("; ", titleG);

                        foreach (DataGridViewRow row in InformationDGV.Rows)
                        {
                            InformationDGV[column.Index, row.Index].Value = value;

                            foreach (var item in nagr.Where(item => item.id == (int)InformationDGV["IdColumn", row.Index].Value))
                            {
                                if (idG.Count > 0)
                                    item.sub_groups = idG.ToArray();
                                else
                                    Array.Clear(item.sub_groups, 0, item.sub_groups.Length);
                            }
                        }
                    }
                }
            }
            titleT = null;
            titleG = null;
            titleA = null;
        }

        private void InformationDGV_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (InformationDGV.Columns[e.ColumnIndex].Name == "TeachersColumn")
                {
                    titleListTeacher = taech;
                    teacherCheck = false;
                }

                if (InformationDGV.Columns[e.ColumnIndex].Name == "GroupsColumn")
                {
                    titleListGroups = group;
                    titleShortListGroups = group;
                    groupCheck = false;
                }

                if (InformationDGV.Columns[e.ColumnIndex].Name == "AuditoriesColumn")
                {
                    titleListAuditorys = aud;
                    auditoryCheck = false;
                }

                if (InformationDGV.Columns[e.ColumnIndex].Name == "DisciplineColumn")
                {
                    titleListDiscipline = dis;
                    disciplineCheck = false;
                }

                if (InformationDGV.Columns[e.ColumnIndex].Name == "KafColumn")
                {
                    titleListKafedra = kaf;
                    kafedraCheck = false;
                }

                if (InformationDGV.Columns[e.ColumnIndex].Name == "OwnersColumn")
                {
                    titleListOwners = own;
                    ownersCheck = false;
                }

                if (InformationDGV.Columns[e.ColumnIndex].Name == "NtColumn")
                {
                    titleListNt = new List<string>();

                    foreach (var i in nt)
                    {
                        switch (i)
                        {
                            case "1":
                                titleListNt.Add("Лекция");
                                break;
                            case "2":
                                titleListNt.Add("Практика");
                                break;
                            case "3":
                                titleListNt.Add("Лаба");
                                break;
                            case "4":
                                titleListNt.Add("Консультация");
                                break;
                            case "5":
                                titleListNt.Add("Экзамен консультация");
                                break;
                            case "6":
                                titleListNt.Add("Экзамен");
                                break;
                            case "7":
                                titleListNt.Add("Зачет");
                                break;
                        }
                    }
                    idListNt = nt;
                    ntCheck = false;
                }

                FilterData();

                taech = new List<string>();
                group = new List<string>();
                aud = new List<string>();
                dis = new List<string>();
                kaf = new List<string>();
                own = new List<string>();
                nt = new List<string>();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}