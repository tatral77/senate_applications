<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="QuestionManagement.Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        :root {
            --brand: #0c3a72;
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
            .home-hero .chip {
                float: right;
                margin: 6px 0 0 8px;
                padding: 6px 14px;
                background: #f3f6f8;
                border: 1px solid var(--line);
                border-radius: 20px;
                font-size: 13px;
                color: var(--ink);
            }
                .home-hero .chip .glyphicon { color: var(--brand); margin-right: 6px; }

        .section-title {
            font-size: 13px;
            font-weight: 700;
            letter-spacing: .08em;
            text-transform: uppercase;
            color: var(--muted);
            margin: 0 0 12px;
        }

        .stat-card {
            display: block;
            position: relative;
            background: #fff;
            border: 1px solid var(--line);
            border-top: 4px solid var(--accent, var(--brand));
            border-radius: 6px;
            box-shadow: 0 1px 4px rgba(0,0,0,.06);
            padding: 16px 18px;
            margin-bottom: 24px;
            min-height: 118px;
            color: var(--ink);
            transition: box-shadow .15s;
        }

            .stat-card:hover { box-shadow: 0 4px 12px rgba(0,0,0,.12); text-decoration: none; color: var(--ink); }
            .stat-card.accent-green { --accent: #2e8b57; }
            .stat-card.accent-amber { --accent: #e69500; }
            .stat-card.accent-red { --accent: #c0392b; }
            .stat-card.accent-blue { --accent: #1f6fb5; }
            .stat-card.accent-purple { --accent: #7b4fb0; }
            .stat-card.accent-teal { --accent: #12867f; }

        .stat-icon {
            position: absolute;
            right: 16px;
            top: 16px;
            width: 44px;
            height: 44px;
            line-height: 44px;
            text-align: center;
            border-radius: 50%;
            background: #f3f6f8;
            color: var(--accent, var(--brand));
            font-size: 18px;
        }
            .stat-icon .glyphicon { top: 0; line-height: 44px; }

        .stat-count { font-size: 38px; font-weight: 700; line-height: 1.1; color: var(--accent, var(--brand)); }
        .stat-title { margin-top: 4px; font-size: 15px; font-weight: 600; }
        .stat-subtitle { font-size: 12px; color: var(--muted); }
        .stat-link { display: block; margin-top: 8px; font-size: 12px; font-weight: 600; color: var(--accent, var(--brand)); }

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
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <div class="container">

        <div class="home-hero">
            <div class="chip"><span class="glyphicon glyphicon-calendar"></span><%= DateTime.Now.ToString("dddd, dd MMMM yyyy") %></div>
            <asp:Panel ID="SessionChip" runat="server" CssClass="chip"><span class="glyphicon glyphicon-list-alt"></span>Session <asp:Literal ID="SessionLit" runat="server"></asp:Literal></asp:Panel>
            <h2>Question Management System</h2>
            <p>Senate of Pakistan &middot; Current session overview</p>
        </div>

        <h5 class="section-title">Current Session</h5>
        <div class="row">
            <asp:Repeater ID="CardsRepeater" runat="server">
                <ItemTemplate>
                    <div class="col-lg-4 col-md-6">
                        <a class="stat-card <%# Eval("CssClass") %>" href='<%# string.IsNullOrEmpty((string)Eval("LinkUrl")) ? "javascript:void(0)" : Eval("LinkUrl") %>'>
                            <span class="stat-icon"><span class="glyphicon <%# Eval("Icon") %>"></span></span>
                            <div class="stat-count"><%# (int)Eval("Count") < 0 ? "&ndash;" : Eval("Count") %></div>
                            <div class="stat-title"><%# Eval("Title") %></div>
                            <div class="stat-subtitle"><%# Eval("Subtitle") %></div>
                            <%# string.IsNullOrEmpty((string)Eval("LinkUrl")) ? "" : "<span class='stat-link'>View list &rarr;</span>" %>
                        </a>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>

        <h5 class="section-title">About</h5>
        <div class="about-card">
            <h4>Questions</h4>
            <p>Parliamentary Questions are an important means used by Members of Parliament to ensure the Government is accountable to the Parliament for its policies and actions and, through the Parliament, to the people. Questions are used by members on both sides of the House to ask, on behalf of the constituents they represent, a Minister about matters of concern relating to Government policy within a Minister’s portfolio. Through this means, members attempt to obtain information, and often the questions imply criticism of Government policies and actions.</p>
        </div>

    </div>
</asp:Content>
