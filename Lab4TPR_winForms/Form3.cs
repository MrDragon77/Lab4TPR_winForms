
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
    //Form3 - форма вывода результатов (по сути вообще не менял с первой лабы, она просто принимает DataTable от этапа вычислений и выводит её)
    public partial class Form3 : Form
    {
        public DataSet datasetResult;
        int curPhase;
        //public DataTable datasetResult;

        public Form3()
        {
            InitializeComponent();
            datasetResult = new DataSet();
            curPhase = 1;
        }
        public Form3(DataSet dataset)
        {
            InitializeComponent();
            this.datasetResult = dataset;
            curPhase = 1;

            int tableID_maximum = 0;
            while (datasetResult.Tables.Contains("phase1_" + (tableID_maximum + 1).ToString()))
            {
                tableID_maximum++;
            }
            numericUpDown_tableID.Maximum = tableID_maximum;
            numericUpDown_tableID.Minimum = 1;

            int phaseID_maximum = 0;
            while (datasetResult.Tables.Contains("phase" + (phaseID_maximum + 1).ToString() + "_1"))
            {
                phaseID_maximum++;
            }
            numericUpDown_phaseID.Maximum = phaseID_maximum;
            numericUpDown_phaseID.Minimum = 1;
        }


        private void Form3_Load(object sender, EventArgs e)
        {
            dataGridView_results.DataSource = datasetResult.Tables["phase1_1"];
        }

        private void numericUpDown_tableID_ValueChanged(object sender, EventArgs e)
        {
            dataGridView_results.DataSource = datasetResult.Tables["phase" + curPhase.ToString() + "_" + numericUpDown_tableID.Value.ToString()];
        }

        private void numericUpDown_phaseID_ValueChanged(object sender, EventArgs e)
        {
            curPhase = Convert.ToInt32(numericUpDown_phaseID.Value);
            numericUpDown_tableID_ValueChanged(sender, e);
        }
    }
}
