namespace Lab4TPR_winForms
{
    partial class Form2
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
            label_table_A = new Label();
            dataGridView_table_A = new DataGridView();
            dataGridView_table_K = new DataGridView();
            numericUpDown_tableID = new NumericUpDown();
            button_SaveChanges = new Button();
            label_table_P = new Label();
            button_Graph = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView_table_A).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView_table_K).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown_tableID).BeginInit();
            SuspendLayout();
            // 
            // label_table_A
            // 
            label_table_A.AutoSize = true;
            label_table_A.Location = new Point(38, 34);
            label_table_A.Name = "label_table_A";
            label_table_A.Size = new Size(124, 15);
            label_table_A.TabIndex = 0;
            label_table_A.Text = "Таблица альтернатив";
            // 
            // dataGridView_table_A
            // 
            dataGridView_table_A.AllowUserToDeleteRows = false;
            dataGridView_table_A.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView_table_A.Location = new Point(38, 51);
            dataGridView_table_A.Margin = new Padding(3, 2, 3, 2);
            dataGridView_table_A.Name = "dataGridView_table_A";
            dataGridView_table_A.RowHeadersWidth = 51;
            dataGridView_table_A.RowTemplate.Height = 29;
            dataGridView_table_A.Size = new Size(623, 204);
            dataGridView_table_A.TabIndex = 1;
            dataGridView_table_A.CellContentClick += dataGridView_table_A_CellContentClick;
            dataGridView_table_A.RowsAdded += dataGridView_table_I_RowsAdded;
            dataGridView_table_A.SelectionChanged += dataGridView_table_I_SelectionChanged;
            // 
            // dataGridView_table_K
            // 
            dataGridView_table_K.AllowUserToDeleteRows = false;
            dataGridView_table_K.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView_table_K.Location = new Point(38, 274);
            dataGridView_table_K.Margin = new Padding(3, 2, 3, 2);
            dataGridView_table_K.Name = "dataGridView_table_K";
            dataGridView_table_K.RowHeadersWidth = 51;
            dataGridView_table_K.RowTemplate.Height = 29;
            dataGridView_table_K.Size = new Size(623, 196);
            dataGridView_table_K.TabIndex = 2;
            dataGridView_table_K.RowsAdded += dataGridView_table_P_RowsAdded;
            dataGridView_table_K.SelectionChanged += dataGridView_table_P_SelectionChanged;
            // 
            // numericUpDown_tableID
            // 
            numericUpDown_tableID.Location = new Point(499, 24);
            numericUpDown_tableID.Margin = new Padding(3, 2, 3, 2);
            numericUpDown_tableID.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDown_tableID.Name = "numericUpDown_tableID";
            numericUpDown_tableID.Size = new Size(162, 23);
            numericUpDown_tableID.TabIndex = 3;
            numericUpDown_tableID.Value = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDown_tableID.ValueChanged += numericUpDown_tableID_ValueChanged;
            // 
            // button_SaveChanges
            // 
            button_SaveChanges.Location = new Point(730, 448);
            button_SaveChanges.Margin = new Padding(3, 2, 3, 2);
            button_SaveChanges.Name = "button_SaveChanges";
            button_SaveChanges.Size = new Size(176, 22);
            button_SaveChanges.TabIndex = 4;
            button_SaveChanges.Text = "Сохранить изменения";
            button_SaveChanges.UseVisualStyleBackColor = true;
            button_SaveChanges.Click += button_SaveChanges_Click;
            // 
            // label_table_P
            // 
            label_table_P.AutoSize = true;
            label_table_P.Location = new Point(38, 257);
            label_table_P.Name = "label_table_P";
            label_table_P.Size = new Size(113, 15);
            label_table_P.TabIndex = 5;
            label_table_P.Text = "Таблица критериев";
            // 
            // button_Graph
            // 
            button_Graph.Location = new Point(787, 67);
            button_Graph.Margin = new Padding(3, 2, 3, 2);
            button_Graph.Name = "button_Graph";
            button_Graph.Size = new Size(176, 22);
            button_Graph.TabIndex = 6;
            button_Graph.Text = "Показать граф состояний";
            button_Graph.UseVisualStyleBackColor = true;
            button_Graph.Visible = false;
            button_Graph.Click += button_Graph_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(38, 490);
            label1.Name = "label1";
            label1.Size = new Size(0, 15);
            label1.TabIndex = 7;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(38, 490);
            label2.Name = "label2";
            label2.Size = new Size(176, 15);
            label2.TabIndex = 8;
            label2.Text = "Выбор функции отображения:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(38, 518);
            label3.Name = "label3";
            label3.Size = new Size(279, 15);
            label3.TabIndex = 9;
            label3.Text = "1 - Обычная функция (доп параметры не нужны)";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(38, 543);
            label4.Name = "label4";
            label4.Size = new Size(196, 15);
            label4.TabIndex = 10;
            label4.Text = "2 - U-образная функция (нужно q)";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(38, 567);
            label5.Name = "label5";
            label5.Size = new Size(193, 15);
            label5.TabIndex = 11;
            label5.Text = "3 - V-образная функция (нужно s)";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(38, 591);
            label6.Name = "label6";
            label6.Size = new Size(208, 15);
            label6.TabIndex = 12;
            label6.Text = "4 - Уровневая функция (нужно q и s)";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(38, 615);
            label7.Name = "label7";
            label7.Size = new Size(0, 15);
            label7.TabIndex = 13;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(38, 615);
            label8.Name = "label8";
            label8.Size = new Size(353, 15);
            label8.TabIndex = 14;
            label8.Text = "5 - V-образная функция с порогами безразличия (нужно q и s)";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(38, 640);
            label9.Name = "label9";
            label9.Size = new Size(309, 15);
            label9.TabIndex = 15;
            label9.Text = "6 - функция Гаусса (нужна сигма, списать в столбец q)";
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(989, 938);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(button_Graph);
            Controls.Add(label_table_P);
            Controls.Add(button_SaveChanges);
            Controls.Add(numericUpDown_tableID);
            Controls.Add(dataGridView_table_K);
            Controls.Add(dataGridView_table_A);
            Controls.Add(label_table_A);
            Margin = new Padding(3, 2, 3, 2);
            Name = "Form2";
            Text = "Редактирование альтернатив и критериев";
            Load += Form2_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView_table_A).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView_table_K).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown_tableID).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label_table_A;
        private DataGridView dataGridView_table_A;
        private DataGridView dataGridView_table_K;
        private NumericUpDown numericUpDown_tableID;
        private Button button_SaveChanges;
        private Label label_table_P;
        private Button button_Graph;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
    }
}