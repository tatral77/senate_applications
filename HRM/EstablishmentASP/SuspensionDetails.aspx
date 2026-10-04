<%@ Page Title="" Language="C#" MasterPageFile="~/EmployeeInformation.master" AutoEventWireup="true" CodeBehind="SuspensionDetails.aspx.cs" Inherits="EstablishmentASP.SuspensionDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="EmpMenues" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="col-md-9">
                <label class="page-header page-title">SUSPENSION DETAILS</label>

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
<th>Post</th>
<th>BPS</th>
<th>From Date</th>
<th>To Date</th>
<th>Final Action</th>
<th>Date</th>
<th>LFP Calculated</th>
<th>Service Calculated</th>
<th>Details</th>
<th>Action</th>


</tr>
        </thead>
     <tr>
    <td colspan="11">
    <asp:ValidationSummary ID="ValidationSummary1"
        HeaderText="You must enter a value in the following fields:"
        DisplayMode="BulletList"
        EnableClientScript="true"
        ShowSummary="true"
        runat="server" ValidationGroup="Group1" ForeColor="#FF3300" />
      </td>
    </tr>
<asp:ListView ID="DisciplinaryActionLV" runat="server"
OnItemCanceling="ItemCanceling"
OnItemCreated="ItemCreated"
OnItemInserting="ItemInserting"
OnItemEditing="ItemEditing"
OnItemDataBound="ItemDataBound"
OnItemUpdating="ItemUpdating"
OnItemDeleting="ItemDeleting"> 
 <ItemTemplate>
<tr>    
     <td><asp:HiddenField ID="HidDisciplinaryActionId" runat="server" Value='<%#Bind("DisciplinaryActionId")%>' />
     <asp:Label ID="SrNo" runat="server" Text='<%#Container.DataItemIndex + 1%> '></asp:Label></td>
    <%-- <td><asp:Label ID="Label1" runat="server" Text='<%#GetDate(Convert.ToDateTime(Eval("ActionDate"))) %>'></asp:Label></td>--%>
    <td ><asp:Label ID="DegreeLevelLb" runat="server" Text='<%#Bind("POST")%>'></asp:Label></td>
    <td><asp:Label ID="DegreeObtLb" runat="server" Text='<%#Bind("BPS") %>'></asp:Label></td>
    <td><asp:Label ID="Label5" runat="server" Text='<%#GetDate(Convert.ToDateTime(Eval("FromDate"))) %>'></asp:Label></td>
    <td><asp:Label ID="Label6" runat="server" Text='<%#GetDate(Convert.ToDateTime(Eval("ToDate"))) %>'></asp:Label></td>
    <td><asp:Label ID="Label7" runat="server" Text='<%#Bind("FinalActionType")%>'></asp:Label></td>
      <td><asp:Label ID="Label2" runat="server" Text='<%#GetDate(Convert.ToDateTime(Eval("FinalActionDate"))) %>'></asp:Label></td>
      <td>
                            <asp:Label ID="Label1" class="table-data" runat="server" Text='<%#(Convert.ToString(Eval("IsLfpCalculated"))=="1")?"Yes":"No"%>' />
                        </td>
      <td>
                            <asp:Label ID="Label4" class="table-data" runat="server" Text='<%#(Convert.ToString(Eval("IsServiceCalculated"))=="1")?"Yes":"No"%>' />
                        </td>
    <td><asp:Label ID="Label3" runat="server" Text='<%#Bind("Details") %>'></asp:Label></td>
     
 
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
                <td colspan="11">
                <asp:HiddenField ID="HidDisciplinaryActionId" runat="server" Value='<%#Bind("DisciplinaryActionId")%>' />
                <asp:HiddenField ID="HidPostId" runat="server" Value='<%#Bind("PostId")%>' />
                <asp:HiddenField ID="HidBPSId" runat="server" Value='<%#Bind("BPSID")%>' />
                <asp:HiddenField ID="HidFinalActionTypeId" runat="server" Value='<%#Bind("FinalActionTypeId")%>' />
                <asp:HiddenField ID="HidIsLfpCalculated" runat="server" Value='<%#Bind("IsLfpCalculated")%>' />
                <asp:HiddenField ID="HidIsSeriviceCalculated" runat="server" Value='<%#Bind("IsServiceCalculated")%>' />
                <table class="table table-condensed table-data">
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
                    <td class="table-data">From Date</td>
                    <td>
                        <asp:TextBox ID="DateFromTxt" class="form-control js-date" runat="server" Text='<%#GetDate(Convert.ToDateTime(Eval("FromDate"))) %>' ></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" Text="*" runat="server" ErrorMessage="From Date" ControlToValidate="DateFromTxt" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">To Date</td>
                    <td>
                        <asp:TextBox ID="DateToTxt" class="form-control js-date" runat="server" Text='<%#GetDate(Convert.ToDateTime(Eval("ToDate"))) %>' ></asp:TextBox>
                        <asp:CustomValidator ID="DateRangeVal" runat="server" ControlToValidate="DateToTxt" ClientValidationFunction="HrmDateRange" Display="Dynamic" ValidationGroup="Group1" Text="To Date cannot be earlier than From Date." ErrorMessage="To Date cannot be earlier than From Date."></asp:CustomValidator>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">Final Action</td>
                    <td>
                        <asp:DropDownList ID="ActionTypeDDL" runat="server" class="form-control" AutoPostBack="False" ></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" Text="*" Display="Dynamic" runat="server" ErrorMessage="Action Taken" ControlToValidate="ActionTypeDDL" InitialValue="0" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">Final Action Date</td>
                    <td>
                        <asp:TextBox ID="FinalActionDateTxt" class="form-control js-date" runat="server" Text='<%#GetDate(Convert.ToDateTime(Eval("FinalActionDate"))) %>' ></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" Text="*" runat="server" ErrorMessage="Final Action Date" ControlToValidate="FinalActionDateTxt" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">LFP Calculated</td>
                    <td>
                        <asp:CheckBox class="form-control" ID="IsLfpCalculatedCB" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td class="table-data">Service Calculated</td>
                    <td>
                        <asp:CheckBox class="form-control" ID="IsServiceCalculatedCB" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td class="table-data">Details</td>
                    <td>
                        <asp:TextBox ID="RemarksTxt" class="form-control" runat="server" Text='<%#Bind("Details")%>' TextMode="MultiLine" Rows="3"></asp:TextBox>
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
                <td colspan="11">
                <table class="table table-condensed table-data">
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
                    <td class="table-data">From Date</td>
                    <td>
                        <asp:TextBox ID="DateFromTxt" class="form-control js-date" runat="server" Text='' ></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" Text="*" runat="server" ErrorMessage="From Date" ControlToValidate="DateFromTxt" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="CompareValidator1" ValidationGroup="Group1" ControlToValidate="DateFromTxt" runat="server" ErrorMessage="Not a valid Date" Type="Date" Operator="DataTypeCheck" ForeColor="#FF3300"></asp:CompareValidator>
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
                    <td class="table-data">Final Action</td>
                    <td>
                        <asp:DropDownList ID="ActionTypeDDL" runat="server" class="form-control" AutoPostBack="False" ></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" Text="*" Display="Dynamic" runat="server" ErrorMessage="Action Taken" ControlToValidate="ActionTypeDDL" InitialValue="0" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">Final Action Date</td>
                    <td>
                        <asp:TextBox ID="FinalActionDateTxt" class="form-control js-date" runat="server" Text='' ></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" Text="*" runat="server" ErrorMessage="Final Action Date" ControlToValidate="FinalActionDateTxt" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="CompareValidator4" ValidationGroup="Group1" ControlToValidate="FinalActionDateTxt" runat="server" ErrorMessage="Not a valid Date" Type="Date" Operator="DataTypeCheck" ForeColor="#FF3300"></asp:CompareValidator>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">LFP Calculated</td>
                    <td>
                        <asp:CheckBox class="form-control" ID="IsLfpCalculatedCB" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td class="table-data">Service Calculated</td>
                    <td>
                        <asp:CheckBox class="form-control" ID="IsServiceCalculatedCB" runat="server" />
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
