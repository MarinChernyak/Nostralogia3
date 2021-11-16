
function get_JD_from_CalDay(year, month, day) {
    var Year = year;
    var Month = month;
    var Day = day;
    var JD = 0;
    if (Month > 0 && Month < 13 && Day > 0 && Day < 32 && !(Month == 2 && Day > 29)) {
        if (Month < 3) {
            Year -= 1;
            Month += 12;
        }

        var A = Math.floor(Year / 100);
        var B = 0;

        var A4 = Math.floor(A / 4);
        if (Year > 1572 || (Year == 1572 && Month > 10) || (Year == 1572 && Month == 10 && Day > 4))
            B = 2 - A + A4;

        var C = 2 - A + B;
        var E = Math.floor(365.25 * (Year + 4716));
        var ff = 30.6001 * (Month + 1);
        var F = Math.floor(ff);
        JD = E + F + Day + B - 1524.5;

    }
    return JD;
}
function get_CalDay_from_JD(jd) {
    var date = [];
    if (jd >= 0) {
        var jd1 = Math.floor(jd);
        var Z = jd1;
        var F = jd-jd1;
        var A = 0;
        if (Z < 2299161)
            A = Z;
        else {
            var alfa = Math.floor((Z - 1867216.25) / 36524.25);
            A = Z + 1 + alfa - Math.floor(alfa / 4.0);
        }
        var B = A + 1524;
        //alert("B= " + B);
        var C = Math.floor((B - 122.1) / 365.25);
        //alert("C= " + C);
        var D = Math.floor(365.25 * C);
        //alert("D= " + D);

        var E = Math.floor((B - D) / 30.6001);
        //alert("E= " + E);

        date.push(B - D - Math.floor(30.6001 * E) + F);//day
        var month = 0;
        if (E < 14)
            month = E - 1; //month
        else // 14 or 15!
            month = E - 13;
        date.push(month);
        if (month > 2)
            date.push(C - 4716);
        else
            date.push(C - 4715);

    }
    //alert("get_CalDay_from_JD => [0]= " + date[0] + "  [1]= " + date[1] + "  [2]= " + date[2]);
    return date;
}
function getRandomInt(min, max) {
    return Math.floor(Math.random() * (max - min + 1)) + min;
}
function getDayWeek(JD) {
    var week = Math.floor((JD + 1.5) % 7.0);
    return week;
}
function isYearLeap(year) {
    
    var y1 = year * 1;

    var isleap = false;
    if (y1 % 100 == 0) {
        if (y1 * 1 % 400 == 0)
            isleap = true;
    }
    else if (y1 % 4 == 0)
        isleap = true;
    
    return isleap;
}