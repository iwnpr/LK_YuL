При формировании файла убирать тег <body> из данного блока:

HTML += 
	'<html><head><title>' +
	Capt + 
	'</title>' +
	document.getElementById('styles').outerHTML + 
	'</head>' + 
	DataText + 
	'</html>';
	w.document.write(HTML);

var listCtrl = w.document.getElementById(listName).firstChild.firstChild.firstChild.firstChild;
if (listCtrl.className == 'list-ctrl') listCtrl.style.display = 'none';