function manageseat(id) {
    var modal = document.getElementById('myModal');
    // Get the button that opens the modal
    var btn = document.getElementById(id);
    var seatnumber = document.getElementById("seatnumber");
    var modal = document.getElementById('myModal');
    modal.style.display = "block";
    seatnumber.innerText = id;

}