<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" EnableViewState="true" ValidateRequest="false" AutoEventWireup="true" CodeBehind="QuestionDetails.aspx.cs" Inherits="QuestionManagement.QuestionDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script src="Summernote/summernote-bs4.js"></script>
    <link href="Summernote/summernote-bs4.css" rel="stylesheet" />
    <script src="Summernote/summernote-lite.js"></script>
    <link href="Summernote/summernote.css" rel="stylesheet" />
    <script src="summernote/summernote.js"></script>
    <script src="Summernote/summernote-ext-print.js"></script>
    <link href="Styles/bootstrap-timepicker.min.css" rel="stylesheet" />
    <script src="Scripts/bootstrap-timepicker.min.js"></script>

    <style>
        .ui-autocomplete { position: relative; cursor: default; z-index: 2000 !important; }

        .qd-header { margin: 6px 0 18px; padding-bottom: 14px; border-bottom: 1px solid #e4e9ee; overflow: hidden; }
            .qd-header h3 { margin: 0 0 2px; font-size: 24px; font-weight: 600; color: #1f2d3d; }
            .qd-header p { margin: 0; font-size: 14px; color: #6b7785; }
            .qd-header .qd-actions { float: right; margin-top: 4px; }
            .qd-header .qd-actions .btn, .qd-header .qd-actions a.btn { margin-left: 6px; }

        .qd-card { background: #fff; border: 1px solid #e4e9ee; border-radius: 6px; box-shadow: 0 1px 4px rgba(0,0,0,.06); margin-bottom: 20px; }
        .qd-card-title { padding: 11px 18px; border-bottom: 1px solid #e4e9ee; background: #f8fafb; border-radius: 6px 6px 0 0; font-size: 12px; font-weight: 700; letter-spacing: .08em; text-transform: uppercase; color: #0c3a72; }
        .qd-card-body { padding: 16px 18px 6px; }
            .qd-card-body .form-group { margin-bottom: 14px; }
            .qd-card-body label { font-size: 13px; font-weight: 600; color: #3c4858; margin-bottom: 4px; }
            .qd-card-body .form-control[readonly] { background: #f3f6f8; }
        .qd-error { color: #c0392b; font-size: 13px; margin-bottom: 8px; }

        .qd-panel { display: none; }
            .qd-panel .qd-card-title { background: #fff8e6; color: #8a5a00; }

        .qd-check { display: block; padding-top: 6px; font-weight: normal !important; }
            .qd-check input { margin-right: 6px; }

        .qd-actionbar { position: sticky; bottom: 0; z-index: 40; display: flex; align-items: center; background: #fff; border: 1px solid #e4e9ee; border-radius: 6px; box-shadow: 0 -2px 10px rgba(0,0,0,.08); padding: 10px 16px; margin: 0 0 20px; }
            .qd-actionbar .qd-left .btn { margin-right: 6px; }
            .qd-actionbar .qd-hint { margin-left: 12px; font-size: 12px; color: #6b7785; }
            .qd-actionbar .qd-right { margin-left: auto; }

        .qd-table td, .qd-table th { font-size: 13px; }
        .qd-table th { color: #6b7785; font-weight: 600; }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    <div class="container">

        <%-- Revive panel (shown by the Revive button) --%>
        <div id="move" class="qd-card qd-panel">
            <div class="qd-card-title">Revive Question</div>
            <div class="qd-card-body">
                <asp:ValidationSummary ID="ValidationSummary1" DisplayMode="BulletList"
                    EnableClientScript="true" Style="color: red;"
                    HeaderText="You must enter a value in the following fields:" ValidationGroup="MoveGroup" runat="server" />
                <asp:UpdatePanel ID="upSetSession" runat="server">
                    <ContentTemplate>
                        <div class="row">
                            <div class="col-md-2 form-group">
                                <label for="MoveAssemblySessionDDL">Session No</label>
                                <asp:DropDownList ID="MoveAssemblySessionDDL" class="form-control" ValidationGroup="MoveGroup" runat="server" AutoPostBack="true" Placeolder="Session" OnSelectedIndexChanged="SessionDDL_SelectedIndexChanged1">
                                    <asp:ListItem Selected="True" Value="0">Session No</asp:ListItem>
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="rfvMoveAssemblySessionDDL" runat="server" Display="None" ErrorMessage="Select Session No" ValidationGroup="MoveGroup" InitialValue="0" ControlToValidate="MoveAssemblySessionDDL"></asp:RequiredFieldValidator>
                            </div>
                            <div class="col-md-3 form-group">
                                <label for="MoveGroupsDDL">Group</label>
                                <asp:DropDownList ID="MoveGroupsDDL" AutoPostBack="true" class="form-control" ValidationGroup="MoveGroup" runat="server" OnSelectedIndexChanged="MoveGroupDDL_SelectedIndexChanged">
                                    <asp:ListItem Selected="True" Value="0">Select Group</asp:ListItem>
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="rfvMoveGroupsDDL" runat="server" Display="None" ControlToValidate="MoveGroupsDDL" ErrorMessage="Select Group" ValidationGroup="MoveGroup" InitialValue="0"></asp:RequiredFieldValidator>
                            </div>
                            <div class="col-md-7 form-group">
                                <label for="MoveDivisionDDL">Division</label>
                                <asp:DropDownList ID="MoveDivisionDDL" AutoPostBack="true" class="form-control" runat="server" ValidationGroup="MoveGroup">
                                    <asp:ListItem Value="0">Select Division</asp:ListItem>
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="rfvMoveDivisionDDL" runat="server" Display="None" ControlToValidate="MoveDivisionDDL" ErrorMessage="Select Division" ValidationGroup="MoveGroup" InitialValue="0"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <div class="row">
                    <div class="col-md-2 form-group">
                        <label for="MoveNoticeDiaryTxt">Notice Diary No</label>
                        <asp:TextBox Type="Number" PlaceHolder="Notice Diary No" ID="MoveNoticeDiaryTxt" ValidationGroup="MoveGroup" Required="true" class="form-control" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvMoveNoticeDiaryTxt" runat="server" ErrorMessage="Enter Diary No." ValidationGroup="MoveGroup" Display="None" ControlToValidate="MoveNoticeDiaryTxt"></asp:RequiredFieldValidator>
                    </div>
                    <div class="col-md-2 form-group">
                        <label for="MoveNoticeDateTxt">Notice Diary Date</label>
                        <asp:TextBox ID="MoveNoticeDateTxt" PlaceHolder="Notice Date" ValidationGroup="MoveGroup" Required="true" class="form-control js-date" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvMoveNoticeDateTxt" runat="server" ErrorMessage="Enter Notice Date" ValidationGroup="MoveGroup" Display="None" ControlToValidate="MoveNoticeDateTxt"></asp:RequiredFieldValidator>
                    </div>
                    <div class="col-md-2 form-group">
                        <label for="MoveNoticeDiaryTimeTxt">Notice Diary Time</label>
                        <asp:TextBox ID="MoveNoticeDiaryTimeTxt" PlaceHolder="Notice Time" ValidationGroup="MoveGroup" Required="true" class="form-control" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvMoveNoticeDiaryTimeTxt" runat="server" ErrorMessage="Enter Notice Diary Time" ValidationGroup="MoveGroup" Display="None" ControlToValidate="MoveNoticeDiaryTimeTxt"></asp:RequiredFieldValidator>
                    </div>
                    <div class="col-md-3 form-group">
                        <label for="MoveQuestionStatusDDL">Question Status</label>
                        <asp:DropDownList ID="MoveQuestionStatusDDL" class="form-control" runat="server" OnSelectedIndexChanged="MoveGroupDDL_SelectedIndexChanged">
                            <asp:ListItem Selected="True" Value="0">Select Status</asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfvMoveQuestionStatusDDL" runat="server" Display="None" ErrorMessage="Select Status" ValidationGroup="MoveGroup" InitialValue="0" ControlToValidate="MoveQuestionStatusDDL"></asp:RequiredFieldValidator>
                    </div>
                    <div class="col-md-3 form-group">
                        <label for="MoveQuestionDiaryTxt">Question Diary No</label>
                        <asp:TextBox Type="Number" PlaceHolder="Question Diary No" ID="MoveQuestionDiaryTxt" ValidationGroup="Group1" class="form-control" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Enter Diary No." ValidationGroup="MoveGroup" Display="None" ControlToValidate="MoveQuestionDiaryTxt"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="form-group">
                    <asp:Button ID="MoveQuestionBtn" runat="server" Text="Revive" ValidationGroup="MoveGroup" class="btn btn-custom" OnClick="MoveQuestionBtn_Click" />
                    <button type="button" class="btn btn-default qd-close-panel">Cancel</button>
                </div>
            </div>
        </div>

        <%-- Defer panel (shown by the Defer button) --%>
        <div id="defer" class="qd-card qd-panel">
            <div class="qd-card-title">Defer Question</div>
            <div class="qd-card-body">
                <asp:ValidationSummary ID="ValidationSummary2" DisplayMode="BulletList"
                    EnableClientScript="true"
                    HeaderText="You must enter a value in the following fields:" ValidationGroup="DefferGroup" runat="server" />
                <div class="row">
                    <div class="col-md-3 form-group">
                        <label for="DefferAssemblySessionDDL">Session No</label>
                        <asp:DropDownList ID="DefferAssemblySessionDDL" class="form-control" runat="server" Placeolder="Session">
                            <asp:ListItem Selected="True" Value="0">Session No</asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfvDefferAssemblySessionDDL" runat="server" Display="None" ErrorMessage="Select Session" ValidationGroup="DefferGroup" InitialValue="0" ControlToValidate="DefferAssemblySessionDDL"></asp:RequiredFieldValidator>
                    </div>
                    <div class="col-md-3 form-group">
                        <label for="DeferDateTxt">Defer Date</label>
                        <asp:TextBox ID="DeferDateTxt" class="form-control js-date" runat="server" PlaceHolder="Defer Date"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvDeferDateTxt" runat="server" ErrorMessage="Enter Date" ValidationGroup="DefferGroup" Display="None" ControlToValidate="DeferDateTxt"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="form-group">
                    <asp:Button ID="DeferBtn" runat="server" Text="Defer" ValidationGroup="DefferGroup" class="btn btn-custom" OnClick="DeferQuestionBtn_Click" />
                    <button type="button" class="btn btn-default qd-close-panel">Cancel</button>
                    <asp:Label ID="Deferror" runat="server" Text="" Style="color: red; margin-left: 10px"></asp:Label>
                </div>
            </div>
        </div>

        <%-- Page header: record-level actions --%>
        <div class="qd-header">
            <div class="qd-actions">
                <asp:HyperLink ID="HyperLink1" CssClass="btn btn-warning" Text="Open File" runat="server" Target="_blank"></asp:HyperLink>
                <asp:Button ID="QuestionFilesDtn" CssClass="btn btn-success" runat="server" Text="Documents" OnClick="QuestionFilesDtn_Click" />
                <button id="Movebtn" class="btn btn-info">Revive</button>
                <button id="Defferbtn" class="btn btn-info">Defer</button>
                <asp:Button ID="TranslateBtn" CssClass="btn btn-custom" runat="server" Text="Send for Translation" OnClick="TranslateBtn_Click" />
                <asp:Label ID="UrduLbl" class="text-danger" Visible="false" runat="server"></asp:Label>
            </div>
            <h3>Question Details</h3>
            <p>Edit question, status, reply and view its history</p>
        </div>

        <div class="qd-error">
            <asp:Label ID="errorlbl" runat="server" Text="" Style="color: red"></asp:Label>
        </div>
        <asp:ValidationSummary ID="ValidationSummary3" DisplayMode="BulletList"
            EnableClientScript="true"
            HeaderText="You must enter a value in the following fields:" ValidationGroup="UpdateGroup" ForeColor="OrangeRed" runat="server" />

        <%-- Notice office --%>
        <div class="qd-card">
            <div class="qd-card-title">Notice Office Details</div>
            <div class="qd-card-body">
                <div class="row">
                    <div class="col-md-2 form-group">
                        <label for="SessionTxt">Session No</label>
                        <asp:TextBox ReadOnly="true" ID="SessionTxt" class="form-control" runat="server"></asp:TextBox>
                        <asp:HiddenField ID="HidSessionNumber" runat="server" />
                    </div>
                    <div class="col-md-3 form-group">
                        <label for="NoticeDiaryNoTxt">Notice Office Diary No</label>
                        <asp:TextBox Type="Number" ID="NoticeDiaryNoTxt" ValidationGroup="Group1" Required="true" ReadOnly="true" class="form-control" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvNoticeDiaryNoTxt" runat="server" ErrorMessage="Enter Office Diary No." ValidationGroup="UpdateGroup" Display="None" ControlToValidate="NoticeDiaryNoTxt"></asp:RequiredFieldValidator>
                    </div>
                    <div class="col-md-3 form-group">
                        <label for="NoticeDiaryDateTxt">Notice Office Diary Date</label>
                        <asp:TextBox ID="NoticeDiaryDateTxt" Type="Date(dd/MM/YYYY)" ValidationGroup="Group1" Required="true" ReadOnly="true" class="form-control js-date" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvNoticeDiaryDateTxt" runat="server" ErrorMessage="Enter Office Diary Date" ValidationGroup="UpdateGroup" Display="None" ControlToValidate="NoticeDiaryDateTxt"></asp:RequiredFieldValidator>
                    </div>
                    <div class="col-md-2 form-group">
                        <label for="NoticeDiaryTimeTxt">Notice Office Diary Time</label>
                        <asp:TextBox ID="NoticeDiaryTimeTxt" ValidationGroup="Group1" Required="true" class="form-control" ReadOnly="true" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvNoticeDiaryTimeTxt" runat="server" ErrorMessage="Enter Office Diary Time" ValidationGroup="UpdateGroup" Display="None" ControlToValidate="NoticeDiaryTimeTxt"></asp:RequiredFieldValidator>
                    </div>
                    <div class="col-md-2 form-group">
                        <label>Priority</label>
                        <label class="qd-check">
                            <asp:CheckBox ID="PriorityCB" runat="server"></asp:CheckBox>
                            High priority
                        </label>
                    </div>
                </div>
            </div>
        </div>

        <%-- Question information --%>
        <div class="qd-card">
            <div class="qd-card-title">Question Information</div>
            <div class="qd-card-body">
                <div class="row">
                    <div class="col-md-2 form-group">
                        <label for="QuestionIDTxt">Question ID</label>
                        <asp:TextBox ID="QuestionIDTxt" ReadOnly="true" class="form-control" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvQuestionDiaryNoTxt" runat="server" ErrorMessage="Enter Quewstion Diary No." ValidationGroup="UpdateGroup" Display="None" ControlToValidate="QuestionDiaryNoTxt"></asp:RequiredFieldValidator>
                    </div>
                    <div class="col-md-2 form-group">
                        <label for="QuestionDiaryNoTxt">Question Diary No</label>
                        <asp:TextBox ID="QuestionDiaryNoTxt" class="form-control" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Enter Quewstion Diary No." ValidationGroup="UpdateGroup" Display="None" ControlToValidate="QuestionDiaryNoTxt"></asp:RequiredFieldValidator>
                    </div>
                    <div class="col-md-3 form-group">
                        <label for="CategoryDDL">Category</label>
                        <asp:DropDownList ID="CategoryDDL" class="form-control" runat="server" ValidationGroup="Group1" OnSelectedIndexChanged="CategoryDDL_SelectedIndexChanged" AutoPostBack="true">
                            <asp:ListItem Value="0">Select</asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfvCategoryDDL" runat="server" ErrorMessage="Select Category" ValidationGroup="UpdateGroup" Display="None" InitialValue="0" ControlToValidate="CategoryDDL"></asp:RequiredFieldValidator>
                    </div>
                    <div class="col-md-3 form-group">
                        <asp:HiddenField ID="HidQuestionStatusId" runat="server" />
                        <label for="QuestionStatusDDL">Question Status</label>
                        <asp:DropDownList ID="QuestionStatusDDL" class="form-control" runat="server" ValidationGroup="Group1">
                            <asp:ListItem Value="0">Select</asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfvQuestionStatusDDL" runat="server" ErrorMessage="Select Status" ValidationGroup="UpdateGroup" Display="None" InitialValue="0" ControlToValidate="QuestionStatusDDL"></asp:RequiredFieldValidator>
                    </div>
                    <div class="col-md-2 form-group">
                        <label for="ReplyDateTxt">Reply Date</label>
                        <asp:TextBox ID="ReplyDateTxt" Type="Date(dd/MM/YYYY)" ValidationGroup="Group1" class="form-control js-date" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-3 form-group">
                        <label for="MemberNameTxt">Senator</label>
                        <asp:TextBox ID="MemberNameTxt" Required="true" runat="server" CssClass="form-control" placeholder="Type to search senators..." />
                        <asp:RequiredFieldValidator ID="rfvMemberNameTxt" runat="server" ErrorMessage="Enter member Name" ValidationGroup="UpdateGroup" Display="None" ControlToValidate="MemberNameTxt"></asp:RequiredFieldValidator>
                        <asp:HiddenField ID="HidMemberId" runat="server" />
                        <asp:HiddenField ID="HidCurrentMemberId" runat="server" />
                    </div>
                    <div class="col-md-2 form-group">
                        <label for="GroupDDL">Group</label>
                        <asp:DropDownList ID="GroupDDL" class="form-control" runat="server" ValidationGroup="Group1" AutoPostBack="true" OnSelectedIndexChanged="GroupDDL_SelectedIndexChanged">
                            <asp:ListItem Value="0">Select</asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfvGroupDDL" runat="server" ErrorMessage="Select Group" ValidationGroup="UpdateGroup" Display="None" InitialValue="0" ControlToValidate="GroupDDL"></asp:RequiredFieldValidator>
                    </div>
                    <div class="col-md-5 form-group">
                        <label for="DivisionDDL">Division</label>
                        <asp:DropDownList ID="DivisionDDL" class="form-control" Required="true" runat="server" ValidationGroup="UpdateGroup">
                            <asp:ListItem Value="">Select</asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfvDivisionDDL" runat="server" ErrorMessage="Select Division" ValidationGroup="UpdateGroup" Display="None" InitialValue="0" ControlToValidate="DivisionDDL"></asp:RequiredFieldValidator>
                    </div>
                    <div class="col-md-2 form-group">
                        <label for="FileStatusDDL">File Status</label>
                        <asp:HiddenField ID="HidFileStatus" runat="server" />
                        <asp:DropDownList ID="FileStatusDDL" class="form-control" Required="true" runat="server" ValidationGroup="UpdateGroup">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Select Division" ValidationGroup="UpdateGroup" Display="None" InitialValue="0" ControlToValidate="DivisionDDL"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="qd-error text-center">
                    <asp:Label ID="Error" runat="server" Style="color: red"></asp:Label>
                </div>
            </div>
        </div>

        <%-- Question text --%>
        <div class="qd-card">
            <div class="qd-card-title">Question Text</div>
            <div class="qd-card-body">
                <div class="form-group">
                    <label>Original Question Text</label>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Enter Question Text" ValidationGroup="UpdateGroup" Display="None" ControlToValidate="QTxt"></asp:RequiredFieldValidator>
                    <textarea id="OriginalTxt" name="OriginalTxt" style="height: 300px;" class="form-control" rows="10" runat="server" required="required"></textarea>
                </div>
                <div class="form-group">
                    <label>Amended Question Text</label>
                    <asp:RequiredFieldValidator ID="rfvQTxt" runat="server" ErrorMessage="Enter Question Text" ValidationGroup="UpdateGroup" Display="None" ControlToValidate="QTxt"></asp:RequiredFieldValidator>
                    <textarea id="QTxt" name="QTxt" style="height: 300px;" class="form-control" rows="10" runat="server" required="required"></textarea>
                </div>
                <div class="form-group">
                    <label>Urdu Text</label>
                    <textarea id="UrduTxt" name="UrduTxt" style="height: 300px;" class="form-control" rows="10" runat="server"></textarea>
                </div>
            </div>
        </div>

        <%-- Reply --%>
        <div class="qd-card">
            <div class="qd-card-title">Reply</div>
            <div class="qd-card-body">
                <div class="form-group">
                    <textarea id="RepTxt" name="RepTxt" style="height: 300px" class="form-control" rows="10" runat="server"></textarea>
                </div>
            </div>
        </div>

        <div id="imagediv" style="display: none"></div>

        <%-- Main actions: stays visible at the bottom of the window --%>
        <div class="qd-actionbar">
            <div class="qd-left">
                <asp:Button ID="UpdateQuestionBtn" runat="server" ValidationGroup="UpdateGroup" Text="Update" OnClick="UpdateQuestion_Click" class="btn btn-custom" />
                <asp:HyperLink ID="PrintHL" runat="server" Target="_blank" Text="Print Amended" CssClass="btn btn-default" />
                <asp:HyperLink ID="PrintOriginalHL" runat="server" Target="_blank" Text="Print Original" CssClass="btn btn-default" />
                <asp:HyperLink ID="PrintUrduHL" runat="server" Target="_blank" Text="Print Urdu" CssClass="btn btn-default" />
                <asp:HiddenField ID="HidQuestionFile" runat="server" />
                <span class="qd-hint">Ctrl + S to update</span>
            </div>
            <div id="deleteDiv" class="qd-right" runat="server" visible="false">
                <asp:Button ID="DeleteBtn" OnClientClick="return confirm('Are you sure you want to delete Question ?');" runat="server" Text="Delete" OnClick="DeleteBtn_Click" class="btn btn-danger" />
            </div>
        </div>

        <%-- Audit --%>
        <div class="qd-card">
            <div class="qd-card-title">Audit Trail</div>
            <div class="qd-card-body">
                <table class="table table-condensed qd-table">
                    <tr>
                        <th style="width: 240px">Action</th>
                        <th>User</th>
                    </tr>
                    <tr>
                        <td>Inserted By</td>
                        <td>
                            <asp:Label ID="InsertedByLbl" class="control-lbl-sm" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td>Updated By</td>
                        <td>
                            <asp:Label ID="UpdatedByLbl" class="control-lbl-sm" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td>Sent for translation By</td>
                        <td>
                            <asp:Label ID="SentForTransByLbl" class="control-lbl-sm" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td>Translation Approved By</td>
                        <td>
                            <asp:Label ID="TransApprovedByLbl" class="control-lbl-sm" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td>Deleted By</td>
                        <td>
                            <asp:Label ID="DeletedByLbl" class="control-lbl-sm" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td>Recovered By</td>
                        <td>
                            <asp:Label ID="RecoveredByLbl" class="control-lbl-sm" runat="server"></asp:Label></td>
                    </tr>
                </table>
            </div>
        </div>

        <%-- Histories --%>
        <div class="row">
            <div class="col-md-6">
                <div class="qd-card">
                    <div class="qd-card-title">Status History</div>
                    <div class="qd-card-body">
                        <table class="table table-hover table-striped table-responsive qd-table">
                            <thead>
                                <tr>
                                    <th>Sr#</th>
                                    <th>Session No</th>
                                    <th>Question Status</th>
                                    <th>Status Date</th>
                                    <th>User</th>
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
                                            <td>
                                                <asp:Label ID="Label8" class="table-data" runat="server" Text='<%#GetUserName(Convert.ToInt32(Eval("InsertedBy")))%>' />
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
                <div class="qd-card">
                    <div class="qd-card-title">Revival History</div>
                    <div class="qd-card-body">
                        <table class="table table-hover table-striped table-responsive qd-table">
                            <thead>
                                <tr>
                                    <th>Sr#</th>
                                    <th>From Session</th>
                                    <th>To Session</th>
                                    <th>Prev. Notice Diary No</th>
                                    <th>Revival Date</th>
                                    <th>User</th>
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
                                                <asp:Label ID="Label5" class="table-data" runat="server" Text='<%#Eval("FromAssemblySession")%>' />
                                            </td>
                                            <td>
                                                <asp:Label ID="Label7" class="table-data" runat="server" Text='<%#Eval("ToAssemblySession")%>' />
                                            </td>
                                            <td>
                                                <asp:Label ID="Label2" class="table-data" runat="server" Text='<%#Eval("NoticeOfficediaryNumber")%>' />
                                            </td>
                                            <td>
                                                <asp:Label ID="Label1" class="table-data" runat="server" Text='<%#GetDate(Convert.ToDateTime(Eval("RevivalDate")))%>' />
                                            </td>
                                            <td>
                                                <asp:Label ID="Label8" class="table-data" runat="server" Text='<%#GetUserName(Convert.ToInt32(Eval("InsertedBy")))%>' />
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
                <div class="qd-card">
                    <div class="qd-card-title">Defer History</div>
                    <div class="qd-card-body">
                        <table class="table table-hover table-striped table-responsive qd-table">
                            <thead>
                                <tr>
                                    <th>Sr#</th>
                                    <th>Deferred to Session</th>
                                    <th>Deferred on</th>
                                    <th>User</th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:ListView ID="DeferLv" runat="server"
                                    OnItemDeleting="ItemDeleting">
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
                                                <asp:Label ID="Label8" class="table-data" runat="server" Text='<%#GetUserName(Convert.ToInt32(Eval("InsertedBy")))%>' />
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
                <div class="qd-card">
                    <div class="qd-card-title">File Status History</div>
                    <div class="qd-card-body">
                        <table class="table table-hover table-striped table-responsive qd-table">
                            <thead>
                                <tr>
                                    <th>Sr#</th>
                                    <th>File Status</th>
                                    <th>Date</th>
                                    <th>User</th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:ListView ID="LVFileStatus" runat="server">
                                    <ItemTemplate>
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label3" class="table-data" runat="server" Text='<%#Container.DataItemIndex + 1%> ' />
                                            </td>
                                            <td>
                                                <asp:Label ID="Label1" class="table-data" runat="server" Text='<%#Eval("FileStatus")%>' />
                                            </td>
                                            <td>
                                                <asp:Label ID="Label6" class="table-data" runat="server" Text='<%#GetDate(Convert.ToDateTime(Eval("StatusHistoryDate")))%>' />
                                            </td>
                                            <td>
                                                <asp:Label ID="Label8" class="table-data" runat="server" Text='<%#Eval("UserName")%>' />
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

    </div>

    <script type="text/javascript">
        $('#ContentPlaceHolder3_NoticeDiaryTimeTxt').timepicker({
            template: false,
            showInputs: false,
            minuteStep: 5
        });

        // one editor configuration for all rich-text boxes
        function questionEditor(selector, height, withPrint) {
            var toolbar = [
                ['pagebreak', ['pagebreak']],
                ['style', ['style']],
                ['font', ['bold', 'italic', 'underline', 'clear']],
                ['fontname', ['fontname']],
                ['fontsize', ['fontsize']],
                ['color', ['color']],
                ['para', ['ul', 'ol', 'paragraph']],
                ['height', ['height']],
                ['table', ['table']],
                ['insert', ['media', 'link', 'hr']],
                ['view', ['fullscreen', 'codeview']],
                ['help', ['help']]
            ];
            if (withPrint) toolbar.push(['print', ['print']]);
            $(selector).summernote({ toolbar: toolbar, height: height });
        }
        $(document).ready(function () {
            questionEditor('#ContentPlaceHolder3_OriginalTxt', 300, true);
            questionEditor('#ContentPlaceHolder3_QTxt', 300, true);
            questionEditor('#ContentPlaceHolder3_UrduTxt', 300, false);
            $('#ContentPlaceHolder3_RepTxt').summernote({ height: 200 });
        });

        // Revive / Defer panels
        $("#Movebtn").click(function (e) {
            e.preventDefault();
            $("#defer").hide();
            $("#move").toggle();
        });
        $("#Defferbtn").click(function (e) {
            e.preventDefault();
            $("#move").hide();
            $("#defer").toggle();
        });
        $(document).on('click', '.qd-close-panel', function () {
            $("#move, #defer").hide();
        });

        // Senator search (single select)
        $(function () {
            $("[id$=MemberNameTxt]").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: '<%=ResolveUrl("~/Service.asmx/GetEmployeeName") %>',
                        data: "{ 'prefix': '" + request.term + "'}",
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        success: function (data) {
                            response($.map(data.d, function (item) {
                                return {
                                    label: item.split('=')[0],
                                    val: item.split('=')[1]
                                }
                            }))
                        },
                        error: function (response) {
                            alert(response.responseText);
                        },
                        failure: function (response) {
                            alert(response.responseText);
                        }
                    });
                },
                select: function (e, i) {
                    $("[id$=HidMemberId]").val(i.item.val);
                },
                minLength: 1
            });
        });

        $(document).bind('keydown', function (e) {
            if (e.ctrlKey && (e.which == 83)) {
                e.preventDefault();
                document.getElementById('ContentPlaceHolder3_UpdateQuestionBtn').click();
                return false;
            }
        });
        $(document).bind('keydown', function (e) {
            if (e.ctrlKey && (e.which == 80)) {
                e.preventDefault();
                document.getElementById('ContentPlaceHolder3_PrintHL').click();
                return false;
            }
        });
    </script>

</asp:Content>
