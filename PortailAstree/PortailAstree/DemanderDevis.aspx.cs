using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace Astree
{
    public partial class DemanderDevis : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["code_utilisateur"] == null)
            {
                Response.Redirect("login.aspx");
            }
            if (!this.IsPostBack)
            {
                MsgError.Visible = false;
                //Txtcode.Text = Session["Code_utilisateur"].ToString();
                this.BindGrid();
            }
        }

        private void BindGrid()
        {

            //afficher just les devis !! 

            AstreeDonnees a = new AstreeDonnees();
            UtilisateurDB user = a.GetUser(Convert.ToInt16(Session["code_utilisateur"].ToString()));

            List<serviceDB> ls = a.GetServices().Where(w => (w.libelleService != null) && (w.libelleService.Trim() == "Devis") && (w.codeUtilisateur == user.code_utilisateur)).OrderBy(w => w.etat).OrderByDescending(w => w.code_service).ToList();
            foreach (serviceDB x in ls)
            {
                if (x.libelleBranche.Trim() == "Choisir")
                {
                    x.libelleBranche = "";
                }
                if (x.libelleSousbranche.Trim() == "Choisir")
                {
                    x.libelleSousbranche = "";
                }
            }
            Session["lstDevis"] = ls;
            gv_Devis.DataSource = ls;
            gv_Devis.DataBind();

        }






        protected void BtnAjoutDevis_Click(object sender, EventArgs e)
        {
            //lblMessage1.Text = "Demande envoyer avec succées";

            AstreeDonnees ad = new AstreeDonnees();
            serviceDB devis = new serviceDB();
            List<serviceDB> ls = ad.GetServices().Where(w => w.libelleService.Trim() == "Devis" && w.codeUtilisateur == Convert.ToInt16(Session["code_utilisateur"].ToString())).ToList();
            if (ddlproduit.SelectedIndex == 0)
            {
                MsgError.Visible = true;
                MsgError.Text = "Vous devez selectionner un produit";
            }
            else
            {
                //devis = ad.GetServices().Where(w => w.libelleService.Trim() == "Devis").FirstOrDefault();
                devis.libelleService = "Devis";
                devis.idBranche = Convert.ToInt16(ddlproduit.SelectedValue.ToString());
                devis.idSousBranche = Convert.ToInt16(ddlsousproduit.SelectedValue.ToString());

                devis.etat = "A";
                devis.dateDemande = DateTime.Now;
                devis.idType = 5;
                devis.codeUtilisateur = Convert.ToInt16(Session["code_utilisateur"].ToString());

                serviceDB ser = ls.Where(w => (w.libelleBranche.Trim() == ddlproduit.SelectedItem.Text.Trim()) && (w.libelleSousbranche.Trim() == ddlsousproduit.SelectedItem.Text.Trim())).FirstOrDefault();
                if (ser == null)
                {
                    ad.Insertservice(devis);
                    lblMsgSucces.Visible = true;
                    lblMsgSucces.Text = "Demande devis envoyée avec succés";
                    BindGrid();
                }
                else
                {
                    lblMsgSucces.Visible = true;
                    lblMsgSucces.Text = "Vous avez déja envoyer cette demande";
                    BindGrid();
                }
            }













        }





        protected void gv_Devis_PageIndexChanging1(object sender, GridViewPageEventArgs e)
        {
            gv_Devis.PageIndex = e.NewPageIndex;
            gv_Devis.DataSource = Session["lstDevis"];
            gv_Devis.DataBind();
            gv_Devis.SelectedIndex = -1;
        }
        protected void ddlproduit_SelectedIndexChanged(object sender, EventArgs e)
        {
            MsgError.Visible = false;
        }
    }
}
