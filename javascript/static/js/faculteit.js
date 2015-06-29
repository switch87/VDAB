function getTheFaculty(nGetal) {
    if (nGetal < 0) return 'Dit lukt niet met een negatief getal!';
    if (nGetal == 0) return 1;
    var nTotaal = 1;
    for (var i = 1; i <= nGetal; i++) {
        nTotaal *= i;
    }
    return nTotaal;
}
window.onload = function () {
    var eGetal = document.getElementById('getal');
    var eButton = document.getElementById('deKnop');
    var eOutput = document.getElementById('output');

    eButton.onclick = function () {
        nGetal = eGetal.value;
        if (nGetal == "" || isNaN(nGetal)) {
            eOutput.innerHTML = 'vul nu maar iets in dat mogelijk is!'
        }

        else eOutput.innerHTML = getTheFaculty(parseInt(nGetal));
    }
};