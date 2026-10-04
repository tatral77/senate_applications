<%@ Page Title="" Language="C#" MasterPageFile="~/MainMaster.Master" AutoEventWireup="true" CodeBehind="EmpPosts.aspx.cs" Inherits="EstablishmentASP.EmpPosts" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Styles/MainStyles.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="container container-fluid">
    <div class="row">
        <div class="col-md-12 page-header">
                <h4>POSTS</h4>
        </div>
     </div>
    
     <div class="row">
        <div class="col-md-12">
               <asp:Button ID="LinkButton1" runat="server" CommandName="new" Text="Add New" onclick="newLinkButton_Click" class="btn btn-custom" />
        </div>
     </div>
     <div class="row">
        <div class="col-md-12">
               <asp:ValidationSummary ID="ValidationSummary1"
        HeaderText="You must enter a value in the following fields:"
        DisplayMode="BulletList"
        EnableClientScript="true"
        ShowSummary="true"
        runat="server" ValidationGroup="Group1" ForeColor="#FF3300" />
        </div>
     </div>
<table class="table table-hover table-striped table-condensed">
 <thead>
<tr class="top-buffer">
    
<th>Sr#</th>
<%--<th>Post Id</th>--%>
<th>Nomenclature:</th>
<th>Post Type</th>
<th>Gazetted/Non-Gazetted:</th>
<th>Scale From</th>
<th>Scale To</th>
<th>No of Posts</th>
<th>Post Status</th>
<th>Active</th>
<th>No of Employees</th>
<th>Action</th>
</tr>
        </thead>
<asp:ListView ID="PostsLv" runat="server"
OnItemEditing="ItemEditing"
OnItemCanceling="ItemCanceling"
OnItemCreated="ItemCreated"
OnItemDataBound="ItemDataBound"
OnItemInserting="ItemInserting"
OnItemUpdating="ItemUpdating"
GroupPlaceholderID="groupPlaceHolder1"
ItemPlaceholderID="itemPlaceHolder1"
OnPagePropertiesChanging="OnPagePropertiesChanging"
>
  <LayoutTemplate>
    <asp:PlaceHolder runat="server" ID="groupPlaceHolder1"></asp:PlaceHolder>
        <tr>
            <td colspan = "11">
                <asp:DataPager ID="DataPager1" runat="server" PagedControlID="PostsLv" PageSize="50">
                    <Fields>
                        <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="false" ShowPreviousPageButton="true"
                            ShowNextPageButton="false" />
                        <asp:NumericPagerField ButtonType="Button" />
                        <asp:NextPreviousPagerField ButtonType="Button" ShowNextPageButton="true" ShowLastPageButton="false" ShowPreviousPageButton = "false" />
                    </Fields>
                </asp:DataPager>
            </td>
        </tr>
    <GroupTemplate>
    <tr>
        <asp:PlaceHolder runat="server" ID="itemPlaceHolder1"></asp:PlaceHolder>
    </tr>
    </GroupTemplate>
    </LayoutTemplate>
<ItemTemplate>
 <tr>
     <asp:HiddenField ID="HidPostId" runat="server" Value='<%#Bind("PostId")%>' />
    <td class="table-data"><asp:Label ID="SrNo" runat="server" Text='<%#Container.DataItemIndex + 1%> '></asp:Label></td>
  <%--  <td class="table-data"><asp:Label ID="Label6" runat="server" Text='<%#Bind("PostId")%>'></asp:Label></td>--%>
    <td class="table-data"><asp:Label ID="PassportNumber" runat="server" Text='<%#Bind("Description")%>'></asp:Label></td>
    <td class="table-data"><asp:Label ID="IssueDate" runat="server" Text='<%#Bind("PostType")%>'></asp:Label></td>
    <td class="table-data"><asp:Label ID="ValidUpto" runat="server" Text='<%#Bind("GazNonGaz")%>'></asp:Label></td>
    <td class="table-data"><asp:Label ID="IssuePlace" runat="server" Text='<%#Bind("ScaleFrom") %>'></asp:Label></td>
    <td class="table-data"><asp:Label ID="Label2" runat="server" Text='<%#Bind("ScaleTo")%>'></asp:Label></td>
    <td class="table-data"><asp:Label ID="Label1" runat="server" Text='<%#Bind("NumOfPosts")%>'></asp:Label></td>
    <td class="table-data"><asp:Label ID="Label3" runat="server" Text='<%#Bind("PostStatus")%>'></asp:Label></td>
    <td class="table-data"><asp:Label ID="Label5" runat="server" Text='<%#GetStatus(Convert.ToInt32(Eval("Is_Active")))%>'></asp:Label></td>
    <td class="table-data"><asp:Label ID="Label7" runat="server" Text='<%#Bind("NumOfEmp")%>'></asp:Label></td>
    
    <td>
                                <asp:LinkButton ID="editImageButton" runat="server" class="btn btn-custom"  CommandName="edit"
                                 ToolTip="Edit" ><span class="glyphicon glyphicon-pencil"></span></asp:LinkButton>
                                
                        </td>
  </tr>

</ItemTemplate>

<EditItemTemplate>
            <tr>
                <td colspan="11">
                <asp:HiddenField ID="HidPostId" runat="server" Value='<%#Bind("PostId")%>' />
                <asp:HiddenField ID="HidPostTypeId" runat="server" Value='<%#Bind("PostTypeId")%>' />
                <asp:HiddenField ID="HidGazNonGazId" runat="server" Value='<%#Bind("GazNonGazId")%>' />
                <asp:HiddenField ID="HidPostStatusId" runat="server" Value='<%#Bind("PostStatusId")%>' />
                <asp:HiddenField ID="HidIs_Active" runat="server" Value='<%#Bind("Is_Active")%>' />
                <table class="table table-condensed table-data">
                <tr>
                    <td class="table-data">Nomenclature</td>
                    <td>
                        <asp:TextBox ID="NomenclatureTxt" class="form-control" runat="server" Text='<%#Bind("Description")%>' ></asp:TextBox>
                        <asp:RequiredFieldValidator ID="NomenclatureTxtValidator" Display="Dynamic" Text="*" runat="server" ErrorMessage="Nomenclature" ControlToValidate="NomenclatureTxt" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">Post Type</td>
                    <td>
                        <asp:DropDownList ID="PostTypeDDL" class="form-control" runat="server" AutoPostBack="False" ><asp:ListItem Selected="True" Value="0">Select</asp:ListItem></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="PostTypeValidator" Display="Dynamic" Text="*" runat="server" ErrorMessage="Post Type" ControlToValidate="PostTypeDDL" InitialValue="0" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">Gazetted/Non-Gazetted</td>
                    <td>
                        <asp:DropDownList ID="GazNonGazDDL" class="form-control" runat="server" AutoPostBack="False" ><asp:ListItem Selected="True" Value="0">Select</asp:ListItem></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="GazNonGazDDLValidator" Display="Dynamic" Text="*" runat="server" ErrorMessage="Gazetted/Non Gazetted" ControlToValidate="GazNonGazDDL" InitialValue="0" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">Post Status</td>
                    <td>
                        <asp:DropDownList ID="PostStatusDDL" class="form-control" runat="server" AutoPostBack="False" ><asp:ListItem Selected="True" Value="0">Select</asp:ListItem></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" Display="Dynamic" Text="*" runat="server" ErrorMessage="Post Status" ControlToValidate="PostStatusDDL" InitialValue="0" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">Scale From</td>
                    <td>
                        <asp:TextBox ID="ScaleFromTxt" class="form-control" runat="server" Text='<%#Bind("ScaleFrom")%>' ></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" Display="Dynamic" Text="*" runat="server" ErrorMessage="Scale From" ControlToValidate="ScaleFromTxt" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">Scale To</td>
                    <td>
                        <asp:TextBox ID="ScaleToTxt" class="form-control" runat="server" Text='<%#Bind("ScaleTo")%>' ></asp:TextBox>
                        <asp:RequiredFieldValidator ID="NOCNumberValidator" Display="Dynamic" Text="*" runat="server" ErrorMessage="Scale to" ControlToValidate="ScaleToTxt" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">No of Posts</td>
                    <td>
                        <asp:TextBox ID="NoOfPostsTxt" class="form-control" runat="server" Text='<%#Bind("NumOfPosts")%>' ></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" Display="Dynamic" Text="*" runat="server" ErrorMessage="Number of Posts" ControlToValidate="NoOfPostsTxt" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">Is Active</td>
                    <td>
                        <asp:DropDownList ID="IsActiveDDL" runat="server" class="form-control" AutoPostBack="False" ><asp:ListItem Value="1">Yes</asp:ListItem><asp:ListItem Value="0">No</asp:ListItem></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:LinkButton ID="cancelImageButton" class="btn btn-custom" runat="server" CommandName="cancel" ToolTip="Cancel"><span class="glyphicon glyphicon-arrow-left"></span></asp:LinkButton>
                        <asp:LinkButton ID="saveImageButton" class="btn btn-custom" runat="server" CommandName="Update" ToolTip="Save" ValidationGroup="Group1"><span class="glyphicon glyphicon-floppy-disk"></span></asp:LinkButton>
                    </td>
                </tr>
                </table>
                </td>
            </tr>
        </EditItemTemplate>
<InsertItemTemplate>
            <tr>
                <td colspan="11">
                <table class="table table-condensed table-data">
                <tr>
                    <td class="table-data">Nomenclature</td>
                    <td>
                        <asp:TextBox ID="NomenclatureTxt" class="form-control" runat="server" Text="" ></asp:TextBox>
                        <asp:RequiredFieldValidator ID="NomenclatureTxtValidator" Display="Dynamic" Text="*" runat="server" ErrorMessage="Nomenclature" ControlToValidate="NomenclatureTxt" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">Post Type</td>
                    <td>
                        <asp:DropDownList ID="PostTypeDDL" class="form-control" runat="server" AutoPostBack="False" ><asp:ListItem Selected="True" Value="0">Select</asp:ListItem></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="PostTypeValidator" Display="Dynamic" Text="*" runat="server" ErrorMessage="Post Type" ControlToValidate="PostTypeDDL" InitialValue="0" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">Gazetted/Non-Gazetted</td>
                    <td>
                        <asp:DropDownList ID="GazNonGazDDL" class="form-control" runat="server" AutoPostBack="False" ><asp:ListItem Selected="True" Value="0">Select</asp:ListItem></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="GazNonGazDDLValidator" Display="Dynamic" Text="*" runat="server" ErrorMessage="Gazetted/Non Gazetted" ControlToValidate="GazNonGazDDL" InitialValue="0" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">Post Status</td>
                    <td>
                        <asp:DropDownList ID="PostStatusDDL" class="form-control" runat="server" AutoPostBack="False" ><asp:ListItem Selected="True" Value="0">Select</asp:ListItem></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" Display="Dynamic" Text="*" runat="server" ErrorMessage="Post Status" ControlToValidate="PostStatusDDL" InitialValue="0" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">Scale From</td>
                    <td>
                        <asp:TextBox ID="ScaleFromTxt" class="form-control" runat="server" Text="" ></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" Display="Dynamic" Text="*" runat="server" ErrorMessage="Scale From" ControlToValidate="ScaleFromTxt" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">Scale To</td>
                    <td>
                        <asp:TextBox ID="ScaleToTxt" class="form-control" runat="server" Text="" ></asp:TextBox>
                        <asp:RequiredFieldValidator ID="NOCNumberValidator" Display="Dynamic" Text="*" runat="server" ErrorMessage="Scale to" ControlToValidate="ScaleToTxt" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">No of Posts</td>
                    <td>
                        <asp:TextBox ID="NoOfPostsTxt" class="form-control" runat="server" Text="" ></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" Display="Dynamic" Text="*" runat="server" ErrorMessage="Number of Posts" ControlToValidate="NoOfPostsTxt" ValidationGroup="Group1" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="table-data">Is Active</td>
                    <td>
                        <asp:DropDownList ID="IsActiveDDL" runat="server" class="form-control" AutoPostBack="False" ><asp:ListItem Value="1">Yes</asp:ListItem><asp:ListItem Value="0">No</asp:ListItem></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:LinkButton ID="cancelImageButton" class="btn btn-custom" runat="server" CommandName="cancel" ToolTip="Cancel"><span class="glyphicon glyphicon-arrow-left"></span></asp:LinkButton>
                        <asp:LinkButton ID="saveImageButton" class="btn btn-custom" runat="server" CommandName="Insert" ToolTip="Save" ValidationGroup="Group1"><span class="glyphicon glyphicon-floppy-disk"></span></asp:LinkButton>
                    </td>
                </tr>
                </table>
                </td>
            </tr>
        </InsertItemTemplate>
<EmptyItemTemplate>
<tr>
    <td colspan="11"><label>No Data Found</label></td>
</tr>
</EmptyItemTemplate>


</asp:ListView>
 
</table>
    
   
</div>

</asp:Content>
