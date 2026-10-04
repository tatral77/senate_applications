/* Multi-select "chips" search box: type to search, pick as many items as needed, remove them with the x on each chip.
   Any number of boxes can be on one page. Markup:
     <div class="form-control member-multi" data-chips data-service="<url of the web method>" data-ids="#idOfHiddenField" data-names="#idOfNamesTextBox" data-placeholder="Type a name...">
         <span class="member-chips"></span><input type="text" class="member-input" autocomplete="off" />
     </div>
   The hidden field keeps the selected ids separated by commas, the names text box keeps the names separated by |
   (both are ordinary server controls, so the selection survives a post back).
   The web method receives {prefix} and returns strings like "Name=Id". */
(function (w, $) {
    'use strict';

    function Chips($box) {
        var service = $box.attr('data-service');
        var $ids = $($box.attr('data-ids'));
        var $names = $($box.attr('data-names'));
        var placeholder = $box.attr('data-placeholder') || 'Type a name to add...';
        var $chips = $box.find('.member-chips');
        var $input = $box.find('.member-input');
        var members = [];

        function has(id) {
            for (var i = 0; i < members.length; i++) { if (members[i].id === String(id)) { return true; } }
            return false;
        }
        function load() {
            members = [];
            var ids = $.grep(($ids.val() || '').split(','), function (s) { return /^\d+$/.test($.trim(s)); });
            var names = ($names.val() || '').split('|');
            for (var i = 0; i < ids.length; i++) {
                members.push({ id: $.trim(ids[i]), name: $.trim(names[i] || ('Item ' + ids[i])) });
            }
        }
        function save() {
            $ids.val($.map(members, function (m) { return m.id; }).join(','));
            $names.val($.map(members, function (m) { return m.name; }).join('|'));
        }
        function render() {
            $chips.empty();
            $.each(members, function (i, m) {
                var chip = $('<span class="member-chip"></span>').text(m.name);
                $('<button type="button" class="member-chip-x" title="Remove">&times;</button>').data('id', m.id).appendTo(chip);
                $chips.append(chip);
            });
            $input.attr('placeholder', members.length ? 'Add another...' : placeholder);
        }
        function add(id, name) {
            if (!has(id)) { members.push({ id: String(id), name: name }); save(); render(); }
            $input.val('');
        }
        function remove(id) {
            members = $.grep(members, function (m) { return m.id !== String(id); });
            save();
            render();
        }

        $chips.on('click', '.member-chip-x', function () { remove($(this).data('id')); $input.focus(); });
        $box.on('click', function (e) { if (!$(e.target).is('button')) { $input.focus(); } });
        $input.on('focus', function () { $box.addClass('focus'); }).on('blur', function () { $box.removeClass('focus'); });
        $input.on('keydown', function (e) {
            if (e.which === 13) { e.preventDefault(); }
            if (e.which === 8 && !$input.val() && members.length) { members.pop(); save(); render(); }
        });
        $input.autocomplete({
            minLength: 1,
            source: function (request, response) {
                $.ajax({
                    url: service,
                    data: JSON.stringify({ prefix: request.term }),
                    dataType: 'json',
                    type: 'POST',
                    contentType: 'application/json; charset=utf-8',
                    success: function (data) {
                        var list = [];
                        $.each(data.d, function (i, item) {
                            var parts = item.split('=');
                            var id = parts[parts.length - 1];
                            var label = parts.slice(0, parts.length - 1).join('=');
                            if (!has(id)) { list.push({ label: label, value: label, val: id }); }
                        });
                        response(list);
                    },
                    error: function (response) { alert(response.responseText); }
                });
            },
            focus: function () { return false; },
            select: function (event, ui) { add(ui.item.val, ui.item.label); return false; }
        });

        load();
        render();
        $box.data('chips', { clear: function () { members = []; save(); render(); $input.val(''); } });
    }

    function init(root) {
        $(root || document).find('[data-chips]').each(function () {
            if (!$(this).data('chips')) { Chips($(this)); }
        });
    }

    $(function () { init(document); });
    w.QMSChips = { init: init };
})(window, window.jQuery);
