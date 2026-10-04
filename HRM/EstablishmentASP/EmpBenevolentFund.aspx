<%@ Page Title="" Language="C#" MasterPageFile="~/EmployeeInformation.master" AutoEventWireup="true" CodeBehind="EmpBenevolentFund.aspx.cs" Inherits="EstablishmentASP.EmpBenevolentFund" %>
<asp:Content ID="Content1" ContentPlaceHolderID="EmpMenues" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="col-md-9">
                <label class="page-header page-title">BENEVOLENT FUNDS</label>
            </div>
            <div class="col-md-2 page-header ">
                <asp:Button ID="LinkButton1" class="btn btn-custom" runat="server" Text="Add New" CommandName="new" OnClick="EmpDepButton_Click" />
            </div>
        </div>
        <div class="row">
            <div class="col-md-11">
                <table class="table table-hover table-striped table-condensed table-data">
                    <thead>
                        <tr>
                            <th>Sr#</th>
                            <th>Fund Type</th>
                            <th>Amount</th>
                            <th>Date</th>
                            <th>Details</th>
                            <th>Action</th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:ListView ID="EmpBenFundsLV" runat="server"
                            OnItemEditing="ItemEditing"
                            OnItemCanceling="ItemCanceling"
                            OnItemCreated="ItemCreated"
                            OnItemDeleting="EmpBenFundsLV_ItemDeleting"
                            OnItemDataBound="ItemDataBound"
                            OnItemUpdating="ItemUpdating"
                            OnItemInserting="ItemInserting">

                            <ItemTemplate>
                                <tr>
                                    <td>
                                        <asp:HiddenField ID="EmpBenevolentFundId" runat="server" Value='<%#Bind("EmpBenevolentFundId") %>' />
                                        <asp:Label ID="Label3" runat="server" Style="font-family: Verdana; font-weight: lighter;" Text='<%#Container.DataItemIndex + 1%> ' />
                                    </td>
                                     <td>
                                        <asp:Label ID="Label2" Style="font-family: Verdana; font-weight: lighter;" runat="server" Text='<%#Eval("BenevolentFundType") %>' />
                                    </td>
                                    <td>
                                        <asp:Label ID="DesignationLabel" Style="font-family: Verdana; font-weight: lighter;" runat="server" Text='<%#Eval("Amount") %>' />
                                    </td>
                                    <td>
                                        <asp:Label ID="PostedFrom" Style="font-family: Verdana; font-weight: lighter;" runat="server" Text='<%#GetDate(Convert.ToDateTime(Eval("FundDate")))%>' />
                                    </td>
                                    <td>
                                        <asp:Label ID="Label1" Style="font-family: Verdana; font-weight: lighter;" runat="server" Text='<%#Eval("Details")%>' />
                                    </td>
                                    <td>
                                        <asp:LinkButton ID="editImageButton" class="btn btn-custom" runat="server" CommandName="edit"
                                            ToolTip="Edit"><span class="glyphicon glyphicon-pencil"></span></asp:LinkButton>
                                        <asp:LinkButton ID="deleteImageButton" class="btn btn-custom" runat="server" CommandName="delete"
                                            ToolTip="Delete" OnClientClick="return confirm('Are you sure you want to delete record ?');"><span class="glyphicon glyphicon-erase"></span></asp:LinkButton>
                                    </td>

                                </tr>
                            </ItemTemplate>

                            <EditItemTemplate>
            <tr>
                <td colspan="6">
                <asp:HiddenField ID="EmpBenevolentFundId" runat="server" Value='<%#Bind("EmpBenevolentFundId") %>' />
                <asp:HiddenField ID="BenevolentFundTypeId" runat="server" Value='<%#Bind("BenevolentFundTypeId") %>' />
                <table class="table table-condensed table-data">
                <tr>
                    <td class="table-data">Fund Type</td>
                    <td>
                        <asp:DropDownList ID="FundTypeDDL" class="form-control control-txt" runat="server"> </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" Text="Please select Fund Type" runat="server" InitialValue="0" ErrorMessage="Fund Date" ControlToValidate="FundTypeDDL" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">Amount</td>
                    <td>
                        <asp:TextBox ID="AmountTxt" class="form-control control-txt" runat="server" Text='<%#Eval("Amount")%>'></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">Date</td>
                    <td>
                        <asp:TextBox ID="FundDateTxt" class="form-control control-txt js-date" runat="server" Text='<%#GetDate(Convert.ToDateTime(Eval("FundDate")))%>'></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" Text="Enter Date" runat="server" ErrorMessage="Fund Date" ControlToValidate="FundDateTxt" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">Details</td>
                    <td>
                        <asp:TextBox ID="DetailsTxt" TextMode="MultiLine" Rows="5" class="form-control control-txt" runat="server" Text='<%#Bind("Details")%>'></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:LinkButton ID="cancelImageButton" class="btn btn-custom" runat="server" CommandName="cancel" ToolTip="Cancel"><span class="glyphicon glyphicon-arrow-left"></span></asp:LinkButton>
                        <asp:LinkButton class="btn btn-custom" ID="saveImageButton" runat="server" CommandName="update" ToolTip="Save" ValidationGroup="Group1"><span class="glyphicon glyphicon-floppy-disk"></span></asp:LinkButton>
                    </td>
                </tr>
                </table>
                </td>
            </tr>
        </EditItemTemplate>
                            <InsertItemTemplate>
            <tr>
                <td colspan="6">
                <table class="table table-condensed table-data">
                <tr>
                    <td class="table-data">Fund Type</td>
                    <td>
                        <asp:DropDownList ID="FundTypeDDL" class="form-control control-txt" runat="server"> </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" Text="Please select Fund Type" runat="server" InitialValue="0" ErrorMessage="Please select fund type" ControlToValidate="FundTypeDDL" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">Amount</td>
                    <td>
                        <asp:TextBox ID="AmountTxt" class="form-control control-txt" runat="server" Text=''></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">Date</td>
                    <td>
                        <asp:TextBox ID="FundDateTxt" class="form-control control-txt js-date" runat="server" Text=''></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" Text="Enter Date" runat="server" ErrorMessage="Fund Date" ControlToValidate="FundDateTxt" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">Details</td>
                    <td>
                        <asp:TextBox ID="DetailsTxt" TextMode="MultiLine" Rows="5" class="form-control control-txt" runat="server" Text=''></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:LinkButton ID="cancelImageButton" class="btn btn-custom" runat="server" CommandName="cancel" ToolTip="Cancel"><span class="glyphicon glyphicon-arrow-left"></span></asp:LinkButton>
                        <asp:LinkButton class="btn btn-custom" ID="saveImageButton" runat="server" CommandName="insert" ToolTip="Save" ValidationGroup="Group1"><span class="glyphicon glyphicon-floppy-disk"></span></asp:LinkButton>
                    </td>
                </tr>
                </table>
                </td>
            </tr>
        </InsertItemTemplate>
                        </asp:ListView>
                    </tbody>
                </table>
            </div>
        </div>
    </div>
</asp:Content>
