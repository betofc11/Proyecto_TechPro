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
            $("#divLoading").hide();
            $("#badgeCart").text(data);


        },
        error: function () {
            alert("ERROR KRUK");
        }


    });

    $(itemID).prop("disabled", true);
    $(itemID).removeClass('btn-success').addClass('btn-secondary ');
    $(itemID).html('En el carrito');
}