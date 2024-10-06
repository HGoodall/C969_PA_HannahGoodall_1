namespace C969_PA_HannahGoodall
{
    partial class DailyApptsForm
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
            this.ApptsDataGrid = new System.Windows.Forms.DataGridView();
            this.apptDateLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ApptsDataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // ApptsDataGrid
            // 
            this.ApptsDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ApptsDataGrid.Location = new System.Drawing.Point(39, 53);
            this.ApptsDataGrid.Name = "ApptsDataGrid";
            this.ApptsDataGrid.RowHeadersVisible = false;
            this.ApptsDataGrid.Size = new System.Drawing.Size(240, 240);
            this.ApptsDataGrid.TabIndex = 0;
            // 
            // apptDateLabel
            // 
            this.apptDateLabel.AutoSize = true;
            this.apptDateLabel.Location = new System.Drawing.Point(73, 28);
            this.apptDateLabel.Name = "apptDateLabel";
            this.apptDateLabel.Size = new System.Drawing.Size(89, 13);
            this.apptDateLabel.TabIndex = 1;
            this.apptDateLabel.Text = "Appointments for ";
            // 
            // DailyApptsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 305);
            this.Controls.Add(this.apptDateLabel);
            this.Controls.Add(this.ApptsDataGrid);
            this.Name = "DailyApptsForm";
            this.Text = "DailyAppointmentsForm";
            ((System.ComponentModel.ISupportInitialize)(this.ApptsDataGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView ApptsDataGrid;
        private System.Windows.Forms.Label apptDateLabel;
    }
}