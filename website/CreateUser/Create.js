const $ = selector => document.querySelector(selector);
//clears failed entries in input
async function CreateUser() {
    const username = $("#Username").value;
    var U = false;
    var P = false;
    if (username == "") {
        $("#CreateUser_error").textContent = "Username is required.";
        return false;
    }
    else {
        const fetchPromise = fetch("http://localhost:5132/Players/"+ username, { method: "Post", mode: "cors", headers: { "Accept": "text/json", "Origin": "create.html" } });
        fetchPromise.then(response => {
            if (response.status == 406) {
                $("#CreateUser_error").textContent = "User Already Exists";
                $("#Username").value = "";
                return;
            }if (response.status == 200) {
                    $("#CreateUser_error").textContent = "";
                    alert("signed in");
                    localStorage.setItem("Username", username)
                    localStorage.setItem("Signed In", "true");
                    document.location = "menu.html";
                    return;      
            }
        })
    }
}
const Create = evt => {
    CreateUser();
};
document.addEventListener("DOMContentLoaded", () => {
        $("#CreateUser").addEventListener("click", Create);
        $("#Username").focus();
    });