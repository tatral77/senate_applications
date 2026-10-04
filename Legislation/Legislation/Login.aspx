<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Legislation.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>LIS Login</title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <style type="text/css">
        * { box-sizing: border-box; }

        html, body { margin: 0; min-height: 100%; }

        body {
            font-family: "Segoe UI", system-ui, -apple-system, "Helvetica Neue", Arial, sans-serif;
            font-size: 14px;
            color: #1f2937;
            background:
                radial-gradient(circle at 8% 8%, rgba(34, 220, 236, .30), transparent 38%),
                radial-gradient(circle at 92% 92%, rgba(63, 164, 234, .35), transparent 42%),
                linear-gradient(135deg, #0c3a72 0%, #124f96 45%, #1f6fc5 100%);
            background-attachment: fixed;
        }

        .lg-shell {
            max-width: 1240px;
            margin: 0 auto;
            padding: 26px 24px 18px;
            min-height: 100vh;
            display: flex;
            flex-direction: column;
        }

        .lg-brand { display: flex; align-items: center; color: #fff; margin-bottom: 26px; }
        .lg-emblem { width: auto; height: 104px; margin-right: 20px; padding: 8px 12px; background: #fff; border-radius: 14px; box-shadow: 0 6px 18px rgba(0, 0, 0, .30); }
        .lg-org { font-size: 28px; font-weight: 700; letter-spacing: 4px; line-height: 1.15; text-shadow: 0 1px 3px rgba(0, 0, 0, .3); }
        .lg-sub { font-size: 14px; letter-spacing: 2px; opacity: .9; margin-top: 3px; }

        .lg-main {
            flex: 1;
            display: grid;
            grid-template-columns: 380px 1fr;
            gap: 28px;
            align-items: start;
        }

        .lg-card {
            background: #fff;
            border-radius: 16px;
            box-shadow: 0 18px 50px rgba(3, 20, 45, .35);
            padding: 30px 30px 26px;
        }
        .lg-card h2 { margin: 0 0 4px; font-size: 22px; font-weight: 700; color: #124f96; }
        .lg-card .lg-hint { margin: 0 0 22px; color: #6b7280; }

        .lg-field { margin-bottom: 16px; }
        .lg-field label { display: block; font-weight: 600; color: #374151; margin-bottom: 6px; }
        .lg-input { position: relative; }
        .lg-input svg { position: absolute; left: 12px; top: 50%; margin-top: -9px; width: 18px; height: 18px; fill: none; stroke: #94a3b8; stroke-width: 1.8; stroke-linecap: round; stroke-linejoin: round; }
        .lg-input input {
            width: 100%;
            height: 44px;
            padding: 0 44px 0 40px;
            border: 1px solid #cbd5e1;
            border-radius: 10px;
            font-family: inherit;
            font-size: 15px;
            color: #1f2937;
            background: #fff;
            transition: border-color .15s, box-shadow .15s;
        }
        .lg-input input:focus { outline: 0; border-color: #1f6fc5; box-shadow: 0 0 0 3px rgba(31, 111, 197, .20); }
        .lg-toggle {
            position: absolute; right: 6px; top: 50%; margin-top: -15px;
            height: 30px; padding: 0 10px; border: 0; border-radius: 8px;
            background: transparent; color: #1f6fc5; font-size: 12.5px; font-weight: 600; cursor: pointer;
        }
        .lg-toggle:hover { background: #e8f2fd; }

        .lg-btn {
            width: 100%;
            height: 46px;
            margin-top: 6px;
            border: 0;
            border-radius: 10px;
            background: linear-gradient(180deg, #2a7fd6, #1f6fc5);
            color: #fff;
            font-family: inherit;
            font-size: 16px;
            font-weight: 600;
            letter-spacing: .5px;
            cursor: pointer;
            box-shadow: 0 6px 16px rgba(31, 111, 197, .35);
            transition: transform .1s, box-shadow .15s, background .15s;
        }
        .lg-btn:hover { background: linear-gradient(180deg, #3a8fe6, #2578cf); box-shadow: 0 8px 20px rgba(31, 111, 197, .45); }
        .lg-btn:active { transform: translateY(1px); }

        .lg-error {
            display: block;
            margin-top: 14px;
            padding: 10px 12px;
            border-radius: 10px;
            background: #fef1f1;
            border: 1px solid #f9c2c2;
            color: #8a1c1c;
            font-weight: 600;
            text-align: center;
        }
        .lg-error:empty { display: none; }

        .lg-apps h3 { margin: 4px 0 14px; color: #fff; font-size: 17px; font-weight: 600; letter-spacing: 2px; text-transform: uppercase; opacity: .95; }
        .lg-grid { display: grid; grid-template-columns: repeat(3, 1fr); gap: 14px; }
        .lg-app {
            display: flex;
            align-items: center;
            padding: 14px 16px;
            background: #fff;
            border-radius: 14px;
            text-decoration: none;
            color: #1f2937;
            box-shadow: 0 6px 18px rgba(3, 20, 45, .22);
            transition: transform .15s, box-shadow .15s;
        }
        .lg-app:hover { transform: translateY(-3px); box-shadow: 0 12px 26px rgba(3, 20, 45, .32); text-decoration: none; color: #1f2937; }
        .lg-app .lg-ico { margin-top: 0; font-size: 0; width: 54px; height: 54px; margin-right: 14px; flex: none; border-radius: 15px; display: flex !important; align-items: center; justify-content: center; color: #fff !important; box-shadow: 0 5px 12px rgba(0, 0, 0, .18), inset 0 1px 0 rgba(255, 255, 255, .35); transition: transform .15s; }
        .lg-app .lg-ico svg { width: 28px; height: 28px; fill: none; stroke: currentColor; stroke-width: 1.8; stroke-linecap: round; stroke-linejoin: round; filter: drop-shadow(0 1px 1px rgba(0, 0, 0, .2)); }
        .lg-app:hover .lg-ico { transform: scale(1.08) rotate(-3deg); }
        .i-hrm { background: linear-gradient(135deg, #3b82f6, #1d4ed8); }
        .i-question { background: linear-gradient(135deg, #f59e0b, #d97706); }
        .i-budget { background: linear-gradient(135deg, #10b981, #047857); }
        .i-notice { background: linear-gradient(135deg, #06b6d4, #0e7490); }
        .i-finance { background: linear-gradient(135deg, #84cc16, #4d7c0f); }
        .i-service { background: linear-gradient(135deg, #8b5cf6, #6d28d9); }
        .i-motion { background: linear-gradient(135deg, #ef4444, #b91c1c); }
        .i-my { background: linear-gradient(135deg, #0ea5e9, #0369a1); }
        .i-ipr { background: linear-gradient(135deg, #eab308, #a16207); }
        .i-committees { background: linear-gradient(135deg, #ec4899, #be185d); }
        .i-legis { background: linear-gradient(135deg, #14b8a6, #0f766e); }
        .i-trans { background: linear-gradient(135deg, #6366f1, #4338ca); }
        .lg-app img { width: 54px; height: 54px; object-fit: contain; margin-right: 14px; flex: none; }
        .lg-app b { display: block; font-size: 13px; letter-spacing: .4px; color: #124f96; line-height: 1.25; }
        .lg-app span { display: block; font-size: 12.5px; color: #6b7280; margin-top: 2px; }

        .lg-foot { text-align: center; color: rgba(255, 255, 255, .8); font-size: 12.5px; padding-top: 22px; letter-spacing: .5px; }

        @media (max-width: 1000px) {
            .lg-main { grid-template-columns: 1fr; }
            .lg-card { max-width: 440px; width: 100%; margin: 0 auto; }
            .lg-grid { grid-template-columns: repeat(2, 1fr); }
        }
        @media (max-width: 560px) {
            .lg-org { font-size: 19px; letter-spacing: 2px; }
            .lg-emblem { width: auto; height: 72px; margin-right: 12px; padding: 5px 8px; border-radius: 10px; }
            .lg-grid { grid-template-columns: 1fr; }
            .lg-app .lg-ico { width: 48px; height: 48px; }
            .lg-shell { padding: 18px 14px; }
            .lg-card { padding: 22px 20px; }
        }
    </style>
</head>
<body>
    <form id="form1" runat="server" defaultbutton="Button1">
        <div class="lg-shell">

            <div class="lg-brand">
                <asp:Image ID="logoImage" runat="server" ImageUrl="~/Images/senate-logo.png" AlternateText="Senate Logo" CssClass="lg-emblem" />
                <div>
                    <div class="lg-org">SENATE OF PAKISTAN</div>
                    <div class="lg-sub">Software Applications</div>
                </div>
            </div>

            <div class="lg-main">

                <div class="lg-card">
                    <h2>Legislation Management System</h2>
                    <p class="lg-hint">Sign in to continue</p>

                    <div class="lg-field">
                        <asp:Label ID="Label1" runat="server" Text="User Name" AssociatedControlID="UserName"></asp:Label>
                        <div class="lg-input">
                            <svg viewBox="0 0 24 24"><circle cx="12" cy="8" r="4" /><path d="M4 21c0-4.4 3.6-7 8-7s8 2.6 8 7" /></svg>
                            <asp:TextBox ID="UserName" runat="server" placeholder="Enter user name" autocomplete="username"></asp:TextBox>
                        </div>
                    </div>

                    <div class="lg-field">
                        <asp:Label ID="Label2" runat="server" Text="Password" AssociatedControlID="Password"></asp:Label>
                        <div class="lg-input">
                            <svg viewBox="0 0 24 24"><rect x="4" y="10" width="16" height="10" rx="2" /><path d="M8 10V7a4 4 0 0 1 8 0v3" /></svg>
                            <asp:TextBox ID="Password" runat="server" TextMode="Password" placeholder="Enter password" autocomplete="current-password"></asp:TextBox>
                            <button type="button" class="lg-toggle" id="togglePwd" tabindex="-1">Show</button>
                        </div>
                    </div>

                    <asp:Button ID="Button1" runat="server" Text="Login" CssClass="lg-btn" OnClick="Button1_Click" />
                    <asp:Label ID="errorlbl" runat="server" CssClass="lg-error" Text=""></asp:Label>
                    <asp:Label ID="Label3" runat="server" Text="" Visible="false"></asp:Label>
                </div>

                <div class="lg-apps">
                    <h3>Senate Applications</h3>
                    <div class="lg-grid">
                        <a class="lg-app" href="http://hrm.senate.gov.pk"><span class="lg-ico i-hrm"><svg viewBox="0 0 24 24" aria-hidden="true"><circle cx="9" cy="8" r="3.2"/><path d="M3 20c0-3.4 2.7-6 6-6s6 2.6 6 6"/><circle cx="17" cy="9" r="2.5"/><path d="M16.5 14.2c2.7.4 4.5 2.4 4.5 5.8"/></svg></span><div><b>HR MANAGEMENT SYSTEM</b><span>HRM Branch</span></div></a>
                        <a class="lg-app" href="http://question.senate.gov.pk"><span class="lg-ico i-question"><svg viewBox="0 0 24 24" aria-hidden="true"><circle cx="12" cy="12" r="9"/><path d="M9.5 9.6a2.6 2.6 0 1 1 3.7 2.3c-.8.4-1.2 1-1.2 1.9"/><path d="M12 17.2h.01"/></svg></span><div><b>QUESTION MANAGEMENT SYSTEM</b><span>Question Branch</span></div></a>
                        <a class="lg-app" href="http://budget.senate.gov.pk"><span class="lg-ico i-budget"><svg viewBox="0 0 24 24" aria-hidden="true"><path d="M4 20V11"/><path d="M10 20V5"/><path d="M16 20v-7"/><path d="M21 20H3"/><path d="M4 7l6-3 6 5 5-4"/></svg></span><div><b>BUDGET MANAGEMENT SYSTEM</b><span>Cash &amp; Accounts Branch</span></div></a>
                        <a class="lg-app" href="http://notice.senate.gov.pk"><span class="lg-ico i-notice"><svg viewBox="0 0 24 24" aria-hidden="true"><rect x="3" y="5" width="18" height="14" rx="2.2"/><path d="M3.5 7l8.5 6 8.5-6"/></svg></span><div><b>NOTICE MANAGEMENT SYSTEM</b><span>Notice Branch</span></div></a>
                        <a class="lg-app" href="http://finance.senate.gov.pk"><span class="lg-ico i-finance"><svg viewBox="0 0 24 24" aria-hidden="true"><circle cx="12" cy="12" r="9"/><path d="M12 6.5v11"/><path d="M15.2 9.3c-.5-1-1.6-1.6-3.2-1.6-1.8 0-3.1.9-3.1 2.2 0 1.2 1.1 1.8 3.1 2.1 2 .3 3.2.9 3.2 2.2 0 1.3-1.3 2.2-3.2 2.2-1.6 0-2.7-.6-3.3-1.7"/></svg></span><div><b>FINANCE MANAGEMENT SYSTEM</b><span>Finance &amp; Accounts Branch</span></div></a>
                        <a class="lg-app" href="http://service.senate.gov.pk"><span class="lg-ico i-service"><svg viewBox="0 0 24 24" aria-hidden="true"><rect x="3" y="7" width="18" height="13" rx="2.2"/><path d="M9 7V5.2A1.7 1.7 0 0 1 10.7 3.5h2.6A1.7 1.7 0 0 1 15 5.2V7"/><path d="M3 13h18"/><path d="M10.5 13v2h3v-2"/></svg></span><div><b>SERVICE MANAGEMENT SYSTEM</b><span>Service Branch</span></div></a>
                        <a class="lg-app" href="http://motion.senate.gov.pk"><span class="lg-ico i-motion"><svg viewBox="0 0 24 24" aria-hidden="true"><path d="M5 21V4"/><path d="M5 5h13l-2.2 4 2.2 4H5"/></svg></span><div><b>MOTION MANAGEMENT SYSTEM</b><span>Motion Branch</span></div></a>
                        <a class="lg-app" href="http://my.senate.gov.pk"><span class="lg-ico i-my"><svg viewBox="0 0 24 24" aria-hidden="true"><circle cx="12" cy="8" r="4"/><path d="M4 21c0-4.4 3.6-7 8-7s8 2.6 8 7"/></svg></span><div><b>PERSONAL MANAGEMENT SYSTEM</b><span>HRM Branch</span></div></a>
                        <a class="lg-app" href="http://ipr.senate.gov.pk"><span class="lg-ico i-ipr"><svg viewBox="0 0 24 24" aria-hidden="true"><path d="M9 18h6"/><path d="M10 21h4"/><path d="M12 3a6 6 0 0 0-3.6 10.8c.6.5 1 1.3 1 2.2h5.2c0-.9.4-1.7 1-2.2A6 6 0 0 0 12 3z"/></svg></span><div><b>IPR MANAGEMENT SYSTEM</b><span>IPR Branch</span></div></a>
                        <a class="lg-app" href="http://committees.senate.gov.pk"><span class="lg-ico i-committees"><svg viewBox="0 0 24 24" aria-hidden="true"><circle cx="12" cy="6" r="2.6"/><circle cx="5.5" cy="18" r="2.6"/><circle cx="18.5" cy="18" r="2.6"/><path d="M12 8.6v3.6"/><path d="M12 12.2l-5.2 3.4"/><path d="M12 12.2l5.2 3.4"/></svg></span><div><b>COMMITTEES MANAGEMENT SYSTEM</b><span>Committee Branch</span></div></a>
                        <a class="lg-app" href="#"><span class="lg-ico i-legis"><svg viewBox="0 0 24 24" aria-hidden="true"><path d="M6 3h8.5L19 7.5V21H6z"/><path d="M14 3v5h5"/><path d="M9.5 13h6"/><path d="M9.5 16.5h6"/></svg></span><div><b>LEGISLATION MANAGEMENT SYSTEM</b><span>Legislation Branch</span></div></a>
                        <a class="lg-app" href="http://trans.senate.gov.pk"><span class="lg-ico i-trans"><svg viewBox="0 0 24 24" aria-hidden="true"><circle cx="12" cy="12" r="9"/><path d="M3 12h18"/><path d="M12 3c3.2 3.2 3.2 14.8 0 18"/><path d="M12 3c-3.2 3.2-3.2 14.8 0 18"/></svg></span><div><b>TRANSLATION MANAGEMENT SYSTEM</b><span>Translation Branch</span></div></a>
                    </div>
                </div>

            </div>

            <div class="lg-foot">Powered by: &copy; IT Directorate</div>
        </div>
    </form>
    <script type="text/javascript">
        (function () {
            var pwd = document.getElementById('<%= Password.ClientID %>');
            var user = document.getElementById('<%= UserName.ClientID %>');
            var btn = document.getElementById('togglePwd');
            btn.onclick = function () {
                var show = pwd.type === 'password';
                pwd.type = show ? 'text' : 'password';
                btn.innerHTML = show ? 'Hide' : 'Show';
            };
            if (user && !user.value) { user.focus(); } else if (pwd) { pwd.focus(); }
        })();
    </script>
</body>
</html>
