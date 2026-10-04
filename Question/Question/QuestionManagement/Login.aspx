<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="QuestionManagement.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <script type="text/javascript" src="Jquery/jquery-1.10.2.js"></script>
    <script type="text/javascript" src="Scripts/bootstrap.min.js"></script>
    <link href="Content/bootstrap-theme.min.css" rel="stylesheet" />
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <link href="Styles/MainStyles.css" rel="stylesheet" />
    <title></title>
</head>
<body>

    <form id="form1" runat="server">
   
        <div class="container">
            <div class="row">
                <div class="col-md-12">
                    <div class="page-header">
                        <h3>Senate of Pakistan</h3>
                        <h4>Question Management</h4>
                    </div>

                </div>
            </div>
             <div class="row">
                <div class="col-md-12">
                    <asp:Label ID="Label1" runat="server" Text="User Name :"></asp:Label>
                    <asp:TextBox ID="UserName" runat="server" class="form-control" style="width:250px"></asp:TextBox>

                </div>
            </div>
             <div class="row">
                <div class="col-md-12">
                    <asp:Label ID="Label2" runat="server" Text="Password :" ></asp:Label>
        <asp:TextBox ID="Password" runat="server" TextMode="Password" class="form-control" style="width:250px"></asp:TextBox>
                </div>
            </div>
            <div class="row top-buffer">
                <div class="col-md-12">
                     <asp:Button ID="Button1" runat="server" Text="Login" class="btn btn-primary" onclick="Button1_Click" />
                    <asp:Label ID="errorlbl" runat="server" Text="Password :" class="text-danger"></asp:Label>
                </div>
            </div>



        </div>
          

      
      
   
       
  
    
       
  
    
   
    </form>
</body>
</html>