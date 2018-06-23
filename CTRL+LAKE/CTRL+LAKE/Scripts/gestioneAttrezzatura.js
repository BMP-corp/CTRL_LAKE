function aggiornaQuantita(element, resDiv) {
    var min = 0 - element.options[element.selectedIndex].getAttribute("nmin");
    var line = '<input type="number" name="quantity" min="' + min + '" class="centrovelicostyle centrovelicoinsidestyle _button" required/>'
    resDiv.innerHTML = line;
}

