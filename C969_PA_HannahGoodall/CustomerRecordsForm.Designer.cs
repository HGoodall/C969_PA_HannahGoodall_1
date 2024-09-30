namespace C969_PA_HannahGoodall
{
    partial class CustomerRecordsForm
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.addCustomerButton = new System.Windows.Forms.Button();
            this.updateCustomerButton = new System.Windows.Forms.Button();
            this.deleteCustomerButton = new System.Windows.Forms.Button();
            this.deleteApptButton = new System.Windows.Forms.Button();
            this.updateApptButton = new System.Windows.Forms.Button();
            this.addApptButton = new System.Windows.Forms.Button();
            this.closeButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.customerDataGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // customerDataGrid
            // 
            this.customerDataGrid.AllowUserToAddRows = false;
            this.customerDataGrid.AllowUserToDeleteRows = false;
            this.customerDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.customerDataGrid.Location = new System.Drawing.Point(41, 52);
            this.customerDataGrid.Name = "customerDataGrid";
            this.customerDataGrid.ReadOnly = true;
            this.customerDataGrid.RowHeadersVisible = false;
            this.customerDataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.customerDataGrid.Size = new System.Drawing.Size(319, 284);
            this.customerDataGrid.TabIndex = 1;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(408, 52);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(304, 284);
            this.dataGridView1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label1.Location = new System.Drawing.Point(38, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Customers";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label2.Location = new System.Drawing.Point(405, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Appointments";
            // 
            // addCustomerButton
            // 
            this.addCustomerButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.addCustomerButton.Location = new System.Drawing.Point(41, 342);
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
            this.updateCustomerButton.Location = new System.Drawing.Point(128, 342);
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
            this.deleteCustomerButton.Location = new System.Drawing.Point(215, 342);
            this.deleteCustomerButton.Name = "deleteCustomerButton";
            this.deleteCustomerButton.Size = new System.Drawing.Size(72, 23);
            this.deleteCustomerButton.TabIndex = 7;
            this.deleteCustomerButton.Text = "Delete";
            this.deleteCustomerButton.UseVisualStyleBackColor = true;
            // 
            // deleteApptButton
            // 
            this.deleteApptButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.deleteApptButton.Location = new System.Drawing.Point(582, 342);
            this.deleteApptButton.Name = "deleteApptButton";
            this.deleteApptButton.Size = new System.Drawing.Size(72, 23);
            this.deleteApptButton.TabIndex = 10;
            this.deleteApptButton.Text = "Delete";
            this.deleteApptButton.UseVisualStyleBackColor = true;
            // 
            // updateApptButton
            // 
            this.updateApptButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.updateApptButton.Location = new System.Drawing.Point(495, 342);
            this.updateApptButton.Name = "updateApptButton";
            this.updateApptButton.Size = new System.Drawing.Size(72, 23);
            this.updateApptButton.TabIndex = 9;
            this.updateApptButton.Text = "Update";
            this.updateApptButton.UseVisualStyleBackColor = true;
            // 
            // addApptButton
            // 
            this.addApptButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.addApptButton.Location = new System.Drawing.Point(408, 342);
            this.addApptButton.Name = "addApptButton";
            this.addApptButton.Size = new System.Drawing.Size(72, 23);
            this.addApptButton.TabIndex = 8;
            this.addApptButton.Text = "Add";
            this.addApptButton.UseVisualStyleBackColor = true;
            // 
            // closeButton
            // 
            this.closeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.closeButton.Location = new System.Drawing.Point(668, 415);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(80, 23);
            this.closeButton.TabIndex = 11;
            this.closeButton.Text = "Close";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // CustomerRecordsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(760, 450);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.deleteApptButton);
            this.Controls.Add(this.updateApptButton);
            this.Controls.Add(this.addApptButton);
            this.Controls.Add(this.deleteCustomerButton);
            this.Controls.Add(this.updateCustomerButton);
            this.Controls.Add(this.addCustomerButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.customerDataGrid);
            this.Name = "CustomerRecordsForm";
            this.Text = "Customer Records";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.CustomerRecordsForm_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.customerDataGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView customerDataGrid;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button addCustomerButton;
        private System.Windows.Forms.Button updateCustomerButton;
        private System.Windows.Forms.Button deleteCustomerButton;
        private System.Windows.Forms.Button deleteApptButton;
        private System.Windows.Forms.Button updateApptButton;
        private System.Windows.Forms.Button addApptButton;
        private System.Windows.Forms.Button closeButton;
    }
}