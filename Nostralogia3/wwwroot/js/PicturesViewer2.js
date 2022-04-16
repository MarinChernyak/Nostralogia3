function PictPreviewer(iduser, numPictures) {
    this.IDUser = iduser;
    this.NumPictures = numPictures;
    this.index = 0;
    this.Init();
}
PictPreviewer.prototype = {
    Init: function () {
        this.index = $("#dv_pict_container").attr("data-index");

        if (this.index == undefined || this.index == 0) {
            this.index = this.NumPictures * 1 - 1;
            if (this.index < 0)
                this.index = 0;
        }
        $("#dv_pict_container").attr("data-index", this.index);

        $("#dvPictNumber").html(this.index);

        $("#dvPictAmount").html(this.NumPictures);

        $("#dvAddPicture").addClass("PV_hidden");

    },
    btnPrevClicked: function () {
        this.DecreaseIndex($("#dv_pict_container").attr("data-index"));
        var curelem = $("#dv_pict_container").find('img:not(.PV_hidden):first');
        curelem.addClass('PV_hidden');
        var prevelem = curelem.prev();
        if (prevelem.attr('src') == undefined)
            prevelem = $("#dv_pict_container img").last();
        prevelem.removeClass("PV_hidden");
        $("#dv_pict_container").attr("data-index", this.index);
        $("#dvPictNumber").html(this.index + 1);

    }
}
