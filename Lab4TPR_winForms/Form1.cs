using System.Data;

namespace Lab4TPR_winForms
{
    //Form1 - главная форма, используется для ввода простых параметров и нажатия на кнопки открытия форм для ввода сложных параметров
    //а также для сохранения данных в файл и загрузки их из файла
    public partial class Form1 : Form
    {
        DataSet dataset; //will have 5 tables
        Calculator calculator;
        bool isDatasetCreated = false;
        bool isBindTablesCreated = false; //tables 
        int savedResourceNum = 0;
        public Form1()
        {
            InitializeComponent();
            dataset = new DataSet();
            calculator = new Calculator();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void buttonEditForm2_Click(object sender, EventArgs e)
        {
            bool isNeedToCreateDataset = false;
            if (!isDatasetCreated)
            {
                isNeedToCreateDataset = true;
            }

            if (isNeedToCreateDataset)
            {
                dataset = new DataSet();
                DataTable A = new DataTable(tablesNames.table_A); //таблица альтернатив
                A.Columns.Add("Название"); //колонка 1 для названия 
                A.Rows.Add();
                dataset.Tables.Add(A);
                DataTable K = new DataTable(tablesNames.table_K); //таблица критериев
                K.Columns.Add("Название"); //колонка 1 для названия 
                K.Rows.Add();
                dataset.Tables.Add(K);
               
                isDatasetCreated = true;
                isBindTablesCreated = false;
            }

            using (Form2 form2 = new Form2(dataset, savedResourceNum)) //открываем Form2 чтобы редактировать списки событий
            {
                if (form2.ShowDialog() == DialogResult.OK)
                {
                    dataset = form2.datasetTemp;
                    isBindTablesCreated = false;
                }

            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            string saveName = textBox_saveName.Text + ".xml";
            if (textBox_saveName.Text == "")
            {
                MessageBox.Show("Напишите имя файла");
                return;
            }
            if (File.Exists(saveName))
            {
                MessageBox.Show("Файл с таким именем уже существует");
                return;
            }
            if (!isDatasetCreated)
            {
                MessageBox.Show("Нечего сохранять. Сначала создайте списки и заполните их данными.");
                return;
            }
            if (!isBindTablesCreated)
            {
                MessageBox.Show("Неполные данные. Сначала создайте связи между состояниями.");
                return;
            }
            if (dataset.Tables.Contains(tablesNames.table_state))
            {
                dataset.Tables.Remove(tablesNames.table_state);
            }
            //DataTable stateTable = new DataTable(tablesNames.table_state); //название технической таблицы state
            //stateTable.Columns.Add("resourceNum", typeof(int));
            //stateTable.Rows.Add(savedResourceNum);
            //dataset.Tables.Add(stateTable);
            dataset.WriteXml(saveName);
            MessageBox.Show("Файл сохранен");
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            string openName = textBox_saveName.Text + ".xml";
            if (!File.Exists(openName))
            {
                MessageBox.Show("Файла с таким именем нет");
                return;
            }
            dataset = new DataSet();
            dataset.ReadXml(openName);
            //DataTable stateTable = dataset.Tables[tablesNames.table_state];
            //nud_resourceNum.Value = Convert.ToDecimal(stateTable.Rows[0]["resourceNum"]);
            //savedResourceNum = Int32.Parse(stateTable.Rows[0]["resourceNum"].ToString());
            MessageBox.Show("Файл загружен");
            isDatasetCreated = true;

        }

        private void button_StartModelling_Click(object sender, EventArgs e)
        {
            calculator = new Calculator(dataset);
            DataSet result = calculator.Calculate();
            using (Form3 form3 = new Form3(result))
            {
                form3.ShowDialog();
            }
        }

        private void button_EditForm4_Click(object sender, EventArgs e)
        {
            if (!isDatasetCreated)
            {
                MessageBox.Show("Ошибка - Списки событий не созданы.\nНеобходимо сначала создать списки Инициирующих, Промежуточных и Конечных событий.");
                return;
            }
            bool isNeedToCreateBindTables = false;
            if (!isBindTablesCreated)
            {
                isNeedToCreateBindTables = true;
            }

            if (isNeedToCreateBindTables)
            {
                int A_num = dataset.Tables[tablesNames.table_A].Rows.Count;
                int K_num = dataset.Tables[tablesNames.table_K].Rows.Count;
                int S_AK_oldRows = 0;
                int S_AK_oldCols = 0;
                DataTable S_AK = new DataTable(tablesNames.table_S_AK); //таблица связей
                if (dataset.Tables.Contains(tablesNames.table_S_AK))
                {
                    S_AK_oldRows = dataset.Tables[tablesNames.table_S_AK].Rows.Count;
                    S_AK_oldCols = dataset.Tables[tablesNames.table_S_AK].Columns.Count;
                    S_AK = dataset.Tables[tablesNames.table_S_AK];
                    dataset.Tables.Remove(tablesNames.table_S_AK);
                }


                for (int j = S_AK_oldCols; j < K_num; j++)
                {
                    S_AK.Columns.Add(tablesNames.table_K + (j + 1).ToString());
                }
                for (int j = S_AK_oldRows; j < A_num; j++)
                {
                    S_AK.Rows.Add("");
                }


                dataset.Tables.Add(S_AK);
            }
            isBindTablesCreated = true;


            using (Form4 form4 = new Form4(dataset, savedResourceNum)) //открываем Form4 чтобы редактировать связи
            {
                if (form4.ShowDialog() == DialogResult.OK)
                {
                    dataset = form4.datasetTemp;
                }

            }
        }
    }

    static public class tablesNames
    {
        //A - table for альтернативы
        //K - table for критерии
        //S_AK - table for связи между альтернативами и критериями
        //state - техническая таблица (используется для сохранения данных на Form1)
        public const String table_A = "A";
        public const String table_K = "K";
        public const String table_S_AK = "S_AK";
        //public const String table_S_PK = "S_PK";
        public const String table_state = "state";
    }
}