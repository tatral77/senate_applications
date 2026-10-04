<%@ Page Title="" Language="C#" MasterPageFile="~/EmployeeInformation.master" AutoEventWireup="true" CodeBehind="EmpCourses.aspx.cs" Inherits="EstablishmentASP.EmpCources" %>
<asp:Content ID="Content1" ContentPlaceHolderID="EmpMenues" runat="server">
   
 <div class="container-fluid regularDiv">
        <div class="sec-head">
        <h5>COURSES/ TRAININGS</h5>
        <div class="nf-toolbar">
            <asp:Button ID="LinkButton1" runat="server" CommandName="new" Text="Add New" class="btn btn-custom" onclick="newLinkButton_Click" />
                 <asp:Button class="btn btn-custom" ID="PrintBtn" runat="server" Text="Print" OnClientClick = "return PrintPanel();"/>
<input type="button" class="btn btn-custom" value="Export PDF" onclick="return ExportPdf();" />
        </div>
    </div>
         
 <asp:Panel ID="pnlContents" runat="server">        
    <div class="row">
        <div class="col-md-12">

    <div class="page-header unhid" id="LeaveHeaderDiv" runat="server" style="display:none"><h4>
      <asp:Label ID="LeaveHeader" runat="server"  Text=""></asp:Label>
    </h4></div>

<table class="table table-striprd table-condensed table-responsive table-data">
<thead>
<tr>
<th>Sr#</th>
<th>Course Name</th>
<th>Course Type</th>
<th>Mandatory</th>
<th>Deg/Dip/Cert</th>
<th>Institution</th>
<th>Country</th>
<%--<th>City</th>--%>
<th>From</th>
<th>To</th>
<th>Sponsored By</th>
<th>Details</th>
<th>Actions</th>

</tr>
</thead>
<tbody>
<asp:ListView ID="EmpCoursesLv" runat="server"
OnItemEditing="ItemEditing"
OnItemCanceling="ItemCanceling"
 OnItemDataBound="ItemDataBound"
 OnItemUpdating="ItemUpdating"
 OnItemCreated="ItemCreated"
 OnItemInserting="ItemInserting"
 OnItemDeleting="ItemDeleting"
 >
<ItemTemplate>
<tr>
    
     <td class="itemLeft"><asp:HiddenField ID="HidEmpCourseId" runat="server" Value='<%#Bind("EmpCourseId")%>' />
     <asp:Label ID="SrNo" runat="server" Text='<%#Container.DataItemIndex + 1%> '></asp:Label></td>
    <td class="itemLeft"><asp:Label ID="PassportNumber" class="table-data" runat="server" Text='<%#Bind("CourseName")%>'></asp:Label></td>
    <td class="itemLeft"><asp:Label ID="Label5" class="table-data" runat="server" Text='<%#GetCourseType(Convert.ToInt32(Eval("CourseTypeId")))%>'></asp:Label></td>
     <td><asp:Label ID="Label1" CssClass="table-data" runat="server" Text='<%#(Convert.ToString(Eval("Mandatory"))=="1")?"Yes":"No"%>' /></td>
    <td class="itemLeft"><asp:Label ID="Label6"  class="table-data" runat="server" Text='<%#Bind("DegDipCert")%>'></asp:Label></td>
    <td class="itemLeft"><asp:Label ID="IssuePlace" class="table-data" runat="server" Text='<%#Bind("InstitutionName") %>'></asp:Label></td>
    <td class="itemLeft"><asp:Label ID="Label2" class="table-data" runat="server" Text='<%# GetCountry(Convert.ToInt32(Eval("CountryId")))%>'></asp:Label></td>
    <%--<td class="itemLeft"><asp:Label ID="Label9" runat="server" Text='<%# GetCity(Convert.ToInt32(Eval("CityId")))%>'></asp:Label></td>--%>
    <td class="itemLeft"><asp:Label ID="Label7" class="table-data" runat="server" Text='<%#Bind("FromDate","{0:dd/MM/yyyy}")%>'></asp:Label></td>
    <td class="itemLeft"><asp:Label ID="Label8" class="table-data" runat="server" Text='<%#Bind("ToDate","{0:dd/MM/yyyy}")%>'></asp:Label></td>
    <td class="itemLeft"><asp:Label ID="Label4" class="table-data" runat="server" Text='<%#Bind("SponsoredBy")%>'></asp:Label></td>
    <td class="itemLeft"><asp:Label ID="Label3" class="table-data" runat="server" Text='<%#Bind("Remarks")%>'></asp:Label></td>
    <td>
                               <asp:LinkButton ID="editImageButton" class="btn btn-custom" runat="server" AlternateText="edit" CommandName="edit"
                                ImageUrl="~/images/edit.png" ToolTip="Edit"><span class="glyphicon glyphicon-pencil"></span></asp:LinkButton>
                                <asp:LinkButton ID="deleteImageButton" class="btn btn-custom" runat="server" AlternateText="delete" CommandName="delete"
                                ImageUrl="~/images/delete.png" ToolTip="Delete" OnClientClick="return confirm('Are you sure you want to delete the record');"><span class="glyphicon glyphicon-erase"></span></asp:LinkButton>
                        </td>
  </tr>

</ItemTemplate>
<EditItemTemplate>
            <tr>
                <td colspan="12">
                <asp:HiddenField ID="HidEmpCourseId" runat="server" Value='<%#Bind("EmpCourseId")%>' />
                <asp:HiddenField ID="HidCourseTypeId" runat="server" Value='<%#Bind("CourseTypeId")%>' />
                <asp:HiddenField ID="HidCourseCountryId" runat="server" Value='<%#Bind("CountryId")%>' />
                <asp:HiddenField ID="HidMandatory" runat="server" Value='<%#Bind("Mandatory") %>' />
                <table class="table table-condensed table-data">
                <tr>
                    <td class="table-data">Course Name</td>
                    <td>
                        <asp:TextBox ID="CourseNameTxt" class="form-control" runat="server" Text='<%#Bind("CourseName")%>' ></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" Display="Dynamic" Text="*" runat="server" ErrorMessage="Course Name" ControlToValidate="CourseNameTxt" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">Course Type</td>
                    <td>
                        <asp:DropDownList ID="CourseTypeDDL" class="form-control" runat="server" AutoPostBack="False" ></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" Display="Dynamic" Text="*" runat="server" ErrorMessage="Course Type" ControlToValidate="CourseTypeDDL" InitialValue="0" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">Mandatory</td>
                    <td>
                        <asp:CheckBox CssClass="form-control" ID="MandatoryCB" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td class="table-data">Deg/Dip/Cert</td>
                    <td>
                        <asp:TextBox ID="DegDipCertTxt" class="form-control" runat="server" Text='<%#Bind("DegDipCert")%>' ></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" Display="Dynamic" Text="*" runat="server" ErrorMessage="Deg/Dep/Cert" ControlToValidate="DegDipCertTxt" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">Institution Name</td>
                    <td>
                        <asp:TextBox ID="InstitutionNameTxt" class="form-control" runat="server" Text='<%#Bind("InstitutionName")%>' ></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" Display="Dynamic" Text="*" runat="server" ErrorMessage="Institution Name" ControlToValidate="InstitutionNameTxt" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">Country</td>
                    <td>
                        <asp:DropDownList ID="CourseCountryDDL" class="form-control" runat="server" AutoPostBack="False"><asp:ListItem Selected="True" Value="0">Select</asp:ListItem></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" Display="Dynamic" Text="*" runat="server" ErrorMessage="Country" ControlToValidate="CourseCountryDDL" InitialValue="0" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">From</td>
                    <td>
                        <asp:TextBox ID="FromDateTxt" class="form-control js-date" runat="server" Text='<%#Bind("FromDate","{0:dd/MM/yyyy}")%>' ></asp:TextBox>
                        <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator6" Text="*" runat="server" ErrorMessage="From Date" ControlToValidate="FromDateTxt" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="CompareValidator3" ValidationGroup="Group1" ControlToValidate="FromDateTxt" runat="server" ErrorMessage="Not a valid Date" Type="Date" Operator="DataTypeCheck" ForeColor="#FF3300"></asp:CompareValidator>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">To</td>
                    <td>
                        <asp:TextBox ID="ToDateTxt" class="form-control js-date" runat="server" Text='<%#Bind("ToDate","{0:dd/MM/yyyy}")%>' ></asp:TextBox>
                        <asp:CustomValidator ID="DateRangeVal" runat="server" ControlToValidate="ToDateTxt" ClientValidationFunction="HrmDateRange" Display="Dynamic" ValidationGroup="Group1" Text="To Date cannot be earlier than From Date." ErrorMessage="To Date cannot be earlier than From Date."></asp:CustomValidator>
                        <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator5" Text="*" runat="server" ErrorMessage="To Date" ControlToValidate="ToDateTxt" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="CompareValidator2" ValidationGroup="Group1" ControlToValidate="ToDateTxt" runat="server" ErrorMessage="Not a valid Date" Type="Date" Operator="DataTypeCheck" ForeColor="#FF3300"></asp:CompareValidator>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">Sponsored By</td>
                    <td>
                        <asp:TextBox ID="SponsoredByTxt" class="form-control" runat="server" Text='<%#Bind("SponsoredBy")%>' ></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">Details</td>
                    <td>
                        <asp:TextBox ID="RemarksTxt" TextMode="MultiLine" class="form-control" runat="server" Text='<%#Bind("Remarks")%>' ></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:LinkButton ID="cancelImageButton" class="btn btn-custom" runat="server" AlternateText="cancel" CommandName="cancel" ImageUrl="~/images/cancel.png" ToolTip="Cancel"><span class="glyphicon glyphicon-arrow-left"></span></asp:LinkButton>
                        <asp:LinkButton class="btn btn-custom" ID="saveImageButton" runat="server" AlternateText="update" CommandName="update" ImageUrl="~/images/save.png" ToolTip="Save" ValidationGroup="Group1"><span class="glyphicon glyphicon-floppy-disk"></span></asp:LinkButton>
                    </td>
                </tr>
                </table>
                </td>
            </tr>
        </EditItemTemplate>
<InsertItemTemplate>
            <tr>
                <td colspan="12">
                <table class="table table-condensed table-data">
                <tr>
                    <td class="table-data">Course Name</td>
                    <td>
                        <asp:TextBox ID="CourseNameTxt" class="form-control" runat="server" Text=''></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" Display="Dynamic" Text="*" runat="server" ErrorMessage="Course Name" ControlToValidate="CourseNameTxt" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">Course Type</td>
                    <td>
                        <asp:DropDownList ID="CourseTypeDDL" class="form-control" runat="server" AutoPostBack="False" ></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" Text="*" Display="Dynamic" runat="server" ErrorMessage="Course Type" ControlToValidate="CourseTypeDDL" InitialValue="0" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">Mandatory</td>
                    <td>
                        <asp:CheckBox CssClass="form-control" ID="MandatoryCB" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td class="table-data">Deg/Dip/Cert</td>
                    <td>
                        <asp:TextBox ID="DegDipCertTxt" class="form-control" runat="server" Text=''></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" Text="*" Display="Dynamic" runat="server" ErrorMessage="Deg/Dep/Cert" ControlToValidate="DegDipCertTxt" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">Institution Name</td>
                    <td>
                        <asp:TextBox ID="InstitutionNameTxt" class="form-control" runat="server" Text=''></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" Text="*" Display="Dynamic" runat="server" ErrorMessage="Institution Name" ControlToValidate="InstitutionNameTxt" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">Country</td>
                    <td>
                        <asp:DropDownList ID="CourseCountryDDL" class="form-control" runat="server" AutoPostBack="False" ></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" Text="*" Display="Dynamic" runat="server" ErrorMessage="Country" ControlToValidate="CourseCountryDDL" InitialValue="0" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">From</td>
                    <td>
                        <asp:TextBox ID="FromDateTxt" class="form-control js-date" runat="server" Text='' ></asp:TextBox>
                        <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator3" Text="*" runat="server" ErrorMessage="From Date" ControlToValidate="FromDateTxt" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="CompareValidator1" ValidationGroup="Group1" ControlToValidate="FromDateTxt" runat="server" ErrorMessage="Not a valid Date" Type="Date" Operator="DataTypeCheck" ForeColor="#FF3300"></asp:CompareValidator>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">To</td>
                    <td>
                        <asp:TextBox ID="ToDateTxt" class="form-control js-date" runat="server" Text='' ></asp:TextBox>
                        <asp:CustomValidator ID="DateRangeVal" runat="server" ControlToValidate="ToDateTxt" ClientValidationFunction="HrmDateRange" Display="Dynamic" ValidationGroup="Group1" Text="To Date cannot be earlier than From Date." ErrorMessage="To Date cannot be earlier than From Date."></asp:CustomValidator>
                        <asp:RequiredFieldValidator Display="Dynamic" ID="RequiredFieldValidator5" Text="*" runat="server" ErrorMessage="To Date" ControlToValidate="ToDateTxt" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="CompareValidator2" ValidationGroup="Group1" ControlToValidate="ToDateTxt" runat="server" ErrorMessage="Not a valid Date" Type="Date" Operator="DataTypeCheck" ForeColor="#FF3300"></asp:CompareValidator>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">Sponsored By</td>
                    <td>
                        <asp:TextBox ID="SponsoredByTxt" class="form-control" runat="server" Text=''></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">Details</td>
                    <td>
                        <asp:TextBox TextMode="MultiLine" ID="RemarksTxt" class="form-control" runat="server" Text=''></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:LinkButton ID="cancelImageButton" class="btn btn-custom" runat="server" AlternateText="cancel" CommandName="cancel" ImageUrl="~/images/cancel.png" ToolTip="Cancel"><span class="glyphicon glyphicon-arrow-left"></span></asp:LinkButton>
                        <asp:LinkButton class="btn btn-custom" ID="saveImageButton" runat="server" AlternateText="insert" CommandName="insert" ImageUrl="~/images/save.png" ToolTip="Insert" ValidationGroup="Group1"><span class="glyphicon glyphicon-floppy-disk"></span></asp:LinkButton>
                    </td>
                </tr>
                </table>
                </td>
            </tr>
        </InsertItemTemplate>
</asp:ListView>
<tr>

    <td colspan="12">
    <asp:ValidationSummary ID="ValidationSummary1"
        HeaderText="You must enter a value in the following fields:"
        DisplayMode="BulletList"
        EnableClientScript="true"
        ShowSummary="true"
        runat="server" ValidationGroup="Group1" ForeColor="#FF3300" />
      </td>
    </tr>
</tbody>
</table>
</div>
        </div>
      </asp:Panel>
      <script src='<%= ResolveUrl("~/Scripts/hrmprint.js") %>' type="text/javascript"></script>
    <script>

        $(document).ready(function () {
            $('#LeaveHeaderDiv').hide();
        });


        jQuery(document).ready(function () {
           
            jQuery('#search').on('click', function (event) {
                event.preventDefault();
                
            });
        });
      
      
           function PrintPanel() {
               return HRMPrint.print("<%=pnlContents.ClientID %>", { title: "EMPLOYEE TRAININGS" });
           }
           function ExportPdf() {
               return HRMPrint.exportPdf("<%=pnlContents.ClientID %>", { title: "EMPLOYEE TRAININGS" });
           }
      
</script>
    </div>
     
</asp:Content>
