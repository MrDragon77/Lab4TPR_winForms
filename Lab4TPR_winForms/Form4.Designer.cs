﻿namespace Lab4TPR_winForms
{
    partial class Form4
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
            dataGridView_table_S_IP = new DataGridView();
            label_table_S_PI = new Label();
            numericUpDown_tableID = new NumericUpDown();
            button_SaveChanges = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView_table_S_IP).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown_tableID).BeginInit();
            SuspendLayout();
            // 
            // dataGridView_table_S_IP
            // 
            dataGridView_table_S_IP.AllowUserToAddRows = false;
            dataGridView_table_S_IP.AllowUserToDeleteRows = false;
            dataGridView_table_S_IP.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView_table_S_IP.Location = new Point(52, 52);
            dataGridView_table_S_IP.Margin = new Padding(3, 2, 3, 2);
            dataGridView_table_S_IP.Name = "dataGridView_table_S_IP";
            dataGridView_table_S_IP.RowHeadersWidth = 51;
            dataGridView_table_S_IP.RowTemplate.Height = 29;
            dataGridView_table_S_IP.Size = new Size(659, 410);
            dataGridView_table_S_IP.TabIndex = 2;
            dataGridView_table_S_IP.RowsAdded += dataGridView_table_S_IP_RowsAdded;
            dataGridView_table_S_IP.SelectionChanged += dataGridView_table_S_IP_SelectionChanged;
            // 
            // label_table_S_PI
            // 
            label_table_S_PI.AutoSize = true;
            label_table_S_PI.Location = new Point(52, 35);
            label_table_S_PI.Name = "label_table_S_PI";
            label_table_S_PI.Size = new Size(233, 15);
            label_table_S_PI.TabIndex = 3;
            label_table_S_PI.Text = "Таблица связей альтернатив и критериев";
            // 
            // numericUpDown_tableID
            // 
            numericUpDown_tableID.Location = new Point(549, 11);
            numericUpDown_tableID.Margin = new Padding(3, 2, 3, 2);
            numericUpDown_tableID.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDown_tableID.Name = "numericUpDown_tableID";
            numericUpDown_tableID.Size = new Size(162, 23);
            numericUpDown_tableID.TabIndex = 6;
            numericUpDown_tableID.Value = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDown_tableID.ValueChanged += numericUpDown_tableID_ValueChanged;
            // 
            // button_SaveChanges
            // 
            button_SaveChanges.Location = new Point(660, 493);
            button_SaveChanges.Margin = new Padding(3, 2, 3, 2);
            button_SaveChanges.Name = "button_SaveChanges";
            button_SaveChanges.Size = new Size(176, 22);
            button_SaveChanges.TabIndex = 7;
            button_SaveChanges.Text = "Сохранить изменения";
            button_SaveChanges.UseVisualStyleBackColor = true;
            button_SaveChanges.Click += button_SaveChanges_Click;
            // 
            // Form4
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(885, 631);
            Controls.Add(button_SaveChanges);
            Controls.Add(numericUpDown_tableID);
            Controls.Add(label_table_S_PI);
            Controls.Add(dataGridView_table_S_IP);
            Name = "Form4";
            Text = "Редактирование связей состояний";
            Load += Form4_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView_table_S_IP).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown_tableID).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView_table_S_IP;
        private Label label_table_S_PI;
        private NumericUpDown numericUpDown_tableID;
        private Button button_SaveChanges;
    }
}