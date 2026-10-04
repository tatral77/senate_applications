<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="NewBill.aspx.cs" Inherits="Legislation.NewBill" %>

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
                NEW BILL
            </div>
        </div>
    </div>

    <div class="container  regularDiv" id="#panel">
        <div class="row top-buffer">
            <asp:ValidationSummary ID="ValidationSummary3" DisplayMode="BulletList"
                EnableClientScript="true"
                HeaderText="You must enter a value in the following fields:" ValidationGroup="SaveGroup" ForeColor="OrangeRed" runat="server" />
            <div class="col-md-3">
                <label class="control-lbl-sm" for="SessionTxt">Parliamentary Year:</label>
                <asp:DropDownList ID="ParliamentaryYearDDL" class="form-control small-control" runat="server" ValidationGroup="Group1">
                </asp:DropDownList>
            </div>
               <div class="col-md-3">
                <label class="control-lbl-sm" for="SessionTxt">Session:</label>
                <asp:DropDownList ID="AssemblySessionDDL" class="form-control small-control" runat="server" ValidationGroup="Group1">
                </asp:DropDownList>
            </div>
              <%--  <div class="col-md-3">
                <label class="control-lbl-sm" for="SessionTxt">Originated In:</label>
                <asp:DropDownList ID="OriginatedInDDL" class="form-control small-control" runat="server" ValidationGroup="Group1">
                    <asp:ListItem Value="1">Senate</asp:ListItem>
                     <asp:ListItem Value="2">National Assembly</asp:ListItem>
                </asp:DropDownList>
            </div>--%>
            <div class="col-md-3 bootst">
                <label class="control-lbl-sm" for="LegislationDiaryNoTxt">File Number:</label>
                <asp:TextBox ID="FileNumberTxt" ValidationGroup="Group1" class="form-control small-control" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvLegislationDiaryNoTxt" runat="server" ErrorMessage="Enter Legislation Diary No." ValidationGroup="SaveGroup" Display="None" ControlToValidate="FileNumberTxt"></asp:RequiredFieldValidator>
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
                <label class="control-lbl-sm" for="LegislationDiaryDateTxt">Notice Date:</label>
                <asp:TextBox ID="NoticedateTxt" ValidationGroup="Group1" class="form-control small-control datepicker" runat="server"></asp:TextBox>
                <asp:Label ID="DateError" runat="server" Style="color: red" Text=""></asp:Label>
                <asp:RequiredFieldValidator ID="rfvLegislationDiaryDateTxt" runat="server" ErrorMessage="Enter Notice Date" ValidationGroup="SaveGroup" Display="None" ControlToValidate="NoticedateTxt"></asp:RequiredFieldValidator>
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
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Select Category" ValidationGroup="SaveGroup" Display="None" InitialValue="0" ControlToValidate="BillTypeDDL"></asp:RequiredFieldValidator>
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
                <asp:Label ID="Label2" runat="server" Style="font-weight: bold; font-size: 10pt">Notice File</asp:Label>
                <asp:FileUpload ID="NoticeUpload" runat="server" CssClass="btn btn-custom" Style="width: 250px;" data-scan="true" />
               <asp:Label ID="Label4" runat="server" Style="font-weight: bold; font-size: 10pt">Notice Date</asp:Label>
                <asp:TextBox ID="NoticeDocumentDate" class="form-control small-control datepicker" runat="server"></asp:TextBox>

            </div>--%>
        </div>
        <div class="row top-buffer">
            <div class="col-md-8">
                    <label class="control-lbl-sm">Bill Movers (MNA) (type a name and pick as many as needed)</label>
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
    </div>
    <div class="row top-buffer">
    </div>
    <div class="row top-buffer">
    </div>
    <div class="row">
        <div class="col-md-12" style="text-align: center">
            <asp:Label ID="Error" runat="server" Style="color: red"></asp:Label>
        </div>
    </div>
    <br />
    <div class="container">
    </div>
    <div class="container  regularDiv">
        <div class="row top-buffer">
            <div class="col-md-7">
                <label class="control-lbl-sm">English Text:</label>
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

                <%--<textarea id="BillTxt" class="form-control" rows="10" runat="server" required="required"></textarea>--%>
            </div>
        </div>
     
    </div>


    <br />
    <div class="container">
        <div class="col-md-12" style="text-align: center">
            <asp:Button ID="Button1" runat="server" Text="Save" ValidationGroup="SaveGroup" OnClick="Button1_Click" class="btn btn-custom" />
            <%-- <asp:Button ID="PrintBtn" Target="_blank" runat="server" ValidationGroup="SaveGroup" Text="Print" CssClass="btn btn-custom" OnClick="PrintBtn_Click" />--%>
        </div>
    </div>

    <br />



    <script type="text/javascript">

        //$('#ContentPlaceHolder3_NoticeDiaryTimeTxt').timepicker({
        //    template: false,
        //    showInputs: false,
        //    defaultTime: false,
        //    minuteStep: 5
        //});



        //$(document).ready(function () {
        //    $('.date').mask('00/00/0000');
        //});
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

        

        

        



    </script>
</asp:Content>
