using Billing_System;
using Guna.UI2.WinForms;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using static System.Windows.Forms.AxHost;


namespace MainClass
{
    class Functions
    {

        //Creat Connection ------
        public static string MsgCaption = "Billing System"; // Add this if needed
        public static string conString = "Data Source=LAHIRU\\SQLEXPRESS;Initial Catalog=BillingSystem;Integrated Security=True";
        public static SqlConnection con = new SqlConnection(conString);


        public static DataTable GetDataTable(string query)
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(conString))
            {
                try
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(dt);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error fetching data: " + ex.Message);
                }
                finally
                {
                    con.Close();
                }
            }

            return dt;
        }


        public static DataTable GetTable(string query)
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(conString))
            {
                try
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(dt);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error fetching table data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    con.Close();
                }
            }

            return dt;
        }


        public static object GetFieldValue(string query)
        {
            object value = null;

            using (SqlConnection con = new SqlConnection(conString))
            {
                try
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        value = cmd.ExecuteScalar(); // ExecuteScalar returns a single value
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error fetching field value: " + ex.Message);
                }
                finally
                {
                    con.Close();
                }
            }

            return value;
        }




        public static void CBFillCombo(string qry, ComboBox cb)
        {
            try
            {
                cb.Items.Clear(); // Clear existing items before loading new data

                SqlCommand cmd = new SqlCommand(qry, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    cb.DisplayMember = "RoleName";  // Column name for the role name
                    cb.ValueMember = "RoleID";      // Column name for the role ID
                    cb.DataSource = dt;
                }

                cb.SelectedIndex = -1; // Avoid auto-selecting the first item
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in CBFillCombo: " + ex.Message);
            }
        }




        //login validation------------------------------------------------------------

        public static bool Validate(Form form)
        {
            bool isValid = true;

            // පරණ validation labels අයින් කරන්න
            var dynamicLabels = form.Controls.OfType<Label>()
                                              .Where(c => c.Tag != null && c.Tag.ToString() == "remove")
                                              .ToList();
            foreach (var lbl in dynamicLabels)
            {
                form.Controls.Remove(lbl);
            }

            // සියලු TextBox වල value පරීක්ෂා කිරීම
            foreach (Control control in form.Controls)
            {
                if (control is Guna.UI2.WinForms.Guna2TextBox textBox)
                {
                    // TextBox එක හිස් නම්
                    if (string.IsNullOrWhiteSpace(textBox.Text))
                    {
                        isValid = false;

                        // "Required" කියන label එකක් යොදයි
                        Label lblError = new Label
                        {
                            Text = "Required",
                            ForeColor = Color.Red,
                            Font = new Font("Segoe UI", 9, FontStyle.Regular),
                            AutoSize = true,
                            Tag = "remove"
                        };

                        // Label එක TextBox එකේ පහළින් පෙන්වයි
                        lblError.Location = new Point(textBox.Location.X, textBox.Location.Y + textBox.Height + 2);
                        form.Controls.Add(lblError);
                    }
                }
            }

            return isValid;
        }








        // Database එකෙන් username එකට අදාල encrypted password එක ලබාගැනීම
        private static string GetEncryptedPassword(string username)
        {
            string encryptedPassword = null;
            string query = "SELECT uPass FROM tblUser WHERE uName = @username";

            using (SqlConnection con = new SqlConnection(conString))
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@username", username);
                try
                {
                    con.Open();
                    encryptedPassword = cmd.ExecuteScalar() as string;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error fetching password: " + ex.Message);
                }
            }

            return encryptedPassword;
        }






        //GetData
        // Username සහ Password validate කරන විධිය
        public static bool IsValidUser(string username, string password)
        {
            // Database එකෙන් encrypted password එක ගන්න
            string encryptedPassword = GetEncryptedPassword(username);

            if (encryptedPassword == null)
            {
                return false; // Username එක database එකේ නැත්නම්
            }

            // Encrypted password එක decrypt කර password එක සසඳන්න
            string decryptedPassword = SecurityFunctions.DecryptPassword(encryptedPassword);

            // User එකෙන් ලැබුණු password එක decrypt කරගත් password එක සමඟ සසඳන්න
            return password == decryptedPassword;
        }





        // For Insert, Update, Delete
        public static int SQL(string qry, Hashtable ht)
        {
            int res = 0;

            try
            {
                SqlCommand cmd = new SqlCommand(qry, con);
                cmd.CommandType = CommandType.Text;

                foreach (DictionaryEntry item in ht)
                {
                    cmd.Parameters.AddWithValue(item.Key.ToString(), item.Value);
                }

                if (con.State == ConnectionState.Closed) { con.Open(); }
                res = cmd.ExecuteNonQuery();
                if (con.State == ConnectionState.Open) { con.Close(); }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                con.Close();
            }

            return res;
        }

        // Method to fetch data from the database
        public static DataTable GetData(string qry)
        {
            try
            {
                SqlCommand cmd = new SqlCommand(qry, con);
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);  // Fill the DataTable with data
                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);  // Show error message
                return null;
            }
        }




        public static void CBFill(string qry, ComboBox cb)
        {
            try
            {
                SqlCommand cmd = new SqlCommand(qry, Functions.con);
                cmd.CommandType = CommandType.Text;

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                cb.DisplayMember = "name";
                cb.ValueMember = "id";
                cb.DataSource = dt;
                cb.SelectedIndex = 0;
                cb.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                Functions.con.Close();
                MessageBox.Show(ex.Message);
            }
        }


        public static void loadData(string qry, DataGridView gv, ListBox lb)
        {
            try
            {
                SqlCommand cmd = new SqlCommand(qry, Functions.con);
                cmd.CommandType = System.Data.CommandType.Text;

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                for (int i = 0; i < lb.Items.Count; i++)
                {
                    string colName1 = ((DataGridViewColumn)lb.Items[i]).Name;
                    gv.Columns[colName1].DataPropertyName = dt.Columns[i].ToString();
                }

                gv.DataSource = dt;
            }
            catch (Exception ex)
            {
                Functions.con.Close();
                MessageBox.Show(ex.ToString());
            }
        }

        public static void LoadData(string qry, DataGridView gv)
        {
            // Serial no in gridview
            gv.CellFormatting += new DataGridViewCellFormattingEventHandler(gv_CellFormatting);

            try
            {
                SqlCommand cmd = new SqlCommand(qry, con);
                cmd.CommandType = CommandType.Text;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                gv.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                con.Close();
            }
        }

        private static void gv_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            Guna.UI2.WinForms.Guna2DataGridView gv = (Guna.UI2.WinForms.Guna2DataGridView)sender;
            int count = 0;

            foreach (DataGridViewRow row in gv.Rows)
            {
                count++;
                row.Cells[0].Value = count;
            }
        }


        //Clear...............................
        public static void ClearAll(Form F)
        {
            foreach (Control c in F.Controls)
            {
                Type type = c.GetType();

                if (type == typeof(Guna.UI2.WinForms.Guna2TextBox))
                {
                    Guna.UI2.WinForms.Guna2TextBox t = (Guna.UI2.WinForms.Guna2TextBox)c;
                    t.Text = "";
                }
                else if (type == typeof(Guna.UI2.WinForms.Guna2ComboBox))
                {
                    Guna.UI2.WinForms.Guna2ComboBox cb = (Guna.UI2.WinForms.Guna2ComboBox)c;
                    cb.SelectedIndex = -1;
                }
                else if (type == typeof(CheckBox))
                {
                    ((CheckBox)c).Checked = false;
                }
                else if (type == typeof(PictureBox)) // Clear PictureBox image
                {
                    PictureBox pb = (PictureBox)c;
                    pb.Image = null; // Or reset to a default image
                }
                // Add any other control types as needed
            }
        }



        public static void BlurBackground(Form Model)
        {
            Form Background = new Form();
            using (Model)
            {
                Background.StartPosition = FormStartPosition.Manual;
                Background.FormBorderStyle = FormBorderStyle.None;
                Background.Opacity = 0.5d;
                Background.BackColor = Color.Black;
                //Background.Size = frmMain.Instance.Size;
                //Background.Location = frmMain.Instance.Location;
                Background.ShowInTaskbar = false;
                Background.Show();
                Model.Owner = Background;
                Model.ShowDialog(Background);
                Background.Dispose();
            }
        }

        // Combo box fill
        public static void CBFfill(string qry, ComboBox cb)
        {
            SqlCommand cmd = new SqlCommand(qry, con);
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            cb.DisplayMember = "name";
            cb.ValueMember = "id";
            cb.DataSource = dt;
            cb.SelectedIndex = -1;
        }





        public static void SrNo(Guna.UI2.WinForms.Guna2DataGridView gv)
        {
            try
            {
                int count = 0;
                foreach (DataGridViewRow row in gv.Rows)
                {
                    count++;
                    row.Cells[0].Value = count;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                con.Close();
            }
        }





        private static Color vColor = Color.FromArgb(245, 29, 70); // Error color

        // Validation function for form controls
        public static bool Validatation(Form F)
        {
            bool isValid = true;
            int count = 0; // Counter to track number of invalid fields
            int x, y;

            // Remove old validation labels
            var dynamicLabels = F.Controls.OfType<Label>()
                                          .Where(c => c.Tag != null && c.Tag.ToString() == "remove")
                                          .ToList();
            foreach (var lbl in dynamicLabels)
            {
                F.Controls.Remove(lbl);
            }

            // Iterate over each control in the form
            foreach (Control c in F.Controls)
            {
                if (c is Guna.UI2.WinForms.Guna2Button)
                {
                    // Skip validation for buttons
                }
                else
                {
                    if (c.Tag == null || c.Tag.ToString() == string.Empty)
                    {
                        // Skip controls without tags
                    }
                    else
                    {
                        Label lbl1 = new Label();
                        lbl1.Font = new Font("Segoe UI", 10, FontStyle.Regular);
                        lbl1.AutoSize = true;

                        // Validation for Guna2TextBox controls
                        if (c is Guna.UI2.WinForms.Guna2TextBox t)
                        {
                            if (t.AutoRoundedCorners)
                            {
                                x = int.Parse(c.Location.X.ToString()) + 10;
                                y = int.Parse(c.Location.Y.ToString()) + 5 + int.Parse(c.Height.ToString());
                            }
                            else
                            {
                                x = int.Parse(c.Location.X.ToString());
                                y = int.Parse(c.Location.Y.ToString()) + 5 + int.Parse(c.Height.ToString());
                            }

                            // Check if textbox is empty
                            if (t.Text == "")
                            {
                                string cname = "lbl" + c.Name;
                                lbl1.Name = cname;
                                lbl1.Tag = "remove";
                                lbl1.Text = "Required";
                                lbl1.ForeColor = vColor;
                                F.Controls.Add(lbl1);
                                lbl1.Location = new System.Drawing.Point(x, y);
                                count++;
                            }

                            // Email validation
                            if (t.Tag.ToString() == "e" && t.Text != "")
                            {
                                Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
                                Match match = regex.Match(t.Text);
                                if (!match.Success)
                                {
                                    string cname = "lbl" + c.Name;
                                    lbl1.Name = cname;
                                    lbl1.Tag = "remove";
                                    lbl1.Text = "Invalid Email";
                                    lbl1.ForeColor = vColor;
                                    F.Controls.Add(lbl1);
                                    lbl1.Location = new System.Drawing.Point(x, y);
                                }
                            }

                            // Number validation
                            if (t.Tag.ToString() == "n" && t.Text != "")
                            {
                                Regex regex = new Regex(@"^(\-?\d+)([0-9\.,]*)$");
                                Match match = regex.Match(t.Text);
                                if (!match.Success)
                                {
                                    string cname = "nlbl" + c.Name;
                                    lbl1.Name = cname;
                                    lbl1.Tag = "remove";
                                    lbl1.Text = "Invalid Number";
                                    lbl1.ForeColor = vColor;
                                    lbl1.Font = new Font("Bookman Old Style", 9, FontStyle.Regular);
                                    F.Controls.Add(lbl1);
                                    lbl1.Location = new System.Drawing.Point(x, y);
                                }
                            }

                            // Date validation
                            if (t.Tag.ToString() == "d" && t.Text != "")
                            {
                                DateTime dt;
                                Regex regex = new Regex(@"^(0?[1-9]|[12][0-9]|3[01])[-/.](0?[1-9]|1[0-2])[-/.](\d{4}|\d{2})$");
                                Match match = regex.Match(t.Text);
                                DateTime.TryParse(t.Text, out dt);
                                if (!match.Success || dt == DateTime.MinValue)
                                {
                                    string cname = "dlbl" + c.Name;
                                    lbl1.Name = cname;
                                    lbl1.Tag = "remove";
                                    lbl1.Text = "Invalid Date";
                                    lbl1.ForeColor = vColor;
                                    lbl1.Font = new Font("Bookman Old Style", 9, FontStyle.Regular);
                                    F.Controls.Add(lbl1);
                                    lbl1.Location = new System.Drawing.Point(x, y);
                                    count++;
                                }
                            }
                        }

                        // Validation for ComboBox (e.g., Role selection)
                        if (c is Guna.UI2.WinForms.Guna2ComboBox comboBox)
                        {
                            if (comboBox.AutoRoundedCorners)
                            {
                                x = int.Parse(c.Location.X.ToString()) + 10;
                                y = int.Parse(c.Location.Y.ToString()) + 5 + int.Parse(c.Height.ToString());
                            }
                            else
                            {
                                x = int.Parse(c.Location.X.ToString());
                                y = int.Parse(c.Location.Y.ToString()) + 5 + int.Parse(c.Height.ToString());
                            }

                            // Check if no role is selected (SelectedIndex = -1 means no selection)
                            if (comboBox.SelectedIndex == -1)
                            {
                                string cname = "lbl" + c.Name;
                                lbl1.Name = cname;
                                lbl1.Tag = "remove";
                                lbl1.Text = "Required";
                                lbl1.ForeColor = vColor;
                                F.Controls.Add(lbl1);
                                lbl1.Location = new System.Drawing.Point(x, y);
                                count++;
                            }
                        }
                    }
                }
            }

            // If any validation failed, return false
            if (count > 0)
            {
                isValid = false;
            }

            return isValid; // Return whether the form is valid or not
        }









        public static void Enable_reset(Form p) // for resetting after save code
        {
            foreach (Control c in p.Controls)
            {
                if (c is Guna.UI2.WinForms.Guna2TextBox)
                {
                    Guna.UI2.WinForms.Guna2TextBox t = (Guna.UI2.WinForms.Guna2TextBox)c;
                    t.Text = "";
                }

                if (c is Guna.UI2.WinForms.Guna2ComboBox)
                {
                    Guna.UI2.WinForms.Guna2ComboBox cb = (Guna.UI2.WinForms.Guna2ComboBox)c;
                    cb.SelectedIndex = 0;
                    cb.SelectedIndex = -1;
                }

                if (c is Guna.UI2.WinForms.Guna2RadioButton)
                {
                    Guna.UI2.WinForms.Guna2RadioButton rb = (Guna.UI2.WinForms.Guna2RadioButton)c;
                    rb.Checked = false;
                }

                if (c is Guna.UI2.WinForms.Guna2CheckBox)
                {
                    Guna.UI2.WinForms.Guna2CheckBox chk = (Guna.UI2.WinForms.Guna2CheckBox)c;
                    chk.Checked = false;
                }

                if (c is Guna.UI2.WinForms.Guna2DateTimePicker)
                {
                    Guna.UI2.WinForms.Guna2DateTimePicker dp = (Guna.UI2.WinForms.Guna2DateTimePicker)c;
                    dp.Value = DateTime.Today;
                }

                if (c is ListBox)
                {
                    ListBox list = (ListBox)c;
                }

                if (c is NumericUpDown)
                {
                    NumericUpDown cb = (NumericUpDown)c;
                    cb.Value = 0;
                }

                if (c is MaskedTextBox)
                {
                    MaskedTextBox cb = (MaskedTextBox)c;
                    cb.Text = "";
                }
            }
        }


        public static void AutoLoadForEdit(Form form, string tableName, int id)
        {
            try
            {
                string idColumn = "";

                // Dynamically choose the correct ID column based on the table name
                if (tableName == "tblUser")
                {
                    idColumn = "userID";
                }
                else if (tableName == "tblProduct")
                {
                    idColumn = "proID";
                }

                else if (tableName == "tblCustomer")  // Added for tblCustomer
                {
                    idColumn = "cusID";
                }

                
                else if (tableName == "tblSupplier")
                {
                    idColumn = "supID";
                }

                // Ensure the ID column is defined
                if (string.IsNullOrEmpty(idColumn))
                {
                    MessageBox.Show("Invalid table name provided.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Use the correct ID column for the query
                string qry = $"SELECT * FROM {tableName} WHERE {idColumn} = @id";

                SqlCommand cmd = new SqlCommand(qry, con);
                cmd.Parameters.AddWithValue("@id", id);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];

                    // Iterate over all controls in the form
                    foreach (Control c in form.Controls)
                    {
                        // For Guna2TextBox controls
                        if (c is Guna.UI2.WinForms.Guna2TextBox t)
                        {
                            string colName = t.Name.Replace("txt", ""); // Assuming control names are txt + column names
                            if (row.Table.Columns.Contains(colName))
                            {
                                t.Text = row[colName].ToString();
                            }
                        }

                        // For PictureBox controls to load the user image
                        else if (c is PictureBox pb)
                        {
                            if (pb.Name == "picuterBoxUser" && tableName == "tblUser" && row["uImage"] != DBNull.Value)
                            {
                                byte[] imageBytes = (byte[])row["uImage"];
                                pb.Image = ByteArrayToImage(imageBytes); // Convert byte array back to image
                            }
                            else if (pb.Name == "pImage" && tableName == "tblProduct" && row["pImage"] != DBNull.Value)
                            {
                                byte[] imageBytes = (byte[])row["pImage"];
                                pb.Image = ByteArrayToImage(imageBytes); // Convert byte array back to image
                            }
                            else
                            {
                                pb.Image = null; // If no image, set PictureBox to null or a default image
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), MsgCaption);
            }
        }

        // Add the ExecuteScalar method
        public static object ExecuteScalar(string query, params SqlParameter[] parameters)
        {
            object result = null;

            using (SqlConnection conn = new SqlConnection(conString))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddRange(parameters);

                    conn.Open();
                    result = cmd.ExecuteScalar(); // Executes the query and returns the first column of the first row
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error executing scalar query: " + ex.Message);
                }
            }

            return result;
        }





        public static void AutoSQL(Form form, string tableName, enmType type, int editID)
        {
            try
            {
                string qry = string.Empty;
                Hashtable ht = new Hashtable();

                // Clear the Hashtable before adding new parameters
                ht.Clear();

                // Determine the query based on the table and the operation type
                switch (tableName)
                {
                    case "tblProduct":
                        if (type == enmType.Insert)
                        {
                            qry = $"INSERT INTO {tableName} (pName, pPrice, pCost, pImage) VALUES (@pName, @pPrice, @pCost, @pImage)";
                        }
                        else if (type == enmType.Update && editID > 0)
                        {
                            qry = $"UPDATE {tableName} SET pName = @pName, pPrice = @pPrice, pCost = @pCost, pImage = @pImage WHERE proID = @proID";
                            ht.Add("@proID", editID);
                        }
                        else if (type == enmType.Delete && editID > 0)
                        {
                            qry = $"DELETE FROM {tableName} WHERE proID = @proID";
                            ht.Add("@proID", editID);
                        }
                        break;

                    case "tblUser":
                        if (type == enmType.Insert)
                        {
                            qry = $"INSERT INTO {tableName} (uName, uRole, uPass, uPhone, uEmail, uImage) VALUES (@uName, @uRole, @uPass, @uPhone, @uEmail, @uImage)";
                        }
                        else if (type == enmType.Update && editID > 0)
                        {
                            qry = $"UPDATE {tableName} SET uName = @uName, uRole = @uRole, uPass = @uPass, uPhone = @uPhone, uEmail = @uEmail, uImage = @uImage WHERE userID = @userID";
                            ht.Add("@userID", editID);
                        }
                        else if (type == enmType.Delete && editID > 0)
                        {
                            qry = $"DELETE FROM {tableName} WHERE userID = @userID";
                            ht.Add("@userID", editID);
                        }
                        break;

                    case "tblPayment":
                        if (type == enmType.Insert)
                        {
                            // PersonID SQL query
                            string personQuery = "SELECT PersonID FROM [BillingSystem].[dbo].[tblInvMain] WHERE mainID = @mainID";
                            var personID = Functions.ExecuteScalar(personQuery, new SqlParameter("@mainID", Convert.ToInt32(form.Controls["mainID"].Text)));

                            // Add parameters if not already in the Hashtable
                            if (!ht.ContainsKey("@mainID"))
                                ht.Add("@mainID", form.Controls["mainID"].Text);

                            if (!ht.ContainsKey("@mdate"))
                                ht.Add("@mdate", form.Controls["mdate"].Text); // Add @mdate if not already added

                            if (!ht.ContainsKey("@PersonID"))
                                ht.Add("@PersonID", personID);

                            if (!ht.ContainsKey("@description"))
                                ht.Add("@description", form.Controls["description"].Text);

                            if (!ht.ContainsKey("@NetAmount"))
                                ht.Add("@NetAmount", form.Controls["NetAmount"].Text);

                            // Optionally add pType if available
                            if (!string.IsNullOrEmpty(form.Controls["pType"].Text) && !ht.ContainsKey("@pType"))
                            {
                                ht.Add("@pType", form.Controls["pType"].Text); // Add pType if not empty
                            }



                            // Now execute your SQL query
                            qry = "INSERT INTO tblPayment (mainID, mdate, PersonID, description, NetAmount) VALUES (@mainID, @mdate, @PersonID, @description, @NetAmount)";
                        }
                        break;

                    default:
                        MessageBox.Show("Invalid table name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                }

                // Loop through form controls and gather values dynamically for all fields
                foreach (Control c in form.Controls)
                {
                    if (c is Guna2TextBox txt)
                    {
                        string colName = txt.Name.Replace("txt", "");
                        if (!ht.ContainsKey("@" + colName))
                        {
                            ht.Add("@" + colName, txt.Text);
                        }
                    }
                    else if (c is Guna2ComboBox cb)
                    {
                        if (!ht.ContainsKey("@" + cb.Name))
                        {
                            ht.Add("@" + cb.Name, cb.SelectedValue);
                        }
                    }
                    else if (c is Guna2DateTimePicker dtp)
                    {
                        if (!ht.ContainsKey("@" + dtp.Name))
                        {
                            ht.Add("@" + dtp.Name, dtp.Value);
                        }
                    }
                    else if (c is PictureBox pb)
                    {
                        if (pb.Name == "picuterBoxUser") // For user images
                        {
                            if (pb.Image != null && !ht.ContainsKey("@uImage"))
                            {
                                ht.Add("@uImage", ImageToByteArray(pb.Image));
                            }
                            else
                            {
                                ht.Add("@uImage", DBNull.Value);  // If no image, add DBNull
                            }
                        }
                        else if (pb.Name == "pImage") // For product images
                        {
                            if (pb.Image != null && !ht.ContainsKey("@pImage"))
                            {
                                ht.Add("@pImage", ImageToByteArray(pb.Image));
                            }
                            else
                            {
                                ht.Add("@pImage", DBNull.Value);  // If no image, add DBNull
                            }
                        }
                    }
                }

                // Execute SQL query
                int result = SQL(qry, ht);

                // Optional: Show success message if rows were affected
                if (result > 0)
                {
                    MessageBox.Show("Operation completed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error");
            }
        }






        public static void SQlAuto2(Form form, string mainTable, string detailTable, DataGridView dgv, int editID, enmType type)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conString))
                {
                    con.Open();
                    SqlTransaction transaction = con.BeginTransaction();

                    try
                    {
                        if (type == enmType.Insert || type == enmType.Update)
                        {
                            // **INSERT OR UPDATE MAIN TABLE**
                            string mainQuery;
                            if (type == enmType.Insert)
                            {


                                mainQuery = $"INSERT INTO {mainTable} (PersonID, mdate, mDueDate, mTotal, Discount, NetAmount, mType, pType) " +
                                            "VALUES (@PersonID, @mdate, @mDueDate, @mTotal, @Discount, @NetAmount, 'Purchase', @pType); SELECT SCOPE_IDENTITY();";

                            }
                            else
                            {
                                mainQuery = $"UPDATE {mainTable} SET PersonID=@PersonID, mdate=@mdate, mDueDate=@mDueDate, " +
                                            "mTotal=@mTotal, Discount=@Discount, NetAmount=@NetAmount WHERE mainID=@mainID";
                            }


                            int mainID;
                            using (SqlCommand cmd = new SqlCommand(mainQuery, con, transaction))
                            {
                                cmd.Parameters.AddWithValue("@PersonID", ((Guna2ComboBox)form.Controls["PersonID"]).SelectedValue);
                               
                                cmd.Parameters.Add("@mdate", SqlDbType.Date).Value = ((Guna2DateTimePicker)form.Controls["mdate"]).Value;  // Use the Value property directly
                                
                                cmd.Parameters.Add("@mDueDate", SqlDbType.Date).Value = ((Guna2DateTimePicker)form.Controls["mDueDate"]).Text;
                              
                                cmd.Parameters.AddWithValue("@pType", ((Guna2ComboBox)form.Controls["pType"]).SelectedItem.ToString());
                                

                                double totalAmount, discount, netAmount;

                                // Validate and parse the Gross Amount
                                if (!double.TryParse(((Guna2TextBox)form.Controls["mTotal"]).Text.Replace(",", ""), out totalAmount))
                                {
                                    MessageBox.Show("Invalid Gross Amount!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }

                                // Validate and parse the Discount
                                if (!double.TryParse(((Guna2TextBox)form.Controls["Discount"]).Text.Replace(",", ""), out discount))
                                {
                                    MessageBox.Show("Invalid Discount!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }

                                // Calculate Net Amount, ensuring precision
                                netAmount = totalAmount - discount;

                                // Ensure that the Net Amount is formatted correctly
                                netAmount = Math.Round(netAmount, 2); // Round to 2 decimal places if necessary

                                // Assign the values to the parameters
                                cmd.Parameters.Add("@mTotal", SqlDbType.Float).Value = totalAmount;
                                cmd.Parameters.Add("@Discount", SqlDbType.Float).Value = discount;
                                cmd.Parameters.Add("@NetAmount", SqlDbType.Float).Value = netAmount;




                                if (type == enmType.Insert)
                                {
                                    mainID = Convert.ToInt32(cmd.ExecuteScalar()); // Get new inserted mainID
                                  //  MessageBox.Show("Record inserted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    //MainClass.Functions.Reset_All(form);  // Reset the form
                                }
                                else
                                {
                                    cmd.Parameters.AddWithValue("@mainID", editID);
                                    cmd.ExecuteNonQuery();
                                    mainID = editID;
                                   // MessageBox.Show("Record updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                   // MainClass.Functions.Reset_All(form);  // Reset the form
                                }

                            }

                            // **DELETE EXISTING DETAILS IF UPDATING**
                            if (type == enmType.Update)
                            {
                                string deleteDetailQuery = $"DELETE FROM {detailTable} WHERE mainID=@mainID";
                                using (SqlCommand cmd = new SqlCommand(deleteDetailQuery, con, transaction))
                                {
                                    cmd.Parameters.AddWithValue("@mainID", mainID);
                                    cmd.ExecuteNonQuery();
                                }
                            }

                            // **INSERT INTO DETAIL TABLE**
                            foreach (DataGridViewRow row in dgv.Rows)
                            {
                                if (row.IsNewRow) continue;

                                double price, amount;
                                int quantity;

                                // Validate and Convert DataGridView Row Values
                                if (!int.TryParse(row.Cells["qty"].Value.ToString(), out quantity))
                                {
                                    MessageBox.Show("Invalid Quantity!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }

                                if (!double.TryParse(row.Cells["Price"].Value.ToString().Replace(",", ""), out price))
                                {
                                    MessageBox.Show("Invalid Price!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }

                                if (!double.TryParse(row.Cells["Amount"].Value.ToString().Replace(",", ""), out amount))
                                {
                                    MessageBox.Show("Invalid Amount!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }

                                // Insert into Detail Table
                                string detailQuery = $"INSERT INTO {detailTable} (mainID, proID, qty, Price, Amount) VALUES (@mainID, @proID, @qty, @Price, @Amount)";
                                using (SqlCommand cmd = new SqlCommand(detailQuery, con, transaction))
                                {
                                    cmd.Parameters.AddWithValue("@mainID", mainID);
                                    cmd.Parameters.AddWithValue("@proID", row.Cells["proID"].Value);
                                    cmd.Parameters.Add("@qty", SqlDbType.Int).Value = quantity;
                                    cmd.Parameters.Add("@Price", SqlDbType.Float).Value = price;
                                    cmd.Parameters.Add("@Amount", SqlDbType.Float).Value = amount;
                                    cmd.ExecuteNonQuery();
                                }
                            }


                            transaction.Commit();
                            //MessageBox.Show(type == enmType.Insert ? "Record inserted successfully!" : "Record updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else if (type == enmType.Delete && editID > 0)
                        {
                            // **DELETE OPERATION**
                            DialogResult result = MessageBox.Show("Are you sure you want to delete this record?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                            if (result == DialogResult.No)
                            {
                                return;
                            }

                            // **Delete from Detail Table First**
                            string deleteDetailQuery = $"DELETE FROM {detailTable} WHERE mainID=@mainID";
                            using (SqlCommand cmd = new SqlCommand(deleteDetailQuery, con, transaction))
                            {
                                cmd.Parameters.AddWithValue("@mainID", editID);
                                cmd.ExecuteNonQuery();
                            }

                            // **Delete from Main Table**
                            string deleteMainQuery = $"DELETE FROM {mainTable} WHERE mainID=@mainID";
                            using (SqlCommand cmd = new SqlCommand(deleteMainQuery, con, transaction))
                            {
                                cmd.Parameters.AddWithValue("@mainID", editID);
                                cmd.ExecuteNonQuery();
                            }

                            transaction.Commit();
                            MessageBox.Show("Record deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        public static void Reset_All(Form form)
        {
            try
            {
                foreach (Control c in form.Controls)
                {
                    if (c is Guna.UI2.WinForms.Guna2TextBox txt)
                    {
                        txt.Text = "";
                    }

                    else if (c is Guna.UI2.WinForms.Guna2ComboBox cmb)
                    {
                        cmb.SelectedIndex = -1;
                    }
                    else if (c is Guna.UI2.WinForms.Guna2CheckBox chk)
                    {
                        chk.Checked = false;
                    }
                    else if (c is Guna.UI2.WinForms.Guna2RadioButton rb)
                    {
                        rb.Checked = false;
                    }
                    else if (c is Guna.UI2.WinForms.Guna2DateTimePicker dtp)
                    {
                        dtp.Value = DateTime.Today;
                    }
                    else if (c is ListBox listBox)
                    {
                        listBox.ClearSelected();
                    }
                    else if (c is NumericUpDown num)
                    {
                        num.Value = 0;
                    }
                    else if (c is MaskedTextBox mtxt)
                    {
                        mtxt.Text = "";
                    }
                    else if (c is PictureBox pb)
                    {
                        pb.Image = null; // Clear PictureBox image
                    }
                }

               // MessageBox.Show("Form Reset Successfully!", "Reset", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error resetting form: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        private static void MaskD_TextChanged(object sender, EventArgs e)
        {
            if (sender is Guna2DateTimePicker textBox)
            {
                MaskD(textBox);
            }
        }





        public static void MaskD(Guna2DateTimePicker guna2DateTimePicker)
        {
            DateTime tempDate = guna2DateTimePicker.Value; // Use the Value property directly

            // Format the date as "dd/MM/yyyy"
            guna2DateTimePicker.Text = tempDate.ToString("dd/MM/yyyy");
        }






        public static void LoadForEdit2(Form form, string tableName, string qry, DataGridView gv, int editID)
        {
            try
            {
                // Load data into DataTable
                DataTable dt = GetData(qry);

                // Prevent auto-generation of columns
                gv.AutoGenerateColumns = false;

                // Set the data source
                gv.DataSource = dt;

                // Define only the required columns manually
                string[] requiredColumns = { "srno", "proName", "qty", "Price", "Amount", "proID" };  // Added proID here

                // Hide unwanted columns
                foreach (DataGridViewColumn column in gv.Columns)
                {
                    if (!requiredColumns.Contains(column.Name))
                    {
                        column.Visible = false;
                    }
                }

                // Assign values manually for numbered rows
                for (int i = 0; i < gv.Rows.Count; i++)
                {
                    if (i < dt.Rows.Count)
                    {
                        DataGridViewRow row = gv.Rows[i];

                        int y = i + 1; // Set serial number
                        row.Cells["srno"].Value = y;
                       

                        row.Cells["proName"].Value = dt.Rows[i]["pName"];
                        

                        row.Cells["qty"].Value = dt.Rows[i]["qty"];
                       

                        row.Cells["Price"].Value = dt.Rows[i]["Price"];
                       

                        row.Cells["Amount"].Value = dt.Rows[i]["Amount"];
                       

                        // **Check and Print Product ID (proID)**
                        row.Cells["proID"].Value = dt.Rows[i]["proID"];
                        
                    }
                }

                // Load form fields for the main table
                string idColumn = (tableName == "tblInvMain") ? "mainID" : "";

                if (string.IsNullOrEmpty(idColumn))
                {
                    MessageBox.Show("Invalid table name provided.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string mainQuery = $"SELECT * FROM {tableName} WHERE {idColumn} = @id";
                using (SqlConnection con = new SqlConnection(conString))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(mainQuery, con);
                    cmd.Parameters.AddWithValue("@id", editID);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable mainTable = new DataTable();
                    da.Fill(mainTable);

                    if (mainTable.Rows.Count > 0)
                    {
                        DataRow row = mainTable.Rows[0];

                        foreach (Control c in form.Controls)
                        {
                            if (c is Guna2TextBox txt)
                            {
                                string colName = txt.Name.Replace("txt", "");
                                if (row.Table.Columns.Contains(colName))
                                {
                                    txt.Text = row[colName].ToString();
                                }
                            }
                            else if (c is Guna2ComboBox cb)
                            {
                                string colName = cb.Name.Replace("cmb", "");  // Column Name Match

                                if (row.Table.Columns.Contains(colName))
                                {
                                    object value = row[colName];

                                    // Handle DBNull case
                                    if (value != DBNull.Value)
                                    {
                                        cb.SelectedValue = value;  // Assign Selected Value
                                        cb.SelectedItem = value.ToString(); // Ensure Display in ComboBox
                                    }
                                    else
                                    {
                                        cb.SelectedIndex = 0; // Set default index (Optional)
                                    }
                                }
                            }
                            else if (c is Guna2DateTimePicker dtp)
                            {
                                string colName = dtp.Name; // Ensure correct property name is used
                                if (row.Table.Columns.Contains(colName))
                                {
                                    if (!Convert.IsDBNull(row[colName]))
                                    {
                                        dtp.Value = Convert.ToDateTime(row[colName]);
                                    }
                                    else
                                    {
                                        Console.WriteLine($"{colName} is NULL in database!");
                                    }
                                }
                            }
                        }

                        // **FIX: Recalculate Net Amount**
                        if (form.Controls["mTotal"] is Guna2TextBox totalTextBox &&
                            form.Controls["Discount"] is Guna2TextBox discountTextBox &&
                            form.Controls["NetAmount"] is Guna2TextBox netAmountTextBox)
                        {
                            double total = 0, discount = 0;

                            double.TryParse(totalTextBox.Text, out total);
                            double.TryParse(discountTextBox.Text, out discount);

                            double netAmount = total - discount;

                            netAmountTextBox.Text = netAmount.ToString("N2");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data for editing: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }





        public static byte[] ImageToByteArray(Image imageIn)
        {
            using (var ms = new System.IO.MemoryStream())
            {
                imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                return ms.ToArray();
            }
        }

        public static Image ByteArrayToImage(byte[] byteArrayIn)
        {
            using (var ms = new System.IO.MemoryStream(byteArrayIn))
            {
                return Image.FromStream(ms);
            }
        }







        public enum enmType
        {
            Insert,
            Update,
            Delete
        }


        public static void BrowsePicture(PictureBox pictureBox)
        {
            // Create a new OpenFileDialog for browsing the picture
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp", // Specify the file types you want to allow
                Title = "Select a Picture"
            };

            // Show the dialog and check if the user selected a file
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Load the selected image into the PictureBox
                    pictureBox.Image = Image.FromFile(openFileDialog.FileName);

                    // Optionally, adjust the size mode to fit the image nicely
                    pictureBox.SizeMode = PictureBoxSizeMode.Zoom; // Adjusts the image size to fit within the PictureBox

                    // Display success message for debugging
                    MessageBox.Show("Image successfully loaded!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    // Handle and display error if any issues occur while loading the image
                    MessageBox.Show("An error occurred while loading the image: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }






    }
}
