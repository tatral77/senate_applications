
<%@ Page Title="" Language="C#" MasterPageFile="~/EmployeeInformation.master" AutoEventWireup="true" CodeBehind="Passport.aspx.cs" Inherits="EstablishmentASP.Passport" %>
<%@ Register TagPrefix="CP" TagName="CountryCities" Src="CountryCities.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="EmpMenues" runat="server">
<div class="container-fluid">
    <div class="row">
            <div class="col-md-9">
                <label class="page-header page-title">PASSPORT DETAILS</label>
                </div>
         <div class="col-md-2 page-header ">
                <asp:Button class="btn btn-custom" ID="Button1" runat="server" CommandName="new" Text="Add New" onclick="newLinkButton_Click" />

            </div></div>
</div>
<div class="container-fluid">
    <div class="row">
    <div class="col-md-11">
<table  class="table table-data table-condensed table-hover table-striped">
    <thead>
<tr>
<th>Sr#</th>
<th>Passport Number</th>
<th>Date of Issue</th>
<th>Valid Upto</th>
<th>Place of Issue</th>
<th>Passport Type</th>
<th>Action</th>
</tr>
</thead>
    <tbody>
         <tr>
    <td align="left" colspan="7">
    <asp:ValidationSummary ID="ValidationSummary1"
        HeaderText="You must enter a value in the following fields:"
        DisplayMode="BulletList"
        EnableClientScript="true"
        ShowSummary="true"
        runat="server" ValidationGroup="Group1" ForeColor="#FF3300" />
      </td>
    </tr>
 <asp:ListView ID="PassportsLv" runat="server"
  OnItemEditing="ItemEditing" 
  OnItemDataBound="ItemDataBound"
  OnItemCanceling="ItemCanceling"
  OnItemCreated="ItemCreated"
  OnItemDeleting="ItemDeleting"
  OnItemInserting="ItemInserting"
  OnItemUpdating="ItemUpdating"
  >
 <ItemTemplate>
 <tr>
     <asp:HiddenField ID="HidEmpPassportId" runat="server" Value='<%#Bind("EmpPassportId")%>' />
    <asp:HiddenField ID="HidEmpPassportTypeId" runat="server" Value='<%#Bind("PassportTypeId")%>' />
    <asp:HiddenField ID="EmpPassportCountryId" runat="server" Value='<%#Bind("CountryId")%>' />
    <asp:HiddenField ID="EmpPassportCityId" runat="server" Value='<%#Bind("CityId")%>' />

    <td><asp:Label ID="SrNo" runat="server" Text='<%#Container.DataItemIndex + 1%> '></asp:Label></td>
    <td><asp:Label ID="PassportNumber" runat="server" Text='<%#Bind("PassportNumber")%>'></asp:Label></td>
    <td><asp:Label ID="IssueDate"  runat="server" Text='<%#Bind("IssueDate","{0:dd/MM/yyyy}")%>'></asp:Label></td>
    <td><asp:Label ID="ValidUpto" runat="server" Text='<%#Bind("ValidUpto","{0:dd/MM/yyyy}")%>'></asp:Label></td>
    <td><asp:Label ID="IssuePlace" runat="server" Text='<%# GetCountry(Convert.ToInt32(Eval("CountryId")))%>'></asp:Label>
   
    </td>
    <td><asp:Label ID="PassportType" runat="server" Text='<%#Eval("PassportType")%>'></asp:Label></td>
    <td>
                                <asp:LinkButton ID="editImageButton" class="btn btn-custom" runat="server"  CommandName="edit"
                                 ToolTip="Edit"><span class="glyphicon glyphicon-pencil"></span></asp:LinkButton>
                                <asp:LinkButton ID="deleteImageButton" class="btn btn-custom" runat="server"  CommandName="delete"
                                 ToolTip="Delete" OnClientClick="return confirm('Are you sure you want to delete therecord ?');"><span class="glyphicon glyphicon-erase"></span></asp:LinkButton>
                        </td>
  </tr>
 </ItemTemplate>
 
  <EditItemTemplate>
            <tr>
                <td colspan="7">
                <asp:HiddenField ID="HidEmpPassportId" runat="server" Value='<%#Bind("EmpPassportId")%>' />
                <asp:HiddenField ID="HidEmpPassportTypeId" runat="server" Value='<%#Bind("PassportTypeId")%>' />
                <asp:HiddenField ID="EmpPassportCountryId" runat="server" Value='<%#Bind("CountryId")%>' />
                <asp:HiddenField ID="EmpPassportCityId" runat="server" Value='<%#Bind("CityId")%>' />
                <table class="table table-condensed table-data">
                <tr>
                    <td class="table-data">Passport Number</td>
                    <td>
                        <asp:TextBox ID="PassportNumberTxt" class="form-control" runat="server" Text='<%#Bind("PassportNumber")%>' ></asp:TextBox>
                        <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator1" Text="*" runat="server" ErrorMessage="Passport Number" ControlToValidate="PassportNumberTxt" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">Date of Issue</td>
                    <td>
                        <asp:TextBox ID="IssueDateTxt" class="form-control js-date" runat="server" Text='<%#Bind("IssueDate","{0:dd/MM/yyyy}")%>' ></asp:TextBox>
                        <asp:CompareValidator Display="Dynamic" id="dateValidator" runat="server" Type="Date" ValidationGroup="Group1" Operator="DataTypeCheck" Text="*" ControlToValidate="IssueDateTxt" ErrorMessage="Please enter a valid date."></asp:CompareValidator>
                        <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator2" Text="*" runat="server" ErrorMessage="Issue Date" ControlToValidate="IssueDateTxt" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="CompareValidator2" Type="Date" Operator="LessThan" ControlToCompare="ValidUptoTxt" ControlToValidate="IssueDateTxt" runat="server" ValidationGroup="Group1" Text="." ErrorMessage="Valid upto Date must be greater than Issue Date"></asp:CompareValidator>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">Valid Upto</td>
                    <td>
                        <asp:TextBox ID="ValidUptoTxt" class="form-control js-date" runat="server" Text='<%#Bind("ValidUpto","{0:dd/MM/yyyy}")%>'></asp:TextBox>
                        <asp:CompareValidator Display="Dynamic" id="CompareValidator1" runat="server" Type="Date" ValidationGroup="Group1" Operator="DataTypeCheck" Text="*" ControlToValidate="ValidUptoTxt" ErrorMessage="Please enter a valid date."></asp:CompareValidator>
                        <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator3" Text="*" runat="server" ErrorMessage="Valid Upto" ControlToValidate="ValidUptoTxt" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">Place of Issue</td>
                    <td>
                        <asp:DropDownList ID="IssuePlaceDDL" runat="server" class="form-control"></asp:DropDownList>
                        <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator4" Text="*" runat="server" ErrorMessage="Country of Issue" ControlToValidate="IssuePlaceDDL" InitialValue="0" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">Passport Type</td>
                    <td>
                        <asp:DropDownList ID="PassportTypeDDL" class="form-control" runat="server"></asp:DropDownList>
                        <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator6" Text="*" runat="server" ErrorMessage="Passport Type" ControlToValidate="PassportTypeDDL" InitialValue="0" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
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
                    <td class="table-data">Passport Number</td>
                    <td>
                        <asp:TextBox ID="PassportNumberTxt" class="form-control" runat="server" Text="" ></asp:TextBox>
                        <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator1" Text="*" runat="server" ErrorMessage="Passport Number" ControlToValidate="PassportNumberTxt" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">Date of Issue</td>
                    <td>
                        <asp:TextBox ID="IssueDateTxt" class="form-control js-date" runat="server" Text="" ></asp:TextBox>
                        <asp:CompareValidator Display="Dynamic" id="dateValidator" runat="server" Type="Date" ValidationGroup="Group1" Operator="DataTypeCheck" Text="*" ControlToValidate="IssueDateTxt" ErrorMessage="Please enter a valid date."></asp:CompareValidator>
                        <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator2" Text="*" runat="server" ErrorMessage="Issue Date" ControlToValidate="IssueDateTxt" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="CompareValidator2" Type="Date" Operator="LessThan" ControlToCompare="ValidUptoTxt" ControlToValidate="IssueDateTxt" runat="server" ValidationGroup="Group1" Text="." ErrorMessage="Valid upto Date must be greater than Issue Date"></asp:CompareValidator>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">Valid Upto</td>
                    <td>
                        <asp:TextBox ID="ValidUptoTxt" class="form-control js-date" runat="server" Text=""></asp:TextBox>
                        <asp:CompareValidator Display="Dynamic" id="CompareValidator1" runat="server" Type="Date" ValidationGroup="Group1" Operator="DataTypeCheck" Text="*" ControlToValidate="ValidUptoTxt" ErrorMessage="Please enter a valid date."></asp:CompareValidator>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" Text="*" runat="server" ErrorMessage="Valid Upto" ControlToValidate="ValidUptoTxt" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">Place of Issue</td>
                    <td>
                        <asp:DropDownList ID="IssuePlaceDDL" class="form-control" runat="server" ValidationGroup="Group1"></asp:DropDownList>
                        <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator4" Text="*" runat="server" ErrorMessage="Country of Issue" ControlToValidate="IssuePlaceDDL" InitialValue="0" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">Passport Type</td>
                    <td>
                        <asp:DropDownList ID="PassportTypeDDL" class="form-control" runat="server" ValidationGroup="Group1"></asp:DropDownList>
                        <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator6" Text="*" runat="server" ErrorMessage="Passport Type" ControlToValidate="PassportTypeDDL" InitialValue="0" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
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
 <EmptyDataTemplate>
    <tr>
    <td colspan="7">No Data Found</td>
    </tr>
    </EmptyDataTemplate>
 </asp:ListView>

   
        </tbody>
   </table>
 </div>
        </div>   
   
</div>
   
</asp:Content>
