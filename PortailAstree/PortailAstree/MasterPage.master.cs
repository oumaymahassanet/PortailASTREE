using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace Astree
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {   //li
            //li
            AstreeDonnees a = new AstreeDonnees();
            List<serviceDB> lsNotification1 = a.GetServices().Where(w => (w.libelleService != null) && (w.etatNotif.Trim() == "N") && (w.codeUtilisateur == Convert.ToInt16(Session["code_utilisateur"]))).ToList();
            liCommandeInter.Visible = false;
            liCommande.Visible = false;
            liCommandeFournisseur.Visible = false;
            accueil.Visible = false;
        Commande.Visible = false;
            EnvoiCommande.Visible = false;
            liCommandeRepondreInter.Visible = false;
            liCommandeFour.Visible = false;
            liCommandeRepondreFour.Visible = false;
            liCommandeConsultInter.Visible = false;
            liHistorique.Visible = false;
            liCommandeConsultFour.Visible = false;
        liDerogation.Visible = false;
            liEnvoiDero.Visible = false;
            liafficherDeroInter.Visible = false;
            liConsulterDero.Visible = false;
            liafficherDeroGest.Visible = false;
        Devis.Visible = false;
            liDemanderDevis.Visible = false;
            liafficherDevisInter.Visible = false;
            liTraiterDevis.Visible = false;
            liaffixherDevisGest.Visible = false;

        liReclamation.Visible = false;
            liEnvoyerReclamation.Visible = false;
            liaffiherReclamation.Visible = false;
            liConsulterStatistiques.Visible= false;
        liGestUser.Visible = false;
        liGestProfil.Visible = false;
        liGestPermission.Visible = false;
            //Notification
            liDevis.Visible = false;
            //liRepIndermidiaire.Visible = false;
            liRemise.Visible = false;
            liProrogatin.Visible = false;
            liSouscripton.Visible = false;
            liCommande.Visible = false;
            liCompteDesactive.Visible = false;
            liCommandeInter.Visible = false;
            liCommandeFournisseur.Visible = false;
            liCommandeInterFourn.Visible = false;
            liAfficheReclamation.Visible = false;
            
            // yjini erreur ! 
            if (Session["code_utilisateur"] == null)
            {
                Response.Redirect("login.aspx");
            }
            UtilisateurDB user = a.GetUser(Convert.ToInt16(Session["code_utilisateur"].ToString()));
            profilDB P = a.Getprofil(Convert.ToInt32( user.code_profil));
            TxtUserProfil.Text = user.Nom_utilisateur;
          TxtTitre.Text = P.libelle;
            // if (Session["code_profil"].Equals("101"))
            //Agent
            if (user.code_profil == 101)
            {
                //Li
                liConsulterStatistiques.Visible = true;
                Commande.Visible = true;
                EnvoiCommande.Visible = true;
                liCommandeConsultInter.Visible = false;
                liDerogation.Visible = true;
                liEnvoiDero.Visible = true;
                liafficherDeroInter.Visible = false;
               
                liReclamation.Visible = true;
                liEnvoyerReclamation.Visible = true;
                liDevis.Visible = false;
                liRemise.Visible = true;
                liProrogatin.Visible = true;
                liSouscripton.Visible = true;
               
                liConsulterStatistiques.Visible = true;
              
                liAfficheReclamation.Visible = true;
                liCommandeInter.Visible = true;
                // List<notificationDB> lsNotification = a.GetNotification().Where(w => w.etatNotif == "N" && w.codeUtilisateur== Convert.ToInt16(Session["code_utilisateur"])).ToList();
                List<serviceDB> lsNotification = a.GetServices().Where(w => (w.libelleService != null) && (w.etatNotif.Trim() == "N") && (w.codeUtilisateur == Convert.ToInt16(Session["code_utilisateur"]))).ToList();

                //int nb = lsNotification.Count();
                //if (nb>0) { nbNotification.Visible = true; }
                lblNotifRemise.Text = lsNotification.Where(w => w.libelleService.Trim() == "Derogation" && w.idType == 1).Count().ToString();
                lblNotifProrogation.Text = lsNotification.Where(w => w.libelleService.Trim() == "Derogation" && w.idType == 2).Count().ToString();
                lblNotifSouscription.Text = lsNotification.Where(w => w.libelleService.Trim() == "Derogation" && w.idType == 3).Count().ToString();

                lblDevis.Text = lsNotification.Where(w => w.libelleService.Trim() == "Devis").Count().ToString();
                lblNotifCommandeInter.Text = lsNotification.Where(w => w.libelleService.Trim() == "Commande" && w.codeUtilisateur == Convert.ToInt16(Session["code_utilisateur"])).Count().ToString();

                List<serviceDB> lstNotifReclamation = a.GetServices().Where(w => w.libelleService.Trim() == "Reclamation" && w.etatNotif.Trim() == "N" && w.codeUtilisateur == Convert.ToInt16(Session["code_utilisateur"])).ToList();
                lblNotifReclamation.Text = lstNotifReclamation.Count().ToString();


                nbNotification.Text = (Convert.ToInt16(lblDevis.Text) + Convert.ToInt16(lblNotifRemise.Text) + Convert.ToInt16(lblNotifProrogation.Text) + Convert.ToInt16(lblNotifReclamation.Text) + Convert.ToInt16(lblNotifCommandeInter.Text) + Convert.ToInt16(lblNotifSouscription.Text)).ToString();

            }
            //Courtier
            else if (user.code_profil == 202)
            {

                //LI

                Commande.Visible = true;
                EnvoiCommande.Visible = true;
                liCommandeConsultInter.Visible = false;
                liDerogation.Visible = true;
                liEnvoiDero.Visible = true;
                liafficherDeroInter.Visible = false;
                Devis.Visible = true;
                liDemanderDevis.Visible = true;
                liafficherDevisInter.Visible = false;
                liReclamation.Visible = true;
                liEnvoyerReclamation.Visible = true;
                // notification
                liCommandeInter.Visible = true;
                liDevis.Visible = true;
                liRemise.Visible = true;
                liProrogatin.Visible = true;
                liSouscripton.Visible = true;
               
                liConsulterStatistiques.Visible = false;
                
                liAfficheReclamation.Visible = true;
                nbNotification.Visible = true;
                // List<notificationDB> lsNotification = a.GetNotification().Where(w => w.etatNotif == "N" && w.codeUtilisateur== Convert.ToInt16(Session["code_utilisateur"])).ToList();
                List<serviceDB> lsNotification = a.GetServices().Where(w => (w.libelleService != null) && (w.etatNotif.Trim() == "N") && (w.codeUtilisateur == Convert.ToInt16(Session["code_utilisateur"]))).ToList();
                //nbNotification.Text = lsNotification.Count().ToString();
                int nb = lsNotification.Count();
                if (nb <= 0) { nbNotification.Visible = false; }

                lblNotifRemise.Text = lsNotification.Where(w => w.libelleService.Trim() == "Derogation" && w.idType == 1).Count().ToString();
                lblNotifProrogation.Text = lsNotification.Where(w => w.libelleService.Trim() == "Derogation" && w.idType == 2).Count().ToString();
                lblNotifSouscription.Text = lsNotification.Where(w => w.libelleService.Trim() == "Derogation" && w.idType == 3).Count().ToString();

                lblDevis.Text = lsNotification.Where(w => w.libelleService.Trim() == "Devis").Count().ToString();
                lblNotifCommandeInter.Text = lsNotification.Where(w => w.libelleService.Trim() == "Commande").Count().ToString();

                List<serviceDB> lstNotifReclamation = a.GetServices().Where(w => w.libelleService.Trim() == "Reclamation" && w.etatNotif.Trim() == "N" && w.codeUtilisateur == Convert.ToInt16(Session["code_utilisateur"])).ToList();
                lblNotifReclamation.Text = lstNotifReclamation.Count().ToString();

                nbNotification.Text = (Convert.ToInt16(lblDevis.Text) + Convert.ToInt16(lblNotifRemise.Text) + Convert.ToInt16(lblNotifProrogation.Text) + Convert.ToInt16(lblNotifReclamation.Text) + Convert.ToInt16(lblNotifCommandeInter.Text) + Convert.ToInt16(lblNotifSouscription.Text)).ToString();

            }
            //Fournisseur
            else if (user.code_profil == 303)
            {
                Commande.Visible = true;
                liCommandeRepondreFour.Visible = true;
                liCommandeConsultFour.Visible = false;
                //notification
                liCommandeFournisseur.Visible = true;
               
                liCommandeFournisseur.Visible = true;

                List<serviceDB> lsNotification = a.GetServices().Where(w => (w.libelleService != null) && (w.codeDest == Convert.ToInt16(Session["code_utilisateur"]))).ToList();

                lsNotification = lsNotification.Where(w => w.etat.Trim() == "A").ToList();


                lblNotifCommandeFourn.Text = lsNotification.Where(w => w.libelleService.Trim() == "Commande").Count().ToString();
                nbNotification.Text = lsNotification.Count().ToString();

            }
            //Gestionnaire Commande
            else if (user.code_profil == 404)
            {

                //Li
                Commande.Visible = true;
                liHistorique.Visible = true;
                liCommandeFour.Visible = true;
                liCommandeRepondreInter.Visible = true;
                liReclamation.Visible = true;
                liaffiherReclamation.Visible = true;
                //notification
                liCommandeInterFourn.Visible = true;
                liCommandeInter.Visible = false;

                liCommande.Visible = true;
               
                
               
                liAfficheReclamation.Visible = true;

                // List<notificationDB> lsNotification = a.GetNotification().Where(w => w.etatNotif == "N" && w.codeUtilisateur== Convert.ToInt16(Session["code_utilisateur"])).ToList();
                List<serviceDB> lsNotification = a.GetServices().Where(w => (w.libelleService != null) && (w.etat.Trim() == "A") && w.codeDest == 404).ToList();
                lblNotifCommande.Text = lsNotification.Where(w => w.libelleService.Trim() == "Commande" && w.etat.Trim() == "A" && w.codeDest == 404).Count().ToString();

                List<serviceDB> lsNotificationFourn = a.GetServices().Where(w => (w.libelleService != null) && (w.etat.Trim() == "V") && w.etatNotif.Trim() != "L" && w.codeDest != 404 && w.codeUtilisateur == Convert.ToInt16(Session["code_utilisateur"])).ToList();
                lblNotifCommandeInterFourn.Text = lsNotificationFourn.Count().ToString();
                //lblNotifCommandeInterFourn.Text = lsNotificationFourn.Where(w => w.libelleService.Trim() == "Commande").Count().ToString();


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

                lblNotifReclamation.Text = lstReclamation.Count().ToString();


                nbNotification.Text = (Convert.ToInt16(lblNotifCommandeInterFourn.Text) + Convert.ToInt16(lblNotifCommande.Text) + Convert.ToInt16(lblNotifReclamation.Text)).ToString();


            }
            //Gestionnaire Devis
            else if (user.code_profil == 505)
            {
                //LI
                Devis.Visible = true;
                liTraiterDevis.Visible = true;
                liaffixherDevisGest.Visible = true;
                liReclamation.Visible = true;
                liaffiherReclamation.Visible = true;
                //notification
                

               
                liDevis.Visible = true;
              
                liAfficheReclamation.Visible = true;
                List<serviceDB> lsNotification = a.GetServices().Where(w => (w.libelleService != null) && (w.etat.Trim() == "A")).ToList();
                lblDevis.Text = lsNotification.Where(w => w.libelleService.Trim() == "Devis").Count().ToString();




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

                lblNotifReclamation.Text = lstReclamation.Count().ToString();


                nbNotification.Text = (Convert.ToInt16(lblDevis.Text) + Convert.ToInt16(lblNotifReclamation.Text)).ToString();


            }
            //Gestionnaire Dérogations
            else if (user.code_profil == 606)
            {

                //LI
                liDerogation.Visible = true;
                liConsulterDero.Visible = true;
                liafficherDeroGest.Visible = false;
                liReclamation.Visible = true;
                liaffiherReclamation.Visible=true;
               //notification
                liRemise.Visible = true;
                liProrogatin.Visible = true;
                liSouscripton.Visible = true;
                //  IntermidiaireProfil.Visible = true;

                
                liRemise.Visible = true;
                liProrogatin.Visible = true;
                liSouscripton.Visible = true;
               
                liAfficheReclamation.Visible = true;
                List<serviceDB> lsNotification = a.GetServices().Where(w => (w.libelleService != null) && (w.etat.Trim() == "A")).ToList();

                lblNotifRemise.Text = lsNotification.Where(w => w.libelleService.Trim() == "Derogation" && w.idType == 1).Count().ToString();
                lblNotifProrogation.Text = lsNotification.Where(w => w.libelleService.Trim() == "Derogation" && w.idType == 2).Count().ToString();
                lblNotifSouscription.Text = lsNotification.Where(w => w.libelleService.Trim() == "Derogation" && w.idType == 3).Count().ToString();





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

                lblNotifReclamation.Text = lstReclamation.Count().ToString();


                nbNotification.Text = (Convert.ToInt16(lblNotifReclamation.Text) + Convert.ToInt16(lblNotifRemise.Text) + Convert.ToInt16(lblNotifProrogation.Text) + Convert.ToInt16(lblNotifSouscription.Text)).ToString();

            }




            //Admin
            else if (user.code_profil == 808)
            {
                //LI
                accueil.Visible = true;
                liGestUser.Visible = true;
                liGestProfil.Visible = true;
                liGestPermission.Visible = true;
                //  IntermidiaireProfil.Visible = true;
                //notification
                liCompteDesactive.Visible = true;

                liGestUser.Visible = true;
                liGestProfil.Visible = true;
              
                

                List<UtilisateurDB> lsNotification = a.GetUser().Where(w => w.Etat.Trim() == "N").ToList();
                nbNotification.Text = lsNotification.Count().ToString();

                lblNotifCompteDesactive.Text = lsNotification.Count().ToString();

            }




        }

        protected void btnDeconnexion_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("login.aspx");
        }

        protected void idRemise_Click(object sender, EventArgs e)
        {
            Session["remise"] = "0";
            Session["prorogation"] = null;
            Session["souscription"] = null;
            Response.Redirect("AfficherDerogation.aspx");
        }



        protected void idProrogation_ServerClick(object sender, EventArgs e)
        {
            Session["prorogation"] = "1";
            Session["remise"] = null;
            Session["souscription"] = null;
            Response.Redirect("AfficherDerogation.aspx");
        }

        protected void idSouscription_ServerClick(object sender, EventArgs e)
        {
            Session["souscription"] = "2";
            Session["prorogation"] = null;
            Session["remise"] = null;
            Response.Redirect("AfficherDerogation.aspx");
        }

        protected void Unnamed_ServerClick(object sender, EventArgs e)
        {
            AstreeDonnees a = new AstreeDonnees();
            UtilisateurDB user = a.GetUser(Convert.ToInt16(Session["code_utilisateur"].ToString()));
            if ((user.code_profil == 101) || (user.code_profil == 202))
            {
                Response.Redirect("DemanderReclamation.aspx");
            }
            else
            {
                Response.Redirect("AfficherReclamation.aspx");
            }
        }
    }
}
