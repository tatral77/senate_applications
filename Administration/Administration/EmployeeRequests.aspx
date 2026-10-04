<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="EmployeeRequests.aspx.cs" Inherits="Administration.EmployeeRequests" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="Custom/jquery-ui.min.js"></script>
    <link href="Custom/jquery-ui.css.css" rel="stylesheet" />
    <style>
        .ui-autocomplete {
            position: relative;
            cursor: default;
            z-index: 2000 !important;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
        <div class="row page-header">
            <div class="col-md-12">

                <h4>
                    <label>EMPLOYEE REQUESTS</label></h4>
            </div>
            
        </div>
        <div class="row">
            <div class="col-md-4">
                <asp:Label ID="Label11" class="control-lbl" runat="server" Text="Employee Name" />
                <asp:TextBox ID="EmployeeNameTxt" runat="server" ClientIDMode="Static" class="form-control"><</asp:TextBox>
                <asp:HiddenField ID="HidSystemUserId" runat="server" Value='' />
                <asp:HiddenField ID="HidPostId" runat="server" Value='' />
                <asp:RequiredFieldValidator ValidationGroup="g1" ControlToValidate="EmployeeNameTxt" Display="Dynamic" CssClass="validationErr" ID="RequiredFieldValidator2" runat="server" ErrorMessage="Enter Employee Name"></asp:RequiredFieldValidator>

            </div>
            <div class="col-md-4">
                <br />
                <asp:Button ID="CheckReq" ValidationGroup="g1" CssClass="btn btn-custom" runat="server" OnClick="CheckReq_Click" Text="Check Requisitions"></asp:Button>
            </div>
              <div class="col-md-4" style="text-align: right">
                <br />
                <asp:Button ID="Button4" ValidationGroup="g1" runat="server" CommandName="new" Text="New Request" class="btn btn-custom" OnClick="Button2_Click" />
            </div>
           <%-- <div class="col-md-2">
                <asp:Label ID="Label5" class="control-lbl" runat="server" Text="Request Date" />
                <asp:TextBox ID="RequestDateFrom" runat="server" ClientIDMode="Static" class="form-control"></asp:TextBox>
            </div>
            <div class="col-md-2">
                <asp:Label ID="Label4" class="control-lbl" runat="server" Text="Request Date" />
                <asp:TextBox ID="RequestDateTo" runat="server" ClientIDMode="Static" class="form-control"></asp:TextBox>
            </div>
             <div class="col-md-4">
                <asp:Label ID="Label1" class="control-lbl" runat="server" Text="Item" />
                <asp:TextBox ID="ItemTxt" runat="server" ClientIDMode="Static" class="form-control"></asp:TextBox>
                <asp:HiddenField ID="HidItemId" runat="server" Value='' />
            </div>--%>
            

        </div>
      
        <br />
        <div class="row">
            <div class="col-md-12">
                <table class="table table-condensed table-striped table-data">
                    <tr>
                        <th>Sr#</th>
                        <th>Requisition Id</th>
                        <th>Requisition Date</th>
                        <th>Month/Year</th>
                        <th>Items</th>
                        <th>Action</th>
                    </tr>
                    <asp:ListView ID="RequisitionItemsLV" runat="server"
                        OnItemEditing="ItemEditing"
                        OnItemInserting="ItemInserting"
                        OnItemCanceling="ItemCanceling"
                        OnItemUpdating="ItemUpdating"
                        OnItemDataBound="ItemDataBound"
                        OnItemDeleting="ItemDeleting"
                        OnItemCreated="ItemCreated">
                        <ItemTemplate>
                            <tr>
                                <td class="itemCent">.
                                    <asp:HiddenField ID="HidRequisitionId" runat="server" Value='<%#Bind("RequisitionId")%>' />
                                    <asp:Label ID="SrNo" runat="server" Text='<%#Container.DataItemIndex + 1%> '></asp:Label></td>
                                <td class="itemCent">
                                    <asp:Label ID="id" runat="server" Text='<%#Bind("RequisitionId")%>' /></td>
                                <td class="itemLeft">
                                    <asp:HyperLink class="details-link" ID="HyperLink1" runat="server" NavigateUrl='<%#Eval("RequisitionId","~/ManageRequisitionItems.aspx?Id={0}")%>'><%#GetLongDate(Convert.ToDateTime(Eval("RequisitionDate")))%></asp:HyperLink>
                                <td class="itemLeft">
                                    <asp:Label ID="Description" runat="server" Text='<%#Eval("ReqMonth") + " / "  + Eval("ReqYear")  %>'></asp:Label></td>
                                   <td class="itemLeft">
                                    <asp:Label ID="Label1" runat="server" Text='<%#Eval("Items")%>'></asp:Label></td>
                                <td class="itemCent">
                                    <asp:LinkButton ID="editImageButton" class="btn btn-custom" runat="server" CommandName="edit"
                                        ToolTip="Edit"><span class="glyphicon glyphicon-pencil"></span></asp:LinkButton>
                                    <asp:LinkButton ID="deleteImageButton" class="btn btn-custom" runat="server" CommandName="delete"
                                        ToolTip="Delete" OnClientClick="return confirm('Are you sure you want to delete record ?');"><span class="glyphicon glyphicon-erase"></span></asp:LinkButton>
                                </td>
                            </tr>
                        </ItemTemplate>

                        <EditItemTemplate>
                            <tr>
                                <td class="itemCent">
                                    <asp:HiddenField ID="HidRequisitionId" runat="server" Value='<%#Bind("RequisitionId")%>' />
                                    <asp:Label ID="SrNo" runat="server" Text='<%#Container.DataItemIndex + 1%> '></asp:Label></td>
                                <td class="itemLeft">
                                    <asp:Label ID="id" runat="server" Text='<%#Bind("RequisitionId")%>' /></td>
                                <td class="itemLeft" colspan="3">
                                    <asp:TextBox ID="RequisitionDateTxt" CssClass="form-control" runat="server" Text='<%#GetDate(Convert.ToDateTime(Eval("RequisitionDate")))%>'></asp:TextBox>
                                        <asp:RequiredFieldValidator ValidationGroup="g1" ControlToValidate="RequisitionDateTxt" Display="Dynamic" CssClass="validationErr" ID="RequiredFieldValidator2" runat="server" ErrorMessage="Enter Requisition Date"></asp:RequiredFieldValidator>
                                    </td>
                                <td>
                                    <asp:LinkButton ID="cancelImageButton" ValidationGroup="g2" class="btn btn-custom" runat="server" CommandName="cancel"
                                        ToolTip="Cancel"><span class="glyphicon glyphicon-arrow-left"></span></asp:LinkButton>
                                    <asp:LinkButton class="btn btn-custom" ID="saveImageButton" runat="server" CommandName="update"
                                        ToolTip="Save" ValidationGroup="g1"><span class="glyphicon glyphicon-floppy-disk"></span></asp:LinkButton>

                                </td>
                            </tr>

                        </EditItemTemplate>
                        <InsertItemTemplate>
                            <tr>
                                <td class="itemCent">
                                    <td class="itemLeft">
                                        <asp:Label ID="Label11" class="control-lbl" runat="server" Text="Requisition Date:" />
                                        <asp:TextBox ID="RequisitionDateTxt" class="form-control" runat="server" Text=''></asp:TextBox>
                                        <asp:RequiredFieldValidator ValidationGroup="g1" ControlToValidate="RequisitionDateTxt" Display="Dynamic" CssClass="validationErr" ID="RequiredFieldValidator2" runat="server" ErrorMessage="Enter Requisition Date"></asp:RequiredFieldValidator>
                                    </td>
                            </tr>
                            <tr>
                                <td colspan="3">
                                    <asp:LinkButton ID="cancelImageButton" ValidationGroup="g2" class="btn btn-custom" runat="server" CommandName="cancel"
                                        ToolTip="Cancel"><span class="glyphicon glyphicon-arrow-left"></span></asp:LinkButton>
                                    <asp:LinkButton class="btn btn-custom" ID="saveImageButton" runat="server" CommandName="insert"
                                        ToolTip="Save" ValidationGroup="g1"><span class="glyphicon glyphicon-floppy-disk"></span></asp:LinkButton>

                                </td>
                            </tr>

                        </InsertItemTemplate>
                        <EmptyDataTemplate>
                            <tr>
                                <td colspan="4" class="altCent" align="center">No Data Found</td>
                            </tr>
                        </EmptyDataTemplate>
                    </asp:ListView>

                   
                </table>


            </div>

        </div>
  
    <script type="text/javascript">
        $(function () {
            $("[id$=EmployeeNameTxt]").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: '<%=ResolveUrl("~/WebService1.asmx/GetEmployeeByName") %>',
                        data: "{ 'prefix': '" + request.term + "'}",
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        success: function (data) {
                            response($.map(data.d, function (item) {
                                return {
                                    label: item.split('-')[0],
                                    val: item.split('-')[1],
                                    val2: item.split('-')[2]
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
                    $("[id$=HidPostId]").val(i.item.val2);
                },
                minLength: 1
            });
          });
        $(function () {
            $("[id$=ItemTxt]").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: '<%=ResolveUrl("~/WebService1.asmx/GetItemName") %>',
                        data: "{ 'prefix': '" + request.term + "'}",
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        success: function (data) {
                            response($.map(data.d, function (item) {
                                return {
                                    label: item.split('-')[0],
                                    val: item.split('-')[1]
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
                    $("[id$=HidItemId]").val(i.item.val);
                },
                minLength: 1
            });
         });

    </script>
</asp:Content>
