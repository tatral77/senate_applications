<%@ Page Title="" Language="C#" MasterPageFile="~/Application.master"  validateRequest="false" AutoEventWireup="true" CodeBehind="ManagePages.aspx.cs" Inherits="Management.ManagePages" %>
<asp:Content ID="Content1" ContentPlaceHolderID="EmpMenues" runat="server">
      <div class="container container-fluid">
        <div class="row">
            <div class="col-md-9">
                <label class="page-header page-title">Manage Pages</label>
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
                        <th>Page Title</th>
                        <th>Url</th>
                        <th>Inner Function</th>
                        <th>Inner CSS</th>
                        <th>Action</th>
                    </tr>
                    <asp:ListView ID="PageLv" runat="server"
                        OnItemEditing="ItemEditing"
                        OnItemInserting="ItemInserting"
                        OnItemCanceling="ItemCanceling"
                        OnItemUpdating="ItemUpdating"
                        OnItemDataBound="ItemDataBound"
                        OnItemCreated="ItemCreated">
                        <ItemTemplate>
                            <tr>

                                <asp:HiddenField ID="HidPageId"  runat="server" Value='<%#Bind("PageId")%>' />
                                <td class="itemCent">
                                    <asp:Label ID="SrNo" runat="server" Text='<%#Container.DataItemIndex + 1%> '></asp:Label></td>
                                <td class="itemLeft">
                                    <asp:Label ID="DescriptionTxt" runat="server" Text='<%#Bind("PageTitle")%>'></asp:Label></td>
                                <td class="itemLeft">
                                    <asp:Label ID="Label4" runat="server" Text='<%#Bind("Url")%>'></asp:Label></td>
                                   <td class="itemLeft">
                                    <asp:Label ID="Label7" runat="server" Text='<%#Bind("InnerFunction")%>'></asp:Label></td>
                                   <td class="itemLeft">
                                    <asp:Label ID="Label8" runat="server" Text='<%#Bind("InnerCss")%>'></asp:Label></td>
                                <td class="itemCent">

                                    <asp:LinkButton ID="editImageButton" class="btn btn-custom" runat="server" CommandName="edit"
                                        ToolTip="Edit"><span class="glyphicon glyphicon-pencil"></span></asp:LinkButton>
                                      <asp:LinkButton ID="deleteImageButton" class="btn btn-custom" runat="server" CommandName="delete"
                                        ToolTip="Delete" OnClientClick="return confirm('Are you sure you want to delete Page?');">
                                          <span class="glyphicon glyphicon-erase"></span></asp:LinkButton>
                                  
                                </td>
                            </tr>
                        </ItemTemplate>

                        <EditItemTemplate>
                            <tr>

                                <asp:HiddenField ID="HidPageId" runat="server" Value='<%#Bind("PageId")%>' />
                                <td class="altCent">
                                    <asp:Label ID="Label2" runat="server" Text='<%#Container.DataItemIndex + 1%> '></asp:Label></td>
                                <td class="altLeft">
                                    <asp:TextBox ID="PageTitleTxt" class="form-control" runat="server" Text='<%#Bind("PageTitle")%>'></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" Display="Dynamic" Text="*" runat="server" ErrorMessage="Page Title" ControlToValidate="PageTitleTxt" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator></td>
                                <td class="altLeft">
                                    <asp:TextBox ID="UrlTxt" class="form-control" runat="server" Text='<%#Bind("Url")%>'></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" Display="Dynamic" Text="*" runat="server" ErrorMessage="Page URL" ControlToValidate="UrlTxt" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator></td>
                                   <td class="altLeft">
                                    <asp:TextBox ID="InnerFunctionTxt" class="form-control" runat="server" Text='<%#Bind("InnerFunction")%>'></asp:TextBox>
                                   </td>
                                <td class="altLeft">
                                    <asp:TextBox ID="InnerCssTxt" class="form-control" runat="server" Text='<%#Bind("InnerCss")%>'></asp:TextBox>
                                    </td>
                               <td class="altCent" width="10%">
                                    <asp:LinkButton ID="cancelImageButton" class="btn btn-custom" runat="server" CommandName="cancel"
                                        ToolTip="Cancel"><span class="glyphicon glyphicon-arrow-left"></span></asp:LinkButton>
                                    <asp:LinkButton class="btn btn-custom" ID="saveImageButton" runat="server" CommandName="update"
                                        ToolTip="Save" ValidationGroup="Group1"><span class="glyphicon glyphicon-floppy-disk"></span></asp:LinkButton>
                                </td>
                            </tr>

                        </EditItemTemplate>
                        <InsertItemTemplate>
                              <tr>
                                <td class="altCent">
                                    <asp:Label ID="Label3" runat="server" Text='<%#Container.DataItemIndex + 1%> '></asp:Label></td>
                                <td class="altLeft">
                                    <asp:TextBox ID="PageTitleTxt" class="form-control" runat="server" Text=''></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" Display="Dynamic" Text="*" runat="server" ErrorMessage="Page Title" ControlToValidate="PageTitleTxt" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator></td>
                                <td class="altLeft">
                                    <asp:TextBox ID="UrlTxt" class="form-control" runat="server" Text=''></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" Display="Dynamic" Text="*" runat="server" ErrorMessage="Page Url" ControlToValidate="UrlTxt" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator></td>
                                     <td class="altLeft">
                                    <asp:TextBox ID="InnerFunctionTxt" class="form-control" runat="server" Text=''></asp:TextBox>
                                   </td>
                                <td class="altLeft">
                                    <asp:TextBox ID="InnerCssTxt" class="form-control" runat="server" Text=''></asp:TextBox>
                                    </td>
                                <td class="altCent" width="10%">
                                    <asp:LinkButton ID="LinkButton2" class="btn btn-custom" runat="server" CommandName="cancel"
                                        ToolTip="Cancel"><span class="glyphicon glyphicon-arrow-left"></span></asp:LinkButton>
                                    <asp:LinkButton class="btn btn-custom" ID="LinkButton3" runat="server" CommandName="insert"
                                        ToolTip="Insert" ValidationGroup="Group1"><span class="glyphicon glyphicon-floppy-disk"></span></asp:LinkButton>
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
    </div>
</asp:Content>
