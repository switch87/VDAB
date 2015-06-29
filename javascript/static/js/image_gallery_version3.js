function DisplayImage(nIndex, eImg) {
    /* wisselt de bron van het src attribuut van de img#beeld
     @ nIndex, een hyperlink element
     @ eImg, plaatshouder img
     @ aModernArt array, global
     */
    aArt = aModernArt[nIndex]; //subarray
    sSource = aArt[0]; //source
    sInfo = aArt[1]; //info
    sName = aArt[2]; //naam
    eImg.src = "static/images/art/" + sSource;
    var eInfo = document.getElementById('info');
    if (eInfo) {
    //wijzig info
        eInfo.innerHTML = sInfo;
    }
    else {
    //maak nieuwe p#info aan
        var eInfo = document.createElement('p');
        eInfo.id = "info";
        eInfo.innerHTML = sInfo;
        eImg.parentNode.insertBefore(eInfo, eImg.parentNode.firstChild);
    }
}
function maakKeuzelijst(a) {
    var nArt = a.length;
    var eSelect = document.createElement('select');
    eSelect.id = "keuzelijst";

    var eOption = document.createElement('option');
    eOption.innerHTML = "Maak een keuze";
    eOption.setAttribute("value", "");
    eSelect.appendChild(eOption);

    for (var i = 0; i < nArt; i++) {
        eOption = document.createElement('option');
        eOption.innerHTML = a[i][2];
        eOption.value = i;
        eSelect.appendChild(eOption);
    }
    return eSelect;
}
window.onload = function () {
    if (typeof aModernArt == "undefined") {
        throw new Error("array aModernArt niet gevonden");
    } else {
        console.log(aModernArt[0][0]);
        var eImg = document.getElementById('placeholder');

        var eKeuzelijst = maakKeuzelijst(aModernArt);
        var eSidebar = document.querySelector('aside');
        eSidebar.appendChild(eKeuzelijst);
        eKeuzelijst.addEventListener("change", function (e) {
            var value = this.value;
            console.log(value);
            if(value!=""&&value!=null){
                DisplayImage(value,eImg);
            }

        })
    }
};