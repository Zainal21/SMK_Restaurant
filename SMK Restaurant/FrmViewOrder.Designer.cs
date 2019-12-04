namespace SMK_Restaurant
{
    partial class FrmViewOrder
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
            this.cbxOrderid = new System.Windows.Forms.ComboBox();
            this.dg1 = new System.Windows.Forms.DataGridView();
            this.Action = new System.Windows.Forms.DataGridViewComboBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dg1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(220, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(180, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "Form View Order";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(165, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Order Id";
            // 
            // cbxOrderid
            // 
            this.cbxOrderid.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxOrderid.FormattingEnabled = true;
            this.cbxOrderid.Location = new System.Drawing.Point(225, 61);
            this.cbxOrderid.Name = "cbxOrderid";
            this.cbxOrderid.Size = new System.Drawing.Size(183, 21);
            this.cbxOrderid.TabIndex = 2;
            this.cbxOrderid.SelectedValueChanged += new System.EventHandler(this.cbxOrderid_SelectedValueChanged);
            // 
            // dg1
            // 
            this.dg1.AllowUserToAddRows = false;
            this.dg1.AllowUserToDeleteRows = false;
            this.dg1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dg1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Action});
            this.dg1.Location = new System.Drawing.Point(12, 100);
            this.dg1.Name = "dg1";
            this.dg1.Size = new System.Drawing.Size(610, 166);
            this.dg1.TabIndex = 3;
            this.dg1.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dg1_CellValueChanged);
            // 
            // Action
            // 
            this.Action.HeaderText = "Action";
            this.Action.Items.AddRange(new object[] {
            "Pending",
            "Cooking",
            "Deliver"});
            this.Action.Name = "Action";
            // 
            // FrmViewOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSkyBlue;
            this.ClientSize = new System.Drawing.Size(634, 294);
            this.Controls.Add(this.dg1);
            this.Controls.Add(this.cbxOrderid);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FrmViewOrder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmViewOrder";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmViewOrder_FormClosing);
            this.Load += new System.EventHandler(this.FrmViewOrder_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dg1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbxOrderid;
        private System.Windows.Forms.DataGridView dg1;
        private System.Windows.Forms.DataGridViewComboBoxColumn Action;
    }
}