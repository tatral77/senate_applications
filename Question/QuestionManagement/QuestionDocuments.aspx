<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="QuestionDocuments.aspx.cs" Inherits="QuestionManagement.QuestionDocuments" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <div class="container">

        <h4 class="page-header">Manage Question Documents</h4>
        <div class="row">
            <div class="col-md-4">
                <asp:Label  runat="server">Document Description</asp:Label>
                <asp:TextBox ID="DriverDesc" ValidationGroup="g1" class="form-control" runat="server" Text='' TextMode="MultiLine"></asp:TextBox>
                <asp:RequiredFieldValidator Style="color: red;" ID="RequiredFieldValidator1" ControlToValidate="DriverDesc" ValidationGroup="g2" runat="server" ErrorMessage="Enter document description"></asp:RequiredFieldValidator>
            </div>
            <div class="col-md-3">
                 <asp:Label  runat="server">Upload File</asp:Label>
                <asp:FileUpload CssClass="btn btn-default" ID="DocumentUpload" runat="server" data-scan="true" />
            </div>
            <div class="col-md-2">
                 <asp:Label  runat="server">List for Members</asp:Label>
                <asp:DropDownList ID="IsListedDDL" class="form-control small-control" Required="true" runat="server">
                    <asp:ListItem Value="0">No</asp:ListItem>
                    <asp:ListItem Value="1">Yes</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="col-md-1">
                <br />
                <asp:Button ID="Button2" runat="server" ValidationGroup="g2" CommandName="new" Text="Save" class="btn btn-custom" OnClick="newLinkButton_Click" />
            </div>
        </div>

        <div class="row" style="margin-top: 0px !important;">
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
                         <th>Inserted By</th>
                         <th>Updated By</th>
                         <th>Is Listed</th>
                        <th>Action</th>
                    </tr>
                    <asp:ListView ID="ListView1" runat="server"
                        OnItemEditing="ItemEditing"
                        OnItemUpdating="ItemUpdating"
                        OnItemCanceling="ItemCanceling"
                        >
                        <ItemTemplate>
                            <tr>
                                <asp:HiddenField ID="HidDocumentId" runat="server" Value='<%#Bind("DocumentId")%>' />

                                <td class="itemCent">
                                    <asp:Label ID="SrNo" runat="server" Text='<%#Container.DataItemIndex + 1%> '></asp:Label></td>
                                <td class="itemLeft">
                                    <asp:Label ID="Description" runat="server" Text='<%#Bind("Description")%>'></asp:Label></td>
                                <td class="itemLeft">
                                    <asp:HyperLink ID="HyperLink1" runat="server" Text="Download" NavigateUrl='<%#"/contents/QuestionFiles/" +Eval("DocumentUrl")%>'></asp:HyperLink>
                                </td>
                                <td class="itemLeft">
                                    <asp:Label ID="Label1" runat="server" Text='<%#GetUserName(Convert.ToInt32(Eval("InsertedById"))) + " on " + Eval("InsertedOn")%>'></asp:Label></td>
                                <td class="itemLeft">
                                    <asp:Label ID="Label3" runat="server" Text='<%#GetUserName(Convert.ToInt32(Eval("UpdatedById")))%>'></asp:Label></td>
                                <td class="itemLeft">
                                   <asp:Label ID="Label2" runat="server" Text='<%#(Convert.ToInt32(Eval("IsListed"))==1)?"Yes":"No"%>'></asp:Label></td>
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
                                <asp:HiddenField ID="HidDocumentId" runat="server" Value='<%#Bind("DocumentId")%>' />
                                <asp:HiddenField ID="HidDocumentUrl" runat="server" Value='<%#Bind("DocumentUrl")%>' />
                                <asp:HiddenField ID="HidIsListed" runat="server" Value='<%#Bind("IsListed")%>' />
                                <td class="itemCent">
                                    <asp:Label ID="SrNo" runat="server" Text='<%#Container.DataItemIndex + 1%> '></asp:Label></td>
                                <td class="itemLeft">
                                    <asp:TextBox ID="DescriptionTxt" ValidationGroup="g1" class="form-control" runat="server" Text=''></asp:TextBox>
                                    <asp:RequiredFieldValidator Style="color: red;" ID="RequiredFieldValidator1" ControlToValidate="DescriptionTxt" ValidationGroup="g1" runat="server" ErrorMessage="Enter document description"></asp:RequiredFieldValidator>
                                </td>
                                <td class="itemLeft">
                                    <asp:FileUpload CssClass="btn btn-default" ID="DocumentUpload" runat="server" data-scan="true" />
                                </td>
                                <td class="itemLeft">
                                    <asp:DropDownList ID="IsListedDDL" class="form-control small-control" Required="true" runat="server">
                                        <asp:ListItem Value="0">No</asp:ListItem>
                                        <asp:ListItem Value="1">Yes</asp:ListItem>
                                    </asp:DropDownList>

                                </td>
                                <td colspan="3">
                                    <asp:LinkButton ID="cancelImageButton" class="btn btn-custom" runat="server" CommandName="cancel"
                                        ToolTip="Cancel"><span class="glyphicon glyphicon-arrow-left"></span></asp:LinkButton>
                                    <asp:LinkButton class="btn btn-custom" ID="saveImageButton" runat="server" CommandName="update"
                                        ToolTip="Save" ValidationGroup="g1"><span class="glyphicon glyphicon-floppy-disk"></span></asp:LinkButton>

                                </td>
                            </tr>
                        </EditItemTemplate>
                        <EmptyDataTemplate>
                            <tr>
                                <td colspan="4" class="altCent" align="center">No Document available</td>
                            </tr>
                        </EmptyDataTemplate>
                    </asp:ListView>
                </table>
            </div>
        </div>

    </div>
</asp:Content>
