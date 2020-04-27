using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace Astree
{

    public partial class EnvoyerCommandeIntermidiaire : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (Session["code_utilisateur"] == null)
            {
                Response.Redirect("login.aspx");
            }
            liste.Visible = false;

            if (!this.IsPostBack)
            {
               

                liste.Visible = false;
                txterror.Visible = false;
                Session["lstCommande"] = null;

                Txtcode.Text = Session["code_utilisateur"].ToString();
                
                BindGrid();
            }
        }
        private void BindGrid()
        {

            AstreeDonnees a = new AstreeDonnees();
            List<DetailCommandeDB> ls = a.GetDetailCommande().Where(w => (w.LibelleService != null) && (w.LibelleService.Trim() == "Commande") && (w.codeUtilisateur == Convert.ToInt16(Session["code_utilisateur"]))).OrderBy(w => w.etat).ThenByDescending(w => w.code_service).ToList();
            Session["lstCommande"] = ls;
            gv_Commande.DataSource = ls;
            gv_Commande.DataBind();
        }
        protected void BtnEnvoyer_Click(object sender, EventArgs e)
        {
            try
            {
                AstreeDonnees a = new AstreeDonnees();
                UtilisateurDB User = a.GetUser(Convert.ToInt16(Session["code_utilisateur"].ToString()));
                serviceDB S = new serviceDB();
                if (ddlProduit.SelectedIndex == 0)
                {
                    MsgQte.Visible = false;
                    MsgProduit.Text = "Vous devez séléctionner un produit!";
                }
                else if (TxtQte.Text =="")
                {
                    MsgProduit.Visible = false;
                    MsgQte.Text = "Vous devez donner la quantité!";
                    MsgQte.Visible = true;
                }

                else
                {
                    //    description.Visible = true;
                    //    description.Text = "Vous devez remplir tout les champs! ";
                    
                        S.libelleService = "Commande";
                        S.etat = "A";
                        // 1 c'est le code du bureau d'ordre 
                        S.codeDest = 404;
                        S.dateDemande = DateTime.Now;
                        S.codeUtilisateur = User.code_utilisateur;
                        a.Insertservice(S);
                        List<serviceDB> lstService = a.GetServices().Where(w => w.codeUtilisateur == User.code_utilisateur && w.libelleService.Trim() == "Commande").ToList();
                        serviceDB serv = lstService.OrderByDescending(w => w.code_service).FirstOrDefault();
                        
                        DetailCommandeDB Detail = new DetailCommandeDB();
                        try
                        {
                            foreach (GridViewRow row in gv_listeCommande.Rows)
                            {

                                Detail.code_service = serv.code_service;
                                Detail.Id_produit = Convert.ToInt16(row.Cells[0].Text);
                                //Detail.code_dest = serv.codeDest;
                                Detail.Qte = Convert.ToInt16(row.Cells[2].Text);
                                Detail.PU = 0;
                                Detail.Observation = "";
                                a.Inserer_Commande(Detail);
                                description.Visible = true;
                                description.Text = "Commande envoyé avec succée";
                                BindGrid();
                            }
                            Session["lstPanier"] = null;
                        }
                        catch (Exception ex)
                        {

                        }

                   
                }
            }


            catch (Exception ex)
            {
                string msg = ex.Message;
            }
        }




        protected void gv_Commande_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                try
                {
                    AstreeDonnees a = new AstreeDonnees();

                    GridViewRow row = e.Row;
                    serviceDB serv = a.GetServices().Where(w => (w.libelleService != null) && (w.libelleService.Trim() == "Commande") && (w.code_service == Convert.ToInt32(row.Cells[1].Text)) && (w.codeUtilisateur == Convert.ToInt16(Session["code_utilisateur"]))).FirstOrDefault();


                    if (serv != null)
                    {
                        if (serv.etatNotif == "N")
                        {
                            //e.Row.BackColor = System.Drawing.Color.Red;
                            e.Row.ForeColor = System.Drawing.Color.Green;
                        }

                    }

                }
                catch (Exception ex)
                { }
            }
        }

        protected void gv_Commande_SelectedIndexChanged(object sender, EventArgs e)
        {
            AstreeDonnees a = new AstreeDonnees();

            GridViewRow row = gv_Commande.SelectedRow;
            produitDB prod = a.GetProduit().Where(w => w.LibelleProduit.Trim() == row.Cells[3].Text.ToString().Trim()).FirstOrDefault();
            Txtcode.Text = row.Cells[2].Text;
            TxtQte.Text = row.Cells[4].Text;
            ddlProduit.SelectedValue = prod.IdProduit.ToString();//;
            //Session["CodeServ"]
            //MessageLabel.Text = "You selected Devis numéro " + row.Cells[1].Text + ".";
            BtnEnvoyer.Visible = false;

            notificationDB notif = a.GetNotification().Where(w => w.codeService == Convert.ToInt16(row.Cells[1].Text)).FirstOrDefault();
            if (notif != null)
            {
                notif.etatNotif = "L";
                a.maj_notification(notif);
                row.ForeColor = System.Drawing.Color.Black;

                Label x = (Label)Master.FindControl("lblNotifCommandeInter") as Label;

                List<serviceDB> lsNotification = a.GetServices().Where(w => (w.libelleService != null) && (w.etatNotif.Trim() == "N") && (w.codeUtilisateur == Convert.ToInt16(Session["code_utilisateur"]))).ToList();

                x.Text = lsNotification.Where(w => w.libelleService.Trim() == "Commande").Count().ToString();

                Label nbNotification = (Label)Master.FindControl("nbNotification") as Label;
                nbNotification.Text = lsNotification.Count().ToString();

                //Response.Redirect(HttpContext.Current.Request.Url.ToString(), true);
            }

        }
        protected void gv_listeCommande_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = gv_listeCommande.SelectedRow;
            List<DetailCommandeDB> lstCommande = new List<DetailCommandeDB>();
            List<DetailCommandeDB> lstCommande2 = new List<DetailCommandeDB>();
            if (Session["lstCommande"] != null)
            {
                lstCommande = (List<DetailCommandeDB>)Session["lstCommande"];
                lstCommande2 = lstCommande.Where(w => w.Id_produit != Convert.ToInt16(row.Cells[0].Text)).ToList();
                Session["lstCommande"] = null;
                gv_listeCommande.DataSource = lstCommande2;
                gv_listeCommande.DataBind();
                Session["lstCommande"] = lstCommande2;

            }
        }
        private void BindGridListeProduit()
        {
            txterror.Visible = false;
            AstreeDonnees a = new AstreeDonnees();
            DetailCommandeDB detail = new DetailCommandeDB();
            List<DetailCommandeDB> lstCommande = new List<DetailCommandeDB>();
            detail.Id_produit = Convert.ToInt16(ddlProduit.SelectedValue);
            detail.LibelleProduit = ddlProduit.Text;

            try
            {
                detail.Qte = Convert.ToInt16(TxtQte.Text);
                MsgQte.Text = "";
                if (Session["lstPanier"] != null)
                {
                    lstCommande = (List<DetailCommandeDB>)Session["lstPanier"];
                    if (lstCommande.Where(w => w.Id_produit == Convert.ToInt16(ddlProduit.SelectedValue)).Count() > 0)
                    {
                       
                        txterror.Visible = true;
                        txterror.Text = "Vous avez déja selectionné cet article";
                    }
                    else
                    {
                        liste.Visible = false;
                        if (MsgQte.Text == "")
                        {
                            liste.Visible = true;
                            lstCommande.Add(detail);
                        }
                        else
                        {
                            MsgQte.Text = "La quantité doit étre un entier!";
                        }

                    }
                }
                else
                {

                    liste.Visible = false;
                    if (MsgQte.Text == "")
                    {
                        liste.Visible = true;
                        lstCommande.Add(detail);
                    }
                    else
                    {
                        MsgQte.Text = "La quantité doit étre un entier!";
                    }

                }

                gv_listeCommande.DataSource = lstCommande;
                gv_listeCommande.DataBind();
                Session["lstPanier"] = lstCommande;

            }
            catch (Exception ex)
            {
                liste.Visible = false;
                MsgQte.Visible = true;
                MsgQte.Text = "La quantité doit étre un entier!";
            }
        }
        protected void ajouterListe_Click(object sender, ImageClickEventArgs e)
        {

            if (ddlProduit.SelectedIndex == 0) {
                MsgQte.Text = "";
                MsgProduit.Text = "Vous devez séléctionner un produit!"; }
            else if (TxtQte.Text == null || TxtQte.Text == "")
            {
                MsgProduit.Text = "";
                MsgQte.Text = "Vous devez donner la quantité! ";
            }
            
            else
            {
                lblMsgSucces.Visible = false;
                liste.Visible = true;
                BindGridListeProduit();
            }



        }
    }
}