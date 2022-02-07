function changeFilters() {
	content = document.getElementById("filtBtn").innerHTML;
	if (content == "Свернуть") {
		document.getElementById("filters").hidden = true;
		document.getElementById("filtBtn").innerHTML = "Развернуть";
	} else {
		document.getElementById("filters").hidden = false;
		document.getElementById("filtBtn").innerHTML = "Свернуть";
	}

}