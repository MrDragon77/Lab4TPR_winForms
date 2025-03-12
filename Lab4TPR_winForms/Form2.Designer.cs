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
            ((System.ComponentModel.ISupportInitialize)dataGridView_table_A).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView_table_K).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown_tableID).BeginInit();
            SuspendLayout();
            // 
            // label_table_A
            // 
            label_table_A.AutoSize = true;
            label_table_A.Location = new Point(38, 19);
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
            numericUpDown_tableID.Location = new Point(566, 11);
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
            // Form2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(989, 938);
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
    }
}