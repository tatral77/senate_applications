/* QMS PDF export and print for result tables and documents.
     ExportPdf(name, orientation)   saves the page's results (the panel whose id ends in "pnlContents", else #printArea) as a PDF file
     PrintPanel()                   prints the same content
   or, from your own script: QMSPdf.export(elementOrSelector, { filename, title, orientation: 'landscape'|'portrait', header: true|false })
   The PDF is made in the browser with html2pdf.js (Scripts/html2pdf.bundle.min.js, loaded on first use), so Urdu and other text
   appears exactly as on screen. Anything with class "no-print" (and buttons) is left out. */
(function (w, d) {
    'use strict';

    var base = (function () {
        var s = d.querySelector('script[src*="qmspdf.js"]');
        return s ? s.src.replace(/qmspdf\.js.*$/, '') : 'Scripts/';
    })();

    var CSS =
        '.qms-pdf{background:#fff;color:#000;font-family:"Segoe UI",Arial,sans-serif;font-size:11px;line-height:1.4;padding:0}' +
        '.qms-pdf .qp-head{text-align:center;border-bottom:2px solid #124f96;padding-bottom:6px;margin-bottom:10px}' +
        '.qms-pdf .qp-org{font-family:"Times New Roman",serif;font-size:17px;font-weight:bold;letter-spacing:2px}' +
        '.qms-pdf .qp-title{font-size:13px;font-weight:bold;margin-top:2px}' +
        '.qms-pdf .qp-date{font-size:10px;color:#555;margin-top:2px}' +
        '.qms-pdf table{width:100% !important;max-width:none !important;border-collapse:collapse !important;border:1px solid #888 !important;display:table !important;background:#fff !important;border-radius:0 !important;margin:0 !important}' +
        '.qms-pdf thead{display:table-header-group !important}' +
        '.qms-pdf tr{page-break-inside:avoid;break-inside:avoid;display:table-row !important;background:#fff !important;border:0 !important;box-shadow:none !important}' +
        '.qms-pdf th,.qms-pdf td{border:1px solid #888 !important;padding:4px 6px !important;font-size:10.5px !important;vertical-align:top !important;display:table-cell !important;text-align:left;width:auto !important;background:#fff !important}' +
        '.qms-pdf th{background:#e8eef5 !important;color:#000 !important;font-weight:bold !important;text-shadow:none !important}' +
        '.qms-pdf td::before{display:none !important}' +
        '.qms-pdf a{color:#000 !important;text-decoration:none !important}';

    function msg(text) {
        var el = d.getElementById('qmsPdfToast');
        if (!text) { if (el) { el.parentNode.removeChild(el); } return; }
        if (!el) {
            el = d.createElement('div');
            el.id = 'qmsPdfToast';
            el.style.cssText = 'position:fixed;right:18px;bottom:18px;z-index:99999;padding:10px 16px;border-radius:10px;background:#124f96;color:#fff;font:600 13px "Segoe UI",Arial,sans-serif;box-shadow:0 6px 18px rgba(0,0,0,.3)';
            d.body.appendChild(el);
        }
        el.textContent = text;
    }

    function find(target) {
        if (target && target.nodeType === 1) { return target; }
        if (typeof target === 'string') { return d.querySelector(target); }
        return d.querySelector('[id$="pnlContents"]') || d.getElementById('printArea');
    }

    function today() {
        var n = new Date();
        function p(x) { return (x < 10 ? '0' : '') + x; }
        return p(n.getDate()) + '/' + p(n.getMonth() + 1) + '/' + n.getFullYear();
    }

    /* A print-ready copy of the element: no buttons, hidden parts or phone card layout. */
    function prepare(src, opts) {
        var clone = src.cloneNode(true);
        // "plain" documents (Orders of the Day) keep their own layout and buttons (they hold headings); tables and forms are stripped
        var kill = clone.querySelectorAll(opts.plain ? '.no-print, script, noscript' : '.no-print, script, noscript, button, input[type=submit], input[type=button], input[type=hidden], .btn, .glyphicon');
        for (var i = 0; i < kill.length; i++) { kill[i].parentNode.removeChild(kill[i]); }
        var cards = clone.querySelectorAll('.card-table');
        for (var c = 0; c < cards.length; c++) { cards[c].classList.remove('card-table'); }
        clone.removeAttribute('id');
        clone.style.cssText = 'width:100%;max-width:none;margin:0;position:static;box-shadow:none;';

        var wrap = d.createElement('div');
        wrap.className = 'qms-pdf';
        wrap.style.width = (opts.orientation === 'portrait' ? '720px' : '1040px');
        if (!opts.plain) {
            var style = d.createElement('style');
            style.textContent = CSS;
            wrap.appendChild(style);
        }
        wrap.style.background = '#fff';
        if (opts.header !== false) {
            var head = d.createElement('div');
            head.className = 'qp-head';
            var title = opts.title || d.title || '';
            head.innerHTML = '<div class="qp-org">SENATE OF PAKISTAN</div><div class="qp-title"></div><div class="qp-date">Generated on ' + today() + '</div>';
            head.querySelector('.qp-title').textContent = title;
            wrap.appendChild(head);
        }
        wrap.appendChild(clone);
        return wrap;
    }

    function loadLib(done) {
        if (w.html2pdf) { done(); return; }
        var s = d.createElement('script');
        s.src = base + 'html2pdf.bundle.min.js';
        s.onload = done;
        s.onerror = function () { msg(''); alert('The PDF component could not be loaded.'); };
        d.head.appendChild(s);
    }

    function exportPdf(target, opts) {
        opts = opts || {};
        var src = find(target);
        if (!src) { alert('There is nothing to export.'); return false; }
        opts.orientation = opts.orientation === 'portrait' ? 'portrait' : 'landscape';
        var name = (opts.filename || 'export').replace(/[^\w\-]+/g, '-');
        var now = new Date();
        var stamp = now.getFullYear() + '-' + ('0' + (now.getMonth() + 1)).slice(-2) + '-' + ('0' + now.getDate()).slice(-2);
        msg('Creating PDF...');
        loadLib(function () {
            var wrap = prepare(src, opts);
            // very long documents: keep the picture below the browser's canvas limit
            var rows = wrap.querySelectorAll('tr').length;
            var scale = rows > 600 ? 1 : (rows > 250 ? 1.4 : 2);
            var options = {
                margin: [10, 8, 12, 8],
                filename: name + '_' + stamp + '.pdf',
                image: { type: 'jpeg', quality: 0.95 },
                html2canvas: { scale: scale, useCORS: true, backgroundColor: '#ffffff', scrollY: 0, windowWidth: opts.orientation === 'portrait' ? 760 : 1080 },
                jsPDF: { unit: 'mm', format: 'a4', orientation: opts.orientation },
                pagebreak: { mode: ['css', 'legacy'], avoid: ['tr', '.qp-head'] }
            };
            w.html2pdf().set(options).from(wrap).toPdf().get('pdf').then(function (pdf) {
                var pages = pdf.internal.getNumberOfPages();
                var pw = pdf.internal.pageSize.getWidth(), ph = pdf.internal.pageSize.getHeight();
                for (var p = 1; p <= pages; p++) {
                    pdf.setPage(p);
                    pdf.setFontSize(8);
                    pdf.setTextColor(110);
                    pdf.text('Page ' + p + ' of ' + pages, pw / 2, ph - 5, { align: 'center' });
                }
            }).save().then(function () { msg(''); }, function () { msg(''); alert('The PDF could not be created.'); });
        });
        return false;
    }

    function printPanel(target, opts) {
        opts = opts || {};
        var src = find(target);
        if (!src) { alert('There is nothing to print.'); return false; }
        opts.orientation = opts.orientation || 'landscape';
        var wrap = prepare(src, opts);
        var win = w.open('', '_blank');
        if (!win) { alert('Please allow pop-ups to print.'); return false; }
        win.document.write('<!DOCTYPE html><html><head><meta charset="utf-8"><title>' + (opts.title || d.title || 'Print').replace(/</g, '&lt;') + '</title>' +
            '<style>@page{size:A4 ' + opts.orientation + ';margin:12mm}body{margin:0}' + '.qms-pdf{width:auto !important}</style></head><body>' + wrap.outerHTML + '</body></html>');
        win.document.close();
        win.focus();
        setTimeout(function () { win.print(); }, 400);
        return false;
    }

    w.QMSPdf = { export: exportPdf, print: printPanel };
    // used by the Export PDF / Print buttons on the search and report pages
    w.ExportPdf = function (name, orientation) { return exportPdf(null, { filename: name, orientation: orientation, title: name ? String(name).replace(/[-_]+/g, ' ') : '' }); };
    w.PrintPanel = function () { return printPanel(null, { title: d.title }); };
})(window, document);
