// JavaScript Document
// JS bestand voor About pagina

var lijst = ['roger', 'evelyn', 'hilde', 'jan'];


$(function () {
    $('tbody tr:odd').addClass('oneven');
    $('tbody tr:even').addClass('even');

    $('a[href^="http"]').on('click', function () {
        alert('U staat op het punt de pagina te verlaten');
    });

    /*$('<a href="#about"title="terug nr boven">terug nr boven</a>')
     .insertBefore('h2, h3, h4, h5, h6');*/
    $('<a href="#about" title="terug nr boven">terug nr boven</a>').insertBefore(':header:gt(1)').button({icons: {secondary: 'ui-icon-circle-triangle-n'}});

    /*var $uul = $('<ul>');
     $.each(lijst, function(n, value){
     $('<li>').text(value).appendTo($uul);
     })
     $('#team').after($uul);*/


// versie vr JSONgegevens
    var $container = $('<div id="teamboks">');
    var $divrechts = $('<div id="teamgegevens">');
    var $keuzelijst = $('<select id="teamkeuzelijst">');
    var strDeOptions = '<option value="">--- het team ---</option>';
    $.each(lijst, function (n, value) {
        strDeOptions += '<option>' + value + '</option>';
    });
    $keuzelijst.html(strDeOptions);
    $container.append($keuzelijst).prepend($divrechts);
    $('#team').after($container);

    //Maak de inhoudsopgave
    var root = $('article')[0];
    var $list = $('<ol>');
    $('#toc').empty().append(walkTree(root,$list,enterNode,exitNode));


});//einde doc.ready

var arrKoppen = ["h1","h2","h3","h4","h5","h6"];
var arrSections = ["article","section","aside","nav"];
var getal = 1;

var checkNode = function(node){
// controleert of deze node in aanmerking komt voor de inhoudsopgave
    // enkel als elementNode, in de lijst sectionElms en geen no-toc
    var strNotoc = "no-toc";
    return (node.nodeType==1 &&arrSections.indexOf(node.tagName.toLowerCase())>=0 &&node.className.indexOf(strNotoc)==-1)
};

var enterNode = function(node,$list) {
//bouwt $list op bij het binnengaan van een node
    if(checkNode(node))
    {
        var $nieuw = $('<li>').attr("tabindex",getal.toString());
        var $a = $('<a>').attr({
            "href" :"#" + getal.toString(),
            "id" :"o" + getal.toString()
        });
        node.setAttribute("id",getal.toString());
        getal++;
        $a.text(zoekKoppen(node));
        $nieuw.append($a);
        if($list[0].tagName=="LI"){
            var $nieuweLijst = $('<ol>').append($nieuw);
            $list.append($nieuweLijst);
            $list = $nieuw;
        }
        else{
            $list.append($nieuw);
            $list = $nieuw;
        }
    }
    return $list;
};

var exitNode = function(node,$list){
//bij het verlaten van de node
    if(checkNode(node)){
        if($list[0].tagName=="OL") {$list = $list.parent()}
        $list = $list.parent();
    }
    return $list;
};

var zoekKoppen = function(node)
{
    var $node = $(node);
    var koptekst = "";
//zoek de hoogste kop, return zijn tekst
    $.each(arrKoppen,function(i,v){
        var $kop = $(v,$node);
        if($kop.length > 0) {
            koptekst = $kop.first().text();
            return false;
        }
    });
    return koptekst;
};


var walkTree = function (root, $list, enter, exit) {
    var node = root;
    start: while (node) {

        $list = enter(node, $list);
        if (node.firstChild) {
            node = node.firstChild;
            continue;
        }
        while (node) {
            $list = exit(node, $list);
            if (node.nextSibling) {
                node = node.nextSibling;
                continue start;
            }
            if (node == root)
                node = null;
            else
                node = node.parentNode;
        }
    }
    return $list;
};
