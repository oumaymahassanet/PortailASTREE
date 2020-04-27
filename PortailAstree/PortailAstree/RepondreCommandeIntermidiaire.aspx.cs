using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Astree
{
    public partial class RepondreCommandeIntermidiaire : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                Pnl_GvDetail.Visible = false;
                this.BindGrid();
            }
        }
        private void BindGrid()
        {
            AstreeDonnees a = new AstreeDonnees();
            List<serviceDB> ls = a.GetServices().Where(w => w.libelleService == "Commande" && w.codeDest == 404 && w.etat.Trim() == "A").ToList();
            List<serviceDB> lsServ = new List<serviceDB>();
            List<notificationDB> lstNotif = a.GetNotification();
            gv_Commande.DataSource = ls;
            gv_Commande.DataBind();
            foreach (GridViewRow row in gv_Commande.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    CheckBox cb = (row.Cells[0].FindControl("Accepter") as CheckBox);

                    serviceDB serv = ls.Where(w => w.code_service == Convert.ToInt16(row.Cells[1].Text.ToString().Trim())).FirstOrDefault();
                    if (serv != null)
                    {
                        if (serv.etat.ToString().Trim() == "A")
                        {
                            row.ForeColor = System.Drawing.Color.Red;
                        }

                        if (serv.etat.ToString().Trim() == "V")
                        {
                            cb.Checked = true;
                            row.ForeColor = System.Drawing.Color.Black;


                        }

                    }

                }
            }

        }

        protected void gv_Commande_SelectedIndexChanged(object sender, EventArgs e)
        {
            AstreeDonnees a = new AstreeDonnees();
            //txtetat.Text = "";
            GridViewRow row = gv_Commande.SelectedRow;
            txtNum.Text = row.Cells[1].Text;
            lblMessage.Text = "Vous avez séléctionner la commande numéro " + row.Cells[1].Text + ".";
            //txtProduit.Text = row.Cells[2].Text;
            //txtQuantiteDemandee.Text= row.Cells[4].Text;




            CheckBox cb = (CheckBox)row.FindControl("Accepter");
            if (cb != null && cb.Checked)
            {
                // txtetat.Text = "VALIDEE";
                Btnreponse.Visible = false;
                cb.Enabled = false;
                notificationDB notif = a.GetNotification().Where(w => w.codeService == Convert.ToInt16(txtNum.Text)).FirstOrDefault();
                if (notif != null)
                {
                    notif.etatNotif = "L";
                    a.maj_notification(notif);
                }
                row.ForeColor = System.Drawing.Color.Black;
                Response.Redirect(HttpContext.Current.Request.Url.ToString(), true);





            }
            else
            {
                Btnreponse.Visible = true;
                //cb.Enabled = true;
            }






            List<DetailCommandeDB> ls = a.GetDetailCommande().Where(w => w.LibelleService.Trim() == "Commande" && w.code_dest == 404 && w.code_service == Convert.ToInt16(txtNum.Text)).ToList();
            if (ls.Count() > 0)
            {
                // PnlInfo.Visible = false;
                Pnl_GvDetail.Visible = true;
                gv_Detail.DataSource = ls;
                gv_Detail.DataBind();

            }

            else
            {
                Pnl_GvDetail.Visible = false;
                //PnlInfo.Visible = true;
                //msg.Text = "il n'existe aucune Demande pour cet fournisseur!";
            }

        }
        protected void Accepter_CheckedChanged(object sender, EventArgs e)
        {
            foreach (GridViewRow row in gv_Commande.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    CheckBox cb = (row.Cells[0].FindControl("Accepter") as CheckBox);
                    if (cb.Checked)
                    {
                        // txtetat.Text = "VALIDEE";
                    }
                }
            }



        }
        protected void Btnreponse_Click(object sender, EventArgs e)
        {
            MsgNum.Text = "";
            AstreeDonnees a = new AstreeDonnees();

            //if (txtetat.Text == "VALIDEE")
            //{
            AstreeDonnees ad = new AstreeDonnees();
            if (txtNum.Text!="") {
                serviceDB ser = a.GetServices().Where(w => w.code_service == Convert.ToInt16(txtNum.Text)).FirstOrDefault();

                DetailCommandeDB detailComm = a.GetDetailCommande().Where(w => w.LibelleService.Trim() == "Commande" && w.code_dest == 404 && w.code_service == Convert.ToInt16(txtNum.Text) && w.LibelleProduit.Trim() == txtProduit.Text.Trim()).FirstOrDefault();
                if (txtQteLivree.Text=="") {
                    txtQteLivree.Text = "Vous devez remplir la quantité à livrée";
                }
                if (detailComm != null)
                {

                    detailComm.reponse = txtReponse.Text;
                    detailComm.QteLivree = Convert.ToInt16(txtQteLivree.Text);
                    ad.maj_DetailCommande(detailComm);

                }
                List<DetailCommandeDB> lstDetailComm = a.GetDetailCommande().Where(w => w.LibelleService.Trim() == "Commande" && w.code_dest == 404 && w.code_service == Convert.ToInt16(txtNum.Text) && w.QteLivree == 0).ToList();

                if (ser != null && lstDetailComm.Count == 0)
                {

                    ser.etat = "V";
                    ser.dateReponse = DateTime.Now;
                    ser.reponse = txtReponse.Text;
                    ser.code_service = Convert.ToInt16(txtNum.Text);
                    ser.QteLivree = Convert.ToInt16(txtQteLivree.Text);
                    a.maj_Commande(ser);
                    gv_Detail.Visible = false;
                    Label x = (Label)Master.FindControl("lblNotifCommande") as Label;
                    Label y = (Label)Master.FindControl("lblNotifCommandeInterFourn") as Label;
                    Label z = (Label)Master.FindControl("nbNotification") as Label;

                    List<serviceDB> lsNotification = a.GetServices().Where(w => (w.libelleService != null) && (w.etat.Trim() == "A") && w.codeDest == 404).ToList();
                    x.Text = lsNotification.Where(w => w.libelleService.Trim() == "Commande" && w.etat.Trim() == "A" && w.codeDest == 404).Count().ToString();

                    List<serviceDB> lsNotificationFourn = a.GetServices().Where(w => (w.libelleService != null) && (w.etat.Trim() == "V") && w.codeDest != 404 && w.codeUtilisateur == Convert.ToInt16(Session["code_utilisateur"])).ToList();

                    y.Text = lsNotificationFourn.Count().ToString();



                    z.Text = (Convert.ToInt16(z.Text.ToString()) - 1).ToString();


                    notificationDB notif = new notificationDB();
                    notif.codeService = ser.code_service;
                    notif.contenuNotification = ser.reponse;
                    notif.etatNotif = "N";// NON LU
                    notif.dateNotification = ser.dateReponse;
                    a.InsertNotification(notif);

                    //    Label x = (Label)Master.FindControl("lblNotifCommande") as Label;
                    //    Label y = (Label)Master.FindControl("lblNotifCommandeInterFourn") as Label;
                    //Label z = (Label)Master.FindControl("nbNotification") as Label;

                    //List<serviceDB> lsNotification = a.GetServices().Where(w => (w.libelleService != null) && (w.etat.Trim() == "A") && w.codeDest == 404).ToList();
                    //    x.Text = lsNotification.Where(w => w.libelleService.Trim() == "Commande" && w.etat.Trim() == "A" && w.codeDest == 404).Count().ToString();

                    //List<serviceDB> lsNotificationFourn = a.GetServices().Where(w => (w.libelleService != null) && (w.etat.Trim() == "V") && w.codeDest != 404 && w.codeUtilisateur == Convert.ToInt16(Session["code_utilisateur"])).ToList();

                    //y.Text = lsNotificationFourn.Count().ToString();



                    //z.Text = (Convert.ToInt16(x.Text) + Convert.ToInt16(y.Text)).ToString();


                    BindGrid();

                }
            }
            else
            {

                MsgNum.Text = "Vous devez séléctionner une commande!";
            }            
            // }
        }

        protected void gv_Commande_RowDataBound(object sender, GridViewRowEventArgs e)
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
                        if (serv.etatNotif == "N")
                        {
                            //e.Row.BackColor = System.Drawing.Color.Red;
                            e.Row.ForeColor = System.Drawing.Color.Red;
                        }

                    }

                }
                catch (Exception ex)
                { }
            }
        }

        protected void affichier_Click(object sender, ImageClickEventArgs e)
        {
            AstreeDonnees a = new AstreeDonnees();
            int id = int.Parse((sender as ImageButton).CommandArgument);
            txtNum.Text = id.ToString();
            lblMessage.Text = "Vous avez séléctionner la commande numéro " + txtNum.Text + ".";
            List<DetailCommandeDB> ls = a.GetDetailCommande().Where(w => w.LibelleService.Trim() == "Commande" && w.code_dest == 404 && w.code_service == Convert.ToInt16(txtNum.Text)).ToList();
            if (ls.Count() > 0)
            {
                // PnlInfo.Visible = false;
                Pnl_GvDetail.Visible = true;
                gv_Detail.DataSource = ls;
                gv_Detail.DataBind();

            }

            else
            {
                Pnl_GvDetail.Visible = false;
                //PnlInfo.Visible = true;
                //msg.Text = "il n'existe aucune Demande pour cet fournisseur!";
            }
        }

        protected void gv_Detail_SelectedIndexChanged(object sender, EventArgs e)
        {
            AstreeDonnees a = new AstreeDonnees();
            //  txtetat.Text = "";
            GridViewRow row = gv_Detail.SelectedRow;
            //txtNum.Text = row.Cells[1].Text;
            //lblMessage.Text = "You selected Commande numéro " + row.Cells[1].Text + ".";
            txtProduit.Text = row.Cells[2].Text;
            txtQuantiteDemandee.Text = row.Cells[3].Text;
        }
    }
}