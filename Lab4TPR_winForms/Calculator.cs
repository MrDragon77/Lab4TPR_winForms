using System.Data;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Xml;

class Calculator
{
    public DataSet DS;

    public Calculator(DataSet newDS)
    {
        DS = newDS;
    }

    public void ChangeDS(DataSet new_DS)
    {
        DS = new_DS;
    }

    double Calculate_r(List<double> P_k, string s_table) 
    { 
        double r = 0;
        for(int i =0; i <P_k.Count; i++)
        {
            r += P_k[i] * Convert.ToDouble(DS.Tables[s_table].Rows[i][1]);
        }
        return r;
    }

    public double Calculate_Pk(int k_num, string i_table, string p_table, string s_ip_table, string s_pk_table)
    {

        int i_events = DS.Tables[i_table].Rows.Count;
        int p_events = DS.Tables[p_table].Columns.Count;

        DataTable probs = new DataTable();
        probs.Clear();

        for (int i = 0; i < p_events; i++)
        {
            probs.Columns.Add(i.ToString());
        }
        for (int i = 0; i < i_events; i++)
        {
            probs.Rows.Add(i.ToString());
        }



        for (int i = 0; i < p_events; i++)
        {
            for (int j = 0; j < i_events; j++)
            {
                probs.Rows[i][j] = 0;
            }
        }
        for (int j = 0; j < p_events; j++)
        {
            if (Convert.ToInt32(DS.Tables[s_pk_table].Rows[k_num][j]) == 1)
            {
                for (int i = 0; i < i_events; i++)
                {
                    if (Convert.ToInt32(DS.Tables[s_ip_table].Rows[j][i]) == 1)
                    {
                        probs.Rows[j][i] = Convert.ToDouble(DS.Tables[i_table].Rows[i][1]);
                    }
                }
            }
        }

        List<double> temp = new List<double>();
        List<double> p_probs = RecurP(0, probs, temp, 1);
        double product = 1;
        double result = 1;

        for (int i = 0; i < p_probs.Count; i++)
        {
            product *= (1 - p_probs[i]);  
        }
        result -= product;
        return result;
    }

    List<double> RecurP(int cur_p, DataTable probs, List<double> result, double product)
    {
        if(cur_p >= probs.Rows.Count)
        {
            result.Add(product);
            return result;
        }
        for (int j = 0; j < probs.Rows.Count; j++)
        {
            if (Convert.ToDouble(probs.Rows[j][cur_p]) != 0)
            {
                product *= Convert.ToDouble(probs.Rows[cur_p][j]);
                result = RecurP(cur_p + 1, probs, result, product);
            }
        }
        return result;
    }
}