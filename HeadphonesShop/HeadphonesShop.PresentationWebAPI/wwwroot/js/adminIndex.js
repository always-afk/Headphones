const uri = '../../api/Admin/';
let items = [];

//function getItems(){
//    fetch(uri)
//    .then(response => response.json())
//    .then(data => _displayItems(data))
//    .catch(error => console.error(error));
//}

async function getAllHeadphones() {
    fetch(uri + "GetAllHeadphones")
    .then(response => response.json())
    .then(data => _displayAllHeadphones(data))
    .catch(error => console.error("error"));
}

async function getHeadphones() {
    fetch(uri + "GetHeadphones",{
        method: "GET",
        headers: {
            "Accept": "application/json",
            "Content-Type": "application/json",
            "name": escape((new URLSearchParams(location.search)).get('name'))
        }
    })
    .then(response => response.json())
    .then(data => _displayHeadphones(data))
    .catch(error => console.error("error " + error));
}

async function updateHeadphones(){
    headphones = {
        name: document.getElementById("headphonesName").value,
        minFrequency: document.getElementById("minFrequency").value,
        maxFrequency: document.getElementById("maxFrequency").value,
        design: {
            name: document.getElementById("designs").value
        },
        company: {
            name: document.getElementById("companies").value
        }
    }
    console.log(JSON.stringify(headphones))
    fetch(uri + "UpdateHeadphones",{
        method: "PUT",
        headers: {
            "Accept": "application/json",
            "Content-Type": "application/json",
        },
        body: JSON.stringify(headphones)
    })
    .then(response => response.json())
    .then(data => window.location.replace(data))
    .catch(error => console.error("error"));
}

async function deleteHeadphones(){
    headphonesName = document.getElementById("headphonesName").value;
    fetch(uri + "DeleteHeadphones",{
        method: "DELETE",
        headers: {
            "Accept": "application/json",
            "Content-Type": "application/json",
        },
        body: JSON.stringify(headphonesName)
    })
    .then(response => response.json())
    .then(data => window.location.replace(data))
    .catch(error => console.error("error " + error));
}

function _displayAllHeadphones(data){
    const tBody = document.getElementById('table');
    data.headphones.forEach(headphones =>{
        let tr = tBody.insertRow();

        let td1 = tr.insertCell(0);
        let textNode1 = document.createTextNode(headphones.name);
        let elem1 = document.createElement("a");
        elem1.innerHTML = headphones.name;
        elem1.href ="/Pages/Admin/InfoHeadphones.html?name="+headphones.name;
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

    companies = document.getElementById("companies")
    companies.innerHTML = '';
    data.companies.forEach(company =>{
        comp = document.createElement("option");
        comp.value = company.name;
        comp.innerHTML = company.name;
        companies.appendChild(comp);
        if(company.name === data.headphones.company.name){
            comp.selected = true;
        }
    })

    designs = document.getElementById("designs")
    designs.innerHTML = '';
    data.designs.forEach(design =>{
        des = document.createElement("option");
        des.value = design.name;
        des.innerHTML = design.name;
        designs.appendChild(des);
        if(design.name === data.headphones.design.name){
            des.selected = true;
        }
    })

    minFrequency = document.getElementById("minFrequency");
    minFrequency.value = data.headphones.minFrequency;

    maxFrequency = document.getElementById("maxFrequency");
    maxFrequency.value = data.headphones.maxFrequency;
}