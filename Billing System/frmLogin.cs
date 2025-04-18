using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Billing_System
{
    public partial class frmLogin : Sample
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            // Hide password initially
            txtPass.UseSystemPasswordChar = true;
           

        }

        private void btnLoginClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUser.Text;
            string password = txtPass.Text;

            // Validate fields
            if (MainClass.Functions.Validate(this) == false)
            {
                return;
            }

            // Check if user is valid
            if (MainClass.Functions.IsValidUser(username, password))
            {
                // 🔄 Get full user data for session
                string query = "SELECT * FROM tblUser WHERE uName = @username";
                SqlCommand cmd = new SqlCommand(query, MainClass.Functions.con);
                cmd.Parameters.AddWithValue("@username", username);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    CurrentUser.UserID = Convert.ToInt32(dt.Rows[0]["userID"]);
                    CurrentUser.UserName = dt.Rows[0]["uName"].ToString();
                    CurrentUser.Role = Convert.ToInt32(dt.Rows[0]["uRole"]); // ✅ FIX

                    if (dt.Rows[0]["uImage"] != DBNull.Value)
                    {
                        CurrentUser.ProfileImage = (byte[])dt.Rows[0]["uImage"];
                    }

                    // Then open main form
                    new frmMain().Show();
                    this.Hide();
                }



            }

            else
            {
                // Login failed
                InvlidN.Visible = true;
                InvalidPd.Visible = true;
                InvlidN.ForeColor = Color.Red;
                InvalidPd.ForeColor = Color.Red;
                txtUser.BorderColor = Color.Red;
                txtPass.BorderColor = Color.Red;
                MessageBox.Show("Invalid username or password", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void guna2ToggleSwitch1_CheckedChanged(object sender, EventArgs e)
        {
            // Show/hide password
            txtPass.UseSystemPasswordChar = !guna2ToggleSwitch1.Checked;
        }
    }
}
