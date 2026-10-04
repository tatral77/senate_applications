<%@ Page Title="" Language="C#" MasterPageFile="~/MainMaster.Master" AutoEventWireup="true" CodeBehind="EmpsDetailsRpt.aspx.cs" Inherits="EstablishmentASP.EmpsDetailsRpt" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Styles/SearchList.css" rel="stylesheet" type="text/css" />
    <link href="Styles/Pages.css" rel="stylesheet" type="text/css" />
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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="heading">Employees Detail</div>
<table width="92%" border="0" align="center" cellpadding="3" cellspacing="1" class="AltEmpAddress">
          <tbody>
              <tr>
              <td align="right">
			        <table border="0" align="center" cellpadding="0" cellspacing="1">
        		        <tbody>
				            <tr>
				                  <td  align="right" class="Labels">Employee Name:</td>
                                  <td >
                                      <asp:TextBox ID="EmpName" runat="server"></asp:TextBox></td>
				            </tr>
                            <tr>
		                            <td class="Labels" nowrap="nowrap" align="right">Job Experience From:</td>
             			            <td nowrap="nowrap" align="left">
                                         <asp:TextBox ID="ExpFrom" runat="server" Width="80px"></asp:TextBox></td>
                                    <td class="Labels" nowrap="nowrap" align="right">To:</td>
                		            <td nowrap="nowrap" align="left">
                                        <asp:TextBox ID="ExpTo" runat="server" Width="80px"></asp:TextBox></td>
            			            <td class="Labels" nowrap="nowrap" align="right">Gender:</td>
						            <td nowrap="nowrap" align="left">
                                    <asp:DropDownList ID="Gender" runat="server" >
                                        <asp:ListItem Selected="True" Value="0">Select</asp:ListItem>
                                        <asp:ListItem Value="1">Male</asp:ListItem>
                                        <asp:ListItem Value="2">Female</asp:ListItem>
                                    </asp:DropDownList></td>
                                    <td nowrap="nowrap" align="right" class="Labels">Age From:</td>
            			            <td nowrap="nowrap" align="left">
                                        <asp:TextBox ID="AgeFrom" runat="server" Width="50px"></asp:TextBox> </td>
                                    <td class="Labels" nowrap="nowrap" align="right">To:</td>
                                    <td nowrap="nowrap" align="left">
                                        <asp:TextBox ID="AgeTo" runat="server" Width="50px"></asp:TextBox></td>
						
            		        </tr>
                        </tbody>
	                </table>
			  
	                <table border="0" align="center" cellpadding="3" cellspacing="1">
       		            <tbody>
		                    <tr>
					            <td align="right" class="Labels">Branch:</td>
					            <td align="left" class="Labels">
                                    <asp:DropDownList ID="Branch" runat="server">
                                        <asp:ListItem Selected="True" Value="0">Select</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td align="right" class="Labels">Province/Unit:</td>
					            <td class="style2" align="right">
                                    <asp:DropDownList ID="Province" runat="server">
                                        <asp:ListItem Selected="True" Value="0">Select</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td align="right" class="Labels">File #:</td>
                                <td align="left">
                                    <asp:TextBox ID="FileNo" runat="server"></asp:TextBox></td>	            
                            </tr>
				            <tr>
       			                <td class="Labels" align="right">Basic Pay Scale From:</td>
					            <td align="left">
                                    <asp:DropDownList ID="BPSFrom" runat="server">
                                        <asp:ListItem Selected="True" Value="0">Select</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
					            <td class="Labels" align="right">Basic Pay Scale To:</td>
				                <td align="left" class="style3">
                                    <asp:DropDownList ID="BPSTo" runat="server">
                                        <asp:ListItem Selected="True" Value="0">Select</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
        			            <td class="Labels" align="right">Employee Status:</td>
					            <td align="left" >
                                    <asp:DropDownList ID="EmpStatusDDL" runat="server">
                                        <asp:ListItem Selected="True" Value="0">Select</asp:ListItem>
                                    </asp:DropDownList>
                                </td>					
		    	            </tr>
		                    <tr>
		                        <td align="right"><span class="Labels">Designation:</span></td>
		                        <td colspan="3" align="left">
                                    <asp:DropDownList ID="Designation" runat="server">
                                        <asp:ListItem Selected="True" Value="0">Select</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td class="Labels" align="right">Employee Pool</td>
                                <td align="left">
                                 <asp:DropDownList ID="EmpPoolDDL" runat="server">
                                        <asp:ListItem Selected="True" Value="0">Select</asp:ListItem>
                                    </asp:DropDownList>
                                
                                </td>
	                        </tr>
                         </tbody>
                    </table>
        </td>
        </tr>
         <tr>
            <td align="center">
                <asp:Button ID="Search" runat="server" Text="Search" onclick="Search_Click" />
                <asp:Button ID="Reset" runat="server" Text="Reset" />
            </td>
        </tr>      
    </tbody>
    </table>
           
		<!--<div class="heading">Search Result</div>   -->
<table width="90%">
    <tr>
    <th>Sr. No</th>
    <th>File Number</th>
     <th>Employee Name</th>
     <th>Age</th>
      <th>Post Held</th>
       <th>Grade</th>
        <th>Status</th>
         <th>Address</th>
         
    </tr>
    <asp:ListView ID="EmpListView" runat="server">
   
    <ItemTemplate>
    <tr>
                        <td class="EmpBPS" width="6%" align="center">
                            
                            <asp:Label ID="Label3" runat="server" Text='<%#Container.DataItemIndex + 1%> ' />
                        </td>
                        <td class="EmpName">
                            <asp:Label ID="Label4" runat="server" Text='<%#Bind("Filenumber")%>' />
                        </td>
                        <td class="EmpName">
                            <asp:HiddenField ID="idHiddenField" runat="server" Value='<%#Bind("EmpId")%>' />
                           <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%#Eval("EmpId","~/PersonalInformation.aspx?empid={0}")%>'><%#Eval("EmpName")%></asp:HyperLink>
                        </td>
                        <td class="EmpBPS" width="6%" align="center">
                            <asp:Label ID="Label5" runat="server" Text='<%#Bind("Age")%>' />
                        </td>
                        <td class="EmpDesig" width="4%">
                            <asp:Label ID="rankLabel" runat="server" Text='<%#Bind("EmpDesignation")%>'></asp:Label>
                        </td>
                        <td class="EmpBPS" width="6%" align="center">
                            <asp:Label ID="descriptionLabel" runat="server" Text='<%#Bind("BPS")%>' />
                        </td>
                        <td class="EmpBPS" width="6%" align="center">
                            <asp:Label ID="Label2" runat="server" Text='<%#Bind("Empstatus")%>' />
                        </td>
                        <td class="EmpDesig">
                            <asp:Label ID="Label1" runat="server" Text='<%#Bind("EmpAddress")%>' />
                        </td>
                        
      </tr>
    </ItemTemplate>
    <AlternatingItemTemplate>
    <tr>
                        <td class="AltEmpBPS" width="6%" align="center">
                            
                            <asp:Label ID="Label3" runat="server" Text='<%#Container.DataItemIndex + 1%> ' />
                        </td>
                        <td class="AltEmpName">
                            <asp:Label ID="Label4" runat="server" Text='<%#Bind("Filenumber")%>'/>
                        </td>
                        <td class="AltEmpName">
                            <asp:HiddenField ID="idHiddenField" runat="server" Value='<%#Bind("EmpId")%>' />
                            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%#Eval("EmpId","~/PersonalInformation.aspx?empid={0}")%>'><%#Eval("EmpName")%></asp:HyperLink>
                            
                           
                           </td>
                        <td class="AltEmpBPS" width="6%" align="center">
                            <asp:Label ID="Label6" runat="server" Text='<%#Bind("Age")%>' />
                        </td>
                        <td class="AltEmpDesig" width="4%">
                            <asp:Label ID="rankLabel" runat="server" Text='<%#Bind("EmpDesignation")%>'></asp:Label>
                        </td>
                        <td class="AltEmpBPS" width="6%" align="center">
                            <asp:Label ID="descriptionLabel" runat="server" Text='<%#Bind("BPS")%>' />
                        </td>
                        <td class="AltEmpBPS" width="6%" align="center">
                            <asp:Label ID="Label2" runat="server" Text='<%#Bind("Empstatus")%>' />
                        </td>
                        <td class="AltEmpBPS">
                            <asp:Label ID="Label1" runat="server" Text='<%#Bind("EmpAddress")%>' />
                        </td>
                        
      </tr>
    </AlternatingItemTemplate>
    </asp:ListView>
    </table>
    
</asp:Content>
