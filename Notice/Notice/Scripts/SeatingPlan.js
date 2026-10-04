//Drag Drop
function onDragStart(event) {
    event
        .dataTransfer
        .setData('text/plain', event.target.id);

    //event
    //    .currentTarget
    //    .style
    //    .backgroundColor = 'yellow';
}
function onDragOver(event) {
    event.preventDefault();
}
function onDrop(event) {

    const targetid = event.target.id;  //Control on which droped
    const sourceid = event
        .dataTransfer
        .getData('text');

    var targetspanid = "L" + targetid.substr(1);
    var sourcespanid = "L" + sourceid.substr(1);

    var targethiddenid = "H" + targetid.substr(1);
    var sourcehiddenid = "H" + sourceid.substr(1);

    var targetdivid = "S" + targetid.substr(1);
    var sourcedivid = "S" + sourceid.substr(1);

    var targetseatid = targetid.substr(1);
    var sourceseatid = sourceid.substr(1);

    var sourceMemberId = document.getElementById(sourcehiddenid).value.split('-')[0];
    var targetMemberId = document.getElementById(targethiddenid).value.split('-')[0];

    var sourceMemberName = document.getElementById(sourcespanid).innerText;
    var TargetMemberName = document.getElementById(targetspanid).innerText;

    var sourceMemberColor = document.getElementById(sourcehiddenid).value.split('-')[1];
    var targetMemberColor = document.getElementById(targethiddenid).value.split('-')[1];

    $.confirm({
        title: 'Please select option',
        content: '',
        buttons: {
            Swap: function () {
                SaveSeat(sourceseatid, targetseatid, sourceMemberId, targetMemberId, sourceMemberColor, targetMemberColor, "Swap");
                // location.reload();
            },
            Move: function () {
                //alert(sourceseatid);
                //alert(targetseatid);
                //alert(sourceMemberId);
                //alert(targetMemberId);
                SaveSeat(sourceseatid, targetseatid, sourceMemberId, 0, sourceMemberColor, targetMemberColor, "Move");
            },
            Cancel:
                function () {

                },
            //somethingElse: {
            //    text: 'Something else',
            //    btnClass: 'btn-blue',
            //    keys: ['enter', 'shift'],
            //    action: function () {
            //        $.alert('Something else?');
            //    }
            //}
        }
    });




    //var message_alert = $('<p>Choose action?</p>').dialog({
    //    buttons: {
    //        "Swap": function () {

    //            message_alert.dialog('close');
    //        },
    //        "Assign": function () {
    //            SaveSeat(sourceseatid, targetseatid, sourceMemberId, targetMemberId, sourceMemberColor, targetMemberColor, "Assign");
    //            message_alert.dialog('close');
    //        },
    //        "Cancel": function () {
    //            //alert('you clicked on cancel');
    //            message_alert.dialog('close');
    //        }
    //    }
    //});

}


    var menu = document.querySelector(".context-menu");
    var menuState = 0;
    var contextMenuActive = "block";
    // Turns the custom context menu on.
    function toggleMenuOn() {
            if (menuState !== 1) {
        menuState = 1;
    menu.classList.add(contextMenuActive);

                //var id = temp.id.substr(1);
                //document.getElementById('light').style.display = 'block';
                ////$('#myModal2').modal('show');
                //document.getElementById('SeatNumber').innerText = id;
                //document.getElementById('HidSeatNumber').value = id;
                //document.getElementById('MemberNameTxt').value = document.getElementById('L' + id).innerText;
                //var id = document.getElementById('H' + id).value;
                //var arr = id.split("-");
                //document.getElementById('HidMemberId').value = arr[0];
                //document.getElementById('SeatColour').value = arr[1];
                //document.getElementById('SeatColour').style.backgroundColor = temp.style.backgroundColor;
            }
        }
    // Turns the custom context menu off.
    function toggleMenuOff() {
            if (menuState !== 0) {
        menuState = 0;
    menu.classList.remove(contextMenuActive);
            }
        }
    // Get the position of the right-click in window and returns the X and Y coordinates
    function getPosition(e) {
            var posx = 0;
    var posy = 0;

    if (!e) var e = window.event;

    if (e.pageX || e.pageY) {
        posx = e.pageX;
    posy = e.pageY;
            } else if (e.clientX || e.clientY) {
        posx =
        e.clientX +
        document.body.scrollLeft +
        document.documentElement.scrollLeft;
    posy =
    e.clientY + document.body.scrollTop + document.documentElement.scrollTop;
            }

    return {
        x: posx,
    y: posy
            };
        }
    // Position the Context Menu in right position.
    function positionMenu(e) {
        let clickCoords = getPosition(e);
    let clickCoordsX = clickCoords.x;
    let clickCoordsY = clickCoords.y;

    let menuWidth = menu.offsetWidth + 4;
    let menuHeight = menu.offsetHeight + 4;

    let windowWidth = window.innerWidth;
    let windowHeight = window.innerHeight;

    if (windowWidth - clickCoordsX < menuWidth) {
        menu.style.left = windowWidth - menuWidth + "px";
            } else {
        menu.style.left = clickCoordsX + "px";
            }

    if (windowHeight - clickCoordsY < menuHeight) {
        menu.style.top = windowHeight - menuHeight + "px";
            } else {
        menu.style.top = clickCoordsY + "px";
            }
        }
        // Event Listener for window ContextMenu Event - When Right Click is clicked
        //var divelement = document.getElementsByClassName("bdr");
        //document.addEventListener("contextmenu", function (event) {
        //    event.preventDefault();
        //    toggleMenuOn();
        //    positionMenu(event);
        //});

        $(function () {
            $(".bdr").bind("contextmenu", function (event) {
                document.getElementById("HidSeatNumber").value = event.target.id.substr(1);
                //alert(event.target.id);
                event.preventDefault();
                toggleMenuOn();
                positionMenu(event);
            });
        });
        //document.body.addEventListener("click", function (evt) {
        //    toggleMenuOff();
        //});
        // Event Listener for Close Context Menu when outside of menu clicked
        document.addEventListener("click", (e) => {
            var button = e.which || e.button;
            var input = e.which || e.input;
            if (input === 1) { }
            if (button === 1) {
                toggleMenuOff();
            }
        });

    // Close Context Menu on Esc key press
    window.onkeyup = function (e) {
            if (e.keyCode === 27) {
        toggleMenuOff();
            }
        }
    function ShowDetails(temp) {
            var id = temp.id.substr(1);
    document.getElementById('light').style.display = 'block';
    //$('#myModal2').modal('show');
    document.getElementById('SeatNumber').innerText = id;
    document.getElementById('HidSeatNumber').value = id;
    document.getElementById('MemberNameTxt').value = document.getElementById('L' + id).innerText;
    var id = document.getElementById('H' + id).value;
    var arr = id.split("-");
    document.getElementById('HidMemberId').value = arr[0];
    document.getElementById('SeatColour').value = arr[1];
    document.getElementById('SeatColour').style.backgroundColor = temp.style.backgroundColor;
        }
    function showtooltip(temp) {
            var id = temp.id.substr(1);
        }
    function SaveSeat(SourceSeat, TargetSeat, SourceMember, TargetMember, SourceMemberColor, TargetMemberColor, Action) {
        $.ajax({
            type: "POST",
            url: "ManageSittingPlan.aspx/SaveSeat",
            data: '{SourceSeat: "' + SourceSeat + '",TargetSeat: "' + TargetSeat + '",SourceMember: "' + SourceMember + '",TargetMember: "' + TargetMember + '",SourceMemberColor: "' + SourceMemberColor + '",TargetMemberColor: "' + TargetMemberColor + '",Action: "' + Action + '" }',
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {
                location.reload();
            },
            failure: function (response) {
            }
        });
        }
    function GetMemberSeats() {
        $.ajax({
            url: 'ManageSittingPlan.aspx/GetMemberSeats',
            dataType: "json",
            type: "POST",
            contentType: "application/json; charset=utf-8",

            success: function (response) {
                if (response != null && response.d != null) {
                    var data = response;
                    alert(typeof (data)); //it comes out to be string 
                    //we need to parse it to JSON 
                    data = $.parseJSON(data);
                    $(data).each(function (index, seat) {
                        document.getElementById("S" + seat.SeatNumber).style.backgroundColor = seat.SeatColour;
                        document.getElementById("L" + seat.SeatNumber).innerText = seat.MemberUrduName;
                        document.getElementById("H" + seat.SeatNumber).value = seat.SystemUsersId + "-" + seat.SeatColour;

                    });
                }
            },

            error: function (err) {
                alert(err);
            }
        });
        }
    function CloseDetails(e) {
        document.getElementById('light').style.display = 'none';
    e.preventDefault();


        }
    $(function () {
        $("#SeatColour").change(function () {
            this.style.backgroundColor = this.value;
        });
        });

    $(function () {
        $("#ContextSeatColour").change(function () {
            this.style.backgroundColor = this.value;
        });
        });

    $(function () {
        $("[id$=MemberNameTxt2]").autocomplete({
            source: function (request, response) {
                $.ajax({
                    url: '<%=ResolveUrl("~/Service.asmx/GetSeatEmployeeName") %>',
                    data: "{ 'prefix': '" + request.term + "'}",
                    dataType: "json",
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    success: function (data) {
                        response($.map(data.d, function (item) {
                            return {
                                label: item.split('=')[0],
                                val: item.split('=')[1]
                            }
                        }))
                    },
                    error: function (response) {
                        alert(response.responseText);
                    },
                    failure: function (response) {
                        alert(response.responseText);
                    }
                });
            },
            select: function (e, i) {
                $("[id$=HidMemberId]").val(i.item.val);

            },
            minLength: 1
        });
           });
    $(function () {
        $("[id$=MemberNameTxt]").autocomplete({
            source: function (request, response) {
                $.ajax({
                    url: '<%=ResolveUrl("~/Service.asmx/GetSeatEmployeeName") %>',
                    data: "{ 'prefix': '" + request.term + "'}",
                    dataType: "json",
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    success: function (data) {
                        response($.map(data.d, function (item) {
                            return {
                                label: item.split('=')[0],
                                val: item.split('=')[1]
                            }
                        }))
                    },
                    error: function (response) {
                        alert(response.responseText);
                    },
                    failure: function (response) {
                        alert(response.responseText);
                    }
                });
            },
            select: function (e, i) {
                $("[id$=HidMemberId]").val(i.item.val);

            },
            minLength: 1
        });
        });



