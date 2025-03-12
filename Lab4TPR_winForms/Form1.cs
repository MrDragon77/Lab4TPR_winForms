using System.Data;
using System.Globalization;

namespace Lab4TPR_winForms
{
    //Form1 - ������� �����, ������������ ��� ����� ������� ���������� � ������� �� ������ �������� ���� ��� ����� ������� ����������
    //� ����� ��� ���������� ������ � ���� � �������� �� �� �����
    public partial class Form1 : Form
    {
        DataSet dataset; //will have 1 table
        Calculator calculator;
        bool isDatasetCreated = false;
        int savedStrategyNum1 = 0;
        int savedStrategyNum2 = 0;
        public Form1()
        {
            InitializeComponent();
            dataset = new DataSet();
            calculator = new Calculator(dataset, 1);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void buttonEditForm2_Click(object sender, EventArgs e)
        {
            int rows = Decimal.ToInt32(nud_strategyNum1.Value);
            int cols = Decimal.ToInt32(nud_strategyNum2.Value);
            bool isNeedToCreateDataset = false;
            if (!isDatasetCreated)
            {
                isNeedToCreateDataset = true;
            }
            else
            {
                if (savedStrategyNum1 != Decimal.ToInt32(nud_strategyNum1.Value) || savedStrategyNum2 != Decimal.ToInt32(nud_strategyNum2.Value))
                {
                    DialogResult result = MessageBox.Show("� ���� ��� ���� ��������� �������. \n�� - ��������� � �� ����.\n��� - ������� ����� �������", "������", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        nud_strategyNum1.Value = Convert.ToDecimal(savedStrategyNum1);
                        nud_strategyNum2.Value = Convert.ToDecimal(savedStrategyNum2);
                        isNeedToCreateDataset = false;
                    }
                    else if (result == DialogResult.No)
                    {
                        isNeedToCreateDataset = true;
                    }
                }
            }

            if (isNeedToCreateDataset)
            {
                int strategyNum1 = Decimal.ToInt32(nud_strategyNum1.Value);
                int strategyNum2 = Decimal.ToInt32(nud_strategyNum2.Value);
                savedStrategyNum1 = strategyNum1;
                savedStrategyNum2 = strategyNum2;
                dataset = new DataSet();
                DataTable paymentMatrix = new DataTable(tablesNames.paymentMatrix);
                for (int i = 1; i <= strategyNum2; i++)
                {
                    paymentMatrix.Columns.Add("");

                }
                for (int j = 1; j <= strategyNum1; j++)
                {
                    paymentMatrix.Rows.Add("");
                }
                dataset.Tables.Add(paymentMatrix);
                isDatasetCreated = true;
            }

            using (Form2 form2 = new Form2(dataset, savedStrategyNum1)) //��������� Form2 ����� ������������� ��������� ��������
            {
                if (form2.ShowDialog() == DialogResult.OK)
                {
                    dataset = form2.datasetTemp;
                }

            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            string saveName = textBox_saveName.Text + ".xml";
            if (textBox_saveName.Text == "")
            {
                MessageBox.Show("�������� ��� �����");
                return;
            }
            if (File.Exists(saveName))
            {
                MessageBox.Show("���� � ����� ������ ��� ����������");
                return;
            }
            if (!isDatasetCreated)
            {
                MessageBox.Show("������ ���������. ������� �������� ������� � ��������� � �������.");
                return;
            }
            double tmp = 0;
            if (!Double.TryParse(textBox_accuracy.Text, CultureInfo.InvariantCulture, out tmp))
            {
                MessageBox.Show("���� �������� �������� �������� ������������ ��������. ���������� ���������.");
                return;
            }
            if (dataset.Tables.Contains(tablesNames.table_state))
            {
                dataset.Tables.Remove(tablesNames.table_state);
            }
            DataTable stateTable = new DataTable(tablesNames.table_state); //�������� ����������� ������� state
            stateTable.Columns.Add("strategyNum1", typeof(int));
            stateTable.Columns.Add("strategyNum2", typeof(int));
            stateTable.Columns.Add("accuracy", typeof(double));
            stateTable.Columns.Add("stepNum", typeof(int));
            stateTable.Rows.Add(savedStrategyNum1, savedStrategyNum2, Double.Parse(textBox_accuracy.Text, CultureInfo.InvariantCulture), Decimal.ToInt32(nud_StepNum.Value));
            dataset.Tables.Add(stateTable);
            dataset.WriteXml(saveName);
            MessageBox.Show("���� ��������");
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            string openName = textBox_saveName.Text + ".xml";
            if (!File.Exists(openName))
            {
                MessageBox.Show("����� � ����� ������ ���");
                return;
            }
            dataset = new DataSet();
            dataset.ReadXml(openName);
            DataTable stateTable = dataset.Tables[tablesNames.table_state];
            nud_strategyNum1.Value = Convert.ToDecimal(stateTable.Rows[0]["strategyNum1"]);
            nud_strategyNum2.Value = Convert.ToDecimal(stateTable.Rows[0]["strategyNum2"]);
            textBox_accuracy.Text = stateTable.Rows[0]["accuracy"].ToString();
            nud_StepNum.Value = Convert.ToDecimal(stateTable.Rows[0]["stepNum"]);
            savedStrategyNum1 = Int32.Parse(stateTable.Rows[0]["strategyNum1"].ToString());
            savedStrategyNum2 = Int32.Parse(stateTable.Rows[0]["strategyNum2"].ToString());
            MessageBox.Show("���� ��������");
            isDatasetCreated = true;

        }

        private void button_StartModelling_Click(object sender, EventArgs e)
        {
            calculator.ChangeDS(dataset);
            calculator.ChangeIterations(Decimal.ToInt32(nud_StepNum.Value));
            DataTable result = calculator.Calculate();
            using (Form3 form3 = new Form3(result))
            {
                form3.ShowDialog();
            }
        }

        private void button_EditForm4_Click(object sender, EventArgs e)
        {
            //    if (!isDatasetCreated)
            //    {
            //        MessageBox.Show("������ - ������ ������� �� �������.\n���������� ������� ������� ������ ������������, ������������� � �������� �������.");
            //        return;
            //    }
            //    bool isNeedToCreateBindTables = false;
            //    if (!isBindTablesCreated)
            //    {
            //        isNeedToCreateBindTables = true;
            //    }
            //    else
            //    {
            //        if (savedResourceNum != Decimal.ToInt32(nud_strategyNum1.Value))
            //        {
            //            DialogResult result = MessageBox.Show("� ���� ��� ���� ����������� ������. \n�� - ��������� �� �� ����.\n��� - ������� ����� ������", "������", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //            if (result == DialogResult.Yes)
            //            {
            //                nud_strategyNum1.Value = Convert.ToDecimal(savedResourceNum);
            //                isNeedToCreateBindTables = false;
            //            }
            //            else if (result == DialogResult.No)
            //            {
            //                isNeedToCreateBindTables = false;
            //                MessageBox.Show("��� ���� ����� ������� ����� ������ ������� �� ������ ������������� ������");
            //            }
            //        }
            //    }


            //    if (isNeedToCreateBindTables)
            //    {
            //        int resourceNum = Decimal.ToInt32(nud_strategyNum1.Value);
            //        for (int i = 1; i <= resourceNum; i++)
            //        {
            //            if (dataset.Tables.Contains(tablesNames.table_S_IP + i.ToString()))
            //            {
            //                dataset.Tables.Remove(tablesNames.table_S_IP + i.ToString());
            //            }
            //            if (dataset.Tables.Contains(tablesNames.table_S_PK + i.ToString()))
            //            {
            //                dataset.Tables.Remove(tablesNames.table_S_PK + i.ToString());
            //            }
            //        }


            //        savedResourceNum = resourceNum;
            //        for (int i = 1; i <= resourceNum; i++)
            //        {
            //            int I_num = dataset.Tables[tablesNames.paymentMatrix + i.ToString()].Rows.Count;
            //            int P_num = dataset.Tables[tablesNames.table_P + i.ToString()].Rows.Count;
            //            int K_num = dataset.Tables[tablesNames.table_K + i.ToString()].Rows.Count;
            //            DataTable S_IP = new DataTable(tablesNames.table_S_IP + i.ToString()); //������� ������ �� ������������ � �������������
            //            for (int j = 1; j <= P_num; j++)
            //            {
            //                S_IP.Columns.Add(tablesNames.table_P + j.ToString());
            //            }
            //            for (int j = 1; j <= I_num; j++)
            //            {
            //                S_IP.Rows.Add("");
            //            }

            //            DataTable S_PK = new DataTable(tablesNames.table_S_PK + i.ToString()); //������� ������ �� ������������ � �������������
            //            for (int j = 1; j <= K_num; j++)
            //            {
            //                S_PK.Columns.Add(tablesNames.table_K + j.ToString());
            //            }
            //            for (int j = 1; j <= P_num; j++)
            //            {
            //                S_PK.Rows.Add("");
            //            }

            //            dataset.Tables.Add(S_IP);
            //            dataset.Tables.Add(S_PK);
            //        }
            //        isBindTablesCreated = true;
            //    }


            //    using (Form4 form4 = new Form4(dataset, savedResourceNum)) //��������� Form4 ����� ������������� ����� �������
            //    {
            //        if (form4.ShowDialog() == DialogResult.OK)
            //        {
            //            dataset = form4.datasetTemp;
            //        }

            //    }
        }
    }

    static public class tablesNames
    {
        //paymentMatrix - ��������� �������
        //state - ����������� ������� (������������ ��� ���������� ������ �� Form1)
        public const String paymentMatrix = "PM";
        public const String table_state = "state";
    }
}