using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ausarbeitung
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ButtonSubmit.Click += new EventHandler(ButtonSubmit_Click);
            PopulateChart();
        }

        void ButtonSubmit_Click(Object sender, EventArgs e)
        {
            if (TextBoxX.Text != "" && TextBoxY.Text != "")
            {
                using (PointDatabaseEntities dc = new PointDatabaseEntities())
                {
                    var p = new Point()
                    {
                        xValue = Convert.ToDecimal(TextBoxX.Text),
                        yValue = Convert.ToDecimal(TextBoxY.Text)
                    };
                    dc.Points.Add(p);
                    dc.SaveChanges();
                }
            }
            PopulateChart();
        }

        private void PopulateChart()
        {
            using (PointDatabaseEntities dc = new PointDatabaseEntities())
            {
                var v = dc.Points.ToList();

                Chart.DataSource = v;
                Chart.DataBind();
            }
        }
    }
}