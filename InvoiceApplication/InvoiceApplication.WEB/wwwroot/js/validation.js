
function validateIdLocatie(input) {
    if (Number.isInteger(input) && input > 0) {
        console.log("idloc valid");
        return true;
    } else {
        console.log("idloc NOT valid");
        return false;
    }
}

function validateInvoiceNumber(input) {
    console.log("SN valid reached");
    if (input.match(/^[a-zA-Z]{1,2} \d{6}$/)) {
        console.log("invoice n match");
        return true;
    } else {
        console.log("invoice num NOT match");
        return false;
    }
}

function validateInvoiceDate(input){
    console.log("date validation reached" + input);
    let year = parseInt(input.split('-')[0]);
    if (year < 1950 || year > new Date().getFullYear()) {
        return false;
    }
    let month = parseInt(input.split('-')[1]);
    if (month < 1 || month > 12) {
        return false;
    }
    let day = parseInt(input.split('-')[2]);
    // more detailed validation required
    if (day < 1 || day > 31) {
        return false;
    }
    console.log("invoice date match");
    return true;
}

function validateCustomerName(input){
    if (input !== "...") {
        return true;
    } else {
        return false;
    }
}

export { validateIdLocatie, validateInvoiceNumber, validateInvoiceDate, validateCustomerName };