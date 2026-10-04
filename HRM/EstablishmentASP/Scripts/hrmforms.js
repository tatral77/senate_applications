/* HRM edit / insert forms:
   1. calendars (dd/mm/yy) on every date box,
   2. "To" date cannot be earlier than its "From" date (calendar limits + validator function used by the page validators),
   3. searchable multi-select: every <select multiple> (ListBox) becomes a chip box with a search list. The original list box stays in
      the page (hidden) and keeps the selection, so the code behind reads it exactly as before. */
(function (w, d, $) {
    'use strict';
    if (!$) { return; }

    var FORMAT = 'dd/mm/yy';
    var PAIRS = { ToDateTxt: 'FromDateTxt', DateToTxt: 'DateFromTxt', ProbationToTxt: 'ProbationFromTxt', PostedToTxt: 'PostedFromTxt', EmploymentToTxt: 'EmploymentFromTxt' };

    function tailOf(id) {
        var parts = String(id || '').split('_');
        return parts[parts.length - 1] || '';
    }
    function prefixOf(id) { return String(id).slice(0, String(id).length - tailOf(id).length); }
    // the From box of a To box (a few templates use another name, e.g. EmploymentDate for Other Employment)
    function fromIdFor(toId) {
        var from = PAIRS[tailOf(toId)];
        if (!from) { return null; }
        if (from === 'FromDateTxt' && !d.getElementById(prefixOf(toId) + from)) {
            if (d.getElementById(prefixOf(toId) + 'EmploymentDateTxt')) { from = 'EmploymentDateTxt'; }
            else if (d.getElementById(prefixOf(toId) + 'AppointmentDateTxt')) { from = 'AppointmentDateTxt'; }
        }
        return prefixOf(toId) + from;
    }
    function toIdFor(fromId) {
        var tail = tailOf(fromId);
        if ((tail === 'EmploymentDateTxt' || tail === 'AppointmentDateTxt') && d.getElementById(prefixOf(fromId) + 'ToDateTxt')) { return prefixOf(fromId) + 'ToDateTxt'; }
        for (var to in PAIRS) { if (PAIRS[to] === tail) { return prefixOf(fromId) + to; } }
        return null;
    }
    function isDateField(el) {
        if (!el || el.tagName !== 'INPUT' || (el.type && el.type !== 'text')) { return false; }
        if (el.readOnly || el.disabled) { return false; }
        if (/(^|\s)(no-calendar|hasDatepicker)(\s|$)/.test(el.className || '')) { return false; }
        // boxes the server marked as dates (their bound value is a date) always get a calendar
        if (/(^|\s)js-date(\s|$)/.test(el.className || '')) { return true; }
        var tail = tailOf(el.id);
        if (/time/i.test(tail)) { return false; }
        if (/date|upto|^dob|^(GovtSrvEntry|SenEntry)$/i.test(tail)) { return true; }
        // a box whose visible label says "date" (e.g. "Govt Service Entry Date") is a date even if its ID does not
        var label = $(el).closest('.pi-f').children('label').first().text() || $(el).closest('td').prev('td').text() || $(el).closest('div').children('label').first().text();
        if (/date/i.test(label || '')) { return true; }
        return !!(PAIRS[tail] || toIdFor(el.id) || /^(ExtendedTo|PenaltyTo)/.test(tail));
    }
    function parse(text) {
        var m = /^\s*(\d{1,2})[\/\-.](\d{1,2})[\/\-.](\d{4})\s*$/.exec(text || '');
        if (!m) { return null; }
        var dt = new Date(+m[3], +m[2] - 1, +m[1]);
        return dt.getMonth() === +m[2] - 1 ? dt : null;
    }

    /* ---------- calendars ---------- */
    function makePicker(el) {
        if (!$.fn.datepicker || !isDateField(el)) { return false; }
        var $el = $(el);
        $el.datepicker({
            dateFormat: FORMAT, changeMonth: true, changeYear: true, yearRange: '1930:2060', showAnim: 'fadeIn',
            beforeShow: function (input) {
                var opts = {};
                var fromEl = d.getElementById(fromIdFor(input.id) || '');
                var toEl = d.getElementById(toIdFor(input.id) || '');
                if (fromEl) { opts.minDate = parse(fromEl.value); }
                if (toEl) { opts.maxDate = parse(toEl.value); }
                return opts;
            }
        });
        $el.attr('autocomplete', 'off');
        if (!el.getAttribute('placeholder')) { el.setAttribute('placeholder', 'dd/mm/yyyy'); }
        return true;
    }
    function attachDates(root) {
        $(root || d).find('input[type=text]').each(function () { makePicker(this); });
    }
    // boxes that appear later (edit form opened after a post back) get their calendar when first used
    $(d).on('focusin click', 'input[type=text]', function () {
        if (!$(this).hasClass('hasDatepicker') && makePicker(this)) { $(this).datepicker('show'); }
    });

    /* ---------- To date must not be earlier than From date ---------- */
    w.HrmDateRange = function (source, args) {
        var toId = source.controltovalidate;
        var fromId = fromIdFor(toId);
        var toEl = d.getElementById(toId), fromEl = fromId && d.getElementById(fromId);
        args.IsValid = true;
        if (!toEl || !fromEl) { return; }
        var to = parse(toEl.value), from = parse(fromEl.value);
        if (to && from && to < from) { args.IsValid = false; }
    };
    // re-check as soon as either date is changed
    $(d).on('change', 'input[type=text]', function () {
        var toId = fromIdFor(this.id) ? this.id : toIdFor(this.id);
        if (!toId || !w.ValidatorValidate || !w.Page_Validators) { return; }
        for (var i = 0; i < w.Page_Validators.length; i++) {
            if (w.Page_Validators[i].controltovalidate === toId && w.Page_Validators[i].clientvalidationfunction === 'HrmDateRange') {
                w.ValidatorValidate(w.Page_Validators[i]);
            }
        }
    });

    /* ---------- searchable multi-select ---------- */
    function enhanceSelect(sel) {
        var $sel = $(sel);
        if ($sel.data('ms') || $sel.hasClass('no-ms')) { return; }
        $sel.data('ms', true);
        var placeholder = $sel.attr('data-placeholder') || 'Type to search...';

        var $box = $('<div class="form-control ms-box"></div>');
        var $chips = $('<span class="ms-chips"></span>').appendTo($box);
        var $input = $('<input type="text" class="ms-input" autocomplete="off" />').appendTo($box);
        var $list = $('<ul class="ms-list" style="display:none"></ul>').appendTo($box);
        $sel.hide().after($box);

        function options() { return $sel.find('option'); }
        function render() {
            $chips.empty();
            options().each(function () {
                if (!this.selected) { return; }
                var chip = $('<span class="ms-chip"></span>').text($(this).text());
                $('<button type="button" class="ms-x" title="Remove">&times;</button>').data('opt', this).appendTo(chip);
                $chips.append(chip);
            });
            $input.attr('placeholder', $chips.children().length ? 'Add another...' : placeholder);
        }
        function fill() {
            var q = $.trim($input.val()).toLowerCase(), shown = 0;
            $list.empty();
            options().each(function () {
                if (this.selected) { return; }
                var text = $(this).text();
                if (q && text.toLowerCase().indexOf(q) < 0) { return; }
                $('<li></li>').text(text).data('opt', this).appendTo($list);
                shown++;
            });
            if (!shown) { $('<li class="ms-none"></li>').text('No matches').appendTo($list); }
            $list.children().first().addClass('on');
            $list.show();
        }
        function pick(opt) {
            opt.selected = true;
            $sel.trigger('change');
            $input.val('');
            render();
            fill();
            $input.focus();
        }
        $chips.on('click', '.ms-x', function () {
            $(this).data('opt').selected = false;
            $sel.trigger('change');
            render();
            $input.focus();
        });
        $list.on('mousedown', 'li', function (e) {
            e.preventDefault();
            var opt = $(this).data('opt');
            if (opt) { pick(opt); }
        });
        $box.on('click', function (e) { if (!$(e.target).is('button')) { $input.focus(); } });
        $input.on('focus', function () { $box.addClass('focus'); fill(); })
              .on('blur', function () { $box.removeClass('focus'); $list.hide(); $input.val(''); })
              .on('input', fill)
              .on('keydown', function (e) {
                  var $on = $list.children('.on');
                  if (e.which === 40 || e.which === 38) {
                      e.preventDefault();
                      var $next = e.which === 40 ? $on.next() : $on.prev();
                      if ($next.length) { $on.removeClass('on'); $next.addClass('on'); }
                  } else if (e.which === 13) {
                      e.preventDefault();
                      if ($on.data('opt')) { pick($on.data('opt')); }
                  } else if (e.which === 27) {
                      $list.hide();
                  } else if (e.which === 8 && !$input.val()) {
                      var sel = options().filter(function () { return this.selected; }).last();
                      if (sel.length) { sel[0].selected = false; render(); fill(); }
                  }
              });
        render();
    }
    function attachSelects(root) {
        $(root || d).find('select[multiple]').each(function () { enhanceSelect(this); });
    }

    /* ---------- edit / insert forms: one consistent structure ----------
       label | control (+ its validators) in two columns, the form spanning the whole list, Save / Cancel in a final row */
    function span(row) {
        var n = 0;
        $(row).children('td, th').each(function () { n += this.colSpan || 1; });
        return n;
    }
    function tidyForms(root) {
        $(root || d).find('td[colspan] > table').each(function () {
            var $form = $(this);
            if ($form.hasClass('ef-form')) { return; }
            var $outer = $form.parent();
            var $list = $outer.closest('table');
            if ($list[0] === $form[0] || !$form.find('[id$="saveImageButton"], [id$="cancelImageButton"]').length) { return; }
            $form.addClass('ef-form');

            // the form takes the full width of the list it sits in
            var cols = 0;
            $list.children('thead, tbody').children('tr').each(function () {
                if (!$(this).find('table').length) { cols = Math.max(cols, span(this)); }
            });
            if (cols > 1) { $outer.attr('colspan', cols); }

            var rows = $form.children('tbody, thead').children('tr').add($form.children('tr'));
            rows.each(function () {
                var $row = $(this), $cells = $row.children('td');
                if ($cells.length < 2) { return; }
                var isAction = $row.find('[id$="saveImageButton"], [id$="cancelImageButton"]').length > 0;
                if (isAction) {
                    // buttons get one full-width cell; an "Action:" label is not needed
                    var $btnCell = $row.find('[id$="saveImageButton"], [id$="cancelImageButton"]').first().closest('td');
                    $btnCell.prepend($btnCell.find('[id$="cancelImageButton"]'));
                    $row.addClass('ef-actions');
                    $btnCell.addClass('ef-actions-cell').attr('colspan', 2);
                    $cells.not($btnCell).each(function () { if (!$.trim($(this).text()).replace(/^action:?$/i, '') && !$(this).find('input, select, textarea, a').length) { $(this).remove(); } else if (/^\s*action\s*:?\s*$/i.test($(this).text())) { $(this).remove(); } });
                    return;
                }
                // validators / notes in a third column go next to the control so the control gets the width
                var $ctl = $cells.eq(1);
                $cells.slice(2).each(function () {
                    var $c = $(this);
                    if (!$c.find('input:not([type=hidden]), select, textarea').length) {
                        $c.contents().appendTo($ctl);
                        $c.remove();
                    }
                });
                $row.children('td').first().addClass('ef-label');
                $row.children('td').eq(1).addClass('ef-field').attr('colspan', 1);
            });
            // a row with a single cell (e.g. a note or validation summary) spans both columns
            rows.each(function () {
                var $c = $(this).children('td');
                if ($c.length === 1) { $c.attr('colspan', 2); }
            });
        });
    }

    /* ---------- report tables: short columns hug their content, long text columns share the rest ---------- */
    function tuneReports(root) {
        $(root || d).find('.report-ui table').each(function () {
            var $t = $(this);
            if ($t.data('tuned') || $t.hasClass('rpt-fixed')) { return; }
            var $rows = $t.find('tbody > tr');
            var $head = $t.find('thead > tr').first().children('th');
            if (!$head.length || !$rows.length) { return; }
            $t.data('tuned', true);
            $head.each(function (i) {
                var longest = 0, hasWords = false;
                $rows.each(function () {
                    var $c = $(this).children('td').eq(i);
                    var txt = $.trim($c.text());
                    longest = Math.max(longest, txt.length);
                    if (txt.indexOf(' ') > 0 && txt.length > 20) { hasWords = true; }
                });
                var title = $.trim($(this).text());
                var fit = longest <= 16 && !hasWords;
                var cls = fit ? 'col-fit' : 'col-text';
                $(this).addClass(cls);
                $rows.each(function () { $(this).children('td').eq(i).addClass(cls); });
            });
        });
    }

    function init() { attachDates(d); attachSelects(d); tidyForms(d); tuneReports(d); }
    $(init);
    if (w.Sys && w.Sys.WebForms && w.Sys.WebForms.PageRequestManager) {
        w.Sys.WebForms.PageRequestManager.getInstance().add_endRequest(init);
    }
    // forms that are drawn later (edit / add opened by a partial post back) are set up as soon as they appear
    if (w.MutationObserver) {
        var timer = null;
        new w.MutationObserver(function () {
            clearTimeout(timer);
            timer = setTimeout(init, 60);
        }).observe(d.body, { childList: true, subtree: true });
    }
    w.HrmForms = { init: init };
})(window, document, window.jQuery);
