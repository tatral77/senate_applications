<%@ Page Title="" Language="C#" MasterPageFile="~/EmployeeInformation.master" AutoEventWireup="true" CodeBehind="EmploymentDetails1.aspx.cs" Inherits="EstablishmentASP.EmploymentDetails1" MaintainScrollPositionOnPostBack="true"%>
<asp:Content ID="Content1" ContentPlaceHolderID="EmpMenues" runat="server">
    <br />
<div class="PageHeading">
EMPLOYMENT DETAILS
</div>
<br />
    <div id="content">
    <form name="f1" method="post" action="">
         <table>

        <tr>
            <td class="style1">File No:</td>
            <td class="PageControl" style="width: 477px">
                <asp:TextBox ID="FileNo" runat="server"></asp:TextBox>
            </td>
       </tr>
        <tr>
            <td class="style1">Main Head:</td>
            <td class="PageControl" style="width: 477px">
                <asp:DropDownList ID="EmpPoolDDL" runat="server" style="margin-left: 0px">
                <asp:ListItem Value="0">Select</asp:ListItem>
                </asp:DropDownList>
            </td>
       </tr>
       <tr>
            <td class="style1">Branch:</td>
            <td class="PageControl" style="width: 477px">
             <asp:DropDownList ID="Branch" runat="server" style="margin-left: 0px">
                <asp:ListItem Value="0">Select</asp:ListItem>
                </asp:DropDownList></td>
       </tr>
       <tr>
            <td class="style1">Post Held:</td>
            <td class="PageControl" style="width: 477px">
             <asp:DropDownList ID="PostHeld" runat="server" style="margin-left: 0px">
                <asp:ListItem Value="0">Select</asp:ListItem>
                </asp:DropDownList></td>
       </tr>
       <tr>
            <td class="style1">Basic Pay Scale:</td>
            <td class="PageControl" style="width: 477px">
             <asp:DropDownList ID="BPS" runat="server" style="margin-left: 0px">
                <asp:ListItem Value="0">Select</asp:ListItem>
                </asp:DropDownList></td>
       </tr>
       <tr>
            <td class="style1">Post Status:</td>
            <td class="PageControl" style="width: 477px">
             <asp:DropDownList ID="PostStatus" runat="server" style="margin-left: 0px">
                <asp:ListItem Value="0">Select</asp:ListItem>
                </asp:DropDownList></td>
       </tr>
      
       <tr>
            <td class="style1">Non-Gazette:</td>
            <td class="PageControl" style="width: 477px">
                <asp:CheckBox ID="NonGazette" runat="server" />
            </td>
       </tr>
        <tr>
            <td class="style1">Employee Status:</td>
            <td class="PageControl" style="width: 477px">
             <asp:DropDownList ID="EmpStatus" runat="server" style="margin-left: 0px">
                <asp:ListItem Value="0">Select</asp:ListItem>
                </asp:DropDownList></td>
       </tr>
       <tr>
            <td class="style1">Govt Service Entry Date:</td>
            <td class="PageControl" style="width: 477px"><asp:TextBox ID="GovtSrvEntry" runat="server" CssClass="js-date"></asp:TextBox></td>
       </tr>
       <tr>
            <td class="style1">Entry into Senate:</td>
            <td class="PageControl" style="width: 477px"><asp:TextBox ID="SenEntry" runat="server" CssClass="js-date"></asp:TextBox></td>
       </tr>
       <tr>
       <td class="style1">Previous Branch:</td>
       <td class="PageControl" style="width: 477px">
            <asp:DropDownList ID="PrevBranch" runat="server" style="margin-left: 0px">
                <asp:ListItem Value="0">Select</asp:ListItem>
                </asp:DropDownList>
       </td>
       </tr>
       <tr>
       <td class="style1">Previous Post Held:</td>
       <td class="PageControl" style="width: 477px">
            <asp:DropDownList ID="PrevPostHeld" runat="server" style="margin-left: 0px">
                <asp:ListItem Value="0">Select</asp:ListItem>
                </asp:DropDownList>
       </td>
       </tr>
       </table>
       <table>
       <tr>
       <td class="style1">Non-Gazette Period From:</td>
       <td class="PageControl">
           <asp:TextBox ID="NonGazFrom" runat="server" CssClass="js-date"></asp:TextBox></td>
       <td class="style1">Non-Gazette Period To:</td>
       <td style="width: 163px" class="PageControl">
           <asp:TextBox ID="NonGazTo" runat="server" CssClass="js-date"></asp:TextBox></td>
       </tr>
       <tr>
       <td class="style1">Gazette Period From:</td>
       <td class="PageControl">
           <asp:TextBox ID="GazFrom" runat="server" CssClass="js-date"></asp:TextBox></td>
       <td class="style1">Gazette Period To:</td>
       <td style="width: 163px" class="PageControl">
           <asp:TextBox ID="GazTo" runat="server" CssClass="js-date"></asp:TextBox></td>
       </tr>
       <tr>
       <td class="style1">Superannuation Date: </td>
       <td class="PageControl">
       <asp:TextBox ID="SuperDate" runat="server" CssClass="js-date"></asp:TextBox></td>
       <td></td><td></td>
       </tr>
       <tr>
       <td colspan="4" ><center><div class="section">PROBATION DETAILS</div></center></td>
       </tr>
       <tr>
       <td class="style1">Period From:</td>
       <td class="PageControl">
           <asp:TextBox ID="ProbFrom" runat="server" CssClass="js-date"></asp:TextBox></td>
       <td class="style1">Period To:</td>
       <td style="width: 163px" class="PageControl">
           <asp:TextBox ID="ProbTo" runat="server" CssClass="js-date"></asp:TextBox></td>

       </tr>
       <tr>
       <td class="style1">Probation Extended:</td>
       <td class="PageControl">
           <asp:DropDownList ID="ProbExtended" runat="server">
               <asp:ListItem Value="0">No</asp:ListItem>
               <asp:ListItem Value="1">Yes</asp:ListItem>
           </asp:DropDownList>
       </td>
       <td class="style1">End Date:</td>
       <td class="PageControl"><asp:TextBox ID="ProbEndDate" runat="server" CssClass="js-date"></asp:TextBox></td>
       </tr>
       <tr>
       <td class="style1">Extension Reason</td>
       <td colspan="3" class="PageControl"><asp:TextBox ID="ProbExtReason" runat="server" 
               Width="291px"></asp:TextBox></td>
       </tr>

       <tr>
       <td colspan="4"><center><div class="section">RE-EMPLOYMENT DETAILS</div></center></td>
       </tr>
       <tr>
       <td class="style1">Period From:</td>
       <td class="PageControl">
           <asp:TextBox ID="ReEmpFrom" runat="server" CssClass="js-date"></asp:TextBox></td>
       <td class="style1">Period To:</td>
       <td style="width: 163px" class="PageControl">
           <asp:TextBox ID="ReEmpTo" runat="server" CssClass="js-date"></asp:TextBox></td>
       </tr>
       <tr>
       <td class="style1">Period of Re-Employment:</td>
       <td colspan="3" class="PageControl"> <asp:TextBox ID="ReEmpPeriod" runat="server" Width="300px"></asp:TextBox></td>
       </tr>
       <tr>
       <td colspan="4"><center><div class="section">POSTING DETAILS</div></center></td>
       </tr>
       <tr>
       <td colspan="4">
    <table width="85%" align="center">
    <tr>
    <th nowrap="nowrap">Sr. No</th>
    <th>Designation</th>
     <th>Branch</th>
     <th>Posted From</th>
     <th>Posted To</th>
     <th>Remarks</th>
     <th>Action</th>
     
    </tr>
    <asp:ListView ID="EmpHistory" 
    OnItemEditing="EmpHistory_ItemEditing"
    OnItemDataBound="EmpHistory_ItemDataBound"
    OnItemCanceling="EmpHistory_ItemCanceling"
    OnItemUpdating="EmpHistory_ItemUpdating"
    OnItemDeleting="EmpHistory_ItemDeleting"
    OnItemCreated="EmpHistory_ItemCreated"
    OnItemInserting="EmpHistory_ItemInserting"
    runat="server">
    <ItemTemplate>
    <tr>
                        <td class="EmpBPS" align="center" nowrap="nowrap">
                                <asp:HiddenField ID="HidEmpHistoryId" runat="server" Value='<%#Bind("HistoryId") %>' />
                                <asp:HiddenField ID="HidDesignationId" runat="server" Value='<%#Bind("DesigId") %>' />
                                <asp:HiddenField ID="HidBranchId" runat="server" Value='<%#Bind("BranchId") %>' />
                           <asp:Label ID="Label3" runat="server" style="font-family: Verdana;font-weight: lighter;" Text='<%#Container.DataItemIndex + 1%> ' />
                        </td>
                        <td class="EmpName">
                            <asp:Label ID="DesignationLabel" style="font-family: Verdana;font-weight: lighter;" runat="server" Text='<%#Bind("Designation") %>' />
                        </td>
                        <td class="EmpName">
                           <asp:Label ID="BranchLabel" style="font-family: Verdana;font-weight: lighter;" runat="server" Text='<%#Bind("Branch") %>' />
                        </td>
                        <td class="EmpName">
                           <asp:Label ID="PostedFrom" style="font-family: Verdana;font-weight: lighter;" runat="server" Text='<%#Bind("StayFrom","{0:dd/MM/yyyy}")%>' />
                        </td>
                        <td class="EmpName">
                           <asp:Label ID="PostedTo" style="font-family: Verdana;font-weight: lighter;" runat="server" Text='<%#Bind("StayTo","{0:dd/MM/yyyy}") %>' />
                        </td>
                        <td class="EmpName">
                           <asp:Label ID="Remarks" style="font-family: Verdana;font-weight: lighter;" runat="server" Text='<%#Bind("Rems") %>' />
                        </td>
                          <td class="AltEmpBPS" align="center" width="15%">
                                <asp:ImageButton ID="editImageButton" runat="server" AlternateText="edit" CommandName="edit"
                                ImageUrl="~/images/edit.png" ToolTip="Edit" />
                                <asp:ImageButton ID="deleteImageButton" runat="server" AlternateText="delete" CommandName="delete"
                                ImageUrl="~/images/delete.png" ToolTip="Delete" OnClientClick="return confirm('Are you sure you want to delete the phone number of Employee');" />
                        </td>
                        
      </tr>
    </ItemTemplate>
    <AlternatingItemTemplate>
    <tr>
                         <td class="AltEmpBPS" align="center" nowrap="nowrap">
                                 <asp:HiddenField ID="HidEmpHistoryId" runat="server" Value='<%#Bind("HistoryId") %>' />
                                <asp:HiddenField ID="HidDesignationId" runat="server" Value='<%#Bind("DesigId") %>' />
                                <asp:HiddenField ID="HidBranchId" runat="server" Value='<%#Bind("BranchId") %>' />
                           
                            <asp:Label ID="Label3" runat="server" style="font-family: Verdana;font-weight: lighter;" Text='<%#Container.DataItemIndex + 1%> ' />
                        </td>
                        <td class="AltEmpName">
                            <asp:Label ID="DesignationLabel" style="font-family: Verdana;font-weight: lighter;" runat="server" Text='<%#Bind("Designation") %>' />
                        </td>
                        <td class="AltEmpName">
                           <asp:Label ID="BranchLabel" style="font-family: Verdana;font-weight: lighter;" runat="server" Text='<%#Bind("Branch") %>' />
                        </td>
                        <td class="AltEmpName">
                           <asp:Label ID="PostedFrom" style="font-family: Verdana;font-weight: lighter;" runat="server" Text='<%#Bind("StayFrom","{0:dd/MM/yyyy}") %>' />
                        </td>
                        <td class="AltEmpName">
                           <asp:Label ID="PostedTo" style="font-family: Verdana;font-weight: lighter;" runat="server" Text='<%#Bind("StayTo","{0:dd/MM/yyyy}") %>' />
                        </td>
                        <td class="AltEmpName">
                           <asp:Label ID="Remarks" style="font-family: Verdana;font-weight: lighter;" runat="server" Text='<%#Bind("Rems") %>' />
                        </td>
                         <td class="AltEmpBPS" align="center">
                                <asp:ImageButton ID="editImageButton" runat="server" AlternateText="edit" CommandName="edit"
                                ImageUrl="~/images/edit.png" ToolTip="Edit" />
                                <asp:ImageButton ID="deleteImageButton" runat="server" AlternateText="delete" CommandName="delete"
                                ImageUrl="~/images/delete.png" ToolTip="Delete" OnClientClick="return confirm('Are you sure you want to delete the phone number of Employee');" />
                        </td>
                   

      </tr>
    </AlternatingItemTemplate>
    <EditItemTemplate>
    <tr>
                        
                        <td>
                        <tr>
                            <td align="center" colspan="7" class="AltEmpBPS" nowrap="nowrap">
                                <asp:HiddenField ID="HidEmpHistoryId" runat="server" Value='<%#Bind("HistoryId") %>' />
                                <asp:HiddenField ID="HidDesignationId" runat="server" Value='<%#Bind("DesigId") %>' />
                                <asp:HiddenField ID="HidBranchId" runat="server" Value='<%#Bind("BranchId") %>' />
                           
                                <asp:Label ID="Label3" runat="server" class="style1" Text='<%#Container.DataItemIndex + 1%> ' ForeColor="Black" Font-Bold="True" Font-Size="Larger" />
                            </td>
                        </tr>
                            <tr>
                                <td class="style1" colspan="2">Designation</td>
                                <td colspan="5" align="left"><asp:DropDownList ID="DesignationDDL"  runat="server">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" Text="*" runat="server" ErrorMessage="Post" ControlToValidate="DesignationDDL" InitialValue="0" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" class="style1">Branch</td>
                                <td colspan="5" align="left"> <asp:DropDownList ID="BranchDDL"  runat="server" >
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" Text="*" runat="server" ErrorMessage="Branch" ControlToValidate="BranchDDL" InitialValue="0" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="style1" nowrap="nowrap" colspan="2">Posted From</td>              
                                <td colspan="5" align="left"><asp:TextBox ID="PostedFromTxt"  runat="server" Text='<%#Bind("StayFrom","{0:dd/MM/yyyy}") %>'  CssClass="js-date"/>
                                <asp:CompareValidator id="dateValidator" runat="server" Type="Date" ValidationGroup="Group1" Operator="DataTypeCheck" Text="*" ControlToValidate="PostedFromTxt" ErrorMessage="Please enter a valid date."></asp:CompareValidator>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" Text="*" runat="server" ErrorMessage="Posted From" ControlToValidate="PostedFromTxt" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="style1" colspan="2">Posted To</td>
                                <td colspan="5" align="left"><asp:TextBox ID="PostedToTxt" runat="server" Text='<%#Bind("StayTo","{0:dd/MM/yyyy}") %>'  CssClass="js-date"/>
                                <asp:CustomValidator ID="DateRangeVal" runat="server" ControlToValidate="PostedToTxt" ClientValidationFunction="HrmDateRange" Display="Dynamic" ValidationGroup="Group1" Text="To Date cannot be earlier than From Date." ErrorMessage="To Date cannot be earlier than From Date."></asp:CustomValidator>
                                <asp:CompareValidator id="CompareValidator1" runat="server" Type="Date" ValidationGroup="Group1" Operator="DataTypeCheck" Text="*" ControlToValidate="PostedToTxt" ErrorMessage="Please enter a valid date."></asp:CompareValidator>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" Text="*" runat="server" ErrorMessage="Posted To" ControlToValidate="PostedToTxt" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                                </td>
                            </tr>   
                            <tr>
                                <td class="style1" colspan="2">Remarks</td>
                                <td colspan="5" align="left"><asp:TextBox ID="RemarksTxt" runat="server" Text='<%#Bind("Rems") %>' Height="121px" TextMode="MultiLine" Width="333px"/>
                                </td>
                            </tr> 
                            
                      
                        <tr>
                        <td align="center" colspan="7" width="85%" class="Style1">
                                <asp:ImageButton ID="cancelImageButton" runat="server" AlternateText="cancel" CommandName="cancel"
                            ImageUrl="~/images/cancel.png" ToolTip="Cancel" />
                            <asp:ImageButton ID="saveImageButton" runat="server" AlternateText="update" CommandName="update"
                            ImageUrl="~/images/save.png" ToolTip="Save" ValidationGroup="Group1" />
                            
                        </td>
                        </tr>
                        
                </td>    

      </tr>
    </EditItemTemplate>
    <InsertItemTemplate>
    <tr>
                        
                        <td>
                        <tr>
                            <td align="center" colspan="7" nowrap="nowrap">
                                <asp:Label ID="Label3" runat="server" class="style1" Text=" New Posting Detail" />
                            </td>
                        </tr>
                            <tr>
                                <td class="style1" colspan="2">Designation</td>
                                <td colspan="5" align="left"><asp:DropDownList ID="DesignationDDL"  runat="server">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" Text="*" runat="server" ErrorMessage="Post" ControlToValidate="DesignationDDL" InitialValue="0" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2"class="style1">Branch</td>
                                <td colspan="5" align="left"> <asp:DropDownList ID="BranchDDL"  runat="server" >
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" Text="*" runat="server" ErrorMessage="Branch" ControlToValidate="BranchDDL" InitialValue="0" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="style1" nowrap="nowrap" colspan="2">Posted From</td>              
                                <td colspan="5" align="left"><asp:TextBox ID="PostedFromTxt"  runat="server" Text=""  CssClass="js-date"/>
                                <asp:CompareValidator id="dateValidator" runat="server" Type="Date" ValidationGroup="Group1" Operator="DataTypeCheck" Text="*" ControlToValidate="PostedFromTxt" ErrorMessage="Please enter a valid date."></asp:CompareValidator>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" Text="*" runat="server" ErrorMessage="Posted From" ControlToValidate="PostedFromTxt" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="style1" colspan="2">Posted To</td>
                                <td colspan="5" align="left"><asp:TextBox ID="PostedToTxt" runat="server" Text=""  CssClass="js-date"/>
                                <asp:CustomValidator ID="DateRangeVal" runat="server" ControlToValidate="PostedToTxt" ClientValidationFunction="HrmDateRange" Display="Dynamic" ValidationGroup="Group1" Text="To Date cannot be earlier than From Date." ErrorMessage="To Date cannot be earlier than From Date."></asp:CustomValidator>
                                <asp:CompareValidator id="CompareValidator1" runat="server" Type="Date" ValidationGroup="Group1" Operator="DataTypeCheck" Text="*" ControlToValidate="PostedToTxt" ErrorMessage="Please enter a valid date."></asp:CompareValidator>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" Text="*" runat="server" ErrorMessage="Posted To" ControlToValidate="PostedToTxt" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                                </td>
                            </tr>   
                            <tr>
                                <td class="style1" colspan="2">Remarks</td>
                                <td colspan="5" align="left"><asp:TextBox ID="RemarksTxt" runat="server" Text="" Height="121px" TextMode="MultiLine" 
                    Width="333px"/></td>
                            </tr> 
                            
                        </td>
                        <tr>
                        <td align="center" colspan="7" width="85%" class="Style1">
                                <asp:ImageButton ID="cancelImageButton" runat="server" AlternateText="cancel" CommandName="cancel"
                            ImageUrl="~/images/cancel.png" ToolTip="Cancel" />
                            <asp:ImageButton ID="saveImageButton" runat="server" AlternateText="Insert" CommandName="Insert"
                            ImageUrl="~/images/save.png" ToolTip="Save" ValidationGroup="Group1"/>
                            
                        </td>
                        </tr>
    </tr>
    
    
    
    </InsertItemTemplate>
    </asp:ListView>

     <tr>
    <td colspan="4">
    <div class="captionCol2" align="left">
                    <asp:Button ID="Button1" class="Pagebutton" runat="server" Text="Add New" CommandName="new" onclick="EmpDetailButton_Click" />
                </div>
    </td>
    </tr>
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
    </td>
    <td> <br /></td>
    </tr>
    <tr>
       <td colspan="4"><center><div class="section">PROMOTION DETAILS</div></center></td>
    </tr>
    <tr>
    <td align="center" colspan="4">
    <table width="85%">
       <tr>
            <th>Sr. No</th>
            <th>Post</th>
            <th>Branch</th>
            <th>BPS</th>
            <th>Date</th>
            <th>Remarks</th>
            <th>Action</th>
      </tr>
    <asp:ListView ID="EmpPromotion" 
    OnItemCreated="EmpPromotion_ItemCreated" 
    OnItemInserting="EmpPromotion_ItemInserting"
    OnItemEditing="EmpPromotion_ItemEditing"
    OnItemDataBound="EmpPromotion_ItemDataBound"
     OnItemDeleting="EmpPromotion_ItemDeleting"
     OnItemCanceling="EmpPromotion_ItemCanceling"
     OnItemUpdating="EmpPromotion_ItemUpdating"

     runat="server">
    <%--
    
    OnItemCanceling="EmpHistory_ItemCanceling"
    OnItemUpdating="EmpHistory_ItemUpdating"
   "
    
    --%>
   
    <ItemTemplate>
    <tr>
                        <td class="EmpBPS" align="center">
                            <asp:HiddenField ID="HidEmpPromotionId" runat="server" Value='<%#Bind("empPromotionId") %>' />
                            <asp:Label ID="Label3" runat="server" style="font-family: Verdana;font-weight: lighter;" Text='<%#Container.DataItemIndex + 1%> ' />
                        </td>
                        <td class="EmpName">
                        <asp:Label ID="DesignationLabel" style="font-family: Verdana;font-weight: lighter;" runat="server" Text='<%# GetPost(Convert.ToInt32(Eval("PostId")))%>' />
                        </td>
                        <td class="EmpName">
                           <asp:Label ID="BranchLabel" style="font-family: Verdana;font-weight: lighter;" runat="server" Text='<%# GetBranch(Convert.ToInt32(Eval("BranchId"))) %>' />
                        </td>
                        <td class="EmpName">
                           <asp:Label ID="Label1" style="font-family: Verdana;font-weight: lighter;" runat="server" Text='<%# GetBps(Convert.ToInt32(Eval("Bps"))) %>' />
                        </td>
                        <td class="EmpName">
                           <asp:Label ID="DateLabel" style="font-family: Verdana;font-weight: lighter;" runat="server" Text='<%#Bind("PromotionDate","{0:dd/MM/yyyy}")%>' />
                        </td>
                         <td class="EmpName">
                           <asp:Label ID="RemarksLabel" style="font-family: Verdana;font-weight: lighter;" runat="server" Text='<%#Bind("Remarks")%>' />
                        </td>
                        
                         <td class="AltEmpBPS" align="center" width="15%">
                                <asp:ImageButton ID="editImageButton" runat="server" AlternateText="edit" CommandName="edit"
                                ImageUrl="~/images/edit.png" ToolTip="Edit" />
                                <asp:ImageButton ID="deleteImageButton" runat="server" AlternateText="delete" CommandName="delete"
                                ImageUrl="~/images/delete.png" ToolTip="Delete" OnClientClick="return confirm('Are you sure you want to delete the phone number of Employee');" />
                        </td>

    </tr>
       </ItemTemplate>
    <AlternatingItemTemplate>
    <tr>
    <td class="AltEmpBPS" align="center">
                            <asp:HiddenField ID="HidEmpPromotionId" runat="server" Value='<%#Bind("EmpPromotionId") %>' />
                            <asp:Label ID="Label3" runat="server" style="font-family: Verdana;font-weight: lighter;" Text='<%#Container.DataItemIndex + 1%> ' />
                        </td>
                        <td class="AltEmpName">
                            <asp:Label ID="DesignationLabel" style="font-family: Verdana;font-weight: lighter;" runat="server" Text='<%# GetPost(Convert.ToInt32(Eval("PostId")))%>' />
                        </td>
                        <td class="AltEmpName">
                           <asp:Label ID="BranchLabel" style="font-family: Verdana;font-weight: lighter;" runat="server" Text='<%# GetBranch(Convert.ToInt32(Eval("BranchId")))%>' />
                        </td>
                         <td class="EmpName">
                           <asp:Label ID="Label1" style="font-family: Verdana;font-weight: lighter;" runat="server" Text='<%# GetBps(Convert.ToInt32(Eval("Bps"))) %>' />
                        </td>
                        <td class="AltEmpName">
                           <asp:Label ID="DateLabel" style="font-family: Verdana;font-weight: lighter;" runat="server" Text='<%#Bind("PromotionDate","{0:dd/MM/yyyy}") %>' />
                        </td>
                        <td class="AltEmpName">
                           <asp:Label ID="RemarksLabel" style="font-family: Verdana;font-weight: lighter;" runat="server" Text="" />
                        </td>
                         <td class="AltEmpBPS" align="center" width="15%">
                                <asp:ImageButton ID="editImageButton" runat="server" AlternateText="edit" CommandName="edit"
                                ImageUrl="~/images/edit.png" ToolTip="Edit" />
                                <asp:ImageButton ID="deleteImageButton" runat="server" AlternateText="delete" CommandName="delete"
                                ImageUrl="~/images/delete.png" ToolTip="Delete" OnClientClick="return confirm('Are you sure you want to delete the phone number of Employee');" />
                        </td>
</tr>
    </AlternatingItemTemplate>
    <EditItemTemplate>
    
     <tr>
                        
                        <td>
                        <tr>
                            <td align="center" colspan="6" width="90%" class="AltEmpBPS" >
                                <asp:HiddenField ID="HidEmpPromotionId" runat="server" Value='<%#Bind("empPromotionId") %>' />
                                <asp:HiddenField ID="HidDesignationId" runat="server" Value='<%#Bind("PostId") %>' /> 
                                <asp:HiddenField ID="HidBranchId" runat="server" Value='<%#Bind("BranchId") %>' />
                                <asp:HiddenField ID="HidBPSId" runat="server" Value='<%#Bind("Bps") %>' />
                           
                                <asp:Label ID="Label3" runat="server" class="style1" Text='<%#Container.DataItemIndex + 1%> ' ForeColor="Black" Font-Bold="True" Font-Size="Larger" />
                            </td>
                        </tr>
                            <tr>
                                <td class="style1">Designation</td>
                                <td colspan="5" align="left"><asp:DropDownList ID="DesignationDDL"  runat="server">
                                </asp:DropDownList></td>
                            </tr>
                            <tr>
                                <td width="40%" class="style1">Branch</td>
                                <td colspan="5" align="left"><asp:DropDownList ID="BranchDDL"  runat="server" >
                                </asp:DropDownList></td>
                            </tr>
                            <tr>
                                <td width="40%" class="style1">BPS</td>
                                <td colspan="5" align="left"><asp:DropDownList ID="BPSDDL"  runat="server" >
                                </asp:DropDownList></td>
                            </tr>
                            <tr>
                                <td class="style1" nowrap="nowrap">Promotion date</td>              
                                <td colspan="5" align="left"><asp:TextBox ID="PostedFromTxt"  runat="server" Text='<%#Bind("PromotionDate","{0:dd/MM/yyyy}") %>'  CssClass="js-date"/></td>
                            </tr>
                            
                            <tr>
                                <td class="style1">Remarks</td>
                                <td colspan="5" align="left"><asp:TextBox ID="RemarksTxt" runat="server" Text='<%#Bind("Remarks") %>' Height="121px" TextMode="MultiLine" 
                    Width="333px"/></td>
                            </tr> 
                            
                      
                        <tr>
                        <td align="center" colspan="6" width="90%" class="Style1">
                                <asp:ImageButton ID="cancelImageButton" runat="server" AlternateText="cancel" CommandName="cancel"
                            ImageUrl="~/images/cancel.png" ToolTip="Cancel" />
                            <asp:ImageButton ID="saveImageButton" runat="server" AlternateText="update" CommandName="update"
                            ImageUrl="~/images/save.png" ToolTip="Save" />
                            
                        </td>
                        </tr>
                        
                </td>    

      </tr>
     
    </EditItemTemplate>
    <InsertItemTemplate>
    <tr>
                        
                    <td>
                        <tr>
                            <td align="center" colspan="6" width="90%" class="AltEmpBPS" >
                                
                           
                                <asp:Label ID="Label3" runat="server" class="style1" Text=" New Promotion Detail" />
                            </td>
                        </tr>
                            <tr>
                                <td class="style1">Designation</td>
                                <td colspan="5" align="left"><asp:DropDownList ID="DesignationDDL"  runat="server">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" Text="*" runat="server" ErrorMessage="Designation" ControlToValidate="DesignationDDL" InitialValue="0" ValidationGroup="Group2" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                                </td>
                            </tr>

                            <tr>
                                <td class="style1">Branch</td>
                                <td colspan="5" align="left"> <asp:DropDownList ID="BranchDDL"  runat="server" >
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" Text="*" runat="server" ErrorMessage="Branch" ControlToValidate="BranchDDL" InitialValue="0" ValidationGroup="Group2" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="style1">BPS</td>
                                <td colspan="5" align="left"><asp:DropDownList ID="BPSDDL"  runat="server">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" Text="*" runat="server" ErrorMessage="BPS" ControlToValidate="BPSDDL" InitialValue="0" ValidationGroup="Group2" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="style1" nowrap="nowrap">Promotion date</td>              
                                <td colspan="5" align="left"><asp:TextBox ID="PromotionDateTxt"  runat="server" Text=""  CssClass="js-date"/>
                                <asp:CompareValidator id="dateValidator" runat="server" Type="Date" ValidationGroup="Group2" Operator="DataTypeCheck" Text="*" ControlToValidate="PromotionDateTxt" ErrorMessage="Please enter a valid date."></asp:CompareValidator>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" Text="*" runat="server" ErrorMessage="Promotion Date" ControlToValidate="PromotionDateTxt" ValidationGroup="Group2" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            
                            <tr>
                                <td class="style1">Remarks</td>
                                <td colspan="5" align="left"><asp:TextBox ID="RemarksTxt" runat="server" Text="" Height="121px" TextMode="MultiLine" 
                    Width="333px"/></td>
                            </tr> 
                            
                      
                        <tr>
                        <td align="center" colspan="6" width="90%" class="Style1">
                                <asp:ImageButton ID="cancelImageButton" runat="server" AlternateText="cancel" CommandName="cancel"
                            ImageUrl="~/images/cancel.png" ToolTip="Cancel" />
                            <asp:ImageButton ID="saveImageButton" runat="server" AlternateText="Insert" CommandName="Insert"
                            ImageUrl="~/images/save.png" ToolTip="Save" ValidationGroup="Group2" />
                            
                        </td>
                        </tr>
                        
                </td>    

      </tr>
    
    
    
    </InsertItemTemplate>
    </asp:ListView>
     <tr>
    <td colspan="4">
    <div class="captionCol2" align="left">
                    <asp:Button ID="LinkButton1" class="Pagebutton" runat="server" Text="Add New" CommandName="new" onclick="NewPromButton_Click" />
                </div>
    </td>
    </tr>
   </table>
    
    </td>
    
    </tr>
    <tr>
        <td colspan="2" align="right" >
            <asp:Button ID="Savebtn" class="Pagebutton" runat="server" Text="Save" ValidationGroup="Group1" onclick="Savebtn_Click" />
       </td>
    </tr>
    <tr>
    <td align="left" colspan="4">
    <asp:ValidationSummary ID="ValidationSummary2"
        HeaderText="You must enter a value in the following fields:"
        DisplayMode="BulletList"
        EnableClientScript="true"
        ShowSummary="true"
        runat="server" ValidationGroup="Group2" ForeColor="#FF3300" />
      </td>
    </tr>
          
       </table>
</form>

       </div>
</asp:Content>
