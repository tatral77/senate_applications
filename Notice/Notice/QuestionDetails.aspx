<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" ValidateRequest="false" AutoEventWireup="true" CodeBehind="QuestionDetails.aspx.cs" Inherits="Notice.QuestionDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <script src="summernote/summernote.js"></script>
    <link href="Summernote/summernote.css" rel="stylesheet" />
    <style>
        .ui-autocomplete { z-index: 2000 !important; max-height: 260px; overflow-y: auto; overflow-x: hidden; }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">

    <div class="nf-head">
        <h4><span class="glyphicon glyphicon-question-sign"></span> QUESTION DETAILS</h4>
    </div>

    <asp:Label ID="errorlbl" runat="server" Text="" CssClass="nf-err"></asp:Label>
    <asp:ValidationSummary ID="ValidationSummary3" DisplayMode="BulletList" CssClass="alert alert-danger"
        EnableClientScript="true"
        HeaderText="You must enter a value in the following fields:" ValidationGroup="UpdateGroup" runat="server" />

    <div class="panel panel-default nf-card">
        <div class="panel-heading"><span class="glyphicon glyphicon-list-alt"></span> NOTICE DETAILS</div>
        <div class="panel-body">
            <div class="row">
                <div class="col-md-2 col-sm-6">
                    <label class="control-lbl-sm" for="SessionTxt">Session No</label>
                    <asp:TextBox ReadOnly="true" ID="SessionTxt" class="form-control small-control" runat="server"></asp:TextBox>
                    <asp:HiddenField ID="HidSessionNumber" runat="server" />
                </div>
                <div class="col-md-2 col-sm-6">
                    <label class="control-lbl-sm" for="QuestionIDTxt">Question ID</label>
                    <asp:TextBox ID="QuestionIDTxt" ReadOnly="true" class="form-control small-control" runat="server"></asp:TextBox>
                </div>
                <div class="col-md-2 col-sm-6">
                    <label class="control-lbl-sm" for="NoticeDiaryNoTxt">Notice Office Diary No</label>
                    <asp:TextBox Type="Number" ID="NoticeDiaryNoTxt" ValidationGroup="Group1" Required="true" class="form-control small-control" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvNoticeDiaryNoTxt" runat="server" ErrorMessage="Enter Office Diary No." ValidationGroup="UpdateGroup" Display="None" ControlToValidate="NoticeDiaryNoTxt"></asp:RequiredFieldValidator>
                </div>
                <div class="col-md-3 col-sm-6">
                    <label class="control-lbl-sm" for="NoticeDiaryDateTxt">Notice Office Diary Date</label>
                    <asp:TextBox ID="NoticeDiaryDateTxt" ValidationGroup="Group1" Required="true" class="form-control small-control" data-max-date="0" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvNoticeDiaryDateTxt" runat="server" ErrorMessage="Enter Office Diary Date" ValidationGroup="UpdateGroup" Display="None" ControlToValidate="NoticeDiaryDateTxt"></asp:RequiredFieldValidator>
                </div>
                <div class="col-md-3 col-sm-6">
                    <label class="control-lbl-sm" for="NoticeDiaryTimeTxt">Notice Office Diary Time</label>
                    <asp:TextBox ID="NoticeDiaryTimeTxt" ValidationGroup="Group1" type="time" Required="true" class="form-control small-control" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvNoticeDiaryTimeTxt" runat="server" ErrorMessage="Enter Office Diary Time" ValidationGroup="UpdateGroup" Display="None" ControlToValidate="NoticeDiaryTimeTxt"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="row">
                <div class="col-md-4 col-sm-6">
                    <label class="control-lbl-sm" for="CategoryDDL">Category</label>
                    <asp:DropDownList ID="CategoryDDL" class="form-control small-control" runat="server" ValidationGroup="Group1" OnSelectedIndexChanged="CategoryDDL_SelectedIndexChanged" AutoPostBack="true">
                        <asp:ListItem Value="0">Select</asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="rfvCategoryDDL" runat="server" ErrorMessage="Select Category" ValidationGroup="UpdateGroup" Display="None" InitialValue="0" ControlToValidate="CategoryDDL"></asp:RequiredFieldValidator>
                </div>
                <div class="col-md-5 col-sm-6">
                    <label class="control-lbl-sm" for="MemberNameTxt">Senator</label>
                    <asp:TextBox ID="MemberNameTxt" Required="true" runat="server" CssClass="form-control small-control" autocomplete="off" />
                    <asp:RequiredFieldValidator ID="rfvMemberNameTxt" runat="server" ErrorMessage="Enter member Name" ValidationGroup="UpdateGroup" Display="None" ControlToValidate="MemberNameTxt"></asp:RequiredFieldValidator>
                    <asp:HiddenField ID="HidMemberId" runat="server" />
                    <asp:HiddenField ID="HidCurrentMemberId" runat="server" />
                </div>
            </div>
            <asp:Label ID="Error" runat="server" CssClass="nf-err"></asp:Label>
        </div>
    </div>

    <div class="panel panel-default nf-card">
        <div class="panel-heading"><span class="glyphicon glyphicon-paperclip"></span> ATTACHMENT</div>
        <div class="panel-body">
            <div class="row">
                <div class="col-md-3 col-sm-6">
                    <label class="control-lbl-sm">Current File</label>
                    <asp:HyperLink ID="HyperLink1" Target="_blank" runat="server" CssClass="btn btn-warning"></asp:HyperLink>
                </div>
                <div class="col-md-6 col-sm-6">
                    <label class="control-lbl-sm" for="FileUpload1">Change File</label>
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
                    <asp:RequiredFieldValidator ID="rfvQTxt" runat="server" ErrorMessage="Enter Question Text" ValidationGroup="UpdateGroup" Display="None" ControlToValidate="QTxt"></asp:RequiredFieldValidator>
                    <textarea id="QTxt" name="QTxt" style="height: 300px" class="form-control" rows="10" runat="server" required="required"></textarea>
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
        <asp:Button ID="UpdateQuestionBtn" runat="server" Text="Update" OnClick="UpdateQuestionBtn_Click" ValidationGroup="UpdateGroup" CssClass="btn btn-custom" />
        <asp:Button ID="DeleteBtn" OnClientClick="return confirm('Are you sure you want to delete record ?');" runat="server" Text="Delete" OnClick="DeleteBtn_Click" CausesValidation="false" CssClass="btn btn-danger" />
    </div>

    <div class="row">
        <div class="col-md-6">
            <div class="panel panel-default nf-card">
                <div class="panel-heading"><span class="glyphicon glyphicon-time"></span> STATUS HISTORY</div>
                <div class="panel-body" style="padding-bottom: 0">
                    <table class="table table-hover table-striped table-responsive">
                        <thead class="thead-inverse">
                            <tr>
                        <th>Sr#</th>
                        <th>Session No</th>
                        <th>Question Status</th>
                        <th>Status Date</th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:ListView ID="LVStatus" runat="server">
                                <ItemTemplate>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label3" class="table-data" runat="server" Text='<%#Container.DataItemIndex + 1%> ' />
                                        </td>
                                        <td>
                                            <asp:Label ID="Label1" class="table-data" runat="server" Text='<%#Bind("AssemblySession")%>' />
                                        </td>
                                        <td>
                                            <asp:Label ID="Label4" class="table-data" runat="server" Text='<%#Bind("QuestionStatus")%>' />
                                        </td>
                                        <td>
                                            <asp:Label ID="Label6" class="table-data" runat="server" Text='<%#GetDate(Convert.ToDateTime(Eval("StatusDate")))%>' />
                                        </td>
                                    </tr>
                                </ItemTemplate>
                            </asp:ListView>
                        </tbody>
                    </table>
                </div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="panel panel-default nf-card">
                <div class="panel-heading"><span class="glyphicon glyphicon-time"></span> MOVEMENT HISTORY</div>
                <div class="panel-body" style="padding-bottom: 0">
                    <table class="table table-hover table-striped table-responsive">
                        <thead class="thead-inverse">
                            <tr>
                        <th>Sr#</th>
                        <th>From Session Number</th>
                        <th>To Session Number</th>
                        <th>Movement Date</th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:ListView ID="LVMovement" runat="server">
                                <ItemTemplate>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label3" class="table-data" runat="server" Text='<%#Container.DataItemIndex + 1%> ' />
                                        </td>
                                        <td>
                                            <asp:Label ID="Label6" class="table-data" runat="server" Text='<%#GetSession(Convert.ToInt32(Eval("FromAssemblySession")))%>' />
                                        </td>
                                        <td>
                                            <asp:Label ID="Label2" class="table-data" runat="server" Text='<%#GetSession(Convert.ToInt32(Eval("ToAssemblySession")))%>' />
                                        </td>
                                        <td>
                                            <asp:Label ID="Label1" class="table-data" runat="server" Text='<%#GetDate(Convert.ToDateTime(Eval("MovementDate")))%>' />
                                        </td>
                                    </tr>
                                </ItemTemplate>
                            </asp:ListView>
                        </tbody>
                    </table>
                </div>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-md-6">
            <div class="panel panel-default nf-card">
                <div class="panel-heading"><span class="glyphicon glyphicon-time"></span> DEFER HISTORY</div>
                <div class="panel-body" style="padding-bottom: 0">
                    <table class="table table-hover table-striped table-responsive">
                        <thead class="thead-inverse">
                            <tr>
                        <th>Sr#</th>
                        <th>Defered to Session No</th>
                        <th>Defered on</th>
                        <th>Action</th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:ListView ID="DeferLv" runat="server">
                                <ItemTemplate>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label3" class="table-data" runat="server" Text='<%#Container.DataItemIndex + 1%> ' />
                                            <asp:HiddenField ID="HidDeferId" runat="server" Value='<%#Eval("DeferId")%>' />
                                        </td>
                                        <td>
                                            <asp:Label ID="Label1" class="table-data" runat="server" Text='<%#GetSession(Convert.ToInt32(Eval("AssemblySessionId")))%>' />
                                        </td>
                                        <td>
                                            <asp:Label ID="Label6" class="table-data" runat="server" Text='<%#GetDate(Convert.ToDateTime(Eval("DeferDate")))%>' />
                                        </td>
                                        <td>
                                            <asp:LinkButton ID="deleteImageButton" Cssclass="btn btn-custom" runat="server" CommandName="delete"
                                            ToolTip="Delete" OnClientClick="return confirm('Are you sure you want to delete record ?');"><span class="glyphicon glyphicon-erase"></span></asp:LinkButton>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                            </asp:ListView>
                        </tbody>
                    </table>
                </div>
            </div>
        </div>
    </div>

    <script type="text/javascript">
        $(document).ready(function () {
            $('#<%= QTxt.ClientID %>').summernote({ height: 300 });
            $('#<%= UrduTxt.ClientID %>').summernote({ height: 300 });
        });

        // the senator must be picked from the list: typing again clears the previous pick
        $(function () {
            var $name = $('#<%= MemberNameTxt.ClientID %>'), $id = $('#<%= HidMemberId.ClientID %>');
            $name.autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: '<%=ResolveUrl("~/Service.asmx/GetEmployeeName") %>',
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

        // Ctrl+S updates the question
        $(document).bind('keydown', function (e) {
            if (e.ctrlKey && (e.which == 83)) {
                e.preventDefault();
                document.getElementById('<%= UpdateQuestionBtn.ClientID %>').click();
                return false;
            }
        });
    </script>
</asp:Content>
