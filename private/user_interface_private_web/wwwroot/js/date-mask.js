window.mask = () => {
	var inputElements = document.querySelectorAll("[data-format]");

	inputElements.forEach(input => {
		var customMask = new IMask(input, {
			mask: input.getAttribute("data-format")
		});
	});
}

function AddStyle(){
	var elem = document.getElementById('html');
	elem.style.cssText = 'width: 100%; overflow: scroll !important; overflow-x: hidden !important; background: #F7F9F9;';
} 