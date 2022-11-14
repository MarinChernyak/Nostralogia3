
function PictPreviewer(iduser, numPictures) {
    this.IDUser = iduser;
    this.NumPictures = numPictures;
    this.index = 0;
    this.Init();
}
PictPreviewer.prototype={
    Init:function()
    {
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
     btnPrevClicked:function() {
         this.DecreaseIndex($("#dv_pict_container").attr("data-index"));
        var curelem = $("#dv_pict_container").find('img:not(.PV_hidden):first');
        curelem.addClass('PV_hidden');
        var prevelem = curelem.prev();
        if (prevelem.attr('src') == undefined)
            prevelem = $("#dv_pict_container img").last();
        prevelem.removeClass("PV_hidden");
        $("#dv_pict_container").attr("data-index", this.index);
        $("#dvPictNumber").html(this.index + 1);

    },

     btnNextClicked:function() {

         this.IncreaseIndex($("#dv_pict_container").attr("data-index"));
         var curelem = $("#dv_pict_container").find('img:not(.PV_hidden):first');
         curelem.addClass('PV_hidden');
        var elem = curelem.next();
        if (elem.attr('src') == undefined)
            elem = $("#dv_pict_container img").first();

        elem.removeClass("PV_hidden");
        $("#dv_pict_container").attr("data-index", this.index);
        $("#dvPictNumber").html(this.index + 1);

    },
     IncreaseIndex:function(index) {

        this.index++;
        var NumPict = $("#dvPictAmount").html();
        if (NumPict * 1 == 0)
            this.index = -1;
        else if (this.index >= NumPict * 1)
            this.index = 0;
    },
     DecreaseIndex:function(index) {

        this.index--;
        var NumPict = $("#dvPictAmount").html();
        if (NumPict * 1 == 0)
            this.index = -1;
        else if (this.index < 0)
            this.index = NumPict * 1 - 1;
     },
     btnAddClicked:function(){
         $("#dvAddPicture").removeClass("PV_hidden");
         $("#dvDelPicture").addClass("PV_hidden");
         $("#MainContainer").addClass("PV_MCOntainerLong");

     },
     btnUploadCancelClicked:function(){
         $("#dvAddPicture").addClass("PV_hidden");
         $("#dvDelPicture").addClass("PV_hidden");
         $("#MainContainer").removeClass("PV_MCOntainerLong");
     },
     btnDelClicked:function(){
         $("#dvDelPicture").removeClass("PV_hidden");
         $("#dvAddPicture").addClass("PV_hidden");
         $("#MainContainer").addClass("PV_MCOntainerLong");
     },
     btnYDelClicked:function(){
         var calJson = {};

         var elem = $("#dv_pict_container").find('img:not(.PV_hidden):first');
         if(elem.attr('src')!=undefined)
         {
             calJson['pictid'] = elem.attr("data-pictid");  
             calJson['iduser'] = this.IDUser;
             calJson['src'] = elem.attr("src");
         
             $.ajax({
                 type: "POST",
                 cache: false,
                 url: "/PicturesViewer/DeletePicture",
                 data: JSON.stringify(calJson),
                 contentType: "application/json",
                 datatype: "json",
                 success: function (data) {
                     if (data["src"] == "deleted") {
                         alert("It is a demo. A picture cannot be deleted. You should add to a correspondent controller a necessary action. \nPlease see comments in a function PictureViewer/DeletePicture");        
                         elem.remove();                     
                         var amount = $("#dv_pict_container").find('img').length;             
                         this.index = amount - 1;
                         if (this.index < 0)
                             this.index = 0;
                         $("#dvPictNumber").html(this.index + 1);

                         $("#dvPictAmount").html(amount);
                         this.btnNextClicked();
                         $("#dvDelPicture").addClass("PV_hidden");
                         $("#MainContainer").removeClass("PV_MCOntainerLong");
                     }
                 }
             });
         }
     },
     btnUploadClicked: function () {
         if (window.FormData != undefined) {
             var fupload = $("#File1").get(0);

             var files = fupload.files;
             if (files.length == 0) {
                 alert("Please select a file to upload");
                 return;
             }

             var filedata = new FormData();
             for (var i = 0; i < files.length; ++i) {

                 filedata.append(files[i].name, files[i]);
             }
             var amount = $("#dv_pict_container").find('img').length;
             filedata.append('iduser', this.IDUser);
             filedata.append('numberpict', amount);
             $.ajax({
                 type: "POST",
                 url: "/PicturesViewer/UpdatePicture",
                 data: filedata,
                 contentType: false,
                 processData: false,
                 success: function (data) {
                     if (data["src"] != 'error') {
                         
                         this.NumPictures = data["pictamount"];
                         var curidIndex = this.NumPictures - 1;
                         $("#dv_pict_container").find('img:not(.PV_hidden):first').addClass('PV_hidden');
                         var id = "img_" + curidIndex;
                         $("#dv_pict_container").attr("data-index", curidIndex);
                         $("#dvPictNumber").html(curidIndex + 1);
                         $("#dvPictAmount").html(this.NumPictures);
                         $("#dvAddPicture").addClass("PV_hidden");
                         $("#MainContainer").removeClass("PV_MCOntainerLong");
                         fupload.value = "";
                         var imgdatastr = '<img id=' + id + ' src=' + data["src"] + ' width=' + data["width"] + ' height=' + data["height"] + '/>';
                         $("#dv_pict_container").append(imgdatastr);
                         $("#" + id).attr("data-pictid", data["pictid"]);
                         alert("In this demo, the viewer provides just images, that it is in a model.\n You will be need to change a code of a model slightly to connect your database");
                     }
                     else
                         alert("Unknown error appeared!");
                 }
             })
         }
     }

}