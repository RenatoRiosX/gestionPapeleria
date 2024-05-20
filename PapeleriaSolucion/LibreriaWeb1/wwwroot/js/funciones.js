function guardarLineas(lineas) {
	localStorage.setItem('lineas', JSON.stringify(lineas));
}

function obtenerLineas() {
	var lineas = localStorage.getItem('lineas');
	if (lineas) {
		return JSON.parse(lineas);
	} else {
		return [];
	}
}



function actualizarTabla() {
	var lineas = obtenerLineas();
	var tbody = $(".table tbody");
	tbody.empty(); // Elimina las filas existentes

	lineas.forEach(function (linea, index) {
		var fila = $("<tr></tr>");
		fila.append($("<td></td>").text(linea.ArticuloDto.Nombre));
		fila.append($("<td></td>").text(linea.Unidades));
		fila.append($("<td></td>").append($("<button class='btn btn-danger'></button>").text("Eliminar").click(function () {
			eliminarLinea(index);
		})));

		tbody.append(fila);
	});
}

function eliminarLinea(index) {
	var lineas = obtenerLineas();
	lineas.splice(index, 1); // Elimina la línea de pedido en el índice especificado
	guardarLineas(lineas);
	actualizarTabla(); // Actualiza la tabla para reflejar la línea de pedido eliminada
}

function cerrarSesion() {
	localStorage.removeItem('lineas');
}