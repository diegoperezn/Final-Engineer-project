function validarRegex(id, regex) {

    var elemento = document.getElementById("MainContent_" + id)

    if (elemento.value != '') {
        if (!regex.test(elemento.value)) {
            elemento.style.backgroundColor = "#FFB0B0"
            return false
        } else {
            elemento.style.backgroundColor = "white"
            return true
        }
    }

    return true;
}

function validarSelectRequeridos(camposString) {
    var campos = camposString.split(',');
    var ok = true;

    for (i = 0; i < campos.length; i++) {
        var elemento = document.getElementById("MainContent_" + campos[i]);

        if (elemento != null) {
            if (elemento.selectedIndex == '-1' ||
                elemento.value == '') {
                elemento.style.backgroundColor = "#FFB0B0";
                ok = false;
            } else {
                elemento.style.backgroundColor = "white";
            }
        }
    }

    return ok
}

function validarRequeridos(camposString) {
    var campos = camposString.split(',');
    var ok = true;

    for (i = 0; i < campos.length; i++) {
        var elemento = document.getElementById("MainContent_" + campos[i]);

        if (elemento.value == '') {
            elemento.style.backgroundColor = "#FFB0B0";
            ok = false;
        } else {
            elemento.style.backgroundColor = "white";
        } 
    }

    return ok
}