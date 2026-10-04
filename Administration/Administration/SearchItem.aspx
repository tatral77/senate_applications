<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" MaintainScrollPositionOnPostback="true" AutoEventWireup="true" CodeBehind="SearchItem.aspx.cs" Inherits="Administration.SearchItem" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link href="./Content/bootstrap-theme.min.css" rel="stylesheet" />
    <script src="Custom/jquery-ui.min.js"></script>
    <link href="Custom/jquery-ui.css.css" rel="stylesheet" />
    <style type="text/css">
        .style2
        {
            font-family: Verdana;
            font-weight: bold;
            font-size: small;
            width: 69px;
        }
        .style3
        {
            width: 69px;
        }
        .top-buffer
        {
            padding-top:5px;
            padding-bottom:5px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <br />
  
            <div class="row">            
                <div class="col-md-4"><h4 style="font-weight:bold">SEARCH ITEMS</h4></div>
                
            </div>
 

                                    <div class="row top-buffer">
                                        <div class="col-md-3">
                                            <asp:Label ID="Label11" class="control-lbl" runat="server" Text="Item Name" />
                                         <asp:TextBox ID="ItemNameTxt" runat="server" ClientIDMode="Static" class="form-control" ></asp:TextBox>
                                        <%--<asp:HiddenField ID="ItemId" runat="server" Value='' />--%>
                                        </div>      
                                                            
                                        <div class="col-md-3">   
                                            <asp:Label ID="Label5" class="control-lbl" runat="server" Text="Category" />           
                                            <asp:DropDownList ID="CategoryDDL" ClientIDMode="Static" class="form-control" runat="server" OnSelectedIndexChanged="CategoryDDL_SelectedIndexChanged" AutoPostBack="true" >
                                            <asp:ListItem Selected="True" Value="0">Select</asp:ListItem>
                                        </asp:DropDownList>
                                        </div>
                                         <div class="col-md-3">  
                                             <asp:Label ID="Label6" class="control-lbl" runat="server" Text="Main Item" />            
                                            <asp:DropDownList ID="MainItemDDL" ClientIDMode="Static" class="form-control" runat="server" OnSelectedIndexChanged="MainItemDDL_SelectedIndexChanged" AutoPostBack="true"   >
                                            <asp:ListItem Selected="True" Value="0">Select</asp:ListItem>
                                        </asp:DropDownList>
                                        </div>
                                        <div class="col-md-3">
                                            <asp:Label ID="Label10" class="control-lbl" runat="server" Text="Item" />
                                            <asp:DropDownList ID="ItemDDL" ClientIDMode="Static" class="form-control" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ItemDDL_SelectedIndexChanged">
                                            <asp:ListItem Selected="True" Value="0">Select</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>                                
                                      
                                    
                                 </div>
                              
                                    <div class="row top-buffer">
                                         <div class="col-md-12" style="text-align:right">
                                                <asp:Button class="btn btn-custom" ID="Button2" runat="server" Text="Search" onclick="Search_Click" />
                                                <asp:Button  class="btn btn-custom" ID="Button1" runat="server" Text="Reset" Onclick="ClearSearch_Click" />
                                            </div>

                                    </div>
       
            
    <br />
  

<%-- <div class="col-md-12">
         <asp:Label ID="CriteriaLbl" runat="server" Text="<b><u>REPORT BASED ON FOLLOWING PARAMETERS</u></b><br>"></asp:Label></div>	--%>
<table class="table table-hover table-striped table-responsive">
    <thead class="thead-inverse">
    <tr>
    <th>Sr#</th>
          <th>Item</th>
           <th>Main Item</th>
           <th>Category</th>
           <th>Current Balance</th>
            <th>Threshold Level</th>
             <th>Action</th>
     
   </tr>
         </thead> 
    <tbody>
    <asp:ListView ID="ListView1"
        OnItemDeleting="ItemDeleting"
         runat="server">
   
    <ItemTemplate>
    <tr>
                        <td>
                            <asp:HiddenField ID="HidItemId" runat="server" Value='<%#Bind("ItemId")%>' />
                            <asp:Label ID="Label3" class="table-data" runat="server" Text='<%#Container.DataItemIndex + 1%> ' />
                        </td>
                         <td>
                             <asp:Label ID="Label4" class="table-data" runat="server" Text='<%#Eval("ItemName")%> ' />
                             <%--<asp:HyperLink ID="HyperLink2"  runat="server" Target="_blank" NavigateUrl='<%#Eval("ItemId","~/ItemInfo.aspx?ItemId={0}")%>' Text='<%#Eval("ItemName") %>' />--%>
                        </td>
                          <td>
                            <asp:HyperLink ID="HyperLink1"  runat="server" Target="_blank" NavigateUrl='<%#Eval("MainItemId","~/ManageItems.aspx?MainItemId={0}")%>' Text='<%#Eval("MainItem") %>' />
                          
                        </td>
                         <td>
                            <asp:HyperLink  ID="HyperLink3"  runat="server" NavigateUrl='<%#Eval("CategoryId","~/ManageMainItems.aspx?CategoryId={0}")%>'><%#Eval("Category").ToString()%></asp:HyperLink>
                             
                        </td>
                         <td>
                            <asp:Label ID="Label1"   runat="server" Text='<%#Eval("CurrentBalance")%>' />
                             
                        </td>
        <td>
                            <asp:Label ID="Label2" class="table-data" runat="server" Text='<%#Eval("ThresholdLevel")%>' />
                             
                        </td>
          <td class="itemCent">
                                  
                                    <asp:LinkButton ID="deleteImageButton" class="btn btn-custom" runat="server"  CommandName="delete"
                                 ToolTip="Delete" OnClientClick="return confirm('Are you sure you want to delete record ?');"><span class="glyphicon glyphicon-erase"></span></asp:LinkButton>
                                </td>
                       
                         
                        
      </tr>
    </ItemTemplate>
  
    </asp:ListView>
        </tbody>
    </table>
            
    
    <script type="text/javascript">
          $(function () {
            $("[id$=EmployeeNameTxt]").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: '<%=ResolveUrl("~/AutomationService.asmx/GetEmployeeName") %>',
                        data: "{ 'prefix': '" + request.term + "'}",
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        success: function (data) {
                            response($.map(data.d, function (item) {
                                return {
                                    label: item.split('-')[0],
                                    val: item.split('-')[1],
                                    val2: item.split('-')[2]
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
                    $("[id$=HidSystemUserId]").val(i.item.val);
                    $("[id$=HidPostId]").val(i.item.val2);
                },
                minLength: 1
            });
        });
    </script>

</asp:Content>
