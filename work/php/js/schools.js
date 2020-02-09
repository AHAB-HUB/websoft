function getMunicipalities() {

  const proxyUrl = "https://cors-anywhere.herokuapp.com/";
  const url = "https://api.scb.se/UF0109/v2/skolenhetsregister/sv/kommun";

  fetch(proxyUrl + url)
    .then((response) => {
      return response.json();
    })
    .then((myJson) => {
      var jsonKommuner = myJson.Kommuner;
      var counter = jsonKommuner.length;
      list = document.getElementById('select-element');

      for (var i = 0; i < counter; i++) {
        list.options[i] = new Option(jsonKommuner[i].Namn + " " + jsonKommuner[i].Kommunkod, jsonKommuner[i].Kommunkod);
      }
    });
};

function getSchools(municipalityNr) {
  const proxyUrl = "https://cors-anywhere.herokuapp.com/";
  const url = "https://api.scb.se/UF0109/v2/skolenhetsregister/sv/kommun/" + municipalityNr;

  fetch(proxyUrl + url)
    .then((response) => {
      return response.json();
    })
    .then((myJson) => {
      var jsonSchool = myJson.Skolenheter;
      var counter = jsonSchool.length;
      var table = "<tr><th>Municipality code</th><th>Pe.Org.Nr</th><th>School code</th><th>School name</th></tr>";

      for (i = 0; i < counter; i++) {
        table +=
          "<tr><td>" +
          jsonSchool[i].Kommunkod +
          "</td><td>" +
          jsonSchool[i].PeOrgNr +
          "</td><td>" +
          jsonSchool[i].Skolenhetskod +
          "</td><td>" +
          jsonSchool[i].Skolenhetsnamn;
        "</td></tr>";
      }
      document.getElementById("table").innerHTML = table;
    });
}
