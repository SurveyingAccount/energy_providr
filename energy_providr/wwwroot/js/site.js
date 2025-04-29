// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

// Function to navigate to a general page by passing the page name
function goToPage(pageName) {
    window.location.href = `/${pageName}`; // Redirects to the specified page
}

// Function to navigate to the single blog page with a specific blog ID
function goToBlog(blogId) {
    window.location.href = `/info/${blogId}`; // Navigate to clean URL
}

// Wait for the DOM to load before attaching event listeners
document.addEventListener("DOMContentLoaded", function () {

    // Select all elements with the class "page-btn" (for general page navigation)
    document.querySelectorAll('.page-btn').forEach(button => {
        button.addEventListener('click', function () {
            const pageName = this.getAttribute('data-page'); // Get the page name from the "data-page" attribute
            if (pageName) {
                goToPage(pageName); // Call the function to navigate to the page
            }
        });
    });

    // Select all elements with the class "blog-btn" (for blog post navigation)
    document.querySelectorAll('.blog-btn').forEach(button => {
        button.addEventListener('click', function () {
            const blogId = this.getAttribute('data-id'); // Get the blog ID from the "data-id" attribute
            if (blogId) {
                goToBlog(blogId); // Call the function to navigate to the blog details page
            }
        });
    });

    // Ensure we only call these functions when the elements are loaded
    const bookingNavBtn = document.querySelector('.booking-nav-btn');

    // Function to load the booking system content
    function loadBookingSystem() {
        const bookingContainer = document.getElementById("bookingContainer");
        bookingContainer.style.visibility = "visible"; // Show the booking container
        updateMonthDisplay(); // Ensure current month is displayed
        generateBookingDays(); // Generate booking days immediately when loading the system
    }

    // Event listener for the Booking link in the Navbar
    if (bookingNavBtn) {
        bookingNavBtn.addEventListener('click', function (e) {
            e.preventDefault(); // Prevent default link behavior
            loadBookingSystem(); // Function to dynamically load the booking system content
        });
    }

    // Month and Day generation logic
    let currentDate = new Date();
    const monthDisplay = document.getElementById("monthDisplay");
    const prevMonthBtn = document.getElementById("prevMonthBtn");
    const nextMonthBtn = document.getElementById("nextMonthBtn");

    // Function to update the month display
    function updateMonthDisplay() {
        if (monthDisplay) {
            monthDisplay.textContent = currentDate.toLocaleString("default", { month: "long", year: "numeric" });
        }
    }

    // Function to generate the booking days
    function generateBookingDays() {
        const gridContainer = document.getElementById("bookingGrid");
        if (gridContainer) {
            gridContainer.innerHTML = ""; // Clear previous days

            let tempDate = new Date(currentDate.getFullYear(), currentDate.getMonth(), 1); // First day of the current month
            let lastDay = new Date(tempDate.getFullYear(), tempDate.getMonth() + 1, 0).getDate(); // Last day of the month

            for (let i = 1; i <= lastDay; i++) {
                let date = new Date(tempDate.getFullYear(), tempDate.getMonth(), i);
                let dateString = date.toDateString();

                let dayDiv = document.createElement("div");
                dayDiv.classList.add("day");
                dayDiv.textContent = dateString;
                dayDiv.addEventListener("click", () => showAvailableTimes(date));

                gridContainer.appendChild(dayDiv);
            }
        }
    }

    // Function to show available times for the selected date
    function showAvailableTimes(date) {
        const timesContainer = document.getElementById("timesContainer");
        const timeSlotsDiv = document.getElementById("timeSlots");

        if (timesContainer) {
            timesContainer.style.visibility = "visible";
            timeSlotsDiv.innerHTML = ""; // Clear previous slots

            let startTime = 9;
            let slotsPerDay = 4;

            for (let i = 0; i < slotsPerDay; i++) {
                let slotTime = startTime + i;
                let timeString = `${slotTime}:00 - ${slotTime + 1}:00`;

                let slotDiv = document.createElement("div");
                slotDiv.classList.add("slot");
                slotDiv.textContent = timeString;
                slotDiv.addEventListener("click", () => alert(`You booked: ${date.toDateString()} at ${timeString}`));

                timeSlotsDiv.appendChild(slotDiv);
            }
        }
    }

    // Navigation buttons for months
    if (prevMonthBtn) {
        prevMonthBtn.addEventListener("click", () => {
            currentDate.setMonth(currentDate.getMonth() - 1); // Move to previous month
            updateMonthDisplay();
            generateBookingDays();
        });
    }

    if (nextMonthBtn) {
        nextMonthBtn.addEventListener("click", () => {
            currentDate.setMonth(currentDate.getMonth() + 1); // Move to next month
            updateMonthDisplay();
            generateBookingDays();
        });
    }

    // Initialize booking system display immediately after DOM content is loaded
    loadBookingSystem(); // Generate current month and days immediately when the page loads
});


// Get elements for accessibility options
const fontSizeSlider = document.getElementById("fontSizeSlider");
const toggleContrast = document.getElementById("toggleContrast");
const resetFontSize = document.getElementById("resetFontSize");

// Default font size (the slider will start at 16px)
let currentFontSize = 16;

// Update font size when the slider value changes
fontSizeSlider.addEventListener("input", function () {
    currentFontSize = fontSizeSlider.value; // Get the slider value
    document.querySelectorAll("body, body *").forEach(function (element) {
        element.style.fontSize = currentFontSize + "px";
    });

    // Optional: Save user preference in localStorage
    localStorage.setItem("fontSize", currentFontSize + "px");
});

// Toggle high contrast mode
toggleContrast.addEventListener("click", function () {
    document.body.classList.toggle("high-contrast");
});

// Reset font size to the default value (16px)
resetFontSize.addEventListener("click", function () {
    currentFontSize = 16; // Reset the font size to 16px
    fontSizeSlider.value = currentFontSize; // Update the slider position
    document.querySelectorAll("body, body *").forEach(function (element) {
        element.style.fontSize = currentFontSize + "px";
    });

    // Save the reset font size in localStorage
    localStorage.setItem("fontSize", currentFontSize + "px");
});

// Optional: Remember the user's preferences using localStorage
document.addEventListener("DOMContentLoaded", function () {
    // Check if the user has previously set high contrast
    if (localStorage.getItem("highContrast") === "true") {
        document.body.classList.add("high-contrast");
    }

    // Check if the user has previously set a custom font size
    const savedFontSize = localStorage.getItem("fontSize");
    if (savedFontSize) {
        // Apply saved font size globally
        document.querySelectorAll("body, body *").forEach(function (element) {
            element.style.fontSize = savedFontSize;
        });
        currentFontSize = parseInt(savedFontSize); // Update current font size
        fontSizeSlider.value = currentFontSize;  // Set the slider to the saved value
    }
});



