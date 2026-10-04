<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Rpt_PendingJSBills.aspx.cs" Inherits="Legislation.Rpt_PendingJSBills" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
    <div class="row">
        <div class="col-md-12" style="text-align:center">
             <h1>SENATE SECRETARIAT</h1>
        </div>
    </div>
     <div class="row">
        <div class="col-md-12"  style="text-align:center">
             <h3>PRIVATE MEMBERS' BILLS PENDING FOR CONSIDERATION IN THE JOINT SITTING OF PARLIAMENT</h3>
        </div>
    </div>
   <%--  <div class="row">
        <div class="col-md-12"  style="text-align:center">
                <div class="col-md-3">
                    <label class="control-lbl-sm" for="BillStatusDDL">Bill Status:</label>
                    <asp:DropDownList ID="BillStatusDDL" class="form-control small-control" runat="server">
                    </asp:DropDownList>
                </div>
        </div>
    </div>--%>
          <div class="row">
                <div class="col-md-12">
                    <table class="table table-hover table-striped table-responsive">
                        <thead class="thead-inverse">
                            <tr>
                                <th>Sr#</th>
                                <th>Title of the Bill</th>
                                <th>Name of Member(s) giving notice</th>
                                <th>Remarks</th>

                            </tr>
                        </thead>
                        <tbody>
                            <asp:ListView ID="JSBillsLV" runat="server">

                                <ItemTemplate>
                                    <tr>
                                        <td>

                                            <asp:Label ID="Label3" class="table-data" runat="server" Text='<%#Container.DataItemIndex + 1%> ' />
                                        </td>
                                        <td>
                                            <asp:Label ID="Label4" class="table-data" runat="server" Text='<%#Bind("BillTitle")%>' />
                                        </td>

                                        <td>
                                             <asp:Label ID="Label220" class="table-data" runat="server" Text='<%#Eval("MoverNames")%>' />
                                     <asp:Label ID="Label24" class="table-data" runat="server" Text='<%#Eval("MinisterNames")%>' />
                                        </td>
                                        <td style="width:40%">
                                            <asp:Label ID="Label8" class="table-data" runat="server" Text='<%#Eval("Remarks")%>' />
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
