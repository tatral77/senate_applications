<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="ManageVisitorPasses.aspx.cs" Inherits="MY.ManageVisitorPasses" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Styles/jquery-ui-1.13.2.css" rel="stylesheet" />
    <style>
        .vp-search { display: flex; flex-wrap: wrap; gap: 10px; align-items: flex-end; }
        .vp-search .grow { flex: 1 1 260px; }
        .vp-search label { display: block; margin: 0 0 4px; font-size: 12px; font-weight: 600; color: #4b5b6e; text-transform: uppercase; letter-spacing: .3px; }
        .vp-range { white-space: nowrap; }
        .vp-range .arrow { color: var(--muted); padding: 0 4px; }
        .vp-chip { display: inline-block; padding: 2px 10px; border-radius: 999px; font-size: 12px; font-weight: 600; }
        .vp-yes { background: #e6f6ec; color: #14653a; }
        .vp-no { background: #eef1f5; color: #5b6673; }
        .vp-type { background: #e8f2fd; color: var(--brand-dark); }
        .vp-actions { white-space: nowrap; }
        .vp-actions .btn { margin: 0 2px 2px 0; }
        .vp-form { padding: 6px 4px 2px; }
        .vp-form .row { margin-bottom: 12px; }
        .vp-form label.lbl { display: block; margin: 0 0 4px; font-size: 12px; font-weight: 600; color: #4b5b6e; text-transform: uppercase; letter-spacing: .3px; }
        .vp-form h5 { margin: 0 0 12px; padding-bottom: 8px; border-bottom: 2px solid #e6eef9; font-weight: 700; letter-spacing: .5px; color: var(--brand-dark); }
        .vp-form .vp-check label { display: inline-block; margin: 0 14px 0 4px; text-transform: none; letter-spacing: 0; font-size: 13.5px; color: var(--ink); font-weight: 500; }
        .vp-form .vp-buttons { display: flex; gap: 8px; padding-top: 6px; border-top: 1px solid var(--line); margin-top: 6px; }
        .vp-form .vp-buttons .btn { min-width: 110px; }
        tr.vp-editrow > td { background: #f7fafe; padding: 14px 16px !important; }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="nf-head">
        <h4>VISITOR PASSES</h4>
        <div class="nf-toolbar" style="margin: 0">
            <input type="button" class="btn btn-default" value="Print" onclick="return PrintPanel();" />
            <input type="button" class="btn btn-default" value="Export PDF" onclick="return ExportPdf();" />
            <asp:Button class="btn btn-custom" ID="Button1" runat="server" CommandName="new" Text="+ Add New Pass" OnClick="newLinkButton_Click" CausesValidation="false" />
        </div>
    </div>

    <asp:Label ID="MsgLbl" runat="server" CssClass="nf-err"></asp:Label>

    <div class="panel panel-default qs-filter">
        <div class="panel-body" style="padding-bottom: 16px">
            <div class="vp-search">
                <div class="grow">
                    <label for="PassIdTxt">Find a pass by Pass ID</label>
                    <asp:TextBox ID="PassIdTxt" AutoPostBack="true" OnTextChanged="PassIdTxt_TextChanged" ClientIDMode="Static" runat="server" CssClass="form-control" placeholder="Enter pass ID and press Enter" />
                </div>
                <div>
                    <asp:Button class="btn btn-custom" ID="SearchBtn" runat="server" CommandName="new" Text="Search" OnClick="SearchBtn_Click" CausesValidation="false" />
                    <asp:Button class="btn btn-default" ID="ResetBtn" runat="server" Text="Show All" OnClick="ResetBtn_Click" CausesValidation="false" />
                </div>
            </div>
        </div>
    </div>

    <asp:Panel ID="pnlContents" runat="server">
    <div class="nm-count"><%= LV.Items.Count %> pass(es)</div>

    <table class="table table-hover table-striped qs-table">
        <thead>
            <tr>
                <th>Sr#</th>
                <th>Pass ID</th>
                <th>Pass Date</th>
                <th>Requested By</th>
                <th>Visit Purpose</th>
                <th>Pass Type</th>
                <th>Valid</th>
                <th>Remarks</th>
                <th>Verified</th>
                <th>Active</th>
                <th class="hid">Action</th>
            </tr>
        </thead>
        <tbody>

            <asp:ListView ID="LV" runat="server"
                OnItemEditing="ItemEditing"
                OnItemDataBound="ItemDataBound"
                OnItemCanceling="ItemCanceling"
                OnItemCreated="ItemCreated"
                OnItemInserting="ItemInserting"
                OnItemUpdating="ItemUpdating">
                <ItemTemplate>
                    <tr>
                        <td>
                            <asp:HiddenField ID="HidMemberCardId" runat="server" Value='<%#Bind("PassId")%>' />
                            <asp:Label ID="SrNo" runat="server" Text='<%#Container.DataItemIndex + 1%>'></asp:Label></td>
                        <td>
                            <b>
                                <asp:Label ID="Label7" runat="server" Text='<%#Eval("PassCode")%>'></asp:Label></b>
                        </td>
                        <td>
                            <asp:Label ID="Label8" runat="server" Text='<%#Convert.ToDateTime(Eval("PassDate")).ToString("dd/MM/yyyy")%>'></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="PassportNumber" runat="server" Text='<%#Convert.ToString(Eval("RequestedBy")) + " - " + Convert.ToString(Eval("Post")) + " ( " +  Convert.ToString(Eval("Bps")) + " ) " %>'></asp:Label></td>
                        <td>
                            <asp:Label ID="Label6" runat="server" Text='<%#Eval("VisitPurpose")%>'></asp:Label></td>
                        <td>
                            <span class="vp-chip vp-type">
                                <asp:Label ID="Label1" runat="server" Text='<%#Eval("PassTypes.Description")%>'></asp:Label></span></td>
                        <td class="vp-range">
                            <asp:Label ID="Label2" runat="server" Text='<%#Convert.ToDateTime(Eval("FromDate")).ToString("dd/MM/yyyy")%>'></asp:Label><span class="arrow">&rarr;</span><asp:Label ID="Label3" runat="server" Text='<%#Convert.ToDateTime(Eval("ToDate")).ToString("dd/MM/yyyy")%>'></asp:Label></td>
                        <td>
                            <asp:Label ID="Label5" runat="server" Text='<%#Eval("Remarks")%>'></asp:Label></td>
                        <td>
                            <span class='<%#(Convert.ToInt32(Eval("Verified"))==1?"vp-chip vp-yes":"vp-chip vp-no")%>'>
                                <asp:Label ID="Label9" runat="server" Text='<%#(Convert.ToInt32(Eval("Verified"))==1?"Yes":"No")%>'></asp:Label></span></td>
                        <td>
                            <span class='<%#(Convert.ToInt32(Eval("IsActive"))==1?"vp-chip vp-yes":"vp-chip vp-no")%>'>
                                <asp:Label ID="Label4" runat="server" Text='<%#(Convert.ToInt32(Eval("IsActive"))==1?"Yes":"No")%>'></asp:Label></span></td>
                        <td class="vp-actions hid">
                            <asp:LinkButton ID="editImageButton" class="btn btn-default btn-sm" runat="server" CommandName="edit" CausesValidation="false"
                                ToolTip="Edit" Visible='<%#(Convert.ToInt32(Eval("Verified"))==1?false:true)%>'><span class="glyphicon glyphicon-pencil"></span> Edit</asp:LinkButton>

                            <asp:LinkButton Visible='<%#(Convert.ToInt32(Eval("Verified"))==1?false:true)%>' ID="DetailsBtn" class="btn btn-default btn-sm" runat="server" OnClick="DetailsBtn_Click" CommandArgument='<%#Eval("PassId")%>' CausesValidation="false"
                                ToolTip="Visitors"><span class="glyphicon glyphicon-user"></span> Visitors</asp:LinkButton>
                            <asp:HyperLink ID="CopyLink" class="btn btn-default btn-sm" runat="server" NavigateUrl='<%#"~/NewVisitorpPass.aspx?CopyFrom=" + Eval("PassId")%>'
                                ToolTip="Create a new pass with the same details and visitors"><span class="glyphicon glyphicon-duplicate"></span> Copy</asp:HyperLink>
                            <asp:HyperLink ID="Print" Target="_blank" class="btn btn-custom btn-sm" runat="server" NavigateUrl='<%#"~/PrintPass.aspx?Id=" + Eval("PassId")%>'
                                ToolTip="Print pass"><span class="glyphicon glyphicon-print"></span> Print</asp:HyperLink>
                        </td>
                    </tr>
                </ItemTemplate>

                <EditItemTemplate>
                    <tr class="vp-editrow">
                        <td colspan="11">
                            <asp:HiddenField ID="HidPassId" runat="server" Value='<%#Bind("PassId")%>' />
                            <asp:HiddenField ID="HidPassTypeId" runat="server" Value='<%#Bind("PassTypes.PassTypeId")%>' />
                            <asp:HiddenField ID="HiIsActive" runat="server" Value='<%#Bind("IsActive")%>' />
                            <asp:HiddenField ID="HidBranchId" runat="server" Value='<%#Bind("BranchId")%>' />
                            <div class="vp-form">
                                <h5>EDIT PASS <%#Eval("PassCode")%></h5>
                                <div class="row">
                                    <div class="col-md-3 col-sm-6">
                                        <label class="lbl">Pass Date</label>
                                        <asp:TextBox ID="PassDateTxt" class="form-control js-date" runat="server" Text='<%#Convert.ToDateTime(Eval("PassDate")).ToString("dd/MM/yyyy")%>'></asp:TextBox>
                                        <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator6" CssClass="nf-err" runat="server" ErrorMessage="Enter pass date" ControlToValidate="PassDateTxt" ValidationGroup="Group1"></asp:RequiredFieldValidator>
                                    </div>
                                    <div class="col-md-3 col-sm-6">
                                        <label class="lbl">Branch</label>
                                        <asp:DropDownList ID="BranchDDL" runat="server" class="form-control">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator Display="Dynamic" InitialValue="0" ID="RequiredFieldValidator5" CssClass="nf-err" runat="server" ErrorMessage="Select branch" ControlToValidate="BranchDDL" ValidationGroup="Group1"></asp:RequiredFieldValidator>
                                    </div>
                                    <div class="col-md-3 col-sm-6">
                                        <label class="lbl">Pass Type</label>
                                        <asp:DropDownList ID="PassTypeDDL" runat="server" class="form-control">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator Display="Dynamic" InitialValue="0" ID="RequiredFieldValidator4" CssClass="nf-err" runat="server" ErrorMessage="Select pass type" ControlToValidate="PassTypeDDL" ValidationGroup="Group1"></asp:RequiredFieldValidator>
                                    </div>
                                    <div class="col-md-3 col-sm-6">
                                        <label class="lbl">Company Name</label>
                                        <asp:TextBox ID="CompanyNameTxt" ClientIDMode="Static" class="form-control" runat="server" Text='<%#Bind("Company.CompanyName")%>'></asp:TextBox>
                                        <asp:HiddenField ID="HidCompanyId" runat="server" Value='<%#Bind("CompanyId")%>' />
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-3 col-sm-6">
                                        <label class="lbl">From Date</label>
                                        <asp:TextBox ID="FromDateTxt" class="form-control js-date" runat="server" Text='<%#Convert.ToDateTime(Eval("FromDate")).ToString("dd/MM/yyyy")%>'></asp:TextBox>
                                        <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator7" CssClass="nf-err" runat="server" ErrorMessage="Enter from date" ControlToValidate="FromDateTxt" ValidationGroup="Group1"></asp:RequiredFieldValidator>
                                    </div>
                                    <div class="col-md-3 col-sm-6">
                                        <label class="lbl">To Date</label>
                                        <asp:TextBox ID="ToDateTxt" class="form-control js-date" runat="server" Text='<%#Convert.ToDateTime(Eval("ToDate")).ToString("dd/MM/yyyy")%>'></asp:TextBox>
                                        <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator3" CssClass="nf-err" runat="server" ErrorMessage="Enter to date" ControlToValidate="ToDateTxt" ValidationGroup="Group1"></asp:RequiredFieldValidator>
                                    </div>
                                    <div class="col-md-3 col-sm-6">
                                        <label class="lbl">Allow Off Days</label>
                                        <div class="vp-check">
                                            <asp:CheckBox ID="SaturdayCB" Text="Saturday" runat="server" Checked='<%#(Convert.ToInt32(Eval("Saturday"))==1)?true:false %>' />
                                            <asp:CheckBox ID="SundayCB" Text="Sunday" runat="server" Checked='<%#(Convert.ToInt32(Eval("Sunday"))==1)?true:false %>' />
                                        </div>
                                    </div>
                                    <div class="col-md-3 col-sm-6">
                                        <label class="lbl">Active</label>
                                        <asp:DropDownList ID="IsActiveDDL" runat="server" class="form-control">
                                            <asp:ListItem Value="1">Yes</asp:ListItem>
                                            <asp:ListItem Value="0">No</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-6">
                                        <label class="lbl">Visit Purpose</label>
                                        <asp:TextBox ID="VisitPurposeTxt" TextMode="MultiLine" Rows="3" class="form-control" runat="server" Text='<%#Bind("VisitPurpose")%>'></asp:TextBox>
                                        <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator2" CssClass="nf-err" runat="server" ErrorMessage="Enter visit purpose" ControlToValidate="VisitPurposeTxt" ValidationGroup="Group1"></asp:RequiredFieldValidator>
                                    </div>
                                    <div class="col-md-6">
                                        <label class="lbl">Remarks</label>
                                        <asp:TextBox ID="RemarksTxt" TextMode="MultiLine" Rows="3" class="form-control" runat="server" Text='<%#Bind("Remarks")%>'></asp:TextBox>
                                    </div>
                                </div>
                                <div class="vp-buttons">
                                    <asp:LinkButton class="btn btn-custom" ID="saveImageButton" runat="server" CommandName="update"
                                        ToolTip="Save" ValidationGroup="Group1"><span class="glyphicon glyphicon-floppy-disk"></span> Save</asp:LinkButton>
                                    <asp:LinkButton ID="cancelImageButton" class="btn btn-default" runat="server" CommandName="cancel" CausesValidation="false"
                                        ToolTip="Cancel"><span class="glyphicon glyphicon-remove"></span> Cancel</asp:LinkButton>
                                </div>
                            </div>
                        </td>
                    </tr>
                </EditItemTemplate>
                <EmptyDataTemplate>
                    <tr>
                        <td colspan="11" style="text-align: center; padding: 28px; color: #6b7280">No passes found.</td>
                    </tr>
                </EmptyDataTemplate>
            </asp:ListView>

        </tbody>
    </table>
    </asp:Panel>

    <script src="scripts/JQuery-ui-1.13.2.js"></script>

    <script>
        $(function () {
            // calendars on the pass, from and to dates of the edit form
            $("[id$=PassDateTxt], [id$=FromDateTxt], [id$=ToDateTxt]").each(function () {
                $(this).attr("autocomplete", "off").attr("placeholder", "dd/mm/yyyy");
            }).datepicker({ dateFormat: "dd/mm/yy", changeMonth: true, changeYear: true, showAnim: "fadeIn" });
            var $from = $("[id$=FromDateTxt]"), $to = $("[id$=ToDateTxt]");
            if ($from.length && $to.length) {
                $from.datepicker("option", "onClose", function (v) { $to.datepicker("option", "minDate", v || null); });
                $to.datepicker("option", "onClose", function (v) { $from.datepicker("option", "maxDate", v || null); });
                if ($from.val()) { $to.datepicker("option", "minDate", $from.val()); }
                if ($to.val()) { $from.datepicker("option", "maxDate", $to.val()); }
            }
        });

        $(function () {
            $("[id$=CompanyNameTxt]").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: '<%=ResolveUrl("~/WebService1.asmx/GetCompanies") %>',
                        data: JSON.stringify({ prefix: request.term }),
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        success: function (data) {
                            response($.map(data.d, function (item) {
                                return {
                                    label: item.split('=')[1],
                                    val: item.split('=')[0]
                                }
                            }))
                        },
                        error: function (response) {
                            alert(response.responseText);
                        }
                    });
                },
                select: function (e, i) {
                    $("[id$=HidCompanyId]").val(i.item.val);
                },
                minLength: 1
            });
        });
    </script>
    <script src='<%= ResolveUrl("~/Scripts/hrmprint.js") %>' type="text/javascript"></script>
    <script type="text/javascript">
        function PrintPanel() {
            return HRMPrint.print("<%= pnlContents.ClientID %>", { title: "MY VISITOR PASSES" });
        }
        function ExportPdf() {
            return HRMPrint.exportPdf("<%= pnlContents.ClientID %>", { title: "MY VISITOR PASSES", fileName: "Visitor Passes" });
        }
    </script>
</asp:Content>
