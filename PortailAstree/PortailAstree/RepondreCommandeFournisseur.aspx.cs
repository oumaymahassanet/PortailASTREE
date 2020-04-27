using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Net.Mail;
using System.Net;
using Astree;


public partial class RepondreCommandeFournisseur : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //AstreeDonnees a = new AstreeDonnees();
        //serviceDB S = a.GetServices().Where(w => w.libelleService == "Commande" && w.code_dest == 4).FirstOrDefault();
        // txtDate.Text = S.dateDemande.ToString();
        //txtNom.Text = S.Nom_utilisateur;
        //  txtContenu.Text = "Demande de commande";
        MsgCode.Text = "";
        MsgEtat.Text = "";
        MsgReponse.Text = "";
        lblMsgSucces.Text = "";
        if (!this.IsPostBack)
        {
            description.Visible = false;
            this.BindGrid();
            //importerF.Attributes.Add("onclick", "document.getElementById('" + FileUpload1.ClientID + "').click();return false;");
        }
    }
    private void BindGrid()
    {
        try
        {

            AstreeDonnees a = new AstreeDonnees();

            List<DetailCommandeDB> ls = a.GetDetailCommande().Where(w => w.LibelleService.Trim() == "Commande" && w.code_dest == Convert.ToInt16(Session["code_utilisateur"].ToString())).OrderBy(w=>w.etat).ThenByDescending(w=>w.dateDemande).ToList();
            gv_Commande.DataSource = ls;
            gv_Commande.DataBind();
            foreach (GridViewRow row in gv_Commande.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    CheckBox cb = (row.Cells[0].FindControl("Accepter") as CheckBox);

                    DetailCommandeDB serv = ls.Where(w => w.code_service == Convert.ToInt16(row.Cells[1].Text.ToString().Trim())).FirstOrDefault();
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
        catch (Exception ex)
        {
        }

    }
    protected void gv_Commande_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow row = gv_Commande.SelectedRow;
        txtcodeService.Text = row.Cells[1].Text;
        txtCode.Text = row.Cells[3].Text;
        txtProduit.Text=row.Cells[4].Text;
        CheckBox cb = (CheckBox)row.FindControl("Accepter");
        if (cb != null && cb.Checked)
        {
           // txtEtat.Text = "VALIDEE";
        }

    }
    protected void gv_Commande_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        GridViewRow row = gv_Commande.Rows[e.NewSelectedIndex];
    }
    //protected void DownloadFile(object sender, EventArgs e)
    //{
    //    int id = int.Parse((sender as LinkButton).CommandArgument);
    //    byte[] bytes;
    //    AstreeDonnees a = new AstreeDonnees();
    //    fichierServiceDB F = new fichierServiceDB();
    //    F = a.GetFichier().Where(w => w.code_service == 21).FirstOrDefault();
    //    bytes = (byte[])F.Data;
    //    Response.Clear();
    //    Response.Buffer = true;
    //    Response.Charset = "";
    //    Response.Clear();
    //    Response.ContentType = "application/pdf";
    //    Response.Cache.SetCacheability(HttpCacheability.NoCache);
    //    Response.AppendHeader("Content-Description", "F DOWNOALD");
    //    Response.AppendHeader("Content-Transfer-Encoding", "binary\n");
    //    Response.AppendHeader("Content-Disposition", "attachment; filename=aaa.pdf");
    //    //   Response.TransmitFile(Server.MapPath("~/Files/Serverside.pdf"));

    //    Response.BinaryWrite(bytes);
    //    Response.Flush();
    //    Response.End();
    //}
    protected void Accepter_CheckedChanged(object sender, EventArgs e)
    {
        foreach (GridViewRow row in gv_Commande.Rows)
        {
            if (row.RowType == DataControlRowType.DataRow)
            {
                CheckBox cb = (row.Cells[0].FindControl("Accepter") as CheckBox);
                if (cb.Checked)
                {
                   // txtEtat.Text = "VALIDEE";
                }
            }
        }



    }
    protected void Btnreponse_Click(object sender, EventArgs e)
    {
        MsgCode.Text = "";
        MsgEtat.Text = "";
        MsgReponse.Text = "";

        try
        {

            AstreeDonnees a = new AstreeDonnees();
            serviceDB lstService = a.GetServices().Where(w => w.libelleService.Trim() == "Commande" && w.code_service == Convert.ToInt16(txtcodeService.Text)).FirstOrDefault();


          



            if (txtCode.Text == "")
            {
                MsgCode.Visible = true;
                MsgCode.Text = "Vous devez selectionner une commande !";
            }
            //else if (txtEtat.Text == "")
            //{
            //    MsgEtat.Visible = true;
            //    MsgEtat.Text = "Vous devez valider la commande !";
            //}
            else if (txtReponse.Text == "")
            {
                MsgReponse.Visible = true;
                MsgReponse.Text = "Vous devez sasir votre réponse !";
            }
            else
            {

                DetailCommandeDB detailComm = a.GetDetailCommande().Where(w => w.LibelleService.Trim() == "Commande"  && w.code_service == lstService.code_service && w.LibelleProduit.Trim() == txtProduit.Text.Trim()).FirstOrDefault();

                if (detailComm != null)
                {

                    detailComm.reponse = txtReponse.Text;
                    detailComm.QteLivree = detailComm.Qte;
                    a.maj_DetailCommande(detailComm);

                }

                List<DetailCommandeDB> lstDetailComm = a.GetDetailCommande().Where(w => w.LibelleService.Trim() == "Commande" && w.code_dest == Convert.ToInt16(Session["code_utilisateur"].ToString()) && w.code_service == lstService.code_service && w.QteLivree == 0).ToList();

                if (lstService != null && lstDetailComm.Count == 0)
                {
                    lstService.etat = "V";
                    lstService.dateReponse = DateTime.Now;
                    lstService.reponse = txtReponse.Text;
                    a.maj_Commande(lstService);
                

                  
                        Label x = (Label)Master.FindControl("lblNotifCommandeFourn") as Label;
                        Label y = (Label)Master.FindControl("nbNotification") as Label;

                        List<serviceDB> lsNotification = a.GetServices().Where(w => (w.libelleService != null) && (w.etat.Trim() == "A") && (w.codeDest == Convert.ToInt16(Session["code_utilisateur"]))).ToList();
                        x.Text = lsNotification.Where(w => w.libelleService.Trim() == "Commande" ).Count().ToString();
                        y.Text = x.Text;
                        BindGrid();
                   
                }

                lblMsgSucces.Visible = true;
                lblMsgSucces.Text = "Reponse envoyé avec succés!";
                txtCode.Text = "";
                txtcodeService.Text = "";
                //txtEtat.Text = "";
                txtReponse.Text = "";


                List<DetailCommandeDB> ls = a.GetDetailCommande().Where(w => w.LibelleService.Trim() == "Commande" && w.code_dest == Convert.ToInt16(Session["code_utilisateur"].ToString())).ToList();
                gv_Commande.DataSource = ls;
                gv_Commande.DataBind();
            }
        }
        catch (Exception ex)
        {
            MsgCode.Visible = true;
            MsgCode.Text = "Vous devez selectionner une commande !";
        }
    }

    //protected void DownloadFileIndexe(object sender, EventArgs e)
    //{
    //    int id = int.Parse((sender as LinkButton).CommandArgument);
    //    byte[] bytes;
    //    AstreeDonnees a = new AstreeDonnees();
    //    fichierIndexeDB F = new fichierIndexeDB();
    //    F = a.GetFichierIndexe().Where(w => w.code_service == id).FirstOrDefault();
    //    bytes = (byte[])F.DataR;
    //    Response.Clear();
    //    Response.Buffer = true;
    //    Response.Charset = "";
    //    Response.Clear();

    //    Response.Cache.SetCacheability(HttpCacheability.NoCache);
    //    Response.AppendHeader("ContentType", "application/pdf");
    //    Response.AppendHeader("Content-Description", "F DOWNOALD");
    //    Response.AppendHeader("Content-Transfer-Encoding", "binary\n");
    //    Response.AppendHeader("Content-Disposition", "attachment; filename=aaa.pdf");
    //    //Response.TransmitFile(Server.MapPath("~/Files/Serverside.pdf"));

    //    Response.BinaryWrite(bytes);
    //    Response.Flush();
    //    Response.End();

    //}

    protected void gv_Commande_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {

            AstreeDonnees a = new AstreeDonnees();

             
            foreach (GridViewRow row in gv_Commande.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {


                    serviceDB serv = a.GetServices().Where(w => (w.libelleService != null) && (w.libelleService.Trim() == "Commande") && w.codeDest == Convert.ToInt16(Session["code_utilisateur"].ToString()) && (w.code_service == Convert.ToInt32(row.Cells[1].Text))).FirstOrDefault();


                    if (serv != null)
                    {

                        if (serv.etat.Trim() == "V")
                        {
                            
                                //e.Row.BackColor = System.Drawing.Color.Red;
                                row.ForeColor = System.Drawing.Color.Green;
                          
                        }

                        if (serv.etat.Trim() == "A")
                        {
                            row.ForeColor = System.Drawing.Color.Red;
                        }
                    }

                }

            }
        }
        catch (Exception ex)
        {
        }
    }
}