using Billing_System.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Billing_System.View
{
    public partial class frmPurchase : SampleView
    {
        public frmPurchase()
        {
            InitializeComponent();
        }

        private void frmPurchase_Load(object sender, EventArgs e)
        {

        }

        private async void LoadData()
        {
            string qry = @"
                        SELECT 0 AS 'Sr', mainID, mdate AS 'Date', mDueDate AS 'Due Date', 
                               s.sName AS 'Supplier Name', mTotal AS 'Gross Amount', 
                               Discount, NetAmount AS 'Net Amount'
                        FROM tblInvMain m
                        INNER JOIN tblSupplier s ON m.PersonID = s.supID
                        WHERE mType = 'Purchase' 
                        AND sName LIKE '%' + txtSearch.Text + '%' 
                        ORDER BY mainID";


            DataTable dt = null;

            // Run the data-fetching task asynchronously
            await Task.Run(() =>
            {
                // Fetch data in the background thread
                dt = MainClass.Functions.GetData(qry);
            });

            // Update the DataGridView on the UI thread
            if (guna2DataGridView1.InvokeRequired)
            {
                guna2DataGridView1.Invoke((MethodInvoker)delegate
                {
                    guna2DataGridView1.DataSource = dt;
                    SetSrColumnWidth(); // Call this after data is loaded
                });
            }
            else
            {
                guna2DataGridView1.DataSource = dt;
                SetSrColumnWidth(); // Call this after data is loaded
            }
        }

        // Method to adjust the "Sr" column width
        private void SetSrColumnWidth()
        {
            if (guna2DataGridView1.Columns["Sr#"] != null)
            {
                guna2DataGridView1.Columns["Sr#"].Width = 80; // Adjust the width
            }
            if (guna2DataGridView1.Columns["proID"] != null)
            {
                guna2DataGridView1.Columns["proID"].Width = 80; // Adjust the width of "proID"
            }
        }

        public override void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        public override void btnAdd_Click(object sender, EventArgs e)
        {
            new frmPurchaseAdd().ShowDialog();
            LoadData();
        }

        public override void guna2DataGridView1_DoubleClick(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(guna2DataGridView1.CurrentRow.Cells[1].Value);
            new frmPurchaseAdd() { editID = id }.ShowDialog();
            LoadData();
        }
    }
}
