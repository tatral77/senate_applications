<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" ValidateRequest="false" AutoEventWireup="true" CodeBehind="ResolutionDetail.aspx.cs" Inherits="QuestionManagement.ResolutionDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="summernote/summernote.js"></script>
    <link href="Summernote/summernote.css" rel="stylesheet" />
    <link href="Styles/bootstrap-timepicker.min.css" rel="stylesheet" />
    <script src="Scripts/bootstrap-timepicker.min.js"></script>
    <style>
        .rd-header { margin: 6px 0 18px; padding-bottom: 14px; border-bottom: 1px solid #e4e9ee; overflow: hidden; }
            .rd-header h3 { margin: 0 0 2px; font-size: 24px; font-weight: 600; color: #1f2d3d; }
            .rd-header p { margin: 0; font-size: 14px; color: #6b7785; }
            .rd-header .rd-actions { float: right; margin-top: 4px; }
            .rd-header .rd-actions .btn, .rd-header .rd-actions a.btn { margin-left: 6px; }

        .rd-card { background: #fff; border: 1px solid #e4e9ee; border-radius: 6px; box-shadow: 0 1px 4px rgba(0,0,0,.06); margin-bottom: 20px; }
        .rd-card-title { padding: 11px 18px; border-bottom: 1px solid #e4e9ee; background: #f8fafb; border-radius: 6px 6px 0 0; font-size: 12px; font-weight: 700; letter-spacing: .08em; text-transform: uppercase; color: #0c3a72; }
        .rd-card-body { padding: 16px 18px 6px; }
            .rd-card-body .form-group { margin-bottom: 14px; }
            .rd-card-body label { font-size: 13px; font-weight: 600; color: #3c4858; margin-bottom: 4px; }
            .rd-card-body .form-control[readonly] { background: #f3f6f8; }
        .rd-error { color: #c0392b; font-size: 13px; text-align: center; margin-bottom: 10px; }

        .rd-move { display: none; }
            .rd-move .rd-card-title { background: #fff8e6; color: #8a5a00; }

        /* sticky action bar */
        .rd-actionbar {
            position: sticky;
            bottom: 0;
            z-index: 40;
            display: flex;
            align-items: center;
            background: #fff;
            border: 1px solid #e4e9ee;
            border-radius: 6px;
            box-shadow: 0 -2px 10px rgba(0,0,0,.08);
            padding: 10px 16px;
            margin: 0 0 20px;
        }
            .rd-actionbar .rd-left .btn { margin-right: 6px; }
            .rd-actionbar .rd-hint { margin-left: 12px; font-size: 12px; color: #6b7785; }
            .rd-actionbar .rd-right { margin-left: auto; }

        .rd-audit td, .rd-audit th { font-size: 13px; }
        .rd-audit th { color: #6b7785; font-weight: 600; }

        /* searchable multiselect */
        .ms { position: relative; }
        .ms-box { min-height: 38px; padding: 3px 6px; background: #fff; border: 1px solid #ccd3da; border-radius: 4px; cursor: text; display: flex; flex-wrap: wrap; align-items: center; }
            .ms-box.focus { border-color: #1f6fb5; box-shadow: 0 0 0 2px rgba(31,111,181,.15); }
        .ms-chip { display: inline-flex; align-items: center; background: #e8f0f9; color: #0c3a72; border-radius: 12px; padding: 2px 4px 2px 10px; margin: 2px 4px 2px 0; font-size: 13px; }
            .ms-chip .ms-x { border: 0; background: transparent; color: #0c3a72; font-size: 16px; line-height: 1; margin-left: 4px; padding: 0 5px; cursor: pointer; border-radius: 50%; }
                .ms-chip .ms-x:hover { background: #c9daee; }
        .ms-input { flex: 1; min-width: 140px; border: 0; outline: 0; padding: 4px; font-size: 14px; background: transparent; }
        .ms-menu { display: none; position: absolute; left: 0; right: 0; top: 100%; z-index: 60; max-height: 220px; overflow-y: auto; background: #fff; border: 1px solid #ccd3da; border-radius: 4px; box-shadow: 0 6px 16px rgba(0,0,0,.15); margin-top: 2px; }
            .ms-menu.open { display: block; }
        .ms-opt { padding: 7px 12px; font-size: 14px; cursor: pointer; }
            .ms-opt.active, .ms-opt:hover { background: #e8f0f9; }
            .ms-opt mark { background: #fff1a8; padding: 0; }
        .ms-note { padding: 8px 12px; font-size: 13px; color: #6b7785; }
        .ms-count { font-size: 12px; color: #6b7785; margin-top: 3px; }
        .ms-hint { font-weight: 400; font-size: 12px; color: #6b7785; margin-left: 6px; }
        .ms-chip.sortable { cursor: grab; }
        .ms-chip.dragging { opacity: .4; }
        .ms-chip.drop-before { box-shadow: -3px 0 0 #1f6fb5; }
        .ms-chip.first { background: #fff1c2; color: #6b4a00; }
            .ms-chip.first .ms-x { color: #6b4a00; }
        .ms-chip .ms-badge { font-size: 10px; font-weight: 700; text-transform: uppercase; background: #e69500; color: #fff; border-radius: 8px; padding: 0 6px; margin-right: 6px; }
        .ms-chip .ms-front { border: 0; background: transparent; color: #0c3a72; font-size: 12px; margin-left: 4px; padding: 0 3px; cursor: pointer; }
            .ms-chip .ms-front:hover { color: #e69500; }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    <div class="container">

        <%-- Revive panel (shown by the Revive button) --%>
        <div id="move" class="rd-card rd-move">
            <div class="rd-card-title">Revive Resolution in another session</div>
            <div class="rd-card-body">
                <asp:ValidationSummary ID="ValidationSummary1" DisplayMode="BulletList"
                    EnableClientScript="true" Style="color: red;"
                    HeaderText="You must enter a value in the following fields:" ValidationGroup="MoveGroup" runat="server" />
                <asp:UpdatePanel ID="upSetSession" runat="server">
                    <ContentTemplate>
                        <div class="row">
                            <div class="col-md-2 form-group">
                                <label for="MoveAssemblySessionDDL">Session No</label>
                                <asp:DropDownList ID="MoveAssemblySessionDDL" class="form-control" ValidationGroup="MoveGroup" runat="server">
                                    <asp:ListItem Selected="True" Value="0">Session No</asp:ListItem>
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="rfvMoveAssemblySessionDDL" runat="server" Display="None" ErrorMessage="Select Session No" ValidationGroup="MoveGroup" InitialValue="0" ControlToValidate="MoveAssemblySessionDDL"></asp:RequiredFieldValidator>
                            </div>
                            <div class="col-md-2 form-group">
                                <label for="MoveNoticeDiaryTxt">Notice Diary No</label>
                                <asp:TextBox Type="Number" PlaceHolder="Notice Diary No" ID="MoveNoticeDiaryTxt" ValidationGroup="MoveGroup" Required="true" class="form-control" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvMoveNoticeDiaryTxt" runat="server" ErrorMessage="Enter Diary No." ValidationGroup="MoveGroup" Display="None" ControlToValidate="MoveNoticeDiaryTxt"></asp:RequiredFieldValidator>
                            </div>
                            <div class="col-md-2 form-group">
                                <label for="MoveNoticeDateTxt">Notice Date</label>
                                <asp:TextBox ID="MoveNoticeDateTxt" PlaceHolder="Notice Date" ValidationGroup="MoveGroup" Required="true" class="form-control js-date" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvMoveNoticeDateTxt" runat="server" ErrorMessage="Enter Notice Date" ValidationGroup="MoveGroup" Display="None" ControlToValidate="MoveNoticeDateTxt"></asp:RequiredFieldValidator>
                            </div>
                            <div class="col-md-2 form-group">
                                <label for="MoveNoticeDiaryTimeTxt">Notice Time</label>
                                <asp:TextBox ID="MoveNoticeDiaryTimeTxt" PlaceHolder="Notice Time" ValidationGroup="MoveGroup" Required="true" class="form-control" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Enter Notice Time" ValidationGroup="MoveGroup" Display="None" ControlToValidate="MoveNoticeDiaryTimeTxt"></asp:RequiredFieldValidator>
                            </div>
                            <div class="col-md-2 form-group">
                                <label for="MoveResDiaryNoTxt">Resolution Diary No</label>
                                <asp:TextBox ID="MoveResDiaryNoTxt" PlaceHolder="Resolution Diary No" ValidationGroup="MoveGroup" Required="true" class="form-control" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Enter Resolution Diary No:" ValidationGroup="MoveGroup" Display="None" ControlToValidate="MoveResDiaryNoTxt"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <div class="form-group">
                    <asp:Button ID="MoveResolutionBtn" runat="server" Text="Revive" ValidationGroup="MoveGroup" class="btn btn-custom" OnClick="MoveResolutionBtn_Click" />
                    <input type="submit" id="CancelBtn" value="Cancel" formnovalidate class="btn btn-default">
                </div>
            </div>
        </div>

        <%-- Page header: record-level actions --%>
        <div class="rd-header">
            <div class="rd-actions">
                <asp:HyperLink ID="HyperLink1" CssClass="btn btn-warning" Text="Open File" runat="server" Target="_blank"></asp:HyperLink>
                <button id="Movebtn" class="btn btn-info">Revive</button>
                <asp:Button ID="TranslateBtn" CssClass="btn btn-custom" runat="server" Text="Send for Translation" OnClick="TranslateBtn_Click" />
                <asp:Label ID="UrduLbl" class="text-danger" Visible="false" runat="server"></asp:Label>
            </div>
            <h3>Resolution Details</h3>
            <p>Edit resolution, movers and ministries</p>
        </div>

        <asp:ValidationSummary ID="ValidationSummary3" DisplayMode="BulletList"
            EnableClientScript="true"
            HeaderText="You must enter a value in the following fields:" ValidationGroup="SaveGroup" ForeColor="OrangeRed" runat="server" />

        <%-- Notice office --%>
        <div class="rd-card">
            <div class="rd-card-title">Notice Office Details</div>
            <div class="rd-card-body">
                <div class="row">
                    <div class="col-md-2 form-group">
                        <label for="SessionTxt">Session No</label>
                        <asp:TextBox ReadOnly="true" ID="SessionTxt" class="form-control control-txt" runat="server"></asp:TextBox>
                        <asp:HiddenField ID="HidSessionNumber" runat="server" />
                    </div>
                    <div class="col-md-2 form-group">
                        <label for="NoticeDiaryNoTxt">Notice Diary No</label>
                        <asp:TextBox Type="Number" ID="NoticeDiaryNoTxt" ReadOnly="true" ValidationGroup="Group1" Required="true" class="form-control control-txt" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvNoticeDiaryNoTxt" runat="server" ErrorMessage="Enter Notice Diary No." ValidationGroup="SaveGroup" Display="None" ControlToValidate="NoticeDiaryNoTxt"></asp:RequiredFieldValidator>
                    </div>
                    <div class="col-md-3 form-group">
                        <label for="NoticeDiaryDateTxt">Notice Diary Date</label>
                        <asp:TextBox ID="NoticeDiaryDateTxt" ValidationGroup="Group1" Required="true" class="form-control control-txt js-date" runat="server"></asp:TextBox>
                        <asp:Label ID="DateError" runat="server" Style="color: red" Text=""></asp:Label>
                        <asp:RequiredFieldValidator ID="rfvNoticeDiaryDateTxt" runat="server" ErrorMessage="Enter Office Diary Date" ValidationGroup="SaveGroup" Display="None" ControlToValidate="NoticeDiaryDateTxt"></asp:RequiredFieldValidator>
                    </div>
                    <div class="col-md-3 form-group bootstrap-timepicker">
                        <label for="NoticeDiaryTimeTxt">Notice Diary Time</label>
                        <asp:TextBox ID="NoticeDiaryTimeTxt" ValidationGroup="Group1" Required="true" class="form-control control-txt" runat="server"></asp:TextBox>
                        <asp:Label ID="Label1" runat="server" Style="color: red" Text=""></asp:Label>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Enter Office Diary Time" ValidationGroup="SaveGroup" Display="None" ControlToValidate="NoticeDiaryTimeTxt"></asp:RequiredFieldValidator>
                    </div>
                    <div class="col-md-2 form-group">
                        <label for="ResolutionNoTxt">Colour Res. No</label>
                        <asp:TextBox ID="ResolutionNoTxt" ValidationGroup="Group1" Required="true" class="form-control control-txt" runat="server"></asp:TextBox>
                    </div>
                </div>
            </div>
        </div>

        <%-- Resolution information --%>
        <div class="rd-card">
            <div class="rd-card-title">Resolution Information</div>
            <div class="rd-card-body">
                <div class="row">
                    <div class="col-md-2 form-group">
                        <label for="ResolutionIDTxt">Resolution ID</label>
                        <asp:TextBox ID="ResolutionIDTxt" ReadOnly="true" Required="true" class="form-control control-txt" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-md-2 form-group">
                        <label for="ResolutionDiaryNoTxt">Resolution Diary No</label>
                        <asp:TextBox ID="ResolutionDiaryNoTxt" Required="true" class="form-control control-txt" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-md-4 form-group">
                        <label for="ResolutionTypeDDL">Resolution Type</label>
                        <asp:DropDownList ID="ResolutionTypeDDL" class="form-control control-txt" runat="server" ValidationGroup="Group1">
                            <asp:ListItem Value="0">Select</asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfvCategoryDDL" runat="server" ErrorMessage="Select Category" ValidationGroup="SaveGroup" Display="None" InitialValue="0" ControlToValidate="ResolutionTypeDDL"></asp:RequiredFieldValidator>
                    </div>
                    <div class="col-md-4 form-group">
                        <label for="ResolutionStatusDDL">Resolution Status</label>
                        <asp:HiddenField ID="HidResolutionStatusId" runat="server" />
                        <asp:DropDownList ID="ResolutionStatusDDL" class="form-control control-txt" runat="server" ValidationGroup="Group1">
                            <asp:ListItem Value="0">Select</asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Select Category" ValidationGroup="SaveGroup" Display="None" InitialValue="0" ControlToValidate="ResolutionTypeDDL"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-2 form-group">
                        <label for="HouseMovingDateTxt">Date of Moving in House</label>
                        <asp:TextBox ID="HouseMovingDateTxt" runat="server" CssClass="form-control js-date" />
                    </div>
                    <div class="col-md-2 form-group">
                        <label for="DiscussionDateTxt">Date of Discussion</label>
                        <asp:TextBox ID="DiscussionDateTxt" runat="server" CssClass="form-control js-date" />
                    </div>
                    <div class="col-md-2 form-group">
                        <label for="PassingDateTxt">Date of Passing</label>
                        <asp:TextBox ID="PassingDateTxt" runat="server" CssClass="form-control js-date" />
                    </div>
                    <div class="col-md-3 form-group">
                        <label for="ClubedToTxt">Clubbed To</label>
                        <asp:TextBox ID="ClubedToTxt" runat="server" CssClass="form-control" />
                    </div>
                    <div class="col-md-3 form-group">
                        <label for="ClubedResolutionsTxt">Clubbed Resolutions</label>
                        <asp:TextBox ID="ClubedResolutionsTxt" runat="server" CssClass="form-control" />
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-12 form-group">
                        <label style="font-weight: normal">
                            <asp:CheckBox ID="UrduCB" runat="server" Checked="false"></asp:CheckBox>
                            &nbsp;This is an Urdu resolution
                        </label>
                    </div>
                </div>
            </div>
        </div>

        <%-- People and ministries: searchable multi-selects --%>
        <div class="rd-card">
            <div class="rd-card-title">Submitters &amp; Ministries</div>
            <div class="rd-card-body">
                <div class="row">
                    <div class="col-md-6 form-group">
                        <label>Resolution Submitters <span class="ms-hint">drag to reorder &middot; first name is printed on top</span></label>
                        <div class="ms" data-sortable="true" data-service="GetEmployeeName" data-hidden='<%= HidMoversJson.ClientID %>' data-placeholder="Search members by name...">
                            <div class="ms-box"><input type="text" class="ms-input" autocomplete="off" /></div>
                            <div class="ms-menu"></div>
                        </div>
                        <asp:HiddenField ID="HidMoversJson" runat="server" />
                        <div class="ms-count" data-for="HidMoversJson"></div>
                    </div>
                    <div class="col-md-6 form-group">
                        <label>Ministries</label>
                        <div class="ms" data-service="GetCurrentDivisionsByName" data-hidden='<%= HidMinistriesJson.ClientID %>' data-placeholder="Search ministries...">
                            <div class="ms-box"><input type="text" class="ms-input" autocomplete="off" /></div>
                            <div class="ms-menu"></div>
                        </div>
                        <asp:HiddenField ID="HidMinistriesJson" runat="server" />
                        <div class="ms-count" data-for="HidMinistriesJson"></div>
                    </div>
                </div>
                <div class="rd-error">
                    <asp:Label ID="Error" runat="server" Style="color: red"></asp:Label>
                </div>
            </div>
        </div>

        <%-- Texts --%>
        <div class="rd-card">
            <div class="rd-card-title">Resolution Text</div>
            <div class="rd-card-body">
                <div class="form-group">
                    <label>Original Resolution Text</label>
                    <textarea id="OriginalTxt" name="ResolutionTxt" style="height: 300px" class="form-control" validationgroup="SaveGroup" rows="10" runat="server" required="required"></textarea>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Enter Resolution Text" ValidationGroup="SaveGroup" Display="None" ControlToValidate="ResolutionTxt"></asp:RequiredFieldValidator>
                </div>
                <div class="form-group">
                    <label>Amended Resolution Text</label>
                    <textarea id="ResolutionTxt" name="ResolutionTxt" style="height: 300px" class="form-control" validationgroup="SaveGroup" rows="10" runat="server" required="required"></textarea>
                    <asp:RequiredFieldValidator ID="rfvQuestionTxt" runat="server" ErrorMessage="Enter Resolution Text" ValidationGroup="SaveGroup" Display="None" ControlToValidate="ResolutionTxt"></asp:RequiredFieldValidator>
                </div>
                <div class="form-group">
                    <label>Urdu Text</label>
                    <textarea id="UrduText" name="ResolutionTxt" style="height: 300px" class="form-control" validationgroup="SaveGroup" rows="10" runat="server" required="required"></textarea>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Enter Urdu Text" ValidationGroup="SaveGroup" Display="None" ControlToValidate="UrduText"></asp:RequiredFieldValidator>
                </div>
            </div>
        </div>

        <%-- Main actions: stays visible at the bottom of the window --%>
        <div class="rd-actionbar">
            <div class="rd-left">
                <asp:Button ID="Button1" runat="server" Text="Save" ValidationGroup="SaveGroup" OnClick="Button1_Click" class="btn btn-custom" />
                <asp:HyperLink ID="PrintOriginal" runat="server" Target="_blank" Text="Print Original" CssClass="btn btn-default" />
                <asp:HyperLink ID="PrintHL" runat="server" Target="_blank" Text="Print Amended" CssClass="btn btn-default" />
                <span class="rd-hint">Ctrl + S to save</span>
            </div>
            <div class="rd-right">
                <span id="DeleteDiv" runat="server">
                    <asp:Button ID="DeleteBtn" runat="server" Text="Delete" OnClick="DeleteBtn_Click" class="btn btn-danger" OnClientClick="return confirm('Are you sure you want to delete Resolution');" />
                </span>
                <span id="RecoverDiv" runat="server">
                    <asp:Button ID="RecoverBtn" runat="server" Text="Recover" OnClick="RecoverBtn_Click" class="btn btn-success" OnClientClick="return confirm('Are you sure you want to Recover Resolution');" />
                </span>
            </div>
        </div>

        <%-- Audit --%>
        <div class="rd-card">
            <div class="rd-card-title">Audit Trail</div>
            <div class="rd-card-body">
                <table class="table table-condensed rd-audit">
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
                <div class="rd-card">
                    <div class="rd-card-title">Status History</div>
                    <div class="rd-card-body">
                        <table class="table table-hover table-striped table-responsive rd-audit">
                            <thead>
                                <tr>
                                    <th>Sr#</th>
                                    <th>Session No</th>
                                    <th>Status</th>
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
                                                <asp:Label ID="Label4" class="table-data" runat="server" Text='<%#Bind("ResolutionStatus")%>' />
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
                <div class="rd-card">
                    <div class="rd-card-title">Revival History</div>
                    <div class="rd-card-body">
                        <table class="table table-hover table-striped table-responsive rd-audit">
                            <thead>
                                <tr>
                                    <th>Sr#</th>
                                    <th>From Session</th>
                                    <th>To Session</th>
                                    <th>Prev. Notice Diary No</th>
                                    <th>Revival Date</th>
                                    <th>User</th>
                                    <th></th>
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
                                            <td>
                                                <asp:HyperLink ID="Label9" class="table-data" runat="server" NavigateUrl='<%#Convert.ToString(Eval("PreviousFile"))%>'>Previous File</asp:HyperLink>
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
            defaultTime: false,
            minuteStep: 5
        });

        $(document).ready(function () {
            $('#ContentPlaceHolder3_OriginalTxt').summernote({ height: 300 });
            $('#ContentPlaceHolder3_ResolutionTxt').summernote({ height: 300 });
            $('#ContentPlaceHolder3_UrduText').summernote({ height: 300 });
        });

        $("#Movebtn").click(function (e) {
            e.preventDefault();
            $("#move").toggle();
            $("#Movebtn").hide();
        });
        $("#CancelBtn").click(function (e) {
            e.preventDefault();
            $("#move").toggle();
            $("#Movebtn").show();
        });

        // ---- Searchable multi-select -------------------------------------------------
        // Selected items live in a hidden field as JSON [{id:1,name:"x"}, ...]; the server
        // reads it when Save is clicked. Search uses the existing Service.asmx methods,
        // which return "Name=Id" strings.
        (function () {
            var serviceBase = '<%=ResolveUrl("~/Service.asmx/") %>';

            function esc(s) { return $('<div>').text(s).html(); }

            function init(root) {
                var $root = $(root);
                var $hidden = $('#' + $root.data('hidden'));
                var $box = $root.find('.ms-box');
                var $input = $root.find('.ms-input').attr('placeholder', $root.data('placeholder'));
                var $menu = $root.find('.ms-menu');
                var $count = $('.ms-count[data-for$="' + $hidden.attr('id').split('_').pop() + '"]');
                var items = [];
                var results = [];
                var active = -1;
                var timer = null;
                var reqId = 0;

                try { items = JSON.parse($hidden.val() || '[]'); } catch (e) { items = []; }

                function save() {
                    $hidden.val(JSON.stringify(items));
                    $count.text(items.length + ' selected');
                }
                function has(id) { return items.some(function (i) { return i.id === id; }); }

                var sortable = $root.data('sortable') === true || $root.data('sortable') === 'true';
                var dragId = null;

                function move(fromId, toIndex) {
                    var from = items.findIndex(function (x) { return x.id === fromId; });
                    if (from < 0) return;
                    var it = items.splice(from, 1)[0];
                    if (toIndex > from) toIndex--;
                    items.splice(toIndex, 0, it);
                    save(); renderChips();
                }

                function renderChips() {
                    $box.find('.ms-chip').remove();
                    items.forEach(function (it, idx) {
                        var $chip = $('<span class="ms-chip"></span>');
                        if (sortable && idx === 0 && items.length > 1) {
                            $chip.addClass('first').append('<span class="ms-badge">First</span>');
                        }
                        $chip.append(document.createTextNode(it.name));
                        if (sortable && idx > 0) {
                            $('<button type="button" class="ms-front" title="Move to front">&#8676;</button>').on('click', function (e) {
                                e.stopPropagation();
                                move(it.id, 0);
                            }).appendTo($chip);
                        }
                        $('<button type="button" class="ms-x" title="Remove">&times;</button>').on('click', function (e) {
                            e.stopPropagation();
                            items = items.filter(function (x) { return x.id !== it.id; });
                            save(); renderChips();
                        }).appendTo($chip);

                        if (sortable) {
                            $chip.addClass('sortable').attr('draggable', 'true')
                                .on('dragstart', function (e) {
                                    dragId = it.id;
                                    $(this).addClass('dragging');
                                    e.originalEvent.dataTransfer.effectAllowed = 'move';
                                    e.originalEvent.dataTransfer.setData('text/plain', String(it.id));
                                })
                                .on('dragend', function () {
                                    dragId = null;
                                    $box.find('.ms-chip').removeClass('dragging drop-before');
                                })
                                .on('dragover', function (e) {
                                    if (dragId === null || dragId === it.id) return;
                                    e.preventDefault();
                                    $box.find('.ms-chip').removeClass('drop-before');
                                    $(this).addClass('drop-before');
                                })
                                .on('drop', function (e) {
                                    e.preventDefault();
                                    if (dragId !== null && dragId !== it.id) move(dragId, idx);
                                });
                        }
                        $chip.insertBefore($input);
                    });
                }

                function closeMenu() { $menu.removeClass('open'); active = -1; }

                function renderMenu(term) {
                    var shown = results.filter(function (r) { return !has(r.id); });
                    if (!shown.length) {
                        $menu.html('<div class="ms-note">' + (term ? 'No matches' : 'Type to search') + '</div>').addClass('open');
                        results = shown; return;
                    }
                    var re = new RegExp('(' + term.replace(/[.*+?^${}()|[\]\\]/g, '\\$&') + ')', 'ig');
                    $menu.empty();
                    shown.forEach(function (r, idx) {
                        var $o = $('<div class="ms-opt"></div>').html(esc(r.name).replace(re, '<mark>$1</mark>'));
                        $o.on('mousedown', function (e) { e.preventDefault(); pick(idx); });
                        $menu.append($o);
                    });
                    results = shown;
                    active = 0;
                    highlight();
                    $menu.addClass('open');
                }

                function highlight() {
                    $menu.find('.ms-opt').removeClass('active').eq(active).addClass('active');
                    var el = $menu.find('.ms-opt').get(active);
                    if (el && el.scrollIntoView) { var m = $menu.get(0); if (el.offsetTop < m.scrollTop) m.scrollTop = el.offsetTop; else if (el.offsetTop + el.offsetHeight > m.scrollTop + m.clientHeight) m.scrollTop = el.offsetTop + el.offsetHeight - m.clientHeight; }
                }

                function pick(idx) {
                    var r = results[idx];
                    if (!r) return;
                    items.push({ id: r.id, name: r.name });
                    save(); renderChips();
                    $input.val('').focus();
                    closeMenu();
                }

                function search(term) {
                    var my = ++reqId;
                    $.ajax({
                        url: serviceBase + $root.data('service'),
                        data: JSON.stringify({ prefix: term }),
                        dataType: 'json', type: 'POST', contentType: 'application/json; charset=utf-8',
                        success: function (data) {
                            if (my !== reqId) return;
                            results = $.map(data.d || [], function (s) {
                                var k = s.lastIndexOf('=');
                                return { name: s.substring(0, k), id: parseInt(s.substring(k + 1), 10) };
                            });
                            renderMenu(term);
                        },
                        error: function () { $menu.html('<div class="ms-note">Search failed</div>').addClass('open'); }
                    });
                }

                $box.on('click', function () { $input.focus(); });
                $input.on('focus', function () { $box.addClass('focus'); });
                $input.on('blur', function () { $box.removeClass('focus'); closeMenu(); });
                $input.on('input', function () {
                    var term = $.trim($input.val());
                    clearTimeout(timer);
                    if (!term) { closeMenu(); return; }
                    timer = setTimeout(function () { search(term); }, 250);
                });
                $input.on('keydown', function (e) {
                    var open = $menu.hasClass('open') && results.length;
                    if (e.which === 40 && open) { e.preventDefault(); active = (active + 1) % results.length; highlight(); }
                    else if (e.which === 38 && open) { e.preventDefault(); active = (active - 1 + results.length) % results.length; highlight(); }
                    else if (e.which === 13) { e.preventDefault(); if (open) pick(active); }
                    else if (e.which === 27) { closeMenu(); }
                    else if (e.which === 8 && !$input.val() && items.length) { items.pop(); save(); renderChips(); }
                });

                save(); renderChips();
            }

            $(function () { $('.ms').each(function () { init(this); }); });
        })();
        // -------------------------------------------------------------------------------

        $(document).bind('keydown', function (e) {
            if (e.ctrlKey && (e.which == 83)) {
                e.preventDefault();
                document.getElementById('ContentPlaceHolder3_Button1').click();
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
