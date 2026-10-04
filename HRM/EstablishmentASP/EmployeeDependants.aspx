<%@ Page Title="" Language="C#" MasterPageFile="~/EmployeeInformation.master" AutoEventWireup="true" CodeBehind="EmployeeDependants.aspx.cs" Inherits="EstablishmentASP.EmployeeDependants" %>

<asp:Content ID="Content1" ContentPlaceHolderID="EmpMenues" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="col-md-9">
                <label class="page-header page-title">DEPENDANTS</label>
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
                            <th>Name</th>
                            <th>Relation</th>
                            <th>Date of Birth</th>
                            <th>Years</th>
                            <th>Months</th>
                            <th>Action</th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:ListView ID="EmpDependantLV" runat="server"
                            OnItemEditing="ItemEditing"
                            OnItemCanceling="ItemCanceling"
                            OnItemDeleting="ItemDeleting"
                            OnItemCreated="ItemCreated"
                            OnItemDataBound="ItemDataBound"
                            OnItemUpdating="ItemUpdating"
                            OnItemInserting="ItemInserting">

                            <ItemTemplate>
                                <tr>
                                    <td>
                                        <asp:HiddenField ID="HidEmpDependantId" runat="server" Value='<%#Bind("EmpDependantId") %>' />
                                        <asp:Label ID="Label3" runat="server" Style="font-family: Verdana; font-weight: lighter;" Text='<%#Container.DataItemIndex + 1%> ' />
                                    </td>
                                    <td>
                                        <asp:Label ID="DesignationLabel" Style="font-family: Verdana; font-weight: lighter;" runat="server" Text='<%#Eval("DependantName") %>' />
                                    </td>
                                    <td>
                                        <asp:Label ID="BranchLabel" Style="font-family: Verdana; font-weight: lighter;" runat="server" Text='<%#Eval("RelationshipName")%>' />
                                    </td>
                                    <td>
                                        <asp:Label ID="PostedFrom" Style="font-family: Verdana; font-weight: lighter;" runat="server" Text='<%#GetDate(Convert.ToDateTime(Eval("DOB")))%>' />
                                    </td>
                                    <td>
                                        <asp:Label ID="Label1" Style="font-family: Verdana; font-weight: lighter;" runat="server" Text='<%#Eval("AgeYears")%>' />
                                    </td>
                                    <td>
                                        <asp:Label ID="Remarks" Style="font-family: Verdana; font-weight: lighter;" runat="server" Text='<%#Eval("AgeMonths") %>' />
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
                <td colspan="7">
                <asp:HiddenField ID="HidEmpDependantId" runat="server" Value='<%#Bind("EmpDependantId") %>' />
                <asp:HiddenField ID="HidRelationId" runat="server" Value='<%#Bind("RelationshipId") %>' />
                <asp:HiddenField ID="HidIsDependant" runat="server" Value='<%#Bind("IsDependant") %>' />
                <table class="table table-condensed table-data">
                <tr>
                    <td class="table-data">Name</td>
                    <td>
                        <asp:TextBox ID="NameTxt" class="form-control control-txt" runat="server" Text='<%#Bind("DependantName")%>'></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">Relation</td>
                    <td>
                        <asp:DropDownList ID="RelationDDL" class="form-control control-txt" runat="server"> </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">Date of Birth</td>
                    <td>
                        <asp:TextBox ID="DOBTxt" class="form-control control-txt js-date" runat="server" Text='<%#GetDate(Convert.ToDateTime(Eval("DOB")))%>'></asp:TextBox>
                        <asp:CompareValidator ID="EndDateValidator" runat="server" Type="Date" ValidationGroup="Group1" Operator="DataTypeCheck" Text="*" ControlToValidate="DOBTxt" ErrorMessage="Please enter valid date."></asp:CompareValidator>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" Text="*" runat="server" ErrorMessage="Date of Birth" ControlToValidate="DOBTxt" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">Years</td>
                    <td>
                        <asp:TextBox ID="YearsTxt" class="form-control control-txt" runat="server" Text='<%#Bind("AgeYears")%>'></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">Months</td>
                    <td>
                        <asp:TextBox ID="MonthsTxt" class="form-control control-txt" runat="server" Width="210px" Text='<%#Bind("AgeMonths")%>'></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">Dependant</td>
                    <td>
                        <asp:CheckBox CssClass="form-control" ID="IsDependant" runat="server" />
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
                <td colspan="7">
                <table class="table table-condensed table-data">
                <tr>
                    <td class="table-data">Name</td>
                    <td>
                        <asp:TextBox ID="NameTxt" class="form-control control-txt" runat="server" Text=''></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">Relation</td>
                    <td>
                        <asp:DropDownList ID="RelationDDL" class="form-control control-txt" runat="server"> </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">Date of Birth</td>
                    <td>
                        <asp:TextBox ID="DOBTxt" runat="server" class="form-control control-txt js-date" Width="210px" Text=''></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">Years</td>
                    <td>
                        <asp:TextBox ID="YearsTxt" class="form-control control-txt" runat="server" Width="210px" Text=''></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">Months</td>
                    <td>
                        <asp:TextBox ID="MonthsTxt" class="form-control control-txt" runat="server" Width="210px" Text=''></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">Dependant</td>
                    <td>
                        <asp:CheckBox ID="IsDependant" class="form-control control-txt" runat="server"></asp:CheckBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:LinkButton ID="cancelImageButton" class="btn btn-custom" runat="server" CommandName="cancel" ToolTip="Cancel"><span class="glyphicon glyphicon-arrow-left"></span></asp:LinkButton>
                        <asp:LinkButton class="btn btn-custom" ID="saveImageButton" runat="server" CommandName="insert" ToolTip="Insert" ValidationGroup="Group1"><span class="glyphicon glyphicon-floppy-disk"></span></asp:LinkButton>
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
