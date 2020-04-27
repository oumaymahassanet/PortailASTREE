using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.DataVisualization.Charting;
namespace Astree
    {
    public partial class ConsulterStatistique : System.Web.UI.Page
    {


        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["code_utilisateur"] == null)
            {
                Response.Redirect("login.aspx");
            }
            if (!Page.IsPostBack)
            {
                Chart2.Visible = true;
                AstreeDonnees a = new AstreeDonnees();
                List < serviceDB > lstServ = a.GetServices().Where(w=>w.libelleService.Trim()=="Devis").ToList();
                //string query = string.Format("select shipcity, count(orderid) from orders where shipcountry = '{0}' group by shipcity", ddlCountries.SelectedValue);
                // DataTable dt = GetData(query);
                //string[] x = new string[lstServ.Count];
                //int[] y = new int[lstServ.Count];
                //int i = 0;
                //foreach(serviceDB z in lstServ )
                //{
                //    x[i] = z.libelleBranche ;

                //    y[i] = 200;// Convert.ToDecimal(z.primeHtax);
                //}
                string[] x = new string[3];
                int[] y = new int[3];
                
                    x[0] ="Incendie" ;

                    y[0] = 200;// Convert.ToDecimal(z.primeHtax);
                x[1] = "Vol";

                y[1] = 50;// Convert.ToDecimal(z.primeHtax);
                x[2] = "Auto";

                y[2] = 500;// Convert.ToDecimal(z.primeHtax);

                Chart2.Series[0].Points.DataBindXY( x,y);
                Chart2.Series[0].ChartType = SeriesChartType.Column;
                Chart2.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = true;
                Chart2.Legends[0].Enabled = true;
            }
        }
     
    }
}