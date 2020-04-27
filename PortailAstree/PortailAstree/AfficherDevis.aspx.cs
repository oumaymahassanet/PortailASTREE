using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Astree
{
    public partial class AfficherDevis : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["code_utilisateur"] == null)
            {
                Response.Redirect("login.aspx");
            }
            if (!this.IsPostBack)
            {
                this.BindGrid();
                AstreeDonnees a = new AstreeDonnees();
                UtilisateurDB user = a.GetUser(Convert.ToInt16(Session["code_utilisateur"].ToString()));
                profilDB P = a.Getprofil(Convert.ToInt32(user.code_profil));

                // if (Session["code_profil"].Equals("505"))
                if (user.code_profil == 505)
                {
                    Btnreponse.Visible = true;

                }
            }
        }
        private void BindGrid()
        {

            AstreeDonnees a = new AstreeDonnees();


            UtilisateurDB user = a.GetUser(Convert.ToInt16(Session["code_utilisateur"].ToString()));
            List<serviceDB> ls = new List<serviceDB>();
            //Gestionnaire
            if (user.code_profil != 101 && user.code_profil != 202)
            {
                ls = a.GetServices().Where(w => (w.libelleService != null) && (w.libelleService.Trim() == "Devis")).OrderBy(w => w.etat).ToList();
            }
            //Agent et courtier
            else
            {
                ls = a.GetServices().Where(w => (w.libelleService != null) && (w.libelleService.Trim() == "Devis") && (w.codeUtilisateur == user.code_utilisateur)).OrderByDescending(w => w.etatNotif).ToList();
            }

            List<serviceDB> lsServ = new List<serviceDB>();
            List<notificationDB> lstNotif = a.GetNotification();
            Session["lstDevis"] = ls;
            gv_Devis.DataSource = ls;
            gv_Devis.DataBind();


            foreach (GridViewRow row in gv_Devis.Rows)
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



        }





        protected void gv_Devis_SelectedIndexChanged1(object sender, EventArgs e)
        {
            AstreeDonnees a = new AstreeDonnees();
            Txtetat.Text = "";
            GridViewRow row = gv_Devis.SelectedRow;
            txtID.Text = row.Cells[1].Text;
            txtproduit.Text = row.Cells[2].Text;
            txtsousproduit.Text = row.Cells[3].Text;
        //    txtdatedemande.Text = row.Cells[4].Text;


            if (row.Cells[5].Text == "&nbsp;")
            {
                TxtPHT.Text = "0";
            }
            else
            {
                TxtPHT.Text = row.Cells[5].Text;
            }
            if (row.Cells[6].Text == "&nbsp;")
            {
                txtTaxe.Text = "0";
            }
            else
            {
                txtTaxe.Text = row.Cells[6].Text;
            }
            if (row.Cells[7].Text == "&nbsp;")
            {
                txtCP.Text = "0";
            }
            else
            {
                txtCP.Text = row.Cells[7].Text;
            }
            if (row.Cells[8].Text == "&nbsp;")
            {
                txtPT.Text = "0";
            }
            else
            {
                txtPT.Text = row.Cells[8].Text;
            }
            MessageLabel.Text = "You selected Devis numéro " + row.Cells[1].Text + ".";
            serviceDB ser = a.GetServices().Where(w => w.code_service == Convert.ToInt16(row.Cells[1].Text)).FirstOrDefault();
            CheckBox cb = (CheckBox)row.FindControl("Accepter");

            if (cb != null && cb.Checked)
            {
                Txtetat.Text = "VALIDEE";
                if (ser.etat.Trim() == "V")
                {
                    Btnreponse.Visible = false;
                }

                cb.Enabled = false;
                notificationDB notif = a.GetNotification().Where(w => w.codeService == Convert.ToInt16(txtID.Text)).FirstOrDefault();
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


                            Label x = (Label)Master.FindControl("lblDevis") as Label;

                            List<serviceDB> lsNotification = a.GetServices().Where(w => (w.libelleService != null) && (w.etatNotif.Trim() == "N") && (w.codeUtilisateur == Convert.ToInt16(Session["code_utilisateur"]))).ToList();

                            x.Text = lsNotification.Where(w => w.libelleService.Trim() == "Devis").Count().ToString();

                            Label nbNotification = (Label)Master.FindControl("nbNotification") as Label;
                            nbNotification.Text = lsNotification.Count().ToString();


                        }

                    }

                }



            }
            else
            {


                UtilisateurDB user = a.GetUser(Convert.ToInt16(Session["code_utilisateur"].ToString()));

                // if (Session["code_profil"].Equals("505"))
                if (user.code_profil == 505)
                {
                    Btnreponse.Visible = true;

                }
                cb.Enabled = true;

                //gestionnaire
                if (user.code_profil != 101 && user.code_profil != 202)
                {


                    serviceDB serv = a.GetServices().Where(w => (w.libelleService != null) && (w.libelleService.Trim() == "Devis") && (w.code_service == Convert.ToInt16(txtID.Text))).FirstOrDefault();


                    if (serv != null)
                    {
                        if (serv.etat.Trim() == "A")
                        {
                            //e.Row.BackColor = System.Drawing.Color.Red;
                            //row.ForeColor = System.Drawing.Color.Black;
                            // serv.etat = "L";
                            //  a.maj_devis(serv);
                            BindGrid();
                            // Response.Redirect(HttpContext.Current.Request.Url.ToString(), true);

                        }

                    }



                }






            }

        }
        protected void gv_Devis_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            GridViewRow row = gv_Devis.Rows[e.NewSelectedIndex];
        }





        protected void Accepter_CheckedChanged(object sender, EventArgs e)
        {

            foreach (GridViewRow row in gv_Devis.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    CheckBox cb = (row.Cells[0].FindControl("Accepter") as CheckBox);
                    if (cb.Checked)
                    {

                        if (row.Cells[1].Text == txtID.Text)
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
            MsgTaxe.Text = "";
            MsgPH.Text = "";
            MsgCP.Text = "";
           
            lblSuccee.Text = "";
            lblerreur.Text = "";
            MsgEtat.Text = "";
            if (txtproduit.Text != "")
            {
                List<serviceDB> lstService = a.GetServices();
                serviceDB ser = new serviceDB();
                ser = lstService.Where(w => w.code_service == Convert.ToInt16(txtID.Text)).FirstOrDefault();

                if (ser != null)
                {
                    if (  Txtetat.Text != "VALIDEE")
                    {
                        MsgProduit.Visible = false;
                        MsgEtat.Visible = true;
                        MsgEtat.Text = "Vous devez valider le devis selectionné!";
                    }
                    else
                    {
                       

                        if (String.IsNullOrEmpty(TxtPHT.Text) || Convert.ToDecimal(TxtPHT.Text)==0)
                        {
                            MsgPT.Visible = false;
                            MsgTaxe.Visible = false;
                            MsgCP.Visible = false;
                            MsgPH.Visible = true;
                            MsgPH.Text = "veuillez remplir le prime HT ";
                        }
                       
                       


                        else if (String.IsNullOrEmpty(txtTaxe.Text) || Convert.ToDecimal(txtTaxe.Text) == 0)
                        {

                           
                            MsgCP.Visible = false;
                            MsgPH.Visible = false;
                            MsgPT.Visible = false;
                            MsgTaxe.Visible = true;
                            MsgTaxe.Text = "veuillez remplir le taxe ";
                        }
                        else if (String.IsNullOrEmpty(txtCP.Text) || Convert.ToDecimal(txtCP.Text) == 0)
                        {

                         
                            MsgPH.Visible = false;
                            MsgPT.Visible = false;
                            MsgTaxe.Visible = false;
                            MsgCP.Visible = true;
                            MsgCP.Text = "veuillez remplir le coût police";
                        }

                        else  if (MsgPH.Text != ""  && MsgCP.Text != "" && MsgTaxe.Text != "" ) {
                            lblerreur.Text = "Vous devez remplir tout les champs!";
                        }
                        else
                        {
                            try {
                                ser.etat = "V";
                                ser.dateReponse = DateTime.Now;
                                ser.primeHtax = Convert.ToDecimal(TxtPHT.Text);
                                ser.primeTotal = Convert.ToDecimal(txtPT.Text);
                                ser.coutPolice = Convert.ToDecimal(txtCP.Text);
                                ser.taxe = Convert.ToDecimal(txtTaxe.Text);
                                a.maj_devis(ser);
                                BindGrid();
                                lblSuccee.Visible = true;
                                lblerreur.Visible = false;
                                lblSuccee.Text = "La réponse envoyée avec succés! ";

                            }
                            catch
                            {
                                lblerreur.Visible = true;
                                lblSuccee.Visible = false;
                                lblerreur.Text = " Les champs doivent être des entiers!";
                            }
                          


                            
                        }
                    }
                    Label x = (Label)Master.FindControl("lblDevis") as Label;
                    Label y = (Label)Master.FindControl("nbNotification") as Label;

                    List<serviceDB> lsNotification = a.GetServices().Where(w => (w.libelleService != null) && (w.etat.Trim() == "A")).ToList();
                    x.Text = lsNotification.Where(w => w.libelleService.Trim() == "Devis").Count().ToString();



                    y.Text = (Convert.ToInt16(y.Text.ToString()) - 1).ToString();


                    if (ser.etatNotif == "")
                    {
                        notificationDB notif = new notificationDB();
                        notif.codeService = ser.code_service;
                        notif.contenuNotification = ser.reponse;
                        notif.etatNotif = "N";// NON LU
                        notif.dateNotification = ser.dateReponse;
                        a.InsertNotification(notif);

                        //lsNotification = a.GetServices().Where(w => (w.libelleService != null) && (w.etat.Trim() == "A")).ToList();
                        //x.Text = lsNotification.Where(w => w.libelleService.Trim() == "Devis" ).Count().ToString();



                        //y.Text = (Convert.ToInt16(y.Text.ToString()) - 1).ToString();





                        BindGrid();
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



        protected void txtCP_TextChanged(object sender, EventArgs e)
        {
            decimal primeTotal = 0;
            decimal primeHT = 0;
            decimal taxe = 0;
            decimal coutPolice = 0;
            primeHT = Convert.ToDecimal(TxtPHT.Text.ToString());
            taxe = Convert.ToDecimal(txtTaxe.Text.ToString());
            coutPolice = Convert.ToDecimal(txtCP.Text.ToString());
            primeTotal = primeHT + taxe + coutPolice;
            txtPT.Text = primeTotal.ToString();
        }

        protected void txtTaxe_TextChanged(object sender, EventArgs e)
        {
            decimal primeTotal = 0;
            decimal primeHT = 0;
            decimal taxe = 0;
            decimal coutPolice = 0;
            primeHT = Convert.ToDecimal(TxtPHT.Text);
            taxe = Convert.ToDecimal(txtTaxe.Text);
            coutPolice = Convert.ToDecimal(txtCP.Text);
            primeTotal = primeHT + taxe + coutPolice;
            txtPT.Text = primeTotal.ToString();
        }

        protected void TxtPHT_TextChanged(object sender, EventArgs e)
        {
            decimal primeTotal = 0;
            decimal primeHT = 0;
            decimal taxe = 0;
            decimal coutPolice = 0;
            primeHT = Convert.ToDecimal(TxtPHT.Text);
            taxe = Convert.ToDecimal(txtTaxe.Text);
            coutPolice = Convert.ToDecimal(txtCP.Text);
            primeTotal = primeHT + taxe + coutPolice;
            txtPT.Text = primeTotal.ToString();
        }



        protected void gv_Devis_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

            gv_Devis.PageIndex = e.NewPageIndex;
            gv_Devis.DataSource = Session["lstDevis"];
            gv_Devis.DataBind();
            gv_Devis.SelectedIndex = -1;


            AstreeDonnees a = new AstreeDonnees();
            List<serviceDB> ls = a.GetServices().Where(w => (w.libelleService != null) && (w.libelleService.Trim() == "Devis")).ToList();

            foreach (GridViewRow row in gv_Devis.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    CheckBox cb = (row.Cells[0].FindControl("Accepter") as CheckBox);

                    serviceDB serv = ls.Where(w => w.code_service == Convert.ToInt16(row.Cells[1].Text.ToString().Trim())).FirstOrDefault();
                    if (serv != null)
                    {

                        if (serv.etat.ToString().Trim() == "V")
                        {
                            cb.Checked = true;

                        }

                    }

                }
            }
        }

        protected void gv_Devis_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            AstreeDonnees a = new AstreeDonnees();
            UtilisateurDB user = a.GetUser(Convert.ToInt16(Session["code_utilisateur"].ToString()));


            if (user.code_profil == 101 || user.code_profil == 102)
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    try
                    {
                        //AstreeDonnees a = new AstreeDonnees();

                        GridViewRow row = e.Row;
                        serviceDB serv = a.GetServices().Where(w => (w.libelleService != null) && (w.libelleService.Trim() == "Devis") && (w.code_service == Convert.ToInt32(row.Cells[1].Text))).FirstOrDefault();


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
            else
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    try
                    {
                        //AstreeDonnees a = new AstreeDonnees();

                        GridViewRow row = e.Row;
                        serviceDB serv = a.GetServices().Where(w => (w.libelleService != null) && (w.libelleService.Trim() == "Devis") && (w.code_service == Convert.ToInt32(row.Cells[1].Text))).FirstOrDefault();


                        if (serv != null)
                        {
                            if (serv.etat.Trim() == "A")
                            {
                                //e.Row.BackColor = System.Drawing.Color.Red;
                                e.Row.ForeColor = System.Drawing.Color.Red;
                            }
                            else
                            {
                                e.Row.ForeColor = System.Drawing.Color.Black;
                            }

                        }

                    }
                    catch (Exception ex)
                    { }
                }

            }

        }
    }
}
