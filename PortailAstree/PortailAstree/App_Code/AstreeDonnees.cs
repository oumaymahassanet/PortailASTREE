using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;


namespace Astree
{

    public class AstreeDonnees
    {
        //public void InsertFichier(UtilisateurDB fichier)
        //{

        //    using (DataAccesDataContext dbContext = new DataAccesDataContext())
        //    {
        //        Utilisateur newfichier = new Utilisateur
        //        {
        //            ContentType = fichier.ContentType,
        //            Data = fichier.Data,
        //            Name = fichier.Name,
        //            code_service = fichier.code_service
        //        };
        //        dbContext.fichierService.InsertOnSubmit(newfichier);
        //        dbContext.SubmitChanges();
        //    }

        //}

        public List<destinationDB> GetDestination()
        {
            try
            {
                DataAccesDataContext dbContext = new DataAccesDataContext();
                destinationDB ls = new destinationDB();
                var pm = (from c in dbContext.destination
                          join d in dbContext.profil on c.LibelleDest.ToString().Trim() equals d.description_profil.ToString().Trim()

                          select new destinationDB
                          {
                              codeDest = c.code_dest,
                              libelleDest = c.LibelleDest,
                              codeProfil = d.code_profil,
                              descriptionProfil = d.description_profil
                          });

                return pm.ToList();
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                return null;
            }
        }
        public List<serviceDB> GetServices1()
        {

            DataAccesDataContext dbContext = new DataAccesDataContext();

            List<serviceDB> ls = new List<serviceDB>();
            var pm = (from c in dbContext.service
                      join b in dbContext.sous_branche on c.id_sous_branche equals b.Id_sous_branche
                      join a in dbContext.type_service on c.id_type equals a.Id_type
                      join d in dbContext.branche on b.Id_branche equals d.Id_branche
                      join l in dbContext.Utilisateur on c.code_utilisateur equals l.code_utilisateur
                      join k in dbContext.destination on c.code_dest equals k.code_dest
                      // join e in dbContext.notification on c.code_service equals e.code_service into newgroup
                      // from e in newgroup.DefaultIfEmpty()
                      //join e in dbContext.type on c.idType equals e.IdType
                      // join e in dbContext.user on c.code_user equals e.Id
                      // orderby e.etat descending
                      select new serviceDB
                      {
                          code_service = c.code_service,
                          numContrat = c.num_contrat == null ? 0 : c.num_contrat,
                          taux = c.taux == null ? 0 : c.taux,
                          idSousBranche = c.id_sous_branche,
                          idType = a.Id_type == null ? 0 : a.Id_type,
                          etat = c.etat == null ? "" : c.etat,
                          reponse = c.reponse == null ? "" : c.reponse,
                          duree = c.duree == null ? 0 : c.duree,
                          libelleType = a.libelle == null ? "" : a.libelle,
                          libelleBranche = d.libelle == null ? "" : d.libelle,
                          libelleSousbranche = b.libelle == null ? "" : b.libelle,
                          libelleService = c.libelleService,
                          dateDemande = c.date_demande == null ? null : c.date_demande,
                          dateReponse = c.date_Reponse == null ? null : c.date_Reponse,
                          contenuReclamation = c.contenu_Reclamation == null ? "" : c.contenu_Reclamation,
                          codeDest = c.code_dest == null ? null : c.code_dest,
                          primeHtax = c.primeHTax == null ? 0 : c.primeHTax,
                          coutPolice = c.coutPolice == null ? 0 : c.coutPolice,
                          primeTotal = c.primeTotal == null ? 0 : c.primeTotal,
                          taxe = c.tax == null ? 0 : c.tax,
                          // etatNotif= (e.etat == null ? "" : e.etat),
                          codeUtilisateur = c.code_utilisateur,
                          libelleDest = k.LibelleDest,
                          NomUtilisateur = l.Nom_utilisateur


                      });
            ls = pm.ToList();

            return ls;

        }

    



public List<DetailCommandeDB> GetDetailCommande()
        {
            DataAccesDataContext dbContext = new DataAccesDataContext();

            List<DetailCommandeDB> ls = new List<DetailCommandeDB>();
            var pm = (from a in dbContext.DetailCommande
                      join k in dbContext.produit on a.id_produit equals k.Id_produit
                      join L in dbContext.service on a.code_service equals L.code_service
                      join D in dbContext.Utilisateur on L.code_utilisateur equals D.code_utilisateur


                      select new DetailCommandeDB
                      {
                          code_service = a.code_service,
                          Id_produit = a.id_produit,
                          PU = a.PU,
                          LibelleProduit = k.LibelleProduit == null ? "" : k.LibelleProduit,
                          Qte = a.Qte,
                          code_dest = L.code_dest,
                          dateDemande = L.date_demande,
                          dateReponse = L.date_Reponse,
                          Observation = a.Observation == null ? "" : a.Observation,
                          QteLivree = a.QteLivree,
                          reponse = L.reponse == null ? "" : L.reponse,
                          etat = L.etat,
                          NomUtilisateur = D.Nom_utilisateur,
                          LibelleService = L.libelleService,
                          codeUtilisateur = L.code_utilisateur

                      });
            ls = pm.ToList();

            return ls;

        }
        public void Inserer_Commande(DetailCommandeDB Detail)
        {
            using (DataAccesDataContext dbContext = new DataAccesDataContext())
            {
                DetailCommande newCommande = new DetailCommande
                {

                    code_service = Detail.code_service,
                    id_produit = Detail.Id_produit,
                    Observation = Detail.Observation,
                    PU = Detail.PU,
                    Qte = Detail.Qte,
                    QteLivree = Detail.QteLivree == null ? 0 : Detail.QteLivree


                };
                dbContext.DetailCommande.InsertOnSubmit(newCommande);
                dbContext.SubmitChanges();
            }
        }
        public string maj_Commande(serviceDB serv)
        {
            try
            {
                using (DataAccesDataContext ctx = new DataAccesDataContext())
                {
                    service service = (from c in ctx.service
                                       where c.code_service == serv.code_service
                                       select c).FirstOrDefault();

                    service.etat = serv.etat;
                    service.date_Reponse = serv.dateReponse;
                    service.reponse = serv.reponse;
                    ctx.SubmitChanges();
                }
                return "OK";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public string maj_DetailCommande(DetailCommandeDB detail)
        {
            try
            {
                using (DataAccesDataContext ctx = new DataAccesDataContext())
                {
                    DetailCommande det = (from c in ctx.DetailCommande
                                       where c.code_service == detail.code_service  && c.id_produit== detail.Id_produit
                                       select c).FirstOrDefault();

                    det.QteLivree = detail.QteLivree;
                    det.reponse = detail.reponse;
                   
                    ctx.SubmitChanges();
                }
                return "OK";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public string maj_Commande_fournisseur(serviceDB serv)
        {
            try
            {
                using (DataAccesDataContext ctx = new DataAccesDataContext())
                {
                    service service = (from c in ctx.service
                                       where c.code_service == serv.code_service
                                       select c).FirstOrDefault();

                    service.etat = serv.etat;
                    service.date_Reponse = serv.dateReponse;
                    service.reponse = serv.reponse;
                    ctx.SubmitChanges();
                }
                return "OK";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        
        public List<UtilisateurDB> GetUser()
        {
            try
            {
                DataAccesDataContext dbContext = new DataAccesDataContext();
                UtilisateurDB ls = new UtilisateurDB();
                var pm = (from c in dbContext.Utilisateur
                          join d in dbContext.profil on c.code_profil equals d.code_profil
                         
                          select new UtilisateurDB
                          {
                              code_utilisateur = c.code_utilisateur,
                              Nom_utilisateur = c.Nom_utilisateur,
                              login = c.login,
                              Mdp = c.Mdp,
                              Etat = c.Etat.ToString(),
                              code_profil = c.code_profil,
                              description_profil = d.description_profil
                               });

                return pm.ToList();
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                return null;
            }
        }
        public UtilisateurDB GetUser(int code_utilisateur)
        {
            try
            {
                DataAccesDataContext dbContext = new DataAccesDataContext();
                UtilisateurDB ls = new UtilisateurDB();
                var pm = (from c in dbContext.Utilisateur
                          join d in dbContext.profil on c.code_profil equals d.code_profil
                          where c.code_utilisateur == code_utilisateur
                          select new UtilisateurDB
                          {
                              code_utilisateur = c.code_utilisateur,
                              Nom_utilisateur = c.Nom_utilisateur,
                              login = c.login,
                              Mdp = c.Mdp,
                              Etat = c.Etat.ToString(),
                              code_profil = c.code_profil,
                              code_partenaire=c.code_partenaire




                          });

                return pm.ToList().FirstOrDefault();
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                return null;
            }
        }
        public UtilisateurDB GetUser(string login, string password)
        {
            try
            {
                DataAccesDataContext dbContext = new DataAccesDataContext();
                UtilisateurDB ls = new UtilisateurDB();
                var pm = (from c in dbContext.Utilisateur
                          

                          where c.login == login && c.Mdp == password && c.Etat == "A"

                          select new UtilisateurDB
                          {
                              code_utilisateur = c.code_utilisateur,
                              code_profil = c.code_profil,
                              Mdp = c.Mdp,
                              Nom_utilisateur = c.Nom_utilisateur,
                              Etat = c.Etat.ToString(),
                              login = c.login

                          });

                return pm.ToList().FirstOrDefault();
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                return null;
            }
        }
        public void modifierEtat(UtilisateurDB Utilisateur)
        {

            using (DataAccesDataContext dbContext = new DataAccesDataContext())
            {
                Utilisateur newUtilisateur = new Utilisateur();
                newUtilisateur = dbContext.Utilisateur.FirstOrDefault(w => w.code_utilisateur == Utilisateur.code_utilisateur);


                newUtilisateur.Etat = Utilisateur.Etat.ToString();

                dbContext.SubmitChanges();

            }



        }
        public void ModifierMDP(UtilisateurDB util)
        {
            using (DataAccesDataContext dbContext = new DataAccesDataContext())
            {
                Utilisateur newUtilisateur = new Utilisateur();
                newUtilisateur = dbContext.Utilisateur.FirstOrDefault(w => w.login == util.login);
                newUtilisateur.Mdp = util.Mdp;
                dbContext.SubmitChanges();

            }
        }
        public string GetHash(string chaine)
        {
            try
            {
                string HashCh = "OK";
                DataAccesDataContext dbContext = new DataAccesDataContext();
                //recuperationMDP ls = new recuperationMDP();
                var pm = (from c in dbContext.recuperationMDP
                          where c.Hash == chaine && c.Etat == "E"
                          select new recuperationMDPDB
                          {
                              Etat = c.Etat,
                              Hash = c.Hash,
                              code_adresse = c.code_adresse



                          }).ToList();
                if (pm.Count != 1) { HashCh = "ERROR"; }
                return HashCh;
            }
            catch (Exception ex)
            {
                return ex.Message;

            }
        }
        public List<produitDB> GetProduit()
        {

            DataAccesDataContext dbContext = new DataAccesDataContext();

            List<produitDB> ls = new List<produitDB>();
            var pm = (from c in dbContext.produit
                      select new produitDB
                      {
                          IdProduit = c.Id_produit,
                          LibelleProduit = c.LibelleProduit,
                         code_profil=c.code_profil

    });
            ls = pm.ToList();

            return ls;

        }

        public List<profilDB> GetProfil()
        {

            DataAccesDataContext dbContext = new DataAccesDataContext();

            List<profilDB> ls = new List<profilDB>();
            var pm = (from c in dbContext.profil
                      select new profilDB
                      {
                          code = c.code_profil,
                          libelle = c.description_profil
                      });
            ls = pm.ToList();

            return ls;

        }
        public profilDB Getprofil(int code)
        {
            try
            {
                DataAccesDataContext dbContext = new DataAccesDataContext();
                profilDB ls = new profilDB();
                var pm = (from c in dbContext.profil
                          join D in dbContext.Utilisateur on c.code_profil equals D.code_profil
                          where D.code_profil == code
                          select new profilDB
                          {

                              code = c.code_profil,
                              libelle = c.description_profil


                          });

                return pm.ToList().FirstOrDefault();
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                return null;
            }
        }
        public List<type_serviceDB> GetTypeService()
        {

            DataAccesDataContext dbContext = new DataAccesDataContext();

            List<type_serviceDB> ls = new List<type_serviceDB>();
            var pm = (from c in dbContext.type_service
                          //join b in dbContext.profil on c.code_profil equals b.code_profil
                      select new type_serviceDB
                      {
                          id_type = c.Id_type,
                          libelle = c.libelle,
                          famille_type= c.famille_type == null ? "" : c.famille_type

                      });
            ls = pm.ToList();

            return ls;

        }
        public List<permissionDB> GetPermission()
        {

            DataAccesDataContext dbContext = new DataAccesDataContext();

            List<permissionDB> ls = new List<permissionDB>();
            var pm = (from c in dbContext.permission 
                      //join b in dbContext.profil on c.code_profil equals b.code_profil
                      select new permissionDB
                      {
                          code = c.code_permission,
                          description = c.description,
                          
                      });
            ls = pm.ToList();

            return ls;

        }
        public List<affecterDB> GetAffecter()
        {
            DataAccesDataContext dbContext = new DataAccesDataContext();
            List<affecterDB> ls = new List<affecterDB> ();
            var pm = (from c in dbContext.affecter
                      join b in dbContext.profil on c.code_profil equals b.code_profil
                      join a in dbContext.permission on c.code_permission equals a.code_permission
                      select new affecterDB
                      {
                          codePermission = c.code_permission,
                          descriptionPermission=a.description,
                          codeProfil =b.code_profil,
                          libelleProfil=b.description_profil
                      });
            ls = pm.ToList();

            return ls;
        }

        public List<adresseDB> GetAdresse(UtilisateurDB user)
        {
            try
            {
                DataAccesDataContext dbContext = new DataAccesDataContext();
                adresseDB ls = new adresseDB();
                var pm = (from c in dbContext.adresse
                          join a in dbContext.partenaire on c.code_adresse equals a.code_adresse
                          join o in dbContext.Utilisateur on a.code_partenaire equals o.code_partenaire
                          where o.code_utilisateur == user.code_utilisateur

                          select new adresseDB
                          {
                              code_adresse = c.code_adresse ,
                              code_postal = c.code_postal == null ? "" : c.code_postal,
                              email = c.email == null ? "" : c.email,
                              fax = c.fax == null ? "" : c.fax,
                              gouvernerat = c.gouvernerat ==null ?"" : c.code_postal,
                              rue = c.rue == null ? "" : c.rue ,
                              tel = c.tel == null ? "" : c.tel,
                              ville = c.ville == null ? "" : c.ville 

                          }).OrderBy(w => w.code_adresse);

                return pm.ToList();
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                return null;
            }
        }
        public List<adresseDB> GetAdresse()
        {
            DataAccesDataContext dbContext = new DataAccesDataContext();

            List<adresseDB> ls = new List<adresseDB>();
            var pm = (from a in dbContext.adresse
                      select new adresseDB
                      {
                          code_adresse = a.code_adresse,
                          code_postal = a.code_postal == null ? "" : a.code_postal,
                          email = a.email == null ? "" : a.email,
                          fax = a.fax == null ? "" :a.fax,
                          gouvernerat = a.gouvernerat== null ?"" : a.gouvernerat,
                          rue = a.rue == null ? "" : a.rue,
                          tel = a.tel == null ? "" : a.tel,
                          ville = a.ville == null ? "" : a.ville

                      }).OrderBy(w => w.code_adresse);
            ls = pm.ToList();

            return ls;

        }

        public List<serviceDB> GetServices()
        {

            DataAccesDataContext dbContext = new DataAccesDataContext();

            List<serviceDB> ls = new List<serviceDB>();
            var pm = (from c in dbContext.service
                      join b in dbContext.sous_branche on c.id_sous_branche equals b.Id_sous_branche
                      join a in dbContext.type_service on c.id_type equals a.Id_type
                      // join k in dbContext.destination on c.code_dest equals k.code_dest
                      join l in dbContext.Utilisateur on c.code_utilisateur equals l.code_utilisateur
                   //  join K in dbContext.profil on l.code_profil equals K.code_profil
                      join d in dbContext.branche on b.Id_branche equals d.Id_branche
                     //join f in dbContext.produit on   c.Id_produit equals f.Id_produit
                      join e in dbContext.notification on c.code_service equals e.code_service into newgroup
                      from e in newgroup.DefaultIfEmpty()
                          //join e in dbContext.type on c.idType equals e.IdType
                          // join e in dbContext.user on c.code_user equals e.Id
                      orderby e.etat descending
                      select new serviceDB
                      {
                          code_service = c.code_service,
                          numContrat = c.num_contrat == null ? 0 : c.num_contrat,
                          taux = c.taux == null ? 0 : c.taux,
                          idSousBranche = c.id_sous_branche,
                          idType = a.Id_type ,
                          etat = c.etat == null ? "" : c.etat,
                          reponse = c.reponse == null ? "" : c.reponse,
                          duree = c.duree == null ? 0 : c.duree ,
                          libelleType = a.libelle == null ? "" : a.libelle,
                          libelleBranche = d.libelle == null ? "" : d.libelle,
                          libelleSousbranche = b.libelle == null ? "" : b.libelle,
                          libelleService= c.libelleService,
                          dateDemande = c.date_demande == null ? null : c.date_demande,
                          dateReponse = c.date_Reponse == null ? null : c.date_Reponse ,
                          contenuReclamation = c.contenu_Reclamation == null ? "" : c.contenu_Reclamation,
                          //libelleDest = k.LibelleDest,
                          codeDest =c.code_dest == null ? 0 : c.code_dest,
                          primeHtax = c.primeHTax == null ? 0 : c.primeHTax,
                          coutPolice = c.coutPolice == null ? 0 : c.coutPolice,
                          primeTotal = c.primeTotal == null ? 0 : c.primeTotal,
                          taxe=c.tax == null ? 0 : c.tax,
                          etatNotif= (e.etat == null ? "" : e.etat),
                          codeUtilisateur=c.code_utilisateur ,
                          NomUtilisateur = l.Nom_utilisateur==null?"":l.Nom_utilisateur,
                         // description_profil=K.description_profil == null ? "" : K.description_profil


                      });
            ls = pm.ToList();

            return ls;

        }
        //public List<serviceDB> GetFichierServices()
        //{

        //    DataAccesDataContext dbContext = new DataAccesDataContext();

        //    List<serviceDB> ls = new List<serviceDB>();
        //    var pm = (from c in dbContext.service
        //              join K in dbContext.Utilisateur on c.code_utilisateur equals K.code_utilisateur
                     
        //              select new serviceDB
        //              {
        //                  code_service = c.code_service,
        //                  libelleService = c.libelleService,
        //                  etat = c.etat,
        //                  dateDemande = c.date_demande,
        //                  dateReponse = c.date_Reponse,
        //                  reponse = c.reponse == null ? "" : c.reponse,
        //                  contenuReclamation = c.contenu_Reclamation == null ? "" : c.contenu_Reclamation,
        //                  codeDest = c.code_dest == null ? 0 : c.code_dest,
                      
        //                  codeUtilisateur = c.code_utilisateur,
        //                  NomUtilisateur = K.Nom_utilisateur,
        //                  Data = L.Data.ToArray(),
        //                  DataR = D.DataR.ToArray()
        //              });
        //    ls = pm.ToList();

        //    return ls;

        //}
        
        //public List<fichierServiceDB> GetFichier()
        //{
        //    DataAccesDataContext dbContext = new DataAccesDataContext();

        //    List<fichierServiceDB> ls = new List<fichierServiceDB>();
        //    var pm = (from c in dbContext.fichierService
        //              select new fichierServiceDB
        //              {
        //                  code_service = c.code_service,
        //                  Data = c.Data.ToArray(),
        //                  ContentType = c.ContentType,
        //                  Name = c.Name

        //              });
        //    ls = pm.ToList();

        //    return ls;

        //}

        //public List<fichierIndexeDB> GetFichierIndexe()
        //{
        //    DataAccesDataContext dbContext = new DataAccesDataContext();

        //    List<fichierIndexeDB> ls = new List<fichierIndexeDB>();
        //    var pm = (from c in dbContext.fichierIndexe
        //              select new fichierIndexeDB
        //              {
        //                  code_service = c.code_service,
        //                  DataR = c.DataR.ToArray(),
        //                  ContentTypeR = c.ContentTypeR,
        //                  NameR = c.NameR

        //              });
        //    ls = pm.ToList();

        //    return ls;

        //}
        //public List<serviceDB> GetServices(int idType)
        //{

        //    DataAccesDataContext dbContext = new DataAccesDataContext();

        //    List<serviceDB> ls = new List<serviceDB>();
        //    var pm = (from c in dbContext.service
        //              join b in dbContext.sous_branche on c.id_sous_branche equals b.Id_sous_branche
        //              join a in dbContext.type_service on c.id_type equals a.Id_type
        //              join d in dbContext.branche on b.Id_branche equals d.Id_branche
        //              join e in dbContext.type on c.idType equals e.IdType
        //              // join e in dbContext.user on c.code_user equals e.Id
        //              select new serviceDB
        //              {
        //                  code_service = c.code_service,
        //                  numContrat = c.num_contrat,
        //                  taux = c.taux,
        //                  idSousBranche = c.id_sous_branche,
        //                  idType = a.Id_type,
        //                  etat = c.etat,
        //                  reponse = c.reponse,
        //                  duree = c.duree,
        //                  libelleType = a.libelle,
        //                  libelleBranche = d.libelle,
        //                  libelleSousbranche = b.libelle,
        //                  dateDemande = c.date_demande,
        //                  dateReponse = c.date_Reponse,
        //                  contenuReclamation = c.contenu_Reclamation,
        //                  iddType = c.idType

        //              });
        //    ls = pm.ToList();

        //    return ls;

        //}

        public List<partenaireDB> GetPartenair()
        {
            try
            {
                DataAccesDataContext dbContext = new DataAccesDataContext();
                partenaireDB ls = new partenaireDB();
                var pm = (from c in dbContext.partenaire
                          //join d in dbContext.adresse on c.code_adresse equals d.code_adresse
                          //join b in dbContext.type_interaction on c.code_interaction equals b.code_interaction
                          //join a in dbContext.Utilisateur on c.code_partenaire equals a.code_partenaire

                          select new partenaireDB
                          {
                              code_partenaire = c.code_partenaire,
                              code_adresse = c.code_adresse,
                              code_interaction = c.code_interaction,
                              description = c.titre_partenaire,
                              description_profil = c.description_profil == null ? "" : c.description_profil,
                              titre_partenaire = c.titre_partenaire





                          });

                return pm.ToList();
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                return null;
            }
        }
        

        public List<notificationDB> GetNotification()
        {
            try
            {
                DataAccesDataContext dbContext = new DataAccesDataContext();
                notificationDB ls = new notificationDB();
                var pm = (from c in dbContext.notification
                          join a in dbContext.service on c.code_service equals a.code_service


                          select new notificationDB
                          {
                              codeNotification = c.code_notification,
                              contenuNotification = c.contenu_notification,
                              dateNotification = c.date_notification,
                              etatNotif = c.etat,
                              codeService = a.code_service,
                              libelleService = a.libelleService,
                              idType = Convert.ToInt16(a.id_type),
                              codeUtilisateur= Convert.ToInt16(a.code_utilisateur)
                              

                          });

                return pm.ToList();
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                return null;
            }
        }
        public List<statistiquesDB> GetStatistiques()
        {
            try
            {
                DataAccesDataContext dbContext = new DataAccesDataContext();
                statistiquesDB ls = new statistiquesDB();
                var pm = (from c in dbContext.statistique
                          group c by new { c.Agence, c.Annee , c.Mois , c.Branche , c.SousBranche } into g

                          select new statistiquesDB
                          {
                              Agence = g.Key.Agence == null ? "" : g.Key.Agence,
                              Annee = g.Key.Annee == null ? 0 : g.Key.Annee,
                              Branche = g.Key.Branche == null ? "" : g.Key.Branche,
                              Comission = g.Sum(w => w.Comission) == null ? 0 : g.Sum(w => w.Comission),
                              Mois = g.Key.Mois == null ? 0 : g.Key.Mois,
                              Prime = g.Sum(w => w.Prime) == null ? 0 : g.Sum(w => w.Prime),

                              Sinistre = g.Sum(w => w.Sinistre) == null ? 0 : g.Sum(w => w.Sinistre),
                              SousBranche = g.Key.SousBranche == null ? "" : g.Key.SousBranche,
                              SP = g.Sum(w => w.SP) == null ? 0 : g.Sum(w => w.SP)
                          }) ;
                int size = pm.ToList().Count();
                return pm.ToList();
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                return null;
            }
        }

        public void modifierUtilisateur(UtilisateurDB Utilisateur)
        {

            using (DataAccesDataContext dbContext = new DataAccesDataContext())
            {
                Utilisateur newUtilisateur = new Utilisateur();
                newUtilisateur = dbContext.Utilisateur.FirstOrDefault(w => w.code_utilisateur== Utilisateur.code_utilisateur);

                newUtilisateur.code_utilisateur = Utilisateur.code_utilisateur;
                newUtilisateur.code_profil = Utilisateur.code_profil;
                newUtilisateur.Mdp = Utilisateur.Mdp;
                newUtilisateur.Nom_utilisateur = Utilisateur.Nom_utilisateur;
                newUtilisateur.Etat = Utilisateur.Etat.ToString();
                newUtilisateur.login = Utilisateur.login;
                newUtilisateur.Image = Utilisateur.Image;

                dbContext.SubmitChanges();

            }



        }
        public string maj_user(string _login)
        {
            try
            {
                using (DataAccesDataContext ctx = new DataAccesDataContext())
                {
                    Utilisateur user = (from c in ctx.Utilisateur
                                        where c.login.ToUpper() == _login.ToUpper()
                                        select c).FirstOrDefault();

                    if (user.Etat == "A")
                    {
                        user.Etat = "N";
                        ctx.SubmitChanges();
                        return "Desactive";
                    }
                    else
                    {
                        user.Etat = "A";
                        ctx.SubmitChanges();
                        return "Active";
                    }


                }
                // return "OK";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        public void InsertProfil(profilDB profl)
        {
            using (DataAccesDataContext dbContext = new DataAccesDataContext())
            {
                profil profil = new profil
                {
                    code_profil = profl.code ,
                    description_profil = profl.libelle
                  
                };
                dbContext.profil.InsertOnSubmit(profil);
                dbContext.SubmitChanges();
            }

        }
        public void InsertPermission(permissionDB permiss)
        {
            using (DataAccesDataContext dbContext = new DataAccesDataContext())
            {

                // incrémenter code permission a partir du dernier code

                List<permissionDB> lsperm = GetPermission();
                int code_permission = lsperm.OrderBy(w => w.code).LastOrDefault().code+1;


                permission permission = new permission
                {
                    code_permission = code_permission,
                    description = permiss.description
                   
                    
                  

                  

                };
                dbContext.permission.InsertOnSubmit(permission);
                dbContext.SubmitChanges();
            }

        }
        public void InsertAffecter(List<affecterDB> lstAff)
        {
           
                

               // List<affecterDB> lsaff = GetAffecter();
                
                foreach(affecterDB aff in lstAff)
                {
                using (DataAccesDataContext dbContext = new DataAccesDataContext())
                {
                    affecter affecter = new affecter
                    {
                        code_permission = aff.codePermission,
                        code_profil = aff.codeProfil

                    };
                    dbContext.affecter.InsertOnSubmit(affecter);
                    dbContext.SubmitChanges();
                }
               
                }

        }
        public void Insertservice(serviceDB ser)
        {

            using (DataAccesDataContext dbContext = new DataAccesDataContext())
            {
                service service = new service
                {

                    //code_service = ser.code_service,
                    num_contrat = ser.numContrat == null ? 0 : ser.numContrat,
                    taux = ser.taux == null ? 0 : ser.taux,
                    id_sous_branche = ser.idSousBranche,
                    id_type = ser.idType,
                    etat = ser.etat == null ? "" : ser.etat,
                    reponse = ser.reponse == null ? "" : ser.reponse,
                    duree = ser.duree == null ? 0 : ser.duree,
                    date_demande = ser.dateDemande == null ? null : ser.dateDemande,
                    contenu_Reclamation = ser.contenuReclamation == null ? "" : ser.contenuReclamation,
                    code_dest=ser.codeDest == null ? 0 : ser.codeDest,
                    primeHTax=ser.primeHtax == null ? 0 : ser.primeHtax,
                    coutPolice=ser.coutPolice == null ? 0 : ser.coutPolice,
                    primeTotal=ser.primeTotal == null ? 0 : ser.primeTotal,
                    libelleService=ser.libelleService == null ? "" : ser.libelleService,
                    code_utilisateur=ser.codeUtilisateur == null ? 0 : ser.codeUtilisateur,
                    //Id_produit = ser.Id_produit == null ? 0 : ser.Id_produit,
                    //Qte = ser.Qte == null ? 0 : ser.Qte


                };
                dbContext.service.InsertOnSubmit(service);
                dbContext.SubmitChanges();
            }
        }
        public void modifierAdresse(adresseDB adress)
        {

            using (DataAccesDataContext dbContext = new DataAccesDataContext())
            {
                adresse newAdresse = new adresse();
                newAdresse = dbContext.adresse.FirstOrDefault(w => w.code_adresse == adress.code_adresse);

                newAdresse.code_postal = adress.code_postal;
                newAdresse.email = adress.email;
                newAdresse.fax = adress.fax;
                newAdresse.gouvernerat = adress.gouvernerat;
                newAdresse.rue = adress.rue;
                newAdresse.tel = adress.tel;
                newAdresse.ville = adress.ville;
                dbContext.SubmitChanges();

            }
        }
        public List<adresseDB> GetAdresse(partenaireDB part)
        {
            DataAccesDataContext dbContext = new DataAccesDataContext();

            List<adresseDB> ls = new List<adresseDB>();
            var pm = (from a in dbContext.adresse
                      where (part.code_adresse == a.code_adresse)
                      select new adresseDB
                      {
                          code_adresse = a.code_adresse,
                          code_postal = a.code_postal,
                          email = a.email,
                          fax = a.fax,
                          gouvernerat = a.gouvernerat,
                         
                          
                          rue = a.rue,
                         
                          tel = a.tel,
                          ville = a.ville

                      }).OrderBy(w => w.code_adresse);

            ls = pm.ToList();

            return ls;

        }
        public void InsertUser(UtilisateurDB user)
        {

            using (DataAccesDataContext dbContext = new DataAccesDataContext())
            {
               Utilisateur utilisateur = new Utilisateur
                {

                   code_utilisateur= user.code_utilisateur,
                   code_profil = user.code_profil,
                   Mdp= user.Mdp,
                    Nom_utilisateur= user.Nom_utilisateur ,
                   Etat = user.Etat ,
                   login = user.login,
                   
                   

                   
                };
                dbContext.Utilisateur.InsertOnSubmit(utilisateur);
                dbContext.SubmitChanges();
            }
        }
        public void InsertNotification(notificationDB notif)
        {

            using (DataAccesDataContext dbContext = new DataAccesDataContext())
            {
                notification not = new notification
                {

                    code_notification = notif.codeNotification,
                    contenu_notification = notif.contenuNotification,
                    date_notification    = notif.dateNotification,
                    etat = notif.etatNotif,
                    code_service    = notif.codeService




                };
                dbContext.notification.InsertOnSubmit(not);
                dbContext.SubmitChanges();
            }
        }
        public void InsertHash(recuperationMDPDB recup)
        {

            using (DataAccesDataContext dbContext = new DataAccesDataContext())
            {
                recuperationMDP recuperation = new recuperationMDP
                {
                    Hash = recup.Hash,
                    Etat = recup.Etat,
                    code_adresse = recup.code_adresse

                };
                dbContext.recuperationMDP.InsertOnSubmit(recuperation);
                dbContext.SubmitChanges();
            }

        }
        //public void InsertFichier(fichierServiceDB fichier)
        //{

        //    using (DataAccesDataContext dbContext = new DataAccesDataContext())
        //    {
        //        fichierService newfichier = new fichierService
        //        {
        //            ContentType = fichier.ContentType,
        //            Data = fichier.Data,
        //            Name = fichier.Name,
        //            code_service = fichier.code_service
        //        };
        //        dbContext.fichierService.InsertOnSubmit(newfichier);
        //        dbContext.SubmitChanges();
        //    }

        //}

        //public void InsertFichierIndexe(fichierIndexeDB fichier)
        //{

        //    using (DataAccesDataContext dbContext = new DataAccesDataContext())
        //    {
        //        fichierIndexe newfichier = new fichierIndexe
        //        {
        //            ContentTypeR = fichier.ContentTypeR,
        //            DataR = fichier.DataR,
        //            NameR = fichier.NameR,
        //            code_service = fichier.code_service,
        //            type_fichierR = fichier.type_fichierR

        //        };
        //        dbContext.fichierIndexe.InsertOnSubmit(newfichier);
        //        dbContext.SubmitChanges();
        //    }

        //}
        public string maj_derogation(serviceDB serv)
        {
            try
            {
                using (DataAccesDataContext ctx = new DataAccesDataContext())
                {
                    service derogation = (from c in ctx.service
                                          where c.code_service == serv.code_service
                                          select c).FirstOrDefault();

                    derogation.etat = serv.etat;
                    derogation.date_Reponse = serv.dateReponse;
                    derogation.reponse= serv.reponse;

                    ctx.SubmitChanges();
                }
                return "OK";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        public string maj_devis(serviceDB serv)
        {
            try
            {
                using (DataAccesDataContext ctx = new DataAccesDataContext())
                {
                    service devis = (from c in ctx.service
                                          where c.code_service == serv.code_service
                                          select c).FirstOrDefault();

                    devis.etat = serv.etat;
                    devis.date_Reponse = serv.dateReponse;
                    devis.primeHTax = serv.primeHtax;
                    devis.coutPolice = serv.coutPolice;
                    devis.tax = serv.taxe;
                    devis.primeTotal = serv.primeTotal;
                    ctx.SubmitChanges();
                }
                return "OK";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        public string maj_reclamation(serviceDB serv)
        {
            try
            {
                using (DataAccesDataContext ctx = new DataAccesDataContext())
                {
                    service service = (from c in ctx.service
                                       where c.code_service == serv.code_service
                                       select c).FirstOrDefault();
                    
                    service.etat = serv.etat;
                    service.date_Reponse = serv.dateReponse;
                    service.reponse = serv.reponse;
                    ctx.SubmitChanges();
                }
                return "OK";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        public string maj_notification(notificationDB notif)
        {
            try
            {
                using (DataAccesDataContext ctx = new DataAccesDataContext())
                {
                   notification notification = (from c in ctx.notification
                                         where c.code_notification == notif.codeNotification
                                     select c).FirstOrDefault();

                    notification.etat =notif.etatNotif;
                    
                    ctx.SubmitChanges();
                }
                return "OK";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }



        public void InsertAdresse(adresseDB adr)
        {

            using (DataAccesDataContext dbContext = new DataAccesDataContext())
            {
                adresse adresse = new adresse
                {

                    email = adr.email,
                    code_postal = adr.code_postal == null ? "" : adr.code_postal,
                    fax = adr.fax == null ? "" : adr.fax,
                    gouvernerat = adr.gouvernerat == null ? "" : adr.gouvernerat,
                    rue = adr.rue == null ? "" : adr.rue,
                    tel = adr.tel == null ? "" : adr.tel,
                    ville = adr.ville == null ? "" : adr.ville




                };
                dbContext.adresse.InsertOnSubmit(adresse);
                dbContext.SubmitChanges();
            }
        }

        public void modifierPartenaire(partenaireDB part)
        {

            using (DataAccesDataContext dbContext = new DataAccesDataContext())
            {
                partenaire partenaire = new partenaire();
                partenaire.code_adresse = part.code_adresse;


                dbContext.SubmitChanges();

            }
        }

    }
}
