using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Astree
{
    public partial class AjouterPermission : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["code_utilisateur"] == null)
            {
                Response.Redirect("login.aspx");
            }
            if (!this.IsPostBack)
            {
                ImageButton1.Visible = false;
                PnlPer.Visible = false;
                this.BindGrid();
            }
        }
        private void BindGrid()
        {
            AstreeDonnees a = new AstreeDonnees();
            gv_Permission.DataSource = a.GetPermission();
            gv_Permission.DataBind();
        }
        protected void BtnAjoutPermission_Click(object sender, EventArgs e)
        {


            bool validDescription = false;


            if (String.IsNullOrEmpty(txtdescription.Text))
            {


                lblMessage1.Visible = true;
                MsgDesc.Text = "veuillez remplir  description!";
            }
            else
            {
                lblMessage1.Visible = false;
                AstreeDonnees a = new AstreeDonnees();
                List<permissionDB> lstpermission = a.GetPermission();

                if (lstpermission.Where(w => w.description == txtdescription.Text).Count() > 0)
                {
                    lblMessage1.Visible = true;
                    MsgDesc.Text = "Description existant!";
                }
                else
                {
                    validDescription = true;
                }
            }
            if ((validDescription))
            {
                AstreeDonnees ad = new AstreeDonnees();
                permissionDB permiss = new permissionDB();
                ////permiss.code = Convert.ToInt16(txtcode.Text);
                permiss.description = txtdescription.Text;




                ad.InsertPermission(permiss);
                DataBind();
                this.BindGrid();
            }
        }


        protected void Ajouter_Click(object sender, ImageClickEventArgs e)
        {
            PnlPer.Visible = true;
            Ajouter.Visible = false;
            ImageButton1.Visible = true;
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {

            PnlPer.Visible = false;
            Ajouter.Visible = true;
            ImageButton1.Visible = false;
        }











    }
}
