import { addNewInvoice, deleteDetail, updateDetail, updateInvoice, addNewDetails } from "./utils.js";
import { validateNumeProdus, validateCantitate, validatePretUnitar, validateValoare } from "./validation.js";

let editDetailActive = false;
let newInvoice = false;
$("#detailsErrorMessage").text("");

// INVOICE HEADER SECTION
setClickEvents();

function setClickEvents() {
    // IdLocatie is a composite primary key and cannot be modified 
    // In order to modify the IdLocatie we have to remove the primary key from it
    // this mechanism only allows us to add IdLocatie only on new invoices
    
    let invoiceId = parseInt($("#idFactura").text());
    if (invoiceId > 0) {
        newInvoice = false;
    } else {
        newInvoice = true;
        $("#idLocatie").unbind('click');
        $("#addressContainer").unbind('click');
        $("#idLocatie").click(function () {
            $("#addressContainer").unbind('click');
            locationSwitchToInput();
        });
        $("#addressContainer").click(function () {
            locationSwitchToInput();
        });
    }
    
    $("#invoiceSerial").unbind('click');
    $("#serialContainerParent").unbind('click');
    $("#invoiceSerial").click(function () {
        $("#serialContainerParent").unbind('click');
        invoiceSerialSwitchToInput();
    });
    $("#serialContainerParent").click(function () {
        invoiceSerialSwitchToInput();
    });

    $("#invoiceNumber").unbind('click');
    $("#numberContainerParent").unbind('click');
    $("#invoiceNumber").click(function () {
        $("#numberContainerParent").unbind('click');
        invoiceNumberSwitchToInput();
    });
    $("#numberContainerParent").click(function () {
        invoiceNumberSwitchToInput();
    });

    $("#invoiceDate").unbind('click');
    $("#dateContainerParent").unbind('click');
    $("#invoiceDate").click(function () {
        $("#dateContainerParent").unbind('click');
        invoiceDateSwitchToInput();
    });
    $("#dateContainerParent").click(function () {
        invoiceDateSwitchToInput();
    });

    $("#customerName").unbind('click');
    $("#customerNameContainerParent").unbind('click');
    $("#customerName").click(function () {
        $("#customerNameContainerParent").unbind('click');
        customerNameSwitchToInput();
    });
    $("#customerNameContainerParent").click(function () {
        customerNameSwitchToInput();
    });
}

function customerNameSwitchToInput() {
    console.log("c name switch to input reached");
    let currentCustomerName = $("#customerName").text().trim();
    console.log("c name: " + currentCustomerName);
    let customerNameInputElement = `
                                    <span>
                                        <input id="newCustomerNameInput" type="text" class="form-control" value="${currentCustomerName}"/>
                                    </span>
                                    `;
    $("#customerName").remove();
    $("#customerNameContainer").append(customerNameInputElement);
    $("#newCustomerNameInput").focus();
    $("#newCustomerNameInput").change(function () {
        let newCustomerName = $("#newCustomerNameInput").val();
        let customerNameElement = `<span id="customerName">${newCustomerName}</span>`;
        $("#newCustomerNameInput").remove();
        $("#customerNameContainer").append(customerNameElement);
        if (newInvoice == true) {
            addNewInvoice();
        } else {
            updateInvoice();
        };        
        setClickEvents();
    });
    $("#newCustomerNameInput").blur(function () {
        let newCustomerName = $("#newCustomerNameInput").val();
        let customerNameElement = `<span id="customerName">${newCustomerName}</span>`;
        $("#newCustomerNameInput").remove();
        $("#customerNameContainer").append(customerNameElement);
        if (newInvoice == true) {
            addNewInvoice();
        } else {
            updateInvoice();
        };
        setClickEvents();
    })
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
        if (newInvoice == true) {
            addNewInvoice();
        } else {
            updateInvoice();
        };
        setClickEvents();
    });
    $("#newDateInput").blur(function () {
        let newDate = $("#newDateInput").val();
        let dateElement = `<span id="invoiceDate">${newDate}</span>`;
        $("#newDateInput").remove();
        $("#invoiceDateContainer").append(dateElement);
        if (newInvoice == true) {
            addNewInvoice();
        } else {
            updateInvoice();
        };
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
        if (newInvoice == true) {
            addNewInvoice();
        } else {
            updateInvoice();
        };
        setClickEvents();
    });
    $("#newNumberInput").blur(function () {
        let newNumber = $("#newNumberInput").val();
        let numberElement = `<span id="invoiceNumber">${newNumber}</span>`;
        $("#newNumberInput").remove();
        $("#invoiceNumberContainer").append(numberElement);
        if (newInvoice == true) {
            addNewInvoice();
        } else {
            updateInvoice();
        };
        setClickEvents();
    })
}

function invoiceSerialSwitchToInput() {
    console.log("serial switch to input reached");
    let currentSerial = $("#invoiceSerial").text().trim().toUpperCase();
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
        let newSerial = $("#newSerialInput").val().toUpperCase();
        let serialElement = `<span id="invoiceSerial">${newSerial}</span>`;
        $("#newSerialInput").remove();
        $("#invoiceSerialContainer").append(serialElement);
        if (newInvoice == true) {
            addNewInvoice();
        } else {
            updateInvoice();
        };
        setClickEvents();
    });
    $("#newSerialInput").blur(function () {
        let newSerial = $("#newSerialInput").val().toUpperCase();
        let serialElement = `<span id="invoiceSerial">${newSerial}</span>`;
        $("#newSerialInput").remove();
        $("#invoiceSerialContainer").append(serialElement);
        if (newInvoice == true) {
            addNewInvoice();
        } else {
            updateInvoice();
        };
        setClickEvents();
    })
}

function locationSwitchToInput() {
    console.log("switch to input reached");
    // replaced by a 0 - leaving ... will display NaN - 0 is a better UI indicator
    let currentLocation = parseInt($("#idLocatie").text().trim());

    let locationInputElement = `
                                <span>
                                    <input id="newLocationInput" type="text" class="form-control" value="0"/>
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
        addNewInvoice();
        setClickEvents();
    });
    $("#newLocationInput").blur(function () {
        let newLocationId = $("#newLocationInput").val();
        let locationElement = `
                                <span id="idLocatie">${newLocationId}</span>
                                `;
        $("#newLocationInput").remove();
        $("#locationContainer").append(locationElement);
        addNewInvoice();
        setClickEvents();
    })
};

// DETAILS SECTION
setClickEventsOnDetails();
setAddDetailsButtonClickEvent();

function setClickEventsOnDetails() {
    var children = $("#detailsContainer").children();
    console.log(children);
    children.unbind('click');
    children.click(function () {
        console.log(this.id);
        let detailId = this.id;
        let tempThis = this;
        //let invoicePosition = $("#" + detailId + "-invoicePosition").text();
        let invoicePosition = this.children[0].textContent.trim();
        let productName = this.children[1].textContent.trim();
        let unitType = this.children[2].textContent.trim();
        let quantity = this.children[3].textContent.trim();
        let unitPrice = this.children[4].textContent.trim();
        let value = this.children[5].textContent.trim();
        let VAT = this.children[6].textContent.trim();
        let VATValue = this.children[7].textContent.trim();
        console.log("ip: " + invoicePosition);
        console.log("pnam: " + productName);
        console.log("U type: " + unitType);
        console.log("qty: " + quantity);
        console.log("u pri: " + unitPrice);
        console.log("val: " + value);
        console.log("VAT: " + VAT);
        console.log("VAT val: " + VATValue);
        let inputElement = `
                            <div class="row" id="${detailId}-detailContainer">
                                <div class="col-1 border text-center">
                                    <p>${invoicePosition} <a id="${detailId}-delete" class="btn btn-outline-danger btn-sm text-danger">Del</a></p>
                                </div>
                                <div class="col-5 border text-center">
                                    <input id="${detailId}-newProductName" type="text" class="form-control" value="${productName}"/>
                                    <button id="${detailId}-save" class="btn btn-outline-success btn-sm m-2"> Save </button>
                                    <button id="${detailId}-cancel" class="btn btn-outline-primary btn-sm m-2"> Cancel </button>
                                </div>
                                <div class="col-1 border text-center">
                                    <p>${unitType}</p>
                                </div>
                                <div class="col-1 border text-center">
                                    <input id="${detailId}-newQuantity" type="text" class="form-control" value="${quantity}"/>
                                </div>
                                <div class="col-1 border text-center">
                                    <input id="${detailId}-newUnitPrice" type="text" class="form-control" value="${unitPrice}"/>
                                </div>
                                <div class="col-1 border text-center">
                                    <input id="${detailId}-newValue" type="text" class="form-control" value="${value}"/>
                                </div>
                                <div class="col-1 border text-center">
                                    <p>${VAT}</p>
                                </div>
                                <div class="col-1 border text-center">
                                    <p>${VATValue}</p>
                                </div>
                            </div>
                            `;
        if (editDetailActive == false) {
            editDetailActive = true;
            $(this).replaceWith(inputElement);
            $("#" + detailId + "-newProductName").focus();
            $("#" + detailId + "-save").click(function () {
                console.log("save edited detail clicked");
                console.log("pre util update detailId: " + detailId.split('-')[0]);
                updateDetail(detailId);
                editDetailActive = false;
            });
            $("#" + detailId + "-cancel").click(function () {
                console.log("cancel edited detail clicked");
                $("#" + detailId + "-detailContainer").replaceWith(tempThis);
                setClickEventsOnDetails();
                editDetailActive = false;
                $("#detailsErrorMessage").text("");
            });
            $("#" + detailId + "-delete").click(function () {
                console.log("delete detail clicked");
                deleteDetail(detailId);
                setClickEventsOnDetails();
                editDetailActive = false;
            });
        } else {
            $("#detailsErrorMessage").text("Only one detail can be edited at a time.");
        }
        
        
    });
};

function setAddDetailsButtonClickEvent() {
    $("#addDetailsButton").unbind('click');
    $("#addDetailsButton").click(function () {
        console.log("add details clicked");
        populateAddDetailsForm();
    });
}


function populateAddDetailsForm() {
    console.log("populating details form");
    let element = `
                    <div class="row" id="saveCancelInputRow">
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

        if (validateNumeProdus(numeProdus) && validateCantitate(cantitate) && validatePretUnitar(pretUnitar) && validateValoare(valoare)) {
            $("#detailsErrorMessage").text("Adding new detail. Please wait.");
            $("#detailsErrorMessage").append(`<img id="loadingImage" src="../img/loading.gif" alt="Loading animation image."/>`);
            addNewDetails(idFactura, idLocatie, numeProdus, cantitate, pretUnitar, valoare);
        } else {
            let errorMessageDetailValidation = "Detail validation failed. Please check: ";
            if (validateNumeProdus(numeProdus) == false) {
                errorMessageDetailValidation += "Nume Produs ";
            };
            if (validateCantitate(cantitate) == false) {
                errorMessageDetailValidation += "Cantitate ";
            };
            if (validatePretUnitar(pretUnitar) == false) {
                errorMessageDetailValidation += "Pret Unitar ";
            };
            if (validateValoare(valoare) == false) {
                errorMessageDetailValidation += "Valoare ";
            };
            $("#detailsErrorMessage").text(errorMessageDetailValidation);
        }
    });
    $("#cancelSaveDetails").click(function () {
        console.log("Cancel Details Clicked");
        let detailsButtonRow = `
                                <div class="row" id="addDetailsButtonRow">
                                    <div class="col-1 border text-center">
                                    </div>
                                    <div class="col-5 border text-center">
                                        <button id="addDetailsButton" class="btn btn-outline-primary btn-sm m-1"> + </button>
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
        $("#saveCancelInputRow").remove();
        $("#saveCancelRow").remove();
        $("#detailsContainer").append(detailsButtonRow);
        setAddDetailsButtonClickEvent();
    });
};