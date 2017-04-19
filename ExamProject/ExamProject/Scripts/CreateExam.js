function CreateExam() {
    var data = {
        "title": $("#slct option:selected").text(),
        "description": $("#slct option:selected").val(),
        "question1": $("#s1").val(),
        "question1_choice": $("#s1c option:selected").val(),
        "question1_A": $("#a1").val(),
        "question1_B": $("#b1").val(),
        "question1_C": $("#c1").val(),
        "question1_D": $("#d1").val(),
        "question2": $("#s2").val(),
        "question2_choice": $("#s2c option:selected").val(),
        "question2_A": $("#a2").val(),
        "question2_B": $("#b2").val(),
        "question2_C": $("#c2").val(),
        "question2_D": $("#d2").val(),
        "question3": $("#s3").val(),
        "question3_choice": $("#s3c option:selected").val(),
        "question3_A": $("#a3").val(),
        "question3_B": $("#b3").val(),
        "question3_C": $("#c3").val(),
        "question3_D": $("#d3").val(),
        "question4": $("#s4").val(),
        "question4_choice": $("#s4c option:selected").val(),
        "question4_A": $("#a4").val(),
        "question4_B": $("#b4").val(),
        "question4_C": $("#c4").val(),
        "question4_D": $("#d4").val(),

    };
    $.ajax({
        url: "/Rss/CreateExam/",
        method: "POST",
        data: { article: data },
        error: function () {
            alert("başarısız");
        }

    })
        .done(function () {
            alert("eklendi");
        });

}
 
