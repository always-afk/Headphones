uri = '../../api/CommonUser/';

async function getAllHeadphones() {
    fetch(uri + "GetAllHeadphones")
    .then(response => response.json())
    .then(data => _displayAllHeadphones(data))
    .catch(error => console.error("error"));
}

async function getHeadphones() {
    fetch(uri + "GetHeadphones?name="+encodeURIComponent((new URLSearchParams(location.search)).get('name')),{
        method: "GET",
        headers: {
            "Accept": "application/json",
            "Content-Type": "application/json"
        }
    })
    .then(response => response.json())
    .then(data => _displayHeadphones(data))
    .catch(error => console.error("error " + error));
}

async function ChangeFavorite(data){
    fetch(uri + "ChangeFavorite",{
        method: "POST",
        headers:{
            "Accept": "application/json",
            "Content-Type": "application/json"
        },
        body: JSON.stringify(data)
    })
    .catch(error => console.error("error " + error));
}

// async function removeFavorite(name)

function _displayAllHeadphones(data){
    const tBody = document.getElementById('table');
    data.headphones.forEach(headphones =>{
        let tr = tBody.insertRow();

        let td1 = tr.insertCell(0);
        let textNode1 = document.createTextNode(headphones.name);
        let elem1 = document.createElement("a");
        console.log(headphones.name)
        elem1.innerHTML = headphones.name;
        elem1.href ="/Pages/CommonUser/InfoHeadphones.html?name="+headphones.name;
        td1.appendChild(elem1);

        let td2 = tr.insertCell(1);
        let textNode2 = document.createTextNode(headphones.company.name);
        td2.appendChild(textNode2);

        let td3 = tr.insertCell(2);
        let textNode3 = document.createTextNode(headphones.design.name);
        td3.appendChild(textNode3);

        let td4 = tr.insertCell(3);
        let textNode4 = document.createTextNode(headphones.minFrequency)
        td4.appendChild(textNode4);

        let td5 = tr.insertCell(4);
        let textNode5 = document.createTextNode(headphones.maxFrequency);
        td5.appendChild(textNode5);
    });
}

function _displayHeadphones(data){

    headphonesName = document.getElementById("headphonesName");
    headphonesName.value = data.headphones.name;
    //headphonesName.readonly = true;

    companies = document.getElementById("companies");
    companies.value = data.headphones.company.name;

    designs = document.getElementById("designs");
    designs.value = data.headphones.design.name;

    minFrequency = document.getElementById("minFrequency");
    minFrequency.value = data.headphones.minFrequency;

    maxFrequency = document.getElementById("maxFrequency");
    maxFrequency.value = data.headphones.maxFrequency;

    isFavorite = document.getElementById("isFavorite");
    isFavorite.checked = data.isFavorite;
    isFavorite.addEventListener('change', function(){
        var dto = {
            name: document.getElementById("headphonesName").value,
            isFavorite: document.getElementById("isFavorite").checked
        }
        ChangeFavorite(dto)
    })
}