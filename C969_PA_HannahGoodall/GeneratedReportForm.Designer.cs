namespace C969_PA_HannahGoodall
{
    partial class GeneratedReportForm
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
            this.typePerMonthReportLabel = new System.Windows.Forms.Label();
            this.userScheduleDataGrid = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.userScheduleDataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // typePerMonthReportLabel
            // 
            this.typePerMonthReportLabel.AutoSize = true;
            this.typePerMonthReportLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.typePerMonthReportLabel.Location = new System.Drawing.Point(40, 40);
            this.typePerMonthReportLabel.Name = "typePerMonthReportLabel";
            this.typePerMonthReportLabel.Size = new System.Drawing.Size(0, 15);
            this.typePerMonthReportLabel.TabIndex = 0;
            // 
            // userScheduleDataGrid
            // 
            this.userScheduleDataGrid.AllowUserToAddRows = false;
            this.userScheduleDataGrid.AllowUserToDeleteRows = false;
            this.userScheduleDataGrid.AllowUserToResizeColumns = false;
            this.userScheduleDataGrid.AllowUserToResizeRows = false;
            this.userScheduleDataGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.userScheduleDataGrid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.userScheduleDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.userScheduleDataGrid.Location = new System.Drawing.Point(12, 40);
            this.userScheduleDataGrid.Name = "userScheduleDataGrid";
            this.userScheduleDataGrid.ReadOnly = true;
            this.userScheduleDataGrid.RowHeadersVisible = false;
            this.userScheduleDataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.userScheduleDataGrid.Size = new System.Drawing.Size(410, 248);
            this.userScheduleDataGrid.TabIndex = 3;
            // 
            // GeneratedReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(440, 318);
            this.Controls.Add(this.userScheduleDataGrid);
            this.Controls.Add(this.typePerMonthReportLabel);
            this.Name = "GeneratedReportForm";
            this.Text = "Generated Report";
            ((System.ComponentModel.ISupportInitialize)(this.userScheduleDataGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label typePerMonthReportLabel;
        private System.Windows.Forms.DataGridView userScheduleDataGrid;
    }
}