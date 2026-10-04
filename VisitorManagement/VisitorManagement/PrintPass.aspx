<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PrintPass.aspx.cs" Inherits="VisitorManagement.PrintPass" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />

    <style>
        body{
            font-size:8pt;
        }
        .qr-code {
            max-width: 150px;
            margin: 10px;
        }

        svg {
            margin: 30px;
            float: left;
            position: relative;
        }

        #download {
            position: absolute;
            margin-top: 100px;
            display: none;
            top: 130px;
            left: 120px;
        }
    </style>
</head>
<body  onload="window.print()">
    <form id="form1" runat="server">
        <div class="container" style="margin-top: 20px">
            <table class="table table-responsive">
                <tr>
                    <td style="text-align: center; border: none; font-weight: bold">
                        <div style="text-align:center;font-size:12pt;font-weight:bold">SENATE OF PAKISTAN</div>
                        <div style="text-align:center;font-size:12pt;font-weight:bold"><asp:Label ID="BranchLbl" runat="server"></asp:Label></div>
                    </td>
                </tr>
                 <tr> 
                    <td style="text-align: right; border: none;"><asp:Label ID="DateLbl" runat="server"></asp:Label></td>
                </tr>
                  <tr> 
                    <td style="text-align: left; border: none;font-weight:bold;">SUBJECT: &nbsp &nbsp&nbsp<asp:Label style="text-align: left; border: none;text-decoration:underline;font-weight:bold;" ID="Label2" Text="VISITORS ENTRY PASS" runat="server"></asp:Label></td>
                </tr>
                  <tr>
                    <td colspan="2" style="border: none">
                        <table style="width:100%">
                          <tr>
                                <td style="width:5%; font-weight: bold;text-align:left">From:</td>
                                <td style="width:10%;text-align:left;padding:5px;">
                                    <asp:Label ID="FromDate" runat="server"></asp:Label></td>
                                <td style="width:5%; font-weight: bold;text-align:right">To:</td>
                                <td style="width:10%;text-align:left;padding:5px;">
                                    <asp:Label ID="ToDate" runat="server"></asp:Label></td>
                               <td style="width:10%; font-weight: bold;text-align:right">Days:</td>
                                <td style="width:10%;text-align:left;padding:5px;">
                                    <asp:Label ID="DaysLbl" runat="server"></asp:Label></td>
                                <td style="width:15%; font-weight: bold;text-align:right">Off Days:</td>
                                <td style="width:35%;text-align:left;padding:5px;">
                                    <asp:Label ID="OffDaysLbl" runat="server" Text="Label"></asp:Label>
                                    </td>
                            </tr>
                          
                        </table>
                    </td>
                </tr>

                  <tr> 
                    <td style="text-align: left; border: none;">
                        <div style="width:10%;float:left"><asp:Label ID="Label3" style="font-weight:bold" runat="server" Text="Purpose:"></asp:Label></div>
                        <div style="width:90%;float:left;padding-left:20px;"><asp:Label ID="PassDetailsLbl" runat="server"></asp:Label></div></td>
                </tr>
                  <tr> 
                    <td style="text-align: left; border: none;">
                        <div style="width:15%;float:left"><asp:Label ID="Label4" style="font-weight:bold" runat="server" Text="Visit Type:"></asp:Label></div>
                        <div style="width:20%;float:left;text-align:left"><asp:Label ID="PassTypeLbl" runat="server"></asp:Label></div>
                   
                      <div style="width:15%;float:left"><asp:Label ID="Label5" style="font-weight:bold" runat="server" Text="Organization:"></asp:Label></div>
                        <div style="width:50%;float:left;padding-left:20px;"><asp:Label ID="CompanyLbl" runat="server"></asp:Label></div></td>
                </tr>
              

                <tr >
                    <td >
                        <table class="table table-condensed" style="width:100%">
                            <thead>
                                <%--<tr>
                                    <td colspan="4">
                                        <h4 style="font-weight: bold;text-decoration:underline">VISITOR'S DETAIL</h4>
                                    </td>
                                </tr>--%>
                                <tr>
                                    <th style="width:5%">Sr#</th>
                                    <th>Visitor Name</th>
                                    <th>CNIC</th>
                                    <th>Details (Vehicle etc) </th>

                                </tr>
                            </thead>
                            <tbody>

                                <asp:ListView ID="LV" runat="server">

                                    <ItemTemplate>
                                        <tr>
                                            <td>
                                                <asp:Label ID="SrNo" runat="server" Text='<%#Container.DataItemIndex + 1%> '></asp:Label></td>
                                            <td>
                                                <asp:Label ID="VisitorName" runat="server" Text='<%#Bind("VisitorName")%>'></asp:Label></td>
                                            <td>
                                                <asp:Label ID="Label6" runat="server" Text='<%#Bind("Cnic")%>'></asp:Label></td>
                                            <td>
                                                <asp:Label ID="Label1" runat="server" Text='<%#Bind("Details")%>'></asp:Label></td>
                                            <%-- <td>
                                        <asp:Image ID="Imagebarcode"  runat="server" CssClass="img-thumbnail" ImageUrl='<%#GenerateBarcode(Convert.ToString(Eval("Cnic")),50,400)%>'/>
                                    </td>--%>
                                        </tr>
                                    </ItemTemplate>

                                </asp:ListView>
                            </tbody>
                        </table>
                    </td>
                </tr>


            </table>
            <br /><br />
            <table style="width:100%">
                <tr>
                    <td style="width:70%"> <asp:Image ID="ImageGeneratedBarcode" runat="server"  Visible="false" Width="70%" Height="70%" /></td>
                    <td style="text-align: center; font-size: 10pt; border: none; font-weight: bold">
                         <asp:Label ID="RequestedBy" runat="server" Text="Label"></asp:Label><br />
                        <asp:Label ID="DesignationLbl" runat="server" Text="Label"></asp:Label>
                    </td>
                </tr>
            </table>
                     
          <%--  <asp:Label ID="BarCode" style="font-family:IDAutomationHC39M;font-size:28pt"  runat="server" ></asp:Label>--%>
            
        </div>

    </form>
    
    <script src="Jquery/jquery-1.10.2.js"></script>
   
</body>
</html>
