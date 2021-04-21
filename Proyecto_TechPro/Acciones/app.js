function agregarCarrito(itemID) {

    $.ajax({
        type: 'Post',
        url: '/Home/AgregaItem',
        data: {
            item: $(itemID).attr("itemid")
        },
        cache: false,
        dataType: 'json',
        success: function (data) {
            $("#badgeCart").text(data);
        },
        error: function() {
            alert("ERROR KRUK");
        }
    
        
    });

}