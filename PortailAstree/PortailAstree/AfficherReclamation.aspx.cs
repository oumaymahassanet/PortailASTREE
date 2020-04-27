using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Web.UI.HtmlControls;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
namespace Astree
{


    public partial class AfficherReclamation : System.Web.UI.Page
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

            if (Session["code_utilisateur"] == null)
            {
                Response.Redirect("login.aspx");
            }
            if (!this.IsPostBack)
            {

                AstreeDonnees a = new AstreeDonnees();
                int nb = a.GetServices().Where(w => w.libelleService.Trim() == "Reclamation" && w.etat.Trim() == "A").Count();
                nbr.Text = nb.ToString();
                lundi(sender, e);

            }


        }

        protected void lundi(object sender, EventArgs e)
        {
            AstreeDonnees a = new AstreeDonnees();
            List<destinationDB> lstDestination = a.GetDestination();
            UtilisateurDB user = a.GetUser(Convert.ToInt16(Session["code_utilisateur"].ToString()));


            List<serviceDB> lstReclamation = a.GetServices().Where(w => w.libelleService.Trim() == "Reclamation" && w.etat.Trim() == "A").ToList();
            DataAccesDataContext dbcontext = new DataAccesDataContext();
            List<serviceDB> lstReclamationFin = new List<serviceDB>();
            foreach (serviceDB recl in lstReclamation)
            {
                if (lstDestination.Where(w => w.codeDest == recl.codeDest && w.codeProfil == user.code_profil).Count() > 0)
                {
                    lstReclamationFin.Add(recl);
                }

            }

            lstReclamation = lstReclamationFin;

            int nb = lstReclamation.Count();
            nbr.Text = nb.ToString();

            var listedemande = from i in dbcontext.service
                               select i.libelleService;
            //foreach (var Demande in listedemande)
            int k = 1;
            foreach (serviceDB Demande in lstReclamation)
            {

                string buttonName = "myBtn" + k.ToString();
                string dataName = "txtDate" + k.ToString();

                Pnl.Controls.Add(GetLiteral("<div class='itemdiv dialogdiv'>"));

               

                Pnl.Controls.Add(GetLiteral(" <div class='body'>"));
                Pnl.Controls.Add(GetLiteral("<br/><div class='name'>"));
                string Nom = "name_" + Demande.code_service;
                Pnl.Controls.Add(GetLiteral("<a href=# style='color:blue' id='" + Nom + "'>" + Demande.NomUtilisateur + "</a>"));

                Pnl.Controls.Add(GetLiteral("</div><br/>"));
                Pnl.Controls.Add(GetLiteral("<div class='time'> "));

                Pnl.Controls.Add(GetLiteral("<i class='ace-icon fa fa-clock-o'></i>"));
                string date = "txtDate_" + Demande.code_service;
                Pnl.Controls.Add(GetLiteral("<span id='" + date + "' class='green'>" + Demande.dateDemande + "</span>"));

                Pnl.Controls.Add(GetLiteral("</div><br/>"));

              
                string rec = "txtcontenu_" + Demande.code_service;
                Pnl.Controls.Add(GetLiteral("<div class='text' id='" + rec + "'> " + Demande.contenuReclamation + "</div>"));


                Pnl.Controls.Add(GetLiteral("<div class='pull-right'><button id='" + buttonName + "' type='button' class='btn  btn-minier btn-info' value='" + Demande.code_service + "'  onclick='mercredi(this.value)' ><i class='icon-only ace-icon fa fa-share'></i></button></div>"));


                Pnl.Controls.Add(GetLiteral("</div></div><br/> <hr/>"));

                k = k + 1;
            }


        }

        protected void BtnRepondre_Click(object sender, EventArgs e)
        {
            try
            {
                AstreeDonnees a = new AstreeDonnees();
                serviceDB reclam = a.GetServices().Where(w => w.libelleService.Trim() == "Reclamation" && w.etat.Trim() == "A" && w.code_service == Convert.ToInt16(myCode.Text)).FirstOrDefault();
                DataAccesDataContext dbcontext = new DataAccesDataContext();


                if (reclam != null)
                {

                    if (String.IsNullOrEmpty(message.Text))
                    {

                        msgerror.Visible = true;
                        msgerror.Text = "veuillez remplir la réponse ";
                        lundi(sender, e);
                    }
                    else
                    {
                        reclam.dateReponse = DateTime.Now;
                        reclam.etat = "V";
                        reclam.reponse = message.Text;
                        a.maj_reclamation(reclam);
                        message.Text = "écrivez votre réponse ici...";

                        lundi(sender, e);


                        if (reclam.etatNotif == "")
                        {
                            notificationDB notif = new notificationDB();
                            notif.codeService = reclam.code_service;
                            notif.contenuNotification = reclam.reponse;
                            notif.etatNotif = "N";// NON LU
                            notif.dateNotification = reclam.dateReponse;
                            a.InsertNotification(notif);

                        }


                       


                        UtilisateurDB user = a.GetUser(Convert.ToInt16(Session["code_utilisateur"].ToString()));
                        List<destinationDB> lstDestination = a.GetDestination();
                        List<serviceDB> lstReclamation = a.GetServices().Where(w => w.libelleService.Trim() == "Reclamation" && w.etat.Trim() == "A").ToList();
                        List<serviceDB> lstReclamationFin = new List<serviceDB>();
                        foreach (serviceDB recl in lstReclamation)
                        {
                            if (lstDestination.Where(w => w.codeDest == recl.codeDest && w.codeProfil == user.code_profil).Count() > 0)
                            {
                                lstReclamationFin.Add(recl);
                            }

                        }

                        lstReclamation = lstReclamationFin;
                        Label y = (Label)Master.FindControl("nbNotification") as Label;

                        Label x = (Label)Master.FindControl("lblNotifReclamation") as Label;
                        x.Text = lstReclamation.Count().ToString();
                        y.Text = (Convert.ToInt16(y.Text.ToString()) - 1).ToString();



                    }
                }

                
            }
            catch (Exception ex)
            {
                lundi(sender, e);
                msgerror.Visible = true;
                msgerror.Text = "Il n'existe aucunne réclamation selectionner";

            }
        }


    }
}