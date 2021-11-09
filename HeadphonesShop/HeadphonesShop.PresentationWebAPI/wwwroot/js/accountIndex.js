const uri = "../api/Account/"

function signIn(){
    const email = document.getElementById("email").value;
    const password = document.getElementById("password").value;

    const user = {
        user: {
            login: email,
            password: password
        }
        
    };

    fetch(uri + "SignIn",{
        method: "POST",
        headers: {
            "Accept": "application/json",
            "Content-Type": "application/json"
        },
        body: JSON.stringify(user)
    })
    .then(response => response.json())
    .then(data => window.location.replace(data))
    .catch(error => console.error("error"));
}

function signInGoogle(){
    fetch(uri + "SignInGoogle",{
        method: "POST",
        headers: {
            "Accept": "application/json",
            "Content-Type": "application/json"
        }
    })
    .then(response => response.json())
    .then(data => console.log(data))
    .catch(error => console.error(error))
}