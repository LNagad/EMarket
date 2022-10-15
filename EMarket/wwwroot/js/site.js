// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.



var inputBox = document.querySelector(".mySearchInput");
var div = document.querySelector(".search-div");


if (inputBox) {
    inputBox.addEventListener('focusout', function () {
        div.classList.remove("k")
    });
    inputBox.addEventListener('focus', function () {
    
            div.classList.add("k")
    
    });
}

