function setModalDraggableAndResizable() {
    $('.modal-content').resizable({
        minHeight: 300,
        minWidth: 300
    });
    $('.modal-dialog').draggable();
}

function printArea(className) {
    $(className).printThis({
        importCSS: true,        // Import the existing CSS
        importStyle: true,      // Import the existing <style> tags
        loadCSS: [
            "css/bootstrap/bootstrap.min.css",
            "css/app.css",
            "assets/css/style.css",
            "assets/font-awesome/css/font-awesome.min.css",
            "css/Custom.css"
        ],                       // Add additional CSS files if needed
        printContainer: true,   // Print the selected container
        pageTitle: "Print Document" // Title of the print document
    });
}

function downloadPDF() {
    const element = document.getElementById('billSection');
    html2pdf().from(element).set({
        margin: 1,
        filename: 'reservation_invoice.pdf',
        image: { type: 'jpeg', quality: 0.98 },
        html2canvas: { scale: 2 },
        jsPDF: { unit: 'in', format: 'letter', orientation: 'portrait' }
    }).save();
}
