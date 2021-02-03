import { updateInvoice, addNewDetails } from "./utils.js";

// INVOICE HEADER SECTION
setClickEvents();

function setClickEvents() {
    $("#idLocatie").unbind('click');
    $("#idLocatie").click(function () {
        console.log("IdLocatie clicked");
        locationSwitchToInput();
    });
    $("#invoiceSerial").unbind('click');
    $("#invoiceSerial").click(function () {
        console.log("inv seri click");
        invoiceSerialSwitchToInput();
    });
    $("#invoiceNumber").unbind('click');
    $("#invoiceNumber").click(function () {
        console.log("inv num click");
        invoiceNumberSwitchToInput();
    });
    $("#invoiceDate").unbind('click');
    $("#invoiceDate").click(function () {
        console.log("inv date click");
        invoiceDateSwitchToInput();
    });
}

function invoiceDateSwitchToInput() {
    console.log("date invo switch to input reached");
    let currentDate = $("#invoiceDate").text().trim();
    console.log("c date: " + currentDate);
    let dateInputElement = `
                            <span>
                                <input id="newDateInput" type="text" class="form-control" value="${currentDate}"/>
                            </span>
                            `;
    $("#invoiceDate").remove();
    $("#invoiceDateContainer").append(dateInputElement);
    $("#newDateInput").focus();
    $("#newDateInput").change(function () {
        let newDate = $("#newDateInput").val();
        let dateElement = `<span id="invoiceDate">${newDate}</span>`;
        $("#newDateInput").remove();
        $("#invoiceDateContainer").append(dateElement);
        updateInvoice();
        setClickEvents();
    });
    $("#newDateInput").blur(function () {
        let newDate = $("#newDateInput").val();
        let dateElement = `<span id="invoiceDate">${newDate}</span>`;
        $("#newDateInput").remove();
        $("#invoiceDateContainer").append(dateElement);
        updateInvoice();
        setClickEvents();
    })
}

function invoiceNumberSwitchToInput() {
    console.log("num invo switch to input reached");
    let currentNumber = $("#invoiceNumber").text().trim();
    console.log("c num: " + currentNumber);
    let numberInputElement = `
                            <span>
                                <input id="newNumberInput" type="text" class="form-control" value="${currentNumber}"/>
                            </span>
                            `;
    $("#invoiceNumber").remove();
    $("#invoiceNumberContainer").append(numberInputElement);
    $("#newNumberInput").focus();
    $("#newNumberInput").change(function () {
        let newNumber = $("#newNumberInput").val();
        let numberElement = `<span id="invoiceNumber">${newNumber}</span>`;
        $("#newNumberInput").remove();
        $("#invoiceNumberContainer").append(numberElement);
        updateInvoice();
        setClickEvents();
    });
    $("#newNumberInput").blur(function () {
        let newNumber = $("#newNumberInput").val();
        let numberElement = `<span id="invoiceNumber">${newNumber}</span>`;
        $("#newNumberInput").remove();
        $("#invoiceNumberContainer").append(numberElement);
        updateInvoice();
        setClickEvents();
    })
}

function invoiceSerialSwitchToInput() {
    console.log("serial switch to input reached");
    let currentSerial = $("#invoiceSerial").text().trim();
    console.log("c ser: " + currentSerial);
    let serialInputElement = `
                            <span>
                                <input id="newSerialInput" type="text" class="form-control" value="${currentSerial}"/>
                            </span>
                            `;
    $("#invoiceSerial").remove();
    $("#invoiceSerialContainer").append(serialInputElement);
    $("#newSerialInput").focus();
    $("#newSerialInput").change(function () {
        let newSerial = $("#newSerialInput").val();
        let serialElement = `<span id="invoiceSerial">${newSerial}</span>`;
        $("#newSerialInput").remove();
        $("#invoiceSerialContainer").append(serialElement);
        updateInvoice();
        setClickEvents();
    });
    $("#newSerialInput").blur(function () {
        let newSerial = $("#newSerialInput").val();
        let serialElement = `<span id="invoiceSerial">${newSerial}</span>`;
        $("#newSerialInput").remove();
        $("#invoiceSerialContainer").append(serialElement);
        updateInvoice();
        setClickEvents();
    })
}

function locationSwitchToInput() {
    console.log("switch to input reached");
    let currentLocation = parseInt($("#idLocatie").text().trim());

    let locationInputElement = `
                                <span>
                                    <input id="newLocationInput" type="text" class="form-control" value="${currentLocation}"/>
                                </span>
                                `;
    $("#idLocatie").remove();
    $("#locationContainer").append(locationInputElement);
    $("#newLocationInput").focus();
    $("#newLocationInput").change(function () {
        let newLocationId = $("#newLocationInput").val();
        let locationElement = `
                                <span id="idLocatie">${newLocationId}</span>
                                `;
        $("#newLocationInput").remove();
        $("#locationContainer").append(locationElement);
        updateInvoice();
        setClickEvents();
    });
    $("#newLocationInput").blur(function () {
        let newLocationId = $("#newLocationInput").val();
        let locationElement = `
                                <span id="idLocatie">${newLocationId}</span>
                                `;
        $("#newLocationInput").remove();
        $("#locationContainer").append(locationElement);
        updateInvoice();
        setClickEvents();
    })
};

// DETAILS SECTION
$("#addDetailsButton").click(function () {
    console.log("add details clicked");
    populateAddDetailsForm();
});

function populateAddDetailsForm() {
    console.log("populating details form");
    let element = `
                    <div class="row">
                    <div class="col-1 border text-center">
                        
                    </div>
                    <div class="col-5 border text-center">
                        <input id="newDetailNumeProdus" type="text" class="form-control"/>
                    </div>
                    <div class="col-1 border text-center">
                        <p>buc</p>
                    </div>
                    <div class="col-1 border text-center">
                        <input id="newDetailCantitate" type="number" class="form-control"/>
                    </div>
                    <div class="col-1 border text-center">
                        <input id="newDetailPretUnitar" type="number" class="form-control"/>
                    </div>
                    <div class="col-1 border text-center">
                        <input id="newDetailValoare" type="number" class="form-control"/>
                    </div>
                    <div class="col-1 border text-center">
                        <p>19.00</p>
                    </div>
                    <div class="col-1 border text-center">
                        
                    </div>
                    `;
    $("#detailsContainer").append(element);
    let elementSaveCancel = `
                            <div class="row" id="saveCancelRow">
                                <div class="col-1 border text-center">
                                </div>
                                <div class="col-5 border text-center">
                                    <button id="saveDetails" class="btn btn-outline-primary btn-sm m-1"> Save </button>
                                    <button id="cancelSaveDetails" class="btn btn-outline-primary btn-sm m-1"> Cancel </button>
                                </div>
                                <div class="col-1 border text-center">
                                </div>
                                <div class="col-1 border text-center">
                                </div>
                                <div class="col-1 border text-center">
                                </div>
                                <div class="col-1 border text-center">
                                </div>
                                <div class="col-1 border text-center">
                                </div>
                                <div class="col-1 border text-center">
                                </div>
                            </div>
                            `;
    $("#detailsContainer").append(elementSaveCancel);
    $("#addDetailsButtonRow").remove();
    $("#saveDetails").click(function () {
        console.log("Save Details Clicked");
        
        let idFactura = $("#idFactura").text();
        let idLocatie = $("#idLocatie").text();
        let numeProdus = $("#newDetailNumeProdus").val();
        let cantitate = $("#newDetailCantitate").val();
        let pretUnitar = $("#newDetailPretUnitar").val();
        let valoare = $("#newDetailValoare").val();
        addNewDetails(idFactura, idLocatie, numeProdus, cantitate, pretUnitar, valoare);

        
    })
    $("#cancelSaveDetails").click(function () {
        console.log("Cancel Save Details Clicked");
    })
};