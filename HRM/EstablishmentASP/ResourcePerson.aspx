<%@ Page Title="" Language="C#" MasterPageFile="~/EmployeeInformation.master" AutoEventWireup="true" CodeBehind="ResourcePerson.aspx.cs" Inherits="EstablishmentASP.ResourcePerson" %>
<asp:Content ID="Content1" ContentPlaceHolderID="EmpMenues" runat="server">
    <div class="container-fluid regularDiv">
        <div class="sec-head">
        <h5>RESOURSE PERSON</h5>
        <asp:Button ID="Button1" runat="server" CommandName="new" Text="Add New" onclick="newLinkButton_Click" class="btn btn-custom"/>
    </div>
         
       
    <div class="row">
        <div class="col-md-12">

<table class="table table-hover table-striped table-condensed table-data table-responsive">
    <thead>
<tr>
<th>Sr#</th>
<th>Post</th>
<th>BPS</th>
<th>Presented As</th>
<th>Station</th>
<th>Date</th>
<th style="width:30%">Details</th>

<th>Action</th>


</tr>
        </thead>
     <tr>
    <td colspan="8">
    <asp:ValidationSummary ID="ValidationSummary1"
        HeaderText="You must enter a value in the following fields:"
        DisplayMode="BulletList"
        EnableClientScript="true"
        ShowSummary="true"
        runat="server" ValidationGroup="Group1" ForeColor="#FF3300" />
      </td>
    </tr>
<asp:ListView ID="ResoursePersonLV" runat="server"
OnItemCanceling="ItemCanceling"
OnItemCreated="ItemCreated"
OnItemInserting="ItemInserting"
OnItemEditing="ItemEditing"
OnItemDataBound="ItemDataBound"
OnItemUpdating="ItemUpdating"
OnItemDeleting="ItemDeleting"> 
 <ItemTemplate>
<tr>    
     <td><asp:HiddenField ID="HidResId" runat="server" Value='<%#Bind("ResoursePersonId")%>' />
     <asp:Label ID="SrNo" runat="server" Text='<%#Container.DataItemIndex + 1%> '></asp:Label></td>
    <td ><asp:Label ID="DegreeLevelLb" runat="server" Text='<%#Bind("Post")%>'></asp:Label></td>
    <td><asp:Label ID="DegreeObtLb" runat="server" Text='<%#Bind("BPS") %>'></asp:Label></td>
    <td><asp:Label ID="Label2" runat="server" Text='<%#Bind("PresAs") %>'></asp:Label></td>
    <td><asp:Label ID="Label6" runat="server" Text='<%#Bind("Station") %>'></asp:Label></td>
     <td><asp:Label ID="Label1" runat="server" Text='<%#GetDate(Convert.ToDateTime(Eval("PresDate"))) %>'></asp:Label></td>
    <td><asp:Label ID="Label5" runat="server" Text='<%#Bind("Details") %>'></asp:Label></td>
   
   
     
 
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
    <td colspan="8">
        <asp:HiddenField ID="HidResId" runat="server" Value='<%#Bind("ResoursePersonId")%>' />
        <asp:HiddenField ID="HidPostId" runat="server" Value='<%#Bind("PostId")%>' />
        <asp:HiddenField ID="HidBPSId" runat="server" Value='<%#Bind("BPSID")%>' />
        <table class="table table-condensed table-data">
            <tr>
                <td class="table-data">Post</td>
                <td><asp:DropDownList ID="PostDDL" runat="server" class="form-control" AutoPostBack="False" ><asp:ListItem Selected="True" Value="0">Select</asp:ListItem></asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" Text="*" Display="Dynamic" runat="server" ErrorMessage="Post" ControlToValidate="PostDDL" InitialValue="0" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td class="table-data">BPS</td>
                <td><asp:DropDownList ID="BPSDDL" runat="server" class="form-control" AutoPostBack="False" ><asp:ListItem Selected="True" Value="0">Select</asp:ListItem></asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" Text="*" Display="Dynamic" runat="server" ErrorMessage="BPS" ControlToValidate="BPSDDL" InitialValue="0" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td class="table-data">Presented As</td>
                <td><asp:TextBox ID="PresAsTxt" class="form-control"  runat="server" Text='<%#Bind("PresAs")%>' ></asp:TextBox>
                <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator2" Text="*" runat="server" ErrorMessage="Presented As" ControlToValidate="PresAsTxt" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td class="table-data">Station</td>
                <td><asp:TextBox ID="StationTxt" class="form-control"  runat="server" Text='<%#Bind("Station")%>'></asp:TextBox></td>
            </tr>
            <tr>
                <td class="table-data">Date</td>
                <td><asp:TextBox ID="DateTxt" class="form-control js-date"  runat="server" Text='<%#GetDate(Convert.ToDateTime(Eval("PresDate"))) %>'></asp:TextBox>
                <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator4" Text="*" runat="server" ErrorMessage="Date" ControlToValidate="DateTxt" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td class="table-data">Details</td>
                <td><asp:TextBox ID="DetailsTxt" class="form-control"  runat="server" Text='<%#Bind("Details")%>' TextMode="MultiLine" Rows="3"></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:LinkButton ID="cancelImageButton" class="btn btn-custom" runat="server" CommandName="cancel" ToolTip="Cancel"><span class="glyphicon glyphicon-arrow-left"></span></asp:LinkButton>
                    <asp:LinkButton ID="saveImageButton" class="btn btn-custom" runat="server" CommandName="update" ToolTip="Save" ValidationGroup="Group1"><span class="glyphicon glyphicon-floppy-disk"></span></asp:LinkButton>
                    <asp:Label ID="ErrorLabel" runat="server" Text="" style="color:red;font-size:small"></asp:Label>
                </td>
            </tr>
        </table>
    </td>
</tr>
</EditItemTemplate>
<InsertItemTemplate>
<tr>
    <td colspan="8">
        <table class="table table-condensed table-data">
            <tr>
                <td class="table-data">Post</td>
                <td><asp:DropDownList ID="PostDDL" runat="server" class="form-control" AutoPostBack="True" ><asp:ListItem Selected="False" Value="0">Select</asp:ListItem></asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" Text="*" Display="Dynamic" runat="server" ErrorMessage="Post" ControlToValidate="PostDDL" InitialValue="0" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td class="table-data">BPS</td>
                <td><asp:DropDownList ID="BPSDDL" runat="server" class="form-control" AutoPostBack="True" ><asp:ListItem Selected="False" Value="0">Select</asp:ListItem></asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" Text="*" Display="Dynamic" runat="server" ErrorMessage="BPS" ControlToValidate="BPSDDL" InitialValue="0" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td class="table-data">Presented As</td>
                <td><asp:TextBox ID="PresAsTxt" class="form-control"  runat="server" Text='' ></asp:TextBox>
                <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator2" Text="*" runat="server" ErrorMessage="Presented As" ControlToValidate="PresAsTxt" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td class="table-data">Station</td>
                <td><asp:TextBox ID="StationTxt" class="form-control"  runat="server" Text=''></asp:TextBox></td>
            </tr>
            <tr>
                <td class="table-data">Date</td>
                <td><asp:TextBox ID="DateTxt" class="form-control js-date"  runat="server" Text=''></asp:TextBox>
                <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator4" Text="*" runat="server" ErrorMessage="Date" ControlToValidate="DateTxt" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td class="table-data">Details</td>
                <td><asp:TextBox ID="DetailsTxt" class="form-control"  runat="server" Text='' TextMode="MultiLine" Rows="3"></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:LinkButton ID="cancelImageButton" class="btn btn-custom" runat="server" CommandName="cancel" ToolTip="Cancel"><span class="glyphicon glyphicon-arrow-left"></span></asp:LinkButton>
                    <asp:LinkButton ID="saveImageButton" class="btn btn-custom" runat="server" CommandName="insert" ToolTip="Insert" ValidationGroup="Group1"><span class="glyphicon glyphicon-floppy-disk"></span></asp:LinkButton>
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
