<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="SearchQuestion.aspx.cs" Inherits="QuestionManagement.SearchQuestion" %>

<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
       <meta name="viewport" content="width=device-width, initial-scale=1">
   <%-- <link href="Styles/SearchList.css" rel="stylesheet" type="text/css" />
    <link href="Styles/Pages.css" rel="stylesheet" type="text/css" />--%>
    <link href="Styles/MainStyles.css" rel="stylesheet" />
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
    </style>
    <script>
        jQuery(document).ready(function () {
           
            jQuery('#search').on('click', function (event) {
                event.preventDefault();
                
            });
        });
      
</script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
     
    <div class="container">
    <div class="row">
            
            <div class="col-md-8"><h4 style="font-weight:bold">SEARCH QUESTIONS</h4></div>
        <div class="col-md-4"><button id="search" class="btn btn-primary" data-toggle="modal" data-target="#myModal">Search Question</button>
            <asp:Button class="btn btn-primary" ID="ClearSearch" runat="server" Text="Clear Search Results" onclick="ClearSearch_Click" />
           
        </div>
    </div>
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
 
     

    <div id="myModal" class="modal fade in"" role="dialog">
                    <div class="modal-dialog modal-lg">
                        <!-- Modal content-->
                      
                        <div class="modal-content">
                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal">&times;</button>
                                <h4 class="modal-title">Search Question</h4>
                            </div>
                            <div class="modal-body">
                                
                                <div class="container-fluid">
                                    <div class="row">
                                         <div class="col-xs-12">
                                         <label class="control-label" for="MemberDDL">Member:</label>
                                        <asp:DropDownList ID="MemberDDL" class="form-control" runat="server">
                                            <asp:ListItem Selected="True" Value="0">Select</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    </div>
                                <div class="row"> 
                                     <asp:UpdatePanel ID="UpdatePanel2" runat="server">
 	                                 <ContentTemplate>
                                     <div class="col-xs-4">              
                                         <label class="control-label" for="AssemblySessionDDL">Session No:</label>
                                         <asp:DropDownList ID="AssemblySessionDDL" class="form-control" runat="server" AutoPostBack="true" OnSelectedIndexChanged="SessionDDL_SelectedIndexChanged">
                                            <asp:ListItem Selected="True" Value="0">Select</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                     <div class="col-xs-4">
                                          
                                         <label class="control-label" for="GroupsDDL">Group:</label>    
                                                   
                                         <asp:DropDownList ID="GroupsDDL"  class="form-control" runat="server">
                                            <asp:ListItem Selected="True" Value="0">Select</asp:ListItem>
                                        </asp:DropDownList>
                                             
                                    </div>
                                    
                                  </ContentTemplate></asp:UpdatePanel>  
                                

                                <div class="row">
                                      <div class="col-xs-4">
                                        <label class="control-label" for="CategoryDDL">Category:</label>
                                        <asp:DropDownList ID="CategoryDDL" class="form-control" runat="server">
                                            <asp:ListItem Selected="True" Value="0">Select</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div> 
                                   <div class="row top-buffer">
                                     <div class="col-xs-4">
                                        <label class="control-label" for="QuestionDiaryNoTxt">Question Diary No:</label>
                                        <asp:TextBox ID="QuestionDiaryNoTxt" runat="server" class="form-control"></asp:TextBox>
                                    </div>
                                    <div class="col-xs-4">
                                         <label class="control-label" for="HouseAffiliationDDL">House Affiliation:</label>               
                                         <asp:DropDownList ID="HouseAffiliationDDL"  class="form-control" runat="server">
                                            <asp:ListItem Selected="True" Value="0">Select</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    
                                    <div class="col-xs-4">
                                        <label class="control-label" for="QuestionStatusDDL">Question Status:</label>
                                        <asp:DropDownList ID="QuestionStatusDDL" runat="server" class="form-control">
                                            <asp:ListItem Selected="True" Value="0">Select</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    </div>
                                   <div class="row top-buffer">
                                     <div class="col-xs-4">
                                        <label class="control-label" for="DateFromTxt">Date From:</label>
                                        <asp:TextBox ID="DateFromTxt" runat="server" class="form-control"></asp:TextBox>
                                    </div>
                                    <div class="col-xs-4">
                                        <label class="control-label" for="DateToTxt">Date To:</label>
                                        <asp:TextBox ID="DateToTxt" runat="server" class="form-control"></asp:TextBox>
                                    </div>
                                        <div class="col-xs-4">
                                        <label class="control-label" for="KeywordsTxt">Keywords:</label>
                                        <asp:TextBox ID="KeywordsTxt" runat="server" class="form-control"></asp:TextBox>
                                    </div>
                                   
                                </div>   
                             
                                   
                                  
             </div>               
            </div>
        <div class="modal-footer">
            <asp:Button class="btn btn-primary" ID="Button2" runat="server" Text="Search" onclick="Search_Click" />
            <button id="Cancel" class="btn btn-primary" data-dismiss="modal">Cancel</button>
           
      </div>
                         </div>
 
 </div>
  </div>
        </div>
              


    <div class="clearfix"></div>
 <div class="col-md-12">
         <asp:Label ID="CriteriaLbl" runat="server" Text="<b><u>REPORT BASED ON FOLLOWING PARAMETERS</u></b><br>"></asp:Label></div>	
<table class="table table-hover table-striped table-responsive">
    <%--<tr><th colspan="8" style="text-align:center">LIST OF EMPLOYEES</th></tr>--%>
    <thead class="thead-inverse">
    <tr>
    <th>Sr#</th>
    <th>Diary No</th>
     <th>Subject Matter</th>
      <th>Date</th>
       <th>Category</th>
        <th>Submitted By</th>
         <th>Status</th>
        <th>
            <asp:CheckBox ID="SelectAll" runat="server" /></th>
        <th>Action</th>
   </tr>
         </thead> 
    <tbody>
    <asp:ListView ID="ListView1" runat="server">
   
    <ItemTemplate>
    <tr>
                        <td>
                            
                            <asp:Label ID="Label3" class="table-data" runat="server" Text='<%#Container.DataItemIndex + 1%> ' />
                        </td>
                        <td>
                            <asp:Label ID="Label4" class="table-data" runat="server" Text='<%#Bind("QuestionDiaryNo")%>' />
                        </td>
                         
                        <td>
                            <asp:HiddenField ID="idHiddenField" runat="server" Value='<%#Bind("QuestionsId")%>' />
                           <asp:HyperLink class="table-data" ID="HyperLink1" runat="server" NavigateUrl='<%#Eval("QuestionsId","~/QuestionDetails.aspx?questionsId={0}")%>'><%#Eval("Subject")%></asp:HyperLink>
                        </td>
                         <td nowrap>
                            <asp:Label ID="Label6" class="table-data" runat="server" Text='<%#GetDate(Convert.ToDateTime(Eval("QuestionDate")))%>' />
                        </td>
                        <td >
                            <asp:Label ID="Label5" class="table-data" runat="server"  Text='<%#Bind("QuestionCategory")%>' />
                        </td>
                        <td>
                            <asp:Label ID="rankLabel" class="table-data" runat="server" Text='<%#Bind("MoverName")%>'></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="descriptionLabel" class="table-data" runat="server" Text='<%#Bind("QuestionStatus")%>' />
                        </td>
                        <td>
                            <asp:CheckBox ID="SelectCB" runat="server" />
                        </td>
                        <td>
                            <asp:HyperLink ID="PrintHL" runat="server" NavigateUrl='<%#Eval("QuestionsId","~/PrintQuestion.aspx?questionsId={0}")%>' Text="Print" CssClass="btn btn-primary"/>
                        </td>
                      
                        
      </tr>
    </ItemTemplate>
  
    </asp:ListView>
        </tbody>
    </table>
  </div>   
</asp:Content>
