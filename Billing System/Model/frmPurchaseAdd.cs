using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.AxHost;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace Billing_System.Model
{
    public partial class frmPurchaseAdd : SampleAdd
    {
        public frmPurchaseAdd()
        {
            InitializeComponent();
        }

        // For search product gridview
        private DataTable dataTable;

        private void frmPurchaseAdd_Load(object sender, EventArgs e)
        {
            // Set today's date for the Date and Due Date fields
            mdate.Value = DateTime.Now; // Set Date to today's date
            mDueDate.Value = DateTime.Now.AddDays(7); // Set Due Date to 7 days from today (if you want)

            // Add Supplier to combobox
            string qry = "Select supID 'id', sName 'name' from tblSupplier";
            //CBFill
            MainClass.Functions.CBFfill(qry, PersonID);

            string qry1 = @"Select proID, pName 'Product', pCost 'Cost' from tblProduct order by pName";
            dataTable = MainClass.Functions.GetTable(qry1);
            guna2DataGridView2.DataSource = dataTable;
            guna2DataGridView2.Columns[0].Visible = false; //hide id column
            guna2DataGridView2.Columns[2].Width = 90; // product Name
            guna2DataGridView2.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(35, 112, 248);

            // For edit load Data
            if (editID > 0)
            {
                string qry2 = @"SELECT detailID, d.proID, pName, qty, Price, Amount 
                         FROM tblInvDetail d 
                         INNER JOIN tblProduct p ON p.proID = d.proID 
                         WHERE d.mainID = " + editID;

                MainClass.Functions.LoadForEdit2(this, "tblInvMain", qry2, guna2DataGridView1, editID);
            }
        }


        private void GrandTotal()
        {
            Double tot = 0;
            Double gtot = 0;
            mTotal.Text = "00";

            foreach (DataGridViewRow row in guna2DataGridView1.Rows)
            {
                double.TryParse(Convert.ToString(row.Cells["Amount"].Value), out tot);
                gtot += tot;
            }

            mTotal.Text = gtot.ToString("N0");

            double amt = 0;
            double dis = 0;

            double.TryParse(mTotal.Text, out amt);
            double.TryParse(Discount.Text, out dis);

            NetAmount.Text = (amt - dis).ToString("N2"); // Keeps two decimal places

        }

        private void guna2DataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            // This will calculate amount by multiplying qty cell with price cell
            int row = guna2DataGridView1.CurrentCell.RowIndex;
            double price, qty = 0;

            double.TryParse(Convert.ToString(guna2DataGridView1.Rows[row].Cells[5].Value), out price);
            double.TryParse(Convert.ToString(guna2DataGridView1.Rows[row].Cells[4].Value), out qty);

            guna2DataGridView1.Rows[row].Cells[6].Value = qty * price;

        }

        private void guna2DataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // When clicking on search grid, add the selected row values to gridview1
            if (guna2DataGridView1.CurrentCell.ColumnIndex == 3)
            {
                int row = guna2DataGridView1.CurrentCell.RowIndex;

                // Insert values into gridview1
                guna2DataGridView1.Rows[row].Cells[2].Value = guna2DataGridView2.CurrentRow.Cells[0].Value; // pro ID
                guna2DataGridView1.Rows[row].Cells[5].Value = guna2DataGridView2.CurrentRow.Cells[2].Value; // price
                guna2DataGridView1.CurrentCell.Value = guna2DataGridView2.CurrentRow.Cells[1].Value; // product name

                guna2DataGridView2.Visible = false;

                if (Convert.ToString(guna2DataGridView1.Rows[row].Cells[1].Value) == string.Empty)
                {
                    guna2DataGridView1.Rows[row].Cells[1].Value = 0; // If ID is null, set it to 0
                }

                GrandTotal();
            }

        }

        private void guna2DataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            // When clicking on a cell, make the search GridView visible
            guna2DataGridView2.Visible = false;

            if (guna2DataGridView1.CurrentCell.ColumnIndex == 3)
            {
                if (e.Control is TextBox)
                {
                    TextBox textBox = (TextBox)e.Control;
                    textBox.TextChanged -= textBox_TextChanged;
                    textBox.TextChanged += textBox_TextChanged;
                }
            }
            if (guna2DataGridView1.CurrentCell.ColumnIndex == 5) {

                int row = guna2DataGridView1.CurrentCell.RowIndex;

                double price, qty = 0;

                double.TryParse(Convert.ToString(guna2DataGridView1.Rows[row].Cells[5].Value), out price);
                double.TryParse(Convert.ToString(guna2DataGridView1.Rows[row].Cells[4].Value), out qty);

                guna2DataGridView1.Rows[row].Cells[6].Value = qty * price;

            }
            GrandTotal();
        }


        private void textBox_TextChanged(object sender, EventArgs e)
        {
            // Check if the column is product name, then make the search grid appear
            int colIndex = guna2DataGridView1.CurrentCell.ColumnIndex;
            TextBox textBox = (TextBox)sender;
            string content = textBox.Text;

            if (colIndex == 3)
            {
                guna2DataGridView2.Visible = true;

                // Filter grid 2
                DataView dataView = dataTable.DefaultView;
                dataView.RowFilter = string.Format("Product LIKE '%{0}%'", content);


                // Check current cell location and display grid under the cell
                Rectangle cellRect = guna2DataGridView1.GetCellDisplayRectangle(guna2DataGridView1.CurrentCell.ColumnIndex,
                                     guna2DataGridView1.CurrentCell.RowIndex, false);

                int centerX = cellRect.Left + 30;
                int centerY = cellRect.Top + 230;

                guna2DataGridView2.Location = new Point(centerX, centerY);
            }


            guna2DataGridView2.CellClick += guna2DataGridView2_CellClick;


        }

        private void guna2DataGridView2_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            MainClass.Functions.SrNo(guna2DataGridView1);
        }

        private void Discount_TextChanged(object sender, EventArgs e)
        {
            double amt = 0;
            double dis = 0;

            double.TryParse(mTotal.Text, out amt);
            double.TryParse(Discount.Text, out dis);

            NetAmount.Text = (amt - dis).ToString("N0");
            

        }




        public override void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // Check if proID is available in the DataGridView
                int proID = Convert.ToInt32(guna2DataGridView1.Rows[0].Cells["proID"].Value);

                // If proID is invalid or DBNull, show an error
                if (proID == 0)
                {
                    MessageBox.Show("Invalid Product ID!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;  // Exit the method if proID is invalid
                }

                // If editID is 0, it's an Insert operation, else it's an Update
                if (editID == 0)
                {
                    // Insert query call if new record
                    MainClass.Functions.SQlAuto2(this, "tblInvMain", "tblInvDetail", guna2DataGridView1, editID, MainClass.Functions.enmType.Insert);
                    MessageBox.Show("RecordX inserted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    
                    MainClass.Functions.Reset_All(this);
                }
                else
                {
                    // Update query call if existing record
                    MainClass.Functions.SQlAuto2(this, "tblInvMain", "tblInvDetail", guna2DataGridView1, editID, MainClass.Functions.enmType.Update);
                    MessageBox.Show("Record updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                   // MainClass.Functions.Reset_All(this);
                }

                // After saving or updating, reset all fields and clear the DataGridView
                if (guna2DataGridView1.Rows.Count > 0)
                {
                    guna2DataGridView1.Rows.Clear(); // Clear rows of the DataGridView
                    editID = 0;
                    MainClass.Functions.Reset_All(this);
                    mTotal.Text = "00";
                    NetAmount.Text = "00";
                    Discount.Text = "00";
                }

                editID = 0;
            }
            catch (Exception ex)
            {
                // Handle any exception and display error message
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }








        public override void btnDelete_Click(object sender, EventArgs e)
        {
            MainClass.Functions.SQlAuto2(this, "tblInvMain", "tblInvDetail", guna2DataGridView1, editID, MainClass.Functions.enmType.Delete);
            guna2DataGridView1.Rows.Clear();
            editID = 0;
            MainClass.Functions.Reset_All(this);

        }



        public override void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void label4_Click(object sender, EventArgs e)
        {

        }


        private void mdate_ValueChanged(object sender, EventArgs e)
        {
            MainClass.Functions.MaskD(mdate); // Correct method for Guna2DateTimePicker
        }

        private void mDueDate_ValueChanged(object sender, EventArgs e)
        {
            MainClass.Functions.MaskD(mDueDate); // Correct method for Guna2DateTimePicker
        }





    }
}
