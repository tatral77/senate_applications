<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="ManageAssemblies.aspx.cs" Inherits="QuestionManagement.ManageAssemblies" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <div class="container container-fluid">
         <div class="row">
            <div class="col-md-9">
               <h4> <label class="page-header">ASSEMBLIES</label></h4>
                </div>
            <div class="col-md-2 page-header ">
                 <asp:Button ID="LinkButton1" runat="server" CommandName="new" Text="Add New" class="btn btn-custom" onclick="newLinkButton_Click" />

            </div></div>
<div class="row">
            <div class="col-md-11">
<table class="table table-condensed table-striped table-data">
<tr>
<th>Sr#</th>

<th>Term</th>
<th>From Date</th>
<th>To Date</th>
<th>No of seats</th>
<th>Election Year</th>
<th>Maximun Starred Allowed</th>
<th>Maximun UnStarred Allowed</th>
<th>Maximun S Notice Allowed</th>
<th>Active</th>
</tr>
 <asp:ListView ID="ListView1" runat="server"
  OnItemEditing="ItemEditing"
  OnItemInserting="ItemInserting"
  OnItemCanceling="ItemCanceling"
  OnItemUpdating="ItemUpdating"
  OnItemDataBound="ItemDataBound"
  OnItemCreated="ItemCreated"
 >

 <ItemTemplate>
 <tr>
    
    <asp:HiddenField ID="HidAssembliesId" runat="server" Value='<%#Bind("AssembliesId")%>' />
    <td class="itemCent"><asp:Label ID="SrNo" runat="server" Text='<%#Container.DataItemIndex + 1%> '></asp:Label></td>
    <td class="itemLeft"><asp:Label ID="Label7" runat="server" Text='<%#Bind("Term")%>'></asp:Label></td
    <td class="itemLeft"><asp:Label ID="Label4" runat="server" Text='<%#Bind("FromDate")%>'></asp:Label></td>
    <td class="itemLeft"><asp:Label ID="Label6" runat="server" Text='<%#Bind("ToDate")%>'></asp:Label></td>
    <td class="itemLeft"><asp:Label ID="Label8" runat="server" Text='<%#Bind("NoOfSeats")%>'></asp:Label></td>
    <td class="itemLeft"><asp:Label ID="Label9" runat="server" Text='<%#Bind("ElectionYear")%>'></asp:Label></td>
    <td class="itemLeft"><asp:Label ID="Label10" runat="server" Text='<%#Bind("MaxStarredAllowed")%>'></asp:Label></td>
    <td class="itemLeft"><asp:Label ID="Label11" runat="server" Text='<%#Bind("MaxUnStarredAllowed")%>'></asp:Label></td>
    <td class="itemLeft"><asp:Label ID="Label12" runat="server" Text='<%#Bind("MaxSNoticeAllowed")%>'></asp:Label></td>
    <td class="itemLeft"><asp:Label ID="Label2" runat="server" Text='<%#(Convert.ToInt32(Eval("IsActive"))==1)?"Yes":"No"%>'></asp:Label></td>
   <td class="itemCent">
                                 <asp:LinkButton ID="editImageButton" class="btn btn-custom" runat="server"  CommandName="edit"
                                 ToolTip="Edit"><span class="glyphicon glyphicon-pencil"></span></asp:LinkButton>
                             <%-- <asp:LinkButton ID="deleteImageButton" class="btn btn-custom" runat="server"  CommandName="delete"
                                 ToolTip="Delete" OnClientClick="return confirm('Are you sure you want to delete record ?');"><span class="glyphicon glyphicon-erase"></span></asp:LinkButton>--%>
                        </td>
  </tr>
 </ItemTemplate>
 
  <EditItemTemplate>
   <tr>
        <td colspan="7">
        <table class="table table-condensed table-data" >
                        <asp:HiddenField ID="HidAssembliesId" runat="server" Value='<%#Bind("AssembliesId")%>' />
                        <asp:HiddenField ID="HidIsActive" runat="server" Value='<%#Bind("IsActive")%>' />
             
             <tr>
                 <asp:Label ID="Label4" runat="server" class="form-control" Text="Label">Term</asp:Label>
             <td>
                                    <asp:TextBox ID="TermTxt" class="form-control" runat="server" Text='<%#Bind("Term")%>'></asp:TextBox>
                                 </td>
                  </tr>

            <tr>
                 <asp:Label ID="Label1" runat="server" class="form-control" Text="Label">From Date</asp:Label>
             <td>
                                    <asp:TextBox ID="FromDateTxt" class="form-control js-date" runat="server" Text='<%#Bind("FromDate")%>'></asp:TextBox>
                                 </td>
                  </tr>
            <tr>
                 <asp:Label ID="Label18" runat="server" class="form-control" Text="Label">To Date</asp:Label>
             <td>
                                    <asp:TextBox ID="ToDateTxt" class="form-control js-date" runat="server" Text='<%#Bind("NoOfSeats")%>'></asp:TextBox>
                                 </td>
                  </tr>

           <tr>
                 <asp:Label ID="Label3" runat="server" class="form-control" Text="Label">No of Seats</asp:Label>
             <td>
                                    <asp:TextBox ID="NoOfSeatsTxt" class="form-control" runat="server" Text='<%#Bind("NoOfSeats")%>'></asp:TextBox>
                                 </td>
                  </tr>
             <tr>
                 <asp:Label ID="Label13" runat="server" class="form-control" Text="Label">Election Year</asp:Label>
             <td>
                                    <asp:TextBox ID="ElectionYearTxt" class="form-control" runat="server" Text='<%#Bind("ElectionYear")%>'></asp:TextBox>
                                 </td>
                  </tr>

           <tr>
                 <asp:Label ID="Label14" runat="server" class="form-control" Text="Label">Maximum Starred Allowed</asp:Label>
             <td>
                                    <asp:TextBox ID="MaxStarredTxt" class="form-control" runat="server" Text='<%#Bind("MaxStarredAllowed")%>'></asp:TextBox>
                                 </td>
                  </tr>
            <tr>
                 <asp:Label ID="Label15" runat="server" class="form-control" Text="Label">Maximum Un Starred Allowed</asp:Label>
             <td>
                                    <asp:TextBox ID="MaxUnStarredTxt" class="form-control" runat="server" Text='<%#Bind("MaxUnStarredAllowed")%>'></asp:TextBox>
                                 </td>
                  </tr>
            <tr>
                 <asp:Label ID="Label16" runat="server" class="form-control" Text="Label">Maximum S Notice Allowed</asp:Label>
             <td>
                                    <asp:TextBox ID="MaxSNoticeTxt" class="form-control" runat="server" Text='<%#Bind("MaxSNoticeAllowed")%>'></asp:TextBox>
                                 </td>
                  </tr>
                            <tr>
                                <td><asp:Label runat="server" >Active</asp:Label></td>
                                <td><asp:DropDownList ID="IsActiveDDL"  class="form-control control-txt" runat="server">
                                    <asp:ListItem Value="1">Yes</asp:ListItem>
                                    <asp:ListItem Value="0">No</asp:ListItem>
                                </asp:DropDownList>
                                 </td>
                            </tr>
                             <tr>
                              
                        <tr>
                        <td colspan="3">
                            <asp:LinkButton ID="cancelImageButton" class="btn btn-custom" runat="server"  CommandName="cancel"
                             ToolTip="Cancel"><span class="glyphicon glyphicon-arrow-left"></span></asp:LinkButton>
                            <asp:LinkButton class="btn btn-custom" ID="saveImageButton" runat="server"  CommandName="update"
                             ToolTip="Save" ValidationGroup="Group1"><span class="glyphicon glyphicon-floppy-disk"></span></asp:LinkButton>
                            
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
                 <asp:Label ID="Label4" runat="server" class="form-control" Text="Label">Term</asp:Label>
             <td>
                                    <asp:TextBox ID="TermTxt" class="form-control" runat="server" Text='<%#Bind("Term")%>'></asp:TextBox>
                                 </td>
                  </tr>

            <tr>
                 <asp:Label ID="Label1" runat="server" class="form-control" Text="Label">From Date</asp:Label>
             <td>
                                    <asp:TextBox ID="FromDateTxt" class="form-control js-date" runat="server" Text='<%#Bind("FromDate")%>'></asp:TextBox>
                                 </td>
                  </tr>

           <tr>
                 <asp:Label ID="Label3" runat="server" class="form-control" Text="Label">To Date</asp:Label>
             <td>
                                    <asp:TextBox ID="ToDateTxt" class="form-control js-date" runat="server" Text='<%#Bind("NoOfSeats")%>'></asp:TextBox>
                                 </td>
                  </tr>
            <tr>
                 <asp:Label ID="Label17" runat="server" class="form-control" Text="Label">No of Seats</asp:Label>
             <td>
                                    <asp:TextBox ID="NoOfSeatsTxt" class="form-control" runat="server" Text='<%#Bind("NoOfSeats")%>'></asp:TextBox>
                                 </td>
                  </tr>
             <tr>
                 <asp:Label ID="Label13" runat="server" class="form-control" Text="Label">Election Year</asp:Label>
             <td>
                                    <asp:TextBox ID="ElectionYearTxt" class="form-control" runat="server" Text='<%#Bind("ElectionYear")%>'></asp:TextBox>
                                 </td>
                  </tr>

           <tr>
                 <asp:Label ID="Label14" runat="server" class="form-control" Text="Label">Maximum Starred Allowed</asp:Label>
             <td>
                                    <asp:TextBox ID="MaxStarredTxt" class="form-control" runat="server" Text='<%#Bind("MaxStarredAllowed")%>'></asp:TextBox>
                                 </td>
                  </tr>
            <tr>
                 <asp:Label ID="Label15" runat="server" class="form-control" Text="Label">Maximum Un Starred Allowed</asp:Label>
             <td>
                                    <asp:TextBox ID="MaxUnStarredTxt" class="form-control" runat="server" Text='<%#Bind("MaxUnStarredAllowed")%>'></asp:TextBox>
                                 </td>
                  </tr>
            <tr>
                 <asp:Label ID="Label16" runat="server" class="form-control" Text="Label">Maximum S Notice Allowed</asp:Label>
             <td>
                                    <asp:TextBox ID="MaxSNoticeTxt" class="form-control" runat="server" Text='<%#Bind("MaxSNoticeAllowed")%>'></asp:TextBox>
                                 </td>
                  </tr>
                                <td><asp:Label runat="server" >Active</asp:Label></td>
                                <td><asp:DropDownList ID="IsActiveDDL"  class="form-control control-txt" runat="server">
                                    <asp:ListItem Value="1">Yes</asp:ListItem>
                                    <asp:ListItem Value="0">No</asp:ListItem>
                                </asp:DropDownList>
                                 </td>
                            </tr>
                             <tr>
                              
                        <tr>
                      
                        <tr>
                        <td colspan="3">
                            <asp:LinkButton ID="cancelImageButton" class="btn btn-custom" runat="server"  CommandName="cancel"
                             ToolTip="Cancel"><span class="glyphicon glyphicon-arrow-left"></span></asp:LinkButton>
                            <asp:LinkButton class="btn btn-custom" ID="saveImageButton" runat="server"  CommandName="insert"
                             ToolTip="Save" ValidationGroup="Group1"><span class="glyphicon glyphicon-floppy-disk"></span></asp:LinkButton>
                            
   </td>
                        </tr>
             </table>           
                </td>    

      </tr>
</InsertItemTemplate>
 <EmptyDataTemplate>
    <tr>
    <td colspan="4" class="altCent" align="center">No Data Found</td>
    </tr>
    </EmptyDataTemplate>
 </asp:ListView>
 
    <tr>
    <td align="left" colspan="4">
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
