using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Astree;

public partial class index : System.Web.UI.Page
{
    public Literal GetLiteral(string text)
    {
        Literal rv = default(Literal);
        rv = new Literal();
        rv.Text = text;
        return rv;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (Session["code_utilisateur"] == null)
        //{
        //    Response.Redirect("login.aspx");
        //}

        AstreeDonnees a = new AstreeDonnees();
        int NBUtil = a.GetUser().Count();
        NBTotal.Text = NBUtil.ToString();
        int NB = a.GetUser().Where(w => w.description_profil.Trim() == "Agent").Count();
        NbAgent.Text = NB.ToString();
        int NBC = a.GetUser().Where(w => w.description_profil.Trim() == "Courtier").Count();
        NbCourtier.Text = NBC.ToString();
        int NBF = a.GetUser().Where(w => w.description_profil.Trim() == "Fournisseur").Count();
        NbFour.Text = NBF.ToString();
        int NBG1 = a.GetUser().Where(w => w.code_profil==404 ).Count();
        int NBG2= a.GetUser().Where(w => w.code_profil == 505).Count();
        int NBG3 = a.GetUser().Where(w => w.code_profil == 606).Count();
        int NBG = NBG1 + NBG2 + NBG3;
        NbGest.Text = NBG.ToString();
        /////////
        DataAccesDataContext dbcontext = new DataAccesDataContext();

        List<UtilisateurDB> listeNotification = a.GetUser().Where(w=>w.Etat.Trim()=="N").ToList() ;
        int k = 1;
        foreach (UtilisateurDB liste in listeNotification)
        {

            string buttonName = "myBtn" + k.ToString();
            string dataName = "txtDate" + k.ToString();
            string code = "Code_" + liste.code_utilisateur;
            Pnl.Controls.Add(GetLiteral("<div  id='" + code + "'>"));
            Pnl.Controls.Add(GetLiteral("<div  id='parag'><div class='block'><div class='block_content'>"));
            Pnl.Controls.Add(GetLiteral(" <h2 class='title'><a>Utilisateur désactivé</a></h2>"));
            DateTime date = DateTime.Now;
            Pnl.Controls.Add(GetLiteral(" <div class='byline'><span>" + date + "</span> Compte de  <a>" + liste.Nom_utilisateur + "</a></div> "));
           
            Pnl.Controls.Add(GetLiteral("</div></div></div>"));

            Pnl.Controls.Add(GetLiteral("<div class='pull-right action-buttons'>"));
            Pnl.Controls.Add(GetLiteral("<button id='" + buttonName + "' type='button' class='btn  btn-minier btn-info' value='" + liste.code_utilisateur + "' onclick='Supprimer(this.value)'><i class='ace-icon fa fa-times bigger-125 '></i></button>"));
            Pnl.Controls.Add(GetLiteral("</div></div><br/><hr/>"));

            k = k + 1;
        }
    }

    protected void ajouter_Click(object sender, EventArgs e)
    {
        Response.Redirect("AjoutProfil.aspx");
    }
}

