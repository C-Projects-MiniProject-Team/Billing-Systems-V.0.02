using Guna.UI2.WinForms;
using Guna.UI2.WinForms.Suite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Services.Description;
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

                    // CellClick Method එකේ
                    if (selectedRow.Cells["Balance"].Value != null)
                    {
                        NetAmount.Text = selectedRow.Cells["Balance"].Value.ToString();
                    }

                    // 🟡 Remove this line or change to:
                    if (string.IsNullOrWhiteSpace(description.Text))
                    {
                        description.Text = "Receipt for Invoice #" + mainID.Text; // Or any default message
                    }


                    // ✅ Optional: Clear description for every new selection
                    description.Text = string.Empty;
                }
            }
        }

        private int lastSelectedRow = -1;




        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex != lastSelectedRow)
            {
                lastSelectedRow = e.RowIndex;

                var selectedRow = guna2DataGridView1.Rows[e.RowIndex];
                // After invoice row selection
                if (selectedRow.Cells["mainID"].Value != null)
                {
                    mainID.Text = selectedRow.Cells["mainID"].Value.ToString();

                    if (selectedRow.Cells["Balance"].Value != null)
                        NetAmount.Text = selectedRow.Cells["Balance"].Value.ToString();

                    // Auto fill description if empty
                    if (string.IsNullOrWhiteSpace(description.Text))
                        description.Text = $"Payment for Invoice #{mainID.Text}";
                }

            }
        }



        private void PersonID_SelectedIndexChanged(object sender, EventArgs e)
        {
            lastSelectedRow = -1;

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


            // Auto-select first row and fill data if rows exist
            if (guna2DataGridView1.Rows.Count > 0)
            {
                // Select first row
                guna2DataGridView1.ClearSelection();
                guna2DataGridView1.Rows[0].Selected = true;

                var firstRow = guna2DataGridView1.Rows[0];

                if (firstRow.Cells["mainID"].Value != null)
                {
                    mainID.Text = firstRow.Cells["mainID"].Value.ToString();
                }

                if (firstRow.Cells["Balance"].Value != null)
                {
                    NetAmount.Text = firstRow.Cells["Balance"].Value.ToString();
                }

                description.Text = $"Payment for Invoice #{mainID.Text}";
            }





        }







        public override async void btnSave_Click(object sender, EventArgs e)
        {

            // Validate: 1. Customer selected?
            if (PersonID.SelectedIndex == -1 || string.IsNullOrWhiteSpace(PersonID.Text))
            {
                guna2MessageDialog1.Parent = this;
                guna2MessageDialog1.Icon = MessageDialogIcon.Warning;
                guna2MessageDialog1.Style = MessageDialogStyle.Dark;
                guna2MessageDialog1.Caption = "Billing System";
                guna2MessageDialog1.Text = "Please select a customer!";
                guna2MessageDialog1.Buttons = MessageDialogButtons.OK;
                guna2MessageDialog1.Show();
                return;
            }

            // Validate: 2. Row selected in table?
            if (guna2DataGridView1.SelectedRows.Count == 0)
            {
                guna2MessageDialog1.Parent = this;
                guna2MessageDialog1.Icon = MessageDialogIcon.Warning;
                guna2MessageDialog1.Style = MessageDialogStyle.Dark;
                guna2MessageDialog1.Caption = "Billing System";
                guna2MessageDialog1.Text = "Please select an invoice from the list!";
                guna2MessageDialog1.Buttons = MessageDialogButtons.OK;
                guna2MessageDialog1.Show();
                return;
            }

            // Validate: 3. Description filled?
            if (string.IsNullOrWhiteSpace(description.Text))
            {
                guna2MessageDialog1.Parent = this;
                guna2MessageDialog1.Icon = MessageDialogIcon.Warning;
                guna2MessageDialog1.Style = MessageDialogStyle.Dark;
                guna2MessageDialog1.Caption = "Billing System";
                guna2MessageDialog1.Text = "Please enter a description!";
                guna2MessageDialog1.Buttons = MessageDialogButtons.OK;
                guna2MessageDialog1.Show();
                return;
            }

            // Validate: 4. NetAmount valid?
            if (string.IsNullOrWhiteSpace(NetAmount.Text) || !decimal.TryParse(NetAmount.Text, out decimal amount) || amount <= 0)
            {
                guna2MessageDialog1.Parent = this;
                guna2MessageDialog1.Icon = MessageDialogIcon.Warning;
                guna2MessageDialog1.Style = MessageDialogStyle.Dark;
                guna2MessageDialog1.Caption = "Billing System";
                guna2MessageDialog1.Text = "Please enter a valid amount!";
                guna2MessageDialog1.Buttons = MessageDialogButtons.OK;
                guna2MessageDialog1.Show();
                return;
            }

            // Proceed if all validations are passed
            await Task.Run(() =>
            {
                if (mainID.Text == "0") return;

                if (!MainClass.Functions.Validatation(this)) return;

                if (editID == 0)
                    MainClass.Functions.AutoSQL(this, "tblReceipt", MainClass.Functions.enmType.Insert, editID);
                else
                    MainClass.Functions.AutoSQL(this, "tblReceipt", MainClass.Functions.enmType.Update, editID);
            });

            // Reset form after save
            // Reset UI
            Invoke(new Action(() =>
            {
                MainClass.Functions.ClearAll(this);
                mainID.Text = "0";
                editID = 0;

                // Clear DataGrid to stop SelectionChanged event
                guna2DataGridView1.DataSource = null;
                guna2DataGridView1.ClearSelection();

                // Clear manually
                description.Text = "";
                NetAmount.Text = "";

                // Reset supplier dropdown
                PersonID.SelectedIndex = -1;

                // Show success message
                ShowMsg("Payment saved successfully!", MessageDialogIcon.Information);
            }));


        }


        private void ShowMsg(string message, MessageDialogIcon icon)
        {
            guna2MessageDialog1.Parent = this;
            guna2MessageDialog1.Style = MessageDialogStyle.Dark;
            guna2MessageDialog1.Icon = icon;
            guna2MessageDialog1.Caption = "Billing System";
            guna2MessageDialog1.Text = message;
            guna2MessageDialog1.Buttons = MessageDialogButtons.OK;
            guna2MessageDialog1.Show();
        }



        public override void btnDelete_Click(object sender, EventArgs e)
        {
            MainClass.Functions.AutoSQL(this, "tblReceipt", MainClass.Functions.enmType.Delete, editID);
            editID = 0;
            MainClass.Functions.ClearAll(this);
        }











    }
}
