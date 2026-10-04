<%@ Page Title="" Language="C#" MasterPageFile="~/EmployeeInformation.master" AutoEventWireup="true" CodeBehind="EmpOtherDuties.aspx.cs" Inherits="EstablishmentASP.EmpOtherDuties" %>
<asp:Content ID="Content1" ContentPlaceHolderID="EmpMenues" runat="server">
     <div class="container-fluid regularDiv">
         <div class="sec-head"><h5>OTHER DUTIES PERFORMED</h5><asp:Button ID="LinkButton1" runat="server" CommandName="new" Text="Add New" class="btn btn-custom" onclick="newLinkButton_Click" /></div>
<div class="row">
            <div class="col-md-12">
<table class="table table-condensed table-striped table-data">
<tr>
<th>Sr#</th>
<th>Duty Type</th>
<th>Post</th>
<th>BPS</th>
<th>Year</th>
<th>From</th>
<th>To</th>
<th style="width:30%;">Details</th>
<th>Action</th>
</tr>
 <asp:ListView ID="OtherDutyLV" runat="server"
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
    
    <asp:HiddenField ID="HidEmpOtherDutyId" runat="server" Value='<%#Bind("EmpOtherDutyId")%>' />
    <td class="itemCent"><asp:Label ID="SrNo" runat="server" Text='<%#Container.DataItemIndex + 1%> '></asp:Label></td>
    <td class="itemLeft"><asp:Label ID="Label5" runat="server" Text='<%#Bind("DutyType")%>'></asp:Label></td>
    <td class="itemLeft"><asp:Label ID="DescriptionTxt" runat="server" Text='<%#Bind("Post")%>'></asp:Label></td>
    <td class="itemLeft"><asp:Label ID="Label1" runat="server" Text='<%#Bind("BPS")%>'></asp:Label></td>
    <td class="itemLeft"><asp:Label ID="Label4" runat="server" Text='<%#Bind("DutyYear")%>'></asp:Label></td>
      <td class="itemLeft"><asp:Label ID="Label2" runat="server" Text='<%#GetDate(Convert.ToDateTime(Eval("FromDate")))%>'></asp:Label></td>
      <td class="itemLeft"><asp:Label ID="Label3" runat="server" Text='<%#GetDate(Convert.ToDateTime(Eval("ToDate")))%>'></asp:Label></td>
     <td class="itemLeft"><asp:Label ID="Label6" runat="server" Text='<%#Bind("Details")%>'></asp:Label></td>

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
                    <asp:ValidationSummary runat="server" ValidationGroup="Group1" DisplayMode="BulletList"></asp:ValidationSummary>
                </td>
            </tr>
            <tr>
                <td colspan="9">
                <asp:HiddenField ID="HidEmpOtherDutyId" runat="server" Value='<%#Bind("EmpOtherDutyId")%>' />
                <asp:HiddenField ID="HidDutyTypeId" runat="server" Value='<%#Bind("DutyTypeId")%>' />
                <asp:HiddenField ID="HidPostId" runat="server" Value='<%#Bind("PostId")%>' />
                <asp:HiddenField ID="HidBPSID" runat="server" Value='<%#Bind("BPSID")%>' />
                <table class="table table-condensed table-data">
                <tr>
                    <td class="table-data">Duty Type</td>
                    <td>
                        <asp:DropDownList ID="DutyTypeDDL" class="form-control control-txt" runat="server"> </asp:DropDownList>
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
                    <td class="table-data">Year</td>
                    <td>
                        <asp:TextBox ID="DutyYearTxt" class="form-control control-txt" runat="server" Text='<%#Bind("DutyYear")%>' ></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" Text="*" runat="server" ErrorMessage="Duty Year" Display="Dynamic" ControlToValidate="DutyYearTxt" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">From Date</td>
                    <td>
                        <asp:TextBox ID="FromDateTxt" class="form-control control-txt js-date" runat="server" Text='<%#GetDate(Convert.ToDateTime(Eval("FromDate")))%>' ></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">To Date</td>
                    <td>
                        <asp:TextBox ID="ToDateTxt" class="form-control control-txt js-date" runat="server" Text='<%#GetDate(Convert.ToDateTime(Eval("ToDate")))%>' ></asp:TextBox>
                        <asp:CustomValidator ID="DateRangeVal" runat="server" ControlToValidate="ToDateTxt" ClientValidationFunction="HrmDateRange" Display="Dynamic" ValidationGroup="Group1" Text="To Date cannot be earlier than From Date." ErrorMessage="To Date cannot be earlier than From Date."></asp:CustomValidator>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">Details</td>
                    <td>
                        <asp:TextBox ID="DetailsTxt" class="form-control" runat="server" Text='<%#Bind("Details")%>' Height="121px" TextMode="MultiLine" Width="333px"/>
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
                    <asp:ValidationSummary runat="server" ValidationGroup="Group1" DisplayMode="BulletList"></asp:ValidationSummary>
                </td>
            </tr>
            <tr>
                <td colspan="9">
                <table class="table table-condensed table-data">
                <tr>
                    <td class="table-data">Duty Type</td>
                    <td>
                        <asp:DropDownList ID="DutyTypeDDL" class="form-control control-txt" runat="server"> </asp:DropDownList>
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
                    <td class="table-data">Year</td>
                    <td>
                        <asp:TextBox ID="DutyYearTxt" class="form-control control-txt" runat="server" Text="" ></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" Text="*" runat="server" ErrorMessage="Duty Year" Display="Dynamic" ControlToValidate="DutyYearTxt" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">From Date</td>
                    <td>
                        <asp:TextBox ID="FromDateTxt" class="form-control control-txt js-date" runat="server" Text="" ></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">To Date</td>
                    <td>
                        <asp:TextBox ID="ToDateTxt" class="form-control control-txt js-date" runat="server" Text="" ></asp:TextBox>
                        <asp:CustomValidator ID="DateRangeVal" runat="server" ControlToValidate="ToDateTxt" ClientValidationFunction="HrmDateRange" Display="Dynamic" ValidationGroup="Group1" Text="To Date cannot be earlier than From Date." ErrorMessage="To Date cannot be earlier than From Date."></asp:CustomValidator>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">Details</td>
                    <td>
                        <asp:TextBox ID="DetailsTxt" class="form-control" runat="server" Text='' Height="121px" TextMode="MultiLine" Width="333px"/>
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
