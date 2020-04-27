<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" EnableEventValidation="false" AutoEventWireup="true" CodeFile="EnvoyerCommandeAFournisseur.aspx.cs" Inherits="Astree.EnvoyerCommandeAFournisseur" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="Server">
   
        <div class="row">
            <div class="col-sm-4 dashboard_graph" style="align-content: center; top: -1px; left: 0px; height: 847px;">
                <div class="x_title dashboard_graph ">
                    <h2 style="color: #73879C;">Envoyer Commande</h2>
                    <div class="clearfix"></div>
                </div>
                <asp:Label ID="description" runat="server" ForeColor="Red"></asp:Label>
                <br />
                <div class="profile-user-info ">
                    <div>
                        <div style="color: #336199">
                            Code Fournisseur&nbsp;&nbsp;&nbsp;   
                                                        <asp:TextBox runat="server" ID="Txtcode" Height="31px" Width="160px"></asp:TextBox>

                            <label style="color: red">*</label>

                        </div>
                        <asp:Label ID="MsgCodeF" runat="server" Visible="false" ForeColor="red" Text=""></asp:Label>
                        <br />


                    </div>

                    <div class="hidden">
                        <div style="color: #336199">
                            Nom fournisseur&nbsp;&nbsp;&nbsp;&nbsp;  
                                                        <asp:TextBox runat="server" ID="TxtNom"></asp:TextBox>
                            <br />
                        </div>

                        <div style="display: inline">
                        </div>
                    </div>

                    <div>
                        <div style="color: #336199">
                            Produit &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;   
                                                                                                               
                                                        <%-- 5 est le code de Gestionnaire Commande --%>
                            <asp:DropDownList ID="ddlListeP" runat="server" DataSourceID="SqlDataSource1" DataTextField="LibelleProduit" DataValueField="Id_produit" Height="34px" Width="160px"></asp:DropDownList>
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:PortailServicesConnectionString %>" SelectCommand="SELECT [Id_produit], [LibelleProduit] FROM [produit] WHERE ([code_profil] = @code_profil)">
                                <SelectParameters>
                                    <asp:Parameter DefaultValue="404" Name="code_profil" Type="Int32" />
                                </SelectParameters>
                            </asp:SqlDataSource>
                            <label style="color: red">*</label>

                            <br />

                        </div>
                        <asp:Label ID="MsgProduit" runat="server" Visible="false" ForeColor="red" Text=""></asp:Label>


                    </div>
                    <div>
                        <div style="color: #336199">
                            <br />
                            Quantité&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;   
                                                        <asp:TextBox runat="server" ID="txtQte" Height="33px" Width="160px"></asp:TextBox>
                            <label style="color: red">*</label>
                            <br />
                        </div>
                        <br />
                        <asp:Label ID="MsgQte" runat="server" Visible="false" ForeColor="red" Text=""></asp:Label>
                        <br />
                        <div style="display: inline">
                            Prix unitaire&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp; &nbsp;
                            <asp:TextBox runat="server" ID="txtPrix" Height="33px" Width="160px"></asp:TextBox>
                            <label style="color: red">
                            *</label>
                            <br />
                            <asp:Label ID="MsgPrix" runat="server" Visible="false" ForeColor="red" Text=""></asp:Label>
                            <br />
                            <asp:ImageButton runat="server" ID="ajouterListe" ImageUrl="images/plus1.png" OnClick="ajouterListe_Click" Height="40px" />
                            <br />
                            <br />
                        </div>
                        <div style="display: inline">
                        </div>
                    </div>

                    <asp:Panel runat="server" ID="liste">
                        <%-- GridView pour l'affichage de liste des produits choisis --%>
                        <div class="widget-box widget-color-blue2" id="widget_box_2" style="width: 32%">
                            <div style="width: 110%; height: 129px; overflow: scroll; margin-left: 0px;">
                                <asp:GridView class="table table-striped table-bordered table-hover" ID="gv_listeCommande" runat="server" AutoGenerateColumns="False"
                                    BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px"
                                    CellPadding="3" Width="101%" Height="26px" OnSelectedIndexChanged="gv_listeCommande_SelectedIndexChanged">
                                    <RowStyle ForeColor="#333333" HorizontalAlign="Center" />
                                    <Columns>



                                        <asp:BoundField DataField="Id_produit" HeaderText="Code article">
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="LibelleProduit" HeaderText="Libelle">
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>

                                        <asp:BoundField DataField="Qte" HeaderText="Quantité">
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="PU" HeaderText="Prix Unitaire">
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:CommandField SelectText="X" ShowSelectButton="True">
                                            <ItemStyle HorizontalAlign="Center" ForeColor="red" />
                                        </asp:CommandField>
                                    </Columns>
                                    <PagerStyle BackColor="#8da1b3" ForeColor="White" HorizontalAlign="Center" />
                                </asp:GridView>
                            </div>
                        </div>
                        <div style="display: inline">
                        </div>

                    </asp:Panel>
                    <asp:Label ID="txterror" runat="server" ForeColor="red"></asp:Label>
                    <br />
                    <div>
                        <div style="color: #336199">
                            Observation
                                                   
                                                        <br />
                            <asp:TextBox runat="server" ID="TxtBesoin" TextMode="MultiLine"></asp:TextBox><label style="color: red">*</label>
                            <%--  <asp:ImageButton runat="server" ID="importerF" ImageUrl="images/folder_small.png" Height="36px" Width="30px"   />--%>

                            <br />
                            <asp:Label ID="MsgObser" runat="server" Visible="false" ForeColor="red" Text=""></asp:Label>
                            <br />


                        </div>


                    </div>

                    <div style="height: 62px; width: 1111px">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button class="btn btn-info" runat="server" ID="BtnEnvoyer" Text="Envoyer" OnClick="BtnEnvoyer_Click"></asp:Button>
                        <br />

                        <asp:Label ID="lblMsgSuccee" Height="70px" runat="server" ForeColor="green" Text=""></asp:Label>
                        <br />
                        <label style="color: red">
                            * Des champs obligatoires
                        </label>
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                    </div>

                </div>
            </div>
            <%-- GridView pour l'affichage des fournisseur --%>
            <div class="col-sm-8 ">
                <div class=" container-fuild dashboard_graph">
                    <div class="x_title dashboard_graph ">
                        <h2 style="color: #73879C;">Liste Fournisseurs</h2>
                        <div class="clearfix"></div>
                    </div>
                    <div class="widget-box widget-color-blue2" id="widget-box-2">
                        <div class="widget-header">

                            <h5 class="widget-title bigger lighter">
                                <i class="ace-icon fa fa-table"></i>
                               Fournisseurs
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
                                </select>
                            </div>
                        </div>
                        <div style="width: 100%; height: 202px; overflow: scroll; margin-left: 0px;">
                            <asp:GridView class="table table-striped table-bordered table-hover" ID="gv_EnvoyerCommande" runat="server" AutoGenerateColumns="False"
                                BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" 
                                CellPadding="3" Width="100%" Height="26px" OnSelectedIndexChanged="gv_EnvoyerCommande_SelectedIndexChanged">
                                <RowStyle ForeColor="#333333" HorizontalAlign="Center" />
                                <Columns>


                                    <asp:CommandField SelectText="+" ShowSelectButton="True">
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:CommandField>
                                    <asp:BoundField DataField="code_utilisateur" HeaderText="Code Fournisseur ">
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Nom_utilisateur" HeaderText="Nom Fournisseur">
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>

                                    <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Détails">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="affichier" runat="server" ImageUrl="images/detail.png"
                                                OnClick="affichier_Click" CommandArgument='<%# Eval("code_utilisateur") %>'></asp:ImageButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>


                                </Columns>
                                <PagerStyle BackColor="#8da1b3" ForeColor="White" HorizontalAlign="Center" />
                            </asp:GridView>
                        </div>

                    </div>
                    <asp:Panel runat="server" CssClass=" dashboard_graph" ID="PnlInfo">
                        <asp:Label class="red lighter smaller" ID="msg" runat="server"></asp:Label>

                    </asp:Panel>
                </div>
            </div>
            <%-- GridView pour l'affichage des transaction  --%>

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
                                </select>
                            </div>
                        </div>

                        <div style="width: 100%; height: 202px; overflow: scroll; margin-left: 0px;">
                            <asp:GridView class="table table-striped table-bordered table-hover" ID="gv_Detail" runat="server" AutoGenerateColumns="False"
                                BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" OnSelectedIndexChanged="gv_Detail_SelectedIndexChanged" OnRowDataBound="gv_Detail_RowDataBound"
                                CellPadding="3" Width="99%" Height="26px">
                                <RowStyle ForeColor="#333333" HorizontalAlign="Center" />
                                <Columns>
                                  
                                     <asp:CommandField SelectText="+" ShowSelectButton="True">
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:CommandField>
                                     <asp:BoundField DataField="code_service" HeaderText="N°" >
                 <ItemStyle HorizontalAlign="Center" />
                 </asp:BoundField>
                                      <asp:BoundField DataField="code_dest" HeaderText="Code fournisseur">
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
                                    <asp:BoundField DataField="observation" HeaderText="Observation">
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>

                                   <asp:BoundField DataField="reponse" HeaderText="Réponse">
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                   
                                    <asp:BoundField DataField="dateReponse" HeaderText="Date Réponse">
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                     <%-- 
                                    <asp:BoundField DataField="etat" HeaderText="Etat">
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>--%>
                                </Columns>
                                <PagerStyle BackColor="#8da1b3" ForeColor="White" HorizontalAlign="Center" />
                            </asp:GridView>
                        </div>

                    </div>
                </div>
            </asp:Panel>

            <br />
            <br />





        </div>
   
    <link rel="stylesheet" href="assets/css/jquery-ui.custom.min.css" />

		<!-- text fonts -->
		

		<!-- ace styles -->
		

</asp:Content>
