/* Expandable search panel for the Question / Resolution search pages.

   Markup it expects (see SearchQuestion.aspx / SearchResolution.aspx):
     .qs-filter                the panel
       #qsBody                 everything under the heading (basic filters, more filters, Search / Reset)
       #qsMore                 the "more filters" block (bootstrap collapse)
       .qs-more-toggle         button that expands / collapses #qsMore
       #qsPanelToggle          button that shows / hides the whole search (#qsBody)
       #qsApplied              small label that says how many filters are applied while the search is hidden

   What it does
     - "More filters" is closed unless one of those filters already has a value, and shows how many are set.
     - "Hide search" gives the results the whole screen; the choice is remembered for this page.
     - After pressing Search the panel folds away so the results are visible; a label keeps showing how many filters are applied.

   QSPanel.init({ key: 'question' });                                                                         */
(function ($) {
    'use strict';

    function store(kind) {
        try { return window[kind + 'Storage']; } catch (e) { return null; }
    }
    function read(kind, key) { var s = store(kind); try { return s ? s.getItem(key) : null; } catch (e) { return null; } }
    function write(kind, key, value) { var s = store(kind); try { if (s) { if (value === null) s.removeItem(key); else s.setItem(key, value); } } catch (e) { } }

    // Fields inside $scope that currently hold a filter value.
    function activeCount($scope) {
        var n = 0;
        $scope.find('input[type=text], input[type=search], input[type=number], textarea').each(function () {
            if (this.id === 'memberSearch') return;                       // the typing box of the member picker
            if ($.trim($(this).val())) n++;
        });
        $scope.find('select').each(function () {
            var v = $(this).val();
            if (this.selectedIndex > 0 && v !== '0' && v !== '' && v !== null) n++;
        });
        $scope.find('input[type=checkbox]').each(function () {
            if (this.checked && !/FullText/i.test(this.id)) n++;        // "Complete Text" changes the display, it is not a filter
        });
        if ($scope.find('#memberChips .member-chip').length) n++;         // members picked in the member box
        return n;
    }

    function init(options) {
        var key = 'qsPanel:' + ((options && options.key) || location.pathname);
        var flagKey = key + ':foldAfterSearch';

        $(function () {
            var $panel = $('.qs-filter');
            var $body = $('#qsBody');
            var $more = $('#qsMore');
            var $moreBtn = $('.qs-more-toggle');
            var $panelBtn = $('#qsPanelToggle');
            var $applied = $('#qsApplied');
            if (!$panel.length || !$body.length) return;

            function refreshCounts() {
                var moreN = $more.length ? activeCount($more) : 0;
                var allN = activeCount($body);
                var $badge = $moreBtn.find('.qs-more-badge');
                if (moreN) $badge.text(moreN).show(); else $badge.hide();
                if (allN) $applied.text(allN + (allN === 1 ? ' filter applied' : ' filters applied')); else $applied.text('No filters');
            }

            function moreLabel(open) {
                $moreBtn.find('.qs-more-text').text(open ? 'Fewer filters' : 'More filters');
                $moreBtn.find('.glyphicon').removeClass('glyphicon-filter glyphicon-chevron-up').addClass(open ? 'glyphicon-chevron-up' : 'glyphicon-filter');
            }

            function setPanel(open, remember) {
                if (open) $body.stop(true, true).slideDown(150); else $body.stop(true, true).slideUp(150);
                $panelBtn.find('.qs-panel-text').text(open ? 'Hide search' : 'Show search');
                $panelBtn.find('.glyphicon').toggleClass('glyphicon-chevron-up', open).toggleClass('glyphicon-chevron-down', !open);
                $applied.toggle(!open);
                if (remember) write('local', key, open ? 'open' : 'closed');
                if (open) refreshCounts();
            }

            // "More filters": closed unless something in it is already filled in
            if ($more.length) {
                if (activeCount($more) > 0) $more.addClass('in'); else $more.removeClass('in');
                moreLabel($more.hasClass('in'));
                $more.on('shown.bs.collapse', function () { moreLabel(true); });
                $more.on('hidden.bs.collapse', function () { moreLabel(false); });
            } else {
                $moreBtn.hide();
            }

            // whole panel: fold after a search, otherwise use the remembered choice
            var open = read('local', key) !== 'closed';
            if (read('session', flagKey) === '1') { open = false; write('session', flagKey, null); }
            refreshCounts();
            if (open) { $body.show(); } else { $body.hide(); }
            $panelBtn.find('.qs-panel-text').text(open ? 'Hide search' : 'Show search');
            $panelBtn.find('.glyphicon').toggleClass('glyphicon-chevron-up', open).toggleClass('glyphicon-chevron-down', !open);
            $applied.toggle(!open);

            $panelBtn.on('click', function () { setPanel($body.is(':hidden'), true); });

            // keep the counts current while the user types
            $body.on('input change', refreshCounts);
            // member picker adds/removes chips without firing input events
            if (window.MutationObserver && document.getElementById('memberChips')) {
                new MutationObserver(refreshCounts).observe(document.getElementById('memberChips'), { childList: true });
            }

            // after Search, fold the panel so the results are in view
            $body.find('input[type=submit][id$=Button2], input[type=submit][id$=Search]').on('click', function () {
                write('session', flagKey, '1');
            });
        });
    }

    window.QSPanel = { init: init };
})(jQuery);
