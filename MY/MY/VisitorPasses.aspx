<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="VisitorPasses.aspx.cs" Inherits="MY.VisitorPasses" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <div class="container">
        <div class="row">
            <div class="col-md-9">
                <label class="page-header page-title">PASSES</label>
            </div>
            <div class="col-md-2 page-header ">
                <input type="button" class="btn btn-default" value="Print" onclick="return PrintPanel();" />
                <input type="button" class="btn btn-default" value="Export PDF" onclick="return ExportPdf();" />
                <asp:Button class="btn btn-primary" ID="Button1" runat="server" CommandName="new" Text="Add New" OnClick="newLinkButton_Click" />

            </div>
        </div>

        <div class="row">
            <div class="col-md-2 page-header ">
                Enter Pass ID:

            </div>
            <div class="col-md-6 page-header ">
                <asp:TextBox ID="PassIdTxt" AutoPostBack="true" OnTextChanged="PassIdTxt_TextChanged" ClientIDMode="Static" runat="server" CssClass="form-control" />
            </div>
            <div class="col-md-2 page-header ">
                <asp:Button class="btn btn-primary" ID="SearchBtn" runat="server" CommandName="new" Text="Search" OnClick="SearchBtn_Click" />

            </div>
        </div>
        <div class="row">
            <div class="col-md-11">
                <asp:Panel ID="pnlContents" runat="server">
                <table class="table table-hover table-striped" style="font-size: 10pt">
                    <thead>
                        <tr>
                            <th>Sr#</th>
                            <th>Pass ID</th>
                            <th>Pass Date</th>
                            <th>Pass Type</th>
                            <th>Requested By</th>
                            <th>Visit Purpose</th>
                            <th>From Date</th>
                            <th>To Date</th>
                            <th>Remarks</th>
                            <th>Is Active</th>
                            <th class="hid" style="width:15%">Action</th>
                        </tr>
                    </thead>
                    <tbody>

                        <asp:ListView ID="LV" runat="server"
                            OnItemEditing="ItemEditing"
                            OnItemDataBound="ItemDataBound"
                            OnItemCanceling="ItemCanceling"
                            OnItemCreated="ItemCreated"
                            OnItemInserting="ItemInserting"
                            OnItemUpdating="ItemUpdating">
                            <ItemTemplate>
                                <tr>
                                    <td>
                                        <asp:HiddenField ID="HidMemberCardId" runat="server" Value='<%#Bind("PassId")%>' />
                                        <asp:Label ID="SrNo" runat="server" Text='<%#Container.DataItemIndex + 1%> '></asp:Label></td>
                                    <td>
                                        <asp:Label ID="Label7" runat="server" Text='<%#Bind("PassCode")%>'></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label8" runat="server" Text='<%#Convert.ToDateTime(Eval("PassDate")).ToShortDateString()%>'></asp:Label>
                                    </td>
                                    <td>

                                        <asp:Label ID="PassportNumber" runat="server" Text='<%#Convert.ToString(Eval("RequestedBy")) + " - " + Convert.ToString(Eval("Post")) + " ( " +  Convert.ToString(Eval("Bps")) + " ) " %>'></asp:Label></td>
                                    <td>
                                        <asp:Label ID="Label6" runat="server" Text='<%#Bind("VisitPurpose")%>'></asp:Label></td>
                                    <td>
                                        <asp:Label ID="Label1" runat="server" Text='<%#Bind("PassTypes.Description")%>'></asp:Label></td>
                                    <td>
                                        <asp:Label ID="Label2" runat="server" Text='<%#Convert.ToDateTime(Eval("FromDate")).ToString("dd/MM/yyyy")%>'></asp:Label></td>
                                    <td>
                                        <asp:Label ID="Label3" runat="server" Text='<%#Convert.ToDateTime(Eval("ToDate")).ToString("dd/MM/yyyy")%>'></asp:Label></td>
                                    <td>
                                        <asp:Label ID="Label5" runat="server" Text='<%#Bind("Remarks")%>'></asp:Label></td>
                                    <td>
                                        <asp:Label ID="Label4" runat="server" Text='<%#(Convert.ToInt32(Eval("IsActive"))==1?"Yes":"No")%>'></asp:Label></td>
                                    <td class="hid">
                                        <asp:LinkButton ID="editImageButton" class="btn btn-primary" runat="server" CommandName="edit"
                                            ToolTip="Edit"><span class="glyphicon glyphicon-pencil"></span></asp:LinkButton>
                                      
                                        <asp:LinkButton ID="DetailsBtn" class="btn btn-primary" runat="server" OnClick="DetailsBtn_Click" CommandArgument='<%#Eval("PassId")%>'
                                            ToolTip="Visitors"><span class="glyphicon glyphicon-user"></span></asp:LinkButton>
                                        <asp:HyperLink ID="Print" Target="_blank" class="btn btn-primary" runat="server" NavigateUrl='<%#"~/PrintPass.aspx?Id=" + Eval("PassId")%>'
                                            ToolTip="Visitors"><span class="glyphicon glyphicon-print"></span></asp:HyperLink>
                                          <asp:LinkButton ID="deleteImageButton" class="btn btn-danger" runat="server" CommandName="delete"
                                            ToolTip="Delete" OnClientClick="return confirm('Are you sure you want to delete therecord ?');"><span class="glyphicon glyphicon-erase"></span></asp:LinkButton>
                                    </td>
                                </tr>
                            </ItemTemplate>

                            <EditItemTemplate>
                                <tr>
                                    <td colspan="7">
                                        <asp:HiddenField ID="HidPassId" runat="server" Value='<%#Bind("PassId")%>' />
                                        <asp:HiddenField ID="HidPassTypeId" runat="server" Value='<%#Bind("PassTypes.PassTypeId")%>' />
                                        <asp:HiddenField ID="HiIsActive" runat="server" Value='<%#Bind("IsActive")%>' />
                                        <asp:HiddenField ID="HidBranchId" runat="server" Value='<%#Bind("BranchId")%>' />
                                        <table class="table table-condensed">
                                            <tr>
                                                <td>Pass Date</td>
                                                <td>
                                                    <asp:TextBox ID="PassDateTxt" class="form-control js-date" runat="server" Text='<%#Convert.ToDateTime(Eval("PassDate")).ToString("dd/MM/yyyy")%>'></asp:TextBox>
                                                    <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator6" Text="*" runat="server" ErrorMessage="Enter Pass Date" ControlToValidate="PassDateTxt" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                                                <td>
                                            </tr>
                                            <tr>
                                                <td>Requested By</td>
                                                <td>
                                                    <asp:TextBox ID="RequestedByTxt" ClientIDMode="Static" class="form-control" runat="server" Text='<%#Bind("RequestedBy")%>'></asp:TextBox>
                                                    <asp:HiddenField ID="HidRequestedById" runat="server" Value='<%#Bind("RequestedById")%>' />
                                                    <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator1" Text="*" runat="server" ErrorMessage="Enter Serial Number" ControlToValidate="RequestedByTxt" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>Branch</td>
                                                <td>
                                                    <asp:DropDownList ID="BranchDDL" runat="server" class="form-control">
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator Display="Dynamic" InitialValue="0" ID="RequiredFieldValidator5" Text="*" runat="server" ErrorMessage="Select Branch" ControlToValidate="BranchDDL" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>Visit Purpose</td>
                                                <td>
                                                    <asp:TextBox ID="VisitPurposeTxt" TextMode="MultiLine" class="form-control" runat="server" Text='<%#Bind("VisitPurpose")%>'></asp:TextBox>
                                                    <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator2" Text="*" runat="server" ErrorMessage="Enter Visit Purpose" ControlToValidate="VisitPurposeTxt" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>Card Type</td>
                                                <td>
                                                    <asp:DropDownList ID="PassTypeDDL" runat="server" class="form-control">
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator Display="Dynamic" InitialValue="0" ID="RequiredFieldValidator4" Text="*" runat="server" ErrorMessage="Select Pass Type" ControlToValidate="PassTypeDDL" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                </tr>
                                <tr>
                                    <td>Company Name</td>
                                    <td>
                                        <asp:TextBox ID="CompanyNameTxt" ClientIDMode="Static" class="form-control" runat="server" Text='<%#Bind("Company.CompanyName")%>'></asp:TextBox>
                                        <asp:HiddenField ID="HidCompanyId" runat="server" Value='<%#Bind("CompanyId")%>' />
                                    </td>
                                </tr>
                                <tr>
                                    <td>From Date</td>
                                    <td>
                                        <asp:TextBox ID="FromDateTxt" class="form-control js-date" runat="server" Text='<%#Convert.ToDateTime(Eval("FromDate")).ToString("dd/MM/yyyy")%>'></asp:TextBox>
                                        <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator7" Text="*" runat="server" ErrorMessage="Enter From Date" ControlToValidate="FromDateTxt" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                                    <td>
                                </tr>
                                <tr>
                                    <td>To Date</td>
                                    <td>
                                        <asp:TextBox ID="ToDateTxt" class="form-control js-date" runat="server" Text='<%#Convert.ToDateTime(Eval("ToDate")).ToString("dd/MM/yyyy")%>'></asp:TextBox>
                                        <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator3" Text="*" runat="server" ErrorMessage="Enter To Date" ControlToValidate="ToDateTxt" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                                    <td>
                                </tr>
                                <tr>
                                    <td>Allow Off Days</td>
                                    <td style="font-size: 12pt; font-weight: normal">
                                        <asp:CheckBox ID="SaturdayCB" Text="Saturday" runat="server" Checked='<%#(Convert.ToInt32(Eval("Saturday"))==1)?true:false %>' />
                                        <asp:CheckBox ID="SundayCB" Text="Sunday" runat="server" Checked='<%#(Convert.ToInt32(Eval("Sunday"))==1)?true:false %>' />
                                    <td>
                                </tr>
                                <tr>
                                    <td>Remarks</td>
                                    <td>
                                        <asp:TextBox ID="RemarksTxt" TextMode="MultiLine" class="form-control" runat="server" Text='<%#Bind("Remarks")%>'></asp:TextBox>
                                    <td>
                                </tr>
                                <tr>
                                    <td>Active</td>
                                    <td>
                                        <asp:DropDownList ID="IsActiveDDL" runat="server" class="form-control">
                                            <asp:ListItem Value="1">Yes</asp:ListItem>
                                            <asp:ListItem Value="0">No</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:LinkButton ID="cancelImageButton" class="btn btn-primary" runat="server" CommandName="cancel"
                                            ToolTip="Cancel"><span class="glyphicon glyphicon-arrow-left"></span></asp:LinkButton>
                                        <asp:LinkButton class="btn btn-primary" ID="saveImageButton" runat="server" CommandName="update"
                                            ToolTip="Save" ValidationGroup="Group1"><span class="glyphicon glyphicon-floppy-disk"></span></asp:LinkButton>
                                    </td>
                                </tr>

                                </table>

                                    </td>
                                </tr>
                            </EditItemTemplate>
                            <InsertItemTemplate>
                                <tr>
                                    <td colspan="7">
                                        <table class="table table-condensed">
                                            <tr>
                                                <td>Pass Date</td>
                                                <td>
                                                    <asp:TextBox ID="PassDateTxt" class="form-control js-date" runat="server"></asp:TextBox>
                                                    <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator6" Text="*" runat="server" ErrorMessage="Enter Pass Date" ControlToValidate="PassDateTxt" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                                                <td>
                                            </tr>
                                            <tr>
                                                <td>Requested By</td>
                                                <td>
                                                    <asp:TextBox ID="RequestedByTxt" ClientIDMode="Static" class="form-control" runat="server"></asp:TextBox>
                                                    <asp:HiddenField ID="HidRequestedById" runat="server" />
                                                    <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator1" Text="*" runat="server" ErrorMessage="Enter Serial Number" ControlToValidate="RequestedByTxt" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>Branch</td>
                                                <td>
                                                    <asp:DropDownList ID="BranchDDL" runat="server" class="form-control">
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator Display="Dynamic" InitialValue="0" ID="RequiredFieldValidator5" Text="*" runat="server" ErrorMessage="Select Branch" ControlToValidate="BranchDDL" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>Visit Purpose</td>
                                                <td>
                                                    <asp:TextBox ID="VisitPurposeTxt" TextMode="MultiLine" class="form-control" runat="server"></asp:TextBox>
                                                    <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator2" Text="*" runat="server" ErrorMessage="Enter Visit Purpose" ControlToValidate="VisitPurposeTxt" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>Card Type</td>
                                                <td>
                                                    <asp:DropDownList ID="PassTypeDDL" runat="server" class="form-control">
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator Display="Dynamic" InitialValue="0" ID="RequiredFieldValidator4" Text="*" runat="server" ErrorMessage="Select Pass Type" ControlToValidate="PassTypeDDL" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>Company Name</td>
                                                <td>
                                                    <asp:TextBox ID="CompanyNameTxt" ClientIDMode="Static" class="form-control" runat="server"></asp:TextBox>
                                                    <asp:HiddenField ID="HidCompanyId" runat="server" Value="0" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>From Date</td>
                                                <td>
                                                    <asp:TextBox ID="FromDateTxt" class="form-control js-date" runat="server"></asp:TextBox>
                                                    <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator7" Text="*" runat="server" ErrorMessage="Enter From Date" ControlToValidate="FromDateTxt" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                                                <td>
                                            </tr>
                                            <tr>
                                                <td>To Date</td>
                                                <td>
                                                    <asp:TextBox ID="ToDateTxt" class="form-control js-date" runat="server"></asp:TextBox>
                                                    <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator3" Text="*" runat="server" ErrorMessage="Enter To Date" ControlToValidate="ToDateTxt" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                                                <td>
                                            </tr>
                                            <tr>
                                                <td>Allow Off Days</td>
                                                <td style="font-size: 12pt; font-weight: normal">
                                                    <asp:CheckBox ID="SaturdayCB" Text="Saturday" runat="server" />
                                                    <asp:CheckBox ID="SundayCB" Text="Sunday" runat="server" />
                                                <td>
                                            </tr>
                                            <tr>
                                                <td>Remarks</td>
                                                <td>
                                                    <asp:TextBox ID="RemarksTxt" TextMode="MultiLine" class="form-control" runat="server"></asp:TextBox>
                                                <td>
                                            </tr>
                                            <tr>
                                                <td>Active</td>
                                                <td>
                                                    <asp:DropDownList ID="IsActiveDDL" runat="server" class="form-control">
                                                        <asp:ListItem Value="1">Yes</asp:ListItem>
                                                        <asp:ListItem Value="0">No</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td></td>
                                                <td>
                                                    <asp:LinkButton ID="cancelImageButton" class="btn btn-primary" runat="server" CommandName="cancel"
                                                        ToolTip="Cancel"><span class="glyphicon glyphicon-arrow-left"></span></asp:LinkButton>
                                                    <asp:LinkButton class="btn btn-primary" ID="saveImageButton" runat="server" CommandName="insert"
                                                        ToolTip="Save" ValidationGroup="Group1"><span class="glyphicon glyphicon-floppy-disk"></span></asp:LinkButton>
                                                </td>
                                            </tr>

                                        </table>
                                    </td>
                                </tr>
                            </InsertItemTemplate>
                            <EmptyDataTemplate>
                                <tr>
                                    <td colspan="3">No Data Found</td>
                                </tr>
                            </EmptyDataTemplate>
                        </asp:ListView>


                    </tbody>
                </table>
                </asp:Panel>
            </div>
        </div>
    </div>

    <script>
        $(function () {
            $("[id$=RequestedByTxt]").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: '<%=ResolveUrl("~/WebService1.asmx/GetEmployeeName") %>',
                        data: "{ 'prefix': '" + request.term + "'}",
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        success: function (data) {
                            response($.map(data.d, function (item) {
                                return {
                                    label: item.split('=')[0],
                                    val: item.split('=')[1],
                                    val2: item.split('=')[2]
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
                    $("[id$=HidRequestedById]").val(i.item.val);
                    $("[id$=HidPostId]").val(i.item.val2);
                },
                minLength: 1
            });
        });

        $(function () {
            $("[id$=CompanyNameTxt]").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: '<%=ResolveUrl("~/WebService1.asmx/GetCompanies") %>',
                        data: "{ 'prefix': '" + request.term + "'}",
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        success: function (data) {
                            response($.map(data.d, function (item) {
                                return {
                                    label: item.split('=')[1],
                                    val: item.split('=')[0],
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
                    $("[id$=HidCompanyId]").val(i.item.val);
                },
                minLength: 1
            });
        });

    </script>
    <script src='<%= ResolveUrl("~/Scripts/hrmprint.js") %>' type="text/javascript"></script>
    <script type="text/javascript">
        function PrintPanel() {
            return HRMPrint.print("<%= pnlContents.ClientID %>", { title: "VISITOR PASSES" });
        }
        function ExportPdf() {
            return HRMPrint.exportPdf("<%= pnlContents.ClientID %>", { title: "VISITOR PASSES", fileName: "Visitor Passes" });
        }
    </script>
</asp:Content>
