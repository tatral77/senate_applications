<%@ Page Title="" Language="C#" MasterPageFile="~/EmployeeInformation.master" AutoEventWireup="true" CodeBehind="EmployeeMedical.aspx.cs" Inherits="EstablishmentASP.EmployeeMedical" %>
<asp:Content ID="Content1" ContentPlaceHolderID="EmpMenues" runat="server">
     <div class="container-fluid">
         <div class="row">
            <div class="col-md-9">
                <label class="page-header page-title">MEDICAL</label>
                </div>
            <div class="col-md-2 page-header ">
                 <asp:Button ID="LinkButton1" runat="server" CommandName="new" Text="Add New" class="btn btn-custom" onclick="newLinkButton_Click" />

            </div></div>
<div class="row">
            <div class="col-md-11">
<table class="table table-condensed table-striped table-data">
<tr>
<th>Sr#</th>
<th>Medical Type</th>
<th>Post</th>
<th>BPS</th>
<th>Checkup Date</th>
<th>Year</th>
<th>Submitted</th>
<th>Details</th>
<th>Action</th>
</tr>
 <asp:ListView ID="MedicalLv" runat="server"
  OnItemEditing="ItemEditing"
  OnItemInserting="ItemInserting"
  OnItemCanceling="ItemCanceling"
  OnItemUpdating="ItemUpdating"
  OnItemDeleting="ItemDeleting"
  OnItemDataBound="ItemDataBound"
  OnItemCreated="ItemCreated"
 >

 <ItemTemplate>
 <tr>
    
    <asp:HiddenField ID="HidMedicalId" runat="server" Value='<%#Bind("EmpMedicalId")%>' />
    <td class="itemCent"><asp:Label ID="SrNo" runat="server" Text='<%#Container.DataItemIndex + 1%> '></asp:Label></td>
    <td class="itemLeft"><asp:Label ID="Label5" runat="server" Text='<%#Bind("MedicalType")%>'></asp:Label></td>
    <td class="itemLeft"><asp:Label ID="DescriptionTxt" runat="server" Text='<%#Bind("Post")%>'></asp:Label></td>
    <td class="itemLeft"><asp:Label ID="Label1" runat="server" Text='<%#Bind("BPS")%>'></asp:Label></td>
       <td class="itemLeft"><asp:Label ID="Label3" runat="server" Text='<%#GetDate(Convert.ToDateTime(Eval("OnDate")))%>'></asp:Label></td>
     <td class="itemLeft"><asp:Label ID="Label4" runat="server" Text='<%#Bind("MedYear")%>'></asp:Label></td>
     <td class="itemLeft"><asp:Label ID="Label6" runat="server" Text='<%#(Convert.ToString(Eval("IsSubmitted"))=="1")?"Yes":"No"%>'></asp:Label></td>
       <td class="itemLeft"><asp:Label ID="Label2" runat="server" Text='<%#Bind("Remarks")%>'></asp:Label></td>

    <td class="itemCent">
                                 <asp:LinkButton ID="editImageButton" class="btn btn-custom" runat="server"  CommandName="edit"
                                 ToolTip="Edit"><span class="glyphicon glyphicon-pencil"></span></asp:LinkButton>
                              <asp:LinkButton ID="deleteImageButton" class="btn btn-custom" runat="server"  CommandName="delete"
                                 ToolTip="Delete" OnClientClick="return confirm('Are you sure you want to delete record ?');"><span class="glyphicon glyphicon-erase"></span></asp:LinkButton>
                        </td>
  </tr>
 </ItemTemplate>
 
  <EditItemTemplate>
            <tr>
                <td colspan="9">
                <asp:HiddenField ID="HidMedicalId" runat="server" Value='<%#Bind("EmpMedicalId")%>' />
                <asp:HiddenField ID="HidMedicalTypeId" runat="server" Value='<%#Bind("MedicalTypeId")%>' />
                <asp:HiddenField ID="HidPostId" runat="server" Value='<%#Bind("PostId")%>' />
                <asp:HiddenField ID="HidBPSID" runat="server" Value='<%#Bind("BPSID")%>' />
                <asp:HiddenField ID="HidSubmitted" runat="server" Value='<%#Bind("IsSubmitted")%>' />
                <table class="table table-condensed table-data">
                <tr>
                    <td class="table-data">Medical Type</td>
                    <td>
                        <asp:DropDownList ID="MedicalTypeDDL" class="form-control control-txt" runat="server"> </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">Post</td>
                    <td>
                        <asp:DropDownList ID="PostDDL" class="form-control control-txt" runat="server"> </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">BPS</td>
                    <td>
                        <asp:DropDownList ID="BPSDDL" class="form-control control-txt" runat="server"> </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">Checkup Date</td>
                    <td>
                        <asp:TextBox ID="CheckupDateTxt" class="form-control control-txt js-date" runat="server" Text='<%#GetDate(Convert.ToDateTime(Eval("OnDate")))%>' ></asp:TextBox>
                        <asp:CompareValidator id="CompareValidator1" runat="server" Type="Date" ValidationGroup="Group1" Operator="DataTypeCheck" Text="*" ControlToValidate="CheckupDateTxt" ErrorMessage="Please enter valid date."></asp:CompareValidator>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" Text="*" runat="server" ErrorMessage="Checkup Date" ControlToValidate="CheckupDateTxt" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">Years</td>
                    <td>
                        <asp:TextBox ID="MedYearTxt" class="form-control control-txt" runat="server" Text='<%#Bind("MedYear")%>' ></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">Submitted</td>
                    <td>
                        <asp:CheckBox CssClass="form-control" ID="SubmittedCB" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td class="table-data">Details</td>
                    <td>
                        <asp:TextBox ID="RemarksTxt" TextMode="MultiLine" class="form-control control-txt" runat="server" Text='<%#Bind("Remarks")%>' ></asp:TextBox>
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
                <td colspan="9">
                <table class="table table-condensed table-data">
                <tr>
                    <td class="table-data">Medical Type</td>
                    <td>
                        <asp:DropDownList ID="MedicalTypeDDL" class="form-control control-txt" runat="server"> </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">Post</td>
                    <td>
                        <asp:DropDownList ID="PostDDL" class="form-control control-txt" runat="server"> </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">BPS</td>
                    <td>
                        <asp:DropDownList ID="BPSDDL" class="form-control control-txt" runat="server"> </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">Checkup Date</td>
                    <td>
                        <asp:TextBox ID="CheckupDateTxt" class="form-control control-txt js-date" runat="server" Text='' ></asp:TextBox>
                        <asp:CompareValidator id="CompareValidator1" runat="server" Type="Date" ValidationGroup="Group1" Operator="DataTypeCheck" Text="*" ControlToValidate="CheckupDateTxt" ErrorMessage="Please enter valid date."></asp:CompareValidator>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" Text="*" runat="server" ErrorMessage="Checkup Date" ControlToValidate="CheckupDateTxt" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">Years</td>
                    <td>
                        <asp:TextBox ID="MedYearTxt" class="form-control control-txt" runat="server" Text='' ></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">Submitted</td>
                    <td>
                        <asp:CheckBox CssClass="form-control" ID="SubmittedCB" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td class="table-data">Details</td>
                    <td>
                        <asp:TextBox ID="RemarksTxt" TextMode="MultiLine" class="form-control control-txt" runat="server" Text='' ></asp:TextBox>
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
 <EmptyDataTemplate>
    <tr>
    <td colspan="9" class="altCent" align="center">No Data Found</td>
    </tr>
    </EmptyDataTemplate>
 </asp:ListView>
 
    <tr>
    <td align="left" colspan="9">
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
</div></div>
</asp:Content>
