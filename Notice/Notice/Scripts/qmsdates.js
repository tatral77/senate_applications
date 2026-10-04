/* QMS calendars: adds the jQuery UI date picker to every date text box on a page, so no page has to be edited one by one.
   A text box is treated as a date when its control name contains "Date" (or is "DOB") and not "Time".
   Skipped: read-only or disabled boxes, boxes with class "no-calendar", boxes a page already set up itself, and pages
   that load their own jQuery from a CDN (they configure their own calendars).
   Optional on a box: data-max-date="0" (no future dates), data-min-date="-30" (at most 30 days back).
   From/To pairs (DateFrom/DateTo, FromDate/ToDate, StartDate/EndDate) are linked so the end date cannot precede the start date. */
(function (w, d) {
    'use strict';
    var $ = w.jQuery;
    if (!$ || !$.fn || !$.fn.datepicker) { return; }
    if (d.querySelector('script[src*="code.jquery.com"]')) { return; }

    var FORMAT = 'dd/mm/yy';
    var PLACEHOLDER = 'dd/mm/yyyy';
    var FROM_TO = [
        [/^(DateFrom)(Txt)?$/i, 'DateTo'],
        [/^(FromDate)(Txt)?$/i, 'ToDate'],
        [/^(StartDate)(Txt)?$/i, 'EndDate']
    ];

    function tailOf(id) {
        var parts = String(id || '').split('_');
        while (parts.length > 1 && /^\d+$/.test(parts[parts.length - 1])) { parts.pop(); }
        return parts[parts.length - 1] || '';
    }

    function isDateField(el) {
        if (el.type && el.type !== 'text') { return false; }
        if (/(^|\s)js-date(\s|$)/.test(el.className || '') && !el.readOnly && !el.disabled && !/hasDatepicker/.test(el.className)) { return true; }
        var tail = tailOf(el.id);
        if (!(/date/i.test(tail) || /^dob$/i.test(tail))) { return false; }
        if (/time/i.test(tail)) { return false; }
        if (el.readOnly || el.disabled) { return false; }
        if (/(^|\s)(no-calendar|hasDatepicker|datepicker)(\s|$)/.test(el.className || '')) { return false; }
        return true;
    }

    function link(fromEl, toEl) {
        var $from = $(fromEl), $to = $(toEl);
        $from.datepicker('option', 'onClose', function (value) { $to.datepicker('option', 'minDate', value || null); });
        $to.datepicker('option', 'onClose', function (value) { $from.datepicker('option', 'maxDate', value || null); });
    }

    function attach(root) {
        var fields = [];
        $(root || d).find('input').each(function () {
            if (!isDateField(this)) { return; }
            var opts = { dateFormat: FORMAT, changeMonth: true, changeYear: true, showAnim: 'fadeIn' };
            var maxDays = this.getAttribute('data-max-date'), minDays = this.getAttribute('data-min-date');
            if (maxDays !== null && maxDays !== '') { opts.maxDate = parseInt(maxDays, 10); }
            if (minDays !== null && minDays !== '') { opts.minDate = parseInt(minDays, 10); }
            $(this).datepicker(opts);
            $(this).attr('autocomplete', 'off');
            if (!this.getAttribute('placeholder')) { this.setAttribute('placeholder', PLACEHOLDER); }
            fields.push(this);
        });
        $.each(fields, function (i, el) {
            var tail = tailOf(el.id);
            for (var k = 0; k < FROM_TO.length; k++) {
                var m = FROM_TO[k][0].exec(tail);
                if (!m) { continue; }
                var suffix = m[2] || '';
                var partnerId = el.id.slice(0, el.id.lastIndexOf(m[1])) + FROM_TO[k][1] + suffix + el.id.slice(el.id.lastIndexOf(m[1]) + m[0].length);
                var partner = d.getElementById(partnerId);
                if (partner && $(partner).hasClass('hasDatepicker')) { link(el, partner); }
            }
        });
    }

    $(function () {
        attach(d);
        if (w.Sys && w.Sys.WebForms && w.Sys.WebForms.PageRequestManager) {
            w.Sys.WebForms.PageRequestManager.getInstance().add_endRequest(function () { attach(d); });
        }
    });

    w.QMSDates = { attach: attach, format: FORMAT };
})(window, document);
