<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="IntermidiaireSetting.aspx.cs" Inherits="Astree.IntermidiaireSetting" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" Runat="Server">
 
			
						
   
        
      
          <div class="">
            <div class="page-title">
              <div class="title_left">
                <h3 style="color: #73879C;">Paramètres Utilisateur </h3>
              </div>

              
            </div>
            
            <div class="clearfix"></div>

            <div class="row">
              <div class="col-md-12 col-sm-12 col-xs-12">
                <div class="x_panel">
                  <div class="x_title">
                     
                    <h2 style="color: #73879C;">Paramètres </h2>
                     
                   
                    <div class="clearfix"></div>
                  </div>
                  <div class="x_content">
                    <div class="col-md-3 col-sm-3 col-xs-12 profile_left">

                        	
                      <div class="profile_img">
                        <div id="crop-avatar">
                          <!-- Current avatar -->
                           
                        <span class="profile-picture">
                          <asp:Image runat="server" ID="img" class="img-responsive avatar-view editable" ImageUrl="images/img.jpg" alt="Avatar" title="Change the avatar"/>

                       </span>
                       <br />
                       <asp:Button CssClass="  bg-green" runat="server" ID="importerF"  Text="Modifier" />
                           
                      </div>
                      </div>

                        <%-- image  --%>
                        <div style="display:inline">
                          
                                                        <asp:FileUpload ID="FileUpload1" runat="server" onchange="fileinfo()" style="display:none;" /> 
                                                                     <asp:TextBox ID="TextBox1" runat="server" hidden="hidden">
                                                                   </asp:TextBox>

                                                       
                                                        <div>
                                                             <asp:Label ID="lien" runat="server" ></asp:Label>
                                                           
                                                             <br />
                                                           
                                                        </div>
													</div>
                        <%-- fin --%>
                      <h3><asp:Label Cssclass="white" runat="server" ID="TxTUserProfil"></asp:Label></h3>

                    

                 

                    

                    </div>
                    <div class="col-md-9 col-sm-9 col-xs-12">

                      <div class="profile_title">
                        <div class="col-md-6">
                          <h2 style="color: #73879C;">Modfier Profil </h2>
                        </div>
                      
                      </div>
                        
                        <br />
                        <br />

												<div style="align-content:center" >
													<asp:Label runat="server" style="color:#336199"> Gouvernerat </asp:Label>
                                                     &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
													
													
                                                        <asp:TextBox runat="server" id="Txtgouvernerat" ></asp:TextBox>&nbsp;<i class="fa fa-map-marker  bigger-110 " style="color:mediumseagreen" >&nbsp;</i><br />
                                                       &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                    <br />
                                                   <asp:Label runat="server" style="color:#336199"> Ville</asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp; &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                        <asp:TextBox runat="server" id="TxtVille" ></asp:TextBox> <i class="fa fa-map-marker light-orange bigger-110" style="color:mediumseagreen" ></i>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                    <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
													
												</div>
                       			

									 <div >
												<asp:Label runat="server" style="color:#336199"> Téléphone</asp:Label>

													
                                                        &nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox Cssclass="input-medium input-mask-phone" id="Txttel" runat="server" Width="171px"   ></asp:TextBox>
                                                        <i class="ace-icon fa fa-phone fa-flip-horizontal light-orange" style="color:mediumseagreen" ></i>
													
												</div>
                         <br />
                        <div >
													<asp:Label runat="server" style="color:#336199"> Mot de passe </asp:Label>
												
                                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
												
                                                        <asp:TextBox id="Txtpsw" runat="server" TextMode="Password" ></asp:TextBox>&nbsp;<i class="fa fa-lock light-orange bigger-110" style="color:mediumseagreen" ></i><br />
												<asp:Label runat="server" ID="MsgPasse" ForeColor="red" text=""></asp:Label>
                            <br />
												</div>
                        <div >
													<asp:Label runat="server" style="color:#336199"> Retapez le mot de passe </asp:Label>
												
                                                        <asp:TextBox id="txtpsw2" runat="server" TextMode="Password" ></asp:TextBox>&nbsp;<i class="fa fa-retweet light-orange bigger-110" style="color:mediumseagreen" ></i> <br />
                            <asp:Label runat="server" ID="txtPasse2" ForeColor="red" text=""></asp:Label>
												
												</div>

                         <br />
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
											<asp:Button class="btn btn-info" runat="server" ID="Btnsave" OnClick="Btnsave_Click" Text="Sauvegarder" > 
												
												
											</asp:Button>

                                          
                        <br />
                                                		<div class="space-12">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </div>
										<div >
											&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

                                          
										</div>
                      
                    
                  </div>
                </div>
              </div>
            </div>
          </div>
        
       
       
   <script language="javascript" type="text/javascript">
        function fileinfo() {
            document.getElementById('<%=TextBox1.ClientID%>').value = document.getElementById('<%=FileUpload1.ClientID%>').value;
            document.getElementById('<%=lien.ClientID%>').innerText = document.getElementById('<%=FileUpload1.ClientID%>').value;
        }
        
    </script>
	
    <script src="vendors/jquery/dist/jquery.min.js"></script>
    <!-- Bootstrap -->
    <script src="vendors/bootstrap/dist/js/bootstrap.min.js"></script>
    <!-- FastClick -->
    <script src="vendors/fastclick/lib/fastclick.js"></script>
    <!-- NProgress -->
    <script src="vendors/nprogress/nprogress.js"></script>
    <!-- Chart.js -->
    <script src="vendors/Chart.js/dist/Chart.min.js"></script>
    <!-- gauge.js -->
    <script src="vendors/gauge.js/dist/gauge.min.js"></script>
    <!-- bootstrap-progressbar -->
    <script src="vendors/bootstrap-progressbar/bootstrap-progressbar.min.js"></script>
    <!-- iCheck -->
    <script src="vendors/iCheck/icheck.min.js"></script>
    <!-- Skycons -->
    <script src="vendors/skycons/skycons.js"></script>
    <!-- Flot -->
    <script src="vendors/Flot/jquery.flot.js"></script>
    <script src="vendors/Flot/jquery.flot.pie.js"></script>
    <script src="vendors/Flot/jquery.flot.time.js"></script>
    <script src="vendors/Flot/jquery.flot.stack.js"></script>
    <script src="vendors/Flot/jquery.flot.resize.js"></script>
    <!-- Flot plugins -->
    <script src="vendors/flot.orderbars/js/jquery.flot.orderBars.js"></script>
    <script src="vendors/flot-spline/js/jquery.flot.spline.min.js"></script>
    <script src="vendors/flot.curvedlines/curvedLines.js"></script>
    <!-- DateJS -->
    <script src="vendors/DateJS/build/date.js"></script>
    <!-- JQVMap -->
    <script src="vendors/jqvmap/dist/jquery.vmap.js"></script>
    <script src="vendors/jqvmap/dist/maps/jquery.vmap.world.js"></script>
    <script src="vendors/jqvmap/examples/js/jquery.vmap.sampledata.js"></script>
    <!-- bootstrap-daterangepicker -->
    <script src="vendors/moment/min/moment.min.js"></script>
    <script src="vendors/bootstrap-daterangepicker/daterangepicker.js"></script>

    <!-- Custom Theme Scripts -->
    <script src="build/js/custom.min.js"></script>
    <script src="vendors/jquery/dist/jquery.min.js"></script>
    <!-- Bootstrap -->
    <script src="vendors/bootstrap/dist/js/bootstrap.min.js"></script>
    <!-- FastClick -->
    <script src="vendors/fastclick/lib/fastclick.js"></script>
    <!-- NProgress -->
    <script src="vendors/nprogress/nprogress.js"></script>
    <!-- bootstrap-daterangepicker -->
    <script src="vendors/moment/min/moment.min.js"></script>
    <script src="vendors/bootstrap-daterangepicker/daterangepicker.js"></script>
    <!-- bootstrap-datetimepicker -->    
    <script src="vendors/bootstrap-datetimepicker/build/js/bootstrap-datetimepicker.min.js"></script>
    <!-- Ion.RangeSlider -->
    <script src="vendors/ion.rangeSlider/js/ion.rangeSlider.min.js"></script>
    <!-- Bootstrap Colorpicker -->
    <script src="vendors/mjolnic-bootstrap-colorpicker/dist/js/bootstrap-colorpicker.min.js"></script>
    <!-- jquery.inputmask -->
    <script src="vendors/jquery.inputmask/dist/min/jquery.inputmask.bundle.min.js"></script>
    <!-- jQuery Knob -->
    <script src="vendors/jquery-knob/dist/jquery.knob.min.js"></script>
    <!-- Cropper -->
    <script src="vendors/cropper/dist/cropper.min.js"></script>

    <!-- Custom Theme Scripts -->
    <script src="build/js/custom.min.js"></script>
    
    <!-- Initialize datetimepicker -->
    <script>

  
    $('#myDatepicker').datetimepicker();
    
   
  
</script>

             

		<!--[if lte IE 8]>
		  <script src="assets/js/excanvas.min.js"></script>
		<![endif]-->
		
		

		
		
	
    
      
 
    </div>
</asp:Content>

