<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PrintOutgoingVisitSanction.aspx.cs" Inherits="IPR.PrintOutgoingVisitSanction" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <title></title>
    <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <meta http-equiv="X-UA-Compatible" content="ie=edge" />
    <link href="Content/bootstrap-theme.min.css" rel="stylesheet" />
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <script src="Scripts/bootstrap.min.js"></script>
    <script src="Scripts/jquery-1.9.1.min.js"></script>
    <style type="text/css">
        span {
            margin: 5px 5px 0px 0px
        }

        body {
            font-size: 15px;
        }

        @media print {
            body {
                -webkit-print-color-adjust: exact;
            }
        }

        .headerrow {
            background-color: #D3D3D3 !important;
            width: 100%;
            padding-left: 5px;
            padding-top: 5px;
            padding-bottom: 5px;
        }
        .spacing{
             padding-right: 78px;
        }

        td {
            vertical-align: top !important;
        }
        /* ---- print rules ---- */
        @media print {

             @page {
                margin: 15mm;

                /* footer */
                @bottom-center {
                content: "Page " counter(page) " of " counter(pages);
                font-size: 12px;
                color: #555;
                }
                }
            /* wrapper that should not be split across pages */
            .keep-together {
                /* modern */
                page-break-before: avoid;
                break-inside: avoid;
                /* for older browsers */
                page-break-inside: avoid;
                -webkit-column-break-inside: avoid;
            }

            /* avoid splitting rows inside a table */
            table, thead, tbody, tr, td, th {
                break-inside: avoid;
                page-break-inside: avoid;
            }

            /* keep table header repeated on each page */
            thead {
                display: table-header-group;
            }

            /* small tweak so margins don't force break */
            body {
                margin: 10mm;
            }
        }
    </style>

</head>
<body>
    <form runat="server" id="form1">
      <%--  <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />--%>
        <asp:Panel ID="pnlContents" runat="server">
             <div class="keep-together">
            <table style="width:80%">
                <tr>
                    <td>
                        <table>
                            <tr>
                                <td colspan="3"><span class="style1"></span>

                                    <div id="printPerview">
                                        <table width="830" align="center" style="page-break-inside: avoid; page-break-before: avoid">

                                            <tr align="center">
                                                <td colspan="6">
                                                    <asp:Label runat="server" Style="font-size: 14pt; font-weight: bold;">SENATE SECRETARIAT</asp:Label></td>
                                            </tr>

                                            <tr>
                                                <td colspan="2"><asp:Label ID="FileNoLbl" runat="server" Text=""></asp:Label></td>
                                                <td></td>
                                                <td></td>
                                                <td colspan="2" class="text-right">
                                                    <asp:Label ID="DateLbl" runat="server" Text=""></asp:Label><br />
                                                    <br />
                                                </td>
                                            </tr>

                                            <tr>
                                                <td width="10%">From:</td>
                                                <td colspan="2" width="36%">
                                                    <asp:Label ID="MoverLbl" runat="server" Text=""></asp:Label><br />
                                                    <asp:Label ID="Label2" runat="server" Text="Section Officer (IPR)"></asp:Label><br />
                                                    <br />
                                                </td>
                                                <td width="18%"></td>
                                                <td width="18%"></td>
                                                <td width="18%"></td>
                                            </tr>

                                            <tr>
                                                <td>To:</td>
                                                <td>The Accountant General<br />
                                                    Pakistan Revenues,<br />
                                                    Islamabad.</td>
                                                <td></td>
                                                <td></td>
                                                <td></td>
                                                <td></td>
                                            </tr>

                                            <tr>
                                                <td colspan="6"></td>
                                            </tr>

                                            <tr>
                                                <td><strong>Subject:</strong></td>
                                                <td colspan="5" class="text-justify">
                                                    <p style="text-decoration: underline;">
                                                        <strong><asp:Label ID="SubjectLbl" runat="server" Text=""></asp:Label></strong>
                                                    </p>
                                                </td>
                                            </tr>

                                            <tr>
                                                <td colspan="6">Sir,</td>
                                            </tr>

                                            <tr>
                                                <td colspan="6">
                                                    <p class="text-justify"><span class="spacing"></span>
                                                        In pursuance of <asp:Label ID="RuleNoLbl" runat="server" Text=""></asp:Label>
                                                        I am directed to convey sanction of President to an expenditure amounting to <strong>
                                                            <asp:Label ID="TotalPkrLbl" runat="server" Text=""></asp:Label></strong> to be incurred on the 
                                                            <asp:Label ID="IncurredOnLbl" runat="server" Text=""></asp:Label>. The composition of the delegation is as follows.-
                                                    </p>
                                                </td>
                                            </tr>

                                            <tr>
                                                <td></td>
                                                <td colspan="5">
                                                    <table>
                                                        <tr>
                                                            <td>
                                                                <ol type="i">
                                                                    <asp:ListView runat="server" ID="CompositionLV">
                                                                        <ItemTemplate>
                                                                            <li style="padding-left: 10px">
                                                                                <asp:Label ID="Label1" runat="server" Text='<%#Eval("VisitorName")%> '></asp:Label></li>
                                                                        </ItemTemplate>
                                                                    </asp:ListView>
                                                                </ol>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>

                                            <tr>
                                                <td colspan="6" class="text-justify" style="margin-top: 5px;">2.<span class="spacing"></span>
                                                    The itinerary is annexed.
                                                </td>
                                            </tr>

                                            <tr>
                                                <td colspan="6" class="text-justify" style="margin-top: 5px;">3.<span class="spacing"></span>
                                                    The expenditure involved will be borne by the Senate Secretariat. The Chairman Senate, Senators & officers will be entitled to the following DA etc. during the period of their official visit abroad:-
                                                </td>
                                            </tr>

                                            <%-- <tr>
                                                <td colspan="2" valign="top">&nbsp;&nbsp;<h5><strong>FOREIGN EXCHANGE</strong></h5>
                                                </td>
                                                <td colspan="4"></td>
                                            </tr>--%>
                                        </table>
                                        <div style="page-break-inside: avoid; page-break-before: avoid">
                                            <table>
                                                <thead>
                                                <tr>
                                                    
                                                    <th>
                                                        <h5><strong>FOREIGN EXCHANGE</strong></h5>
                                                    </th>
                                                </tr>
                                                </thead>
                                                <tbody>
                                                <tr>
                                                    
                                                    <td>

                                                        <asp:ListView ID="VisitLV" OnItemDataBound="VisitLV_ItemDataBound" runat="server">
                                                            <ItemTemplate>

                                                                <table class="table table-condensed table-bordered" style="width: 99%">
                                                                    <thead style="background-color: #D3D3D3!important">
                                                                        <%#AddLocationgHeader()%>
                                                                    </thead>
                                                                    <tbody>
                                                                        <tr>
                                                                            <td colspan="5">
                                                                                <table class="table table-condensed table-bordered">
                                                                                    <tr>
                                                                                        <th>Name</th>
                                                                                        <th>Category</th>
                                                                                        <th>Formula</th>
                                                                                        <th>Total (US$)</th>
                                                                                        <th>Remarks</th>
                                                                                    </tr>

                                                                                    <asp:ListView ID="VisitorsLV" runat="server">
                                                                                        <ItemTemplate>
                                                                                            <%--    <%#AddCategoryRow()%>--%>
                                                                                            <tr>
                                                                                                <td>
                                                                                                    <asp:Label ID="Label1" runat="Server" Text='<%#Eval("VisitorName") + " ("  + Eval("Post") + ")"  %>' /></td>

                                                                                                <td>
                                                                                                    <asp:Label ID="FirstNameLabel" runat="Server" Text='<%#Eval("Category") %>' /></td>
                                                                                                <td>
                                                                                                    <asp:Label ID="Label3" runat="Server" Text='<%#Eval("Formula") %>' /></td>
                                                                                                <td>
                                                                                                    <asp:Label ID="LastNameLabel" runat="Server" Text='<%#Eval("TotalDA") %>' /></td>
                                                                                                <td style="width: 30%">
                                                                                                    <asp:Label ID="DaRemarksLbl" runat="Server" Text='<%#Eval("DaRemarks") %>' /></td>

                                                                                            </tr>
                                                                                        </ItemTemplate>
                                                                                    </asp:ListView>
                                                                                </table>
                                                                            </td>
                                                                        </tr>
                                                                    </tbody>
                                                                    <tfoot>
                                                                        <%#AddLocationgFooter()%>
                                                                    </tfoot>
                                                                </table>

                                                            </ItemTemplate>
                                                        </asp:ListView>

                                                    </td>
                                                </tr>
                                                </tbody>
                                            </table>
                                        </div>
                                        <table class="table table-condensed table-bordered" style="width: 99%">
                                            <tr id="ChairmanAllowancesRow1" runat="server" visible="false">
                                                <td style="width: 85%">
                                                    <p>Personal Discretionary Allowance/ Entertainment Charges for Chairman Senate</p>
                                                </td>
                                                <td><b>US$1000</b></td>
                                            </tr>

                                            <tr id="ChairmanAllowancesRow2" runat="server" visible="false">
                                                <td>Additional Miscellaneous expenses advance for Chairman Senate</td>
                                                <td><b>US$1000</b></td>
                                            </tr>

                                            <tr id="transportChargesRow" runat="server" visible="false">
                                                <td>
                                                    <asp:Label ID="TransportChargesDescLbl" runat="Server" Text="" /></td>
                                                <td><b>
                                                    <asp:Label ID="TransportChargesLbl" runat="Server" Text="" /></b></td>
                                            </tr>
                                            <tr>
                                                <td style='font-weight: bold;'>GRAND TOTAL</td>
                                                <td style='font-weight: bold;'><b>
                                                    <asp:Label ID="GrandTotalLbl" runat="Server" Text="" /></b></td>
                                            </tr>
                                        </table>
                                        <div style="page-break-inside: avoid; page-break-before: auto">
                                            <table>

                                                <tr>
                                                    <td colspan="6" class="text-justify" style="margin-top: 5px; width: 10%">4.<span class="spacing"></span>
                                                            A cheque amounting to  <strong>
                                                                <asp:Label ID="TotalPkrLbl2" runat="server" Text=""></asp:Label></strong>  may be issued in favour of D.D.O Senate Secretariat, who will render the account in due course.
                                                    </td>
                                                </tr>

                                                <tr>
                                                    <td colspan="6" class="text-justify" style="margin-top: 5px;">5.<span class="spacing"></span>
                                                        The  Chairman Senate has aproved the expenditure and the Secretary Senate has approved the payment of the amount in advance.
                                                    </td>
                                                </tr>

                                                <tr>
                                                    <td colspan="6" class="text-justify" style="margin-top: 5px;">6.<span class="spacing"></span>
                                                            The expenditure involved will be debitable to the head 
                                                                <b>"<asp:Label ID="HeadOfAccountLbl" runat="server" Text=""></asp:Label>"</b>
                                                                 under demand No. <asp:Label ID="DemandNoLbl" runat="server" Text=""></asp:Label> during the financial year <asp:Label ID="FinancialYearLbl1" runat="server" Text=""></asp:Label>.
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="6" class="text-justify" style="margin-top: 5px;">7.<span class="spacing"></span>
                                                            The foreign exchange component of the expenditure involved will be met from the Foreign 
                                                    Exchange allocation of the Senate for the financial year <asp:Label ID="FinancialYearLbl2" runat="server" Text=""></asp:Label>.
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="6" class="text-justify" style="margin-top: 5px;">8.<span class="spacing"></span>
                                                            The Chairman Senate, Senators and officer will not be entitled to draw any pay and allowances 
                                                    from any Pakistani Mission during their visit abroad.
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="6" class="text-justify" style="margin-top: 5px;">9.<span class="spacing"></span>
                                                            The Chairman Senate has approved the travel itinerary and the air-tickets from a travel agent under 
                                                    rule 21-A of the Senate Finance Committee Rules, 1973 and the General Directions of the Senate Finance 
                                                    Committee to regulate expenditure on visits abroad.
                                                    </td>
                                                </tr>
                                            </table>
                                            <table style="width:100%">
                                                <tr align="center">
                                                    <td style="width: 75%"></td>
                                                    <td>
                                                        <p>Yours faithfully,</p>
                                                        <p style="height: 20px"></p>
                                                    </td>
                                                </tr>
                                                <tr align="center">
                                                    <td></td>
                                                    <td style="font-weight: bold">(
                                                    <asp:Label ID="MoverLabel2" runat="server" Text=""></asp:Label>)<br />
                                                        <asp:Label ID="Label5" runat="server" Text="Section Officer (IPR)"></asp:Label><br />
                                                        <br />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="text-justify">Copy forwarded to:
                                              <ol type="1">
                                                  <li>The Cash & Accounts Branch, Senate Secretariat, Islamabad</li>
                                                  <li>The Finance & Accounts Branch, Senate Secretariat, Islamabad</li>
                                                  <li>The Director General (Audit), Federal Government, Islamabad</li>
                                              </ol>
                                                        <br />
                                                    </td>
                                                </tr>
                                                <tr align="center">
                                                    <td></td>
                                                    <td style="font-weight: bold">(
                                                    <asp:Label ID="MoverLabel3" runat="server" Text=""></asp:Label>)<br />
                                                        <asp:Label ID="Label8" runat="server" Text="Section Officer (IPR)"></asp:Label><br />
                                                        <br />
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </div>
                                    <!-- Print Preview END-->
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
                 </div>
        </asp:Panel>

    </form>

    <script type="text/javascript">
        $(window).bind("load", function () {
            window.print();
        });
        function PrintPanel() {
            var panel = document.getElementById("<%=pnlContents.ClientID %>");
            var printWindow = window.open('', '', 'height=400,width=800');
            printWindow.document.write("<html><head> <link href='Styles/Print.css' rel='stylesheet'/><title></title>");
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
