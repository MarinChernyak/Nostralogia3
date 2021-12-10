//           Jan  Feb  Mar  Apr   May Jun  July  Aug  Sep  Oct  Nov
var monthes = ["31", "28", "31", "30", "31", "30", "31", "31", "30", "31", "30", "31"];

function UpdateMonthDays() {
    var month = $("#@Model.GetIdMonthes() option:selected").val();
    console.log("month = " + month);
    FillDaysOfMonth(month);
    if (month == 2) {
        var year = $("#@Model.GetIdYear()").val();
        console.log("year = " + year);
        if (isLeap(year)) {
            var newOption = $('<option value="29">29</option>');
            $("#@Model.GetIdDays()").append(newOption);
        }
    }
}
function isLeap(yr) {
    var isleap = (yr % 400) ? ((yr % 100) ? ((yr % 4) ? false : true) : false) : true;
    console.log("isleap = " + isleap);
    return isleap;
}
function FillDaysOfMonth(month) {
    $("#@Model.GetIdDays()").empty();
    for (var i = 1; i <= monthes[month * 1 - 1]; i++) {
        var newOption = $('<option value=' + i + '>' + i + '</option>');
        $("#@Model.GetIdDays()").append(newOption);
    }
}