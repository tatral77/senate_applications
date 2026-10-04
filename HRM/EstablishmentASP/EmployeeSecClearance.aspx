<%@ Page Title="" Language="C#" MasterPageFile="~/EmployeeInformation.master" AutoEventWireup="true" CodeBehind="EmployeeSecClearance.aspx.cs" Inherits="EstablishmentASP.EmployeeSecClearance" %>
<asp:Content ID="Content1" ContentPlaceHolderID="EmpMenues" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="col-md-9">
                <label class="page-header page-title">SECURITY CLEARANCE</label>
                </div>
            <div class="col-md-2 page-header" style="text-align:center">
                  <asp:Button ID="Button1" runat="server" CommandName="new" Text="Add New" onclick="newLinkButton_Click" class="btn btn-custom"/>

            </div></div>
         
       
    <div class="row">
        <div class="col-md-11">

<table class="table table-hover table-striped table-condensed table-data table-responsive">
    <thead>
<tr>
<th>Sr#</th>
<th>Security Clearance Type</th>
<th>Post</th>
<th>BPS</th>
<th>Submission Date</th>
<th>Details</th>
<th>Action</th>


</tr>
        </thead>
     <tr>
    <td colspan="7">
    <asp:ValidationSummary ID="ValidationSummary1"
        HeaderText="You must enter a value in the following fields:"
        DisplayMode="BulletList"
        EnableClientScript="true"
        ShowSummary="true"
        runat="server" ValidationGroup="Group1" ForeColor="#FF3300" />
      </td>
    </tr>
<asp:ListView ID="SecurityClearanceLV" runat="server"
OnItemCanceling="ItemCanceling"
OnItemCreated="ItemCreated"
OnItemInserting="ItemInserting"
OnItemEditing="ItemEditing"
OnItemDataBound="ItemDataBound"
OnItemUpdating="ItemUpdating"
OnItemDeleting="ItemDeleting"> 
 <ItemTemplate>
<tr>    
     <td><asp:HiddenField ID="HidEmpSecClearanceId" runat="server" Value='<%#Bind("SecurityClearanceId")%>' />
     <asp:Label ID="SrNo" runat="server" Text='<%#Container.DataItemIndex + 1%> '></asp:Label></td>
     <td ><asp:Label ID="Label4" runat="server" Text='<%#Bind("SecClearanceType")%>'></asp:Label></td>
    <td ><asp:Label ID="DegreeLevelLb" runat="server" Text='<%#Bind("POST")%>'></asp:Label></td>
    <td><asp:Label ID="DegreeObtLb" runat="server" Text='<%#Bind("BPS") %>'></asp:Label></td>
      <td><asp:Label ID="Label2" runat="server" Text='<%#GetDate(Convert.ToDateTime(Eval("OnDate"))) %>'></asp:Label></td>
    <td><asp:Label ID="Label3" runat="server" Text='<%#Bind("Remarks") %>'></asp:Label></td>
     
 
    <td>
                               <asp:LinkButton ID="editImageButton" class="btn btn-custom" runat="server"  CommandName="edit"
                                 ToolTip="Edit"><span class="glyphicon glyphicon-pencil"></span></asp:LinkButton>
                                <asp:LinkButton ID="deleteImageButton" class="btn btn-custom" runat="server"  CommandName="delete"
                                 ToolTip="Delete" OnClientClick="return confirm('Are you sure you want to delete the Posting of Employee');"><span class="glyphicon glyphicon-erase"></span></asp:LinkButton>
                        </td>
  </tr>

</ItemTemplate>

<EditItemTemplate>
            <tr>
                <td colspan="7">
                <asp:HiddenField ID="HidEmpSecClearanceId" runat="server" Value='<%#Bind("SecurityClearanceId")%>' />
                <asp:HiddenField ID="HidPostId" runat="server" Value='<%#Bind("PostId")%>' />
                <asp:HiddenField ID="HidBPSId" runat="server" Value='<%#Bind("BPSID")%>' />
                <asp:HiddenField ID="HidClearanceTypeId" runat="server" Value='<%#Bind("SecClearanceTypeId")%>' />
                <table class="table table-condensed table-data">
                <tr>
                    <td class="table-data">Security Clearance Type</td>
                    <td>
                        <asp:DropDownList ID="ClearanceTypeDDL" runat="server" class="form-control" AutoPostBack="False" ></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" Text="*" Display="Dynamic" runat="server" ErrorMessage="ChargeType" ControlToValidate="ClearanceTypeDDL" InitialValue="0" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">Post</td>
                    <td>
                        <asp:DropDownList ID="PostDDL" runat="server" class="form-control" AutoPostBack="False" ><asp:ListItem Selected="True" Value="0">Select</asp:ListItem></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" Text="*" Display="Dynamic" runat="server" ErrorMessage="Post" ControlToValidate="PostDDL" InitialValue="0" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">BPS</td>
                    <td>
                        <asp:DropDownList ID="BPSDDL" runat="server" class="form-control" AutoPostBack="False" ></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" Text="*" Display="Dynamic" runat="server" ErrorMessage="BPS" ControlToValidate="BPSDDL" InitialValue="0" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">Submission Date</td>
                    <td>
                        <asp:TextBox ID="DateOnTxt" class="form-control js-date" runat="server" Text='<%#GetDate(Convert.ToDateTime(Eval("OnDate"))) %>' ></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" Text="*" runat="server" ErrorMessage="On Date" ControlToValidate="DateOnTxt" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">Details</td>
                    <td>
                        <asp:TextBox ID="RemarksTxt" class="form-control" runat="server" Text='<%#Bind("Remarks")%>' TextMode="MultiLine" Rows="3"></asp:TextBox>
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
<InsertItemTemplate>
            <tr>
                <td colspan="7">
                <table class="table table-condensed table-data">
                <tr>
                    <td class="table-data">Security Clearance Type</td>
                    <td>
                        <asp:DropDownList ID="ClearanceTypeDDL" runat="server" class="form-control" AutoPostBack="False" ></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" Text="*" Display="Dynamic" runat="server" ErrorMessage="ChargeType" ControlToValidate="ClearanceTypeDDL" InitialValue="0" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">Post</td>
                    <td>
                        <asp:DropDownList ID="PostDDL" runat="server" class="form-control" AutoPostBack="False" ><asp:ListItem Selected="True" Value="0">Select</asp:ListItem></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" Text="*" Display="Dynamic" runat="server" ErrorMessage="Post" ControlToValidate="PostDDL" InitialValue="0" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">BPS</td>
                    <td>
                        <asp:DropDownList ID="BPSDDL" runat="server" class="form-control" AutoPostBack="False" ></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" Text="*" Display="Dynamic" runat="server" ErrorMessage="BPS" ControlToValidate="BPSDDL" InitialValue="0" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">Submission Date</td>
                    <td>
                        <asp:TextBox ID="DateOnTxt" class="form-control js-date" runat="server" Text='' ></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" Text="*" runat="server" ErrorMessage="On Date" ControlToValidate="DateOnTxt" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">Details</td>
                    <td>
                        <asp:TextBox ID="RemarksTxt" class="form-control" runat="server" Text='' TextMode="MultiLine" Rows="3"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:LinkButton ID="cancelImageButton" class="btn btn-custom" runat="server" CommandName="cancel" ToolTip="Cancel"><span class="glyphicon glyphicon-arrow-left"></span></asp:LinkButton>
                        <asp:LinkButton class="btn btn-custom" ID="saveImageButton" runat="server" CommandName="insert" ToolTip="Insert" ValidationGroup="Group1"><span class="glyphicon glyphicon-floppy-disk"></span></asp:LinkButton>
                        <asp:Label ID="ErrorLabel" runat="server" Text="" style="color:red;font-size:small"></asp:Label>
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
