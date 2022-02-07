function openModal(){
    var modal = document.getElementById("imgModal");
    var img = document.getElementById("myImg");
    var modalImg = document.getElementById("modalImg");
    var captionText = document.getElementById("caption");
    modal.style.display = "block";
    modalImg.src = img.src;
    captionText.innerHTML = img.alt;
}



function closeModal() {
    var modal = document.getElementById("imgModal");
    modal.style.display = "none";
}