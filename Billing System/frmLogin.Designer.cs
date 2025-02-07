﻿namespace Billing_System
{
    partial class frmLogin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.InvalidPd = new System.Windows.Forms.Label();
            this.InvlidN = new System.Windows.Forms.Label();
            this.btnLogin = new Guna.UI2.WinForms.Guna2GradientButton();
            this.label4 = new System.Windows.Forms.Label();
            this.guna2ToggleSwitch1 = new Guna.UI2.WinForms.Guna2ToggleSwitch();
            this.txtPass = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtUser = new Guna.UI2.WinForms.Guna2TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCloseLogin = new Guna.UI2.WinForms.Guna2Button();
            this.guna2BorderlessForm2 = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
            this.guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.guna2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(28)))), ((int)(((byte)(30)))));
            this.guna2Panel1.BorderRadius = 5;
            this.guna2Panel1.Controls.Add(this.InvalidPd);
            this.guna2Panel1.Controls.Add(this.InvlidN);
            this.guna2Panel1.Controls.Add(this.btnLogin);
            this.guna2Panel1.Controls.Add(this.label4);
            this.guna2Panel1.Controls.Add(this.guna2ToggleSwitch1);
            this.guna2Panel1.Controls.Add(this.txtPass);
            this.guna2Panel1.Controls.Add(this.txtUser);
            this.guna2Panel1.Controls.Add(this.label3);
            this.guna2Panel1.Controls.Add(this.label2);
            this.guna2Panel1.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(38)))), ((int)(((byte)(56)))));
            this.guna2Panel1.CustomBorderThickness = new System.Windows.Forms.Padding(0, 0, 4, 0);
            this.guna2Panel1.Location = new System.Drawing.Point(0, 2);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(424, 549);
            this.guna2Panel1.TabIndex = 0;
            // 
            // InvalidPd
            // 
            this.InvalidPd.AutoSize = true;
            this.InvalidPd.Font = new System.Drawing.Font("Segoe UI Emoji", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InvalidPd.Location = new System.Drawing.Point(64, 261);
            this.InvalidPd.Name = "InvalidPd";
            this.InvalidPd.Size = new System.Drawing.Size(119, 20);
            this.InvalidPd.TabIndex = 12;
            this.InvalidPd.Text = "Invalid Password";
            this.InvalidPd.Visible = false;
            // 
            // InvlidN
            // 
            this.InvlidN.AutoSize = true;
            this.InvlidN.Font = new System.Drawing.Font("Segoe UI Emoji", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InvlidN.Location = new System.Drawing.Point(66, 158);
            this.InvlidN.Name = "InvlidN";
            this.InvlidN.Size = new System.Drawing.Size(97, 20);
            this.InvlidN.TabIndex = 11;
            this.InvlidN.Text = "Invalid Name";
            this.InvlidN.Visible = false;
            // 
            // btnLogin
            // 
            this.btnLogin.Animated = true;
            this.btnLogin.BackColor = System.Drawing.Color.Transparent;
            this.btnLogin.BorderColor = System.Drawing.Color.MediumOrchid;
            this.btnLogin.BorderRadius = 9;
            this.btnLogin.BorderThickness = 3;
            this.btnLogin.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnLogin.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnLogin.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnLogin.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnLogin.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnLogin.FillColor = System.Drawing.Color.DarkViolet;
            this.btnLogin.FillColor2 = System.Drawing.Color.MediumOrchid;
            this.btnLogin.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnLogin.ForeColor = System.Drawing.Color.White;
            this.btnLogin.HoverState.BorderColor = System.Drawing.Color.Fuchsia;
            this.btnLogin.Location = new System.Drawing.Point(65, 431);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(284, 58);
            this.btnLogin.TabIndex = 5;
            this.btnLogin.Text = "LOGIN";
            this.btnLogin.UseTransparentBackground = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Emoji", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(250, 364);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 17);
            this.label4.TabIndex = 8;
            this.label4.Text = "Show Password";
            // 
            // guna2ToggleSwitch1
            // 
            this.guna2ToggleSwitch1.CheckedState.BorderColor = System.Drawing.Color.DarkViolet;
            this.guna2ToggleSwitch1.CheckedState.BorderThickness = 2;
            this.guna2ToggleSwitch1.CheckedState.FillColor = System.Drawing.Color.DarkViolet;
            this.guna2ToggleSwitch1.CheckedState.InnerBorderColor = System.Drawing.Color.White;
            this.guna2ToggleSwitch1.CheckedState.InnerColor = System.Drawing.Color.White;
            this.guna2ToggleSwitch1.Location = new System.Drawing.Point(210, 360);
            this.guna2ToggleSwitch1.Name = "guna2ToggleSwitch1";
            this.guna2ToggleSwitch1.Size = new System.Drawing.Size(38, 24);
            this.guna2ToggleSwitch1.TabIndex = 0;
            this.guna2ToggleSwitch1.TabStop = false;
            this.guna2ToggleSwitch1.UncheckedState.BorderColor = System.Drawing.Color.DarkViolet;
            this.guna2ToggleSwitch1.UncheckedState.BorderThickness = 2;
            this.guna2ToggleSwitch1.UncheckedState.FillColor = System.Drawing.Color.Transparent;
            this.guna2ToggleSwitch1.UncheckedState.InnerBorderColor = System.Drawing.Color.White;
            this.guna2ToggleSwitch1.UncheckedState.InnerColor = System.Drawing.Color.White;
            this.guna2ToggleSwitch1.CheckedChanged += new System.EventHandler(this.guna2ToggleSwitch1_CheckedChanged);
            // 
            // txtPass
            // 
            this.txtPass.BorderColor = System.Drawing.Color.DarkViolet;
            this.txtPass.BorderRadius = 9;
            this.txtPass.BorderThickness = 2;
            this.txtPass.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPass.DefaultText = "";
            this.txtPass.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtPass.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtPass.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtPass.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtPass.FillColor = System.Drawing.Color.Transparent;
            this.txtPass.FocusedState.BorderColor = System.Drawing.Color.Fuchsia;
            this.txtPass.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.txtPass.ForeColor = System.Drawing.Color.DarkViolet;
            this.txtPass.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtPass.Location = new System.Drawing.Point(65, 284);
            this.txtPass.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtPass.Name = "txtPass";
            this.txtPass.PasswordChar = '\0';
            this.txtPass.PlaceholderForeColor = System.Drawing.Color.DarkGray;
            this.txtPass.PlaceholderText = "Passowrd";
            this.txtPass.SelectedText = "";
            this.txtPass.Size = new System.Drawing.Size(286, 65);
            this.txtPass.TabIndex = 2;
            this.txtPass.TabStop = false;
            this.txtPass.Tag = "v";
            // 
            // txtUser
            // 
            this.txtUser.BorderColor = System.Drawing.Color.DarkViolet;
            this.txtUser.BorderRadius = 9;
            this.txtUser.BorderThickness = 2;
            this.txtUser.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtUser.DefaultText = "";
            this.txtUser.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtUser.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtUser.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtUser.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtUser.FillColor = System.Drawing.Color.Transparent;
            this.txtUser.FocusedState.BorderColor = System.Drawing.Color.Fuchsia;
            this.txtUser.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.txtUser.ForeColor = System.Drawing.Color.DarkViolet;
            this.txtUser.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtUser.Location = new System.Drawing.Point(65, 182);
            this.txtUser.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtUser.Name = "txtUser";
            this.txtUser.PasswordChar = '\0';
            this.txtUser.PlaceholderForeColor = System.Drawing.Color.DarkGray;
            this.txtUser.PlaceholderText = "User Name";
            this.txtUser.SelectedText = "";
            this.txtUser.Size = new System.Drawing.Size(286, 65);
            this.txtUser.TabIndex = 2;
            this.txtUser.TabStop = false;
            this.txtUser.Tag = "v";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(51, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(381, 69);
            this.label3.TabIndex = 4;
            this.label3.Text = "WELLCOME";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Emoji", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(153, 116);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Billing System C#";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Emoji", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(535, 505);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(269, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Powerd by LK Programmers (Group-12)";
            // 
            // btnCloseLogin
            // 
            this.btnCloseLogin.BorderColor = System.Drawing.Color.DarkViolet;
            this.btnCloseLogin.BorderRadius = 6;
            this.btnCloseLogin.BorderThickness = 3;
            this.btnCloseLogin.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnCloseLogin.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnCloseLogin.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnCloseLogin.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnCloseLogin.FillColor = System.Drawing.Color.Transparent;
            this.btnCloseLogin.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCloseLogin.ForeColor = System.Drawing.Color.White;
            this.btnCloseLogin.HoverState.BorderColor = System.Drawing.Color.Fuchsia;
            this.btnCloseLogin.Location = new System.Drawing.Point(807, 27);
            this.btnCloseLogin.Name = "btnCloseLogin";
            this.btnCloseLogin.Size = new System.Drawing.Size(63, 36);
            this.btnCloseLogin.TabIndex = 1;
            this.btnCloseLogin.TabStop = false;
            this.btnCloseLogin.Text = "Exit";
            this.btnCloseLogin.Click += new System.EventHandler(this.btnLoginClose_Click);
            // 
            // guna2BorderlessForm2
            // 
            this.guna2BorderlessForm2.AnimateWindow = true;
            this.guna2BorderlessForm2.AnimationInterval = 200;
            this.guna2BorderlessForm2.AnimationType = Guna.UI2.WinForms.Guna2BorderlessForm.AnimateWindowType.AW_CENTER;
            this.guna2BorderlessForm2.ContainerControl = this;
            this.guna2BorderlessForm2.DockIndicatorTransparencyValue = 0.6D;
            this.guna2BorderlessForm2.ShadowColor = System.Drawing.Color.DarkViolet;
            this.guna2BorderlessForm2.TransparentWhileDrag = true;
            // 
            // guna2PictureBox1
            // 
            this.guna2PictureBox1.Image = global::Billing_System.Properties.Resources.logomain;
            this.guna2PictureBox1.ImageRotate = 0F;
            this.guna2PictureBox1.Location = new System.Drawing.Point(506, 69);
            this.guna2PictureBox1.Name = "guna2PictureBox1";
            this.guna2PictureBox1.Size = new System.Drawing.Size(318, 363);
            this.guna2PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.guna2PictureBox1.TabIndex = 1;
            this.guna2PictureBox1.TabStop = false;
            // 
            // frmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 552);
            this.Controls.Add(this.btnCloseLogin);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.guna2PictureBox1);
            this.Controls.Add(this.guna2Panel1);
            this.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.Name = "frmLogin";
            this.Text = "frmLogin";
            this.Load += new System.EventHandler(this.frmLogin_Load);
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2TextBox txtUser;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2ToggleSwitch guna2ToggleSwitch1;
        private Guna.UI2.WinForms.Guna2TextBox txtPass;
        private System.Windows.Forms.Label label4;
        private Guna.UI2.WinForms.Guna2Button btnCloseLogin;
        private Guna.UI2.WinForms.Guna2GradientButton btnLogin;
        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm2;
        private System.Windows.Forms.Label InvalidPd;
        private System.Windows.Forms.Label InvlidN;
    }
}