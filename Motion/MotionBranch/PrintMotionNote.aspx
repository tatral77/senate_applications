<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PrintMotionNote.aspx.cs" Inherits="MotionBranch.PrintMotionNote" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        td {
            padding: 10px;
        }
        @media print {
            .page-break {
                display: none;
                break-after: always !important;
            }
        }

	
	
    </style>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
</head>

<body style="font-family:'Times New Roman';margin-top:0px;padding-top:0px;overflow:visible;">
    <form id="form1" runat="server">
      
       
                    <div ID="printingdiv"  style="margin-left:40px;margin-right:40px;" runat="server">

                    </div>
    </form>
    <script type="text/javascript">
        $(window).bind("load", function () {
            window.print();
        });
    </script>
</body>
</html>
