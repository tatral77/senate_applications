<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="ManageDeductions.aspx.cs" Inherits="Finance.ManageDeductions" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="container">
        <div class="row">
            <div class="col-md-11 page-header">
                <%--<label id="header" style="font-weight:normal" runat="server" class="page-header page-title"></label>--%>
                <asp:HyperLink  ID="HeaderLink" runat="server" Style="color: black;"></asp:HyperLink>
            </div>

        </div>
         <div class="row">
            <div class="col-md-11" style="text-align: right">
                <asp:Button ID="Button1" runat="server" CommandName="new" Text="Add New" OnClick="Button1_Click" class="btn btn-success" />
            </div>
        </div>
          <div class="row">
             <div class="col-md-12">
                 <asp:Label runat="server" ID="err" style="color:red" Text=""></asp:Label>
             </div>
             </div>
        <div class="row" style="margin-top: 10px">

            <div class="col-md-11">

                <table class="table table-hover table-striped table-condensed table-data table-responsive">
                    <thead>
                        <tr>
                            <th>Sr#</th>
                            <th>Deduction</th>
                            <th>Action</th>
                        </tr>
                    </thead>
                    <asp:ListView ID="LV" runat="server"
                        OnItemCanceling="ItemCanceling"
                        OnItemInserting="ItemInserting"
                        OnItemEditing="ItemEditing"
                        OnItemUpdating="ItemUpdating">
                        <ItemTemplate>
                            <tr>
                                <td>
                                    <asp:HiddenField ID="HidDeduction" runat="server" Value='<%#Bind("DeductionId")%>' />
                                    <asp:Label ID="SrNo" runat="server" Text='<%#Container.DataItemIndex + 1%> '></asp:Label></td>
                                 <td>
                                      <asp:Label class="table-data" ID="AllowanceTxt" runat="server" Text='<%#Eval("DeductionDesc")%>'></asp:Label>
                                </td>
                                <td>
                                    <asp:LinkButton ID="editImageButton" class="btn btn-success" runat="server" CommandName="edit"
                                        ToolTip="Edit"><span class="glyphicon glyphicon-pencil"></span></asp:LinkButton>
                                    <asp:LinkButton ID="deleteImageButton" class="btn btn-success" runat="server" CommandName="delete"
                                        ToolTip="Delete" OnClientClick="return confirm('Are you sure you want to delete the Posting of Employee');"><span class="glyphicon glyphicon-erase"></span></asp:LinkButton>
                                </td>
                            </tr>

                        </ItemTemplate>

                        <EditItemTemplate>
                            <tr>
                                <td><asp:Label ID="SrNo" runat="server" Text='<%#Container.DataItemIndex + 1%> '></asp:Label></td>
                                <td>
                                    <asp:HiddenField ID="HidDeductionId" runat="server" Value='<%#Bind("DeductionId")%>' />
                                    <asp:TextBox ID="DeductionTxt" required="true" class="form-control" runat="server" Text='<%#Bind("DeductionDesc")%>'></asp:TextBox>
                                 </td>
                                <td class="altCent">
                                    <asp:LinkButton ID="cancelImageButton" class="btn btn-success" runat="server" CommandName="cancel"
                                        ToolTip="Cancel"><span class="glyphicon glyphicon-arrow-left"></span></asp:LinkButton>
                                    <asp:LinkButton class="btn btn-success" ID="saveImageButton" runat="server" CommandName="update"
                                        ToolTip="Save" ValidationGroup="Group1"><span class="glyphicon glyphicon-floppy-disk"></span></asp:LinkButton>
                                    <asp:Label ID="ErrorLabel" runat="server" Text="" Style="color: red; font-size: small"></asp:Label>
                                </td>
                          
                            </tr>
                        </EditItemTemplate>
                        <InsertItemTemplate>
                             <tr>
                                 <td></td>
                                 <td><asp:TextBox ID="DeductionTxt" required="true" class="form-control" runat="server" Text=''></asp:TextBox>
                                  </td>
                                                <td class="altCent">
                                                    <asp:LinkButton ID="LinkButton1" class="btn btn-success" runat="server" CommandName="cancel"
                                                        ToolTip="Cancel"><span class="glyphicon glyphicon-arrow-left"></span></asp:LinkButton>
                                                    <asp:LinkButton class="btn btn-success" ID="LinkButton2" runat="server" CommandName="insert"
                                                        ToolTip="Save" ValidationGroup="Group1"><span class="glyphicon glyphicon-floppy-disk"></span></asp:LinkButton>
                                                    <asp:Label ID="Label3" runat="server" Text="" Style="color: red; font-size: small"></asp:Label>
                                                </td>
                                </tr>
                        </InsertItemTemplate>
                    </asp:ListView>
                </table>
            </div>
        </div>
    </div>
    <script type="text/javascript">
      
        $(function () {
            $("[id$='HeadOfAccountTxt']").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: '<%=ResolveUrl("~/WebService1.asmx/GetBranchHeadOfAccountByName") %>',
                        data: "{ 'prefix': '" + request.term + "','BranchId':'10'}",
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        success: function (data) {
                            response($.map(data.d, function (item) {
                                return {
                                    label: item.split('=')[0],
                                    val: item.split('=')[1]
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
                },
                minLength: 1
            });
        });
        </script>
</asp:Content>
