<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" EnableEventValidation="false" AutoEventWireup="true" CodeFile="AfficherDevis.aspx.cs" Inherits="Astree.AfficherDevis" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" Runat="Server">

   
    
        <div class="row">
            <div class="col-sm-4  dashboard_graph" style="align-content:center; top: -1px; left: 0px; height: 682px;">
                <div class="x_title dashboard_graph " >
                 <h2 style="color: #73879C;">Traiter Devis</h2>
                  <div class="clearfix"> </div>
                </div>
   <div class="form-group">
    
	
    <label style="color:#336199; width: 176px;" for="form-field-pass1">Risque&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp; </label>
       <asp:TextBox ID="txtproduit" runat="server" Height="32px"></asp:TextBox><asp:Label runat="server" ForeColor="Red">*</asp:Label>
       <br />
       <asp:Label runat="server" ID="MsgProduit" ForeColor="Red" Text=""  Visible="false"></asp:Label>
       <br />
  </div>
  <div class="form-group">
  
  
   <label style="color:#336199; width: 176px;"for="form-field-pass1">Sous-Risque&nbsp; &nbsp; &nbsp; </label>
      <asp:TextBox ID="txtsousproduit" runat="server" Height="32px"></asp:TextBox><asp:Label runat="server" ForeColor="Red">*</asp:Label>
      <br />
        <asp:Label runat="server" ID="Label1" ForeColor="Red" Text=""></asp:Label>
      <br />
   </div>
   
    
    
   <div class="form-group">
    <label style="color:#336199; width: 176px;" for="form-field-pass1">Etat&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp; &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;</label>&nbsp;<asp:TextBox ID="Txtetat" runat="server" Height="32px"></asp:TextBox><asp:Label runat="server" ForeColor="Red">*</asp:Label>
       <br />
         <asp:Label runat="server" ID="MsgEtat" ForeColor="Red" Text=""  Visible="false"></asp:Label>
       <br />
   </div>
   <div class="form-group">
     <label style="color:#336199; width: 174px;" for="form-field-pass1">Prime Hors Tax</label>&nbsp; <asp:TextBox ID="TxtPHT" runat="server" Text="0" AutoPostBack="true" OnTextChanged="TxtPHT_TextChanged" Height="32px"></asp:TextBox><asp:Label runat="server" ForeColor="Red">*</asp:Label>
	   <br />
         <asp:Label runat="server" ID="MsgPH" ForeColor="Red" Text=""  Visible="false"></asp:Label>
       <br />
	</div>
   <div class="form-group">
    <label style="color:#336199; width: 176px;" for="form-field-pass1">Taxe&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp; &nbsp; </label>
       <asp:TextBox ID="txtTaxe" runat="server" AutoPostBack="true" OnTextChanged="txtTaxe_TextChanged" Text="0" Height="32px"></asp:TextBox><asp:Label runat="server" ForeColor="Red">*</asp:Label>
    <asp:TextBox ID="txtID" runat="server" Visible="false"></asp:TextBox>
       <br />
         <asp:Label runat="server" ID="MsgTaxe" ForeColor="Red" Text=""  Visible="false"></asp:Label>
       <br />
  </div>
   <div class="form-group">
    
	
       <label  style="color:#336199; width: 176px;" for="form-field-pass1" >
       &nbsp;<br />
       Cout Police&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </label>&nbsp;<asp:TextBox ID="txtCP" runat="server" AutoPostBack="true" OnTextChanged="txtCP_TextChanged" Text="0" Height="33px"></asp:TextBox><asp:Label runat="server" ForeColor="Red">*</asp:Label>
       <br />
         <asp:Label runat="server" ID="MsgCP" ForeColor="Red" Text=""  Visible="false"></asp:Label>
       <br />
  </div>
  <div class="form-group">
    <label style="color:#336199; width: 176px;" for="form-field-pass1">Prime Totale&nbsp; &nbsp; &nbsp;&nbsp; </label>
      <asp:TextBox ID="txtPT" runat="server" Text="0" Height="32px"></asp:TextBox><asp:Label runat="server" ForeColor="Red">*</asp:Label>
      <br />
        <asp:Label runat="server" ID="MsgPT" ForeColor="Red" Text=""  Visible="false"></asp:Label>
      <br />
   </div>
    
   <div class="form-group">
<%--    <label class="col-sm-3 control-label no-padding-right">date Reponse</label>--%>
    <div class="col-sm-9">
    <asp:TextBox ID="txtdatereponse" runat="server" Text="0" Visible="false"></asp:TextBox>
	</div>
       <br />
         <asp:Label runat="server" ID="Label6" ForeColor="Red" Text=""></asp:Label>
       <br />
   </div>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="Btnreponse"  runat="server" class="btn btn-info" Text="Répondre" OnClick="Btnreponse_Click" />

                <br />
                 <asp:Label runat="server" ID="lblerreur" ForeColor="Red" Text=""  Visible="false"></asp:Label>
                <asp:Label runat="server" ID="lblSuccee" ForeColor="Green" Text="" Visible="false"></asp:Label>
                <br />
                <label style="color:red">
                * Des champs obligatoires<br />
                </label>
                <br />

</div>
            <div class="col-sm-8 col-md-8 col-xs-8">
                <div  class=" container-fuild dashboard_graph">
             <div class="x_title dashboard_graph " >
                 <h2 style="color: #73879C;">Liste Devis</h2>
                  <div class="clearfix"> </div>
              </div>
            <div class="widget-box widget-color-blue2" id="widget-box-2">
   <div class="widget-header" >
       
													<h5 class="widget-title bigger lighter">
													<i class="ace-icon fa fa-table"></i>
														Devis Réçus
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
       
         <div style="width: 100%; height:300px; overflow: scroll">
    <asp:gridview  class="table table-striped table-bordered table-hover"  ID="gv_Devis" runat="server" AutoGenerateColumns="False" 
             AllowPaging="true" PageSize="6"
             backColor="White"  BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" 
             CellPadding="3" CellSpacing="1"  Width="100%" Height="160px" OnPageIndexChanging="gv_Devis_PageIndexChanging" OnSelectedIndexChanged="gv_Devis_SelectedIndexChanged1"  OnSelectedIndexChanging="gv_Devis_SelectedIndexChanging"
        >
                   <RowStyle  ForeColor="#333333" HorizontalAlign="Center" />

             <columns >
                  <asp:CommandField  SelectText="+" ShowSelectButton="True" >
                 <ItemStyle HorizontalAlign="Center" />
                 </asp:CommandField>
                <asp:BoundField  DataField="code_service" HeaderText="N° " >
                   <ItemStyle HorizontalAlign="Center" />
                 </asp:BoundField>
                   
                 <asp:BoundField DataField="libelleBranche"  HeaderText="Risque" >
                 <ItemStyle HorizontalAlign="Center" />
                 </asp:BoundField>
                 <asp:BoundField DataField="libelleSousbranche"  HeaderText="Sous-Risque" >
                 <ItemStyle HorizontalAlign="Center" />
                 </asp:BoundField>
                 <asp:BoundField DataField="dateDemande" HeaderText="Date Demande" >
                 <ItemStyle HorizontalAlign="Center" />
                 </asp:BoundField>  
                 <asp:BoundField  DataField="PrimeHTax" HeaderText="Prime Hors Tax" >
                 <ItemStyle HorizontalAlign="Center" />
                 </asp:BoundField>
                 <asp:BoundField  DataField="taxe" HeaderText="Taxe" >
                 <ItemStyle HorizontalAlign="Center" />
                 </asp:BoundField>
                 <asp:BoundField  DataField="coutPolice" HeaderText="Cout Police" >
                 <ItemStyle HorizontalAlign="Center" />
                 </asp:BoundField>
                 <asp:BoundField  DataField="primeTotal" HeaderText="Prime Totale" >
                 <ItemStyle HorizontalAlign="Center" />
                 </asp:BoundField>
                  <asp:BoundField  DataField="dateReponse" HeaderText="Date Réponse" >
                 <ItemStyle HorizontalAlign="Center" />
                 </asp:BoundField>
                  <asp:TemplateField HeaderText="Etat">
                     
                     <ItemTemplate>
                      <asp:CheckBox ID="Accepter" OnCheckedChanged="Accepter_CheckedChanged" AutoPostBack="true"  runat="server" />
                     </ItemTemplate>
                     <ItemStyle HorizontalAlign="Center" />
                     
                 </asp:TemplateField>
                 
                
             </columns>
                     <PagerStyle BackColor="#8da1b3" ForeColor="White" HorizontalAlign="Center" />

        <selectedrowstyle backcolor="LightCyan"
         forecolor="DarkBlue"
         font-bold="true"/> 
         </asp:gridview> </div></div>
                 
           <br/>
           <asp:label id="MessageLabel" forecolor="Red" runat="server"/>
                    </div>
        </div>
        </div>
  
  

    <link rel="stylesheet" href="assets/css/jquery-ui.custom.min.css" />

		<!-- text fonts -->
		

		<!-- ace styles -->
	


								
</asp:Content>

