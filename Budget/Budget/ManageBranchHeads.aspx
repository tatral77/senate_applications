<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="ManageBranchHeads.aspx.cs" Inherits="Budget.ManageBranchHeads" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
      <link href="Styles/MainStyles.css" rel="stylesheet" />
      <script src="Custom/jquery-ui.min.js"></script>
    <link href="Custom/jquery-ui.css.css" rel="stylesheet" />
    <style type="text/css">
        .group
        {
            background-color:#d3d3d3;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <div class="container container-fluid">
     <div class="row">
            <div class="col-md-4">
                <label id="heading" runat="server" class="page-header page-title"></label>
            </div>
              <div class="col-md-5">
                  <br />
                <label style="font-size: small; font-weight: bold">Financial Year</label>
                <asp:DropDownList ID="FinancialYearsDDL" AutoPostBack="true" runat="server" class="form-control" OnSelectedIndexChanged="BranchDDL_SelectedIndexChanged">
                </asp:DropDownList>
            </div>
            <div class="col-md-2 page-header" style="text-align: center">
                <asp:Button ID="Button1" runat="server" CommandName="new" Text="Add New" class="btn btn-success" OnClick="Button1_Click" />
            </div>
        </div>
        <div class="row" style="margin-top: 10px">
        <div class="row">
            <div class="col-md-11">
                <table class="table table-condensed table-striped table-data">
                    <tr>
                        <th>Sr#</th>
                        <th>Head Of Account - Current Amount</th>
                         <th>Budget Limit</th>
                        <th class="hideall">Action</th>
                        
                    </tr>
                    <asp:ListView ID="BranchHeadsLV" runat="server"
                        OnItemEditing="ItemEditing"
                        OnItemInserting="ItemInserting"
                        OnItemCanceling="ItemCanceling"
                        OnItemDeleting="ItemDeleting"
                        OnItemUpdating="ItemUpdating"
                        OnItemDataBound="ItemDataBound"
                        OnItemCreated="ItemCreated">
                        <ItemTemplate>
                              <%#AddGroupingRow()%>
                            <%#AddMajorGroupingRow()%>
                            <tr>

                                <asp:HiddenField ID="HidBranchHeadId" runat="server" Value='<%#Bind("BranchHeadId")%>' />
                                <td class="itemCent">
                                    <asp:Label ID="SrNo" runat="server" Text='<%#Container.DataItemIndex + 1%> '></asp:Label></td>
                                <td class="itemLeft">
                                      <asp:Label ID="Label1" runat="server" Text='<%#Bind("HeadOfAccount")%>'></asp:Label>
                                    
                                </td>
                                 <td class="itemLeft">
                                      <asp:Label ID="Label2" runat="server" Text='<%#FormatAmount(Convert.ToDouble(Eval("BudgetLimit")))%>'></asp:Label>
                                    
                                </td>
                                <td class="itemCent hideall">
                                  <%--  <asp:LinkButton ID="editImageButton" class="btn btn-success hideedit" runat="server" CommandName="edit"
                                        ToolTip="Edit"><span class="glyphicon glyphicon-pencil"></span></asp:LinkButton>--%>
                                    <asp:LinkButton ID="deleteImageButton" class="btn btn-danger hidedelete" runat="server"  CommandName="delete"
                                 ToolTip="Delete" OnClientClick="return confirm('Are you sure you want to delete record ?');"><span class="glyphicon glyphicon-erase"></span></asp:LinkButton>
                                </td>
                            </tr>
                        </ItemTemplate>

                        <EditItemTemplate>
                            <tr>
                                <td colspan="7">
                                    <asp:HiddenField ID="HidBranchHeadId" runat="server" Value='<%#Bind("BranchHeadId")%>' />
                                    <table class="table table-condensed table-data">
                                        
                                        <tr>
                                            <td class="table-data">
                                                <asp:Label runat="server">Head of Account</asp:Label>

                                            </td>
                                            <td>
                                                 <asp:HiddenField ID="HidHeadOfAccountId" runat="server" Value='<%#Bind("HeadOfAccountId")%>' />
                                                <asp:TextBox ID="HeadOfAccountTxt" class="form-control" runat="server" Text='<%#Bind("HeadOfAccount")%>'></asp:TextBox>
                                                <asp:RequiredFieldValidator ValidationGroup="g1" ControlToValidate="HeadOfAccountTxt" Display="Dynamic" CssClass="validationErr" ID="RequiredFieldValidator2" runat="server" ErrorMessage="Enter Name"></asp:RequiredFieldValidator>
                                            </td>

                                        </tr>
                                          <tr>
                                            <td class="table-data">
                                                <asp:Label runat="server">Budget Limit</asp:Label></td>
                                            <td>
                                                <asp:TextBox ID="BudgetLimitTxt" class="form-control" runat="server" Text='<%#Bind("BudgetLimit")%>'></asp:TextBox>
                                                 <asp:HiddenField ID="HidCurrentBudget" runat="server" Value='' />
                                                
                                            </td>

                                        </tr>
                                        <tr>
                                            <td colspan="3">
                                                <asp:LinkButton ID="cancelImageButton" ValidationGroup="g2" class="btn btn-success" runat="server" CommandName="cancel"
                                                    ToolTip="Cancel"><span class="glyphicon glyphicon-arrow-left"></span></asp:LinkButton>
                                                <asp:LinkButton class="btn btn-success" ID="saveImageButton" runat="server" CommandName="update"
                                                    ToolTip="Save" ValidationGroup="g1"><span class="glyphicon glyphicon-floppy-disk"></span></asp:LinkButton>
                                                 <asp:Label runat="server" ID="err"></asp:Label>
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
                                                <asp:Label runat="server">Head of Account</asp:Label></td>
                                            <td>
                                                <asp:HiddenField ID="HidHeadOfAccountId" runat="server" Value='' />
                                                <asp:TextBox ID="HeadOfAccountTxt" class="form-control" runat="server" Text=''></asp:TextBox>
                                                <asp:RequiredFieldValidator ValidationGroup="g1" ControlToValidate="HeadOfAccountTxt" Display="Dynamic" CssClass="validationErr" ID="RequiredFieldValidator1" runat="server" ErrorMessage="Enter Name"></asp:RequiredFieldValidator>
                                            </td>

                                        </tr>
                                     
                                         <tr>
                                            <td class="table-data">
                                                <asp:Label runat="server">Budget Limit</asp:Label></td>
                                            <td>
                                                <asp:TextBox ID="BudgetLimitTxt" class="form-control" runat="server" Text='0'></asp:TextBox>
                                                <asp:HiddenField ID="HidCurrentBudget" runat="server" Value='' />
                                            </td>

                                        </tr>
                                        <tr>
                                            <td colspan="3">
                                                <asp:LinkButton ID="LinkButton2" ValidationGroup="g2" class="btn btn-success" runat="server" CommandName="cancel"
                                                    ToolTip="Cancel"><span class="glyphicon glyphicon-arrow-left"></span></asp:LinkButton>
                                                <asp:LinkButton class="btn btn-success" ID="LinkButton3" runat="server" CommandName="insert"
                                                    ToolTip="Save" ValidationGroup="g1"><span class="glyphicon glyphicon-floppy-disk"></span></asp:LinkButton>
                                                <asp:Label runat="server" ID="err"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </td>

                            </tr>
                        </InsertItemTemplate>
                        <EmptyDataTemplate>
                            <tr>
                                <td colspan="4" class="altCent">No Data Found</td>
                            </tr>
                        </EmptyDataTemplate>
                    </asp:ListView>
                </table>
            </div>
        </div>
    </div>
          </div>
     <script type="text/javascript">
         function getUrlParameter(name) {
             name = name.replace(/[\[]/, '\\[').replace(/[\]]/, '\\]');
             var regex = new RegExp('[\\?&]' + name + '=([^&#]*)');
             var results = regex.exec(location.search);
             return results === null ? '' : decodeURIComponent(results[1].replace(/\+/g, ' '));
         };
        $(function () {
            $("[id$=HeadOfAccountTxt]").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: '<%=ResolveUrl("~/WebService1.asmx/GetBranchHeadOfAccountByName") %>',
                        data: "{ 'prefix': '" + request.term + "','BranchId':'" + getUrlParameter('BID') + "'}",
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        success: function (data) {
                            response($.map(data.d, function (item) {
                                return {
                                    label: item.split('=')[0],
                                    val: item.split('=')[1],
                                    amount: item.split('=')[2]
                                 
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
                    $("[id$=HidHeadOfAccountId]").val(i.item.val);
                    $("[id$=BudgetLimitTxt]").val(i.item.amount);
                    $("[id$=HidCurrentBudget]").val(i.item.amount);
                },
                minLength: 1
            });
          });
</script>
</asp:Content>
