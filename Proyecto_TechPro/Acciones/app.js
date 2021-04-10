function agregarCarrito(itemID) {

    $.ajax({
        type: 'Post',
        url: '/Home/AgregaItem',
        data: {
            item: $(itemID).attr("itemid")
        },
        cache: false,
        dataType: 'string',
        success: function (data) {
            alert("dfsgv");
        },
        error: function() {
            alert("ERROR KRUK");
        }
    
        
    });

}