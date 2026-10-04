<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="ManageMajorObjects.aspx.cs" Inherits="Budget.ManageMojaorObjects" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="container">
        <div class="row">
            <div class="col-md-9">
                <label id="header" runat="server" class="page-header page-title"></label>
            </div>
            <div class="col-md-2 page-header" style="text-align: center">
                <asp:Button ID="Button1" runat="server" CommandName="new" Text="Add New" OnClick="newLinkButton_Click" class="btn btn-success" />

            </div>
        </div>
         <div class="row">
             <div class="col-md-12">
                 <asp:Label runat="server" ID="err" style="color:red;" Text=""></asp:Label>
             </div>
             </div>
             
        <div class="row" style="margin-top: 10px">

            <div class="col-md-11">

                <table class="table table-hover table-striped table-condensed table-data table-responsive">
                    <thead>
                        <tr>
                            <th>Sr#</th>
                            <th style="width: 40%">Major Object</th>
                             <th>Allocated Amount</th>
                            <th>Remaining Amount</th>
                            <th>Action</th>


                        </tr>
                    </thead>
                    <tr>
                        <td colspan="4">
                            <asp:ValidationSummary ID="ValidationSummary1"
                                HeaderText="You must enter a value in the following fields:"
                                DisplayMode="BulletList"
                                EnableClientScript="true"
                                ShowSummary="true"
                                runat="server" ValidationGroup="Group1" ForeColor="#FF3300" />
                        </td>
                    </tr>
                    <asp:ListView ID="LV" runat="server"
                        OnItemCanceling="ItemCanceling"
                        OnItemCreated="ItemCreated"
                        OnItemDeleting="ItemDeleting"
                        OnItemInserting="ItemInserting"
                        OnItemEditing="ItemEditing"
                        OnItemDataBound="ItemDataBound"
                        OnItemUpdating="ItemUpdating">
                        <ItemTemplate>
                            <tr>
                                <td>
                                    <asp:HiddenField ID="HidMajorObject" runat="server" Value='<%#Bind("MajorObjectId")%>' />
                                    <asp:Label ID="SrNo" runat="server" Text='<%#Container.DataItemIndex + 1%> '></asp:Label></td>
                                <td>
                                    <asp:HyperLink class="table-data" ID="HyperLink1" runat="server" Style="color: black;" NavigateUrl='<%#GetLink(Convert.ToInt32(Eval("MajorObjectId")))%>'><%#Eval("MajorObject")%></asp:HyperLink>
                                </td>
                                   <td>
                                    <asp:Label class="table-data" ID="HyperLink2" runat="server" Text='<%#FormatAmount(Convert.ToDouble(Eval("MajorObjectAmount")))%>'></asp:Label>
                                </td>
                                 <td>
                                    <asp:Label class="table-data" ID="Label1" runat="server" Text='<%#FormatAmount(Convert.ToDouble(Eval("MajorObjectRemaining")))%>'></asp:Label>
                                </td>
                                <td>
                                    <asp:LinkButton ID="editImageButton" class="btn btn-success" runat="server" CommandName="edit"
                                        ToolTip="Edit"><span class="glyphicon glyphicon-pencil"></span></asp:LinkButton>
                                    <asp:LinkButton ID="deleteImageButton" class="btn btn-danger" runat="server" CommandName="delete"
                                        ToolTip="Delete" OnClientClick="return confirm('Are you sure you want to delete the Posting of Employee');"><span class="glyphicon glyphicon-erase"></span></asp:LinkButton>
                                </td>
                            </tr>

                        </ItemTemplate>

                        <EditItemTemplate>
                            <tr>
                                <td colspan="9">
                                    <asp:HiddenField ID="HidMajorObjectId" runat="server" Value='<%#Bind("MajorObjectId")%>' />
                                    <asp:HiddenField ID="HidFundCenterId" runat="server" Value='<%#Bind("FundCenterId")%>' />
                                    <table class="table table-condensed table-data">
                                        <tr>
                                            <td>Major Object:</td>
                                            <td>
                                                <asp:TextBox ID="MajorObjectTxt" required="true" class="form-control" runat="server" Text='<%#Bind("MajorObject")%>'></asp:TextBox>
                                                </td>
                                    </tr>
                                        <tr>
                                            <td>Fund Center:</td>
                                            <td><asp:DropDownList ID="FundCenterDDL" runat="server" class="form-control"><asp:ListItem Selected="True" Value="0">Select</asp:ListItem></asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" Text="*" Display="Dynamic" runat="server" ErrorMessage="Post" ControlToValidate="FundCenterDDL" InitialValue="0" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                                            </td>
                                    </tr>
                                <tr>
                                <td>Action:</td>
                                <td class="altCent">
                                    <asp:LinkButton ID="cancelImageButton" class="btn btn-success" runat="server" CommandName="cancel"
                                        ToolTip="Cancel"><span class="glyphicon glyphicon-arrow-left"></span></asp:LinkButton>
                                    <asp:LinkButton class="btn btn-success" ID="saveImageButton" runat="server" CommandName="update"
                                        ToolTip="Save" ValidationGroup="Group1"><span class="glyphicon glyphicon-floppy-disk"></span></asp:LinkButton>
                                    <asp:Label ID="ErrorLabel" runat="server" Text="" Style="color: red; font-size: small"></asp:Label>
                                </td>
                            </tr>
                            </table>
</td>
</tr>
                        </EditItemTemplate>
                        <InsertItemTemplate>
                            <tr>
                                <tr>
                                    <td colspan="9">
                                        <table class="table table-condensed table-data">
                                            <tr>
                                                <td>Major Object:</td>
                                                <td>
                                                    <asp:TextBox ID="MajorObjectTxt" required="true" class="form-control" runat="server" Text=''></asp:TextBox>
                                            </tr>
                                            <tr>
                                                <td>Action:</td>
                                                <td class="altCent">
                                                    <asp:LinkButton ID="LinkButton1" class="btn btn-success" runat="server" CommandName="cancel"
                                                        ToolTip="Cancel"><span class="glyphicon glyphicon-arrow-left"></span></asp:LinkButton>
                                                    <asp:LinkButton class="btn btn-success" ID="LinkButton2" runat="server" CommandName="insert"
                                                        ToolTip="Save" ValidationGroup="Group1"><span class="glyphicon glyphicon-floppy-disk"></span></asp:LinkButton>
                                                    <asp:Label ID="Label3" runat="server" Text="" Style="color: red; font-size: small"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                        </InsertItemTemplate>

                    </asp:ListView>


                </table>
            </div>
        </div>

    </div>
</asp:Content>
