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

function smartSearch(req) {
	if (req.length == 0) {
		document.getElementById("livesearch").innerHTML = "";
		document.getElementById("livesearch").style.border = "0px";
		return;
	}

	var html = "";

	jQuery.ajax({
		url: 'http://localhost:49739/Home/SmartSearch',
		contentType: 'application/json; charset=utf-8',
		method: 'GET',
		data: req,
		success: function (data) {
			var res = JSON.parse(data);
			res.forEach(
				elem => html += "<a href='http://localhost:49739/Cars/CarPage/" +
					elem.CarId +
					"'>" +
					elem.Mark +
					" " +
					elem.Year +
					"</a></br>"
			);
		},
		complete: function () {
			document.getElementById("livesearch").innerHTML = html;
			document.getElementById("livesearch").style.border = "1px solid #A5ACB2";
		}
	})
}

function smartSearch1(req) {
	var url = 'http://localhost:49739/Home/SmartSearch?' + req
	console.log(req, url)
	if (req.length == 0) {
		document.getElementById("livesearch").innerHTML = "";
		document.getElementById("livesearch").style.border = "0px";
		return;
	}

	var html = "";

	var request = new XMLHttpRequest();

	request.open(
		"GET",
		url
	)
	request.send()

	request.onload = function () {
		if (request.status != 200) {
			alert("При загрузке проищошла ошибка")
		}
		else {
			var res = JSON.parse(request.responseText);
			res.forEach(
				elem => html += "<a href='http://localhost:49739/Cars/CarPage/" +
					elem.CarId +
					"'>" +
					elem.Mark +
					" " +
					elem.Year +
					"</a></br>"
			);
		}
	}

	request.onloadend = function () {
		document.getElementById("livesearch").innerHTML = html;
		document.getElementById("livesearch").style.border = "1px solid #A5ACB2";
	}
}