<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Management.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <script type="text/javascript" src="Jquery/jquery-1.10.2.js"></script>
    <script type="text/javascript" src="Scripts/bootstrap.min.js"></script>
    <link href="Content/bootstrap-theme.min.css" rel="stylesheet" />
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <link href="Styles/MainStyles.css" rel="stylesheet" />
    <title></title>
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
                            <h4 style="font-weight: bold; font-family: Tahoma">APPLICATIONS CMS</h4>
                        </div>
                    </div>
                </div>

            </div>
        </div>
        <div class="container login" >
            <div class="row">
                <div class="col-md-12 login-header" >
                    CMS LOGIN
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
</html>
