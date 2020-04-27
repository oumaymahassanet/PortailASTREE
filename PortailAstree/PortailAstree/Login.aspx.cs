using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Security.Cryptography;
using System.Net.Mail;
using System.Net;
using System.Reflection;
using System.Text;

namespace Astree
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                Session["nbreTentative"] = null;
            }

        }


        protected void btnLogin_Click(object sender, EventArgs e)
        {
            DataAccesDataContext dbcontext = new DataAccesDataContext();
            AstreeDonnees a = new AstreeDonnees();
            UtilisateurDB user = new UtilisateurDB();
            adresseDB adr = new adresseDB();

            user = a.GetUser(txtUsername.Text, txtpassword.Text);
            UtilisateurDB user1 = a.GetUser().Where(w => w.login.Trim() == txtUsername.Text.Trim()).FirstOrDefault();
            int i = 0;
            if (Session["nbreTentative"] == null)
            {
                i = 0;
            }
            else
            {
                i = Convert.ToInt32(Session["nbreTentative"]);
            }
            Session["nbreTentative"] = i + 1;

            if (user == null)
            {
                msgerror.Visible = true;
                msgerror.Text = "login ou Mot de passe incorrect";
                PnlMdp.Visible = true;

                if (i > 3)
                {
                    if (user1 != null)
                    {
                        if (txtUsername.Text != "")
                        {
                            if (user1.login == txtUsername.Text)
                            {
                                user1.Etat = "N";
                                a.modifierEtat(user1);
                                msgerror.Text = "Votre compte est désactivé!";

                            }
                            else
                            {
                                msgerror.Text = "Vous n'avez pas un compte!";
                            }
                        }

                    }


                }
            }

            else
            {

                Session["code_profil"] = Convert.ToString(user.code_profil);// creation session 
                Session["code_utilisateur"] = user.code_utilisateur.ToString();
                if (user.code_profil == 101)
                {
                    Response.Redirect("Statistique.aspx");
                }
                else if (user.code_profil == 202)
                { Response.Redirect("DemanderDevis.aspx"); }
                else if (user.code_profil == 303)
                { Response.Redirect("RepondreCommandeFournisseur.aspx"); }
                else if (user.code_profil == 404)
                { Response.Redirect("RepondreCommandeIntermidiaire.aspx"); }
                else if (user.code_profil == 505)
                { Response.Redirect("AfficherDevis.aspx"); }
                else if (user.code_profil == 606)
                { Response.Redirect("AfficherDerogation.aspx"); }
                else if (user.code_profil == 808)
                { Response.Redirect("index.aspx"); }

            }


        }
        public string CalculateMD5Hash(string input)

        {

            // step 1, calculate MD5 hash from input

            MD5 md5 = System.Security.Cryptography.MD5.Create();

            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);

            byte[] hash = md5.ComputeHash(inputBytes);

            // step 2, convert byte array to hex string

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < hash.Length; i++)

            {

                sb.Append(hash[i].ToString());

            }

            return sb.ToString();

        }

        protected void btnSendMe_Click(object sender, EventArgs e)
        {

            try

            {
                AstreeDonnees a1 = new AstreeDonnees();
                DataAccesDataContext dbcontext = new DataAccesDataContext();

                adresseDB rech = a1.GetAdresse().Where(w => w.email.Trim() == txtEmail.Text.Trim()).FirstOrDefault();

                //foreach (var R in rech)
                //{
                    if (rech!=null)
                    {
                        AstreeDonnees a = new AstreeDonnees();
                        adresseDB adr = new adresseDB();
                        adr = a.GetAdresse().Where(w => w.email== txtEmail.Text).FirstOrDefault();
                        string mail = txtEmail.Text;
                        string[] lst = mail.Split('@');
                        string date = DateTime.Now.ToString();
                        string[] lstDate = date.Split(' ');
                        string hash = lst[0] + lstDate[1];
                        recuperationMDPDB rec = new recuperationMDPDB();
                        rec.code_adresse = adr.code_adresse;
                        rec.Hash = CalculateMD5Hash(hash);
                        rec.Etat = "E";
                        a.InsertHash(rec);
                        string url = "http://localhost:53110/RecuperationMotDePasse.aspx?x=" + CalculateMD5Hash(hash);
                        MailMessage o = new MailMessage("drissi.dalanda6@gmail.com", mail, "Récuperation Mot De Passe", "Pour la récupération de votre mot de passe il suffit de clicker sur ce lien : " + url);
                        NetworkCredential netCred = new NetworkCredential("drissi.dalanda6@gmail.com", "soutenancepfe");
                        SmtpClient smtpobj = new SmtpClient("smtp.gmail.com", 25);
                        smtpobj.EnableSsl = true;
                        smtpobj.Credentials = netCred;
                        smtpobj.Send(o);

                    }
                    else
                    {

                    }
                //}

            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }
        }
    }
}
