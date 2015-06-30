var aLanguages = [
    [
        ["Toon alle screenshots", "Verberg alle screenshots"],
        ["Toon dit screenshot", "Verberg dit screenshot"]
    ],
    [
        ["Montrez toutes captures d'�crans", "Cachez toutes captures d'�crans"],
        ["Montrez cette capture d'�cran", "Cachez cette capture d'�cran"]
    ]
]

var bToonAlle = true;											//global, alle schermen worden getoond/niet, true = begintoestand
var nLanguage = 0;											// global, taalkeuze uit aLanguages


window.onload = function () {

    var eKnop = document.getElementById('hoofdknop');
    var eScreens = document.querySelectorAll('img.screenshot');	//verzameling van alle screen figuren
    //console.log(eScreens.length);

    //eventhandler hoofdknop
    eKnop.addEventListener('click', function () {
        var self = this;
        toggleAlleFiguren(self, eScreens)
    });


    //maak knoppen aan voor elke figuur
    var nScreens = eScreens.length;
    for (var i = 0; i < nScreens; i++) {

        var eFig = eScreens[i];
        var eButton = document.createElement('button');
        eButton.innerHTML = aLanguages[nLanguage][1][1];
        eButton.addEventListener('click', toggleFiguur);
        eFig.parentNode.appendChild(eButton);
    }
}

//===================================================

function toggleFiguur() {
    /*
     toggle, 	toont of verbergt een individuele 'screenshot'-figuur
     this = da button
     */

    var eScreen = getFiguur(this);
    var sDisplay = eScreen.style.display;

    console.log(eScreen.nodeName, sDisplay);

    if (!sDisplay || sDisplay == "" || sDisplay == "block") {			//style.display is een inline property: die is afwezig in het begin: testen

        //figuur is nu getoond en wordt verborgen
        eScreen.style.display = "none";
        this.innerHTML = aLanguages[nLanguage][1][0];
    }
    else {
        //figuur is verborgen en wordt getoond
        eScreen.style.display = "block";
        this.innerHTML = aLanguages[nLanguage][1][1];
    }

}

//===================================================

function toggleAlleFiguren(eHoofdKnop, eFiguren) {
    /*
     toont of verbergt alle 'screenshot'-figuren gebaseerd op de var boolean 'schermen' init=false
     returnt de tegengestelde waarde van 'toonAlle'
     @elm	de hoofdknop
     @eFiguren	de collectie screenshots

     return void, maar wisselt de global bToonAlle
     */

    var nFiguren = eFiguren.length;
    //console.log(nFiguren)

    if (bToonAlle === false) {
        //screens zijn nu verborgen en worden getoond
        for (var i = 0; i < nFiguren; i++) {
            eFiguren[i].style.display = 'block'; 					//toon ze
            var eKnop = getKnop(eFiguren[i]);
            eKnop.innerHTML = aLanguages[nLanguage][1][1];
        }
        eHoofdKnop.innerHTML = aLanguages[nLanguage][0][1];
    }
    else {
        //screens zijn nu getoond en worden verborgen
        for (var i = 0; i < nFiguren; i++) {
            eFiguren[i].style.display = 'none';						//verberg ze
            var eKnop = getKnop(eFiguren[i]);
            eKnop.innerHTML = aLanguages[nLanguage][1][0];
        }
        eHoofdKnop.innerHTML = aLanguages[nLanguage][0][0];
    }

    bToonAlle = !bToonAlle;										//wissel boolean
}
//===================================================
function getKnop(eScreen) {
    //return de knop bij de figuur
    return eScreen.parentNode.querySelector('button');
}
//===================================================
function getFiguur(eKnop) {
    //return de figuur bij de knop
    return eKnop.parentNode.querySelector('img.screenshot');
}