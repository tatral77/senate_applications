<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="ManagePurchaseItems.aspx.cs" Inherits="Administration.ManagePurchaseItems" %>
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
                <h4><label>PURCHASE ITEMS</label></h4>
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
                <asp:Label ID="Label6" class="control-lbl" runat="server" Text="Quantity" />
                <asp:TextBox ID="QuantityTxt" runat="server" type="number" ClientIDMode="Static" class="form-control"></asp:TextBox>
                 <asp:RequiredFieldValidator ValidationGroup="g1" ControlToValidate="QuantityTxt" Display="Dynamic" CssClass="validationErr" ID="RequiredFieldValidator1" runat="server" ErrorMessage="Enter Quantity"></asp:RequiredFieldValidator>
            </div>
             <div class="col-md-2">
                <asp:Label ID="Label4" class="control-lbl" runat="server" Text="Unit" />
                  <asp:DropDownList ID="UnitDDL" class="form-control control-txt" runat="server">
                  <asp:ListItem Value="0">Select</asp:ListItem>
                  </asp:DropDownList>
                 <asp:RequiredFieldValidator CssClass="validationErr" ID="RequiredFieldValidator3" runat="server" ControlToValidate="UnitDDL" InitialValue="0" ValidationGroup="g1" Display="Dynamic" ErrorMessage="Select Unit"></asp:RequiredFieldValidator>
            </div>
             <div class="col-md-3">
                <asp:Label ID="Label5" class="control-lbl" runat="server" Text="Unit Price" />
                <asp:TextBox ID="PriceTxt" type="number" runat="server" ClientIDMode="Static" class="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ValidationGroup="g1" ControlToValidate="PriceTxt" Display="Dynamic" CssClass="validationErr" ID="RequiredFieldValidator4" runat="server" ErrorMessage="Enter Price"></asp:RequiredFieldValidator>

            </div>
            </div>
           <div class="row">
                 <div class="col-md-4">
                <asp:Label ID="Label7" class="control-lbl" runat="server" Text="Remarks" />
                <asp:TextBox ID="RemarksTxt" runat="server" ClientIDMode="Static" class="form-control"></asp:TextBox>

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
                        <th>Quantity</th>
                        <th>Unit</th>
                         <th>Unit Price</th>
                        <th>Total Items</th>
                        <th>Total Price</th>
                        <th>Remarks</th>
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
                                    <asp:HiddenField ID="HidPurchaseItemId" runat="server" Value='<%#Bind("PurchaseItemId")%>' />
                                    <asp:Label ID="SrNo" runat="server" Text='<%#Container.DataItemIndex + 1%> '></asp:Label></td>
                                <td class="itemCent">
                                    <asp:Label ID="id" runat="server" Text='<%#Bind("Item")%>' /></td>
                                <td class="itemCent">
                                    <asp:Label ID="Label8" runat="server" Text='<%#Bind("Quantity")%>' /></td>
                                 <td class="itemLeft">
                                    <asp:Label ID="Label2" runat="server" Text='<%#Bind("Unit")%>' /></td>
                                 <td class="itemLeft">
                                    <asp:Label ID="Label10" runat="server" Text='<%#String.Format("{0:#,##0}", Convert.ToDecimal(Eval("SingleItemPrice")))%>' /></td>
                                  <td class="itemLeft">
                                    <asp:Label ID="Label1" runat="server" Text='<%#Bind("TotalItems")%>' /></td>
                                  <td class="itemCent">
                                    <asp:Label ID="TotalPrice" runat="server" Text='<%#String.Format("{0:#,##0}", Convert.ToDecimal(Eval("TotalPrice")))%>' /></td>
                                 <td class="itemCent">
                                    <asp:Label ID="Label9" runat="server" Text='<%#Bind("Remarks")%>' /></td>
                               
                                <td class="itemCent">
                                 <%--   <asp:LinkButton ID="editImageButton" class="btn btn-custom" runat="server" CommandName="edit"
                                        ToolTip="Edit"><span class="glyphicon glyphicon-pencil"></span></asp:LinkButton>--%>
                                    <asp:LinkButton ID="deleteImageButton" class="btn btn-custom" runat="server" CommandName="delete"
                                        ToolTip="Delete" OnClientClick="return confirm('Are you sure you want to delete record ?');"><span class="glyphicon glyphicon-erase"></span></asp:LinkButton>
                                </td>
                            </tr>
                        </ItemTemplate>

                       <%-- <EditItemTemplate>
                            <tr>
                                <td class="itemCent">
                                    <asp:HiddenField ID="HidPurchaseItemId" runat="server" Value='<%#Bind("PurchaseItemId")%>' />
                                     <asp:HiddenField ID="HidUnitId" runat="server" Value='<%#Bind("UnitId")%>' />
                                    <asp:Label ID="SrNo" runat="server" Text='<%#Container.DataItemIndex + 1%> '></asp:Label></td>
                                <td class="itemLeft">
                                    <asp:Label ID="id" runat="server" Text='<%#Bind("Item")%>' /></td>
                                <td class="itemLeft">
                                    <asp:TextBox ID="QuantityTxt" CssClass="form-control" runat="server" Text='<%#Bind("Quantity")%>'></asp:TextBox></td>
                                 <td class="itemLeft">
                                <asp:DropDownList ID="UnitDDL" class="form-control control-txt" runat="server">
                                    <asp:ListItem Value="0">Select</asp:ListItem>
                                </asp:DropDownList>
                                </td>
                                <td class="itemLeft">
                                    <asp:TextBox ID="PriceTxt" CssClass="form-control" runat="server" Text='<%#Bind("SingleItemPrice")%>'></asp:TextBox></td>
                                 <td class="itemLeft">
                                    <asp:TextBox ID="TotalItemsTxt" CssClass="form-control" runat="server" Text='<%#Bind("TotalItems")%>'></asp:TextBox></td>
                                 <td class="itemLeft">
                                    <asp:TextBox ID="TotalPriceTxt" CssClass="form-control" runat="server" Text='<%#Bind("TotalPrice")%>'></asp:TextBox></td>
                                <td class="itemLeft">
                                    <asp:TextBox ID="RemarksTxt" TextMode="MultiLine" CssClass="form-control" runat="server" Text='<%#Bind("Remarks")%>'></asp:TextBox></td>
                               
                                <td>
                                    <asp:LinkButton ID="cancelImageButton" class="btn btn-custom" runat="server" CommandName="cancel"
                                        ToolTip="Cancel"><span class="glyphicon glyphicon-arrow-left"></span></asp:LinkButton>
                                    <asp:LinkButton class="btn btn-custom" ID="saveImageButton" runat="server" CommandName="update"
                                        ToolTip="Save" ValidationGroup="Group1"><span class="glyphicon glyphicon-floppy-disk"></span></asp:LinkButton>

                                </td>
                            </tr>

                        </EditItemTemplate>--%>
                        <EmptyDataTemplate>
                            <tr>
                                <td colspan="9" class="altCent" align="center">No Data Found</td>
                            </tr>
                        </EmptyDataTemplate>
                    </asp:ListView>
                    <tr>
                        <td style="background-color:#F0F0F0;font-weight:bold"></td>
                        <td colspan="5" style="background-color:#F0F0F0;font-weight:bold">Grand Total </td>
                        <td colspan="3" style="background-color:#F0F0F0;font-weight:bold">
                            <asp:Label  ID="GrandTotalLbl" runat="server" Text=""></asp:Label></td>
                    </tr>
                  
                </table>


            </div>

        </div>
 
    <script type="text/javascript">
       
        $(function () {
            $("[id$=ItemTxt]").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: '<%=ResolveUrl("~/WebService1.asmx/GetItemsNotInPurchase") %>',
                        data: "{ 'prefix': '" + request.term + "','Id': '" +<%=Request.QueryString["Id"]%>+"'}",
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        success: function (data) {
                            response($.map(data.d, function (item) {
                                return {
                                    label: item.split('-')[1],
                                    val: item.split('-')[0],
                                    price: item.split('-')[2],
                                    unit: item.split('-')[3]
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
                    $("[id$=PriceTxt]").val(i.item.price);
                    $("[id$=UnitDDL]").val(i.item.unit);

                },
                minLength: 1
            });
          });

    </script>
</asp:Content>
