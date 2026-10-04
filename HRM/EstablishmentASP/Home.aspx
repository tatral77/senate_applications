<%@ Page Title="" Language="C#" MasterPageFile="~/MainMaster.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="EstablishmentASP.Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        :root {
            --brand: #086623;
            --brand-dark: #054a18;
            --ink: #1f2d3d;
            --muted: #6b7785;
            --line: #e4e9ee;
        }

        .home-hero {
            padding: 4px 0 16px;
            margin: 6px 0 22px;
            border-bottom: 1px solid var(--line);
            overflow: hidden;
        }

            .home-hero h2 { margin: 0 0 2px; font-weight: 600; font-size: 24px; color: var(--ink); }
            .home-hero p { margin: 0; color: var(--muted); font-size: 14px; }
            .home-hero .today {
                float: right;
                margin-top: 6px;
                padding: 6px 14px;
                background: #f3f6f8;
                border: 1px solid var(--line);
                border-radius: 20px;
                font-size: 13px;
                color: var(--ink);
            }
            .home-hero .today .glyphicon { color: var(--brand); margin-right: 6px; }

        .section-title {
            font-size: 13px;
            font-weight: 700;
            letter-spacing: .08em;
            text-transform: uppercase;
            color: var(--muted);
            margin: 0 0 12px;
        }

        .dash-card {
            background: #fff;
            border: 1px solid var(--line);
            border-top: 4px solid var(--accent, var(--brand));
            border-radius: 6px;
            box-shadow: 0 1px 4px rgba(0,0,0,.06);
            margin-bottom: 24px;
            transition: box-shadow .15s;
        }

            .dash-card:hover { box-shadow: 0 4px 12px rgba(0,0,0,.12); }
            .dash-card.accent-red { --accent: #c0392b; }
            .dash-card.accent-amber { --accent: #e69500; }
            .dash-card.accent-blue { --accent: #1f6fb5; }

        .dash-head { padding: 14px 16px 10px; border-bottom: 1px solid var(--line); overflow: hidden; }
        .dash-count {
            float: right;
            min-width: 44px;
            height: 44px;
            line-height: 44px;
            text-align: center;
            border-radius: 50%;
            background: var(--accent, var(--brand));
            color: #fff;
            font-size: 20px;
            font-weight: 700;
        }
        .dash-title { margin: 0; font-size: 16px; font-weight: 700; color: var(--ink); }
        .dash-subtitle { font-size: 12px; color: var(--muted); }

        .dash-list { max-height: 300px; overflow-y: auto; padding: 4px 0; }
        .dash-item { display: flex; align-items: center; padding: 9px 16px; border-bottom: 1px solid #f1f4f7; }
            .dash-item:last-child { border-bottom: 0; }
            .dash-item:hover { background: #f8fafb; }
        .dash-avatar {
            flex: 0 0 36px;
            width: 36px;
            height: 36px;
            line-height: 36px;
            text-align: center;
            border-radius: 50%;
            background: #eef2f5;
            color: var(--accent, var(--brand));
            font-weight: 700;
            font-size: 13px;
            margin-right: 12px;
        }
        .dash-body { flex: 1; min-width: 0; }
            .dash-body a { font-weight: 600; color: var(--ink); display: block; white-space: nowrap; overflow: hidden; text-overflow: ellipsis; }
            .dash-body a:hover { color: var(--brand); text-decoration: none; }
        .dash-sub { font-size: 12px; color: var(--muted); white-space: nowrap; overflow: hidden; text-overflow: ellipsis; }
        .dash-date {
            flex: 0 0 auto;
            margin-left: 10px;
            text-align: right;
            font-size: 12px;
            font-weight: 600;
            color: var(--accent, var(--brand));
        }
            .dash-date small { display: block; font-weight: 400; color: var(--muted); }

        .dash-empty { padding: 28px 16px; text-align: center; color: var(--muted); font-size: 13px; }
            .dash-empty .glyphicon { display: block; font-size: 24px; margin-bottom: 6px; color: #b8c2cc; }

        .about-card {
            background: #fff;
            border: 1px solid var(--line);
            border-left: 4px solid var(--brand);
            border-radius: 6px;
            padding: 18px 22px;
            margin-bottom: 30px;
            line-height: 1.6;
            font-size: 14px;
            color: #3c4858;
        }
            .about-card h4 { margin-top: 0; font-weight: 700; color: var(--ink); font-size: 16px; }
            .about-card p:last-child { margin-bottom: 0; }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">

        <div class="home-hero">
            <div class="today">
                <span class="glyphicon glyphicon-calendar"></span><%= DateTime.Now.ToString("dddd, dd MMMM yyyy") %>
            </div>
            <h2>Human Resource Management System</h2>
            <p>Senate of Pakistan &middot; HR overview and upcoming events</p>
        </div>

        <h5 class="section-title">Upcoming Events</h5>
        <div class="row">
            <asp:Repeater ID="CardsRepeater" runat="server">
                <ItemTemplate>
                    <div class="col-lg-4 col-md-6">
                        <div class="dash-card <%# Eval("CssClass") %>">
                            <div class="dash-head">
                                <span class="dash-count"><%# Eval("Count") %></span>
                                <h3 class="dash-title"><%# Eval("Title") %></h3>
                                <div class="dash-subtitle"><%# Eval("Subtitle") %></div>
                            </div>
                            <div class="dash-list">
                                <asp:Repeater ID="EmployeesRepeater" runat="server" DataSource='<%# Eval("Employees") %>'>
                                    <ItemTemplate>
                                        <div class="dash-item">
                                            <div class="dash-avatar"><%# Initials(Eval("EmployeeName")) %></div>
                                            <div class="dash-body">
                                                <a href='EmploymentDetails.aspx?EmpId=<%# Eval("SystemUsersId") %>'><%# Eval("EmployeeName") %></a>
                                                <div class="dash-sub"><%# Eval("Post") %> (<%# Eval("Bps") %>)<%# string.IsNullOrEmpty(Convert.ToString(Eval("Detail"))) ? "" : " &middot; " + Eval("Detail") %></div>
                                            </div>
                                            <div class="dash-date">
                                                <%# Eval("Date", "{0:dd MMM yyyy}") %>
                                                <small><%# Eval("DateLabel") %></small>
                                            </div>
                                        </div>
                                    </ItemTemplate>
                                </asp:Repeater>
                                <%# (int)Eval("Count") == 0 ? "<div class='dash-empty'><span class='glyphicon glyphicon-ok-circle'></span>No employees in this period</div>" : "" %>
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>

        <h5 class="section-title">About</h5>
        <div class="about-card">
            <h4>Human Resource Management</h4>
            <p>HRM is primarily concerned with the management of people within organizations, focusing on policies. It involves all management decisions and practices that directly influence the people who work for the organization. HRM is an integral part of management. It involves taking decisions and their execution for the effective management of people for the accomplishment of organizational objectives and also for the satisfaction of the needs and aspirations of people.</p>

            <h4>HRMS (Human Resource Management System)</h4>
            <p>Main function of an HR Management System is to standardize and consolidate the core processes related to Human Resource management. HRMS is used in Recruitment, Employment, Promotion, Probation, Leave, Succession planning, Career progression, Training &amp; Development, Performance Management and the overall maintenance of employee information within an organization. HRM tasks are too complex and time-consuming when performed manually. Leveraging the help of a technological solution like an HRMS can help HRM to save time, cut costs, and manage staff efficiently &amp; effectively. HRMS helps the higher authorities in decision making and implementing new strategies.</p>
        </div>

    </div>
</asp:Content>
