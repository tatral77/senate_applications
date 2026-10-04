<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="MY.Profile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        /* hero */
        .pf-hero { display: flex; gap: 22px; align-items: center; padding: 22px 26px; margin: 0 0 16px; border-radius: 16px; color: #fff; box-shadow: var(--shadow);
            background: radial-gradient(circle at 92% -30%, rgba(34,220,236,.35), transparent 50%), linear-gradient(100deg, #072b57 0%, #0b5fb3 60%, #0f86d6 100%); }
        .pf-photo { position: relative; flex: none; width: 128px; height: 160px; border-radius: 14px; overflow: hidden; border: 3px solid rgba(255,255,255,.85); background: #dbe7f5; box-shadow: 0 6px 18px rgba(0,0,0,.3); }
        .pf-photo img { width: 100%; height: 100%; object-fit: cover; display: block; }
        .pf-photo .pf-change { position: absolute; left: 0; right: 0; bottom: 0; padding: 5px 0; border: 0; background: rgba(7,43,87,.78); color: #fff; font-size: 12px; font-weight: 600; text-align: center; cursor: pointer; }
        .pf-photo .pf-change:hover { background: rgba(7,43,87,.95); }
        .pf-id { min-width: 0; }
        .pf-name { margin: 0 0 4px; font-size: 27px; font-weight: 700; line-height: 1.2; color: #fff; word-break: break-word; }
        .pf-name span { color: #fff; }
        .pf-post { font-size: 16px; opacity: .95; }
        .pf-post span { color: #fff; }
        .pf-chips { display: flex; flex-wrap: wrap; gap: 8px; margin-top: 12px; }
        .pf-chip { padding: 4px 12px; border-radius: 999px; background: rgba(255,255,255,.16); border: 1px solid rgba(255,255,255,.28); font-size: 12.5px; font-weight: 600; }
        .pf-chip span { color: #fff; }
        .pf-chip:empty, .pf-chip.hide { display: none; }
        /* stats */
        .pf-stats { display: grid; grid-template-columns: repeat(4, 1fr); gap: 12px; margin: 0 0 16px; }
        .pf-stat { padding: 14px 16px; background: #fff; border: 1px solid var(--line); border-radius: 14px; box-shadow: var(--shadow); }
        .pf-stat .k { display: block; font-size: 11.5px; font-weight: 600; text-transform: uppercase; letter-spacing: .4px; color: var(--muted); }
        .pf-stat .v { display: block; margin-top: 2px; font-size: 20px; font-weight: 700; color: var(--brand-dark); }
        .pf-stat .v span { font-size: inherit; font-weight: inherit; color: inherit; }
        /* cards */
        .pf-grid { display: grid; grid-template-columns: 2fr 1fr; gap: 16px; align-items: start; margin-bottom: 16px; }
        .pf-card { background: #fff; border: 1px solid var(--line); border-radius: 14px; box-shadow: var(--shadow); padding: 16px 18px; margin: 0 0 16px; }
        .pf-grid .pf-card:last-child { margin-bottom: 0; }
        .pf-card h4 { display: flex; align-items: center; gap: 8px; margin: 0 0 12px; padding-bottom: 9px; border-bottom: 2px solid #e6eef9; font-size: 14px; font-weight: 700; letter-spacing: .6px; text-transform: uppercase; color: var(--brand-dark); }
        .pf-card h4 .glyphicon { color: var(--brand); }
        .pf-card h4 .n { margin-left: auto; padding: 1px 9px; border-radius: 999px; background: #e8f2fd; color: var(--brand-dark); font-size: 12px; letter-spacing: 0; }
        .pf-kv { display: grid; grid-template-columns: repeat(2, 1fr); gap: 0 26px; margin: 0; }
        .pf-kv > div { padding: 8px 0; border-bottom: 1px solid #edf1f6; min-width: 0; }
        .pf-kv > div.wide { grid-column: 1 / -1; }
        .pf-kv .k { display: block; font-size: 11.5px; font-weight: 600; text-transform: uppercase; letter-spacing: .3px; color: var(--muted); }
        .pf-kv .v { display: block; font-size: 14.5px; font-weight: 600; color: var(--ink); word-break: break-word; }
        .pf-kv .v span:empty::after { content: "\2014"; color: #b8c2cf; font-weight: 400; }
        .pf-kvt { width: 100%; border-collapse: collapse; margin: 0; }
        .pf-kvt td { padding: 8px 10px; border-bottom: 1px solid #edf1f6; vertical-align: top; }
        .pf-kvt td.k { width: 18%; font-size: 11.5px; font-weight: 600; text-transform: uppercase; letter-spacing: .3px; color: var(--muted); }
        .pf-kvt td.v { width: 32%; font-size: 14.5px; font-weight: 600; word-break: break-word; }
        .pf-kvt td.v span:empty::after { content: "\2014"; color: #b8c2cf; font-weight: 400; }
        .pf-toolbar-note { display: none; }
        .pf-subhead { margin: 14px 0 4px; font-size: 12px; font-weight: 700; letter-spacing: .5px; text-transform: uppercase; color: var(--brand); }
        .pf-card .table { margin-bottom: 0; }
        .pf-empty { padding: 16px; text-align: center; color: var(--muted); }
        .pf-note { color: var(--muted); font-size: 12.5px; }
        @media (max-width: 991px) { .pf-grid { grid-template-columns: 1fr; } .pf-stats { grid-template-columns: repeat(2, 1fr); } }
        @media (max-width: 767px) {
            .pf-hero { flex-direction: column; text-align: center; padding: 18px; }
            .pf-chips { justify-content: center; }
            .pf-name { font-size: 22px; }
            .pf-kvt, .pf-kvt tbody, .pf-kvt tr, .pf-kvt td { display: block; width: 100% !important; }
            .pf-kvt td.k { padding-bottom: 0; border-bottom: 0; }
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="nf-head">
        <h4>PERSONAL INFORMATION</h4>
        <div class="nf-toolbar">
            <asp:Button class="btn btn-custom" ID="PrintBtn" runat="server" Text="Print Profile" OnClientClick="return PrintPanel();" UseSubmitBehavior="false" />
            <input type="button" class="btn btn-default" value="Export PDF" onclick="return ExportPdf();" />
        </div>
    </div>
    <asp:Label ID="ErrLbl" runat="server" CssClass="nf-err"></asp:Label>

    <asp:Panel ID="pnlContents" runat="server">

        <div class="pf-hero hid">
            <div class="pf-photo">
                <asp:Image ID="PhotoImg" runat="server" AlternateText="Employee photo" />
                <button type="button" class="pf-change no-print" data-toggle="modal" data-target="#myModal"><span class="glyphicon glyphicon-camera"></span> Change photo</button>
            </div>
            <div class="pf-id">
                <h2 class="pf-name">
                    <asp:Label ID="title" runat="server"></asp:Label>
                    <asp:Label ID="EmpNametxt" runat="server"></asp:Label></h2>
                <div class="pf-post">
                    <asp:Label ID="HeroPost" runat="server"></asp:Label></div>
                <div class="pf-chips">
                    <span class="pf-chip"><span class="glyphicon glyphicon-briefcase"></span>
                        <asp:Label ID="HeroBranch" runat="server"></asp:Label></span>
                    <span class="pf-chip"><span class="glyphicon glyphicon-ok-circle"></span>
                        <asp:Label ID="HeroStatus" runat="server"></asp:Label></span>
                    <span class="pf-chip"><span class="glyphicon glyphicon-credit-card"></span>
                        <asp:Label ID="HeroCnic" runat="server"></asp:Label></span>
                </div>
            </div>
        </div>

        <div class="pf-stats hid">
            <div class="pf-stat"><span class="k">Age</span><span class="v">
                <asp:Label ID="StatAge" runat="server" Text="-"></asp:Label></span></div>
            <div class="pf-stat"><span class="k">Service in Senate</span><span class="v">
                <asp:Label ID="StatSenate" runat="server" Text="-"></asp:Label></span></div>
            <div class="pf-stat"><span class="k">Total Govt Service</span><span class="v">
                <asp:Label ID="StatGovt" runat="server" Text="-"></asp:Label></span></div>
            <div class="pf-stat"><span class="k">Superannuation</span><span class="v">
                <asp:Label ID="StatSuper" runat="server" Text="-"></asp:Label></span></div>
        </div>

        <asp:Literal ID="SheetLit" runat="server"></asp:Literal>

        <div class="pf-grid">
            <div>
                <div class="pf-card">
                    <h4><span class="glyphicon glyphicon-user"></span>Personal Details</h4>
                    <table class="pf-kvt">
                        <tr><td class="k">Father / Husband Name</td><td class="v" colspan="3"><asp:Label ID="FatherNametxt" runat="server"></asp:Label></td></tr>
                        <tr><td class="k">Gender</td><td class="v"><asp:Label ID="Gender" runat="server"></asp:Label></td><td class="k">Marital Status</td><td class="v"><asp:Label ID="MaritalStatus" runat="server"></asp:Label></td></tr>
                        <tr><td class="k">Date of Birth</td><td class="v"><asp:Label ID="DOB" runat="server"></asp:Label></td><td class="k">Place of Birth</td><td class="v"><asp:Label ID="BirthPlace" runat="server"></asp:Label></td></tr>
                        <tr><td class="k">Religion</td><td class="v"><asp:Label ID="Religion" runat="server"></asp:Label></td><td class="k">NTN</td><td class="v"><asp:Label ID="NTN" runat="server"></asp:Label></td></tr>
                        <tr><td class="k">Province</td><td class="v"><asp:Label ID="PermProvince" runat="server"></asp:Label></td><td class="k">Domicile</td><td class="v"><asp:Label ID="DomDistrict" runat="server"></asp:Label></td></tr>
                    </table>

                    <div class="pf-subhead">Identity Card</div>
                    <table class="pf-kvt">
                        <tr><td class="k">CNIC No</td><td class="v"><asp:Label ID="CNIC" runat="server"></asp:Label></td><td class="k">Place of Issue</td><td class="v"><asp:Label ID="CNICIssuePlace" runat="server"></asp:Label></td></tr>
                        <tr><td class="k">Issue Date</td><td class="v"><asp:Label ID="CNICDate" runat="server"></asp:Label></td><td class="k">Expiry Date</td><td class="v"><asp:Label ID="CNICExpDateTxt" runat="server"></asp:Label></td></tr>
                    </table>

                    <div class="pf-subhead">Addresses</div>
                    <table class="pf-kvt">
                        <tr><td class="k">Permanent Address</td><td class="v" colspan="3"><asp:Label ID="PermAddress" runat="server"></asp:Label></td></tr>
                        <tr><td class="k">Permanent Address City</td><td class="v" colspan="3"><asp:Label ID="PermCity" runat="server"></asp:Label></td></tr>
                        <tr><td class="k">Local Address</td><td class="v" colspan="3"><asp:Label ID="LocalAddress" runat="server"></asp:Label></td></tr>
                        <tr><td class="k">Local Address City</td><td class="v" colspan="3"><asp:Label ID="LocalCity" runat="server"></asp:Label></td></tr>
                    </table>
                </div>
            </div>

            <div>
                <div class="pf-card">
                    <h4><span class="glyphicon glyphicon-earphone"></span>Phone Numbers</h4>
                    <table class="table table-condensed table-hover">
                        <thead>
                            <tr>
                                <th>Type</th>
                                <th>Number</th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:ListView ID="EmpPhones" runat="server">
                                <ItemTemplate>
                                    <tr>
                                        <td>
                                            <asp:HiddenField ID="HidEmpPhoneId" runat="server" Value='<%#Bind("EmpPhoneId")%>' />
                                            <asp:HiddenField ID="HidPhoneTypeId" runat="server" Value='<%#Bind("PhoneTypeId")%>' />
                                            <asp:Label ID="Label4" runat="server" Text='<%#Eval("PhoneType")%>' />
                                        </td>
                                        <td><b>
                                            <asp:Label ID="nameLabel" runat="server" Text='<%#Eval("PhoneNumber")%>' /></b>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                                <EmptyDataTemplate>
                                    <tr>
                                        <td colspan="2" class="pf-empty">No phone numbers recorded.</td>
                                    </tr>
                                </EmptyDataTemplate>
                            </asp:ListView>
                        </tbody>
                    </table>
                </div>

                <div class="pf-card">
                    <h4><span class="glyphicon glyphicon-envelope"></span>Email Addresses</h4>
                    <table class="table table-condensed table-hover">
                        <thead>
                            <tr>
                                <th>Email</th>
                                <th>Official</th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:ListView ID="EmailLV" runat="server">
                                <ItemTemplate>
                                    <tr>
                                        <td>
                                            <asp:HiddenField ID="HidUserEmailId" runat="server" Value='<%#Bind("UserEmailId")%>' />
                                            <asp:Label ID="Label6" runat="server" Text='<%#Eval("Email")%>' />
                                        </td>
                                        <td>
                                            <asp:Label ID="Label7" runat="server" Text='<%#(Convert.ToString(Eval("IsOfficial"))=="1")?"Yes":"No"%>' />
                                        </td>
                                    </tr>
                                </ItemTemplate>
                                <EmptyDataTemplate>
                                    <tr>
                                        <td colspan="2" class="pf-empty">No email addresses recorded.</td>
                                    </tr>
                                </EmptyDataTemplate>
                            </asp:ListView>
                        </tbody>
                    </table>
                </div>
            </div>
        </div>

        <div id="qualification" class="pf-card">
            <h4><span class="glyphicon glyphicon-education"></span>Qualification <span class="n"><%= EmpQualificationLv.Items.Count %></span></h4>
            <table class="table table-hover table-striped table-condensed table-data">
                <thead>
                    <tr>
                        <th>Sr#</th>
                        <th>Degree Level</th>
                        <th>Discipline</th>
                        <th>Subjects</th>
                        <th>Institution</th>
                        <th>Country</th>
                        <th>Completion Year</th>
                        <th>Grade</th>
                        <th>CGPA</th>
                        <th>Percentage</th>
                        <th>Division</th>
                    </tr>
                </thead>
                <tbody>
                    <asp:ListView ID="EmpQualificationLv" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td>
                                    <asp:HiddenField ID="HidEmpQualificationId" runat="server" Value='<%#Bind("Emp_Qualification_Id")%>' />
                                    <asp:Label ID="SrNo" runat="server" Text='<%#Container.DataItemIndex + 1%>'></asp:Label></td>
                                <td>
                                    <asp:Label ID="DegreeLevelLb" runat="server" Text='<%# GetDegreeLevel(Convert.ToInt32(Eval("Degree_Level_Id")))%>'></asp:Label></td>
                                <td>
                                    <asp:Label ID="DegreeObtLb" runat="server" Text='<%#Eval("Degree_Obtained") %>'></asp:Label></td>
                                <td>
                                    <asp:Label ID="Label1" runat="server" Text='<%#Eval("Subjects") %>'></asp:Label></td>
                                <td>
                                    <asp:Label ID="Label2" runat="server" Text='<%#Eval("Institution_Name") %>'></asp:Label></td>
                                <td>
                                    <asp:Label ID="Label8" runat="server" Text='<%# GetCountry(Convert.ToInt32(Eval("Country_Id")))%>'></asp:Label></td>
                                <td style="text-align: center">
                                    <asp:Label ID="Label9" runat="server" Text='<%#Eval("Completion_Year")%>'></asp:Label></td>
                                <td style="text-align: center">
                                    <asp:Label ID="Label10" runat="server" Text='<%#Eval("Grade")%>'></asp:Label></td>
                                <td style="text-align: center">
                                    <asp:Label ID="Label11" runat="server" Text='<%# Eval("Cgpa").ToString()=="0" ? "":Eval("Cgpa")%>'></asp:Label></td>
                                <td style="text-align: center">
                                    <asp:Label ID="Label12" runat="server" Text='<%# Eval("Percentage").ToString()=="0" ? "":Eval("Percentage")%>'></asp:Label></td>
                                <td style="text-align: center">
                                    <asp:Label ID="Label13" runat="server" Text='<%# Eval("Division")%>'></asp:Label></td>
                            </tr>
                        </ItemTemplate>
                        <EmptyDataTemplate>
                            <tr>
                                <td colspan="11" class="pf-empty">No qualifications recorded.</td>
                            </tr>
                        </EmptyDataTemplate>
                    </asp:ListView>
                </tbody>
            </table>
        </div>

        <div id="Trainings" class="pf-card">
            <h4><span class="glyphicon glyphicon-blackboard"></span>Trainings <span class="n"><%= EmpCoursesLv.Items.Count %></span></h4>
            <table class="table table-hover table-striped table-condensed table-data">
                <thead>
                    <tr>
                        <th>Sr#</th>
                        <th>Course Name</th>
                        <th>Course Type</th>
                        <th>Mandatory</th>
                        <th>Deg/Dip/Cert</th>
                        <th>Institution</th>
                        <th>Country</th>
                        <th>From</th>
                        <th>To</th>
                        <th>Sponsored By</th>
                    </tr>
                </thead>
                <tbody>
                    <asp:ListView ID="EmpCoursesLv" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td>
                                    <asp:HiddenField ID="HidEmpCourseId" runat="server" Value='<%#Bind("EmpCourseId")%>' />
                                    <asp:Label ID="Label14" runat="server" Text='<%#Container.DataItemIndex + 1%>'></asp:Label></td>
                                <td>
                                    <asp:Label ID="PassportNumber" runat="server" Text='<%#Eval("CourseName")%>'></asp:Label></td>
                                <td>
                                    <asp:Label ID="Label15" runat="server" Text='<%#GetCourseType(Convert.ToInt32(Eval("CourseTypeId")))%>'></asp:Label></td>
                                <td>
                                    <asp:Label ID="Label16" runat="server" Text='<%#(Convert.ToString(Eval("Mandatory"))=="1")?"Yes":"No"%>' /></td>
                                <td>
                                    <asp:Label ID="Label17" runat="server" Text='<%#Eval("DegDipCert")%>'></asp:Label></td>
                                <td>
                                    <asp:Label ID="IssuePlace" runat="server" Text='<%#Eval("InstitutionName") %>'></asp:Label></td>
                                <td>
                                    <asp:Label ID="Label18" runat="server" Text='<%# GetCountry(Convert.ToInt32(Eval("CountryId")))%>'></asp:Label></td>
                                <td>
                                    <asp:Label ID="Label19" runat="server" Text='<%#Eval("FromDate","{0:dd/MM/yyyy}")%>'></asp:Label></td>
                                <td>
                                    <asp:Label ID="Label20" runat="server" Text='<%#Eval("ToDate","{0:dd/MM/yyyy}")%>'></asp:Label></td>
                                <td>
                                    <asp:Label ID="Label21" runat="server" Text='<%#Eval("SponsoredBy")%>'></asp:Label></td>
                            </tr>
                        </ItemTemplate>
                        <EmptyDataTemplate>
                            <tr>
                                <td colspan="10" class="pf-empty">No trainings recorded.</td>
                            </tr>
                        </EmptyDataTemplate>
                    </asp:ListView>
                </tbody>
            </table>
        </div>

        <div id="Dependants" class="pf-card">
            <h4><span class="glyphicon glyphicon-heart-empty"></span>Dependants <span class="n"><%= EmpDependantLV.Items.Count %></span></h4>
            <table class="table table-hover table-striped table-condensed table-data">
                <thead>
                    <tr>
                        <th>Sr#</th>
                        <th>Name</th>
                        <th>Relation</th>
                        <th>Date of Birth</th>
                        <th>Years</th>
                        <th>Months</th>
                    </tr>
                </thead>
                <tbody>
                    <asp:ListView ID="EmpDependantLV" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td>
                                    <asp:HiddenField ID="HidEmpDependantId" runat="server" Value='<%#Bind("EmpDependantId") %>' />
                                    <asp:Label ID="Label23" runat="server" Text='<%#Container.DataItemIndex + 1%>' />
                                </td>
                                <td>
                                    <asp:Label ID="DesignationLabel" runat="server" Text='<%#Eval("DependantName") %>' />
                                </td>
                                <td>
                                    <asp:Label ID="BranchLabel" runat="server" Text='<%#Eval("RelationshipName")%>' />
                                </td>
                                <td>
                                    <asp:Label ID="PostedFrom" runat="server" Text='<%#GetDate(Convert.ToDateTime(Eval("DOB")))%>' />
                                </td>
                                <td>
                                    <asp:Label ID="Label24" runat="server" Text='<%#Eval("AgeYears")%>' />
                                </td>
                                <td>
                                    <asp:Label ID="Remarks" runat="server" Text='<%#Eval("AgeMonths") %>' />
                                </td>
                            </tr>
                        </ItemTemplate>
                        <EmptyDataTemplate>
                            <tr>
                                <td colspan="6" class="pf-empty">No dependants recorded.</td>
                            </tr>
                        </EmptyDataTemplate>
                    </asp:ListView>
                </tbody>
            </table>
        </div>
    </asp:Panel>

    <div class="pf-note">Something wrong in your record? Use <a href="Corrections.aspx">Corrections</a> to report it to the HRM branch.</div>

    <%-- photo dialog --%>
    <div id="myModal" class="modal fade" role="dialog">
        <div class="modal-dialog modal-sm">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                    <h4 class="modal-title">Change Photo</h4>
                </div>
                <div class="modal-body">
                    <asp:FileUpload ID="FileUpload1" runat="server" accept="image/jpeg,image/png,image/gif" data-scan="true" />
                    <div class="pf-note" style="margin-top: 8px">JPG, PNG or GIF, up to 2 MB.</div>
                </div>
                <div class="modal-footer">
                    <asp:Button ID="SaveImage" runat="server" Text="Upload" class="btn btn-custom" OnClick="SaveImage_Click"></asp:Button>
                    <button type="button" class="btn btn-default" data-dismiss="modal">Cancel</button>
                </div>
            </div>
        </div>
    </div>

    <script src='<%= ResolveUrl("~/Scripts/hrmprint.js") %>' type="text/javascript"></script>
    <script type="text/javascript">
        // hide hero chips that have no value
        (function () {
            var chips = document.querySelectorAll('.pf-chip');
            for (var i = 0; i < chips.length; i++) {
                if (!chips[i].textContent.replace(/\s+/g, '')) { chips[i].className += ' hide'; }
            }
        })();
        function PrintPanel() {
            return HRMPrint.print("<%= pnlContents.ClientID %>", { title: "EMPLOYEE PROFILE", orientation: "portrait" });
        }
        function ExportPdf() {
            return HRMPrint.exportPdf("<%= pnlContents.ClientID %>", { title: "EMPLOYEE PROFILE", orientation: "portrait", fileName: "Employee Profile" });
        }
    </script>
</asp:Content>
