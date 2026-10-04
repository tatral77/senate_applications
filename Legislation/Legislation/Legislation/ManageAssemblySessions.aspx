<%@ Page Title="" Language="C#" MasterPageFile="~/site1.Master" AutoEventWireup="true" CodeBehind="ManageAssemblySessions.aspx.cs" Inherits="QuestionManagement.ManageAssemblySessions" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="col-md-6">
        <div class="page-header"><h4>Manage Sessions</h4></div>
       
         <div class="row top-buffer">
             <div class="col-md-6" style="font-weight:bold"><asp:Label ID="Label6" runat="server" lablefor="LegislativeYear" Text="Legislative Year:" />
            <asp:Label ID="LegislativeYear" runat="server" Text="Session" />
                 <asp:HiddenField ID="HidParliamentaryYearId" runat="server" />
             </div>
        </div>

        <div class="row top-buffer">
             <div class="col-md-6" style="font-weight:bold"><asp:Label ID="lbl" runat="server" lablefor="HidAssemblySessionId" Text="Session No:" />
            <asp:Label ID="AssemblySessionLbl" runat="server" Text="" />
                 <asp:HiddenField ID="HidAssemblySessionId" runat="server" />
             </div>
        </div>
        <div class="row top-buffer">
             <div class="col-md-6"><asp:Label ID="Label2" lablefor="CalledByDDL" runat="server" Text="Session Type" />
            <asp:DropDownList ID="CalledByDDL" CssClass="form-control" runat="server">
                                    <asp:ListItem Value="0">Select</asp:ListItem>
                                    <asp:ListItem Value="Government">Government</asp:ListItem>
                                    <asp:ListItem Value="Requisition">Requisition</asp:ListItem>
            </asp:DropDownList></div>    
          </div>
         
            <div class="row top-buffer">
             <div class="col-md-6"><asp:Label ID="Label7" lablefor="CalledByDDL" runat="server" Text="Questions" Required="true" />
            <asp:DropDownList ID="BusinessDDL" AutoPostBack="true" CssClass="form-control" runat="server" OnSelectedIndexChanged="BusinessDDL_SelectedIndexChanged">
                                    <asp:ListItem Value="0">Select</asp:ListItem>
                                    <asp:ListItem Value="1">Carry Forward</asp:ListItem>
                                    <asp:ListItem Value="2">Lapse</asp:ListItem>
            </asp:DropDownList>
                  <asp:RequiredFieldValidator ID="rfvCategoryDDL" runat="server"  ErrorMessage="Select Questions Lapse/Carry Forward" ValidationGroup="SaveGroup" Display="None" InitialValue="0" ControlToValidate="BusinessDDL"></asp:RequiredFieldValidator> 
             </div>   
                  
          </div>
              <div class="row top-buffer">
             <div class="col-md-6"><asp:Label ID="Label8" lablefor="CalledByDDL" runat="server" Text="Motions" Required="true" />
            <asp:DropDownList ID="MotionsDDL" AutoPostBack="true" CssClass="form-control" runat="server" OnSelectedIndexChanged="BusinessDDL_SelectedIndexChanged">
                                    <asp:ListItem Value="0">Select</asp:ListItem>
                                    <asp:ListItem Value="1">Carry Forward</asp:ListItem>
                                    <asp:ListItem Value="2">Lapse</asp:ListItem>
            </asp:DropDownList>
                  <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"  ErrorMessage="Select Motions Lapse/Carry Forward" ValidationGroup="SaveGroup" Display="None" InitialValue="0" ControlToValidate="MotionsDDL"></asp:RequiredFieldValidator>
             </div>    
                    
          </div>
              <div class="row top-buffer">
             <div class="col-md-6"><asp:Label ID="Label9" lablefor="CalledByDDL" runat="server" Text="Resolutions" Required="true" />
            <asp:DropDownList ID="ResolutionsDDL" AutoPostBack="true" CssClass="form-control" runat="server" OnSelectedIndexChanged="BusinessDDL_SelectedIndexChanged">
                                    <asp:ListItem Value="0">Select</asp:ListItem>
                                    <asp:ListItem Value="1">Carry Forward</asp:ListItem>
                                    <asp:ListItem Value="2">Lapse</asp:ListItem>
            </asp:DropDownList>
                  <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"  ErrorMessage="Select Resolution Lapse/Carry Forward" ValidationGroup="SaveGroup" Display="None" InitialValue="0" ControlToValidate="ResolutionsDDL"></asp:RequiredFieldValidator>
             </div>    
          </div>
          <%--    <div class="row top-buffer">
             <div class="col-md-6"><asp:Label ID="Label5" lablefor="CalledByDDL" runat="server" Text="Select Business to be Carry forwarded or Lapsed" /><br />
                 <asp:CheckBox ID="QuestionCB" runat="server" Text="Question" Checked="true" /><br />
                 <asp:CheckBox ID="MotionCB" runat="server" Text="Motion" /><br />
                 <asp:CheckBox ID="ResolutionCB" runat="server" Text="Resolution" />


             </div>    
          </div> --%>
          <div class="row top-buffer" id="BusinessSessionsdiv" runat="server">
             <div class="col-md-6"><asp:Label ID="Label1" lablefor="CalledByDDL" runat="server" Text="Carry Forward Business Sessions" />
                 <br />
                <asp:Label ID="errorlbl" runat="server" Text="" style="color:brown"></asp:Label>
                 <asp:ListBox ID="BusinessSessionsLB" CssClass="form-control" height="250px" runat="server" SelectionMode="Multiple"></asp:ListBox>

            </div>
          </div>
        <div class="row top-buffer">   
             <div class="col-md-6"><asp:Label ID="Label3" lablefor="StartDateTxt" runat="server" Text="Start Date" />
            <asp:TextBox CssClass="form-control js-date" ID="StartDateTxt" runat="server"></asp:TextBox></div>
           </div>
        <div class="row top-buffer">
                <div class="col-md-6"><asp:Label ID="Label4" lablefor="EndDateTxt" runat="server" Text="Prorogation Date" />
            <asp:TextBox ID="EndDateTxt" CssClass="form-control js-date" runat="server"></asp:TextBox></div>    
       </div>
       

         <div class="row top-buffer">
            
            <div class="col-md-6">
              <%--  <asp:Button ID="SaveBtn" runat="server" Cssclass="btn btn-custom" Text="Save" OnClick="SaveBtn_Click" />--%>
                <asp:Button ID="Prorogue1" runat="server" OnClientClick="Show();"  Cssclass="btn btn-custom" Text="Prorogue Session" OnClick="Prorogue1_Click" ValidationGroup="SaveGroup" />
                
            </div>
        </div>
        
    </div>
    <div class="col-md-6" ID="confirmdiv" runat="server" >
       <div class="page-header"><h4>Confirm</h4></div>
        <div class="row">
            Are you sure to prorogue the Session?  
            <br /> 
          
            <asp:Label ID="confirmlabel" runat="server" Text="" style="color:brown"></asp:Label>
              <br /> <br /> <br /> 
            <br />
        </div>
        <div class="row">

            <%--<asp:Button ID="ProrogueBtn" Cssclass="btn btn-custom" runat="server" Text="Yes Prorogue Session" OnClick="ProrogueBtn_Click" ValidationGroup="SaveGroup" />--%>
            <asp:Button ID="NoBtn" Cssclass="btn btn-custom" runat="server" Text="No" OnClick="NoBtn_Click" /><br /><br /><br />
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="SaveGroup" DisplayMode="BulletList" ForeColor="Red" />
        </div>
    </div>
    </div>
   <%-- <script type="text/javascript">
        $(function(){
            $("#confirmdiv").hide();
        });
        function Show() {
            
            document.getElementById('confirmdiv').style.display = "block";
            event.preventDefault();
        }

       
    </script>--%>
</asp:Content>
