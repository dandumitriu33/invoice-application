import { addNewDetails } from "./utils.js";

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