/*  Attachment box - a shared, plain-JavaScript "polish" for <input type="file"> boxes.
    -------------------------------------------------------------------------------------------------
    Turns the native file box into a light card: a styled "Choose File" button, drag-and-drop, a chip
    showing the chosen file's name/size/type with a clear (x) button, and a note when the file looks
    too big or the wrong kind for what the box accepts.

    It does not replace the <input>: the input stays exactly where it is in the form, so ASP.NET
    postbacks and any existing "on change" code keep working. This script only adds things around it.

    Use:  every <input type="file" runat="server" /> is picked up automatically - nothing to mark.
          To skip a box, add  data-ab-skip="true"  to it.
    Load once per page (e.g. from the master page), before senatescan.js if both are used:
          <script src="Scripts/attachbox.js"></script>
          <script src="Scripts/senatescan.js"></script>                                                    */
(function () {
    'use strict';

    function el(tag, className, html) {
        var e = document.createElement(tag);
        if (className) e.className = className;
        if (html !== undefined) e.innerHTML = html;
        return e;
    }
    function esc(s) { var d = document.createElement('div'); d.appendChild(document.createTextNode(s == null ? '' : String(s))); return d.innerHTML; }

    function addStyles() {
        if (document.getElementById('ab-styles')) return;
        var css =
            '.ab-box{position:relative;border:1px solid #e2e8f0;border-radius:8px;background:#fff;box-shadow:0 1px 3px rgba(15,30,60,.06);padding:14px 16px;max-width:560px;transition:border-color .15s,box-shadow .15s}' +
            '.ab-box.ab-drag{border-color:#1f6fb5;border-style:dashed;background:#f5f9fd;box-shadow:0 0 0 3px rgba(31,111,181,.12)}' +
            '.ab-row{display:flex;align-items:center;flex-wrap:wrap;gap:10px}' +
            '.ab-pick{display:inline-flex;align-items:center;gap:7px;height:34px;padding:0 16px;border-radius:5px;border:1px solid #0c3a72;background:#0c3a72;color:#fff;font-size:13px;font-weight:600;cursor:pointer;user-select:none;transition:background .15s,box-shadow .15s}' +
            '.ab-pick:hover{background:#0a2f5d}' +
            '.ab-pick:active{box-shadow:inset 0 1px 3px rgba(0,0,0,.25)}' +
            '.ab-pick .glyphicon{font-size:12px}' +
            '.ab-hint{font-size:12px;color:#8996a6}' +
            '.ab-box input[type=file]{position:absolute;width:1px;height:1px;opacity:0;overflow:hidden;pointer-events:none}' +
            '.ab-chip{display:none;align-items:center;gap:10px;margin-top:12px;padding:9px 12px;background:#f8fafc;border:1px solid #eef1f5;border-radius:6px}' +
            '.ab-chip.ab-on{display:flex}' +
            '.ab-ic{flex:0 0 32px;height:32px;line-height:32px;text-align:center;border-radius:5px;background:#e8f0f9;color:#0c3a72;font-size:10px;font-weight:700;letter-spacing:.02em}' +
            '.ab-ic.ab-pdf{background:#fbe4e1;color:#a5281b}.ab-ic.ab-img{background:#e6f4ea;color:#1b6b34}.ab-ic.ab-doc{background:#eaf0fb;color:#2447a0}' +
            '.ab-meta{min-width:0;flex:1}' +
            '.ab-name{font-size:13px;font-weight:600;color:#1f2d3d;white-space:nowrap;overflow:hidden;text-overflow:ellipsis}' +
            '.ab-size{font-size:11.5px;color:#8996a6;margin-top:1px}' +
            '.ab-clear{flex:0 0 auto;width:26px;height:26px;border-radius:50%;border:0;background:transparent;color:#8996a6;font-size:17px;line-height:1;cursor:pointer;transition:background .15s,color .15s}' +
            '.ab-clear:hover{background:#fbe4e1;color:#a5281b}' +
            '.ab-warn{margin-top:8px;font-size:12px;color:#a5281b}' +
            '@media (max-width:520px){.ab-box{max-width:none}.ab-row{gap:8px}}';
        var style = el('style'); style.id = 'ab-styles'; style.appendChild(document.createTextNode(css));
        document.head.appendChild(style);
    }

    function fileKind(name) {
        var ext = (name.split('.').pop() || '').toLowerCase();
        if (ext === 'pdf') return ['ab-pdf', 'PDF'];
        if (/^(jpe?g|png|gif|bmp|tiff?|webp)$/.test(ext)) return ['ab-img', 'IMG'];
        if (/^(docx?|rtf)$/.test(ext)) return ['ab-doc', 'DOC'];
        if (/^(xlsx?|csv)$/.test(ext)) return ['ab-doc', 'XLS'];
        return ['', (ext || '?').slice(0, 3).toUpperCase()];
    }

    function niceSize(bytes) {
        if (bytes < 1024) return bytes + ' B';
        if (bytes < 1024 * 1024) return Math.round(bytes / 1024) + ' KB';
        return (bytes / (1024 * 1024)).toFixed(1) + ' MB';
    }

    // Checks a chosen file against the input's own "accept" attribute (if it has one).
    function accepted(input, file) {
        var accept = input.getAttribute('accept');
        if (!accept) return true;
        var name = file.name.toLowerCase(), type = (file.type || '').toLowerCase();
        return accept.split(',').some(function (rule) {
            rule = rule.trim().toLowerCase();
            if (!rule) return true;
            if (rule.charAt(0) === '.') return name.indexOf(rule, name.length - rule.length) !== -1;
            if (rule.indexOf('/*') !== -1) return type.indexOf(rule.slice(0, rule.indexOf('/'))) === 0;
            return type === rule;
        });
    }

    function enhance(input) {
        if (!input || input.getAttribute('data-ab-ready') || input.getAttribute('data-ab-skip') === 'true') return;
        input.setAttribute('data-ab-ready', '1');

        var box = el('div', 'ab-box');
        input.parentNode.insertBefore(box, input);
        box.appendChild(input);

        var row = el('div', 'ab-row');
        var pickBtn = el('button', 'ab-pick', '<span class="glyphicon glyphicon-paperclip"></span> Choose File');
        pickBtn.type = 'button';
        pickBtn.onclick = function () { input.click(); };
        row.appendChild(pickBtn);
        var hint = el('span', 'ab-hint', input.multiple ? 'or drop files here' : 'or drop a file here');
        row.appendChild(hint);
        box.appendChild(row);

        var chip = el('div', 'ab-chip');
        box.appendChild(chip);
        var warn = el('div', 'ab-warn');
        warn.style.display = 'none';
        box.appendChild(warn);

        function oneChip(file) {
            var kind = fileKind(file.name);
            var c = el('span', 'ab-chip ab-on');
            c.appendChild(el('span', 'ab-ic ' + kind[0], kind[1]));
            var meta = el('span', 'ab-meta');
            meta.appendChild(el('span', 'ab-name', esc(file.name)));
            meta.appendChild(el('br'));
            meta.appendChild(el('span', 'ab-size', niceSize(file.size)));
            c.appendChild(meta);
            var x = el('button', 'ab-clear', '&times;'); x.type = 'button'; x.title = 'Remove';
            x.onclick = function (e) { e.preventDefault(); clearInput(); };
            c.appendChild(x);
            return c;
        }

        function render() {
            chip.className = 'ab-chip'; chip.innerHTML = '';
            warn.style.display = 'none';
            var files = input.files ? Array.prototype.slice.call(input.files) : [];
            if (!files.length) return;
            chip.className = 'ab-chip ab-on';
            if (files.length === 1) chip.appendChild(oneChip(files[0]));
            else {
                var total = files.reduce(function (n, f) { return n + f.size; }, 0);
                chip.appendChild(el('span', 'ab-ic', String(files.length)));
                var meta = el('span', 'ab-meta');
                meta.appendChild(el('span', 'ab-name', files.length + ' files selected'));
                meta.appendChild(el('br'));
                meta.appendChild(el('span', 'ab-size', niceSize(total)));
                chip.appendChild(meta);
                var x = el('button', 'ab-clear', '&times;'); x.type = 'button'; x.title = 'Remove all';
                x.onclick = function (e) { e.preventDefault(); clearInput(); };
                chip.appendChild(x);
            }
            var bad = files.filter(function (f) { return !accepted(input, f); });
            if (bad.length) {
                warn.style.display = '';
                warn.textContent = (bad.length === 1 ? 'This file type' : 'Some of these file types') + ' may not be accepted here.';
            }
        }

        function clearInput() {
            try { input.value = ''; } catch (e) { }
            var ev; try { ev = new Event('change', { bubbles: true }); } catch (e2) { ev = document.createEvent('Event'); ev.initEvent('change', true, true); }
            input.dispatchEvent(ev);
        }

        input.addEventListener('change', render);

        // drag and drop
        ['dragenter', 'dragover'].forEach(function (evt) {
            box.addEventListener(evt, function (e) { e.preventDefault(); e.stopPropagation(); box.classList.add('ab-drag'); });
        });
        ['dragleave', 'dragend', 'drop'].forEach(function (evt) {
            box.addEventListener(evt, function (e) { box.classList.remove('ab-drag'); });
        });
        box.addEventListener('drop', function (e) {
            e.preventDefault(); e.stopPropagation();
            var dropped = e.dataTransfer && e.dataTransfer.files;
            if (!dropped || !dropped.length) return;
            var dt = new DataTransfer();
            if (input.multiple) {
                if (input.files) for (var i = 0; i < input.files.length; i++) dt.items.add(input.files[i]);
                for (var j = 0; j < dropped.length; j++) dt.items.add(dropped[j]);
            } else {
                dt.items.add(dropped[0]);
            }
            try { input.files = dt.files; } catch (e2) { return; }
            var ev; try { ev = new Event('change', { bubbles: true }); } catch (e3) { ev = document.createEvent('Event'); ev.initEvent('change', true, true); }
            input.dispatchEvent(ev);
        });

        render();
    }

    function init() {
        addStyles();
        var inputs = document.querySelectorAll('input[type=file]');
        for (var i = 0; i < inputs.length; i++) enhance(inputs[i]);
    }

    // Picks up file boxes added later: modals opened on demand, partial page updates.
    if (window.MutationObserver) {
        var timer = null;
        new MutationObserver(function () { clearTimeout(timer); timer = setTimeout(init, 150); })
            .observe(document.documentElement, { childList: true, subtree: true });
    }

    window.AttachBox = { init: init, enhance: enhance };
    if (document.readyState === 'loading') document.addEventListener('DOMContentLoaded', init); else init();
})();
