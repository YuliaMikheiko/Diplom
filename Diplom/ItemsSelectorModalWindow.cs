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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp2
{
    public partial class ItemsSelectorModalWindow : Form
    {

        public List<int?> idsList;
        public List<string> TitleList;

        ScheduleRow nagr;

        Dictionary<int, Teacher> teachers;
        Dictionary<int, Auditory> auditories;
        Dictionary<int, SubGroup> sub_groups_info;

        //DataTable dtSales = new DataTable();
       // string filterField = "Country";

        internal ItemsSelectorModalWindow(int type, ScheduleRow nagr, ScheduleDataModel scheduleDataModel)
        {
            InitializeComponent();
            this.nagr = nagr;

            teachers = scheduleDataModel.GetTeachers();
            auditories = scheduleDataModel.GetAuditories();
            sub_groups_info = scheduleDataModel.GetGroups();

            if (type == 1)
                ReadTeachers();
            else if (type == 2)
                ReadGroups();
            else
                ReadAuditorys();
        }

        private void ReadTeachers()
        {
            ItemsDGV.DataSource = teachers.Select(x => new RowCheckedItem
            {
                Key = x.Key,
                Value = x.Value.name,
                Checked = nagr.teachers.Contains(x.Key),
            }).OrderByDescending(x =>x.Checked).ToList();

           // dtSales = (DataTable)ItemsDGV.DataSource;
        }

        private void ReadGroups()
        {
            ItemsDGV.DataSource = sub_groups_info.Select(x => new RowCheckedItem
            {
                Key = x.Key,
                Value = x.Value.title,
                Checked = nagr.sub_groups.Contains(x.Key),
            }).OrderByDescending(x => x.Checked).ToList();
        }

        private void ReadAuditorys()
        {
            ItemsDGV.DataSource = auditories.Select(x => new RowCheckedItem
            {
                Key = x.Key,
                Value = x.Value.title,
                Checked = nagr.auds.Contains(x.Key),
            }).OrderByDescending(x => x.Checked).ToList();
        }

        private void Choice_Click(object sender, EventArgs e)
        {
            idsList = new List<int?>();
            TitleList = new List<string>();

            var items = (ItemsDGV.DataSource as List<RowCheckedItem>).Where(x => x.Checked);

            foreach (DataGridViewRow rows in ItemsDGV.Rows)
            {
                if (rows.Cells[0].Value != null)
                {
                    if ((bool)rows.Cells[0].Value)
                    {
                        idsList.Add((int)rows.Cells[1].Value);
                    }
                }
            }
            TitleList = items.Select(x => x.Value).ToList();


            this.DialogResult = DialogResult.OK;
        }

        //private void filter_TextChanged(object sender, EventArgs e)
        //{
        //    dtSales.DefaultView.RowFilter = string.Format("[{0}] LIKE '%{1}%'", filterField, filter.Text);
        //}
    }

    public class RowCheckedItem
    {
        public bool Checked { get; set; }
        public int Key { get; set; }
        public string Value { get; set; }
    }
}
