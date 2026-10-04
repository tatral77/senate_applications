<%@ Page Title="" Language="C#" MasterPageFile="~/Application.master" AutoEventWireup="true" CodeBehind="ManageUsers.aspx.cs" Inherits="Management.ManageUsers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="EmpMenues" runat="server">
    <div class="container container-fluid">
        <div class="row">
            <div class="col-md-9">
                <label class="page-header page-title">Users</label>
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
                         <th>User Id</th>
                        <th>Full Name</th>
                        <th>User Name</th>
                        <th>Password</th>
                        <th>User Type</th>
                        <th>Role</th>
                        <th>Is Active</th>
                        <th>Action</th>
                    </tr>
                    <asp:ListView ID="UserLv" runat="server"
                        OnItemEditing="ItemEditing"
                        OnItemInserting="ItemInserting"
                        OnItemCanceling="ItemCanceling"
                        OnItemUpdating="ItemUpdating"
                        OnItemDataBound="ItemDataBound"
                        OnItemCreated="ItemCreated">

                        <ItemTemplate>
                            <tr>

                                <asp:HiddenField ID="HidRoleId" runat="server" Value='<%#Bind("UserId")%>' />
                                <td class="itemCent">
                                    <asp:Label ID="SrNo" runat="server" Text='<%#Container.DataItemIndex + 1%> '></asp:Label></td>
                                 <td class="itemLeft">
                                    <asp:Label ID="Label3" runat="server" Text='<%#Bind("UserId")%>'></asp:Label></td>
                                <td class="itemLeft">
                                    <asp:Label ID="DescriptionTxt" runat="server" Text='<%#Bind("FullName")%>'></asp:Label></td>
                                <td class="itemLeft">
                                    <asp:Label ID="Label4" runat="server" Text='<%#Bind("UserName")%>'></asp:Label></td>
                                <td class="itemLeft">
                                    <asp:Label ID="Label5" runat="server" Text='<%#Bind("Password")%>'></asp:Label></td>
                                 <td class="itemLeft">
                                    <asp:Label ID="Label7" runat="server" Text='<%#Bind("UserType")%>'></asp:Label></td>
                                <td class="itemLeft">
                                    <asp:Label ID="Label6" runat="server" Text='<%#Bind("Role")%>'></asp:Label></td>
                               
                                <td class="itemCent">
                                    <asp:Label ID="Label1" runat="server" Text='<%# GetStatus(Convert.ToInt32(Eval("IsActive")))%>'></asp:Label></td>

                                <td class="itemCent">
                                    <asp:LinkButton ID="editImageButton" class="btn btn-custom" runat="server" CommandName="edit"
                                        ToolTip="Edit"><span class="glyphicon glyphicon-pencil"></span></asp:LinkButton>
                                    <%-- <asp:ImageButton ID="deleteImageButton" runat="server"  CommandName="delete"
                                 ToolTip="Delete" OnClientClick="return confirm('Are you sure you want to delete the passport of Employee');" />--%>
                                </td>
                            </tr>
                        </ItemTemplate>

                        <EditItemTemplate>
                            <tr>

                                <asp:HiddenField ID="HidUserId" runat="server" Value='<%#Bind("UserId")%>' />
                                <asp:HiddenField ID="HidUserTypeId" runat="server" Value='<%#Bind("UserTypeId")%>' />
                                <asp:HiddenField ID="HidRoleId" runat="server" Value='<%#Bind("RoleId")%>' />
                                <asp:HiddenField ID="HidIsActive" runat="server" Value='<%#Bind("IsActive")%>' />

                                <td class="altCent">
                                    <asp:Label ID="Label2" runat="server" Text='<%#Container.DataItemIndex + 1%> '></asp:Label>
                                </td>
                               <td> <asp:Label ID="Label8" runat="server" Text='<%#Bind("UserId")%>'></asp:Label></td>
                                <td class="altLeft">
                                    <asp:TextBox ID="FullNameTxt" class="form-control" runat="server" Text='<%#Bind("FullName")%>'></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" Display="Dynamic" Text="*" runat="server" ErrorMessage="Full Name" ControlToValidate="FullNameTxt" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator></td>
                                <td class="altLeft">
                                    <asp:TextBox ID="UserNameTxt" class="form-control" runat="server" Text='<%#Bind("UserName")%>'></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" Display="Dynamic" Text="*" runat="server" ErrorMessage="User Name" ControlToValidate="UserNameTxt" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator></td>
                                <td class="altLeft">
                                    <asp:TextBox ID="PasswordTxt" class="form-control" runat="server" Text='<%#Bind("Password")%>'></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" Display="Dynamic" Text="*" runat="server" ErrorMessage="Password" ControlToValidate="PasswordTxt" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator></td>
                                <td class="altLeft">
                                    <asp:DropDownList class="form-control" ID="UserTypeDDL" runat="server">
                                    </asp:DropDownList>
                                </td>
                                <td class="altLeft">
                                    <asp:DropDownList class="form-control" ID="RoleDDL" runat="server">
                                    </asp:DropDownList>
                                </td>

                                <td class="altLeft">
                                    <asp:DropDownList class="form-control" ID="IsActiveDDL" runat="server">
                                        <asp:ListItem Value="1">Yes</asp:ListItem>
                                        <asp:ListItem Value="0">No</asp:ListItem>
                                    </asp:DropDownList>
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
                                    <asp:Label ID="Label2" runat="server" Text='<%#Container.DataItemIndex + 1%> '></asp:Label></td><td>0</td>
                                <td class="altLeft">
                                    <asp:TextBox ID="FullNameTxt" class="form-control" runat="server" Text=''></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" Display="Dynamic" Text="*" runat="server" ErrorMessage="Full Name" ControlToValidate="FullNameTxt" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator></td>
                                <td class="altLeft">
                                    <asp:TextBox ID="UserNameTxt" class="form-control" runat="server" Text=''></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" Display="Dynamic" Text="*" runat="server" ErrorMessage="User Name" ControlToValidate="UserNameTxt" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator></td>
                                <td class="altLeft">
                                    <asp:TextBox ID="PasswordTxt" class="form-control" runat="server" Text=''></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" Display="Dynamic" Text="*" runat="server" ErrorMessage="Password" ControlToValidate="PasswordTxt" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator></td>
                                <td class="altLeft">
                                    <asp:DropDownList class="form-control" ID="UserTypeDDL" runat="server">
                                    </asp:DropDownList>
                                </td>
                                <td class="altLeft">
                                    <asp:DropDownList class="form-control" ID="RoleDDL" runat="server">
                                    </asp:DropDownList>
                                </td>

                                <td class="altLeft">
                                    <asp:DropDownList class="form-control" ID="IsActiveDDL" runat="server">
                                        <asp:ListItem Value="1">Yes</asp:ListItem>
                                        <asp:ListItem Value="0">No</asp:ListItem>
                                    </asp:DropDownList>
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
