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

    public DataSet Calculate()
    {
        String table_A = "A";
        String table_K = "K";
        String table_S_AK = "S_AK";
        String table_phase1 = "phase1_";
        DataSet datasetResult = new DataSet();

        //phase 1
        //result tables - [a.rows.count, a.rows.count]
        //num of result tables - k.rows.count

        DataTable S_AK = DS.Tables[table_S_AK];
        int A_num = DS.Tables["A"].Rows.Count;
        int K_num = DS.Tables["K"].Rows.Count;

        for(int i = 0; i < K_num; i++)
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
        return datasetResult;
    }
}