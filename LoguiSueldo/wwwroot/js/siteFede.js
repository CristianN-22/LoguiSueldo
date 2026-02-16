document.addEventListener("DOMContentLoaded", function () {
    // Toggle del sidebar
    var sidebarToggle = document.getElementById("sidebar-toggle");
    if (sidebarToggle) {
        sidebarToggle.onclick = function () {
            document.body.classList.toggle("sidebar-collapse");
        };
    }

    // Inicialización de Datepickers
    var datepickers = document.querySelectorAll(".datepicker");
    datepickers.forEach(function (picker) {
        if (typeof $(picker).datepicker === "function") {
            $(picker).datepicker({
                autoclose: true,
                format: "dd/mm/yyyy"
            });
        }
    });

    // Inicialización de tablas dinámicas (DataTables)
    var tables = document.querySelectorAll(".datatable");
    tables.forEach(function (table) {
        if (typeof $(table).DataTable === "function") {
            $(table).DataTable();
        }
    });

    // Bloquer boton PDF
    var pdfBtn = document.getElementById("pdf-button");
    if (pdfBtn) {
        pdfBtn.onclick = function () { i(); }
    }
});


