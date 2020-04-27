<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" EnableEventValidation="false" AutoEventWireup="true" CodeFile="RepondreCommandeFournisseur.aspx.cs" Inherits="RepondreCommandeFournisseur" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" Runat="Server">
    
    
    <div  class="row">
    <div class="col-sm-4 dashboard_graph" style="align-content:center; top: -1px; left: 0px; height:522px;">
         <div class="x_title dashboard_graph " >
                 <h2 style="color: #73879C;">Répondre Commande</h2>
                  <div class="clearfix"> </div>
                </div>
          <asp:Label ID="description" runat="server" ForeColor="Red"></asp:Label>
    <div>
    <asp:TextBox runat="server" ID="txtcodeService" hidden="hidden"></asp:TextBox>
	

        <div>
    <label style="color:#336199" for="TxtCode">Envoyé par&nbsp; </label>
&nbsp;<asp:TextBox ID="txtCode" runat="server" Height="32px"></asp:TextBox><label style="color:red">*</label>
            <br />
            <asp:Label ID="MsgCode" runat="server" visible="false" Forecolor="red" Text=""></asp:Label>
        </div>
        <div style="display:inline"></div>

         <br/>
        <div>
	        <label style="color:#336199" for="TxtCode">Produit &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;</label>
                                                                    <asp:TextBox ID="txtProduit" runat="server" Height="33px" ></asp:TextBox><label style="color:red">*</label>
                                                                    
														</div>	
   

    </div>
       <br/>
        <asp:Label ID="MsgEtat" runat="server" visible="false" Forecolor="red" Text=""></asp:Label>
       <br/>
   <div >
   <div>
   <label style="color:#336199" for="txtReonse">Réponse</label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
   <asp:TextBox ID="txtReponse" runat="server" textMode="MultiLine"></asp:TextBox><label style="color:red">*</label>
  <%-- <asp:ImageButton runat="server" ID="importerF" ImageUrl="images/folder_small.png" Height="36px" Width="30px"   />--%>
   </div>
       <br />
        <asp:Label ID="MsgReponse" runat="server" visible="false" Forecolor="red" Text=""></asp:Label>
       <br />
      
      
   </div>
   
  <%--	<div style="display:inline">
                                                        <asp:FileUpload ID="FileUpload1" runat="server" onchange="fileinfo()" style="display:none;" /> 
                                                                     <asp:TextBox ID="TextBox1" runat="server" hidden="hidden">
                                                                   </asp:TextBox>
                                                       
                                                        <div>
                                                             <asp:Label ID="lien" runat="server"></asp:Label>
                                                           
                                                             <br />
                                                           
                                                        </div>
													</div>--%>
       &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

           <asp:Button ID="Btnreponse" runat="server" class="btn btn-info" Text="Répondre" OnClick="Btnreponse_Click" />
          
       <br />
       <div style="width: 156px">

           &nbsp;&nbsp;<br />
           &nbsp;

           </div>
         <br />
            <asp:Label ID="lblMsgSucces" Forecolor="Green" runat="server" visible="false"  Text="aaa"></asp:Label>
       
    <br />
       <label style="color:red">* Des champs obligatoires<br />
            </label>
       <br />

</div>
      <div class="col-sm-8">
          <div  class=" container-fuild dashboard_graph">
             <div class="x_title dashboard_graph " >
                 <h2 style="color: #73879C;">Liste Demandes</h2>
                  <div class="clearfix"> </div>
                </div>
    <div class="widget-box widget-color-blue2" id="widget-box-2">
   <div class="widget-header" >
       
													<h5 class="widget-title bigger lighter">
													<i class="ace-icon fa fa-table"></i>
														Les demandes Réçus
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
       
         <div style="height:300px; overflow: scroll">
    <asp:gridview  class="table table-striped table-bordered table-hover"  ID="gv_Commande" runat="server" AutoGenerateColumns="False" 
             AllowPaging="true" PageSize="6"
             backColor="White"  BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" OnRowDataBound="gv_Commande_RowDataBound"
             CellPadding="3" CellSpacing="1"  Width="100%" Height="160px"  OnSelectedIndexChanged="gv_Commande_SelectedIndexChanged"  OnSelectedIndexChanging="gv_Commande_SelectedIndexChanging">
                   <RowStyle  ForeColor="#333333" HorizontalAlign="Center" />

             <columns >
                  <asp:CommandField  SelectText="+" ShowSelectButton="True" >
                 <ItemStyle HorizontalAlign="Center" />
                 </asp:CommandField>
                <asp:BoundField  DataField="code_service" HeaderText="N°" >
                   <ItemStyle HorizontalAlign="Center" />
                 </asp:BoundField>
                 <asp:BoundField DataField="NomUtilisateur"  HeaderText="Envoyé par" >
                 <ItemStyle HorizontalAlign="Center" />
                 </asp:BoundField>
                 <%--<asp:BoundField DataField="codeUtilisateur"  HeaderText="Code Utilisateur" >
                 <ItemStyle HorizontalAlign="Center" />
                 </asp:BoundField>--%>
                  <asp:BoundField DataField="LibelleProduit" HeaderText="Article" >
                  <ItemStyle HorizontalAlign="Center" />
                   </asp:BoundField> 
                   <asp:BoundField DataField="PU" HeaderText="Prix unitaire" >
                  <ItemStyle HorizontalAlign="Center" />
                  </asp:BoundField> 
                <asp:BoundField DataField="Qte" HeaderText="Quantité" >
               <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField> 
                  <asp:BoundField  DataField="Observation" HeaderText="Observation" >
                 <ItemStyle HorizontalAlign="Center" />
                 </asp:BoundField>
                 <asp:BoundField DataField="dateDemande" HeaderText="Date Demande" >
                 <ItemStyle HorizontalAlign="Center" />
                 </asp:BoundField>  
                
                <%-- <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="fichier Envoyé">  
                    <ItemTemplate>  
                        <asp:LinkButton ID="lnkDownload" runat="server" Text="Télécharger" OnClick="DownloadFile"  
                            CommandArgument='<%# Eval("code_service") %>'></asp:LinkButton>  
                    </ItemTemplate>  
                </asp:TemplateField>  --%>
                  <asp:BoundField  DataField="reponse" HeaderText="Votre réponse" >
                 <ItemStyle HorizontalAlign="Center" />
                 </asp:BoundField>
               <%--  <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Fichier repondu">  
                    <ItemTemplate>  
                        <asp:LinkButton ID="lnkDownload1" runat="server" Text="Télécharger" OnClick="DownloadFileIndexe"  
                            CommandArgument='<%# Eval("code_service") %>'></asp:LinkButton>  
                    </ItemTemplate>  
                </asp:TemplateField>  --%>
                 <asp:BoundField  DataField="dateReponse" HeaderText="Date Reponse" >
                 <ItemStyle HorizontalAlign="Center" />
                 </asp:BoundField>

                 <%-- <asp:TemplateField HeaderText="etat">
                     
                     <ItemTemplate>
                      <asp:CheckBox ID="Accepter" OnCheckedChanged="Accepter_CheckedChanged" AutoPostBack="true"  runat="server" />
                     </ItemTemplate>
                     <ItemStyle HorizontalAlign="Center" />
                     
                 </asp:TemplateField>--%>
                 
                
             </columns>
                     <PagerStyle BackColor="#8da1b3" ForeColor="White" HorizontalAlign="Center" />

        <selectedrowstyle backcolor="LightCyan"
         forecolor="DarkBlue"
         font-bold="true"/> 
         </asp:gridview> </div></div>
              </div>
</div>    
    <br/><asp:label id="MessageLabel"
        forecolor="Red"
        runat="server"/>

 
</div>
   

    
	


<link rel="stylesheet" href="assets/css/jquery-ui.custom.min.css" />

		<!-- text fonts -->
		

		<!-- ace styles -->
		
</asp:Content>

