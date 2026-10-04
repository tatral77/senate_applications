<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="ManageCategories.aspx.cs" Inherits="Administration.ManageCategories" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
        <div class="row">
            <div class="col-md-9">
                <h4>
                    <label class="page-header">Manage Categories</label></h4>
            </div>
            <div class="col-md-2 page-header hideadd">
                <asp:Button ID="LinkButton1" runat="server" CommandName="new" Text="Add New" class="btn btn-custom" OnClick="newLinkButton_Click" />

            </div>
        </div>
        <div class="row">
            <div class="col-md-11">
                <table class="table table-condensed table-striped table-data">
                    <tr>
                        <th>Sr#</th>
                        <th>Category</th>
                        <th>Active</th>
                        <th class="hideall">Action</th>
                    </tr>
                    <asp:ListView ID="CategoryLV" runat="server"
                        OnItemEditing="ItemEditing"
                        OnItemInserting="ItemInserting"
                        OnItemCanceling="ItemCanceling"
                        OnItemUpdating="ItemUpdating"
                        OnItemDataBound="ItemDataBound"
                        OnItemCreated="ItemCreated">

                        <ItemTemplate>
                            <tr>

                                <asp:HiddenField ID="HidCategoryId" runat="server" Value='<%#Bind("CategoryId")%>' />
                                <td class="itemCent">
                                    <asp:Label ID="SrNo" runat="server" Text='<%#Container.DataItemIndex + 1%> '></asp:Label></td>
                                <td class="itemLeft">
                                    <asp:HyperLink class="details-link" ID="HyperLink1" runat="server" NavigateUrl='<%#Eval("CategoryId","~/ManageMainItems.aspx?CategoryId={0}")%>'><%#Eval("CategoryName").ToString()%></asp:HyperLink>
                                <td class="itemLeft">
                                    <asp:Label ID="Label2" runat="server" Text='<%#(Convert.ToInt32(Eval("IsActive"))==1)?"Yes":"No"%>'></asp:Label></td>
                                <td class="itemCent hideall">
                                    <asp:LinkButton ID="editImageButton" class="btn btn-custom hideedit" runat="server" CommandName="edit"
                                        ToolTip="Edit"><span class="glyphicon glyphicon-pencil"></span></asp:LinkButton>
                                    <asp:LinkButton ID="deleteImageButton" class="btn btn-custom hidedelete" runat="server"  CommandName="delete"
                                 ToolTip="Delete" OnClientClick="return confirm('Are you sure you want to delete record ?');"><span class="glyphicon glyphicon-erase"></span></asp:LinkButton>
                                </td>
                            </tr>
                        </ItemTemplate>

                        <EditItemTemplate>
                            <tr>
                                <td colspan="7">
                                    <asp:HiddenField ID="HidCategoryId" runat="server" Value='<%#Bind("CategoryId")%>' />
                                    <asp:HiddenField ID="HidIsActive" runat="server" Value='<%#Bind("IsActive")%>' />
                                    <table class="table table-condensed table-data">
                                        <tr>
                                            <td class="table-data">
                                                <asp:Label runat="server">Category</asp:Label></td>
                                            <td>
                                                <asp:TextBox ID="CategoryTxt" class="form-control" runat="server" Text='<%#Bind("CategoryName")%>'></asp:TextBox>
                                                <asp:RequiredFieldValidator ValidationGroup="g1" ControlToValidate="CategoryTxt" Display="Dynamic" CssClass="validationErr" ID="RequiredFieldValidator2" runat="server" ErrorMessage="Enter Category"></asp:RequiredFieldValidator>
                                            </td>

                                        </tr>
                                        <tr>
                                            <td class="table-data">
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
                                                <asp:Label runat="server">Category</asp:Label></td>
                                            <td>
                                                <asp:TextBox ID="CategoryTxt" class="form-control" runat="server" Text=''></asp:TextBox>
                                                <asp:RequiredFieldValidator ValidationGroup="g1" ControlToValidate="CategoryTxt" Display="Dynamic" CssClass="validationErr" ID="RequiredFieldValidator2" runat="server" ErrorMessage="Enter Category"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="table-data">
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
  
</asp:Content>
