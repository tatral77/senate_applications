<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" ValidateRequest="false" MaintainScrollPositionOnPostback="true" AutoEventWireup="true" CodeBehind="NABillDetail.aspx.cs" Inherits="Legislation.NABillDetail" %>

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
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md-12 page-header">
                BILL DETAILS
            </div>
        </div>
    </div>


    <section id="BasicDetails">
        <div class="container  regularDiv" id="#panel">

             <asp:ValidationSummary ID="ValidationSummary3" DisplayMode="BulletList"
                EnableClientScript="true"
                HeaderText="You must enter a value in the following fields:" ValidationGroup="SaveGroup" ForeColor="OrangeRed" runat="server" />

               <div class="col-md-2">
                    <label class="control-lbl-sm" for="BillIdTxt">Bill Id:</label>
                    <asp:TextBox ID="BillIdTxt" ReadOnly="true" class="form-control small-control" runat="server"></asp:TextBox>

                </div>
        <div class="row top-buffer">
           
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
                <label class="control-lbl-sm" for="LegislationDiaryNoTxt">File Number:</label>
                <asp:TextBox ID="FileNumberTxt" ValidationGroup="Group1" class="form-control small-control" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvLegislationDiaryNoTxt" runat="server" ErrorMessage="Enter Legislation Diary No." ValidationGroup="SaveGroup" Display="None" ControlToValidate="FileNumberTxt"></asp:RequiredFieldValidator>
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
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ErrorMessage="Enter Status Date" ValidationGroup="SaveGroup" Display="None" ControlToValidate="StatusDateTxt"></asp:RequiredFieldValidator>
                </div>
              <div class="col-md-2">
                <label class="control-lbl-sm" for="BillCategoryDDL">Bill Category:</label>
                <asp:DropDownList ID="BillCategoryDDL" class="form-control small-control" runat="server" ValidationGroup="Group1">
                    <asp:ListItem Value="0">Select</asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="rfvCategoryDDL" runat="server" ErrorMessage="Select Category" ValidationGroup="SaveGroup" Display="None" InitialValue="0" ControlToValidate="BillCategoryDDL"></asp:RequiredFieldValidator>
            </div>
            <div class="col-md-2">
                <label class="control-lbl-sm" for="BillTypeDDL">Bill Type:</label>
                <asp:DropDownList ID="BillTypeDDL" class="form-control small-control" runat="server" ValidationGroup="Group1">
                    <asp:ListItem Value="0">Select</asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="Select Category" ValidationGroup="SaveGroup" Display="None" InitialValue="0" ControlToValidate="BillTypeDDL"></asp:RequiredFieldValidator>
            </div>
                <div class="col-md-2">
                    <label class="control-lbl-sm" for="IsActiveDDL">Is Active:</label>
                    <asp:DropDownList ID="IsActiveDDL" class="form-control small-control" runat="server">
                        <asp:ListItem Value="1">Yes</asp:ListItem>
                        <asp:ListItem Value="0">No</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="col-md-2">
                <label class="control-lbl-sm" for="LegislationDiaryDateTxt">Passed by NA Date:</label>
                <asp:TextBox ID="PassedByNADateTxt" ValidationGroup="Group1" class="form-control small-control datepicker js-date" runat="server"></asp:TextBox>
                <asp:Label ID="Label1" runat="server" Style="color: red" Text=""></asp:Label>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Enter Passed by NA date" ValidationGroup="SaveGroup" Display="None" ControlToValidate="PassedByNADateTxt"></asp:RequiredFieldValidator>
            </div>
             <div class="col-md-2">
                <label class="control-lbl-sm" for="LegislationDiaryDateTxt">Date of receipt of Message from NA:</label>
                <asp:TextBox ID="NAMessageReceiptDateTxt" ValidationGroup="Group1" class="form-control small-control datepicker js-date" runat="server"></asp:TextBox>
                <asp:Label ID="Label2" runat="server" Style="color: red" Text=""></asp:Label>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"  ErrorMessage="Enter Message Receipt date" ValidationGroup="SaveGroup" Display="None" ControlToValidate="NAMessageReceiptDateTxt"></asp:RequiredFieldValidator>
            </div>
            <%--  <div class="col-md-3 bootstrap-timepicker">
                <label class="control-lbl-sm" for="LegislationDiaryTimeTxt">Legislation Diary Time:</label>
                <asp:TextBox ID="LegislationDiaryTimeTxt" ValidationGroup="Group1" Required="true" class="form-control small-control" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvLegislationDiaryTimeTxt" runat="server" ErrorMessage="Enter Legislation Diary Time" ValidationGroup="SaveGroup" Display="None" ControlToValidate="LegislationDiaryTimeTxt"></asp:RequiredFieldValidator>
            </div>--%>
           <%-- <div class="col-md-3">
                <label class="control-lbl-sm">Bill Diary No:</label>
                <asp:TextBox ID="BillDiaryNoTxt" class="form-control small-control" runat="server"></asp:TextBox>
            </div>--%>
        </div>

        <div class="row top-buffer">

         
              <div class="col-md-3">
                <label class="control-lbl-sm" for="LegislationDiaryDateTxt">Bill Circulation Date:</label>
                <asp:TextBox ID="BillCirculationDateTxt" ValidationGroup="Group1" class="form-control small-control datepicker js-date" runat="server"></asp:TextBox>
                <asp:Label ID="Label3" runat="server" Style="color: red" Text=""></asp:Label>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="Enter Bill Circulation Date" ValidationGroup="SaveGroup" Display="None" ControlToValidate="BillCirculationDateTxt"></asp:RequiredFieldValidator>
            </div>
               <div class="col-md-3">
                <label class="control-lbl-sm" for="LegislationDiaryDateTxt">Member Notice Receipt Date:</label>
                <asp:TextBox ID="NoticeReceiptDateTxt" ValidationGroup="Group1" class="form-control small-control datepicker js-date" runat="server"></asp:TextBox>
                <asp:Label ID="DateError" runat="server" Style="color: red" Text=""></asp:Label>
                <%--<asp:RequiredFieldValidator ID="rfvLegislationDiaryDateTxt" runat="server" ErrorMessage="Enter Notice Receipt Date" ValidationGroup="SaveGroup" Display="None" ControlToValidate="NoticeReceiptDateTxt"></asp:RequiredFieldValidator>--%>
            </div>
             <div class="col-md-3">
                <label class="control-lbl-sm" for="LegislationDiaryDateTxt">Notice Circulation Date:</label>
                <asp:TextBox ID="NoticeCirculationDateTxt" ValidationGroup="Group1" class="form-control small-control datepicker js-date" runat="server"></asp:TextBox>
                <asp:Label ID="Label4" runat="server" Style="color: red" Text=""></asp:Label>
                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="Enter Notice Circulation Date" ValidationGroup="SaveGroup" Display="None" ControlToValidate="NoticeCirculationDateTxt"></asp:RequiredFieldValidator>--%>
            </div>
           
          
                         <%--   <div class="col-md-2">
                <label class="control-lbl-sm" for="CategoryDDL">Originated By:</label>
                <asp:DropDownList ID="OriginatedByDDL" class="form-control small-control" runat="server" ValidationGroup="Group1">
                    <asp:ListItem Value="0">Select</asp:ListItem>
                     <asp:ListItem Value="1">Senate</asp:ListItem>
                     <asp:ListItem Value="2">National Assembly</asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Select Category" ValidationGroup="SaveGroup" Display="None" InitialValue="0" ControlToValidate="OriginatedByDDL"></asp:RequiredFieldValidator>
            </div>
<div class="col-md-3">
                <label class="control-lbl-sm" for="CategoryDDL">Concerned Committee:</label>
                <asp:DropDownList ID="CommitteeDDL" class="form-control small-control" runat="server" ValidationGroup="Group1">
                    <asp:ListItem Value="0">Select</asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Select Category" ValidationGroup="SaveGroup" Display="None" InitialValue="0" ControlToValidate="CommitteeDDL"></asp:RequiredFieldValidator>
            </div>--%>
        </div>
        <div class="row top-buffer">
            <div class="col-md-7">
                <label class="control-lbl-sm">Bill Title:</label>
            </div>
        </div>
        <div class="row top-buffer">
            <div class="col-md-12">

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
                                        .css('borderCollapse', 'collapse');

                                    $(this).find('td')
                                        .css('borderColor', '#000')
                                        .css('padding', '5px');
                                },
                                height: 300
                            });
                    });
                </script>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ErrorMessage="Enter Bill Text" ValidationGroup="SaveGroup" Display="None" ControlToValidate="BillTitleTxt"></asp:RequiredFieldValidator>

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
                <asp:Label ID="Label2" runat="server" Style="font-weight: bold; font-size: 10pt">Notice File</asp:Label>
                <asp:FileUpload ID="NoticeUpload" runat="server" CssClass="btn btn-custom" Style="width: 250px;" data-scan="true" />
               <asp:Label ID="Label4" runat="server" Style="font-weight: bold; font-size: 10pt">Notice Date</asp:Label>
                <asp:TextBox ID="NoticeDocumentDate" class="form-control small-control datepicker" runat="server"></asp:TextBox>

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

             <%-- <div class="col-md-2">
                <asp:Label ID="Label1" runat="server" Style="font-weight: bold; font-size: 10pt">Bill File</asp:Label>
                <asp:FileUpload ID="BillUpload" runat="server" CssClass="btn btn-custom" Style="width: 250px;" data-scan="true" />
               <asp:Label ID="Label3" runat="server" Style="font-weight: bold; font-size: 10pt">Bill Date</asp:Label>
                  <asp:TextBox ID="BillDocumentDate"  class="form-control small-control datepicker" runat="server"></asp:TextBox>
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
            <div class="row top-buffer">
                <div class="col-md-2">
                    <label class="control-lbl-sm" for="LegislationDiaryDateTxt">Layed in House On:</label>
                    <asp:TextBox ID="IntroducedInHouseOnTxt" class="form-control small-control datepicker js-date" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" Style="color: orangered" runat="server" ErrorMessage="Enter Date" ValidationGroup="CommitteeSaveGroup" Display="Dynamic" ControlToValidate="IntroducedInHouseOnTxt"></asp:RequiredFieldValidator>
                </div>
                <div class="col-md-2">
                    <label class="control-lbl-sm" for="CategoryDDL">Layed in Session:</label>
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
                    <label class="control-lbl-sm" for="LegislationDiaryDateTxt">Date of assent by the President:</label>
                    <asp:TextBox ID="PresidentAccentDateTxt" class="form-control small-control datepicker js-date" runat="server"></asp:TextBox>
                </div>
                    <div class="col-md-3">
                    <label class="control-lbl-sm" for="LegislationDiaryDateTxt">Date of publish in the Gazette:</label>
                    <asp:TextBox ID="GazettePublishDateTxt" class="form-control small-control datepicker js-date" runat="server"></asp:TextBox>
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
            <div class="row top-buffer">
                <div class="col-md-7">
                    <label class="control-lbl-sm">Bill Contents (English):</label>
                </div>

            </div>
            <div class="row top-buffer">
                <div class="col-md-12">

                    <%--<CKEditor:CKEditorControl ID="BillTxt1" runat="server" ValidationGroup="SaveGroup" spellcheck="true"></CKEditor:CKEditorControl>--%>
                    <textarea id="SubjectTxt" name="BillTxt" style="height: 300px" class="form-control" validationgroup="SaveGroup" rows="10" runat="server"></textarea>
                    <script>
                        $(document).ready(function () {
                            $('#ContentPlaceHolder1_BillTxt').summernote(
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
                                    height: 300
                                });
                        });
                    </script>
                    <asp:RequiredFieldValidator ID="rfvBillTxt" runat="server" ErrorMessage="Enter Bill Text" ValidationGroup="SaveGroup" Display="None" ControlToValidate="SubjectTxt"></asp:RequiredFieldValidator>

                </div>
            </div>
            <div class="row top-buffer">
                <div class="col-md-10"></div>
                <div class="col-md-2">
                    <asp:Button ID="Button1" runat="server" Text="Update" ValidationGroup="SaveGroup" OnClick="Button1_Click" class="btn btn-custom" />
                    <%-- <asp:Button ID="PrintBtn" Target="_blank" runat="server" ValidationGroup="SaveGroup" Text="Print" CssClass="btn btn-custom" OnClick="PrintBtn_Click" />--%>
                </div>
            </div>

        </div>



    </section>

    <section id="BillDocuments">
        <div class="container  regularDiv">
            <div class="row top-buffer">
                <div class="col-md-7">
                    <label class="control-lbl-sm">Bill Documents:</label>
                </div>
            </div>
            <div class="row top-buffer">
                <div class="row" style="margin-left: 10px;">
                    <div class="col-md-6">
                        <asp:Label runat="server">Document Description</asp:Label>
                        <asp:TextBox ID="DocumentDescTxt" ValidationGroup="g1" TextMode="MultiLine" Rows="4" class="form-control" runat="server" Text=''></asp:TextBox>
                        <asp:RequiredFieldValidator Style="color: red;" ID="RequiredFieldValidator2" ControlToValidate="DocumentDescTxt" ValidationGroup="g1" runat="server" ErrorMessage="Enter document description"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="row" style="margin-left: 10px;">
                    <div class="col-md-4">
                        <asp:Label runat="server">Document Date</asp:Label>
                        <asp:TextBox ID="DocumentDateTxt" ValidationGroup="g1" class="form-control datepicker js-date" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator Style="color: red;" ID="RequiredFieldValidator6" ControlToValidate="DocumentDateTxt" ValidationGroup="g1" runat="server" ErrorMessage="Enter Date"></asp:RequiredFieldValidator>
                    </div>
                    <div class="col-md-2">
                        <asp:Label runat="server">Document Type</asp:Label>
                        <asp:DropDownList ID="DocumentTypeDDL" class="form-control small-control" runat="server">
                            <asp:ListItem Value="0">Select</asp:ListItem>

                        </asp:DropDownList>
                        <asp:RequiredFieldValidator Style="color: red;" ID="RequiredFieldValidator4" ControlToValidate="DocumentTypeDDL" ValidationGroup="g1" InitialValue="0" runat="server" ErrorMessage="Select Document Type"></asp:RequiredFieldValidator>
                    </div>
                    <div class="col-md-3">
                        <asp:Label runat="server">Attach Document</asp:Label>
                        <asp:FileUpload CssClass="btn btn-default" ID="BillDocumentFileUpload" runat="server" data-scan="true" />
                        <asp:RequiredFieldValidator ForeColor="Red" runat="server" Display="Dynamic" ErrorMessage="Attach File" ControlToValidate="BillDocumentFileUpload" ValidationGroup="g1">
                        </asp:RequiredFieldValidator>
                        <%--  <asp:RegularExpressionValidator ID="RegularExpressionValidator7"  
                             runat="server" ControlToValidate="BillDocumentFileUpload"  
                             ErrorMessage="Only .pdf, .doc, .jpg, .png formats are allowed." ForeColor="Red"  
                             ValidationExpression="/^(([a-zA-Z]:)|(\\{2}\w+)\$?)(\\(\w[\w].*))+(.pdf|.doc|.docx|.jpg|.png)$/"  
                             ValidationGroup="g1" SetFocusOnError="true"></asp:RegularExpressionValidator>  --%>
                    </div>
                    <div class="col-md-1">
                        <br />
                        <asp:Button ID="UploadDocumentBtn" runat="server" ValidationGroup="g1" CommandName="new" Text="Upload" class="btn btn-custom" OnClick="UploadBtn_Click" />
                    </div>
                </div>

                <div class="row" style="margin-top: 0px !important; margin-left: 10px;">
                    <div class="col-md-8" style="text-align: left">
                        <asp:Label runat="server" Style="color: red; font-weight: bold" ID="errorlbl"></asp:Label>
                    </div>
                </div>
                <div class="row" style="margin-left: 10px;">
                    <div class="col-md-10">
                        <table class="table table-condensed table-striped table-data">
                            <tr>
                                <th>Sr#</th>
                                <th>Document Description</th>
                                <th>File</th>
                                <th>Document Type</th>
                                <th>Document Date</th>
                                <%-- <th>Action</th>--%>
                            </tr>
                           <asp:ListView ID="DriversLV" runat="server"
                                OnItemEditing="DriversLV_ItemEditing"
                                OnItemUpdating="DriversLV_ItemUpdating"
                                OnItemDataBound="ItemDataBound"
                                OnItemCreated="ItemCreated"
                                >
                                <ItemTemplate>
                                    <tr>
                                       
                                        <td class="itemCent">
                                             <asp:HiddenField ID="HidDocumentId" runat="server" Value='<%#Bind("DocumentId")%>' />
                                            <asp:Label ID="SrNo" runat="server" Text='<%#Container.DataItemIndex + 1%> '></asp:Label></td>
                                        <td class="itemLeft" style="width: 50%">
                                            <asp:Label ID="Description" runat="server" Text='<%#Bind("DocumentDescription")%>'></asp:Label></td>
                                        <td class="itemLeft">
                                            <asp:HyperLink ID="HyperLink1" runat="server" Text="Download" NavigateUrl='<%#Eval("Url")%>'></asp:HyperLink>
                                        </td>
                                        <td class="itemLeft">
                                            <asp:Label ID="Label3" runat="server" Text='<%#Bind("DocumentType")%>'></asp:Label></td>
                                        </td>
                                         <td class="itemLeft">
                                             <asp:Label ID="Label4" runat="server" Text='<%#Bind("AttachmentDate")%>'></asp:Label></td>
                                        </td>
                                        <td class="itemCent">
                                            <asp:LinkButton ID="deleteImageButton" class="btn btn-custom" runat="server" CommandName="edit"
                                                ToolTip="Edit" ><span class="glyphicon glyphicon-pencil"></span></asp:LinkButton>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                                <EditItemTemplate>
                                      <tr>
                                        <asp:HiddenField ID="HidDocumentId" runat="server" Value='<%#Bind("DocumentId")%>' />
                                           <asp:HiddenField ID="HidDocumentTypeId" runat="server" Value='<%#Bind("DocumentTypeId")%>' />
                                        <td class="itemCent">
                                            <asp:Label ID="Label1" runat="server" Text='<%#Container.DataItemIndex + 1%> '></asp:Label></td>
                                        <td class="itemLeft" style="width: 50%">
                                            <asp:TextBox CssClass="form-control" ID="DocumentDescriptionTxt" runat="server" Text='<%#Bind("DocumentDescription")%>'></asp:TextBox>
                                        </td>
                                        <td class="itemLeft">
                                             <asp:FileUpload CssClass="btn btn-default" ID="FileUpload1" runat="server" data-scan="true" />
                                             <asp:HiddenField ID="HidUrl" runat="server" Value='<%#Bind("Url")%>' />
                                        </td>
                                        <td class="itemLeft">
                                              <asp:DropDownList ID="DocumentTypeDDL" class="form-control small-control" runat="server">
                                              </asp:DropDownList></td>
                                       <td class="itemLeft">
                                            <%-- <asp:Label ID="Label7" runat="server" Text='<%#Bind("AttachmentDate")%>'></asp:Label></td>--%>
                                        </td>
                                      <td class="itemCent">
                                            <asp:LinkButton ID="updateBtn" class="btn btn-custom" runat="server" CommandName="update"
                                                ToolTip="Update" ><span class="glyphicon glyphicon-save-file"></span></asp:LinkButton>
                                        </td>
                                    </tr>

                                </EditItemTemplate>
                                <EmptyDataTemplate>
                                    <tr>
                                        <td colspan="4" class="altCent" align="center">No Document available</td>
                                    </tr>
                                </EmptyDataTemplate>
                            </asp:ListView>

                            <tr>
                                <td align="left" colspan="4">
                                    <asp:ValidationSummary ID="ValidationSummary1"
                                        HeaderText="You must enter a value in the following fields:"
                                        DisplayMode="BulletList"
                                        EnableClientScript="true"
                                        ShowSummary="true"
                                        runat="server" ValidationGroup="Group1" ForeColor="#FF3300" />
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>



            </div>
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
</asp:Content>
