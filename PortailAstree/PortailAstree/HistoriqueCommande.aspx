<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="HistoriqueCommande.aspx.cs" Inherits="HistoriqueCommande" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" Runat="Server">

  
     <div class="row">
									<div class="col-xs-12 dashboard_graph ">
										<div class="clearfix">
									<%--		<div class="pull-right tableTools-container">
                                                <div class="dt-buttons btn-overlap btn-group">
                        
                                                    <a class="dt-button buttons-copy buttons-html5 btn btn-white btn-primary btn-bold" tabindex="0" aria-controls="dynamic-table" data-original-title="" title="">
                                                        <span>
                                                            <i class="fa fa-copy bigger-110 pink"></i> 
                                                            <span class="hidden">Copy to clipboard</span>

                                                        </span>

                                                    </a>
                                                    <a class="dt-button buttons-csv buttons-html5 btn btn-white btn-primary btn-bold" tabindex="0" aria-controls="dynamic-table" data-original-title="" title="">
                                                        <span>
                                                            <i class="fa fa-database bigger-110 orange"></i>
                                                             <span class="hidden">Export to CSV</span></span>

                                                    </a>
                                                    <a class="dt-button buttons-print btn btn-white btn-primary btn-bold" tabindex="0" aria-controls="dynamic-table" data-original-title="" title="">
                                                        <span>
                                                            <i class="fa fa-print bigger-110 grey"></i> 
                                                            <span class="hidden">Print</span></span></a>

                                                </div>

											</div>
										</div>--%>
                                        <%--<div class="clearfix">
											<div class="pull-right tableTools-container"></div>
										</div>--%>
                                              <div class="x_title dashboard_graph " >
                 <h2 style="color: #73879C;">Liste Commandes</h2>
                     <div class="pull-right">
                                                                       <label style="color:#336199" >Chercher :&nbsp;&nbsp;&nbsp;&nbsp; </label>&nbsp;<asp:TextBox runat="server" ID="txtChercher" Width="103px"  ></asp:TextBox>

                                                                     </div>
                  <div class="clearfix"> </div>
                </div>	
										

										<!-- div.table-responsive -->

										<!-- div.dataTables_borderWrap -->
										<div>
											
     <div class="widget-box widget-color-blue2" id="widget-box-2">
   <div class="widget-header" >
       
													<h5 class="widget-title bigger lighter">
													<i class="ace-icon fa fa-table"></i>
													Historique
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
                                                <asp:gridview   class="table table-striped table-bordered table-hover"   ID="gv_Historique" runat="server" AutoGenerateColumns="False" 
                                                 backColor="White"  BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" OnSelectedIndexChanged="gv_Historique_SelectedIndexChanged" OnRowDataBound="gv_Historique_RowDataBound"
                                                 CellPadding="3"  Width="100%"  Height="26px"  >
                                                    <RowStyle  ForeColor="#333333" HorizontalAlign="Center" />
                                                 <columns >
                                                      <asp:CommandField  SelectText="+" ShowSelectButton="True" >
                                     <ItemStyle HorizontalAlign="Center" />
                                     </asp:CommandField>
                                                     <asp:BoundField DataField="code_service" HeaderText="N°" >
                                                     <ItemStyle HorizontalAlign="Center" />
                                                     </asp:BoundField>
                                                     
                                                      <%-- <asp:BoundField DataField="description_profil" HeaderText="Type partenaire" >
                                                     <ItemStyle HorizontalAlign="Center" />
                                                     </asp:BoundField>
                                                    --%>
                                                      <asp:BoundField DataField="NomUtilisateur" HeaderText="Envoyée par" >
                                                     <ItemStyle HorizontalAlign="Center" />
                                                     </asp:BoundField>

                                                      <asp:BoundField DataField="dateDemande" HeaderText="Date Demande" >   
                                                     <ItemStyle HorizontalAlign="Center" />
                                                     </asp:BoundField>
                                                     
                                                    
                                                     
                                                      
                                                     <asp:BoundField DataField="dateReponse" HeaderText="Date Réponse" >   
                                                     <ItemStyle HorizontalAlign="Center" />
                                                     </asp:BoundField>
                                                     <asp:BoundField  DataField="etat" HeaderText="Etat" >
                                                       <ItemStyle HorizontalAlign="Center" />
                                                     </asp:BoundField>
                                                        </columns>
                                                     <PagerStyle BackColor="#8da1b3" ForeColor="White" HorizontalAlign="Center" />

        <selectedrowstyle backcolor="LightCyan"
         forecolor="DarkBlue"
         font-bold="true"/> 
                                                  </asp:gridview>

									</div>
          </div>
         <br />
         <br />
                                             <div class="widget-box widget-color-blue2" id="widget-box-2">
   <div class="widget-header" >
       
													<h5 class="widget-title bigger lighter">
													<i class="ace-icon fa fa-table"></i>
											Détails
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
                                            <div style="width: 100%; height: 202px; overflow: scroll; margin-left: 0px;">
                            <asp:GridView class="table table-striped table-bordered table-hover" ID="gv_Detail" runat="server" AutoGenerateColumns="False"
                                BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" 
                                CellPadding="3" Width="99%" Height="26px">
                                <RowStyle ForeColor="#333333" HorizontalAlign="Center" />
                                <Columns>
                                   
                                    <asp:BoundField DataField="NomUtilisateur" HeaderText="Envoyée par">
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="dateDemande" HeaderText="Date demande">
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="LibelleProduit" HeaderText="Article">
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="PU" HeaderText="Prix unitaire">
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Qte" HeaderText="Quantité">
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="reponse" HeaderText="Réponse" >   
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
     
                                                <div></div>
									</div>
								</div>
                                        </div>
      </div>
         <br />
         <br />
       
   <%-- <script src="assets/js/jquery-2.1.4.min.js"></script>--%>

		<!-- <![endif]-->

		<!--[if IE]>
<script src="assets/js/jquery-1.11.3.min.js"></script>
<![endif]-->
  <%--  <script type="text/javascript" src="js/jquery.printElement.js"></script>
		<script type="text/javascript">
            if ('ontouchstart' in document.documentElement) document.write("<script src='assets/js/jquery.mobile.custom.min.js'>" + "<" + "/script>");
		</script>
	--%>

		<!-- inline scripts related to this page -->
		
    <%--<link rel="stylesheet" href="assets/css/jquery-ui.custom.min.css" />--%>

		<!-- text fonts -->
		

		<!-- ace styles -->
	

</asp:Content>

