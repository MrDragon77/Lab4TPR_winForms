namespace Lab4TPR_winForms
{
    partial class Form3
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
            dataGridView_results = new DataGridView();
            numericUpDown_tableID = new NumericUpDown();
            numericUpDown_phaseID = new NumericUpDown();
            label_ = new Label();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView_results).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown_tableID).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown_phaseID).BeginInit();
            SuspendLayout();
            // 
            // dataGridView_results
            // 
            dataGridView_results.AllowUserToAddRows = false;
            dataGridView_results.AllowUserToDeleteRows = false;
            dataGridView_results.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView_results.ColumnHeadersVisible = false;
            dataGridView_results.Location = new Point(33, 126);
            dataGridView_results.Margin = new Padding(3, 2, 3, 2);
            dataGridView_results.Name = "dataGridView_results";
            dataGridView_results.ReadOnly = true;
            dataGridView_results.RowHeadersVisible = false;
            dataGridView_results.RowHeadersWidth = 51;
            dataGridView_results.RowTemplate.Height = 29;
            dataGridView_results.Size = new Size(659, 263);
            dataGridView_results.TabIndex = 2;
            // 
            // numericUpDown_tableID
            // 
            numericUpDown_tableID.Location = new Point(530, 87);
            numericUpDown_tableID.Margin = new Padding(3, 2, 3, 2);
            numericUpDown_tableID.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDown_tableID.Name = "numericUpDown_tableID";
            numericUpDown_tableID.Size = new Size(162, 23);
            numericUpDown_tableID.TabIndex = 4;
            numericUpDown_tableID.Value = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDown_tableID.ValueChanged += numericUpDown_tableID_ValueChanged;
            // 
            // numericUpDown_phaseID
            // 
            numericUpDown_phaseID.Location = new Point(87, 29);
            numericUpDown_phaseID.Margin = new Padding(3, 2, 3, 2);
            numericUpDown_phaseID.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDown_phaseID.Name = "numericUpDown_phaseID";
            numericUpDown_phaseID.Size = new Size(162, 23);
            numericUpDown_phaseID.TabIndex = 5;
            numericUpDown_phaseID.Value = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDown_phaseID.ValueChanged += numericUpDown_phaseID_ValueChanged;
            // 
            // label_
            // 
            label_.AutoSize = true;
            label_.Location = new Point(33, 31);
            label_.Name = "label_";
            label_.Size = new Size(48, 15);
            label_.TabIndex = 6;
            label_.Text = "Этап №";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(455, 89);
            label1.Name = "label1";
            label1.Size = new Size(69, 15);
            label1.TabIndex = 7;
            label1.Text = "Таблица №";
            // 
            // Form3
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(858, 481);
            Controls.Add(label1);
            Controls.Add(label_);
            Controls.Add(numericUpDown_phaseID);
            Controls.Add(numericUpDown_tableID);
            Controls.Add(dataGridView_results);
            Margin = new Padding(3, 2, 3, 2);
            Name = "Form3";
            Text = "Результаты моделирования";
            Load += Form3_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView_results).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown_tableID).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown_phaseID).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView_results;
        private NumericUpDown numericUpDown_tableID;
        private NumericUpDown numericUpDown_phaseID;
        private Label label_;
        private Label label1;
    }
}