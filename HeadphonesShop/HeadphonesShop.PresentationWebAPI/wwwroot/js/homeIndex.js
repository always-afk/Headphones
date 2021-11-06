const uri = 'api/Home/Index';
let items = [];

function getItems(){
    fetch(uri)
    .then(response => response.json())
    .then(data => _displayItems(data))
    .catch(error => console.error(error));
}

function _displayItems(data){
    const tBody = document.getElementById('items');
    data.forEach(item =>{
        let tr = tBody.insertRow();
        let td = tr.insertCell(0);
        let textNode = document.createTextNode(item)
        td.appendChild(textNode)
    })

    items = data;
}