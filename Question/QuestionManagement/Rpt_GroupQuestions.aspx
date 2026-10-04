<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Rpt_GroupQuestions.aspx.cs" Inherits="QuestionManagement.Rpt_GroupQuestions" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md-12">
                   <div class="row page-header">
            <div class="col-md-12">
                <h4 style="color: #000;">DEFFERED QUESTIONS (CURRENT SESSION)</h4>
            </div>
        </div>
         <table class="table table-hover table-striped table-responsive" style="border-collapse: collapse;">
                <thead class="thead-inverse">
                    <tr>
                        <th>Sr#</th>
                        <th>QID</th>
                        <th>Q-DN</th>
                        <th class="hid">List No</th>
                        <th>Session Number</th>
                        <th>Group</th>
                        <th>Division</th>
                     
                        <th>Category</th>
                      
                        <%--  <th>Carry Fwd</th>
        <th>
            <asp:CheckBox ID="SelectAll" runat="server" AutoPostBack="true" OnCheckedChanged="SelectAll_CheckedChanged" /></th>--%>
                        <th class="hid">Action</th>
                    </tr>
                </thead>
                <tbody>
                    <asp:ListView ID="DefferedLV" runat="server">

                        <ItemTemplate>
                            <tr>
                                <td>

                                    <asp:Label ID="Label3" class="table-data" runat="server" Text='<%#Container.DataItemIndex + 1%> ' />
                                </td>
                             
                                <td>
                                    <asp:Label ID="Label1" class="table-data" runat="server" Text='<%#Bind("QuestionId")%>' />
                                    <asp:HiddenField ID="HidQuestionId" runat="server" Value='<%#Bind("QuestionId")%>' />
                                </td>
                                <td style="text-align: center">
                                    <asp:Label ID="Label7" class="table-data" runat="server" Text='<%#Bind("QuestionDiaryNo") %>' />

                                </td>
                                <td style="text-align: center" class="hid">
                                    <asp:Label ID="Label23" class="table-data" runat="server" Text='<%#Bind("ListNo") %>' />

                                </td>
                                <td style="text-align: center">
                                    <asp:Label ID="Label4" class="table-data" runat="server" Text='<%#Bind("SessionName")%>' />
                                    <asp:HiddenField ID="HidSessionId" runat="server" Value='<%#Bind("SessionId")%>' />
                                </td>
                               <td>
                                    <asp:Label ID="Label8" class="table-data" runat="server" Text='<%#Eval("Group")%>' />
                                </td>
                                 <td>
                                    <asp:Label ID="Label24" class="table-data" runat="server" Text='<%#Eval("Division")%>' />
                                </td>
                                <td style="text-align: justify;min-width:400px !important;" runat="server" ID="FullSearch">
                                    <asp:HyperLink class="table-data" ID="HyperLink1" CssClass="printText" runat="server" Style="color: black;font-size:10pt;" Target="_blank" NavigateUrl='<%#GetLink(Eval("QuestionId").ToString())%>'><%#Eval("QuestionText")%></asp:HyperLink>
                                </td>
                                  <td style="text-align: justify;min-width:400px !important;" runat="server" ID="RestrictedSearch" visible="false">
                                    <asp:HyperLink class="table-data" ID="HyperLink3" CssClass="printText" runat="server" Style="color: black;font-size:10pt;" Target="_blank" NavigateUrl='<%#GetLink(Eval("QuestionId").ToString())%>'><%#Eval("QuestionText")%></asp:HyperLink>
                                </td>

                                <td>

                                    <asp:Label ID="Label6" class="table-data" runat="server" Text='<%#Eval("NoticeDiaryNo") + "<br>" + GetDate(Convert.ToDateTime(Eval("NoticeDiaryDate")))%>' />
                                </td>
                                <td>

                                    <asp:Label ID="Label2" class="table-data" runat="server" Text='<%#GetTime(Convert.ToDateTime(Eval("NoticeDiaryTime")))%>' />
                                </td>

                              <td>
                                    <asp:Label ID="Label5" class="table-data" runat="server" Text='<%#Bind("Category")%>' />
                                </td>
                                <td>
                                    <asp:Label ID="rankLabel" class="table-data" runat="server" Text='<%#Bind("MoverName")%>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="descriptionLabel" class="table-data" runat="server" Text='<%#Bind("Status")%>' /><br />
                                    <asp:Label ID="Label20" class="table-data" runat="server" Text='<%#GetDate(Convert.ToDateTime(Eval("StatusDate")))%>' />
                                </td>
                                <td id="fullPrint" runat="server" class="hid">
                                    <asp:HyperLink ID="PrintHL" runat="server" Target="_blank" NavigateUrl='<%#Eval("QuestionId","~/PrintQuestion.aspx?questionsId={0}")%>' Text="Print" Cssclass="btn btn-custom" />
                                </td>
                                  <td ID="restrictedPrint" runat="server" Visible="false">
                                    <asp:HyperLink ID="HyperLink2" runat="server" Target="_blank" NavigateUrl='<%#Eval("QuestionId","~/PrintQuestion.aspx?questionsId={0}")%>' Text="Print" Cssclass="btn btn-custom" />
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
