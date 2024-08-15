//function setModalDraggableAndResizable() {
//    $('.modal-content').resizable({
//        minHeight: 300,
//        minWidth: 300
//    });
//    $('.modal-dialog').draggable();
//}

function printPDF(elementId) {
    const { jsPDF } = window.jspdf;

    // Capture the element as canvas
    html2canvas(document.querySelector(`#${elementId}`), { scale: 2 }).then(canvas => {
        const imgData = canvas.toDataURL('image/png');
        const pdf = new jsPDF('p', 'mm', 'a4');

        // Padding values
        const padding = 10; // 10mm padding
        const imgWidth = 210 - 2 * padding; // A4 width minus padding
        const pageHeight = 295 - 2 * padding; // A4 height minus padding
        const imgHeight = (canvas.height * imgWidth) / canvas.width;
        let heightLeft = imgHeight;
        let position = padding; // Start with padding from the top

        // Add first page with padding
        pdf.addImage(imgData, 'PNG', padding, position, imgWidth, imgHeight);
        heightLeft -= pageHeight;

        // Add additional pages with padding
        while (heightLeft >= 0) {
            position = heightLeft - imgHeight + padding;
            pdf.addPage();
            pdf.addImage(imgData, 'PNG', padding, position, imgWidth, imgHeight);
            heightLeft -= pageHeight;
        }

        // Convert the PDF to a Blob
        const pdfBlob = pdf.output('blob');
        const pdfUrl = URL.createObjectURL(pdfBlob);

        // Open the PDF in a new window
        const printWindow = window.open(pdfUrl);
        if (printWindow) {
            printWindow.onload = function () {
                printWindow.print(); // Automatically trigger the print dialog
            };
        } else {
            alert('Popup blocker is preventing the print dialog from opening.');
        }
    });
}

function downloadPDF(elementId, filename = 'document.pdf') {
    const { jsPDF } = window.jspdf;
    const padding = 10; // Padding in mm

    html2canvas(document.querySelector(`#${elementId}`), { scale: 2 }).then(canvas => {
        const imgData = canvas.toDataURL('image/png');
        const pdf = new jsPDF('p', 'mm', 'a4');
        const imgWidth = 210 - 2 * padding; // Adjust width for padding
        const pageHeight = 295 - 2 * padding; // Adjust height for padding
        const imgHeight = (canvas.height * imgWidth) / canvas.width;
        let heightLeft = imgHeight;
        let position = padding; // Start from padding

        // Add initial image
        pdf.addImage(imgData, 'PNG', padding, position, imgWidth, imgHeight);
        heightLeft -= pageHeight;

        // Add additional pages if needed
        while (heightLeft >= 0) {
            position = heightLeft - imgHeight + padding;
            pdf.addPage();
            pdf.addImage(imgData, 'PNG', padding, position, imgWidth, imgHeight);
            heightLeft -= pageHeight;
        }

        // Save the PDF with the specified filename
        pdf.save(filename);
    });
}


