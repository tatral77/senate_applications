<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Rpt_17b_Deputation.aspx.cs" Inherits="EstablishmentASP.Reports.Rpt_17b_Deputation" %>

<!DOCTYPE html>
<head>
    <title></title>
     <script src="../Scripts/bootstrap.min.js" type="text/javascript"></script>
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
    <link href="../Content/bootstrap-theme.min.css" rel="stylesheet" />
    <link href="../Styles/jquery-ui-1.10.4.custom.css" rel="stylesheet" />
    <link href="../Styles/MainStyles.css" rel="stylesheet" />
    <link href="../Styles/modern.css" rel="stylesheet" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
</head>
<body>
     <form runat="server">   
         <br /><br />
<div class="container-fluid"> <asp:Button class="btn btn-custom" ID="PrintBtn" runat="server" Text="Print" OnClientClick = "return PrintPanel();"/>
<input type="button" class="btn btn-custom" value="Export PDF" onclick="return ExportPdf();" />      </div>         
<asp:Panel id="pnlContents" runat = "server">
<div class="regularDiv report-ui">   
    <div class="container-fluid">
    <h4 class="page-header">
<asp:Label ID="FName" runat="server"></asp:Label>
</h4>
    <table class="table table-data table-condensed" style="width:700px">
      <tr>
            <td><label class="control-lbl-sm" for="title">Date of Birth:</label></td>
            <td><asp:Label ID="DOB" runat="server"></asp:Label></td>
      </tr>
        <tr>
            <td><label class="control-lbl-sm" for="title">Age:</label></td>
            <td><asp:Label ID="Age" runat="server"></asp:Label></td>
      </tr>
          
           <tr>
            <td>
                <label class="control-lbl-sm" for="title">Current Designation:</label></td>
            <td><asp:Label ID="CurrentDesignation" runat="server"></asp:Label></td>
           </tr>

          <tr>
            <td><label class="control-lbl-sm" for="title">Current BPS:</label></td>
            <td><asp:Label ID="bps" runat="server"></asp:Label></td>
           </tr>
       
         <tr>
            <td>
                <label class="control-lbl-sm" for="title">Employee Branch:</label></td>
            <td><asp:Label ID="CurrentBranch" runat="server"></asp:Label></td>
         </tr>

        <tr>
            <td>
                <label class="control-lbl-sm" for="title">Employee Status:</label></td>
            <td><asp:Label ID="EmployeeStatus" runat="server"></asp:Label></td>
        </tr>
           <tr>
            <td runat="server" visible="false" id="supertr">
                <label class="control-lbl-sm" for="title">Superannuation Date:</label></td>
         <td>
                 <asp:Label ID="SuperantuationDate" runat="server"></asp:Label></td>
         </tr>
       

         <tr>
            <td>
                <label class="control-lbl-sm" for="title">Senate Service Start Date:</label></td>
         <td>
                 <asp:Label ID="SenateServiceStartDate" runat="server"></asp:Label></td>
         </tr>
        
         <tr>
            <td>
                <label class="control-lbl-sm" for="title">Total Service in Senate:</label></td>
         <td>
                 <asp:Label ID="HouseService" runat="server"></asp:Label></td>
         </tr>
       
        
        
</table>
   
<div class="row">
    <div class="col-md-12">
            <div class="col-md-9">
                <label class="page-header page-title">EMPLOYMENT</label>
                </div>
          </div>
    <table class="table table-hover table-striped table-data rpt-fixed">
    <thead style="text-align:center">
       <tr>
            <th style="width:3%">Sr#</th>
           <th style="width:9%">Ref. Id</th>
           <th style="width:10%">Empl-Type</th>
           <th style="width:10%">Contract Type</th>
            <th style="width:10%">Post</th>
            <th style="width:5%">BPS</th>
            <th style="width:5%">Post Status</th>
            <th style="width:5%">Gazetted</th>
           <th style="width:6%">Empl-From</th>
           <th style="width:6%">Empl-To</th>
           <th style="width:5%">Current Status</th>
           <th style="width:6%">Status Date</th>
            <th style="width:20%">Details</th>
           
      </tr>
    </thead>
    <tbody>

   <asp:ListView ID="OtherEmploymentLV" runat="server">
    <ItemTemplate>
    <tr>
                        <td class="itemCent">
                           
                            <asp:Label ID="Label3" runat="server" class="table-data" Text='<%#Container.DataItemIndex + 1%> ' />
                        </td>
                         <td>                    
                        <asp:Label ID="Label10" class="table-data" runat="server" Text='<%#Eval("EmploymentHistoryId")%>' />
                        </td>
                         <td>                    
                        <asp:Label ID="Label14" class="table-data" runat="server" Text='<%#Eval("EmploymentStatus")%>' />
                        </td>
                        <td>                    
                        <asp:Label ID="Label13" class="table-data" runat="server" Text='<%#Eval("Quota")%>' />
                        </td>
                        <td>                    
                        <asp:Label ID="Label2" class="table-data" runat="server" Text='<%#Eval("Post")%>' />
                        </td>
                        <td>
                           <asp:Label ID="Label6" class="table-data" runat="server" Text='<%#Eval("BPS")%>' />
                        </td>
                         <td>
                           <asp:Label ID="DateLabel" class="table-data" runat="server" Text='<%#Eval("PostStatus")%>' />
                        </td>
                        <td>
                    
                           <asp:Label ID="Label5" class="table-data" runat="server" Text='<%#(Convert.ToString(Eval("IsGazetted"))=="1")?"Yes":"No"%>' />
                        </td>
                       
                      
                        <td>
                           <asp:Label ID="Label1" class="table-data" runat="server" Text='<%#GetDate(Convert.ToDateTime(Eval("EmploymentStatusDate")))%>' />
                        </td>
                        <td>
                           <asp:Label ID="Label15" class="table-data" runat="server" Text='<%#GetDate(Convert.ToDateTime(Eval("ToDate")))%>' />
                        </td>
                       <%-- <td>
                           <asp:Label ID="Label16" class="table-data" runat="server" Text='<%#Eval("Details")%>' />
                        </td>--%>
                       
                         <td>
                           <asp:Label ID="Label9" class="table-data" runat="server" Text='<%#Eval("CurrentStatus")%>' />
                        </td>
                        <td>
                           <asp:Label ID="Label7" class="table-data" runat="server" Text='<%#GetDate(Convert.ToDateTime(Eval("CurrentStatusDate")))%>' />
                        </td>
                        <td>
                           <asp:Label ID="Label17" class="table-data" runat="server" Text='<%#Eval("Remarks")%>' />
                        </td>
                   

    </tr>
       </ItemTemplate>
  </asp:ListView>
        </tbody>
        </table>          
</div>
    
   
 <div class="row">            
            <div class="col-md-9">
                <label class="page-header page-title-Medium">EXTENSION DETAILS</label>
                </div>
          </div>
    <div id="contract">
    <table class="table table-hover table-striped table-data rpt-fixed">
    <thead style="text-align:center">
       <tr>
            <th style="width:8%">Sr#</th>
           <th style="width:24%">Ref. Id</th>
           
           <th style="width:18%">Extended To</th>
             <th style="width:50%">Details</th>
             </tr>
    </thead>
    <tbody>
      <asp:ListView ID="ExtensionLV" runat="server">

     
    <ItemTemplate>
    <tr>
                        <td class="itemCent">
                            <asp:HiddenField ID="HidExtensionId" runat="server" Value='<%#Bind("ExtensionId") %>' />
                            <asp:Label ID="Label3" runat="server" class="table-data" Text='<%#Container.DataItemIndex + 1%> ' />
                        </td>
                          <td>                    
                        <asp:Label ID="Label11" class="table-data" runat="server" Text='<%#Eval("EmploymentHistoryId") %>' />
                        </td>
                       
                        <td>                    
                        <asp:Label ID="Label2" class="table-data" runat="server" Text='<%#GetDate(Convert.ToDateTime(Eval("ExtendedTo")))%>' />
                        </td>
                         
                         <td>
                           <asp:Label ID="Label8" class="table-data" runat="server" Text='<%#Bind("Remarks")%>' />
                        </td>
                       
                        
                         <td>
                                <asp:LinkButton ID="editImageButton" class="btn btn-custom" runat="server"  CommandName="edit"
                                 ToolTip="Edit"><span class="glyphicon glyphicon-pencil"></span></asp:LinkButton>
                                <asp:LinkButton ID="deleteImageButton" class="btn btn-custom" runat="server"  CommandName="delete"
                                 ToolTip="Delete" OnClientClick="return confirm('Are you sure you want to delete therecord ?');"><span class="glyphicon glyphicon-erase"></span></asp:LinkButton>
                        </td>

    </tr>
       </ItemTemplate>
   
 
    
          
    <EmptyDataTemplate>
             <tr>
                     <td>
                         <b>No probation details found.</b>                            

                    </td>
             </tr>
        </EmptyDataTemplate>
    </asp:ListView>                   

   
   
        </tbody>

    </table>
        
</div>    

 </div>
    

    </div>
</asp:Panel>

   

      <script src='<%= ResolveUrl("~/Scripts/hrmprint.js") %>' type="text/javascript"></script>
    <script type="text/javascript">
       function PrintPanel() {
           return HRMPrint.print("<%=pnlContents.ClientID %>", { title: ("DEPUTATION DETAILS - " + ((document.getElementById("<%=FName.ClientID %>") || {}).innerText || "")).replace(/\s+/g, " ").trim() });
       }
       function ExportPdf() {
           return HRMPrint.exportPdf("<%=pnlContents.ClientID %>", { title: ("DEPUTATION DETAILS - " + ((document.getElementById("<%=FName.ClientID %>") || {}).innerText || "")).replace(/\s+/g, " ").trim() });
       }
    </script> 
             </form>
</body>
