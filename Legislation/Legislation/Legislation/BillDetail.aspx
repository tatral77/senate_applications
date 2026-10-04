<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="BillDetail.aspx.cs" Inherits="Legislation.BillDetail" %>

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
                BILL DETAILS (ORIGINATED BY SENATE)
            </div>
        </div>
    </div>

    <div class="container  regularDiv" id="#panel">
        <div class="row top-buffer">
            <asp:ValidationSummary ID="ValidationSummary3" DisplayMode="BulletList"
                EnableClientScript="true"
                HeaderText="You must enter a value in the following fields:" ValidationGroup="SaveGroup" ForeColor="OrangeRed" runat="server" />
            <div class="col-md-2">
                <label class="control-lbl-sm" for="SessionTxt">Session No:</label>
                <asp:TextBox ReadOnly="true" ID="SessionTxt" class="form-control small-control" runat="server"></asp:TextBox>
                <asp:HiddenField ID="HidSessionNumber" runat="server" />
            </div>
              <div class="col-md-3 bootst">
                <label class="control-lbl-sm" for="BillIdTxt">Bill Id:</label>
                <asp:TextBox ID="BillIdTxt" ReadOnly="true" class="form-control small-control" runat="server"></asp:TextBox>

            </div>
            <div class="col-md-3 bootst">
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
                <label class="control-lbl-sm" for="LegislationDiaryDateTxt">Presented in House On:</label>
                <asp:TextBox ID="PresentedInHouseOnTxt" ValidationGroup="Group1" class="form-control small-control datepicker" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Enter Presentation Date" ValidationGroup="SaveGroup" Display="None" ControlToValidate="PresentedInHouseOnTxt"></asp:RequiredFieldValidator>
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
        <%--  <div class="col-md-2">
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
            <div class="col-md-3">
                <label class="control-lbl-sm" for="SenatorDDL">Sarch Senator:</label>
                <asp:TextBox ID="MemberNameTxt" runat="server" CssClass="form-control" ClientIDMode="Static" />
                <asp:HiddenField ID="HidMemberId" ClientIDMode="Static" runat="server" />
                <asp:Label ID="err" runat="server" Text="" Style="color: red"></asp:Label>
            </div>

            <div class="col-md-1" style="margin-top:25px; margin-left:0px; margin-right: 0px;">
                <asp:Button ID="AddMover" runat="server" Text=">>" Style="margin-bottom:2px;" class="btn btn-custom" OnClick="AddMover_Click" /><br />
                <asp:Button ID="DeleteMover" runat="server" Text="<<" class="btn btn-custom" OnClick="DeleteMover_Click" />
            </div>

            <div class="col-md-4">

                <label class="control-lbl-sm" for="SenatorDDL">Bill Movers (Senators):</label>
                <asp:ListBox ID="MoversLB" SelectionMode="Multiple" runat="server" class="form-control" placeholder="Members"></asp:ListBox>
            </div>
            <div class="col-md-2">
                <asp:Label ID="Label2" runat="server" Style="font-weight: bold; font-size: 10pt">Change Notice File</asp:Label>
                <asp:FileUpload ID="NoticeUpload" runat="server" CssClass="btn btn-custom" Style="width: 250px;" />
                <asp:HyperLink ID="NoticeLink" runat="server" CssClass="btn btn-info" style="margin-top:1px">Download Notice</asp:HyperLink>

            </div>

        </div>
         <div class="row top-buffer">
            <div class="col-md-3">
                <label class="control-lbl-sm" for="SenatorDDL">Search Minister:</label>
                <asp:TextBox ID="MinisterNameTxt" runat="server" CssClass="form-control" ClientIDMode="Static" />
                <asp:HiddenField ID="HidMinisterId" ClientIDMode="Static" runat="server" />
                <asp:Label ID="MinisterErr" runat="server" Text="" Style="color: red"></asp:Label>
            </div>

            <div class="col-md-1" style="margin-top: 25px; margin-left: 0px; margin-right: 0px;">
                <asp:Button ID="AddMinister" runat="server" Text=">>" Style="margin-bottom: 2px;" class="btn btn-custom" OnClick="AddMinister_Click" /><br />
                <asp:Button ID="DeleteMinister" runat="server" Text="<<" class="btn btn-custom" OnClick="DeleteMinister_Click" />
            </div>

            <div class="col-md-4">

                <label class="control-lbl-sm" for="SenatorDDL">Bill Movers (Ministers):</label>
                <asp:ListBox ID="MinistersLB" SelectionMode="Multiple" runat="server" class="form-control" placeholder="Members"></asp:ListBox>
            </div>
        </div>
        <div class="row top-buffer">
            <div class="col-md-3">
                <label class="control-lbl-sm" for="SenatorDDL">Search Ministry:</label>
                <asp:TextBox ID="MinistryTxt" AutoCompleteType="Disabled" runat="server" CssClass="form-control" />
                <asp:HiddenField ID="HidMinistryId" runat="server" />
                <asp:Label ID="err2" runat="server" Text="" Style="color: red"></asp:Label>
            </div>
            <div class="col-md-1" style="margin-top: 25px; margin-left: 0px; margin-right: 0px;">
                <asp:Button ID="AddMinistry" runat="server" Text=">>" class="btn btn-custom" Style="margin-bottom: 2px;" OnClick="AddMinistry_Click" /><br />
                <asp:Button ID="DeleteMinistry" runat="server" Text="<<" class="btn btn-custom" OnClick="DeleteMinistry_Click" />
            </div>
            <div class="col-md-4">
                <label class="control-lbl-sm" for="SenatorDDL">Ministries:</label>
                <asp:ListBox ID="MinistryLB" SelectionMode="Multiple" runat="server" class="form-control" placeholder="Members"></asp:ListBox>
            </div>
            <div class="col-md-2">
                <asp:Label ID="Label1" runat="server" Style="font-weight: bold; font-size: 10pt">Change Bill File</asp:Label>
                <asp:FileUpload ID="BillUpload" runat="server" CssClass="btn btn-custom" Style="width: 250px;" />
                <asp:HyperLink ID="BillLink" runat="server" CssClass="btn btn-info"  style="margin-top:1px">Download Bill</asp:HyperLink>
            </div>
        </div>
        </div>
     <div class="container  regularDiv">
        <div class="row top-buffer">
            <div class="col-md-7">
                <label class="control-lbl-sm">Searchable English Text:</label>
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
      
    </div>
     <div class="container  regularDiv">
        <div class="row top-buffer">
              <div class="col-md-5">
                <label class="control-lbl-sm" for="CategoryDDL">Refered to Committee:</label>
                <asp:DropDownList ID="CommitteeDDL" class="form-control small-control" runat="server" ValidationGroup="Group1">
                    <asp:ListItem Value="0">Select</asp:ListItem>
                </asp:DropDownList>
            </div>
             <div class="col-md-2">
                <label class="control-lbl-sm" for="SenatorDDL">Refered On:</label>
                <asp:TextBox ID="CommitteeRefDateTxt" runat="server" CssClass="form-control datepicker" />
            </div>
          </div>
         <div class="row top-buffer">
              <div class="col-md-2">
                <label class="control-lbl-sm" for="SenatorDDL">Comm Report Date:</label>
                <asp:TextBox ID="CommitteeReportDateTxt" runat="server" CssClass="form-control datepicker" />
            </div>
             <div class="col-md-2">
                <label class="control-lbl-sm" for="SenatorDDL">Committee Report</label>
                <asp:HyperLink ID="CommitteeReportLink" runat="server" CssClass="btn btn-info">Download Committee Report</asp:HyperLink>
            </div>
             
        </div>
        <div class="row">
            <div class="row top-buffer">
            <div class="col-md-10" style="margin-left:10px;margin-right:10px;">
                 <label class="control-lbl-sm" for="SenatorDDL">Committee Remarks:</label>
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
                </script>
            </div>
        </div>
        </div>

    </div>
    
    <div class="row">
        <div class="col-md-12" style="text-align: center">
            <asp:Label ID="Error" runat="server" Style="color: red"></asp:Label>
        </div>
    </div>
    
    <div class="container  regularDiv">
        <div class="row top-buffer">
            <div class="col-md-7">
                <label class="control-lbl-sm">Bill Documents:</label>
            </div>
        </div>
        <div class="row top-buffer">
             <div class="row" style="margin-left:10px;">
                  <div class="col-md-6">
                <asp:Label  runat="server">Document Description</asp:Label>
                <asp:TextBox ID="DocumentDescTxt" ValidationGroup="g1" TextMode="MultiLine" Rows="4" class="form-control" runat="server" Text=''></asp:TextBox>
               <asp:RequiredFieldValidator Style="color: red;" ID="RequiredFieldValidator2" ControlToValidate="DocumentDescTxt" ValidationGroup="g1" runat="server" ErrorMessage="Enter document description"></asp:RequiredFieldValidator>
            </div>
                 </div>
           <div class="row" style="margin-left:10px;">
             <div class="col-md-4">
                <asp:Label  runat="server">Document Date</asp:Label>
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
             <asp:Label  runat="server">Attach Document</asp:Label>
                <asp:FileUpload  CssClass="btn btn-default" ID="BillDocumentFileUpload" runat="server" />
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

        <div class="row" style="margin-top:0px !important;margin-left:10px;">
            <div class="col-md-8" style="text-align: left">
                <asp:Label runat="server" Style="color: red; font-weight: bold" ID="errorlbl"></asp:Label>
            </div>
        </div>
        <div class="row" style="margin-left:10px;">
            <div class="col-md-10">
                <table class="table table-condensed table-striped table-data">
                    <tr>
                        <th>Sr#</th>
                        <th>Document Description</th>
                        <th>File</th>
                        <th>Document Type</th>
                        <th>Attachment Date</th>
                       <%-- <th>Action</th>--%>
                    </tr>
                    <asp:ListView ID="DriversLV" runat="server"
                        OnItemDeleting="ItemDeleting">
                        <ItemTemplate>
                            <tr>
                                <asp:HiddenField ID="HidDocumentId" runat="server" Value='<%#Bind("DocumentId")%>' />
                                <td class="itemCent">
                                    <asp:Label ID="SrNo" runat="server" Text='<%#Container.DataItemIndex + 1%> '></asp:Label></td>
                                <td class="itemLeft" style="width:50%">
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
                              <%--  <td class="itemCent">
                                    <asp:LinkButton ID="deleteImageButton" class="btn btn-custom" runat="server" CommandName="delete"
                                        ToolTip="Delete" OnClientClick="return confirm('Are you sure you want to delete record ?');"><span class="glyphicon glyphicon-erase"></span></asp:LinkButton>
                                </td>--%>
                            </tr>
                        </ItemTemplate>
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

   


    <br />
    <div class="container">
        <div class="col-md-12" style="text-align: center">
            <asp:Button ID="Button1" runat="server" Text="Save" ValidationGroup="SaveGroup" OnClick="Button1_Click" class="btn btn-custom" />
            <%-- <asp:Button ID="PrintBtn" Target="_blank" runat="server" ValidationGroup="SaveGroup" Text="Print" CssClass="btn btn-custom" OnClick="PrintBtn_Click" />--%>
        </div>
    </div>

    <br />
     <div class="container">
        <div class="row">
            <div class="col-md-6">
                <div class="page-header"><b>Status History</b></div>
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

   
    <script type="text/javascript">
        $(function () {
            $(".datepicker").datepicker({
                beforeShow: function () {
                    setTimeout(function () {
                        $('.ui-datepicker').css('z-index', 99999999999999);
                    }, 0);
                },
                dateFormat: 'dd/mm/yy',
                minDate: 0,
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


        $(function () {
            $("[id$=MinistryTxt]").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: '<%=ResolveUrl("~/Service.asmx/GetCurrentDivisionsByName") %>',
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
                    $("[id$=HidMinistryId]").val(i.item.val);
                    $("[id$=NoOfBillsTxt]").val("");
                    //$("[id$=GroupDDL]").val('0');
                    //$("[id$=DivisionDDL]").val('0');


                },
                minLength: 1
            });
        });

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
                minLength: 2
            });
        });
        $(function () {
            $("[id$=MinisterNameTxt]").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: '<%=ResolveUrl("~/Service.asmx/GetMinisters") %>',
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
                    $("[id$=HidMinisterId]").val(i.item.val);
                },
                minLength: 2
            });
            });




    </script>
</asp:Content>
