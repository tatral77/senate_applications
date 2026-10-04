<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Translation.Login" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>TMS Login</title>
    <script type="text/javascript" src="Scripts/AdminLte.js"></script>
    <link href="Styles/AdminLte.css" rel="stylesheet" />
    <link href="Styles/fontawsome.css" rel="stylesheet" />
   <%-- <link rel="stylesheet" href="https://pro.fontawesome.com/releases/v5.10.0/css/all.css" />--%>
    <link href="Assets/css/bootstrap.css" rel="stylesheet" />
    <style type="text/css">
        .logintext {
            border: none;
            border-bottom: solid thin;
            border-bottom-color: #fff;
            background-color: #2E8B57;
            color: #fff;
        }

        .btn-cutom {
            background-color: #fff;
            color: #000;
        }

        .header {
            margin-top: 5px;
            margin-bottom: 5px;
            padding: 20px;
            border-bottom: solid thin;
        }

        .login {
            background-color: #2b7196;
            color: #fff;
            padding: 10px;
            border-radius: 10px;
            font-family: 'Times New Roman', Times, serif;
        }

        .login-header {
            padding-bottom: 5px;
            padding-top: 5px;
            font-size: 20px;
            font-family: 'Times New Roman', Times, serif;
        }

        #errorlbl {
            padding-top: 10px;
            color: coral;
            font-weight: bold;
        }



        .pointer {
  position: relative;
  background: red;
}
.pointer:after {
  content: "";
  position: absolute;
  left: 0;
  bottom: 0;
  width: 0;
  height: 0;
  border-left: 40px solid white;
  border-top: 55px solid transparent;
  border-bottom: 55px solid transparent;
}
.pointer:before {
  content: "";
  position: absolute;
  right: -20px;
  bottom: 0;
  width: 0;
  height: 0;
  border-left: 20px solid red;
 
  border-top: 20px solid transparent;
  border-bottom: 20px solid transparent;
}
  

    </style>
</head>
<body>
    <form id="form1" runat="server">

        <div class="container-fluid">
            <div class="row">
                <div class="col-md-12" style="text-align: center; margin-top: 15px; margin-bottom: 15px;  color: #fff;padding:10px;">
                     <asp:Image ID="logoImage" runat="server" ImageUrl="~/images/banner.png" AlternateText="Senate Logo" Width="100%" Style="margin-top: 0px;" />
                </div>
              <%--  <div class="col-md-11 pointer" style="text-align: center; margin-top: 15px; margin-bottom: 15px; background-color:#2E8B57; color: #fff;padding:10px;">
                    <h2 style="font-family: 'Times New Roman', Times, serif">SENATE OF PAKISTAN</h2>
                    <h4>SOFTWARE APPLICATIONS</h4>
                </div>--%>
                 

            </div>
            <div class="row">
                <div class="col-md-3">
                      <div class="col-md-12" style="text-align: center; margin-top: 15px; margin-bottom: 15px;">
                    <div class="container login">
                        <div class="row">
                            <div class="col-md-12 login-header">
                                Translation Management System
                            </div>
                        </div>
                        <div class="row" style="margin-bottom:5px;">
                            <div class="col-md-12">
                                <div style="float: left; font-size: 15px;">
                                    <asp:Label ID="Label1" runat="server" Text="User Name :"></asp:Label>
                                </div>
                                <div>
                                    <asp:TextBox ID="UserName" runat="server" placeholder="Enter User Name" class="form-control btn-sm" ></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row"  style="margin-bottom:5px;">
                            <div class="col-md-12">
                                <div style="float: left; font-size: 15px;">
                                    <asp:Label ID="Label2" runat="server" Text="Password :"></asp:Label>
                                </div>
                                <div>
                                    <asp:TextBox ID="Password" placeholder="Enter Password" runat="server" TextMode="Password" class="form-control"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row top-buffer">
                            <div class="col-md-12">
                                <div style="float: right;">
                                    <asp:Button ID="Button1" runat="server" Text="Login" class="btn btn-cutom" OnClick="Button1_Click" />
                                    <asp:Label ID="errorlbl" runat="server" Text=""></asp:Label>
                                </div>
                                <div>
                                    <asp:Label ID="Label3" runat="server" Text=""></asp:Label>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                </div>
               <div class="col-md-9">
                    <div class="container-fluid">
                        <div class="row">
                            <div class="col-md-4 col-sm-6 col-12">
                                <div class="info-box">
                                    <img src="Assets/images/HRM.png" style="width: 100px; height: 100px;" />
                                    <div class="info-box-content">
                                        <span class="info-box-number"><a href="http://hrm.senate.gov.pk">HR MANAGEMENT SYSTEM</a></span>
                                        <p>HRM Branch</p>
                                       <%-- <p>HRMS, or human resources management system, is a suite of software applications used to manage human resources and related processes throughout the employee lifecycle. Companies can empower managers and employees with self-service for common tasks—an important selling point for younger hires. </p>--%>

                                    </div>
                                </div>
                            </div>
                            <div class="col-md-4 col-sm-6 col-12">
                                <div class="info-box">
                                    <%-- <span class="info-box-icon">--%>
                                    <img src="Assets/images/Question.png" style="width: 100px; height: 100px;" /><%--</span>--%>
                                    <div class="info-box-content">
                                        <span class="info-box-number"><a href="http://question.senate.gov.pk">QUESTION MANAGEMENT SYSTEM</a></span>
                                         <p>Question Branch</p>
                                        <%--<p>HRMS, or human resources management system, is a suite of software applications used to manage human resources and related processes throughout the employee lifecycle. Companies can empower managers and employees with self-service for common tasks—an important selling point for younger hires. </p>--%>

                                    </div>
                                </div>
                            </div>
                            <div class="col-md-4 col-sm-6 col-12">
                                <div class="info-box">
                                    <img src="Assets/images/Budget.png" style="width: 100px; height: 100px;" />
                                    <div class="info-box-content">
                                        <span class="info-box-number"><a href="http://budget.senate.gov.pk">BUDGET MANAGEMENT SYSTEM</a></span>
                                         <p>Cash & Accounts Branch</p>
                                        <%--<p>HRMS, or human resources management system, is a suite of software applications used to manage human resources and related processes throughout the employee lifecycle. Companies can empower managers and employees with self-service for common tasks—an important selling point for younger hires. </p>--%>

                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-4 col-sm-6 col-12">
                                <div class="info-box">
                                    <img src="Assets/images/envelop.png" style="width: 100px; height: 100px;" />
                                    <div class="info-box-content">
                                        <span class="info-box-number"><a href="http://notice.senate.gov.pk">NOTICE MANAGEMENT SYSTEM</a></span>
                                        <p>Notice Branch</p>
                                        <%--<p>HRMS, or human resources management system, is a suite of software applications used to manage human resources and related processes throughout the employee lifecycle. Companies can empower managers and employees with self-service for common tasks—an important selling point for younger hires. </p>--%>

                                    </div>
                                </div>
                            </div>
                            <div class="col-md-4 col-sm-6 col-12">
                                <div class="info-box">
                                    <%-- <span class="info-box-icon">--%>
                                    <img src="Assets/images/Finance.png" style="width: 100px; height: 100px;" /><%--</span>--%>
                                    <div class="info-box-content">
                                        <span class="info-box-number"><a href="http://finance.senate.gov.pk">FINANCE MANAGEMENT SYSTEM</a></span>
                                         <p>Finance & Accounts Branch</p>
                                        <%--<p>HRMS, or human resources management system, is a suite of software applications used to manage human resources and related processes throughout the employee lifecycle. Companies can empower managers and employees with self-service for common tasks—an important selling point for younger hires. </p>--%>

                                    </div>
                                </div>
                            </div>
                            <div class="col-md-4 col-sm-6 col-12">
                                <div class="info-box">
                                    <img src="Assets/images/service.png" style="width: 100px; height: 90px;" />
                                    <div class="info-box-content">
                                        <span class="info-box-number"><a href="http://service.senate.gov.pk">SERVICE MANAGEMENT SYSTEM</a></span>
                                         <p>Service Branch</p>
                                        <%--<p>HRMS, or human resources management system, is a suite of software applications used to manage human resources and related processes throughout the employee lifecycle. Companies can empower managers and employees with self-service for common tasks—an important selling point for younger hires. </p>--%>

                                    </div>
                                </div>
                            </div>
                        </div>

                          <div class="row">
                                <div class="col-md-4 col-sm-6 col-12">
                                <div class="info-box">
                                    <img src="Assets/images/motion.png" style="width: 100px; height: 100px;" />
                                    <div class="info-box-content">
                                        <span class="info-box-number"><a href="http://motion.senate.gov.pk">MOTION MANAGEMENT SYSTEM</a></span>
                                        <p>Motion Branch</p>
                                        <%--<p>HRMS, or human resources management system, is a suite of software applications used to manage human resources and related processes throughout the employee lifecycle. Companies can empower managers and employees with self-service for common tasks—an important selling point for younger hires. </p>--%>

                                    </div>
                                </div>
                            </div>
                            <div class="col-md-4 col-sm-6 col-12">
                                <div class="info-box">
                                    <img src="Assets/images/my.png" style="width: 100px; height: 100px;" />
                                    <div class="info-box-content">
                                        <span class="info-box-number"><a href="http://my.senate.gov.pk">PERSONAL MANAGEMENT SYSTEM</a></span>
                                        <p>HRM Branch</p>
                                        <%--<p>HRMS, or human resources management system, is a suite of software applications used to manage human resources and related processes throughout the employee lifecycle. Companies can empower managers and employees with self-service for common tasks—an important selling point for younger hires. </p>--%>

                                    </div>
                                </div>
                            </div>
                            <div class="col-md-4 col-sm-6 col-12">
                                <div class="info-box">
                                    <%-- <span class="info-box-icon">--%>
                                    <img src="Assets/images/ipr.png" style="width: 100px; height: 100px;" /><%--</span>--%>
                                    <div class="info-box-content">
                                        <span class="info-box-number"><a href="http://ipr.senate.gov.pk">IPR MANAGEMENT SYSTEM</a></span>
                                         <p>IPR Branch</p>
                                        <%--<p>HRMS, or human resources management system, is a suite of software applications used to manage human resources and related processes throughout the employee lifecycle. Companies can empower managers and employees with self-service for common tasks—an important selling point for younger hires. </p>--%>

                                    </div>
                                </div>
                            </div>
                        
                        </div>
                            <div class="row">
                            <div class="col-md-4 col-sm-6 col-12">
                                <div class="info-box">
                                    <img src="Assets/images/committees.png" style="width: 100px; height: 100px;" />
                                    <div class="info-box-content">
                                        <span class="info-box-number"><a href="http://committees.senate.gov.pk">COMMITTEES MANAGEMENT SYSTEM</a></span>
                                        <p>Committee Branch</p>
                                        <%--<p>HRMS, or human resources management system, is a suite of software applications used to manage human resources and related processes throughout the employee lifecycle. Companies can empower managers and employees with self-service for common tasks—an important selling point for younger hires. </p>--%>

                                    </div>
                                </div>
                            </div>
                                <div class="col-md-4 col-sm-6 col-12">
                                <div class="info-box">
                                    <img src="Assets/images/bill.png" style="width: 100px; height: 100px;" />
                                    <div class="info-box-content">
                                        <span class="info-box-number"><a href="#">LEGISLATION MANAGEMENT SYSTEM</a></span>
                                        <p>Legislation Branch</p>
                                        <%--<p>HRMS, or human resources management system, is a suite of software applications used to manage human resources and related processes throughout the employee lifecycle. Companies can empower managers and employees with self-service for common tasks—an important selling point for younger hires. </p>--%>

                                    </div>
                                </div>
                            </div>
                                <div class="col-md-4 col-sm-6 col-12">
                                <div class="info-box">
                                    <img src="Assets/images/translation.png" style="width: 100px; height: 100px;" />
                                    <div class="info-box-content">
                                        <span class="info-box-number"><a href="http://trans.senate.gov.pk">TRANSLATION MANAGEMENT SYSTEM</a></span>
                                        <p>Translation Branch</p>
                                        <%--<p>HRMS, or human resources management system, is a suite of software applications used to manage human resources and related processes throughout the employee lifecycle. Companies can empower managers and employees with self-service for common tasks—an important selling point for younger hires. </p>--%>

                                    </div>
                                </div>
                            </div>
                         
                    </div>
                </div>
                      <div class="row" >
                          <div class="col-md-12" style="text-align:center;background-color:#2E8B57; color: #fff;">
                              Powered by: &copy; IT Directorate
                          </div>
                
            </div>
            </div>
        </div>





    </form>
</body>
</html>
<%--<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <script type="text/javascript" src="Jquery/jquery-1.10.2.js"></script>
    <script type="text/javascript" src="Scripts/bootstrap.min.js"></script>
    <link href="Content/bootstrap-theme.min.css" rel="stylesheet" />
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <link href="Styles/MainStyles.css" rel="stylesheet" />
    <title>QMS</title>
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
                            <h4 style="font-weight: bold; font-family: Tahoma">QUESTIONS MANAGEMENT SYSTEM</h4>
                        </div>
                    </div>
                </div>

            </div>
        </div>
        <div class="container login" >
            <div class="row">
                <div class="col-md-12 login-header" >
                    QMS LOGIN
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
                    </div>
                    <div>
                        <asp:Label ID="errorlbl" runat="server" Text=""></asp:Label>
                    </div>
                </div>
            </div>

            <div class="modal-footer" style="margin-top:10px;"> Developed By: Senate Automation Branch</div>
    </div>
    </form>
</body>
</html>--%>