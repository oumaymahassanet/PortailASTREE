<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" EnableEventValidation="false" AutoEventWireup="true" CodeFile="DemanderDerogation.aspx.cs" Inherits="Astree.DemanderDerogation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" Runat="Server">
  
        <div class="row">
    <div class="col-sm-4  dashboard_graph" style="align-content:center; top: -1px; left: 0px; height: 687px;">
                <div class="x_title dashboard_graph " >
                 <h2 style="color: #73879C;">Envoyer Dérogation</h2>
                  <div class="clearfix"> </div>
                </div>
    <div class="form-group ">    		
	<div >
											<label style="color:#336199" > Type&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp; </label>
                                            &nbsp;<asp:DropDownList ID="ddltype" class="multiselect" runat="server" Width="149px" OnSelectedIndexChanged="ddltype_SelectedIndexChanged"
                                                     AutoPostBack="true"   DataValueField="Id_type" DataTextField="libelle"  DataSourceID="SqlDataSourceType" Height="36px" >
                                                        <asp:ListItem Text="Choose a State..." Value=""   />
                                                    </asp:DropDownList>
			<label style="color:red">*</label>
        									<asp:SqlDataSource ID="SqlDataSourceType" runat="server" ConnectionString="<%$ ConnectionStrings:PortailServicesConnectionString %>" SelectCommand="SELECT * FROM [type_service] WHERE ([famille_type] = @famille_type)">
                                                <SelectParameters>
                                                    <asp:Parameter DefaultValue="Derogation" Name="famille_type" Type="String" />
                                                </SelectParameters>
                                            </asp:SqlDataSource>
	
										</div>

    </div>
        <asp:Label ID="MsgddlType" runat="server" visible="false" Forecolor="red" Text=""></asp:Label>
											<br />
        <br />
    <div class="form-group">
                                              
										<div >
											<label style="color:#336199"> Risque&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; </label>
                                                     <asp:DropDownList ID="ddlproduit" class="multiselect" runat="server" Width="149px" AutoPostBack="true"
                                                        DataValueField="Id_branche" DataTextField="libelle" OnSelectedIndexChanged="ddlproduit_SelectedIndexChanged" DataSourceID="SqlDataSourceBranche" Height="35px" >
                                                        <asp:ListItem Text="Choose a State..." Value=""   />
                                                    </asp:DropDownList>
                                            <label style="color:red">*</label>
                                            <asp:SqlDataSource ID="SqlDataSourceBranche" runat="server" ConnectionString="<%$ ConnectionStrings:PortailServicesConnectionString %>" SelectCommand="SELECT * FROM [branche]">

											</asp:SqlDataSource>
										</div>

    </div>
                                            <asp:Label ID="MsgddlP" runat="server" visible="false" Forecolor="red" Text=""></asp:Label>
											<br />
        <br />
    <div class="form-group ">
                          
										<div >
                                            <label style="color:#336199"> Sous-Risque&nbsp; </label>&nbsp;<asp:DropDownList ID="ddlsousproduit" class="multiselect" runat="server" Width="149px"  AutoPostBack="true"
                                                        DataValueField="Id_sous_branche" DataTextField="libelle"  DataSourceID="SqlDataSourceSousbranche" Height="36px" >
                                                        <asp:ListItem Text="Choose a State..." Value=""/>
                                                    </asp:DropDownList>
                                            <label style="color:red">*</label>
                                                <asp:SqlDataSource ID="SqlDataSourceSousbranche" runat="server" ConnectionString="<%$ ConnectionStrings:PortailServicesConnectionString %>" SelectCommand="SELECT * FROM [sous_branche] WHERE ([Id_branche] = @Id_branche)">
                                                    <SelectParameters>
                                                        <asp:ControlParameter ControlID="ddlproduit" Name="Id_branche" PropertyName="SelectedValue" Type="Int32" />
                                                    </SelectParameters>
                                            </asp:SqlDataSource>
												
											</div>
											
  </div>
                                            <asp:Label ID="MsgddlSP" runat="server" visible="false" Forecolor="red" Text=""></asp:Label>
                                                <br />
        <br />
    <div class="form-group ">
         <asp:Panel ID="PnlNumContrat"  runat="server">
       <label style="color:#336199">N° Contrat&nbsp; </label>
             &nbsp;&nbsp;&nbsp;&nbsp;
		  <asp:TextBox ID="txtnumcontrat" runat="server" Width="149px" Height="36px" />
            <label style="color:red">*</label>
              <br />
            <br />
            
            <asp:Label ID="MsgContrat" runat="server" visible="false" Forecolor="red" Text=""></asp:Label>
               <br />
            </asp:Panel>
            </div>
    <div class="form-group ">
        <asp:Panel ID="pnlDuree"  runat="server">                   
   <asp:Label ID="lblDuree"  style="color:#336199" runat="server" Text="Durée"></asp:Label>			
            &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;			
     <asp:TextBox ID="txtduree" runat="server" Width="149px" Height="37px" /> 
			 <label style="color:red">*</label>		
            (Par mois)<br />&nbsp;<asp:Label ID="MsgDuree" runat="server" Forecolor="red" Text="" visible="false"></asp:Label>
            &nbsp;<br />
            </asp:Panel>
            </div>
    <div class="form-group ">
            <asp:Panel ID="pnlTaux"  runat="server">
               <asp:Label ID="lbltaux" style="color:#336199" runat="server" Text="Taux"></asp:Label>
		        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
		       <asp:TextBox ID="txttaux"  TextMode="Number" runat="server" Width="150px" Height="37px" />
                 <label style="color:red">*</label>
                </asp:Panel>
            </div>
                <asp:Label ID="MsgTaux" runat="server" visible="false" Forecolor="red" Text=""></asp:Label>
        <br />
    <div class="form-group">
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button1" runat="server" class="btn btn-info" Text="Envoyer"   Onclick="BtnAjoutDerogation_Click" />
    
        
            </div>
        <div>
            <asp:Label ID="lblMsg" Forecolor="red" runat="server" visible="false"  Text="aaa"></asp:Label>
           <asp:Label ID="lblMsgSucces" Forecolor="Green" runat="server" visible="false"  Text="aaa"></asp:Label>
            <br />

            <label style="color:red">* Des champs obligatoires
            </label>
           
        <br />
     
 				
          
           
        &nbsp;</div>
           </div>
    <div class="col-sm-8 ">
               <div  class=" container-fuild dashboard_graph">
             <div class="x_title dashboard_graph " >
                 <h2 style="color: #73879C;">Liste Dérogations</h2>
                  <div class="clearfix"> </div>
              </div>

            <div class="widget-box widget-color-blue2" id="widget-box-2">
             <div class="widget-header" >
       
													<h5 class="widget-title bigger lighter">
													<i class="ace-icon fa fa-table"></i>
														Dérogations Envoyées
													</h5>

												</div>
             <div style="width: 100%; height:305px; overflow: scroll">

			<asp:gridview  style=" overflow:auto"  ID="gv_Derogation" class="table table-striped table-bordered table-hover"  runat="server" AllowPaging="True" CellPadding="1" 
       GridLines="None" Height="87px" Width="1092px" AutoGenerateColumns="false" CellSpacing="1" BorderStyle="None" 
                           OnPageIndexChanging="gv_Derogation_PageIndexChanging" PageSize="4" >
          <RowStyle  ForeColor="#333333" HorizontalAlign="Center" />
          
             <columns >
                <asp:BoundField  DataField="code_service" HeaderText="Id Dérogation" >
                   <ItemStyle HorizontalAlign="Center" />
                 </asp:BoundField>
                   <asp:BoundField DataField="libelleType" HeaderText="Type Dérogation" >
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
                 <asp:BoundField  DataField="numContrat" HeaderText="Num Contrat" >
                 <ItemStyle HorizontalAlign="Center" />
                 </asp:BoundField>
                 <asp:BoundField DataField="taux" HeaderText="Taux voulu" >   
                 <ItemStyle HorizontalAlign="Center" />
                 </asp:BoundField>
                 <asp:BoundField  DataField="etat" HeaderText="Etat" >
                 <ItemStyle HorizontalAlign="Center" />
                 </asp:BoundField>
                 <asp:BoundField  DataField="reponse" HeaderText="Réponse" >
                 <ItemStyle HorizontalAlign="Center" />
                 </asp:BoundField>
                  <asp:BoundField  DataField="dateReponse" HeaderText="Date Réponse" >
                 <ItemStyle HorizontalAlign="Center" />
                 </asp:BoundField>
                 
            </columns>
           <PagerStyle BackColor="#8da1b3" ForeColor="White" HorizontalAlign="Center"  />
         </asp:gridview> 
		
        <%-- Prorogation --%>
                            

        <asp:gridview  ID="gvProrogation" class="table table-striped table-bordered table-hover"  runat="server" AllowPaging="True" CellPadding="1" 
       GridLines="None" Height="16px" Width="1200px" AutoGenerateColumns="false" CellSpacing="1" BorderStyle="None" 
                           OnPageIndexChanging="gvProrogation_PageIndexChanging" PageSize="4" >
          <RowStyle  ForeColor="#333333" HorizontalAlign="Center" />
          
             <columns >
                <asp:BoundField  DataField="code_service" HeaderText="Id Dérogation" >
                   <ItemStyle HorizontalAlign="Center" />
                 </asp:BoundField>
                   <asp:BoundField DataField="libelleType" HeaderText="Type Dérogation" >
                 <ItemStyle HorizontalAlign="Center" />
                 </asp:BoundField>
                 <asp:BoundField DataField="libelleBranche"  HeaderText="Risque" >
                 <ItemStyle HorizontalAlign="Center" />
                 </asp:BoundField>
                 <asp:BoundField DataField="libelleSousbranche"  HeaderText="Sous Risque" >
                 <ItemStyle HorizontalAlign="Center" />
                 </asp:BoundField>
                 <asp:BoundField DataField="dateDemande" HeaderText="Date Demande" >
                 <ItemStyle HorizontalAlign="Center" />
                 </asp:BoundField>
                 <asp:BoundField  DataField="numContrat" HeaderText="Num Contrat" >
                 <ItemStyle HorizontalAlign="Center" />
                 </asp:BoundField>
                 <asp:BoundField DataField="duree" HeaderText="Durée(mois)" >
                 <ItemStyle HorizontalAlign="Center" />
                 </asp:BoundField> 
                 <asp:BoundField  DataField="etat" HeaderText="Etat" >
                 <ItemStyle HorizontalAlign="Center" />
                 </asp:BoundField>
                 <asp:BoundField  DataField="reponse" HeaderText="Réponse" >
                 <ItemStyle HorizontalAlign="Center" />
                 </asp:BoundField>
                  <asp:BoundField  DataField="dateReponse" HeaderText="Date Réponse" >
                 <ItemStyle HorizontalAlign="Center" />
                 </asp:BoundField>
             </columns>
             <PagerStyle BackColor="#8da1b3" ForeColor="White" HorizontalAlign="Center" />
             </asp:gridview> 
		
        <%-- Souscription --%>

        <asp:gridview  ID="gvSouscription" class="table table-striped table-bordered table-hover"  runat="server" AllowPaging="True" CellPadding="1" 
       GridLines="None" Height="16px" Width="1200px" AutoGenerateColumns="false" CellSpacing="1" BorderStyle="None" 
                           OnPageIndexChanging="gvSouscription_PageIndexChanging" PageSize="6" >
          <RowStyle  ForeColor="#333333" HorizontalAlign="Center" />
          
             <columns >
                <asp:BoundField  DataField="code_service" HeaderText="Id Dérogation" >
                   <ItemStyle HorizontalAlign="Center" />
                 </asp:BoundField>
                   <asp:BoundField DataField="libelleType" HeaderText="Type Dérogation" >
                 <ItemStyle HorizontalAlign="Center" />
                 </asp:BoundField>
                 <asp:BoundField DataField="libelleBranche"  HeaderText="Risque" >
                 <ItemStyle HorizontalAlign="Center" />
                 </asp:BoundField>
                 <asp:BoundField DataField="libelleSousbranche"  HeaderText="Sous Risque" >
                 <ItemStyle HorizontalAlign="Center" />
                 </asp:BoundField>
                 <asp:BoundField DataField="dateDemande" HeaderText="Date Demande" >
                 <ItemStyle HorizontalAlign="Center" />
                 </asp:BoundField>
                 <asp:BoundField  DataField="numContrat" HeaderText="Num Contrat" >
                 <ItemStyle HorizontalAlign="Center" />
                 </asp:BoundField>
                 
                 
                 
                 <asp:BoundField  DataField="etat" HeaderText="Etat" >
                 <ItemStyle HorizontalAlign="Center" />
                 </asp:BoundField>
                 <asp:BoundField  DataField="reponse" HeaderText="Réponse" >
                 <ItemStyle HorizontalAlign="Center" />
                 </asp:BoundField>
                  <asp:BoundField  DataField="dateReponse" HeaderText="Date Réponse" >
                 <ItemStyle HorizontalAlign="Center" />
                 </asp:BoundField>
                 
                
             </columns>
                                         <PagerStyle BackColor="#8da1b3" ForeColor="White" HorizontalAlign="Center" />

         </asp:gridview> </div>
                 </div>
                    </div>
    </div>

</div>
		<!-- HTML5shiv and Respond.js for IE8 to support HTML5 elements and media queries -->

		<!--[if lte IE 8]>
		<script src="assets/js/html5shiv.min.js"></script>
		<script src="assets/js/respond.min.js"></script>
		<![endif]-->
	




   
   
<script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
<script type="text/javascript">
    $("[src*=plus]").live("click", function () {
        $(this).closest("tr").after("<tr><td></td><td colspan = '999'>" + $(this).next().html() + "</td></tr>")
        $(this).attr("src", "images/minus.png");
    });
    $("[src*=minus]").live("click", function () {
        $(this).attr("src", "images/plus.png");
        $(this).closest("tr").next().remove();
    });
</script>
    <script type="text/javascript">
        if ('ontouchstart' in document.documentElement) document.write("<script src='assets/js/jquery.mobile.custom.min.js'>" + "<" + "/script>");
		</script>
		<script src="assets/js/bootstrap.min.js"></script>

		<!-- page specific plugin scripts -->
		<script src="assets/js/jquery-ui.custom.min.js"></script>
		<script src="assets/js/jquery.ui.touch-punch.min.js"></script>

		<!-- ace scripts -->
		<script src="assets/js/ace-elements.min.js"></script>
		<script src="assets/js/ace.min.js"></script>

		<!-- inline scripts related to this page -->
		<script type="text/javascript">
            jQuery(function ($) {

                $('#simple-colorpicker-1').ace_colorpicker({ pull_right: true }).on('change', function () {
                    var color_class = $(this).find('option:selected').data('class');
                    var new_class = 'widget-box';
                    if (color_class != 'default') new_class += ' widget-color-' + color_class;
                    $(this).closest('.widget-box').attr('class', new_class);
                });


                // scrollables
                $('.scrollable').each(function () {
                    var $this = $(this);
                    $(this).ace_scroll({
                        size: $this.attr('data-size') || 100,
                        //styleClass: 'scroll-left scroll-margin scroll-thin scroll-dark scroll-light no-track scroll-visible'
                    });
                });
                $('.scrollable-horizontal').each(function () {
                    var $this = $(this);
                    $(this).ace_scroll(
                        {
                            horizontal: true,
                            styleClass: 'scroll-top',//show the scrollbars on top(default is bottom)
                            size: $this.attr('data-size') || 500,
                            mouseWheelLock: true
                        }
                    ).css({ 'padding-top': 12 });
                });

                $(window).on('resize.scroll_reset', function () {
                    $('.scrollable-horizontal').ace_scroll('reset');
                });


                $('#id-checkbox-vertical').prop('checked', false).on('click', function () {
                    $('#widget-toolbox-1').toggleClass('toolbox-vertical')
                        .find('.btn-group').toggleClass('btn-group-vertical')
                        .filter(':first').toggleClass('hidden')
                        .parent().toggleClass('btn-toolbar')
                });

				/**
				//or use slimScroll plugin
				$('.slim-scrollable').each(function () {
					var $this = $(this);
					$this.slimScroll({
						height: $this.data('height') || 100,
						railVisible:true
					});
				});
				*/


				/**$('.widget-box').on('setting.ace.widget' , function(e) {
					e.preventDefault();
				});*/

				/**
				$('.widget-box').on('show.ace.widget', function(e) {
					//e.preventDefault();
					//this = the widget-box
				});
				$('.widget-box').on('reload.ace.widget', function(e) {
					//this = the widget-box
				});
				*/

                //$('#my-widget-box').widget_box('hide');



                // widget boxes
                // widget box drag & drop example
                $('.widget-container-col').sortable({
                    connectWith: '.widget-container-col',
                    items: '> .widget-box',
                    handle: ace.vars['touch'] ? '.widget-title' : false,
                    cancel: '.fullscreen',
                    opacity: 0.8,
                    revert: true,
                    forceHelperSize: true,
                    placeholder: 'widget-placeholder',
                    forcePlaceholderSize: true,
                    tolerance: 'pointer',
                    start: function (event, ui) {
                        //when an element is moved, it's parent becomes empty with almost zero height.
                        //we set a min-height for it to be large enough so that later we can easily drop elements back onto it
                        ui.item.parent().css({ 'min-height': ui.item.height() })
                        //ui.sender.css({'min-height':ui.item.height() , 'background-color' : '#F5F5F5'})
                    },
                    update: function (event, ui) {
                        ui.item.parent({ 'min-height': '' })
                        //p.style.removeProperty('background-color');


                        //save widget positions
                        var widget_order = {}
                        $('.widget-container-col').each(function () {
                            var container_id = $(this).attr('id');
                            widget_order[container_id] = []


                            $(this).find('> .widget-box').each(function () {
                                var widget_id = $(this).attr('id');
                                widget_order[container_id].push(widget_id);
                                //now we know each container contains which widgets
                            });
                        });

                        ace.data.set('demo', 'widget-order', widget_order, null, true);
                    }
                });


                ///////////////////////

                //when a widget is shown/hidden/closed, we save its state for later retrieval
                $(document).on('shown.ace.widget hidden.ace.widget closed.ace.widget', '.widget-box', function (event) {
                    var widgets = ace.data.get('demo', 'widget-state', true);
                    if (widgets == null) widgets = {}

                    var id = $(this).attr('id');
                    widgets[id] = event.type;
                    ace.data.set('demo', 'widget-state', widgets, null, true);
                });


                (function () {
                    //restore widget order
                    var container_list = ace.data.get('demo', 'widget-order', true);
                    if (container_list) {
                        for (var container_id in container_list) if (container_list.hasOwnProperty(container_id)) {

                            var widgets_inside_container = container_list[container_id];
                            if (widgets_inside_container.length == 0) continue;

                            for (var i = 0; i < widgets_inside_container.length; i++) {
                                var widget = widgets_inside_container[i];
                                $('#' + widget).appendTo('#' + container_id);
                            }

                        }
                    }


                    //restore widget state
                    var widgets = ace.data.get('demo', 'widget-state', true);
                    if (widgets != null) {
                        for (var id in widgets) if (widgets.hasOwnProperty(id)) {
                            var state = widgets[id];
                            var widget = $('#' + id);
                            if
							(
                                (state == 'shown' && widget.hasClass('collapsed'))
                                ||
                                (state == 'hidden' && !widget.hasClass('collapsed'))
                            ) {
                                widget.widget_box('toggleFast');
                            }
                            else if (state == 'closed') {
                                widget.widget_box('closeFast');
                            }
                        }
                    }


                    $('#main-widget-container').removeClass('invisible');


                    //reset saved positions and states
                    $('#reset-widgets').on('click', function () {
                        ace.data.remove('demo', 'widget-state');
                        ace.data.remove('demo', 'widget-order');
                        document.location.reload();
                    });

                })();

            });
		</script>

            <link rel="stylesheet" href="assets/css/jquery-ui.custom.min.css" />

		<!-- text fonts -->
		

		<!-- ace styles -->
		
</asp:Content>



