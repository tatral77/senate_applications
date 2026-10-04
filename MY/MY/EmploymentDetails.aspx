<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="EmploymentDetails.aspx.cs" Inherits="MY.EmploymentDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .pf-kvt { width: 100%; border-collapse: collapse; margin: 0 0 14px; background: #fff; border: 1px solid var(--line); border-radius: 12px; overflow: hidden; }
        .pf-kvt td { padding: 9px 12px; border-bottom: 1px solid #edf1f6; vertical-align: top; }
        .pf-kvt td.k { width: 18%; font-size: 11.5px; font-weight: 600; text-transform: uppercase; letter-spacing: .3px; color: var(--muted); background: #f8fafc; }
        .pf-kvt td.v { width: 32%; font-size: 14.5px; font-weight: 600; word-break: break-word; }
        .pf-kvt td.v span:empty::after { content: "4"; color: #b8c2cf; font-weight: 400; }
        @media (max-width: 767px) { .pf-kvt, .pf-kvt tbody, .pf-kvt tr, .pf-kvt td { display: block; width: 100% !important; } .pf-kvt td.k { padding-bottom: 0; border-bottom: 0; } }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="nf-head">
        <h4>EMPLOYMENT DETAILS</h4>
        <div class="nf-toolbar" style="margin: 0">
            <asp:Button class="btn btn-custom" ID="PrintBtn" runat="server" Text="Print" OnClientClick="return PrintPanel();" UseSubmitBehavior="false" />
            <input type="button" class="btn btn-default" value="Export PDF" onclick="return ExportPdf();" />
        </div>
    </div>
    <asp:Panel ID="pnlContents" runat="server">
    <asp:Literal ID="PrintHeadLit" runat="server"></asp:Literal>
    <div>
            <table class="pf-kvt">
                <tr><td class="k">Personnel Number</td><td class="v"><asp:Label ID="PersonalNoTxt" runat="server"></asp:Label></td><td class="k">File Number</td><td class="v"><asp:Label ID="FileNo" runat="server"></asp:Label></td></tr>
                <tr><td class="k">Main Head</td><td class="v"><asp:Label ID="PoolLbl" runat="server"></asp:Label></td><td class="k">Appointment Mode</td><td class="v"><asp:Label ID="AppointmentModeLbl" runat="server"></asp:Label></td></tr>
                <tr><td class="k">Quota</td><td class="v"><asp:Label ID="QuotaLbl" runat="server"></asp:Label></td><td class="k">Govt Service Entry Date</td><td class="v"><asp:Label ID="GovtSrvEntry" runat="server"></asp:Label></td></tr>
                <tr><td class="k">Employment in Senate</td><td class="v"><asp:Label ID="SenEntry" runat="server"></asp:Label></td><td class="k">Seniority Number</td><td class="v"><asp:Label ID="SeniorityNumber" runat="server"></asp:Label></td></tr>
            </table>
        <div class="top-buffer"></div>

        <%-------------------------------------------------------------------------REGULAR EMPLOYMENT--%>

            <div id="regulardiv" runat="server">
                <div class="row">
                    <div class="col-md-12">
                        <h4>Regular Employment</h4>
                    </div>
                </div>
                <table class="table table-hover table-striped table-data">
                    <thead style="text-align: center">
                        <tr>
                            <th>Sr#</th>
                            <th>Ref-Id</th>
                            <th>Post</th>
                            <th>BPS</th>
                            <th>Post Status</th>
                            <th>Gazetted</th>
                            <%-- <th>Employment Status</th>--%>
                            <th>Appointment Date</th>
                            <th>Current Status</th>
                            <th>Status Date</th>
                            <th>Is Current</th>
                        </tr>
                    </thead>
                    <tbody>

                        <asp:ListView ID="RegularEmploymentLV" runat="server">
                            <ItemTemplate>
                                <tr>
                                    <td class="itemCent">
                                        <asp:HiddenField ID="HidEmploymentHistoryId" runat="server" Value='<%#Bind("EmploymentHistoryId") %>' />
                                        <asp:Label ID="Label3" runat="server" class="table-data" Text='<%#Container.DataItemIndex + 1%> ' />
                                    </td>
                                    <td>
                                        <asp:Label ID="Label11" class="table-data" runat="server" Text='<%#Eval("EmploymentHistoryId") %>' />
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
                                    <%--  <td>
                           <asp:Label ID="Label10" class="table-data" runat="server" Text='<%#Eval("EmploymentStatus")%>' />
                        </td>--%>

                                    <td>
                                        <asp:Label ID="Label1" class="table-data" runat="server" Text='<%#GetDate(Convert.ToDateTime(Eval("EmploymentStatusDate")))%>' />
                                    </td>

                                    <td>
                                        <asp:Label ID="Label9" class="table-data" runat="server" Text='<%#Eval("CurrentStatus")%>' />
                                    </td>
                                    <td>
                                        <asp:Label ID="Label7" class="table-data" runat="server" Text='<%#GetDate(Convert.ToDateTime(Eval("CurrentStatusDate")))%>' />
                                    </td>
                                    <td>
                                        <asp:Label ID="Label16" class="table-data" runat="server" Text='<%#(Convert.ToString(Eval("IsCurrent"))=="1")?"Yes":"No"%>' />
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:ListView>
                    </tbody>
                </table>
            </div>
            <%-------------------------------------------------------------------------PROBATION-----------------------------------------------------%>
            <div id="probationdiv" runat="server">
                <div class="row">
                    <div class="col-md-12">
                        <h4>Probation Details</h4>
                    </div>
                </div>
                <table class="table table-hover table-striped table-data">
                    <thead style="text-align: center">
                        <tr>
                            <th>Sr#</th>
                            <th>Ref-Id</th>
                            <th>Probation Type</th>
                            <th>Probation From</th>
                            <th>Probation To</th>
                            <th>Remarks</th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:ListView ID="ProbationLV" runat="server">
                            <ItemTemplate>
                                <tr>
                                    <td class="itemCent">
                                        <asp:HiddenField ID="HidProbationId" runat="server" Value='<%#Bind("ProbationId") %>' />
                                        <asp:Label ID="Label8" runat="server" class="table-data" Text='<%#Container.DataItemIndex + 1%> ' />
                                    </td>
                                    <td>
                                        <asp:Label ID="Label10" class="table-data" runat="server" Text='<%#Eval("EmploymentHistId") %>' />
                                    </td>
                                    <td>
                                        <asp:Label ID="Label12" class="table-data" runat="server" Text='<%#Eval("ProbationType")%>' />
                                    </td>
                                    <td>
                                        <asp:Label ID="Label13" class="table-data" runat="server" Text='<%#GetDate(Convert.ToDateTime(Eval("ProbationFrom")))%>' />
                                    </td>
                                    <td>
                                        <asp:Label ID="Label14" class="table-data" runat="server" Text='<%#GetDate(Convert.ToDateTime(Eval("ProbationTo")))%>' />
                                    </td>
                                    <td>
                                        <asp:Label ID="Label15" class="table-data" runat="server" Text='<%#Bind("Remarks")%>' />
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
            <%-------------------------------------------------------------------------DEPUTATION OUT / LIEN-----------------------------------------------------%>
            <div id="deputationdiv" runat="server">
                <div class="row">
                    <div class="col-md-9">
                        <label class="page-header page-title-Small">Deputation Out / Lien</label>
                    </div>

                </div>
                <div id="DeputedOutn">
                    <table class="table table-hover table-striped table-data">
                        <thead style="text-align: center">
                            <tr>
                                <th>Sr#</th>
                                <th>Employment Out Type</th>
                                <th>From Date</th>
                                <th>From Post</th>
                                <th>To Date</th>
                                <th>To Post</th>
                                <th>Is-Extended</th>
                                <th>Details</th>
                            </tr>
                        </thead>
                        <tbody>

                            <asp:ListView ID="EmploymentOutLV" runat="server">



                                <ItemTemplate>
                                    <tr>
                                        <td class="itemCent">
                                            <asp:HiddenField ID="HidEmploymentOutId" runat="server" Value='<%#Bind("EmploymentOutId") %>' />

                                            <asp:Label ID="Label18" runat="server" class="table-data" Text='<%#Container.DataItemIndex + 1%> ' />
                                        </td>

                                        <td>
                                            <asp:Label ID="Label19" class="table-data" runat="server" Text='<%#Eval("EmploymentOutType")%>' />
                                        </td>
                                        <td>
                                            <asp:Label ID="Label20" class="table-data" runat="server" Text='<%#GetDate(Convert.ToDateTime(Eval("FromDate")))%>' />
                                        </td>
                                        <td>
                                            <asp:Label ID="Label21" class="table-data" runat="server" Text='<%#Eval("InPostDesc") + " (" + GetBps(Convert.ToInt32(Eval("InBps"))) + ")" %>' />
                                        </td>
                                        <td>
                                            <asp:Label ID="Label22" class="table-data" runat="server" Text='<%#GetDate(Convert.ToDateTime(Eval("ToDate")))%>' />
                                        </td>
                                        <td>
                                            <asp:Label ID="Label23" class="table-data" runat="server" Text='<%#Eval("OutPostDesc") + " (" + GetBps(Convert.ToInt32(Eval("OutBps"))) + ")" %>' />
                                        </td>
                                        <td>
                                            <asp:Label ID="Label24" class="table-data" runat="server" Text='<%#(Convert.ToString(Eval("IsExtended"))=="1")?"Yes":"No"%>' /></td>
                                        <td>
                                            <asp:Label ID="Label25" class="table-data" runat="server" Text='<%#Bind("Remarks")%>' />
                                        </td>


                                    </tr>
                                </ItemTemplate>



                                <EmptyDataTemplate>
                                    <tr>
                                        <td>
                                            <b>No Employment Out details found.</b>

                                        </td>
                                    </tr>
                                </EmptyDataTemplate>
                            </asp:ListView>
                        </tbody>
                    </table>
                </div>
            </div>
            <div id="retirementdiv" runat="server">
                <div class="row">
                    <div class="col-md-9">
                        <label class="page-header page-title-Small">Retirement Details</label>
                    </div>
                </div>
                <div id="Retirement">
                    <table class="table table-hover table-striped table-data">
                        <thead style="text-align: center">
                            <tr>
                                <th>Sr#</th>
                                <th>Retirement Type</th>
                                <th>Date</th>
                                <th>Retirement Mode</th>
                                <th>Details</th>
                            </tr>
                        </thead>
                        <tbody>

                            <asp:ListView ID="RetirementLV" runat="server">



                                <ItemTemplate>
                                    <tr>
                                        <td class="itemCent">
                                            <asp:HiddenField ID="HidEmpRetirementId" runat="server" Value='<%#Bind("EmpRetirementId") %>' />

                                            <asp:Label ID="Label27" runat="server" class="table-data" Text='<%#Container.DataItemIndex + 1%> ' />
                                        </td>

                                        <td>
                                            <asp:Label ID="Label28" class="table-data" runat="server" Text='<%#Eval("RetirementType")%>' />
                                        </td>
                                        <td>
                                            <asp:Label ID="Label29" class="table-data" runat="server" Text='<%#GetDate(Convert.ToDateTime(Eval("RetirementDate")))%>' />
                                        </td>

                                        <td>
                                            <asp:Label ID="Label30" class="table-data" runat="server" Text='<%#Eval("RetirementMode")%>' /></td>
                                        <td>
                                            <asp:Label ID="Label31" class="table-data" runat="server" Text='<%#Bind("Remarks")%>' />
                                        </td>
                                    </tr>
                                </ItemTemplate>

                                <EmptyDataTemplate>
                                    <tr>
                                        <td>
                                            <b>No Retirements details found.</b>

                                        </td>
                                    </tr>
                                </EmptyDataTemplate>
                            </asp:ListView>
                        </tbody>
                    </table>
                </div>
            </div>

        <div class="col-md-12">
            <div id="otheremploymentdiv" runat="server">
                <div class="row">
                    <div class="col-md-9">
                        <label class="page-header page-title">Other Employment</label>
                    </div>
                </div>
                <table class="table table-hover table-striped table-data">
                    <thead style="text-align: center">
                        <tr>
                            <th>Sr#</th>
                            <th>Ref. Id</th>
                            <th>Empl-Type</th>
                            <th>Contract Type</th>
                            <th>Post</th>
                            <th>BPS</th>
                            <th>Post Status</th>
                            <th>Gazetted</th>
                            <th>Empl-From</th>
                            <th>Empl-To</th>
                            <%--  <th>Details</th>--%>
                            <th>Current Status</th>
                            <th>Status Date</th>
                            <th>Details</th>
                        </tr>
                    </thead>
                    <tbody>

                        <asp:ListView ID="OtherEmploymentLV" runat="server">
                            <ItemTemplate>
                                <tr>
                                    <td class="itemCent">
                                        <asp:Label ID="Label33" runat="server" class="table-data" Text='<%#Container.DataItemIndex + 1%> ' />
                                    </td>
                                    <td>
                                        <asp:Label ID="Label34" class="table-data" runat="server" Text='<%#Eval("EmploymentHistoryId")%>' />
                                    </td>
                                    <td>
                                        <asp:Label ID="Label35" class="table-data" runat="server" Text='<%#Eval("EmploymentStatus")%>' />
                                    </td>
                                    <td>
                                        <asp:Label ID="Label36" class="table-data" runat="server" Text='<%#Eval("Quota")%>' />
                                    </td>
                                    <td>
                                        <asp:Label ID="Label37" class="table-data" runat="server" Text='<%#Eval("Post")%>' />
                                    </td>
                                    <td>
                                        <asp:Label ID="Label38" class="table-data" runat="server" Text='<%#Eval("BPS")%>' />
                                    </td>
                                    <td>
                                        <asp:Label ID="Label39" class="table-data" runat="server" Text='<%#Eval("PostStatus")%>' />
                                    </td>
                                    <td>

                                        <asp:Label ID="Label40" class="table-data" runat="server" Text='<%#(Convert.ToString(Eval("IsGazetted"))=="1")?"Yes":"No"%>' />
                                    </td>


                                    <td>
                                        <asp:Label ID="Label41" class="table-data" runat="server" Text='<%#GetDate(Convert.ToDateTime(Eval("EmploymentStatusDate")))%>' />
                                    </td>
                                    <td>
                                        <asp:Label ID="Label42" class="table-data" runat="server" Text='<%#GetDate(Convert.ToDateTime(Eval("ToDate")))%>' />
                                    </td>
                                    <%-- <td>
                           <asp:Label ID="Label16" class="table-data" runat="server" Text='<%#Eval("Details")%>' />
                        </td>--%>

                                    <td>
                                        <asp:Label ID="Label43" class="table-data" runat="server" Text='<%#Eval("CurrentStatus")%>' />
                                    </td>
                                    <td>
                                        <asp:Label ID="Label44" class="table-data" runat="server" Text='<%#GetDate(Convert.ToDateTime(Eval("CurrentStatusDate")))%>' />
                                    </td>
                                    <td>
                                        <asp:Label ID="Label45" class="table-data" runat="server" Text='<%#Eval("Remarks")%>' />
                                    </td>
                                </tr>
                            </ItemTemplate>
                            <EmptyDataTemplate>
                                <tr>
                                    <td colspan="9">
                                        <b>No Other Emloyment details found.</b>
                                    </td>
                                </tr>
                            </EmptyDataTemplate>
                        </asp:ListView>
                    </tbody>
                </table>
            </div>
            <%-------------------------------------------------------------------------OTHER EMPLOYMENT EXTENSION DETAILS--%>
            <div id="extensiondiv" runat="server">
                <div class="row">
                    <div class="col-md-9">
                        <label class="page-header page-title-Medium">Extension Details</label>
                    </div>
                </div>
                <div id="contract">
                    <table class="table table-hover table-striped table-data">
                        <thead style="text-align: center">
                            <tr>
                                <th>Sr#</th>
                                <th>Ref. Id</th>

                                <th>Extended To</th>
                                <th>Remarks</th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:ListView ID="ExtensionLV" runat="server">


                                <ItemTemplate>
                                    <tr>
                                        <td class="itemCent">
                                            <asp:Label ID="Label48" runat="server" class="table-data" Text='<%#Container.DataItemIndex + 1%> ' />
                                        </td>
                                        <td>
                                            <asp:Label ID="Label49" class="table-data" runat="server" Text='<%#Eval("EmploymentHistoryId") %>' />
                                        </td>

                                        <td>
                                            <asp:Label ID="Label50" class="table-data" runat="server" Text='<%#GetDate(Convert.ToDateTime(Eval("ExtendedTo")))%>' />
                                        </td>

                                        <td>
                                            <asp:Label ID="Label51" class="table-data" runat="server" Text='<%#Bind("Remarks")%>' />
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

        <div id="Promotion" class="row">

            <div class="col-md-12">
                <h4>Promotion Details</h4>
                <table class="table table-hover table-striped table-data">
                    <thead style="text-align: center">
                        <tr>
                            <th>Sr#</th>
                            <th>Ref. Id</th>
                            <th>Promotion Type</th>
                            <th>Promotion Mode</th>
                            <th>Post</th>
                            <th>BPS</th>
                            <th>Date</th>
                            <th>Is Gazetted</th>
                            <th>Is Current</th>
                            <th>Remarks</th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:ListView ID="EmpPromotion" runat="server">
                            <ItemTemplate>
                                <tr>
                                    <td class="itemCent">
                                        <asp:HiddenField ID="HidEmpPromotionId" runat="server" Value='<%#Bind("empPromotionId") %>' />
                                        <asp:Label ID="Label25" runat="server" class="table-data" Text='<%#Container.DataItemIndex + 1%> ' />
                                    </td>
                                    <td>
                                        <asp:Label ID="Label26" class="table-data" runat="server" Text='<%#Eval("empPromotionId")%>' />
                                    </td>
                                    <td>
                                        <asp:Label ID="Label27" class="table-data" runat="server" Text='<%#Eval("PromotionType")%>' />
                                    </td>
                                    <td>
                                        <asp:Label ID="Label28" class="table-data" runat="server" Text='<%#Eval("PromotionMode")%>' />
                                    </td>
                                    <td>
                                        <asp:Label ID="Label29" class="table-data" runat="server" Text='<%#Eval("Post")%>' />
                                    </td>
                                    <td>

                                        <asp:Label ID="Label30" class="table-data" runat="server" Text='<%#Eval("Bps") %>' />
                                    </td>
                                    <td>
                                        <asp:Label ID="DateLabel" class="table-data" runat="server" Text='<%#GetDate(Convert.ToDateTime(Eval("PromotionDate")))%>' />
                                    </td>
                                    <td>
                                        <asp:Label ID="Label31" class="table-data" runat="server" Text='<%#(Convert.ToString(Eval("IsGazetted"))=="1")?"Yes":"No"%>' />
                                    </td>
                                    <td>
                                        <asp:Label ID="Label32" class="table-data" runat="server" Text='<%#(Convert.ToString(Eval("IsCurrent"))=="1")?"Yes":"No"%>' />
                                    </td>
                                    <td>
                                        <asp:Label ID="RemarksLabel" class="table-data" runat="server" Text='<%#Bind("Remarks")%>' />
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:ListView>
                </table>
            </div>
        </div>


        <div id="Promotion2" class="row">

            <div class="col-md-12">
                <h4>Promotion Probation Details</h4>
                <table class="table table-hover table-striped table-data">
                    <thead style="text-align: center">
                        <tr>
                            <th>Sr#</th>
                            <th>Ref-Id</th>
                            <th>Probation Type</th>
                            <th>Probation From</th>
                            <th>Probation To</th>
                            <th>Remarks</th>
                        </tr>
                    </thead>
                    <tbody>

                        <asp:ListView ID="PromProbationLV" runat="server">


                            <ItemTemplate>
                                <tr>
                                    <td class="itemCent">

                                        <asp:Label ID="Label3" runat="server" class="table-data" Text='<%#Container.DataItemIndex + 1%> ' />
                                    </td>
                                    <td>
                                        <asp:Label ID="Label11" class="table-data" runat="server" Text='<%#Eval("PromotionId") %>' />
                                    </td>
                                    <td>
                                        <asp:Label ID="Label4" class="table-data" runat="server" Text='<%#Eval("ProbationType")%>' />
                                    </td>
                                    <td>
                                        <asp:Label ID="Label2" class="table-data" runat="server" Text='<%#GetDate(Convert.ToDateTime(Eval("ProbationFrom")))%>' />
                                    </td>
                                    <td>
                                        <asp:Label ID="DateLabel" class="table-data" runat="server" Text='<%#GetDate(Convert.ToDateTime(Eval("ProbationTo")))%>' />
                                    </td>
                                    <td>
                                        <asp:Label ID="Label8" class="table-data" runat="server" Text='<%#Bind("Remarks")%>' />
                                    </td>

                                </tr>
                            </ItemTemplate>
                        </asp:ListView>
                </table>
            </div>
        </div>


        <div id="Postings" class="row">

            <div class="col-md-12">
                <h4>Posting Details</h4>
                <table class="table table-hover table-striped table-condensed table-data">
                    <thead>
                        <tr>
                            <th>Sr#</th>
                            <th>Post</th>
                            <th>BPS</th>
                            <th>Branch</th>
                            <th>Additional Branches</th>
                            <th>From Date</th>
                            <th>To Date</th>
                            <th>Working</th>
                            <th style="width: 30%;">Remarks</th>


                        </tr>
                    </thead>

                    <asp:ListView ID="EmpPostingLv" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td>
                                    <asp:HiddenField ID="HidEmpPostingId" runat="server" Value='<%#Bind("Emp_Posting_Id")%>' />
                                    <asp:Label ID="SrNo" runat="server" Text='<%#Container.DataItemIndex + 1%> '></asp:Label></td>
                                <td>
                                    <asp:Label ID="DegreeLevelLb" runat="server" Text='<%#Bind("Post")%>'></asp:Label></td>
                                <td>
                                    <asp:Label ID="DegreeObtLb" runat="server" Text='<%#Bind("BPSDesc") %>'></asp:Label></td>
                                <td>
                                    <asp:Label ID="Label5" runat="server" Text='<%#Bind("Branch") %>'></asp:Label></td>
                                <td>
                                    <asp:Label ID="Label6" runat="server" Text='<%#Bind("AddtionalBranchesNames") %>'></asp:Label></td>
                                <td>
                                    <asp:Label ID="Label1" runat="server" Text='<%#GetDate(Convert.ToDateTime(Eval("Date_From"))) %>'></asp:Label></td>
                                <td>
                                    <asp:Label ID="Label2" runat="server" Text='<%#GetDate(Convert.ToDateTime(Eval("Date_To"))) %>'></asp:Label></td>
                                <td>
                                    <asp:Label ID="Label4" class="table-data" runat="server" Text='<%#(Convert.ToString(Eval("Working"))=="1")?"Yes":"No"%>' /></td>
                                <td>
                                    <asp:Label ID="Label3" runat="server" Text='<%#Bind("Remarks") %>'></asp:Label></td>
                            </tr>
                        </ItemTemplate>
                    </asp:ListView>
                </table>
            </div>
        </div>
        <div id="NOC" class="row">
             <div class="col-md-12">

                <table class="table table-striped table-condensed table-responsive table-data">
                    <thead>
                        <tr>
                            <th>Sr#</th>
                           
                            <th>NOC Date</th>
                            <th>NOC Type</th>
                            <th>Remarks</th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:ListView ID="EmpNocsLv" runat="server">
                            <ItemTemplate>
                                <tr>

                                    <td class="itemLeft">
                                        <asp:HiddenField ID="HidNocId" runat="server" Value='<%#Bind("NocId")%>' />
                                        <asp:Label ID="SrNo" runat="server" Text='<%#Container.DataItemIndex + 1%> '></asp:Label></td>
                                   <td>
                                        <asp:Label ID="Label5" class="table-data" runat="server" Text='<%#Bind("IssueDate","{0:dd/MM/yyyy}")%>'></asp:Label></td>
                                    <td class="itemLeft">
                                        <asp:Label ID="Label7" class="table-data" runat="server" Text='<%#Bind("NocType")%>'></asp:Label></td>
                                    <td class="itemLeft">
                                        <asp:Label ID="Label4" class="table-data" runat="server" Text='<%#Bind("Remarks")%>'></asp:Label></td>
                                </tr>

                            </ItemTemplate>
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
            return HRMPrint.print("<%= pnlContents.ClientID %>", { title: "EMPLOYMENT DETAILS" });
        }
        function ExportPdf() {
            return HRMPrint.exportPdf("<%= pnlContents.ClientID %>", { title: "EMPLOYMENT DETAILS", fileName: "Employment Details" });
        }
    </script>
    <script type="text/javascript">
        $(function () {

            $("[id$=AppointmentDateTxt]").change(function () {
                $("[id$=ProbationFromTxt]").val($("[id$=AppointmentDateTxt]").val());
                $("[id$=CurrentStatusDateTxt]").val($("[id$=AppointmentDateTxt]").val());

            });



        });
    </script>
</asp:Content>
