<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="ManageUserQuestions.aspx.cs" Inherits="Translation.ManageUserQuestions" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <div class="container">
         <section id="AssignedToUsers">
            <div class="row">
                <div class="col-md-9">
                    <h4>
                        <label class="page-header">QUESTIONS ASSIGNED TO USERS</label></h4>
                </div>
            </div>
            <div class="row" style="margin-bottom: 10px;">
                <div class="col-md-3">
                    <asp:DropDownList runat="server" class="form-control" ID="AssignedQuestionsUsersDDL" AutoPostBack="true" OnSelectedIndexChanged="AssignedQuestionsUsersDDL_SelectedIndexChanged"></asp:DropDownList>
                </div>
                 <div class="col-md-4">
                </div>
                 <div class="col-md-3">
                    <asp:DropDownList runat="server" class="form-control" ID="AssignQuestionsUsersDDL"></asp:DropDownList>
                </div>
                <div class="col-md-2">
                    <asp:Button runat="server" ID="ReAssignBtn" Text="Assign" OnClick="ReAssign_Click" CssClass="btn btn-custom" />
                </div>
            </div>
            <table class="table table-hover table-striped table-responsive">
                <thead class="thead-inverse">
                    <tr>
                        <th>Sr#</th>
                        <th>Select</th>
                        <th>QID</th>
                        <th>Session Number</th>
                        <th>Subject Matter</th>
                        <th>Notice No/ Date</th>
                        <th>Notice Time</th>
                        <th>Category</th>
                        <th>Submitted By</th>
                        <th>Status</th>
                        <th>Sent On</th>
                        <th>Returned On</th>
                        <th>Assigned To</th>
                    </tr>
                </thead>
                <tbody>
                    <asp:ListView ID="AssignedToUsersLV" runat="server">

                        <ItemTemplate>
                            <tr>
                                <td>

                                    <asp:Label ID="Label3" class="table-data" runat="server" Text='<%#Container.DataItemIndex + 1%> ' />
                                </td>
                                <td class="hid">
                                    <asp:CheckBox ID="SelectCB" CssClass="form-control" runat="server" />
                                </td>
                                <td>
                                    <asp:Label ID="Label1" class="table-data" runat="server" Text='<%#Bind("QuestionsId")%>' />
                                    <asp:HiddenField ID="HidQuestionId" runat="server" Value='<%#Bind("QuestionsId")%>' />
                                </td>
                                <%--  <td style="text-align:center">
                            <asp:Label ID="Label7" class="table-data"  runat="server" Text='<%#Bind("QuestionDiaryNo")%>' />
                          
                        </td>--%>
                                <td style="text-align: center">
                                    <asp:Label ID="Label4" class="table-data" runat="server" Text='<%#Bind("SessionNumber")%>' />
                                    <asp:HiddenField ID="HidSessionId" runat="server" Value='<%#Bind("SessionNumberId")%>' />
                                </td>
                                <%--  <td>                                
                            <asp:Label ID="Label8" class="table-data" runat="server" Text='<%#GetGroupName(Convert.ToInt32(Eval("MinistryGroup")))%>' />
                        </td>--%>

                                <td style="text-align: justify">
                                    <asp:HyperLink class="table-data" ID="HyperLink1" runat="server" Style="color: black;" Target="_blank" NavigateUrl='<%#Eval("QuestionsId","~/QuestionDetails.aspx?QuestionsId={0}")%>'><%#Eval("QuestionText").ToString()%></asp:HyperLink>
                                </td>

                                <td>

                                    <asp:Label ID="Label6" class="table-data" runat="server" Text='<%#Eval("NoticeDiaryNo") + "<br>" + GetDate(Convert.ToDateTime(Eval("NoticeDiaryDate")))   %>' />
                                </td>
                                <td>

                                    <asp:Label ID="Label2" class="table-data" runat="server" Text='<%#GetTime(Convert.ToDateTime(Eval("NoticeDiaryTime")))%>' />
                                </td>

                                <td>
                                    <asp:Label ID="Label5" class="table-data" runat="server" Text='<%#Bind("QuestionCategory")%>' />
                                </td>
                                <td>
                                    <asp:Label ID="rankLabel" class="table-data" runat="server" Text='<%#Bind("MoverName")%>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="descriptionLabel" class="table-data" runat="server" Text='<%#Bind("QuestionStatus")%>' /><br />
                                    <asp:Label ID="Label20" class="table-data" runat="server" Text='<%#GetDate(Convert.ToDateTime(Eval("QuestionStatusDate")))%>' />
                                </td>
                                <td>
                                    <asp:Label ID="Label7" class="table-data" runat="server" Text='<%#GetDate(Convert.ToDateTime(Eval("SentForTranslationOn")))%>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label8" class="table-data" runat="server" Text='<%#GetDate(Convert.ToDateTime(Eval("ReturnedFromTranslationOn")))%>'></asp:Label>
                                </td>
                                 <td>
                                    <asp:Label ID="Label9" class="table-data" runat="server" Text='<%#Eval("AssignedForTranslationToName")%>'></asp:Label>
                                </td>
                             

                            </tr>
                        </ItemTemplate>

                    </asp:ListView>
                </tbody>
            </table>
        </section>

        <section id="TranslatedByUsers">
            <div class="row">
                <div class="col-md-9">
                    <h4>
                        <label class="page-header">QUESTIONS TRANSLATED BY USERS</label></h4>
                </div>
            </div>
            <div class="row" style="margin-bottom: 10px;">
                <div class="col-md-3">
                    <asp:DropDownList runat="server" class="form-control" ID="TranslatedQuestionsUsersDDL"  AutoPostBack="true" OnSelectedIndexChanged="TranslatedQuestionsUsersDDL_SelectedIndexChanged"></asp:DropDownList>
                </div>
            </div>
            <table class="table table-hover table-striped table-responsive">
                <thead class="thead-inverse">
                    <tr>
                        <th>Sr#</th>
                        <th>Select</th>
                        <th>QID</th>
                        <th>Session Number</th>
                        <th>Subject Matter</th>
                        <th>Notice No/ Date</th>
                        <th>Notice Time</th>
                        <th>Category</th>
                        <th>Submitted By</th>
                        <th>Status</th>
                        <th>Sent On</th>
                        <th>Returned On</th>
                        <th>Assign</th>
                    </tr>
                </thead>
                <tbody>
                    <asp:ListView ID="TranslatedByUsersLV" runat="server">

                        <ItemTemplate>
                            <tr>
                                <td>

                                    <asp:Label ID="Label3" class="table-data" runat="server" Text='<%#Container.DataItemIndex + 1%> ' />
                                </td>
                                <td class="hid">
                                    <asp:CheckBox ID="SelectCB" CssClass="form-control" runat="server" />
                                </td>
                                <td>
                                    <asp:Label ID="Label1" class="table-data" runat="server" Text='<%#Bind("QuestionsId")%>' />
                                    <asp:HiddenField ID="HidQuestionId" runat="server" Value='<%#Bind("QuestionsId")%>' />
                                </td>
                                <%--  <td style="text-align:center">
                            <asp:Label ID="Label7" class="table-data"  runat="server" Text='<%#Bind("QuestionDiaryNo")%>' />
                          
                        </td>--%>
                                <td style="text-align: center">
                                    <asp:Label ID="Label4" class="table-data" runat="server" Text='<%#Bind("SessionNumber")%>' />
                                    <asp:HiddenField ID="HidSessionId" runat="server" Value='<%#Bind("SessionNumberId")%>' />
                                </td>
                                <%--  <td>                                
                            <asp:Label ID="Label8" class="table-data" runat="server" Text='<%#GetGroupName(Convert.ToInt32(Eval("MinistryGroup")))%>' />
                        </td>--%>

                                <td style="text-align: justify">
                                    <asp:HyperLink class="table-data" ID="HyperLink1" runat="server" Style="color: black;" Target="_blank" NavigateUrl='<%#Eval("QuestionsId","~/QuestionDetails.aspx?QuestionsId={0}")%>'><%#Eval("QuestionText").ToString()%></asp:HyperLink>
                                </td>

                                <td>

                                    <asp:Label ID="Label6" class="table-data" runat="server" Text='<%#Eval("NoticeDiaryNo") + "<br>" + GetDate(Convert.ToDateTime(Eval("NoticeDiaryDate")))   %>' />
                                </td>
                                <td>

                                    <asp:Label ID="Label2" class="table-data" runat="server" Text='<%#GetTime(Convert.ToDateTime(Eval("NoticeDiaryTime")))%>' />
                                </td>

                                <td>
                                    <asp:Label ID="Label5" class="table-data" runat="server" Text='<%#Bind("QuestionCategory")%>' />
                                </td>
                                <td>
                                    <asp:Label ID="rankLabel" class="table-data" runat="server" Text='<%#Bind("MoverName")%>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="descriptionLabel" class="table-data" runat="server" Text='<%#Bind("QuestionStatus")%>' /><br />
                                    <asp:Label ID="Label20" class="table-data" runat="server" Text='<%#GetDate(Convert.ToDateTime(Eval("QuestionStatusDate")))%>' />
                                </td>
                                <td>
                                    <asp:Label ID="Label7" class="table-data" runat="server" Text='<%#GetDate(Convert.ToDateTime(Eval("SentForTranslationOn")))%>'></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label8" class="table-data" runat="server" Text='<%#GetDate(Convert.ToDateTime(Eval("ReturnedFromTranslationOn")))%>'></asp:Label>
                                </td>

                            </tr>
                        </ItemTemplate>

                    </asp:ListView>
                </tbody>
            </table>
        </section>

    </div>
        
</asp:Content>

