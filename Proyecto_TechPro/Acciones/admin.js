function confirmar(idItem) {
    $("#divLoading").show();



    $.ajax({
        type: 'Post',
        url: '/Admin/confirmarItem',
        data: {
            item: $(idItem).attr("idItem")
        },
        cache: false,
        dataType: 'json',
        success: function (data) {

            var id = $(idItem).attr("idItem");
            $("#"+id).find("#estado").html(data);
            $("#divLoading").hide();
            $("#badgeCart").text(data);


        },
        error: function () {
            alert("ERROR KRUK");
        }


    });
}



    $('input[type="file"]').change(function (e) {
        var fileName = e.target.files[0].name;
        $("#txt_imagen").val(fileName)
        alert('The file "' + fileName + '" has been selected.');
    });