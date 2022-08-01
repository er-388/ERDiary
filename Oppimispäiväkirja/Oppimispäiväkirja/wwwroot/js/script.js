//const { each } = require("jquery");

function kohdistus(input) {
    input.addEventListener("focusin", () => {
        input.style.background = "#A2999E";
        //console.log('tässä!')
    });
}


function focusPois(input) {
    input.addEventListener('focusout', () => {
        input.style.background = '';
        //console.log('poisto!')
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

const naytaLisatiedotNappi = document.querySelector("#nayta-kaikki-tiedot");
//const lisatietorivit = document.querySelectorAll(".kaikki-tiedot-kytkin");
const lisatietorivit = document.getElementsByClassName("kaikki-tiedot-kytkin");
naytaLisatiedotNappi.addEventListener("click", naytaKaikkiTiedot);

function naytaKaikkiTiedot() {
    for (const div of lisatietorivit) {
        if (div.style.display === "none") {
            div.style.display = "block";
        } else {
            div.style.display = "none";
        }
        //div.style.display = 'none';
    }
        
}

//Tulostusten muuttaminen DOM:illa

const testiin = document.querySelectorAll('.attribuutti');

for (const div of testiin) {
    if (div.innerText == '') {
        div.innerText = 'tieto puuttuu...';
    }
}

