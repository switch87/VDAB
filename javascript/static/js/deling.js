function DelenMaar(number, number2) {
    var returnval = "";
    if (number > number2) return (number / number2);
    return (number2 / number);

}

window.onload = function () {

    //=============variabelen=======

    var eOutput = document.getElementById('output');
    var eKnop = document.getElementById('deKnop');
    var eGetal1 = document.getElementById('getal1');
    var eGetal2 = document.getElementById('getal2');

    //=============event handlers===========

    eKnop.onclick = function () {
        var nGetal1 = eGetal1.value;
        var nGetal2 = eGetal2.value;
        if (nGetal1 == "" || isNaN(nGetal1) ||
            nGetal2 == "" || isNaN(nGetal2)) {
            alert(' Deze functie werkt enkel met getallen');
        }
        else {
            eOutput.innerHTML = DelenMaar(parseInt(nGetal1), parseInt(nGetal2))
        }
    }

}//einde window.onload
