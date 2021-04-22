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

