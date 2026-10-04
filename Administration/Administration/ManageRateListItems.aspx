<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="ManageRateListItems.aspx.cs" Inherits="Administration.ManageRateListItems" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
       <script src="Custom/jquery-ui.min.js"></script>
    <link href="Custom/jquery-ui.css.css" rel="stylesheet" />
    <style>
        .ui-autocomplete {
            position: relative;
            cursor: default;
            z-index: 2000 !important;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     
        <div class="row page-header">
            <div class="col-md-12">

                <h4>
                    <label>RATE LIST ITEMS</label></h4>
            </div>
            
        </div>
        <div class="row">
            <div class="col-md-4">
                <asp:Label ID="Label11" class="control-lbl" runat="server" Text="Item" />
                <asp:TextBox ID="ItemTxt" runat="server" ClientIDMode="Static" class="form-control"></asp:TextBox>
                <asp:HiddenField ID="HidItemId" runat="server" Value='' />
                <asp:RequiredFieldValidator ValidationGroup="g1" ControlToValidate="ItemTxt" Display="Dynamic" CssClass="validationErr" ID="RequiredFieldValidator2" runat="server" ErrorMessage="Enter Item Name"></asp:RequiredFieldValidator>

            </div>
             <div class="col-md-3">
                <asp:Label ID="Label5" class="control-lbl" runat="server" Text="Price" />
                <asp:TextBox ID="PriceTxt" runat="server" ClientIDMode="Static" class="form-control"></asp:TextBox>
                <asp:HiddenField ID="HiddenField1" runat="server" Value='' />
                 <asp:RequiredFieldValidator ValidationGroup="g1" ControlToValidate="PriceTxt" Display="Dynamic" type="number" CssClass="validationErr" ID="RequiredFieldValidator1" runat="server" ErrorMessage="Enter Price"></asp:RequiredFieldValidator>

            </div>
            <div class="col-md-2">
                <asp:Label ID="Label4" class="control-lbl" runat="server" Text="Unit" />
                  <asp:DropDownList ID="UnitDDL" class="form-control control-txt" runat="server">
                  <asp:ListItem Value="0">Select</asp:ListItem>
                  </asp:DropDownList>
                    <asp:RequiredFieldValidator CssClass="validationErr" ID="RequiredFieldValidator3" runat="server" ControlToValidate="UnitDDL" InitialValue="0" ValidationGroup="g1" Display="Dynamic" ErrorMessage="Select Unit"></asp:RequiredFieldValidator>
            </div>
            <div class="col-md-2">
                <br />
                <asp:Button ID="CheckReq" ValidationGroup="g1" CssClass="btn btn-custom" runat="server" OnClick="newLinkButton_Click" Text="Save"></asp:Button>
            </div>
          </div>
      
        <br />
        <div class="row">
            <div class="col-md-12">
                <table class="table table-condensed table-striped table-data">
                    <tr>
                        <th>Sr#</th>
                        <th>Item</th>
                        <th>Price</th>
                        <th>Unit</th>
                        <th>Is Active</th>
                        <th>Action</th>
                    </tr>
                    <asp:ListView ID="ListView1" runat="server"
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
                                    <asp:HiddenField ID="HidRateListItemId" runat="server" Value='<%#Bind("RateListItemId")%>' />
                                    <asp:Label ID="SrNo" runat="server" Text='<%#Container.DataItemIndex + 1%> '></asp:Label></td>
                                <td class="itemCent">
                                    <asp:Label ID="id" runat="server" Text='<%#Bind("ItemName")%>' /></td>
                                  <td class="itemCent">
                                    <asp:Label ID="Label3" runat="server" Text='<%#Bind("Price")%>' /></td>
                                <td class="itemLeft">
                                    <asp:Label ID="Label2" runat="server" Text='<%#Bind("Unit")%>' /></td>
                                   <td class="itemLeft">
                                    <asp:Label ID="Label1" runat="server" Text='<%#(Convert.ToInt32(Eval("IsActive"))==1)?"Yes":"No"%>'></asp:Label></td>
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
                                <td class="itemCent">
                                    <asp:HiddenField ID="HidRateListItemId" runat="server" Value='<%#Bind("RateListItemId")%>' />
                                     <asp:HiddenField ID="HidUnitId" runat="server" Value='<%#Bind("UnitId")%>' />
                                    <asp:HiddenField ID="HidIsActive" runat="server" Value='<%#Bind("IsActive")%>' />
                                    <asp:Label ID="SrNo" runat="server" Text='<%#Container.DataItemIndex + 1%> '></asp:Label></td>
                                <td class="itemLeft">
                                    <asp:Label ID="id" runat="server" Text='<%#Bind("ItemName")%>' /></td>
                                <td class="itemLeft">
                                    <asp:TextBox ID="PriceTxt" CssClass="form-control" runat="server" Text='<%#Bind("Price")%>'></asp:TextBox></td>
                                <td class="itemLeft">
                                <asp:DropDownList ID="UnitDDL" class="form-control control-txt" runat="server">
                                    <asp:ListItem Value="0">Select</asp:ListItem>
                                </asp:DropDownList>
                                </td>
                                <td>
                                 <asp:DropDownList ID="IsActiveDDL" class="form-control control-txt" runat="server">
                                     <asp:ListItem Value="1">Yes</asp:ListItem>
                                    <asp:ListItem Value="0">No</asp:ListItem>
                                </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:LinkButton ID="cancelImageButton" class="btn btn-custom" runat="server" CommandName="cancel"
                                        ToolTip="Cancel"><span class="glyphicon glyphicon-arrow-left"></span></asp:LinkButton>
                                    <asp:LinkButton class="btn btn-custom" ID="saveImageButton" runat="server" CommandName="update"
                                        ToolTip="Save" ValidationGroup="Group1"><span class="glyphicon glyphicon-floppy-disk"></span></asp:LinkButton>

                                </td>
                            </tr>

                        </EditItemTemplate>
                        <EmptyDataTemplate>
                            <tr>
                                <td colspan="6" class="altCent" align="center">No Data Found</td>
                            </tr>
                        </EmptyDataTemplate>
                    </asp:ListView>
                  
                </table>


            </div>

        </div>

    <script type="text/javascript">
       
        $(function () {
            $("[id$=ItemTxt]").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: '<%=ResolveUrl("~/WebService1.asmx/GetItemsNotInRateList") %>',
                        data: "{ 'prefix': '" + request.term + "','Id': '" +<%=Request.QueryString["Id"]%>+"'}",
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
                    $("[id$=HidItemId]").val(i.item.val);
                    $("[id$=HidItemId]").val(i.item.val);
                },
                minLength: 1
            });
          });

    </script>
</asp:Content>
