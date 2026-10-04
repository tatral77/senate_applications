<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="ManageMainItems.aspx.cs" Inherits="Administration.ManageMainItems" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

       <%-- <div class="row">
            <div class="col-md-9">
                <h4>
                    <asp:HyperLink class="table-data" ID="HyperLink1" runat="server" NavigateUrl="~/ManageCategories.aspx">Back to Categories</asp:HyperLink>
                </h4>
            </div>
            </div>--%>
        <div class="row" style="margin-top:0px;">
            <div class="col-md-9 page-header">
                <h4>
                    <asp:HyperLink CssClass="details-link" ID="HyperLink1" runat="server"><asp:Label ID="heading" runat="server"></asp:Label></asp:HyperLink>
                </h4>
            </div>
            <div class="col-md-2 page-header ">
                <asp:Button ID="LinkButton1" runat="server" CommandName="new" Text="Add New" class="btn btn-custom" OnClick="newLinkButton_Click" />

            </div>
        </div>
        <div class="row">
            <div class="col-md-11">
                <table class="table table-condensed table-striped table-data">
                    <tr>
                        <th>Sr#</th>
                        <th>Main Item</th>
                        <th>Category</th>
                        <th>Active</th>
                        <th>Action</th>
                    </tr>
                    <asp:ListView ID="MainItemLV" runat="server"
                        OnItemEditing="ItemEditing"
                        OnItemInserting="ItemInserting"
                        OnItemCanceling="ItemCanceling"
                        OnItemUpdating="ItemUpdating"
                        OnItemDataBound="ItemDataBound"
                        OnItemCreated="ItemCreated">

                        <ItemTemplate>
                            <tr>

                                <asp:HiddenField ID="HidHardwareSubTypeId" runat="server" Value='<%#Bind("MainItemId")%>' />
                                <td class="itemCent">
                                    <asp:Label ID="SrNo" runat="server" Text='<%#Container.DataItemIndex + 1%> '></asp:Label></td>
                                <td class="itemLeft">
                                    <asp:HyperLink class="details-link" ID="HyperLink1" runat="server" NavigateUrl='<%#Eval("MainItemId","~/ManageItems.aspx?MainItemId={0}")%>'><%#Eval("MainItem").ToString()%></asp:HyperLink>
                                    
                                <td class="itemLeft">
                                    <asp:Label ID="Descriptiontxt" runat="server" Text='<%#Bind("Category")%>'></asp:Label></td>
                                <td class="itemLeft">
                                    <asp:Label ID="Label2" runat="server" Text='<%#(Convert.ToInt32(Eval("IsActive"))==1)?"Yes":"No"%>'></asp:Label></td>
                                <td class="itemCent">
                                    <asp:LinkButton ID="editImageButton" class="btn btn-custom" runat="server" CommandName="edit"
                                        ToolTip="Edit"><span class="glyphicon glyphicon-pencil"></span></asp:LinkButton>
                                    <%-- <asp:LinkButton ID="deleteImageButton" class="btn btn-custom" runat="server"  CommandName="delete"
                                 ToolTip="Delete" OnClientClick="return confirm('Are you sure you want to delete record ?');"><span class="glyphicon glyphicon-erase"></span></asp:LinkButton>--%>
                                </td>
                            </tr>
                        </ItemTemplate>

                        <EditItemTemplate>
                            <tr>
                                <td colspan="7">
                                    <asp:HiddenField ID="HidMainItemId" runat="server" Value='<%#Bind("MainItemId")%>' />
                                    <asp:HiddenField ID="HidIsActive" runat="server" Value='<%#Bind("IsActive")%>' />
                                    <table class="table table-condensed table-data">
                                        <tr>
                                            <td class="table-data">
                                                <asp:Label runat="server">Main Item</asp:Label></td>
                                            <td>
                                                <asp:TextBox ID="MainItemTxt" class="form-control" runat="server" Text='<%#Bind("MainItem")%>'></asp:TextBox>
                                                <asp:RequiredFieldValidator Display="Dynamic" CssClass="validationErr" ID="RequiredFieldValidator1" ValidationGroup="g1" runat="server" ErrorMessage="Enter Main Type" ControlToValidate="MainItemTxt"></asp:RequiredFieldValidator>

                                            </td>

                                        </tr>
                                        <tr>
                                            <td class="table-data">
                                                <asp:Label runat="server">Category</asp:Label></td>
                                            <td>
                                                <asp:DropDownList ID="CategoryDDL" class="form-control control-txt" runat="server">
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator CssClass="validationErr" Display="Dynamic" ValidationGroup="g1" ID="RequiredFieldValidator3" runat="server" ErrorMessage="Select Category" ControlToValidate="CategoryDDL"></asp:RequiredFieldValidator>
                                            </td>
                                            
                                        </tr>
                                        <tr>

                                            <td>
                                                <asp:Label runat="server">Active</asp:Label></td>

                                            <td>
                                                <asp:DropDownList ID="IsActiveDDL" class="form-control control-txt" runat="server">
                                                    <asp:ListItem Value="1">Yes</asp:ListItem>
                                                    <asp:ListItem Value="0">No</asp:ListItem>

                                                </asp:DropDownList>
                                            </td>
                                        </tr>

                                        <tr>
                                            <td colspan="3">
                                                <asp:LinkButton ID="cancelImageButton" ValidationGroup="g2" class="btn btn-custom" runat="server" CommandName="cancel"
                                                    ToolTip="Cancel"><span class="glyphicon glyphicon-arrow-left"></span></asp:LinkButton>
                                                <asp:LinkButton class="btn btn-custom" ID="saveImageButton" runat="server" CommandName="update"
                                                    ToolTip="Save" ValidationGroup="g1"><span class="glyphicon glyphicon-floppy-disk"></span></asp:LinkButton>

                                            </td>
                                        </tr>
                                    </table>
                                </td>

                            </tr>
                        </EditItemTemplate>

                        <InsertItemTemplate>
                            <tr>
                                <td colspan="7">
                                    <table class="table table-condensed table-data">
                                        <tr>
                                            <td class="table-data">
                                                <asp:Label runat="server">Main Item</asp:Label></td>
                                            <td>
                                                <asp:TextBox ID="MainItemTxt" class="form-control" runat="server" Text=''></asp:TextBox>
                                                <asp:RequiredFieldValidator CssClass="validationErr" Display="Dynamic" ID="RequiredFieldValidator1" ValidationGroup="g1" runat="server" ErrorMessage="Enter Main Type" ControlToValidate="MainItemTxt"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>

                                            <td>
                                                <asp:Label runat="server">Active</asp:Label></td>

                                            <td>
                                                <asp:DropDownList ID="IsActiveDDL" class="form-control control-txt" runat="server">
                                                    <asp:ListItem Value="1">Yes</asp:ListItem>
                                                    <asp:ListItem Value="0">No</asp:ListItem>

                                                </asp:DropDownList>
                                            </td>
                                        </tr>

                                        <tr>
                                            <td colspan="3">
                                                <asp:LinkButton ID="LinkButton2" ValidationGroup="g2" class="btn btn-custom" runat="server" CommandName="cancel"
                                                    ToolTip="Cancel"><span class="glyphicon glyphicon-arrow-left"></span></asp:LinkButton>
                                                <asp:LinkButton class="btn btn-custom" ID="LinkButton3" runat="server" CommandName="insert"
                                                    ToolTip="Save" ValidationGroup="g1"><span class="glyphicon glyphicon-floppy-disk"></span></asp:LinkButton>

                                            </td>
                                        </tr>
                                    </table>
                                </td>

                            </tr>
                        </InsertItemTemplate>
                        <EmptyDataTemplate>
                            <tr>
                                <td colspan="4" class="altCent" align="center">No Data Found</td>
                            </tr>
                        </EmptyDataTemplate>
                    </asp:ListView>

                   
                </table>


            </div>
        </div>

</asp:Content>
