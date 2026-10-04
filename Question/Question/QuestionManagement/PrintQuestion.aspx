<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PrintQuestion.aspx.cs" Inherits="QuestionManagement.PrintQuestion" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Print Question</title>
    <link href="Styles/NSole.css" rel="stylesheet" />
 <style type="text/css">
<!--
.style1 {font-size: 10px}
.Labels
{
	font-family:Verdana, Arial, Helvetica, sans-serif;
	font-size: 14px;
	font-weight:bold;
	text-align:right;
}

.LabelsLeftAlign
{
	font-family:Verdana;
	font-size: 14px;
	font-weight:bold;
	text-align:left;
}

.LabelsCenterAlign
{
	font-family:Verdana;
	font-size: 14px;
	font-weight:bold;
	text-align:center;
}


-->
</style>
</head>
<body>
<table id="mainTable" width="100%" class="mainTableHeight1024x768" border="0" cellpadding="0" cellspacing="0">
  <tr>
    <td width="123" valign="top" class="LeftBgColor">

</td>
    <td valign="top">
    <form name="frm" method="POST" action="question_print_view.jsp">
    <table  cellspacing="0" cellpadding="5" border="0" width="100%" align="center">
        <tr>
          <td colspan="3"><span class="style1"></span>            <span class="style1"></span></td>
          </tr>
        <tr>
          <td colspan="3"><span class="style1"></span>
		    <div id="printPerview">
		    <table width="670" border="0" align="center" cellpadding="5" cellspacing="1">
              <tr align="center">
                <td valign="top">&nbsp;			    </td>
                <td valign="top"><table  border="0" align="center" cellpadding="0" cellspacing="0">
                  <tr>
                    <td><h3 align="center">SENATE OF PAKISTAN</h3></td>
                  </tr>
                  <tr>
                    <td class="LabelsCenterAlign">(Question Branch)</td>
                  </tr>
                  <tr>
                    <td class="LabelsCenterAlign">---------------------------------</td>
                  </tr>
                  <tr>
                    <td class="LabelsCenterAlign">SESSION NO: <asp:Label ID="SessionNoLbl" runat="server" Text="Label"></asp:Label></td>
                  </tr>
                </table></td>
                <td colspan="2" align="left" valign="top">
			      <table  border="1" cellpadding="2" cellspacing="2" bordercolor="#000000">
                    <tr>
                        
                      <td style="font:Verdana; font-size:14px">&nbsp;<asp:Label ID="CategoryLbl" runat="server" Text="Label"></asp:Label>&nbsp;</td>
                    </tr>
                    </table></td>
                </tr>
              <tr align="center">
                <td width="143" class="Labels">&nbsp;</td>
                <td width="326" class="LabelsCenterAlign">&nbsp;</td>
                <td width="86" class="LabelsLeftAlign"> Diary No:</td>
                <td width="70" align="left">
                    <asp:Label ID="DiaryNoLbl" runat="server" Text="Label"></asp:Label></td>
              </tr>
              <tr align="center">
                <td class="Labels">&nbsp;</td>
                <td class="Labels">&nbsp;</td>
                <td class="LabelsLeftAlign">Group No: </td>
                <td align="left">
                    <asp:Label ID="GroupNoLbl" runat="server" Text="Label"></asp:Label></td>
              </tr>
              <tr align="center">
                <td class="Labels">&nbsp;</td>
                <td class="Labels">&nbsp;</td>
                <td align="left" nowrap="nowrap">&nbsp;</td>
                <td align="left" nowrap="nowrap">&nbsp;</td>
              </tr>
              
              <tr align="center">
                <td class="LabelsLeftAlign">NOTICE DATE:</td>
                <td align="center" style="font:Verdana; font-size:14px">
                    <asp:Label ID="NotiveDateLbl" runat="server" Text="Label"></asp:Label>
                    <asp:Label ID="NoticeTimeLbl" runat="server" Text="Label"></asp:Label>
                </td>
                <td align="left">&nbsp;</td>
                <td align="left">&nbsp;</td>
              </tr>
              <tr align="center">
                <td class="LabelsLeftAlign">MIN/DIV/DEPTT:</td>                          
                <td align="center" style="font:Verdana; font-size:14px">
                    <asp:Label ID="DivisionLbl" runat="server" Text="Label"></asp:Label></td>
                <td align="left">&nbsp;</td>
                <td align="left">&nbsp;</td>
              </tr>
              <tr align="center">
                <td class="LabelsLeftAlign">STATUS:</td>                          
                <td align="center" style="font:Verdana; font-size:14px">
                    <asp:Label ID="StatusLBL" runat="server" Text="Label"></asp:Label></td>
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
-->
              <tr align="center">
              <td colspan="3"  style="font-family:Verdana; font-size:16px; text-align:left; font-weight:bold; text-decoration:underline">
                  <asp:Label ID="SenatorNameLbl" runat="server" Text=""></asp:Label></td>                          
                <td class="LabelsLeftAlign"></td>
              </tr>
                <tr align="center">
                <td colspan="4" style="font:Verdana; font-size:16px"><div style="line-height: 40px; text-align:justify;"><p align="justify">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="QuestionLbl" runat="server" Text="Label"></asp:Label></p>
<p align="justify">&nbsp;</p>
<p align="justify">&nbsp;</p></div></td>
                </tr>
              <tr align="center" class="hide">
                <td>&nbsp;
              </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
              </tr>
            </table>
		      </div>		    <span class="style1"></span></td>
          </tr>
        <tr>
          <td colspan="3"><span class="style1"></span>          <span class="style1"></span></td>
          </tr>
        <tr>
          <td width="90%">&nbsp;</td>
          <td width="90%"><input type="hidden" name="tableData"/></td>
          <td width="5%"><span class="style1"></span></td>
        </tr>
        <tr>
          <td colspan="3"></td>
        </tr>
        <tr>
		  <td colspan="3" align="center">
		  <button class="InputButton" type="button" name="back" title="Click to Back"  accesskey="P" onclick="javascript:history.back();">&nbsp;<u>B</u>ack&nbsp;</button>
		  &nbsp;
                  <button class="InputButton" type="button" name="preview" title="Click to Preview"  accesskey="P" onclick="javascript:openDialog('questionPrint_perview.jsp',window);">&nbsp;<u>P</u>rint Preview&nbsp;</button>
                        &nbsp;
                      <button type="button" class="InputButton" accesskey="E"  onclick="editReportResult();" title="Print Perview"><u>E</u>dit Question Print</button>                    
                       &nbsp;
   
    <button name="btnPrintUrduPreview" type="button" class="InputButton" accesskey=""  onclick="printUrduText();" title="Print Translated Text">Print Translated Text</button>
&nbsp;  

					 &nbsp;                 
                  
				  <button class="hide" type="submit" name="preview" title="Click to Print References"  accesskey="P">&nbsp;<u>P</u>rint Previous References</button></td>
        </tr>
</table>
</form>
    </td>
  </tr>
  
  <tr>
    <td height="10" class="LeftBgColor">&nbsp;</td>
    <td height="10" align="center" class="Footer"></td>
  </tr>
</table>
</body>
</html>
