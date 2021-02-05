import { validateIdLocatie, validateInvoiceNumber, validateInvoiceDate, validateCustomerName } from "./validation.js"
import { validateNumeProdus, validateCantitate, validatePretUnitar, validateValoare } from "./validation.js";

async function updateDetail(detailId) {
    let idFactura = parseInt($("#idFactura").text().trim());
    let idLocatie = parseInt($("#idLocatie").text().trim());
    let newProductName = $("#" + detailId + "-newProductName").val();
    let newQuantity = parseFloat($("#" + detailId + "-newQuantity").val());
    let newUnitPrice = parseFloat($("#" + detailId + "-newUnitPrice").val());
    let newValue = parseFloat($("#" + detailId + "-newValue").val());

    if (validateNumeProdus(newProductName) && validateCantitate(newQuantity) && validatePretUnitar(newUnitPrice) && validateValoare(newValue)) {
        $("#detailsErrorMessage").text("Updating detail. Please wait.");
        $("#detailsErrorMessage").append(`<img id="loadingImage" src="../img/loading.gif" alt="Loading animation image."/>`);
        //await new Promise(r => setTimeout(r, 2000));
        let data = {
            "IdDetaliiFactura": parseInt(detailId.split('-')[0]),
            "IdLocatie": idLocatie,
            "IdFactura": idFactura,
            "NumeProdus": newProductName,
            "Cantitate": newQuantity,
            "PretUnitar": newUnitPrice,
            "Valoare": newValue
        }
        let URL = `https://localhost:44317/api/invoices/update-invoice-detail`;

        var obj = JSON.stringify(data);
        await $.ajax({
            type: "PUT",
            url: URL,
            data: obj,
            contentType: "application/json; charset=utf-8",
            crossDomain: true,
            success: function () {
            },
            error: function (jqXHR, status) {
                console.log(jqXHR);
                console.log('fail' + status.code);
            }
        });

        location.reload(true);
    } else {
        let errorMessageDetailValidation = "Detail validation failed. Please check: ";
        if (validateNumeProdus(newProductName) == false) {
            errorMessageDetailValidation += "Nume Produs ";
        };
        if (validateCantitate(newQuantity) == false) {
            errorMessageDetailValidation += "Cantitate ";
        };
        if (validatePretUnitar(newUnitPrice) == false) {
            errorMessageDetailValidation += "Pret Unitar ";
        };
        if (validateValoare(newValue) == false) {
            errorMessageDetailValidation += "Valoare ";
        };
        $("#detailsErrorMessage").text(errorMessageDetailValidation);
    }    
}

async function deleteDetail(detailId) {
    let delIdFactura = parseInt($("#idFactura").text().trim());
    let delIdLocatie = parseInt($("#idLocatie").text().trim());
    let delProductName = $("#" + detailId + "-newProductName").val();
    let delQuantity = parseFloat($("#" + detailId + "-newQuantity").val());
    let delUnitPrice = parseFloat($("#" + detailId + "-newUnitPrice").val());
    let delValue = parseFloat($("#" + detailId + "-newValue").val());

    let data = {
        "IdDetaliiFactura": parseInt(detailId.split('-')[0]),
        "IdLocatie": delIdLocatie,
        "IdFactura": delIdFactura,
        "NumeProdus": delProductName,
        "Cantitate": delQuantity,
        "PretUnitar": delUnitPrice,
        "Valoare": delValue
    }

    let URL = `https://localhost:44317/api/invoices/delete-invoice-detail`;

    var obj = JSON.stringify(data);
    await $.ajax({
        type: "DELETE",
        url: URL,
        data: obj,
        contentType: "application/json; charset=utf-8",
        crossDomain: true,
        success: function () {
        },
        error: function (jqXHR, status) {
            console.log(jqXHR);
            console.log('fail' + status.code);
        }
    });
    location.reload(true);    
}

async function updateInvoice() {
    let idFactura = parseInt($("#idFactura").text().trim());
    let idLocatie = parseInt($("#idLocatie").text().trim());
    let invoiceNumber = $("#invoiceSerial").text().trim() + " " + $("#invoiceNumber").text().trim();
    let unprocessedInvoiceDate = $("#invoiceDate").text().trim();
    let invoiceDate = `${unprocessedInvoiceDate.split('.')[2]}-${unprocessedInvoiceDate.split('.')[1]}-${unprocessedInvoiceDate.split('.')[0]}T00:00:00`;
    let customerName = $("#customerName").text().trim();
    if (validateInvoiceNumber(invoiceNumber) && validateInvoiceDate(invoiceDate) && validateCustomerName(customerName)) {
        $("#detailsErrorMessage").text("Updating invoice. Please wait.");
        $("#detailsErrorMessage").append(`<img id="loadingImage" src="../img/loading.gif" alt="Loading animation image."/>`);
        let data = {
            "IdFactura": idFactura,
            "IdLocatie": idLocatie,
            "NumarFactura": invoiceNumber,
            "DataFactura": invoiceDate,
            "NumeClient": customerName
        }
        let URL = `https://localhost:44317/api/invoices/update-invoice`;

        var obj = JSON.stringify(data);
        await $.ajax({
            type: "PUT",
            url: URL,
            data: obj,
            contentType: "application/json; charset=utf-8",
            crossDomain: true,
            success: function () {
                $("#detailsErrorMessage").text("");
            },
            error: function (jqXHR, status) {
                console.log(jqXHR);
                console.log('fail' + status.code);
            }
        });        
    } else {
        var validationErrorMessage = "Cannot update invoice. Please check: ";
        if (validateInvoiceNumber(invoiceNumber) == false) {
            validationErrorMessage += " Invoice SN";
        }
        if (validateInvoiceDate(invoiceDate) == false) {
            validationErrorMessage += " Invoice Date";
        }
        if (validateCustomerName(customerName) == false) {
            validationErrorMessage += " Customer Name";
        }
        $("#detailsErrorMessage").text(validationErrorMessage);
    };    
}

async function addNewDetails(idFactura, idLocatie, numeProdus, cantitate, pretUnitar, valoare) {
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
    await $.ajax({
        type: "POST",
        url: URL,
        data: obj,
        contentType: "application/json; charset=utf-8",
        crossDomain: true,
        success: function () {
        },
        error: function (jqXHR, status) {
            console.log(jqXHR);
            console.log('fail' + status.code);
        }
    });
    location.reload(true);
}

async function addNewInvoice() {
    let invoiceId = 0;
    let locationId = parseInt($("#idLocatie").text());
    let invoiceNumber = $("#invoiceSerial").text().trim().toUpperCase() + " " + $("#invoiceNumber").text().trim();
    let year = $("#invoiceDate").text().trim().split('.')[2];
    let month = $("#invoiceDate").text().trim().split('.')[1];
    let day = $("#invoiceDate").text().trim().split('.')[0];
    let invoiceDate = `${year}-${month}-${day}T00:00:00`;
    let customerName = $("#customerName").text().trim(); 

    if (validateIdLocatie(locationId) && validateInvoiceNumber(invoiceNumber) && validateInvoiceDate(invoiceDate) && validateCustomerName(customerName)) {
        $("#detailsErrorMessage").text("Creating new invoice. Please wait.");
        $("#detailsErrorMessage").append(`<img id="loadingImage" src="../img/loading.gif" alt="Loading animation image."/>`);
        let data = {
            "IdFactura": invoiceId,
            "IdLocatie": locationId,
            "NumarFactura": invoiceNumber,
            "DataFactura": invoiceDate,
            "NumeClient": customerName
        };
        let URL = `https://localhost:44317/api/invoices/add-invoice`;

        var obj = JSON.stringify(data);
        await $.ajax({
            type: "POST",
            url: URL,
            data: obj,
            contentType: "application/json; charset=utf-8",
            crossDomain: true,
            success(response) {
                window.location.replace(`https://localhost:44363/editinvoice/${response.idFactura}`);
            },
            error: function (jqXHR, status) {
                console.log(jqXHR);
                console.log('fail' + status.code);
            }
        });
    } else {
        var validationErrorMessage = "Cannot add new invoice. Please check: ";
        if (validateIdLocatie(locationId) == false) {
            validationErrorMessage += "Location No";
        }
        if (validateInvoiceNumber(invoiceNumber) == false) {
            validationErrorMessage += " Invoice SN";
        }
        if (validateInvoiceDate(invoiceDate) == false) {
            validationErrorMessage += " Invoice Date";
        }
        if (validateCustomerName(customerName) == false) {
            validationErrorMessage += " Customer Name";
        }
        $("#detailsErrorMessage").text(validationErrorMessage);
    }    
}

export { addNewInvoice, deleteDetail, updateDetail, updateInvoice, addNewDetails };