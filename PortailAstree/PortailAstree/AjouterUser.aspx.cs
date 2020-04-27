using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Security;
using System.Net.Mail;
using System.Net;


namespace Astree
{
    public partial class AjouterUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!this.IsPostBack)//activer page
            {
                MsgProfil.Text = "";
                MsgNom.Text = "";
                MsgLogin.Text = "";
                MsgPsw.Text = "";
                lblMessage.Visible = false;
                lblMessage1.Visible = false;
                this.BindGrid();
            }
        }
        private void BindGrid()
        {

            AstreeDonnees a = new AstreeDonnees();
            gv_User.DataSource = a.GetUser();
            gv_User.DataBind();
        }

        protected void btnajout(object sender, EventArgs e)
        {
            MsgProfil.Text = "";
            MsgNom.Text = "";
            MsgLogin.Text = "";
            MsgPsw.Text = "";
            lblMessage.Visible = false;
            lblMessage.Visible = false;
            Msgemail.Text = "";
            bool ajouter = false;

            if (String.IsNullOrEmpty(txtnom.Text))
            {

                //lblMessage1.Visible = true;
                //lblMessage1.Text = "veuillez remplir votre nom";
                MsgNom.Text = "veuillez remplir le nom";

            }

            else if (String.IsNullOrEmpty(txtlogin.Text))
            {


                //lblMessage1.Visible = true;
                //lblMessage1.Text = "veuillez remplir votre login";
                MsgLogin.Text = "veuillez remplir le  login!";
            }
            else if (String.IsNullOrEmpty(txtpassword.Text))
            {


                //lblMessage1.Visible = true;
                //lblMessage1.Text = "veuillez remplir votre Password";
                MsgPsw.Text = "veuillez remplir le Password!";
            }
            else if (Convert.ToInt16(ddlprofil1.SelectedValue) == 0)
            {
                MsgProfil.Text = "Vous devez selectionner le profil!";
            }
            else if (String.IsNullOrEmpty(txtemail.Text))
            {
                Msgemail.Text = "Vous devez saisir l'email";
            }
            else
            {
                lblMessage1.Visible = false;
                AstreeDonnees a = new AstreeDonnees();


                List<UtilisateurDB> lstUser = a.GetUser();

                if (lstUser.Where(w => w.login == txtlogin.Text).Count() > 0)
                {

                    MsgLogin.Text = "Login existant";


                }
                else
                {
                    // lblMessage1.Visible = false;
                    ajouter = true;
                }

            }



            if (ajouter == true)
            {
                AstreeDonnees ad = new AstreeDonnees();
                UtilisateurDB usr = new UtilisateurDB();
                adresseDB adr = new adresseDB();


                if (MsgNom.Text == "" && MsgLogin.Text == "" && MsgProfil.Text == "")
                {
                    try
                    {

                        usr.Etat = "A";
                        usr.code_profil = Convert.ToInt16(ddlprofil1.SelectedValue.ToString());
                        //  usr.code_partenaire = Convert.ToInt16(ddlpartenaire.SelectedValue.ToString());
                        usr.Nom_utilisateur = txtnom.Text;
                        usr.login = txtlogin.Text;
                        usr.Mdp = txtpassword.Text;


                        int nb = ad.GetAdresse().Where(w => w.email.Trim() == txtemail.Text.Trim()).Count();
                        int nb1 = ad.GetPartenair().Where(w => w.code_adresse == 0 && w.code_partenaire == usr.code_partenaire).Count();
                        if (nb == 0 && nb1 != 0)
                        {
                            adr.email = txtemail.Text;
                            ad.InsertAdresse(adr);
                            adresseDB adr1 = ad.GetAdresse().Where(w => w.email.Trim() == txtemail.Text.Trim()).LastOrDefault();

                            partenaireDB part = ad.GetPartenair().Where(w => w.code_partenaire == usr.code_partenaire).FirstOrDefault();

                            part.code_adresse = adr1.code_adresse;
                            ad.modifierPartenaire(part);


                        }
                        else if (nb1 == 0)
                        {
                            txtemail.Enabled = true;
                            Msgemail.Text = "le partenaire :" + ddlpartenaire.Text + " a déja un email";

                        }
                        else
                        {
                            txtemail.Enabled = true;
                            Msgemail.Text = "l'email déja existe";
                        }

                        ad.InsertUser(usr);
                        partenaireDB part1 = ad.GetPartenair().Where(w => w.code_partenaire == Convert.ToInt16(ddlprofil1.SelectedValue.ToString())).FirstOrDefault();
                        adresseDB adr2 = ad.GetAdresse().Where(w => w.code_adresse == part1.code_adresse).FirstOrDefault();
                        string chaine = "le  Login est =" + txtlogin.Text + " et le mot de passe est = " + txtpassword.Text + "pour l'utilisateur =" + txtnom.Text;
                        lblMessage1.Visible = true;
                        lblMessage1.Text = "L'utilisateur à été ajouter avec succés";
                        txtemail.Text = "";
                        txtlogin.Text = "";
                        txtnom.Text = "";
                        txtpassword.Text = "";
                        try
                        {
                            MailMessage o = new MailMessage("oumaima.hassanet1@gmail.com", adr2.email, "Login et Mot de passe", chaine);
                            NetworkCredential netCred = new NetworkCredential("oumaima.hassanet1@gmail.com",""  );
                            SmtpClient smtpobj = new SmtpClient("smtp.gmail.com", 25);
                            smtpobj.EnableSsl = true;
                            smtpobj.Credentials = netCred;
                            smtpobj.Send(o);
                        }
                        catch
                        {
                            lblMessage.Visible = true;
                            lblMessage.Text = "l'envoi de l'email n'a étét transmis ! verifiez l'adresse email!!";
                        }

                    }
                    catch (Exception ex)
                    {
                        lblMessage.Visible = true;
                        lblMessage.Text = "L'ajout n'a pas été éffectuer !";
                    }

                }


            }
            DataBind();
            this.BindGrid();
        }


        protected void gv_User_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                lblMessage.Text = gv_User.Rows[gv_User.SelectedIndex].Cells[1].Text;
                AstreeDonnees ad = new AstreeDonnees();
                string ret = ad.maj_user(gv_User.Rows[gv_User.SelectedIndex].Cells[1].Text);
                Label x = (Label)Master.FindControl("lblNotifCompteDesactive") as Label;
                Label y = (Label)Master.FindControl("nbNotification") as Label;
                
                List<UtilisateurDB> lsNotification = ad.GetUser().Where(w => w.Etat.Trim() == "N").ToList();

                x.Text = lsNotification.Count().ToString();
                y.Text= lsNotification.Count().ToString();
                if (ret == "Active")
                {
                    lblMessage.Text = "Traitement fait avec succès!!";
                    this.BindGrid();
                    //gv_User.SelectedIndex = -1;
                    UtilisateurDB S = ad.GetUser().Where(w => w.login == gv_User.Rows[gv_User.SelectedIndex].Cells[1].Text).FirstOrDefault();
                    partenaireDB part2 = ad.GetPartenair().Where(w => w.code_partenaire == S.code_partenaire).FirstOrDefault();
                    adresseDB adr = ad.GetAdresse().Where(w => w.code_adresse == part2.code_adresse).FirstOrDefault();
                    string chaine = "Le compte de votre utilisateur =" + S.Nom_utilisateur + "  est activé";
                    MailMessage o = new MailMessage("oumaima.hassanet1@gmail.com", adr.email, "Activation du compte", chaine);
                    NetworkCredential netCred = new NetworkCredential("oumaima.hassanet1@gmail.com", "HA_ouma147896321");
                    SmtpClient smtpobj = new SmtpClient("smtp.gmail.com", 25);
                    smtpobj.EnableSsl = true;
                    smtpobj.Credentials = netCred;
                    smtpobj.Send(o);

                }
                else if (ret == "Desactive")
                {
                    lblMessage.Text = "Traitement fait avec succès!!";
                    this.BindGrid();
                    // gv_User.SelectedIndex = -1;
                    UtilisateurDB S = ad.GetUser().Where(w => w.login == gv_User.Rows[gv_User.SelectedIndex].Cells[1].Text).FirstOrDefault();
                    partenaireDB part2 = ad.GetPartenair().Where(w => w.code_partenaire == S.code_partenaire).FirstOrDefault();
                    adresseDB adr = ad.GetAdresse().Where(w => w.code_adresse == part2.code_adresse).FirstOrDefault();
                    string chaine = "Le compte de votre utilisateur =" + S.Nom_utilisateur + "  est désaactivé";
                    MailMessage o = new MailMessage("oumaima.hassanet1@gmail.com", adr.email, "Désactivation du compte", chaine);
                    NetworkCredential netCred = new NetworkCredential("oumaima.hassanet1@gmail.com", "HA_ouma147896321");
                    SmtpClient smtpobj = new SmtpClient("smtp.gmail.com", 25);
                    smtpobj.EnableSsl = true;
                    smtpobj.Credentials = netCred;
                    smtpobj.Send(o);

                }
                else
                { lblMessage.Text = ret; }




            }
            catch (Exception ex)
            {
                //Response.Redirect("PageErreur.aspx"); 
            }




        }


        protected void btnGenererPass_Click(object sender, EventArgs e)
        {
            string password = Membership.GeneratePassword(12, 1);
            txtpassword.Text = password;
        }
        protected void Ajouter_Click(object sender, ImageClickEventArgs e)
        {
            PnlAffichage.Visible = true;
            Ajouter.Visible = false;
            ImageButton1.Visible = true;
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {

            PnlAffichage.Visible = false;
            Ajouter.Visible = true;
            ImageButton1.Visible = false;
        }



        protected void ddlprofil1_SelectedIndexChanged(object sender, EventArgs e)
        {
            AstreeDonnees a = new AstreeDonnees();
            List<partenaireDB> lstPart = new List<partenaireDB>();
            lstPart = a.GetPartenair();
            lstPart = a.GetPartenair().Where(w => w.description_profil.Trim() == ddlprofil1.SelectedItem.Text.Trim()).ToList();
            ddlpartenaire.DataSource = lstPart;
            ddlpartenaire.DataBind();
            if (lstPart.Count() == 1)
            {

                adresseDB adr = new adresseDB();

                adr = a.GetAdresse(lstPart.FirstOrDefault()).FirstOrDefault();
                if (adr != null)
                {
                    txtemail.Text = adr.email;
                }

            }

        }

        protected void ddlpartenaire_SelectedIndexChanged(object sender, EventArgs e)
        {

            AstreeDonnees a = new AstreeDonnees();
            adresseDB adr = new adresseDB();
            List<partenaireDB> lstPart = a.GetPartenair().Where(w => w.code_partenaire == Convert.ToInt16(ddlpartenaire.SelectedValue)).ToList();

            adr = a.GetAdresse(lstPart.FirstOrDefault()).FirstOrDefault();
            if (adr != null)
            {
                txtemail.Text = adr.email;
            }
        }
    }
}
