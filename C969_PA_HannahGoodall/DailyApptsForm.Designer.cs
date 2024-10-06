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
            this.apptDateLabel = new System.Windows.Forms.Label();
            this.ApptsDataGrid = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.ApptsDataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // apptDateLabel
            // 
            this.apptDateLabel.AutoSize = true;
            this.apptDateLabel.Location = new System.Drawing.Point(127, 20);
            this.apptDateLabel.Name = "apptDateLabel";
            this.apptDateLabel.Size = new System.Drawing.Size(89, 13);
            this.apptDateLabel.TabIndex = 1;
            this.apptDateLabel.Text = "Appointments for ";
            // 
            // ApptsDataGrid
            // 
            this.ApptsDataGrid.AllowUserToAddRows = false;
            this.ApptsDataGrid.AllowUserToDeleteRows = false;
            this.ApptsDataGrid.AllowUserToResizeColumns = false;
            this.ApptsDataGrid.AllowUserToResizeRows = false;
            this.ApptsDataGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.ApptsDataGrid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.ApptsDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ApptsDataGrid.Location = new System.Drawing.Point(25, 45);
            this.ApptsDataGrid.Name = "ApptsDataGrid";
            this.ApptsDataGrid.ReadOnly = true;
            this.ApptsDataGrid.RowHeadersVisible = false;
            this.ApptsDataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ApptsDataGrid.Size = new System.Drawing.Size(362, 237);
            this.ApptsDataGrid.TabIndex = 3;
            // 
            // DailyApptsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(411, 305);
            this.Controls.Add(this.ApptsDataGrid);
            this.Controls.Add(this.apptDateLabel);
            this.Name = "DailyApptsForm";
            this.Text = "Daily Appointments";
            ((System.ComponentModel.ISupportInitialize)(this.ApptsDataGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label apptDateLabel;
        private System.Windows.Forms.DataGridView ApptsDataGrid;
    }
}