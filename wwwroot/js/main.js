console.log("main.js is running!");

// Eventlyssnare på menyn
document.addEventListener("DOMContentLoaded", () => {
    const hamburger = document.querySelector(".hamburger");
    const menu = document.querySelector(".menu");

    // Hantera klick på menyn
    hamburger.addEventListener("click", (event) => {
        event.stopPropagation();
        menu.classList.toggle("show");
    });

    // Stäng menyn om man klickar utanför
    document.addEventListener("click", (event) => {
        if (!menu.contains(event.target) && menu.classList.contains("show")) {
            menu.classList.remove("show");
        }
    });
});



