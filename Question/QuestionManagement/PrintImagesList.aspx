<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PrintImagesList.aspx.cs" Inherits="QuestionManagement.PrintImagesList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="CustomScripts/jquery.min.js"></script>
    <script src="./Scripts/bootstrap.min.js" type="text/javascript"></script>
    <script src="CustomScripts/jquery-ui.min.js"></script>
   <link href="/Styles/MainStyles.css" rel="stylesheet" />
    <link href="./Content/bootstrap.min.css" rel="stylesheet" />
    <link href="./Content/bootstrap-theme.min.css" rel="stylesheet" />
    <link href="CustomScripts/jquery-ui.css.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container" id="maindiv" runat="server">
         
        </div>
    </form>
     <script type="text/javascript">
         $(window).bind("load", function () {
             window.print();
         });
    </script>
</body>
</html>
