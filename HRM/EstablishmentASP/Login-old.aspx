<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login-old.aspx.cs" Inherits="EstablishmentASP.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html lang="en">

<head>
	<meta charset="UTF-8">
	<meta name="viewport" content="width=device-width, initial-scale=1.0">
	<meta http-equiv="X-UA-Compatible" content="ie=edge">
	<title>OFFICIAL DEVELOPMENTS :: I.T DIRECTORATE</title>
	<link rel="shortcut icon" href="Assets/images/favicon.ico">
	<!--[if lt IE 9]>
        <script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
    <![endif]-->

	<!-- Bootstrap CSS -->
	<link href="Assets/css/bootstrap.css" rel="stylesheet" type="text/css" />
	<!-- Font Awesome CSS-->
	<link href="Assets/css/font-awesome.css" rel="stylesheet" type="text/css" />
	<!-- Custom CSS-->
	<style type="text/css" >
		@font-face{
    font-family: 'Diavlo';
    src: url('Assets/fonts/Diavlo_LIGHT_II_37.otf');
}

H1, H2, H3, H4, H5, H6
{
    font-family: 'Diavlo';
}

* {
    padding: 0;
    margin: 0;
}

body {
    background-color: #fff;
}

a {
    color: #a2070f;
    text-decoration: none;
    background-color: transparent;
  }
  
  a:hover {
    color: #CC777C;
    text-decoration: underline;
  }

  .logo {
    background-color: #90050d;
    background-image:url('Assets/images/hdr-img.jpg');
    background-position: center center;
    background-repeat: no-repeat;
    background-size: 90% 90%;
    position: relative;
}
.pl-85{
    padding-left: 85px;
}

.img-responsive{
    max-width: 100%;
    height: auto;
    display:block;
}

/* ----------------------- LEFT SIDE ----------------------- */

.jumbotron {
    padding: 0.5625rem;
    background-color: transparent;
    /* border: 1px solid #DADADA; */
	border-bottom: 1px solid #DADADA;
    border-radius: 0.3125rem;
}

.jumbotron-login{
	border-bottom: none;
}

.display-4 {
    font-size: 1.2rem;
    font-weight: 500;
    border-bottom: 2px solid #a2070f;
    color: #000;
    padding-bottom: 10px;
}

.display-2 {
    font-weight: 700;
    color: #a2070f;
	font-size: 2rem;
}

.lead {
    font-size: 1rem;
	text-align:justify;
}

.font-size {
    font-size: 0.8rem;
}

/* -----------------------------------------------------------------------------------*/

/* Extra small devices (portrait phones, less than 576px) */
@media (max-width: 575.98px) { 
    #logo{
        max-width: 17vw;
    }
    .logo{
        padding: 1.875rem 0.625rem;
    }  
}

/* Small devices (landscape phones, 576px and up) */
@media (min-width: 576px) and (max-width: 767.98px) { 
      #logo{
          max-width: 19vw;
      }
      .logo{
        padding: 1.875rem 0.625rem;
    }  
}

/* Medium devices (tablets, 768px and up) */
@media (min-width: 768px) and (max-width: 991.98px) { 
    #logo{
        max-width: 21vw;
    }
    .logo{
        padding: 1.875rem 0.625rem;
    }  
 }

/* Large devices (desktops, 992px and up) */
@media (min-width: 992px) and (max-width: 1199.98px) { 
    #logo{
        max-width: 30vw;
    }
    .logo{
        padding: 1.875rem 0.625rem;
    }  
}

/* Extra large devices (large desktops, 1200px and up) */
@media (min-width: 1200px) { 
    #logo{
        max-width: 37vw;
    }
    .logo{
        padding: 1.875rem 0.625rem;
    }  
 }
	</style>

</head>

<body>
	<div id="wrapper" class="container-fluid">
		<!-- --------------------------------------- HEADER SECTION ---------------------------------------- -->
		<header>
			<div class="row">
				<div class="logo col-12">
					<a href="index.php" title="Home" rel="home" class="pl-85">
						<img src="Assets/images/logo.png" alt="Home" id="logo" class="img-responsive">
					</a>
				</div>
			</div>
		</header>
		<!-- --------------------------------------- MAIN SECTION ---------------------------------------- -->
		<main class="container">
			<h2 class="mt-4 mb-4 text-center display-2">
				Senate Application Modules
			</h2>
			<div class="row mt-3">
				<div class="col-3">
					<div class="container">
						<div class="row">
							<form id="form1" runat="server">
							<div class="jumbotron jumbotron-login jumbotron-fluid col-12">
								<div class="container">
									<h1 class="display-4">
										<a href="http://localhost:2315/Dashboard" target="_blank" rel="noopener noreferrer">
											<span class="fa fa-users"></span> HRM Login	</a>
									</h1>
									<p class="lead"></p>
									<div class="input-group input-group-sm mb-1">
										<div class="input-group-prepend">
											<span class="input-group-text" id="inputGroup-sizing-sm">Login</span>
										</div>
										<asp:TextBox ID="UserName" runat="server" placeholder="Enter User Name" class="form-control" aria-label="Small" aria-describedby="inputGroup-sizing-sm"></asp:TextBox>
									</div>
									<div class="input-group input-group-sm mb-1">
										<div class="input-group-prepend">
											<span class="input-group-text" id="inputGroup-sizing-sm">Password</span>
										</div>
										<asp:TextBox ID="Password" placeholder="Enter Password" runat="server" TextMode="Password" class="form-control" aria-label="Small" aria-describedby="inputGroup-sizing-sm"></asp:TextBox>
	
									</div>
									<p></p>
									  <asp:Button ID="Button1" runat="server" Text="Login" class="btn btn-outline-danger btn-sm mb-2" OnClick="Button1_Click" />
						<asp:Label ID="errorlbl" runat="server" Text=""></asp:Label>
									<%--<button type="submit" class="btn btn-outline-danger btn-sm mb-2">Submit</button>--%>
									<p class="lead">
										An HRMS, or human resources management system, is a suite of software applications used to manage human resources and related processes throughout the employee lifecycle. ... Companies can empower managers and employees with self-service for common tasks—an important selling point for younger hires.
									</p>
								</div>
							</div>
							</form>
						</div>
					</div>

				</div>

				<div class="col-9">
					<div class="container">
						<div class="row">
			
							<div class="jumbotron jumbotron-fluid col-4">
								<div class="container">
									<h1 class="display-4">
										<a href="http://automation.senate.gov.pk" target="_blank" rel="noopener noreferrer">
											<span class="fa fa-keyboard-o"></span> Automation Branch
										</a>
									</h1>
									<p class="lead">
										The information technology department is responsible for the architecture, hardware, software and networking of computers in Senate.
									</p>
									<small></small>
								</div>
							</div>
			
							<div class="jumbotron jumbotron-fluid col-4">
								<div class="container">
									<h1 class="display-4">
										<a href="http://question.senate.gov.pk" target="_blank" rel="noopener noreferrer">
											<span class="fa fa-question-circle"></span> Question Branch
										</a>
									</h1>
									<p class="lead">
										Parliamentary Questions are an important means used by Members of Parliament to ensure the Government is accountable to the Parliament for its policies and actions and, through the Parliament, to the people.
									</p>
								</div>
							</div>
			
							<div class="jumbotron jumbotron-fluid col-4">
								<div class="container">
									<h1 class="display-4">
										<a href="http://budget.senate.gov.pk" target="_blank" rel="noopener noreferrer">
											<span class="fa fa-money"></span>Cash & Accounts Branch
										</a>
									</h1>
									<p class="lead">
										Budget Management System is a professional system for financial department, department managers to control and monitor expenditure base on plan and actual budget in year. 
									</p>
								</div>
							</div>
						</div>
						<!-- ------------------------------------------------------------------------------------------- -->
						<div class="row mt-3">
							
							<div class="jumbotron jumbotron-fluid col-4">
								<div class="container">
									<h1 class="display-4">
										<a href="http://finance.senate.gov.pk" target="_blank" rel="noopener noreferrer">
											<span class="fa fa-area-chart"></span> F & A Branch
										</a>
									</h1>
									<p class="lead">
										Finance represents money management and the process of acquiring needed funds. Finance also encompasses the oversight, creation, and study of money, banking, credit, investments, assets, and liabilities that make up financial systems. 
									</p>
								</div>
							</div>

							<div class="jumbotron jumbotron-fluid col-4">
								<div class="container">
									<h1 class="display-4">
										<a href="http://motion.senate.gov.pk" target="_blank" rel="noopener noreferrer">
											<span class="fa fa-tasks"></span>Motion Management System
										</a>
									</h1>
									<p class="lead">
										Motion Management System
									</p>
								</div>
							</div>
			
							<div class="jumbotron jumbotron-fluid col-4">
								<div class="container">
									<h1 class="display-4">
										<a href="http://notice.senate.gov.pk" target="_blank" rel="noopener noreferrer">
											<span class="fa fa-tasks"></span>Notice Management System
										</a>
									</h1>
									<p class="lead">
										Notice Management System
									</p>
								</div>
							</div>
						</div>
						<!-- ------------------------------------------------------------------------------------------- -->
						<%--<div class="row mt-3">
							
							<div class="jumbotron jumbotron-fluid col-4">
								<div class="container">
									<h1 class="display-4">
										<a href="#http://localhost:2314/Account/SignIn" target="_blank" rel="noopener noreferrer">
											<span class="fa fa-exchange"></span> Web Security (OAuth & OpenID)
										</a>
									</h1>
									<p class="lead">
										<span class="fa fa-sign-in"></span> user<br>
										<span class="fa fa-key"></span> user123
									</p>
								</div>
							</div>

							<div class="jumbotron jumbotron-fluid col-4">
								<div class="container">
									<h1 class="display-4">
										<a href="#http://localhost:2313/" target="_blank" rel="noopener noreferrer">
											<span class="fa fa-tasks"></span> ASP.NET Identity 2
										</a>
									</h1>
									<p class="lead">
										<span class="fa fa-sign-in"></span> null<br>
										<span class="fa fa-key"></span> null
									</p>
								</div>
							</div>
			
							<div class="jumbotron jumbotron-fluid col-4">
								<div class="container">
									<h1 class="display-4">
										<a href="#http://localhost:2313/" target="_blank" rel="noopener noreferrer">
											<span class="fa fa-tasks"></span> ASP.NET Identity 2
										</a>
									</h1>
									<p class="lead">
										<span class="fa fa-sign-in"></span> null<br>
										<span class="fa fa-key"></span> null
									</p>
								</div>
							</div>
						</div>--%>
					</div>
				</div>

				

			</div>
		<!-- ------------------------------------------------------------------------------------------- -->

		</main>
		<!-- --------------------------------------- FOOTER SECTION ---------------------------------------- -->
		<footer class="row">
			<section class="text-center mt-3 border-top col-12">
				<p class="alert-light mt-2">
					<small>Copyright &copy; 2010-2021. All rights are reserved. I.T Directorate of Senate Secretariat</small>
				</p>
			</section>
		</footer>
		<!-- ------------------------------------------------------------------------------------------- -->
	</div>
	<!-- ------------------------------------------------------------------------------------------- -->
	<!-- jQuery library -->
	<script src="Assets/js/jquery.js" type="text/javascript"></script>

	<!-- Bootstrap JS -->
	<script src="Assets/js/bootstrap.js" type="text/javascript"></script>
</body>

</html>






<%--<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <script type="text/javascript" src="Jquery/jquery-1.10.2.js"></script>
    <script type="text/javascript" src="Scripts/bootstrap.min.js"></script>
    <link href="Content/bootstrap-theme.min.css" rel="stylesheet" />
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <link href="Styles/MainStyles.css" rel="stylesheet" />
    <title>HRM</title>
    <style type="text/css">
        .logintext {
            border: none;
            border-bottom: solid thin;
            font-size: 15px;
            border-bottom-color:#fff;
            height:30px;
            background-color:#2E8B57;
            color:#fff;
        }
        .btn-cutom
        {
            background-color:#fff;
            color:#000;
        }
        .header{
            margin-top: 10px; 
            margin-bottom: 50px;
            padding: 20px; 
            border-bottom: solid thin;
        }
        .login{
            background-color:#2E8B57;
            color:#fff;
            padding:0px 0px 100px 100px;
            border-radius:10px;
             font-family: 'Times New Roman', Times, serif;
        }
        .login-header{
            padding-bottom:50px;
            padding-top:50px;
            font-size:20px;
            font-family: 'Times New Roman', Times, serif;
        }
         #errorlbl
        {
            padding-top:10px;
            color:coral;
            font-weight:bold;
        }
</style>
</head>
<body>
<form id="form1" runat="server">
        <div class="container">
            <div class="row">
                <div class="col-md-12 header">
                    <div class="row">
                        <div class="col-md-2">
                            <asp:Image ID="logoImage" runat="server" ImageUrl="~/images/logo.png" AlternateText="Senate Logo" Width="80px" Height="90px" Style="margin-top: 0px; margin-left: 20px" />
                        </div>
                        <div class="col-md-8" style="text-align: center">
                            <h3 style="font-family: 'Times New Roman', Times, serif; font-weight: bold; color: #086623">SENATE OF PAKISTAN</h3>
                            <h4 style="font-weight: bold; font-family: Tahoma">HUMAN RESOURCE MANAGEMENT SYSTEM</h4>
                        </div>
                    </div>
                </div>

            </div>
        </div>
        <div class="container login" >
            <div class="row">
                <div class="col-md-12 login-header" >
                    HRMS LOGIN
                </div>
            </div>
            <div class="row">
                <div class="col-md-12" >
                    <div style="width:130px;float:left;font-size:15px;">
                        <asp:Label ID="Label1" runat="server" Text="USER NAME :"></asp:Label>
                    </div>
                    <div>
                        <asp:TextBox ID="UserName" runat="server" placeholder="Enter User Name" class="logintext" Style="width: 250px"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-12">
                    <div style="width:130px;float:left;font-size: 15px;">
                        <asp:Label ID="Label2" runat="server" Text="PASSWORD :"></asp:Label>
                    </div>
                    <div>
                        <asp:TextBox ID="Password" placeholder="Enter Password" runat="server" TextMode="Password" class="logintext" Style="width: 250px"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="row top-buffer">
                <div class="col-md-12">
                    <div style="width:100px;float:left;">
                        <asp:Button ID="Button1" runat="server" Text="Login" class="btn btn-cutom" OnClick="Button1_Click" />
						<asp:Label ID="errorlbl" runat="server" Text=""></asp:Label>
                    </div>
                    <div>
                        <asp:Label ID="errorlbl" runat="server" Text=""></asp:Label>
                    </div>
                </div>
            </div>

            <div class="modal-footer" style="margin-top:10px;font-family:Verdana;font-size:10pt;font-weight:bold;"> Developed By: Senate Automation Branch</div>
    </div>
    </form>
</body>
</html>--%>
