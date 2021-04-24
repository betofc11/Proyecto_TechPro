function ConsutaDireccion() {

	
	$.ajax({
		type: 'Post',
		url: '/Carrito/TraerValores',
		data: {
			provincia: provinciasA;
			canton: cantonesA
		},
		cache: false,
		dataType: 'json', //html //string
		success: function (data) {

			document.getElementById("provincias").value = data.provincias;
			document.getElementById("cantones").value = data.cantones;

			alert("Correcto");

		},
		error: function () {

			alert("todo mal");

		}
	});

}