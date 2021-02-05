
function validateIdLocatie(input) {
    if (Number.isInteger(input) && input >= 0) {
        return true;
    } else {
        return false;
    }
}

function validateInvoiceNumber(input) {
    if (input.match(/^[a-zA-Z]{1,2} \d{6}$/)) {
        return true;
    } else {
        return false;
    }
}

function validateInvoiceDate(input){
    let year = parseInt(input.split('-')[0]);
    if (year < 1950 || year > new Date().getFullYear()) {
        return false;
    }
    let month = parseInt(input.split('-')[1]);
    if (month < 1 || month > 12) {
        return false;
    }
    let day = parseInt(input.split('-')[2]);
    // TODO: more detailed validation - Feb in leap years ++
    if (day < 1 || day > 31) {
        return false;
    }
    return true;
}

function validateCustomerName(input){
    if (input !== "...") {
        return true;
    } else {
        return false;
    }
}

function validateNumeProdus(numeProdus) {
    if (numeProdus !== "") {
        return true;
    } else {
        return false;
    }
};

function validateCantitate(cantitate) {
    if (cantitate > 0) {
        return true;
    } else {
        return false;
    }
};

function validatePretUnitar(pretUnitar) {
    if (pretUnitar > 0) {
        return true;
    } else {
        return false;
    }
};

function validateValoare(valoare) {
    if (valoare > 0) {
        return true;
    } else {
        return false;
    }
};

export {
    validateIdLocatie, validateInvoiceNumber, validateInvoiceDate, validateCustomerName,
    validateNumeProdus, validateCantitate, validatePretUnitar, validateValoare
};