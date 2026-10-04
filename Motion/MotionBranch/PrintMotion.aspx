<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PrintMotion.aspx.cs" Inherits="MotionBranch.PrintMotion" %>

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
	
<body style="font-family:Verdana;margin-left:15mm;margin-right:2mm;margin-top:5mm;">
	<form id="form1" runat="server">
	   
	<table  border="0" style="width:100%">
		<tr><td style="font-size:13pt;text-align:center;font-weight:bold;padding:0;text-decoration:underline;" colspan="4">SENATE SECRETARIAT</td></tr>
		<tr><td colspan="4" style="font-size:10pt;text-align:center;font-weight:bold;padding-top:0px;padding-bottom:5mm;">
			<asp:Label ID="MotionTypeLbl1" runat="server" Text="Label"></asp:Label></td></tr>
		<tr>
			  <td style="width:23%;font-size:9pt;font-weight:bold;padding-top:10px;">SESSION NO / MID:</td>
			<td style="width:27%;font-size:9pt;font-weight:bold;padding-top:10px;padding-left:10px;"><asp:Label ID="SessionLbl" runat="server" Text=""></asp:Label></td>
			<td style="width:23%;font-size:9pt;font-weight:bold;padding-top:10px;text-align:left;;padding-left:10px;">MOTION WEEK:</td>
			<td style="width:27%;font-size:9pt;font-weight:bold;padding-top:10px;"><asp:Label ID="MotionDNoLbl" runat="server" Text=""></asp:Label></td>
		  
		</tr>
		 <tr>
			<td style="font-size:9pt;font-weight:bold;padding-top:10px;" >NOTICE RECEIVED ON:</td>
			<td style="font-size:9pt;font-weight:bold;padding-top:10px;;padding-left:10px;" ><asp:Label ID="NoticeDateLbl" runat="server" Text=""></asp:Label></td>
			<td style="font-size:9pt;font-weight:bold;padding-top:10px;text-align:left;padding-left:10px;">STATUS:</td>
			<td style="font-size:9pt;font-weight:bold;padding-top:10px;"><asp:Label ID="StatusLbl" runat="server" Text=""></asp:Label></td>
		</tr>
		
		</table>
		<div style="padding-right:10mm;margin-top:30px;padding-bottom:5mm;text-align:justify">
			 <asp:Label Visible="false" ID="MotionTextLblEng" runat="server" Text="" style="font-size:11pt;padding-right:0mm;text-align:justify;line-height:2.5; font-family:'Verdana';"></asp:Label>
			<asp:Label visible="false" ID="MotionTextLblUr" runat="server" Text="" style="direction: rtl;font-size:11pt;padding-left:40mm;padding-right:0mm;text-align:justify;line-height:2.5; font-family: 'Noto Nastaliq Urdu Draft';"></asp:Label>
			<div style="text-align:right;font-size:11pt;font-weight:bold;margin-top:20px;">
			<asp:Label ID="MoversLbl" runat="server" Text=""></asp:Label>
		</div>  
		</div>
		
		<%-- <tr>
			<td colspan="4" style="padding-left:40mm;"> 	
				

			</td>
		</tr>--%>
	   <%-- <tr>
			<td></td>
			
		   
			<td colspan="3" style="font-size:9pt;text-align:left;font-weight:bold;padding-top:15mm; padding-left:25mm"> 	
			  

			</td>
		</tr>--%>
	
	</form>
	<script type="text/javascript">
        $(window).bind("load", function () {
            window.print();

        });
    </script>
</body>
</html>
