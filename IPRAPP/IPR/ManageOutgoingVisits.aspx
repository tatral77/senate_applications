<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="ManageOutgoingVisits.aspx.cs" Inherits="IPR.ManageVisits" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
     .btn-custom
      {
          background-color:#302c2c;
          color:#fff;
      }
    </style>
    <div class="container">
        <div class="row">
            <div class="col-md-9">
                <label class="page-header page-title">VISITS</label>
                </div>
            <div class="col-md-2 page-header" style="text-align:center">
                  <asp:Button ID="Button1" runat="server" CommandName="new" Text="Add New" onclick="newLinkButton_Click" class="btn btn-custom"/>

            </div></div>
         
       <div class="row">
           <div class="col-md-4">
               <label style="font-size:small;font-weight:bold">Financial Year</label>
                <asp:DropDownList ID="FinancialYearDDL" CssClass="form-control" runat="server" AutoPostBack="true" OnSelectedIndexChanged="FinancialYearDDL_SelectedIndexChanged">
                   <%--<asp:ListItem Selected="True" Value="1">2018-2019</asp:ListItem>--%>
               </asp:DropDownList>
           </div>
            <div class="col-md-4">
                <label style="font-size:small;font-weight:bold">Visits</label>
               <asp:DropDownList ID="VisitsDDL" AutoPostBack="true" OnSelectedIndexChanged="VisitsDDL_SelectedIndexChanged" runat="server" class="form-control">
                   <asp:ListItem  Value="1">All</asp:ListItem>
                    <asp:ListItem Selected="True" Value="2">Upcoming</asp:ListItem>
                    <asp:ListItem  Value="3">Previous</asp:ListItem>
               </asp:DropDownList>
           </div>
       </div>
    <div class="row" style="margin-top:20px">
        
        <div class="col-md-11">

<table class="table table-hover table-striped table-condensed table-data table-responsive" >
    <thead>
<tr>
<th>Sr#</th>
<th style="width:40%">Visit Title</th>
<th>Country</th>
<th>From Date</th>
<th>To Date</th>
    <th>Dollar Rate</th>
<th style="max-width:15%">Transport Charges</th>

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
<asp:ListView ID="VisitsLV" runat="server"
OnItemCanceling="ItemCanceling"
OnItemCreated="ItemCreated"
OnItemInserting="ItemInserting"
OnItemEditing="ItemEditing"
OnItemDataBound="ItemDataBound"
OnItemUpdating="ItemUpdating">
 <ItemTemplate>
<tr>    
     <td><asp:HiddenField ID="HidVisitId" runat="server" Value='<%#Bind("VisitId")%>' />
     <asp:Label ID="SrNo" runat="server" Text='<%#Container.DataItemIndex + 1%> '></asp:Label></td>
    <td >
      <%--  <asp:Label ID="DegreeLevelLb" runat="server" Text='<%#Bind("VisitTitle")%>'></asp:Label>--%>
        <asp:HyperLink class="table-data" ID="HyperLink1" runat="server" style="color:black;" NavigateUrl='<%#Eval("VisitId","~/ManageOutgoingVisit.aspx?Id={0}")%>'><%#Eval("VisitTitle")%></asp:HyperLink>
    </td>
    <td><asp:Label ID="DegreeObtLb" runat="server" Text='<%#Bind("CountryName") %>'></asp:Label></td>
    <td><asp:Label ID="Label1" runat="server" Text='<%#GetDate(Convert.ToDateTime(Eval("FromDate"))) %>'></asp:Label></td>
    <td><asp:Label ID="Label2" runat="server" Text='<%#GetDate(Convert.ToDateTime(Eval("ToDate"))) %>'></asp:Label></td>
    <td><asp:Label ID="Label4" runat="server" Text='<%#string.Concat("Rs. ", Eval("DollarRate")) %>'></asp:Label></td>
    <td><asp:Label ID="Label3" runat="server" Text='<%#Bind("TransportCharges") %>'></asp:Label></td>
     
 
    <td>
                               <asp:LinkButton ID="editImageButton" class="btn btn-custom" runat="server"  CommandName="edit"
                                 ToolTip="Edit"><span class="glyphicon glyphicon-pencil"></span></asp:LinkButton>
                                <asp:LinkButton ID="deleteImageButton" class="btn btn-custom" runat="server"  CommandName="delete"
                                 ToolTip="Delete" OnClientClick="return confirm('Are you sure you want to delete');"><span class="glyphicon glyphicon-erase"></span></asp:LinkButton>
                        </td>
  </tr>

</ItemTemplate>

<EditItemTemplate>
<tr>
<td colspan="9">
        <asp:HiddenField ID="HidVisitId" runat="server" Value='<%#Bind("VisitId")%>' />
        <asp:HiddenField ID="HidCountryId" runat="server" Value='<%#Bind("CountryId")%>' />
        <table class="table table-condensed table-data">
             <tr>
            <td>Visit Title:</td><td><asp:TextBox ID="VisitTitleTxt" TextMode="MultiLine" class="form-control"  runat="server" Text='<%#Bind("VisitTitle")%>'></asp:TextBox>
            
        </tr>
          <tr>
            <td>Country:</td>
            <td><asp:DropDownList ID="CountryDDL" runat="server" class="form-control"><asp:ListItem Selected="True" Value="0">Select</asp:ListItem></asp:DropDownList>
            <td><asp:RequiredFieldValidator ID="RequiredFieldValidator1" Text="*" Display="Dynamic" runat="server" ErrorMessage="Post" ControlToValidate="CountryDDL" InitialValue="0" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator></td>
           </td>
               </tr>
           
          <tr>
            <td>From Date:</td><td><asp:TextBox ID="FromDateTxt" class="form-control"  runat="server" Text='<%#GetDate(Convert.ToDateTime(Eval("FromDate"))) %>' ></asp:TextBox>
                <asp:CompareValidator id="EndDateValidator" runat="server" Type="Date" ValidationGroup="Group1" Operator="DataTypeCheck" Text="*" ControlToValidate="FromDateTxt" ErrorMessage="Please enter valid date."></asp:CompareValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" Text="*" runat="server" ErrorMessage="From Date" ControlToValidate="FromDateTxt" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
         </tr>
         <tr>
            <td>To Date:</td><td><asp:TextBox ID="ToDateTxt" class="form-control"  runat="server" Text='<%#GetDate(Convert.ToDateTime(Eval("ToDate"))) %>' ></asp:TextBox>
           <asp:CompareValidator id="CompareValidator1" runat="server" Type="Date" ValidationGroup="Group1" Operator="DataTypeCheck" Text="*" ControlToValidate="ToDateTxt" ErrorMessage="Please enter valid date."></asp:CompareValidator>
           <asp:RequiredFieldValidator ID="RequiredFieldValidator5" Text="*" runat="server" ErrorMessage="To Date" ControlToValidate="ToDateTxt" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
        </tr>
                         <tr>
     <td>Dollar Rate:</td>
     <td><asp:TextBox  ID="DollarRateTxt" class="form-control" type="number"  runat="server" Text='<%#Bind("DollarRate")%>'></asp:TextBox></td>
</tr>
            <tr>
            <td>Transport Charges:</td><td><asp:TextBox ID="TransportChargesTxt" class="form-control"  runat="server" Text='<%#Bind("TransportCharges")%>'></asp:TextBox>
        </tr>
            <tr>
            <td>Transport Charges Description:</td><td><asp:TextBox ID="TransportChargesDescriptionTxt" class="form-control"  runat="server" Text='<%#Bind("TransportChargesDescription")%>'></asp:TextBox>
        </tr>
            <tr>
            <td>Details (if any):</td><td><asp:TextBox ID="DetailsTxt" class="form-control"  runat="server" Text='<%#Bind("Details")%>'></asp:TextBox>
        </tr>
     
        <tr>
            <td>Action:</td><td class="altCent">
                             <asp:LinkButton ID="cancelImageButton" class="btn btn-custom" runat="server"  CommandName="cancel"
                             ToolTip="Cancel"><span class="glyphicon glyphicon-arrow-left"></span></asp:LinkButton>
                            <asp:LinkButton class="btn btn-custom" ID="saveImageButton" runat="server"  CommandName="update"
                             ToolTip="Save" ValidationGroup="Group1"><span class="glyphicon glyphicon-floppy-disk"></span></asp:LinkButton>
                           <asp:Label ID="ErrorLabel" runat="server" Text="" style="color:red;font-size:small"></asp:Label>
            </td>
        </tr>
    </table>
</td>
</tr>
</EditItemTemplate>
<InsertItemTemplate>
<tr>
<tr>
<td colspan="9">
        <table class="table table-condensed table-data">
             <tr>
                 <td>Visit Title:</td>
                 <td><asp:TextBox TextMode="MultiLine" ID="VisitTitleTxt" class="form-control"  runat="server" Text=''></asp:TextBox></td>
            </tr>
            <tr>
                <td>Country:</td>
                <td><asp:DropDownList ID="CountryDDL" runat="server" class="form-control"><asp:ListItem Selected="True" Value="0">Select</asp:ListItem></asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" Text="*" Display="Dynamic" runat="server" ErrorMessage="Select Visit Country" ControlToValidate="CountryDDL" InitialValue="0" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>From Date:</td>
                <td><asp:TextBox ID="FromDateTxt" class="form-control"  runat="server"  type="date" ></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" Text="*" runat="server" ErrorMessage="Please enter valid From Date" ControlToValidate="FromDateTxt" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                    <asp:CompareValidator id="EndDateValidator" runat="server" Type="Date" ValidationGroup="Group1" Operator="DataTypeCheck" Text="*" ControlToValidate="FromDateTxt" ErrorMessage="Please enter valid from date."></asp:CompareValidator>
               </td>
            </tr>
         <tr>
           <td>To Date:</td>
             <td><asp:TextBox ID="ToDateTxt" class="form-control"  runat="server"  type="date" ></asp:TextBox>
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator5" Text="*" runat="server" ErrorMessage="Please enter valid To Date" ControlToValidate="ToDateTxt" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                 <asp:CompareValidator id="CompareValidator1" runat="server" Type="Date" ValidationGroup="Group1" Operator="DataTypeCheck" Text="*" ControlToValidate="ToDateTxt" ErrorMessage="Please enter valid to date."></asp:CompareValidator>
            </td>
        </tr>
              <tr>
      <td>Dollar Rate:</td>
      <td><asp:TextBox  ID="DollarRateTxt" class="form-control" type="number"  runat="server" Text=''></asp:TextBox></td>
 </tr>
            <tr>
            <td>Transport Charges:</td>
                <td><asp:TextBox ID="TransportChargesTxt" class="form-control"  runat="server" Text=''>0</asp:TextBox>
        </tr>
            <tr>
            <td>Transport Charges Description:</td><td><asp:TextBox ID="TransportChargesDescriptionTxt" class="form-control"  runat="server" Text=''></asp:TextBox>
        </tr>
            <tr>
            <td>Details (if any):</td>
                <td><asp:TextBox ID="DetailsTxt" class="form-control"  runat="server" Text=''></asp:TextBox>
        </tr>
        <tr>
            <td>Action:</td>
            <td class="altCent">
                <asp:LinkButton ID="cancelImageButton" class="btn btn-custom" runat="server"  CommandName="cancel" ToolTip="Cancel"><span class="glyphicon glyphicon-arrow-left"></span></asp:LinkButton>
                <asp:LinkButton class="btn btn-custom" ID="saveImageButton" runat="server"  CommandName="insert" ToolTip="Save" ValidationGroup="Group1"><span class="glyphicon glyphicon-floppy-disk"></span></asp:LinkButton>
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
