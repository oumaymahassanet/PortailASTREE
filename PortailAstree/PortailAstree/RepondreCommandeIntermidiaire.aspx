<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" EnableEventValidation="false" AutoEventWireup="true" CodeFile="RepondreCommandeIntermidiaire.aspx.cs" Inherits="Astree.RepondreCommandeIntermidiaire" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" Runat="Server">
   
      <div class="row">
           <div class="col-sm-4 dashboard_graph" style="align-content:center; top: -1px; left: 0px; height:500px;">
                <div class="x_title dashboard_graph " >
                 <h2 style="color: #73879C;">Traiter commande</h2>
                  <div class="clearfix"> </div>
                </div>
                                                   <div class="hidden">
																<label style="color:#336199" for="txtNum">Le numéro d'opération&nbsp;&nbsp;&nbsp; 
                                                                    <asp:TextBox ID="txtNum" runat="server" Width="40px"></asp:TextBox>
                                                                  
                                                                </label>
                                                                   
																&nbsp;
                                                                 <div style="display:inline">
													              </div>  
																</div>
															<asp:Label runat="server" ID="MsgNum" ForeColor="red" Text=""></asp:Label>
                                                
                                                <div >
                                                     <div>
																<label style="color:#336199" for="QteLivree">Produit&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;
                                                                    <asp:TextBox ID="txtProduit" runat="server" Width="150px" Height="30px"></asp:TextBox>
                                                                     <label style="color:red">*</label>
                                                                </label>
														</div>	
                                                     <div>
																<label style="color:#336199" for="QteLivree">
                                                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                                <br />
                                                                Quantité Demandée&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;
                                                                    <asp:TextBox ID="txtQuantiteDemandee" runat="server" Width="149px" Height="32px"></asp:TextBox>
                                                                     <label style="color:red">*</label>
                                                                </label>
														</div>	
                                                    <div>
																<br />
																<label style="color:#336199" for="QteLivree">Quantité Livrée&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp; &nbsp; &nbsp;&nbsp;
                                                                    <asp:TextBox ID="txtQteLivree" runat="server" Width="148px" Height="32px"></asp:TextBox>
                                                                     <label style="color:red">*</label>
                                                                </label>
                                                        <br />
                                                        <asp:Label runat="server" ID="MsgQteLivree" ForeColor="red" Text=""></asp:Label>
														</div>	
                                                  
                                                    <asp:Label runat="server" ID="MsgQteLivre" Text="" ForeColor="red"></asp:Label>
                                                    <br />
                                                    </div>
                                           <%--   <div >
																<label style="color:#336199" for="txtetat">Etat&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </label>

                                                                    <asp:TextBox ID="txtetat" runat="server" Width="118px"></asp:TextBox><label style="color:red">*</label>
                                                                      
																
																</div>--%>
               
        <asp:Label runat="server" ID="MsgEtat" ForeColor="Green" Text=""></asp:Label>
        <br />
                                                            <div style="display:inline">
													              </div>
              
               
                                                       <div>
                                                        <div>
                                                                <label style="color:#336199; height: 36px; margin-top: 0px;" for="txtReponse">
                                                                Réponse&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox ID="txtReponse" textMode="MultiLine" runat="server" Width="196px" Height="73px"></asp:TextBox> 
                                                                &nbsp;&nbsp;&nbsp;<br />
                                                              
                                                              
                                                                &nbsp;
                                                                </label>
                                                                </div>
                                                          
                                                        <div style="display:inline">
													              </div>
															</div>
                <div >
                                                            
														</div>
    <div> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp; <asp:Button ID="Btnreponse" runat="server" class="btn btn-info" Text="Repondre" OnClick="Btnreponse_Click" />
        <br />
        <asp:Label runat="server" ID="LblMsgSuccee" ForeColor="Green" Text=""></asp:Label>
        <br />
      
        <asp:Label runat="server" ID="description" ForeColor="red" Text=""></asp:Label>
        <br />
        <label style="color:red">* Des champs obligatoires<br />
            </label>
    </div>
                                               
      </div>                                         
               
          <div class="col-sm-8">
              <div  class=" container-fuild dashboard_graph">
             <div class="x_title dashboard_graph " >
                 <h2 style="color: #73879C;">Liste des demandes</h2>
                  <div class="clearfix"> </div>
                </div>
              <div class="widget-box widget-color-blue2" id="widget-box-2">
   <div class="widget-header" >
       
													<h5 class="widget-title bigger lighter">
													&nbsp;Demandes Réçus
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
     <asp:gridview   class="table table-striped table-bordered table-hover" 
     OnSelectedIndexChanged="gv_Commande_SelectedIndexChanged" 
          ID="gv_Commande" runat="server" AutoGenerateColumns="False" OnRowDataBound="gv_Commande_RowDataBound"
             backColor="White"  BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" 
             CellPadding="3"  Width="100%"  Height="26px"  >
                   <RowStyle  ForeColor="#333333" HorizontalAlign="Center" />
             <columns >
                  <asp:CommandField  SelectText="+" ShowSelectButton="True" >
                 <ItemStyle HorizontalAlign="Center" />
                 </asp:CommandField>
                  <asp:BoundField  DataField="code_service" HeaderText="N°" >
                   <ItemStyle HorizontalAlign="Center" />
                 </asp:BoundField>
                  <%-- <asp:BoundField DataField="libelleProduit" HeaderText="Le  produit " >
                 <ItemStyle HorizontalAlign="Center" />
                 </asp:BoundField>--%>
                   <asp:BoundField DataField="NomUtilisateur" HeaderText="Envoyer par" >
                 <ItemStyle HorizontalAlign="Center" />
                 </asp:BoundField>
                 <%--<asp:BoundField  DataField="Qte" HeaderText="La quantité demandé" >
                   <ItemStyle HorizontalAlign="Center" />
                 </asp:BoundField>--%>
                  <asp:BoundField DataField="dateDemande" HeaderText="Date de demande" >   
                 <ItemStyle HorizontalAlign="Center" />
                 </asp:BoundField>
                
                <%-- <asp:TemplateField HeaderText="Etat">
                     
                     <ItemTemplate>
                         <asp:CheckBox ID="Accepter" OnCheckedChanged="Accepter_CheckedChanged"  AutoPostBack="true" runat="server" />
                     </ItemTemplate>
                     <ItemStyle HorizontalAlign="Center" />
                     
                 </asp:TemplateField>--%>
                 
                  <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Détails">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="affichier" runat="server" ImageUrl="images/detail.png"
                                                OnClick="affichier_Click" CommandArgument='<%# Eval("code_service") %>'></asp:ImageButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                
             </columns>
            <PagerStyle BackColor="#8da1b3" ForeColor="White" HorizontalAlign="Center" />

        <selectedrowstyle backcolor="LightCyan"
         forecolor="DarkBlue"
         font-bold="true"/> 
         </asp:gridview> 
        <asp:label  ID="lblMessage" runat="server" text="" foreColor="Red" />
        </div>
                  </div>

                 
              </div>
       </div>

          
            <asp:Panel class="col-sm-8 " runat="server" ID="Pnl_GvDetail">
                <div class=" container-fuild dashboard_graph">
                    <div class="x_title dashboard_graph ">
                        <h2 style="color: #73879C;">Détails Commande</h2>
                        <div class="clearfix"></div>
                    </div>
                    <div class="widget-box widget-color-blue2">
                        <div class="widget-header">

                            <h5 class="widget-title bigger lighter">
                                <i class="ace-icon fa fa-table"></i>
                                <asp:Label runat="server" ID="Fournisseur"></asp:Label>
                            </h5>

                            <div class="widget-toolbar widget-toolbar-light no-border">
                                <select id="simple-colorpicker-2" class="hide">
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
                                </select>
                            </div>
                        </div>

                          <asp:GridView class="table table-striped table-bordered table-hover" ID="gv_Detail" runat="server" AutoGenerateColumns="False"
                                BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" OnSelectedIndexChanged="gv_Detail_SelectedIndexChanged"
                                CellPadding="3" Width="99%" Height="26px">
                                <RowStyle ForeColor="#333333" HorizontalAlign="Center" />
                                <Columns>
                                    <asp:CommandField  SelectText="+" ShowSelectButton="True" >
                                     <ItemStyle HorizontalAlign="Center" />
                                     </asp:CommandField>
                                   <%-- <asp:BoundField DataField="NomUtilisateur" HeaderText="Code fournisseur">
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>--%>
                                    <asp:BoundField DataField="dateDemande" HeaderText="Date demande">
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="LibelleProduit" HeaderText="Article">
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                   <%-- <asp:BoundField DataField="PU" HeaderText="Prix unitaire">
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>--%>
                                    <asp:BoundField DataField="Qte" HeaderText="Quantité Demandée">
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                   <asp:BoundField DataField="QteLivree" HeaderText="Quantité Livrée">
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="reponse" HeaderText="Réponse">
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>

                                   <%-- <asp:BoundField DataField="reponse" HeaderText="Réponse">
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>--%>

                                   <%-- <asp:BoundField DataField="dateReponse" HeaderText="Date Réponse">
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="etat" HeaderText="Etat">
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>--%>

                                     <%--<asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Details">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="affichier" runat="server" ImageUrl="images/detail.png"
                                                OnClick="affichier_Click" CommandArgument='<%# Eval("code_service") %>'></asp:ImageButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>
                                </Columns>
                                <PagerStyle BackColor="#8da1b3" ForeColor="White" HorizontalAlign="Center" />
                            </asp:GridView>

                    </div>
                </div>
            </asp:Panel>

</div>
      

     <!-- bootstrap & fontawesome -->
		
		

		<!-- page specific plugin styles -->
		<link rel="stylesheet" href="assets/css/jquery-ui.custom.min.css" />

		<!-- text fonts -->
		

		<!-- ace styles -->
		

		
   
 


</asp:Content>