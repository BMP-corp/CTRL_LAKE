function aggiornaQuantita(element, resDiv) {
    var min = 0 - element.options[element.selectedIndex].value;
    var line = '<input type="number" style="width: 40px" name="quantity" min="' + min + '" />'
    resDiv.innerHTML = line;
}

