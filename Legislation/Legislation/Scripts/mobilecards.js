/* On phones every data table is shown as a stack of cards. This script copies each column heading onto its cells
   (data-label) so the card can show "Heading: value" lines; the layout itself is CSS in Styles/modern.css. */
(function (w, d) {
    'use strict';

    function textOf(el) { return (el.textContent || '').replace(/\s+/g, ' ').replace(/^ | $/g, ''); }

    function isHeaderRow(tr) {
        var th = 0, td = 0;
        for (var i = 0; i < tr.cells.length; i++) {
            if (tr.cells[i].tagName === 'TH') { th++; } else { td++; }
        }
        return th > 0 && td === 0;
    }

    function convert(table) {
        if (table.getAttribute('data-cards') === '1' || /(^|\s)no-cards(\s|$)/.test(table.className)) { return; }
        var rows = table.rows;
        var headRow = null;
        for (var i = 0; i < rows.length; i++) {
            if (isHeaderRow(rows[i])) { headRow = rows[i]; break; }
        }
        if (!headRow || headRow.cells.length < 2) { return; }

        var labels = [];
        for (var c = 0; c < headRow.cells.length; c++) {
            var label = textOf(headRow.cells[c]);
            var span = headRow.cells[c].colSpan || 1;
            for (var s = 0; s < span; s++) { labels.push(s === 0 ? label : ''); }
        }

        for (var r = 0; r < rows.length; r++) {
            var row = rows[r];
            if (isHeaderRow(row)) { row.className += ' card-head'; continue; }
            var index = 0;
            for (var k = 0; k < row.cells.length; k++) {
                var cell = row.cells[k];
                var colspan = cell.colSpan || 1;
                if (colspan > 1) {
                    cell.className += ' card-span';
                } else if (labels[index]) {
                    cell.setAttribute('data-label', labels[index]);
                }
                if (!textOf(cell) && !cell.querySelector('img, input, a, button, select, textarea')) {
                    cell.className += ' card-empty';
                }
                index += colspan;
            }
        }
        table.className += ' card-table';
        table.setAttribute('data-cards', '1');
    }

    function run(root) {
        var tables = (root || d).querySelectorAll('table');
        for (var i = 0; i < tables.length; i++) { convert(tables[i]); }
    }

    function start() {
        run(d);
        if (w.Sys && w.Sys.WebForms && w.Sys.WebForms.PageRequestManager) {
            var prm = w.Sys.WebForms.PageRequestManager.getInstance();
            prm.add_endRequest(function () { run(d); });
        }
    }

    if (d.readyState === 'loading') { d.addEventListener('DOMContentLoaded', start); } else { start(); }
    w.HRMCards = { run: run };
})(window, document);
