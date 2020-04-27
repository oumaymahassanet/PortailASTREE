<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" EnableEventValidation="false" AutoEventWireup="true" CodeFile="AfficherReclamation.aspx.cs" Inherits="Astree.AfficherReclamation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" Runat="Server">
 
   
     <div class="row">
    	<div class="col-sm-6">
										<div class=" dashboard_graph">
											<div class=" dashboard_graph">
												
                                                  <div class="x_title dashboard_graph " >
                 <h2 style="color: #73879C;"><asp:Label runat="server" ID="nbr" ForeColor="Blue"></asp:Label>&nbsp; Réclamations</h2>
                  <div class="clearfix"> </div>
              </div>
                                                
									</div>
                                            <div style=" height:400px; overflow: scroll">
                                                <asp:Panel class="widget-body" runat="server" ID="PnlMardi">
                                                    <div class="widget-main no-padding">
                                                    <asp:Panel class="dialogs" runat="server" ID="Pnl">

                                                    </asp:Panel>

                                                    </div>
                                                    </asp:Panel>
                                                </div>
												<%--<div class="widget-main no-padding">
													<div class="dialogs">
														<div class="itemdiv dialogdiv">
															<div class="user">
																<img alt="Alexa's Avatar" src="assets/images/avatars/avatar1.png" />
															</div>

															<div class="body">
																<div class="time">
																	<i class="ace-icon fa fa-clock-o"></i>
																	<span id="txtDate" class="green"> </span>
																</div>

																<div class="name">
																	<a href="#"></a>
																</div>
																<div class="text" ></div>
                                                                <asp:ImageButton class="btn btn-minier btn-info" runat="server" ID="Btn" ></asp:ImageButton>
																<%--<div class="tools">
																	<a href="#" class="btn btn-minier btn-info">
																		<i class="icon-only ace-icon fa fa-share"></i>
																	</a>
																</div>--%>
												<%--</div>
														</div>
													</div>

												
												</div>--%><!-- /.widget-main -->
											

                                           										
										</div>
									</div>
        <div class="col-sm-6" >
										<div class="dashboard_graph"">
											<div class=" dashboard_graph">
												
                                                  <div class="x_title dashboard_graph " >
                 <h2 style="color: #73879C;"> Répondre</h2>
                  <div class="clearfix"> </div>
              </div>
                                                
									</div>
                                            

											<div class="widget-body dashboard_graph">
												<div class="widget-main no-padding">
													

												
														<div class=" dashboard_graph">
															<div class="input-group" >
                                                                <div class=" dialogdiv" runat="server" >
                                                                  
                                                                    <div class="body">
                                                                          <div class="name">
                                                                            <a href="#" id="nom"></a>
                                                                            </div>
                                                                        <div class="time">
                                                                          <%--  <i class="ace-icon fa fa-clock-o"></i>--%>
                                                                            <span id="date" class="green"></span>
                                                                            </div>
                                                                      
                                                                        <div class="text" id="contenu"></div>
                                                                      
                                                                        <asp:TextBox ID="myCode" runat="server" hidden="hidden" ></asp:TextBox>
                                                                     </div>

                                                                </div>
                                                                <div>
                                                                    
                                                               <%--  <asp:FileUpload ID="FileUpload1" runat="server" onchange="fileinfo()" style="display:none;" /> 
                                                                 <asp:ImageButton runat="server" ID="importerF" ImageUrl="assets/images/email/envoyer.png" OnClick="importerF_Click"  />
                                                                     <asp:TextBox ID="TextBox1" runat="server" hidden="hidden">
                                                                   </asp:TextBox>--%>
                                                                    <asp:TextBox ID="message" runat="server" Cssclass="form-control" Height="31px" placeholder="Écrivez votre réponse ici ..." Width="418px" TextMode="MultiLine">
                                                                        
                                                                   </asp:TextBox>
                                                                    <br />
                                                                    <br />
                                                                </div>
                                                              <br />
																<br />
                                                                 <asp:Button ID="BtnRepondre" runat="server" class="btn btn-info" Text="Repondre" OnClick="BtnRepondre_Click" />

                                                                
															    <%--<asp:Button ID="BtnRepondre" Cssclass="btn btn-sm btn-info no-radius" runat="server"  Text="Répondre" OnClick="BtnRepondre_Click">
																	</asp:Button>

														--%>
                                                                
															</div>
                                                            <asp:Label runat="server" ID="msgerror" Visible="false" ForeColor="red"></asp:Label>
														</div>
												
                                                    
												</div><!-- /.widget-main -->
											</div><!-- /.widget-body -->
										</div><!-- /.widget-box -->
									</div> 
         
    </div>
       
  
    <script language="javascript" type="text/javascript">
       
           
        function mercredi(x) {

                   k = "txtDate_" + x;
            document.getElementById("date").innerHTML = document.getElementById(k).innerHTML;
                   L = "name_" + x;
            document.getElementById("nom").innerHTML = document.getElementById(L).innerHTML;
                   y = "txtcontenu_" + x;
            document.getElementById("contenu").innerHTML = document.getElementById(y).innerHTML;
          //  document.getElementById("myCode").innerHTML = x;
           //  document.getElementById("Code").innerText = x; 
           //document.getElementById('content_myCode').text = x;
          document.getElementById('<%=myCode.ClientID%>').value=x;
        }
       <%-- function fileinfo() {
            document.getElementById('<%=TextBox1.ClientID%>').value=document.getElementById('<%=FileUpload1.ClientID%>').value
        }--%>
        
    </script>
</asp:Content>