using System;
using System.Collections.Generic;
using System.Text;

namespace Astree
{
    public class destinationDB
    {
        public int codeDest { get; set; }
        public string libelleDest { get; set; }
        public int codeProfil { get; set; }
        public string descriptionProfil { get; set; }

    }
    public class DetailCommandeDB
    {
        public int Id_detail { get; set; }
        public int? Id_produit { get; set; }
        public int? Qte { get; set; }
        public int? QteLivree { get; set; }
        public string Observation { get; set; }
        public int? code_service { get; set; }
        public int? PU { get; set; }
        public string LibelleProduit { get; set; }
        public int? code_dest { get; set; }
        public DateTime? dateDemande { get; set; }
        public DateTime? dateReponse { get; set; }
        public string reponse { get; set; }
        public string etat { get; set; }

        public string NomUtilisateur { get; set; }
        public string LibelleService { get; set; }
        public int? codeUtilisateur { get; set; }
    }
   
    public class recuperationMDPDB
    {

        public int Id { get; set; }
        public int? code_adresse { get; set; }
        public string Hash { get; set; }
        public string Etat { get; set; }
    }
    public class UtilisateurDB
    {

        public int code_utilisateur { get; set; }
        public int? code_profil { get; set; }
        public string Nom_utilisateur { get; set; }
        public string Mdp { get; set; }
        public string Etat { get; set; }
        public string login { get; set; }
        public string description_profil { get; set; }
        public int? code_partenaire { get; set; }
        public int? code_adresse { get; set; }
        public Byte[] Image { get; set; }

    }

    public class partenaireDB
    {

        public int code_partenaire { get; set; }
        public int? code_adresse { get; set; }
        public int? code_interaction { get; set; }
        public string description { get; set; }
        public string titre_partenaire { get; set; }
        public string description_profil { get; set; }

    }
    
    public class profilDB
    {
        public int code { get; set; }
        public string libelle { get; set; }
        

    }
    public class produitDB
    {
        public int IdProduit { get; set; }
        public string LibelleProduit { get; set; }
        public int? code_profil { get; set; }


    }
    public class permissionDB
    {
        public int code { get; set; }
        public string description { get; set; }
        public int codeProfil { get; set; }
        public string libelle { get; set; }
        
    }
    public class affecterDB
    {
        public int codeProfil { get; set; }
        public int codePermission { get; set; }
        public string libelleProfil { get; set; }
        public string descriptionPermission { get; set; }


    }
    public class serviceDB
    {
        public int code_service{ get; set; }
        public int? numContrat { get; set; }
        public int? taux { get; set; }
        public int idSousBranche { get; set; }
        public int idType { get; set; }
        public string etat { get; set; }
        public DateTime? dateDemande { get; set; }
        public DateTime? dateReponse { get; set; }
        public string reponse { get; set; }
        public int? duree { get; set; }
        public string libelleType { get; set; }
        public string libelleBranche { get; set; }
        public string libelleSousbranche { get; set; }
        public string contenuReclamation { get; set; }
        public string libelleService { get; set; }
        public int idBranche { get; set; }
        public int? codeDest { get; set; }
        public string libelleDest { get; set; }
        public decimal? primeHtax { get; set; }
        public decimal? coutPolice { get; set; }
        public decimal? primeTotal { get; set; }
        public decimal? taxe { get; set; }
        public int? codeUtilisateur { get; set; }
        public string  NomUtilisateur { get; set; }
        public int? Id_produit { get; set; }
        public int? Qte { get; set; }
        public int? QteLivree { get; set; }
        public string libelleProduit { get; set; }
        public byte[] Data { get; set; }
        public string type_fichier { get; set; }
        public string Nom_utilisateur { get; set; }
        public byte[] DataR { get; set; }
        public int? code_profil { get; set; }
        public string description_profil { get; set; }

        public string etatNotif { get; set; }




    }
    public class type_serviceDB
    {

        public int id_type { get; set; }
        public string libelle { get; set; }
        public string famille_type { get; set; }
    }
    public class brancheDB
    {

        public int idBranche { get; set; }
        public string libelle { get; set; }

    }

    public class sous_brancheDB
    {

        public int Id_sous_branche { get; set; }
        public string libelle { get; set; }
        public int Id_branche { get; set; }

    }
    public class adresseDB

    {
        public int code_adresse { get; set; }
        public string libelle { get; set; }
        public string rue { get; set; }
        public string code_postal { get; set; }
        public string ville { get; set; }
        public string gouvernerat { get; set; }
        public string pays { get; set; }
        public string tel { get; set; }
        public string fax { get; set; }

        public string email { get; set; }
        public string site_web { get; set; }

    }
    public class notificationDB
    {

        public int codeNotification { get; set; }
        public string contenuNotification { get; set; }
        public string etatNotif { get; set; }
        public DateTime? dateNotification { get; set; }
        public int codeService{ get; set; }
        public string libelleService { get; set; }
        public int idType { get; set; }
        public int codeUtilisateur { get; set; }
        public string NomUtilisateur { get; set; }

    }

    public class statistiquesDB
    {

        public string Agence { get; set; }
        public double? Annee { get; set; }
        public double? Mois { get; set; }       
        public string Branche { get; set; }
        public string SousBranche { get; set; }
        public double? Sinistre { get; set; }
        public double? Prime { get; set; }
        public double? SP { get; set; }
        public double? Comission { get; set; }
    }


}

