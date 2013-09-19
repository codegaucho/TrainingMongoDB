$(document).ready(function () {
    $('.summernote').summernote();

    //now bind to the form's submit event so we can push the contents of the editor into content
    $("#courseform").submit(function (event) {
        alert("get html");
        var aHTML = $('.summernote').code(); //aHTML: array of strings.

        alert("now stick in textarea");
        //now stick that into the textareea
        $("#content").val(aHTML[0]);

        alert("now carry on with submit");
    });
});