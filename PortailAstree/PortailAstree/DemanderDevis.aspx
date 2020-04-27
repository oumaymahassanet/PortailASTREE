<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="DemanderDevis.aspx.cs" Inherits="Astree.DemanderDevis" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" Runat="Server">
    

       <div class="row">
            
       <div class="col-sm-4  dashboard_graph" style="align-content:center; top: -1px; left: 0px; height: 441px;">
         
           <div class="x_title dashboard_graph " >
                 <h2 style="color: #73879C;">Demander Devis</h2>
                  <div class="clearfix"> </div>
                </div>
            <br />
        <div class="form-group"> 
        <label style="color:#336199">Risque</label>
      &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;  &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="ddlproduit" class="multiselect" runat="server" Width="179px" AutoPostBack="true"
        DataValueField="Id_branche" DataTextField="libelle" OnSelectedIndexChanged="ddlproduit_SelectedIndexChanged" DataSourceID="SqlDataSourceBranche" Height="32px" >
        <asp:ListItem Text="Choose a State..." Value=""   />
        </asp:DropDownList>
            <label style="color:red">*</label>
            <br />
            <asp:Label ID="MsgError" runat="server" visible="false" Forecolor="red" Text=""></asp:Label>
            <br />
        <asp:SqlDataSource ID="SqlDataSourceBranche" runat="server" ConnectionString="<%$ ConnectionStrings:PortailServicesConnectionString %>" SelectCommand="SELECT * FROM [branche]"></asp:SqlDataSource>
        									
        
       </div>
         <div class="form-group">
            <label style="color:#336199">Sous-Risque</label>
		   &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
           <asp:DropDownList    ID="ddlsousproduit" class="multiselect" runat="server" Width="178px"  AutoPostBack="true"
            DataValueField="Id_sous_branche" DataTextField="libelle"  DataSourceID="SqlDataSourceSousbranche" Height="34px" >
           <asp:ListItem Text="Choose a State..." Value=""   />
           </asp:DropDownList>
              <label style="color:red">*</label>
             <br />
            <asp:Label ID="MsgDuree" runat="server" visible="false" Forecolor="red" Text=""></asp:Label>
            <br />
           <asp:SqlDataSource ID="SqlDataSourceSousbranche" runat="server" ConnectionString="<%$ ConnectionStrings:PortailServicesConnectionString %>" SelectCommand="SELECT * FROM [sous_branche] WHERE ([Id_branche] = @Id_branche)">
           <SelectParameters>
           <asp:ControlParameter ControlID="ddlproduit" Name="Id_branche" PropertyName="SelectedValue" Type="Int32" />
           </SelectParameters>
           </asp:SqlDataSource>
          
		  
         </div>
    
           &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    
           <asp:Button ID="BtnAjoutDevis"  runat="server" Text="Envoyer" class="btn btn-info" Onclick="BtnAjoutDevis_Click" />
        <br />
       <asp:Label ID="lblMsgSucces" Height="60px" class=""  ForeColor="Green" runat="server" 
           visible="false"  Text=""></asp:Label>
           <br />
 <asp:Label ID="lblMessage1" Height="70px" runat="server" visible="false" ForeColor="Green" Text=""></asp:Label>
     
     <br />
           <label style="color:red">* Des champs obligatoires
            </label>

           <br />
           <br />

          
        </div>
     
        <div class="col-sm-8">
        <div class=" container-fuild dashboard_graph">
             <div class="x_title dashboard_graph " >
                 <h2 style="color: #73879C;">Liste Devis</h2>
                  <div class="clearfix"> </div>
                </div>
           
           
        <div class="widget-box widget-color-blue2 " id="widget-box-2">
   <div class="widget-header" >
       
													<h5 class="widget-title bigger lighter">
													<i class="ace-icon fa fa-table"></i>
														Devis Envoyés
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
       


                <div style="height: 300px; overflow: scroll">

    <asp:gridview  ID="gv_Devis" class="table table-striped table-bordered table-hover"  runat="server" AllowPaging="True" CellPadding="1" 
       GridLines="None" Height="16px" Width="895px" AutoGenerateColumns="false" CellSpacing="1" BorderStyle="None" 
                          OnPageIndexChanging="gv_Devis_PageIndexChanging1" PageSize="6" >
          <RowStyle  ForeColor="#333333" HorizontalAlign="Center" />
             <columns >
                <asp:BoundField  DataField="code_service" HeaderText="N° " >
                  <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                   <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                 </asp:BoundField>
                   
                 <asp:BoundField DataField="libelleBranche"  HeaderText="Risque" >
                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                 <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                 </asp:BoundField>
                 <asp:BoundField DataField="libelleSousbranche"  HeaderText="Sous-Risque" >
                 <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                 <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                 </asp:BoundField>
                  
                
                 <asp:BoundField DataField="dateDemande" HeaderText="Date Demande" >
                 <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                 <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                 </asp:BoundField>
                 
                
                 <asp:BoundField  DataField="primeHTax" HeaderText="Prime Hors Tax" >
                 <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                 <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                 </asp:BoundField>
                 <asp:BoundField  DataField="coutPolice" HeaderText="Cout Police" >
                 <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                 <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                 </asp:BoundField>
                 <asp:BoundField  DataField="primeTotal" HeaderText="Prime Total" >
                 <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                 <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                 </asp:BoundField>
                  <asp:BoundField  DataField="dateReponse" HeaderText="Date Réponse" >
                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                 <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                 </asp:BoundField>
                 
                 <asp:BoundField  DataField="etat" HeaderText="Etat" >
                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                           <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                 </asp:BoundField>
                
                 
             </columns>
                                         <PagerStyle BackColor="#8da1b3" ForeColor="White" HorizontalAlign="Center" />
                         
                       
         </asp:gridview> </div></div>
             <br />
          
           
        </div>
					</div>	
    
           </div>

        

    

    <link rel="stylesheet" href="assets/css/jquery-ui.custom.min.css" />

		<!-- text fonts -->
		

	
		

</asp:Content>

