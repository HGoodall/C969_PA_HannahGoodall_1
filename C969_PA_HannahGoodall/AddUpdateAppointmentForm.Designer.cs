namespace C969_PA_HannahGoodall
{
    partial class AddUpdateAppointmentForm
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.customerIdTextBox = new System.Windows.Forms.TextBox();
            this.typeTextBox = new System.Windows.Forms.TextBox();
            this.startTimePicker = new System.Windows.Forms.DateTimePicker();
            this.endTimePicker = new System.Windows.Forms.DateTimePicker();
            this.saveApptButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.typeToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.custIdToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.startToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.endToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label1.Location = new System.Drawing.Point(75, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Type:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label2.Location = new System.Drawing.Point(45, 189);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 15);
            this.label2.TabIndex = 7;
            this.label2.Text = "Start Time:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label3.Location = new System.Drawing.Point(48, 244);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 15);
            this.label3.TabIndex = 10;
            this.label3.Text = "End Time:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label5.Location = new System.Drawing.Point(33, 130);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 15);
            this.label5.TabIndex = 3;
            this.label5.Text = "Customer ID:";
            // 
            // customerIdTextBox
            // 
            this.customerIdTextBox.Location = new System.Drawing.Point(125, 129);
            this.customerIdTextBox.Name = "customerIdTextBox";
            this.customerIdTextBox.Size = new System.Drawing.Size(196, 20);
            this.customerIdTextBox.TabIndex = 4;
            this.customerIdTextBox.TextChanged += new System.EventHandler(this.customerIdTextBox_TextChanged);
            // 
            // typeTextBox
            // 
            this.typeTextBox.Location = new System.Drawing.Point(125, 77);
            this.typeTextBox.Name = "typeTextBox";
            this.typeTextBox.Size = new System.Drawing.Size(196, 20);
            this.typeTextBox.TabIndex = 2;
            this.typeTextBox.TextChanged += new System.EventHandler(this.typeTextBox_TextChanged);
            // 
            // startTimePicker
            // 
            this.startTimePicker.Location = new System.Drawing.Point(125, 185);
            this.startTimePicker.Name = "startTimePicker";
            this.startTimePicker.Size = new System.Drawing.Size(196, 20);
            this.startTimePicker.TabIndex = 8;
            // 
            // endTimePicker
            // 
            this.endTimePicker.Location = new System.Drawing.Point(125, 240);
            this.endTimePicker.Name = "endTimePicker";
            this.endTimePicker.Size = new System.Drawing.Size(196, 20);
            this.endTimePicker.TabIndex = 11;
            // 
            // saveApptButton
            // 
            this.saveApptButton.Location = new System.Drawing.Point(125, 313);
            this.saveApptButton.Name = "saveApptButton";
            this.saveApptButton.Size = new System.Drawing.Size(75, 23);
            this.saveApptButton.TabIndex = 14;
            this.saveApptButton.Text = "Save";
            this.saveApptButton.UseVisualStyleBackColor = true;
            this.saveApptButton.Click += new System.EventHandler(this.saveApptButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(246, 313);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 15;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // AddUpdateAppointmentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(397, 374);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.saveApptButton);
            this.Controls.Add(this.endTimePicker);
            this.Controls.Add(this.startTimePicker);
            this.Controls.Add(this.typeTextBox);
            this.Controls.Add(this.customerIdTextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "AddUpdateAppointmentForm";
            this.Text = "AddUpdateAppointmentForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox customerIdTextBox;
        private System.Windows.Forms.TextBox typeTextBox;
        private System.Windows.Forms.DateTimePicker startTimePicker;
        private System.Windows.Forms.DateTimePicker endTimePicker;
        private System.Windows.Forms.Button saveApptButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.ToolTip typeToolTip;
        private System.Windows.Forms.ToolTip custIdToolTip;
        private System.Windows.Forms.ToolTip startToolTip;
        private System.Windows.Forms.ToolTip endToolTip;
    }
}