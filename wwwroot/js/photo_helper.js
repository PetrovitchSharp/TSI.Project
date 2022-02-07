function onImageUpload() {
	if (document.getElementById('imageData')
		&& document.getElementById('imageData').files
		&& document.getElementById('imageData').files[0].name !== "") {
		document.getElementById("imageDataName").value
			= "...\\" + document.getElementById('imageData').files[0].name;
	}
}