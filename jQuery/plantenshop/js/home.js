/**
 * Created by net04 on 14/07/2015.
 */
$(function(){
    var ikoontjes = {
        header: "ui-icon-circle-arrow-e",
        headerSelected: "ui-icon-circle-arrow-s"
    }
    $('#keuzes').accordion({
        active:1,
        icons: ikoontjes,
        heightStyle:"content"
    });
});//einde doc ready