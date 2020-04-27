using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace Astree
{

    public partial class AfficherDerogation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (Session["code_utilisateur"] == null)
            {
                Response.Redirect("login.aspx");
            }





            //ddltype.SelectedIndex = -1;
            if (!this.IsPostBack)
            {
                pnlDerogation.Visible = false;
                AstreeDonnees a = new AstreeDonnees();
                ddltype.DataSource = a.GetTypeService().Where(w => w.famille_type.Trim() == "Derogation").ToList();
                ddltype.DataBind();
                if (Session["remise"] == null)
                {

                }
                else
                {
                    if (Session["remise"].ToString() == "0")
                    {
                        ddltype.SelectedIndex = 0;
                        pnlTaux.Visible = true;
                        pnlDuree.Visible = false;
                        gvRemise.Visible = true;
                        gvSouscription.Visible = false;
                        gvProrogation.Visible = false;
                    }
                }

                if (Session["prorogation"] == null)
                {

                }
                else
                {
                    if (Session["prorogation"].ToString() == "1")
                    {
                        ddltype.SelectedIndex = 1;
                        pnlTaux.Visible = false;
                        pnlDuree.Visible = true;
                        gvRemise.Visible = false;
                        gvSouscription.Visible = false;
                        gvProrogation.Visible = true;
                    }
                }
                if (Session["souscription"] == null)
                {

                }
                else
                {

                    if (Session["souscription"].ToString() == "2")
                    {
                        ddltype.SelectedIndex = 2;
                        pnlTaux.Visible = false;
                        pnlDuree.Visible = false;
                        gvRemise.Visible = false;
                        gvSouscription.Visible = true;
                        gvProrogation.Visible = false;
                    }
                }



                UtilisateurDB user = a.GetUser(Convert.ToInt16(Session["code_utilisateur"].ToString()));
                profilDB P = a.Getprofil(Convert.ToInt32(user.code_profil));

                // if (Session["code_profil"].Equals("505"))
                if (user.code_profil == 606)
                {
                    Btnreponse.Visible = true;

                }
                this.BindGrid();


                if (ddltype.SelectedIndex == 0)
                {
                    pnlTaux.Visible = true;
                    pnlDuree.Visible = false;
                    gvRemise.Visible = true;
                    gvSouscription.Visible = false;
                    gvProrogation.Visible = false;
                }

                if (ddltype.SelectedIndex == 1)
                {
                    pnlTaux.Visible = false;
                    pnlDuree.Visible = true;
                    gvRemise.Visible = false;
                    gvSouscription.Visible = false;
                    gvProrogation.Visible = true;
                }

                if (ddltype.SelectedIndex == 2)
                {
                    pnlTaux.Visible = false;
                    pnlDuree.Visible = false;
                    gvRemise.Visible = false;
                    gvSouscription.Visible = true;
                    gvProrogation.Visible = false;
                }

            }
        }
        private void BindGrid()
        {

            AstreeDonnees a = new AstreeDonnees();

            UtilisateurDB user = a.GetUser(Convert.ToInt16(Session["code_utilisateur"].ToString()));
            List<serviceDB> ls = new List<serviceDB>();
            List<serviceDB> lss = new List<serviceDB>();
            List<serviceDB> lsss = new List<serviceDB>();
            //Gestionnaire
            if (user.code_profil != 101 && user.code_profil != 202)
            {
                ls = a.GetServices().Where(w => (w.libelleService != null) && (w.libelleService.Trim() == "Derogation") && (w.libelleType.Trim() == "Remise")).OrderBy(w => w.etat).ToList();
                lss = a.GetServices().Where(w => (w.libelleService != null) && (w.libelleService.Trim() == "Derogation") && (w.libelleType.Trim() == "Prorogation")).OrderBy(w => w.etat).ToList();
                lsss = a.GetServices().Where(w => (w.libelleService != null) && (w.libelleService.Trim() == "Derogation") && (w.libelleType.Trim() == "Souscription")).OrderBy(w => w.etat).ToList();

            }
            //Agent et courtier
            else
            {
                ls = a.GetServices().Where(w => (w.libelleService != null) && (w.libelleService.Trim() == "Derogation") && (w.libelleType.Trim() == "Remise") && (w.codeUtilisateur == user.code_utilisateur)).OrderByDescending(w => w.etatNotif).ToList();
                lss = a.GetServices().Where(w => (w.libelleService != null) && (w.libelleService.Trim() == "Derogation") && (w.libelleType.Trim() == "Prorogation") && (w.codeUtilisateur == user.code_utilisateur)).OrderByDescending(w => w.etatNotif).ToList();
                lsss = a.GetServices().Where(w => (w.libelleService != null) && (w.libelleService.Trim() == "Derogation") && (w.libelleType.Trim() == "Souscription") && (w.codeUtilisateur == user.code_utilisateur)).OrderByDescending(w => w.etatNotif).ToList();
            }


            List<serviceDB> lsServ = new List<serviceDB>();
            List<notificationDB> lstNotif = a.GetNotification();
            Session["lstremise"] = ls;
            gvRemise.DataSource = ls;
            gvRemise.DataBind();

            profilDB P = a.Getprofil(Convert.ToInt32(user.code_profil));

            //if (P.code== 606)
            //{
            //    lss = a.GetServices().Where(w => (w.libelleService != null) && (w.libelleService.Trim() == "Derogation") && (w.libelleType.Trim() == "prorogation") ).ToList();
            //    Session["lstproro"] = lss;
            //    gvProrogation.DataSource = lss;
            //    gvProrogation.DataBind();
            //}
            //else
            //{
            //     lss = a.GetServices().Where(w => (w.libelleService != null) && (w.libelleService.Trim() == "Derogation") && (w.libelleType.Trim() == "prorogation") && (w.codeUtilisateur == Convert.ToInt16(Session["code_utilisateur"]))).ToList();
            //    Session["lstproro"] = lss;
            //    gvProrogation.DataSource = lss;
            //    gvProrogation.DataBind();
            //}

            Session["lstproro"] = lss;
            gvProrogation.DataSource = lss;
            gvProrogation.DataBind();

            Session["lstsouscrip"] = lsss;
            gvSouscription.DataSource = lsss;
            gvSouscription.DataBind();

            foreach (GridViewRow row in gvRemise.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    CheckBox cb = (row.Cells[0].FindControl("Accepter") as CheckBox);

                    serviceDB serv = ls.Where(w => w.code_service == Convert.ToInt16(row.Cells[1].Text.ToString().Trim())).FirstOrDefault();
                    if (serv != null)
                    {


                        if (serv.etat.ToString().Trim() == "A")
                        {
                            //Gestionnaire
                            if (user.code_profil != 101 && user.code_profil != 202)
                            {
                                row.ForeColor = System.Drawing.Color.Red;
                            }
                            //Agent ou Courtier
                            else
                            {
                                row.ForeColor = System.Drawing.Color.Black;
                            }
                        }
                        if (serv.etat.ToString().Trim() == "V")
                        {
                            cb.Checked = true;

                            //Gestionnaire
                            if (user.code_profil != 101 && user.code_profil != 202)
                            {


                                row.ForeColor = System.Drawing.Color.Black;

                            }
                            //Agent ou Courtier
                            else
                            {
                                if (serv.etatNotif.ToString().Trim() == "N")
                                {

                                    row.ForeColor = System.Drawing.Color.Green;
                                }

                                if (serv.etatNotif.ToString().Trim() == "L")
                                {

                                    row.ForeColor = System.Drawing.Color.Black;
                                }
                            }





                        }



                    }

                }
            }



            foreach (GridViewRow row in gvProrogation.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    CheckBox cb = (row.Cells[0].FindControl("AccepterProrogation") as CheckBox);

                    serviceDB serv = lss.Where(w => w.code_service == Convert.ToInt16(row.Cells[1].Text.ToString().Trim())).FirstOrDefault();
                    if (serv != null)
                    {


                        if (serv.etat.ToString().Trim() == "A")
                        {
                            //Gestionnaire
                            if (user.code_profil != 101 && user.code_profil != 202)
                            {
                                row.ForeColor = System.Drawing.Color.Red;
                            }
                            //Agent ou Courtier
                            else
                            {
                                row.ForeColor = System.Drawing.Color.Black;
                            }
                        }
                        if (serv.etat.ToString().Trim() == "V")
                        {
                            cb.Checked = true;

                            //Gestionnaire
                            if (user.code_profil != 101 && user.code_profil != 202)
                            {

                                row.ForeColor = System.Drawing.Color.Black;

                            }
                            //Agent ou Courtier
                            else
                            {
                                if (serv.etatNotif.ToString().Trim() == "N")
                                {

                                    row.ForeColor = System.Drawing.Color.Green;
                                }

                                if (serv.etatNotif.ToString().Trim() == "L")
                                {

                                    row.ForeColor = System.Drawing.Color.Black;
                                }
                            }





                        }



                    }

                }
            }



            foreach (GridViewRow row in gvSouscription.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    CheckBox cb = (row.Cells[0].FindControl("AccepterSouscription") as CheckBox);

                    serviceDB serv = lsss.Where(w => w.code_service == Convert.ToInt16(row.Cells[1].Text.ToString().Trim())).FirstOrDefault();
                    if (serv != null)
                    {


                        if (serv.etat.ToString().Trim() == "A")
                        {
                            //Gestionnaire
                            if (user.code_profil != 101 && user.code_profil != 202)
                            {
                                row.ForeColor = System.Drawing.Color.Red;
                            }
                            //Agent ou Courtier
                            else
                            {
                                row.ForeColor = System.Drawing.Color.Black;
                            }
                        }
                        if (serv.etat.ToString().Trim() == "V")
                        {
                            cb.Checked = true;

                            //Gestionnaire
                            if (user.code_profil != 101 && user.code_profil != 202)
                            {


                                row.ForeColor = System.Drawing.Color.Black;

                            }
                            //Agent ou Courtier
                            else
                            {
                                if (serv.etatNotif.ToString().Trim() == "N")
                                {

                                    row.ForeColor = System.Drawing.Color.Green;
                                }

                                if (serv.etatNotif.ToString().Trim() == "L")
                                {

                                    row.ForeColor = System.Drawing.Color.Black;
                                }
                            }





                        }



                    }

                }
            }
        }






        protected void gvRemise_SelectedIndexChanged(object sender, EventArgs e)
        {
            pnlDerogation.Visible = true;
            AstreeDonnees a = new AstreeDonnees();
            //Faire ceci pour toutes les grids
            Txtetat.Text = "";
            GridViewRow row = gvRemise.SelectedRow;
            txtId.Text = row.Cells[1].Text;
            txttype.Text = row.Cells[2].Text;
            txtproduit.Text = row.Cells[3].Text;
            txtsousproduit.Text = row.Cells[4].Text;
           // txtdatedemande.Text = row.Cells[5].Text;
            txtnumcontrat.Text = row.Cells[6].Text;
            txttaux.Text = row.Cells[7].Text;

            serviceDB serv = a.GetServices().Where(w => w.code_service == Convert.ToInt16(row.Cells[1].Text)).FirstOrDefault();
            CheckBox cb = (CheckBox)row.FindControl("Accepter");
            if (cb != null && cb.Checked)
            {
                Txtetat.Text = "VALIDEE";
                if (serv.etat.Trim() == "V")
                {
                    Btnreponse.Visible = false;
                }

                cb.Enabled = false;
                notificationDB notif = a.GetNotification().Where(w => w.codeService == Convert.ToInt16(txtId.Text)).FirstOrDefault();

                if (notif != null)
                {
                    if (notif.etatNotif == "N")
                    {
                        UtilisateurDB user = a.GetUser(Convert.ToInt16(Session["code_utilisateur"].ToString()));
                        if (user.code_profil == 101 || user.code_profil == 202)
                        {
                            notif.etatNotif = "L";
                            a.maj_notification(notif);
                            row.ForeColor = System.Drawing.Color.Black;
                            // Response.Redirect(HttpContext.Current.Request.Url.ToString(), true);
                            Label x = (Label)Master.FindControl("lblNotifRemise") as Label;

                            List<serviceDB> lsNotification = a.GetServices().Where(w => (w.libelleService != null) && (w.etatNotif.Trim() == "N") && (w.codeUtilisateur == Convert.ToInt16(Session["code_utilisateur"]))).ToList();

                            x.Text = lsNotification.Where(w => w.libelleService.Trim() == "Derogation" && w.idType == 1).Count().ToString();

                            Label nbNotification = (Label)Master.FindControl("nbNotification") as Label;
                            nbNotification.Text = lsNotification.Count().ToString();

                        }

                    }
                }

            }
            else
            {
                UtilisateurDB user = a.GetUser(Convert.ToInt16(Session["code_utilisateur"].ToString()));
                profilDB P = a.Getprofil(Convert.ToInt32(user.code_profil));

                // if (Session["code_profil"].Equals("505"))
                if (user.code_profil == 606)
                {
                    Btnreponse.Visible = true;

                }
                cb.Enabled = true;
            }
            MessageLabel.Text = "Vous avez séléctionner la dérogation numéro " + row.Cells[1].Text + ".";

        }


        protected void Accepter_CheckedChanged(object sender, EventArgs e)
        {

            foreach (GridViewRow row in gvRemise.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    CheckBox cb = (row.Cells[0].FindControl("Accepter") as CheckBox);
                    if (cb.Checked)
                    {
                        if (row.Cells[1].Text == txtId.Text)
                        {
                            Txtetat.Text = "VALIDEE";
                        }
                    }
                }
            }



        }


        protected void Btnreponse_Click(object sender, EventArgs e)
        {
            AstreeDonnees a = new AstreeDonnees();

            if (txtproduit.Text != "")
            {
                List<serviceDB> lstService = a.GetServices();
                serviceDB ser = new serviceDB();
                ser = lstService.Where(w => w.code_service == Convert.ToInt16(txtId.Text)).FirstOrDefault();
                if (ser != null)
                {
                    if (Txtetat.Text != "VALIDEE")
                    {
                        lblMsgSucces.Visible = false;
                        MsgProduit.Visible = false;
                        MsgEtat.Visible = true;
                        MsgEtat.Text = "Vous devez valider le devis selectionné!";
                    }
                    else {

                        if (String.IsNullOrEmpty(txtreponse.Text))
                        {
                            lblMsgSucces.Visible = false;
                            MsgEtat.Visible = false;
                            Msgreponse.Visible = true;
                            Msgreponse.Text = "veuillez remplir la réponse ";
                        }
                        else
                        {
                            ser.etat = "V";

                            ser.dateReponse = DateTime.Now;



                            ser.reponse = txtreponse.Text;
                            a.maj_derogation(ser);
                            BindGrid();
                            MsgEtat.Visible = false;
                            Msgreponse.Visible = false;
                            lblMsgSucces.Visible = true;
                           lblMsgSucces.Text = "Reponse envoyée avec succès ";

                            if (ser.etatNotif == "")
                            {
                                notificationDB notif = new notificationDB();
                                notif.codeService = ser.code_service;
                                notif.contenuNotification = ser.reponse;
                                notif.etatNotif = "N";// NON LU
                                notif.dateNotification = ser.dateReponse;
                                a.InsertNotification(notif);
                                Label b = (Label)Master.FindControl("nbNotification") as Label;

                                Label x = (Label)Master.FindControl("lblNotifRemise") as Label;

                                List<serviceDB> lsNotification = a.GetServices().Where(w => (w.libelleService != null) && (w.etat.Trim() == "A")).ToList();

                                x.Text = lsNotification.Where(w => w.libelleService.Trim() == "Derogation" && w.idType == 1).Count().ToString();
                                //b.Text = x.Text;
                                Label y = (Label)Master.FindControl("lblNotifProrogation") as Label;

                                y.Text = lsNotification.Where(w => w.libelleService.Trim() == "Derogation" && w.idType == 2).Count().ToString();
                                //b.Text = y.Text;
                                Label z = (Label)Master.FindControl("lblNotifSouscription") as Label;
                                z.Text = lsNotification.Where(w => w.libelleService.Trim() == "Derogation" && w.idType == 3).Count().ToString();

                                //b.Text = z.Text;

                                b.Text = (Convert.ToInt16(b.Text.ToString()) - 1).ToString();

                            }
                        }


                       
                    }
                   



                }
                else
                {
                    MsgEtat.Visible = false;
                    MsgProduit.Visible = true;
                    MsgProduit.Text = "Vous devez selectionner un devis!";
                }

            }

        }



        protected void ddltype_SelectedIndexChanged(object sender, EventArgs e)
        {

            BindGrid();
            Session["souscription"] = null;
            Session["prorogation"] = null;
            Session["remise"] = null;


            //remise
            if (ddltype.SelectedIndex == 0)
            {

                pnlDuree.Visible = false;
                pnlTaux.Visible = true;
                txtduree.Text = "0";
                gvRemise.Visible = true;
                gvSouscription.Visible = false;
                gvProrogation.Visible = false;
            }
            //prorogation
            if (ddltype.SelectedIndex == 1)
            {

                pnlDuree.Visible = true;
                pnlTaux.Visible = false;
                txttaux.Text = "0";
                gvRemise.Visible = false;
                gvSouscription.Visible = false;
                gvProrogation.Visible = true;
            }
            //souscription
            if (ddltype.SelectedIndex == 2)
            {

                pnlDuree.Visible = false;
                pnlTaux.Visible = false;
                txtduree.Text = "0";
                txttaux.Text = "0";
                gvRemise.Visible = false;
                gvSouscription.Visible = true;
                gvProrogation.Visible = false;
            }
        }

        protected void gvRemise_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvRemise.PageIndex = e.NewPageIndex;
            gvRemise.DataSource = Session["lstremise"];
            gvRemise.DataBind();
            gvRemise.SelectedIndex = -1;


            AstreeDonnees a = new AstreeDonnees();
            List<serviceDB> ls = a.GetServices().Where(w => (w.libelleService != null) && (w.libelleService.Trim() == "Derogation")).ToList();

            foreach (GridViewRow row in gvRemise.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    CheckBox cb = (row.Cells[0].FindControl("Accepter") as CheckBox);

                    serviceDB serv = ls.Where(w => w.code_service == Convert.ToInt16(row.Cells[1].Text.ToString().Trim())).FirstOrDefault();


                    UtilisateurDB user = a.GetUser(Convert.ToInt16(Session["code_utilisateur"].ToString()));

                    if (serv != null)
                    {


                        if (serv.etat.ToString().Trim() == "A")
                        {
                            //Gestionnaire
                            if (user.code_profil != 101 && user.code_profil != 202)
                            {
                                row.ForeColor = System.Drawing.Color.Red;
                            }
                            //Agent ou Courtier
                            else
                            {
                                row.ForeColor = System.Drawing.Color.Black;
                            }
                        }
                        if (serv.etat.ToString().Trim() == "V")
                        {
                            cb.Checked = true;

                            //Gestionnaire
                            if (user.code_profil != 101 && user.code_profil != 202)
                            {


                                row.ForeColor = System.Drawing.Color.Black;

                            }
                            //Agent ou Courtier
                            else
                            {
                                if (serv.etatNotif.ToString().Trim() == "N")
                                {

                                    row.ForeColor = System.Drawing.Color.Green;
                                }

                                if (serv.etatNotif.ToString().Trim() == "L")
                                {

                                    row.ForeColor = System.Drawing.Color.Black;
                                }
                            }





                        }



                    }





                }
            }
        }


        protected void gvProrogation_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvProrogation.PageIndex = e.NewPageIndex;
            gvProrogation.DataSource = Session["lstproro"];
            gvProrogation.DataBind();
            gvProrogation.SelectedIndex = -1;

            AstreeDonnees a = new AstreeDonnees();
            List<serviceDB> lss = a.GetServices().Where(w => (w.libelleService != null) && (w.libelleService.Trim() == "Derogation") && (w.libelleType.Trim() == "Prorogation")).ToList();

            foreach (GridViewRow row in gvProrogation.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    CheckBox cb = (row.Cells[0].FindControl("AccepterProrogation") as CheckBox);

                    serviceDB serv = lss.Where(w => w.code_service == Convert.ToInt16(row.Cells[1].Text.ToString().Trim())).FirstOrDefault();
                    UtilisateurDB user = a.GetUser(Convert.ToInt16(Session["code_utilisateur"].ToString()));

                    if (serv != null)
                    {


                        if (serv.etat.ToString().Trim() == "A")
                        {
                            //Gestionnaire
                            if (user.code_profil != 101 && user.code_profil != 202)
                            {
                                row.ForeColor = System.Drawing.Color.Red;
                            }
                            //Agent ou Courtier
                            else
                            {
                                row.ForeColor = System.Drawing.Color.Black;
                            }
                        }
                        if (serv.etat.ToString().Trim() == "V")
                        {
                            cb.Checked = true;

                            //Gestionnaire
                            if (user.code_profil != 101 && user.code_profil != 202)
                            {


                                row.ForeColor = System.Drawing.Color.Black;

                            }
                            //Agent ou Courtier
                            else
                            {
                                if (serv.etatNotif.ToString().Trim() == "N")
                                {

                                    row.ForeColor = System.Drawing.Color.Green;
                                }

                                if (serv.etatNotif.ToString().Trim() == "L")
                                {

                                    row.ForeColor = System.Drawing.Color.Black;
                                }
                            }





                        }



                    }

                }
            }

        }

        protected void gvSouscription_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvSouscription.PageIndex = e.NewPageIndex;
            gvSouscription.DataSource = Session["lstsouscrip"];
            gvSouscription.DataBind();
            gvSouscription.SelectedIndex = -1;

            AstreeDonnees a = new AstreeDonnees();
            List<serviceDB> lsss = a.GetServices().Where(w => (w.libelleService != null) && (w.libelleService.Trim() == "Derogation") && (w.libelleType.Trim() == "Souscription")).ToList();

            foreach (GridViewRow row in gvSouscription.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    CheckBox cb = (row.Cells[0].FindControl("AccepterSouscription") as CheckBox);

                    serviceDB serv = lsss.Where(w => w.code_service == Convert.ToInt16(row.Cells[1].Text.ToString().Trim())).FirstOrDefault();
                    UtilisateurDB user = a.GetUser(Convert.ToInt16(Session["code_utilisateur"].ToString()));

                    if (serv != null)
                    {


                        if (serv.etat.ToString().Trim() == "A")
                        {
                            //Gestionnaire
                            if (user.code_profil != 101 && user.code_profil != 202)
                            {
                                row.ForeColor = System.Drawing.Color.Red;
                            }
                            //Agent ou Courtier
                            else
                            {
                                row.ForeColor = System.Drawing.Color.Black;
                            }
                        }
                        if (serv.etat.ToString().Trim() == "V")
                        {
                            cb.Checked = true;

                            //Gestionnaire
                            if (user.code_profil != 101 && user.code_profil != 202)
                            {


                                row.ForeColor = System.Drawing.Color.Black;

                            }
                            //Agent ou Courtier
                            else
                            {
                                if (serv.etatNotif.ToString().Trim() == "N")
                                {

                                    row.ForeColor = System.Drawing.Color.Green;
                                }

                                if (serv.etatNotif.ToString().Trim() == "L")
                                {

                                    row.ForeColor = System.Drawing.Color.Black;
                                }
                            }





                        }



                    }

                }
            }
        }

        protected void gvProrogation_SelectedIndexChanged(object sender, EventArgs e)
        {
            pnlDerogation.Visible = true;
            AstreeDonnees a = new AstreeDonnees();
            Txtetat.Text = "";
            GridViewRow row = gvProrogation.SelectedRow;
            txtId.Text = row.Cells[1].Text;
            txttype.Text = row.Cells[2].Text;
            txtproduit.Text = row.Cells[3].Text;
            txtsousproduit.Text = row.Cells[4].Text;
        //    txtdatedemande.Text = row.Cells[5].Text;
            txtnumcontrat.Text = row.Cells[6].Text;
            txtduree.Text = row.Cells[7].Text;

            serviceDB serv = a.GetServices().Where(w => w.code_service == Convert.ToInt16(row.Cells[1].Text)).FirstOrDefault();


            CheckBox cb = (CheckBox)row.FindControl("AccepterProrogation");
            if (cb != null && cb.Checked)
            {
                Txtetat.Text = "VALIDEE";
                if (serv.etat.Trim() == "V")
                {
                    Btnreponse.Visible = false;
                }

                cb.Enabled = false;
                notificationDB notif = a.GetNotification().Where(w => w.codeService == Convert.ToInt16(txtId.Text)).FirstOrDefault();
                if (notif != null)
                {
                    if (notif.etatNotif == "N")
                    {
                        UtilisateurDB user = a.GetUser(Convert.ToInt16(Session["code_utilisateur"].ToString()));
                        if (user.code_profil == 101 || user.code_profil == 202)
                        {
                            notif.etatNotif = "L";
                            a.maj_notification(notif);
                            row.ForeColor = System.Drawing.Color.Black;
                            // Response.Redirect(HttpContext.Current.Request.Url.ToString(), true);
                            Label x = (Label)Master.FindControl("lblNotifProrogation") as Label;

                            List<serviceDB> lsNotification = a.GetServices().Where(w => (w.libelleService != null) && (w.etatNotif.Trim() == "N") && (w.codeUtilisateur == Convert.ToInt16(Session["code_utilisateur"]))).ToList();

                            x.Text = lsNotification.Where(w => w.libelleService.Trim() == "Derogation" && w.idType == 2).Count().ToString();

                            Label nbNotification = (Label)Master.FindControl("nbNotification") as Label;
                            nbNotification.Text = lsNotification.Count().ToString();

                        }

                    }
                }
            }
            else
            {
                UtilisateurDB user = a.GetUser(Convert.ToInt16(Session["code_utilisateur"].ToString()));
                profilDB P = a.Getprofil(Convert.ToInt32(user.code_profil));

                // if (Session["code_profil"].Equals("505"))
                if (user.code_profil == 606)
                {
                    Btnreponse.Visible = true;

                }
                cb.Enabled = true;
            }
        }


        protected void AccepterProrogation_CheckedChanged1(object sender, EventArgs e)
        {
            foreach (GridViewRow row in gvProrogation.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    CheckBox cb = (row.Cells[0].FindControl("AccepterProrogation") as CheckBox);
                    if (cb.Checked)
                    {
                        if (row.Cells[1].Text == txtId.Text)
                        {
                            Txtetat.Text = "VALIDEE";
                        }
                    }
                }
            }
        }


        protected void gvSouscription_SelectedIndexChanged(object sender, EventArgs e)
        {
            pnlDerogation.Visible = true;
            AstreeDonnees a = new AstreeDonnees();
            Txtetat.Text = "";

            GridViewRow row = gvSouscription.SelectedRow;
            txtId.Text = row.Cells[1].Text;
            txttype.Text = row.Cells[2].Text;
            txtproduit.Text = row.Cells[3].Text;
            txtsousproduit.Text = row.Cells[4].Text;
          //  txtdatedemande.Text = row.Cells[5].Text;
            //txtnumcontrat.Text = row.Cells[6].Text;
            serviceDB serv = a.GetServices().Where(w => w.code_service == Convert.ToInt16(row.Cells[1].Text)).FirstOrDefault();

            CheckBox cb = (CheckBox)row.FindControl("AccepterSouscription");
            if (cb != null && cb.Checked)
            {
                Txtetat.Text = "VALIDEE";
                if (serv.etat.Trim() == "V")
                {
                    Btnreponse.Visible = false;
                }
                cb.Enabled = false;
                notificationDB notif = a.GetNotification().Where(w => w.codeService == Convert.ToInt16(txtId.Text)).FirstOrDefault();
                if (notif != null)
                {
                    if (notif.etatNotif == "N")
                    {
                        UtilisateurDB user = a.GetUser(Convert.ToInt16(Session["code_utilisateur"].ToString()));
                        if (user.code_profil == 101 || user.code_profil == 202)
                        {
                            notif.etatNotif = "L";
                            a.maj_notification(notif);
                            row.ForeColor = System.Drawing.Color.Black;
                            // Response.Redirect(HttpContext.Current.Request.Url.ToString(), true);
                            Label x = (Label)Master.FindControl("lblNotifSouscription") as Label;

                            List<serviceDB> lsNotification = a.GetServices().Where(w => (w.libelleService != null) && (w.etatNotif.Trim() == "N") && (w.codeUtilisateur == Convert.ToInt16(Session["code_utilisateur"]))).ToList();

                            x.Text = lsNotification.Where(w => w.libelleService.Trim() == "Derogation" && w.idType == 3).Count().ToString();

                            Label nbNotification = (Label)Master.FindControl("nbNotification") as Label;
                            nbNotification.Text = lsNotification.Count().ToString();

                        }

                    }
                }
            }
            else
            {
                UtilisateurDB user = a.GetUser(Convert.ToInt16(Session["code_utilisateur"].ToString()));
                profilDB P = a.Getprofil(Convert.ToInt32(user.code_profil));

                // if (Session["code_profil"].Equals("505"))
                if (user.code_profil == 606)
                {
                    Btnreponse.Visible = true;

                }
                cb.Enabled = true;
            }


        }


        protected void AccepterSouscription_CheckedChanged1(object sender, EventArgs e)
        {
            foreach (GridViewRow row in gvSouscription.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    CheckBox cb = (row.Cells[0].FindControl("AccepterSouscription") as CheckBox);
                    if (cb.Checked)
                    {
                        if (row.Cells[1].Text == txtId.Text)
                        {
                            Txtetat.Text = "VALIDEE";
                        }
                    }
                }
            }
        }

        protected void gvRemise_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                try
                {
                    AstreeDonnees a = new AstreeDonnees();

                    GridViewRow row = e.Row;
                    serviceDB serv = a.GetServices().Where(w => (w.libelleService != null) && (w.libelleService.Trim() == "Derogation" && w.idType == 1) && (w.code_service == Convert.ToInt32(row.Cells[1].Text))).FirstOrDefault();


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

        protected void gvProrogation_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                try
                {
                    AstreeDonnees a = new AstreeDonnees();

                    GridViewRow row = e.Row;
                    serviceDB serv = a.GetServices().Where(w => (w.libelleService != null) && (w.libelleService.Trim() == "Derogation" && w.idType == 2) && (w.code_service == Convert.ToInt32(row.Cells[1].Text))).FirstOrDefault();


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

        protected void gvSouscription_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                try
                {
                    AstreeDonnees a = new AstreeDonnees();

                    GridViewRow row = e.Row;
                    serviceDB serv = a.GetServices().Where(w => (w.libelleService != null) && (w.libelleService.Trim() == "Derogation" && w.idType == 3) && (w.code_service == Convert.ToInt32(row.Cells[1].Text))).FirstOrDefault();


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
    }
}