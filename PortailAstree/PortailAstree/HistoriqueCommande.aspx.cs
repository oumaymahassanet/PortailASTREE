using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Astree;

public partial class HistoriqueCommande : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {

            this.BindGrid();
        }
    }
    private void BindGrid()
    {
        AstreeDonnees a = new AstreeDonnees();
        gv_Historique.DataSource = a.GetServices().Where(w => w.libelleService == "Commande".Trim() && w.codeDest == 404 ).OrderByDescending(w=>w.dateReponse);
        gv_Historique.DataBind();
    }

    protected void gv_Historique_SelectedIndexChanged(object sender, EventArgs e)
    {
        AstreeDonnees a = new AstreeDonnees();
        GridViewRow row = gv_Historique.SelectedRow;     
        List<DetailCommandeDB> ls = a.GetDetailCommande().Where(w => w.LibelleService.Trim() == "Commande" && w.code_dest == 404 && w.code_service == Convert.ToInt16(row.Cells[1].Text)).ToList();
        if (ls.Count() > 0)
        {
            
            gv_Detail.DataSource = ls;
            gv_Detail.DataBind();

        }

        else
        {
          
        }
    }

    protected void gv_Historique_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            try
            {
                

                GridViewRow row = e.Row;
               

               
                    if (row.Cells[5].Text.Trim()=="V")
                    {
                        //e.Row.BackColor = System.Drawing.Color.Red;
                        e.Row.ForeColor = System.Drawing.Color.Green;
                    }

                if (row.Cells[5].Text.Trim() == "A")
                {
                    //e.Row.BackColor = System.Drawing.Color.Red;
                    e.Row.ForeColor = System.Drawing.Color.Red;
                }

            }
            catch (Exception ex)
            { }
        }
    }


   
}