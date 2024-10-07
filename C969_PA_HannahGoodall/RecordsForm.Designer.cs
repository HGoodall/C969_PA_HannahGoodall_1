namespace C969_PA_HannahGoodall
{
    partial class RecordsForm
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
            this.customerDataGrid = new System.Windows.Forms.DataGridView();
            this.appointmentDataGrid = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.addCustomerButton = new System.Windows.Forms.Button();
            this.updateCustomerButton = new System.Windows.Forms.Button();
            this.deleteCustomerButton = new System.Windows.Forms.Button();
            this.deleteApptButton = new System.Windows.Forms.Button();
            this.updateApptButton = new System.Windows.Forms.Button();
            this.addApptButton = new System.Windows.Forms.Button();
            this.closeButton = new System.Windows.Forms.Button();
            this.ApptByDayPicker = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.utcApptsRadio = new System.Windows.Forms.RadioButton();
            this.localApptsRadio = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.userScheduleButton = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.customerAppointmentsButton = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.apptTypeReportButton = new System.Windows.Forms.Button();
            this.userIdScheduleTextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.customerDataGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.appointmentDataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // customerDataGrid
            // 
            this.customerDataGrid.AllowUserToAddRows = false;
            this.customerDataGrid.AllowUserToDeleteRows = false;
            this.customerDataGrid.AllowUserToResizeColumns = false;
            this.customerDataGrid.AllowUserToResizeRows = false;
            this.customerDataGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.customerDataGrid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.customerDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.customerDataGrid.Location = new System.Drawing.Point(41, 32);
            this.customerDataGrid.Name = "customerDataGrid";
            this.customerDataGrid.ReadOnly = true;
            this.customerDataGrid.RowHeadersVisible = false;
            this.customerDataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.customerDataGrid.Size = new System.Drawing.Size(336, 248);
            this.customerDataGrid.TabIndex = 1;
            // 
            // appointmentDataGrid
            // 
            this.appointmentDataGrid.AllowUserToAddRows = false;
            this.appointmentDataGrid.AllowUserToDeleteRows = false;
            this.appointmentDataGrid.AllowUserToResizeColumns = false;
            this.appointmentDataGrid.AllowUserToResizeRows = false;
            this.appointmentDataGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.appointmentDataGrid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.appointmentDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.appointmentDataGrid.Location = new System.Drawing.Point(440, 32);
            this.appointmentDataGrid.Name = "appointmentDataGrid";
            this.appointmentDataGrid.ReadOnly = true;
            this.appointmentDataGrid.RowHeadersVisible = false;
            this.appointmentDataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.appointmentDataGrid.Size = new System.Drawing.Size(445, 248);
            this.appointmentDataGrid.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label1.Location = new System.Drawing.Point(38, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Customers";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label2.Location = new System.Drawing.Point(437, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Appointments";
            // 
            // addCustomerButton
            // 
            this.addCustomerButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.addCustomerButton.Location = new System.Drawing.Point(41, 286);
            this.addCustomerButton.Name = "addCustomerButton";
            this.addCustomerButton.Size = new System.Drawing.Size(72, 23);
            this.addCustomerButton.TabIndex = 5;
            this.addCustomerButton.Text = "Add";
            this.addCustomerButton.UseVisualStyleBackColor = true;
            this.addCustomerButton.Click += new System.EventHandler(this.addCustomerButton_Click);
            // 
            // updateCustomerButton
            // 
            this.updateCustomerButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.updateCustomerButton.Location = new System.Drawing.Point(128, 286);
            this.updateCustomerButton.Name = "updateCustomerButton";
            this.updateCustomerButton.Size = new System.Drawing.Size(72, 23);
            this.updateCustomerButton.TabIndex = 6;
            this.updateCustomerButton.Text = "Update";
            this.updateCustomerButton.UseVisualStyleBackColor = true;
            this.updateCustomerButton.Click += new System.EventHandler(this.updateCustomerButton_Click);
            // 
            // deleteCustomerButton
            // 
            this.deleteCustomerButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.deleteCustomerButton.Location = new System.Drawing.Point(215, 286);
            this.deleteCustomerButton.Name = "deleteCustomerButton";
            this.deleteCustomerButton.Size = new System.Drawing.Size(72, 23);
            this.deleteCustomerButton.TabIndex = 7;
            this.deleteCustomerButton.Text = "Delete";
            this.deleteCustomerButton.UseVisualStyleBackColor = true;
            this.deleteCustomerButton.Click += new System.EventHandler(this.deleteCustomerButton_Click);
            // 
            // deleteApptButton
            // 
            this.deleteApptButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.deleteApptButton.Location = new System.Drawing.Point(614, 286);
            this.deleteApptButton.Name = "deleteApptButton";
            this.deleteApptButton.Size = new System.Drawing.Size(72, 23);
            this.deleteApptButton.TabIndex = 10;
            this.deleteApptButton.Text = "Delete";
            this.deleteApptButton.UseVisualStyleBackColor = true;
            this.deleteApptButton.Click += new System.EventHandler(this.deleteApptButton_Click);
            // 
            // updateApptButton
            // 
            this.updateApptButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.updateApptButton.Location = new System.Drawing.Point(527, 286);
            this.updateApptButton.Name = "updateApptButton";
            this.updateApptButton.Size = new System.Drawing.Size(72, 23);
            this.updateApptButton.TabIndex = 9;
            this.updateApptButton.Text = "Update";
            this.updateApptButton.UseVisualStyleBackColor = true;
            this.updateApptButton.Click += new System.EventHandler(this.updateApptButton_Click);
            // 
            // addApptButton
            // 
            this.addApptButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.addApptButton.Location = new System.Drawing.Point(440, 286);
            this.addApptButton.Name = "addApptButton";
            this.addApptButton.Size = new System.Drawing.Size(72, 23);
            this.addApptButton.TabIndex = 8;
            this.addApptButton.Text = "Add";
            this.addApptButton.UseVisualStyleBackColor = true;
            this.addApptButton.Click += new System.EventHandler(this.addApptButton_Click);
            // 
            // closeButton
            // 
            this.closeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.closeButton.Location = new System.Drawing.Point(839, 373);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(80, 23);
            this.closeButton.TabIndex = 11;
            this.closeButton.Text = "Close";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // ApptByDayPicker
            // 
            this.ApptByDayPicker.Location = new System.Drawing.Point(579, 322);
            this.ApptByDayPicker.Name = "ApptByDayPicker";
            this.ApptByDayPicker.Size = new System.Drawing.Size(200, 20);
            this.ApptByDayPicker.TabIndex = 13;
            this.ApptByDayPicker.ValueChanged += new System.EventHandler(this.ApptByDayPicker_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(437, 325);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(137, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "View Appointments By Day:";
            // 
            // utcApptsRadio
            // 
            this.utcApptsRadio.AutoSize = true;
            this.utcApptsRadio.Checked = true;
            this.utcApptsRadio.Location = new System.Drawing.Point(440, 359);
            this.utcApptsRadio.Name = "utcApptsRadio";
            this.utcApptsRadio.Size = new System.Drawing.Size(140, 17);
            this.utcApptsRadio.TabIndex = 15;
            this.utcApptsRadio.TabStop = true;
            this.utcApptsRadio.Text = "UTC Time Appointments";
            this.utcApptsRadio.UseVisualStyleBackColor = true;
            this.utcApptsRadio.CheckedChanged += new System.EventHandler(this.utcApptsRadio_CheckedChanged);
            // 
            // localApptsRadio
            // 
            this.localApptsRadio.AutoSize = true;
            this.localApptsRadio.Location = new System.Drawing.Point(586, 359);
            this.localApptsRadio.Name = "localApptsRadio";
            this.localApptsRadio.Size = new System.Drawing.Size(144, 17);
            this.localApptsRadio.TabIndex = 16;
            this.localApptsRadio.Text = "Local Time Appointments";
            this.localApptsRadio.UseVisualStyleBackColor = true;
            this.localApptsRadio.CheckedChanged += new System.EventHandler(this.localApptsRadio_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(38, 314);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(134, 16);
            this.label4.TabIndex = 17;
            this.label4.Text = "Generate Reports:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // userScheduleButton
            // 
            this.userScheduleButton.Location = new System.Drawing.Point(273, 356);
            this.userScheduleButton.Name = "userScheduleButton";
            this.userScheduleButton.Size = new System.Drawing.Size(65, 23);
            this.userScheduleButton.TabIndex = 18;
            this.userScheduleButton.Text = "Generate";
            this.userScheduleButton.UseVisualStyleBackColor = true;
            this.userScheduleButton.Click += new System.EventHandler(this.userScheduleButton_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(38, 361);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(154, 13);
            this.label5.TabIndex = 19;
            this.label5.Text = "Enter User Id to See Schedule:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(38, 384);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(219, 13);
            this.label6.TabIndex = 21;
            this.label6.Text = "Number of Appointments For Each Customer:";
            // 
            // customerAppointmentsButton
            // 
            this.customerAppointmentsButton.Location = new System.Drawing.Point(260, 379);
            this.customerAppointmentsButton.Name = "customerAppointmentsButton";
            this.customerAppointmentsButton.Size = new System.Drawing.Size(65, 23);
            this.customerAppointmentsButton.TabIndex = 20;
            this.customerAppointmentsButton.Text = "Generate";
            this.customerAppointmentsButton.UseVisualStyleBackColor = true;
            this.customerAppointmentsButton.Click += new System.EventHandler(this.customerAppointmentsButton_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(38, 338);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(200, 13);
            this.label7.TabIndex = 23;
            this.label7.Text = "Number of Appointment Types by Month:";
            // 
            // apptTypeReportButton
            // 
            this.apptTypeReportButton.Location = new System.Drawing.Point(239, 333);
            this.apptTypeReportButton.Name = "apptTypeReportButton";
            this.apptTypeReportButton.Size = new System.Drawing.Size(65, 23);
            this.apptTypeReportButton.TabIndex = 22;
            this.apptTypeReportButton.Text = "Generate";
            this.apptTypeReportButton.UseVisualStyleBackColor = true;
            this.apptTypeReportButton.Click += new System.EventHandler(this.apptTypeReportButton_Click);
            // 
            // userIdScheduleTextBox
            // 
            this.userIdScheduleTextBox.Location = new System.Drawing.Point(195, 358);
            this.userIdScheduleTextBox.Name = "userIdScheduleTextBox";
            this.userIdScheduleTextBox.Size = new System.Drawing.Size(72, 20);
            this.userIdScheduleTextBox.TabIndex = 24;
            // 
            // RecordsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(931, 408);
            this.Controls.Add(this.userIdScheduleTextBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.apptTypeReportButton);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.customerAppointmentsButton);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.userScheduleButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.localApptsRadio);
            this.Controls.Add(this.utcApptsRadio);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ApptByDayPicker);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.deleteApptButton);
            this.Controls.Add(this.updateApptButton);
            this.Controls.Add(this.addApptButton);
            this.Controls.Add(this.deleteCustomerButton);
            this.Controls.Add(this.updateCustomerButton);
            this.Controls.Add(this.addCustomerButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.appointmentDataGrid);
            this.Controls.Add(this.customerDataGrid);
            this.Name = "RecordsForm";
            this.Text = "Customer Records";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.CustomerRecordsForm_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.customerDataGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.appointmentDataGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView customerDataGrid;
        private System.Windows.Forms.DataGridView appointmentDataGrid;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button addCustomerButton;
        private System.Windows.Forms.Button updateCustomerButton;
        private System.Windows.Forms.Button deleteCustomerButton;
        private System.Windows.Forms.Button deleteApptButton;
        private System.Windows.Forms.Button updateApptButton;
        private System.Windows.Forms.Button addApptButton;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.DateTimePicker ApptByDayPicker;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton utcApptsRadio;
        private System.Windows.Forms.RadioButton localApptsRadio;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button userScheduleButton;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button customerAppointmentsButton;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button apptTypeReportButton;
        private System.Windows.Forms.TextBox userIdScheduleTextBox;
    }
}