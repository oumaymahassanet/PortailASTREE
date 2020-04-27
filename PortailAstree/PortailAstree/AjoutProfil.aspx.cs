using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Astree
{
    public partial class AjoutProfil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                PnlProfil.Visible = false;
                // PnlAffecter.Visible = false;
                lblMessage1.Visible = true;
                this.BindGrid();
            }
        }
        private void BindGrid()
        {
            AstreeDonnees a = new AstreeDonnees();
            gv_Profil.DataSource = a.GetProfil().Where(w=>w.code!=0);
            gv_Profil.DataBind();
        }
        protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string codeProfil = gv_Profil.DataKeys[e.Row.RowIndex].Value.ToString();
                GridView gvPermission = e.Row.FindControl("gvPermission") as GridView;//Recherche gridview

                AstreeDonnees a = new AstreeDonnees();
                List<affecterDB> lsPermission = a.GetAffecter().Where(w => w.codeProfil == Convert.ToInt32(codeProfil)).ToList();

                gvPermission.DataSource = lsPermission;
                gvPermission.DataBind();
            }
        }
        protected void BtnAjoutProfil_Click(object sender, EventArgs e)
        {
            // MsgCode.Text = "";
            MsgProfil.Text = "";
            bool validCode = false;
            bool validLibelle = false;
            if (String.IsNullOrEmpty((txtcode.Text)))
            {

                MsgCode.Text = "veuillez remplir votre code";
            }

            else if (String.IsNullOrEmpty(txtlibelle.Text))
            {

                MsgCode.Text = "";
                MsgProfil.Text = "veuillez remplir votre libelle";
            }
            else
            {
                lblMessage1.Visible = false;
                AstreeDonnees a = new AstreeDonnees();
                List<profilDB> lstprofil = a.GetProfil();
                try
                {
                    if (lstprofil.Where(w => w.code == Convert.ToInt16(txtcode.Text.ToString())).Count() > 0)
                    {
                        lblMessage1.Visible = true;
                        lblMessage1.Text = "code existant!";


                    }
                    else
                    {
                        MsgCode.Text = "";
                        MsgProfil.Text = "";
                        lblMessage1.Visible = false;
                        validCode = true;

                    }
                    if (lstprofil.Where(w => w.libelle == txtlibelle.Text).Count() > 0)
                    {
                        lblMessage1.Visible = true;
                        lblMessage1.Text = "Libelle existant";


                    }
                    else
                    {
                        if (validCode)
                        {
                            lblMessage1.Visible = false;
                            validLibelle = true;
                        }

                    }
                }
                catch
                {
                    MsgCode.Text = "Le code doit étre un entier!";
                }

            }
            if ((validCode) && (validLibelle))
            {
                AstreeDonnees ad = new AstreeDonnees();
                profilDB profl = new profilDB();
                try
                {
                    profl.code = Convert.ToInt16(txtcode.Text.ToString());
                    profl.libelle = txtlibelle.Text;
                    ad.InsertProfil(profl);
                    lblMessage1.Visible = true;
                    lblMessage1.Text = "Ajout fait avec succés!";
                    // PnlAffecter.Visible = true;
                }
                catch
                {

                    MsgCode.Text = "Le code doit étre un entier!!";
                }





                // insert affec


                DataBind();
                BindGrid();
            }
        }

        protected void gv_Profil_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = gv_Profil.SelectedRow;
            txtcode.Text = row.Cells[2].Text;
            txtlibelle.Text = row.Cells[3].Text;

            MessageLabel.Text = "You selected " + row.Cells[3].Text + ".";
        }

        protected void gv_Profil_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            GridViewRow row = gv_Profil.Rows[e.NewSelectedIndex];

        }





        protected void btnMoveAll_Click(object sender, ImageClickEventArgs e)
        {
            lstChoisies.Items.Clear();
            foreach (ListItem li in lstpermission.Items)

            {

                lstChoisies.Items.Add(li);

            }

        }

        protected void btnRemoveAll_Click(object sender, ImageClickEventArgs e)
        {
            lstChoisies.Items.Clear();
        }

        //protected void lstpermission_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    ListItem itemChoisi = new ListItem(lstpermission.SelectedValue, lstpermission.SelectedItem.Text);
        //    lstChoisies.Items.Add(itemChoisi);
        //}

        //protected void lstChoisies_SelectedIndexChanged(object sender, EventArgs e)
        //{

        //}

        protected void btnRemoveOne_Click(object sender, ImageClickEventArgs e)
        {
            ListItemCollection lstItems = new ListItemCollection();
            // lstItems = lstChoisies.Items;


            foreach (ListItem li in lstChoisies.Items)

            {
                if (li.Selected)

                {

                    //lstItems.Remove(li);

                }
                else
                {
                    lstItems.Add(li);
                }
            }

            lstChoisies.Items.Clear();
            foreach (ListItem li in lstItems)

            {

                lstChoisies.Items.Add(li);


            }
        }

        protected void btnAddOne_Click(object sender, ImageClickEventArgs e)
        {
            foreach (ListItem li in lstpermission.Items)

            {



                if (li.Selected)

                {

                    lstChoisies.Items.Add(li);

                }



            }
        }

        protected void btnAffecter_Click(object sender, EventArgs e)
        {
            AstreeDonnees ad = new AstreeDonnees();
            affecterDB aff = new affecterDB();
            List<affecterDB> lstAffect = ad.GetAffecter();
            affecterDB z = new affecterDB();
            if (txtcode.Text != "")
            {
                List<affecterDB> lstAff = new List<affecterDB>();
                foreach (ListItem x in lstChoisies.Items)
                {
                    aff = new affecterDB();
                    aff.codePermission = Convert.ToInt16(x.Value);
                    aff.codeProfil = Convert.ToInt16(txtcode.Text);
                    z = lstAffect.Where(w => (w.codeProfil == aff.codeProfil) && (w.codePermission == aff.codePermission)).FirstOrDefault();

                    if (z == null)
                    {
                        lstAff.Add(aff);
                    }

                }
                if (lstAff.Count > 0)
                {
                    ad.InsertAffecter(lstAff);
                    txtcode.Text = "";
                    txtlibelle.Text = "";
                }

            }


        }
        protected void Ajouter_Click(object sender, ImageClickEventArgs e)
        {
            PnlProfil.Visible = true;
            PnlAffecter.Visible = true;
            Ajouter.Visible = false;
            ImageButton2.Visible = true;
        }

        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {

            PnlProfil.Visible = false;
            Ajouter.Visible = true;
            ImageButton2.Visible = false;
        }
    }
}