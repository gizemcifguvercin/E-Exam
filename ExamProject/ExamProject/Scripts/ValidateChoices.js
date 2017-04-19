function ValidateChoices() {
   
    var data = {
        "aid": $("#aid").val(),
        "q1": $("#q1").val(),
        "q2": $("#q2").val(),
        "q3": $("#q3").val(),
        "q4": $("#q4").val(),
    };
    $.ajax({
        url: "/Articles/Exam",
        method: "POST",
        data: { vd: data },
    })
        .done(function (sonuclar) {

          
            var str = String(sonuclar);
            var sorular = str.split(",");
            var soru1 = sorular[0].split(":");
            var soru2 = sorular[1].split(":");
            var soru3 = sorular[2].split(":");
            var soru4 = sorular[3].split(":");
    
            $("#" + soru1[1] + "1").css("background-color", soru1[0]);
            $("#" + soru2[1] + "2").css("background-color", soru2[0]);
            $("#" + soru3[1] + "3").css("background-color", soru3[0]);
            $("#" + soru4[1] + "4").css("background-color", soru4[0]);
            $("#button1").hide();
        });
}