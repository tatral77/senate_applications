<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PrintMotion1.aspx.cs" Inherits="MotionBranch.PrintMotion" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        td {
            padding: 10px;
        }

    </style>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
</head>

<body style="font-family:'Times New Roman';margin-top:0px;padding-top:0px;">
    <form id="form1" runat="server">
        <table border="0" style="height:10in;margin-top:0px;padding-top:0px;width:100%" >
            <tr>
                <td style="border-right:solid;border-right-width:1px;border-right-color:#000;width:.8in;"></td>
                <td style="padding-left:10pt;padding-top:0pt;margin-top:0px;vertical-align:top;">
                    <table border="0" style="width: 95%">                        
                        <tr>
                            <td style="padding-top:3mm">
                                <div style="font-size: 14pt; text-align: center; font-weight: bold; padding: 0; padding-top: 1mm;text-decoration:underline;">SENATE SECRETARIAT</div>
                                <div style="font-size: 13pt; text-align: center; font-weight: bold; padding-top: 0px;">(MOTION BRANCH)</div>
                                 <div style="text-align: right; font-size: 13pt;text-decoration:underline;font-weight:bold;padding-bottom: 5mm;"><asp:Label ID="MotionFileNoLbl" runat="server" Text=""></asp:Label></div>
                                <div style="font-size: 13pt; padding-right: 0mm; text-align: justify; line-height: 1.5"><asp:Label ID="MotionTextLbl" runat="server" Text=""></asp:Label></div>
                                  <div style="text-align: center;width:400px;float:right;padding-top:15mm;">
                                     <asp:Label ID="MoversLbl" runat="server" Text="" style="font-size: 13pt; font-weight: bold;">S.O (Motion)<br /></asp:Label>
                               <%-- <asp:Label ID="Label2" runat="server" Text="" style="font-size: 13pt; text-align: center;">Section Officer (Motion)<br /></asp:Label>--%>
                                </div>
                                <div style="font-size: 13pt; text-align: left; font-weight: bold;padding-top:25mm;text-decoration:underline;">
                                    <asp:Label ID="Label1" runat="server" Text="">D.S. (Legis)</asp:Label>
                                </div>
                            </td>
                        </tr>                       
                    </table>
                </td>
            </tr>
        </table>
    </form>
        <script type="text/javascript">
        $(window).bind("load", function () {
            window.print();
        });
        </script>
</body>
</html>