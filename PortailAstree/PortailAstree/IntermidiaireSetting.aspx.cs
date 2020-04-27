using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows;
using System.IO;






namespace Astree
{

    public partial class IntermidiaireSetting : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
          
            if (Session["code_utilisateur"] == null)
            {
                Response.Redirect("login.aspx");
            }
            if (!IsPostBack)
            {

                if (Session["code_utilisateur"] != null)
                {
                    AstreeDonnees a = new AstreeDonnees();
                    UtilisateurDB user = a.GetUser(Convert.ToInt16(Session["code_utilisateur"].ToString()));
                    adresseDB adr = a.GetAdresse(user).FirstOrDefault();
                    //img=ConvertbyteToImage(user.Image);
                  Txttel.Text = adr.tel;

                    Txtgouvernerat.Text = adr.gouvernerat;
                    TxtVille.Text = adr.ville;
                    TxTUserProfil.Text = user.description_profil;
                }
                else
                {
                    Response.Redirect("login.aspx");
                }


            }
            importerF.Attributes.Add("onclick", "document.getElementById('" + FileUpload1.ClientID + "').click();return false;");
        }


        protected void Btnsave_Click(object sender, EventArgs e)
        {
           

            if (Txtpsw.Text=="") {
                txtPasse2.Text = "";
                MsgPasse.Text = "Vous devez saisir votre mot de passe!";
                Txtpsw.Focus();
            }
          
            else if (txtpsw2.Text=="") {
                
                txtpsw2.Focus();
                MsgPasse.Text = "";
                txtPasse2.Text = "Vous devez retaper votre mot de passe";
            }
            else if (txtpsw2.Text.Trim()!= Txtpsw.Text.Trim()) {
                txtpsw2.Focus();
                txtpsw2.Text = "";
                MsgPasse.Text = "";
                txtPasse2.Text = "Les deux mot de passe ne sont pas identique!";
            }
            else {
                System.Drawing.Image.FromStream(FileUpload1.PostedFile.InputStream);
                System.Drawing.Image imag = System.Drawing.Image.FromStream(FileUpload1.PostedFile.InputStream);
                txtPasse2.Text = "";
                MsgPasse.Text = "";
                AstreeDonnees astrDonnes = new AstreeDonnees();

                UtilisateurDB usr = astrDonnes.GetUser(Convert.ToInt16(Session["code_utilisateur"]));
                adresseDB adr = astrDonnes.GetAdresse(usr).FirstOrDefault();

                adr.ville = TxtVille.Text;
                adr.tel = Txttel.Text;
                adr.gouvernerat = Txtgouvernerat.Text;
                usr.Mdp = Txtpsw.Text;
              
                byte[] tab = ConvertImageToByteArray(imag, System.Drawing.Imaging.ImageFormat.Jpeg); ;
                usr.Image = tab;

                astrDonnes.modifierUtilisateur(usr);
                astrDonnes.modifierAdresse(adr);
                //lblMsgSucces.Visible = true;
                //lblMsgSucces.Text = "Modification Terminée";

            }

        }

        protected void DownloadFileIndexe(object sender, EventArgs e)
        {
            //int id = int.Parse((sender as LinkButton).CommandArgument);
            //byte[] bytes;
            //AstreeDonnees a = new AstreeDonnees();
            //UtilisateurDB F = new UtilisateurDB();
            //F = a.GetUser().Where(w => w.code_utilisateur == Convert.ToInt16(Session["code_utilisateur"].ToString())).FirstOrDefault();
            //bytes = F.Image;
            //Response.Clear();
            //Response.Buffer = true;
            //Response.Charset = "";
            //Response.Clear();
            


            //Response.Cache.SetCacheability(HttpCacheability.NoCache);
            //Response.AppendHeader("ContentType", "application/pdf");
            //Response.AppendHeader("Content-Description", "F DOWNOALD");
            //Response.AppendHeader("Content-Transfer-Encoding", "binary\n");
            //Response.AppendHeader("Content-Disposition", "attachment; filename=aaa.pdf");
            ////Response.TransmitFile(Server.MapPath("~/Files/Serverside.pdf"));

            //Response.BinaryWrite(bytes);
            //Response.Flush();
            //Response.End();

        }

        protected void importer_Click(object sender, EventArgs e)
        {
           
        }
        // insérer une image
        public byte[] ConvertImageTobyte(string path)
        {
            byte[] result = null;
            using (FileStream oFileStream = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                result = new byte[oFileStream.Length];
                oFileStream.Read(result, 0, (int)oFileStream.Length);
            }

            return result;
        }
        // affichage de l'image
        private Bitmap ConvertbyteToImage(byte[] ImageBuffer)
        {
            Bitmap result = null;
            using (MemoryStream oMemoryStream = new MemoryStream(ImageBuffer, true))
            {
                oMemoryStream.Write(ImageBuffer, 0, ImageBuffer.Length);
                result = new Bitmap(oMemoryStream);
            }
            return result;
        }

        // fonction
        private byte[] ConvertImageToByteArray(System.Drawing.Image imageToConvert,System.Drawing.Imaging.ImageFormat formatOfImage)
        {
            byte[] Ret;
            try
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    imageToConvert.Save(ms, formatOfImage);
                    Ret = ms.ToArray();
                }
            }
            catch (Exception) { throw; }
            return Ret;
        }


    
    }
}
