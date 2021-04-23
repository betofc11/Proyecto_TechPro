function agregarCarrito(itemID) {
    $("#divLoading").show();

        

    $.ajax({
        type: 'Post',
        url: '/Home/AgregaItem',
        data: {
            item: $(itemID).attr("itemid")
        },
        cache: false,
        dataType: 'json',
        success: function (data) {
            $("#divLoading").hide();
            $("#badgeCart").text(data);
            
            
        },
        error: function() {
            alert("ERROR KRUK");
        }
    
        
    });

    $(itemID).prop("disabled", true);
    $(itemID).removeClass('btn-success').addClass('btn-secondary ');
    $(itemID).html('En el carrito');
}


function seleccionaCat(catID) {

    $.ajax({
        type: 'Post',
        url: '/Home/SeleccionaCat',
        data: {
            cat: $(catID).attr("catID")
        },
        cache: false,
        dataType: 'html',
        success: function (data) {
            alert("good");


        },
        error: function () {
            alert("ERROR KRUK");
        }


    });
}

