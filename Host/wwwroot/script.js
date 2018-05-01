var inputData = [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0];
var dataToSend = {
    "ownHeroId": 0,
    "allyHeroIds": [],
    "enemyHeroIds": [],
    "isRadiant": true,
    "steamId": ""
}
$(document).ready(function() {
    for (var i = 0; i < heros.length; i++) {
        var newElement = $('<div/>');
        newElement.attr('id', heros[i].id);
        $('#hero-container').append(newElement);
        newElement.addClass('hero_image');
        $('<img/>')
            .attr('src', 'hero_images\\' + heros[i].image)
            .attr('title', heros[i].localized_name)
            .appendTo(newElement);
    }
});

$(document).click(function(event) {
    if ($(event.target).hasClass('input_image')) {
        $('.selected').removeClass('selected');
        $(event.target).addClass('selected');
    }
    if ($(event.target).parent().hasClass('hero_image')) {
        var id = $($('.selected')[0]).attr('id');
        var inPosition = id.substring(2);
        var heroId = $(event.target).parent().attr('id');
        inputData.splice(inPosition, 1, parseInt(heroId));
        $('#' + id).css('background-image', 'url(' + 'hero_images/' + getImageById(parseInt(heroId)) + ')');
    }
    if ($(event.target).hasClass('sides')) {
        $('.side_selected').removeClass('side_selected');
        $(event.target).addClass('side_selected');
        if ($(event.target).attr('id') === 'radiant') {
            inputData[10] = 0;
        } else {
            inputData[10] = 1;
        }
    }
    console.log(inputData);
});

function getImageById(id) {
    for (var i = 0; i < heros.length; i++)
        if (heros[i].id == id)
            return heros[i].image;
}

function submit() {
    dataToSend.ownHeroId = inputData[0];
    dataToSend.allyHeroIds = inputData.slice(1, 5);
    dataToSend.enemyHeroIds = inputData.slice(5, 10);
    dataToSend.isRadiant = inputData[10] == 0 ? true : false;
    dataToSend.steamId = $('#steam_id_input').val();
    $.ajax({
        url: "api/predict",
        type: "POST",
        data: JSON.stringify(dataToSend),
        contentType: "application/json; charset=utf-8",
        success: function(data) {
            $('#result').text(data);
        }
    });
}