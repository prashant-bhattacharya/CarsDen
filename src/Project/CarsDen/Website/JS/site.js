'use strict';

/**
* navbar toggle
*/

const overlay = document.querySelector("[data-overlay]");
const navbar = document.querySelector("[data-navbar]");
const navToggleBtn = document.querySelector("[data-nav-toggle-btn]");
const navbarLinks = document.querySelectorAll("[data-nav-link]");

const navToggleFunc = function () {
    navToggleBtn.classList.toggle("active");
    navbar.classList.toggle("active");
    overlay.classList.toggle("active");
}

navToggleBtn.addEventListener("click", navToggleFunc);
overlay.addEventListener("click", navToggleFunc);

for (let i = 0; i < navbarLinks.length; i++) {
    navbarLinks[i].addEventListener("click", navToggleFunc);
}


/**
* header active on scroll
*/

const header = document.querySelector("[data-header]");

window.addEventListener("scroll", function () {
    window.scrollY >= 10 ? header.classList.add("active")
        : header.classList.remove("active");
});

/**
* Booking Form Total Price Calculation
*/

document.addEventListener("DOMContentLoaded", function () {
    const carModelSelect = document.getElementById("car-model");
    const startDateInput = document.getElementById("start-date");
    const endDateInput = document.getElementById("end-date");
    const totalPriceInput = document.getElementById("total-price");

    window.calculateTotalPrice = function () {
        const carModelOption = carModelSelect.options[carModelSelect.selectedIndex];
        const rentPerDay = parseFloat(carModelOption.getAttribute("data-rent")) || 0;
        const startDate = new Date(startDateInput.value);
        const endDate = new Date(endDateInput.value);
        const oneDay = 24 * 60 * 60 * 1000;
        const diffDays = Math.round((endDate - startDate) / oneDay) + 1;

        if (!isNaN(diffDays) && diffDays > 0) {
            totalPriceInput.value = (diffDays * rentPerDay).toFixed(2);
        } else {
            totalPriceInput.value = "";
        }
    };

    carModelSelect.addEventListener("change", calculateTotalPrice);
    startDateInput.addEventListener("change", calculateTotalPrice);
    endDateInput.addEventListener("change", calculateTotalPrice);
});