<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="BillDocuments.aspx.cs" Inherits="Administration.BillDocuments" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        
        <h4 class="page-header">Manage Bill Documents</h4>
          <div class="row">
            <div class="col-md-12">
                    <asp:Label  ID="DriversLabel" runat="server" Text="Label"></asp:Label>
            </div>

        </div>
          <br />
        <div class="row">
            <div class="col-md-4">
                <asp:Label style="font-weight:bold" runat="server">Document Description</asp:Label>
                <asp:TextBox ID="DriverDesc" ValidationGroup="g1" class="form-control" runat="server" Text=''></asp:TextBox>
               <asp:RequiredFieldValidator Style="color: red;" ID="RequiredFieldValidator1" ControlToValidate="DriverDesc" ValidationGroup="g1" runat="server" ErrorMessage="Enter document description"></asp:RequiredFieldValidator>
            </div>
            <div class="col-md-7">
                <br />
                <asp:FileUpload  CssClass="btn btn-default" ID="driversFU" runat="server" />
            </div>
            <div class="col-md-1">
                <br />
                <asp:Button ID="Button2" runat="server" ValidationGroup="g1" CommandName="new" Text="Save" class="btn btn-success" OnClick="newLinkButton_Click" />
            </div>
        </div>

        <div class="row" style="margin-top:0px !important;">
            <div class="col-md-8" style="text-align: left">
                <asp:Label runat="server" Style="color: red; font-weight: bold" ID="errorlbl"></asp:Label>
            </div>
        </div>
      <%--  <h4 class="page-header">Available Drivers</h4>--%>
        <div class="row">
            <div class="col-md-12">
                <table class="table table-condensed table-striped table-data">
                    <tr>
                        <th>Sr#</th>
                        <th>Document Description</th>
                        <th>File</th>
                        <th>Action</th>
                    </tr>
                    <asp:ListView ID="DriversLV" runat="server"
                        OnItemDeleting="ItemDeleting">
                        <ItemTemplate>
                            <tr>
                                <asp:HiddenField ID="HidDriverId" runat="server" Value='<%#Bind("DocumentId")%>' />
                                <td class="itemCent">
                                    <asp:Label ID="SrNo" runat="server" Text='<%#Container.DataItemIndex + 1%> '></asp:Label></td>
                                <td class="itemLeft">
                                    <asp:Label ID="Description" runat="server" Text='<%#Bind("DocumentDescription")%>'></asp:Label></td>
                                <td class="itemLeft">
                                    <asp:HyperLink ID="HyperLink1" runat="server" Text="Download" NavigateUrl='<%#"Bills/" +Eval("Url")%>'></asp:HyperLink>
                                </td>
                                <td class="itemCent">
                                    <%--<asp:LinkButton ID="editImageButton" class="btn btn-custom" runat="server" CommandName="edit"
                                        ToolTip="Edit"><span class="glyphicon glyphicon-pencil"></span></asp:LinkButton>--%>
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
</asp:Content>
