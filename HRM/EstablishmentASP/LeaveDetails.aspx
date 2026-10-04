<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeBehind="LeaveDetails.aspx.cs" Inherits="EstablishmentASP.LeaveDetails" %>

<head>
    <title></title>
    <link href="Styles/MainStyles.css" rel="stylesheet" />
    <script src="./Jquery/jquery-1.10.2.js" type="text/javascript"></script>
    <script src="./Scripts/bootstrap.min.js" type="text/javascript"></script>
    <link href="./Content/bootstrap.min.css" rel="stylesheet" />
    <link href="./Content/bootstrap-theme.min.css" rel="stylesheet" />
    <link href="./Styles/jquery-ui-1.10.4.custom.css" rel="stylesheet" />
    <link href="./Styles/modern.css" rel="stylesheet" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
</head>
<body>

    <form id="f1" runat="server">
        <div class="container">
            <div class="col-md-8">
                <asp:Button class="btn btn-custom" ID="PrintBtn" runat="server" Text="Print" OnClientClick="return PrintPanel();" UseSubmitBehavior="false" />
                <asp:Button class="btn btn-custom" ID="ExportPdfBtn" runat="server" Text="Export PDF" OnClick="ExportPdfBtn_Click" />
            </div>
            <div class="col-md-4">
                <label class="control-label" for="ServiceDDL">Calculate Leave Credit From:</label>
                <asp:DropDownList ID="ServiceDDL" runat="server" CssClass="form-control" OnSelectedIndexChanged="ServiceDDL_SelectedIndexChanged" AutoPostBack="true">
                    <asp:ListItem Value="0">Govt Service Date</asp:ListItem>
                    <asp:ListItem Value="1">Senate Service Date</asp:ListItem>
                </asp:DropDownList>
            </div>
            <asp:Panel ID="pnlContents" runat="server">
                <div class="row">
                    <div class="col-md-10">
                        <div style="text-align: center">
                            <h4><u>SERVICE DETAILS</u></h4>
                            <h5>
                                <b>
                                    <asp:Label ID="Dated" runat="server"></asp:Label></b></h5>
                        </div>
                        <h4 class="page-header"><b><u>
                            <asp:Label ID="FName" runat="server"></asp:Label></u></b>
                        </h4>

                        <table class="table table-data table-condensed emp-details">
                            <tr>
                                <td>
                                    <label class="control-lbl-sm">Date of Birth:</label></td>
                                <td>
                                    <asp:Label ID="DOB" runat="server"></asp:Label></td>
                            </tr>
                            <tr>
                                <td>
                                    <label class="control-lbl-sm">Age:</label></td>
                                <td>
                                    <asp:Label ID="Age" runat="server"></asp:Label></td>
                            </tr>
                            <tr>
                                <td>
                                    <label class="control-lbl-sm">Current Designation:</label></td>
                                <td>
                                    <asp:Label ID="CurrentDesignation" runat="server"></asp:Label></td>
                            </tr>
                            <tr>
                                <td>
                                    <label class="control-lbl-sm">Current BPS:</label></td>
                                <td>
                                    <asp:Label ID="bps" runat="server"></asp:Label></td>
                            </tr>
                            <tr>
                                <td>
                                    <label class="control-lbl-sm">Employee Branch:</label></td>
                                <td>
                                    <asp:Label ID="CurrentBranch" runat="server"></asp:Label></td>
                            </tr>
                            <tr>
                                <td>
                                    <label class="control-lbl-sm">Employee Status:</label></td>
                                <td>
                                    <asp:Label ID="EmployeeStatus" runat="server"></asp:Label></td>
                            </tr>
                            <tr>
                                <td>
                                    <label class="control-lbl-sm">Govt Service Start Date:</label></td>
                                <td>
                                    <asp:Label ID="GovtServiceStartDate" runat="server"></asp:Label></td>
                            </tr>
                            <tr>
                                <td>
                                    <label class="control-lbl-sm">Senate Service Start Date:</label></td>
                                <td>
                                    <asp:Label ID="SenateServiceStartDate" runat="server"></asp:Label></td>
                            </tr>
                            <tr>
                                <td>
                                    <label class="control-lbl-sm">Current Status:</label></td>
                                <td>
                                    <asp:Label ID="CurrentStatusLbl" runat="server"></asp:Label></td>
                            </tr>
                            <tr>
                                <td>
                                    <label class="control-lbl-sm">Total Govt Service:</label></td>
                                <td>
                                    <asp:Label ID="GovtService" runat="server"></asp:Label></td>
                            </tr>
                            <tr>
                                <td>
                                    <label class="control-lbl-sm">Total Service in Senate:</label></td>
                                <td>
                                    <asp:Label ID="HouseService" runat="server"></asp:Label></td>
                            </tr>
                            <tr>
                                <td>
                                    <label class="control-lbl-sm">Superannuation Date:</label></td>
                                <td>
                                    <asp:Label ID="SuperantuationDate" runat="server"></asp:Label></td>
                            </tr>
                            <tr>
                                <td>
                                    <label class="control-lbl-sm">Leave Credit from Previous Department:</label></td>
                                <td>
                                    <asp:Label ID="PreviousLeaveCredit" runat="server"></asp:Label></td>
                            </tr>
                            <tr>
                                <td>
                                    <label class="control-lbl-sm">Current Leave Credit:</label></td>
                                <td>
                                    <asp:Label ID="CurrentLeaveCreditLbl" runat="server"></asp:Label></td>
                            </tr>
                        </table>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-10">
                        <hr />
                        <div style="text-align: center" id="GovtServiceDiv" runat="server">
                            <h4><u>LEAVE DETAILS FROM START OF GOVERNMENT SERVICE </u></h4>
                        </div>
                        <div style="text-align: center" id="SenServiceDiv" runat="server">
                            <h4><u>LEAVE DETAILS FROM START OF SENATE SERVICE </u></h4>
                        </div>
                        <div style="text-align: center">
                            <small>As per the Revised Leave Rules, 1980</small>
                        </div>
                        <asp:Label ID="NoticeLbl" runat="server" ForeColor="#FF3300"></asp:Label>
                        <table class="table table-striped table-condensed table-data leave-grid">
                            <thead>
                                <tr>
                                    <th style="text-align: center">Sr#</th>
                                    <th style="text-align: center">Year</th>
                                    <th style="text-align: center">LFP to be Earned</th>
                                    <th style="text-align: center">Earned LFP</th>
                                    <th style="text-align: center">Unearned LFP</th>
                                    <th style="text-align: center">Availed LFP</th>
                                    <th style="text-align: center">Leave Period</th>
                                    <th style="text-align: center">EOL</th>
                                    <th style="text-align: center">Credit in this year</th>
                                    <th style="text-align: center">Encashment Availed</th>
                                    <th style="text-align: center">Total Credit</th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:ListView ID="EmpLeaveLv" runat="server">
                                    <ItemTemplate>
                                        <tr>
                                            <td style="text-align: center"><%# Container.DataItemIndex + 1 %></td>
                                            <td style="text-align: center; font-weight: bold"><%# Eval("Year") %></td>
                                            <td style="text-align: center"><%# Eval("GrossEarned") %></td>
                                            <td style="text-align: center"><%# Eval("NetEarned") %></td>
                                            <td style="text-align: center"><%# Eval("NotEarned") %></td>
                                            <td style="text-align: center"><%# Eval("Availed") %></td>
                                            <td style="text-align: center"><%# Eval("LeavePeriod") %></td>
                                            <td style="text-align: center; font-weight: bold"><%# Eval("EolDays") %></td>
                                            <td style="text-align: center"><%# Eval("YearCredit") %></td>
                                            <td style="text-align: center"><%# Eval("Encashed") %></td>
                                            <td style="text-align: center"><%# Eval("Balance") %></td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:ListView>
                            </tbody>
                        </table>
                        <small>Total Credit includes the leave credit brought forward from the previous department. Leave earned is 4 days for every calendar month with more than 15 days of duty (Rule 3); no leave is earned during leave, and a leave running from one month into the next credits one month only (Rule 3(2)). Casual leave is outside the leave account.</small>

                        <asp:Literal ID="TypeSummaryLit" runat="server"></asp:Literal>
                    </div>
                </div>
            </asp:Panel>
        </div>
    </form>
    <script>
        function PrintPanel() {
            var panel = document.getElementById("<%= pnlContents.ClientID %>");
            var css = [
                "@page { size: A4 landscape; margin: 12mm 14mm; }",
                "* { -webkit-print-color-adjust: exact; print-color-adjust: exact; box-sizing: border-box; }",
                "body { font-family: 'Segoe UI', Calibri, Arial, sans-serif; font-size: 9.5pt; color: #1b1f24; margin: 0; }",
                ".letterhead { text-align: center; margin-bottom: 10px; padding-bottom: 6px; border-bottom: 3px double #1f3a5f; }",
                ".letterhead .org { font-size: 19pt; font-weight: 700; letter-spacing: 3px; color: #1f3a5f; }",
                ".letterhead .sub { font-size: 9.5pt; color: #555; letter-spacing: 1px; margin-top: 1px; }",
                ".letterhead .title { display: inline-block; margin-top: 8px; padding: 3px 22px; font-size: 11.5pt; font-weight: 700; letter-spacing: 1.5px; color: #fff; background: #1f3a5f; }",
                "u { text-decoration: none; }",
                "b { font-weight: 700; }",
                "h4, h5 { margin: 4px 0; font-weight: 600; }",
                "h4 { font-size: 10.5pt; color: #1f3a5f; letter-spacing: 1px; text-transform: uppercase; }",
                "h5 { font-size: 9pt; color: #555; }",
                "h4.page-header { font-size: 12.5pt; text-transform: none; letter-spacing: 0; background: #eaf0f7; border-left: 5px solid #1f3a5f; padding: 5px 10px; margin: 8px 0 6px; color: #1f3a5f; text-align: left; }",
                "hr { display: none; }",
                "label { font-weight: 600; color: #2c3e57; }",
                "table { border-collapse: collapse; width: 100%; }",
                "thead { display: table-header-group; }",
                "tr { page-break-inside: avoid; break-inside: avoid; }",
                ".emp-details { margin: 4px 0 12px; }",
                ".emp-details tbody { display: block; column-count: 2; column-gap: 0; column-rule: 1px solid #c5cfdc; border: 1px solid #c5cfdc; }",
                ".emp-details tr { display: table; width: 100%; table-layout: fixed; }",
                ".emp-details td { padding: 3px 9px; border-bottom: 1px solid #dde4ee; font-size: 9.5pt; }",
                ".emp-details td:first-child { width: 46%; background: #f3f6fa; }",
                ".leave-grid, .type-summary { margin-top: 6px; }",
                ".leave-grid th, .type-summary th { background: #1f3a5f; color: #fff; font-weight: 600; font-size: 8.5pt; padding: 5px 4px; border: 1px solid #1f3a5f; text-align: center; }",
                ".leave-grid td, .type-summary td { padding: 4px 5px; border: 1px solid #c5cfdc; font-size: 9pt; text-align: center; }",
                ".leave-grid tbody tr:nth-child(even) td, .type-summary tbody tr:nth-child(even) td { background: #f5f8fc; }",
                ".leave-grid td:nth-child(2) { font-weight: 700; color: #1f3a5f; }",
                ".leave-grid td:last-child, .leave-grid th:last-child { border-left: 2px solid #1f3a5f; }",
                ".leave-grid td:last-child { font-weight: 700; background: #e3ebf6 !important; }",
                ".summary-block { page-break-inside: avoid; break-inside: avoid; margin-top: 12px; }",
                ".type-summary { width: 60%; margin-left: auto; margin-right: auto; }",
                ".type-summary td:first-child, .type-summary th:first-child { text-align: left; padding-left: 9px; }",
                "small { display: block; font-size: 8pt; color: #555; font-style: italic; margin-top: 6px; line-height: 1.35; }",
                ".printed { margin-top: 14px; padding-top: 4px; border-top: 1px solid #c5cfdc; text-align: right; font-size: 7.5pt; color: #777; }"
            ].join("\n");

            var head = '<div class="letterhead">' +
                '<div class="org">SENATE OF PAKISTAN</div>' +
                '<div class="sub">HRM DATABASE &nbsp;|&nbsp; HRM BRANCH</div>' +
                '<div class="title">LEAVE ACCOUNT &mdash; REVISED LEAVE RULES, 1980</div>' +
                '</div>';
            var now = new Date();
            var pad = function (n) { return (n < 10 ? '0' : '') + n; };
            var stamp = pad(now.getDate()) + '/' + pad(now.getMonth() + 1) + '/' + now.getFullYear() + ' ' + pad(now.getHours()) + ':' + pad(now.getMinutes());

            var frame = document.createElement('iframe');
            frame.style.position = 'fixed';
            frame.style.right = '0';
            frame.style.bottom = '0';
            frame.style.width = '0';
            frame.style.height = '0';
            frame.style.border = '0';
            document.body.appendChild(frame);

            var doc = frame.contentWindow.document;
            doc.open();
            doc.write('<html><head><title>Leave Account</title><style>' + css + '</style></head><body>' +
                head + panel.innerHTML + '<div class="printed">Computer generated report &nbsp;|&nbsp; Printed on ' + stamp + '</div></body></html>');
            doc.close();

            setTimeout(function () {
                frame.contentWindow.focus();
                frame.contentWindow.print();
                setTimeout(function () { document.body.removeChild(frame); }, 1000);
            }, 300);
            return false;
        }
    </script>
</body>
