﻿namespace Billing_System.Model
{
    partial class frmSaleAdd
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.description = new System.Windows.Forms.Label();
            this.mainID = new System.Windows.Forms.Label();
            this.mDueDate = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.mdate = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.mType = new System.Windows.Forms.Label();
            this.guna2DataGridView2 = new Guna.UI2.WinForms.Guna2DataGridView();
            this.label7 = new System.Windows.Forms.Label();
            this.NetAmount = new Guna.UI2.WinForms.Guna2TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.Discount = new Guna.UI2.WinForms.Guna2TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.mTotal = new Guna.UI2.WinForms.Guna2TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.pType = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.PersonID = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.InvlidN = new System.Windows.Forms.Label();
            this.guna2DataGridView1 = new Guna.UI2.WinForms.Guna2DataGridView();
            this.srno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.detailID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.proID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.proName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.guna2DataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2DataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Size = new System.Drawing.Size(154, 33);
            this.label1.Text = "Sale Details";
            // 
            // description
            // 
            this.description.AutoSize = true;
            this.description.Font = new System.Drawing.Font("Segoe UI Emoji", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.description.Location = new System.Drawing.Point(1120, 232);
            this.description.Name = "description";
            this.description.Size = new System.Drawing.Size(67, 20);
            this.description.TabIndex = 52;
            this.description.Text = "Purchase";
            this.description.Visible = false;
            // 
            // mainID
            // 
            this.mainID.AutoSize = true;
            this.mainID.Font = new System.Drawing.Font("Segoe UI Emoji", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mainID.Location = new System.Drawing.Point(965, 232);
            this.mainID.Name = "mainID";
            this.mainID.Size = new System.Drawing.Size(67, 20);
            this.mainID.TabIndex = 51;
            this.mainID.Text = "Purchase";
            this.mainID.Visible = false;
            // 
            // mDueDate
            // 
            this.mDueDate.BackColor = System.Drawing.Color.Black;
            this.mDueDate.BorderColor = System.Drawing.Color.DarkViolet;
            this.mDueDate.BorderRadius = 9;
            this.mDueDate.BorderThickness = 2;
            this.mDueDate.Checked = true;
            this.mDueDate.CheckedState.BorderColor = System.Drawing.Color.DarkViolet;
            this.mDueDate.FillColor = System.Drawing.Color.Black;
            this.mDueDate.FocusedColor = System.Drawing.Color.Fuchsia;
            this.mDueDate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.mDueDate.ForeColor = System.Drawing.Color.DarkViolet;
            this.mDueDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.mDueDate.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.mDueDate.HoverState.FillColor = System.Drawing.Color.Transparent;
            this.mDueDate.HoverState.ForeColor = System.Drawing.Color.DarkViolet;
            this.mDueDate.Location = new System.Drawing.Point(528, 155);
            this.mDueDate.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.mDueDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.mDueDate.Name = "mDueDate";
            this.mDueDate.Size = new System.Drawing.Size(195, 53);
            this.mDueDate.TabIndex = 50;
            this.mDueDate.Value = new System.DateTime(2025, 2, 18, 0, 0, 0, 0);
            // 
            // mdate
            // 
            this.mdate.BackColor = System.Drawing.Color.Black;
            this.mdate.BorderColor = System.Drawing.Color.DarkViolet;
            this.mdate.BorderRadius = 9;
            this.mdate.BorderThickness = 2;
            this.mdate.Checked = true;
            this.mdate.CheckedState.BorderColor = System.Drawing.Color.DarkViolet;
            this.mdate.FillColor = System.Drawing.Color.Black;
            this.mdate.FocusedColor = System.Drawing.Color.Fuchsia;
            this.mdate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.mdate.ForeColor = System.Drawing.Color.DarkViolet;
            this.mdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.mdate.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.mdate.HoverState.FillColor = System.Drawing.Color.Transparent;
            this.mdate.HoverState.ForeColor = System.Drawing.Color.DarkViolet;
            this.mdate.Location = new System.Drawing.Point(316, 155);
            this.mdate.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.mdate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.mdate.Name = "mdate";
            this.mdate.Size = new System.Drawing.Size(195, 53);
            this.mdate.TabIndex = 49;
            this.mdate.Value = new System.DateTime(2025, 2, 18, 0, 0, 0, 0);
            // 
            // mType
            // 
            this.mType.AutoSize = true;
            this.mType.Font = new System.Drawing.Font("Segoe UI Emoji", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mType.Location = new System.Drawing.Point(965, 180);
            this.mType.Name = "mType";
            this.mType.Size = new System.Drawing.Size(37, 20);
            this.mType.TabIndex = 48;
            this.mType.Text = "Sale";
            this.mType.Visible = false;
            // 
            // guna2DataGridView2
            // 
            this.guna2DataGridView2.AllowUserToAddRows = false;
            this.guna2DataGridView2.AllowUserToDeleteRows = false;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(28)))), ((int)(((byte)(36)))));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.White;
            this.guna2DataGridView2.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
            this.guna2DataGridView2.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(28)))), ((int)(((byte)(36)))));
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(28)))), ((int)(((byte)(36)))));
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Segoe UI Emoji", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.DarkViolet;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.guna2DataGridView2.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.guna2DataGridView2.ColumnHeadersHeight = 35;
            this.guna2DataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(28)))), ((int)(((byte)(36)))));
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Segoe UI Emoji", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(43)))), ((int)(((byte)(54)))));
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.guna2DataGridView2.DefaultCellStyle = dataGridViewCellStyle9;
            this.guna2DataGridView2.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(43)))), ((int)(((byte)(54)))));
            this.guna2DataGridView2.Location = new System.Drawing.Point(129, 355);
            this.guna2DataGridView2.Name = "guna2DataGridView2";
            this.guna2DataGridView2.ReadOnly = true;
            this.guna2DataGridView2.RowHeadersVisible = false;
            this.guna2DataGridView2.RowHeadersWidth = 51;
            this.guna2DataGridView2.RowTemplate.Height = 30;
            this.guna2DataGridView2.Size = new System.Drawing.Size(660, 245);
            this.guna2DataGridView2.TabIndex = 47;
            this.guna2DataGridView2.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.guna2DataGridView2.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.guna2DataGridView2.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.guna2DataGridView2.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.guna2DataGridView2.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.guna2DataGridView2.ThemeStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(28)))), ((int)(((byte)(36)))));
            this.guna2DataGridView2.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(43)))), ((int)(((byte)(54)))));
            this.guna2DataGridView2.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.guna2DataGridView2.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.guna2DataGridView2.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI Emoji", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2DataGridView2.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.guna2DataGridView2.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.guna2DataGridView2.ThemeStyle.HeaderStyle.Height = 35;
            this.guna2DataGridView2.ThemeStyle.ReadOnly = true;
            this.guna2DataGridView2.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.guna2DataGridView2.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.guna2DataGridView2.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI Emoji", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2DataGridView2.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.White;
            this.guna2DataGridView2.ThemeStyle.RowsStyle.Height = 30;
            this.guna2DataGridView2.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.guna2DataGridView2.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.guna2DataGridView2.Visible = false;
            this.guna2DataGridView2.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.guna2DataGridView2_CellClick);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI Emoji", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(904, 534);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(90, 20);
            this.label7.TabIndex = 46;
            this.label7.Text = "Net Amount";
            // 
            // NetAmount
            // 
            this.NetAmount.BorderColor = System.Drawing.Color.DarkViolet;
            this.NetAmount.BorderRadius = 9;
            this.NetAmount.BorderThickness = 2;
            this.NetAmount.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.NetAmount.DefaultText = "";
            this.NetAmount.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.NetAmount.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.NetAmount.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.NetAmount.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.NetAmount.FillColor = System.Drawing.Color.Transparent;
            this.NetAmount.FocusedState.BorderColor = System.Drawing.Color.Fuchsia;
            this.NetAmount.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.NetAmount.ForeColor = System.Drawing.Color.DarkViolet;
            this.NetAmount.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.NetAmount.Location = new System.Drawing.Point(1012, 519);
            this.NetAmount.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.NetAmount.Name = "NetAmount";
            this.NetAmount.PasswordChar = '\0';
            this.NetAmount.PlaceholderForeColor = System.Drawing.Color.DimGray;
            this.NetAmount.PlaceholderText = "Net Amount";
            this.NetAmount.SelectedText = "";
            this.NetAmount.Size = new System.Drawing.Size(195, 50);
            this.NetAmount.TabIndex = 45;
            this.NetAmount.TabStop = false;
            this.NetAmount.Tag = "v";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI Emoji", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(904, 475);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 20);
            this.label6.TabIndex = 44;
            this.label6.Text = "Discount";
            // 
            // Discount
            // 
            this.Discount.BorderColor = System.Drawing.Color.DarkViolet;
            this.Discount.BorderRadius = 9;
            this.Discount.BorderThickness = 2;
            this.Discount.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.Discount.DefaultText = "";
            this.Discount.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.Discount.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.Discount.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.Discount.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.Discount.FillColor = System.Drawing.Color.Transparent;
            this.Discount.FocusedState.BorderColor = System.Drawing.Color.Fuchsia;
            this.Discount.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.Discount.ForeColor = System.Drawing.Color.DarkViolet;
            this.Discount.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.Discount.Location = new System.Drawing.Point(1012, 460);
            this.Discount.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Discount.Name = "Discount";
            this.Discount.PasswordChar = '\0';
            this.Discount.PlaceholderForeColor = System.Drawing.Color.DimGray;
            this.Discount.PlaceholderText = "Discount";
            this.Discount.SelectedText = "";
            this.Discount.Size = new System.Drawing.Size(195, 50);
            this.Discount.TabIndex = 43;
            this.Discount.TabStop = false;
            this.Discount.Tag = "v";
            this.Discount.TextChanged += new System.EventHandler(this.Discount_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Emoji", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(904, 414);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(102, 20);
            this.label5.TabIndex = 42;
            this.label5.Text = "Gross Amount";
            // 
            // mTotal
            // 
            this.mTotal.BorderColor = System.Drawing.Color.DarkViolet;
            this.mTotal.BorderRadius = 9;
            this.mTotal.BorderThickness = 2;
            this.mTotal.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.mTotal.DefaultText = "";
            this.mTotal.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.mTotal.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.mTotal.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.mTotal.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.mTotal.FillColor = System.Drawing.Color.Transparent;
            this.mTotal.FocusedState.BorderColor = System.Drawing.Color.Fuchsia;
            this.mTotal.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.mTotal.ForeColor = System.Drawing.Color.DarkViolet;
            this.mTotal.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.mTotal.Location = new System.Drawing.Point(1012, 399);
            this.mTotal.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.mTotal.Name = "mTotal";
            this.mTotal.PasswordChar = '\0';
            this.mTotal.PlaceholderForeColor = System.Drawing.Color.DimGray;
            this.mTotal.PlaceholderText = "Gross Amount";
            this.mTotal.SelectedText = "";
            this.mTotal.Size = new System.Drawing.Size(195, 50);
            this.mTotal.TabIndex = 41;
            this.mTotal.TabStop = false;
            this.mTotal.Tag = "v";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Emoji", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(755, 124);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 20);
            this.label4.TabIndex = 40;
            this.label4.Text = "Type";
            // 
            // pType
            // 
            this.pType.BackColor = System.Drawing.Color.Transparent;
            this.pType.BorderColor = System.Drawing.Color.DarkViolet;
            this.pType.BorderRadius = 9;
            this.pType.BorderThickness = 2;
            this.pType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.pType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.pType.FillColor = System.Drawing.Color.Black;
            this.pType.FocusedColor = System.Drawing.Color.Fuchsia;
            this.pType.FocusedState.BorderColor = System.Drawing.Color.Fuchsia;
            this.pType.Font = new System.Drawing.Font("Segoe UI Emoji", 9F, System.Drawing.FontStyle.Bold);
            this.pType.ForeColor = System.Drawing.Color.DarkViolet;
            this.pType.ItemHeight = 39;
            this.pType.Items.AddRange(new object[] {
            "Cash",
            "Credit"});
            this.pType.Location = new System.Drawing.Point(750, 155);
            this.pType.Name = "pType";
            this.pType.Size = new System.Drawing.Size(119, 45);
            this.pType.TabIndex = 39;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Emoji", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(524, 124);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 20);
            this.label3.TabIndex = 38;
            this.label3.Text = "Due Date";
            // 
            // PersonID
            // 
            this.PersonID.BackColor = System.Drawing.Color.Transparent;
            this.PersonID.BorderColor = System.Drawing.Color.DarkViolet;
            this.PersonID.BorderRadius = 9;
            this.PersonID.BorderThickness = 2;
            this.PersonID.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.PersonID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.PersonID.FillColor = System.Drawing.Color.Black;
            this.PersonID.FocusedColor = System.Drawing.Color.Fuchsia;
            this.PersonID.FocusedState.BorderColor = System.Drawing.Color.Fuchsia;
            this.PersonID.Font = new System.Drawing.Font("Segoe UI Emoji", 9F, System.Drawing.FontStyle.Bold);
            this.PersonID.ForeColor = System.Drawing.Color.DarkViolet;
            this.PersonID.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.PersonID.ItemHeight = 39;
            this.PersonID.Location = new System.Drawing.Point(40, 155);
            this.PersonID.Name = "PersonID";
            this.PersonID.Size = new System.Drawing.Size(261, 45);
            this.PersonID.TabIndex = 37;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Emoji", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(312, 124);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 20);
            this.label2.TabIndex = 36;
            this.label2.Text = "Date";
            // 
            // InvlidN
            // 
            this.InvlidN.AutoSize = true;
            this.InvlidN.Font = new System.Drawing.Font("Segoe UI Emoji", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InvlidN.Location = new System.Drawing.Point(48, 124);
            this.InvlidN.Name = "InvlidN";
            this.InvlidN.Size = new System.Drawing.Size(108, 20);
            this.InvlidN.TabIndex = 35;
            this.InvlidN.Text = "Supplier Name";
            // 
            // guna2DataGridView1
            // 
            this.guna2DataGridView1.AllowUserToDeleteRows = false;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(28)))), ((int)(((byte)(36)))));
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.White;
            this.guna2DataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle10;
            this.guna2DataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(28)))), ((int)(((byte)(36)))));
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(28)))), ((int)(((byte)(36)))));
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Segoe UI Emoji", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.Color.DarkViolet;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.guna2DataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle11;
            this.guna2DataGridView1.ColumnHeadersHeight = 35;
            this.guna2DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.guna2DataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.srno,
            this.detailID,
            this.proID,
            this.proName,
            this.qty,
            this.Price,
            this.Amount});
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(28)))), ((int)(((byte)(36)))));
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Segoe UI Emoji", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(43)))), ((int)(((byte)(54)))));
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.guna2DataGridView1.DefaultCellStyle = dataGridViewCellStyle12;
            this.guna2DataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.guna2DataGridView1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(43)))), ((int)(((byte)(54)))));
            this.guna2DataGridView1.Location = new System.Drawing.Point(40, 232);
            this.guna2DataGridView1.Name = "guna2DataGridView1";
            this.guna2DataGridView1.RowHeadersVisible = false;
            this.guna2DataGridView1.RowHeadersWidth = 51;
            this.guna2DataGridView1.RowTemplate.Height = 30;
            this.guna2DataGridView1.Size = new System.Drawing.Size(829, 356);
            this.guna2DataGridView1.TabIndex = 34;
            this.guna2DataGridView1.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.guna2DataGridView1.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.guna2DataGridView1.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.guna2DataGridView1.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.guna2DataGridView1.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.guna2DataGridView1.ThemeStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(28)))), ((int)(((byte)(36)))));
            this.guna2DataGridView1.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(43)))), ((int)(((byte)(54)))));
            this.guna2DataGridView1.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.guna2DataGridView1.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.guna2DataGridView1.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI Emoji", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2DataGridView1.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.guna2DataGridView1.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.guna2DataGridView1.ThemeStyle.HeaderStyle.Height = 35;
            this.guna2DataGridView1.ThemeStyle.ReadOnly = false;
            this.guna2DataGridView1.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.guna2DataGridView1.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.guna2DataGridView1.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI Emoji", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2DataGridView1.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.White;
            this.guna2DataGridView1.ThemeStyle.RowsStyle.Height = 30;
            this.guna2DataGridView1.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.guna2DataGridView1.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.guna2DataGridView1.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.guna2DataGridView1_CellEndEdit);
            this.guna2DataGridView1.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.guna2DataGridView2_CellFormatting);
            this.guna2DataGridView1.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.guna2DataGridView1_EditingControlShowing);
            // 
            // srno
            // 
            this.srno.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.srno.FillWeight = 70F;
            this.srno.HeaderText = "Sr#";
            this.srno.MinimumWidth = 70;
            this.srno.Name = "srno";
            this.srno.Width = 70;
            // 
            // detailID
            // 
            this.detailID.HeaderText = "id";
            this.detailID.MinimumWidth = 6;
            this.detailID.Name = "detailID";
            this.detailID.Visible = false;
            // 
            // proID
            // 
            this.proID.HeaderText = "proID";
            this.proID.MinimumWidth = 6;
            this.proID.Name = "proID";
            this.proID.Visible = false;
            // 
            // proName
            // 
            this.proName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.proName.HeaderText = "product Name";
            this.proName.MinimumWidth = 6;
            this.proName.Name = "proName";
            // 
            // qty
            // 
            this.qty.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.qty.FillWeight = 70F;
            this.qty.HeaderText = "Qty";
            this.qty.MinimumWidth = 70;
            this.qty.Name = "qty";
            this.qty.Width = 70;
            // 
            // Price
            // 
            this.Price.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Price.FillWeight = 70F;
            this.Price.HeaderText = "Price";
            this.Price.MinimumWidth = 70;
            this.Price.Name = "Price";
            this.Price.Width = 70;
            // 
            // Amount
            // 
            this.Amount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Amount.FillWeight = 90F;
            this.Amount.HeaderText = "Amount";
            this.Amount.MinimumWidth = 90;
            this.Amount.Name = "Amount";
            this.Amount.Width = 90;
            // 
            // frmSaleAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1246, 725);
            this.Controls.Add(this.description);
            this.Controls.Add(this.mainID);
            this.Controls.Add(this.mDueDate);
            this.Controls.Add(this.mdate);
            this.Controls.Add(this.mType);
            this.Controls.Add(this.guna2DataGridView2);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.NetAmount);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.Discount);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.mTotal);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.pType);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.PersonID);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.InvlidN);
            this.Controls.Add(this.guna2DataGridView1);
            this.Name = "frmSaleAdd";
            this.Text = "frmSaleAdd";
            this.Load += new System.EventHandler(this.frmSaleAdd_Load);
            ((System.ComponentModel.ISupportInitialize)(this.guna2DataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2DataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label description;
        private System.Windows.Forms.Label mainID;
        private Guna.UI2.WinForms.Guna2DateTimePicker mDueDate;
        private Guna.UI2.WinForms.Guna2DateTimePicker mdate;
        private System.Windows.Forms.Label mType;
        public Guna.UI2.WinForms.Guna2DataGridView guna2DataGridView2;
        private System.Windows.Forms.Label label7;
        private Guna.UI2.WinForms.Guna2TextBox NetAmount;
        private System.Windows.Forms.Label label6;
        private Guna.UI2.WinForms.Guna2TextBox Discount;
        private System.Windows.Forms.Label label5;
        private Guna.UI2.WinForms.Guna2TextBox mTotal;
        private System.Windows.Forms.Label label4;
        private Guna.UI2.WinForms.Guna2ComboBox pType;
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2ComboBox PersonID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label InvlidN;
        public Guna.UI2.WinForms.Guna2DataGridView guna2DataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn srno;
        private System.Windows.Forms.DataGridViewTextBoxColumn detailID;
        private System.Windows.Forms.DataGridViewTextBoxColumn proID;
        private System.Windows.Forms.DataGridViewTextBoxColumn proName;
        private System.Windows.Forms.DataGridViewTextBoxColumn qty;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price;
        private System.Windows.Forms.DataGridViewTextBoxColumn Amount;
    }
}