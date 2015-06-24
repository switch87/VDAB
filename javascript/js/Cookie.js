/**
 * Created by net04 on 23/06/2015.
 */
function setCookie(name, value, days) {
    var decay = "";
    if (days) {
        var today = new Date();
        var decayDate = new Date(today.getTime() + days * 24 * 60 * 60 * 1000);
        decay = decayDate.toUTCString();
    }
    document.cookie = name + "=" + value + ";expires=" + decay;
}

function getCookie(name) {
    var search = name + "=";
    if (document.cookie.length > 0) {
        var begin = document.cookie.indexOf(search);
        if (begin != -1) {
            begin += search.length;
            var end = document.cookie.indexOf(";", begin);
            if (end == -1) {
                end = document.cookie.length;
            }
            return document.cookie.substring(begin, end);
        }
    }
}

function clearCookie(name) {
    // remove cookie
    setCookie(name, "", -1)
}