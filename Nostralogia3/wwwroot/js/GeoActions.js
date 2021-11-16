function UpdateCountry() {
    var selCountry = $("#cmbCountries option:selected").val();
    //console.log("UpdateCountry id =" + selCountry);
    $.ajax({
        type: "POST",
        url: "/EventPlace/CountryChangedValue",
        data: { Id: selCountry },
        success: function (data) {            

            UpdateCitiesCmb(data[1]);
            UpdateStatesCmb(data[0]);

            //UpdateLabelAllCities();
        },
        fail: function (e) {
            alert("Country update error");
        }
    });
}
function UpdateStates() {
    var selState = $("#cmbStates option:selected").val();
    console.log("UpdateStates id =" + selState);
    $.ajax({
        type: "POST",
        url: "/EventPlace/StateChangedValue",
        data: { Id: selState },
        datatype: "json",
        success: function (data) {
            console.log("UpdateStates city1 =" + data[0]);
            console.log("UpdateStates city2 =" + data[0].text);
            UpdateCitiesCmb(data);
            //UpdateLabelAllCities();

        }
    });
}
//function UpdateLabelAllCities() {
//    var placename = '';
//    if (selCountry = $("#cmbStates option:selected").val() * 1 == -1) {
//        placename = $("#cmbCountries option:selected").text();
//    }
//    else {
//        placename = $("#cmbStates option:selected").text();
//    }

    
//}

function UpdateStatesCmb(result) {
    var options = $("#cmbStates");
    options.empty();
    options.append(new Option("Select state...", "-1"));
    $.each(result, function () {
        options.append(new Option(this.text, this.value));
    });

}
function UpdateCitiesCmb(result) {
    var options = $("#cmbCities");
    options.empty();
    options.append(new Option("Select city...", "-1"));
    $.each(result, function () {
        options.append(new Option(this.text, this.value));

    });
}