<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" Runat="Server">
    
  
          <div class="row tile_count dashboard_graph">
              <div class="x_title">
                  <h2 style="color: #73879C;">Information Génèrales</h2>
                  
                  <div class="clearfix"></div>
                </div>
            <div class="col-md-2 col-sm-4 col-xs-6 tile_stats_count" >
                <br />
                
             &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <span class="count_top" style=" color: #73879C; font-size:unset; font-family:'Helvetica Neue',Roboto,Arial,'Droid Sans',sans-serif;font-weight: 400;
    line-height: 1.471;text-align:center; "><i class="fa fa-user"></i> Total Utilisateurs</span>
              <div style="color: #73879C;font-family: 'Helvetica Neue',Roboto,Arial,'Droid Sans',sans-serif; text-align:center">
                  <asp:Label runat="server" ID="NBTotal" CssClass="count"></asp:Label></div>
              
            </div>
           
            <div class="col-md-2 col-sm-4 col-xs-6 tile_stats_count">
                <br />
              <span class="count_top" style="color: #73879C; font-size:unset; font-family:'Helvetica Neue',Roboto,Arial,'Droid Sans',sans-serif;font-weight: 400;
    line-height: 1.471; text-align:center;"><i class="fa fa-user"></i> Total Agents</span>
              <div style="color: #73879C;
   
    font-family: 'Helvetica Neue',Roboto,Arial,'Droid Sans',sans-serif; text-align:center;"><asp:Label runat="server" ID="NbAgent" CssClass="count" ></asp:Label></div>
             
            </div>
            <div class="col-md-2 col-sm-4 col-xs-6 tile_stats_count">
                <br />
              <span class="count_top" style="color: #73879C; font-size:unset; font-family:'Helvetica Neue',Roboto,Arial,'Droid Sans',sans-serif;font-weight: 400;
    line-height: 1.471; text-align:center;"><i class="fa fa-user"></i> Total Courtiers</span>
              <div style="color: #73879C;
   
    font-family: 'Helvetica Neue',Roboto,Arial,'Droid Sans',sans-serif;text-align:center;"><asp:Label runat="server" ID="NbCourtier"  class="count"></asp:Label></div>
              
            </div>
            <div class="col-md-2 col-sm-4 col-xs-6 tile_stats_count">
                <br />
              <span class="count_top" style="color: #73879C; font-size:unset; font-family:'Helvetica Neue',Roboto,Arial,'Droid Sans',sans-serif;font-weight: 400;
    line-height: 1.471;text-align:center; "><i class="fa fa-user"></i> Total Fournisseurs</span>
              <div style="color: #73879C;
   
    font-family: 'Helvetica Neue',Roboto,Arial,'Droid Sans',sans-serif;text-align:center;"><asp:Label runat="server" ID="NbFour" class="count"></asp:Label></div>
             
            </div>
            <div class="col-md-2 col-sm-4 col-xs-6 tile_stats_count">
                <br />
              <span class="count_top" style="color: #73879C; font-size:unset; font-family:'Helvetica Neue',Roboto,Arial,'Droid Sans',sans-serif;font-weight: 400;
    line-height: 1.471; text-align:center;"><i class="fa fa-user"></i> Total Gestionnaires</span>
              <div style="color: #73879C; font-family: 'Helvetica Neue',Roboto,Arial,'Droid Sans',sans-serif;text-align:center;"><asp:Label runat="server" ID="NbGest" class="count"></asp:Label></div>
             
            </div>
            <div class="col-md-2 col-sm-4 col-xs-6 tile_stats_count">
                <br />
                  <div style="text-align:center;">
             <asp:ImageButton runat="server"  ID="Ajouter" ImageUrl="images/NVPlus.png" OnClick="ajouter_Click" Height="39px" Width="47px"/>
              </div>
            </div>
          </div>
          <!-- /top tiles -->
             <div class="row">
          
            <div class="col-md-8 col-sm-8 col-xs-8 dashboard_graph">
              <div class="dashboard_graph">

                <div class="row x_title">
                  <div class="col-md-5">
                    <h3 style="color: #73879C;">Activités Récentes</h3>
                  </div>
                  <div class="col-md-3 pull-right">
                   <div>
                        <div class='input-group date' id='myDatepicker'>
                            <input type='text' class="form-control" " />
                            <span class="input-group-addon">
                               <span class="glyphicon glyphicon-calendar"></span>
                            </span>
                        </div>
                    </div>
                      </div>
                  
                  </div>
                  
              
                </div>
               
           
               
                <asp:Panel runat="server" ID="Pnl" class=" dashboard_graph">
               
              </asp:Panel>
                                                            
                  
              </div>
            <div class="col-md-4 col-sm-4 col-xs-4 ">
               <div class="x_panel tile fixed_height_320">
                <div class="x_title">
                  <h2 style="color: #73879C;">Accés rapide</h2>
                  
                  <div class="clearfix"></div>
                </div>
                <div class="">
                  <div class="">
                    <ul class="quick-list">
                      <li><i class=" fa fa-cogs"></i><a href="IntermidiaireSetting.aspx">Paramètres</a>
                      </li>
                      <li><i class="fa fa-pencil-square-o"></i><a href="AjoutProfil.aspx">Profiles</a>
                      </li>
                      <li><i class="fa fa-key"></i><a href="AjouterPermission.aspx">Permissions</a> </li>
                      <li><i class="fa fa-users"></i><a href="AjouterUser.aspx">Utilisateurs</a>
                      </li>
                      
                    </ul>

                   
                  </div>
                </div>
              </div>
                <%--<div id="mySidenav" class="sidenav pull-right" style="position:relative fixed;">
          <a href="#" id="parametre">Paramétres</a>
          <a href="#" id="profile">Profiles</a>
          <a href="#" id="utilisateur">Utilisateurs</a>
          <a href="#" id="permission">Permissions</a>
        </div>--%>
          
             
            </div>
            
         </div>
    <script src="assets/js/bootstrap.min.js"></script>

		<!-- page specific plugin scripts -->

		<!--[if lte IE 8]>
		  <script src="assets/js/excanvas.min.js"></script>
		<![endif]-->
		<script src="assets/js/jquery-ui.custom.min.js"></script>
		<script src="assets/js/jquery.ui.touch-punch.min.js"></script>
		<script src="assets/js/jquery.gritter.min.js"></script>
		<script src="assets/js/bootbox.js"></script>
		<script src="assets/js/jquery.easypiechart.min.js"></script>
		<script src="assets/js/bootstrap-datepicker.min.js"></script>
		<script src="assets/js/jquery.hotkeys.index.min.js"></script>
		<script src="assets/js/bootstrap-wysiwyg.min.js"></script>
		<script src="assets/js/select2.min.js"></script>
		<script src="assets/js/spinbox.min.js"></script>
		<script src="assets/js/bootstrap-editable.min.js"></script>
		<script src="assets/js/ace-editable.min.js"></script>
		<script src="assets/js/jquery.maskedinput.min.js"></script>

		<!-- ace scripts -->
		<script src="assets/js/ace-elements.min.js"></script>
		<script src="assets/js/ace.min.js"></script>
	
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
    
    $('#myDatepicker2').datetimepicker({
        format: 'DD.MM.YYYY'
    });
    
    $('#myDatepicker3').datetimepicker({
        format: 'hh:mm A'
    });
    
    $('#myDatepicker4').datetimepicker({
        ignoreReadonly: true,
        allowInputToggle: true
    });

    $('#datetimepicker6').datetimepicker();
    
    $('#datetimepicker7').datetimepicker({
        useCurrent: false
    });
    
    $("#datetimepicker6").on("dp.change", function(e) {
        $('#datetimepicker7').data("DateTimePicker").minDate(e.date);
    });
    
    $("#datetimepicker7").on("dp.change", function(e) {
        $('#datetimepicker6').data("DateTimePicker").maxDate(e.date);
    });
</script>
    <script  type="text/javascript">
       
           
        function Supprimer(x) {
            k = "Code_" + x;
            document.getElementById(k).remove();
        }
       <%-- function fileinfo() {
            document.getElementById('<%=TextBox1.ClientID%>').value=document.getElementById('<%=FileUpload1.ClientID%>').value
        }--%>
        
   </script>
    
    
  
	
<style>

    .tile_count .tile_stats_count .count {
    font-size: 30px;
    line-height: 47px;
    font-weight: 600;
}
    
   
</style>
    <style>
#mySidenav a {

    position: absolute;
    right: -105px;
    transition: 0.3s;
    padding: 15px;
    width: 100px;
    text-decoration: none;
    font-size: 18px;
    color: white;
    border-radius: 5px 0px 0px 5px;
}

#mySidenav a:hover {
   right: 0;
}

#parametre{
text-align:right;
    top: 20px;
    background-color: #4CAF50;
}

#profile {
text-align:right;
    top: 80px;
    background-color: #2196F3;
}

#utilisateur{
text-align:right;
    top: 140px;
    background-color: #f44336;
}

#permission {
text-align:right;
    top: 200px;
    background-color: #555
}
</style>
    
</asp:Content>

