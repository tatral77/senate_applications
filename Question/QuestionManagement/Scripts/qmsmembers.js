/* QMS member multi-select: type to search members, pick as many as needed, remove them with the x on each chip.
   Markup expected on the page:
     <div id="memberBox" class="form-control member-multi"><span id="memberChips"></span><input type="text" id="memberSearch" class="member-input" /></div>
     <asp:TextBox ID="MemberNameTxt" ClientIDMode="Static" style="display:none" />   (holds the names, separated by |)
     <asp:HiddenField ID="HidMemberId" />                                          (holds the member ids, separated by commas)
   Usage:  QMSMembers.init({ service: '<url of Service.asmx/GetAllMembersByName>' });   and  QMSMembers.clear();  from Reset. */
(function (w, $) {
    'use strict';
    var members = [];
    var ui = null;

    function has(id) {
        for (var i = 0; i < members.length; i++) { if (members[i].id === String(id)) { return true; } }
        return false;
    }
    function load() {
        members = [];
        var ids = $.grep((ui.$ids.val() || '').split(','), function (s) { return /^\d+$/.test($.trim(s)); });
        var names = (ui.$names.val() || '').split('|');
        for (var i = 0; i < ids.length; i++) {
            members.push({ id: $.trim(ids[i]), name: $.trim(names[i] || ('Member ' + ids[i])) });
        }
    }
    function save() {
        ui.$ids.val($.map(members, function (m) { return m.id; }).join(','));
        ui.$names.val($.map(members, function (m) { return m.name; }).join('|'));
    }
    function render() {
        ui.$chips.empty();
        $.each(members, function (i, m) {
            var chip = $('<span class="member-chip"></span>').text(m.name);
            $('<button type="button" class="member-chip-x" title="Remove">&times;</button>').data('id', m.id).appendTo(chip);
            ui.$chips.append(chip);
        });
        ui.$input.attr('placeholder', members.length ? 'Add another member...' : 'Type a member name to add...');
    }
    function add(id, name) {
        if (!has(id)) { members.push({ id: String(id), name: name }); save(); render(); }
        ui.$input.val('');
    }
    function removeId(id) {
        members = $.grep(members, function (m) { return m.id !== String(id); });
        save();
        render();
    }

    function init(options) {
        ui = {
            $ids: $('[id$=HidMemberId]'),
            $names: $('#MemberNameTxt'),
            $chips: $('#memberChips'),
            $input: $('#memberSearch'),
            $box: $('#memberBox')
        };
        if (!ui.$input.length) { return; }

        ui.$chips.on('click', '.member-chip-x', function () { removeId($(this).data('id')); ui.$input.focus(); });
        ui.$box.on('click', function (e) { if (!$(e.target).is('button')) { ui.$input.focus(); } });
        ui.$input.on('focus', function () { ui.$box.addClass('focus'); }).on('blur', function () { ui.$box.removeClass('focus'); });
        ui.$input.on('keydown', function (e) {
            if (e.which === 13) { e.preventDefault(); }
            if (e.which === 8 && !ui.$input.val() && members.length) { members.pop(); save(); render(); }
        });
        ui.$input.autocomplete({
            minLength: 1,
            source: function (request, response) {
                $.ajax({
                    url: options.service,
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
            select: function (event, ui2) { add(ui2.item.val, ui2.item.label); return false; }
        });

        load();
        render();
    }

    function clear() {
        if (!ui) { return; }
        members = [];
        save();
        render();
        ui.$input.val('');
    }

    w.QMSMembers = { init: init, clear: clear };
})(window, window.jQuery);
