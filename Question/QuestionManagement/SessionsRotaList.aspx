<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="SessionsRotaList.aspx.cs" Inherits="QuestionManagement.SessionsRotaList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .rota-chip { display: inline-block; padding: 2px 10px; margin: 2px 4px 2px 0; border-radius: 999px; background: #e8f2fd; color: #124f96; font-size: 12px; font-weight: 600; white-space: nowrap; }
        .rota-chip small { font-weight: 500; color: #5b6b7d; }
        .rota-group { background: #e9f6ee; color: #1b6b34; }
        .rota-chips { min-width: 0; }
        .rota-table > tbody > tr > td { vertical-align: middle; }
        .rota-form-cell { background: #f8fafc; padding: 0 !important; }
        .rota-form { padding: 18px 20px 16px; }
        .rota-form-title { margin: 0 0 16px; color: #124f96; font-weight: 700; }
        .rota-form .form-group { margin-bottom: 14px; }
        .rota-form label { display: block; margin-bottom: 5px; }
        .rota-form-sub { margin: -8px 0 16px; color: #6b7785; font-size: 13px; }
        .rota-form .req { color: #c0392b; font-weight: 700; }
        .rota-form label { font-size: 13px; font-weight: 600; color: #3c4858; }
        .rota-help { display: block; margin-top: 4px; font-size: 12px; font-weight: 400; color: #6b7785; line-height: 1.35; }
        .rota-section { background: #fff; border: 1px solid #e4e9ee; border-radius: 6px; margin-bottom: 16px; box-shadow: 0 1px 3px rgba(0,0,0,.05); }
        .rota-section-title { padding: 9px 16px; background: #f3f7fc; border-bottom: 1px solid #e4e9ee; border-radius: 6px 6px 0 0; font-size: 12px; font-weight: 700; letter-spacing: .08em; text-transform: uppercase; color: #0c3a72; }
            .rota-section-title .rota-help { display: inline; margin: 0 0 0 8px; text-transform: none; letter-spacing: 0; }
        .rota-section-body { padding: 14px 16px 4px; }
        .rota-add .form-control { min-width: 130px; }
        .rota-listbox { background: #fbfcfe; }
        .rota-summary { margin: 4px 0 12px; padding: 9px 14px; background: #eef5fc; border: 1px solid #d5e4f4; border-radius: 6px; font-size: 13px; color: #24425f; }
            .rota-summary .glyphicon { color: #1f6fb5; margin-right: 6px; }
        .rota-add { display: flex; gap: 8px; flex-wrap: wrap; align-items: stretch; }
        .rota-add .form-control { flex: 1 1 130px; min-width: 120px; width: auto; }
        .rota-listbox { height: auto; min-height: 120px; margin-top: 10px; }
        .rota-remove { margin-top: 8px; }
        .rota-actions { margin-top: 6px; padding-top: 14px; border-top: 1px solid #e3e8ef; text-align: right; }
        .rota-actions .btn { margin-left: 6px; }
        .rota-empty { padding: 26px 10px; text-align: center; color: #6b7280; }
        .rota-empty .glyphicon { display: block; font-size: 26px; margin-bottom: 8px; opacity: .6; }
        .rota-sub { color: #6b7280; margin: -4px 0 14px; }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="col-xs-8 col-md-9">
                <h4 class="page-header" style="margin-top: 0">ROTA LIST</h4>
                <asp:Label ID="day" runat="server" Text=""></asp:Label>
                <p class="rota-sub">Question rota lists for each assembly session.</p>
            </div>
            <div class="col-xs-4 col-md-3 text-right">
                <asp:Button ID="LinkButton1" runat="server" CommandName="new" Text="Add New" class="btn btn-custom" OnClick="newLinkButton_Click" />
            </div>
        </div>
        <div class="row">
            <div class="col-md-12">
                <asp:ValidationSummary ID="ValidationSummary1"
                    HeaderText="You must enter a value in the following fields:"
                    DisplayMode="BulletList"
                    EnableClientScript="true"
                    ShowSummary="true"
                    CssClass="alert alert-danger"
                    runat="server" ValidationGroup="Group1" />

                <table class="table table-hover table-striped table-data rota-table">
                    <tr>
                        <th>Sr#</th>
                        <th>Session Number</th>
                        <th>Start List No</th>
                        <th>List Type</th>
                        <th>Start Date</th>
                        <th>End Date</th>
                        <th>Skip Days</th>
                        <th>Week Days</th>
                        <th>Start Group</th>
                        <th class="text-center">Action</th>
                    </tr>
                    <asp:ListView ID="ListView1" runat="server"
                        OnItemEditing="ItemEditing"
                        OnItemInserting="ItemInserting"
                        OnItemCanceling="ItemCanceling"
                        OnItemUpdating="ItemUpdating"
                        OnItemDataBound="ItemDataBound"
                        OnItemCreated="ItemCreated"
                        OnItemDeleting="ItemDeleting">

                        <ItemTemplate>
                            <tr>
                                <td class="text-center">
                                    <asp:HiddenField ID="HidRotaListId" runat="server" Value='<%#Bind("RotaListId")%>' />
                                    <asp:HiddenField ID="HidAssemblySessionId" runat="server" Value='<%#Bind("AssemblySessionsId")%>' />
                                    <asp:Label ID="SrNo" runat="server" Text='<%#Container.DataItemIndex + 1%> '></asp:Label></td>
                                <td>
                                    <asp:HyperLink class="table-data" ID="HyperLink1" runat="server" NavigateUrl='<%#Eval("RotaListId","~/RotaList.aspx?rotalistid={0}")%>' Font-Bold="true">Session No: <%#Eval("SessionNumber")%></asp:HyperLink></td>
                                <td>
                                    <asp:Label ID="Label3" runat="server" Text='<%#Eval("StartListNo")%>'></asp:Label></td>
                                <td>
                                    <asp:Label ID="Label5" runat="server" Text='<%#Eval("ListType")%>'></asp:Label></td>
                                <td>
                                    <asp:Label ID="Label4" runat="server" Text='<%#GetDate(Convert.ToDateTime(Eval("StartDate")))%>'></asp:Label></td>
                                <td>
                                    <asp:Label ID="Label6" runat="server" Text='<%#GetDate(Convert.ToDateTime(Eval("EndDate")))%>'></asp:Label></td>
                                <td>
                                    <div class="rota-chips">
                                    <asp:ListView ID="SkipDatesLV" runat="server" DataSource='<%#Eval("SkipRotaGroups")%>'>
                                        <ItemTemplate>
                                            <span class="rota-chip">
                                                <asp:Label ID="Label1" runat="server" Text='<%#Convert.ToDateTime(Eval("SkipDate")).ToShortDateString()%>'></asp:Label>
                                                <small>
                                                    <asp:Label ID="Label2" runat="server" Text='<%#Eval("SkipGroupDesc")%>'></asp:Label></small>
                                            </span>
                                        </ItemTemplate>
                                        <EmptyDataTemplate>
                                            <span class="text-muted">-</span>
                                        </EmptyDataTemplate>
                                    </asp:ListView>
                                    </div>
                                </td>
                                <td>
                                    <asp:Label ID="Label1" runat="server" Text='<%#Bind("RotaWeekDay")%>'></asp:Label></td>
                                <td>
                                    <span class="rota-chip rota-group">
                                        <asp:Label ID="Label8" runat="server" Text='<%#"Group-" + Eval("StartGroup")%>'></asp:Label></span></td>
                                <td class="text-center" style="white-space: nowrap">
                                    <asp:LinkButton ID="editImageButton" class="btn btn-custom" runat="server" CommandName="edit"
                                        ToolTip="Edit"><span class="glyphicon glyphicon-pencil"></span></asp:LinkButton>
                                    <asp:LinkButton ID="deleteImageButton" class="btn btn-danger" runat="server" CommandName="delete"
                                        ToolTip="Delete" OnClientClick="return confirm('Are you sure you want to delete record ?');"><span class="glyphicon glyphicon-trash"></span></asp:LinkButton>
                                </td>
                            </tr>
                        </ItemTemplate>

                        <EditItemTemplate>
                            <tr>
                                <td colspan="10" class="rota-form-cell">
                    <asp:HiddenField ID="HidRotaListId" runat="server" Value='<%#Bind("RotaListId")%>' />
                    <asp:HiddenField ID="HidAssemblySessionId" runat="server" Value='<%#Bind("AssemblySessionsId")%>' />
                    <asp:HiddenField ID="HidRotaWeekDayId" runat="server" Value='<%#Bind("RotaWeekDayId")%>' />
                    <asp:HiddenField ID="HidStartGroup" runat="server" Value='<%#Bind("StartGroup")%>' />
                    <asp:HiddenField ID="HidAllowedDates" runat="server" Value='<%#Bind("AllowedDates")%>' />
                    <asp:HiddenField ID="HidListType" runat="server" Value='<%#Bind("ListType")%>' />
                                    <div class="rota-form">
                                        <h4 class="rota-form-title"><span class="glyphicon glyphicon-pencil"></span> Edit Rota List</h4>
                                        <p class="rota-form-sub">Update the session, dates, days and groups of this rota list.</p>
                                        <div class="rota-section">
                                            <div class="rota-section-title">Rota details</div>
                                            <div class="rota-section-body">
                                        <div class="row">
                                            <div class="col-md-3 col-sm-6 form-group">
                                                <label>Session Number <span class="req">*</span></label>
                                                <asp:DropDownList ID="SessionDDL" class="form-control control-txt" Required="true" runat="server"></asp:DropDownList>
                                            </div>
                                            <div class="col-md-3 col-sm-6 form-group">
                                                <label>List Type <span class="req">*</span></label>
                                                <asp:DropDownList ID="ListTypeDDL" class="form-control control-txt" Required="true" runat="server">
                                                    <asp:ListItem Value="Provisional">Provisional</asp:ListItem>
                                                    <asp:ListItem Value="Revised Provisional">Revised Provisional</asp:ListItem>
                                                    <asp:ListItem Value="Further Revised Provisional">Further Revised Provisional</asp:ListItem>
                                                    <asp:ListItem Value="Further">Further</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                            <div class="col-md-2 col-sm-4 form-group">
                                                <label>Start List No <span class="req">*</span></label>
                                                <asp:TextBox ID="StartListNoTxt" class="form-control control-txt" ClientIDMode="Static" type="number" runat="server" Text='<%#Eval("StartListNo")%>'></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="StartListNoRFV" runat="server" ControlToValidate="StartListNoTxt" ErrorMessage="Start List No" Display="None" ValidationGroup="Group1" />
                                            </div>
                                            <div class="col-md-2 col-sm-4 form-group">
                                                <label>Start Group</label>
                                                <asp:DropDownList ID="StartGroupDDL" class="form-control control-txt" runat="server">
                                                    <asp:ListItem Value="1">Group-1</asp:ListItem>
                                                    <asp:ListItem Value="2">Group-2</asp:ListItem>
                                                    <asp:ListItem Value="3">Group-3</asp:ListItem>
                                                    <asp:ListItem Value="4">Group-4</asp:ListItem>
                                                    <asp:ListItem Value="5">Group-5</asp:ListItem>
                                                </asp:DropDownList>
                                                <span class="rota-help">The group that answers on the first date</span>
                                            </div>
                                            <div class="col-md-2 col-sm-4 form-group">
                                                <label>Week Days</label>
                                                <asp:DropDownList ID="RotaWeekDaysDDL" class="form-control control-txt" runat="server"></asp:DropDownList>
                                                <span class="rota-help">Days of the week on which questions are answered</span>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-md-3 col-sm-6 form-group">
                                                <label>Start Date <span class="req">*</span></label>
                                                <asp:TextBox ID="FromDateTxt" class="form-control control-txt datepicker js-date" placeholder="dd-mm-yyyy" autocomplete="off" ClientIDMode="Static" runat="server" Text='<%#GetDate(Convert.ToDateTime(Eval("StartDate")))%>'></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="FromDateRFV" runat="server" ControlToValidate="FromDateTxt" ErrorMessage="Start Date" Display="None" ValidationGroup="Group1" />
                                            </div>
                                            <div class="col-md-3 col-sm-6 form-group">
                                                <label>End Date <span class="req">*</span></label>
                                                <asp:TextBox ID="ToDateTxt" class="form-control control-txt datepicker js-date" placeholder="dd-mm-yyyy" autocomplete="off" ClientIDMode="Static" runat="server" Text='<%#GetDate(Convert.ToDateTime(Eval("EndDate")))%>'></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="ToDateRFV" runat="server" ControlToValidate="ToDateTxt" ErrorMessage="End Date" Display="None" ValidationGroup="Group1" />
                                            </div>
                                        </div>
                                        </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-md-6">
                                                <div class="rota-section">
                                                    <div class="rota-section-title">Skip Groups <span class="rota-help">On a date, leave out one group or all groups</span></div>
                                                    <div class="rota-section-body">
                                                        <div class="rota-add">
                                                            <asp:TextBox ID="SkipDateTxt" class="form-control control-txt datepicker js-date" placeholder="dd-mm-yyyy" autocomplete="off" runat="server" Text=''></asp:TextBox>
                                                            <asp:DropDownList ID="SkipGroupsDDL" class="form-control control-txt" runat="server">
                                                                <asp:ListItem Value="0">All Groups</asp:ListItem>
                                                                <asp:ListItem Value="1">Group-1</asp:ListItem>
                                                                <asp:ListItem Value="2">Group-2</asp:ListItem>
                                                                <asp:ListItem Value="3">Group-3</asp:ListItem>
                                                                <asp:ListItem Value="4">Group-4</asp:ListItem>
                                                                <asp:ListItem Value="5">Group-5</asp:ListItem>
                                                            </asp:DropDownList>
                                                            <asp:Button ID="AddGroupBtn" runat="server" Text="Add" CssClass="btn btn-success" CausesValidation="false" OnClick="AddGroupBtn_Click" />
                                                        </div>
                                                        <asp:ListBox ID="SkipedGroupsLB" runat="server" Rows="5" SelectionMode="Multiple" CssClass="form-control rota-listbox"></asp:ListBox>
                                                        <asp:Button ID="RemoveGroupBtn" runat="server" Text="Remove selected" CssClass="btn btn-danger btn-sm rota-remove" CausesValidation="false" OnClick="RemoveGroupBtn_Click" />
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-6">
                                                <div class="rota-section">
                                                    <div class="rota-section-title">Other Allowed Dates <span class="rota-help">Extra answering dates outside the usual week days</span></div>
                                                    <div class="rota-section-body">
                                                        <div class="rota-add">
                                                            <asp:TextBox ID="AddDaysTxt" class="form-control control-txt datepicker" placeholder="dd-mm-yyyy" autocomplete="off" runat="server" Text=''></asp:TextBox>
                                                            <asp:Button ID="AddDayBtn" runat="server" Text="Add" CssClass="btn btn-success" CausesValidation="false" OnClick="AddDayBtn_Click" />
                                                        </div>
                                                        <asp:ListBox ID="AllowedDaysLB" runat="server" Rows="5" SelectionMode="Multiple" CssClass="form-control rota-listbox"></asp:ListBox>
                                                        <asp:Button ID="RemoveDayBtn" runat="server" Text="Remove selected" CssClass="btn btn-danger btn-sm rota-remove" CausesValidation="false" OnClick="RemoveDayBtn_Click" />
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="rota-summary"><span class="glyphicon glyphicon-info-sign"></span><span class="rota-summary-text"></span></div>
                                        <div class="rota-actions">
                                            <asp:LinkButton ID="cancelImageButton" class="btn btn-default" runat="server" CommandName="cancel" CausesValidation="false"
                                                ToolTip="Cancel"><span class="glyphicon glyphicon-arrow-left"></span> Cancel</asp:LinkButton>
                                            <asp:LinkButton class="btn btn-custom" ID="saveImageButton" runat="server" CommandName="update"
                                                ToolTip="Save" ValidationGroup="Group1"><span class="glyphicon glyphicon-floppy-disk"></span> Save</asp:LinkButton>
                                        </div>
                                    </div>
                                </td>
                            </tr>
                        </EditItemTemplate>
                        <InsertItemTemplate>
                            <tr>
                                <td colspan="10" class="rota-form-cell">
                                    <div class="rota-form">
                                        <h4 class="rota-form-title"><span class="glyphicon glyphicon-plus"></span> New Rota List</h4>
                                        <p class="rota-form-sub">Choose the session, the period and the days on which questions are answered.</p>
                                        <div class="rota-section">
                                            <div class="rota-section-title">Rota details</div>
                                            <div class="rota-section-body">
                                        <div class="row">
                                            <div class="col-md-3 col-sm-6 form-group">
                                                <label>Session Number <span class="req">*</span></label>
                                                <asp:DropDownList ID="SessionDDL" class="form-control control-txt" Required="true" runat="server"></asp:DropDownList>
                                            </div>
                                            <div class="col-md-3 col-sm-6 form-group">
                                                <label>List Type <span class="req">*</span></label>
                                                <asp:DropDownList ID="ListTypeDDL" class="form-control control-txt" Required="true" runat="server">
                                                    <asp:ListItem Value="Provisional">Provisional</asp:ListItem>
                                                    <asp:ListItem Value="Revised Provisional">Revised Provisional</asp:ListItem>
                                                    <asp:ListItem Value="Further Revised Provisional">Further Revised Provisional</asp:ListItem>
                                                    <asp:ListItem Value="Further">Further</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                            <div class="col-md-2 col-sm-4 form-group">
                                                <label>Start List No <span class="req">*</span></label>
                                                <asp:TextBox ID="StartListNoTxt" class="form-control control-txt" ClientIDMode="Static" type="number" runat="server" Text='<%#Eval("StartListNo")%>'></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="StartListNoRFV" runat="server" ControlToValidate="StartListNoTxt" ErrorMessage="Start List No" Display="None" ValidationGroup="Group1" />
                                            </div>
                                            <div class="col-md-2 col-sm-4 form-group">
                                                <label>Start Group</label>
                                                <asp:DropDownList ID="StartGroupDDL" class="form-control control-txt" runat="server">
                                                    <asp:ListItem Value="1">Group-1</asp:ListItem>
                                                    <asp:ListItem Value="2">Group-2</asp:ListItem>
                                                    <asp:ListItem Value="3">Group-3</asp:ListItem>
                                                    <asp:ListItem Value="4">Group-4</asp:ListItem>
                                                    <asp:ListItem Value="5">Group-5</asp:ListItem>
                                                </asp:DropDownList>
                                                <span class="rota-help">The group that answers on the first date</span>
                                            </div>
                                            <div class="col-md-2 col-sm-4 form-group">
                                                <label>Week Days</label>
                                                <asp:DropDownList ID="RotaWeekDaysDDL" class="form-control control-txt" runat="server"></asp:DropDownList>
                                                <span class="rota-help">Days of the week on which questions are answered</span>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-md-3 col-sm-6 form-group">
                                                <label>Start Date <span class="req">*</span></label>
                                                <asp:TextBox ID="FromDateTxt" class="form-control control-txt datepicker js-date" placeholder="dd-mm-yyyy" autocomplete="off" ClientIDMode="Static" runat="server" Text=''></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="FromDateRFV" runat="server" ControlToValidate="FromDateTxt" ErrorMessage="Start Date" Display="None" ValidationGroup="Group1" />
                                            </div>
                                            <div class="col-md-3 col-sm-6 form-group">
                                                <label>End Date <span class="req">*</span></label>
                                                <asp:TextBox ID="ToDateTxt" class="form-control control-txt datepicker js-date" placeholder="dd-mm-yyyy" autocomplete="off" ClientIDMode="Static" runat="server" Text=''></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="ToDateRFV" runat="server" ControlToValidate="ToDateTxt" ErrorMessage="End Date" Display="None" ValidationGroup="Group1" />
                                            </div>
                                        </div>
                                        </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-md-6">
                                                <div class="rota-section">
                                                    <div class="rota-section-title">Skip Groups <span class="rota-help">On a date, leave out one group or all groups</span></div>
                                                    <div class="rota-section-body">
                                                        <div class="rota-add">
                                                            <asp:TextBox ID="SkipDateTxt" class="form-control control-txt datepicker js-date" placeholder="dd-mm-yyyy" autocomplete="off" runat="server" Text=''></asp:TextBox>
                                                            <asp:DropDownList ID="SkipGroupsDDL" class="form-control control-txt" runat="server">
                                                                <asp:ListItem Value="0">All Groups</asp:ListItem>
                                                                <asp:ListItem Value="1">Group-1</asp:ListItem>
                                                                <asp:ListItem Value="2">Group-2</asp:ListItem>
                                                                <asp:ListItem Value="3">Group-3</asp:ListItem>
                                                                <asp:ListItem Value="4">Group-4</asp:ListItem>
                                                                <asp:ListItem Value="5">Group-5</asp:ListItem>
                                                            </asp:DropDownList>
                                                            <asp:Button ID="AddGroupBtn" runat="server" Text="Add" CssClass="btn btn-success" CausesValidation="false" OnClick="AddGroupBtn_Click" />
                                                        </div>
                                                        <asp:ListBox ID="SkipedGroupsLB" runat="server" Rows="5" SelectionMode="Multiple" CssClass="form-control rota-listbox"></asp:ListBox>
                                                        <asp:Button ID="RemoveGroupBtn" runat="server" Text="Remove selected" CssClass="btn btn-danger btn-sm rota-remove" CausesValidation="false" OnClick="RemoveGroupBtn_Click" />
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-6">
                                                <div class="rota-section">
                                                    <div class="rota-section-title">Other Allowed Dates <span class="rota-help">Extra answering dates outside the usual week days</span></div>
                                                    <div class="rota-section-body">
                                                        <div class="rota-add">
                                                            <asp:TextBox ID="AddDaysTxt" class="form-control control-txt datepicker" placeholder="dd-mm-yyyy" autocomplete="off" runat="server" Text=''></asp:TextBox>
                                                            <asp:Button ID="AddDayBtn" runat="server" Text="Add" CssClass="btn btn-success" CausesValidation="false" OnClick="AddDayBtn_Click" />
                                                        </div>
                                                        <asp:ListBox ID="AllowedDaysLB" runat="server" Rows="5" SelectionMode="Multiple" CssClass="form-control rota-listbox"></asp:ListBox>
                                                        <asp:Button ID="RemoveDayBtn" runat="server" Text="Remove selected" CssClass="btn btn-danger btn-sm rota-remove" CausesValidation="false" OnClick="RemoveDayBtn_Click" />
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="rota-summary"><span class="glyphicon glyphicon-info-sign"></span><span class="rota-summary-text"></span></div>
                                        <div class="rota-actions">
                                            <asp:LinkButton ID="cancelImageButton" class="btn btn-default" runat="server" CommandName="cancel" CausesValidation="false"
                                                ToolTip="Cancel"><span class="glyphicon glyphicon-arrow-left"></span> Cancel</asp:LinkButton>
                                            <asp:LinkButton class="btn btn-custom" ID="saveImageButton" runat="server" CommandName="insert"
                                                ToolTip="Save" ValidationGroup="Group1"><span class="glyphicon glyphicon-floppy-disk"></span> Save</asp:LinkButton>
                                        </div>
                                    </div>
                                </td>
                            </tr>
                        </InsertItemTemplate>
                        <EmptyDataTemplate>
                            <tr>
                                <td colspan="10">
                                    <div class="rota-empty">
                                        <span class="glyphicon glyphicon-calendar"></span>
                                        No rota lists found. Use <b>Add New</b> to create one.
                                    </div>
                                </td>
                            </tr>
                        </EmptyDataTemplate>
                    </asp:ListView>
                </table>
            </div>
        </div>
    </div>
    <script type="text/javascript">
        $(document).ready(function () {
            $('.datepicker').datepicker({
                dateFormat: 'dd-mm-yy', changeMonth: true, changeYear: true,
                onSelect: function () { $(this).trigger('change'); }
            });

            // one-line summary of the form, kept up to date while the user fills it in
            function summarise() {
                $('.rota-form').each(function () {
                    var $f = $(this);
                    function text(sel) { return $.trim($f.find(sel + ' option:selected').text()); }
                    var from = $.trim($f.find('[id$=FromDateTxt]').val()), to = $.trim($f.find('[id$=ToDateTxt]').val());
                    var skips = $f.find('[id$=SkipedGroupsLB] option').length, extra = $f.find('[id$=AllowedDaysLB] option').length;
                    var parts = [];
                    parts.push((text('[id$=ListTypeDDL]') || 'List') + ' list' + (text('[id$=SessionDDL]') ? ', session ' + text('[id$=SessionDDL]') : ''));
                    parts.push(from && to ? 'from ' + from + ' to ' + to : 'dates not set yet');
                    if (text('[id$=RotaWeekDaysDDL]')) parts.push('answering on ' + text('[id$=RotaWeekDaysDDL]'));
                    parts.push('starting with ' + text('[id$=StartGroupDDL]'));
                    parts.push(skips + ' skipped date' + (skips === 1 ? '' : 's') + ', ' + extra + ' extra date' + (extra === 1 ? '' : 's'));
                    $f.find('.rota-summary-text').text(parts.join(' \u00b7 '));
                });
            }
            $(document).on('input change', '.rota-form select, .rota-form input', summarise);
            summarise();
        });
    </script>
</asp:Content>
