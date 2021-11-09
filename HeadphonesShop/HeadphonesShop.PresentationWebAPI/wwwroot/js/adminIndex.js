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
    fetch(uri + "GetHeadphones")
    .then(response => response.json())
    .then(data => console.log(JSON.stringify(data)))
    .catch(error => console.error("error"));
}



function _displayAllHeadphones(data){
    console.log(JSON.stringify(data))
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