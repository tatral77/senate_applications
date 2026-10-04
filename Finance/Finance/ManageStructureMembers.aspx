<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="ManageStructureMembers.aspx.cs" Inherits="Finance.ManageStructureMembers" %>
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
            <div class="col-md-10 page-header">
                <asp:label ID="qw" runat="server">MEMBERS</asp:label>
            </div>
            <div class="col-md-2 page-header" style="text-align: center">
                 <asp:Button ID="Button1" runat="server" CommandName="new" Text="Assign Salary Structure" OnClick="Button1_Click" class="btn btn-success" />
            </div>
        </div>

       <%--    <div class="row">
           <div class="col-md-4">
               <label style="font-size:small;font-weight:bold">Parliamentary Year</label>
               <asp:DropDownList ID="FinancialYearsDDL" runat="server" class="form-control">
               </asp:DropDownList>
           </div>
            <div class="col-md-4">
                <label style="font-size:small;font-weight:bold">Month</label>
               <asp:DropDownList ID="MonthsDDL" AutoPostBack="true" runat="server" class="form-control">
                   <asp:ListItem  Value="0">Select</asp:ListItem>
               </asp:DropDownList>
           </div>
       </div>--%>
        <div class="row" style="margin-top: 10px">

            <div class="col-md-12">

                <table class="table table-hover table-striped table-condensed table-data table-responsive">
                    <thead>
                        <tr>
                            <th>Sr#</th>
                            <th style="width: 40%">Member Name</th>
                            <th>Salary Category</th>
                             <th>Salary Active</th>
                            <th colspan="2">Action</th>
                        </tr>
                    </thead>
                   
                    <asp:ListView ID="LV" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td>
                                    <asp:HiddenField ID="HidSalaryStructureId" runat="server" Value='<%#Bind("MemberId")%>' />
                                    <asp:Label ID="SrNo" runat="server" Text='<%#Container.DataItemIndex + 1%> '></asp:Label></td>
                                 <td>
                                    <asp:Label class="table-data" ID="Label3" runat="server" Text='<%#Eval("MemberName")%>'></asp:Label>
                                </td>
                                 <td>
                                    <asp:Label class="table-data" ID="Label2" runat="server" Text='<%#Eval("MemberSalCategory")%>'></asp:Label>
                                </td>
                                  <td>
                                    <asp:Label class="table-data" ID="Label1" runat="server" Text='<%#(Convert.ToInt32(Eval("SalaryStatus"))==1)?"Yes":"No"%>'></asp:Label>
                                </td>
                                 <td>
                                    <asp:HyperLink class="btn btn-primary" ID="HyperLink2" Target="_blank" runat="server" NavigateUrl='<%#GetLink(Convert.ToInt32(Eval("MemberId")))%>'>Salary Details</asp:HyperLink>
                                </td>
                                <%-- <td>
                                    <asp:Button class="btn btn-success" ID="PrintSlipBtn" runat="server" CommandArgument='<%#Eval("MemberId")%>' Text="Print Salary Slip" OnClick="PrintSlipBtn_Click" />
                                </td>--%>
                            </tr>


                        </ItemTemplate>
                      <%--   <InsertItemTemplate>
                            <tr>
                                <td></td>
                                <td>
                                    <asp:Label class="form-control" ID="MemberNameLbl" runat="server"></asp:Label>
                                </td>
                                  <td>
                                    <asp:DropDownList class="form-control" ID="MemSalCategoryDDL" runat="server">
                                          <asp:Listitem Value="0">Select</asp:Listitem>
                                    </asp:DropDownList>
                                </td>
                                 <td>
                                    <asp:CheckBox class="table-data" ID="IsCurrentCB" runat="server" Checked="true"></asp:CheckBox>
                                </td>
                                <td>
                                    <asp:LinkButton ID="LinkButton2" ValidationGroup="g2" class="btn btn-success" runat="server" CommandName="cancel"
                                                    ToolTip="Cancel"><span class="glyphicon glyphicon-arrow-left"></span></asp:LinkButton>
                                                <asp:LinkButton class="btn btn-success" ID="LinkButton3" runat="server" CommandName="insert"
                                                    ToolTip="Save" ValidationGroup="g1"><span class="glyphicon glyphicon-floppy-disk"></span></asp:LinkButton>
                                </td>
                            </tr>

                        </InsertItemTemplate>--%>
                       <%--  <EditItemTemplate>
                            <tr>
                                
                                 <td><asp:Label ID="SrNo" runat="server" Text='<%#Container.DataItemIndex + 1%> '></asp:Label></td>
                                <td>
                                    <asp:HiddenField ID="HidMemberId" runat="server" Value='<%#Bind("MemberId")%>' />
                                    <asp:HiddenField ID="HidMemberSalCategoryId" runat="server" Value='<%#Bind("MemberSalCategoryId")%>' />
                                    <asp:Label ID="SalaryStructureTxt" runat="server" Text='<%#Eval("MemberName") %>'></asp:Label>
                                </td>
                                  <td>
                                    <asp:DropDownList class="form-control" ID="MemSalCategoryDDL" runat="server">
                                         
                                    </asp:DropDownList>
                                </td>
                                 <td>
                                    <asp:CheckBox class="table-data" ID="SalaryStatusCB" runat="server" Checked='<%#(Convert.ToInt32(Eval("SalaryStatus"))==1)?true :false%>'></asp:CheckBox>
                                </td>
                                <td>
                                    <asp:LinkButton ID="cancelImageButton" ValidationGroup="g2" class="btn btn-success" runat="server" CommandName="cancel"
                                                    ToolTip="Cancel"><span class="glyphicon glyphicon-arrow-left"></span></asp:LinkButton>
                                                <asp:LinkButton class="btn btn-success" ID="saveImageButton" runat="server" CommandName="update"
                                                    ToolTip="Save" ValidationGroup="g1"><span class="glyphicon glyphicon-floppy-disk"></span></asp:LinkButton>
                               
                            </tr>

                        </EditItemTemplate>--%>

                      

                    </asp:ListView>


                </table>
            </div>
        </div>

    </div>
</asp:Content>
