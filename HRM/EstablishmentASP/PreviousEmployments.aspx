<%@ Page Title="" Language="C#" MasterPageFile="~/EmployeeInformation.master" AutoEventWireup="true" CodeBehind="PreviousEmployments.aspx.cs" Inherits="EstablishmentASP.PreviousEmployments" %>
<asp:Content ID="Content1" ContentPlaceHolderID="EmpMenues" runat="server">
      <div class="nf-head">
        <h4>PREVIOUS EMPLOYMENTS</h4>
        <asp:Button ID="Button7" class="btn btn-custom" runat="server" Text="Add New" CommandName="new" onclick="newPreviousEmpl_Click" />
    </div>
  <div id="DeputedOutn" class="regularDiv">
    <table class="table table-hover table-striped table-data">
    <thead style="text-align:center">
       <tr>
            <th>Sr#</th>
            <th>Organization</th>
           <th>Department</th>
           <th>Post</th>
           <th>BPS</th>
            <th>From Date</th>
            <th>To Date</th>
            <th>Details</th>
            <th>Action</th>
      </tr>
    </thead>
    <tbody>
    <asp:ListView ID="PreviousEmplLV" runat="server"
      OnItemCreated="PrevEmployments_ItemCreated" 
    OnItemInserting="PrevEmployments_ItemInserting"
    OnItemEditing="PrevEmployments_ItemEditing"
    OnItemDataBound="PrevEmployments_ItemDataBound"
     OnItemDeleting="PrevEmployments_ItemDeleting"
     OnItemCanceling="PrevEmployments_ItemCanceling"
     OnItemUpdating="PrevEmployments_ItemUpdating">

     
    <ItemTemplate>
    <tr>
                        <td class="itemCent">
                            <asp:HiddenField ID="HidPreviousEmplId" runat="server" Value='<%#Bind("EmpPrevEmplId") %>' />
                            <asp:HiddenField ID="HidBPSID" runat="server" Value='<%#Bind("BPSID") %>' />
                            <asp:Label ID="Label3" runat="server" class="table-data" Text='<%#Container.DataItemIndex + 1%> ' />
                        </td>
                        
                        <td>                    
                        <asp:Label ID="Label4" class="table-data" runat="server" Text='<%#Eval("Organization")%>' />
                        </td>
                         <td>                    
                        <asp:Label ID="Label1" class="table-data" runat="server" Text='<%#Eval("Department")%>' />
                        </td>
                  
                          <td>                    
                        <asp:Label ID="Label5" class="table-data" runat="server" Text='<%#Eval("Post")%>' />
                        </td>
                          <td>                    
                        <asp:Label ID="Label6" class="table-data" runat="server" Text='<%#Eval("BPS")%>' />
                        </td>
            
                        <td>              
                        <asp:Label ID="Label2" class="table-data" runat="server" Text='<%#GetDate(Convert.ToDateTime(Eval("FromDate")))%>' />
                        </td>
                         <td>
                           <asp:Label ID="DateLabel" class="table-data" runat="server" Text='<%#GetDate(Convert.ToDateTime(Eval("ToDate")))%>' />
                        </td>
                       
                         <td>
                           <asp:Label ID="Label8" class="table-data" runat="server" Text='<%#Bind("Remarks")%>' />
                        </td>
                        <td>
                                <asp:LinkButton ID="editImageButton" class="btn btn-custom" runat="server"  CommandName="edit"
                                 ToolTip="Edit"><span class="glyphicon glyphicon-pencil"></span></asp:LinkButton>
                                <asp:LinkButton ID="deleteImageButton" class="btn btn-custom" runat="server"  CommandName="delete"
                                 ToolTip="Delete" OnClientClick="return confirm('Are you sure you want to delete therecord ?');"><span class="glyphicon glyphicon-erase"></span></asp:LinkButton>
                        </td>

    </tr>
       </ItemTemplate>
   
 
    <InsertItemTemplate>
            <tr>
                <td colspan="9">
                <table class="table table-condensed table-data">
                <tr>
                    <td class="table-data">Organization</td>
                    <td>
                        <asp:TextBox ID="OrganizationTxt" class="form-control" runat="server" Text='' />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" Display="Dynamic" Text="*" runat="server" ErrorMessage="Organization" ControlToValidate="OrganizationTxt" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">Department</td>
                    <td>
                        <asp:TextBox ID="DepartmentTxt" class="form-control" runat="server" Text='' />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" Display="Dynamic" Text="*" runat="server" ErrorMessage="Department" ControlToValidate="DepartmentTxt" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">Post</td>
                    <td>
                        <asp:TextBox ID="PostTxt" class="form-control" runat="server" Text='' />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" Display="Dynamic" Text="*" runat="server" ErrorMessage="Post" ControlToValidate="PostTxt" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">BPS</td>
                    <td>
                        <asp:DropDownList ID="BPSDDL" class="form-control" runat="server" > </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">From Date</td>
                    <td>
                        <asp:TextBox ID="FromDateTxt" class="form-control js-date" runat="server" Text='' />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" Display="Dynamic" Text="*" runat="server" ErrorMessage="Employment From" ControlToValidate="FromDateTxt" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">To Date</td>
                    <td>
                        <asp:TextBox ID="ToDateTxt" class="form-control js-date" runat="server" Text='' />
                        <asp:CustomValidator ID="DateRangeVal" runat="server" ControlToValidate="ToDateTxt" ClientValidationFunction="HrmDateRange" Display="Dynamic" ValidationGroup="Group1" Text="To Date cannot be earlier than From Date." ErrorMessage="To Date cannot be earlier than From Date."></asp:CustomValidator>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" Display="Dynamic" Text="*" runat="server" ErrorMessage="Employment To" ControlToValidate="ToDateTxt" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">Details</td>
                    <td>
                        <asp:TextBox ID="RemarksTxt" class="form-control" runat="server" Text='' Height="121px" TextMode="MultiLine" Width="333px"/>
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
        <EditItemTemplate>
            <tr>
                <td colspan="9">
                <asp:HiddenField ID="HidPreviousEmplId" runat="server" Value='<%#Bind("EmpPrevEmplId") %>' />
                <asp:HiddenField ID="HidBPSID" runat="server" Value='<%#Bind("BPSID") %>' />
                <table class="table table-condensed table-data">
                <tr>
                    <td class="table-data">Organization</td>
                    <td>
                        <asp:TextBox ID="OrganizationTxt" class="form-control" runat="server" Text='<%#Bind("Organization")%>' />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" Display="Dynamic" Text="*" runat="server" ErrorMessage="Organization" ControlToValidate="OrganizationTxt" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">Department</td>
                    <td>
                        <asp:TextBox ID="DepartmentTxt" class="form-control" runat="server" Text='<%#Bind("Department")%>' />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" Display="Dynamic" Text="*" runat="server" ErrorMessage="Department" ControlToValidate="DepartmentTxt" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">Post</td>
                    <td>
                        <asp:TextBox ID="PostTxt" class="form-control" runat="server" Text='<%#Bind("Post")%>' />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" Display="Dynamic" Text="*" runat="server" ErrorMessage="Post" ControlToValidate="PostTxt" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">BPS</td>
                    <td>
                        <asp:DropDownList ID="BPSDDL" class="form-control" runat="server" > </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">From Date</td>
                    <td>
                        <asp:TextBox ID="FromDateTxt" class="form-control js-date" runat="server" Text='<%#GetDate(Convert.ToDateTime(Eval("FromDate")))%>' />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" Display="Dynamic" Text="*" runat="server" ErrorMessage="From Date" ControlToValidate="FromDateTxt" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">To Date</td>
                    <td>
                        <asp:TextBox ID="ToDateTxt" class="form-control js-date" runat="server" Text='<%#GetDate(Convert.ToDateTime(Eval("ToDate")))%>' />
                        <asp:CustomValidator ID="DateRangeVal" runat="server" ControlToValidate="ToDateTxt" ClientValidationFunction="HrmDateRange" Display="Dynamic" ValidationGroup="Group1" Text="To Date cannot be earlier than From Date." ErrorMessage="To Date cannot be earlier than From Date."></asp:CustomValidator>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" Display="Dynamic" Text="*" runat="server" ErrorMessage="To Date" ControlToValidate="ToDateTxt" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">Details</td>
                    <td>
                        <asp:TextBox ID="RemarksTxt" class="form-control" runat="server" Text='<%#Bind("Remarks")%>' Height="121px" TextMode="MultiLine" Width="333px"/>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:LinkButton ID="cancelImageButton" class="btn btn-custom" runat="server" CommandName="cancel" ToolTip="Cancel"><span class="glyphicon glyphicon-arrow-left"></span></asp:LinkButton>
                        <asp:LinkButton class="btn btn-custom" ID="saveImageButton" runat="server" CommandName="update" ToolTip="Save" ValidationGroup="Group1"><span class="glyphicon glyphicon-floppy-disk"></span></asp:LinkButton>
                        <asp:Label ID="ErrorLabel" runat="server" Text="" style="color:red;font-size:small"></asp:Label>
                    </td>
                </tr>
                </table>
                </td>
            </tr>
        </EditItemTemplate>
    <EmptyDataTemplate>
             <tr>
                     <td>
                         <b>No Employment Out details found.</b>                            

                    </td>
             </tr>
        </EmptyDataTemplate>
    </asp:ListView>                   

   
    <tr>
    <td colspan="9">
    <asp:ValidationSummary ID="ValidationSummary5"
        HeaderText="You must enter a value in the following fields:"
        DisplayMode="BulletList"
        EnableClientScript="true"
        ShowSummary="true"
        runat="server" ValidationGroup="Group2" ForeColor="#FF3300" />
      </td>
    </tr>
</tbody>          
 </table> 
   </div>
</asp:Content>
