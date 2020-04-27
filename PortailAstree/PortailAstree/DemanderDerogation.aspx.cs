using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
namespace Astree
{
    public partial class DemanderDerogation : System.Web.UI.Page
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

                if (ddltype.SelectedIndex == 0)
                {
                    PnlNumContrat.Visible = true;
                    pnlTaux.Visible = true;
                    pnlDuree.Visible = false;
                }
                gv_Derogation.Visible = true;
                gvSouscription.Visible = false;
                gvProrogation.Visible = false;

            }
        }
        private void BindGrid()
        {

            AstreeDonnees a = new AstreeDonnees();
            UtilisateurDB user = a.GetUser(Convert.ToInt16(Session["code_utilisateur"].ToString()));

            List<serviceDB> ls = a.GetServices().Where(w => (w.libelleService != null) && (w.libelleService.Trim() == "Derogation") && (w.libelleType.Trim() == "Remise") && (w.codeUtilisateur == user.code_utilisateur)).OrderBy(w => w.etat).ThenByDescending(w => w.code_service).ToList();
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
            Session["lstremise"] = ls;
            gv_Derogation.DataSource = ls;
            gv_Derogation.DataBind();

            List<serviceDB> lss = a.GetServices().Where(w => (w.libelleService != null) && (w.libelleService.Trim() == "Derogation") && (w.libelleType.Trim() == "Prorogation") && (w.codeUtilisateur == user.code_utilisateur)).OrderBy(w => w.etat).ThenByDescending(w => w.code_service).ToList();
            foreach (serviceDB x in lss)
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
            Session["lstproro"] = lss;
            gvProrogation.DataSource = lss;
            gvProrogation.DataBind();

            List<serviceDB> lsss = a.GetServices().Where(w => (w.libelleService != null) && (w.libelleService.Trim() == "Derogation") && (w.libelleType.Trim() == "Souscription") && (w.codeUtilisateur == user.code_utilisateur)).OrderBy(w => w.etat).ThenByDescending(w => w.code_service).ToList();
            foreach (serviceDB x in lsss)
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
            Session["lstsouscrip"] = lsss;
            gvSouscription.DataSource = lsss;
            gvSouscription.DataBind();


        }

        //protected void BtnAjoutDerogation_Click(object sender, EventArgs e)
        //{
        //    lblMessage1.Text = "";
        //    if (String.IsNullOrEmpty(ddltype.Text))
        //    {
        //        lblMessage1.Visible = true;
        //        lblMessage1.Text = "veuillez choisir le type ";
        //    }
        //    else if (String.IsNullOrEmpty(ddlproduit.Text))
        //    {


        //        lblMessage1.Visible = true;
        //        lblMessage1.Text = "veuillez choisir  le produit";
        //    }
        //    else if (String.IsNullOrEmpty(ddlsousproduit.Text))
        //    {


        //        lblMessage1.Visible = true;
        //        lblMessage1.Text = "veuillez spécifier le produit";
        //    }
        //    else if (String.IsNullOrEmpty(txtnumcontrat.Text))
        //    {
        //        lblMessage1.Visible = true;
        //        lblMessage1.Text = "veuillez remplir votre numéro du contrat";
        //    }
        //    else if (ddltype.SelectedIndex == 0)
        //    {
        //        if ((String.IsNullOrEmpty(txttaux.Text)) || (Convert.ToInt16(txttaux.Text) > 15))//n7eb tst taux mayfoutech 15%
        //        {
        //            lblMessage1.Visible = true;
        //            lblMessage1.Text = "veuillez remplir le taux";
        //            txtduree.Text = "0";

        //        }
        //    }
        //    else if (ddltype.SelectedIndex == 1)
        //    {
        //        if (String.IsNullOrEmpty(txtduree.Text))
        //        {


        //            lblMessage1.Visible = true;
        //            lblMessage1.Text = "veuillez remplir la durée";
        //            txttaux.Text = "0";
        //        }
        //    }






        //    if (lblMessage1.Text == "")
        //    {
        //        lblMessage1.Visible = false;




        //        AstreeDonnees ad = new AstreeDonnees();
        //        serviceDB drg = new serviceDB();

        //        drg.numContrat = Convert.ToInt16(txtnumcontrat.Text);
        //        if (txttaux.Text == "")
        //        {
        //            drg.taux = 0;
        //        }
        //        else
        //        {
        //            drg.taux = Convert.ToInt16(txttaux.Text);
        //        }

        //        drg.idSousBranche = Convert.ToInt16(ddlsousproduit.SelectedValue.ToString());
        //        drg.idType = Convert.ToInt16(ddltype.SelectedValue.ToString());
        //        drg.etat = "A";
        //        drg.dateDemande = DateTime.Now;

        //        if (txtduree.Text == "")
        //        {
        //            drg.duree = 0;
        //        }
        //        else
        //        {
        //            drg.duree = Convert.ToInt16(txtduree.Text);
        //        }
        //        drg.libelleService = "Derogation";
        //        drg.codeUtilisateur = Convert.ToInt16(Session["code_utilisateur"].ToString());
        //        ad.Insertservice(drg);
        //        lblMsgSucces.Visible = true;
        //        lblMsgSucces.Text = "Dérogation envoyée avec succés";
        //        BindGrid();

        //        //////Notification
        //        //notificationDB notif = new notificationDB();
        //        //notif.codeService = drg.code_service;
        //        //notif.contenuNotification = drg.reponse;
        //        //notif.etat = "N";// NON LU
        //        //notif.dateNotification = drg.dateReponse;
        //        //ad.InsertNotification(notif);


        //    }

        //}
        protected void BtnAjoutDerogation_Click(object sender, EventArgs e)
        {
            lblMsg.Text = "";
            MsgddlType.Text = "";
            MsgddlP.Text = "";
            MsgddlSP.Text = "";
            MsgDuree.Text = "";
            MsgTaux.Text = "";
            MsgContrat.Text = "";
            string typeDerogation = "Remise";
            if (ddltype.SelectedIndex == 1)
            {
                typeDerogation = "Prorogation";
            }
            if (ddltype.SelectedIndex == 2)
            {
                typeDerogation = "Souscription";
            }
            AstreeDonnees a = new AstreeDonnees();
            UtilisateurDB user = a.GetUser(Convert.ToInt16(Session["code_utilisateur"].ToString()));

            List<serviceDB> ls = a.GetServices().Where(w => (w.libelleService != null) && (w.libelleService.Trim() == "Derogation") && (w.libelleType.Trim() == typeDerogation) && (w.codeUtilisateur == user.code_utilisateur)).ToList();
            if (String.IsNullOrEmpty(ddltype.Text))
            {
                MsgddlType.Visible = true;
                MsgddlType.Text = "veuillez choisir le type ";
            }
            else if (String.IsNullOrEmpty(ddlproduit.Text) || ddlproduit.SelectedIndex == 0 )
            {


                MsgddlP.Visible = true;
                MsgddlP.Text = "veuillez choisir  le produit";
            }
            else if (String.IsNullOrEmpty(ddlsousproduit.Text))
            {


                MsgddlSP.Visible = true;
                MsgddlSP.Text = "veuillez spécifier le produit";
            }
            else if (String.IsNullOrEmpty(txtnumcontrat.Text))
            {
                if (ddltype.SelectedIndex != 2)
                {
                    MsgContrat.Visible = true;
                    MsgContrat.Text = "veuillez remplir votre numéro du contrat";
                }

            }
            else if (ddltype.SelectedIndex == 0)
            {

                if ((String.IsNullOrEmpty(txttaux.Text)) || (Convert.ToInt16(txttaux.Text) > 15))//n7eb tst taux mayfoutech 15%
                {
                    MsgTaux.Visible = true;
                    MsgTaux.Text = "veuillez remplir le taux";
                    txtduree.Text = "0";

                }
                //else if ((Convert.ToInt16(txttaux.Text).GetType()!= typeof(int))) {
                //    MsgTaux.Text = "le taux doit étre un entier";
                //}
            }
            else if (ddltype.SelectedIndex == 1)
            {
                if (String.IsNullOrEmpty(txtduree.Text))
                {


                    MsgDuree.Visible = true;
                    MsgDuree.Text = "veuillez remplir la durée";
                    txttaux.Text = "0";
                }
            }

            if (MsgddlType.Text == "" && MsgddlP.Text == "" && MsgddlSP.Text == "" && MsgDuree.Text == "" && MsgTaux.Text == "" && MsgContrat.Text == "" && lblMsg.Text == "")
            {
                MsgddlType.Visible = false;
                MsgddlP.Visible = false;
                MsgddlSP.Visible = false;
                MsgDuree.Visible = false;
                MsgTaux.Visible = false;
                MsgContrat.Visible = false;




                AstreeDonnees ad = new AstreeDonnees();
                serviceDB drg = new serviceDB();
                try
                {
                    if (ddltype.SelectedIndex != 2)
                    {
                        drg.numContrat = Convert.ToInt16(txtnumcontrat.Text);
                    }
                    else
                    {
                        drg.numContrat = 0;
                    }


                }
                catch (Exception ex)
                {
                    MsgContrat.Visible = true;
                    MsgContrat.Text = "le N° contrat doit etre un entier";
                }

                if (txttaux.Text == "")
                {
                    drg.taux = 0;
                }
                else
                {
                    try
                    {
                        drg.taux = Convert.ToInt16(txttaux.Text);
                    }
                    catch
                    {
                        MsgTaux.Visible = true;
                        MsgTaux.Text = "Le taux doit étre un entier";
                    }
                }

                drg.idSousBranche = Convert.ToInt16(ddlsousproduit.SelectedValue.ToString());
                drg.idType = Convert.ToInt16(ddltype.SelectedValue.ToString());
                drg.etat = "A";
                drg.dateDemande = DateTime.Now;

                if (txtduree.Text == "")
                {
                    drg.duree = 0;
                }
                else
                {
                    try { drg.duree = Convert.ToInt16(txtduree.Text); }
                    catch
                    {
                        MsgDuree.Visible = true;
                        MsgDuree.Text = "la durée doit étre un entier";
                    }

                }
                drg.libelleService = "Derogation";
                drg.codeUtilisateur = Convert.ToInt16(Session["code_utilisateur"].ToString());
                int nb = 0;
                if (ddltype.SelectedIndex != 2)
                {
                    nb = ad.GetServices().Where(w => w.numContrat == drg.numContrat).Count();
                }
                else
                {
                    nb = 0;
                }
                //if (nb > 0)
                //{
                //    lblMsgSucces.Text = "Vous avez déja envoyer une demande pour ce N° de contrat!";
                //}
                //else
                //{
                if (MsgDuree.Text != "" || MsgTaux.Text != "" || MsgContrat.Text != "" || MsgddlP.Text != "" || MsgddlSP.Text != "")
                {
                    lblMsgSucces.Visible = true;
                    lblMsgSucces.Text = "Impossible d'envoyer la demande! Vérifiez les champs";
                }
                else
                {
                    serviceDB ser = new serviceDB();
                    if (ddltype.SelectedIndex != 2)
                    {
                        ser = ls.Where(w => w.numContrat == drg.numContrat).FirstOrDefault();
                        if (ser == null)
                        {
                            ad.Insertservice(drg);
                            lblMsgSucces.Visible = true;
                            lblMsgSucces.Text = "Dérogation envoyée avec succés";
                            BindGrid();
                        }
                        else
                        {
                            lblMsgSucces.Visible = true;
                            lblMsgSucces.Text = "Demande déjà envoyée pour ce contrat";
                            BindGrid();
                        }
                    }
                    else if(ddltype.SelectedIndex ==2)
                    {
                        int nb1 = ad.GetServices().Where(w => w.idBranche == ser.idBranche && w.idSousBranche==ser.idSousBranche && w.idType==3).Count();
                        if (nb1 > 1)
                        {
                            lblMsg.Visible = true;
                            lblMsg.Text = "Vous avez déja envoyé une souscription pour ce produit ";
                        }

                        else
                        {
                            ad.Insertservice(drg);
                            lblMsgSucces.Visible = true;
                            lblMsgSucces.Text = "Dérogation envoyée avec succés";
                            BindGrid();
                        }


                    }




                }
                //}



            }

        }

        protected void ddltype_SelectedIndexChanged(object sender, EventArgs e)
        {



            //remise
            if (ddltype.SelectedIndex == 0)
            {
                PnlNumContrat.Visible = true;
                pnlDuree.Visible = false;
                pnlTaux.Visible = true;
                txtduree.Text = "0";
                gv_Derogation.Visible = true;
                gvSouscription.Visible = false;
                gvProrogation.Visible = false;
            }
            //prorogation
            if (ddltype.SelectedIndex == 1)
            {
                PnlNumContrat.Visible = true;
                pnlDuree.Visible = true;
                pnlTaux.Visible = false;
                txttaux.Text = "0";
                gv_Derogation.Visible = false;
                gvSouscription.Visible = false;
                gvProrogation.Visible = true;
            }
            //souscription
            if (ddltype.SelectedIndex == 2)
            {
                PnlNumContrat.Visible = false;
                pnlDuree.Visible = false;
                pnlTaux.Visible = false;
                txtduree.Text = "0";
                txttaux.Text = "0";
                gv_Derogation.Visible = false;
                gvSouscription.Visible = true;
                gvProrogation.Visible = false;
            }
        }

        protected void gv_Derogation_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gv_Derogation.PageIndex = e.NewPageIndex;
            gv_Derogation.DataSource = Session["lstremise"];
            gv_Derogation.DataBind();
            gv_Derogation.SelectedIndex = -1;
        }

        protected void gvProrogation_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvProrogation.PageIndex = e.NewPageIndex;
            gvProrogation.DataSource = Session["lstproro"];
            gvProrogation.DataBind();
            gvProrogation.SelectedIndex = -1;
        }

        protected void gvSouscription_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvSouscription.PageIndex = e.NewPageIndex;
            gvSouscription.DataSource = Session["lstSouscrip"];
            gvSouscription.DataBind();
            gvSouscription.SelectedIndex = -1;
        }
        protected void ddlproduit_SelectedIndexChanged(object sender, EventArgs e)
        {
            MsgddlP.Visible = false;
        }
    }
}