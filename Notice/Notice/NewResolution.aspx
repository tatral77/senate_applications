<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" ValidateRequest="false" AutoEventWireup="true" CodeBehind="NewResolution.aspx.cs" Inherits="Notice.NewResolution" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <script src="summernote/summernote.js"></script>
    <link href="Summernote/summernote.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">

    <div class="nf-head">
        <h4><span class="glyphicon glyphicon-file"></span> NEW RESOLUTION</h4>
        <asp:Button ID="AddNewBtn" runat="server" Text="Add New" CssClass="btn btn-default" OnClick="AddNewBtn_Click" CausesValidation="false" />
    </div>

    <asp:ValidationSummary ID="ValidationSummary3" DisplayMode="BulletList" CssClass="alert alert-danger"
        EnableClientScript="true"
        HeaderText="You must enter a value in the following fields:" ValidationGroup="SaveGroup" runat="server" />

    <div class="panel panel-default nf-card">
        <div class="panel-heading"><span class="glyphicon glyphicon-list-alt"></span> NOTICE DETAILS</div>
        <div class="panel-body">
            <div class="row">
                <div class="col-md-2 col-sm-6">
                    <label class="control-lbl-sm" for="SessionTxt">Session No</label>
                    <asp:TextBox ReadOnly="true" ID="SessionTxt" class="form-control control-txt" runat="server"></asp:TextBox>
                    <asp:HiddenField ID="HidSessionNumber" runat="server" />
                </div>
                <div class="col-md-3 col-sm-6">
                    <label class="control-lbl-sm" for="ResolutionTypeDDL">Resolution Type</label>
                    <asp:DropDownList ID="ResolutionTypeDDL" class="form-control control-txt" runat="server" ValidationGroup="Group1">
                        <asp:ListItem Value="0">Select</asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="rfvCategoryDDL" runat="server" ErrorMessage="Select Category" ValidationGroup="SaveGroup" Display="None" InitialValue="0" ControlToValidate="ResolutionTypeDDL"></asp:RequiredFieldValidator>
                </div>
                <div class="col-md-2 col-sm-6">
                    <label class="control-lbl-sm" for="NoticeDiaryNoTxt">Notice Diary No</label>
                    <asp:TextBox Type="Number" ID="NoticeDiaryNoTxt" ReadOnly="true" ValidationGroup="Group1" class="form-control control-txt" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvNoticeDiaryNoTxt" runat="server" ErrorMessage="Enter Notice Diary No." ValidationGroup="SaveGroup" Display="None" ControlToValidate="NoticeDiaryNoTxt"></asp:RequiredFieldValidator>
                </div>
                <div class="col-md-2 col-sm-6">
                    <label class="control-lbl-sm" for="FileNoTxt">File No</label>
                    <asp:TextBox ID="FileNoTxt" class="form-control control-txt" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Enter File No." ValidationGroup="SaveGroup" Display="None" ControlToValidate="FileNoTxt"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="row">
                <div class="col-md-3 col-sm-6">
                    <label class="control-lbl-sm" for="NoticeDiaryDateTxt">Notice Office Diary Date</label>
                    <asp:TextBox ID="NoticeDiaryDateTxt" ValidationGroup="Group1" class="form-control control-txt" data-max-date="0" runat="server"></asp:TextBox>
                    <asp:Label ID="DateError" runat="server" CssClass="nf-err" Text=""></asp:Label>
                    <asp:RequiredFieldValidator ID="rfvNoticeDiaryDateTxt" runat="server" ErrorMessage="Enter Office Diary Date" ValidationGroup="SaveGroup" Display="None" ControlToValidate="NoticeDiaryDateTxt"></asp:RequiredFieldValidator>
                </div>
                <div class="col-md-2 col-sm-6">
                    <label class="control-lbl-sm" for="NoticeDiaryTimeTxt">Notice Office Diary Time</label>
                    <asp:TextBox ID="NoticeDiaryTimeTxt" ValidationGroup="Group1" Type="time" class="form-control control-txt" runat="server"></asp:TextBox>
                    <asp:Label ID="Label1" runat="server" CssClass="nf-err" Text=""></asp:Label>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Enter Office Diary Time" ValidationGroup="SaveGroup" Display="None" ControlToValidate="NoticeDiaryTimeTxt"></asp:RequiredFieldValidator>
                </div>
            </div>
        </div>
    </div>

    <div class="panel panel-default nf-card">
        <div class="panel-heading"><span class="glyphicon glyphicon-user"></span> RESOLUTION MOVERS</div>
        <div class="panel-body">
            <div class="row">
                <div class="col-md-8">
                    <label class="control-lbl-sm" for="memberSearch">Movers (type a name and pick as many members as needed)</label>
                    <div class="form-control member-multi" data-chips data-service="<%= ResolveUrl("~/service.asmx/GetEmployeeName") %>" data-ids="#<%= HidMemberId.ClientID %>" data-names="#<%= MemberNameTxt.ClientID %>" data-placeholder="Type a member name to add...">
                        <span class="member-chips"></span>
                        <input type="text" class="member-input" autocomplete="off" />
                    </div>
                    <asp:TextBox ID="MemberNameTxt" runat="server" Style="display: none" />
                    <asp:HiddenField ID="HidMemberId" runat="server" />
                    <asp:Label ID="err" runat="server" CssClass="nf-err" Text=""></asp:Label>
                </div>
            </div>
        </div>
    </div>

    <div class="panel panel-default nf-card">
        <div class="panel-heading"><span class="glyphicon glyphicon-paperclip"></span> ATTACHMENT</div>
        <div class="panel-body">
            <div class="row">
                <div class="col-md-6">
                    <label class="control-lbl-sm" for="FileUpload1">Attach Image or PDF File</label>
                    <asp:FileUpload ID="FileUpload1" runat="server" data-scan="true" />
                </div>
            </div>
        </div>
    </div>

    <div class="panel panel-default nf-card nf-editor">
        <div class="panel-heading"><span class="glyphicon glyphicon-align-left"></span> RESOLUTION TEXT</div>
        <div class="panel-body">
            <div class="row">
                <div class="col-md-12">
                    <label class="control-lbl-sm">English Text</label>
                    <textarea id="ResolutionTxt" name="ResolutionTxt" style="height: 300px" class="form-control" validationgroup="SaveGroup" rows="10" runat="server"></textarea>
                    <asp:RequiredFieldValidator ID="rfvQuestionTxt" runat="server" ErrorMessage="Enter Resolution Text" ValidationGroup="SaveGroup" Display="None" ControlToValidate="ResolutionTxt"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="row">
                <div class="col-md-12">
                    <label class="control-lbl-sm">Urdu Text</label>
                    <textarea id="UrduTxt" name="QuestionTxt" style="height: 300px" class="form-control" rows="10" runat="server"></textarea>
                </div>
            </div>
        </div>
    </div>

    <div class="nf-submit">
        <asp:Button ID="Button2" runat="server" Text="Submit" OnClick="Button1_Click" ValidationGroup="SaveGroup" CssClass="btn btn-custom" />
    </div>

    <script type="text/javascript">
        $(document).ready(function () {
            $('#<%= ResolutionTxt.ClientID %>').summernote({ height: 300 });
            $('#<%= UrduTxt.ClientID %>').summernote({ height: 300 });
        });

        // Ctrl+S submits the resolution
        $(document).bind('keydown', function (e) {
            if (e.ctrlKey && (e.which == 83)) {
                e.preventDefault();
                document.getElementById('<%= Button2.ClientID %>').click();
                return false;
            }
        });
    </script>

</asp:Content>
