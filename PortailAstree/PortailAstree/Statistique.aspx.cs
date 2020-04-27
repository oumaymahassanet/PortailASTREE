using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.DataVisualization.Charting;
namespace Astree
{
    public partial class Statistique : System.Web.UI.Page
    {
        Dictionary<DateTime, int> testData = new Dictionary<DateTime, int>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["code_utilisateur"] == null)
            {
                Response.Redirect("login.aspx");
            }


            if (!IsPostBack)
            {
                // bind chart type names to ddl

                ddlChartType.DataSource = Enum.GetNames(typeof(SeriesChartType));
                ddlChartType.DataBind();

                foreach (ListItem ite in ddlChartType.Items)
                {
                    if (ite.Text == "Column")
                    {
                        ite.Selected = true;
                    }
                }
                
                AstreeDonnees a = new AstreeDonnees();
                UtilisateurDB user = a.GetUser(Convert.ToInt16(Session["code_utilisateur"].ToString()));
                List<statistiquesDB> lsStat = a.GetStatistiques().Where(w => w.Agence == user.code_partenaire.ToString()).ToList();
                Session["lstStat"] = lsStat;
                gv_statistiques.DataSource = lsStat;
                gv_statistiques.DataBind();
                //DataBind();
                getAnnee();
                getBranche();
                getCharte();

            }

        }
        private void getCharte()
        {
            AstreeDonnees a = new AstreeDonnees();
            UtilisateurDB user = a.GetUser(Convert.ToInt16(Session["code_utilisateur"].ToString()));


            List<statistiquesDB> lsStat = a.GetStatistiques().Where(w => w.Agence == user.code_partenaire.ToString()).ToList();
            
            string annee = "";
            if (ddlAnnee.SelectedIndex == 0)
            {

            }
            else
            {
                annee = ddlAnnee.SelectedValue;
                if (ddlBranche.SelectedIndex > 0)
                {
                    lsStat = a.GetStatistiques().Where(w => (w.Agence == user.code_partenaire.ToString()) && (w.Branche == ddlBranche.SelectedValue) && w.Annee == Convert.ToInt16(annee)).ToList();
                }
                else
                {
                    lsStat = a.GetStatistiques().Where(w => (w.Annee == Convert.ToInt16(annee) && (w.Agence == user.code_partenaire.ToString()))).ToList();
                }

                gv_statistiques.DataSource = lsStat;
                gv_statistiques.DataBind();
            }
            string branch = "";
            if (ddlBranche.SelectedIndex == 0)
            {

            }
            else
            {
                branch = ddlBranche.SelectedValue;
                if (ddlAnnee.SelectedIndex > 0)
                {
                    lsStat = a.GetStatistiques().Where(w => (w.Agence == user.code_partenaire.ToString()) && (w.Branche == branch.ToString()) && (w.Annee == Convert.ToInt16(annee))).ToList();
                }
                else
                {
                    lsStat = a.GetStatistiques().Where(w => (w.Agence == user.code_partenaire.ToString()) && (w.Branche == branch.ToString())).ToList();
                }

                string sousBranch = "";
                if (ddlSousBranche.SelectedIndex <= 0)
                {

                }
                else
                {

                    lsStat = a.GetStatistiques().Where(w => (w.Agence == user.code_partenaire.ToString()) && (w.Branche == branch.ToString())&&(w.SousBranche==ddlSousBranche.SelectedValue.ToString().Trim()) && (w.Annee == Convert.ToInt16(annee))).ToList();
                    gv_statistiques.DataSource = lsStat;
                    gv_statistiques.DataBind();
                }

                gv_statistiques.DataSource = lsStat;
                gv_statistiques.DataBind();
            }
            



            int i = 0;
            string[] x = new string[lsStat.Count];
            decimal[] y = new decimal[lsStat.Count];
            decimal[] z = new decimal[lsStat.Count];
            decimal[] u = new decimal[lsStat.Count];
            decimal[] o = new decimal[lsStat.Count];
            string[] b = new string[lsStat.Count];


            foreach (statistiquesDB t in lsStat)
            {

                if (t.Mois == 1)
                {
                    x[i] = "Janvier";
                }
                if (t.Mois == 2)
                {
                    x[i] = "Février";
                }
                if (t.Mois == 3)
                {
                    x[i] = "Mars";
                }
                if (t.Mois == 4)
                {
                    x[i] = "Avril";
                }
                if (t.Mois == 5)
                {
                    x[i] = "Mai";
                }
                if (t.Mois == 6)
                {
                    x[i] = "Juin";
                }
                if (t.Mois == 7)
                {
                    x[i] = "Juillet";
                }
                if (t.Mois == 8)
                {
                    x[i] = "Aout";
                }
                if (t.Mois == 9)
                {
                    x[i] = "Septembre";
                }
                if (t.Mois == 10)
                {
                    x[i] = "Octobre";
                }
                if (t.Mois == 11)
                {
                    x[i] = "Novembre";
                }
                if (t.Mois == 12)
                {
                    x[i] = "Décembre";
                }
                y[i] = Convert.ToDecimal(t.Sinistre);
                i = i + 1;
                //if (ddlAnnee.SelectedValue.)
                //{

                //}
                chartSinistre.Series["serieSinistre"].Points.DataBindXY(x, y);
                //chartSinistre.Series["serieSinistre"].ChartType = SeriesChartType.Column;
                chartSinistre.Series["serieSinistre"].ChartTypeName = ddlChartType.SelectedValue;
                chartSinistre.ChartAreas["ChartAreaSinistre"].Area3DStyle.Enable3D = cbUse3D.Checked;
                chartSinistre.ChartAreas["ChartAreaSinistre"].Area3DStyle.Inclination = Convert.ToInt32(rblInclinationAngle.SelectedValue);
                chartSinistre.Legends["Default"].Enabled = true;
            }

            ////Prime
            i = 0;
            foreach (statistiquesDB t in lsStat)
            {

                // x[i] = t.Mois;
                z[i] = Convert.ToDecimal(t.Prime);
                i = i + 1;

                chartPrime.Series["seriePrime"].Points.DataBindXY(x, z);
                //chartPrime.Series["seriePrime"].ChartType = SeriesChartType.Column;
                chartPrime.Series["seriePrime"].ChartTypeName = ddlChartType.SelectedValue;
                chartPrime.ChartAreas["ChartAreaPrime"].Area3DStyle.Enable3D = cbUse3D.Checked;
                chartPrime.ChartAreas["ChartAreaPrime"].Area3DStyle.Inclination = Convert.ToInt32(rblInclinationAngle.SelectedValue);
                chartPrime.Legends["Default"].Enabled = true;
            }
            ////Comission
            i = 0;
            foreach (statistiquesDB t in lsStat)
            {


                u[i] = Convert.ToDecimal(t.Comission);
                i = i + 1;

                chartComission.Series["serieComission"].Points.DataBindXY(x, u);
                //chartPrime.Series["seriePrime"].ChartType = SeriesChartType.Column;
                chartComission.Series["serieComission"].ChartTypeName = ddlChartType.SelectedValue;
                chartComission.ChartAreas["ChartAreaComission"].Area3DStyle.Enable3D = cbUse3D.Checked;
                chartComission.ChartAreas["ChartAreaComission"].Area3DStyle.Inclination = Convert.ToInt32(rblInclinationAngle.SelectedValue);
                chartComission.Legends["Default"].Enabled = true;
            }
            ////SP
            i = 0;
            foreach (statistiquesDB t in lsStat)
            {

                //x[i] = t.Mois;
                o[i] = Convert.ToDecimal(t.SP);
                i = i + 1;

                chartSP.Series["serieSP"].Points.DataBindXY(x, o);
                //chartSP.Series["serieSP"].ChartType = SeriesChartType.Column;
                chartSP.Series["serieSP"].ChartTypeName = ddlChartType.SelectedValue;
                chartSP.ChartAreas["ChartAreaSP"].Area3DStyle.Enable3D = cbUse3D.Checked;
                chartSP.ChartAreas["ChartAreaSP"].Area3DStyle.Inclination = Convert.ToInt32(rblInclinationAngle.SelectedValue);
                chartSP.Legends["Default"].Enabled = true;
            }

            // // // // // // // // // // // // // // // // // // // // //
            //        //Sinistre
            //        i = 0;
            //        foreach (statistiquesDB t in lsStat)
            //        {
            //            b[i] = t.Branche;
            //            y[i] = Convert.ToDecimal(t.Sinistre);
            //        i = i + 1;

            //        chartSinistre.Series["serieSinistre"].Points.DataBindXY(b, y);
            //        //chartSinistre.Series["serieSinistre"].ChartType = SeriesChartType.Column;
            //        chartSinistre.Series["serieSinistre"].ChartTypeName = ddlChartType.SelectedValue;
            //        chartSinistre.ChartAreas["ChartAreaSinistre"].Area3DStyle.Enable3D = cbUse3D.Checked;
            //        chartSinistre.ChartAreas["ChartAreaSinistre"].Area3DStyle.Inclination = Convert.ToInt32(rblInclinationAngle.SelectedValue);
            //        chartSinistre.Legends["Default"].Enabled = true;
            //    }

            //    ////Prime
            //    i = 0;
            //        foreach (statistiquesDB t in lsStat)
            //        {

            //            b[i] = t.Branche;
            //            z[i] = Convert.ToDecimal(t.Prime);
            //            i = i + 1;

            //            chartPrime.Series["seriePrime"].Points.DataBindXY(b, z);
            //            //chartPrime.Series["seriePrime"].ChartType = SeriesChartType.Column;
            //            chartPrime.Series["seriePrime"].ChartTypeName = ddlChartType.SelectedValue;
            //            chartPrime.ChartAreas["ChartAreaPrime"].Area3DStyle.Enable3D = cbUse3D.Checked;
            //            chartPrime.ChartAreas["ChartAreaPrime"].Area3DStyle.Inclination = Convert.ToInt32(rblInclinationAngle.SelectedValue);
            //            chartPrime.Legends["Default"].Enabled = true;
            //        }
            //////Comission
            //i = 0;
            //        foreach (statistiquesDB t in lsStat)
            //        {

            //            b[i] = t.Branche;
            //            u[i] = Convert.ToDecimal(t.Comission);
            //            i = i + 1;

            //            chartComission.Series["serieComission"].Points.DataBindXY(b, u);
            //            //chartPrime.Series["seriePrime"].ChartType = SeriesChartType.Column;
            //            chartComission.Series["serieComission"].ChartTypeName = ddlChartType.SelectedValue;
            //            chartComission.ChartAreas["ChartAreaComission"].Area3DStyle.Enable3D = cbUse3D.Checked;
            //            chartComission.ChartAreas["ChartAreaComission"].Area3DStyle.Inclination = Convert.ToInt32(rblInclinationAngle.SelectedValue);
            //            chartComission.Legends["Default"].Enabled = true;
            //        }

            //        ////SP
            //        i = 0;
            //        foreach (statistiquesDB t in lsStat)
            //        {

            //            b[i] = t.Branche;
            //            o[i] = Convert.ToDecimal(t.SP);
            //            i = i + 1;

            //            chartSP.Series["serieSP"].Points.DataBindXY(b, o);
            //            //chartSP.Series["serieSP"].ChartType = SeriesChartType.Column;
            //            chartSP.Series["serieSP"].ChartTypeName = ddlChartType.SelectedValue;
            //            chartSP.ChartAreas["ChartAreaSP"].Area3DStyle.Enable3D = cbUse3D.Checked;
            //            chartSP.ChartAreas["ChartAreaSP"].Area3DStyle.Inclination = Convert.ToInt32(rblInclinationAngle.SelectedValue);
            //            chartSP.Legends["Default"].Enabled = true;
            //        }




        }






        private void getAnnee()
        {
            AstreeDonnees a = new AstreeDonnees();
            UtilisateurDB user = a.GetUser(Convert.ToInt16(Session["code_utilisateur"].ToString()));

            List<statistiquesDB> lsStat = a.GetStatistiques().Where(w => w.Agence == user.code_partenaire.ToString()).ToList();
            var lst = lsStat.Select(w => w.Annee);
            List<double?> lstAnnee = lst.Distinct().ToList();

            List<ListItem> itemsAnnee = new List<ListItem>();

            itemsAnnee.Add(new ListItem("--Choisir", "--Choisir"));
            foreach (int x in lstAnnee)
            {
                itemsAnnee.Add(new ListItem(x.ToString(), x.ToString()));
            }

            ddlAnnee.Items.AddRange(itemsAnnee.ToArray());

        }
        private void getBranche()
        {
            AstreeDonnees a = new AstreeDonnees();
            UtilisateurDB user = a.GetUser(Convert.ToInt16(Session["code_utilisateur"].ToString()));

            List<statistiquesDB> lsStat = a.GetStatistiques().Where(w => w.Agence == user.code_partenaire.ToString()).ToList();
            var lst2 = lsStat.Select(w => w.Branche);
            List<string> lstBranche = lst2.Distinct().ToList();

            List<ListItem> itemsBranche = new List<ListItem>();

            itemsBranche.Add(new ListItem("--Choisir--", "--Choisir--"));
            foreach (string x in lstBranche)
            {
                itemsBranche.Add(new ListItem(x, x));
            }

            ddlBranche.Items.AddRange(itemsBranche.ToArray());
        }


        protected void ddlChartType_SelectedIndexChanged(object sender, EventArgs e)
        {
            getCharte();
        }

        protected void cbUse3D_CheckedChanged(object sender, EventArgs e)
        {
            getCharte();
            
        }

        protected void rblInclinationAngle_SelectedIndexChanged(object sender, EventArgs e)
        {
            getCharte();
        }





        protected void ddlAnnee_SelectedIndexChanged(object sender, EventArgs e)
        {
            getCharte();
        }

        protected void ddlBranche_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlSousBranche.Items.Clear();
            AstreeDonnees a = new AstreeDonnees();
            UtilisateurDB user = a.GetUser(Convert.ToInt16(Session["code_utilisateur"].ToString()));

            List<statistiquesDB> lsStat = a.GetStatistiques().Where(w => w.Agence == user.code_partenaire.ToString()).ToList();
            var lst = lsStat.Where(w => w.Branche == ddlBranche.SelectedValue).Select(w => w.SousBranche);
            List<string> lstSousBranche = lst.Distinct().ToList();
            List<ListItem> itemsSousBranche = new List<ListItem>();

            itemsSousBranche.Add(new ListItem("--Choisir--", "--Choisir--"));
            foreach (string x in lstSousBranche)
            {
                itemsSousBranche.Add(new ListItem(x, x));
            }

            ddlSousBranche.Items.AddRange(itemsSousBranche.ToArray());

            getCharte();
        }

        protected void ddlSousBranche_SelectedIndexChanged(object sender, EventArgs e)
        {

            getCharte();
        }

        

        protected void gv_statistiques_PageIndexChanging1(object sender, GridViewPageEventArgs e)
        {
            gv_statistiques.PageIndex = e.NewPageIndex;
            gv_statistiques.DataSource = Session["lstStat"];
            gv_statistiques.DataBind();
            gv_statistiques.SelectedIndex = -1;

        }
    }
}