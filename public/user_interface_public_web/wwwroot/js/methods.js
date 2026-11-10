function ShowMessage(message) {
    alert(message);
}

function BrowserConsoleWrite(message) {
    console.log(message);
}

function BrowserConsoleError(message) {
    console.error(message);
}

function ModalClose() {
    document.body.classList.remove("modal-open");
    document.body.style = "";
    document.querySelectorAll('.modal-backdrop')[0].remove();
}

function SaveStringToFile(stringText, fileName) {
    var element = document.createElement('a');
    element.setAttribute('href', 'data:text/plain;charset=utf-8,' + encodeURIComponent(stringText));
    element.setAttribute('download', fileName);
    element.style.display = 'none';
    document.body.appendChild(element);
    element.click();
    document.body.removeChild(element);
}


function ShowModalWindow(linkId) {
    var element = document.getElementById(linkId);
    element.click();
}


function ShowError(id, message) {
    var element = document.getElementById(id);
    element.setCustomValidity(message);
    element.reportValidity();
}

function CloseModalWindow(linkId) {
    var element = document.getElementById(linkId);
    element.click();
}

function NavigateTo(url) {
    window.location.href = url;
}


function SavePDFToFile(pdf, fileName) {
    var element = document.createElement('a');
    element.setAttribute('href', "data:application/pdf;base64, " + pdf);
    element.setAttribute('download', fileName);
    element.style.display = 'none';
    document.body.appendChild(element);
    element.click();
    document.body.removeChild(element);
}

function post(url, data) {
    return fetch(url, {
        credentials: 'same-origin',  // параметр определяющий передвать ли разные сессионные данные вместе с запросом
        method: 'POST',
        mode: 'no-cors',
        //cert:	certificate,// метод POST
        body: data,  // тип запрашиаемого документа
        headers: new Headers({
            'Content-Type': 'application/xml'
        }),
    })
        .then(response => response.text()) // возвращаем промис
}

function AddStyle() {
    var elem = document.getElementById('html');
    elem.style.cssText = 'width: 100%; overflow: scroll !important; overflow-x: hidden !important; background: #F7F9F9;';
}

window.downloadFileFromStream = async (fileName, contentStreamReference) => {
    const arrayBuffer = await contentStreamReference.arrayBuffer();
    const blob = new Blob([arrayBuffer]);
    const url = URL.createObjectURL(blob);
    const anchorElement = document.createElement("a");

    anchorElement.href = url;
    anchorElement.download = fileName ?? "";
    anchorElement.click();
    anchorElement.remove();
    URL.revokeObjectURL(url);
}

function GetUserAgent() {
    var userAgent = navigator.userAgent;
    if (navigator.userAgent.search(/Safari/) > 0) { userAgent = 'Safari' };
    if (navigator.userAgent.search(/Firefox/) > 0) { userAgent = 'MozillaFirefox' };
    if (navigator.userAgent.search(/MSIE/) > 0 || navigator.userAgent.search(/NET CLR /) > 0) { userAgent = 'Internet Explorer' };
    if (navigator.userAgent.search(/Chrome/) > 0) { userAgent = 'Google Chrome' };
    if (navigator.userAgent.search(/GOST/) > 0) { userAgent = 'Chromium GOST' };
    if (navigator.userAgent.search(/YaBrowser/) > 0) { userAgent = 'Яндекс браузер' };
    if (navigator.userAgent.search(/OPR/) > 0) { userAgent = 'Opera' };
    if (navigator.userAgent.search(/Konqueror/) > 0) { userAgent = 'Konqueror' };
    if (navigator.userAgent.search(/Iceweasel/) > 0) { userAgent = 'Debian Iceweasel' };
    if (navigator.userAgent.search(/SeaMonkey/) > 0) { userAgent = 'SeaMonkey' };
    if (navigator.userAgent.search(/Edg/) > 0) { userAgent = 'Microsoft Edge' };
    return userAgent;
};
