

function showOffices() {
	var html = "";

	jQuery.ajax({
		url: 'http://localhost:49739/Admin/GetOfficePanel',
		contentType: 'application/json; charset=utf-8',
		method: 'GET',
		success: function (data) {
			var res = JSON.parse(data);
			res.forEach(
				elem => html +=
					"<tr><td>" +
					elem.City +
					"</td><td>" +
					elem.Street +
					"</td><td>" +
					elem.Building +
					"</td></tr>"

			);
		},
		complete: function () {
			document.getElementById("officetbody").innerHTML = html;
		}
	})
}

function addOffice(event) {

	event.preventDefault();
	//var data = new FormData();
	//data.append('City', document.getElementById('city').value)
	//data.append('Street', document.getElementById('street').value)
	//data.append('Building', document.getElementById('building').value)

	var data = {
		'City': document.getElementById('city').value,
		'Street': document.getElementById('street').value,
		'Building': document.getElementById('building').value
	}

	jQuery.ajax({
		url: 'http://localhost:49739/Offices/AjaxAddOffice',
		contentType: "application/json",
		processData: false,
		dataType: 'json',
		method: 'POST',
		crossDomain: true,
		data: JSON.stringify(data),
		success: () => {
			window.alert("The record was successfully added to the database")
		},
		error: () => {
			window.alert("An error occurred when adding to the database")
		},
	});

	return true;


}