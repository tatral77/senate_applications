<%@ Page Title="" Language="C#" MasterPageFile="~/EmployeeInformation.master" AutoEventWireup="true" CodeBehind="EmpOtherCharges.aspx.cs" Inherits="EstablishmentASP.EmpOtherCharges" %>
<asp:Content ID="Content1" ContentPlaceHolderID="EmpMenues" runat="server">
    <div class="container-fluid regularDiv">
        <div class="sec-head"><h5>OTHER CHARGES</h5><asp:Button ID="Button1" runat="server" CommandName="new" Text="Add New" onclick="newLinkButton_Click" class="btn btn-custom"/></div>
         
       
    <div class="row">
        <div class="col-md-12">

<table class="table table-hover table-striped table-condensed table-data table-responsive">
    <thead>
<tr>
<th>Sr#</th>
<th>Charge</th>
<th>Post</th>
<th>BPS</th>
<th>Branch</th>
<th>From Date</th>
<th>To Date</th>
<th>Details</th>
<th>Action</th>


</tr>
        </thead>
     <tr>
    <td colspan="9">
    <asp:ValidationSummary ID="ValidationSummary1"
        HeaderText="You must enter a value in the following fields:"
        DisplayMode="BulletList"
        EnableClientScript="true"
        ShowSummary="true"
        runat="server" ValidationGroup="Group1" ForeColor="#FF3300" />
      </td>
    </tr>
<asp:ListView ID="OtherChargesLV" runat="server"
OnItemCanceling="ItemCanceling"
OnItemCreated="ItemCreated"
OnItemInserting="ItemInserting"
OnItemEditing="ItemEditing"
OnItemDataBound="ItemDataBound"
OnItemUpdating="ItemUpdating"
OnItemDeleting="ItemDeleting"> 
 <ItemTemplate>
<tr>    
     <td><asp:HiddenField ID="HidOtherChargeId" runat="server" Value='<%#Bind("OtherChargeId")%>' />
     <asp:Label ID="SrNo" runat="server" Text='<%#Container.DataItemIndex + 1%> '></asp:Label></td>
     <td ><asp:Label ID="Label4" runat="server" Text='<%#Bind("OtherChargeType")%>'></asp:Label></td>
    <td ><asp:Label ID="DegreeLevelLb" runat="server" Text='<%#Bind("POST")%>'></asp:Label></td>
    <td><asp:Label ID="DegreeObtLb" runat="server" Text='<%#Bind("BPS") %>'></asp:Label></td>
    <td><asp:Label ID="Label5" runat="server" Text='<%#Bind("Branch") %>'></asp:Label></td>
    <td><asp:Label ID="Label1" runat="server" Text='<%#GetDate(Convert.ToDateTime(Eval("FromDate"))) %>'></asp:Label></td>
    <td><asp:Label ID="Label2" runat="server" Text='<%#GetDate(Convert.ToDateTime(Eval("ToDate"))) %>'></asp:Label></td>
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
                <td colspan="9">
                <asp:HiddenField ID="HidOtherChargeId" runat="server" Value='<%#Bind("OtherChargeId")%>' />
                <asp:HiddenField ID="HidPostId" runat="server" Value='<%#Bind("PostId")%>' />
                <asp:HiddenField ID="HidBPSId" runat="server" Value='<%#Bind("BPSID")%>' />
                <asp:HiddenField ID="HidBranchId" runat="server" Value='<%#Bind("BranchId")%>' />
                <asp:HiddenField ID="HidChargeTypeId" runat="server" Value='<%#Bind("OtherChargeTypeId")%>' />
                <table class="table table-condensed table-data">
                <tr>
                    <td class="table-data">Charge</td>
                    <td>
                        <asp:DropDownList ID="ChargeTypeDDL" runat="server" class="form-control" AutoPostBack="False" ><asp:ListItem Selected="True" Value="0">Select</asp:ListItem></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" Text="*" Display="Dynamic" runat="server" ErrorMessage="ChargeType" ControlToValidate="ChargeTypeDDL" InitialValue="0" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">Post</td>
                    <td>
                        <asp:DropDownList ID="PostDDL" runat="server" class="form-control" AutoPostBack="True" ><asp:ListItem Selected="True" Value="0">Select</asp:ListItem></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" Text="*" Display="Dynamic" runat="server" ErrorMessage="Post" ControlToValidate="PostDDL" InitialValue="0" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">BPS</td>
                    <td>
                        <asp:DropDownList ID="BPSDDL" runat="server" class="form-control" AutoPostBack="True" ><asp:ListItem Selected="True" Value="0">Select</asp:ListItem></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" Text="*" Display="Dynamic" runat="server" ErrorMessage="BPS" ControlToValidate="BPSDDL" InitialValue="0" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">Branch</td>
                    <td>
                        <asp:DropDownList ID="BranchDDL" runat="server" class="form-control" AutoPostBack="False" ><asp:ListItem Selected="True" Value="0">Select</asp:ListItem></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" Text="*" Display="Dynamic" runat="server" ErrorMessage="BPS" ControlToValidate="BranchDDL" InitialValue="0" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">From Date</td>
                    <td>
                        <asp:TextBox ID="DateFromTxt" class="form-control js-date" runat="server" Text='<%#GetDate(Convert.ToDateTime(Eval("FromDate"))) %>' ></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" Text="*" runat="server" ErrorMessage="From Date" ControlToValidate="DateFromTxt" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                        <asp:CompareValidator id="CompareValidator9" runat="server" Type="Date" ValidationGroup="Group1" Operator="DataTypeCheck" Text="*" ControlToValidate="DateFromTxt" ErrorMessage="Please enter valid date."></asp:CompareValidator>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">To Date</td>
                    <td>
                        <asp:TextBox TextMode="MultiLine" ID="DateToTxt" class="form-control" runat="server" Text='<%#GetDate(Convert.ToDateTime(Eval("ToDate"))) %>' ></asp:TextBox>
                        <asp:CustomValidator ID="DateRangeVal" runat="server" ControlToValidate="DateToTxt" ClientValidationFunction="HrmDateRange" Display="Dynamic" ValidationGroup="Group1" Text="To Date cannot be earlier than From Date." ErrorMessage="To Date cannot be earlier than From Date."></asp:CustomValidator>
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
                <td colspan="9">
                <table class="table table-condensed table-data">
                <tr>
                    <td class="table-data">Charge</td>
                    <td>
                        <asp:DropDownList ID="ChargeTypeDDL" runat="server" class="form-control" AutoPostBack="False" ><asp:ListItem Selected="True" Value="0">Select</asp:ListItem></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" Text="*" Display="Dynamic" runat="server" ErrorMessage="ChargeType" ControlToValidate="ChargeTypeDDL" InitialValue="0" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
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
                        <asp:DropDownList ID="BPSDDL" runat="server" class="form-control" AutoPostBack="False" ><asp:ListItem Selected="True" Value="0">Select</asp:ListItem></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" Text="*" Display="Dynamic" runat="server" ErrorMessage="BPS" ControlToValidate="BPSDDL" InitialValue="0" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">Branch</td>
                    <td>
                        <asp:DropDownList ID="BranchDDL" runat="server" class="form-control" AutoPostBack="False" ><asp:ListItem Selected="True" Value="0">Select</asp:ListItem></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" Text="*" Display="Dynamic" runat="server" ErrorMessage="BPS" ControlToValidate="BranchDDL" InitialValue="0" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">From Date</td>
                    <td>
                        <asp:TextBox ID="DateFromTxt" class="form-control js-date" runat="server" Text='' ></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" Text="*" runat="server" ErrorMessage="From Date" ControlToValidate="DateFromTxt" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                        <asp:CompareValidator id="CompareValidator1" runat="server" Type="Date" ValidationGroup="Group1" Operator="DataTypeCheck" Text="*" ControlToValidate="DateFromTxt" ErrorMessage="Please enter valid date."></asp:CompareValidator>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">To Date</td>
                    <td>
                        <asp:TextBox ID="DateToTxt" class="form-control js-date" runat="server" Text='' ></asp:TextBox>
                        <asp:CustomValidator ID="DateRangeVal" runat="server" ControlToValidate="DateToTxt" ClientValidationFunction="HrmDateRange" Display="Dynamic" ValidationGroup="Group1" Text="To Date cannot be earlier than From Date." ErrorMessage="To Date cannot be earlier than From Date."></asp:CustomValidator>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">Details</td>
                    <td>
                        <asp:TextBox TextMode="MultiLine" ID="RemarksTxt" class="form-control" runat="server" Text=''></asp:TextBox>
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
