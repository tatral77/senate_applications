<%@ Page Title="" Language="C#" MasterPageFile="~/EmployeeInformation.master" AutoEventWireup="true" CodeBehind="EmpHistoryDetails.aspx.cs"  Inherits="EstablishmentASP.EmpHistoryDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="EmpMenues" runat="server">

 <div class="container container-fluid">
        <div class="row">
            <div class="col-md-9">
                <label class="page-header page-title">EMPLOYMENT HISTORY</label>
                </div>
            <div class="col-md-2 page-header ">
                <asp:Button ID="LinkButton1" class="btn btn-custom" runat="server" Text="Add New" CommandName="new" onclick="EmpDetailButton_Click" />

            </div></div>
      <div class="row">
        <div class="col-md-11">
 <table class="table table-data table-condensed table-striped table-hover">
     <thead>
      <tr>
    <th>Sr. No</th>
    <th>Designation</th>
     <th>Branch</th>
     <th>Posted From</th>
     <th>Posted To</th>
     <th style="width:30%">Details</th>
     <th>Action</th>
     
    </tr>
         </thead>
     <tbody>
         
    
    <asp:ListView ID="EmpHistory" 
    OnItemEditing="EmpHistory_ItemEditing"
    OnItemDataBound="EmpHistory_ItemDataBound"
    OnItemCanceling="EmpHistory_ItemCanceling"
    OnItemUpdating="EmpHistory_ItemUpdating"
    OnItemDeleting="EmpHistory_ItemDeleting"
    OnItemCreated="EmpHistory_ItemCreated"
    OnItemInserting="EmpHistory_ItemInserting"
    runat="server">
    <ItemTemplate>
    <tr>
                        <td>    
                                <asp:HiddenField ID="HidEmpHistoryId" runat="server" Value='<%#Bind("EmploymentHistoryId") %>' />
                               
                           <asp:Label ID="Label3" runat="server" style="font-family: Verdana;font-weight: lighter;" Text='<%#Container.DataItemIndex + 1%> ' />
                        </td>
                        <td>
                            <asp:Label ID="DesignationLabel" style="font-family: Verdana;font-weight: lighter;" runat="server" Text='<%#Eval("Post") %>' />
                        </td>
                        <td>
                           <asp:Label ID="BranchLabel" style="font-family: Verdana;font-weight: lighter;" runat="server" Text='<%#Eval("BPS")%>' />
                        </td>
                        <td>
                           <%--<asp:Label ID="PostedFrom" style="font-family: Verdana;font-weight: lighter;" runat="server" Text='<%#Bind("StayFrom","{0:dd/MM/yyyy}")%>' />--%>
                            <asp:Label ID="PostedFrom" style="font-family: Verdana;font-weight: lighter;" runat="server" Text='<%#GetDate(Convert.ToDateTime(Eval("StayFrom")))%>' />
                        </td>
                        <td>
                           <%--<asp:Label ID="PostedTo" style="font-family: Verdana;font-weight: lighter;" runat="server" Text='<%#Bind("StayTo","{0:dd/MM/yyyy}") %>' />--%>
                           <asp:Label ID="Label1" style="font-family: Verdana;font-weight: lighter;" runat="server" Text='<%#GetDate(Convert.ToDateTime(Eval("StayTo")))%>' />
                        </td>
                        <td>
                           <asp:Label ID="Remarks" style="font-family: Verdana;font-weight: lighter;" runat="server" Text='<%#Bind("Rems") %>' />
                        </td>
                          <td>
                                <asp:LinkButton ID="editImageButton" class="btn btn-custom" runat="server"  CommandName="edit"
                                 ToolTip="Edit"><span class="glyphicon glyphicon-pencil"></span></asp:LinkButton>
                                <asp:LinkButton ID="deleteImageButton" class="btn btn-custom" runat="server"  CommandName="delete"
                                 ToolTip="Delete" OnClientClick="return confirm('Are you sure you want to delete the record ?');"><span class="glyphicon glyphicon-erase"></span></asp:LinkButton>
                        </td>
                        
      </tr>
    </ItemTemplate>
    
    <EditItemTemplate>
            <tr>
                <td colspan="7">
                    <asp:ValidationSummary ID="ValidationSummary1" HeaderText="You must enter a value in the following fields:" DisplayMode="BulletList" EnableClientScript="true" ShowSummary="true" runat="server" ValidationGroup="Group1" ForeColor="#FF3300" />
                </td>
            </tr>
            <tr>
                <td colspan="7">
                <asp:HiddenField ID="HidEmpHistoryId" runat="server" Value='<%#Bind("EmploymentHistoryId") %>' />
                <asp:HiddenField ID="HidDesignationId" runat="server" Value='<%#Bind("DesigId") %>' />
                <asp:HiddenField ID="HidBranchId" runat="server" Value='<%#Bind("BranchId") %>' />
                <table class="table table-condensed table-data">
                <tr>
                    <td class="table-data">Designation</td>
                    <td>
                        <asp:DropDownList ID="DesignationDDL" class="form-control" runat="server"> </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" Text="*" runat="server" ErrorMessage="Post" ControlToValidate="DesignationDDL" InitialValue="0" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">Branch</td>
                    <td>
                        <asp:DropDownList ID="BranchDDL" class="form-control" runat="server" > </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" Text="*" runat="server" ErrorMessage="Branch" ControlToValidate="BranchDDL" InitialValue="0" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">Posted From</td>
                    <td>
                        <asp:TextBox ID="PostedFromTxt" class="form-control js-date" runat="server" Text='<%#GetDate(Convert.ToDateTime(Eval("StayFrom")))%>' />
                        <asp:CompareValidator id="dateValidator" runat="server" Type="Date" ValidationGroup="Group1" Operator="DataTypeCheck" Text="*" ControlToValidate="PostedFromTxt" ErrorMessage="Please enter a valid date."></asp:CompareValidator>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" Text="*" runat="server" ErrorMessage="Posted From" ControlToValidate="PostedFromTxt" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">Posted To</td>
                    <td>
                        <asp:TextBox ID="PostedToTxt" class="form-control js-date" runat="server" Text='<%#GetDate(Convert.ToDateTime(Eval("StayTo"))) %>' />
                        <asp:CustomValidator ID="DateRangeVal" runat="server" ControlToValidate="PostedToTxt" ClientValidationFunction="HrmDateRange" Display="Dynamic" ValidationGroup="Group1" Text="To Date cannot be earlier than From Date." ErrorMessage="To Date cannot be earlier than From Date."></asp:CustomValidator>
                        <asp:CompareValidator id="CompareValidator1" runat="server" Type="Date" ValidationGroup="Group1" Operator="DataTypeCheck" Text="*" ControlToValidate="PostedToTxt" ErrorMessage="Please enter a valid date."></asp:CompareValidator>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" Text="*" runat="server" ErrorMessage="Posted To" ControlToValidate="PostedToTxt" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">Details</td>
                    <td>
                        <asp:TextBox ID="RemarksTxt" class="form-control" runat="server" Text='<%#Bind("Rems") %>' Height="121px" TextMode="MultiLine" Width="333px"/>
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
                    <asp:ValidationSummary ID="ValidationSummary1" HeaderText="You must enter a value in the following fields:" DisplayMode="BulletList" EnableClientScript="true" ShowSummary="true" runat="server" ValidationGroup="Group1" ForeColor="#FF3300"/>
                </td>
            </tr>
            <tr>
                <td colspan="7">
                <table class="table table-condensed table-data">
                <tr>
                    <td class="table-data">Designation</td>
                    <td>
                        <asp:DropDownList ID="DesignationDDL" class="form-control" runat="server"> </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" Text="*" runat="server" ErrorMessage="Post" ControlToValidate="DesignationDDL" InitialValue="0" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">Branch</td>
                    <td>
                        <asp:DropDownList ID="BranchDDL" class="form-control" runat="server" > </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" Text="*" runat="server" ErrorMessage="Branch" ControlToValidate="BranchDDL" InitialValue="0" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">Posted From</td>
                    <td>
                        <asp:TextBox ID="PostedFromTxt" class="form-control js-date" runat="server" Text="" />
                        <asp:CompareValidator id="dateValidator" runat="server" Type="Date" ValidationGroup="Group1" Operator="DataTypeCheck" Text="*" ControlToValidate="PostedFromTxt" ErrorMessage="Please enter a valid date."></asp:CompareValidator>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" Text="*" runat="server" ErrorMessage="Posted From" ControlToValidate="PostedFromTxt" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">Posted To</td>
                    <td>
                        <asp:TextBox ID="PostedToTxt" class="form-control js-date" runat="server" Text="" />
                        <asp:CustomValidator ID="DateRangeVal" runat="server" ControlToValidate="PostedToTxt" ClientValidationFunction="HrmDateRange" Display="Dynamic" ValidationGroup="Group1" Text="To Date cannot be earlier than From Date." ErrorMessage="To Date cannot be earlier than From Date."></asp:CustomValidator>
                        <asp:CompareValidator id="CompareValidator1" runat="server" Type="Date" ValidationGroup="Group1" Operator="DataTypeCheck" Text="*" ControlToValidate="PostedToTxt" ErrorMessage="Please enter a valid date."></asp:CompareValidator>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" Text="*" runat="server" ErrorMessage="Posted To" ControlToValidate="PostedToTxt" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">Details</td>
                    <td>
                        <asp:TextBox ID="RemarksTxt" class="form-control" runat="server" Text="" Height="121px" TextMode="MultiLine" Width="333px"/>
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
</div></div></div>



</asp:Content>
