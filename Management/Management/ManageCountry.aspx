<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" MaintainScrollPositionOnPostback="true" CodeBehind="ManageCountry.aspx.cs" Inherits="Management.ManageCountry" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="DivisionDiv">
        <div class="container container-fluid">
            <div class="row">
                <div class="col-md-12">
                    <h3>
                        <asp:Label class="page-header" id="CountryNameLbl" runat="server" ></asp:Label></h3>
                </div>
            </div>
            <div class="row">
                <div class="col-md-9">
                    <h4>
                        <label class="page-header" style="font-weight:normal">COUNTRY DIVISIONS</label></h4>
                </div>
                <div class="col-md-2 page-header ">
                    <asp:Button ID="LinkButton1" runat="server" CommandName="new" Text="Add New Division" class="btn btn-success" OnClick="NewDivision_Click" />

                </div>
            </div>
            <div class="row">
                <div class="col-md-11">
                    <table class="table table-condensed table-striped table-data">
                        <tr>
                            <th>Sr#</th>
                            <th>Division Name</th>
                            <th>Division Type</th>
                            <th>Is Active</th>
                            <th>Action</th>
                        </tr>
                        <asp:ListView ID="DivisionLv" runat="server"
                            OnItemEditing="DivisionItemEditing"
                            OnItemInserting="DivisionItemInserting"
                            OnItemCanceling="DivisionItemCanceling"
                            OnItemUpdating="DivisionItemUpdating"
                            OnItemDataBound="ItemDataBound"
                            OnItemCreated="ItemCreated">

                            <ItemTemplate>
                                <tr>

                                    <asp:HiddenField ID="HidDivisionId" runat="server" Value='<%#Bind("CountryDivisionId")%>' />
                                    <td class="itemCent">
                                        <asp:Label ID="SrNo" runat="server" Text='<%#Container.DataItemIndex + 1%> '></asp:Label></td>
                                    <td class="itemLeft">
                                        <asp:Label ID="DescriptionTxt" runat="server" Text='<%#Bind("CountryDivisionName")%>'></asp:Label></td>
                                    <td class="itemLeft">
                                        <asp:Label ID="Label5" runat="server" Text='<%#Bind("CountryDivisionType")%>'></asp:Label></td>
                                    <td class="itemLeft">
                                        <asp:Label ID="Label1" runat="server" Text='<%#(Convert.ToInt32(Eval("IsActive"))==1)?"Yes":"No"%>'></asp:Label></td>
                                    <td class="itemCent">
                                        <asp:LinkButton ID="editImageButton" class="btn btn-success" runat="server" CommandName="edit"
                                            ToolTip="Edit"><span class="glyphicon glyphicon-pencil"></span></asp:LinkButton>
                                    </td>
                                </tr>
                            </ItemTemplate>

                            <EditItemTemplate>
                                <tr>
                                    <td colspan="7">
                                        <table class="table table-condensed table-data">
                                            <asp:HiddenField ID="HidDivisionId" runat="server" Value='<%#Bind("CountryDivisionId")%>' />
                                            <asp:HiddenField ID="HidDivisionTypeId" runat="server" Value='<%#Bind("CountryDivisionTypeId")%>' />
                                            <asp:HiddenField ID="HidIsActive" runat="server" Value='<%#Bind("IsActive")%>' />
                                            <tr>
                                                <td class="table-data">
                                                    <asp:Label runat="server">Division Name</asp:Label></td>
                                                <td>
                                                    <asp:TextBox ID="DivisionNameTxt" class="form-control control-txt" runat="server" Text='<%#Bind("CountryDivisionName")%>'></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label runat="server">Division Type</asp:Label></td>
                                                <td>
                                                    <asp:DropDownList ID="DivisionTypeDDL" class="form-control control-txt" runat="server">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label runat="server">Active</asp:Label></td>
                                                <td>
                                                    <asp:DropDownList ID="IsActiveDDL" class="form-control control-txt" runat="server">
                                                        <asp:ListItem Value="1">Yes</asp:ListItem>
                                                        <asp:ListItem Value="0">No</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>

                                            <tr>
                                                <td colspan="3">
                                                    <asp:LinkButton ID="cancelImageButton" class="btn btn-success" runat="server" CommandName="cancel"
                                                        ToolTip="Cancel"><span class="glyphicon glyphicon-arrow-left"></span></asp:LinkButton>
                                                    <asp:LinkButton class="btn btn-success" ID="saveImageButton" runat="server" CommandName="update"
                                                        ToolTip="Save" ValidationGroup="Group1"><span class="glyphicon glyphicon-floppy-disk"></span></asp:LinkButton>

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
                                                    <asp:Label runat="server">Division Name</asp:Label></td>
                                                <td>
                                                    <asp:TextBox ID="DivisionNameTxt" class="form-control control-txt" runat="server"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label runat="server">Division Type</asp:Label></td>
                                                <td>
                                                    <asp:DropDownList ID="DivisionTypeDDL" class="form-control control-txt" runat="server">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label runat="server">Active</asp:Label></td>
                                                <td>
                                                    <asp:DropDownList ID="IsActiveDDL" class="form-control control-txt" runat="server">
                                                        <asp:ListItem Value="1">Yes</asp:ListItem>
                                                        <asp:ListItem Value="0">No</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>

                                            <tr>

                                            <tr>
                                                <td colspan="3">
                                                    <asp:LinkButton ID="LinkButton2" class="btn btn-success" runat="server" CommandName="cancel"
                                                        ToolTip="Cancel"><span class="glyphicon glyphicon-arrow-left"></span></asp:LinkButton>
                                                    <asp:LinkButton class="btn btn-success" ID="LinkButton3" runat="server" CommandName="insert"
                                                        ToolTip="Save" ValidationGroup="Group1"><span class="glyphicon glyphicon-floppy-disk"></span></asp:LinkButton>

                                                </td>
                                            </tr>
                                        </table>
                                    </td>

                                </tr>
                            </InsertItemTemplate>
                            <EmptyDataTemplate>
                                <tr>
                                    <td colspan="4" class="altCent" align="center">No Data Found</td>
                                </tr>
                            </EmptyDataTemplate>
                        </asp:ListView>

                        <tr>
                            <td align="left" colspan="4">
                                <asp:ValidationSummary ID="ValidationSummary1"
                                    HeaderText="You must enter a value in the following fields:"
                                    DisplayMode="BulletList"
                                    EnableClientScript="true"
                                    ShowSummary="true"
                                    runat="server" ValidationGroup="Group1" ForeColor="#FF3300" />
                            </td>
                        </tr>
                    </table>


                </div>
            </div>
        </div>

    </div>
    <div id="CityDiv">
        <div class="container container-fluid">
            <div class="row">
                <div class="col-md-9">
                    <h4>
                        <label class="page-header" style="font-weight:normal">CITIES</label></h4>
                </div>
                <div class="col-md-2 page-header ">
                    <asp:Button ID="Button1" runat="server" CommandName="new" Text="Add New City" class="btn btn-success" OnClick="NewCity_Click" />
                </div>
            </div>
            <div class="row">
                <div class="col-md-11">
                    <table class="table table-condensed table-striped table-data">
                        <tr>
                            <th>Sr#</th>
                            <th>City</th>
                            <th>Division</th>
                            <th>Is Active</th>
                            <th>Action</th>
                        </tr>
                        <asp:ListView ID="CityLv" runat="server"
                            OnItemEditing="ItemEditing"
                            OnItemInserting="ItemInserting"
                            OnItemCanceling="ItemCanceling"
                            OnItemUpdating="ItemUpdating"
                            OnItemDataBound="ItemDataBound"
                            OnItemCreated="ItemCreated">


                            <ItemTemplate>
                                <tr>

                                    <asp:HiddenField ID="HiddenField1" runat="server" Value='<%#Bind("CityId")%>' />
                                    <td class="itemCent">
                                        <asp:Label ID="Label2" runat="server" Text='<%#Container.DataItemIndex + 1%> '></asp:Label></td>
                                    <td class="itemLeft">
                                        <asp:Label ID="Label3" runat="server" Text='<%#Bind("CityName")%>'></asp:Label></td>
                                    <td class="itemLeft">
                                        <asp:Label ID="Label6" runat="server" Text='<%#Bind("CountryDivisionName")%>'></asp:Label></td>
                                    <td class="itemLeft">
                                        <asp:Label ID="Label4" runat="server" Text='<%#(Convert.ToInt32(Eval("IsActive"))==1)?"Yes":"No"%>'></asp:Label></td>
                                    <td class="itemCent">
                                        <asp:LinkButton ID="LinkButton4" class="btn btn-success" runat="server" CommandName="edit"
                                            ToolTip="Edit"><span class="glyphicon glyphicon-pencil"></span></asp:LinkButton>
                                    </td>
                                </tr>
                            </ItemTemplate>

                            <EditItemTemplate>
                                <tr>
                                    <td colspan="7">
                                        <table class="table table-condensed table-data">
                                            <asp:HiddenField ID="HidCityId" runat="server" Value='<%#Bind("CityId")%>' />
                                            <asp:HiddenField ID="HidDivisionId" runat="server" Value='<%#Bind("CountryDivisionId")%>' />
                                            <asp:HiddenField ID="HidIsActive" runat="server" Value='<%#Bind("IsActive")%>' />
                                            <tr>
                                                <td class="table-data">
                                                    <asp:Label runat="server">City</asp:Label></td>
                                                <td>
                                                    <asp:TextBox ID="CityNameTxt" class="form-control control-txt" runat="server" Text='<%#Bind("CityName")%>'></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label runat="server">Active</asp:Label></td>
                                                <td>
                                                    <asp:DropDownList ID="DivisionDDL" class="form-control control-txt" runat="server">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label runat="server">Active</asp:Label></td>
                                                <td>
                                                    <asp:DropDownList ID="IsActiveDDL" class="form-control control-txt" runat="server">
                                                        <asp:ListItem Value="1">Yes</asp:ListItem>
                                                        <asp:ListItem Value="0">No</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>

                                            <tr>
                                                <td colspan="3">
                                                    <asp:LinkButton ID="LinkButton5" class="btn btn-success" runat="server" CommandName="cancel"
                                                        ToolTip="Cancel"><span class="glyphicon glyphicon-arrow-left"></span></asp:LinkButton>
                                                    <asp:LinkButton class="btn btn-success" ID="LinkButton6" runat="server" CommandName="update"
                                                        ToolTip="Save" ValidationGroup="Group1"><span class="glyphicon glyphicon-floppy-disk"></span></asp:LinkButton>

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
                                                    <asp:Label runat="server">Country</asp:Label></td>
                                                <td>
                                                    <asp:TextBox ID="CityNameTxt" class="form-control control-txt" runat="server"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label runat="server">Division</asp:Label></td>
                                                <td>
                                                    <asp:DropDownList ID="DivisionDDL" class="form-control control-txt" runat="server">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label runat="server">Active</asp:Label></td>
                                                <td>
                                                    <asp:DropDownList ID="IsActiveDDL" class="form-control control-txt" runat="server">
                                                        <asp:ListItem Value="1">Yes</asp:ListItem>
                                                        <asp:ListItem Value="0">No</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>

                                            <tr>

                                            <tr>
                                                <td colspan="3">
                                                    <asp:LinkButton ID="LinkButton7" class="btn btn-success" runat="server" CommandName="cancel"
                                                        ToolTip="Cancel"><span class="glyphicon glyphicon-arrow-left"></span></asp:LinkButton>
                                                    <asp:LinkButton class="btn btn-success" ID="LinkButton8" runat="server" CommandName="insert"
                                                        ToolTip="Save" ValidationGroup="Group1"><span class="glyphicon glyphicon-floppy-disk"></span></asp:LinkButton>

                                                </td>
                                            </tr>
                                        </table>
                                    </td>

                                </tr>
                            </InsertItemTemplate>
                            <EmptyDataTemplate>
                                <tr>
                                    <td colspan="4" class="altCent" align="center">No Data Found</td>
                                </tr>
                            </EmptyDataTemplate>
                        </asp:ListView>

                        <tr>
                            <td align="left" colspan="4">
                                <asp:ValidationSummary ID="ValidationSummary2"
                                    HeaderText="You must enter a value in the following fields:"
                                    DisplayMode="BulletList"
                                    EnableClientScript="true"
                                    ShowSummary="true"
                                    runat="server" ValidationGroup="Group1" ForeColor="#FF3300" />
                            </td>
                        </tr>
                    </table>


                </div>
            </div>
        </div>
    </div>
</asp:Content>
