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
    if ($(event.target).hasClass('hero_image')) {
    
    }
});