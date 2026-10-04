<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="BranchHeads.aspx.cs" Inherits="Budget.BranchHeads" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
       <link href="Styles/MainStyles.css" rel="stylesheet" />
      <script src="Custom/jquery-ui.min.js"></script>
    <link href="Custom/jquery-ui.css.css" rel="stylesheet" />
        <style>
            .ui-autocomplete {
                position: relative;
                cursor: default;
                z-index: 2000 !important;
            }
                lis {
                background-color: #00688B;
            }

            li a {
                color: #fff;
            }

            .navbar-fixed-left {
                position: fixed;
                border-radius: 0;
                height: 100%;
                width: 12%;
            }

                .navbar-fixed-left .navbar-nav > li {
                    float: none; /* Cancel default li float: left */
                }

                .navbar-fixed-left + .container {
                }

                /* On using dropdown menu (To right shift popuped) */
                .navbar-fixed-left .navbar-nav > li > .dropdown-menu {
                    margin-top: -50px;
                }
        </style>
    </asp:Content>
      
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="container">
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
            <div class="col-md-11">
                <table class="table table-hover table-striped table-condensed table-data table-responsive">
                    <thead>
                        <tr>
                            <th>Sr#</th>
                            <th>Head of Account - Current Amount</th>
                            <th>Action</th>
                        </tr>
                    </thead>
                    <asp:ListView ID="BillLV" runat="server"
                        OnItemCanceling="ItemCanceling"
                        OnItemInserting="ItemInserting"
                        OnItemEditing="ItemEditing"
                        OnItemUpdating="ItemUpdating">
                        <ItemTemplate>
                            <tr>
                                <td>
                                    <asp:HiddenField ID="HidBranchHeadId" runat="server" Value='<%#Bind("BranchHeadId")%>' />
                                  
                                    <asp:Label ID="SrNo" runat="server" Text='<%#Container.DataItemIndex + 1%> '></asp:Label></td>
                                <td>
                                    <asp:Label ID="DegreeLevelLb" runat="server" Text='<%#Bind("HeadOfAccount")%>'></asp:Label>
                                </td>
                              
                                <td>
                                    <asp:LinkButton ID="editImageButton" class="btn btn-success" runat="server" CommandName="edit"
                                        ToolTip="Edit"><span class="glyphicon glyphicon-pencil"></span></asp:LinkButton>
                                    <asp:LinkButton ID="deleteImageButton" class="btn btn-danger" runat="server" CommandName="delete"
                                        ToolTip="Delete" OnClientClick="return confirm('Are you sure you want to delete the Head');"><span class="glyphicon glyphicon-erase"></span></asp:LinkButton>
                                </td>
                            </tr>

                        </ItemTemplate>
                        <EditItemTemplate>
                            <tr>
                                <td colspan="9">
                                    <asp:HiddenField ID="HidBranchHeadId" runat="server" Value='<%#Bind("BranchHeadId")%>' />
                                    <table class="table table-condensed table-data">
                                        <tr>
                                            <td>Head Of Account:</td>
                                            <td>
                                                <asp:TextBox ID="HeadOfAccountTxt" class="form-control" runat="server" Text='<%#Bind("HeadOfAccount")%>'></asp:TextBox>
                                                  <asp:HiddenField ID="HidHeadOfAccountId" runat="server" Value='<%#Bind("HeadOfAccountId")%>' />
                                            </td>

                                        </tr>
                            <tr>
                                <td>Action:</td>
                                <td class="altCent">
                                    <asp:LinkButton ID="cancelImageButton" class="btn btn-success" runat="server" CommandName="cancel"
                                        ToolTip="Cancel"><span class="glyphicon glyphicon-arrow-left"></span></asp:LinkButton>
                                    <asp:LinkButton class="btn btn-success" ID="saveImageButton" runat="server" CommandName="update"
                                        ToolTip="Save" ValidationGroup="Group1"><span class="glyphicon glyphicon-floppy-disk"></span></asp:LinkButton>
                                    <asp:Label ID="ErrorLabel" runat="server" Text="" Style="color: red; font-size: small"></asp:Label>
                                </td>
                            </tr>
                            </table>
                                </td>
                            </tr>
                        </EditItemTemplate>
                        <InsertItemTemplate>
                             <tr>
                                <td colspan="9">
                                    <asp:HiddenField ID="HidHeadOfAccountId" runat="server" />
                                    <table class="table table-condensed table-data">
                                        <tr>
                                            <td>Head Of Account:</td>
                                            <td>
                                                <asp:TextBox ID="HeadOfAccountTxt" class="form-control" runat="server" Text=''></asp:TextBox>
                                                 <asp:TextBox ID="TextBox1" class="form-control" runat="server"></asp:TextBox>
                                            </td>

                                        </tr>
                            <tr>
                                <td>Action:</td>
                                <td class="altCent">
                                    <asp:LinkButton ID="LinkButton1" class="btn btn-success" runat="server" CommandName="cancel"
                                        ToolTip="Cancel"><span class="glyphicon glyphicon-arrow-left"></span></asp:LinkButton>
                                    <asp:LinkButton class="btn btn-success" ID="LinkButton2" runat="server" CommandName="insert"
                                        ToolTip="Save" ValidationGroup="Group1"><span class="glyphicon glyphicon-floppy-disk"></span></asp:LinkButton>
                                    <asp:Label ID="Label4" runat="server" Text="" Style="color: red; font-size: small"></asp:Label>
                                </td>
                            </tr>
                            </table>
                                    </td>
                                </tr>
                        </InsertItemTemplate>

                    </asp:ListView>


                </table>
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
                        url: '<%=ResolveUrl("~/WebService1.asmx/GetHeadOfAccountByName") %>',
                        data: "{ 'prefix': '" + request.term + "'}",
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
                     $("[id$=TextBox1]").val(i.item.val);
                     $("[id$=ContentPlaceHolder1_BillLV_HidHeadOfAccountId]").val(i.item.val);
                  },
             minLength: 1
            });
        });
        

</script>

</asp:Content>
