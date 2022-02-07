function changeFilters() {
	content = document.getElementById("filtBtn").innerHTML;
	if (content == "Свернуть") {
		document.getElementById("filtersBlock").hidden = true;
		document.getElementById("filtBtn").innerHTML = "Развернуть";
		refreshFilters();

	} else {
		document.getElementById("filtersBlock").hidden = false;
		document.getElementById("filtBtn").innerHTML = "Свернуть";
		refreshFilters();
	}

}

function changeInput(obj, id) {
	document.getElementById(id).value = obj.value;
}

function refreshFilters() {
	document.getElementById("state").selectedIndex = 2;
	document.getElementById("bodytype").selectedIndex = 4;
	document.getElementById("transmission").selectedIndex = 2;
	document.getElementById("engine").selectedIndex = 2;
	document.getElementById("drive").selectedIndex = 3;

	document.getElementById("minprice").value = 0;
	document.getElementById("maxprice").value = 1e7;
	document.getElementById("priceOutput1").value = 0;
	document.getElementById("priceOutput2").value = 1e7;

	document.getElementById("minpower").value = 0;
	document.getElementById("maxpower").value = 300;
	document.getElementById("powerOutput1").value = 0;
	document.getElementById("powerOutput2").value = 300;

	document.getElementById("minmileage").value = 0;
	document.getElementById("maxmileage").value = 1e6;
	document.getElementById("mileageOutput1").value = 0;
	document.getElementById("mileageOutput2").value = 1e6;

	document.getElementById("mincons").value = 0;
	document.getElementById("maxcons").value = 25;
	document.getElementById("consOutput1").value = 0;
	document.getElementById("consOutput2").value = 25;

	document.getElementById("minyear").value = 1950;
	document.getElementById("maxyear").value = 2022;
	document.getElementById("yearOutput1").value = 1950;
	document.getElementById("yearOutput2").value = 2022;
}