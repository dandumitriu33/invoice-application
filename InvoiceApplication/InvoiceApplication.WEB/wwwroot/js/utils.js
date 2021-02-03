
async function updateInvoice() {
    let idLocatie = $("#idLocatie").text().trim();
    let invoiceSerial = $("#invoiceSerial").text().trim();
    let invoiceNumber = $("#invoiceNumber").text().trim();
    let invoiceDate = $("#invoiceDate").text().trim();
    let customerName = $("#customerName").text().trim();
    console.log("utils id locatie: " + idLocatie + " Serial: " + invoiceSerial +
        " inv num: " + invoiceNumber + " inv date: " + invoiceDate +
        " c name: " + customerName);
}

async function addNewDetails(idFactura, idLocatie, numeProdus, cantitate, pretUnitar, valoare) {
    console.log("idFactura " + idFactura + " idLocatie " + idLocatie + " nume: " + numeProdus + " cant: " + cantitate + " pretUnit: " + pretUnitar + " valoare: " + valoare);

    let data = {
        "IdDetaliiFactura": 0,
        "IdLocatie": parseInt(idLocatie),
        "IdFactura": parseInt(idFactura),
        "NumeProdus": numeProdus,
        "Cantitate": parseFloat(cantitate),
        "PretUnitar": parseFloat(pretUnitar),
        "Valoare": parseFloat(valoare)
    };

    let URL = `https://localhost:44317/api/invoices/add-invoice-details`;

    var obj = JSON.stringify(data);
    console.log("obj" + obj);
    await $.ajax({
        type: "POST",
        url: URL,
        data: obj,
        contentType: "application/json; charset=utf-8",
        crossDomain: true,
        success: function () {
            console.log("Details added successfully.");
        },
        error: function (jqXHR, status) {
            console.log(jqXHR);
            console.log('fail' + status.code);
        }
    });
    location.reload(true);


}

export { updateInvoice, addNewDetails };