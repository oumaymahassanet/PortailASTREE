<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Statistique.aspx.cs" Inherits="Astree.Statistique" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    

	<style type="text/css">
		
		h2 { margin-left:5px; }
		
		.clearfixx:after {
			content: ".";
			display: block;
			clear: both;
			visibility: hidden;
			line-height: 0;
			height: 0;
		}
 
		.clearfixx {
			display: inline-block;
		}
		.boxx{ float:left; width:200px; margin:10px; padding:10px; border:1px solid #ccc; }
	</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="Server">
   <%-- <div class="clearfix">--%>
		<div class="x_title dashboard_graph " >
                 <h2 style="color: #73879C;">Consulter Statistique</h2>
                    <br />
                  <div class="clearfix"> </div>
                </div>
    
		<div class=" dashboard_graph " >

            <h2 style="color:red">Choisir votre critére de choix : </h2>
       

        <div class="row" style="width:auto">
            <div class="col-sm-2">
         <div class="dashboard_graph ">
			

			
            <div  class="dashboard_graph ">

				<h4 style="color:#336199;">Année&nbsp;&nbsp; </h4>
				<p>
                  
					<asp:DropDownList ID="ddlAnnee" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlAnnee_SelectedIndexChanged" Width="120px">
					</asp:DropDownList>

				    <%--<asp:SqlDataSource ID="SqlDataSourceAnnee" runat="server" ConnectionString="<%$ ConnectionStrings:PortailServicesConnectionString %>" SelectCommand="SELECT [Annee] FROM [statistiques] GROUP BY ([Annee])">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="annee" Name="Annee" Type="Int32" />
                        </SelectParameters>
                    </asp:SqlDataSource>--%>

				</p>
			</div>
      <br runat="server" class="well"/>
             <div  class="dashboard_graph ">
				<h4 style="color:#336199">Branche</h4>
				<p>
					<asp:DropDownList ID="ddlBranche" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlBranche_SelectedIndexChanged" Width="120px">
                       
                       
					</asp:DropDownList>
				</p>
			</div>
          <br runat="server" class="well"/>
             <div  class="dashboard_graph ">
				<h4 style="color:#336199">Sous Branche</h4>
				<p>
					<asp:DropDownList ID="ddlSousBranche" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlSousBranche_SelectedIndexChanged" Width="120px">
                        
                       
					</asp:DropDownList>
				</p>
			</div>
                </div>
		
         </div>
           
            <div class="col-sm-2 dashboard_graph ">
                	<div   style="height:385px">
            <h4 style="color:#336199">Type de la charte</h4>
            <p>
					<asp:DropDownList ID="ddlChartType" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlChartType_SelectedIndexChanged" >
					</asp:DropDownList>
				</p>
<br  class="well"/>
			<h4 style="color:#336199">paramètres 3D</h4>
			<p>
				<asp:CheckBox ID="cbUse3D" runat="server" AutoPostBack="True" Text="Utiliser Chart 3D " OnCheckedChanged ="cbUse3D_CheckedChanged" />
			</p>
                        <br class="well" />
			<h4 style="color:#336199">Angle d'inclinaison</h4>
			<p>
				<asp:RadioButtonList ID="rblInclinationAngle" runat="server" AutoPostBack="True" OnSelectedIndexChanged="rblInclinationAngle_SelectedIndexChanged" Width="45px">
					<asp:ListItem Value="-90">-90°</asp:ListItem>
					<asp:ListItem Value="-50">-50°</asp:ListItem>
					<asp:ListItem Value="-20">-20°</asp:ListItem>
					<asp:ListItem Value="0">0°</asp:ListItem>
					<asp:ListItem Selected="True" Value="20">20°</asp:ListItem>
					<asp:ListItem Value="50">50°</asp:ListItem>
					<asp:ListItem Value="90">90°</asp:ListItem>
				</asp:RadioButtonList>
			</p>
		</div>


         </div>
            <div class="col-sm-8">
                	<div  class="dashboard_graph " style ="width:auto;height:443px">
                         <div style="width: 100%; height: 400px; overflow: scroll">
            <asp:gridview  class="table table-striped table-bordered table-hover"  ID="gv_statistiques" runat="server" AutoGenerateColumns="False" 
              OnPageIndexChanging="gv_statistiques_PageIndexChanging1"   AllowPaging="true" PageSize="8"
             backColor="White"  BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" 
             CellPadding="3" CellSpacing="1"  Width="354px" Height="16px" 
        >
                   <RowStyle  ForeColor="#333333" HorizontalAlign="Center" />

             <columns >
                  
                <asp:BoundField  DataField="Agence" HeaderText="Agence" >
                   <ItemStyle HorizontalAlign="Center" />
                 </asp:BoundField>
                   
                 <asp:BoundField DataField="Annee"  HeaderText="Annee" >
                 <ItemStyle HorizontalAlign="Center" />
                 </asp:BoundField>
                 <asp:BoundField DataField="Mois"  HeaderText="Mois" >
                 <ItemStyle HorizontalAlign="Center" />
                 </asp:BoundField>
                 <asp:BoundField DataField="Branche" HeaderText="Branche" >
                 <ItemStyle HorizontalAlign="Center" />
                 </asp:BoundField>  
                 <asp:BoundField  DataField="SousBranche" HeaderText="SousBranche" >
                 <ItemStyle HorizontalAlign="Center" />
                 </asp:BoundField>
                 <asp:BoundField  DataField="Sinistre" HeaderText="Sinistre" >
                 <ItemStyle HorizontalAlign="Center" />
                 </asp:BoundField>
                 <asp:BoundField  DataField="Prime" HeaderText="Prime" >
                 <ItemStyle HorizontalAlign="Center" />
                 </asp:BoundField>
                 <asp:BoundField  DataField="SP" HeaderText="SP" >
                 <ItemStyle HorizontalAlign="Center" />
                 </asp:BoundField>
                  <asp:BoundField  DataField="Comission" HeaderText="Commission" >
                 <ItemStyle HorizontalAlign="Center" />
                 </asp:BoundField>
                 
                 
                
             </columns>
                 
                <PagerStyle BackColor="#8da1b3" ForeColor="White" HorizontalAlign="Center" />
       
         </asp:gridview> 
    </div>
            </div>
         </div>
            </div>

		</div>

	


   <br runat="server" class="well" />

    <div class=" dashboard_graph " >
 
    <div class="clearfixx">
	

        
    <div class="boxx" style="width:auto">
		<asp:Chart ID="chartSinistre" runat="server" Height="450px" Width="450px">
            <Legends>
        <asp:Legend Alignment="Center" Docking="Bottom" IsTextAutoFit="False" Name="Default" LegendStyle="Row" />
    </Legends>
			<Series>
				<asp:Series Name="serieSinistre">
				</asp:Series>
			</Series>
			<ChartAreas>
				<asp:ChartArea Name="ChartAreaSinistre">
					<Area3DStyle />
				</asp:ChartArea>
			</ChartAreas>
		</asp:Chart>
        </div>
    &nbsp;&nbsp;&nbsp;&nbsp;
        <div class="boxx" style="width:auto">
        <asp:Chart ID="chartPrime" runat="server" Height="450px" Width="450px">
            <Legends>
        <asp:Legend Alignment="Center" Docking="Bottom" IsTextAutoFit="False" Name="Default" LegendStyle="Row" />
    </Legends>
			<Series>
				<asp:Series Name="seriePrime">
				</asp:Series>
			</Series>
			<ChartAreas>
				<asp:ChartArea Name="ChartAreaPrime">
					<Area3DStyle />
				</asp:ChartArea>
			</ChartAreas>
		</asp:Chart>
            </div>
        </div>
        <div class="clearfixx">
        <div class="boxx" style="width:auto">
        <asp:Chart ID="chartComission" runat="server" Height="450px" Width="450px">
            <Legends>
        <asp:Legend Alignment="Center" Docking="Bottom" IsTextAutoFit="False" Name="Default" LegendStyle="Row" />
    </Legends>
			<Series>
				<asp:Series Name="serieComission">
				</asp:Series>
			</Series>
			<ChartAreas>
				<asp:ChartArea Name="ChartAreaComission">
					<Area3DStyle />
				</asp:ChartArea>
			</ChartAreas>
		</asp:Chart>
            </div>
        <div class="boxx" style="width:auto">
        <asp:Chart ID="chartSP" runat="server" Height="450px" Width="450px">
            <Legends>
        <asp:Legend Alignment="Center" Docking="Bottom" IsTextAutoFit="False" Name="Default" LegendStyle="Row" />
    </Legends>
			<Series>
				<asp:Series Name="serieSP">
				</asp:Series>
			</Series>
			<ChartAreas>
				<asp:ChartArea Name="ChartAreaSP">
					<Area3DStyle />
				</asp:ChartArea>
			</ChartAreas>
		</asp:Chart>
            </div>
    </div>
        </div>
    <link rel="stylesheet" href="assets/css/jquery-ui.custom.min.css" />

		<!-- text fonts -->
		

		<!-- ace styles -->

    </asp:Content>

