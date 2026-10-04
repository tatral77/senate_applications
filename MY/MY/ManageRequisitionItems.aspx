<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="ManageRequisitionItems.aspx.cs" Inherits="MY.ManageRequisitionItems" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="CustomScripts/jquery-ui.min.js"></script>
    <link href="CustomScripts/jquery-ui.css.css" rel="stylesheet" />
    <style>
        .ui-autocomplete {
            position: relative;
            cursor: default;
            z-index: 2000 !important;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <div class="row page-header" style="margin-bottom: 10px;">
            <div class="col-md-8">
                <h4>
                    <asp:Label runat="server" ID="heading"></asp:Label></h4>
            </div>
            <div style="text-align: right">
                <h4>
                    <asp:Label runat="server" Style="margin-right: 10px;" ID="RequisitionIDLbl"></asp:Label></h4>
            </div>
        </div>
        <div class="row">
            <div class="col-md-6">
                <asp:Label ID="Label1" class="control-lbl" runat="server" Text="Item (Type item name)" />
                <asp:TextBox ID="ItemTxt" runat="server" required="true" placeholder="Type Item Name" ClientIDMode="Static" class="form-control"></asp:TextBox>
                <asp:HiddenField ID="HidItemId" runat="server" Value='' />
            </div>
            <div class="col-md-2">
                <asp:Label ID="Label2" class="control-lbl" runat="server" Text="Quantity" />
                <asp:TextBox ID="QuantityRequestedTxt" min="1" runat="server" Type="Number" ClientIDMode="Static" class="form-control" Text="1"></asp:TextBox>
            </div>
            <div class="col-md-2">
                <%--<asp:Label ID="Label3" class="control-lbl" runat="server" Text="Quantity Issued" />           
                <asp:TextBox ID="QuantityIssuedTxt" runat="server" Type="Number" ClientIDMode="Static" class="form-control" ></asp:TextBox>--%>
            </div>
            <div class="col-md-2">
                <br />
                <asp:Button ID="Button1" runat="server" CommandName="new" Text="Add Item" class="btn btn-custom" OnClick="newLinkButton_Click" />
            </div>
            <div class="row">
                <div class="col-md-4">
                    <asp:Label CssClass="validationErr" ID="InsertError" runat="server" Text=""></asp:Label>
                </div>

            </div>

        </div>
        <br />
        <div class="row">
            <div class="col-md-12">
                <table class="table table-condensed table-striped table-data">
                    <tr>
                        <th>Sr#</th>
                        <th>Item</th>
                        <th>Requested</th>
                        <th>Issued</th>
                        <th>Action</th>
                    </tr>
                    <asp:ListView ID="RequisitionItemsLV" runat="server"
                        OnItemEditing="ItemEditing"
                        OnItemInserting="ItemInserting"
                        OnItemCanceling="ItemCanceling"
                        OnItemUpdating="ItemUpdating"
                        OnItemDataBound="ItemDataBound"
                        OnItemDeleting="ItemDeleting"
                        OnItemCreated="ItemCreated">
                        <ItemTemplate>
                            <tr>
                                <td class="itemCent">
                                    <asp:HiddenField ID="HidRequisitionItemId" runat="server" Value='<%#Bind("RequisitionItemId")%>' />
                                    <asp:Label ID="SrNo" runat="server" Text='<%#Container.DataItemIndex + 1%> '></asp:Label></td>
                                <td class="itemLeft">
                                    <asp:Label ID="Descriptiontxt" runat="server" Text='<%#Bind("Item")%>'></asp:Label></td>
                                <td class="itemLeft">
                                    <asp:Label ID="Description" runat="server" Text='<%#Bind("QuantityDemanded")%>'></asp:Label></td>
                                <td class="itemLeft">
                                    <asp:Label ID="Label4" runat="server" Text='<%#Bind("QuantityIssued")%>'></asp:Label></td>
                                <td class="itemCent">
                                    <asp:LinkButton ID="editImageButton" class="btn btn-custom" runat="server" CommandName="edit"
                                        ToolTip="Edit"><span class="glyphicon glyphicon-pencil"></span></asp:LinkButton>
                                    <asp:LinkButton ID="deleteImageButton" class="btn btn-custom" runat="server" CommandName="delete"
                                        ToolTip="Delete" OnClientClick="return confirm('Are you sure you want to delete record ?');"><span class="glyphicon glyphicon-erase"></span></asp:LinkButton>
                                </td>
                            </tr>
                        </ItemTemplate>

                        <EditItemTemplate>
                            <tr>
                                <td colspan="5">
                                    <asp:Label CssClass="validationErr" ID="EditError" runat="server" Text=""></asp:Label></td>
                            </tr>
                            <tr>

                                <td class="itemCent">
                                    <asp:HiddenField ID="HidRequisitionItemId" runat="server" Value='<%#Bind("RequisitionItemId")%>' />
                                    <asp:Label ID="Label5" runat="server" Text='<%#Container.DataItemIndex + 1%> '></asp:Label></td>
                                <td class="itemLeft">
                                    <asp:Label ID="Label6" runat="server" Text='<%#Bind("Item")%>'></asp:Label></td>
                                <td class="itemLeft">
                                    <asp:TextBox CssClass="form-control" ID="QuantityDemanded" runat="server" Text='<%#Bind("QuantityDemanded")%>'></asp:TextBox></td>
                                <td class="itemLeft">
                                    <asp:TextBox ID="QuantityIssued" CssClass="form-control" runat="server" Text='<%#Bind("QuantityIssued")%>'></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td colspan="3">
                                    <asp:LinkButton ID="cancelImageButton" class="btn btn-custom" runat="server" CommandName="cancel"
                                        ToolTip="Cancel"><span class="glyphicon glyphicon-arrow-left"></span></asp:LinkButton>
                                    <asp:LinkButton class="btn btn-custom" ID="saveImageButton" runat="server" CommandName="update"
                                        ToolTip="Save" ValidationGroup="Group1"><span class="glyphicon glyphicon-floppy-disk"></span></asp:LinkButton>

                                </td>
                            </tr>

                        </EditItemTemplate>
                        <EmptyDataTemplate>
                            <tr>
                                <td colspan="4" class="altCent" align="center">No Data Found</td>
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
    <script type="text/javascript">

        $(function () {
            $("[id$=ItemTxt]").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: '<%=ResolveUrl("~/WebService1.asmx/GetEmpItemNameNotAssigned") %>',
                        data: "{ 'prefix': '" + request.term + "','Id': '" +<%=Request.QueryString["Id"]%> +"'}",
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        success: function (data) {
                            response($.map(data.d, function (item) {
                                return {
                                    label: item.split('-')[1],
                                    val: item.split('-')[0]
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
                    $("[id$=HidItemId]").val(i.item.val);
                },
                minLength: 1
            });
         });

    </script>
</asp:Content>
