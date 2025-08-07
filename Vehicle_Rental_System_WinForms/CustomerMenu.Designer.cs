namespace Vehicle_Rental_System_WinForms
{
    partial class CustomerMenu
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
            this.btnSignOUt = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.Btn_Customer_Sign_Out = new System.Windows.Forms.Button();
            this.Btn_Customer_View_All_Vehicles = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnSignOUt
            // 
            this.btnSignOUt.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnSignOUt.AutoSize = true;
            this.btnSignOUt.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.btnSignOUt.Location = new System.Drawing.Point(300, 30);
            this.btnSignOUt.Name = "btnSignOUt";
            this.btnSignOUt.Size = new System.Drawing.Size(259, 45);
            this.btnSignOUt.TabIndex = 0;
            this.btnSignOUt.Text = "Customer Menu";
            this.btnSignOUt.Click += new System.EventHandler(this.label1_Click);
            // 
            // linkLabel1
            // 
            this.linkLabel1.Location = new System.Drawing.Point(0, 0);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(100, 23);
            this.linkLabel1.TabIndex = 4;
            // 
            // Btn_Customer_Sign_Out
            // 
            this.Btn_Customer_Sign_Out.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_Customer_Sign_Out.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.Btn_Customer_Sign_Out.FlatAppearance.BorderSize = 0;
            this.Btn_Customer_Sign_Out.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Customer_Sign_Out.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.Btn_Customer_Sign_Out.ForeColor = System.Drawing.Color.White;
            this.Btn_Customer_Sign_Out.Location = new System.Drawing.Point(680, 20);
            this.Btn_Customer_Sign_Out.Name = "Btn_Customer_Sign_Out";
            this.Btn_Customer_Sign_Out.Size = new System.Drawing.Size(100, 40);
            this.Btn_Customer_Sign_Out.TabIndex = 2;
            this.Btn_Customer_Sign_Out.Text = "Sign Out";
            this.Btn_Customer_Sign_Out.UseVisualStyleBackColor = false;
            this.Btn_Customer_Sign_Out.Click += new System.EventHandler(this.Btn_Customer_Sign_Out_Click);
            // 
            // Btn_Customer_View_All_Vehicles
            // 
            this.Btn_Customer_View_All_Vehicles.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Btn_Customer_View_All_Vehicles.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.Btn_Customer_View_All_Vehicles.FlatAppearance.BorderSize = 0;
            this.Btn_Customer_View_All_Vehicles.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Customer_View_All_Vehicles.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.Btn_Customer_View_All_Vehicles.ForeColor = System.Drawing.Color.White;
            this.Btn_Customer_View_All_Vehicles.Location = new System.Drawing.Point(300, 180);
            this.Btn_Customer_View_All_Vehicles.Name = "Btn_Customer_View_All_Vehicles";
            this.Btn_Customer_View_All_Vehicles.Size = new System.Drawing.Size(229, 69);
            this.Btn_Customer_View_All_Vehicles.TabIndex = 3;
            this.Btn_Customer_View_All_Vehicles.Text = "View All Vehicles";
            this.Btn_Customer_View_All_Vehicles.UseVisualStyleBackColor = false;
            this.Btn_Customer_View_All_Vehicles.Click += new System.EventHandler(this.Btn_Customer_View_All_Vehicles_Click);
            // 
            // CustomerMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(242)))), ((int)(((byte)(245)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Btn_Customer_View_All_Vehicles);
            this.Controls.Add(this.Btn_Customer_Sign_Out);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.btnSignOUt);
            this.MinimumSize = new System.Drawing.Size(600, 400);
            this.Name = "CustomerMenu";
            this.Text = "Customer Menu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label btnSignOUt;
        private System.Windows.Forms.LinkLabel linkLabel1;
        //private System.Windows.Forms.Button btnSignOut;
        private System.Windows.Forms.Button Btn_Customer_Sign_Out;
        private System.Windows.Forms.Button Btn_Customer_View_All_Vehicles;
    }
}