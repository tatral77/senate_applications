<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="ManageMonthlyChange.aspx.cs" Inherits="Finance.ManageMonthlyChange" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="container">
        <div class="row">
            <div class="col-md-10 page-header">
                <asp:Label ID="header" runat="server"></asp:Label>

            </div>
            <div class="col-md-2 page-header">
                 <asp:Button ID="Button1" runat="server" CommandName="new" Text="Add New" OnClick="Button1_Click" class="btn btn-success" />
            </div>
        </div>
        <div class="row" style="margin-top: 10px">

            <div class="col-md-12">

                <table class="table table-hover table-striped table-condensed table-data table-responsive">
                    <thead>
                        <tr>
                            <th>Sr#</th>
                            <th style="width: 40%">Allowance</th>
                            <th>Amount</th>
                            <th>Remarks</th>
                            <th>Action</th>
                        </tr>
                    </thead>
                    <asp:ListView ID="LV" runat="server"
                        OnItemCanceling="ItemCanceling"
                        OnItemDeleting="ItemDeleting"
                        OnItemInserting="ItemInserting"
                        OnItemCreated="ItemCreated">
                        <ItemTemplate>
                            <tr>
                                <td>
                                    <asp:HiddenField ID="HidMonthlyChangeId" runat="server" Value='<%#Bind("MonthlyChangeId")%>' />
                                    <asp:Label ID="SrNo" runat="server" Text='<%#Container.DataItemIndex + 1%> '></asp:Label></td>
                                <td>
                                    <asp:Label class="table-data" ID="Label3" runat="server" Text='<%#Eval("Description")%>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label class="table-data" ID="Label2" runat="server" Text='<%#Eval("Amount")%>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label class="table-data" ID="Label6" runat="server" Text='<%#Eval("Remarks")%>'></asp:Label>
                                </td>
                                <td>
                                    <asp:LinkButton ID="editImageButton" class="btn btn-success" runat="server" CommandName="edit"
                                        ToolTip="Edit"><span class="glyphicon glyphicon-pencil"></span></asp:LinkButton>
                                    <asp:LinkButton ID="deleteImageButton" class="btn btn-success" runat="server" CommandName="delete"
                                        ToolTip="Delete" OnClientClick="return confirm('Are you sure you want to delete the Posting of Employee');"><span class="glyphicon glyphicon-erase"></span></asp:LinkButton>

                                </td>
                            </tr>


                        </ItemTemplate>
                        <InsertItemTemplate>
                            <tr>
                                <td></td>
                                 <td>
                                    <asp:DropDownList class="form-control" ID="AllowanceDDL" runat="server">
                                          <asp:Listitem Value="0">Select</asp:Listitem>
                                    </asp:DropDownList>
                                </td>

                                <td>
                                    <asp:TextBox class="form-control" ID="AmountTxt" runat="server"></asp:TextBox>
                                </td>
                                
                                 <td>
                                    <asp:TextBox TextMode="MultiLine" class="form-control" ID="RemarksTxt" runat="server"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:LinkButton ID="LinkButton2" ValidationGroup="g2" class="btn btn-success" runat="server" CommandName="cancel"
                                        ToolTip="Cancel"><span class="glyphicon glyphicon-arrow-left"></span></asp:LinkButton>
                                    <asp:LinkButton class="btn btn-success" ID="LinkButton3" runat="server" CommandName="insert"
                                        ToolTip="Save" ValidationGroup="g1"><span class="glyphicon glyphicon-floppy-disk"></span></asp:LinkButton>
                                </td>
                            </tr>

                        </InsertItemTemplate>
                    </asp:ListView>
                </table>
            </div>
        </div>
          <div class="row">
            <div class="col-md-10 page-header">
                <asp:Label ID="Label1" runat="server"></asp:Label>

            </div>
            <div class="col-md-2 page-header">
                 <asp:Button ID="DeductionBtn" runat="server" CommandName="new" Text="Add New" OnClick="DeductionBtn_Click" class="btn btn-success" />
            </div>
        </div>
        <div class="row" style="margin-top: 10px">

            <div class="col-md-12">

                <table class="table table-hover table-striped table-condensed table-data table-responsive">
                    <thead>
                        <tr>
                            <th>Sr#</th>
                            <th style="width: 40%">Deduction</th>
                            <th>Amount</th>
                            <th>Limit</th>
                             <th>Remarks</th>
                            <th>Action</th>
                        </tr>
                    </thead>
                    <asp:ListView ID="DLV" runat="server"
                        OnItemCanceling="ItemDeductionCanceling"
                        OnItemDeleting="ItemDeductionDeleting"
                        OnItemInserting="ItemDeductionInserting"
                        OnItemCreated="ItemCreated">
                        <ItemTemplate>
                            <tr>
                                <td>
                                    <asp:HiddenField ID="HidMonthlyChangeId" runat="server" Value='<%#Bind("MonthlyChangeId")%>' />
                                    <asp:Label ID="SrNo" runat="server" Text='<%#Container.DataItemIndex + 1%> '></asp:Label></td>
                                <td>
                                    <asp:Label class="table-data" ID="Label3" runat="server" Text='<%#Eval("Description")%>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label class="table-data" ID="Label2" runat="server" Text='<%#Eval("Amount")%>'></asp:Label>
                                </td>
                                  <td>
                                    <asp:Label class="table-data" ID="Label4" runat="server" Text='<%#Eval("Limit")%>'></asp:Label>
                                </td>
                                  <td>
                                    <asp:Label class="table-data" ID="Label5" runat="server" Text='<%#Eval("Remarks")%>'></asp:Label>
                                </td>
                                <td>
                                    <asp:LinkButton ID="editImageButton" class="btn btn-success" runat="server" CommandName="edit"
                                        ToolTip="Edit"><span class="glyphicon glyphicon-pencil"></span></asp:LinkButton>
                                    <asp:LinkButton ID="deleteImageButton" class="btn btn-success" runat="server" CommandName="delete"
                                        ToolTip="Delete" OnClientClick="return confirm('Are you sure you want to delete the Posting of Employee');"><span class="glyphicon glyphicon-erase"></span></asp:LinkButton>

                                </td>
                            </tr>


                        </ItemTemplate>
                        <InsertItemTemplate>
                            <tr>
                                <td></td>
                                 <td>
                                    <asp:DropDownList class="form-control" ID="DeductionDDL" runat="server">
                                          <asp:Listitem Value="0">Select</asp:Listitem>
                                    </asp:DropDownList>
                                </td>

                                <td>
                                    <asp:TextBox class="form-control" ID="AmountTxt" runat="server"></asp:TextBox>
                                </td>
                                 <td>
                                    <asp:TextBox class="form-control" ID="LimitTxt" runat="server" Text="0"></asp:TextBox>
                                </td>
                                </tr>
                                <tr>
                                 <td colspan="4">
                                      <asp:Label class="table-data" ID="Label2" runat="server" Text="Remarks"></asp:Label>
                                    <asp:TextBox TextMode="MultiLine" class="form-control" ID="RemarksTxt" runat="server"></asp:TextBox>
                                </td>
                                <td>
                                    <br />
                                    <asp:LinkButton ID="LinkButton2" ValidationGroup="g2" class="btn btn-success" runat="server" CommandName="cancel"
                                        ToolTip="Cancel"><span class="glyphicon glyphicon-arrow-left"></span></asp:LinkButton>
                                    <asp:LinkButton class="btn btn-success" ID="LinkButton3" runat="server" CommandName="insert"
                                        ToolTip="Save" ValidationGroup="g1"><span class="glyphicon glyphicon-floppy-disk"></span></asp:LinkButton>
                                </td>
                            </tr>

                        </InsertItemTemplate>
                    </asp:ListView>
                </table>
            </div>
        </div>
    </div>
</asp:Content>
