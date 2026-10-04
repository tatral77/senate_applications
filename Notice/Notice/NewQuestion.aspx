<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" ValidateRequest="false" AutoEventWireup="true" CodeBehind="NewQuestion.aspx.cs" Inherits="Notice.NewQuestion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <script src="summernote/summernote.js"></script>
    <script src="Summernote/plugin/rtl.js"></script>
    <link href="Summernote/summernote.css" rel="stylesheet" />
    <script src="Scripts/jquery.mask.js"></script>
    <style>
        .ui-autocomplete { z-index: 2000 !important; max-height: 260px; overflow-y: auto; overflow-x: hidden; }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">

    <div class="nf-head">
        <h4><span class="glyphicon glyphicon-question-sign"></span> NEW QUESTION</h4>
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
                    <asp:TextBox ReadOnly="true" ID="SessionTxt" class="form-control small-control" runat="server"></asp:TextBox>
                    <asp:HiddenField ID="HidSessionNumber" runat="server" />
                </div>
                <div class="col-md-3 col-sm-6">
                    <label class="control-lbl-sm" for="CategoryDDL">Category</label>
                    <asp:DropDownList ID="CategoryDDL" class="form-control small-control" runat="server" ValidationGroup="Group1">
                        <asp:ListItem Value="0">Select</asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="rfvCategoryDDL" runat="server" ErrorMessage="Select Category" ValidationGroup="SaveGroup" Display="None" InitialValue="0" ControlToValidate="CategoryDDL"></asp:RequiredFieldValidator>
                </div>
                <div class="col-md-2 col-sm-6">
                    <label class="control-lbl-sm" for="NoticeDiaryNoTxt">Notice Office Diary No</label>
                    <asp:TextBox Type="Number" ID="NoticeDiaryNoTxt" ValidationGroup="Group1" ReadOnly="true" Required="true" class="form-control small-control" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvNoticeDiaryNoTxt" runat="server" ErrorMessage="Enter Notice Diary No." ValidationGroup="SaveGroup" Display="None" ControlToValidate="NoticeDiaryNoTxt"></asp:RequiredFieldValidator>
                </div>
                <div class="col-md-3 col-sm-6">
                    <label class="control-lbl-sm" for="NoticeDiaryDateTxt">Notice Office Diary Date</label>
                    <asp:TextBox ID="NoticeDiaryDateTxt" ValidationGroup="Group1" Required="true" class="form-control small-control" data-max-date="0" data-min-date="-30" runat="server"></asp:TextBox>
                    <asp:Label ID="DateError" runat="server" CssClass="nf-err" Text=""></asp:Label>
                    <asp:RequiredFieldValidator ID="rfvNoticeDiaryDateTxt" runat="server" ErrorMessage="Enter Office Diary Date" ValidationGroup="SaveGroup" Display="None" ControlToValidate="NoticeDiaryDateTxt"></asp:RequiredFieldValidator>
                    <div class="nf-hint">Within the last 30 days.</div>
                </div>
                <div class="col-md-2 col-sm-6">
                    <label class="control-lbl-sm" for="NoticeDiaryTimeTxt">Notice Office Diary Time</label>
                    <asp:TextBox ID="NoticeDiaryTimeTxt" ValidationGroup="Group1" type="time" Required="true" class="form-control small-control" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvNoticeDiaryTimeTxt" runat="server" ErrorMessage="Enter Office Diary Time" ValidationGroup="SaveGroup" Display="None" ControlToValidate="NoticeDiaryTimeTxt"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="row">
                <div class="col-md-6">
                    <label class="control-lbl-sm" for="MemberNameTxt">Senator</label>
                    <asp:TextBox ID="MemberNameTxt" Required="true" runat="server" CssClass="form-control small-control" placeholder="Type a senator name and pick from the list" autocomplete="off" />
                    <asp:HiddenField ID="HidMemberId" runat="server" />
                    <asp:Label ID="SenatorError" runat="server" CssClass="nf-err" Text=""></asp:Label>
                    <asp:RequiredFieldValidator ID="rfvMemberNameTxt" runat="server" ErrorMessage="Enter Senator Name" ValidationGroup="SaveGroup" Display="None" ControlToValidate="MemberNameTxt"></asp:RequiredFieldValidator>
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
        <div class="panel-heading"><span class="glyphicon glyphicon-align-left"></span> QUESTION TEXT</div>
        <div class="panel-body">
            <div class="row">
                <div class="col-md-12">
                    <label class="control-lbl-sm">English Text</label>
                    <textarea id="QuestionTxt" name="QuestionTxt" style="height: 300px" class="form-control" validationgroup="SaveGroup" rows="10" runat="server"></textarea>
                </div>
            </div>
            <div class="row">
                <div class="col-md-12">
                    <label class="control-lbl-sm">Urdu Text</label>
                    <textarea id="UrduTxt" name="UrduTxt" style="height: 300px" class="form-control" rows="10" runat="server"></textarea>
                </div>
            </div>
        </div>
    </div>

    <div class="nf-submit">
        <asp:Button ID="Button1" runat="server" Text="Submit" ValidationGroup="SaveGroup" OnClick="Button1_Click" CssClass="btn btn-custom" />
    </div>

    <script type="text/javascript">
        $(document).ready(function () {
            $('#<%= QuestionTxt.ClientID %>').summernote({ height: 300 });
            $('#<%= UrduTxt.ClientID %>').summernote({ height: 300 });
        });

        // the senator must be picked from the list: typing again clears the previous pick
        $(function () {
            var $name = $('#<%= MemberNameTxt.ClientID %>'), $id = $('#<%= HidMemberId.ClientID %>');
            $name.autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: '<%=ResolveUrl("~/service.asmx/GetEmployeeName") %>',
                        data: JSON.stringify({ prefix: request.term }),
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        success: function (data) {
                            response($.map(data.d, function (item) {
                                return { label: item.split('=')[0], val: item.split('=')[1] };
                            }));
                        },
                        error: function (response) { alert(response.responseText); }
                    });
                },
                select: function (e, i) { $id.val(i.item.val); },
                minLength: 1
            });
            $name.on('input', function () { $id.val(''); });
        });

        // Ctrl+S submits the question
        $(document).bind('keydown', function (e) {
            if (e.ctrlKey && (e.which == 83)) {
                e.preventDefault();
                document.getElementById('<%= Button1.ClientID %>').click();
                return false;
            }
        });
    </script>

</asp:Content>
