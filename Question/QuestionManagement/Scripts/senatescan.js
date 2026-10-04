/*  SenateScan web script
    -------------------------------------------------------------------------------------------------
    Adds a "Scan" button next to every file box marked  data-scan="true".
    The button opens a dialog that talks to the SenateScan program running on the user's PC
    (http://127.0.0.1:47600), scans, lets the user check / rotate / reorder / delete pages, and then
    puts the resulting PDF or picture into the file box - exactly as if the user had chosen a file.

    Use:   <asp:FileUpload ID="FileUpload1" runat="server" data-scan="true" />
           <script src="Scripts/senatescan.js"></script>          (once per page or in the master page)

    Two ways it can talk to the utility:
      1. Directly from the page (fast). Some browsers block a website from reaching the user's own PC.
      2. Through a small window served by the utility itself (/ui). Nothing can block that, so the page falls back to it
         when the direct way fails; the finished file is sent back to the page with postMessage.

    Optional settings, set before the script loads:   window.SenateScanConfig = { port: 47600 };
    Plain JavaScript, no other libraries needed.                                                            */
(function () {
    'use strict';

    // Where to download the utility from. Preferred: a data-download attribute on this <script> tag,
    // set by the server (works no matter how or when the script is loaded). Falls back to working it
    // out from the script's own address, then to a plain relative guess.
    var SELF_TAG = document.currentScript || null;
    if (!SELF_TAG) {
        var tags = document.querySelectorAll('script[src*="senatescan.js"]');
        SELF_TAG = tags.length ? tags[tags.length - 1] : null;
    }
    var SELF_SRC = (SELF_TAG && SELF_TAG.src) || '';
    var DOWNLOAD_URL = (SELF_TAG && SELF_TAG.getAttribute('data-download')) ||
        (SELF_SRC ? SELF_SRC.replace(/Scripts\/senatescan\.js.*$/i, 'SenateScan/SenateScan.zip') : 'SenateScan/SenateScan.zip');

    var cfg = window.SenateScanConfig || {};
    var popupMode = !!cfg.popup;                       // true inside the window the utility itself serves
    var API_ORIGIN = 'http://127.0.0.1:' + (cfg.port || 47600);
    var BASE = popupMode ? '' : API_ORIGIN;            // inside the utility's own window every address is on the same site
    var SETTINGS_KEY = 'senatescan.settings';

    // ---------------------------------------------------------------- small helpers
    function el(tag, className, html) {
        var e = document.createElement(tag);
        if (className) e.className = className;
        if (html !== undefined) e.innerHTML = html;
        return e;
    }
    function esc(s) { var d = document.createElement('div'); d.appendChild(document.createTextNode(s == null ? '' : String(s))); return d.innerHTML; }
    // true when the box's own "accept" attribute lists only picture types (e.g. a photo box) - never PDF or "any file"
    function imageOnlyBox(input) {
        var accept = (input.getAttribute('accept') || '').toLowerCase();
        if (!accept) return false;
        return accept.split(',').every(function (rule) { rule = rule.trim(); return rule.indexOf('image/') === 0; });
    }
    function loadSettings() { try { return JSON.parse(localStorage.getItem(SETTINGS_KEY)) || {}; } catch (e) { return {}; } }
    function saveSettings(s) { try { localStorage.setItem(SETTINGS_KEY, JSON.stringify(s)); } catch (e) { } }

    function api(path, body) {
        var options = body === undefined ? { method: 'GET' } :
            { method: 'POST', headers: { 'Content-Type': 'application/json' }, body: JSON.stringify(body) };
        return fetch(BASE + path, options).then(function (r) {
            if (r.ok) return r;
            return r.json().catch(function () { return {}; }).then(function (j) {
                throw new Error(j.error || 'The scanner utility returned an error (' + r.status + ').');
            });
        });
    }
    function apiJson(path, body) { return api(path, body).then(function (r) { return r.json(); }); }

    // ---------------------------------------------------------------- styles
    function addStyles() {
        if (document.getElementById('sb-styles')) return;
        var css =
            '.sb-btn{margin-left:8px}' +
            '.sb-btn-ab{margin-left:0;height:32px;border-color:#0c3a72;color:#0c3a72;font-weight:600}' +
            '.sb-btn-ab:hover:not(:disabled){background:#eef5fc}' +
            '.sb-note{margin-left:10px;font-size:12px;color:#23663c}' +
            '.ab-box .sb-note{display:block;margin:8px 0 0;font-size:12px;font-weight:600;color:#1b6b34}' +
            '.ab-box .sb-dl{display:inline-flex;margin-left:auto}' +
            '.sb-overlay{position:fixed;left:0;top:0;right:0;bottom:0;background:rgba(20,30,45,.55);z-index:100000;display:flex;align-items:center;justify-content:center;font-family:"Segoe UI",Tahoma,Arial,sans-serif}' +
            '.sb-dialog{background:#fff;width:880px;max-width:96vw;max-height:94vh;border-radius:8px;box-shadow:0 10px 40px rgba(0,0,0,.35);display:flex;flex-direction:column;color:#1f2d3d;font-size:14px}' +
            '.sb-head{display:flex;align-items:center;padding:12px 18px;border-bottom:1px solid #e4e9ee;background:#f8fafb;border-radius:8px 8px 0 0}' +
            '.sb-title{font-size:13px;font-weight:700;letter-spacing:.08em;text-transform:uppercase;color:#0c3a72;flex:1}' +
            '.sb-x{border:0;background:transparent;font-size:24px;line-height:1;color:#6b7785;cursor:pointer}' +
            '.sb-body{padding:16px 18px;overflow:auto;flex:1;min-height:220px}' +
            '.sb-foot{display:flex;align-items:center;gap:8px;padding:12px 18px;border-top:1px solid #e4e9ee;background:#f8fafb;border-radius:0 0 8px 8px}' +
            '.sb-foot .sb-grow{flex:1}' +
            '.sb-msg{padding:9px 12px;border-radius:6px;margin-bottom:12px;font-size:13px}' +
            '.sb-msg.err{background:#fdecea;color:#a5281b;border:1px solid #f3c6c1}' +
            '.sb-msg.info{background:#eef5fc;color:#24425f;border:1px solid #d5e4f4}' +
            '.sb-msg.busy{background:#f3f6f8;color:#3c4858;border:1px solid #e4e9ee}' +
            '.sb-form{display:grid;grid-template-columns:repeat(auto-fit,minmax(190px,1fr));gap:12px 16px}' +
            '.sb-form label{display:block;font-size:12px;font-weight:600;color:#3c4858;margin-bottom:4px}' +
            '.sb-form select{width:100%;height:34px;border:1px solid #ccd3da;border-radius:4px;padding:0 8px;background:#fff}' +
            '.sb-wide{grid-column:1/-1}' +
            '.sb-files{max-height:260px;overflow:auto;border:1px solid #e4e9ee;border-radius:6px}' +
            '.sb-file{display:flex;align-items:center;gap:10px;padding:7px 12px;border-bottom:1px solid #f1f4f7;cursor:pointer}' +
            '.sb-file:last-child{border-bottom:0}.sb-file:hover{background:#f8fafb}' +
            '.sb-file small{color:#6b7785;margin-left:auto}' +
            '.sb-grid{display:grid;grid-template-columns:repeat(auto-fill,minmax(150px,1fr));gap:14px}' +
            '.sb-page{border:1px solid #e4e9ee;border-radius:6px;background:#fbfcfe;padding:8px;text-align:center}' +
            '.sb-thumb{height:190px;display:flex;align-items:center;justify-content:center;overflow:hidden;background:#eef1f5;border-radius:4px}' +
            '.sb-thumb img{max-width:100%;max-height:100%;transition:transform .15s}' +
            '.sb-tools{display:flex;justify-content:center;gap:4px;margin-top:6px}' +
            '.sb-tools button{border:1px solid #ccd3da;background:#fff;border-radius:4px;width:30px;height:28px;cursor:pointer;color:#3c4858}' +
            '.sb-tools button:hover:not(:disabled){background:#eef5fc}.sb-tools button:disabled{opacity:.35;cursor:default}' +
            '.sb-tools .sb-del{color:#c0392b}' +
            '.sb-num{font-size:12px;color:#6b7785;margin-top:4px}' +
            '.sb-b{height:34px;padding:0 16px;border-radius:4px;border:1px solid #ccd3da;background:#fff;color:#1f2d3d;cursor:pointer;font-size:14px}' +
            '.sb-b:hover:not(:disabled){background:#f3f6f8}.sb-b:disabled{opacity:.5;cursor:default}' +
            '.sb-b.primary{background:#0c3a72;border-color:#0c3a72;color:#fff}.sb-b.primary:hover:not(:disabled){background:#0a2f5d}' +
            '.sb-spin{display:inline-block;width:14px;height:14px;border:2px solid #b8c4d2;border-top-color:#0c3a72;border-radius:50%;animation:sbspin .8s linear infinite;vertical-align:-2px;margin-right:8px}' +
            '@keyframes sbspin{to{transform:rotate(360deg)}}' +
            '.sb-help{font-size:12px;color:#6b7785;margin-top:10px}' +
            '.sb-dl{margin-left:8px;font-size:12px}' +
            '.sb-dl a{display:inline-flex;align-items:center;gap:5px;height:32px;padding:0 12px;border-radius:4px;border:1px solid #d5dde5;background:#fff;color:#3c4858;text-decoration:none;font-weight:600;white-space:nowrap}' +
            '.sb-dl a:hover{background:#f3f6f8;border-color:#ccd3da;text-decoration:none}' +
            '.sb-dl a:before{content:"\\2b07";color:#1f6fb5;font-weight:700}';
        var style = el('style'); style.id = 'sb-styles'; style.appendChild(document.createTextNode(css));
        document.head.appendChild(style);
    }

    // ---------------------------------------------------------------- the dialog
    function Dialog(input, note, deliver) {
        var self = this;
        this.input = input;
        this.note = note;
        this.deliver = deliver;
        this.settings = loadSettings();
        this.scanId = null;
        this.pages = [];             // { n: index in the utility, rotate: 0|90|180|270 }
        this.pdfOnly = false;
        this.seen = {};              // every page number the utility has given us (so deleted pages do not come back)
        this.devices = [];

        this.overlay = el('div', 'sb-overlay');
        this.dialog = el('div', 'sb-dialog');
        this.dialog.setAttribute('role', 'dialog');
        this.dialog.setAttribute('aria-label', 'Scan document');
        var head = el('div', 'sb-head');
        head.appendChild(el('div', 'sb-title', 'Scan document'));
        var x = el('button', 'sb-x', '&times;'); x.type = 'button'; x.title = 'Close';
        x.onclick = function () { self.close(); };
        head.appendChild(x);
        this.body = el('div', 'sb-body');
        this.foot = el('div', 'sb-foot');
        this.dialog.appendChild(head); this.dialog.appendChild(this.body); this.dialog.appendChild(this.foot);
        this.overlay.appendChild(this.dialog);
        this.overlay.addEventListener('mousedown', function (e) { if (e.target === self.overlay) self.close(); });
        this.keyHandler = function (e) { if (e.keyCode === 27) self.close(); };
        document.addEventListener('keydown', this.keyHandler);
        document.body.appendChild(this.overlay);
        this.check();
    }

    Dialog.prototype.close = function () {
        document.removeEventListener('keydown', this.keyHandler);
        if (this.scanId) { api('/api/discard', { scanId: this.scanId }).catch(function () { }); }
        if (this.overlay.parentNode) this.overlay.parentNode.removeChild(this.overlay);
        if (popupMode) { try { window.close(); } catch (e) { } }
    };

    Dialog.prototype.message = function (kind, html) {
        var box = this.body.querySelector('.sb-msgbox');
        if (!box) { box = el('div', 'sb-msgbox'); this.body.insertBefore(box, this.body.firstChild); }
        box.innerHTML = html ? '<div class="sb-msg ' + kind + '">' + html + '</div>' : '';
    };

    Dialog.prototype.buttons = function (list) {
        this.foot.innerHTML = '';
        for (var i = 0; i < list.length; i++) {
            var b = list[i];
            if (b === 'grow') { this.foot.appendChild(el('div', 'sb-grow')); continue; }
            if (b.html) { this.foot.appendChild(b.html); continue; }
            var btn = el('button', 'sb-b' + (b.primary ? ' primary' : ''), b.text);
            btn.type = 'button'; btn.disabled = !!b.disabled; btn.onclick = b.click;
            this.foot.appendChild(btn);
        }
    };

    // 1. is the utility running?
    Dialog.prototype.check = function () {
        var self = this;
        this.body.innerHTML = '';
        this.message('busy', '<span class="sb-spin"></span>Looking for the scanner utility...');
        this.buttons(['grow', { text: 'Cancel', click: function () { self.close(); } }]);
        apiJson('/api/status').then(function () { return self.loadDevices(); }).catch(function (e) {
            self.body.innerHTML = '';
            if (popupMode) {
                self.message('err', '<b>The scanner utility did not answer.</b><br><small>' + esc(e.message) + '</small>');
                self.buttons(['grow', { text: 'Try again', click: function () { self.check(); } }, { text: 'Close', click: function () { self.close(); } }]);
                return;
            }
            self.message('err',
                '<b>Could not reach the scanner utility from this page.</b><br>' +
                'Either <b>SenateScan</b> is not running on this computer (its icon appears near the clock), or the browser is blocking this website from reaching it.<br><br>' +
                'If SenateScan is running, click <b>Open scanner window</b>. It works even when the browser blocks the direct connection.<br>' +
                'Not installed on this PC yet? <a href="' + DOWNLOAD_URL + '" target="_blank">Download SenateScan</a>.' +
                '<br><small style="color:#6b7785">Website: ' + esc(location.origin) + ' &middot; Detail: ' + esc(e.message) + '</small>');
            self.buttons(['grow',
                { text: 'Try again', click: function () { self.check(); } },
                { text: 'Open scanner window', primary: true, click: function () { self.close(); openWindow(self.input, self.note); } },
                { text: 'Cancel', click: function () { self.close(); } }]);
        });
    };

    // 2. which scanners?
    Dialog.prototype.loadDevices = function () {
        var self = this;
        return apiJson('/api/devices').then(function (r) {
            self.devices = r.devices || [];
            self.showSetup();
        });
    };

    Dialog.prototype.showSetup = function () {
        var self = this, s = this.settings;
        this.body.innerHTML = '';
        if (!this.devices.length) {
            this.message('err', '<b>No scanner was found.</b><br>Check that the scanner is connected, switched on and its Windows driver is installed. Then click Try again.');
            this.buttons(['grow', { text: 'Try again', click: function () { self.check(); } }, { text: 'Cancel', click: function () { self.close(); } }]);
            return;
        }
        if (this.pages.length) this.message('info', 'You have ' + this.pages.length + ' page(s) so far. Scan more to add to them.');

        function opt(value, label, sel) { return '<option value="' + value + '"' + (sel ? ' selected' : '') + '>' + label + '</option>'; }
        var devOptions = '';
        for (var i = 0; i < this.devices.length; i++)
            devOptions += opt(this.devices[i].id, esc(this.devices[i].name), this.devices[i].id === s.deviceId);

        var form = el('div', 'sb-form');
        form.innerHTML =
            '<div class="sb-wide"><label>Scanner</label><select data-f="device">' + devOptions + '</select></div>' +
            '<div class="sb-opt"><label>Paper source</label><select data-f="source">' +
                opt('flatbed', 'Flat glass (one page)', s.source === 'flatbed' || !s.source) +
                opt('feeder', 'Document feeder', s.source === 'feeder') +
                opt('duplex', 'Document feeder, both sides', s.source === 'duplex') + '</select></div>' +
            '<div class="sb-opt"><label>Colour</label><select data-f="color">' +
                opt('color', 'Colour', s.color === 'color' || !s.color) + opt('gray', 'Grey', s.color === 'gray') + opt('bw', 'Black and white', s.color === 'bw') + '</select></div>' +
            '<div class="sb-opt"><label>Quality</label><select data-f="dpi">' +
                opt('150', 'Draft (150 dpi)', String(s.dpi) === '150') + opt('200', 'Normal (200 dpi)', String(s.dpi) === '200' || !s.dpi) + opt('300', 'High (300 dpi)', String(s.dpi) === '300') + '</select></div>' +
            '<div class="sb-opt"><label>Paper size</label><select data-f="paper">' +
                opt('auto', 'Automatic', s.paper === 'auto' || !s.paper) + opt('a4', 'A4', s.paper === 'a4') + opt('legal', 'Legal', s.paper === 'legal') + '</select></div>' +
            '<div class="sb-wide sb-filesbox" style="display:none"></div>';
        this.body.appendChild(form);
        this.body.appendChild(el('div', 'sb-help', 'Put the paper in the scanner, then click Scan. Higher quality is slower and makes a bigger file; Normal is right for most notices.'));
        this.form = form;

        var deviceSel = form.querySelector('[data-f=device]');
        deviceSel.onchange = function () { self.deviceChanged(); };
        this.deviceChanged();
    };

    Dialog.prototype.field = function (name) { return this.form.querySelector('[data-f=' + name + ']'); };
    Dialog.prototype.currentDevice = function () {
        var id = this.field('device').value;
        for (var i = 0; i < this.devices.length; i++) if (this.devices[i].id === id) return this.devices[i];
        return this.devices[0];
    };

    Dialog.prototype.deviceChanged = function () {
        var self = this, dev = this.currentDevice();
        var isFolder = dev.kind === 'folder';
        var opts = this.form.querySelectorAll('.sb-opt');
        for (var i = 0; i < opts.length; i++) opts[i].style.display = isFolder && opts[i].querySelector('[data-f=color]') === null ? 'none' : '';
        var filesBox = this.form.querySelector('.sb-filesbox');
        filesBox.style.display = isFolder ? '' : 'none';
        if (isFolder) this.loadFolderFiles(filesBox);

        this.buttons(this.pages.length ? [
            { text: 'Back to pages', click: function () { self.showReview(); } }, 'grow',
            { text: 'Cancel', click: function () { self.close(); } },
            isFolder ? { text: 'Use selected files', primary: true, click: function () { self.importFiles(); } } : { text: 'Scan', primary: true, click: function () { self.scan(); } }
        ] : [
            'grow', { text: 'Cancel', click: function () { self.close(); } },
            isFolder ? { text: 'Use selected files', primary: true, click: function () { self.importFiles(); } } : { text: 'Scan', primary: true, click: function () { self.scan(); } }
        ]);
    };

    Dialog.prototype.loadFolderFiles = function (box) {
        box.innerHTML = '<span class="sb-spin"></span>Reading the scan folder...';
        apiJson('/api/folder/files').then(function (r) {
            var files = r.files || [];
            if (!files.length) { box.innerHTML = '<div class="sb-msg info">No recent scans were found in the scan folder.</div>'; return; }
            var html = '<label>Choose the scanned file(s) &mdash; newest first</label><div class="sb-files">';
            for (var i = 0; i < files.length; i++)
                html += '<label class="sb-file"><input type="checkbox" data-file="' + esc(files[i].name) + '"> <span>' + esc(files[i].name) + '</span><small>' + esc(files[i].modified) + ' &middot; ' + files[i].kb + ' KB</small></label>';
            box.innerHTML = html + '</div>';
        }).catch(function (e) { box.innerHTML = '<div class="sb-msg err">' + esc(e.message) + '</div>'; });
    };

    Dialog.prototype.remember = function () {
        this.settings = {
            deviceId: this.field('device').value, source: this.field('source').value, color: this.field('color').value,
            dpi: this.field('dpi').value, paper: this.field('paper').value
        };
        saveSettings(this.settings);
    };

    // 3. scan
    Dialog.prototype.scan = function () {
        var self = this;
        this.remember();
        var st = this.settings;
        this.message('busy', '<span class="sb-spin"></span>Scanning... please wait. Do not open the scanner cover until it stops.');
        this.buttons(['grow', { text: 'Scanning...', disabled: true }]);
        apiJson('/api/scan', { deviceId: st.deviceId, source: st.source, color: st.color, dpi: parseInt(st.dpi, 10), paper: st.paper, scanId: this.scanId })
            .then(function (r) { self.gotPages(r); })
            .catch(function (e) { self.showSetup(); self.message('err', esc(e.message)); });
    };

    Dialog.prototype.importFiles = function () {
        var self = this;
        this.remember();
        var chosen = [], boxes = this.form.querySelectorAll('[data-file]');
        for (var i = 0; i < boxes.length; i++) if (boxes[i].checked) chosen.push(boxes[i].getAttribute('data-file'));
        if (!chosen.length) { this.message('err', 'Tick at least one file.'); return; }
        apiJson('/api/import', { files: chosen, color: this.settings.color, scanId: this.scanId })
            .then(function (r) { self.gotPages(r); })
            .catch(function (e) { self.message('err', esc(e.message)); });
    };

    Dialog.prototype.gotPages = function (r) {
        this.scanId = r.scanId;
        this.pdfOnly = !!r.pdfOnly;
        if (this.pdfOnly) { this.pages = []; this.seen = {}; }
        for (var i = 0; i < r.pages.length; i++) {
            var n = r.pages[i].n;
            if (this.seen[n]) continue;
            this.seen[n] = true;
            this.pages.push({ n: n, rotate: 0, label: r.pages[i].label });
        }
        this.showReview();
    };

    // 4. check the pages
    Dialog.prototype.showReview = function () {
        var self = this;
        this.body.innerHTML = '';
        if (!this.pages.length) { this.showSetup(); return; }
        this.message('info', this.pdfOnly ? 'This PDF will be attached as it is.' : 'Check the pages. Turn, move or delete any page, or scan more pages.');
        var grid = el('div', 'sb-grid');
        var total = this.pages.length;
        this.pages.forEach(function (p, idx) {
            var card = el('div', 'sb-page');
            var thumb = el('div', 'sb-thumb');
            var img = el('img');
            img.alt = 'Page ' + (idx + 1);
            img.src = BASE + '/api/page?scan=' + self.scanId + '&n=' + p.n + '&max=420';
            img.style.transform = 'rotate(' + p.rotate + 'deg)' + (p.rotate % 180 ? ' scale(.72)' : '');
            thumb.appendChild(img);
            card.appendChild(thumb);
            var tools = el('div', 'sb-tools');
            function tool(html, title, fn, cls, disabled) {
                var b = el('button', cls || '', html); b.type = 'button'; b.title = title; b.disabled = !!disabled; b.onclick = fn; tools.appendChild(b);
            }
            tool('&#9664;', 'Move earlier', function () { self.move(idx, -1); }, '', idx === 0 || self.pdfOnly);
            tool('&#8634;', 'Turn left', function () { p.rotate = (p.rotate + 270) % 360; self.showReview(); }, '', self.pdfOnly);
            tool('&#8635;', 'Turn right', function () { p.rotate = (p.rotate + 90) % 360; self.showReview(); }, '', self.pdfOnly);
            tool('&#9654;', 'Move later', function () { self.move(idx, 1); }, '', idx === total - 1 || self.pdfOnly);
            tool('&#10005;', 'Delete this page', function () { self.pages.splice(idx, 1); self.showReview(); }, 'sb-del', self.pdfOnly);
            card.appendChild(tools);
            card.appendChild(el('div', 'sb-num', p.label ? esc(p.label) : 'Page ' + (idx + 1)));
            grid.appendChild(card);
        });
        this.body.appendChild(grid);

        var formatSel = el('select', 'sb-format');
        formatSel.style.height = '34px';
        formatSel.innerHTML = '<option value="pdf">Save as PDF</option><option value="jpg">Save as picture (JPG)</option>';
        formatSel.disabled = this.pdfOnly || this.pages.length > 1;
        formatSel.title = 'A picture holds one page only';
        // a box that only accepts pictures (e.g. a photo) gets JPG picked by default, instead of a PDF it cannot use
        if (this.input && imageOnlyBox(this.input)) formatSel.value = 'jpg';
        this.buttons([
            { text: 'Scan more pages', click: function () { self.showSetup(); }, disabled: this.pdfOnly },
            'grow', { html: formatSel },
            { text: 'Cancel', click: function () { self.close(); } },
            { text: 'Use these pages', primary: true, click: function () { self.build(formatSel.value); } }
        ]);
    };

    Dialog.prototype.move = function (idx, delta) {
        var t = this.pages[idx]; this.pages[idx] = this.pages[idx + delta]; this.pages[idx + delta] = t;
        this.showReview();
    };

    // 5. make the file and put it in the page's file box
    Dialog.prototype.build = function (format) {
        var self = this;
        this.message('busy', '<span class="sb-spin"></span>Preparing the file...');
        this.buttons(['grow', { text: 'Please wait...', disabled: true }]);
        var order = this.pages.map(function (p) { return { n: p.n, rotate: p.rotate }; });
        api('/api/build', { scanId: this.scanId, format: format, pages: order }).then(function (r) {
            var disposition = r.headers.get('Content-Disposition') || '';
            var m = /filename="?([^";]+)"?/.exec(disposition);
            var name = m ? m[1] : (format === 'jpg' ? 'scan.jpg' : 'scan.pdf');
            var count = r.headers.get('X-Page-Count') || order.length;
            return r.blob().then(function (blob) { self.attach(blob, name, count); });
        }).catch(function (e) { self.showReview(); self.message('err', esc(e.message)); });
    };

    Dialog.prototype.attach = function (blob, name, count) {
        var self = this;
        this.deliver(blob, name, count, function (problem, stay) {
            if (problem) { self.showReview(); self.message('err', esc(problem)); return; }
            if (stay) { self.showReview(); self.message('info', stay); return; }
            self.close();
        });
    };

    // Puts the file into the page's file box (used when the dialog runs inside the Notice page).
    function attachToInput(input, note) {
        return function (blob, name, count, done) {
            try {
                var file = (blob instanceof File) ? blob : new File([blob], name, { type: blob.type });
                var dt = new DataTransfer();
                if (input.multiple && input.files) for (var k = 0; k < input.files.length; k++) dt.items.add(input.files[k]);   // keep files already chosen
                dt.items.add(file);
                input.files = dt.files;
            } catch (e) {
                done('This browser cannot attach the scan automatically. Please use a current version of Chrome or Edge.');
                return;
            }
            var ev;
            try { ev = new Event('change', { bubbles: true }); } catch (e2) { ev = document.createEvent('Event'); ev.initEvent('change', true, true); }
            input.dispatchEvent(ev);
            note.textContent = '\u2714 Scanned file attached: ' + name + ' (' + count + (String(count) === '1' ? ' page' : ' pages') + ', ' + Math.max(1, Math.round(blob.size / 1024)) + ' KB)';
            done(null);
        };
    }

    // Used inside the utility's own window: hand the file back to the Notice page that opened it.
    function sendToOpener(blob, name, count, done) {
        var target = cfg.opener;
        var receiver = (window.opener && !window.opener.closed) ? window.opener : (window.parent !== window ? window.parent : null);   // the page that opened (or contains) this window
        if (target && receiver) {
            try {
                var file = new File([blob], name, { type: blob.type });
                receiver.postMessage({ type: 'senatescan-file', file: file, count: count }, target);
                done(null);
            } catch (e) { done('Could not send the scan back to the page: ' + e.message); }
            return;
        }
        // opened by hand (no page waiting): save the file instead, useful for testing the scanner
        var a = document.createElement('a');
        a.href = URL.createObjectURL(blob); a.download = name;
        document.body.appendChild(a); a.click(); document.body.removeChild(a);
        done(null, 'Saved as ' + esc(name) + ' (' + count + ' page(s)). You can scan again or close this window.');
    }

    // Opens the utility's own window and waits for the scan to come back.
    var pending = null;
    function openWindow(input, note) {
        pending = { input: input, note: note };
        var w = window.open(API_ORIGIN + '/ui?origin=' + encodeURIComponent(location.origin), 'senatescan_window', 'width=940,height=760,resizable=yes,scrollbars=yes');
        if (!w) alert('The scanner window was blocked. Please allow pop-ups for this website, then click Scan again.');
    }
    if (!popupMode) {
        window.addEventListener('message', function (e) {
            if (e.origin !== API_ORIGIN) return;                       // only the utility's own window may send files
            var d = e.data;
            if (!d || d.type !== 'senatescan-file' || !d.file || !pending) return;
            attachToInput(pending.input, pending.note)(d.file, d.file.name, d.count, function () { });
        });
    }

    // ---------------------------------------------------------------- put a Scan button next to each marked file box
    // finds the attachbox.js wrapper around an input, if that script has run on this page
    function findAbBox(input) {
        var node = input.parentNode;
        for (var hops = 0; node && hops < 4; hops++, node = node.parentNode)
            if (node.className && (' ' + node.className + ' ').indexOf(' ab-box ') !== -1) return node;
        return null;
    }

    function attach(input) {
        if (!input || input.getAttribute('data-sb-ready')) return;
        input.setAttribute('data-sb-ready', '1');
        var btn = el('button', 'btn btn-default sb-btn', '<span class="glyphicon glyphicon-print"></span> Scan');
        btn.type = 'button';
        btn.title = 'Scan a document from the scanner';
        var note = el('span', 'sb-note');
        var dl = el('span', 'sb-dl', '<a href="' + DOWNLOAD_URL + '" target="_blank" title="Scanner utility - install once on the PC that has the scanner, then use Scan above">Get SenateScan</a>');

        var abBox = findAbBox(input);
        var abRow = abBox ? abBox.querySelector('.ab-row') : null;
        if (abRow) {
            // matches the look of the "attachment box" (attachbox.js) instead of sitting as bare text next to the input
            btn.className += ' sb-btn-ab';
            abRow.appendChild(btn);
            abRow.appendChild(dl);
            abBox.insertBefore(note, abBox.querySelector('.ab-chip'));
        } else {
            input.parentNode.insertBefore(btn, input.nextSibling);
            btn.parentNode.insertBefore(dl, btn.nextSibling);
            btn.parentNode.insertBefore(note, dl.nextSibling);
        }
        btn.onclick = function () { addStyles(); new Dialog(input, note, attachToInput(input, note)); };
        // clear the note if the user picks a different file by hand
        input.addEventListener('change', function () {
            if (!input.files || !input.files.length || note.textContent.indexOf(input.files[0].name) < 0) note.textContent = '';
        });
    }

    function init() {
        addStyles();
        if (popupMode) { new Dialog(null, null, sendToOpener); return; }      // the utility's own window: open the dialog straight away
        var inputs = document.querySelectorAll('input[type=file][data-scan]');
        for (var i = 0; i < inputs.length; i++) attach(inputs[i]);
    }

    if (!popupMode && window.MutationObserver) {
        var watchTimer = null;
        new MutationObserver(function () { clearTimeout(watchTimer); watchTimer = setTimeout(init, 200); })
            .observe(document.documentElement, { childList: true, subtree: true });
    }

    window.SenateScan = { attach: attach, init: init, openWindow: openWindow };
    if (document.readyState === 'loading') document.addEventListener('DOMContentLoaded', init); else init();
})();

