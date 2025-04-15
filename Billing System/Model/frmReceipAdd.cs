using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Billing_System.Model
{
    public partial class frmReceipAdd : SampleAdd
    {
        public frmReceipAdd()
        {
            InitializeComponent();
        }

        private void frmReceipAdd_Load(object sender, EventArgs e)
        {
            mainID.Text = "0";

            PersonID.SelectedIndexChanged -= PersonID_SelectedIndexChanged;

            string qry = "SELECT cusID 'id', cName 'name' FROM tblCustomer";
            MainClass.Functions.CBFill(qry, PersonID);

            if (editID > 0)
            {
                MainClass.Functions.AutoLoadForEdit(this, "tblReceipt", editID);
            }

            PersonID.SelectedIndexChanged += PersonID_SelectedIndexChanged;

            // Prevent duplicate events
            guna2DataGridView1.SelectionChanged -= guna2DataGridView1_SelectionChanged;

            // frmPaymentAdd_Load() method 
            guna2DataGridView1.SelectionChanged += guna2DataGridView1_SelectionChanged;
        }

        private void mdate_ValueChanged(object sender, EventArgs e)
        {
            MainClass.Functions.MaskD(mdate);
        }




        private void guna2DataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (guna2DataGridView1.SelectedRows.Count > 0)
            {
                var selectedRow = guna2DataGridView1.SelectedRows[0];
                if (selectedRow.Cells["mainID"].Value != null)
                {
                    mainID.Text = selectedRow.Cells["mainID"].Value.ToString();
                    Console.WriteLine("Selected row mainID: " + mainID.Text);
                }
            }
        }

        private void PersonID_SelectedIndexChanged(object sender, EventArgs e)
        {
            lastRowIndex = -1;

            int partyID = (PersonID.SelectedIndex == -1) ? 0 : Convert.ToInt32(PersonID.SelectedValue);


            guna2DataGridView1.DataSource = null;
            string qry = @"
                            SELECT 0 AS 'Sr#', 
                                   m.mainID, 
                                   m.NetAmount AS 'Invoice Amount',
                                   (SELECT ISNULL(SUM(r.NetAmount), 0) FROM tblReceipt r WHERE r.mainID = m.mainID) AS 'Receipt',
                                   m.NetAmount - (SELECT ISNULL(SUM(r.NetAmount), 0) FROM tblReceipt r WHERE r.mainID = m.mainID) AS 'Balance'
                            FROM tblInvMain m
                            WHERE m.NetAmount - (SELECT ISNULL(SUM(r.NetAmount), 0) FROM tblReceipt r WHERE r.mainID = m.mainID) <> 0
                              AND m.mType <> 'Cash'
                              AND m.mType = 'Sale'
                              AND m.PersonID = " + partyID;



            MainClass.Functions.LoadData(qry, guna2DataGridView1);



            if (guna2DataGridView1.Columns.Contains("mainID"))
            {
                guna2DataGridView1.Columns["mainID"].Visible = true;
            }
        }

        private int lastRowIndex = -1;



        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {


            if (e.RowIndex >= 0)
            {
                int row = guna2DataGridView1.CurrentCell.RowIndex;
                mainID.Text = guna2DataGridView1.CurrentRow.Cells[1].Value.ToString();
            }



        }


        public override async void btnSave_Click(object sender, EventArgs e)
        {
            await Task.Run(() =>
            {
                if (mainID.Text == "0") return;

                if (!MainClass.Functions.Validatation(this)) return;

                if (editID == 0)
                    MainClass.Functions.AutoSQL(this, "tblReceipt", MainClass.Functions.enmType.Insert, editID);
                else
                    MainClass.Functions.AutoSQL(this, "tblReceipt", MainClass.Functions.enmType.Update, editID);
            });

            Invoke(new Action(() =>
            {
                MainClass.Functions.ClearAll(this);
                mainID.Text = "0";
                editID = 0;
                guna2DataGridView1.ClearSelection();
            }));
        }









        public override void btnDelete_Click(object sender, EventArgs e)
        {
            MainClass.Functions.AutoSQL(this, "tblReceipt", MainClass.Functions.enmType.Delete, editID);
            editID = 0;
            MainClass.Functions.ClearAll(this);
        }











    }
}
