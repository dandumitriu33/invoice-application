
async function updateDetail(detailId) {
    console.log("reached update detail in utils --- detailId: " + detailId);
    let idFactura = parseInt($("#idFactura").text().trim());
    let idLocatie = parseInt($("#idLocatie").text().trim());
    let newProductName = $("#" + detailId + "-newProductName").val();
    let newQuantity = parseFloat($("#" + detailId + "-newQuantity").val());
    let newUnitPrice = parseFloat($("#" + detailId + "-newUnitPrice").val());
    let newValue = parseFloat($("#" + detailId + "-newValue").val());
    console.log("npn: " + newProductName + " Q: " + newQuantity + " P: " + newUnitPrice + " V: " + newValue);

    let data = {
        "IdDetaliiFactura": parseInt(detailId.split('-')[0]),
        "IdLocatie": idLocatie,
        "IdFactura": idFactura,
        "NumeProdus": newProductName,
        "Cantitate": newQuantity,
        "PretUnitar": newUnitPrice,
        "Valoare": newValue
    }
    console.log(data);
    let URL = `https://localhost:44317/api/invoices/update-invoice-detail`;

    var obj = JSON.stringify(data);
    console.log("obj" + obj);
    await $.ajax({
        type: "PUT",
        url: URL,
        data: obj,
        contentType: "application/json; charset=utf-8",
        crossDomain: true,
        success: function () {
            console.log("Invoice detail updated successfully.");
        },
        error: function (jqXHR, status) {
            console.log(jqXHR);
            console.log('fail' + status.code);
        }
    });

    location.reload(true);
}

async function deleteDetail(detailId) {
    console.log("reached delete detail in utils");
    let newProductName = $("#" + detailId + "-newProductName").val();
    console.log("deleting npn: " + newProductName);
    location.reload(true);
}

async function updateInvoice() {
    console.log("Entered UPDATE");
    let idFactura = parseInt($("#idFactura").text().trim());
    let idLocatie = parseInt($("#idLocatie").text().trim());
    //let invoiceSerial = $("#invoiceSerial").text().trim();
    //let invoiceNumber = $("#invoiceNumber").text().trim();
    let invoiceNumber = $("#invoiceSerial").text().trim() + " " + $("#invoiceNumber").text().trim();
    let unprocessedInvoiceDate = $("#invoiceDate").text().trim();
    let invoiceDate = `${unprocessedInvoiceDate.split('.')[2]}-${unprocessedInvoiceDate.split('.')[1]}-${unprocessedInvoiceDate.split('.')[0]}T00:00:00`;
    let customerName = $("#customerName").text().trim();
    if (invoiceNumber.trim().length > 7 && invoiceDate !== "0001-01-01T00:00:00" && (customerName === "...") == false) {
        let data = {
            "IdFactura": idFactura,
            "IdLocatie": idLocatie,
            "NumarFactura": invoiceNumber,
            "DataFactura": invoiceDate,
            "NumeClient": customerName
        }
        console.log(data);
        let URL = `https://localhost:44317/api/invoices/update-invoice`;

        var obj = JSON.stringify(data);
        console.log("obj" + obj);
        await $.ajax({
            type: "PUT",
            url: URL,
            data: obj,
            contentType: "application/json; charset=utf-8",
            crossDomain: true,
            success: function () {
                console.log("Invoice updated successfully.");
                $("#detailsErrorMessage").text("");
            },
            error: function (jqXHR, status) {
                console.log(jqXHR);
                console.log('fail' + status.code);
            }
        });        
    } else {
        $("#detailsErrorMessage").text("Cannot update. Please check the location ID, the invoice serial and number, the invoice date and the customer name.");
    }
    
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

async function addNewInvoice() {
    let invoiceId = 0;
    let locationId = parseInt($("#idLocatie").text());
    let invoiceNumber = $("#invoiceSerial").text().trim() + " " + $("#invoiceNumber").text().trim();
    let year = $("#invoiceDate").text().trim().split('.')[2];
    let month = $("#invoiceDate").text().trim().split('.')[1];
    let day = $("#invoiceDate").text().trim().split('.')[0];
    let invoiceDate = `${year}-${month}-${day}T00:00:00`;
    let customerName = $("#customerName").text().trim();

    if (locationId > 0 && invoiceNumber.trim().length > 7 && invoiceDate !== "0001-01-01T00:00:00" && customerName !== "...") {
        let data = {
            "IdFactura": invoiceId,
            "IdLocatie": locationId,
            "NumarFactura": invoiceNumber,
            "DataFactura": invoiceDate,
            "NumeClient": customerName
        };

        let URL = `https://localhost:44317/api/invoices/add-invoice`;

        var obj = JSON.stringify(data);
        console.log("obj" + obj);
        await $.ajax({
            type: "POST",
            url: URL,
            data: obj,
            contentType: "application/json; charset=utf-8",
            crossDomain: true,
            //success: function () {
            //    console.log("Invoice added successfully.");
            //    //window.location.replace(``);
            //    console.log(response);
            //},
            success(response) {
                console.log("IDFACT RESP >>>>>>" + response.idFactura);
                window.location.replace(`https://localhost:44363/editinvoice/${response.idFactura}`);
            },
            error: function (jqXHR, status) {
                console.log(jqXHR);
                console.log('fail' + status.code);
            }
        });
    //location.reload(true);
    //window.location.replace(``)
    } else {
        $("#detailsErrorMessage").text("Cannot add new invoice. Please check all fields.");
    }

    

    
}

export { addNewInvoice, deleteDetail, updateDetail, updateInvoice, addNewDetails };