
function CalendarBase(curDay, curMonth, CurH,CurM,CurS,CalID,index) {

    this._index = index;
    this.LimitSelectedClasses=5;

    this.ID_calendarTable = "";
    this._name = CalID;
    this.calID = "";
    this.curMonth = "";
    this.curDay = curDay;

    this.ID_close_icon = "";
    this.ID_clockicon = "";
    this.ID_cldr_icon="";
    this.ID_cldr_value="";
    this.ID_main_container = "";
    this.ID_cmbMonthes = "";
    this.ID_time = "";
    this.ID_time_closeicon = "";
    this.year_plus_0 = "";
    this.year_minus_0 = "";
    this.year_plus_1 = "";
    this.year_minus_1 = "";
    this.year_plus_2 = "";
    this.year_minus_2 = "";
    this.year_plus_3 = "";
    this.year_minus_3 = "";
    this.year_number_0 = "";
    this.year_number_1 = "";
    this.year_number_2 = "";
    this.year_number_3 = "";

    this.curDayID = "";
    this.curHID = ""; 
    this.curMID = ""; 
    this.curSID = "";
    this.previousCellClass = "";
    this._tm = null;
    this.CalResult = "";

    

    this.CreateIDs(CalID);
    this._tm = new TimeDataManipulator(this._name, CurH, CurM, CurS);

    this.InitCalendar(curMonth);

    this.UpdateTable();

}
CalendarBase.prototype = {
    CreateIDs: function (CalID) {

        this.CalID = "calID_" + CalID;
        $("#calID").attr("id", this.calID);

        this.CalResult = "CalResult_" + CalID;
        $("#CalResult").attr("id", this.CalResult);

        this.ID_close_icon = "ID_close_icon_" + CalID;
        $("#ID_close_icon").attr("id", this.ID_close_icon);

        this.curSID = "curSID_" + CalID;
        $("#curSID").attr("id", this.curSID);

        this.curMID = "curM_" + CalID;
        $("#curMID").attr("id", this.curMID);

        this.curHID = "curH_" + CalID;
        $("#curHID").attr("id", this.curHID);

        this.curDayID = "curDayID_" + CalID;
        $("#curDayID").attr("id", this.curDayID);

        this.curMonthID = "curMonthID_" + CalID;
        $("#curMonthID").attr("id", this.curMonthID);

        this.ID_calendarTable = "ID_calendarTable_" + CalID;
        $("#ID_calendarTable").attr("id", this.ID_calendarTable);

        this.ID_clockicon ="ID_clockicon_"+ CalID;
        $("#ID_clockicon").attr("id",this.ID_clockicon);

        this.ID_cldr_icon = "ID_cldr_icon_" + CalID;
        $("#ID_cldr_icon").attr("id", this.ID_cldr_icon);
        
        this.ID_cldr_value="ID_Cldr_value_"+ CalID;
        $("#ID_cldr_value").attr("id",this.ID_cldr_value);

        this.ID_main_container = "ID_main_container_" + CalID;
        $("#ID_main_container").attr("id", this.ID_main_container);

        this.ID_time_closeicon = "ID_time_closeicon_"+CalID;
        $("#ID_time_closeicon").attr("id", this.ID_time_closeicon);

        this.ID_time = "ID_time_" + CalID;
        $("#ID_time").attr("id", this.ID_time);

        this.ID_cldrEditBox = "ID_cldrEditBox_" + CalID;
        $("#ID_cldrEditBox").attr("id", this.ID_cldrEditBox);

        this.ID_cmbMonthes = "ID_cmbMonthes_" + CalID;
        $("#ID_cmbMonthes").attr("id", this.ID_cmbMonthes);

        this.year_plus_0 = "year_plus_0_" + CalID;
        $("#year_plus_0").attr("id", this.year_plus_0);

        this.year_minus_0 = "year_minus_0_" + CalID;
        $("#year_minus_0").attr("id", this.year_minus_0);

        this.year_plus_1 = "year_plus_1_" + CalID;
        $("#year_plus_1").attr("id", this.year_plus_1);

        this.year_minus_1 = "year_minus_1_" + CalID;
        $("#year_minus_1").attr("id", this.year_minus_1);

        this.year_plus_2 = "year_plus_2_" + CalID;
        $("#year_plus_2").attr("id", this.year_plus_2);

        this.year_minus_2 = "year_minus_2_" + CalID;
        $("#year_minus_2").attr("id", this.year_minus_2);

        this.year_plus_3 = "year_plus_3_" + CalID;
        $("#year_plus_3").attr("id", this.year_plus_3);

        this.year_minus_3 = "year_minus_3_" + CalID;
        $("#year_minus_3").attr("id", this.year_minus_3);

        this.year_number_0 = "year_number_0_" + CalID;
        $("#year_number_0").attr("id", this.year_number_0);

        this.year_number_1 = "year_number_1_" + CalID;
        $("#year_number_1").attr("id", this.year_number_1);

        this.year_number_2 = "year_number_2_" + CalID;
        $("#year_number_2").attr("id", this.year_number_2);

        this.year_number_3 = "year_number_3_" + CalID;
        $("#year_number_3").attr("id", this.year_number_3);

    },
    UpdateResult:function()
    {       
         $("#"+this.CalResult).val(this.getDate());
    },
    InitCalendar: function (curMonth) {
        var sMonthVal = this.UpdateMonthVal(curMonth);
        $("#" + this.ID_cmbMonthes).val(sMonthVal);
        $("#" + this.ID_time).addClass("Cldr_hidden");
        $("#" + this.ID_time_closeicon).removeClass("Cldr_hidden");
        $("#" + this.ID_cldr_value).html(this.getDateTimeOut());
        $("#" + this.ID_cldrEditBox).removeClass("Cldr_hidden");
    },
    UpdateMonthVal: function (monthval) {
        var sMonthval = '';
        sMonthval+=monthval;
        if (sMonthval.length==1)
            sMonthval = '0' + monthval;
        return sMonthval;
    },
    UpdateCalendar:function (visibleContainer) {

        var main = $("#" + this.ID_main_container);
        var ebox = $("#" + this.ID_cldrEditBox);
        var tbox = $("#" + this.ID_time);
        if (visibleContainer == "m") {
            main.removeClass("Cldr_hidden");
            ebox.addClass("Cldr_hidden");
            tbox.addClass("Cldr_hidden");
        }
        else if (visibleContainer == "t") {
            main.addClass("Cldr_hidden");
            tbox.removeClass("Cldr_hidden");
            ebox.addClass("Cldr_hidden");
        }
        else {
            $("#" + this.ID_cldr_value).html(this.getDateTimeOut());
            main.addClass("Cldr_hidden");
            ebox.removeClass("Cldr_hidden");
            tbox.addClass("Cldr_hidden");
        }
    },
//    /////// ---- Get / Update Region ----////////
    getTime:function () {

        var tVal = this._tm.ToString();

        if (tVal == "::") {
            tVal = "12:00:00";
        }
        return tVal;
    },
    getDate:function() {
    //format data: 2011-06-02 11:16:53.393
        var monthval = this.getMonth();
        var dayval = this.getDay();
        if (dayval.length == 1)
            dayval = "0" + dayval;
    return dayval + "-" + this.UpdateMonthVal(monthval) + "-" + this.getYear();
    },
    getDateTimeOut: function () {
        
        //var date = "2011-06-02 11:16:53";
        var date = this.getDate();
        var time = this.getTime();
        
        var sout = "<div class=\"Cldr_Value_box1\" >" + date + '</div><div class=\"Cldr_Value_box2\" >  ' + time + "</div>";
        return sout;
    },
    getYear: function () {
        var yval0 = $("#" + this.year_number_0).html();
        var yval1 = $("#" + this.year_number_1).html();
        var yval2 = $("#" + this.year_number_2).html();
        var yval3 = $("#" + this.year_number_3).html();

    return yval0 * 1000 + yval1 * 100 + yval2 * 10 + yval3 * 1;
    },
    updateYear: function(year)
    {
        var y0 = Math.floor(year / 1000);
        var y1 = Math.floor((year - y0 * 1000) / 100);
        var y2 = Math.floor((year - y0 * 1000 - y1 * 100) / 10);
        var y3 = year - y0 * 1000 - y1 * 100 - y2 * 10;

        $("#" + this.year_number_0).html(y0);
        $("#" + this.year_number_1).html(y1);
        $("#" + this.year_number_2).html(y2);
        $("#" + this.year_number_3).html(y3);
    },
    getMonth: function () {
        var monthval = $("#" + this.ID_cmbMonthes + " option:selected").val();
        return monthval;
    },
    getCldrVarClass: function (classVar) {
        var classCell = classVar;
  
        if (this._index != undefined && this._index > 0 && this._index <= this.LimitSelectedClasses) {
            classCell = classCell + this._index;
            
        }

        return classCell;
        
    },
    getDay: function () {

        var dayval = $("."+this.getCldrVarClass("Cldr_Cell_selDay")).html();
        if (dayval == undefined)
            dayval = this.curDay;

        return dayval;
    },
    //    ///////// *** End of Get  / Update *****

    //////// ----- Click events processing --------------

    clickYearChange: function (index, action) {
        var vid = "year_number_" + index + "_" + this._name;
        
        var yval = $("#" + vid).html();
       
        if (action == '+') {
            yval = yval * 1 + 1;
            if (yval > 9)
                yval = 0;
        }
        else {
            yval = yval * 1 - 1;
            if (yval <0)
                yval = 9;
        }
        
        $("#" + vid).html(yval);
    
        this.UpdateTable();
        this.UpdateResult();
    },
    clickDayChange:function(selDayId, selectedClass)
    {

        var olddiv = $(this.getCldrVarClass(".Cldr_Cell_selDay"));

        if (olddiv != undefined && olddiv != null) {

            olddiv.removeClass(this.getCldrVarClass("Cldr_Cell_selDay"));
            olddiv.addClass(this.previousCellClass);
            this.previousCellClass = selectedClass;
            
        }

        if (selectedClass == this.getCldrVarClass("Cldr_Cell")) {
            var date = [];
            date= selDayId.split("_");
            if (Array.isArray(date)) {
                
                this.processTable(date[2], date[3], date[4]);

                $("#" + this.ID_cmbMonthes).val(date[3]);
                this.updateYear(date[4]);

                var myClass = $("#" + selDayId).attr("class");
               
                if (myClass != undefined) {                    
                    $("#" + selDayId).removeClass(myClass);
                    this.previousCellClass = myClass;
                }
                $("#" + selDayId).addClass(this.getCldrVarClass("Cldr_Cell_selDay"));
            }
            else {
                allert("error processing selected date!");
                
            }
        }
        $("#" + selDayId).removeClass(selectedClass);
        $("#" + selDayId).addClass(this.getCldrVarClass("Cldr_Cell_selDay"));
        this.UpdateResult();


    },



    ////// ***  End of Click processing ***

    //// ---  Table Building region ----

    UpdateTable: function () {
            var year = this.getYear();
            var month = this.getMonth();
            var day = this.getDay();

            this.processTable(day, month, year);
            this.UpdateResult();
    },
    processTable:function(day, month,year)
    {
        var table = "";
        var date = [];
        var week = 111;

        var jd = get_JD_from_CalDay(year * 1, month * 1, 1.5);
        week = getDayWeek(jd);

        //[day,moth,year]
        date = get_CalDay_from_JD(jd - 1);
        if (Array.isArray(date)) {
            //date[0] - last dayof the previous month
            var first_day_in_cal_prev_month = date[0] - week + 1;

            table = this.addFirstRow(first_day_in_cal_prev_month, date[0], date[1], date[2], table, week);

            var startDayInNextRow = 8 - week;
            table = this.addOtherRows(startDayInNextRow, month, year, table);
            $("#" + this.ID_calendarTable).html(table);            
        }
    },

    addFirstRow: function (first_day_in_cal_prev_month, last_day_in_cal_prev_month,month,year, table, week)
    {

        table = this.startRow(table);
        var dayStart = 1;
        table = this.addPrevMonth(first_day_in_cal_prev_month, last_day_in_cal_prev_month, month, year, table);
        month = month*1 + 1;
        if (month > 12) {
            month = month-12;
            year+=1;
        }
        while (week != 6) {
            if (week == 0)
                table = this.addCell(table, dayStart, month,year, this.getCldrVarClass("Cldr_Cell_HolyDay"));
            else
                table = this.addCell(table, dayStart, month, year, this.getCldrVarClass("Cldr_Cell_belongMonth"));

            week++;
            dayStart++;            
        }

        table = this.addCell(table, dayStart, month,year, this.getCldrVarClass("Cldr_Cell_HolyDay"));
        //?????
        return this.endRow(table);
    },
    startRow: function (table) {
        table=table+"<div class=\"Cldr_InnerRow\">";
        return table;
    },
    endRow:function(table){
        table = table + "</div>";
        return table;
    },
    addPrevMonth: function (first_day_in_cal_prev_month, last_day_in_cal_prev_month,month,year, table) {
        var curday = first_day_in_cal_prev_month;
        var m1 = month * 1;
        var y1 = year;
        if (m1 == 0) {
            m1 = 12;
            y1 = y1 * 1 - 1;
        }

        while (curday <= last_day_in_cal_prev_month) {
            table = this.addCell(table, curday, m1, y1, this.getCldrVarClass("Cldr_Cell"));
                curday = curday + 1;
        }
        return table;
    },
    addCell: function (table, day, month, year, classcell) {
        table = table + "<div class=\"" + classcell + "\" id=\"" + this._name + "_" + day + "_" + month + "_" + year + "\">" + day + "</div>";
        return table;
    },
    addOtherRows: function (startDayInNextRow, month, year, table)
    {
        
        var curDay = startDayInNextRow;
        var week = 0;
        var Iscompleted = false;
        
        while (week <= 6 && !Iscompleted) {
            var classCell = this.getCldrVarClass("Cldr_Cell_belongMonth");
            if (week == 0) {
                classCell = this.getCldrVarClass("Cldr_Cell_HolyDay");
                table = this.startRow(table);
            }
            if (week == 6) {
                classCell = this.getCldrVarClass("Cldr_Cell_HolyDay");
                
            }

            table = this.addCell(table, curDay, month, year, classCell);
            curDay++;
            week++;
            if (week == 7) {
                table = this.endRow(table);
                week = 0;
            }
            if (this.ShouldTurnNextMonth(curDay, month, year))
            {                
                Iscompleted = true;                    
            }
        }
       
        if (this.ShouldTurnNextMonth(curDay, month, year)) {
            
                curDay = 1;
                month = month*1+1;

                if (month > 12) {
                    month = month - 12;
                    year = year * 1 + 1;
                }
            }

        while (week > 0 && week < 7) {
            var classCell = this.getCldrVarClass("Cldr_Cell");            
            table = this.addCell(table, curDay, month, year, classCell);
            curDay++;
            week++; 
        }

        return table;
    },
    ShouldTurnNextMonth: function(day, month,year)
    {
        var shoulBe = false;

        if (day * 1 > 28 && month * 1 == 2 && isYearLeap(year * 1) == false)
        {
            shoulBe = true;
        }
        else if ((day*1 > 29 && month*1 == 2) ||
             (day * 1 > 30 && (month * 1 == 4 || month * 1 == 6 || month * 1 == 9 || month * 1 == 11))
             || day * 1 > 31)
            {
                
            shoulBe = true;
        }
        
        return shoulBe;
    }
    /// *** End of Table Building region
}


//////////////////// TIME ///////////////////////////

function TimeDataManipulator(idTime, curH, curM, curS) {
    this.ID = idTime;
    this.timeID = "";
    this.tH10 = "";
    this.tH10add = "";
    this.tH10min = "";
    this.tH1 = "";
    this.tH1add = "";
    this.tH1min = "";
    this.tM10 = "";
    this.tM10add = "";
    this.tM10min = "";
    this.tM1 = "";
    this.tM1add = "";
    this.tM1min = "";
    this.tS10 = "";
    this.tS10add = "";
    this.tS10min = "";
    this.tS1 = "";
    this.tS1add = "";
    this.tS1min = "";
    this.timeContainer = "";
    this.TimeResult = "";
    this.CreateID(idTime);
    this.InitControl(curH, curM, curS);

}
TimeDataManipulator.prototype = {
    InitControl: function (Hour, Min, Sec) {

        this.UpdateHour(Hour);
        this.UpdateMin(Min);
        this.UpdateSec(Sec);

    },
    CreateID: function (idTime) {

        this.idTimeParam = idTime;

        this.timeID = "timeID_" + idTime;
        $("#timeID").attr("id", this.timeID);

        this.timeContainer = "timeContainer_" + idTime;
        $("#timeContainer").attr("id", this.timeContainer);

        this.tS10 = "tS10_" + idTime;
        $("#tS10").attr("id", this.tS10);

        this.tS10add = "tS10add_" + idTime;
        $("#tS10add").attr("id", this.tS10add);

        this.tS10min = "tS10min_" + idTime;
        $("#tS10min").attr("id", this.tS10min);

        this.tS1 = "tS1_" + idTime;
        $("#tS1").attr("id", this.tS1);

        this.tS1add = "tS1add_" + idTime;
        $("#tS1add").attr("id", this.tS1add);

        this.tS1min = "tS1min_" + idTime;
        $("#tS1min").attr("id", this.tS1min);

        this.tM10 = "tM10_" + idTime;
        $("#tM10").attr("id", this.tM10);

        this.tM10add = "tM10add_" + idTime;
        $("#tM10add").attr("id", this.tM10add);

        this.tM10min = "tM10min_" + idTime;
        $("#tM10min").attr("id", this.tM10min);

        this.tM1 = "tM1_" + idTime;
        $("#tM1").attr("id", this.tM1);

        this.tM1add = "tM1add_" + idTime;
        $("#tM1add").attr("id", this.tM1add);

        this.tM1min = "tM1min_" + idTime;
        $("#tM1min").attr("id", this.tM1min);

        this.tH10 = "tH10_" + idTime;
        $("#tH10").attr("id", this.tH10);

        this.tH10add = "tH10add_" + idTime;
        $("#tH10add").attr("id", this.tH10add);

        this.tH10min = "tH10min_" + idTime;
        $("#tH10min").attr("id", this.tH10min);

        this.tH1 = "tH1_" + idTime;
        $("#tH1").attr("id", this.tH1);

        this.tH1add = "tH1add_" + idTime;
        $("#tH1add").attr("id", this.tH1add);

        this.tH1min = "tH1min_" + idTime;
        $("#tH1min").attr("id", this.tH1min);

        this.TimeResult = "TimeResult_" + idTime;
        $("#TimeResult").attr("id", this.TimeResult);
    },
    UpdateHour: function (Value) {
        this.UpdateCategoryWithNum(Value, "H");
    },
    UpdateMin: function (Value) {
        this.UpdateCategoryWithNum(Value, "M");
    },
    UpdateSec: function (Value) {
        this.UpdateCategoryWithNum(Value, "S");
    },
    //category "H","M","S"
    UpdateCategoryWithNum: function (Value, category) {
        var v1 = 0;
        var v10 = 0;
        if (Value > 9) {
            v10 = Math.floor(Value / 10);
            v1 = Value % 10;
        }
        else
            v1 = Value;

        var id = "t" + category + "10_" + this.idTimeParam;
        $("#" + id).html(v10);
       
        id = "t" + category + "1_" + this.idTimeParam;
        $("#" + id).html(v1);
    },
    // element is H10,M1,S10 etc. Case sencitive!
    UpdateElement: function (Value, element) {

        var curValue = $("#" + this.timeID + "_t" + element).html();
        var vElem = curValue * 1 + Value;
        if (vElem > 0) {
            if ((element == 'H10' && vElem > 2) || (element == "M10" || element == "S10") && vElem > 5)
                vElem = 0;
            else if (element == 'H10' && vElem == 2) {
                var H1 = $("#" + this.timeID + "_tH1").html();
                if (H1 > 3)
                    $("#" + this.timeID + "_tH1").text("3");
            }
            else if ((element == "S1" || element == "M1") && vElem > 9) {
                vElem = 0;
            }
            else if (element == "H1") {
                var H10 = $("#" + this.timeID + "_tH10").html();
                if ((H10 < 2 && vElem > 9) || (H10 == 2 && vElem > 3))
                    vElem = 0;
            }
        }
        else if (vElem < 0) {
            if (element == "S1" || element == "M1")
                vElem = 9;
            else if (element == "M10" || element == "S10")
                vElem = 5;
            else if (element == "H10") {
                vElem = 2;
                var H1 = $("#" + this.timeID + "_tH1").html();
                if (H1 > 3)
                    $("#" + this.timeID + "_tH1").text("3");
            }
            else if (element == "H1") {
                var H10 = $("#" + this.timeID + "_tH10").html();
                if (H10 == 2)
                    vElem = 3;
                else
                    vElem = 9;
            }

        }


        $("#" + this.timeID + "_t" + element).text(vElem);
    },
    //category "H","M","S"
    GetTimeDataValue: function (category) {              
       
        var V10 = this.GetTimeCategoryIndexValue(category, 10);
        var V1 = this.GetTimeCategoryIndexValue(category, 1);

        return V10*10 + V1*1;
    },
    GetTimeCategoryIndexValue:function(category, index)
    {
        var id = "t" + category + index + "_" + this.idTimeParam;
        var V1 = $("#" + id).html();
        return V1;
    },
    ToString: function () {

        return this.updateValue(this.GetTimeDataValue("H") + ":") +  this.updateValue(this.GetTimeDataValue("M") + ":") +  this.updateValue(this.GetTimeDataValue("S")+' ');
    },
    GetTimeNumber: function () {
        var output = 0;
        output = this.GetTimeDataValue("H") * 1 + this.GetTimeDataValue("M") / 60.0 + this.GetTimeDataValue("S") / 3600.0;
        return output;
    },
    updateValue: function (val) {
        if (val.length == 2) {
            val = "0" + val;
        }
        return val;
    },
    ////// Click tvent processing ////////////
    clickTimeChange: function (category, index, action) {
        var vid = "t" + category + index + "_" + this.idTimeParam;
        var tval = $("#" + vid).html();
        if (action == '+') {
            tval = tval * 1 + 1;
            if ((category == "S" || category == "M") && index == "1" && tval > 9) {
                tval = 0;
            }
            else if ((category == "S" || category == "M") && index == "10" && tval > 5) {
                tval = 0;
            }
            else if (category == "H" && index == "1" && tval > 3) {
                var h10 = this.GetTimeCategoryIndexValue("H", 10);
                if (h10 == 2) {
                    tval = 0;
                }
                else if (tval > 9) {
                    tval = 0;
                }
            }
            else if (category == "H" && index == "10" && tval > 2) {
                tval = 0;
            }
        }
        else {
            tval = tval * 1 - 1;
            if (tval < 0) {
                if ((category == "S" || category == "M") && index == "1") {
                    tval = 9;
                }
                else if ((category == "S" || category == "M") && index == "10") {
                    tval = 5;
                }
                else if (category == "H" && index == "10") {
                    tval = 2;
                }
                else if (category == "H" && index == "1") {
                    var h10 = this.GetTimeCategoryIndexValue("H", 10);
                    if (h10 * 1 < 2) {
                        tval = 9;
                    }
                    else {
                        tval = 3;
                    }
                }
            }

        }

        $("#" + vid).html(tval);
        this.UpdateTimeResult();
    },
    UpdateTimeResult: function () {
        $("#" + this.TimeResult).val(this.ToString());
    }



}




