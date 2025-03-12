using ConjTable.Demo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab4TPR_winForms
{
    //Form2 - форма для ввода сложных параметров
    //конкретно здесь вводятся данные об альтернативах и критериях.
    public partial class Form2 : Form
    {
        public DataSet datasetTemp;
        public Form2()
        {
            InitializeComponent();
            datasetTemp = new DataSet();
        }
        public Form2(DataSet dataset, int strategyNum)
        {
            InitializeComponent();
            this.datasetTemp = dataset;
            numericUpDown_tableID.Maximum = strategyNum;
            numericUpDown_tableID.Minimum = 1;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            dataGridView_table_A.DataSource = datasetTemp.Tables[tablesNames.table_A];
            dataGridView_table_K.DataSource = datasetTemp.Tables[tablesNames.table_K];
        }

        private void numericUpDown_tableID_ValueChanged(object sender, EventArgs e)
        {
            dataGridView_table_A.DataSource = datasetTemp.Tables[tablesNames.table_A + numericUpDown_tableID.Value.ToString()];
            dataGridView_table_K.DataSource = datasetTemp.Tables[tablesNames.table_K + numericUpDown_tableID.Value.ToString()];
            dataGridView_table_A.Update();
            dataGridView_table_K.Update();
        }

        private void button_SaveChanges_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void dataGridView_table_I_SelectionChanged(object sender, EventArgs e)
        {
            dataGridView_table_A.Update();
        }

        private void dataGridView_table_P_SelectionChanged(object sender, EventArgs e)
        {
            dataGridView_table_K.Update();
        }

        private void button_Graph_Click(object sender, EventArgs e)
        {

            //Application.Run(new MainForm(datasetTemp.Tables["s" + numericUpDown_tableID.Value.ToString()]));
            MainForm GraphForm = new MainForm(datasetTemp.Tables["s" + numericUpDown_tableID.Value.ToString()]);
            GraphForm.ShowDialog();
        }

        private void dataGridView_table_I_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            for (int i = 0; i < dataGridView_table_A.Rows.Count; i++)
            {
                dataGridView_table_A.Rows[i].HeaderCell.Value = "a" + (i + 1).ToString();
            }
        }

        private void dataGridView_table_P_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            for (int i = 0; i < dataGridView_table_K.Rows.Count; i++)
            {
                dataGridView_table_K.Rows[i].HeaderCell.Value = "f" + (i + 1).ToString();
            }
        }

        private void dataGridView_table_A_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
