using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Astree;

public partial class RecuperationMotDePasse : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            string x = Request.Url.AbsoluteUri;
            string[] ls = x.Split('?');
            if (ls.Length == 2)
            {
                AstreeDonnees a = new AstreeDonnees();
                string rec;
                rec = a.GetHash(ls[1].Substring(2));
                if (rec == "OK")
                {
                    signup_box.Visible = true;

                }
                else
                {
                    Response.Redirect("PageErreur.aspx");
                }
            }
            else
            {
                Response.Redirect("PageErreur.aspx");

            }


        }
        catch (Exception ex)
        {
            Response.Redirect("PageErreur.aspx");
        }

    }

    protected void btnRegister_Click(object sender, EventArgs e)
    {

        DataAccesDataContext dbcontext = new DataAccesDataContext();
        var rech = from i in dbcontext.Utilisateur
                   select i.login;
        foreach (var R in rech)
        {
            if (R.Equals(txtlogin.Text))
            {
                AstreeDonnees a = new AstreeDonnees();
                UtilisateurDB util = a.GetUser().Where(w => w.login == txtlogin.Text).FirstOrDefault();
                if (txtRepeatpassword.Text == txtpassword2.Text)
                {
                    util.Mdp = txtRepeatpassword.Text;
                    a.ModifierMDP(util);
                    Response.Redirect("Login.aspx");
                }
                else
                {
                    msgerror.Visible = true;
                    msgerror.Text = "les deux mot de passe ne sont pas identiques";
                }

            }

        }
    }
}