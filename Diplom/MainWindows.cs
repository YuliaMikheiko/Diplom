using Equin.ApplicationFramework;
using System;
using System.Collections.Generic;
using System.Data;
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
        List<int> zanlist = new List<int>();

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
                    Owners = String.Join("; ", x.owners),
                    Zanlist = ReadZanlist(x.id)
                }).ToList()
            );
        }

        private bool ReadZanlist(int id)
        {
            foreach (var values in dZanlist.Values)
            {
                foreach (int value in values)
                {
                    if (id == value)
                        return true;
                }
            }
            return false;
        }

        private void InformationDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                switch (InformationDGV.Columns[e.ColumnIndex].Name)
                {
                    case "TColumn" when ModalWindow(e.RowIndex, Type.Teachers, "TeachersColumn") != null:
                        foreach (var item in nagr.Where(item => item.id == (int)InformationDGV["IdColumn", e.RowIndex].Value))
                        {
                            if (idsList.Count > 0)
                                item.teachers = idsList.ToArray();
                            else
                                Array.Clear(item.teachers, 0, item.teachers.Length);
                        }
                        idT = idsList;
                        titleT = titleList;
                        break;

                    case "GColumn" when ModalWindow(e.RowIndex, Type.Groups, "GroupsColumn") != null:
                        foreach (var item in nagr.Where(item => item.id == (int)InformationDGV["IdColumn", e.RowIndex].Value))
                        {
                            if (idsList.Count > 0)
                                item.sub_groups = idsList.ToArray();
                            else
                                Array.Clear(item.sub_groups, 0, item.sub_groups.Length);
                        }
                        idG = idsList;
                        titleG = titleList;
                        break;

                    case "AColumn" when ModalWindow(e.RowIndex, Type.Auditorys, "AuditoriesColumn") != null:
                        foreach (var item in nagr.Where(item => item.id == (int)InformationDGV["IdColumn", e.RowIndex].Value))
                        {
                            if (idsList.Count > 0)
                                item.auds = idsList.ToArray();
                            else
                                Array.Clear(item.auds, 0, item.auds.Length);
                        }
                        idA = idsList;
                        titleA = titleList;
                        break;

                    case "ZColumn":
                        int key = 0;
                        foreach (var j in dZanlist.SelectMany(j => j.Value.Where(values => (int)InformationDGV["IdColumn", e.RowIndex].Value == values).Select(values => j)))
                        {
                            key = j.Key;
                            break;
                        }

                        List<string> list = new List<string>();
                        if (key != 0)
                        {
                            list.AddRange(dZanlist[key].Select(item => item.ToString()));
                        }

                        (InformationDGV.DataSource as BindingListView<ScheduleRowDataGridRowItem>).ApplyFilter(x =>
                        {
                            bool allResult = true;

                            if (list.Count() > 0)
                            {
                                if (list.Contains(x.Id.ToString()))
                                    allResult = true;
                                else
                                    allResult = false;
                            }
                            return allResult;
                        });

                        break;

                    case "OnlineColumn":
                        InformationDGV.EndEdit();
                        foreach (var item in nagr.Where(item => item.id == (int)InformationDGV["IdColumn", e.RowIndex].Value))
                        {
                            if (InformationDGV[e.ColumnIndex, e.RowIndex].Value.Equals(true))
                                item.is_online = 1;
                            else
                                item.is_online = 0;
                        }
                        break;

                    case "ZanlistColumn":
                        InformationDGV.EndEdit();
                        if (InformationDGV[e.ColumnIndex, e.RowIndex].Value.Equals(true))
                            zanlist.Add((int)InformationDGV[0, e.RowIndex].Value);
                        break;
                }
            }
        }

        public string ModalWindow(int row, Type type, string columnName)
        {
            object dataItem = (InformationDGV.Rows[row].DataBoundItem as ObjectView<ScheduleRowDataGridRowItem>).Object;

            List<string> columnItem = new List<string>();
            columnItem.AddRange(dataItem.ToString().Split('%')[(int)type].Split(';').ToList().Where(title => title != "").Select(title => title.Trim()));

            ItemsSelectorModalWindow modalWindow = new ItemsSelectorModalWindow((int)type, activeScheduleDataModel, columnItem, true);

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

            InformationDGV.EndEdit();

            (activeScheduleDataModel as JsonScheduleDataModel).nagruzka = nagr;
            activeScheduleDataModel.Save();
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
            Wish((int)Type.Teachers);
        }

        private void GroupWishMenuItem_Click(object sender, EventArgs e)
        {
            Wish((int)Type.Groups);
        }

        private void AudsWishToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Wish((int)Type.Auditorys);
        }

        public void Wish(int type)
        {
            ItemsSelectorModalWindow modalWindow = new ItemsSelectorModalWindow(type, activeScheduleDataModel, new List<string>(), false);

            if (modalWindow.ShowDialog() == DialogResult.OK)
            {
                idsList = modalWindow.idsList;

                if (idsList.Count > 0 & idsList.Count < 2)
                {
                    WishWindow wish = new WishWindow(type, activeScheduleDataModel, idsList);

                    wish.ShowDialog();
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show(
                    "Выберете однин пункт",
                    "Сообщение",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                }
            }
        }

        private void InformationDGV_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Right:
                    {
                        if (e.RowIndex > -1)
                        {
                            InformationDGV.ClearSelection();

                            InformationDGV[e.ColumnIndex, e.RowIndex].Selected = true;

                            switch (InformationDGV.Columns[e.ColumnIndex].Name)
                            {
                                case "TeachersColumn":
                                    taech.AddRange(InformationDGV[e.ColumnIndex, e.RowIndex].Value.ToString().Split(';').Select(t => t.Trim()));
                                    break;
                                case "GroupsColumn":
                                    group.AddRange(InformationDGV[e.ColumnIndex, e.RowIndex].Value.ToString().Split(';').Select(g => g.Trim()));
                                    break;
                                case "AuditoriesColumn":
                                    aud.AddRange(InformationDGV[e.ColumnIndex, e.RowIndex].Value.ToString().Split(';').Select(a => a.Trim()));
                                    break;
                                case "DisciplineColumn":
                                    dis.Add((string)InformationDGV[e.ColumnIndex, e.RowIndex].Value);
                                    break;
                                case "KafColumn":
                                    kaf.Add((string)InformationDGV[e.ColumnIndex, e.RowIndex].Value);
                                    break;
                                case "OwnersColumn":
                                    own.AddRange(InformationDGV[e.ColumnIndex, e.RowIndex].Value.ToString().Split(';').Select(o => o.Trim()));
                                    break;
                                case "NtColumn":
                                    nt.Add(((int)InformationDGV[e.ColumnIndex, e.RowIndex].Value).ToString());
                                    break;

                                case "ZanlistColumn":
                                    int key = 0;
                                    foreach (var j in dZanlist.SelectMany(j => j.Value.Where(values => (int)InformationDGV["IdColumn", e.RowIndex].Value == values).Select(values => j)))
                                    {
                                        key = j.Key;
                                        break;
                                    }

                                    if (key != 0)
                                    {
                                        list1.AddRange(dZanlist[key].Select(item => item.ToString()));
                                    }
                                    break;
                            }
                        }
                        break;
                    }

                default:
                    taech = new List<string>();
                    group = new List<string>();
                    aud = new List<string>();
                    dis = new List<string>();
                    kaf = new List<string>();
                    own = new List<string>();
                    nt = new List<string>();
                    break;
            }
        }

        public List<string> list1 = new List<string>();
        private void Reset_Click(object sender, EventArgs e)
        {
            ResetFilter();
        }

        private void Reset_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control & e.KeyCode == Keys.Z)
            {
                ResetFilter();
            }
        }

        private void ResetFilter()
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

        private void Distribute_Click(object sender, EventArgs e)
        {
            string value;

            foreach (DataGridViewColumn column in InformationDGV.Columns)
            {
                switch (column.Name)
                {
                    case "TeachersColumn":
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
                        break;

                    case "AuditoriesColumn":
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
                        break;

                    case "GroupsColumn":
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
                        break;
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
                switch (InformationDGV.Columns[e.ColumnIndex].Name)
                {
                    case "TeachersColumn":
                        titleListTeacher = taech;
                        teacherCheck = false;
                        break;
                    case "GroupsColumn":
                        titleListGroups = group;
                        titleShortListGroups = group;
                        groupCheck = false;
                        break;
                    case "AuditoriesColumn":
                        titleListAuditorys = aud;
                        auditoryCheck = false;
                        break;
                    case "DisciplineColumn":
                        titleListDiscipline = dis;
                        disciplineCheck = false;
                        break;
                    case "KafColumn":
                        titleListKafedra = kaf;
                        kafedraCheck = false;
                        break;
                    case "OwnersColumn":
                        titleListOwners = own;
                        ownersCheck = false;
                        break;
                    case "NtColumn":
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
                        break;
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

        private void MergeList_Click(object sender, EventArgs e)
        {
            if (zanlist.Count != 0)
            {
                dZanlist.Add(dZanlist.Select(x => x.Key).Max() + 1, zanlist.ToArray());
                zanlist.Clear();
            }
        }

        private void InformationDGV_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            switch (InformationDGV.Columns[e.ColumnIndex].Name)
            {
                case "HColumn":
                    foreach (var item in nagr.Where(item => item.id == (int)InformationDGV["IdColumn", e.RowIndex].Value))
                    {
                        item.h = (int)InformationDGV[e.ColumnIndex, e.RowIndex].Value;
                    }
                    break;

                case "NtColumn":
                    foreach (var item in nagr.Where(item => item.id == (int)InformationDGV["IdColumn", e.RowIndex].Value))
                    {
                        item.nt = (int)InformationDGV[e.ColumnIndex, e.RowIndex].Value;
                    }
                    break;

                case "KafColumn":
                    foreach (var item in nagr.Where(item => item.id == (int)InformationDGV["IdColumn", e.RowIndex].Value))
                    {
                        item.kaf = (string)InformationDGV[e.ColumnIndex, e.RowIndex].Value;
                    }
                    break;

                case "DisciplineColumn":
                    foreach (var item in nagr.Where(item => item.id == (int)InformationDGV["IdColumn", e.RowIndex].Value))
                    {
                        item.discipline = (string)InformationDGV[e.ColumnIndex, e.RowIndex].Value;
                    }
                    break;

                case "OwnersColumn":
                    foreach (var item in nagr.Where(item => item.id == (int)InformationDGV["IdColumn", e.RowIndex].Value))
                    {
                        item.owners = ((string)InformationDGV[e.ColumnIndex, e.RowIndex].Value).Split(';');
                    }
                    break;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            (InformationDGV.DataSource as BindingListView<ScheduleRowDataGridRowItem>).ApplyFilter(x =>
            {
                bool allResult = true;

                if (list1.Count() > 0)
                {
                    if (list1.Contains(x.Id.ToString()))
                        allResult = true;
                    else
                        allResult = false;
                }
                return allResult;
            });

            list1.Clear();
        }
    }
}