using System.Data;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Xml;

class Calculator
{
    public DataSet DS; //original dataset of our data

    public Calculator()
    {
        DS = new DataSet();
    }
    public Calculator(DataSet newDS)
    {
        this.DS = newDS;
    }

    //функции отображения
    private double func1(double d)
    {
        //1 - обычная функция
        return d <= 0 ? 0 : 1;
    }
    private double func2(double d, double q)
    {
        //U-образная функция
        return d <= q ? 0 : 1;
    }
    private double func3(double d, double s)
    {
        //V-образная функция
        if (d <= 0)
            return 0;
        if (d <= s)
            return d / s;
        return 1;
    }
    private double func4(double d, double q, double s)
    {
        //Уровневая функция
        if (d <= q)
            return 0;
        if (d <= s)
            return 0.5;
        return 1;
    }
    private double func5(double d, double q, double s)
    {
        //V-образная функция с порогами безразличия
        if (d <= q)
            return 0;
        if (d <= s)
            return (d - q) / (s - q);
        return 1;
    }
    private double func6(double d, double q)
    {
        //функция Гаусса, q - сигма
        if (d <= 0)
            return 0;
        return 1 - Math.Exp((-d*d) / (2*q*q));
    }
    private double dispFunc(int funcNum, double d, double q, double s) //управляющая функция функций отображения
    {
        if (funcNum == 1)
        {
            return func1(d);
        }
        if (funcNum == 2)
        {
            return func2(d, q);
        }
        if (funcNum == 3)
        {
            return func3(d, s);
        }
        if (funcNum == 4)
        {
            return func4(d, q, s);
        }
        if (funcNum == 5)
        {
            return func5(d, q, s);
        }
        if (funcNum == 6)
        {
            return func6(d, q);
        }
        return Double.NaN;
    }


    public DataSet Calculate()
    {
        String table_A = "A";
        String table_K = "K";
        String table_S_AK = "S_AK";
        String table_phase1 = "phase1_";
        String table_phase2 = "phase2_";
        String table_phase3 = "phase3_";
        String table_phase4 = "phase4_";
        String table_phase5 = "phase5_";
        DataSet datasetResult = new DataSet();

        DataTable A = DS.Tables[table_A];
        DataTable K = DS.Tables[table_K];
        DataTable S_AK = DS.Tables[table_S_AK]; //таблица связей
        int A_num = DS.Tables["A"].Rows.Count; //количество альтернатив
        int K_num = DS.Tables["K"].Rows.Count; //количество критериев

        //phase 1
        //result tables - [a.rows.count, a.rows.count]
        //num of result tables - k.rows.count

        for (int i = 0; i < K_num; i++)
        {
            DataTable cur_table_phase1 = new DataTable(table_phase1 + (i+1).ToString());
            for(int j = 0; j < A_num; j++)
            {
                cur_table_phase1.Columns.Add();
            }
            for (int j = 0; j < A_num; j++)
            {
                cur_table_phase1.Rows.Add();
            }
            for (int j = 0; j < A_num; j++)
            {
                for (int k = 0; k < A_num; k++)
                {
                    cur_table_phase1.Rows[j][k] = (Convert.ToDouble(S_AK.Rows[j][i]) - Convert.ToDouble(S_AK.Rows[k][i])).ToString();
                }
            }
            datasetResult.Tables.Add(cur_table_phase1);
        }


        //phase 2
        for (int i = 0; i < K_num; i++)
        {
            DataTable cur_table_phase2 = new DataTable(table_phase2 + (i + 1).ToString());
            for (int j = 0; j < A_num; j++)
            {
                cur_table_phase2.Columns.Add();
            }
            for (int j = 0; j < A_num; j++)
            {
                cur_table_phase2.Rows.Add();
            }
            for (int j = 0; j < A_num; j++)
            {
                for (int k = 0; k < A_num; k++) //k - столбец
                {
                    //2 стобцец - номер функции
                    //3 - q
                    //4 - s
                    cur_table_phase2.Rows[j][k] = dispFunc(Convert.ToInt32(K.Rows[i][2]), Convert.ToDouble(datasetResult.Tables[table_phase1 + (i + 1).ToString()].Rows[j][k]), Convert.ToDouble(K.Rows[i][3]), Convert.ToDouble(K.Rows[i][4]));
                }
            }
            datasetResult.Tables.Add(cur_table_phase2);
        }


        //phase 3
        for (int i = 0; i < 1; i++)
        {
            DataTable cur_table_phase3 = new DataTable(table_phase3 + (i + 1).ToString());
            for (int j = 0; j < A_num; j++)
            {
                cur_table_phase3.Columns.Add();
            }
            for (int j = 0; j < A_num; j++)
            {
                cur_table_phase3.Rows.Add();
            }
            for (int j = 0; j < A_num; j++)
            {
                for (int k = 0; k < A_num; k++) //k - столбец
                {
                    //2 стобцец - номер функции
                    //3 - q
                    //4 - s
                    double sum = 0;
                    for (int l = 0; l < K_num; l++)
                    {
                        sum += Convert.ToDouble(datasetResult.Tables[table_phase2 + (l + 1).ToString()].Rows[j][k])
                            * Convert.ToDouble(K.Rows[l][1]);
                    }
                    cur_table_phase3.Rows[j][k] = sum;

                }
            }
            cur_table_phase3.Columns.Add();
            cur_table_phase3.Rows.Add();
            for(int j = 0; j < A_num; j++)
            {
                double sum1 = 0;
                for(int k = 0; k < A_num; k++)
                {
                    sum1 += Convert.ToDouble(cur_table_phase3.Rows[k][j]);
                }
                cur_table_phase3.Rows[A_num][j] = Math.Round(sum1, 5);

                double sum2 = 0;
                for (int k = 0; k < A_num; k++)
                {
                    sum2 += Convert.ToDouble(cur_table_phase3.Rows[j][k]);
                }
                cur_table_phase3.Rows[j][A_num] = Math.Round(sum2, 5);
            }
            datasetResult.Tables.Add(cur_table_phase3);
        }


        //phase 4
        double[, ] phase4_array = new double[2, A_num];
        DataTable cur_table_phase4 = new DataTable(table_phase4 + 1.ToString());
        cur_table_phase4.Columns.Add();
        for (int j = 0; j < A_num; j++)
        {
            cur_table_phase4.Rows.Add();
        }
        for (int j = 0; j < A_num; j++)
        {
            //2 стобцец - номер функции
            //3 - q
            //4 - s
            phase4_array[0, j] = j;
            phase4_array[1, j] = Math.Round(Convert.ToDouble(datasetResult.Tables[table_phase3 + "1"].Rows[j][A_num])
                                       - Convert.ToDouble(datasetResult.Tables[table_phase3 + "1"].Rows[A_num][j]), 5);
            cur_table_phase4.Rows[j][0] = phase4_array[1, j];
        }
        datasetResult.Tables.Add(cur_table_phase4);


        //phase 4.1 (5) (вывод ранжира)
        DataTable cur_table_phase5 = new DataTable(table_phase5 + 1.ToString());
        cur_table_phase5.Columns.Add();
        cur_table_phase5.Columns.Add();
        for (int j = 0; j < A_num; j++)
        {
            cur_table_phase5.Rows.Add();
        }

        int rows = phase4_array.GetLength(1);
        int cols = phase4_array.GetLength(0);

        bool swapped;
        // Пузырьковая сортировка по второму столбцу
        for (int i = 0; i < rows - 1; i++)
        {
            swapped = false;
            for (int j = 0; j < rows - i - 1; j++)
            {
                // Сравниваем элементы второго столбца
                if (phase4_array[1, j] < phase4_array[1, j + 1])
                {
                    // Меняем местами строки
                    for (int k = 0; k < cols; k++)
                    {
                        double temp = phase4_array[k, j];
                        phase4_array[k, j] = phase4_array[k, j + 1];
                        phase4_array[k, j + 1] = temp;
                        
                    }
                    swapped = true;
                }
            }
            if (!swapped)
                break;
        }

        for (int k = 0; k < A_num; k++)
        {
            //2 стобцец - номер функции
            //3 - q
            //4 - s
            cur_table_phase5.Rows[k][0] = phase4_array[0, k];
            cur_table_phase5.Rows[k][1] = A.Rows[Convert.ToInt32(phase4_array[0, k])][0];
        }
        datasetResult.Tables.Add(cur_table_phase5);

        return datasetResult;
    }
}