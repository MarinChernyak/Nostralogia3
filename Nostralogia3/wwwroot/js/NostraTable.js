

function NostraTable(id, expandAreaId) {
    this.ExpanderId = id;
    this.ExpandAreaId = expandAreaId;
    //console.log('created: ' + this.ExpanderId + '  ' + this.ExpandAreaId);
}
NostraTable.prototype = {
    OnExpanderClicked: function () {
        $("#" + this.ExpandAreaId).toggle();

        if ($("#" + this.ExpanderId+" > i").hasClass("fa-arrow-circle-up")) {
            $("#" + this.ExpanderId + " > i").removeClass("fa-arrow-circle-up");
            $("#" + this.ExpanderId+" > i").addClass("fa-arrow-circle-down");
        }
        else {
            $("#" + this.ExpanderId + " > i").removeClass("fa-arrow-circle-down");
            $("#" + this.ExpanderId + " > i").addClass("fa-arrow-circle-up");

        }
    }
}
