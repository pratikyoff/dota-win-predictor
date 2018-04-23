populateSelect();
var isRadiant = true
var allyHeros = [];
var ownHero;
var enemyHeros = [];
var playerId;


function setSide(s) {
    var side = s.options[s.selectedIndex].text;
    if (side === 'Dire') {
        isRadiant = false;
    }
}
//function _submitButton() {

//    playerId = _getPlayerId()

//}
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

$("button").click(function () {
    playerId = _getPlayerId()
    var objToSend = {
        ownHeroId: ownHero,
        allyHeroIds: allyHeros,
        enemyHeroIds: enemyHeros,
        isRadiant: isRadiant,
        steamId: playerId
    };
    $.ajax({
        url: "api/predict",
        type: "POST",
        data: JSON.stringify(objToSend),
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            alert("Data: " + data + "\nStatus: ");
        }
    })
});

function setOwn(n) {
    ownHero = parseFloat(n.value);
}
function setAlly(n) {
    allyHeros.push(parseInt(n.value));
}
function setEnemy(n) {
    enemyHeros.push(parseInt(n.value));
}

function _getPlayerId() {
    return String(document.getElementById('playerId').value);
}

function show(ele) {
    // GET THE SELECTED VALUE FROM <select> ELEMENT AND SHOW IT.
    var msg = document.getElementById('msg');

    //msg.innerHTML = 'Selected Bird: <b>' + ele.options[ele.selectedIndex].text + '</b> </br>' +
    //    'ID: <b>' + ele.value + '</b>';
}