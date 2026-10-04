<%@ Page Title="" Language="C#" MasterPageFile="~/EmployeeInformation.master" AutoEventWireup="true" CodeBehind="EmpLeaves.aspx.cs" Inherits="EstablishmentASP.EmpLeaves" %>
<asp:Content ID="Content1" ContentPlaceHolderID="EmpMenues" runat="server">

<div class="container-fluid">
    <div class="nf-head">
        <h4>LEAVE DETAILS (REVISED LEAVE RULES, 1980)</h4>
        <div class="nf-toolbar">
            <asp:Button ID="AddNewBtn" runat="server" class="btn btn-custom" Text="Add New" CausesValidation="false" OnClick="AddNewBtn_Click" />
            <asp:HyperLink ID="LeaveDetailsLink" runat="server" class="btn btn-custom" Target="_blank">Details</asp:HyperLink>
            <asp:Button class="btn btn-custom" ID="PrintBtn" runat="server" Text="Print" OnClientClick="return PrintPanel();" UseSubmitBehavior="false" CausesValidation="false" />
            <asp:Button ID="ExportPdfBtn" runat="server" class="btn btn-custom" Text="Export PDF" CausesValidation="false" OnClick="ExportPdfBtn_Click" />
        </div>
    </div>

    <div class="row">
        <div class="col-md-12">
            <asp:Label ID="MsgLbl" runat="server" EnableViewState="false"></asp:Label>
        </div>
    </div>

    <asp:Panel ID="pnlForm" runat="server" Visible="false">
        <div class="pi-card">
            <h5>Leave Entry</h5>
            <table class="form-table">
                    <tr>
                        <td colspan="2">
                            <asp:Label ID="FormMsgLbl" runat="server" ForeColor="#FF3300" EnableViewState="false"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="table-data">Leave Type</td>
                        <td>
                            <asp:DropDownList ID="LeaveTypeDDL" runat="server" class="form-control" AutoPostBack="true" CausesValidation="false" OnSelectedIndexChanged="LeaveTypeDDL_SelectedIndexChanged">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="LeaveTypeRFV" runat="server" Display="Dynamic" Text="*" ErrorMessage="Leave Type" ControlToValidate="LeaveTypeDDL" InitialValue="0" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                            <asp:Label ID="RuleHintLbl" runat="server" CssClass="help-block"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="table-data">Leave Sub Type</td>
                        <td>
                            <asp:DropDownList ID="LeaveSubTypeDDL" runat="server" class="form-control">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="LeaveSubTypeRFV" runat="server" Display="Dynamic" Text="*" ErrorMessage="Leave Sub Type" ControlToValidate="LeaveSubTypeDDL" InitialValue="0" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="table-data">From</td>
                        <td>
                            <asp:TextBox ID="StartDateTxt" runat="server" class="form-control js-date" placeholder="DD/MM/YYYY" />
                            <asp:RequiredFieldValidator ID="StartDateRFV" runat="server" Display="Dynamic" Text="Please enter a valid date" ErrorMessage="Start Date" ControlToValidate="StartDateTxt" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="table-data">No of Days</td>
                        <td>
                            <asp:TextBox ID="NoOfDaysTxt" runat="server" class="form-control" />
                            <asp:RequiredFieldValidator ID="NoOfDaysRFV" runat="server" Display="Dynamic" Text="Enter the number of days" ErrorMessage="No of Days" ControlToValidate="NoOfDaysTxt" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                            <asp:CompareValidator ID="NoOfDaysCV" runat="server" Display="Dynamic" Operator="DataTypeCheck" Type="Integer" ControlToValidate="NoOfDaysTxt" Text="Enter a valid number of days" ErrorMessage="Enter valid number of days" ValidationGroup="Group1" ForeColor="#FF3300" />
                        </td>
                    </tr>
                    <tr>
                        <td class="table-data">Ex-Pakistan</td>
                        <td>
                            <asp:CheckBox ID="ExPakistanCB" runat="server" class="form-control" />
                        </td>
                    </tr>
                    <tr>
                        <td class="table-data">Is Extension</td>
                        <td>
                            <asp:CheckBox ID="IsExtensionCB" runat="server" class="form-control" />
                        </td>
                    </tr>
                    <tr id="McRow" runat="server">
                        <td class="table-data">Medical Certificate</td>
                        <td>
                            <asp:CheckBox ID="MedicalCB" runat="server" class="form-control" />
                            <span class="help-block">Required for LFP above 120 days at a time (up to 180 days), Rule 5.</span>
                        </td>
                    </tr>
                    <tr>
                        <td class="table-data">Details</td>
                        <td>
                            <asp:TextBox ID="RemarksTxt" runat="server" class="form-control" TextMode="MultiLine" Rows="4" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:LinkButton ID="CancelBtn" runat="server" class="btn btn-custom" ToolTip="Cancel" CausesValidation="false" OnClick="CancelBtn_Click"><span class="glyphicon glyphicon-arrow-left"></span></asp:LinkButton>
                            <asp:LinkButton ID="SaveBtn" runat="server" class="btn btn-custom" ToolTip="Save" ValidationGroup="Group1" OnClick="SaveBtn_Click"><span class="glyphicon glyphicon-floppy-disk"></span></asp:LinkButton>
                        </td>
                    </tr>
                </table>
        </div>
    </asp:Panel>

    <div class="row">
        <div class="col-md-12">
            <asp:Literal ID="PositionLit" runat="server" EnableViewState="false"></asp:Literal>
        </div>
    </div>

    <div class="row">
        <asp:Panel ID="pnlContents" runat="server">
            <div class="col-md-12 regularDiv">
                <div class="page-header unhid" id="LeaveHeaderDiv" runat="server" style="display: none">
                    <h4>
                        <asp:Label ID="LeaveHeader" runat="server" Text=""></asp:Label>
                    </h4>
                </div>
                <asp:ListView ID="EmpLeavesLv" runat="server" OnItemCommand="EmpLeavesLv_ItemCommand">
                    <LayoutTemplate>
                        <table class="table table-hover table-striped table-condensed table-data leave-grid">
                            <thead>
                                <tr>
                                    <th>Sr#</th>
                                    <th>Leave Type</th>
                                    <th>Leave Sub Type</th>
                                    <th>Ex-Pakistan</th>
                                    <th>Is Extension</th>
                                    <th>Start Date</th>
                                    <th>Leave Applied</th>
                                    <th>End Date</th>
                                    <th>Joining Date</th>
                                    <th>LFP Debited</th>
                                    <th style="width: 20%">Details</th>
                                    <th class="hid">Action</th>
                                </tr>
                            </thead>
                            <tbody>
                                <tr runat="server" id="itemPlaceholder"></tr>
                            </tbody>
                        </table>
                    </LayoutTemplate>
                    <ItemTemplate>
                        <tr>
                            <td class="itemCent"><%# Container.DataItemIndex + 1 %></td>
                            <td class="itemLeft"><asp:Label CssClass="table-data" runat="server" Text='<%# Eval("LeaveType") %>'></asp:Label></td>
                            <td class="itemLeft"><asp:Label CssClass="table-data" runat="server" Text='<%# Eval("LeaveSubType") %>'></asp:Label></td>
                            <td class="itemCent"><asp:Label CssClass="table-data" runat="server" Text='<%# (Convert.ToString(Eval("ExPakistan")) == "1") ? "Yes" : "No" %>'></asp:Label></td>
                            <td class="itemCent"><asp:Label CssClass="table-data" runat="server" Text='<%# (Convert.ToString(Eval("IsExtension")) == "1") ? "Yes" : "No" %>'></asp:Label></td>
                            <td class="itemCent"><asp:Label CssClass="table-data" runat="server" Text='<%# Eval("StartDate", "{0:dd/MM/yyyy}") %>'></asp:Label></td>
                            <td style="text-align: center"><asp:Label CssClass="table-data" runat="server" Text='<%# Eval("NumberOfDays") + " Days" %>'></asp:Label></td>
                            <td class="itemCent"><asp:Label CssClass="table-data" runat="server" Text='<%# Eval("EndDate", "{0:dd/MM/yyyy}") %>'></asp:Label></td>
                            <td class="itemCent"><asp:Label CssClass="table-data" runat="server" Text='<%# GetDate(Convert.ToDateTime(Eval("ExpectedJoiningDate"))) %>'></asp:Label></td>
                            <td class="itemCent"><asp:Label CssClass="table-data" runat="server" Text='<%# GetDebit(Eval("LeaveTypeId"), Eval("LeaveSubTypeId"), Eval("StartDate"), Eval("EndDate")) %>'></asp:Label></td>
                            <td class="itemLeft"><asp:Label CssClass="table-data" runat="server" Text='<%# GetDetails(Eval("Remarks")) %>'></asp:Label></td>
                            <td class="hid">
                                <asp:LinkButton ID="EditBtn" runat="server" class="btn btn-custom" CommandName="EditLeave" CommandArgument='<%# Eval("EmpLeaveId") %>' CausesValidation="false" ToolTip="Edit"><span class="glyphicon glyphicon-pencil"></span></asp:LinkButton>
                                <asp:LinkButton ID="DeleteBtn" runat="server" class="btn btn-danger" CommandName="DeleteLeave" CommandArgument='<%# Eval("EmpLeaveId") %>' CausesValidation="false" ToolTip="Delete" OnClientClick="return confirm('Are you sure you want to delete the record');"><span class="glyphicon glyphicon-trash"></span></asp:LinkButton>
                            </td>
                        </tr>
                    </ItemTemplate>
                    <EmptyDataTemplate>
                        <table class="table table-condensed table-data">
                            <tr>
                                <td><label>No Data Found</label></td>
                            </tr>
                        </table>
                    </EmptyDataTemplate>
                </asp:ListView>
            </div>
        </asp:Panel>
    </div>

    <script>
        function PrintPanel() {
            var panel = document.getElementById("<%= pnlContents.ClientID %>");
            var headerDiv = document.getElementById("<%= LeaveHeaderDiv.ClientID %>");
            var employee = headerDiv ? headerDiv.getElementsByTagName('h4')[0].innerHTML : '';

            var clone = panel.cloneNode(true);
            var toRemove = clone.querySelectorAll('.hid, #<%= LeaveHeaderDiv.ClientID %>');
            for (var i = 0; i < toRemove.length; i++) {
                toRemove[i].parentNode.removeChild(toRemove[i]);
            }

            var css = [
                "@page { size: A4 landscape; margin: 12mm 14mm; }",
                "* { -webkit-print-color-adjust: exact; print-color-adjust: exact; box-sizing: border-box; }",
                "body { font-family: 'Segoe UI', Calibri, Arial, sans-serif; font-size: 9.5pt; color: #1b1f24; margin: 0; }",
                ".letterhead { text-align: center; margin-bottom: 10px; padding-bottom: 6px; border-bottom: 3px double #1f3a5f; }",
                ".letterhead .org { font-size: 19pt; font-weight: 700; letter-spacing: 3px; color: #1f3a5f; }",
                ".letterhead .sub { font-size: 9.5pt; color: #555; letter-spacing: 1px; margin-top: 1px; }",
                ".letterhead .title { display: inline-block; margin-top: 8px; padding: 3px 22px; font-size: 11.5pt; font-weight: 700; letter-spacing: 1.5px; color: #fff; background: #1f3a5f; }",
                ".employee { font-size: 12pt; font-weight: 700; background: #eaf0f7; border-left: 5px solid #1f3a5f; padding: 5px 10px; margin: 8px 0 8px; color: #1f3a5f; }",
                "table { border-collapse: collapse; width: 100%; }",
                "thead { display: table-header-group; }",
                "tr { page-break-inside: avoid; break-inside: avoid; }",
                ".leave-grid { margin-top: 6px; }",
                ".leave-grid th { background: #1f3a5f; color: #fff; font-weight: 600; font-size: 8.5pt; padding: 5px 4px; border: 1px solid #1f3a5f; text-align: center; }",
                ".leave-grid td { padding: 4px 5px; border: 1px solid #c5cfdc; font-size: 9pt; text-align: center; }",
                ".leave-grid tbody tr:nth-child(even) td { background: #f5f8fc; }",
                ".leave-grid td.itemLeft { text-align: left; }",
                ".leave-grid td:first-child { font-weight: 700; color: #1f3a5f; }",
                ".leave-grid th:last-child { width: 24%; }",
                ".leave-grid td:last-child { text-align: left; }",
                ".leave-grid td:nth-child(10) { font-weight: 700; background: #e3ebf6 !important; }",
                ".printed { margin-top: 14px; padding-top: 4px; border-top: 1px solid #c5cfdc; text-align: right; font-size: 7.5pt; color: #777; }"
            ].join("\n");

            var head = '<div class="letterhead">' +
                '<div class="org">SENATE OF PAKISTAN</div>' +
                '<div class="sub">HRM DATABASE &nbsp;|&nbsp; HRM BRANCH</div>' +
                '<div class="title">LEAVE DETAILS &mdash; REVISED LEAVE RULES, 1980</div>' +
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
            doc.write('<html><head><title>Leave Details</title><style>' + css + '</style></head><body>' +
                head + '<div class="employee">' + employee + '</div>' + clone.innerHTML +
                '<div class="printed">Computer generated report &nbsp;|&nbsp; Printed on ' + stamp + '</div></body></html>');
            doc.close();

            setTimeout(function () {
                frame.contentWindow.focus();
                frame.contentWindow.print();
                setTimeout(function () { document.body.removeChild(frame); }, 1000);
            }, 300);
            return false;
        }
    </script>
</div>

</asp:Content>
