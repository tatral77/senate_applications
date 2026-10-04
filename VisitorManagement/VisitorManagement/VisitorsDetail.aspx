<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="VisitorsDetail.aspx.cs" Inherits="VisitorManagement.VisitorsDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
      <script src="Jquery/jquery-1.10.2.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="container">
        <div class="row">
            <div class="col-md-9">
                <label class="page-header page-title">VISITORS</label>
            </div>
            <div class="col-md-2 page-header ">
                <asp:Button class="btn btn-primary" ID="Button1" runat="server" CommandName="new" Text="Add New" OnClick="newLinkButton_Click" />
            </div>
        </div>
        <div class="row">
            <div class="col-md-11">
                <table class="table table-hover table-striped"  style="font-size:10pt">
                    <thead>
                        <tr>
                            <th>Sr#</th>
                            <th>Visitor Name</th>
                            <th>CNIC</th>
                             <th>Visitor Details</th>
                            <th>Action</th>
                        </tr>
                    </thead>
                    <tbody>

                        <asp:ListView ID="LV" runat="server"
                            OnItemEditing="ItemEditing"
                          
                            OnItemCanceling="ItemCanceling"
                         
                            OnItemDeleting="ItemDeleting"
                            OnItemInserting="ItemInserting"
                            OnItemUpdating="ItemUpdating">
                            <ItemTemplate>
                                <tr>
                                    <td>
                                        <asp:HiddenField ID="HidVisitorId" runat="server" Value='<%#Bind("VisitorId")%>' />
                                        <asp:Label ID="SrNo" runat="server" Text='<%#Container.DataItemIndex + 1%> '></asp:Label></td>
                                    <td>
                                        <asp:Label ID="VisitorName" runat="server" Text='<%#Bind("VisitorName")%>'></asp:Label></td>
                                       <td>
                                        <asp:Label ID="Label6" runat="server" Text='<%#Bind("Cnic")%>'></asp:Label></td>
                                    <td>
                                        <asp:Label ID="Label1" runat="server" Text='<%#Bind("Details")%>'></asp:Label></td>
                                   <td>
                                        <asp:LinkButton ID="editImageButton" class="btn btn-primary" runat="server" CommandName="edit"
                                            ToolTip="Edit"><span class="glyphicon glyphicon-pencil"></span></asp:LinkButton>
                                        <asp:LinkButton ID="deleteImageButton" class="btn btn-primary" runat="server" CommandName="delete"
                                            ToolTip="Delete" OnClientClick="return confirm('Are you sure you want to delete therecord ?');"><span class="glyphicon glyphicon-erase"></span></asp:LinkButton>
                                    </td>
                                </tr>
                            </ItemTemplate>

                            <EditItemTemplate>
                                <tr  style="font-size:10pt">
                                    <td colspan="7">
                                        <asp:HiddenField ID="HidVisitorId" runat="server" Value='<%#Bind("VisitorId")%>' />
                                        <table class="table table-condensed">
                                            <tr>
                                                <td>Visitor Name</td>
                                                <td>
                                                    <asp:TextBox ID="VisitorNameTxt" ClientIDMode="Static" class="form-control" runat="server" Text='<%#Bind("VisitorName")%>'></asp:TextBox>
                                                    <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator1" Text="*" runat="server" ErrorMessage="Enter Visitor Name" ControlToValidate="VisitorNameTxt" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                                 <tr>
                                                <td>CNIC</td>
                                                <td>
                                                    <asp:TextBox ID="CnicTxt" ClientIDMode="Static" class="form-control" runat="server" Text='<%#Bind("Cnic")%>'></asp:TextBox>
                                                    <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator2" Text="*" runat="server" ErrorMessage="Enter CNIC" ControlToValidate="CnicTxt" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                               <tr>
                                                <td>Visitor Details</td>
                                                <td>
                                                    <asp:TextBox ID="DetailsTxt" class="form-control" TextMode="MultiLine" runat="server" Text='<%#Eval("Details")%>'></asp:TextBox>
                                                    <td>
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
                                <tr  style="font-size:10pt">
                                    <td colspan="7">
                                        <table class="table table-condensed">
                                                <tr>
                                                <td>Visitor Name</td>
                                                <td>
                                                    <asp:TextBox ID="VisitorNameTxt" ClientIDMode="Static" class="form-control" runat="server" ></asp:TextBox>
                                                    <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator1" Text="*" runat="server" ErrorMessage="Enter Visitor Name" ControlToValidate="VisitorNameTxt" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                                 <tr>
                                                <td>CNIC</td>
                                                <td>
                                                    <asp:TextBox ID="CnicTxt" ClientIDMode="Static" class="form-control" runat="server" ></asp:TextBox>
                                                    <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator2" Text="*" runat="server" ErrorMessage="Enter CNIC" ControlToValidate="CnicTxt" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                               <tr>
                                                <td>Visitor Details</td>
                                                <td>
                                                    <asp:TextBox ID="DetailsTxt" class="form-control" TextMode="MultiLine" runat="server" ></asp:TextBox>
                                                    <td>
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
            </div>
        </div>
    </div>

        <script>
            $(function () {
                $("[id$=VisitorNameTxt]").autocomplete({
                    source: function (request, response) {
                        $.ajax({
                            url: '<%=ResolveUrl("~/WebService1.asmx/GetVisitorByName") %>',
                        data: "{ 'prefix': '" + request.term + "'}",
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        success: function (data) {
                            response($.map(data.d, function (item) {
                                return {
                                    label: item.split('=')[0],
                                    val: item.split('=')[1],
                                    val2: item.split('=')[2],
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
                    $("[id$=CnicTxt]").val(i.item.val);
                   
                },
                minLength: 1
            });
        });

        </script>
</asp:Content>
