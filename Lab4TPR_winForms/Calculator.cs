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

        return datasetResult;
    }
}