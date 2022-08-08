//const { each } = require("jquery");

function kohdistus(input) {
    input.addEventListener("focusin", () => {
        input.style.background = "#A2999E";
    });
}


function focusPois(input) {
    input.addEventListener('focusout', () => {
        input.style.background = '';
    });
}

function infoNappula() {
    alert("Tervetuloa oppimispäiväkirjaan! \r\n\r\nKlikkaamalla ETUSIVU näet kaikki lisätyt aiheet ja voit hakea aiheita.\r\n\r\nKlikkaamalla LISÄÄ UUSI AIHE voit lisätä uuden aiheen.");
}


function varmistaPoisto() {
    confirm("Haluatko varmasti poistaa aiheen?")
}


//Infolaatikon näyttö; piilotus/näyttö tehty JS:llä ilman CSS:ää.

const naytaInfolaatikko = document.querySelector(".nayta-info");
const piilotettuSisalto = document.querySelector(".piilotettu-sisalto");
piilotettuSisalto.style.display = "none";
naytaInfolaatikko.addEventListener("click", paljastaSisalto);


function paljastaSisalto() {
    //if (piilotettuSisalto.classList.contains("nayta-info")
    //) {
    //    piilotettuSisalto.classList.remove("nayta-info")
    //} else {
    //    piilotettuSisalto.classList.add("nayta-info")
    //}
    
    if (piilotettuSisalto.style.display === "none") {
        piilotettuSisalto.style.display = "block";
    } else {
        piilotettuSisalto.style.display = "none";
    }

}

//Näytä kaikki tiedot -laatikko näkyviin

const naytaLisatiedot = document.querySelector("#nayta-kaikki-tiedot");
//console.log(naytaLisatiedot);
const lisatietorivit = document.querySelectorAll(".lisatietotaulukko");
naytaLisatiedot.addEventListener("click", naytaKaikkiTiedot);


function naytaKaikkiTiedot() {
    for (const div of lisatietorivit) {
        if (div.classList.contains("piilota-sisalto")) {
            div.classList.remove("piilota-sisalto")
        } else {
            div.classList.add("piilota-sisalto");
        }

    }
}


//Puuttuvien tietojen tulostusten muuttaminen DOM:illa

const attribuutit = document.querySelectorAll('.attribuutti');

for (const div of attribuutit) {
    if (div.innerText == '') {
        div.classList.add("tieto-puuttuu", "text-small", "cursive");
        div.innerText = 'tieto puuttuu...';
    }
}

const pienetAttribuutit = document.querySelectorAll('.lisatieto-attribuutti');

for (const div of pienetAttribuutit) {
    if (div.innerText == '') {
        div.classList.add("tieto-puuttuu", "text-small", "cursive");
        div.innerText = '---';
    }
}
