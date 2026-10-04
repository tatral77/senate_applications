<%@ Page Title="" Language="C#" MasterPageFile="~/MainMaster.Master" AutoEventWireup="true" CodeBehind="Corrections.aspx.cs" Inherits="EstablishmentASP.Corrections" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md-10">
                <label class="page-header page-title">CORRECTIONS</label>
            </div>
            <div class="col-md-2 page-header ">
                <asp:Button ID="NewCorrectionBtn" class="btn btn-custom" runat="server" Text="Add New" CommandName="new" OnClick="NewCorrectionBtn_Click" />
            </div>
        </div>
        <div class="row">
            <div class="col-md-8">
            </div>
            <div class="col-md-4">
                <asp:DropDownList ID="StatusDDL" runat="server" AutoPostBack="true" CssClass="form-control" OnSelectedIndexChanged="StatusDDL_SelectedIndexChanged">
                    <asp:ListItem Value="0">Un-Solved</asp:ListItem>
                    <asp:ListItem Value="1">Solved</asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>
    </div>
    <div class="container">
        <div class="row">
            <div class="col-md-12">
                <table class="table table-hover table-striped table-condensed table-data">
                    <thead>
                        <tr>
                            <th>Sr#</th>
                            <th>Employee Name</th>
                            <th>Correction</th>
                            <th>Date</th>
                            <th>Status</th>
                            <th>Action</th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:ListView ID="CorrectionLV" runat="server"
                            OnItemEditing="ItemEditing"
                            OnItemCanceling="ItemCanceling"
                            OnItemUpdating="ItemUpdating"
                            OnItemInserting="ItemInserting"
                            OnItemDeleting="ItemDeleting">

                            <ItemTemplate>
                                <tr>
                                    <td>
                                        <asp:HiddenField ID="HidCorrectionId" runat="server" Value='<%#Bind("CorrectionId") %>' />
                                        <asp:Label ID="Label3" runat="server" Style="font-family: Verdana; font-weight: lighter;" Text='<%#Container.DataItemIndex + 1%> ' />
                                    </td>
                                    <td>
                                        <asp:HiddenField ID="idHiddenField" runat="server" Value='<%#Bind("SystemUsersId")%>' />
                                        <a class="tooltip table-data" style="font-weight: bold;" href='<%#Eval("SystemUsersId","../PersonalInformation.aspx?empid={0}")%>'><%#Eval("EmployeeName")%>
                                    </td>
                                    <td style="width:30%">
                                        <asp:Label ID="Label2" Style="font-family: Verdana; font-weight: lighter;" runat="server" Text='<%#Eval("CorrectionTxt") %>' />
                                    </td>
                                    <td>
                                        <asp:Label ID="PostedFrom" Style="font-family: Verdana; font-weight: lighter;" runat="server" Text='<%#GetDate(Convert.ToDateTime(Eval("CorrectionDate")))%>' />
                                    </td>
                                    <td>
                                        <asp:Label ID="BranchLabel" Style="font-family: Verdana; font-weight: lighter;" runat="server" Text='<%#Convert.ToInt32(Eval("Solved"))==1?"Processed":"Under-Process"%>' />
                                    </td>

                                    <td style='display: <%#Convert.ToInt32(Eval("Solved"))==1?"none":"normal"%>'>
                                        <asp:Button CssClass="btn btn-row" ID="SolvedBtn" OnClientClick="return confirm('Are you sure you want to change status?');" runat="server" CommandArgument='<%#Eval("CorrectionId")%>' Text="Solved" OnClick="SolvedBtn_Click" />
                                    </td>

                                </tr>
                            </ItemTemplate>
                        </asp:ListView>
                    </tbody>
                </table>
            </div>
        </div>
    </div>
</asp:Content>
