/**
 * Created by net04 on 24/06/2015.
 */
var eButton = document.querySelector('#goKnop');
eButton.addEventListener('click', evaluate);

function evaluate() {
    /* evaluate if a student passed or not */
    console.log('fn evaluate');

    var eMath = document.getElementById('wiskunde');
    var eBookKeeping = document.getElementById('boekhouden');
    var eInformatics = document.getElementById('informatica');

    var nMath = parseInt(eMath.value);
    var nBook = parseInt(eBookKeeping.value);
    var nInfr = parseInt(eInformatics.value);

    var nTotal = nMath + nBook + nInfr;
    var nAvg = nTotal / 3;

    console.log("Total: " + nTotal);

    // the evaluation
    var eOutput = document.querySelector('#output');
    var sMessage = "";
    if ((nMath>=6 && nBook+nInfr>=12) || nInfr==10) {
        sMessage = "U bent geslaagd";
        eOutput.style.backgroundColor = "#CFC";
        if (nAvg>=7) {
            sMessage += " met onderscheiding";
        }
        else {
            sMessage += " met voldoening";
        }
    }
    else {
        sMessage = "U bent NIET geslaagd";
        eOutput.style.backgroundColor = "red";
    }
    console.log(sMessage);

    // output to div
    eOutput.innerHTML = sMessage;
}