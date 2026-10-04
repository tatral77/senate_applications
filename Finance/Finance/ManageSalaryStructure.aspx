<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="ManageSalaryStructure.aspx.cs" Inherits="Finance.ManageSalaryStructure" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md-10">
                <label class="page-header page-title">SALARY STRUCTURES</label>
            </div>
            <div class="col-md-2 page-header" style="text-align: center">
               
                 <asp:Button ID="Button1" runat="server" CommandName="new" Text="Add New" OnClick="Button1_Click" class="btn btn-success" />
            </div>
        </div>

        <%--   <div class="row">
           <div class="col-md-4">
               <label style="font-size:small;font-weight:bold">Parliamentary Year</label>
               <asp:DropDownList ID="ParliamentaryYearDDL" runat="server" class="form-control"><asp:ListItem Selected="True" Value="1">2018-2019</asp:ListItem></asp:DropDownList>
           </div>
            <div class="col-md-4">
                <label style="font-size:small;font-weight:bold">Visits</label>
               <asp:DropDownList ID="VisitsDDL" AutoPostBack="true" OnSelectedIndexChanged="VisitsDDL_SelectedIndexChanged" runat="server" class="form-control">
                   <asp:ListItem  Value="1">All</asp:ListItem>
                    <asp:ListItem Selected="True" Value="2">Upcoming</asp:ListItem>
                    <asp:ListItem  Value="3">Previous</asp:ListItem>
               </asp:DropDownList>
           </div>
       </div>--%>
        <div class="row" style="margin-top: 10px">

            <div class="col-md-11">

                <table class="table table-hover table-striped table-condensed table-data table-responsive">
                    <thead>
                        <tr>
                            <th>Sr#</th>
                            <th style="width: 40%">Description</th>
                            <th>Salary Category</th>
                            <th>Financial Year</th>
                            <th>Current</th>
                            <th>Action</th>


                        </tr>
                    </thead>
                   
                    <asp:ListView ID="LV" runat="server"
                        OnItemUpdating="ItemUpdating"
                        OnItemCreated="ItemCreated"
                        OnItemDataBound="ItemDataBound"
                        OnItemInserting="ItemInserting"
                        OnItemEditing="ItemEditing"
                        OnItemCanceling="ItemCanceling"
                      >
                        <ItemTemplate>
                            <tr>
                                <td>
                                    <asp:HiddenField ID="HidSalaryStructureId" runat="server" Value='<%#Bind("SalaryStructureId")%>' />
                                    <asp:Label ID="SrNo" runat="server" Text='<%#Container.DataItemIndex + 1%> '></asp:Label></td>
                                <td>
                                    <asp:HyperLink class="table-data" ID="HyperLink1" runat="server" Style="color: black;" Target="_blank" NavigateUrl='<%#GetLink(Convert.ToInt32(Eval("SalaryStructureId")))%>'><%#Eval("Description") %></asp:HyperLink>
                                </td>
                                 <td>
                                    <asp:Label class="table-data" ID="Label2" runat="server" Text='<%#Eval("MemberSalCategory")%>'></asp:Label>
                                </td>
                                 
                                  <td>
                                    <asp:Label class="table-data" ID="Label4" runat="server" Text='<%#Eval("FinancialYear")%>'></asp:Label>
                                </td>
                                 <td>
                                    <asp:Label class="table-data" ID="Label1" runat="server" Text='<%#(Convert.ToInt32(Eval("IsCurrent"))==1)?"Yes":"No"%>'></asp:Label>
                                </td>
                                
                                <td style="width:15%">
                                    <asp:HyperLink class="btn btn-primary" ID="HyperLink2" runat="server" NavigateUrl='<%#GetLink2(Convert.ToInt32(Eval("SalaryStructureId")))%>'>Members</asp:HyperLink>
                                    <asp:LinkButton ID="editImageButton" class="btn btn-success" runat="server" CommandName="edit"
                                        ToolTip="Edit"><span class="glyphicon glyphicon-pencil"></span></asp:LinkButton>
                                  <%--  <asp:LinkButton ID="deleteImageButton" class="btn btn-danger" runat="server" CommandName="delete"
                                        ToolTip="Delete" OnClientClick="return confirm('Are you sure you want to delete the Posting of Employee');"><span class="glyphicon glyphicon-erase"></span></asp:LinkButton>--%>
                                   
                                </td>
                            </tr>

                        </ItemTemplate>
                         <InsertItemTemplate>
                            <tr>
                                <td></td>
                                <td>
                                    <asp:TextBox class="form-control" ID="SalaryStructureTxt" runat="server"></asp:TextBox>
                                </td>
                                  <td>
                                    <asp:DropDownList class="form-control" ID="MemSalCategoryDDL" runat="server">
                                          <asp:Listitem Value="0">Select</asp:Listitem>
                                    </asp:DropDownList>
                                </td>
                                 <td>
                                    <asp:DropDownList class="form-control" ID="FundCenterDDL" runat="server">
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

                        </InsertItemTemplate>
                         <EditItemTemplate>
                            <tr>
                                
                                 <td><asp:Label ID="SrNo" runat="server" Text='<%#Container.DataItemIndex + 1%> '></asp:Label></td>
                                <td>
                                    <asp:HiddenField ID="HidSalaryStructureId" runat="server" Value='<%#Bind("SalaryStructureId")%>' />
                                    <asp:HiddenField ID="HidMemberSalCategoryId" runat="server" Value='<%#Bind("MemberSalCategoryId")%>' />
                                     <asp:HiddenField ID="HidFundCenterId" runat="server" Value='<%#Bind("FundCenterId")%>' />
                                    <asp:TextBox class="form-control" ID="SalaryStructureTxt" runat="server" Text='<%#Eval("Description") %>'></asp:TextBox>

                                </td>
                                  <td>
                                    <asp:DropDownList class="form-control" ID="MemSalCategoryDDL" runat="server">
                                          <asp:Listitem Value="0">Select</asp:Listitem>
                                    </asp:DropDownList>
                                </td>
                                   <td>
                                    <asp:DropDownList class="form-control" ID="FundCenterDDL" runat="server">
                                          <asp:Listitem Value="0">Select</asp:Listitem>
                                    </asp:DropDownList>
                                </td>
                                 <td>
                                    <asp:CheckBox class="table-data" ID="IsCurrentCB" runat="server" Checked='<%#(Convert.ToInt32(Eval("IsCurrent"))==1)?true :false%>'></asp:CheckBox>
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
