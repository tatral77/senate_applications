<%@ Page Title="" Language="C#" MasterPageFile="~/EmployeeInformation.master" AutoEventWireup="true" CodeBehind="EmployeeAcr.aspx.cs" Inherits="EstablishmentASP.EmployeeAcr" %>
<asp:Content ID="Content1" ContentPlaceHolderID="EmpMenues" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="col-md-9">
                <label class="page-header page-title">ANNUAL CONFIDENTIAL REPORT</label>
                </div>
            <div class="col-md-3 page-header" style="text-align:center">
                  <asp:Button ID="Button1" runat="server" CommandName="new" Text="Add New" onclick="newLinkButton_Click" class="btn btn-custom"/>

            </div></div>
         
       
    <div class="row">
        <div class="col-md-12">

<table class="table table-hover table-striped table-condensed table-data table-responsive">
    <thead>
<tr>
<th>Sr#</th>
<th>Post</th>
<th>BPS</th>
<th>Year</th>
<th>Count Signing Off</th>
<th>Received</th>
<th>Signed</th>
<th>Rep. Officer</th>
<th>Received</th>
<th>Signed</th>
<th>Status</th>
<th>Grade</th>
<th>Details</th>
<th>Action</th>


</tr>
        </thead>
     <tr>
    <td colspan="14">
    <asp:ValidationSummary ID="ValidationSummary1"
        HeaderText="You must enter a value in the following fields:"
        DisplayMode="BulletList"
        EnableClientScript="true"
        ShowSummary="true"
        runat="server" ValidationGroup="Group1" ForeColor="#FF3300" />
      </td>
    </tr>
<asp:ListView ID="EmpAcrLv" runat="server"
OnItemCanceling="ItemCanceling"
OnItemCreated="ItemCreated"
OnItemInserting="ItemInserting"
OnItemEditing="ItemEditing"
OnItemDataBound="ItemDataBound"
OnItemUpdating="ItemUpdating"
OnItemDeleting="ItemDeleting"> 
 <ItemTemplate>
<tr>    
     <td><asp:HiddenField ID="HidEmpAcrId" runat="server" Value='<%#Bind("AnConfRepId")%>' />
     <asp:Label ID="SrNo" runat="server" Text='<%#Container.DataItemIndex + 1%> '></asp:Label></td>
    <td ><asp:Label ID="DegreeLevelLb" runat="server" Text='<%#Bind("Post")%>'></asp:Label></td>
    <td><asp:Label ID="DegreeObtLb" runat="server" Text='<%#Bind("BPS") %>'></asp:Label></td>
        <td><asp:Label ID="Label2" runat="server" Text='<%#Bind("RepYear") %>'></asp:Label></td>
    <td><asp:Label ID="Label5" runat="server" Text='<%#Bind("CounterSignOff") %>'></asp:Label></td>
    <td><asp:Label ID="Label7" runat="server" Text='<%#GetDate(Convert.ToDateTime(Eval("CSInDate")))%>'></asp:Label></td>
    <td><asp:Label ID="Label8" runat="server" Text='<%#GetDate(Convert.ToDateTime(Eval("CSOutDate")))%>'></asp:Label></td>
    <td><asp:Label ID="Label1" runat="server" Text='<%#Bind("ReportingOfficer") %>'></asp:Label></td>
    <td><asp:Label ID="Label9" runat="server" Text='<%#GetDate(Convert.ToDateTime(Eval("ROInDate")))%>'></asp:Label></td>
    <td><asp:Label ID="Label10" runat="server" Text='<%#GetDate(Convert.ToDateTime(Eval("ROOutDate")))%>'></asp:Label></td>
     <td><asp:Label ID="Label4" runat="server" Text='<%#Bind("AcrStatus") %>'></asp:Label></td>
     <td><asp:Label ID="Label6" runat="server" Text='<%#Bind("AcrGrade") %>'></asp:Label></td>
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
                <td colspan="14">
                <asp:HiddenField ID="HidEmpAcrId" runat="server" Value='<%#Bind("AnConfRepId")%>' />
                <asp:HiddenField ID="HidPostId" runat="server" Value='<%#Bind("PostId")%>' />
                <asp:HiddenField ID="HidBPSId" runat="server" Value='<%#Bind("BPSID")%>' />
                <asp:HiddenField ID="HidCSOfficerId" runat="server" Value='<%#Bind("CounterSignOffId")%>' />
                <asp:HiddenField ID="HidRepOfficerId" runat="server" Value='<%#Bind("ReportingOfficerId")%>' />
                <asp:HiddenField ID="HidGradeId" runat="server" Value='<%#Bind("GradeId")%>' />
                <asp:HiddenField ID="HidStatusId" runat="server" Value='<%#Bind("StatusId")%>' />
                <table class="table table-condensed table-data">
                <tr>
                    <td class="table-data">Post</td>
                    <td>
                        <asp:DropDownList ID="PostDDL" runat="server" class="form-control" AutoPostBack="True" ></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" Text="*" Display="Dynamic" runat="server" ErrorMessage="Post" ControlToValidate="PostDDL" InitialValue="0" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">BPS</td>
                    <td>
                        <asp:DropDownList ID="BPSDDL" runat="server" class="form-control" AutoPostBack="True" ></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" Text="*" Display="Dynamic" runat="server" ErrorMessage="BPS" ControlToValidate="BPSDDL" InitialValue="0" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">Year</td>
                    <td>
                        <asp:TextBox ID="RepYearTxt" class="form-control" runat="server" Text='<%#Bind("RepYear")%>'></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">Counter Signing Officer</td>
                    <td>
                        <asp:DropDownList ID="CSOfficerDDL" runat="server" class="form-control" AutoPostBack="False" ></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" Text="*" Display="Dynamic" runat="server" ErrorMessage="Countersigning Officer" ControlToValidate="CSOfficerDDL" InitialValue="0" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">Counter Signing: Received On</td>
                    <td>
                        <asp:TextBox ID="CSInDateTxt" runat="server" class="form-control control-txt js-date" Text='<%#GetDate(Convert.ToDateTime(Eval("CSInDate")))%>' ></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">Counter Signing: Signed On</td>
                    <td>
                        <asp:TextBox ID="CSOutDateTxt" runat="server" class="form-control control-txt js-date" Text='<%#GetDate(Convert.ToDateTime(Eval("CSOutDate")))%>' ></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">Reporting Officer</td>
                    <td>
                        <asp:DropDownList ID="RepOfficerDDL" runat="server" class="form-control" AutoPostBack="False" ></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" Text="*" Display="Dynamic" runat="server" ErrorMessage="Reporting Officer" ControlToValidate="RepOfficerDDL" InitialValue="0" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">Reporting Officer: Received On</td>
                    <td>
                        <asp:TextBox ID="ROInDateTxt" runat="server" class="form-control control-txt js-date" Text='<%#GetDate(Convert.ToDateTime(Eval("ROInDate")))%>' ></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">Reporting Officer: Signed On</td>
                    <td>
                        <asp:TextBox ID="ROOutDateTxt" runat="server" class="form-control control-txt js-date" Text='<%#GetDate(Convert.ToDateTime(Eval("ROOutDate")))%>' ></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">Status</td>
                    <td>
                        <asp:DropDownList ID="StatusDDL" runat="server" class="form-control" AutoPostBack="False" ></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" Text="*" Display="Dynamic" runat="server" ErrorMessage="Status" ControlToValidate="StatusDDL" InitialValue="0" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">Grade</td>
                    <td>
                        <asp:DropDownList ID="GradeDDL" runat="server" class="form-control" AutoPostBack="False" ></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" Text="*" Display="Dynamic" runat="server" ErrorMessage="Grade" ControlToValidate="GradeDDL" InitialValue="0" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
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
                <td colspan="14">
                <table class="table table-condensed table-data">
                <tr>
                    <td class="table-data">Post</td>
                    <td>
                        <asp:DropDownList ID="PostDDL" runat="server" class="form-control" AutoPostBack="True" ></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" Text="*" Display="Dynamic" runat="server" ErrorMessage="Post" ControlToValidate="PostDDL" InitialValue="0" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">BPS</td>
                    <td>
                        <asp:DropDownList ID="BPSDDL" runat="server" class="form-control" AutoPostBack="True" ></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" Text="*" Display="Dynamic" runat="server" ErrorMessage="BPS" ControlToValidate="BPSDDL" InitialValue="0" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">Year</td>
                    <td>
                        <asp:TextBox ID="RepYearTxt" class="form-control" runat="server" Text=''></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">Counter Signing Officer</td>
                    <td>
                        <asp:DropDownList ID="CSOfficerDDL" runat="server" class="form-control" AutoPostBack="False" ></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" Text="*" Display="Dynamic" runat="server" ErrorMessage="Countersigning Officer" ControlToValidate="CSOfficerDDL" InitialValue="0" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">Counter Signing: Received On</td>
                    <td>
                        <asp:TextBox ID="CSInDateTxt" runat="server" class="form-control control-txt js-date" Text=''></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">Counter Signing: Signed On</td>
                    <td>
                        <asp:TextBox ID="CSOutDateTxt" runat="server" class="form-control control-txt js-date" Text=''></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">Reporting Officer</td>
                    <td>
                        <asp:DropDownList ID="RepOfficerDDL" runat="server" class="form-control" AutoPostBack="False" ></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" Text="*" Display="Dynamic" runat="server" ErrorMessage="Reporting Officer" ControlToValidate="RepOfficerDDL" InitialValue="0" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">Reporting Officer: Received On</td>
                    <td>
                        <asp:TextBox ID="ROInDateTxt" runat="server" class="form-control control-txt js-date" Text=''></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">Reporting Officer: Signed On</td>
                    <td>
                        <asp:TextBox ID="ROOutDateTxt" runat="server" class="form-control control-txt js-date" Text=''></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">Status</td>
                    <td>
                        <asp:DropDownList ID="StatusDDL" runat="server" class="form-control" AutoPostBack="False" ></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" Text="*" Display="Dynamic" runat="server" ErrorMessage="Status" ControlToValidate="StatusDDL" InitialValue="0" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">Grade</td>
                    <td>
                        <asp:DropDownList ID="GradeDDL" runat="server" class="form-control" AutoPostBack="False" ></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" Text="*" Display="Dynamic" runat="server" ErrorMessage="Grade" ControlToValidate="GradeDDL" InitialValue="0" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
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
