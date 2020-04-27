<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" EnableEventValidation="false"  AutoEventWireup="true" CodeFile="DemanderReclamation.aspx.cs" Inherits="Astree.DemanderReclamation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" Runat="Server">
    	
		
					

				
						

						
                         <div class="row">
                      <div class="col-sm-4 dashboard_graph" style="align-content:center; top: -1px; left: 0px; height: 490px;">
                          <div class="x_title dashboard_graph " >
                 <h2 style="color: #73879C;">Envoyer Réclamation</h2>
                  <div class="clearfix"> </div>
                </div>
                          <div class="profile-info-row">
													<div style="color:#336199" hidden="hidden"> Votre code:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp; 
														
                                                      <asp:textbox runat="server" Width="127px" ID="TxtCode" Height="28px" Visible="false"></asp:textbox>

                                                       
                                                    </div>

													<div >
                                                    </div>
												</div>

                                   	<div class="profile-info-row">
										<div style="color:#336199"> 
                                            <br />
                                            Votre destination: 
                                          <asp:DropDownList ID="ddlDest" runat="server" DataSourceID="SqlDataSource1" DataTextField="LibelleDest" DataValueField="code_dest" Height="29px" Width="143px"></asp:DropDownList><label style="color:red">*</label>
                                            <br />
                                        </div>

										<div >
                                          <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:PortailServicesConnectionString %>" SelectCommand="SELECT [LibelleDest], [code_dest] FROM [destination]"></asp:SqlDataSource>
                                     </div>
                                           
                                            <br />
                                            <asp:Label ID="MsgddlDest" runat="server" visible="false" Forecolor="red" Text=""></asp:Label>
                                            <br />
										</div>
                           
                           
                                <div class="profile-info-row">
                               <div style="color:#336199"> 
                                  
                                   Rédigez votre réclamation:<asp:textbox runat="server" ID="TxtCommentaire" textMode="MultiLine" Width="97px"></asp:textbox><label style="color:red">*</label>

                                    <br />
                                   
                                            <asp:Label ID="MsgContenu" runat="server" visible="false" Forecolor="red" Text=""></asp:Label>
                                            <br />
                                   &nbsp;</div>

                                </div>
								<!--<div class="wysiwyg-editor" id="editor1"></div>-->

							

								     <div>
											&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
											<asp:Button Cssclass="btn btn-info" runat="server" ID="Btnsave" OnClick="Btnsave_Click" Text="Envoyer" > 
										   </asp:Button>
                                         <br />
                                         <br />
                                         <asp:Label ID="lblMsgSucces" Forecolor="Green" runat="server" visible="false"  Text="aa"></asp:Label>
                                         <br />
                                         <br />
                                            <label style="color:red">* Des champs obligatoires
                                            </label>
           
                                        <br />
							          </div>
                      </div>
                            
                        <!-- GridView-->

                         <div class="col-sm-8 col-md-8 col-xs-8">
                              <div class=" container-fuild dashboard_graph">
             <div class="x_title dashboard_graph " >
                 <h2 style="color: #73879C;">Liste Réclamations</h2>
                  <div class="clearfix"> </div>
                </div>
                              <div class="widget-box widget-color-blue2" id="widget-box-2">
   <div class="widget-header" >
       
													<h5 class="widget-title bigger lighter">
													<i class="ace-icon fa fa-table"></i>
														Réclamations Envoyées
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
           <div style="width: 100%; height:305px; overflow: scroll">
           <asp:gridview  ID="gv_Reclamation" class="table table-striped table-bordered table-hover"  runat="server" AllowPaging="True" CellPadding="1" 
       GridLines="None" Height="16px" Width="800px" AutoGenerateColumns="false" CellSpacing="1" BorderStyle="None" OnRowDataBound="gv_Reclamation_RowDataBound" OnSelectedIndexChanged="gv_Reclamation_SelectedIndexChanged"
                          OnPageIndexChanging="gv_Reclamation_PageIndexChanging" PageSize="6" >
         <RowStyle  ForeColor="#333333" HorizontalAlign="Center" />
         <columns >
             <asp:CommandField  SelectText="+" ShowSelectButton="True" >
                 <ItemStyle HorizontalAlign="Center" />
                 </asp:CommandField>
                 <asp:BoundField DataField="code_service" HeaderText="N°" >
                 <ItemStyle HorizontalAlign="Center" />
                 </asp:BoundField>
                <%-- <asp:BoundField DataField="libelleType"  HeaderText="Type service" >
                 <ItemStyle HorizontalAlign="Center" />
                 </asp:BoundField>--%>
               <asp:BoundField  DataField="codeDest" HeaderText="Code Destinataire" >
                 <ItemStyle HorizontalAlign="Center" />
                 </asp:BoundField>
              <asp:BoundField  DataField="libelleDest" HeaderText="Destinataire" >
                 <ItemStyle HorizontalAlign="Center" />
                 </asp:BoundField>
                 <asp:BoundField DataField="dateDemande"  HeaderText="Envoyer le" >
                 <ItemStyle HorizontalAlign="Center" />
                 </asp:BoundField>
                 <asp:BoundField DataField="contenuReclamation" HeaderText="Contenu Réclamation" >
                 <ItemStyle HorizontalAlign="Center" />
                 </asp:BoundField>
               
             
                 <asp:BoundField DataField="reponse" HeaderText="Réponse" >   
                 <ItemStyle HorizontalAlign="Center" />
                 </asp:BoundField>
                 <%-- <asp:TemplateField ItemStyle-HorizontalAlign="Center"> 
                <ItemTemplate>  
                 <asp:LinkButton ID="lnkDownload" runat="server" Text="Télécharger" OnClick="DownloadFile"  
                  CommandArgument='<%# Eval("code_service") %>'></asp:LinkButton>  
                </ItemTemplate>  
                     </asp:TemplateField>--%>
                 <asp:BoundField  DataField="dateReponse" HeaderText="Date Réponse" >
                 <ItemStyle HorizontalAlign="Center" />
                 </asp:BoundField>
                 <asp:BoundField  DataField="etat" HeaderText="Etat" >
                 <ItemStyle HorizontalAlign="Center" />
                 </asp:BoundField>
             </columns>
               <PagerStyle BackColor="#8da1b3" ForeColor="White" HorizontalAlign="Center" />
         </asp:gridview> </div>
                 </div>
                 </div>         
          </div>     
          </div>
         
   

    <link rel="stylesheet" href="assets/css/jquery-ui.custom.min.css" />

		<!-- text fonts -->
		

		<!-- ace styles -->
		

    </asp:Content>

