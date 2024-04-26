const $ = selector => document.querySelector(selector);
//clears failed entries in input
async function CheckAll() {
    const username = $("#Username").value;
    if (username == "") {
        $("#SignIn_error").textContent = "Username is required.";
        return false;
    }
    else {
        const fetchPromise = fetch("http://localhost:5132/players/" + username, { method: "GET", mode: "cors", headers: { "Accept": "text/json", "Origin": "sign.html" } });
        fetchPromise.then(response => {
            if (response.status == 204) {
                $("#SignIn_error").textContent = "UserName does not exist";
                $("#Username").value = "";
                return;
            } if (response.status == 200) {  
                $("#SignIn_error").textContent = "";
                alert("signed in");
                localStorage.setItem("Username", username)
                localStorage.setItem("Signed In", "true");
                document.location = "menu.html";
                return;
            }
            })
    }
}
const SignIn = evt => {
    CheckAll();
};
document.addEventListener("DOMContentLoaded", () => {
    if (localStorage.getItem("Signed In") == "true") {
        document.location = "menu.html";
    }
        $("#Sign_In").addEventListener("click", SignIn);
        $("#Username").focus();
    });