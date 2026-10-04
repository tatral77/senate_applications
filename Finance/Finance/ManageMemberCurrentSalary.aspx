<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" MaintainScrollPositionOnPostback="true" AutoEventWireup="true" CodeBehind="ManageMemberCurrentSalary.aspx.cs" Inherits="Finance.ManageMemberCurrentSalary" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="container">
    <div class="row">
        <div class="col-md-12 page-header">
            <asp:Label ID="header" runat="server"></asp:Label>
           
        </div>
        </div>
       <div class="row">
          <div class="col-md-10 page-header">ALLOWANCES</div>
            <div class="col-md-2 page-header"> <asp:Button ID="AddAllowanceBtn" runat="server" CommandName="new" Text="Add Allowance"  class="btn btn-success" OnClick="AddAllowanceBtn_Click" /></div>
       </div>
         <div class="row">
        <div class="col-md-12">
            <table class="table table-condensed">
                <tr>
                    <th>Sr#</th>
                    <th>Allowance</th>
                    <th>Head Of Account</th>
                    <th>Amount</th>
                    <th>Action</th>
                </tr>
            <asp:ListView ID="AllowancesLV" runat="server"
                OnItemUpdating="AllowanceItemUpdating"
                OnItemInserting="AllowanceItemInserting"
                OnItemEditing="AllowanceItemEditing"
                OnItemDeleting="AllowanceItemDeleting"
                OnItemCreated="ItemCreated"
                OnItemDataBound="AllowanceItemDataBound"
                OnItemCanceling="AllowanceItemCanceling"
            >
                 <ItemTemplate>
                            <tr>
                                <td>
                                    <asp:HiddenField ID="HidCurrentAllowanceId" runat="server" Value='<%#Bind("CurrentAllowanceId")%>' />
                                    <asp:Label ID="SrNo" runat="server" Text='<%#Container.DataItemIndex + 1%> '></asp:Label></td>
                                <td>
                                    <asp:Label class="table-data" ID="Label2" runat="server" Text='<%#Eval("AllowanceDesc")%>'></asp:Label>
                                </td>
                                 <td>
                                    <asp:Label class="table-data" ID="Label3" runat="server" Text='<%#Eval("HeadOfAccount")%>'></asp:Label>
                                </td>
                               
                                 <td>
                                    <asp:Label class="table-data" ID="Label1" runat="server" Text='<%#Eval("Amount")%>'></asp:Label>
                                </td>
                                
                                <td>
                                    <asp:LinkButton ID="editImageButton" class="btn btn-success" runat="server" CommandName="edit"
                                        ToolTip="Edit"><span class="glyphicon glyphicon-pencil"></span></asp:LinkButton>
                                    <asp:LinkButton ID="deleteImageButton" class="btn btn-danger" runat="server" CommandName="delete"
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
                                    <asp:TextBox class="form-control" ID="AmountTxt" runat="server" Text='0'></asp:TextBox>
                                </td>
                                <td>
                                    <asp:LinkButton ID="LinkButton2" ValidationGroup="g2" class="btn btn-success" runat="server" CommandName="cancel"
                                                    ToolTip="Cancel"><span class="glyphicon glyphicon-arrow-left"></span></asp:LinkButton>
                                                <asp:LinkButton class="btn btn-success" ID="LinkButton3" runat="server" CommandName="insert"
                                                    ToolTip="Save" ValidationGroup="g1"><span class="glyphicon glyphicon-floppy-disk"></span></asp:LinkButton>
                                </td>
                            </tr>

                        </InsertItemTemplate>
                         <EditItemTemplate>
                            <tr>
                                
                                   <td></td>
                                <td>
                                     <asp:HiddenField ID="HidCurrentAllowanceId" runat="server" Value='<%#Bind("CurrentAllowanceId")%>' />
                                   <asp:HiddenField ID="HidAllowanceId" runat="server" Value='<%#Bind("AllowanceId")%>' />
                                    <asp:DropDownList class="form-control" ID="AllowanceDDL" runat="server">
                                         <asp:Listitem Value="0">Select</asp:Listitem>
                                    </asp:DropDownList>
                                </td>
                                 <td>
                                    <asp:TextBox class="form-control" ID="AmountTxt" runat="server" Text='<%#Eval("Amount") %>'></asp:TextBox>
                                </td>
                                <td>
                                    <asp:LinkButton ID="cancelImageButton" ValidationGroup="g2" class="btn btn-success" runat="server" CommandName="cancel"
                                                    ToolTip="Cancel"><span class="glyphicon glyphicon-arrow-left"></span></asp:LinkButton>
                                                <asp:LinkButton class="btn btn-success" ID="saveImageButton" runat="server" CommandName="update"
                                                    ToolTip="Save" ValidationGroup="g1"><span class="glyphicon glyphicon-floppy-disk"></span></asp:LinkButton>
                               
                            </tr>

                        </EditItemTemplate>
            </asp:ListView>
            </table>
        </div>
        </div>











        <div class="row">
          <div class="col-md-10 page-header">DEDUCTIONS</div> 
            <div class="col-md-2 page-header"> <asp:Button ID="AddDeductionBtn" runat="server" CommandName="new" Text="Add Deduction"  class="btn btn-success" OnClick="AddDeductionBtn_Click" /></div>
       </div>
         <div class="row">
        <div class="col-md-12">
              <table class="table table-condensed">
                <tr>
                    <th>Sr#</th>
                    <th>Deduction</th>
                    <th>Amount</th>
                    <th>Action</th>
                </tr>
            <asp:ListView ID="DeductionsLV" runat="server"
                 OnItemEditing="DeductionItemEditing"
                OnItemInserting="DeductionItemInserting"
                OnItemDeleting="DeductionItemDeleting"
                OnItemCreated="ItemCreated"
                OnItemUpdating="DeductionItemUpdating"
                OnItemDataBound="DeductionItemDataBound"
                OnItemCanceling="DeductionItemCanceling">
                 <ItemTemplate>
                            <tr>
                                <td>
                                    <asp:HiddenField ID="HidCurrentDeductionId" runat="server" Value='<%#Bind("CurrentDeductionId")%>' />
                                    <asp:Label ID="SrNo" runat="server" Text='<%#Container.DataItemIndex + 1%> '></asp:Label></td>
                                <td>
                                    <asp:Label class="table-data" ID="Label2" runat="server" Text='<%#Eval("DeductionDesc")%>'></asp:Label>
                                </td>
                               
                                 <td>
                                    <asp:Label class="table-data" ID="Label1" runat="server" Text='<%#Eval("Amount")%>'></asp:Label>
                                </td>
                                
                                <td>
                                    <asp:LinkButton ID="editImageButton" class="btn btn-success" runat="server" CommandName="edit"
                                        ToolTip="Edit"><span class="glyphicon glyphicon-pencil"></span></asp:LinkButton>
                                    <asp:LinkButton ID="deleteImageButton" class="btn btn-danger" runat="server" CommandName="delete"
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
                                    <asp:TextBox class="form-control" ID="AmountTxt" runat="server" Text='0'></asp:TextBox>
                                </td>
                                <td>
                                    <asp:LinkButton ID="LinkButton2" ValidationGroup="g2" class="btn btn-success" runat="server" CommandName="cancel"
                                                    ToolTip="Cancel"><span class="glyphicon glyphicon-arrow-left"></span></asp:LinkButton>
                                                <asp:LinkButton class="btn btn-success" ID="LinkButton3" runat="server" CommandName="insert"
                                                    ToolTip="Save" ValidationGroup="g1"><span class="glyphicon glyphicon-floppy-disk"></span></asp:LinkButton>
                                </td>
                            </tr>

                        </InsertItemTemplate>
                         <EditItemTemplate>
                            <tr>
                                
                                   <td></td>
                                <td>
                                     <asp:HiddenField ID="HidCurrentDeductionId" runat="server" Value='<%#Bind("CurrentDeductionId")%>' />
                                   <asp:HiddenField ID="HidDeductionId" runat="server" Value='<%#Bind("DeductionId")%>' />
                                    <asp:DropDownList class="form-control" ID="DeductionDDL" runat="server">
                                         <asp:Listitem Value="0">Select</asp:Listitem>
                                    </asp:DropDownList>
                                </td>
                                 <td>
                                    <asp:TextBox class="form-control" ID="AmountTxt" runat="server" Text='<%#Eval("Amount") %>'></asp:TextBox>
                                </td>
                                <td>
                                    <asp:LinkButton ID="cancelImageButton" ValidationGroup="g2" class="btn btn-success" runat="server" CommandName="cancel"
                                                    ToolTip="Cancel"><span class="glyphicon glyphicon-arrow-left"></span></asp:LinkButton>
                                                <asp:LinkButton class="btn btn-success" ID="saveImageButton" runat="server" CommandName="update"
                                                    ToolTip="Save" ValidationGroup="g1"><span class="glyphicon glyphicon-floppy-disk"></span></asp:LinkButton>
                               
                            </tr>

                        </EditItemTemplate>
            </asp:ListView>
            </table>
        </div>
        </div>
        </div>
</asp:Content>
