<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" EnableEventValidation="false" AutoEventWireup="true" CodeFile="AjouterPermission.aspx.cs" Inherits="Astree.AjouterPermission" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" Runat="Server">
    
    <div class="row">
        <div class="col-sm-8  col-md-7 col-xs-8">
            <div class="dashboard_graph" >
                <div class="x_title dashboard_graph " >
                 <h2 style="color: #73879C;">Liste Permissions</h2>
                <asp:ImageButton runat="server" CssClass="pull-right" ID="Ajouter" ImageUrl="images/plus.png" OnClick="Ajouter_Click" Height="35px" />
 <asp:ImageButton runat="server" CssClass="pull-right" ID="ImageButton1" ImageUrl="images/minus1.png" OnClick="ImageButton1_Click" Height="35px"  Visible="false"/>
                  <div class="clearfix"> </div>
                </div>

                <div class="widget-box widget-color-blue2" id="widget-box-2">
   <div class="widget-header" >
       
													<h5 class="widget-title bigger lighter">
													<i class="ace-icon fa fa-table"></i>
														Permissions
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
                    <div style="width: 100%; height: 300px; overflow: scroll">
         <asp:gridview class="table table-striped table-bordered table-hover" ID="gv_Permission" runat="server" AutoGenerateColumns="False" ShowFooter="false" 
             backColor="White"  BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" 
             CellPadding="3" Width="100%" Height="160px"   >
           
             <columns>
                 <asp:BoundField DataField="code" HeaderText="Code Permission" />
                 <asp:BoundField DataField="description" HeaderText="Description" />
                 

             </columns>
         </asp:gridview> </div>
                </div>
            </div>
        </div>
        <asp:Panel runat="server" ID="PnlPer" class="col-sm-4  dashboard_graph" Visible="false" >
            <div class="x_title dashboard_graph " >
                 <h2 style="color: #73879C;">Ajouter Permission </h2>
                  <div class="clearfix"> </div>
                </div>
            <div>

                 <label  style="color:#336199" >Description</label>
	       
              <asp:TextBox ID="txtdescription" runat="server" Width="190px" /><asp:Label runat="server" ForeColor="Red">*</asp:Label>
            </div>
           <br />
              <asp:Label runat="server"  ID="MsgDesc" Text="" ForeColor="red"></asp:Label>                                   
				<br />
            <asp:Button ID="BtnAjoutPermission" runat="server" Text="Ajouter" class="btn btn-info" OnClick="BtnAjoutPermission_Click" />
    <br />
    <asp:Label ID="lblMessage1" runat="server" visible="false" ForeColor="Red" Text=""></asp:Label>
      <br />
     <asp:Label runat="server"  ID="lblSucce" Text="" ForeColor="green"></asp:Label>  	
        </asp:Panel>

    </div>
   



					

  
                                     

  
   
  
<script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
<%--<script type="text/javascript">
    $("[src*=plus]").live("click", function () {
        $(this).closest("PnlPer").after("<tr><td></td><td colspan = '999'>" + $(this).next().html() + "</td></tr>")
        $(this).attr("src", "images/minus1.png");
    });
    $("[src*=minus1]").live("click", function () {
        $(this).attr("src", "images/plus.png");
        $(this).closest("PnlPer").next().remove();
    });
</script>--%>
   <%-- <script type="text/javascript">
        if ('ontouchstart' in document.documentElement) document.write("<script src='assets/js/jquery.mobile.custom.min.js'>" + "<" + "/script>");
		</script>
	
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
		</script>--%>
    <link rel="stylesheet" href="assets/css/jquery-ui.custom.min.css" />

		<!-- text fonts -->
		

		<!-- ace styles -->
		

</asp:Content>
