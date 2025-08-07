namespace Vehicle_Rental_System_WinForms
{
    partial class AddVehicle
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.txtBrandModel = new System.Windows.Forms.TextBox();
            this.txtMileage = new System.Windows.Forms.TextBox();
            this.txtRegistrationNumber = new System.Windows.Forms.TextBox();
            this.txtSeatingCapacity = new System.Windows.Forms.TextBox();
            this.txtRentalRate = new System.Windows.Forms.TextBox();
            this.txtIsAvailable = new System.Windows.Forms.TextBox();
            this.btnBack = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(320, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(197, 45);
            this.label1.TabIndex = 0;
            this.label1.Text = "Add Vehicle";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label2.Location = new System.Drawing.Point(91, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(125, 28);
            this.label2.TabIndex = 1;
            this.label2.Text = "Brand Model";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label3.Location = new System.Drawing.Point(134, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 28);
            this.label3.TabIndex = 2;
            this.label3.Text = "Mileage";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label4.Location = new System.Drawing.Point(22, 98);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(194, 28);
            this.label4.TabIndex = 3;
            this.label4.Text = "Registration Number";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label5.Location = new System.Drawing.Point(58, 143);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(158, 28);
            this.label5.TabIndex = 4;
            this.label5.Text = "Seating Capacity";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label6.Location = new System.Drawing.Point(106, 188);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(110, 28);
            this.label6.TabIndex = 5;
            this.label6.Text = "Rental Rate";
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label7.Location = new System.Drawing.Point(111, 233);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(105, 28);
            this.label7.TabIndex = 6;
            this.label7.Text = "IsAvailable";
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(340, 380);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(120, 45);
            this.button1.TabIndex = 7;
            this.button1.Text = "Add";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtBrandModel
            // 
            this.txtBrandModel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBrandModel.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtBrandModel.Location = new System.Drawing.Point(222, 5);
            this.txtBrandModel.Name = "txtBrandModel";
            this.txtBrandModel.Size = new System.Drawing.Size(315, 34);
            this.txtBrandModel.TabIndex = 8;
            this.txtBrandModel.TextChanged += new System.EventHandler(this.txtBrandModel_TextChanged);
            // 
            // txtMileage
            // 
            this.txtMileage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMileage.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtMileage.Location = new System.Drawing.Point(222, 50);
            this.txtMileage.Name = "txtMileage";
            this.txtMileage.Size = new System.Drawing.Size(315, 34);
            this.txtMileage.TabIndex = 9;
            // 
            // txtRegistrationNumber
            // 
            this.txtRegistrationNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRegistrationNumber.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtRegistrationNumber.Location = new System.Drawing.Point(222, 95);
            this.txtRegistrationNumber.Name = "txtRegistrationNumber";
            this.txtRegistrationNumber.Size = new System.Drawing.Size(315, 34);
            this.txtRegistrationNumber.TabIndex = 10;
            // 
            // txtSeatingCapacity
            // 
            this.txtSeatingCapacity.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSeatingCapacity.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtSeatingCapacity.Location = new System.Drawing.Point(222, 140);
            this.txtSeatingCapacity.Name = "txtSeatingCapacity";
            this.txtSeatingCapacity.Size = new System.Drawing.Size(315, 34);
            this.txtSeatingCapacity.TabIndex = 11;
            // 
            // txtRentalRate
            // 
            this.txtRentalRate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRentalRate.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtRentalRate.Location = new System.Drawing.Point(222, 185);
            this.txtRentalRate.Name = "txtRentalRate";
            this.txtRentalRate.Size = new System.Drawing.Size(315, 34);
            this.txtRentalRate.TabIndex = 12;
            // 
            // txtIsAvailable
            // 
            this.txtIsAvailable.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtIsAvailable.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtIsAvailable.Location = new System.Drawing.Point(222, 230);
            this.txtIsAvailable.Name = "txtIsAvailable";
            this.txtIsAvailable.Size = new System.Drawing.Size(315, 34);
            this.txtIsAvailable.TabIndex = 13;
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnBack.FlatAppearance.BorderSize = 0;
            this.btnBack.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.btnBack.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(134)))), ((int)(((byte)(193)))));
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnBack.ForeColor = System.Drawing.Color.White;
            this.btnBack.Location = new System.Drawing.Point(20, 20);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(100, 40);
            this.btnBack.TabIndex = 14;
            this.btnBack.Text = "← Back";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 219F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 221F));
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtBrandModel, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtMileage, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtRegistrationNumber, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtSeatingCapacity, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.label6, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.txtRentalRate, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.label7, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.txtIsAvailable, 1, 5);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(160, 100);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(540, 270);
            this.tableLayoutPanel1.TabIndex = 15;
            // 
            // AddVehicle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(242)))), ((int)(((byte)(245)))));
            this.ClientSize = new System.Drawing.Size(800, 500);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.MinimumSize = new System.Drawing.Size(700, 500);
            this.Name = "AddVehicle";
            this.Text = "Add Vehicle";
            this.Load += new System.EventHandler(this.AddVehicle_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtBrandModel;
        private System.Windows.Forms.TextBox txtMileage;
        private System.Windows.Forms.TextBox txtRegistrationNumber;
        private System.Windows.Forms.TextBox txtSeatingCapacity;
        private System.Windows.Forms.TextBox txtRentalRate;
        private System.Windows.Forms.TextBox txtIsAvailable;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}