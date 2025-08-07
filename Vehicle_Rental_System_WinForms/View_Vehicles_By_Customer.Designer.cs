namespace Vehicle_Rental_System_WinForms
{
    partial class View_Vehicles_By_Customer
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
            this.Btn_Back = new System.Windows.Forms.Button();
            this.DataGrid_View = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.DataGrid_View)).BeginInit();
            this.SuspendLayout();
            // 
            // Btn_Back
            // 
            this.Btn_Back.BackColor = System.Drawing.SystemColors.ControlDark;
            this.Btn_Back.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Back.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.Btn_Back.Location = new System.Drawing.Point(26, 28);
            this.Btn_Back.Name = "Btn_Back";
            this.Btn_Back.Size = new System.Drawing.Size(100, 35);
            this.Btn_Back.TabIndex = 0;
            this.Btn_Back.Text = "← Back";
            this.Btn_Back.UseVisualStyleBackColor = false;
            this.Btn_Back.Click += new System.EventHandler(this.Btn_Back_Click);
            // 
            // DataGrid_View
            // 
            this.DataGrid_View.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGrid_View.Location = new System.Drawing.Point(246, 143);
            this.DataGrid_View.Name = "DataGrid_View";
            this.DataGrid_View.RowHeadersWidth = 62;
            this.DataGrid_View.RowTemplate.Height = 28;
            this.DataGrid_View.Size = new System.Drawing.Size(240, 150);
            this.DataGrid_View.TabIndex = 1;
            this.DataGrid_View.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGrid_View_CellContentClick);
            // 
            // View_Vehicles_By_Customer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.DataGrid_View);
            this.Controls.Add(this.Btn_Back);
            this.Name = "View_Vehicles_By_Customer";
            this.Text = "View_Vehicles_By_Customer";
            this.Load += new System.EventHandler(this.View_Vehicles_By_Customer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DataGrid_View)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Btn_Back;
        private System.Windows.Forms.DataGridView DataGrid_View;
    }
}