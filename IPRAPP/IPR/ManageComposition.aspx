<%@ Page Title="" Language="C#" MasterPageFile="~/OutgoingVisits.master" AutoEventWireup="true" CodeBehind="ManageComposition.aspx.cs" Inherits="IPR.ManageComposition" %>
<asp:Content ID="Content1" ContentPlaceHolderID="EmpMenues" runat="server">
  <style>
      .custom-success
      {
          background-color:#000;
          color:#fff;
         
      }
       .btn-custom
      {
          background-color:#302c2c;
          color:#fff;
      }
  </style>
     <div class="container container-fluid">
        <div class="row">
            <div class="col-md-9">
                <h4>
                    <label id="heading" runat="server" class="page-header">COMPOSITION</label></h4>
            </div>
            <div class="col-md-2 page-header hideadd">
                <asp:Button ID="LinkButton1" runat="server" CommandName="new" Text="Add New" class="btn btn-custom" OnClick="newLinkButton_Click" />

            </div>
        </div>
        <div class="row">
            <div class="col-md-11">
                <table class="table table-condensed table-striped table-data">
                    <tr>
                        <th>Sr#</th>
                        <th>Name</th>
                        <th>Category</th>
                        <th>Status</th>
                        <th>Is Chairman</th>
                        <th>Status Date</th>
                        <th>Remarks</th>
                        <th class="hideall">Action</th>
                        
                    </tr>
                    <asp:ListView ID="CompositionLV" runat="server"
                        OnItemEditing="ItemEditing"
                        OnItemInserting="ItemInserting"
                        OnItemCanceling="ItemCanceling"
                        OnItemDeleting="ItemDeleting"
                        OnItemUpdating="ItemUpdating"
                        OnItemDataBound="ItemDataBound"
                        OnItemCreated="ItemCreated">
                        <ItemTemplate>
                            <tr>
                                <asp:HiddenField ID="HidCompositionId" runat="server" Value='<%#Bind("CompositionId")%>' />
                                <td class="itemCent">
                                    <asp:Label ID="SrNo" runat="server" Text='<%#Container.DataItemIndex + 1%> '></asp:Label>
                                </td>
                                
                                <td class="itemLeft">
                                    <asp:Label ID="Label1" runat="server" Text='<%#Bind("VisitorName")%>'></asp:Label>
                                </td>
                               
                                <td class="itemLeft">
                                    <asp:Label ID="Label5" runat="server" Text='<%#Bind("CategoryName")%>'></asp:Label>
                                </td>

                                <td class="itemLeft">
                                    <asp:Label ID="Label4" runat="server" Text='<%#Bind("VisitorStatus")%>'></asp:Label>
                                </td>

                                  <td class="itemLeft">
                                      <asp:Label ID="Label2" runat="server" Text='<%#(Convert.ToInt32(Eval("IsChairman"))==1)?"Yes":"No"%>'></asp:Label>
                                </td>
                                
                                <td class="itemLeft">
                                    <asp:Label ID="Label6" runat="server" Text='<%#Convert.ToDateTime(Eval("VisitorStatusDate")).ToShortDateString()%>'></asp:Label>
                                </td>
                                
                                <td class="itemLeft">
                                    <asp:Label ID="Label7" runat="server" Text='<%#Bind("Remarks")%>'></asp:Label>
                                </td>
                                
                                <td class="itemCent hideall">
                                    <asp:LinkButton ID="editImageButton" class="btn btn-custom hideedit" runat="server" CommandName="edit" ToolTip="Edit"><span class="glyphicon glyphicon-pencil"></span></asp:LinkButton>
                                    <asp:LinkButton ID="deleteImageButton" class="btn btn-custom hidedelete" runat="server"  CommandName="delete" ToolTip="Delete" OnClientClick="return confirm('Are you sure you want to delete record ?');"><span class="glyphicon glyphicon-erase"></span></asp:LinkButton>
                                </td>
                            </tr>
                        </ItemTemplate>

                        <EditItemTemplate>
                            <tr>
                                <td colspan="7">
                                    <asp:HiddenField ID="HidCompositionId" runat="server" Value='<%#Bind("CompositionId")%>' ClientIDMode="Static" />
                                    <asp:HiddenField ID="HidVisitorStatusId" runat="server" Value='<%#Bind("VisitorStatusId")%>' ClientIDMode="Static" />
                                    <asp:HiddenField ID="HidCategoryId" runat="server" Value='<%#Bind("CategoryId")%>' ClientIDMode="Static"/>
                                    <asp:HiddenField ID="HidIsEmployee" runat="server" Value='<%#Bind("IsEmployee")%>' ClientIDMode="Static"/>
                                      <asp:HiddenField ID="HidDesignation" runat="server" Value='<%#Bind("Post")%>' ClientIDMode="Static"/>
                                    <table class="table table-condensed table-data">
                                        <tr>
                                            <td class="table-data">
                                                <asp:Label runat="server">Visitor Name</asp:Label></td>
                                            <td>
                                                <asp:HiddenField ID="HidSystemUserId" runat="server" Value='<%#Bind("SystemUserId")%>' />
                                                <asp:TextBox ID="VisitorNameTxt" class="form-control" runat="server" Text='<%#Bind("VisitorName")%>' ClientIDMode="Static"></asp:TextBox>
                                                <asp:RequiredFieldValidator ValidationGroup="g1" ControlToValidate="VisitorNameTxt" Display="Dynamic" CssClass="validationErr" ID="RequiredFieldValidator2" runat="server" ErrorMessage="Enter Name"></asp:RequiredFieldValidator>
                                            </td>

                                        </tr>
                                        <tr>
                                            <td class="table-data">
                                                <asp:Label runat="server">Is Chairman</asp:Label></td>
                                            <td>
                                                <asp:CheckBox ID="IsChairmanCB" class="form-control" Checked='<%#(Convert.ToInt32(Eval("IsChairman"))==1)?true:false%>' runat="server"></asp:CheckBox>
                                            </td>
                                        </tr>
                                           <tr>
                                            <td class="table-data">
                                                <asp:Label runat="server">Visitor Status</asp:Label></td>
                                            <td>
                                                <asp:DropDownList runat="server" ID="VisitorStatusDDL" CssClass="form-control">
                                                   
                                                </asp:DropDownList>
                                            </td>

                                        </tr>
                                         <tr>
                                            <td class="table-data">
                                                <asp:Label runat="server">Status Date</asp:Label></td>
                                            <td>
                                                <asp:TextBox ID="VisitorStatusDateTxt" class="form-control" runat="server" Text='<%#Convert.ToDateTime(Eval("VisitorStatusDate")).ToShortDateString()%>'></asp:TextBox>
                                                <asp:RequiredFieldValidator ValidationGroup="g1" ControlToValidate="VisitorStatusDateTxt" Display="Dynamic" CssClass="validationErr" ID="RequiredFieldValidator3" runat="server" ErrorMessage="Enter Date"></asp:RequiredFieldValidator>
                                            </td>

                                        </tr>
                                         <tr>
                                            <td class="table-data">
                                                <asp:Label runat="server">Remarks</asp:Label></td>
                                            <td>
                                                <asp:TextBox ID="RemarksTxt" class="form-control" runat="server" Text='<%#Bind("Remarks")%>'></asp:TextBox>
                                               
                                            </td>

                                        </tr>

                                        <tr>
                                            <td colspan="3">
                                                <asp:LinkButton ID="cancelImageButton" ValidationGroup="g2" class="btn btn-custom" runat="server" CommandName="cancel"
                                                    ToolTip="Cancel"><span class="glyphicon glyphicon-arrow-left"></span></asp:LinkButton>
                                                <asp:LinkButton class="btn btn-custom" ID="saveImageButton" runat="server" CommandName="update"
                                                    ToolTip="Save" ValidationGroup="g1"><span class="glyphicon glyphicon-floppy-disk"></span></asp:LinkButton>

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
                                            <td class="table-data">
                                                <asp:Label runat="server">Visitor Name</asp:Label></td>
                                            <td>
                                                <asp:HiddenField ID="HidSystemUserId" runat="server" Value='' />
                                                 <asp:HiddenField ID="HidCategoryId" runat="server" Value='' />
                                                <asp:HiddenField ID="HidIsEmployee" runat="server" Value='' />
                                                 <asp:HiddenField ID="HidDesignation" runat="server" Value='' />
                                                <asp:TextBox ID="VisitorNameTxt" class="form-control" runat="server" Text=''></asp:TextBox>
                                                <asp:RequiredFieldValidator ValidationGroup="g1" ControlToValidate="VisitorNameTxt" Display="Dynamic" CssClass="validationErr" ID="RequiredFieldValidator1" runat="server" ErrorMessage="Enter Name"></asp:RequiredFieldValidator>
                                            </td>

                                        </tr>
                                          <tr>
                                            <td class="table-data">
                                                <asp:Label runat="server">Is Chairman</asp:Label></td>
                                            <td>
                                                <asp:CheckBox ID="IsChairmanCB" class="form-control" runat="server"></asp:CheckBox>
                                            </td>
                                        </tr>
                                         <tr>
                                            <td class="table-data">
                                                <asp:Label runat="server">Category</asp:Label></td>
                                            <td>
                                                 <asp:TextBox ID="CategoryTxt" class="form-control" runat="server" Text=''></asp:TextBox>
                                               <%-- <asp:DropDownList runat="server" ID="VisitorTypeDDL" CssClass="form-control">
                                                   
                                                </asp:DropDownList>--%>
                                            </td>

                                        </tr>
                                           <tr>
                                            <td class="table-data">
                                                <asp:Label runat="server">Visitor Status</asp:Label></td>
                                            <td>
                                                <asp:DropDownList runat="server" ID="VisitorStatusDDL" CssClass="form-control">
                                                   
                                                </asp:DropDownList>
                                            </td>

                                        </tr>
                                         <tr>
                                            <td class="table-data">
                                                <asp:Label runat="server">Status Date</asp:Label></td>
                                            <td>
                                                <asp:TextBox ID="VisitorStatusDateTxt" class="form-control" runat="server" Text='<%#DateTime.Now.ToShortDateString() %>'></asp:TextBox>
                                                <asp:RequiredFieldValidator ValidationGroup="g1" ControlToValidate="VisitorStatusDateTxt" Display="Dynamic" CssClass="validationErr" ID="RequiredFieldValidator4" runat="server" ErrorMessage="Enter Date"></asp:RequiredFieldValidator>
                                            </td>

                                        </tr>
                                         <tr>
                                            <td class="table-data">
                                                <asp:Label runat="server">Remarks</asp:Label></td>
                                            <td>
                                                <asp:TextBox ID="RemarksTxt" class="form-control" runat="server" TextMode="MultiLine" Text='<%#Bind("Remarks")%>'></asp:TextBox>
                                               
                                            </td>

                                        </tr>
                                        <tr>
                                            <td colspan="3">
                                                <asp:LinkButton ID="LinkButton2" ValidationGroup="g2" class="btn btn-custom" runat="server" CommandName="cancel"
                                                    ToolTip="Cancel"><span class="glyphicon glyphicon-arrow-left"></span></asp:LinkButton>
                                                <asp:LinkButton class="btn btn-custom" ID="LinkButton3" runat="server" CommandName="insert"
                                                    ToolTip="Save" ValidationGroup="g1"><span class="glyphicon glyphicon-floppy-disk"></span></asp:LinkButton>

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
        </div>
    </div>
     <script type="text/javascript">
        $(function () {
            $("[id$=VisitorNameTxt]").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: '<%=ResolveUrl("~/WebService1.asmx/GetEmployeeByName") %>',
                        //data: "{ 'prefix': '" + request.term + "','type': '" + document.getElementById("ContentPlaceHolder1_EmpMenues_CompositionLV_VisitorTypeDDL").value + "'}",
                        data: "{ 'prefix': '" + request.term + "'}",
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        success: function (data) {
                            response($.map(data.d, function (item) {
                                return {
                                    label: item.split('=')[0],
                                    val: item.split('=')[1],
                                    val2: item.split('=')[2],
                                    val3: item.split('=')[3],
                                    val4: item.split('=')[4]
                                }
                            }))
                        },
                        error: function (response) {
                            alert(response.responseText);
                        },
                        failure: function (response) {
                            alert(response.responseText);
                        }
                    });
                },
                select: function (e, i) {
                    $("[id$=HidSystemUserId]").val(i.item.val);
                    $("[id$=HidCategoryId]").val(i.item.val2);
                    $("[id$=CategoryTxt]").val('Category-' + i.item.val2);
                    $("[id$=HidIsEmployee]").val(i.item.val3);
                    $("[id$=HidDesignation]").val(i.item.val4);
                },
                minLength: 1
            });
          });
     </script>
</asp:Content>
