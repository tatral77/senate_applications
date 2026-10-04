<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" ValidateRequest="false" MaintainScrollPositionOnPostback="true" AutoEventWireup="true" CodeBehind="BillDetail.aspx.cs" Inherits="Legislation.BillDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="CustomScripts/jquery.min.js"></script>
    <script src="summernote/summernote.js"></script>
    <script src="Summernote/plugin/rtl.js"></script>
    <link href="Summernote/summernote.css" rel="stylesheet" />
    <script src="CustomScripts/JQuery-ui-1.13.2.js"></script>
    <link href="Styles/jquery-ui-1.13.2.css" rel="stylesheet" />
    <style>
        .ui-autocomplete {
            position: relative;
            cursor: default;
            z-index: 2000 !important;
        }
        /* section jump bar */
        .bd-nav { position: sticky; top: 52px; z-index: 1020; display: flex; flex-wrap: wrap; gap: 6px; padding: 8px 10px; margin: 0 0 16px; background: #fff; border: 1px solid var(--line); border-radius: 10px; box-shadow: var(--shadow); }
        .bd-nav a { padding: 5px 12px; border-radius: 999px; background: #eef4fb; color: var(--brand-dark); font-weight: 600; font-size: 12.5px; text-decoration: none; }
        .bd-nav a:hover, .bd-nav a.active { background: var(--brand); color: #fff; }
        section[id] { scroll-margin-top: 120px; }
        /* section titles */
        .bd-title { display: flex; align-items: center; gap: 8px; margin: 0 0 16px; padding-bottom: 10px; border-bottom: 2px solid #e9f0f9; font-size: 15px; font-weight: 700; letter-spacing: .6px; text-transform: uppercase; color: var(--brand-dark); }
        .bd-title .glyphicon { color: var(--brand); }
        .bd-count { display: inline-block; min-width: 24px; padding: 1px 8px; border-radius: 999px; background: var(--brand); color: #fff; font-size: 12px; text-align: center; }
        .bd-hint { margin: -6px 0 12px; color: var(--muted); font-size: 12.5px; }
        .bd-savebar { display: flex; justify-content: flex-end; margin-top: 12px; }
        /* rich text editor */
        .bd-editor .note-editor.note-frame { border: 1px solid #cbd5e1; border-radius: 10px; box-shadow: none; }
        .bd-editor .note-editor.note-frame.fullscreen { z-index: 2100; }
        .bd-editor .note-toolbar { background: #f6f8fb; border-bottom: 1px solid var(--line); border-radius: 10px 10px 0 0; }
        .bd-editor .note-editable { background: #fff; font-size: 15px; line-height: 1.7; text-align: justify; }
        /* documents */
        .bd-upload { padding: 16px 16px 6px; margin-bottom: 18px; background: #f8fafc; border: 1px solid var(--line); border-radius: 12px; }
        .bd-upload .row { margin-bottom: 12px; }
        .bd-upload-btn { padding-top: 22px; }
        .bd-drop { position: relative; height: 96px; display: flex; flex-direction: column; align-items: center; justify-content: center; text-align: center; border: 2px dashed #9db6d3; border-radius: 12px; background: #fff; color: var(--brand-dark); transition: background .15s, border-color .15s; }
        .bd-drop:hover, .bd-drop.over { background: #eaf3fd; border-color: var(--brand); }
        .bd-drop.has-file { border-style: solid; border-color: #16a34a; background: #f0fdf4; color: #14532d; }
        .bd-file { position: absolute; inset: 0; width: 100% !important; height: 100% !important; opacity: 0; cursor: pointer; padding: 0; }
        .bd-drop-icon { font-size: 22px; }
        .bd-drop-text { font-weight: 600; word-break: break-all; padding: 0 12px; }
        .bd-drop-hint { font-size: 12px; color: var(--muted); }
        .bd-table > tbody > tr > td { vertical-align: top; }
        .bd-desc { white-space: pre-line; min-width: 260px; }
        .bd-type { display: inline-block; padding: 2px 10px; border-radius: 999px; background: #e8f2fd; color: var(--brand-dark); font-size: 12px; font-weight: 600; }
        .bd-editrow > td { background: #fffbea; }
        .bd-actions .btn { margin: 0 0 4px; }
        .bd-empty { text-align: center; padding: 26px !important; color: var(--muted); }
        .bd-empty .glyphicon { display: block; font-size: 26px; margin-bottom: 6px; }
        @media (max-width: 767px) { .bd-nav { top: 0; position: static; } .bd-upload-btn { padding-top: 0; } }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="nf-head">
        <h4>BILL DETAILS</h4>
    </div>
    <div class="bd-nav" id="bdNav">
        <a href="#BasicDetails">Basic</a>
        <a href="#CommitteeDetails">Committee</a>
        <a href="#MemberDetails">Member Passage</a>
        <a href="#NADetails">National Assembly</a>
        <a href="#SearchableContents">Bill Contents</a>
        <a href="#BillDocuments">Documents</a>
        <a href="#StatusHistory">Status History</a>
    </div>


    <section id="BasicDetails">
        <div class="container  regularDiv" id="#panel">
            <h4 class="bd-title"><span class="glyphicon glyphicon-list-alt"></span>Basic Details</h4>
            <div class="row top-buffer">
                <asp:ValidationSummary ID="ValidationSummary3" DisplayMode="BulletList"
                    EnableClientScript="true"
                    HeaderText="You must enter a value in the following fields:" ValidationGroup="SaveGroup" ForeColor="OrangeRed" runat="server" />
                <div class="col-md-2 bootst">
                    <label class="control-lbl-sm" for="BillIdTxt">Bill Id:</label>
                    <asp:TextBox ID="BillIdTxt" ReadOnly="true" class="form-control small-control" runat="server"></asp:TextBox>

                </div>
                <div class="col-md-2">
                    <label class="control-lbl-sm" for="SessionTxt">Parliamentary Year:</label>
                    <asp:DropDownList ID="ParliamentaryYearDDL" class="form-control small-control" runat="server" ValidationGroup="Group1">
                    </asp:DropDownList>
                </div>
                <div class="col-md-2">
                    <label class="control-lbl-sm" for="SessionTxt">Session:</label>
                    <asp:DropDownList ID="AssemblySessionDDL" class="form-control small-control" runat="server" ValidationGroup="Group1">
                    </asp:DropDownList>
                </div>
               <%-- <div class="col-md-3">
                    <label class="control-lbl-sm" for="SessionTxt">Originated In:</label>
                    <asp:DropDownList ID="OriginatedInDDL" class="form-control small-control" runat="server" ValidationGroup="Group1">
                        <asp:ListItem Value="1">Senate</asp:ListItem>
                        <asp:ListItem Value="2">National Assembly</asp:ListItem>
                    </asp:DropDownList>
                </div>--%>

                <div class="col-md-2 bootst">
                    <label class="control-lbl-sm" for="FileNumberTxt">File Number:</label>
                    <asp:TextBox ID="FileNumberTxt" ValidationGroup="Group1" class="form-control small-control" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvLegislationDiaryNoTxt" runat="server" ErrorMessage="Enter File No." ValidationGroup="SaveGroup" Display="None" ControlToValidate="FileNumberTxt"></asp:RequiredFieldValidator>
                </div>

                <div class="col-md-2">
                    <label class="control-lbl-sm" for="NoticeDateTxt">Notice Date:</label>
                    <asp:TextBox ID="NoticeDateTxt" ValidationGroup="Group1" class="form-control small-control datepicker js-date" runat="server"></asp:TextBox>
                    <asp:Label ID="DateError" runat="server" Style="color: red" Text=""></asp:Label>
                    <asp:RequiredFieldValidator ID="rfvLegislationDiaryDateTxt" runat="server" ErrorMessage="Enter Notice Date" ValidationGroup="SaveGroup" Display="None" ControlToValidate="NoticeDateTxt"></asp:RequiredFieldValidator>
                </div>
                <div class="col-md-2">
                    <label class="control-lbl-sm" for="BillCategoryDDL">Bill Category:</label>
                    <asp:DropDownList ID="BillCategoryDDL" ValidationGroup="Group1" class="form-control small-control" runat="server">
                    </asp:DropDownList>
                </div>
                <div class="col-md-2">
                    <label class="control-lbl-sm" for="BillTypeDDL">Bill Type:</label>
                    <asp:DropDownList ID="BillTypeDDL" class="form-control small-control" runat="server">
                    </asp:DropDownList>
                </div>
                <div class="col-md-3">
                    <label class="control-lbl-sm" for="BillStatusDDL">Bill Status:</label>
                    <asp:DropDownList ID="BillStatusDDL" class="form-control small-control" runat="server">
                    </asp:DropDownList>
                    <asp:HiddenField ID="HidBillStatusId" runat="server" />
                </div>
                <div class="col-md-2">
                    <label class="control-lbl-sm" for="NoticeDateTxt">Status Date:</label>
                    <asp:TextBox ID="StatusDateTxt" ValidationGroup="Group1" class="form-control small-control datepicker js-date" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Enter Status Date" ValidationGroup="SaveGroup" Display="None" ControlToValidate="StatusDateTxt"></asp:RequiredFieldValidator>
                </div>
                <div class="col-md-2">
                    <label class="control-lbl-sm" for="IsActiveDDL">Is Active:</label>
                    <asp:DropDownList ID="IsActiveDDL" class="form-control small-control" runat="server">
                        <asp:ListItem Value="1">Yes</asp:ListItem>
                        <asp:ListItem Value="0">No</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <%--  <div class="col-md-3 bootstrap-timepicker">
                <label class="control-lbl-sm" for="LegislationDiaryTimeTxt">Legislation Diary Time:</label>
                <asp:TextBox ID="LegislationDiaryTimeTxt" ValidationGroup="Group1" Required="true" class="form-control small-control" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvLegislationDiaryTimeTxt" runat="server" ErrorMessage="Enter Legislation Diary Time" ValidationGroup="SaveGroup" Display="None" ControlToValidate="LegislationDiaryTimeTxt"></asp:RequiredFieldValidator>
            </div>--%>
                <%--<div class="col-md-3">
                <label class="control-lbl-sm">Bill Diary No:</label>
                <asp:TextBox ID="BillDiaryNoTxt" class="form-control small-control" runat="server"></asp:TextBox>
            </div>--%>
            </div>

            <div class="row top-buffer">
            </div>
            <%--   <div class="col-md-2">
                <label class="control-lbl-sm" for="CategoryDDL">Originated By:</label>
                <asp:DropDownList ID="OriginatedByDDL" class="form-control small-control" runat="server" ValidationGroup="Group1">
                     <asp:ListItem Value="1">Senate</asp:ListItem>
                     <asp:ListItem Value="2">National Assembly</asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidato" runat="server" ErrorMessage="Select Category" ValidationGroup="SaveGroup" Display="None" InitialValue="0" ControlToValidate="OriginatedByDDL"></asp:RequiredFieldValidator>
            </div>
           <div class="col-md-3">
                <label class="control-lbl-sm" for="CategoryDDL">Concerned Committee:</label>
                <asp:DropDownList ID="CommitteeDDL" class="form-control small-control" runat="server" ValidationGroup="Group1">
                    <asp:ListItem Value="0">Select</asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Select Category" ValidationGroup="SaveGroup" Display="None" InitialValue="0" ControlToValidate="CommitteeDDL"></asp:RequiredFieldValidator>
            </div>--%>

            <div class="row top-buffer">
                <div class="col-md-10">
                    <label class="control-lbl-sm">Bill Title:</label>
                </div>
            </div>
            <div class="row top-buffer">
                <div class="col-md-10">

                    <%--<CKEditor:CKEditorControl ID="BillTxt1" runat="server" ValidationGroup="SaveGroup" spellcheck="true"></CKEditor:CKEditorControl>--%>
                    <textarea id="BillTitleTxt" name="BillTitleTxt" style="height: 70px" class="form-control" validationgroup="SaveGroup" rows="10" runat="server"></textarea>
                    <script>
                        $(document).ready(function () {
                            $('#ContentPlaceHolder1_BillTitleTxt').summernote(
                                {
                                    tableClassName: function () {
                                        $(this).addClass('table table-bordered')

                                            .attr('cellpadding', 12)
                                            .attr('cellspacing', 0)
                                            .attr('border', 1)
                                            .css('borderCollapse', 'collapse')


                                        $(this).find('td')
                                            .css('borderColor', '#000')
                                            .css('padding', '5px')

                                    },
                                    height: 150
                                });
                        });
                    </script>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Enter Bill Text" ValidationGroup="SaveGroup" Display="None" ControlToValidate="BillTitleTxt"></asp:RequiredFieldValidator>

                    <%--<textarea id="BillTxt" class="form-control" rows="10" runat="server" required="required"></textarea>--%>
                </div>
            </div>
            <div class="row top-buffer">
                <div class="col-md-8">
                    <label class="control-lbl-sm">Bill Movers (Senators) (type a name and pick as many as needed)</label>
                    <div class="form-control member-multi" data-chips data-service="<%= ResolveUrl("~/Service.asmx/GetEmployeeName") %>" data-ids="#<%= HidMemberId.ClientID %>" data-names="#<%= MemberNameTxt.ClientID %>" data-placeholder="Type a senator name to add...">
                        <span class="member-chips"></span>
                        <input type="text" class="member-input" autocomplete="off" />
                    </div>
                    <asp:TextBox ID="MemberNameTxt" runat="server" Style="display: none" />
                    <asp:HiddenField ID="HidMemberId" runat="server" />
                    <asp:Label ID="err" runat="server" Text="" Style="color: red"></asp:Label>
                    <asp:ListBox ID="MoversLB" SelectionMode="Multiple" runat="server" Style="display: none"></asp:ListBox>
                </div>
                <%--  <div class="col-md-2">
                <asp:Label ID="Label2" runat="server" Style="font-weight: bold; font-size: 10pt">Change Notice File</asp:Label>
                <asp:FileUpload ID="NoticeUpload" runat="server" CssClass="btn btn-custom" Style="width: 250px;" data-scan="true" />
                <asp:HyperLink ID="NoticeLink" runat="server" CssClass="btn btn-info" style="margin-top:1px">Download Notice</asp:HyperLink>

            </div>--%>
            </div>
            <div class="row top-buffer">
                <div class="col-md-8">
                    <label class="control-lbl-sm">Bill Movers (MNAs) (type a name and pick as many as needed)</label>
                    <div class="form-control member-multi" data-chips data-service="<%= ResolveUrl("~/Service.asmx/GetMinisters") %>" data-ids="#<%= HidMinisterId.ClientID %>" data-names="#<%= MinisterNameTxt.ClientID %>" data-placeholder="Type an MNA name to add...">
                        <span class="member-chips"></span>
                        <input type="text" class="member-input" autocomplete="off" />
                    </div>
                    <asp:TextBox ID="MinisterNameTxt" runat="server" Style="display: none" />
                    <asp:HiddenField ID="HidMinisterId" runat="server" />
                    <asp:Label ID="MinisterErr" runat="server" Text="" Style="color: red"></asp:Label>
                    <asp:ListBox ID="MinistersLB" SelectionMode="Multiple" runat="server" Style="display: none"></asp:ListBox>
                </div>
            </div>
            <div class="row top-buffer">
                <div class="col-md-8">
                    <label class="control-lbl-sm">Ministries (type a name and pick as many as needed)</label>
                    <div class="form-control member-multi" data-chips data-service="<%= ResolveUrl("~/Service.asmx/GetCurrentDivisionsByName") %>" data-ids="#<%= HidMinistryId.ClientID %>" data-names="#<%= MinistryTxt.ClientID %>" data-placeholder="Type a ministry name to add...">
                        <span class="member-chips"></span>
                        <input type="text" class="member-input" autocomplete="off" />
                    </div>
                    <asp:TextBox ID="MinistryTxt" runat="server" Style="display: none" />
                    <asp:HiddenField ID="HidMinistryId" runat="server" />
                    <asp:Label ID="err2" runat="server" Text="" Style="color: red"></asp:Label>
                    <asp:ListBox ID="MinistryLB" SelectionMode="Multiple" runat="server" Style="display: none"></asp:ListBox>
                </div>

                <%--  <div class="col-md-2">
                <asp:Label ID="Label1" runat="server" Style="font-weight: bold; font-size: 10pt">Change Bill File</asp:Label>
                <asp:FileUpload ID="BillUpload" runat="server" CssClass="btn btn-custom" Style="width: 250px;" data-scan="true" />
                <asp:HyperLink ID="BillLink" runat="server" CssClass="btn btn-info"  style="margin-top:1px">Download Bill</asp:HyperLink>
            </div>--%>
            </div>
            <div class="row top-buffer">
                <div class="col-md-10">
                    <label class="control-lbl-sm">Remarks:</label>
                </div>
            </div>
            <div class="row">
                <div class="col-md-10">
                    <textarea id="BillRemarksTxt" name="BillRemarksTxt" style="height: 70px" class="form-control" validationgroup="SaveGroup" rows="10" runat="server"></textarea>
                    <script>
                        $(document).ready(function () {
                            $('#ContentPlaceHolder1_BillRemarksTxt').summernote(
                                {
                                    tableClassName: function () {
                                        $(this).addClass('table table-bordered')

                                            .attr('cellpadding', 12)
                                            .attr('cellspacing', 0)
                                            .attr('border', 1)
                                            .css('borderCollapse', 'collapse')


                                        $(this).find('td')
                                            .css('borderColor', '#000')
                                            .css('padding', '5px')

                                    },
                                    height: 150
                                });
                        });
                    </script>
                </div>
            </div>

            <div class="row">
                <div class="col-md-10"></div>
                <div class="col-md-2">
                    <asp:Button ID="Button2" runat="server" Text="Update" ValidationGroup="SaveGroup" OnClick="Button1_Click" class="btn btn-custom" /></div>
            </div>
        </div>

    </section>




    <section id="CommitteeDetails">
        <div class="container  regularDiv">
            <h4 class="bd-title"><span class="glyphicon glyphicon-briefcase"></span>Committee Stage</h4>
            <div class="row top-buffer">
                <div class="col-md-2">
                    <label class="control-lbl-sm" for="LegislationDiaryDateTxt">Introduced in House On:</label>
                    <asp:TextBox ID="IntroducedInHouseOnTxt" class="form-control small-control datepicker js-date" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" Style="color: orangered" runat="server" ErrorMessage="Enter Date" ValidationGroup="CommitteeSaveGroup" Display="Dynamic" ControlToValidate="IntroducedInHouseOnTxt"></asp:RequiredFieldValidator>
                </div>
                <div class="col-md-2">
                    <label class="control-lbl-sm" for="CategoryDDL">Introduced in Session:</label>
                    <asp:DropDownList ID="IntroduceSessionDDL" class="form-control small-control" runat="server" ValidationGroup="Group1">
                    </asp:DropDownList>
                </div>
            </div>
            <div class="row top-buffer">
                <div class="col-md-5">
                    <label class="control-lbl-sm" for="CategoryDDL">Refered to Committee:</label>
                    <asp:DropDownList ID="CommitteeDDL" class="form-control small-control" runat="server" ValidationGroup="Group1">
                        <asp:ListItem Value="0">Select</asp:ListItem>
                    </asp:DropDownList>
                </div>
                  <div class="col-md-2">
                <label class="control-lbl-sm" for="SenatorDDL">Refered On:</label>
                <asp:TextBox ID="CommitteeRefDateTxt" runat="server" CssClass="form-control datepicker js-date" />
            </div>
                <div class="col-md-2">
                    <label class="control-lbl-sm" for="SenatorDDL">Time limit for report (Days):</label>
                    <asp:TextBox TextMode="Number" ID="CommitteeTimeLimitTxt" runat="server" CssClass="form-control" />
                </div>
            </div>
            <div class="row top-buffer">
                <div class="col-md-5">
                    <label class="control-lbl-sm" for="CategoryDDL">Committee Recomendation:</label>
                    <asp:DropDownList ID="CommitteeRecomendationDDL" class="form-control small-control" runat="server" ValidationGroup="Group1">
                        <asp:ListItem Value="0">Select</asp:ListItem>
                        <asp:ListItem Value="1">Ammended By Standing Committee</asp:ListItem>
                        <asp:ListItem Value="2">May be Passed as Introduced in the House</asp:ListItem>
                        <asp:ListItem Value="3">Passed without sending to Committee</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="col-md-2">
                    <label class="control-lbl-sm" for="SenatorDDL">Report Presentation Date:</label>
                    <asp:TextBox ID="CommitteeReportDateTxt" runat="server" CssClass="form-control datepicker js-date" />
                </div>
                <%--  <div class="col-md-2">
                <label class="control-lbl-sm" for="SenatorDDL">Committee Report</label>
                <asp:HyperLink ID="CommitteeReportLink" runat="server" CssClass="btn btn-info">Download Committee Report</asp:HyperLink>
            </div>--%>
            </div>
            <div class="row">
                <div class="row top-buffer">
                    <div class="col-md-10" style="margin-left: 10px; margin-right: 10px;">
                        <%--    <label class="control-lbl-sm" for="SenatorDDL">Committee Remarks:</label>
                <textarea id="CommitteeRemarksTxt" name="CommitteeRemarksTxt" style="height:30px" class="form-control" validationgroup="SaveGroup" rows="5" runat="server"></textarea>
                <script>
                    $(document).ready(function () {
                        $('#ContentPlaceHolder1_CommitteeRemarksTxt').summernote(
                            {
                                tableClassName: function () {
                                    $(this).addClass('table table-bordered')

                                        .attr('cellpadding', 12)
                                        .attr('cellspacing', 0)
                                        .attr('border', 1)
                                        .css('borderCollapse', 'collapse');

                                    $(this).find('td')
                                        .css('borderColor', '#000')
                                        .css('padding', '5px');
                                },
                                height: 150
                            });
                    });
                </script>--%>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-10"></div>
                    <div class="col-md-2">
                        <asp:Button ID="UpdateCommitteeDetailsBtn" runat="server" Text="Update" ValidationGroup="CommitteeSaveGroup" OnClick="UpdateCommitteeDetailsBtn_Click" class="btn btn-custom" /></div>
                </div>
            </div>
        </div>
    </section>

    <section id="MemberDetails">
        <div class="container  regularDiv">
            <h4 class="bd-title"><span class="glyphicon glyphicon-user"></span>Member Passage / Withdrawal</h4>
            <div class="row top-buffer">
                <div class="col-md-3">
                    <label class="control-lbl-sm" for="CategoryDDL">Memeber Passage/Withdrawal Status:</label>
                    <asp:DropDownList ID="MemberPassWithdrawStatusDDL" class="form-control small-control" runat="server" ValidationGroup="Group1">
                        <asp:ListItem Value="0">Select</asp:ListItem>
                        <asp:ListItem Value="1">Passage</asp:ListItem>
                        <asp:ListItem Value="2">Withdrawal</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="col-md-3">
                    <label class="control-lbl-sm" for="SenatorDDL">Memeber Passage/Withdrawal Notice Date:</label>
                    <asp:TextBox ID="PassWithdrawDateTxt" runat="server" CssClass="form-control datepicker js-date" />
                </div>

                <div class="col-md-3">
                    <label class="control-lbl-sm" for="SenatorDDL">Date of consideration of the Bill:</label>
                    <asp:TextBox ID="HouseForConsiderationDate" runat="server" CssClass="form-control datepicker js-date" />
                </div>

                <div class="col-md-2">
                    <label class="control-lbl-sm" for="CategoryDDL">Consideration in Session:</label>
                    <asp:DropDownList ID="ConsiderationSessionDDL" class="form-control small-control" runat="server" ValidationGroup="Group1">
                    </asp:DropDownList>
                </div>
            </div>
            <div class="row">
                <div class="row top-buffer">
                    <div class="col-md-10" style="margin-left: 10px; margin-right: 10px;">
                        <%-- <label class="control-lbl-sm" for="SenatorDDL">Remarks:</label>
                <textarea id="MemberRemarksTxt" name="RemarksTxt" style="height:30px" class="form-control" validationgroup="SaveGroup" rows="5" runat="server"></textarea>
                <script>
                    $(document).ready(function () {
                        $('#ContentPlaceHolder1_MemberRemarksTxt').summernote(
                            {
                                tableClassName: function () {
                                    $(this).addClass('table table-bordered')

                                        .attr('cellpadding', 12)
                                        .attr('cellspacing', 0)
                                        .attr('border', 1)
                                        .css('borderCollapse', 'collapse');

                                    $(this).find('td')
                                        .css('borderColor', '#000')
                                        .css('padding', '5px');
                                },
                                height: 150
                            });
                    });
                </script>--%>
                    </div>
                    <div class="col-md-2">
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-10"></div>
                <div class="col-md-2">
                    <asp:Button ID="UpdateMemberPassageDetailsBtn" runat="server" Text="Update" ValidationGroup="SaveGroup" OnClick="UpdateMemberPassageDetailsBtn_Click" class="btn btn-custom" /></div>
            </div>
        </div>
    </section>

    <section id="NADetails">
        <div class="container  regularDiv">
            <h4 class="bd-title"><span class="glyphicon glyphicon-transfer"></span>National Assembly Stage</h4>
            <div class="row top-buffer">
                <div class="col-md-3">
                    <label class="control-lbl-sm" for="LegislationDiaryDateTxt">Date of Passage by Senate:</label>
                    <asp:TextBox ID="SenatePassageDate" class="form-control small-control datepicker js-date" runat="server"></asp:TextBox>
                </div>
                <div class="col-md-3">
                    <label class="control-lbl-sm" for="LegislationDiaryDateTxt">Date of Transmission to NA:</label>
                    <asp:TextBox ID="ToNAMessageDate" class="form-control small-control datepicker js-date" runat="server"></asp:TextBox>
                </div>
                <div class="col-md-3">
                    <label class="control-lbl-sm" for="LegislationDiaryDateTxt">Date of Receipt of Message from NA:</label>
                    <asp:TextBox ID="FromNAMessageDate" class="form-control small-control datepicker js-date" runat="server"></asp:TextBox>
                </div>
                <div class="col-md-3">
                    <label class="control-lbl-sm" for="LegislationDiaryDateTxt">Date of Passage by NA:</label>
                    <asp:TextBox ID="PassedByNADate" class="form-control small-control datepicker js-date" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="row top-buffer">
                    <div class="col-md-10" style="margin-left: 10px; margin-right: 10px;">
                        <%-- <label class="control-lbl-sm" for="SenatorDDL">Remarks:</label>
                        <textarea id="NARemarksTxt" name="NARemarksTxt" style="height:30px" class="form-control" validationgroup="SaveGroup" rows="5" runat="server"></textarea>
                        <script>
                            $(document).ready(function () {
                                $('#ContentPlaceHolder1_NARemarksTxt').summernote(
                                    {
                                        tableClassName: function () {
                                            $(this).addClass('table table-bordered')

                                                .attr('cellpadding', 12)
                                                .attr('cellspacing', 0)
                                                .attr('border', 1)
                                                .css('borderCollapse', 'collapse');

                                            $(this).find('td')
                                                .css('borderColor', '#000')
                                                .css('padding', '5px');
                                        },
                                        height: 150
                                    });
                            });
                        </script>--%>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-10"></div>
                <div class="col-md-2">
                    <asp:Button ID="UpdateNADetailsBtn" runat="server" Text="Update" ValidationGroup="SaveGroup" OnClick="UpdateNADetailsBtn_Click" class="btn btn-custom" /></div>
            </div>
        </div>
    </section>

    <section id="SearchableContents">
        <div class="container  regularDiv">
            <h4 class="bd-title"><span class="glyphicon glyphicon-align-justify"></span>Bill Contents (English)</h4>
            <div class="bd-hint">Type or paste the full text of the bill. Formatting (headings, numbering, tables) is kept, and the text is used by the search.</div>
            <div class="row">
                <div class="col-md-12 bd-editor">
                    <textarea id="SubjectTxt" name="BillTxt" style="height: 300px" class="form-control" validationgroup="SaveGroup" rows="10" runat="server"></textarea>
                    <asp:RequiredFieldValidator ID="rfvBillTxt" runat="server" CssClass="nf-err" ErrorMessage="Enter Bill Text" ValidationGroup="SaveGroup" Display="None" ControlToValidate="SubjectTxt"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="bd-savebar">
                <asp:Button ID="Button1" runat="server" Text="Update Bill Contents" ValidationGroup="SaveGroup" OnClick="Button1_Click" class="btn btn-custom" />
            </div>
        </div>
    </section>

    <section id="BillDocuments">
        <div class="container  regularDiv">
            <h4 class="bd-title"><span class="glyphicon glyphicon-paperclip"></span>Bill Documents <span class="bd-count"><%= DriversLV.Items.Count %></span></h4>

            <div class="bd-upload">
                <div class="row">
                    <div class="col-md-3 col-sm-6">
                        <label class="control-lbl-sm" for="<%= DocumentTypeDDL.ClientID %>">Document Type</label>
                        <asp:DropDownList ID="DocumentTypeDDL" class="form-control small-control" runat="server">
                            <asp:ListItem Value="0">Select</asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator CssClass="nf-err" ID="RequiredFieldValidator4" ControlToValidate="DocumentTypeDDL" ValidationGroup="g1" InitialValue="0" Display="Dynamic" runat="server" ErrorMessage="Select document type"></asp:RequiredFieldValidator>
                    </div>
                    <div class="col-md-3 col-sm-6">
                        <label class="control-lbl-sm" for="<%= DocumentDateTxt.ClientID %>">Document Date</label>
                        <asp:TextBox ID="DocumentDateTxt" ValidationGroup="g1" data-max-date="0" class="form-control small-control js-date" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator CssClass="nf-err" ID="RequiredFieldValidator6" ControlToValidate="DocumentDateTxt" ValidationGroup="g1" Display="Dynamic" runat="server" ErrorMessage="Enter date"></asp:RequiredFieldValidator>
                    </div>
                    <div class="col-md-6">
                        <label class="control-lbl-sm">Attach Document</label>
                        <div class="bd-drop" id="bdDrop">
                            <asp:FileUpload ID="BillDocumentFileUpload" CssClass="bd-file" runat="server" data-scan="true" />
                            <span class="glyphicon glyphicon-cloud-upload bd-drop-icon"></span>
                            <div class="bd-drop-text" id="bdDropText">Click to choose a file, or drag it here</div>
                            <div class="bd-drop-hint">PDF, Word, Excel, JPG or PNG &middot; up to 25 MB</div>
                        </div>
                        <asp:RequiredFieldValidator CssClass="nf-err" runat="server" Display="Dynamic" ErrorMessage="Attach a file" ControlToValidate="BillDocumentFileUpload" ValidationGroup="g1"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-9">
                        <label class="control-lbl-sm" for="<%= DocumentDescTxt.ClientID %>">Document Description</label>
                        <asp:TextBox ID="DocumentDescTxt" ValidationGroup="g1" TextMode="MultiLine" Rows="2" class="form-control" runat="server" Text=''></asp:TextBox>
                        <asp:RequiredFieldValidator CssClass="nf-err" ID="RequiredFieldValidator2" ControlToValidate="DocumentDescTxt" ValidationGroup="g1" Display="Dynamic" runat="server" ErrorMessage="Enter document description"></asp:RequiredFieldValidator>
                    </div>
                    <div class="col-md-3 bd-upload-btn">
                        <asp:Button ID="UploadDocumentBtn" runat="server" ValidationGroup="g1" CommandName="new" Text="Upload Document" class="btn btn-custom btn-block" OnClick="UploadBtn_Click" />
                    </div>
                </div>
                <asp:Label runat="server" CssClass="nf-err" ID="errorlbl"></asp:Label>
                <div class="nf-err" id="bdClientErr"></div>
            </div>

            <table class="table table-hover bd-table">
                <thead>
                    <tr>
                        <th>Sr#</th>
                        <th>Description</th>
                        <th>Type</th>
                        <th>Date</th>
                        <th>File</th>
                        <th>Action</th>
                    </tr>
                </thead>
                <tbody>
                    <asp:ListView ID="DriversLV" runat="server"
                        OnItemEditing="DriversLV_ItemEditing"
                        OnItemUpdating="DriversLV_ItemUpdating"
                        OnItemCanceling="DriversLV_ItemCanceling"
                        OnItemDataBound="ItemDataBound"
                        OnItemCreated="ItemCreated">
                        <ItemTemplate>
                            <tr>
                                <td class="itemCent">
                                    <asp:HiddenField ID="HidDocumentId" runat="server" Value='<%#Bind("DocumentId")%>' />
                                    <asp:Label ID="SrNo" runat="server" Text='<%#Container.DataItemIndex + 1%>'></asp:Label></td>
                                <td class="itemLeft bd-desc">
                                    <asp:Label ID="Description" runat="server" Text='<%#Eval("DocumentDescription")%>'></asp:Label></td>
                                <td class="itemLeft">
                                    <span class="bd-type"><asp:Label ID="Label3" runat="server" Text='<%#Eval("DocumentType")%>'></asp:Label></span></td>
                                <td class="itemLeft">
                                    <asp:Label ID="Label4" runat="server" Text='<%#Eval("AttachmentDate", "{0:dd/MM/yyyy}")%>'></asp:Label></td>
                                <td class="itemLeft">
                                    <asp:HyperLink ID="HyperLink1" runat="server" Target="_blank" CssClass="btn btn-default btn-sm" NavigateUrl='<%#Eval("Url")%>'><span class="glyphicon glyphicon-download-alt"></span> <%#FileLabel(Eval("Url"))%></asp:HyperLink>
                                </td>
                                <td class="itemCent">
                                    <asp:LinkButton ID="deleteImageButton" CssClass="btn btn-default btn-sm" runat="server" CommandName="edit" CausesValidation="false"
                                        ToolTip="Edit"><span class="glyphicon glyphicon-pencil"></span> Edit</asp:LinkButton>
                                </td>
                            </tr>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <tr class="bd-editrow">
                                <td class="itemCent">
                                    <asp:HiddenField ID="HidDocumentId" runat="server" Value='<%#Bind("DocumentId")%>' />
                                    <asp:HiddenField ID="HidDocumentTypeId" runat="server" Value='<%#Bind("DocumentTypeId")%>' />
                                    <asp:Label ID="Label1" runat="server" Text='<%#Container.DataItemIndex + 1%>'></asp:Label></td>
                                <td class="itemLeft">
                                    <asp:TextBox CssClass="form-control" ID="DocumentDescriptionTxt" TextMode="MultiLine" Rows="3" runat="server" Text='<%#Bind("DocumentDescription")%>'></asp:TextBox>
                                </td>
                                <td class="itemLeft">
                                    <asp:DropDownList ID="DocumentTypeDDL" class="form-control small-control" runat="server">
                                    </asp:DropDownList></td>
                                <td class="itemLeft">
                                    <asp:TextBox CssClass="form-control small-control js-date" ID="EditDateTxt" data-max-date="0" runat="server" Text='<%#Eval("AttachmentDate", "{0:dd/MM/yyyy}")%>'></asp:TextBox></td>
                                <td class="itemLeft">
                                    <asp:FileUpload CssClass="form-control" ID="FileUpload1" runat="server" data-scan="true" />
                                    <div class="nf-hint">Leave empty to keep the current file.</div>
                                    <asp:HiddenField ID="HidUrl" runat="server" Value='<%#Bind("Url")%>' />
                                </td>
                                <td class="itemCent bd-actions">
                                    <asp:LinkButton ID="updateBtn" CssClass="btn btn-custom btn-sm" runat="server" CommandName="update" CausesValidation="false"
                                        ToolTip="Save"><span class="glyphicon glyphicon-ok"></span> Save</asp:LinkButton>
                                    <asp:LinkButton ID="cancelBtn" CssClass="btn btn-default btn-sm" runat="server" CommandName="cancel" CausesValidation="false"
                                        ToolTip="Cancel"><span class="glyphicon glyphicon-remove"></span> Cancel</asp:LinkButton>
                                </td>
                            </tr>
                        </EditItemTemplate>
                        <EmptyDataTemplate>
                            <tr>
                                <td colspan="6" class="bd-empty"><span class="glyphicon glyphicon-folder-open"></span>No documents attached yet</td>
                            </tr>
                        </EmptyDataTemplate>
                    </asp:ListView>
                </tbody>
            </table>
            <asp:ValidationSummary ID="ValidationSummary1"
                HeaderText="You must enter a value in the following fields:"
                DisplayMode="BulletList"
                EnableClientScript="true"
                ShowSummary="true"
                runat="server" ValidationGroup="Group1" ForeColor="#FF3300" />
        </div>
    </section>

    <br />
     <div class="container regularDiv">
        <div class="row">
            <div class="col-md-6">
                <table class="table table-condensed">
                   <tr>
                       <th>Action</th>
                       <th>User</th>
                   </tr>
                    <tr>
                        <td>Inserted By</td>
                        <td>  <asp:Label ID="InsertedByLbl" class="control-lbl-sm"  runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td>Updated By</td>
                        <td> <asp:Label ID="UpdatedByLbl" class="control-lbl-sm"  runat="server"></asp:Label></td>
                    </tr>
                   <%-- <tr>
                        <td>Sent for translation By</td>
                        <td><asp:Label ID="SentForTransByLbl" class="control-lbl-sm"  runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td>Translation Approved By </td>
                        <td><asp:Label ID="TransApprovedByLbl" class="control-lbl-sm"  runat="server"></asp:Label></td>
                    </tr>--%>
                     <tr>
                        <td>Deleted By</td>
                        <td><asp:Label ID="DeletedByLbl" class="control-lbl-sm"  runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td>Recovered By </td>
                        <td><asp:Label ID="RecoveredByLbl" class="control-lbl-sm"  runat="server"></asp:Label></td>
                    </tr>
                  
                </table>
            </div>
        </div>
    </div>

    <section id="StatusHistory">
        <div class="container">
            <div class="row">
                <div class="col-md-6">
                    <div><b>Status History</b></div>
                    <table class="table table-hover table-striped table-responsive">
                        <thead class="thead-inverse">
                            <tr>
                                <th>Sr#</th>
                                <th>Status</th>
                                <th>Status Date</th>
                                <th>User</th>

                            </tr>
                        </thead>
                        <tbody>
                            <asp:ListView ID="BillStatusHistoryLV" runat="server">

                                <ItemTemplate>
                                    <tr>
                                        <td>

                                            <asp:Label ID="Label3" class="table-data" runat="server" Text='<%#Container.DataItemIndex + 1%> ' />
                                        </td>
                                        <td>
                                            <asp:Label ID="Label4" class="table-data" runat="server" Text='<%#Bind("BillStatus")%>' />
                                        </td>

                                        <td>
                                            <asp:Label ID="Label6" class="table-data" runat="server" Text='<%#GetDate(Convert.ToDateTime(Eval("StatusDate")))%>' />
                                        </td>
                                        <td>
                                            <asp:Label ID="Label8" class="table-data" runat="server" Text='<%#Eval("UpdatedBy")%>' />
                                        </td>

                                    </tr>
                                </ItemTemplate>

                            </asp:ListView>
                        </tbody>
                    </table>
                </div>
            </div>
        </div>
    </section>
    <br />



    <script type="text/javascript">
        $(function () {
            $(".datepicker").datepicker({
                beforeShow: function () {
                    setTimeout(function () {
                        $('.ui-datepicker').css('z-index', 99999999999999);
                    }, 0);
                },
                dateFormat: 'dd/mm/yy',
                changeYear: true,
                changeMonth: true,
                maxDate: 0,
                onSelect: function (dateText, inst) { }
            });
        });
        //$('#ContentPlaceHolder3_NoticeDiaryTimeTxt').timepicker({
        //    template: false,
        //    showInputs: false,
        //    defaultTime: false,
        //    minuteStep: 5
        //});



        //$(document).ready(function () {
        //    $('.date').mask('00/00/0000');
        //});


        

        
        




    </script>

    <script type="text/javascript">
        (function ($) {
            // Rich text for the bill contents
            $(function () {
                var editor = $('#<%= SubjectTxt.ClientID %>');
                editor.summernote({
                    height: 460,
                    minHeight: 260,
                    placeholder: 'Bill text...',
                    toolbar: [
                        ['style', ['style']],
                        ['font', ['bold', 'italic', 'underline', 'strikethrough', 'clear']],
                        ['fontsize', ['fontsize']],
                        ['color', ['color']],
                        ['para', ['ul', 'ol', 'paragraph']],
                        ['table', ['table']],
                        ['insert', ['link', 'hr']],
                        ['view', ['undo', 'redo', 'fullscreen', 'codeview']]
                    ],
                    fontSizes: ['10', '12', '14', '16', '18', '20', '24'],
                    tableClassName: function () {
                        $(this).addClass('table table-bordered')
                            .attr('cellpadding', 12).attr('cellspacing', 0).attr('border', 1)
                            .css('borderCollapse', 'collapse');
                        $(this).find('td').css('borderColor', '#000').css('padding', '5px');
                    }
                });
                // make sure the latest text is posted, even if the code view is open
                $('form').on('submit', function () {
                    if (editor.next('.note-editor').hasClass('codeview')) { editor.summernote('codeview.deactivate'); }
                    editor.val(editor.summernote('code'));
                });
            });

            // document upload: pick or drop a file
            $(function () {
                var allowed = ['pdf', 'doc', 'docx', 'xls', 'xlsx', 'jpg', 'jpeg', 'png'];
                var maxBytes = 25 * 1024 * 1024;
                var $drop = $('#bdDrop'), $text = $('#bdDropText'), $err = $('#bdClientErr');
                var $file = $('#<%= BillDocumentFileUpload.ClientID %>');
                var idle = $text.text();
                $drop.on('dragenter dragover', function () { $drop.addClass('over'); })
                     .on('dragleave drop', function () { $drop.removeClass('over'); });
                $file.on('change', function () {
                    $err.text('');
                    var f = this.files && this.files[0];
                    if (!f) { $drop.removeClass('has-file'); $text.text(idle); return; }
                    var ext = f.name.split('.').pop().toLowerCase();
                    if ($.inArray(ext, allowed) < 0) { $err.text('This file type is not allowed. Use PDF, Word, Excel, JPG or PNG.'); this.value = ''; $drop.removeClass('has-file'); $text.text(idle); return; }
                    if (f.size > maxBytes) { $err.text('The file is larger than 25 MB.'); this.value = ''; $drop.removeClass('has-file'); $text.text(idle); return; }
                    $drop.addClass('has-file');
                    $text.text(f.name + ' (' + (f.size / 1048576).toFixed(2) + ' MB)');
                });
            });

            // highlight the section being viewed in the jump bar
            $(function () {
                var links = $('#bdNav a');
                $(window).on('scroll', function () {
                    var y = $(window).scrollTop() + 160, current = null;
                    links.each(function () {
                        var t = $($(this).attr('href'));
                        if (t.length && t.offset().top <= y) { current = this; }
                    });
                    links.removeClass('active');
                    if (current) { $(current).addClass('active'); }
                });
            });
        })(jQuery);
    </script>
</asp:Content>
