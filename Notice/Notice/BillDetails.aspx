<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" ValidateRequest="false" AutoEventWireup="true" CodeBehind="BillDetails.aspx.cs" Inherits="Notice.BillDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <script src="summernote/summernote.js"></script>
    <script src="Summernote/plugin/rtl.js"></script>
    <link href="Summernote/summernote.css" rel="stylesheet" />
    <style>
        .ui-autocomplete { z-index: 2000 !important; max-height: 260px; overflow-y: auto; overflow-x: hidden; }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">

    <div class="nf-head">
        <h4><span class="glyphicon glyphicon-book"></span> BILL DETAILS</h4>
    </div>

    <asp:ValidationSummary ID="ValidationSummary3" DisplayMode="BulletList" CssClass="alert alert-danger"
        EnableClientScript="true"
        HeaderText="You must enter a value in the following fields:" ValidationGroup="SaveGroup" runat="server" />
    <asp:Label ID="Error" runat="server" CssClass="nf-err"></asp:Label>

    <div class="panel panel-default nf-card">
        <div class="panel-heading"><span class="glyphicon glyphicon-list-alt"></span> BILL DETAILS</div>
        <div class="panel-body">
            <div class="row">
                <div class="col-md-3 col-sm-6">
                    <label class="control-lbl-sm" for="ParliamentaryYearDDL">Parliamentary Year</label>
                    <asp:DropDownList ID="ParliamentaryYearDDL" class="form-control small-control" runat="server" ValidationGroup="Group1">
                    </asp:DropDownList>
                </div>
                <div class="col-md-3 col-sm-6">
                    <label class="control-lbl-sm" for="AssemblySessionDDL">Session</label>
                    <asp:DropDownList ID="AssemblySessionDDL" class="form-control small-control" runat="server" ValidationGroup="Group1">
                    </asp:DropDownList>
                </div>
                <div class="col-md-3 col-sm-6">
                    <label class="control-lbl-sm" for="FileNumberTxt">File Number</label>
                    <asp:TextBox ID="FileNumberTxt" ValidationGroup="Group1" class="form-control small-control" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvLegislationDiaryNoTxt" runat="server" ErrorMessage="Enter Legislation Diary No." ValidationGroup="SaveGroup" Display="None" ControlToValidate="FileNumberTxt"></asp:RequiredFieldValidator>
                </div>
                <div class="col-md-3 col-sm-6">
                    <label class="control-lbl-sm" for="NoticedateTxt">Notice Date</label>
                    <asp:TextBox ID="NoticedateTxt" ValidationGroup="Group1" class="form-control small-control" data-max-date="0" runat="server"></asp:TextBox>
                    <asp:Label ID="DateError" runat="server" CssClass="nf-err" Text=""></asp:Label>
                    <asp:RequiredFieldValidator ID="rfvLegislationDiaryDateTxt" runat="server" ErrorMessage="Enter Notice Date" ValidationGroup="SaveGroup" Display="None" ControlToValidate="NoticedateTxt"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="row">
                <div class="col-md-3 col-sm-6">
                    <label class="control-lbl-sm" for="BillCategoryDDL">Bill Category</label>
                    <asp:DropDownList ID="BillCategoryDDL" class="form-control small-control" runat="server" ValidationGroup="Group1">
                        <asp:ListItem Value="0">Select</asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="rfvCategoryDDL" runat="server" ErrorMessage="Select Category" ValidationGroup="SaveGroup" Display="None" InitialValue="0" ControlToValidate="BillCategoryDDL"></asp:RequiredFieldValidator>
                </div>
                <div class="col-md-3 col-sm-6">
                    <label class="control-lbl-sm" for="BillTypeDDL">Bill Type</label>
                    <asp:DropDownList ID="BillTypeDDL" class="form-control small-control" runat="server" ValidationGroup="Group1">
                        <asp:ListItem Value="0">Select</asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Select Bill Type" ValidationGroup="SaveGroup" Display="None" InitialValue="0" ControlToValidate="BillTypeDDL"></asp:RequiredFieldValidator>
                </div>
            </div>
        </div>
    </div>

    <div class="panel panel-default nf-card">
        <div class="panel-heading"><span class="glyphicon glyphicon-user"></span> MOVERS AND MINISTRIES</div>
        <div class="panel-body">
            <div class="row">
                <div class="col-md-6">
                    <label class="control-lbl-sm">Bill Movers (Senators)</label>
                    <div class="form-control member-multi" data-chips data-service="<%= ResolveUrl("~/Service.asmx/GetEmployeeName") %>" data-ids="#<%= HidMemberId.ClientID %>" data-names="#<%= MemberNameTxt.ClientID %>" data-placeholder="Type a senator name to add...">
                        <span class="member-chips"></span>
                        <input type="text" class="member-input" autocomplete="off" />
                    </div>
                    <asp:TextBox ID="MemberNameTxt" runat="server" Style="display: none" ClientIDMode="Static" />
                    <asp:HiddenField ID="HidMemberId" ClientIDMode="Static" runat="server" />
                    <asp:Label ID="err" runat="server" CssClass="nf-err" Text=""></asp:Label>
                </div>
                <div class="col-md-6">
                    <label class="control-lbl-sm">Bill Movers (MNA)</label>
                    <div class="form-control member-multi" data-chips data-service="<%= ResolveUrl("~/Service.asmx/GetMinisters") %>" data-ids="#<%= HidMinisterId.ClientID %>" data-names="#<%= MinisterNameTxt.ClientID %>" data-placeholder="Type an MNA name to add...">
                        <span class="member-chips"></span>
                        <input type="text" class="member-input" autocomplete="off" />
                    </div>
                    <asp:TextBox ID="MinisterNameTxt" runat="server" Style="display: none" ClientIDMode="Static" />
                    <asp:HiddenField ID="HidMinisterId" ClientIDMode="Static" runat="server" />
                    <asp:Label ID="MinisterErr" runat="server" CssClass="nf-err" Text=""></asp:Label>
                </div>
            </div>
            <div class="row">
                <div class="col-md-6">
                    <label class="control-lbl-sm">Ministries</label>
                    <div class="form-control member-multi" data-chips data-service="<%= ResolveUrl("~/Service.asmx/GetCurrentDivisionsByName") %>" data-ids="#<%= HidMinistryId.ClientID %>" data-names="#<%= MinistryTxt.ClientID %>" data-placeholder="Type a ministry name to add...">
                        <span class="member-chips"></span>
                        <input type="text" class="member-input" autocomplete="off" />
                    </div>
                    <asp:TextBox ID="MinistryTxt" runat="server" Style="display: none" />
                    <asp:HiddenField ID="HidMinistryId" runat="server" />
                    <asp:Label ID="err2" runat="server" CssClass="nf-err" Text=""></asp:Label>
                </div>
            </div>
        </div>
    </div>

    <div class="panel panel-default nf-card">
        <div class="panel-heading"><span class="glyphicon glyphicon-paperclip"></span> ATTACHMENTS</div>
        <div class="panel-body">
            <div class="row">
                <div class="col-md-6">
                    <label class="control-lbl-sm">Notice File</label>
                    <asp:HyperLink ID="HyperLink2" Target="_blank" runat="server" CssClass="btn btn-warning"></asp:HyperLink>
                    <label class="control-lbl-sm" for="FileUpload2" style="margin-top: 10px">Change Notice File</label>
                    <asp:FileUpload ID="FileUpload2" runat="server" data-scan="true" />
                </div>
                <div class="col-md-6">
                    <label class="control-lbl-sm">Bill File</label>
                    <asp:HyperLink ID="HyperLink1" Target="_blank" runat="server" CssClass="btn btn-warning"></asp:HyperLink>
                    <label class="control-lbl-sm" for="FileUpload1" style="margin-top: 10px">Change Bill File</label>
                    <asp:FileUpload ID="FileUpload1" runat="server" data-scan="true" />
                </div>
            </div>
        </div>
    </div>

    <div class="panel panel-default nf-card nf-editor">
        <div class="panel-heading"><span class="glyphicon glyphicon-align-left"></span> BILL TITLE AND TEXT</div>
        <div class="panel-body">
            <div class="row">
                <div class="col-md-12">
                    <label class="control-lbl-sm">Bill Title</label>
                    <textarea id="BillTitleTxt" name="BillTitleTxt" style="height: 70px" class="form-control" validationgroup="SaveGroup" rows="10" runat="server"></textarea>
                </div>
            </div>
            <div class="row">
                <div class="col-md-12">
                    <label class="control-lbl-sm">English Text</label>
                    <textarea id="SubjectTxt" name="BillTxt" style="height: 300px" class="form-control" validationgroup="SaveGroup" rows="10" runat="server"></textarea>
                    <asp:RequiredFieldValidator ID="rfvBillTxt" runat="server" ErrorMessage="Enter Bill Text" ValidationGroup="SaveGroup" Display="None" ControlToValidate="SubjectTxt"></asp:RequiredFieldValidator>
                </div>
            </div>
        </div>
    </div>

    <div class="nf-submit">
        <asp:Button ID="UpdateQuestionBtn" runat="server" Text="Update" OnClick="Button1_Click" ValidationGroup="SaveGroup" CssClass="btn btn-custom" />
        <asp:Button ID="DeleteBtn" OnClientClick="return confirm('Are you sure you want to delete record ?');" runat="server" Text="Delete" OnClick="DeleteBtn_Click" CausesValidation="false" CssClass="btn btn-danger" />
    </div>

    <script type="text/javascript">
        $(document).ready(function () {
            var tableOptions = function () {
                $(this).addClass('table table-bordered')
                    .attr('cellpadding', 12)
                    .attr('cellspacing', 0)
                    .attr('border', 1)
                    .css('borderCollapse', 'collapse');
                $(this).find('td')
                    .css('borderColor', '#000')
                    .css('padding', '5px');
            };
            $('#<%= BillTitleTxt.ClientID %>').summernote({ tableClassName: tableOptions, height: 120 });
            $('#<%= SubjectTxt.ClientID %>').summernote({ tableClassName: tableOptions, height: 300 });
        });

        // Ctrl+S updates the bill
        $(document).bind('keydown', function (e) {
            if (e.ctrlKey && (e.which == 83)) {
                e.preventDefault();
                document.getElementById('<%= UpdateQuestionBtn.ClientID %>').click();
                return false;
            }
        });
    </script>

</asp:Content>
