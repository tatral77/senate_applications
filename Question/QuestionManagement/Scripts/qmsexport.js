/* QMS "Export PDF": collects what is shown in a page panel (headings, paragraphs, tables) and posts it to PdfExport.ashx,
   which returns it as a PDF download. Printing is left to each page's own PrintPanel().
   Usage:  QMSExport.exportPdf(panelClientId, { title: 'REPORT TITLE', fallback: PrintPanel });
   Urdu text cannot be shaped by the PDF generator, so when it is present the page's print dialog is offered instead. */
(function (w, d) {
    'use strict';

    var scriptSrc = (function () {
        var s = d.currentScript;
        if (!s) {
            var all = d.getElementsByTagName('script');
            for (var i = all.length - 1; i >= 0; i--) {
                if (/qmsexport\.js/i.test(all[i].src)) { s = all[i]; break; }
            }
        }
        return s ? s.src : '';
    })();
    var pdfUrl = scriptSrc.replace(/Scripts\/qmsexport\.js.*$/i, 'PdfExport.ashx');

    var BLOCK = { DIV: 1, P: 1, UL: 1, OL: 1, LI: 1, SECTION: 1, HEADER: 1, FOOTER: 1, FORM: 1, FIELDSET: 1, CENTER: 1, ARTICLE: 1, ASIDE: 1, NAV: 1, PRE: 1, DL: 1, DT: 1, DD: 1, LEGEND: 1, HR: 1 };
    function range(a, b) { return String.fromCharCode(a) + '-' + String.fromCharCode(b); }
    var ARABIC = new RegExp('[' + range(0x600, 0x6FF) + range(0x750, 0x77F) + range(0xFB50, 0xFDFF) + range(0xFE70, 0xFEFF) + ']');

    function toArray(list) { return Array.prototype.slice.call(list || []); }
    function get(id) { return d.getElementById(id); }
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
            var rep;
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
        var drop = toArray(clone.querySelectorAll('script, style, button, a.btn, .hid, .no-print'));
        for (var j = 0; j < drop.length; j++) {
            if (drop[j].parentNode) { drop[j].parentNode.removeChild(drop[j]); }
        }
        return clone;
    }

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
        if (grid) { dropEmptyColumns(rows); }
        if (rows.length) { out.push({ t: 'table', grid: grid, rows: rows }); }
    }

    /* Columns that hold nothing but a heading (for example a column of action buttons) are left out. */
    function dropEmptyColumns(rows) {
        if (rows.length < 2) { return; }
        var width = rows[0].length;
        for (var r = 0; r < rows.length; r++) {
            if (rows[r].length !== width) { return; }
            for (var c = 0; c < width; c++) {
                if (rows[r][c].cs !== 1) { return; }
            }
        }
        for (var col = width - 1; col >= 0; col--) {
            var empty = true;
            for (var i = 0; i < rows.length; i++) {
                if (!rows[i][col].th && rows[i][col].t) { empty = false; break; }
            }
            if (empty) {
                for (var k = 0; k < rows.length; k++) { rows[k].splice(col, 1); }
            }
        }
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

    function exportPdf(panelId, opts) {
        opts = opts || {};
        var panel = get(panelId);
        if (!panel) { w.alert('Nothing to export.'); return false; }
        var blocks = collectBlocks(panel);
        if (!blocks.length) { w.alert('Nothing to export.'); return false; }

        var json = JSON.stringify({
            title: opts.title || '',
            orientation: opts.orientation || (maxColumns(blocks) > 7 ? 'landscape' : 'portrait'),
            fileName: opts.fileName || opts.title || d.title || 'Report',
            blocks: blocks
        });
        if (ARABIC.test(json)) {
            if (typeof opts.fallback === 'function' &&
                w.confirm('This report contains Urdu text, which cannot be exported to PDF reliably.\n\nOpen the print dialog instead? Choose "Save as PDF" as the printer to get a PDF with correct Urdu.')) {
                return opts.fallback();
            }
            if (typeof opts.fallback === 'function') { return false; }
        }

        var form = d.createElement('form');
        form.method = 'post';
        form.action = pdfUrl;
        form.style.display = 'none';
        var field = d.createElement('textarea');
        field.name = 'data';
        field.value = json;
        form.appendChild(field);
        d.body.appendChild(form);
        form.submit();
        setTimeout(function () { if (form.parentNode) { form.parentNode.removeChild(form); } }, 1500);
        return false;
    }

    w.QMSExport = { exportPdf: exportPdf, collectAttached: function (panelId) { return collectBlocks(get(panelId)); } };
})(window, document);
