<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="TranslationMotions.aspx.cs" Inherits="MotionBranch.TranslationMotions" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <div class="container">
         <div class="row">
            <div class="col-md-9">
                <h4>
                    <label class="page-header">TRANSLATED MOTIONS</label></h4>
            </div>
        </div>
        <table class="table table-hover table-striped table-responsive">
            <thead class="thead-inverse">
                <tr>
                    <th>Sr#</th>
                    <th>MID</th>
                    <th>Session Number</th>
                    <th>Subject Matter</th>
                    <th>Notice Date</th>
                    <th>Notice Time</th>
                    <th>Category</th>
                    <th>Sent for Translation On</th>
                     <th>Translated On</th>

                </tr>
            </thead>
            <tbody>
                <asp:ListView ID="TranslatedLV" runat="server">

                     <ItemTemplate>
                        <tr>
                            <td>

                                <asp:Label ID="Label3" class="table-data" runat="server" Text='<%#Container.DataItemIndex + 1%> ' />
                            </td>
                            <td>
                                <asp:Label ID="Label1" class="table-data" runat="server" Text='<%#Bind("MotionsId")%>' />
                                <asp:HiddenField ID="HidQuestionId" runat="server" Value='<%#Bind("MotionsId")%>' />
                            </td>
                            <%--  <td style="text-align:center">
                            <asp:Label ID="Label7" class="table-data"  runat="server" Text='<%#Bind("QuestionDiaryNo")%>' />
                          
                        </td>--%>
                            <td style="text-align: center">
                                <asp:Label ID="Label4" class="table-data" runat="server" Text='<%#Bind("SessionNumber")%>' />
                                <asp:HiddenField ID="HidSessionId" runat="server" Value='<%#Bind("SessionDesc")%>' />
                            </td>
                            <%--  <td>                                
                            <asp:Label ID="Label8" class="table-data" runat="server" Text='<%#GetGroupName(Convert.ToInt32(Eval("MinistryGroup")))%>' />
                        </td>--%>

                            <td style="text-align: justify">
                                <asp:HyperLink class="table-data" ID="HyperLink1" runat="server" Style="color: black;" Target="_blank" NavigateUrl='<%#Eval("MotionsId","~/TranslatedMotionDetail.aspx?MotionId={0}")%>'><%#Eval("Description").ToString()%></asp:HyperLink>
                            </td>

                            <td>

                                <asp:Label ID="Label6" class="table-data" runat="server" Text='<%#GetDate(Convert.ToDateTime(Eval("NoticeDiaryDate")))%>' />
                            </td>
                            <td>

                                <asp:Label ID="Label2" class="table-data" runat="server" Text='<%#GetTime(Convert.ToDateTime(Eval("NoticeDiaryTime")))%>' />
                            </td>

                            <td>
                                <asp:Label ID="Label5" class="table-data" runat="server" Text='<%#Bind("MotionType")%>' />
                            </td>
                            <td>
                                <asp:Label ID="Label7" class="table-data" runat="server" Text='<%#GetDate(Convert.ToDateTime(Eval("SentForTranslationOn")))%>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="Label8" class="table-data" runat="server" Text='<%#GetDate(Convert.ToDateTime(Eval("ReturnedFromTranslationOn")))%>'></asp:Label>
                            </td>
                            <%--  <td>
                            <asp:HyperLink ID="PrintHL" runat="server" Target="_blank" NavigateUrl='<%#Eval("QuestionsId","~/PrintQuestion.aspx?questionsId={0}")%>' Text="Print" Cssclass="btn btn-custom"/>
                        </td>  --%>
                        </tr>
                    </ItemTemplate>

                </asp:ListView>
            </tbody>
        </table>

        <div class="row">
            <div class="col-md-9">
                <h4>
                    <label class="page-header">MOTIONS SENT TO TRANSLATION BRANCH</label></h4>
            </div>
        </div>
        <table class="table table-hover table-striped table-responsive">
            <thead class="thead-inverse">
                <tr>
                     <th>Sr#</th>
                    <th>MID</th>
                    <th>Session Number</th>
                    <th>Subject Matter</th>
                    <th>Notice Date</th>
                    <th>Notice Time</th>
                    <th>Category</th>
                    <th>Sent for Translation On</th>
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
                                <asp:Label ID="Label1" class="table-data" runat="server" Text='<%#Bind("MotionsId")%>' />
                                <asp:HiddenField ID="HidQuestionId" runat="server" Value='<%#Bind("MotionsId")%>' />
                            </td>
                            <%--  <td style="text-align:center">
                            <asp:Label ID="Label7" class="table-data"  runat="server" Text='<%#Bind("QuestionDiaryNo")%>' />
                          
                        </td>--%>
                            <td style="text-align: center">
                                <asp:Label ID="Label4" class="table-data" runat="server" Text='<%#Bind("SessionNumber")%>' />
                                <asp:HiddenField ID="HidSessionId" runat="server" Value='<%#Bind("SessionDesc")%>' />
                            </td>
                            <%--  <td>                                
                            <asp:Label ID="Label8" class="table-data" runat="server" Text='<%#GetGroupName(Convert.ToInt32(Eval("MinistryGroup")))%>' />
                        </td>--%>

                            <td style="text-align: justify">
                                <asp:HyperLink class="table-data" ID="HyperLink1" runat="server" Style="color: black;" Target="_blank" NavigateUrl='<%#Eval("MotionsId","~/TranslatedMotionDetail.aspx?MotionId={0}")%>'><%#Eval("Description").ToString()%></asp:HyperLink>
                            </td>

                            <td>

                                <asp:Label ID="Label6" class="table-data" runat="server" Text='<%#GetDate(Convert.ToDateTime(Eval("NoticeDiaryDate")))%>' />
                            </td>
                            <td>

                                <asp:Label ID="Label2" class="table-data" runat="server" Text='<%#GetTime(Convert.ToDateTime(Eval("NoticeDiaryTime")))%>' />
                            </td>

                            <td>
                                <asp:Label ID="Label5" class="table-data" runat="server" Text='<%#Bind("MotionType")%>' />
                            </td>
                            <td>
                                <asp:Label ID="Label7" class="table-data" runat="server" Text='<%#GetDate(Convert.ToDateTime(Eval("SentForTranslationOn")))%>'></asp:Label>
                            </td>
                         <%--   <td>
                                <asp:Label ID="Label8" class="table-data" runat="server" Text='<%#GetDate(Convert.ToDateTime(Eval("ReturnedFromTranslationOn")))%>'></asp:Label>
                            </td>--%>
                            <%--  <td>
                            <asp:HyperLink ID="PrintHL" runat="server" Target="_blank" NavigateUrl='<%#Eval("QuestionsId","~/PrintQuestion.aspx?questionsId={0}")%>' Text="Print" Cssclass="btn btn-custom"/>
                        </td>  --%>
                        </tr>
                    </ItemTemplate>

                </asp:ListView>
            </tbody>
        </table>

        
    </div>
</asp:Content>


