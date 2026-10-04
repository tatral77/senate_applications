<%@ Page Title="" Language="C#" MasterPageFile="~/EmployeeInformation.master" MaintainScrollPositionOnPostback="true" AutoEventWireup="true" CodeBehind="PersonalInformation.aspx.cs" Inherits="EstablishmentASP.test" %>

<asp:Content ID="Content2" ContentPlaceHolderID="EmpMenues" runat="server">

<div class="nf-head"><h4>PERSONAL DETAILS</h4></div>
    <div class="container-flued">
        <div class="row">
            <div class="col-md-12">

                  <div class="pi-card">
            <h5>Basic Information</h5>
            <div class="pi-grid">
            <div class="pi-f"><label>Is Active</label>
                <asp:DropDownList ID="ActiveDDL" class="form-control" runat="server">
                <asp:ListItem Value="1">Yes</asp:ListItem>
                 <asp:ListItem Value="0">No</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="pi-f"><label>Title</label>
                <asp:TextBox ID="title" runat="server" class="form-control control-txt"></asp:TextBox>
            </div>
            <div class="pi-f"><label>Name</label>
                <asp:TextBox ID="EmpNametxt" runat="server" class="form-control control-txt" required="true"></asp:TextBox>
                <asp:RequiredFieldValidator ControlToValidate="EmpNametxt" ValidationGroup="Group1" ID="RequiredFieldValidator1" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
            </div>
            <div class="pi-f"><label>Previous Name</label>
                <asp:TextBox ID="PreviousNameTxt" runat="server" class="form-control control-txt"></asp:TextBox>
            </div>
            <div class="pi-f"><label>Name Change Date</label>
                <asp:TextBox ID="NameChangeDateTxt" runat="server" class="form-control control-txt js-date"></asp:TextBox>
            </div>
            <div class="pi-f"><label>Father/Husband Name</label>
                <asp:TextBox ID="FatherNametxt" ValidationGroup="Group1" class="form-control control-txt" runat="server"></asp:TextBox>
            </div>
            <div class="pi-f"><label>Gender</label>
                <asp:DropDownList ID="Gender" class="form-control control-txt" runat="server" ValidationGroup="Group1">
                <asp:ListItem Value="0">Select</asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidaor4" Text="*" runat="server" ErrorMessage="Select Gender" ControlToValidate="Gender" InitialValue="0" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
            </div>
            <div class="pi-f"><label>Date of Birth</label>
                <asp:TextBox ID="DOB" runat="server" class="form-control control-txt js-date" ValidationGroup="Group1" required="true"></asp:TextBox>
            </div>
            <div class="pi-f"><label>Place of Birth</label>
                <asp:DropDownList ID="BirthPlace" class="form-control control-txt" runat="server">
                <asp:ListItem Value="0" Selected="True">Select</asp:ListItem>
                </asp:DropDownList>
            </div>
            </div>
        </div>
        <div class="pi-card">
            <h5>Identity and Tax</h5>
            <div class="pi-grid">
            <div class="pi-f"><label>CNIC No</label>
                <asp:TextBox ID="CNIC" runat="server" class="form-control control-txt"></asp:TextBox>
            </div>
            <div class="pi-f"><label>CNIC Issue Date</label>
                <asp:TextBox ID="CNICDate" class="form-control control-txt js-date" ValidationGroup="Group1" runat="server"></asp:TextBox>
            </div>
            <div class="pi-f"><label>CNIC Exp Date</label>
                <asp:TextBox ID="CNICExpDateTxt" class="form-control control-txt js-date" ValidationGroup="Group1" runat="server"></asp:TextBox>
            </div>
            <div class="pi-f"><label>Place of Issue</label>
                <asp:DropDownList ID="CNICIssuePlace" class="form-control control-txt" runat="server">
                <asp:ListItem Value="0"  Selected="True">Select</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="pi-f"><label>NTN</label>
                <asp:TextBox ID="NTN" class="form-control control-txt" runat="server"></asp:TextBox>
            </div>
            </div>
        </div>
        <div class="pi-card">
            <h5>Personal</h5>
            <div class="pi-grid">
            <div class="pi-f"><label>Religion</label>
                <asp:DropDownList ID="Religion" class="form-control control-txt" runat="server">
                <asp:ListItem Selected="True" Value="0">Select</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="pi-f"><label>Marital Status</label>
                <asp:DropDownList ID="MaritalStatus" class="form-control control-txt" runat="server">
                <asp:ListItem Selected="True" Value="0">Select</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="pi-f"><label>Province</label>
                <asp:DropDownList ID="PermProvince" class="form-control control-txt" runat="server" OnSelectedIndexChanged="Fill_Districts" AutoPostBack="True">
                <asp:ListItem Selected="True" Value="0">Select</asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" Text="*" runat="server" ErrorMessage="Province" ControlToValidate="PermProvince" InitialValue="0" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
            </div>
            <div class="pi-f"><label>Domicile</label>
                <asp:DropDownList ID="DomDistrict" class="form-control control-txt" runat="server" AutoPostBack="True">
                <asp:ListItem Selected="True" Value="0">Select</asp:ListItem>
                </asp:DropDownList>
            </div>
            </div>
        </div>
        <div class="pi-card">
            <h5>Addresses</h5>
            <div class="pi-grid">
            <div class="pi-f wide"><label>Permanent Address</label>
                <asp:TextBox ID="PermAddress" class="form-control control-txt" runat="server" Rows="3" 
               TextMode="MultiLine"></asp:TextBox>
            </div>
            <div class="pi-f"><label>Permanent City</label>
                <asp:DropDownList ID="PermCity" class="form-control control-txt" runat="server">
                <asp:ListItem Value="0" Selected="True">Select</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="pi-f wide"><label>Local Address</label>
                <asp:TextBox ID="LocalAddress" class="form-control control-txt" runat="server" Rows="3" 
               TextMode="MultiLine"></asp:TextBox>
            </div>
            <div class="pi-f"><label>Local City</label>
                <asp:DropDownList ID="LocalCity" class="form-control control-txt" runat="server" >
           <asp:ListItem Selected="True" Value="0">Select</asp:ListItem>
           </asp:DropDownList>
            </div>
            </div>
        </div>

                <%--  <div class="row top-buffer">
            <div class="col-md-3">
                <label class="control-lbl-sm"="control-label" for="Gender">Email:</label>
            </div>
            <div class="col-md-6">
                <asp:TextBox ID="EmailTxt" class="form-control control-txt" type="email" runat="server" style="Width:300px"></asp:TextBox>
                <asp:RegularExpressionValidator Display="Dynamic" ID="regexEmailValid" runat="server" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="EmailTxt" ErrorMessage="Invalid Email Format"></asp:RegularExpressionValidator>
             </div>
       </div>--%>
      
       <div class="pi-card">
            <div class="pi-head"><h5>Contact Numbers</h5><asp:Button ID="LinkButton1" class="btn btn-custom" runat="server" Text="Add Contact" CommandName="new" onclick="newLinkButton_Click" /></div>
            <table class="table table-hover">
    <tr>
    <th>Sr#</th>
    <th>Phone Type</th>
     <th>Phone Number</th>
     <th>Action</th>
    </tr>
    <asp:ListView ID="EmpPhones" 
    OnItemEditing="Phones_ItemEditing" 
    OnItemDataBound="OnItemDataBound" 
    OnItemCanceling="EmpPhones_ItemCanceling" 
    OnItemUpdating="EmpPhones_ItemUpdating" 
    OnItemDeleting="EmpPhones_ItemDeleting" 
    OnItemInserting="EmpPhones_ItemInserting" 
    runat="server">
    <ItemTemplate>
    <tr>
                        <td class="table-data">
                            <asp:HiddenField ID="HidEmpPhoneId" runat="server" Value='<%#Bind("EmpPhoneId")%>' />
                            <asp:HiddenField ID="HidPhoneTypeId" runat="server" Value='<%#Bind("PhoneTypeId")%>' />
                            <asp:Label ID="Label3" runat="server" style="font-family: Verdana;font-weight: lighter;" Text='<%#Container.DataItemIndex + 1%> ' />
                        </td>
                        <td class="table-data">
                            <asp:Label ID="Label4" style="font-family: Verdana;font-weight: lighter;" runat="server" Text='<%#Bind("PhoneType")%>' />
                        </td>
                        <td class="table-data">
                           <asp:Label ID="nameLabel" style="font-family: Verdana;font-weight: lighter;" runat="server" Text='<%#Bind("PhoneNumber")%>' />
                        </td>
                         <td style="text-align:right">
                                <asp:LinkButton ID="editImageButton" class="btn btn-custom" runat="server"  CommandName="edit"
                                 ToolTip="Edit"><span class="glyphicon glyphicon-pencil"></span></asp:LinkButton>
                                <asp:LinkButton ID="deleteImageButton" class="btn btn-custom" runat="server"  CommandName="delete"
                                 ToolTip="Delete" OnClientClick="return confirm('Are you sure you want to delete therecord ?');"><span class="glyphicon glyphicon-erase"></span></asp:LinkButton>
                        </td>
      </tr>
    </ItemTemplate>
    <EditItemTemplate>
    <tr>
                        <td class="table-data">
                            <asp:HiddenField ID="HidEmpPhoneId" runat="server" Value='<%#Bind("EmpPhoneId")%>' />
                            <asp:HiddenField ID="HidPhoneTypeId" runat="server" Value='<%#Bind("PhoneTypeId")%>' />
                            <asp:Label ID="Label3" style="font-family: Verdana;font-weight: lighter;" runat="server" Text='<%#Container.DataItemIndex + 1%> ' />
                        </td>
                        <td class="table-data">
                            
                            <asp:DropDownList ID="PhoneTypesDDL" runat="server" class="form-control">
                            <asp:ListItem  Value="0">Select</asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" Display="Dynamic" Text="*" runat="server" ErrorMessage="Phone Type" ControlToValidate="PhoneTypesDDL" InitialValue="0" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                        </td>
                        <td class="table-data">
                            
                            <asp:TextBox ID="PhoneNumberTxt" runat="server" class="form-control" Text='<%#Bind("PhoneNumber")%>'></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" Display="Dynamic" Text="*" runat="server" ErrorMessage="Phone Number" ControlToValidate="PhoneNumberTxt" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                           
                         </td>
                       <td style="text-align:right">
                            <asp:LinkButton ID="cancelImageButton" class="btn btn-custom" runat="server"  CommandName="cancel"
                             ToolTip="Cancel"><span class="glyphicon glyphicon-arrow-left"></span></asp:LinkButton>
                            <asp:LinkButton class="btn btn-custom" ID="saveImageButton" runat="server"  CommandName="update"
                             ToolTip="Save" ValidationGroup="Group1"><span class="glyphicon glyphicon-floppy-disk"></span></asp:LinkButton>
                            
                    </td>
   </tr>
    
    </EditItemTemplate>
    <InsertItemTemplate>
     <tr>
                        <td class="table-data">
                            <asp:Label ID="Label3" style="font-family: Verdana;font-weight: lighter;" runat="server" Text='<%#Container.DataItemIndex + 1%> ' />
                        </td>
                        <td class="table-data">
                            
                            <asp:DropDownList ID="PhoneTypesDDL" class="form-control" runat="server" ValidationGroup="Group1">
                            <asp:ListItem Selected="True" Value="0">Select</asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" Display="Dynamic"  Text="Phone type required" runat="server" ErrorMessage="Phone Type" ControlToValidate="PhoneTypesDDL" InitialValue="0" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                        </td>
                        <td class="table-data">
                            
                            <asp:TextBox ID="PhoneNumberTxt" class="form-control" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" Display="Dynamic" Text="Phone Number required" runat="server" ErrorMessage="Phone Number required" ControlToValidate="PhoneNumberTxt" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                           
                         </td>
                         <td style="text-align:right">
                          <asp:LinkButton ID="cancelImageButton" class="btn btn-custom" runat="server"  CommandName="cancel"
                             ToolTip="Cancel"><span class="glyphicon glyphicon-arrow-left"></span></asp:LinkButton>
                            <asp:LinkButton class="btn btn-custom" ID="saveImageButton" runat="server"  CommandName="insert"
                             ToolTip="Insert" ValidationGroup="Group1"><span class="glyphicon glyphicon-floppy-disk"></span></asp:LinkButton>
                            

</td>
   </tr>
    
    
    
    </InsertItemTemplate>
    <EmptyDataTemplate>
    <tr>
    <td colspan="4" class="table-data" >No Data Found</td>
    </tr>
    </EmptyDataTemplate>
    </asp:ListView>
   
    </table>
        </div>


                  <div class="pi-card">
            <div class="pi-head"><h5>Email Addresses</h5><asp:Button ID="NewEmailBtn" class="btn btn-custom" runat="server" Text="Add Email" CommandName="new" onclick="NewEmailBtn_Click" /></div>
            <table class="table table-hover">
    <tr>
    <th>Sr#</th>
    <th>Email</th>
     <th>Is Official</th>
     <th>Action</th>
     
    </tr>
    
    <asp:ListView ID="EmailLV" 
    OnItemEditing="Email_ItemEditing" 
    OnItemDataBound="OnEmailItemDataBound" 
    OnItemCanceling="Email_ItemCanceling" 
    OnItemUpdating="Email_ItemUpdating" 
    OnItemDeleting="Email_ItemDeleting" 
    OnItemInserting="Email_ItemInserting" 
    
    
    runat="server">
    <ItemTemplate>
    <tr>
                        <td class="table-data">
                            <asp:HiddenField ID="HidUserEmailId" runat="server" Value='<%#Bind("UserEmailId")%>' />
                            <asp:Label ID="Label3" runat="server" style="font-family: Verdana;font-weight: lighter;" Text='<%#Container.DataItemIndex + 1%> ' />
                        </td>
                        <td class="table-data">
                            <asp:Label ID="Label4" style="font-family: Verdana;font-weight: lighter;" runat="server" Text='<%#Bind("Email")%>' />
                        </td>
                        <td class="table-data">
                           <asp:Label ID="nameLabel" style="font-family: Verdana;font-weight: lighter;" runat="server" Text='<%#(Convert.ToString(Eval("IsOfficial"))=="1")?"Yes":"No"%>' />
                        </td>
                         <td style="text-align:right">
                                <asp:LinkButton ID="editImageButton" class="btn btn-custom" runat="server"  CommandName="edit"
                                 ToolTip="Edit"><span class="glyphicon glyphicon-pencil"></span></asp:LinkButton>
                                <asp:LinkButton ID="deleteImageButton" class="btn btn-custom" runat="server"  CommandName="delete"
                                 ToolTip="Delete" OnClientClick="return confirm('Are you sure you want to delete therecord ?');"><span class="glyphicon glyphicon-erase"></span></asp:LinkButton>
                        </td>
                        
      </tr>
    </ItemTemplate>
  
    <EditItemTemplate>
    <tr>
                        <td class="table-data">
                            <asp:HiddenField ID="HidUserEmailId" runat="server" Value='<%#Bind("UserEmailId")%>' />
                            <asp:HiddenField ID="HidIsOfficial" runat="server" Value='<%#Bind("IsOfficial")%>' />
                             <asp:Label ID="Label3" style="font-family: Verdana;font-weight: lighter;" runat="server" Text='<%#Container.DataItemIndex + 1%> ' />
                        </td>
                        
                        <td class="table-data">
                            
                            <asp:TextBox ID="EmailTxt" runat="server" class="form-control" Text='<%#Bind("Email")%>'></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" Display="Dynamic" Text="*" runat="server" ErrorMessage="Email" ControlToValidate="EmailTxt" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                           
                         </td>
                         <td class="table-data">                            
                           <asp:CheckBox class="form-control" ID="IsOfficial" runat="server" />                           
                         </td>


                       <td style="text-align:right">
                            <asp:LinkButton ID="cancelImageButton" class="btn btn-custom" runat="server"  CommandName="cancel"
                             ToolTip="Cancel"><span class="glyphicon glyphicon-arrow-left"></span></asp:LinkButton>
                            <asp:LinkButton class="btn btn-custom" ID="saveImageButton" runat="server"  CommandName="update"
                             ToolTip="Save" ValidationGroup="Group1"><span class="glyphicon glyphicon-floppy-disk"></span></asp:LinkButton>
                            
                    </td>
   </tr>
    
    </EditItemTemplate>
    <InsertItemTemplate>
     <tr>
                        <td class="table-data">
                            <asp:Label ID="Label3" style="font-family: Verdana;font-weight: lighter;" runat="server" Text='<%#Container.DataItemIndex + 1%> ' />
                        </td>
                         <td class="table-data">
                            
                            <asp:TextBox ID="EmailTxt" runat="server" class="form-control" Text=''></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" Display="Dynamic" Text="*" runat="server" ErrorMessage="Email" ControlToValidate="EmailTxt" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                           
                         </td>
                         <td class="table-data">                            
                           <asp:CheckBox class="form-control" ID="IsOfficial" runat="server" />                           
                         </td>
                         <td style="text-align:right">
                          <asp:LinkButton ID="cancelImageButton" class="btn btn-custom" runat="server"  CommandName="cancel"
                             ToolTip="Cancel"><span class="glyphicon glyphicon-arrow-left"></span></asp:LinkButton>
                            <asp:LinkButton class="btn btn-custom" ID="saveImageButton" runat="server"  CommandName="insert"
                             ToolTip="Insert" ValidationGroup="Group1"><span class="glyphicon glyphicon-floppy-disk"></span></asp:LinkButton>
                            

</td>
   </tr>
    
    
    
    </InsertItemTemplate>
    <EmptyDataTemplate>
    <tr>
    <td colspan="4" class="table-data" >No Data Found</td>
    </tr>
    </EmptyDataTemplate>
    </asp:ListView>
   
    </table>
        </div>


     <div class="pi-actions">
            <asp:Button ID="Savebtn" class="btn btn-custom" runat="server" Text="Save" ValidationGroup="Group1" onclick="Savebtn_Click" />
       <asp:Button ID="DeleteBtn" OnClientClick="return confirm('Click OK to delete the record permanently ?');" class="btn btn-danger" runat="server" Text="Delete"  onclick="DeleteBtn_Click" />
      
           <asp:Label ID="err" CssClass="nf-err" runat="server" Text="" />
        </div>
      
    
      
     
</div> 

<%--<div class="col-md-2 col-sm-2">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                 <ContentTemplate>
       
                    <asp:ImageButton ID="ImageButton1" runat="server" AlternateText="Click to Add Image"  class="img-rounded" AutoPostBack="False" Style="width:150px;height:200px" data-toggle="modal" data-target="#myModal"/>
            
        </ContentTemplate>
        </asp:UpdatePanel>

        <div id="myModal" class="modal fade in"" role="dialog">
                    <div class="modal-dialog modal-sm">
                        <!-- Modal content-->
                      
                        <div class="modal-content">
                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal">&times;</button>
                                <h4 class="modal-title">Add Image</h4>
                            </div>
                            <div class="modal-body">
                             </div>

        <div class="modal-footer">
            <asp:FileUpload ID="FileUpload1" runat="server" />
             <asp:Button ID="SaveImage" runat="server" type="button" Text="Save" class="btn btn-default" Ondata-dismiss="modal" OnClick="SaveImage_Click" ></asp:Button>
            <asp:Button class="btn btn-custom" ID="Button3" runat="server" Text="Reset" />
      </div>
                         </div>
 </div>
        
 </div>
</div>--%>
            </div>
</div>
</asp:Content>
