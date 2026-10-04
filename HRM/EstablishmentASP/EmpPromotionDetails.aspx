<%@ Page Title="" Language="C#" MasterPageFile="~/EmployeeInformation.master" AutoEventWireup="true" CodeBehind="EmpPromotionDetails.aspx.cs" Inherits="EstablishmentASP.EmpPromotionDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="EmpMenues" runat="server">
    <div class="container-fluid regularDiv">
        <div class="sec-head"><h5>PROMOTION DETAILS</h5><asp:Button ID="LinkButton1" class="btn btn-custom" runat="server" Text="Add New" CommandName="new" onclick="NewPromButton_Click" /></div><div class="row">
        <div class="col-md-12">

<table class="table table-hover table-striped table-data">
    <thead style="text-align:center">
       <tr>
            <th>Sr#</th>
           <th>Ref. Id</th>
            <th>Promotion Type</th>
            <th>Promotion Mode</th>
            <th>Post</th>
            <th>BPS</th>
            <th>Date</th>
           <th>Is Gazetted</th>
            <th>Is Current</th>
            <th>Details</th>
           <th>Action</th>
      </tr>
    </thead>
    <tbody>
    <asp:ListView ID="EmpPromotion" 
    OnItemCreated="EmpPromotion_ItemCreated" 
    OnItemInserting="EmpPromotion_ItemInserting"
    OnItemEditing="EmpPromotion_ItemEditing"
    OnItemDataBound="EmpPromotion_ItemDataBound"
     OnItemDeleting="EmpPromotion_ItemDeleting"
     OnItemCanceling="EmpPromotion_ItemCanceling"
     OnItemUpdating="EmpPromotion_ItemUpdating"

     runat="server">
    <ItemTemplate>
    <tr>
                        <td class="itemCent">
                            <asp:HiddenField ID="HidEmpPromotionId" runat="server" Value='<%#Bind("empPromotionId") %>' />
                            <asp:Label ID="Label3" runat="server" class="table-data" Text='<%#Container.DataItemIndex + 1%> ' />
                        </td>
                        <td>                    
                        <asp:Label ID="Label1" class="table-data" runat="server" Text='<%#Eval("empPromotionId")%>' />
                        </td>
                        <td>                    
                        <asp:Label ID="Label9" class="table-data" runat="server" Text='<%#Eval("PromotionType")%>' />
                        </td>
                         <td>                    
                        <asp:Label ID="Label10" class="table-data" runat="server" Text='<%#Eval("PromotionMode")%>' />
                        </td>
                        <td>                    
                        <asp:Label ID="Label2" class="table-data" runat="server" Text='<%#Eval("Post")%>' />
                        </td>
                        <td>
                    
                           <asp:Label ID="Label5" class="table-data" runat="server" Text='<%#Eval("Bps") %>' />
                        </td>
                        <td>
                           <asp:Label ID="DateLabel" class="table-data" runat="server" Text='<%#GetDate(Convert.ToDateTime(Eval("PromotionDate")))%>' />
                        </td>
                         <td>
                            <asp:Label ID="Label7" class="table-data" runat="server" Text='<%#(Convert.ToString(Eval("IsGazetted"))=="1")?"Yes":"No"%>' />
                        </td>
                         <td>
                            <asp:Label ID="Label6" class="table-data" runat="server" Text='<%#(Convert.ToString(Eval("IsCurrent"))=="1")?"Yes":"No"%>' />
                        </td>
                         <td>
                           <asp:Label ID="RemarksLabel" class="table-data" runat="server" Text='<%#Bind("Remarks")%>' />
                        </td>
                   
                         <td>
                                <asp:LinkButton ID="editImageButton" class="btn btn-custom" runat="server"  CommandName="edit"
                                 ToolTip="Edit"><span class="glyphicon glyphicon-pencil"></span></asp:LinkButton>
                                <asp:LinkButton ID="deleteImageButton" class="btn btn-custom" runat="server"  CommandName="delete"
                                 ToolTip="Delete" OnClientClick="return confirm('Are you sure you want to delete therecord ?');"><span class="glyphicon glyphicon-erase"></span></asp:LinkButton>
                        </td>

    </tr>
       </ItemTemplate>
   
    <EditItemTemplate>
            <tr>
                <td colspan="11">
                <asp:HiddenField ID="HidEmpPromotionId" runat="server" Value='<%#Bind("empPromotionId") %>' />
                <asp:HiddenField ID="HidEmpProbationId" runat="server" Value='<%#Bind("ProbationId") %>' />
                <asp:HiddenField ID="HidPromotionModeId" runat="server" Value='<%#Bind("PromotionModeId") %>' />
                <asp:HiddenField ID="HidPromotionTypeId" runat="server" Value='<%#Bind("PromotionTypeId") %>' />
                <asp:HiddenField ID="HidIsGazetted" runat="server" Value='<%#Bind("IsGazetted") %>' />
                <asp:HiddenField ID="HidDesignationId" runat="server" Value='<%#Bind("PostId") %>' />
                <asp:HiddenField ID="HidBPSId" runat="server" Value='<%#Bind("Bps") %>' />
                <asp:HiddenField ID="HidIsExtended" runat="server" Value='<%#Bind("IsExtended") %>' />
                <asp:HiddenField ID="HidIsCurrent" runat="server" Value='<%#Bind("IsCurrent") %>' />
                <table class="table table-condensed table-data">
                <tr>
                    <td class="table-data">Promotion Type</td>
                    <td>
                        <asp:DropDownList ID="PromotionTypeDDL" class="form-control" runat="server"> </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" Display="Dynamic" Text="*" runat="server" ErrorMessage="Promotion Type" ControlToValidate="PromotionTypeDDL" InitialValue="0" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">Promotion Mode</td>
                    <td>
                        <asp:DropDownList ID="PromotionModeDDL" class="form-control" runat="server"> </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" Display="Dynamic" Text="*" runat="server" ErrorMessage="Promotion Mode" ControlToValidate="PromotionModeDDL" InitialValue="0" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">Designation</td>
                    <td>
                        <asp:DropDownList ID="DesignationDDL" class="form-control" runat="server"> </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" Display="Dynamic" Text="*" runat="server" ErrorMessage="Designation" ControlToValidate="DesignationDDL" InitialValue="0" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">BPS</td>
                    <td>
                        <asp:DropDownList ID="BPSDDL" class="form-control" runat="server" > </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="PostTypeValidator" Display="Dynamic" Text="*" runat="server" ErrorMessage="BPS" ControlToValidate="BPSDDL" InitialValue="0" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">Promotion date</td>
                    <td>
                        <asp:TextBox ID="PromotionDateTxt" class="form-control js-date" runat="server" Text='<%#Bind("PromotionDate","{0:dd/MM/yyyy}") %>' />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" Display="Dynamic" Text="*" runat="server" ErrorMessage="Promotion Date" ControlToValidate="PromotionDateTxt" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">Is Current</td>
                    <td>
                        <asp:CheckBox class="form-control" ID="IsCurrentCB" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td class="table-data">Is Gazetted</td>
                    <td>
                        <asp:CheckBox class="form-control" ID="IsGazettedCB" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td class="table-data">Details</td>
                    <td>
                        <asp:TextBox ID="RemarksTxt" runat="server" class="form-control" Text='<%#Bind("Remarks") %>' Height="121px" TextMode="MultiLine" Width="333px"/>
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
                    <td class="table-data">Promotion Type</td>
                    <td>
                        <asp:DropDownList ID="PromotionTypeDDL" class="form-control" runat="server"> </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" Display="Dynamic" Text="*" runat="server" ErrorMessage="Promotion Type" ControlToValidate="PromotionTypeDDL" InitialValue="0" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">Promotion Mode</td>
                    <td>
                        <asp:DropDownList ID="PromotionModeDDL" class="form-control" runat="server"> </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" Display="Dynamic" Text="*" runat="server" ErrorMessage="Promotion Mode" ControlToValidate="PromotionModeDDL" InitialValue="0" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">Designation</td>
                    <td>
                        <asp:DropDownList ID="DesignationDDL" class="form-control" runat="server"> </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">BPS</td>
                    <td>
                        <asp:DropDownList ID="BPSDDL" class="form-control" runat="server" > </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">Promotion date</td>
                    <td>
                        <asp:TextBox ID="PromotionDateTxt" class="form-control js-date" runat="server" Text='' />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" Display="Dynamic" Text="*" runat="server" ErrorMessage="Promotion Date" ControlToValidate="PromotionDateTxt" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">Probation From</td>
                    <td>
                        <asp:TextBox ID="ProbationFromTxt" runat="server" class="form-control js-date" Text='' Width="333px"/>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">Probation To</td>
                    <td>
                        <asp:TextBox ID="ProbationToTxt" runat="server" class="form-control js-date" Text='' Width="333px"/>
                        <asp:CustomValidator ID="DateRangeVal" runat="server" ControlToValidate="ProbationToTxt" ClientValidationFunction="HrmDateRange" Display="Dynamic" ValidationGroup="Group1" Text="To Date cannot be earlier than From Date." ErrorMessage="To Date cannot be earlier than From Date."></asp:CustomValidator>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">Is Current</td>
                    <td>
                        <asp:CheckBox class="form-control" ID="IsCurrentCB" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td class="table-data">Is Gazetted</td>
                    <td>
                        <asp:CheckBox class="form-control" ID="IsGazettedCB" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td class="table-data">Details</td>
                    <td>
                        <asp:TextBox ID="RemarksTxt" runat="server" class="form-control" Text='' Height="121px" TextMode="MultiLine" Width="333px"/>
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

   
    <tr>
    <td colspan="11">
    <asp:ValidationSummary ID="ValidationSummary2"
        HeaderText="You must enter a value in the following fields:"
        DisplayMode="BulletList"
        EnableClientScript="true"
        ShowSummary="true"
        runat="server" ValidationGroup="Group2" ForeColor="#FF3300" />
      </td>
    </tr>
</tbody>          
 </table>
</div>
 </div>
</div> 
<div class="container-fluid regularDiv">
        <div class="sec-head"><h5>PROBATION DETAILS</h5><asp:Button ID="Button2" class="btn btn-custom" runat="server" Text="Add New" CommandName="new" onclick="newProbation_Click" /></div>
   <div class="col-md-12">
    <table class="table table-hover table-striped table-data">
    <thead style="text-align:center">
       <tr>
            <th>Sr#</th>
           <th>Ref-Id</th>
            <th>Probation Type</th>
            <th>Probation From</th>
            <th>Probation To</th>
            <th>Details</th>
            <th>Action</th>
      </tr>
    </thead>
    <tbody>

    <asp:ListView ID="ProbationLV" runat="server"
    
        OnItemCreated="Probation_ItemCreated" 
    OnItemInserting="Probation_ItemInserting"
    OnItemEditing="Probation_ItemEditing"
    OnItemDataBound="Probation_ItemDataBound"
     OnItemDeleting="Probation_ItemDeleting"
     OnItemCanceling="Probation_ItemCanceling"
     OnItemUpdating="Probation_ItemUpdating">

     
    <ItemTemplate>
    <tr>
                        <td class="itemCent">
                            <asp:HiddenField ID="HidProbationId" runat="server" Value='<%#Bind("ProbationId") %>' />
                            <asp:Label ID="Label3" runat="server" class="table-data" Text='<%#Container.DataItemIndex + 1%> ' />
                        </td>
                          <td>                    
                        <asp:Label ID="Label11" class="table-data" runat="server" Text='<%#Eval("PromotionId") %>' />
                        </td>
                        <td>                    
                        <asp:Label ID="Label4" class="table-data" runat="server" Text='<%#Eval("ProbationType")%>' />
                        </td>
                        <td>                    
                        <asp:Label ID="Label2" class="table-data" runat="server" Text='<%#GetDate(Convert.ToDateTime(Eval("ProbationFrom")))%>' />
                        </td>
                         <td>
                           <asp:Label ID="DateLabel" class="table-data" runat="server" Text='<%#GetDate(Convert.ToDateTime(Eval("ProbationTo")))%>' />
                        </td>
                         <td>
                           <asp:Label ID="Label8" class="table-data" runat="server" Text='<%#Bind("Remarks")%>' />
                        </td>
                       
                        
                         <td>
                                <asp:LinkButton ID="editImageButton" class="btn btn-custom" runat="server"  CommandName="edit"
                                 ToolTip="Edit"><span class="glyphicon glyphicon-pencil"></span></asp:LinkButton>
                                <asp:LinkButton ID="deleteImageButton" class="btn btn-custom" runat="server"  CommandName="delete"
                                 ToolTip="Delete" OnClientClick="return confirm('Are you sure you want to delete therecord ?');"><span class="glyphicon glyphicon-erase"></span></asp:LinkButton>
                        </td>

    </tr>
       </ItemTemplate>
   
 
    <InsertItemTemplate>
            <tr>
                <td colspan="7">
                <asp:HiddenField ID="HidPromotionId" runat="server" Value='<%#Bind("PromotionId") %>' />
                <table class="table table-condensed table-data">
                <tr>
                    <td class="table-data">Probation Type</td>
                    <td>
                        <asp:DropDownList ID="ProbationTypeDDL" class="form-control" runat="server"> </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">Reference Id</td>
                    <td>
                        <asp:TextBox ID="ReferenceIdTxt" class="form-control" runat="server" Text='' />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" Display="Dynamic" Text="*" runat="server" ErrorMessage="Reference Id" ControlToValidate="ReferenceIdTxt" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">Probation From</td>
                    <td>
                        <asp:TextBox ID="ProbationFromTxt" class="form-control js-date" runat="server" Text='' />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" Display="Dynamic" Text="*" runat="server" ErrorMessage="Probation From" ControlToValidate="ProbationFromTxt" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">Probation To</td>
                    <td>
                        <asp:TextBox ID="ProbationToTxt" class="form-control js-date" runat="server" Text='' />
                        <asp:CustomValidator ID="DateRangeVal" runat="server" ControlToValidate="ProbationToTxt" ClientValidationFunction="HrmDateRange" Display="Dynamic" ValidationGroup="Group1" Text="To Date cannot be earlier than From Date." ErrorMessage="To Date cannot be earlier than From Date."></asp:CustomValidator>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" Display="Dynamic" Text="*" runat="server" ErrorMessage="Probation To" ControlToValidate="ProbationToTxt" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
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
        <EditItemTemplate>
            <tr>
                <td colspan="7">
                <asp:HiddenField ID="HidPromotionId" runat="server" Value='<%#Bind("PromotionId") %>' />
                <asp:HiddenField ID="HidProbationId" runat="server" Value='<%#Bind("ProbationId") %>' />
                <asp:HiddenField ID="HidProbationTypeId" runat="server" Value='<%#Bind("ProbationTypeId") %>' />
                <table class="table table-condensed table-data">
                <tr>
                    <td class="table-data">Probation Type</td>
                    <td>
                        <asp:DropDownList ID="ProbationTypeDDL" class="form-control"  runat="server">
                                    <asp:ListItem Value="2">Promotion</asp:ListItem>
                                     <asp:ListItem Value="3">Extended</asp:ListItem>
                                </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">Reference Id</td>
                    <td>
                        <asp:TextBox ID="ReferenceIdTxt" class="form-control" runat="server" Text='<%#Bind("PromotionId") %>' />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" Display="Dynamic" Text="*" runat="server" ErrorMessage="Reference Id" ControlToValidate="ReferenceIdTxt" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">Probation From</td>
                    <td>
                        <asp:TextBox ID="ProbationFromTxt" class="form-control js-date" runat="server" Text='<%#GetDate(Convert.ToDateTime(Eval("ProbationFrom")))%>' />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" Display="Dynamic" Text="*" runat="server" ErrorMessage="Appointment Date" ControlToValidate="ProbationFromTxt" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">Probation To</td>
                    <td>
                        <asp:TextBox ID="ProbationToTxt" class="form-control js-date" runat="server" Text='<%#GetDate(Convert.ToDateTime(Eval("ProbationTo")))%>' />
                        <asp:CustomValidator ID="DateRangeVal" runat="server" ControlToValidate="ProbationToTxt" ClientValidationFunction="HrmDateRange" Display="Dynamic" ValidationGroup="Group1" Text="To Date cannot be earlier than From Date." ErrorMessage="To Date cannot be earlier than From Date."></asp:CustomValidator>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" Display="Dynamic" Text="*" runat="server" ErrorMessage="Appointment Date" ControlToValidate="ProbationToTxt" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
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
    <EmptyDataTemplate>
             <tr>
                     <td>
                         <b>No probation details found.</b>                            

                    </td>
             </tr>
        </EmptyDataTemplate>
    </asp:ListView>                   

   
    <tr>
    <td colspan="7">
    <asp:ValidationSummary ID="ValidationSummary1"
        HeaderText="You must enter a value in the following fields:"
        DisplayMode="BulletList"
        EnableClientScript="true"
        ShowSummary="true"
        runat="server" ValidationGroup="Group2" ForeColor="#FF3300" />
      </td>
    </tr>
</tbody>          
 </table> 
   </div>
    </div>

</asp:Content>
