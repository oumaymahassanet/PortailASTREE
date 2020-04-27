<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" EnableEventValidation="false" AutoEventWireup="true" CodeFile="AfficherDerogation.aspx.cs" Inherits="Astree.AfficherDerogation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" Runat="Server">

  
   <div class="row">
        <div class="col-sm-4 dashboard_graph" style="align-content:center; top: -2px; left: 0px; height: 788px;">
            <div class="x_title dashboard_graph " >
                 <h2 style="color: #73879C;">Traiter Dérogation</h2>
                  <div class="clearfix"> </div>
                </div>
            <%-- dropdownListe des type de dérogations --%>
             <div>
    &nbsp;&nbsp;
    <label style="color:#336199"> Type&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </label>
    <asp:DropDownList ID="ddltype" class="multiselect" runat="server" Width="165px" OnSelectedIndexChanged="ddltype_SelectedIndexChanged"
      AutoPostBack="true"   DataValueField="Id_type" DataTextField="libelle" Height="35px">
       <asp:ListItem Text="Choose a State..." Value=""   />
         </asp:DropDownList>
			<label style="color:red">*</label>
		&nbsp;<div >
			
		<asp:SqlDataSource ID="SqlDataSourceType" runat="server" ConnectionString="<%$ ConnectionStrings:PortailServicesConnectionString %>" SelectCommand="SELECT * FROM [type_service] WHERE ([famille_type] = @famille_type)">
         <SelectParameters>
           <asp:Parameter DefaultValue="Derogation" Name="famille_type" Type="String" />
              </SelectParameters>
                </asp:SqlDataSource>
    </div>
     </div>
       <br />  
           
            <%-- Formulaire de traitement du dérogation --%>
   <asp:Panel ID="pnlDerogation" runat="server" class="dashboard_graph" style="align-content:center; top: -1px; left: 0px; " Height="509px">
  <div>
	 <div >
     <label style="color:#336199" for="txttype">Type&nbsp; </label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp; &nbsp;<asp:TextBox ID="txttype" runat="server" Height="32px" Width="168px"></asp:TextBox><asp:Label runat="server" ForeColor="red">*</asp:Label>
     <asp:TextBox ID="txtId" runat="server" Visible="false"></asp:TextBox>
         
	</div>
   </div>
   <br />
  <div>
    
	<div >
    <label style="color:#336199"  for="txtproduit">Risque&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp; </label>
&nbsp;<asp:TextBox ID="txtproduit" runat="server" Height="32px" Width="168px"></asp:TextBox><asp:Label runat="server" ForeColor="red">*</asp:Label>
      
	</div>
      <asp:Label runat="server" ID="MsgProduit" ForeColor="Red" Text=""  visible="false"></asp:Label>
      <br />
   </div>
     
  <div >
	  <div >
      <label style="color:#336199" for="txtsousproduit">Sous-Risque</label>
     <asp:TextBox ID="txtsousproduit" runat="server" Height="34px" Width="170px"></asp:TextBox><asp:Label runat="server" ForeColor="red">*</asp:Label>
          
	  </div>
	</div>
    <br />
   <div>
     
	 <div >
     <label style="color:#336199" for="txtnumContrat">N° Contrat&nbsp;&nbsp; &nbsp;</label>&nbsp;<asp:TextBox ID="txtnumcontrat" runat="server" Height="32px" Width="169px"></asp:TextBox><asp:Label runat="server" ForeColor="red">*</asp:Label>
	 </div>
	</div>
    <br />
   <div>
    <asp:Panel ID="pnlDuree"  runat="server"> 
    <div>
    <asp:Label ID="lblDuree" style="color:#336199" runat="server" Text="Durée"></asp:Label>
        &nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="txtduree" runat="server" Width="168px" Height="32px" /><asp:Label runat="server" ForeColor="red">*</asp:Label>
	    <br />
	</div>
    </asp:Panel>
   </div>
   
   <div>
    <asp:Panel ID="pnlTaux"  runat="server">
                  
    <div>
    <asp:Label ID="lbltaux" style="color:#336199" runat="server" Text="Taux" ></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
   <asp:TextBox ID="txttaux"  TextMode="Number" runat="server" Width="169px" Height="33px" /><asp:Label runat="server" ForeColor="red">*</asp:Label>
    </div>
    </asp:Panel>
   </div>
    <br />
   <div>
    
	<div>
    <label style="color:#336199">Etat&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp; </label>
&nbsp;<asp:TextBox ID="Txtetat" runat="server" Width="169px" Height="32px"></asp:TextBox>
	    <asp:Label runat="server"  ForeColor="red" >*</asp:Label></div>
  </div>
 <br />
       <asp:Label runat="server" ID="MsgEtat" ForeColor="Red" Text=""  visible="false"></asp:Label>
   <br />
  <div>
    <div>                   
    <label style="color:#336199" for="txtreponse">Reponse</label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
   <asp:TextBox ID="txtreponse" textMode="MultiLine" runat="server" Width="202px" Height="81px"></asp:TextBox><label style="color:red">*</label>
        <br />
        <asp:Label ID="Msgreponse" runat="server" visible="false" Forecolor="red" Text=""></asp:Label>
	</div>
   </div>
 <br />
       &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
   <asp:Button ID="Btnreponse"  runat="server" class="btn btn-info" Text="Répondre" OnClick="Btnreponse_Click" />
       <br />
       <asp:Label ID="lblMsgSucces" Forecolor="Green" runat="server" visible="false"  Text="aaa"></asp:Label>
       <br />
       <label style="color:red">* Des champs obligatoires<br />
            </label>
       <br />

        
                </asp:Panel>
  </div>
     
        <div class=" col-sm-8 col-md-8 col-xs-8" >
    <div class="dashboard_graph" >
    <div class="x_title dashboard_graph " >
                 <h2 style="color: #73879C;">Liste Dérogations </h2>
                  <div class="clearfix"> </div>
                </div>
   <div class="widget-box widget-color-blue2" id="widget-box-2" style="height: 362px">
   <div class="widget-header" >
       
													<h5 class="widget-title bigger lighter">
													<i class="ace-icon fa fa-table"></i>
														Dérogations Réçues
													</h5>

													<div class="widget-toolbar widget-toolbar-light no-border">
														<select id="simple-colorpicker-1" class="hide">
															<option selected="" data-class="blue" value="#307ECC">#307ECC</option>
															<option data-class="blue2" value="#5090C1">#5090C1</option>
															<option data-class="blue3" value="#6379AA">#6379AA</option>
															<option data-class="green" value="#82AF6F">#82AF6F</option>
															<option data-class="green2" value="#2E8965">#2E8965</option>
															<option data-class="green3" value="#5FBC47">#5FBC47</option>
															<option data-class="red" value="#E2755F">#E2755F</option>
															<option data-class="red2" value="#E04141">#E04141</option>
															<option data-class="red3" value="#D15B47">#D15B47</option>
															<option data-class="orange" value="#FFC657">#FFC657</option>
															<option data-class="purple" value="#7E6EB0">#7E6EB0</option>
															<option data-class="pink" value="#CE6F9E">#CE6F9E</option>
															<option data-class="dark" value="#404040">#404040</option>
															<option data-class="grey" value="#848484">#848484</option>
															<option data-class="default" value="#EEE">#EEE</option>
														</select></div> 
												</div>
       
   <div style="width: 100%; height: 320px; overflow: scroll">
            <asp:GridView Style="overflow: auto" ID="gvRemise" class="table table-striped table-bordered table-hover" runat="server" AllowPaging="True" CellPadding="1"
                GridLines="None" Height="49px" Width="100%" AutoGenerateColumns="false" CellSpacing="1" BorderStyle="None"
                OnPageIndexChanging="gvRemise_PageIndexChanging" PageSize="6" OnSelectedIndexChanged="gvRemise_SelectedIndexChanged">
                <RowStyle ForeColor="#333333" HorizontalAlign="Center" />

                <Columns>
                    <asp:CommandField SelectText="+" ShowSelectButton="True">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:CommandField>
                    <asp:BoundField DataField="code_service" HeaderText="N°">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="libelleType" HeaderText="Type Dérogation">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="libelleBranche" HeaderText="Risque">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="libelleSousbranche" HeaderText="Sous-Risque">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="dateDemande" HeaderText="Date Demande">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="numContrat" HeaderText="Num Contrat">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>

                    <asp:BoundField DataField="taux" HeaderText="Taux voulu">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>

                    <asp:BoundField DataField="dateReponse" HeaderText="Date Réponse">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="reponse" HeaderText="Réponse">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>

                    <asp:TemplateField HeaderText="Etat">

                        <ItemTemplate>
                            <asp:CheckBox ID="Accepter" OnCheckedChanged="Accepter_CheckedChanged" AutoPostBack="true" runat="server" />
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />

                    </asp:TemplateField>




                </Columns>
                <PagerStyle BackColor="#8da1b3" ForeColor="White" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="LightCyan"
                    ForeColor="DarkBlue"
                    Font-Bold="true" />
            </asp:GridView>


            <asp:GridView Style="overflow: auto" ID="gvProrogation" class="table table-striped table-bordered table-hover" runat="server" AllowPaging="True" CellPadding="1"
                GridLines="None" Height="15px" Width="100%" AutoGenerateColumns="false" CellSpacing="1" BorderStyle="None"
                OnPageIndexChanging="gvProrogation_PageIndexChanging" PageSize="6" OnSelectedIndexChanged="gvProrogation_SelectedIndexChanged">
                <RowStyle ForeColor="#333333" HorizontalAlign="Center" />

                <Columns>
                    <asp:CommandField SelectText="+" ShowSelectButton="True">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:CommandField>
                    <asp:BoundField DataField="code_service" HeaderText="N°">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="libelleType" HeaderText="Type Dérogation">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="libelleBranche" HeaderText="Risque">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="libelleSousbranche" HeaderText="Sous-Risque">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="dateDemande" HeaderText="Date Demande">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="numContrat" HeaderText="Num Contrat">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>

                    <asp:BoundField DataField="duree" HeaderText="Durée(mois)">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>

                    <asp:BoundField DataField="dateReponse" HeaderText="Date Réponse">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="reponse" HeaderText="Réponse">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>

                    <asp:TemplateField HeaderText="Etat">

                        <ItemTemplate>
                            <asp:CheckBox ID="AccepterProrogation" OnCheckedChanged="AccepterProrogation_CheckedChanged1" AutoPostBack="true" runat="server" />
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />

                    </asp:TemplateField>




                </Columns>
                <SelectedRowStyle BackColor="LightCyan"
                    ForeColor="DarkBlue"
                    Font-Bold="true" />
                <PagerStyle BackColor="#8da1b3" ForeColor="White" HorizontalAlign="Center" />

            </asp:GridView>




            <asp:GridView Style="overflow: auto" ID="gvSouscription" class="table table-striped table-bordered table-hover" runat="server" AllowPaging="True" CellPadding="1"
                GridLines="None" Height="15px" Width="100%" AutoGenerateColumns="false" CellSpacing="1" BorderStyle="None"
                OnPageIndexChanging="gvSouscription_PageIndexChanging" PageSize="6" OnSelectedIndexChanged="gvSouscription_SelectedIndexChanged">
                <RowStyle ForeColor="#333333" HorizontalAlign="Center" />

                <Columns>
                    <asp:CommandField SelectText="+" ShowSelectButton="True">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:CommandField>
                    <asp:BoundField DataField="code_service" HeaderText="N°">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="libelleType" HeaderText="Type Dérogation">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="libelleBranche" HeaderText="Risque">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="libelleSousbranche" HeaderText="Sous-Risque">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="dateDemande" HeaderText="Date Demande">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="numContrat" HeaderText="Num Contrat">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>

                    <asp:BoundField DataField="dateReponse" HeaderText="Date Réponse">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="reponse" HeaderText="Réponse">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>

                    <asp:TemplateField HeaderText="Etat">

                        <ItemTemplate>
                            <asp:CheckBox ID="AccepterSouscription" OnCheckedChanged="AccepterSouscription_CheckedChanged1" AutoPostBack="true" runat="server" />
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />

                    </asp:TemplateField>




                </Columns>
                <SelectedRowStyle BackColor="LightCyan"
                    ForeColor="DarkBlue"
                    Font-Bold="true" />
                <PagerStyle BackColor="#8da1b3" ForeColor="White" HorizontalAlign="Center" />

            </asp:GridView>
        </div>
    <br/>
    
     </div>
        <asp:label id="MessageLabel" forecolor="Red" runat="server"/>
    <asp:label  ID="lblMessage" runat="server" text="" foreColor="Red" />
      </div>
   </div>
</div>
  <link rel="stylesheet" href="assets/css/jquery-ui.custom.min.css" />

		<!-- text fonts -->
		

	
    </asp:Content>

