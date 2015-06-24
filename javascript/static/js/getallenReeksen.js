window.onload = function () {

    //=============variabelen=======

    var eOutput = document.getElementById('output');
    var eKnop = document.getElementById('deKnop');
    var eGetal = document.getElementById('getal');

    //=============event handlers===========

    eKnop.onclick = function () {
        var nGetal = eGetal.value;
        if (nGetal == "" || isNaN(nGetal)) {
            alert(' Deze functie werkt enkel met getallen');
        }
        else {
            eOutput.innerHTML = lussenMaar(parseInt(nGetal))
        }
    }

}//einde window.onload

//=============functies=================

function lussenMaar(n) {
    /* Testfunctie voor iteraties
     @n getal, verplicht, max aantal iteraties
     */
    console.log(n);
    var sTekst = "";
    for (var i = 0; i < n; i++) {
        for (var j = 1; j <= n; j++) {
            sTekst += i * j + "&nbsp;";
        }
        sTekst += "<br>";
    }
    return sTekst;

}