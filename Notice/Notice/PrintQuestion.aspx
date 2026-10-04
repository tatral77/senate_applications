<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PrintQuestion.aspx.cs" Inherits="Notice.PrintQuestion" %>

<!DOCTYPE html>

<html>
<head runat="server">
   <title></title>
	<link href="Styles/NSole.css" rel="stylesheet" />
	<link href="Content/bootstrap-theme.min.css" rel="stylesheet" />
	<link href="Content/bootstrap.min.css" rel="stylesheet" />
	<script src="Scripts/bootstrap.min.js"></script>
	<script src="Scripts/jquery-1.9.1.min.js"></script>
 <style type="text/css">

.Labels
{
	font-family:'Times New Roman';
	font-size: 14pt;
	font-weight:bold;
	text-align:right;
}

.LabelsLeftAlign
{
	font-family:'Times New Roman';
	font-size: 14pt;
	font-weight:bold;
	text-align:left;
}

.LabelsCenterAlign
{
	font-family:'Times New Roman';
	font-size: 14pt;
	font-weight:bold;
	text-align:center;
}
p
{
	margin-top:10px;
	
}

-->
</style>
	 
</head>
<body>
	<form runat="server" id="form1">
		<asp:Panel id="pnlContents" runat = "server">
<table style="align-self:center" width="80%"  border="0" cellpadding="0" cellspacing="0">
  <tr>
  <%--  <td width="123" valign="top" class="LeftBgColor">

</td>--%>
	<td valign="top">

	<table  cellspacing="0" cellpadding="0" border="0" width="80%" align="center">
	   <%-- <tr>
		  <td colspan="3"><span class="style1"></span>            <span class="style1"></span></td>
		  </tr>--%>
		<tr>
		  <td colspan="3"><span class="style1"></span>
			<div id="printPerview">
			<table width="870" border="0" align="center" cellpadding="4" cellspacing="1" style="page-break-inside: avoid;page-break-before:auto">
			  <tr align="center">
			   <td valign="top">&nbsp;			    </td>
				<td valign="top">
                    <table  border="0" align="center" cellpadding="0" cellspacing="0">
				  <tr>
					<td><asp:Label runat="server" style="font-family:'Times New Roman';font-size:18pt;text-align:center">SENATE OF PAKISTAN</asp:Label></td>
				  </tr>
				  <tr>
					<td class="LabelsCenterAlign" style="font-family:'Times New Roman';font-size:16pt">(Notice Office)</td>
				  </tr>
				  <tr>
					<td class="LabelsCenterAlign">---------------------------------</td>
				  </tr>
				  <tr>
					<td class="LabelsCenterAlign" style="font-family:'Times New Roman';font-size:16pt">SESSION NO: <asp:Label ID="SessionNoLbl" runat="server" Text="Label"></asp:Label></td>
				  </tr>
				</table></td>
				<td colspan="2" align="center" valign="top">
					<table  border="1" cellpadding="2" cellspacing="2" bordercolor="#000000">
					<tr>
						
					  <td style="font-family:'Times New Roman';font-size:14pt;letter-spacing: 3px;">&nbsp;<asp:Label ID="CategoryLbl" runat="server" Text="" Style="padding:2px; margin:2px" ></asp:Label>&nbsp;</td>
					</tr>
					</table>
				 </td>
				</tr>
			
			  <tr align="center">
				<td width="143" class="Labels">&nbsp;</td>
				<td width="326" class="LabelsCenterAlign">&nbsp;</td>
				<td width="90" class="LabelsLeftAlign" style="font-size:14pt;" > Diary No:</td>
				<td width="70" align="left" >
					<asp:Label ID="DiaryNoLbl" runat="server" Text="" style="font-size:14pt;font-family:'Times New Roman'"></asp:Label></td>
			  </tr>
			  <tr align="center">
				<td class="Labels">&nbsp;</td>
				<td class="Labels">&nbsp;</td>
				<td class="LabelsLeftAlign" style="font-size:14pt;">Origin: </td>
				<td align="left">
					<asp:Label ID="DeviceLbl" style="font-family:'Times New Roman'; font-size:14pt" runat="server" Text=""></asp:Label></td>
			  </tr>
			  <tr align="center">
				<td class="Labels">&nbsp;</td>
				<td class="Labels">&nbsp;</td>
				<td align="left" nowrap="nowrap">&nbsp;</td>
				<td align="left" nowrap="nowrap">&nbsp;</td>
			  </tr>
			  
			  <tr align="center">
				<td class="LabelsLeftAlign" nowrap style="font-size:14pt;">NOTICE DATE/TIME:</td>
				<td align="center" style="font-family:'Times New Roman'; font-size:14pt">
					<asp:Label ID="NotiveDateLbl" runat="server" Text="Label"></asp:Label>
					<asp:Label ID="NoticeTimeLbl" runat="server" Text="Label"></asp:Label>
				</td>
				<td align="left">&nbsp;</td>
				<td align="left">&nbsp;</td>
			  </tr>
				
<!--

font-family:Verdana;
	color: #F6EEA5;
	font-size: 11px;
	font-weight:bold;
	text-align:left;
	class="LabelsLeftAlign"
--></table>
              
			  </div>		   </td>
		  </tr>
		
	   
</table>
		

	</td>
  </tr>
  
  
</table>
            <div style="padding-top:10px;">
				  <asp:Label ID="SenatorNameLbl" runat="server" Text="" style="font-family:Verdana;font-size:18pt; text-align:left; font-weight:bold; text-decoration:underline;padding:10px;"></asp:Label>
				  <div style="width:680pt;page-break-before:avoid;font-family:'Times New Roman'; font-size:18pt;line-height:2.5; text-align:justify;"><asp:Label ID="QuestionLbl" runat="server"></asp:Label></div>
			</div>
			</asp:Panel>
		
		</form>

	 <script type="text/javascript">
		$(window).bind("load", function() { 
	 window.print();
});
		function PrintPanel() {
			var panel = document.getElementById("<%=pnlContents.ClientID %>");
			var printWindow = window.open('', '', 'height=400,width=800');
			printWindow.document.write("<html><head><link href='Styles/NSole.css' rel='stylesheet' /><title></title>");
			printWindow.document.write('</head><body >');
			printWindow.document.write(panel.innerHTML);
			printWindow.document.write('</body></html>');
			printWindow.document.close();
			setTimeout(function () {
				printWindow.print();
			}, 500);
			return false;
		}
	</script> 
</body>
</html>
