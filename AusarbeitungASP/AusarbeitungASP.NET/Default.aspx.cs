using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AusarbeitungASP.NET
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ButtonSubmit.Click += ButtonSubmit_Click;
            ButtonClear.Click += ButtonClear_Click;
            if (!IsPostBack)
                Label.Text = ComputePolynom();
        }

        void ButtonClear_Click(object sender, EventArgs e)
        {
            SqlDataSource.Delete();
            Label.Text = ComputePolynom();
        }

        void ButtonSubmit_Click(object sender, EventArgs e)
        {
            SqlDataSource.Insert();
            Label.Text = ComputePolynom();
        }        

        public string ComputePolynom ()
        {
            var data = (DataView)SqlDataSource.Select(DataSourceSelectArguments.Empty);
            double[] f = new double[data.Table.Rows.Count];
            double[] x = new double[data.Table.Rows.Count];

            for (int i = 0; i < data.Table.Rows.Count; i++)
            {
                f[i] = Convert.ToDouble(data.Table.Rows[i][1]);
                x[i] = Convert.ToDouble(data.Table.Rows[i][0]);
            }
            
            if (f.All(o => o == 0) || x.All(o => o == 0))
                return "";
            var poly = NewtonPolynom.Newton(f, x);
            return WritePolynom(poly);
        }

        string WritePolynom(double[] factors)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = factors.Length - 1; i >= 0; i--)
            {
                sb.Append(Math.Round(factors[i],2));
                if (i > 0) { 
                    sb.Append("X^" + i);
                    sb.Append("+");
                }
            }
            return sb.ToString();
        }
    }
}