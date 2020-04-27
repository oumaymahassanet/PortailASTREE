using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace Astree
{
    public partial class DemanderReclamation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["code_utilisateur"] == null)
            {
                Response.Redirect("login.aspx");
            }
            if (!this.IsPostBack)
            {
                TxtCode.Text = Session["Code_utilisateur"].ToString();
                BindGrid();
            }
        }
        private void BindGrid()
        {
            AstreeDonnees a = new AstreeDonnees();
            List<serviceDB> ls = a.GetServices().Where(w => w.libelleService.Trim() == "Reclamation" && w.codeUtilisateur == Convert.ToInt16(Session["Code_utilisateur"])).OrderBy(w => w.etat).ThenByDescending(w => w.code_service).ToList();

            List<destinationDB> lstDestination = a.GetDestination();

            foreach (serviceDB serv in ls)
            {
                destinationDB dest = lstDestination.Where(w => w.codeDest == serv.codeDest).FirstOrDefault();
                if (dest != null)
                {
                    serv.libelleDest = dest.libelleDest;
                }
            }
            List<serviceDB> lsFin = ls.OrderBy(w => w.etat.Trim()).ThenByDescending(w => w.etatNotif).ThenByDescending(w => w.dateReponse).ToList();
            Session["lstReclamation"] = lsFin;
            gv_Reclamation.DataSource = lsFin;
            gv_Reclamation.DataBind();
        }

        protected void Btnsave_Click(object sender, EventArgs e)
        {

            //AstreeDonnees a = new AstreeDonnees();
            //serviceDB S = new serviceDB();

            ////serviceDB S1 = new serviceDB();
            //// S1 = a.GetServices().Where(w=>w.libelleService.Trim()=="Reclamation").FirstOrDefault();
            //S.libelleService = "Reclamation";
            //S.etat = "A";
            //S.idType = Convert.ToInt16(ddlRec.SelectedValue);
            //S.dateDemande = DateTime.Now;
            //S.contenuReclamation = TxtCommentaire.Text;
            //S.codeDest = Convert.ToInt16(ddlDest.SelectedValue);
            //S.codeUtilisateur = Convert.ToInt16(TxtCode.Text);
            //S.idSousBranche = 1;
            //a.Insertservice(S);
            //BindGrid();

            try
            {

                MsgContenu.Text = "";
                AstreeDonnees a = new AstreeDonnees();
                serviceDB S = new serviceDB();
                S.libelleService = "Reclamation";
                S.etat = "A";
                S.dateDemande = DateTime.Now;
                if (TxtCommentaire.Text == "")
                {
                    
                    MsgddlDest.Visible = false;
                    MsgContenu.Visible = true;
                    MsgContenu.Text = "Vous devez saisir votre réclamation!";
                }
                else if (ddlDest.SelectedIndex == 0)
                {
                    
                    MsgContenu.Visible = false;
                    MsgddlDest.Visible = true;
                    MsgddlDest.Text = "Vous devez selectionner la destination! ";
                }
                
                else
                {
                    MsgContenu.Visible = false;
                    MsgddlDest.Visible = false;
                    S.contenuReclamation = TxtCommentaire.Text;
                    S.codeDest = Convert.ToInt16(ddlDest.SelectedValue);
                    S.codeUtilisateur = Convert.ToInt16(TxtCode.Text);
                    S.idSousBranche = 1;
                    a.Insertservice(S);
                    BindGrid();
                    lblMsgSucces.Visible = true;
                    lblMsgSucces.Text = "La demande a été transmis avec succés";
                    ddlDest.SelectedIndex = 0;
                    TxtCommentaire.Text = "";
                }
            }

            catch
            {

                Response.Redirect("PageErreur.aspx");
            }
        }


        protected void gv_Reclamation_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gv_Reclamation.PageIndex = e.NewPageIndex;
            gv_Reclamation.DataSource = Session["lstReclamation"];
            gv_Reclamation.DataBind();
            gv_Reclamation.SelectedIndex = -1;
        }

        protected void gv_Reclamation_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                try
                {
                    AstreeDonnees a = new AstreeDonnees();

                    GridViewRow row = e.Row;
                    serviceDB serv = a.GetServices().Where(w => w.code_service == Convert.ToInt32(row.Cells[1].Text)).FirstOrDefault();


                    if (serv != null)
                    {
                        if (serv.etat.Trim() == "A")
                        {
                            e.Row.ForeColor = System.Drawing.Color.Red;
                        }
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
                            if (serv.etatNotif.Trim() == "")
                            {
                                //e.Row.BackColor = System.Drawing.Color.Red;
                                e.Row.ForeColor = System.Drawing.Color.Green;
                            }
                        }
                    }

                }
                catch (Exception ex)
                { }
            }
        }

        protected void gv_Reclamation_SelectedIndexChanged(object sender, EventArgs e)
        {
            Btnsave.Visible = false;
            AstreeDonnees a = new AstreeDonnees();

            GridViewRow row = gv_Reclamation.SelectedRow;
            serviceDB serv = a.GetServices().Where(w => w.code_service == Convert.ToInt32(row.Cells[1].Text)).FirstOrDefault();
            UtilisateurDB user = a.GetUser(Convert.ToInt16(serv.codeUtilisateur));

            TxtCode.Text = serv.codeUtilisateur.ToString();
           

            List<destinationDB> lstDestination = a.GetDestination();

            destinationDB dest = lstDestination.Where(w => w.codeDest == Convert.ToInt16(row.Cells[5].Text.Trim())).FirstOrDefault();
            if (dest != null)
            {
                ddlDest.SelectedItem.Text = dest.libelleDest;
            }

            TxtCommentaire.Text = row.Cells[4].Text.Trim();

            notificationDB notif = a.GetNotification().Where(w => w.codeService == serv.code_service).FirstOrDefault();
            if (notif != null)
            {
                if (notif.etatNotif == "N")
                {

                    notif.etatNotif = "L";
                    a.maj_notification(notif);
                    row.ForeColor = System.Drawing.Color.Black;

                    Label x = (Label)Master.FindControl("lblNotifReclamation") as Label;

                    List<serviceDB> lsNotification = a.GetServices().Where(w => (w.libelleService != null) && (w.etatNotif.Trim() == "N") && (w.codeUtilisateur == Convert.ToInt16(Session["code_utilisateur"]))).ToList();

                    x.Text = lsNotification.Where(w => w.libelleService.Trim() == "Reclamation").Count().ToString();

                    Label nbNotification = (Label)Master.FindControl("nbNotification") as Label;
                    nbNotification.Text = (Convert.ToInt16(nbNotification.Text) - 1).ToString();






                }
            }
            BindGrid();
        }
    }
}