<%@ Page Title="" Language="C#" MasterPageFile="~/EmployeeInformation.master" AutoEventWireup="true" CodeBehind="OnePage.aspx.cs" Inherits="EstablishmentASP.OnePage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="EmpMenues" runat="server">
 <div class="container">
        <div class="row">
            <div class="col-md-9">
                <label class="page-header page-title">One Page Profile</label>
                </div>
            <div class="col-md-2 page-header ">
                  <asp:Button ID="Button1" runat="server" CommandName="new" Text="Add New" onclick="newLinkButton_Click" class="btn btn-primary"/>

            </div></div>
         
       
    <div class="row">
        <div class="col-md-11">

<table class="table table-hover table-striped table-condensed table-data">
    <thead>
<tr>
<th>Sr#</th>
<th>Degree Level</th>
<th>Discipline</th>
<th>Institution</th>
<th>Country</th>
<%--<th>City</th>--%>
<th>Completion Year</th>
<th>Grade</th>
<th>CGPA</th>
<th>Percentage</th>
<th>Action</th>


</tr>
        </thead>
     <tr>
    <td colspan="4">
    <asp:ValidationSummary ID="ValidationSummary1"
        HeaderText="You must enter a value in the following fields:"
        DisplayMode="BulletList"
        EnableClientScript="true"
        ShowSummary="true"
        runat="server" ValidationGroup="Group1" ForeColor="#FF3300" />
      </td>
    </tr>
<asp:ListView ID="EmpQualificationLv" runat="server" 
OnItemEditing="ItemEditing"
OnItemDataBound="ItemDataBound"
OnItemCanceling="ItemCanceling"
OnItemInserting="ItemInserting"
OnItemCreated="ItemCreated"
OnItemDeleting="ItemDeleting"
OnItemUpdating="ItemUpdating">
    <%--
     OnItemUpdating="ItemUpdating"
 
     --%>
 
<ItemTemplate>
<tr>
    
     <td><asp:HiddenField ID="HidEmpQualificationId" runat="server" Value='<%#Bind("Emp_Qualification_Id")%>' />
     <asp:Label ID="SrNo" runat="server" Text='<%#Container.DataItemIndex + 1%> '></asp:Label></td>
    <td ><asp:Label ID="DegreeLevelLb" runat="server" Text='<%# GetDegreeLevel(Convert.ToInt32(Eval("Degree_Level_Id")))%>'></asp:Label></td>
    <td><asp:Label ID="DegreeObtLb" runat="server" Text='<%#Bind("Degree_Obtained") %>'></asp:Label></td>
    <td><asp:Label ID="Label5" runat="server" Text='<%#Bind("Institution_Name") %>'></asp:Label></td>
    <td><asp:Label ID="Label2" runat="server" Text='<%# GetCountry(Convert.ToInt32(Eval("Country_Id")))%>'></asp:Label></td>
   <%-- <td class="itemLeft"><asp:Label ID="Label6" runat="server" Text='<%# GetCity(Convert.ToInt32(Eval("City_Id")))%>'></asp:Label></td>--%>
    <td style="text-align:center"><asp:Label ID="Label1" runat="server" Text='<%#Bind("Completion_Year")%>'></asp:Label></td>
    <td style="text-align:center"><asp:Label ID="Label3" runat="server" Text='<%#Bind("Grade")%>'></asp:Label></td>
    <td style="text-align:center"><asp:Label ID="Label4" runat="server" Text='<%# Eval("Cgpa").ToString()=="0" ? "":Eval("Cgpa")%>'></asp:Label></td>
    <td style="text-align:center"><asp:Label ID="Label8" runat="server" Text='<%# Eval("Percentage").ToString()=="0" ? "":Eval("Percentage")%>'></asp:Label></td>
    <td>
                               <asp:LinkButton ID="editImageButton" class="btn btn-primary" runat="server" AlternateText="edit" CommandName="edit"
                                ImageUrl="~/images/edit.png" ToolTip="Edit"><span class="glyphicon glyphicon-pencil"></span></asp:LinkButton>
                                <asp:LinkButton ID="deleteImageButton" class="btn btn-primary" runat="server" AlternateText="delete" CommandName="delete"
                                ImageUrl="~/images/delete.png" ToolTip="Delete" OnClientClick="return confirm('Are you sure you want to delete the qualification of Employee');"><span class="glyphicon glyphicon-erase"></span></asp:LinkButton>
                        </td>
  </tr>

</ItemTemplate>

<EditItemTemplate>
<tr>
<td colspan="10">
        <asp:HiddenField ID="HidEmpQualificationId" runat="server" Value='<%#Bind("Emp_Qualification_Id")%>' />
        <asp:HiddenField ID="HidDegreeLevelId" runat="server" Value='<%#Bind("Degree_Level_Id")%>' />
        <asp:HiddenField ID="HidCountryId" runat="server" Value='<%#Bind("Country_Id")%>' />
       <%-- <asp:HiddenField ID="HidCityId" runat="server" Value='<%#Bind("City_Id")%>' />--%>
    <table class="table table-condensed">
          <tr>
            <td>Degree Level:</td>
            <td><asp:DropDownList ID="DegreeLevelDDL" runat="server" class="form-control" AutoPostBack="True" ><asp:ListItem Selected="True" Value="0">Select</asp:ListItem></asp:DropDownList>
            <td><asp:RequiredFieldValidator ID="RequiredFieldValidator1" Text="*" runat="server" ErrorMessage="Degree Level" ControlToValidate="DegreeLevelDDL" InitialValue="0" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator></td>
           </td>
               </tr>
            <tr>
            <td>Discipline:</td><td><asp:TextBox ID="DegreeObtainedTxt" class="form-control" runat="server" Text='<%#Bind("Degree_Obtained")%>' Width="400"></asp:TextBox>
            <td><asp:RequiredFieldValidator ID="RequiredFieldValidator2" Text="*" runat="server" ErrorMessage="Degree Obtained" ControlToValidate="DegreeObtainedTxt" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator></td></td>
         </tr>
         <tr>
            <td>Institution Name:</td><td><asp:TextBox ID="InstitutionNameTxt" class="form-control"  runat="server" Text='<%#Bind("Institution_Name")%>' Width="400"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" Text="*" runat="server" ErrorMessage="Institution Name" ControlToValidate="InstitutionNameTxt" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator></td>
         </tr>
         <tr>
            <td>Country:</td><td><asp:DropDownList ID="CountryDDL" class="form-control" runat="server" AutoPostBack="True" ><asp:ListItem Selected="True" Value="0">Select</asp:ListItem></asp:DropDownList>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" Text="*" runat="server" ErrorMessage="Country" ControlToValidate="CountryDDL" InitialValue="0" ValidationGroup="Group1" ForeColor="#FF3300" ></asp:RequiredFieldValidator></td>
        </tr>
        <%--<tr>
            <td>City:</td><td><asp:DropDownList ID="CityDDL" runat="server" AutoPostBack="True" ><asp:ListItem Selected="True" Value="0">Select</asp:ListItem></asp:DropDownList>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" Text="*" runat="server" ErrorMessage="City" ControlToValidate="CityDDL" InitialValue="0" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator></td>
        </tr>--%>
        <tr>
            <td>Completion Year:</td><td><asp:TextBox ID="CompletionYearTxt" class="form-control" runat="server" Text='<%#Bind("Completion_Year")%>' Width="10%"></asp:TextBox>
            <td><asp:RequiredFieldValidator ID="RequiredFieldValidator5" Text="*" runat="server" ErrorMessage="Completion Year" ControlToValidate="CompletionYearTxt" InitialValue="0" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator></td></td>
        </tr>
        <tr>
            <td>Grade:</td><td><asp:TextBox ID="GradeTxt" class="form-control"  runat="server" Text='<%#Bind("Grade")%>' Width="10%"></asp:TextBox></td>
        </tr>
        <tr>
            <td>CGPA:</td><td><asp:TextBox ID="CGPATxt" class="form-control"  runat="server" Text='<%# Eval("Cgpa").ToString()=="0" ? "":Eval("Cgpa")%>' Width="10%"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Percentage:</td><td><asp:TextBox ID="PercentageTxt" class="form-control"  runat="server" Text='<%# Eval("Percentage").ToString()=="0" ? "":Eval("Percentage")%>' Width="10%"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Action:</td><td class="altCent">
                             <asp:LinkButton ID="cancelImageButton" class="btn btn-primary" runat="server" AlternateText="cancel" CommandName="cancel"
                            ImageUrl="~/images/cancel.png" ToolTip="Cancel"><span class="glyphicon glyphicon-arrow-left"></span></asp:LinkButton>
                            <asp:LinkButton class="btn btn-primary" ID="saveImageButton" runat="server" AlternateText="update" CommandName="update"
                            ImageUrl="~/images/save.png" ToolTip="Save" ValidationGroup="Group1"><span class="glyphicon glyphicon-floppy-disk"></span></asp:LinkButton>
                          
            </td>
        </tr>
    </table>
</td>
</tr>
</EditItemTemplate>
<InsertItemTemplate>
<tr>
<td colspan="10">
        
    <table class="table table-condensed">
          <tr>
            <td>Degree Level:</td>
            <td><asp:DropDownList ID="DegreeLevelDDL" class="form-control" runat="server" AutoPostBack="True" ><asp:ListItem Selected="True" Value="0">Select</asp:ListItem></asp:DropDownList>
            <td><asp:RequiredFieldValidator ID="RequiredFieldValidator1" Text="*" runat="server" ErrorMessage="Degree Level" ControlToValidate="DegreeLevelDDL" InitialValue="0" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator></td></td>
            </tr>
            <tr>
            <td>Discipline:</td><td><asp:TextBox ID="DegreeObtainedTxt"  class="form-control" runat="server" Text="" Width="400"></asp:TextBox>
            <td><asp:RequiredFieldValidator ID="RequiredFieldValidator2" Text="*" runat="server" ErrorMessage="Degree Obtained" ControlToValidate="DegreeObtainedTxt" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator></td></td>
         </tr>
         <tr>
            <td>Institution Name:</td><td><asp:TextBox ID="InstitutionNameTxt" class="form-control" runat="server" Text="" Width="400"></asp:TextBox>
            <td><asp:RequiredFieldValidator ID="RequiredFieldValidator8" Text="*" runat="server" ErrorMessage="Institution Name" ControlToValidate="InstitutionNameTxt" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator></td></td>
         </tr>
         <tr>
            <td>Country:</td><td><asp:DropDownList ID="CountryDDL" class="form-control" runat="server" AutoPostBack="True" ><asp:ListItem Selected="True" Value="0">Select</asp:ListItem></asp:DropDownList>
            <td><asp:RequiredFieldValidator ID="RequiredFieldValidator4" Text="*" runat="server" ErrorMessage="Country" ControlToValidate="CountryDDL" InitialValue="0" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator></td></td>
        </tr>
        <%--<tr>
            <td>City:</td><td><asp:DropDownList ID="CityDDL" runat="server" AutoPostBack="True" ><asp:ListItem Selected="True" Value="0">Select</asp:ListItem></asp:DropDownList>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" Text="*" runat="server" ErrorMessage="City" ControlToValidate="CityDDL" InitialValue="0" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator></td>
        </tr>--%>
        <tr>
            <td>Completion Year:</td><td><asp:TextBox ID="CompletionYearTxt" class="form-control" runat="server" Text="" Width="10%"></asp:TextBox>
            <td><asp:RequiredFieldValidator ID="RequiredFieldValidator5" Text="*" runat="server" ErrorMessage="Completion Year" ControlToValidate="CompletionYearTxt" InitialValue="0" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator></td></td>
        </tr>
        <tr>
            <td>Grade:</td><td><asp:TextBox ID="GradeTxt" class="form-control" runat="server" Text="" Width="10%"></asp:TextBox></td>
        </tr>
        <tr>
            <td>CGPA:</td><td><asp:TextBox ID="CGPATxt" class="form-control" runat="server" Text="" Width="10%"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Percentage:</td><td><asp:TextBox ID="PercentageTxt" class="form-control"  runat="server" Text="" Width="10%"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Action:</td><td class="altCent">
                          <asp:LinkButton ID="cancelImageButton" class="btn btn-primary" runat="server" AlternateText="cancel" CommandName="cancel"
                            ImageUrl="~/images/cancel.png" ToolTip="Cancel"><span class="glyphicon glyphicon-arrow-left"></span></asp:LinkButton>
                            <asp:LinkButton class="btn btn-primary" ID="saveImageButton" runat="server" AlternateText="insert" CommandName="insert"
                            ImageUrl="~/images/save.png" ToolTip="Insert" ValidationGroup="Group1"><span class="glyphicon glyphicon-floppy-disk"></span></asp:LinkButton>
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

