function kinderGeldBerekenaar(nMaandloon, nKinderen) {
    nMinFortune = nKinderen * 25.0;
    nFortune = nMinFortune;
    if (nKinderen >= 3) {
        nFortune += (nKinderen - 2) * 12.5;
        if (nKinderen >= 5) {
            nFortune += (nKinderen - 4) * 7.5;
        }
    }
    if (nMaandloon <= 500) {
        return nFortune * 1.25;
    }
    else if (nMaandloon >= 2000) {
        nFortune *= 0.55;
        if (nFortune < nMinFortune) return nMinFortune;
    }
    return nFortune;
}
window.onload = function () {
    var eOutput = document.getElementById('output');
    var eButton = document.getElementById('deKnop');
    var eKinderen = document.getElementById('kinderen');
    var eMaandloon = document.getElementById('maandloon');

    eButton.onclick = function () {
        var nKinderen = eKinderen.value;
        var nMaandloon = eMaandloon.value;
        if (nKinderen == "" || isNaN(nKinderen) ||
            nMaandloon == "" || isNaN(nMaandloon)) {
            alert('Zo gaan we niet beginnen hé jongens!');
        }
        else {
            eOutput.innerHTML = '&euro; ' + kinderGeldBerekenaar(parseInt(nMaandloon), parseInt(nKinderen));
        }
    }
}