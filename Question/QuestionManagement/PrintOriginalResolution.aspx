<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PrintOriginalResolution.aspx.cs" Inherits="QuestionManagement.PrintOriginalResolution" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        td{
            padding:10px;
        }
    </style>
    <link href="Styles/NSole.css" rel="stylesheet" />
	<link href="Content/bootstrap-theme.min.css" rel="stylesheet" />
	<link href="Content/bootstrap.min.css" rel="stylesheet" />
	<script src="Scripts/bootstrap.min.js"></script>
	<script src="Scripts/jquery-1.9.1.min.js"></script>
    <%--<link rel="stylesheet" href="//fonts.googleapis.com/earlyaccess/notonastaliqurdudraft.css" />--%>
    <link href="Styles/notonastaliqurdudraft.css" rel="stylesheet" />
</head>
    
<body style="margin-left:15mm;margin-right:3mm;margin-top:5mm;">
    <form id="form1" runat="server">
       
    <table  border="0" style="width:95%">
        <tr><td style="font-size:16pt;text-align:center;font-weight:bold;padding:0;" colspan="4">SENATE SECRETARIAT</td></tr>
        <tr><td colspan="4" style="font-size:12pt;text-align:center;font-weight:bold;padding-top:0px;padding-bottom:10mm;">(RESOLUTION)</td></tr>
        <tr>
              <td style="width:15%;font-size:10pt;font-weight:bold;padding:10px;">SESSION NO / RID:</td>
            <td style="width:35%;font-size:10pt;font-weight:bold;padding:10px;"><asp:Label ID="SessionLbl" runat="server" Text=""></asp:Label></td>
            <td style="width:15%;font-size:10pt;font-weight:bold;padding:10px;text-align:left;">R.D.NO.:</td>
            <td style="width:35%;font-size:10pt;font-weight:bold;padding:10px;"><asp:Label ID="MotionDNoLbl" runat="server" Text=""></asp:Label></td>
          
        </tr>
         <tr>
            <td style="width:35%;font-size:10pt;font-weight:bold;padding:10px;" >NOTICE RECEIVED ON:</td>
            <td style="width:15%;font-size:10pt;font-weight:bold;padding:10px;" ><asp:Label ID="NoticeDateLbl" runat="server" Text=""></asp:Label></td>
            <td style="width:15%;font-size:10pt;font-weight:bold;padding:10px;text-align:left;">STATUS:</td>
            <td style="width:55%;font-size:10pt;font-weight:bold;padding:10px;"><asp:Label ID="StatusLbl" runat="server" Text=""></asp:Label></td>
        </tr>
        <tr>
            <td colspan="4" >
            <asp:Label  ID="Label1" runat="server" Text="RESOLUTION:-" style="font-weight:bold;font-size:11pt;text-decoration:underline;padding-left:10px"></asp:Label><br />
           
            </td>
        </tr>
        </table>
        <div style="padding-left:15mm;padding-right:20mm;text-align:justify">
             <asp:Label Visible="false" ID="MotionTextLblEng" runat="server" Text="" style="font-size:11pt;padding-left:40mm;padding-right:0mm;text-align:justify;line-height:2.5; font-family: 'Noto Nastaliq Urdu Draft', Verdana;"></asp:Label>
            <asp:Label visible="false" ID="MotionTextLblUr" runat="server" Text="" style="direction: rtl;font-size:11pt;padding-left:40mm;padding-right:0mm;text-align:justify;line-height:2.5; font-family: 'Noto Nastaliq Urdu Draft', 'Times New Roman';"></asp:Label>
                  
        </div>
       <div style="padding-left:50mm;padding-right:20mm;padding-top:5mm;padding-bottom:5mm;width:auto;float:right;font-size:11pt;font-weight:bold;">
            <asp:Label ID="MoversLbl" runat="server" Text=""></asp:Label>
        </div>
        <%-- <tr>
            <td colspan="4" style="padding-left:40mm;"> 	
                

            </td>
        </tr>--%>
       <%-- <tr>
            <td></td>
            
           
            <td colspan="3" style="font-size:10pt;text-align:left;font-weight:bold;padding-top:15mm; padding-left:25mm"> 	
              

            </td>
        </tr>--%>
    
    </form>
    <script type="text/javascript">
    	$(window).bind("load", function() { 
    	    window.print();
      
    	});
        </script>
</body>
</html>
