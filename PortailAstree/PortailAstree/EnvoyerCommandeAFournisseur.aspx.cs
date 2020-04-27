using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Net.Mail;
using System.Net;
namespace Astree
{

    public partial class EnvoyerCommandeAFournisseur : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Pnl_GvDetail.Visible = false;
            lblMsgSuccee.Visible = false;
            MsgQte.Visible = false;
            MsgCodeF.Visible = false;
            MsgObser.Visible = false;
            MsgPrix.Visible = false;
            MsgProduit.Visible = false;
            MsgQte.Visible = false;
            MsgObser.Visible = false;
            liste.Visible = false;
            txterror.Visible = false;
           
            PnlInfo.Visible = false;
            
            description.Visible = false;
            if (!(IsPostBack))
            {
                Pnl_GvDetail.Visible = false;
                Session["lstCommande"] = null;
                lblMsgSuccee.Visible = false;
                MsgQte.Visible = false;
                MsgCodeF.Visible = false;
                MsgObser.Visible = false;
                MsgPrix.Visible = false;
                MsgProduit.Visible = false;
                MsgQte.Visible = false;
                MsgObser.Visible = false;
                liste.Visible = false;
                txterror.Visible = false;
                Session["lstCommande"] = null;
                PnlInfo.Visible = false;
                Pnl_GvDetail.Visible = false;
                description.Visible = false;
                this.BindGrid();
                //importerF.Attributes.Add("onclick", "document.getElementById('" + FileUpload1.ClientID + "').click();return false;");
            }

        }
        private void BindGrid()
        {

            AstreeDonnees a = new AstreeDonnees();

            //sachant que 303 est le code profil effectuer aux fournisseurs
            gv_EnvoyerCommande.DataSource = a.GetUser().Where(w => w.code_profil == 303);
            gv_EnvoyerCommande.DataBind();
        }
        private void BindGridListeProduit()
        {
            try
            {
                txterror.Visible = false;
                AstreeDonnees a = new AstreeDonnees();
                DetailCommandeDB detail = new DetailCommandeDB();
                List<DetailCommandeDB> lstCommande = new List<DetailCommandeDB>();
                if (Convert.ToInt16(ddlListeP.SelectedValue) == 0)
                {
                    MsgProduit.Visible = true;
                    MsgProduit.Text = "Vous devez choisir un article!";
                }
                else
                {
                    detail.Id_produit = Convert.ToInt16(ddlListeP.SelectedValue);
                    detail.LibelleProduit = ddlListeP.Text;
                }
                if (txtQte.Text == "")
                {
                    MsgPrix.Text = "";
                    MsgQte.Visible = true;
                    MsgQte.Text = "Vous devez choisir la quantité!";
                }
                else if (txtPrix.Text == "")
                {
                    MsgQte.Text = "";
                    MsgPrix.Visible = true;
                    MsgPrix.Text = "Vous devez choisir le prix unitaire!";
                }
                else
                {
                    detail.PU = Convert.ToInt16(txtPrix.Text);
                    detail.Qte = Convert.ToInt16(txtQte.Text);
                }



                if (txtQte.Text != "" && txtQte.Text != null && txtPrix.Text != "" && txtPrix.Text != null)
                {
                    if (Session["lstCommande"] != null)
                    {
                        lstCommande = (List<DetailCommandeDB>)Session["lstCommande"];
                        if (lstCommande.Where(w => w.Id_produit == Convert.ToInt16(ddlListeP.SelectedValue)).Count() > 0)
                        {
                            MsgPrix.Text = "";
                            MsgQte.Text = "";
                            txterror.Visible = true;
                            txterror.Text = "Vous avez déja selectionné cet article";
                        }
                        else
                        {
                            lstCommande.Add(detail);
                        }

                    }
                    else
                    {


                        lstCommande.Add(detail);




                    }
                    gv_listeCommande.DataSource = lstCommande;
                    gv_listeCommande.DataBind();
                    Session["lstCommande"] = lstCommande;
                }
                else
                {
                    //txterror.Visible = true;
                    //txterror.Text = "Vous avez remplir tout les champs!";
                }
            }
            catch
            {
                Response.Redirect("PageErreur.aspx");
            }

        }
        private void BindGridAffichage(int id)
        {
            AstreeDonnees a = new AstreeDonnees();
            gv_Detail.DataSource = a.GetDetailCommande().Where(w => w.code_dest == id).OrderByDescending(w=>w.dateDemande).ToList();
            gv_Detail.DataBind();
        }
        protected void gv_EnvoyerCommande_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = gv_EnvoyerCommande.SelectedRow;
            Txtcode.Text = row.Cells[1].Text;
            TxtNom.Text = row.Cells[2].Text;
        }
        protected void gv_listeCommande_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = gv_listeCommande.SelectedRow;
            //Txtcode.Text = row.Cells[1].Text;
            //TxtNom.Text = row.Cells[2].Text;
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
       


        protected void affichier_Click(object sender, ImageClickEventArgs e)
        {
            AstreeDonnees a = new AstreeDonnees();
            int id = int.Parse((sender as ImageButton).CommandArgument);

            int ls = a.GetDetailCommande().Where(w => w.code_dest == id).Count();
            if (ls != 0)
            {
                PnlInfo.Visible = false;
                Pnl_GvDetail.Visible = true;
                BindGridAffichage(id);
            }

            else
            {
                Pnl_GvDetail.Visible = false;
                PnlInfo.Visible = true;
                msg.Text = "il n'existe aucune Demande pour cet fournisseur!";
            }
        }

        protected void ajouterListe_Click(object sender, ImageClickEventArgs e)
        {
            liste.Visible = true;
            BindGridListeProduit();
        }
        protected void BtnEnvoyer_Click(object sender, EventArgs e)
        {

            try
            {
                MsgCodeF.Text = "";
                MsgObser.Text = "";
                MsgPrix.Text = "";
                MsgProduit.Text = "";
                MsgQte.Text = "";
                lblMsgSuccee.Text = "";


                AstreeDonnees a = new AstreeDonnees();
                UtilisateurDB User = a.GetUser(Convert.ToInt16(Session["code_utilisateur"].ToString()));
                serviceDB S = new serviceDB();

                S.libelleService = "Commande";
                S.etat = "A";
                if (Txtcode.Text == "")
                {

                    MsgCodeF.Visible = true;
                    MsgCodeF.Text = "Vous devez selectionner un fournisseur!";
                }
                else
                {
                    S.dateDemande = DateTime.Now;
                    S.codeDest = Convert.ToInt16(Txtcode.Text);
                    S.codeUtilisateur =Convert.ToInt16(Session["code_utilisateur"].ToString());
                    a.Insertservice(S);

                   

                  
                    List<serviceDB> lstService = a.GetServices();
                    serviceDB serv = lstService.Where(w => w.codeUtilisateur == User.code_utilisateur).LastOrDefault();

                    notificationDB notif = new notificationDB();
                    notif.codeService = serv.code_service;
                    notif.contenuNotification = serv.reponse;
                    notif.etatNotif = "N";// NON LU
                    notif.dateNotification = serv.dateReponse;
                    a.InsertNotification(notif);


                    DetailCommandeDB Detail = new DetailCommandeDB();
                    if (gv_listeCommande.Rows.Count > 0)
                    {


                        try
                        {
                            foreach (GridViewRow row in gv_listeCommande.Rows)
                            {

                                Detail.code_service = serv.code_service;
                                Detail.Id_produit = Convert.ToInt16(row.Cells[0].Text);

                                Detail.Qte = Convert.ToInt16(row.Cells[2].Text);
                                Detail.PU = Convert.ToInt16(row.Cells[3].Text);
                                if (TxtBesoin.Text == "" || TxtBesoin.Text == null)
                                {
                                    MsgObser.Visible = true;
                                    MsgObser.Text = "Vous devez saisir une observation!";
                                }
                                else
                                {
                                    Detail.Observation = TxtBesoin.Text;
                                    a.Inserer_Commande(Detail);
                                }
                            }
                            if (TxtBesoin.Text == "" || TxtBesoin.Text == null)
                            {
                                MsgObser.Visible = true;
                                MsgObser.Text = "Vous devez saisir une observation!";
                            }
                            else
                            {
                                lblMsgSuccee.Visible = true;
                                lblMsgSuccee.Text = "Commande envoyé avec succés!";
                                Txtcode.Text = "";
                                txtPrix.Text = "";
                                txtQte.Text = "";
                                TxtBesoin.Text = "";
                                // lblMsgSuccee.Text = "";
                            }
                            Session["lstCommande"] = null;

                        }
                        catch (Exception ex)
                        {
                            Response.Redirect("PageErreur.aspx");
                        }
                    }


                    else
                    {
                        MsgCodeF.Text = "";
                        txterror.Visible = true;
                        txterror.Text = "aucun article dans le panier!";
                    }
                }
            }


            catch (Exception ex)
            {
                Response.Redirect("PageErreur.aspx");

            }
        }

        protected void gv_Detail_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = gv_Detail.SelectedRow;
            //txtNum.Text = row.Cells[1].Text;
            //lblMessage.Text = "You selected Commande numéro " + row.Cells[1].Text + ".";
            Txtcode.Text = row.Cells[2].Text;
            txtQte.Text = row.Cells[6].Text;
            txtPrix.Text = row.Cells[5].Text;
            TxtBesoin.Text = row.Cells[7].Text;

            ddlListeP.SelectedItem.Text= row.Cells[4].Text;
            BtnEnvoyer.Visible = false;

            AstreeDonnees a = new AstreeDonnees();
            serviceDB serv = a.GetServices().Where(w=>w.code_service == Convert.ToInt16(row.Cells[1].Text)).FirstOrDefault();

            if (serv.etatNotif == "N")
            {
                List<notificationDB> lstNotif = new List<notificationDB>();
                lstNotif = a.GetNotification();
                notificationDB notif = lstNotif.Where(w=>w.codeService==serv.code_service).FirstOrDefault();             
                notif.etatNotif = "L";//  LU
                a.maj_notification(notif);
                foreach (GridViewRow grvRow in gv_Detail.Rows)
                {
                    if(row.Cells[1].Text== grvRow.Cells[1].Text)
                    {
                        grvRow.ForeColor = System.Drawing.Color.Black;
                    }
                    
                }
                
            }
        }

       

        protected void gv_Detail_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                try
                {
                    AstreeDonnees a = new AstreeDonnees();

                    GridViewRow row = e.Row;
                    serviceDB serv = a.GetServices().Where(w => (w.libelleService != null) && (w.libelleService.Trim() == "Commande") && (w.code_service == Convert.ToInt32(row.Cells[1].Text))).FirstOrDefault();


                    if (serv != null)
                    {

                        if (serv.etat.Trim() == "V")
                        {

                            if (serv.etatNotif.Trim() == "N")
                            {
                                //e.Row.BackColor = System.Drawing.Color.Red;
                                e.Row.ForeColor = System.Drawing.Color.Green;
                            }
                            if (serv.etatNotif.Trim() == "L")
                            {
                                //e.Row.BackColor = System.Drawing.Color.Red;
                                e.Row.ForeColor = System.Drawing.Color.Black;
                            }
                        }

                        if (serv.etat.Trim() == "A")
                        {
                            e.Row.ForeColor = System.Drawing.Color.Red;
                        }
                    }
                }
                catch (Exception ex)
                { }
            }
        }
    }
}