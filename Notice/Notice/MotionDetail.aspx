<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" ValidateRequest="false" AutoEventWireup="true" CodeBehind="MotionDetail.aspx.cs" Inherits="QuestionManagement.MotionDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <script src="summernote/summernote.js"></script>
    <link href="Summernote/summernote.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">

    <div class="nf-head">
        <h4><span class="glyphicon glyphicon-file"></span> MOTION DETAILS</h4>
    </div>

    <asp:ValidationSummary ID="ValidationSummary3" DisplayMode="BulletList" CssClass="alert alert-danger"
        EnableClientScript="true"
        HeaderText="You must enter a value in the following fields:" ValidationGroup="SaveGroup" runat="server" />

    <div class="panel panel-default nf-card">
        <div class="panel-heading"><span class="glyphicon glyphicon-list-alt"></span> NOTICE DETAILS</div>
        <div class="panel-body">
            <div class="row">
                <div class="col-md-2 col-sm-6">
                    <label class="control-lbl-sm" for="SessionDDL">Session No</label>
                    <asp:DropDownList ID="SessionDDL" class="form-control control-txt" runat="server" ValidationGroup="Group1">
                    </asp:DropDownList>
                </div>
                <div class="col-md-3 col-sm-6">
                    <label class="control-lbl-sm" for="MotionTypeDDL">Motion Type</label>
                    <asp:DropDownList ID="MotionTypeDDL" class="form-control control-txt" runat="server" ValidationGroup="Group1">
                        <asp:ListItem Value="0">Select</asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="rfvCategoryDDL" runat="server" ErrorMessage="Select Category" ValidationGroup="SaveGroup" Display="None" InitialValue="0" ControlToValidate="MotionTypeDDL"></asp:RequiredFieldValidator>
                </div>
                <div class="col-md-2 col-sm-6">
                    <label class="control-lbl-sm" for="NoticeDiaryNoTxt">Notice Office Diary No</label>
                    <asp:TextBox Type="Number" ID="NoticeDiaryNoTxt" ReadOnly="true" class="form-control control-txt" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvNoticeDiaryNoTxt" runat="server" ErrorMessage="Enter Notice Diary No." ValidationGroup="SaveGroup" Display="None" ControlToValidate="NoticeDiaryNoTxt"></asp:RequiredFieldValidator>
                </div>
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
        <div class="panel-heading"><span class="glyphicon glyphicon-user"></span> MOTION MOVERS</div>
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
                <div class="col-md-3 col-sm-6">
                    <label class="control-lbl-sm">Current File</label>
                    <asp:HyperLink ID="HyperLink1" Target="_blank" runat="server" CssClass="btn btn-warning"></asp:HyperLink>
                    <asp:HiddenField ID="HidMotionFile" runat="server" />
                </div>
                <div class="col-md-6 col-sm-6">
                    <label class="control-lbl-sm" for="FileUpload1">Change File</label>
                    <asp:FileUpload ID="FileUpload1" runat="server" data-scan="true" />
                </div>
            </div>
        </div>
    </div>

    <div class="panel panel-default nf-card nf-editor">
        <div class="panel-heading"><span class="glyphicon glyphicon-align-left"></span> MOTION TEXT</div>
        <div class="panel-body">
            <div class="row">
                <div class="col-md-12">
                    <label class="control-lbl-sm">English Text</label>
                    <textarea id="MotionTxt" name="MotionTxt" style="height: 300px" class="form-control" validationgroup="SaveGroup" rows="10" runat="server"></textarea>
                    <asp:RequiredFieldValidator ID="rfvQuestionTxt" runat="server" ErrorMessage="Enter Motion Text" ValidationGroup="SaveGroup" Display="None" ControlToValidate="MotionTxt"></asp:RequiredFieldValidator>
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
        <asp:Button ID="Button1" runat="server" Text="Save" ValidationGroup="SaveGroup" OnClick="Button1_Click" CssClass="btn btn-custom" />
        <asp:HyperLink ID="PrintHL" runat="server" Target="_blank" Text="Print" CssClass="btn btn-default" />
    </div>

    <script type="text/javascript">
        $(document).ready(function () {
            $('#<%= MotionTxt.ClientID %>').summernote({ height: 300 });
            $('#<%= UrduTxt.ClientID %>').summernote({ height: 300 });
        });

        // Ctrl+S submits the motion
        $(document).bind('keydown', function (e) {
            if (e.ctrlKey && (e.which == 83)) {
                e.preventDefault();
                document.getElementById('<%= Button1.ClientID %>').click();
                return false;
            }
        });
    </script>

</asp:Content>
