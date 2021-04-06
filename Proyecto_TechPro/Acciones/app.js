function agregarCarrito(itemID) {
    var item = $(itemID).attr("itemid");
    sessionStorage.setItem("ejemplo", item);
    alert("El id del item es: "+sessionStorage.getItem("ejemplo"));
}