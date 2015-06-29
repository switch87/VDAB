window.onload= function(){
    var sensors=[
        'document.images',
        'document.layers',
        'document.all',
        'document.getElementById',
        'document.querySelector',
        'document.styleSheets',
        'document.createElement',
        'document.createNodeIterator',
        'document.implementation.createDocument',
        'window.walkTheDog',
        'window.focus',
        'window.ActiveXObject',
        'window.XMLHttpRequest',
        'window.localStorage',
        '[].push',
        '[].filter',
        'Object.prototype',
        'navigator.geolocation',
        'document.documentElement.classList']
    var eTable=document.getElementById('senseTable');
    sensors.forEach (function(sensor){
        console.log(sensor+' '+eval(sensor));
        var eRow= document.createElement('tr');
        var eSensor = document.createElement('td');
        eSensor.innerHTML = sensor;
        var eBool = document.createElement('td');
        if (eval(sensor)){
            eBool.style.color='green';
            eBool.innerHTML = 'True';
        }
        else{
            eBool.style.color='red';
            eBool.innerHTML = 'False';
        }

        eRow.appendChild(eSensor);
        eRow.appendChild(eBool);
        eTable.appendChild(eRow);
    });
}