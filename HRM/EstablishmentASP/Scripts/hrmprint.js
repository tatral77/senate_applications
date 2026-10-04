/* HRM shared report printing and PDF export.
   Usage from a page:
     HRMPrint.print(panelClientId, { title: 'REPORT TITLE' });
     HRMPrint.exportPdf(panelClientId, { title: 'REPORT TITLE' });
   Reports are printed A4, landscape when the widest table has more than 7 columns. No signature blocks are added. */
(function (w, d) {
    'use strict';

    var scriptSrc = (function () {
        var s = d.currentScript;
        if (!s) {
            var all = d.getElementsByTagName('script');
            for (var i = all.length - 1; i >= 0; i--) {
                if (/hrmprint\.js/i.test(all[i].src)) { s = all[i]; break; }
            }
        }
        return s ? s.src : '';
    })();
    var pdfUrl = scriptSrc.replace(/Scripts\/hrmprint\.js.*$/i, 'PdfExport.ashx');

    var BLOCK = { DIV: 1, P: 1, UL: 1, OL: 1, LI: 1, SECTION: 1, HEADER: 1, FOOTER: 1, FORM: 1, FIELDSET: 1, CENTER: 1, ARTICLE: 1, ASIDE: 1, NAV: 1, PRE: 1, DL: 1, DT: 1, DD: 1, LEGEND: 1, HR: 1 };

    function toArray(list) { return Array.prototype.slice.call(list || []); }
    function get(id) { return d.getElementById(id); }
    function pad(n) { return (n < 10 ? '0' : '') + n; }
    function stamp() {
        var n = new Date();
        return pad(n.getDate()) + '/' + pad(n.getMonth() + 1) + '/' + n.getFullYear() + ' ' + pad(n.getHours()) + ':' + pad(n.getMinutes());
    }
    function esc(s) { return String(s).replace(/&/g, '&amp;').replace(/</g, '&lt;').replace(/>/g, '&gt;'); }
    function clean(s) {
        return String(s || '').replace(/[ \t\r\f\v\xa0]+/g, ' ').replace(/ *\n */g, '\n').replace(/^\s+|\s+$/g, '');
    }
    function text(el) { return el.innerText !== undefined ? el.innerText : el.textContent; }

    /* Copy of the panel with form controls replaced by their current values and screen-only parts removed. */
    function prepare(panel) {
        var clone = panel.cloneNode(true);
        var src = toArray(panel.querySelectorAll('input, select, textarea'));
        var dst = toArray(clone.querySelectorAll('input, select, textarea'));
        for (var i = 0; i < dst.length; i++) {
            var s = src[i], t = dst[i];
            if (!s || !t || !t.parentNode) { continue; }
            var tag = s.tagName.toLowerCase();
            var type = (s.type || '').toLowerCase();
            var rep = null;
            if (tag === 'select') {
                var o = s.options[s.selectedIndex];
                rep = o ? o.text : '';
            } else if (tag === 'textarea') {
                rep = s.value;
            } else if (type === 'checkbox' || type === 'radio') {
                rep = s.checked ? 'Yes' : 'No';
            } else if (type === 'button' || type === 'submit' || type === 'image' || type === 'reset' || type === 'hidden' || type === 'file') {
                rep = null;
            } else {
                rep = s.value;
            }
            if (rep === null) {
                t.parentNode.removeChild(t);
            } else {
                var sp = d.createElement('span');
                sp.appendChild(d.createTextNode(rep));
                t.parentNode.replaceChild(sp, t);
            }
        }
        var mobile = toArray(clone.querySelectorAll('.card-table, .card-head, .card-span, .card-empty, .m-hide'));
        for (var m = 0; m < mobile.length; m++) {
            mobile[m].className = mobile[m].className.replace(/(^|\s)(card-table|card-head|card-span|card-empty|m-hide)(?=\s|$)/g, ' ');
        }
        var drop = toArray(clone.querySelectorAll('script, style, button, .hid'));
        for (var j = 0; j < drop.length; j++) {
            if (drop[j].parentNode) { drop[j].parentNode.removeChild(drop[j]); }
        }
        return clone;
    }

    function widestTable(root) {
        var max = 0;
        var tables = root.querySelectorAll('table');
        for (var i = 0; i < tables.length; i++) {
            var t = tables[i];
            if (!t.querySelector('th')) { continue; }
            for (var r = 0; r < t.rows.length; r++) {
                if (t.rows[r].querySelector('th')) {
                    var n = 0;
                    for (var c = 0; c < t.rows[r].cells.length; c++) { n += t.rows[r].cells[c].colSpan || 1; }
                    if (n > max) { max = n; }
                    break;
                }
            }
        }
        return max;
    }

    /* ---------------------------------------------------------------- Print */

    function css(landscape) {
        return [
            "@page { size: A4 " + (landscape ? "landscape" : "portrait") + "; margin: 12mm 14mm; }",
            "* { -webkit-print-color-adjust: exact; print-color-adjust: exact; box-sizing: border-box; }",
            "body { font-family: 'Segoe UI', Calibri, Arial, sans-serif; font-size: 9.5pt; color: #1b1f24; margin: 0; }",
            ".letterhead { text-align: center; margin-bottom: 10px; padding-bottom: 6px; border-bottom: 2px solid #b9c9dd; }",
            ".letterhead .org { font-size: 19pt; font-weight: 700; letter-spacing: 3px; color: #1f3a5f; }",
            ".letterhead .sub { font-size: 9.5pt; color: #555; letter-spacing: 1px; margin-top: 1px; }",
            ".letterhead .title { display: inline-block; margin-top: 8px; padding: 3px 22px; font-size: 11.5pt; font-weight: 700; letter-spacing: 1.5px; color: #1f3a5f; background: #e3ecf7; border: 1px solid #b9c9dd; border-radius: 3px; }",
            ".hid { display: none !important; }",
            ".unhid { display: block !important; }",
            "u { text-decoration: none; }",
            "b, strong { font-weight: 700; }",
            "h1, h2, h3, h4, h5, h6 { margin: 6px 0; font-weight: 700; color: #1f3a5f; }",
            "h1, h2, h3 { font-size: 12pt; } h4 { font-size: 11pt; } h5, h6 { font-size: 10pt; }",
            ".page-header, .Headings { margin: 8px 0; padding: 5px 10px; background: #f0f5fb; border-left: 4px solid #9fbfe6; color: #1f3a5f; font-weight: 700; text-align: left; }",
            ".page-header h1, .page-header h2, .page-header h3, .page-header h4, .page-header h5, .page-header h6 { margin: 0; }",
            ".heading-left { text-align: left; }",
            "hr { display: none; }",
            "label, .control-lbl, .control-lbl-sm { font-weight: 600; color: #2c3e57; }",
            ".control-label { border: none !important; }",
            "a { color: inherit; text-decoration: none; }",
            "img { max-width: 100%; }",
            "table { border-collapse: collapse; width: 100%; }",
            "thead { display: table-header-group; }",
            "tr { page-break-inside: avoid; break-inside: avoid; }",
            "td, th { padding: 3px 5px; vertical-align: top; }",
            ".itemCent { text-align: center; } .itemLeft { text-align: left; }",
            ".td-bottom-border { border-bottom: solid 1.5px; } .td-top-border { border-top: solid 1.5px !important; }",
            "table.hrm-grid { margin: 6px 0 12px; }",
            "table.hrm-grid th { background: #e3ecf7 !important; color: #1f3a5f !important; font-weight: 700; font-size: 8.5pt; padding: 5px 4px; border: 1px solid #b9c9dd; text-align: center; vertical-align: middle; }",
            "table.hrm-grid td { padding: 4px 5px; border: 1px solid #d5deea !important; font-size: 9pt; vertical-align: middle; }",
            "table.hrm-grid tbody tr:nth-child(even) td { background: #f9fbfd; }",
            "table.pf-kvt { margin: 4px 0 10px; } table.pf-kvt td { border: 1px solid #c5cfdc; padding: 3px 6px; font-size: 9pt; } table.pf-kvt td.k { width: 18%; background: #f3f6fa; font-weight: 600; color: #2c3e57; } table.pf-kvt td.v { width: 32%; }",
            ".pf-hero { margin: 6px 0 8px; padding: 6px 10px; background: #f0f5fb; border-left: 4px solid #9fbfe6; } .pf-hero .pf-avatar, .pf-hero .pf-cap { display: none; } .pf-hero h4 { margin: 0; font-size: 13pt; }",
            ".pf-card { margin-bottom: 8px; } .pf-card h4 { font-size: 10.5pt; }",
            "small { font-size: 8pt; color: #555; }",
            ".regularDiv { border: 0 !important; box-shadow: none !important; padding: 0 !important; margin: 0 !important; background: none !important; }",
            ".report-criteria { margin: 4px 0 8px; padding: 4px 8px; border: 1px solid #d5deea; background: #f9fbfd; font-size: 8.5pt; color: #2c3e57; }",
            ".sec-head { margin: 6px 0; padding: 4px 8px; background: #f0f5fb; border-left: 4px solid #9fbfe6; } .sec-head h5 { margin: 0; font-size: 10.5pt; }",
            "table.rpt-fixed { table-layout: fixed; } table.rpt-fixed td, table.rpt-fixed th { overflow-wrap: anywhere; word-break: normal; }",
            "tr.group td { background: #eef3fa !important; font-weight: 700; font-size: 9.5pt; text-align: left !important; border: 1px solid #c9d7e8 !important; break-after: avoid; page-break-after: avoid; }",
            "tr.group td a { color: #1f3a5f; }",
            "tr.emp-row td.emp-cell { background: #f0f5fb !important; border-top: 2px solid #b9c9dd !important; font-size: 9pt; vertical-align: top; }",
            "tr.emp-row { break-after: avoid; page-break-after: avoid; }",
            ".emp-name { font-weight: 700; font-size: 10pt; color: #1f3a5f; } .k { font-weight: 600; color: #2c3e57; }",
            "tr.train-row td { padding-left: 9px; } tr.train-row td:nth-child(n+3) { text-align: center; }",
            ".hrm-printed { margin-top: 14px; padding-top: 4px; border-top: 1px solid #c5cfdc; text-align: right; font-size: 7.5pt; color: #777; }"
        ].join("\n");
    }

    function buildPrintHtml(panelId, opts) {
        opts = opts || {};
        var panel = get(panelId);
        if (!panel) { return null; }
        var clone = prepare(panel);
        if (opts.title) {
            // the title is already in the letterhead
            var secs = toArray(clone.querySelectorAll('.sec-head'));
            for (var q = 0; q < secs.length; q++) { if (secs[q].parentNode) { secs[q].parentNode.removeChild(secs[q]); } }
        }
        var tables = clone.querySelectorAll('table');
        for (var i = 0; i < tables.length; i++) {
            if (tables[i].querySelector('th')) { tables[i].className += ' hrm-grid'; }
        }
        var landscape = opts.orientation ? opts.orientation === 'landscape' : widestTable(clone) > 7;
        var head = '<div class="letterhead"><div class="org">SENATE OF PAKISTAN</div>' +
            '<div class="sub">HRM DATABASE &nbsp;|&nbsp; HRM BRANCH</div>' +
            (opts.title ? '<div class="title">' + esc(opts.title) + '</div>' : '') + '</div>';
        return '<html><head><title>' + esc(opts.title || d.title || 'Report') + '</title><style>' + css(landscape) + '</style></head><body>' +
            head + clone.innerHTML +
            '<div class="hrm-printed">Computer generated report &nbsp;|&nbsp; Printed on ' + stamp() + '</div></body></html>';
    }

    function print(panelId, opts) {
        var html = buildPrintHtml(panelId, opts);
        if (html === null) { w.alert('Nothing to print.'); return false; }
        var frame = d.createElement('iframe');
        frame.style.position = 'fixed';
        frame.style.right = '0';
        frame.style.bottom = '0';
        frame.style.width = '0';
        frame.style.height = '0';
        frame.style.border = '0';
        d.body.appendChild(frame);
        var doc = frame.contentWindow.document;
        doc.open();
        doc.write(html);
        doc.close();
        setTimeout(function () {
            frame.contentWindow.focus();
            frame.contentWindow.print();
            setTimeout(function () { if (frame.parentNode) { frame.parentNode.removeChild(frame); } }, 1000);
        }, 300);
        return false;
    }

    /* ----------------------------------------------------------- PDF export */

    function isHidden(el) {
        if (el.className && /(^|\s)unhid(\s|$)/.test(el.className)) { return false; }
        var cs = w.getComputedStyle ? w.getComputedStyle(el, null) : null;
        return !!cs && (cs.display === 'none' || cs.visibility === 'hidden');
    }
    function hasTable(el) { return !!el.querySelector('table'); }
    function hasBlock(el) { return !!el.querySelector('div, p, h1, h2, h3, h4, h5, h6, ul, ol, table'); }
    function isHeading(el) {
        return /^H[1-6]$/.test(el.tagName) || /(^|\s)(page-header|Headings|page-title)(\s|$)/.test(el.className || '');
    }

    function tableBlock(t, out) {
        if (hasTable(t)) {
            for (var r = 0; r < t.rows.length; r++) {
                if (isHidden(t.rows[r])) { continue; }
                for (var c = 0; c < t.rows[r].cells.length; c++) {
                    if (!isHidden(t.rows[r].cells[c])) { walk(t.rows[r].cells[c], out); }
                }
            }
            return;
        }
        var grid = !!t.querySelector('th');
        var rows = [];
        for (var i = 0; i < t.rows.length; i++) {
            var row = t.rows[i];
            if (isHidden(row)) { continue; }
            var cells = [];
            var any = false;
            for (var j = 0; j < row.cells.length; j++) {
                var cell = row.cells[j];
                if (isHidden(cell)) { continue; }
                var txt = clean(text(cell));
                if (txt) { any = true; }
                cells.push({ t: txt, cs: cell.colSpan || 1, th: cell.tagName === 'TH' });
            }
            if (cells.length && any) { rows.push(cells); }
        }
        if (rows.length) { out.push({ t: 'table', grid: grid, rows: rows }); }
    }

    function walk(node, out) {
        var buf = [];
        function flush() {
            var t = clean(buf.join(''));
            buf = [];
            if (t) { out.push({ t: 'p', text: t }); }
        }
        for (var i = 0; i < node.childNodes.length; i++) {
            var ch = node.childNodes[i];
            if (ch.nodeType === 3) { buf.push(ch.nodeValue); continue; }
            if (ch.nodeType !== 1) { continue; }
            if (isHidden(ch)) { continue; }
            var tag = ch.tagName;
            if (tag === 'TABLE') {
                flush();
                tableBlock(ch, out);
            } else if (tag === 'BR') {
                buf.push('\n');
            } else if (isHeading(ch)) {
                flush();
                if (hasTable(ch)) {
                    walk(ch, out);
                } else {
                    var h = clean(text(ch));
                    if (h) { out.push({ t: 'h', text: h }); }
                }
            } else if (BLOCK[tag]) {
                flush();
                walk(ch, out);
            } else if (hasTable(ch) || hasBlock(ch)) {
                flush();
                walk(ch, out);
            } else {
                buf.push(text(ch) + ' ');
            }
        }
        flush();
    }

    function maxColumns(blocks) {
        var max = 0;
        for (var i = 0; i < blocks.length; i++) {
            if (blocks[i].t !== 'table' || !blocks[i].grid) { continue; }
            for (var r = 0; r < blocks[i].rows.length; r++) {
                var n = 0;
                for (var c = 0; c < blocks[i].rows[r].length; c++) { n += blocks[i].rows[r][c].cs; }
                if (n > max) { max = n; }
            }
        }
        return max;
    }

    function collectBlocks(panel) {
        var clone = prepare(panel);
        var wrap = d.createElement('div');
        wrap.style.cssText = 'position:absolute;left:-10000px;top:0;width:1100px;';
        wrap.appendChild(clone);
        d.body.appendChild(wrap);
        var unhid = clone.querySelectorAll('.unhid');
        for (var u = 0; u < unhid.length; u++) { unhid[u].style.display = 'block'; }
        var blocks = [];
        try {
            walk(clone, blocks);
        } finally {
            d.body.removeChild(wrap);
        }
        return blocks;
    }

    function exportPdf(panelId, opts) {
        opts = opts || {};
        var panel = get(panelId);
        if (!panel) { w.alert('Nothing to export.'); return false; }
        var blocks = collectBlocks(panel);
        if (!blocks.length) { w.alert('Nothing to export.'); return false; }

        var payload = {
            title: opts.title || '',
            orientation: opts.orientation || (maxColumns(blocks) > 7 ? 'landscape' : 'portrait'),
            fileName: opts.fileName || opts.title || d.title || 'Report',
            blocks: blocks
        };
        var form = d.createElement('form');
        form.method = 'post';
        form.action = pdfUrl;
        form.style.display = 'none';
        var field = d.createElement('textarea');
        field.name = 'data';
        field.value = JSON.stringify(payload);
        form.appendChild(field);
        d.body.appendChild(form);
        form.submit();
        setTimeout(function () { if (form.parentNode) { form.parentNode.removeChild(form); } }, 1500);
        return false;
    }

    w.HRMPrint = { print: print, exportPdf: exportPdf, buildPrintHtml: buildPrintHtml, collectAttached: function (panelId) { return collectBlocks(get(panelId)); } };
})(window, document);
