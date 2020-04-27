<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation="false" CodeFile="RecuperationMotDePasse.aspx.cs" Inherits="RecuperationMotDePasse" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
		<meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1" />
		<meta charset="utf-8" />
		<title>Login Page</title>

		<meta name="description" content="User login page" />
		<meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0" />

		<!-- bootstrap & fontawesome -->
		<link rel="stylesheet" href="assets/css/bootstrap.min.css" />
		<link rel="stylesheet" href="assets/font-awesome/4.5.0/css/font-awesome.min.css" />

		<!-- text fonts -->
		<link rel="stylesheet" href="assets/css/fonts.googleapis.com.css" />

		<!-- ace styles -->
		<link rel="stylesheet" href="assets/css/ace.min.css" />

		<!--[if lte IE 9]>
			<link rel="stylesheet" href="assets/css/ace-part2.min.css" />
		<![endif]-->
		<link rel="stylesheet" href="assets/css/ace-rtl.min.css" />

		<!--[if lte IE 9]>
		  <link rel="stylesheet" href="assets/css/ace-ie.min.css" />
		<![endif]-->

		<!-- HTML5shiv and Respond.js for IE8 to support HTML5 elements and media queries -->

		<!--[if lte IE 8]>
		<script src="assets/js/html5shiv.min.js"></script>
		<script src="assets/js/respond.min.js"></script>
		<![endif]-->
	</head>

<body class="login-layout">
        <form id="form2" runat="server">
		<div class="main-container">
			<div class="main-content">
				<div class="row">
					<div class="col-sm-10 col-sm-offset-1">
						<div class="login-container">
							<div class="center">
								<h1>
									
									<span class="red">Portail</span>
									<span class="white" id="id-text2">Des Services</span>
								</h1>
								<h4 class="blue" id="id-company-text">&copy;ASTREE </h4>
							</div>

							<div class="space-6"></div>
							
					       <asp:Panel ID="signup_box" class="signup-box  visible  widget-box    no-border" runat="server" Visible="false">
									<div class="widget-body">
										<div class="widget-main">
											<h4 class="header green lighter bigger">
												<i class="ace-icon fa fa-users blue"></i>
												Récupération de mot de passe
											</h4>

											<div class="space-6"></div>
											<p> <h3>Donnez vos coordonnés : </h3></p>
												<fieldset>
                                                    <asp:Label ID="msgerror" Visible="false" runat="server"  ></asp:Label>
													<label class="block clearfix">
														<span class="block input-icon input-icon-right">
															<%--<input type="email" class="form-control" placeholder="Email" />--%>
                                                             <asp:TextBox ID ="txtlogin" runat="server"  CssClass="form-control" ></asp:TextBox>
															<i class="ace-icon fa fa-user"></i>
														</span>
													</label>
													<label class="block clearfix">
														<span class="block input-icon input-icon-right">
														<%--	<input type="password" class="form-control" placeholder="Password" />--%>
                                                             <asp:TextBox ID ="txtpassword2" runat="server"  CssClass="form-control" ></asp:TextBox>
															<i class="ace-icon fa fa-lock"></i>
														</span>
													</label>

													<label class="block clearfix">
														<span class="block input-icon input-icon-right">
															<%--<input type="password" class="form-control" placeholder="Repeat password" />--%>
                                                             <asp:TextBox ID ="txtRepeatpassword" runat="server"  CssClass="form-control" ></asp:TextBox>
															<i class="ace-icon fa fa-retweet"></i>
														</span>
													</label>
													<div class="space-24"></div>

													<div class="clearfix">

														
                                                         <asp:Button id="btnRegister" CssClass="width-35 pull-right btn btn-sm btn-primary" runat="server" Text="Envoyer"  OnClick="btnRegister_Click">
														
														</asp:Button>
                                                        <div class="space-24"></div>
                                                        <asp:Button id="btnReset" CssClass="width-35 pull-right btn btn-sm btn-primary" runat="server" Text="Annuler">
														</asp:Button>
													</div>
												</fieldset>
											
										</div>

										
									</div><!-- /.widget-body -->
								</asp:Panel><!-- /.signup-box -->
							

							<div class="navbar-fixed-top align-right">
								<br />
								&nbsp;
								<a id="btn-login-dark" href="#">Dark</a>
								&nbsp;
								<span class="blue">/</span>
								&nbsp;
								<a id="btn-login-blur" href="#">Blur</a>
								&nbsp;
								<span class="blue">/</span>
								&nbsp;
								<a id="btn-login-light" href="#">Light</a>
								&nbsp; &nbsp; &nbsp;
							</div>
						</div>
					</div><!-- /.col -->
				</div><!-- /.row -->
			</div><!-- /.main-content -->
		</div><!-- /.main-container -->

		<!-- basic scripts -->

		<!--[if !IE]> -->
		<script src="assets/js/jquery-2.1.4.min.js"></script>

		<!-- <![endif]-->

		<!--[if IE]>
<script src="assets/js/jquery-1.11.3.min.js"></script>
<![endif]-->
		<script type="text/javascript">
			if('ontouchstart' in document.documentElement) document.write("<script src='assets/js/jquery.mobile.custom.min.js'>"+"<"+"/script>");
		</script>

		<!-- inline scripts related to this page -->
		<script type="text/javascript">
			jQuery(function($) {
			 $(document).on('click', '.toolbar a[data-target]', function(e) {
				e.preventDefault();
				var target = $(this).data('target');
				$('.widget-box.visible').removeClass('visible');//hide others
				$(target).addClass('visible');//show target
			 });
			});
			
			
			
			//you don't need this, just used for changing background
			jQuery(function($) {
			 $('#btn-login-dark').on('click', function(e) {
				$('body').attr('class', 'login-layout');
				$('#id-text2').attr('class', 'white');
				$('#id-company-text').attr('class', 'blue');
				
				e.preventDefault();
			 });
			 $('#btn-login-light').on('click', function(e) {
				$('body').attr('class', 'login-layout light-login');
				$('#id-text2').attr('class', 'grey');
				$('#id-company-text').attr('class', 'blue');
				
				e.preventDefault();
			 });
			 $('#btn-login-blur').on('click', function(e) {
				$('body').attr('class', 'login-layout blur-login');
				$('#id-text2').attr('class', 'white');
				$('#id-company-text').attr('class', 'light-blue');
				
				e.preventDefault();
			 });
			 
			});
		</script>
            </form>
	</body>
</html>