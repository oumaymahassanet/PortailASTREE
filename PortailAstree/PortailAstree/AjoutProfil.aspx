<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" EnableEventValidation="false" AutoEventWireup="true" CodeFile="AjoutProfil.aspx.cs" Inherits="Astree.AjoutProfil" %>



<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" Runat="Server">
    <div class="col-sm-5 col-md-5 col-xs-8">
            <div class="dashboard_graph" style="align-content:center; top: -1px; left: 0px; height: 662px;">
             <div class="x_title dashboard_graph " >
                 <h2 style="color: #73879C; height: 19px;">Liste Profiles </h2>
                  <asp:ImageButton runat="server" CssClass="pull-right" ID="Ajouter" ImageUrl="images/plus.png" OnClick="Ajouter_Click" Height="35px" />
 <asp:ImageButton runat="server" CssClass="pull-right" ID="ImageButton2" ImageUrl="images/minus1.png" OnClick="ImageButton2_Click" Height="35px"  Visible="false"/>
                  <div class="clearfix"> </div>
                </div>

            <div class="widget-box widget-color-blue2" id="widget-box-2">
   <div class="widget-header" >
       
													<h5 class="widget-title bigger lighter">
													<i class="ace-icon fa fa-table"></i>
														Profiles
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
       
      
  <div style="width: 100%; height:437px; overflow: scroll">
         <asp:GridView class="table table-striped table-bordered table-hover" ID="gv_Profil" runat="server" AutoGenerateColumns="False"  
        selectedindex="1"
             backColor="White"  BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" 
             CellPadding="3"  Width="100%" Height="160px" OnSelectedIndexChanged="gv_Profil_SelectedIndexChanged" OnSelectedIndexChanging="gv_Profil_SelectedIndexChanging" 
             DataKeyNames="code" OnRowDataBound="OnRowDataBound">
        <Columns>
            <asp:CommandField  SelectText="+" ShowSelectButton="True" >
                 <ItemStyle HorizontalAlign="Center" />
                 </asp:CommandField> 
         <asp:TemplateField>
            <ItemStyle HorizontalAlign="Center" />
                <ItemTemplate>
                    <img alt = "" style="cursor: pointer" src="images/plus1.png" />
                    <asp:Panel ID="pnlOrders" runat="server" Style="display: none">
                        <asp:GridView ID="gvPermission" runat="server" AutoGenerateColumns="false" class="table table-striped table-bordered table-hover">
                            <Columns>
                                <asp:BoundField ItemStyle-Width="200px" DataField="codePermission" HeaderText="code permission" >
                                <ItemStyle HorizontalAlign="Center" />
                                   
                     </asp:BoundField>
                                <asp:BoundField ItemStyle-Width="200px" DataField="descriptionPermission" HeaderText="Description" >
                                <ItemStyle HorizontalAlign="Center" />
                                    
                     </asp:BoundField>
                            </Columns>
                        </asp:GridView>
                    </asp:Panel>
                </ItemTemplate>
            </asp:TemplateField>
             
            
            <asp:BoundField DataField="code" HeaderText="Code Profil" >
                
                 <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                
                 <ItemStyle HorizontalAlign="Center" />
                     </asp:BoundField>
         
                    
            <asp:BoundField DataField="libelle" HeaderText="Libelle" >
               <ItemStyle HorizontalAlign="Center" />
           
                     </asp:BoundField>
        </Columns>

 

    </asp:GridView>

        </div>



     </div>
         <br/><asp:label id="MessageLabel" forecolor="Red" runat="server"/> 
    
       </div>
       
</div>
       <asp:Panel runat="server" ID="PnlProfil" class="col-sm-7 " Visible="false">
           
           <div class=" dashboard_graph">

                <div class="x_title dashboard_graph " >
                 <h2 style="color: #73879C;">Ajouter un profil </h2>
                  <div class="clearfix"> </div>
                </div>
      <%-- les text box --%>                     
    <div >
                                          <label style="color:#336199" >Code Profile&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </label>

											
												 &nbsp;<asp:TextBox ID="txtcode" runat="server" Height="31px" /><asp:Label runat="server" ForeColor="red" >*</asp:Label>
											
										</div>
               <br />
               <asp:Label runat="server" ID="MsgCode" ForeColor="Red" Text=""></asp:Label>
               <br />
								
    <div >
                                       <label style="color:#336199">Libelle Profile&nbsp;&nbsp;&nbsp; </label>
                                      &nbsp;<asp:TextBox ID="txtlibelle" runat="server" Height="31px" /><asp:Label runat="server" ForeColor="red" >*</asp:Label>
										</div>
               <br />
               <asp:Label runat="server" ID="MsgProfil" ForeColor="Red" Text=""></asp:Label>
               <br />
						
    <div style="height: 79px" >
           &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
           <asp:Button ID="BtnAjoutProfil" runat="server" Text="Ajouter" class="btn btn-info" OnClick="BtnAjoutProfil_Click" />
        <br />	
    <asp:Label ID="lblMessage1" runat="server" visible="false" ForeColor="green" Text=""></asp:Label>
    </div>
              
						
           </div>
   
        
           <br  class="well"/>
            <%-- Move all  --%>
          
           <asp:Panel runat="server" ID="PnlAffecter" class="dashboard_graph" visible="false">
                <div class="x_title dashboard_graph " >
                 <h2 style="color: #73879C;">Affecter Permissions</h2>
                  <div class="clearfix"> </div>
                </div>
    <div >
    <div class="bootstrap-duallistbox-container row moveonselect"> 
                                                <div class="box1 col-md-6">  
                                                   
                                                    <div style="width: 68px" >    
                                                     
                                                         <asp:ImageButton id="btnMoveAll" class=" btn moveall  btn-info smaller " ImageUrl="~/assets/images/gallery/moveall.png"
                                                           Text="move all" 
                                                           OnClick="btnMoveAll_Click" 
                                                           runat="server" Height="51px" Width="377px" />

                                                    </div>  
                                                   

                                                     <asp:ListBox id="lstpermission"  class="form-control"  style="height:150px;" 
                                                    DataSourceID="SqlDataSource1" DataTextField="description" DataValueField="code_permission"
                                                    
                                                    SelectionMode="Multiple" 
                                                    runat="server" >

                                                    

                                                </asp:ListBox>

                                     <asp:ImageButton id="btnAddOne" 
                                                           Text=">"  class="pull-right btn btn-sm btn-primary btn-white btn-round"
                                                           OnClick="btnAddOne_Click" ImageUrl="~/assets/images/gallery/ad.png"
                                                           runat="server" />

     
      <br />
                                                    <br />


                                                    <asp:Button ID="btnAffecter" runat="server" Text="Affecter" class="btn btn-info" OnClick="btnAffecter_Click" />

     <br />
                                                    
    <asp:Label ID="lblsuccee" runat="server" visible="false" ForeColor="green" Text=""></asp:Label> <br />	
      

                                                </div> 
        
                                                <div class="box2 col-md-6">  
                                              
                                                <div style="width: 40px" >
                                                     <asp:ImageButton id="ImageButton1" class="btn moveall  btn-info smaller " ImageUrl="images/RemoveAll.png"
                                                           Text="move all" 
                                                           OnClick="btnMoveAll_Click" 
                                                           runat="server" Height="50px" Width="376px" />
                                          
                                              <%--<asp:ImageButton id="btnRemoveAll" class="btn moveall btn-white btn-bold btn-info smaller" ImageUrl="~/assets/images/gallery/RemoveAll.png"
                                                           Text="Remove all" 
                                                           OnClick="btnRemoveAll_Click" 
                                                        --%>   
                                                </div>  
                                               <%-- <select multiple="multiple" id="bootstrap-duallistbox-selected-list_duallistbox_demo1[]" class="form-control" name="duallistbox_demo1[]_helper2" style="height: 250px;">

                                                </select>--%>

                                                    <asp:ListBox id="lstChoisies"  class="form-control"  style="height: 150px;"                                                    
                                                    SelectionMode="Multiple" 
                                                    runat="server" AutoPostBack="True" >

                                                    

                                                </asp:ListBox>

                                                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:PortailServicesConnectionString %>" SelectCommand="SELECT * FROM [permission]"></asp:SqlDataSource>
                                                     <asp:ImageButton id="btnRemoveOne"  
                                                           Text="<" class="pull-right btn btn-sm btn-primary btn-white btn-round"
                                                           OnClick="btnRemoveOne_Click" ImageUrl="~/assets/images/gallery/rmove.png"
                                                           runat="server" />
                                                </div>

 </div>


       
		
         
        </div>
    </asp:Panel>
         </asp:Panel>
    <%-- La gridView  --%>
       
  


   































     
    
    <script type="text/javascript">
        $("[src*=plus1]").live("click", function () {
            $(this).closest("tr").after("<tr><td></td><td colspan = '999'>" + $(this).next().html() + "</td></tr>")
            $(this).attr("src", "images/minus.png");
        });
        $("[src*=minus]").live("click", function () {
            $(this).attr("src", "images/plus1.png");
            $(this).closest("tr").next().remove();
        });
</script>

 
<script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>

    <script type="text/javascript">
        if ('ontouchstart' in document.documentElement) document.write("<script src='assets/js/jquery.mobile.custom.min.js'>" + "<" + "/script>");
		</script>
		
    <%-- <script type="text/javascript">
        $("[src*=plus1]").live("click", function () {
            $(this).closest("tr").after("<tr><td></td><td colspan = '999'>" + $(this).next().html() + "</td></tr>")
            $(this).attr("src", "images/minus.png");
        });
        $("[src*=minus]").live("click", function () {
            $(this).attr("src", "images/plus1.png");
            $(this).closest("tr").next().remove();
        });
</script>--%>

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


    <script type="text/javascript">
            if ('ontouchstart' in document.documentElement) document.write("<script src='assets/js/jquery.mobile.custom.min.js'>" + "<" + "/script>");
		</script>
		<link rel="stylesheet" href="assets/css/jquery-ui.custom.min.css" />

		<!-- text fonts -->
		

		<!-- ace styles -->
	

</asp:Content>


