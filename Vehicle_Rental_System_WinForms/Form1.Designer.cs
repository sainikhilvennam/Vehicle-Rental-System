namespace Vehicle_Rental_System_WinForms
{
    partial class Form1
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
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.linkLabel3 = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_Customer_Sign_Up = new System.Windows.Forms.Button();
            this.btn_Customer_Sign_In = new System.Windows.Forms.Button();
            this.btn_Admin_Sign_In = new System.Windows.Forms.Button();
            this.Btn_Exit = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // linkLabel1
            // 
            this.linkLabel1.Location = new System.Drawing.Point(0, 0);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(100, 23);
            this.linkLabel1.TabIndex = 10;
            // 
            // linkLabel2
            // 
            this.linkLabel2.Location = new System.Drawing.Point(0, 0);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(100, 23);
            this.linkLabel2.TabIndex = 9;
            // 
            // linkLabel3
            // 
            this.linkLabel3.Location = new System.Drawing.Point(0, 0);
            this.linkLabel3.Name = "linkLabel3";
            this.linkLabel3.Size = new System.Drawing.Size(100, 23);
            this.linkLabel3.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(275, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(343, 45);
            this.label1.TabIndex = 4;
            this.label1.Text = "Vehicle Rental System";
            // 
            // btn_Customer_Sign_Up
            // 
            this.btn_Customer_Sign_Up.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btn_Customer_Sign_Up.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_Customer_Sign_Up.FlatAppearance.BorderSize = 0;
            this.btn_Customer_Sign_Up.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Customer_Sign_Up.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btn_Customer_Sign_Up.ForeColor = System.Drawing.Color.White;
            this.btn_Customer_Sign_Up.Location = new System.Drawing.Point(10, 10);
            this.btn_Customer_Sign_Up.Margin = new System.Windows.Forms.Padding(10);
            this.btn_Customer_Sign_Up.Name = "btn_Customer_Sign_Up";
            this.btn_Customer_Sign_Up.Size = new System.Drawing.Size(225, 78);
            this.btn_Customer_Sign_Up.TabIndex = 5;
            this.btn_Customer_Sign_Up.Text = "Customer Sign Up";
            this.btn_Customer_Sign_Up.UseVisualStyleBackColor = false;
            this.btn_Customer_Sign_Up.Click += new System.EventHandler(this.btn_Customer_Sign_Up_Click);
            // 
            // btn_Customer_Sign_In
            // 
            this.btn_Customer_Sign_In.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btn_Customer_Sign_In.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_Customer_Sign_In.FlatAppearance.BorderSize = 0;
            this.btn_Customer_Sign_In.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Customer_Sign_In.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btn_Customer_Sign_In.ForeColor = System.Drawing.Color.White;
            this.btn_Customer_Sign_In.Location = new System.Drawing.Point(255, 10);
            this.btn_Customer_Sign_In.Margin = new System.Windows.Forms.Padding(10);
            this.btn_Customer_Sign_In.Name = "btn_Customer_Sign_In";
            this.btn_Customer_Sign_In.Size = new System.Drawing.Size(226, 78);
            this.btn_Customer_Sign_In.TabIndex = 6;
            this.btn_Customer_Sign_In.Text = "Customer Sign In";
            this.btn_Customer_Sign_In.UseVisualStyleBackColor = false;
            this.btn_Customer_Sign_In.Click += new System.EventHandler(this.btn_Customer_Sign_In_Click);
            // 
            // btn_Admin_Sign_In
            // 
            this.btn_Admin_Sign_In.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182)))));
            this.tableLayoutPanel1.SetColumnSpan(this.btn_Admin_Sign_In, 2);
            this.btn_Admin_Sign_In.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_Admin_Sign_In.FlatAppearance.BorderSize = 0;
            this.btn_Admin_Sign_In.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Admin_Sign_In.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btn_Admin_Sign_In.ForeColor = System.Drawing.Color.White;
            this.btn_Admin_Sign_In.Location = new System.Drawing.Point(10, 108);
            this.btn_Admin_Sign_In.Margin = new System.Windows.Forms.Padding(10);
            this.btn_Admin_Sign_In.Name = "btn_Admin_Sign_In";
            this.btn_Admin_Sign_In.Size = new System.Drawing.Size(471, 79);
            this.btn_Admin_Sign_In.TabIndex = 7;
            this.btn_Admin_Sign_In.Text = "Admin Sign In";
            this.btn_Admin_Sign_In.UseVisualStyleBackColor = false;
            this.btn_Admin_Sign_In.Click += new System.EventHandler(this.btn_Admin_Sign_In_Click);
            // 
            // Btn_Exit
            // 
            this.Btn_Exit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_Exit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.Btn_Exit.FlatAppearance.BorderSize = 0;
            this.Btn_Exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Exit.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.Btn_Exit.ForeColor = System.Drawing.Color.White;
            this.Btn_Exit.Location = new System.Drawing.Point(708, 20);
            this.Btn_Exit.Name = "Btn_Exit";
            this.Btn_Exit.Size = new System.Drawing.Size(80, 35);
            this.Btn_Exit.TabIndex = 11;
            this.Btn_Exit.Text = "Exit";
            this.Btn_Exit.UseVisualStyleBackColor = false;
            this.Btn_Exit.Click += new System.EventHandler(this.Btn_Exit_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.btn_Customer_Sign_Up, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btn_Customer_Sign_In, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btn_Admin_Sign_In, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(145, 128);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(491, 197);
            this.tableLayoutPanel1.TabIndex = 12;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.Btn_Exit);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.linkLabel3);
            this.Controls.Add(this.linkLabel2);
            this.Controls.Add(this.linkLabel1);
            this.MinimumSize = new System.Drawing.Size(600, 400);
            this.Name = "Form1";
            this.Text = "Vehicle Rental System";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.LinkLabel linkLabel2;
        private System.Windows.Forms.LinkLabel linkLabel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_Customer_Sign_Up;
        private System.Windows.Forms.Button btn_Customer_Sign_In;
        private System.Windows.Forms.Button btn_Admin_Sign_In;
        private System.Windows.Forms.Button Btn_Exit;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}

