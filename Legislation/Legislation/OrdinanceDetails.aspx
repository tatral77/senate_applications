<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" ValidateRequest="false" AutoEventWireup="true" CodeBehind="OrdinanceDetails.aspx.cs" Inherits="Legislation.OrdinanceDetails" %>
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
               ORDINANCE DETAILS
            </div>
        </div>
    </div>

    <div class="container  regularDiv" id="#panel">
        <div class="row top-buffer">
            <asp:ValidationSummary ID="ValidationSummary3" DisplayMode="BulletList"
                EnableClientScript="true"
                HeaderText="You must enter a value in the following fields:" ValidationGroup="SaveGroup" ForeColor="OrangeRed" runat="server" />
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
             <div class="col-md-2">
                <label class="control-lbl-sm" for="SessionTxt">Status:</label>
                <asp:DropDownList ID="StatusDDL" class="form-control small-control" runat="server" ValidationGroup="Group1">
                </asp:DropDownList>
                 <asp:HiddenField ID="HidStatusId" runat="server" />
            </div>
              <div class="col-md-2">
                <label class="control-lbl-sm" for="SessionTxt">Status Date:</label>
               <asp:TextBox ID="StatusDateTxt" ValidationGroup="Group1"  class="form-control small-control datepicker js-date" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Enter Status Date" ValidationGroup="SaveGroup" Display="None" ControlToValidate="StatusDateTxt"></asp:RequiredFieldValidator>
            </div>
            <div class="col-md-2">
                <label class="control-lbl-sm" for="LegislationDiaryTimeTxt">Date of Promulgation:</label>
                <asp:TextBox ID="DateOfPromulgationTxt" ValidationGroup="Group1" Required="true" class="form-control small-control datepicker js-date" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvLegislationDiaryTimeTxt" runat="server" ErrorMessage="Enter Promulgation Date" ValidationGroup="SaveGroup" Display="None" ControlToValidate="DateOfPromulgationTxt"></asp:RequiredFieldValidator>
            </div>
              <div class="col-md-2">
                <label class="control-lbl-sm" for="LegislationDiaryTimeTxt">Date of laying in the Senate :</label>
                <asp:TextBox ID="LayingDateTxt" ValidationGroup="Group1" Required="true" class="form-control small-control datepicker js-date" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Enter Promulgation Date" ValidationGroup="SaveGroup" Display="None" ControlToValidate="DateOfPromulgationTxt"></asp:RequiredFieldValidator>
            </div>
        </div>
        <div class="row top-buffer">
            <div class="col-md-8">
                <label class="control-lbl-sm" for="LegislationDiaryTimeTxt">Title:</label>
                <asp:TextBox ID="TitleTxt" ValidationGroup="Group1" TextMode="Multiline" Rows="5" class="form-control small-control datepicker" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Enter Title of Oridinance" ValidationGroup="SaveGroup" Display="None" ControlToValidate="TitleTxt"></asp:RequiredFieldValidator>
            </div>
        </div>
           <div class="row top-buffer">
            <div class="col-md-8">
                <label class="control-lbl-sm" for="LegislationDiaryTimeTxt">Remarks:</label>
                <textarea id="RemarksTxt" name="BillTitleTxt" style="height: 70px" class="form-control" validationgroup="SaveGroup" rows="10" runat="server"></textarea>
                    <script>
                        $(document).ready(function () {
                            $('#ContentPlaceHolder1_RemarksTxt').summernote(
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
        <div class="row top-buffer">
            <div class="col-md-12">
                <asp:Button ID="Button1" runat="server" Text="Save" ValidationGroup="SaveGroup" OnClick="Button1_Click" class="btn btn-custom" />
            </div>
        </div>
    </div>
  <section id="BillDocuments">
        <div class="container  regularDiv">
            <div class="row top-buffer">
                <div class="col-md-7">
                    <label class="control-lbl-sm">Documents:</label>
                </div>
            </div>
            <div class="row top-buffer">
                <div class="row" style="margin-left: 10px;">
                    <div class="col-md-6">
                        <asp:Label runat="server">Document Description</asp:Label>
                        <asp:TextBox ID="DocumentDescTxt" ValidationGroup="g1" TextMode="MultiLine" Rows="4" class="form-control" runat="server" Text=''></asp:TextBox>
                        <asp:RequiredFieldValidator Style="color: red;" ID="RequiredFieldValidator1" ControlToValidate="DocumentDescTxt" ValidationGroup="g1" runat="server" ErrorMessage="Enter document description"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="row" style="margin-left: 10px;">
                    <div class="col-md-4">
                        <asp:Label runat="server">Document Date</asp:Label>
                        <asp:TextBox ID="DocumentDateTxt" ValidationGroup="g1" class="form-control datepicker" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator Style="color: red;" ID="RequiredFieldValidator6" ControlToValidate="DocumentDateTxt" ValidationGroup="g1" runat="server" ErrorMessage="Enter Date"></asp:RequiredFieldValidator>
                    </div>
                    <div class="col-md-3">
                        <asp:Label runat="server">Attach Document</asp:Label>
                        <asp:FileUpload CssClass="btn btn-default" ID="BillDocumentFileUpload" runat="server" data-scan="true" />
                        <asp:RequiredFieldValidator ForeColor="Red" runat="server" Display="Dynamic" ErrorMessage="Attach File" ControlToValidate="BillDocumentFileUpload" ValidationGroup="g1">
                        </asp:RequiredFieldValidator>
                  <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator7"  
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
                                <th>Document Date</th>
                        <th>Action</th>
                            </tr>
                            <asp:ListView ID="DriversLV" runat="server"
                                OnItemDeleting="ItemDeleting">
                                <ItemTemplate>
                                    <tr>
                                        <asp:HiddenField ID="HidDocumentId" runat="server" Value='<%#Bind("OrdinanceDocumentsId")%>' />
                                        <td class="itemCent">
                                            <asp:Label ID="SrNo" runat="server" Text='<%#Container.DataItemIndex + 1%> '></asp:Label></td>
                                        <td class="itemLeft" style="width: 50%">
                                            <asp:Label ID="Description" runat="server" Text='<%#Bind("Description")%>'></asp:Label></td>
                                        <td class="itemLeft">
                                            <asp:HyperLink ID="HyperLink1" runat="server" Text="Download" NavigateUrl='<%#Eval("DocumentUrl")%>'></asp:HyperLink>
                                        </td>
                                         <td class="itemLeft">
                                             <asp:Label ID="Label4" runat="server" Text='<%#Bind("AttachmentDate")%>'></asp:Label></td>
                                        </td>
                                 <td class="itemCent">
                                            <asp:LinkButton ID="deleteImageButton" class="btn btn-custom" runat="server" CommandName="delete"
                                                ToolTip="Delete" OnClientClick="return confirm('Are you sure you want to delete record ?');"><span class="glyphicon glyphicon-erase"></span></asp:LinkButton>
                                        </td>
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
    </section>
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
                            </tr>
                        </thead>
                        <tbody>
                            <asp:ListView ID="OrdinanceStatusHistoryLV" runat="server">

                                <ItemTemplate>
                                    <tr>
                                        <td>

                                            <asp:Label ID="Label3" class="table-data" runat="server" Text='<%#Container.DataItemIndex + 1%> ' />
                                        </td>
                                        <td>
                                            <asp:Label ID="Label4" class="table-data" runat="server" Text='<%#Bind("OrdinanceStatus")%>' />
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
    </section>
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
    </script>
</asp:Content>
