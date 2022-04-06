// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(document).ready(function () {
    $('.collapse').on('show.bs.collapse', function (e) {
        $('.collapse').collapse("hide")
    })
})

let active = document.querySelectorAll(".accordion-div .accordion.active");
for (let j = 0; j < active.length; j++) {
    active[j].classList.remove("active");
    active[j].nextElementSibling.style.maxHeight = null; //or 0px
}