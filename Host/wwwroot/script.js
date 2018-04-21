populateSelect();
var side;
var allyHeros[];
var ownHero;
var enemyHeros[];


function setSide(s) {
    side = s.options[s.selectedIndex].text;
}
function _submitButton() {

}
function populateSelect() {

    var ele = document.getElementsByClassName('sel');
    for (var j = 0; j < ele.length; j++) {
    for (var i = 0; i < heroes.length; i++) {
        // POPULATE SELECT ELEMENT WITH JSON.
        ele[j].innerHTML = ele[j].innerHTML +
            '<option value="' + heroes[i]['id'] + '">' + heroes[i]['localized_name'] + '</option>';
    }
    }
}


function setOwn(n) {
    ownHero = n.value;
}
function setAlly(n) {
    allyHeros.push(n.value);
}
function setEnemy(n) {
    enemyHeros.push(n.value);
}

function show(ele) {
    // GET THE SELECTED VALUE FROM <select> ELEMENT AND SHOW IT.
    var msg = document.getElementById('msg');

    //msg.innerHTML = 'Selected Bird: <b>' + ele.options[ele.selectedIndex].text + '</b> </br>' +
    //    'ID: <b>' + ele.value + '</b>';
}