<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="ManageSessionSittings.aspx.cs" Inherits="QuestionManagement.ManageSessionSittings" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <div class="container container-fluid">
         <div class="row">
            <div class="col-md-5">
               <h4> <label class="page-header">SESSION SITTINGS</label></h4>
                </div>
              <div class="col-md-5">
               <label class="page-header">Session No.</label>
                  <asp:DropDownList ID="SessionDDL" runat="server" OnSelectedIndexChanged="SessionDDL_SelectedIndexChanged"></asp:DropDownList>

                </div>
            <div class="col-md-2 page-header ">
                 <asp:Button ID="LinkButton1" runat="server" CommandName="new" Text="Add New" class="btn btn-custom" onclick="newLinkButton_Click" />
            </div></div> 
<div class="row">
            <div class="col-md-11">
<table class="table table-condensed table-striped table-data">
<tr>
<th>Sr#</th>
<th>Assembly Sessions</th>
<th>Sitting Date</th>
<th>Is Morning Sitting</th>
<th>Start Time</th>
<th>End Time</th>
<th>Evening Start Time</th>
<th>Evening End Time</th>
<th>Action</th>
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
    
    <asp:HiddenField ID="HidSessionSittingsId" runat="server" Value='<%#Bind("SessionSittingsId")%>' />
    <td class="itemCent"><asp:Label ID="SrNo" runat="server" Text='<%#Container.DataItemIndex + 1%> '></asp:Label></td>
    <td class="itemLeft"><asp:Label ID="Label5" runat="server" Text='<%#Bind("Description")%>'></asp:Label></td>
    <td class="itemLeft"><asp:Label ID="DescriptionTxt" runat="server" Text='<%#Bind("AssemblySessionsId")%>'></asp:Label></td>
    <td class="itemLeft"><asp:Label ID="Label4" runat="server" Text='<%#Bind("SessionDate")%>'></asp:Label></td>
    <td class="itemLeft"><asp:Label ID="Label3" runat="server" Text='<%#(Convert.ToInt32(Eval("IsMorningSitting"))==1)?"Yes":"No"%>'></asp:Label></td>
    <td class="itemLeft"><asp:Label ID="Label7" runat="server" Text='<%#Bind("StartTime")%>'></asp:Label></td>
    <td class="itemLeft"><asp:Label ID="Label8" runat="server" Text='<%#Bind("EndTime")%>'></asp:Label></td>
    <td class="itemLeft"><asp:Label ID="Label1" runat="server" Text='<%#Bind("EveningStartTime")%>'></asp:Label></td>
    <td class="itemLeft"><asp:Label ID="Label6" runat="server" Text='<%#Bind("EveningEndTime")%>'></asp:Label></td>
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
                        <asp:HiddenField ID="HidSessionSittingsId" runat="server" Value='<%#Bind("SessionSittingsId")%>' />
                        <asp:HiddenField ID="HidIsActive" runat="server" Value='<%#Bind("IsActive")%>' />
                        <asp:HiddenField ID="HidMorningSitting" runat="server" Value='<%#Bind("IsMorningSitting")%>' />
             
                              
                         <tr>
                                <td class="table-data"><asp:Label runat="server" >Assembly Session</asp:Label></td>
                                <td>
                                    <asp:TextBox ID="AssemblySessionTxt" class="form-control" runat="server" Text='<%#Bind("SessionNumber")%>'></asp:TextBox>
                                 </td>
                            </tr>
                             <tr>
                                <td class="table-data"><asp:Label runat="server" >Session Date</asp:Label></td>
                                <td>
                                    <asp:TextBox ID="SessionDate" class="form-control js-date" runat="server"></asp:TextBox>
                                 </td>
                            </tr>
              <tr>
                                  <td class="table-data">Is Morning Session</td>
                              <td><asp:CheckBox class="form-control" ID="IsMorningSessionCB" Text= " Morning" runat="server" />
                                  <asp:CheckBox class="form-control" ID="IsEveningSessionCB" Text= " Evening" runat="server" />
                                </td>
                            </tr>
            <tr>
                                <td class="table-data"><asp:Label runat="server" >Start Time</asp:Label></td>
                                <td>
                                    <asp:TextBox ID="StartTimeTxt" class="form-control" runat="server"></asp:TextBox>
                                 </td>
                            </tr>
             <tr>
                                <td class="table-data"><asp:Label runat="server" >End Time</asp:Label></td>
                                <td>
                                    <asp:TextBox ID="EndTimeTxt" class="form-control" runat="server"></asp:TextBox>
                                 </td>
                            </tr>
            <tr>
                                <td class="table-data"><asp:Label runat="server" > Evening Start Time</asp:Label></td>
                                <td>
                                    <asp:TextBox ID="EveningStartTimeTxt" class="form-control" runat="server" ></asp:TextBox>
                                 </td>
                            </tr>
             <tr>
                                <td class="table-data"><asp:Label runat="server" >Evening End Time</asp:Label></td>
                                <td>
                                    <asp:TextBox ID="EveningEndTimeTxt" class="form-control" runat="server"></asp:TextBox>
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
                                <td class="table-data"><asp:Label runat="server" >Session Date</asp:Label></td>
                                <td>
                                    <asp:TextBox ID="SessionDate1" class="form-control" runat="server" Text='<%#Bind("SessionDate")%>'></asp:TextBox>
                                 </td>
                            </tr>
                         <tr>
                                <td class="table-data"><asp:Label runat="server" >Assembly Session</asp:Label></td>
                                <td>
                                    <asp:TextBox ID="AssemblySessionTxt" class="form-control" runat="server" Text='<%#Bind("SessionNumber")%>'></asp:TextBox>
                                 </td>
                            </tr>
              <tr>
                                <td class="table-data">Is Morning Session</td>
                              <td><asp:CheckBox class="form-control" ID="IsMorningSessionCB" Text= " Morning" runat="server" />
                                  <asp:CheckBox class="form-control" ID="IsEveningSessionCB" Text= " Evening" runat="server" />
                                </td>
                            </tr>
         
                         <tr>
                                <td class="table-data"><asp:Label runat="server" >Start Time</asp:Label></td>
                                <td>
                                    <asp:TextBox ID="StartTimeTxt" class="form-control" runat="server"></asp:TextBox>
                                  </td>
                            </tr>
             <tr>
                                <td class="table-data"><asp:Label runat="server" >End Time</asp:Label></td>
                                <td>
                                    <asp:TextBox ID="EndTimeTxt" class="form-control" runat="server"></asp:TextBox>
                                 </td>
                            </tr>
            <tr>
                                <td class="table-data"><asp:Label runat="server" > Evening Start Time</asp:Label></td>
                                <td>
                                    <asp:TextBox ID="EveningStartTimeTxt" class="form-control" runat="server" ></asp:TextBox>
                                 </td>
                            </tr>
             <tr>
                                <td class="table-data"><asp:Label runat="server" >Evening End Time</asp:Label></td>
                                <td>
                                    <asp:TextBox ID="EveningEndTimeTxt" class="form-control" runat="server"></asp:TextBox>
                                 </td>
                            </tr>
            <tr>

                 
            <tr>
                          
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
