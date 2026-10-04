"""Rebuild the Edit / Insert item templates of a ListView page into a clean two-column form.
usage: python rebuild_forms.py <page.aspx> <colspan>
Every control is carried over unchanged (checked before writing); only the surrounding markup is rebuilt."""
import re, sys, collections

fn = sys.argv[1]
colspans = [int(x) for x in sys.argv[2].split(',')]
colspan = colspans[0]
import json
OPTS = json.load(open(sys.argv[3], encoding='utf-8')) if len(sys.argv) > 3 else {}
CAPTIONS = OPTS.get('captions', {})
DROP = set(OPTS.get('drop', []))
raw = open(fn, 'rb').read()
bom = raw.startswith(b'\xef\xbb\xbf')
s = raw.decode('utf-8-sig').replace('\r\n', '\n')

CTRL = re.compile(r'<asp:(?P<tag>HiddenField|TextBox|DropDownList|ListBox|CheckBox|RadioButton|RadioButtonList|CheckBoxList|\w*Validator|LinkButton|ImageButton|Button|Label|FileUpload|ValidationSummary)\b(?:<%.*?%>|[^>])*?(?:/>|>.*?</asp:(?P=tag)>)', re.S)
LABEL_TD = re.compile(r'<td\b[^>]*>\s*(?:<asp:Label\b[^>]*>)?\s*([A-Za-z][^<>]*?)\s*(?:</asp:Label>)?\s*</td>', re.S)
TOKEN = re.compile(r'(?P<ctrl>' + CTRL.pattern + r')|(?P<label>' + LABEL_TD.pattern + r')', re.S)


def norm(c):
    return re.sub(r'\s+', ' ', c).strip()


def rebuild(kind, body, colspan):
    body_nc = re.sub(r'<%--.*?--%>', '', body, flags=re.S)
    hidden, rows, cur, actions = [], [], None, []
    inner = re.search(r'<table\b[^>]*>(.*)</table>', body_nc, re.S)
    if inner is None:
        class _Whole:
            def __init__(self, t):
                self.t = t
            def group(self, n):
                return self.t
            def start(self):
                return 0
        inner = _Whole(body_nc)
    head = body_nc[:inner.start()]
    hidden +=[m.group(0) for m in CTRL.finditer(head) if m.group('tag') == 'HiddenField']
    summaries = [m.group(0) for m in CTRL.finditer(head) if m.group('tag') == 'ValidationSummary']
    for m in TOKEN.finditer(inner.group(1)):
        if m.group('ctrl'):
            tag = m.group(2) if False else re.match(r'<asp:(\w+)', m.group('ctrl')).group(1)
            c = m.group('ctrl')
            _id = re.search(r'ID="(\w+)"', c)
            if _id and _id.group(1) in DROP:
                continue
            if tag == 'HiddenField':
                hidden.append(c)
            elif tag in ('LinkButton', 'ImageButton', 'Button'):
                actions.append(c)
            elif tag == 'Label':
                if cur is None or re.search(r'ErrorLabel|err', c, re.I):
                    actions.append(c)
                else:
                    cur[1].append(c)
            else:
                _cid = _id.group(1) if _id else ''
                if _cid in CAPTIONS and tag not in ('RequiredFieldValidator', 'CompareValidator', 'CustomValidator', 'RangeValidator'):
                    cur = [CAPTIONS[_cid], []]
                    rows.append(cur)
                if cur is None:
                    cur = ['', []]
                    rows.append(cur)
                cur[1].append(c)
        else:
            text = re.sub(r':$', '', re.sub(r'<[^>]+>', '', m.group('label')).strip()).strip()
            if text.lower() == 'action':
                cur = None
                continue
            cur = [text, []]
            rows.append(cur)
    rows = [r for r in rows if r[1]]
    # a validator belongs to the row of the control it checks
    for r in rows:
        for c in list(r[1]):
            if re.match(r'<asp:\w*Validator', c):
                cv = re.search(r'ControlToValidate="(\w+)"', c)
                if not cv:
                    continue
                for r2 in rows:
                    if r2 is not r and any(re.search(r'ID="%s"' % cv.group(1), x) for x in r2[1]):
                        r[1].remove(c)
                        r2[1].append(c)
                        break
    for r in rows:
        if not r[0]:
            first = re.search(r'ID="(\w+)"', r[1][0])
            r[0] = CAPTIONS.get(first.group(1) if first else '', '')
    out_rows = ''
    for label, ctls in rows:
        cells = '\n                        '.join(norm(c) if 'ListItem' not in c else c.strip() for c in ctls)
        out_rows += '                <tr>\n                    <td class="table-data">%s</td>\n                    <td>\n                        %s\n                    </td>\n                </tr>\n' % (label, cells)
    btns = ''
    cancel = [a for a in actions if 'cancelImageButton' in a]
    save = [a for a in actions if 'saveImageButton' in a]
    other = [a for a in actions if a not in cancel and a not in save]
    for a in cancel + save + other:
        btns += '                        ' + norm(a) + '\n'
    act = '                <tr>\n                    <td colspan="2">\n%s                    </td>\n                </tr>\n' % btns
    summ_row = ''.join('            <tr>\n                <td colspan="%d">\n                    %s\n                </td>\n            </tr>\n' % (colspan, norm(x)) for x in summaries)
    hid = ''.join('                ' + norm(h) + '\n' for h in hidden)
    new = ('<%sItemTemplate>\n' % kind) + summ_row + ('            <tr>\n                <td colspan="%d">\n%s                <table class="table table-condensed table-data">\n%s%s                </table>\n                </td>\n            </tr>\n        </%sItemTemplate>' % (colspan, hid, out_rows, act, kind))
    return new


before = collections.Counter(norm(m.group(0)) for m in CTRL.finditer(re.sub(r'<%--.*?--%>', '', s, flags=re.S)))
pos = len(s)
for m in reversed(list(re.finditer(r'<(Edit|Insert)ItemTemplate>(.*?)</\1ItemTemplate>', s, re.S))):
    lv = len(re.findall(r'<asp:ListView', s[:m.start()])) - 1
    cs = colspans[min(max(lv, 0), len(colspans) - 1)]
    colspan = cs
    s = s[:m.start()] + rebuild(m.group(1), m.group(2), cs) + s[m.end():]
summ = iter(colspans)
def _sum(m):
    try: c = next(summ)
    except StopIteration: c = colspans[-1]
    return m.group(1) + '<td colspan="%d">' % c + m.group(2)
s = re.sub(r'(<tr>\s*)<td colspan="\d+">(\s*<asp:ValidationSummary)', _sum, s)
after = collections.Counter(norm(m.group(0)) for m in CTRL.finditer(re.sub(r'<%--.*?--%>', '', s, flags=re.S)))

# controls must be identical apart from whitespace (ListItem children keep their own layout)
def key(c):
    return re.sub(r'\s+', '', c)
b = collections.Counter(key(k) for k in before.elements())
a = collections.Counter(key(k) for k in after.elements())
lost, added = b - a, a - b
# plain text Labels without an ID only served as the row captions; they became the caption cells
lost = collections.Counter({k: v for k, v in lost.items() if not any('ID="%s"' % d in k for d in DROP) and not re.match(r'<asp:Labelrunat="server">[^<]*</asp:Label>$', k)})
if lost or added:
    print('ABORT: control mismatch')
    for k in lost: print('  lost ', k[:140])
    for k in added: print('  added', k[:140])
    sys.exit(1)
open(fn, 'wb').write((b'\xef\xbb\xbf' if bom else b'') + s.replace('\n', '\r\n').encode('utf-8'))
print('ok', fn, sum(after.values()), 'controls preserved')
