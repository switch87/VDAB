function DisplayImage(eLink, eImg) {
    console.log(eLink.href);
    eImg.src = eLink.href;

    var sInfo = eLink.getAttribute('title');
    var eInfo = document.getElementById('info');
    if (eInfo) {
        eInfo.innerHTML = sInfo
    }
    else {
        eInfo = document.createElement('p');
        eInfo.id = "info";
        eInfo.innerHTML = sInfo;
        eImg.parentNode.insertBefore(eInfo, eImg.parentNode.firstChild);
    }
}
window.onload = function () {
    var eImg = document.getElementById('placeholder');
    var eLinks = document.querySelectorAll('aside a');
    console.log('sidebarLinks %s', eLinks.length);

    for (var i = 0; i < eLinks.length; i++) {
        eLinks[i].addEventListener('click', function (e) {
            e.preventDefault();
            DisplayImage(this, eImg);
        });
        eLinks[i].addEventListener('mouseover', function (e) {
            DisplayImage(this, eImg);
        });
    }
};