const $ = selector => document.querySelector(selector);
//clears failed entries in input
function CEonFail(U, P) {
    if (U == true) {
        $("#Username").value = "";
        $("#Username").focus();
    } if (P == true) {
        $("#Password").value = "";
        $("#PasswordV").value = "";
        $("#Password").focus();
    }
}
async function CheckAll() {
    const password = $("#Password").value;
    const passwordV = $("#PasswordV").value;
    const username = $("#Username").value;
    var U = false;
    var P = false;
    if (username == "") {
        $("#CreateUser_error").textContent = "Username is required.";
        return false;
    }
    else {
        const fetchPromise = fetch("http://localhost:5132/players/" + username, { method: "Get", mode: "cors", headers: { "Accept": "text/json", "Origin": "create.html" } });
        fetchPromise.then(response => {
            if (response.status == 200) {
                $("#CreateUser_error").textContent = "User Already Exists";
                U = true;
                CEonFail(U, P);
                $("#Sign_In").textContent = "Check Username";
                return;
            }if (response.status == 204) {
                $("#SignIn_error").textContent = "";
                    if (password == "") {
                    $("#SignIn_error").textContent = "password required";
                    return;
                    }
                    else if (passwordV == "") {
                    $("#SignIn_error").textContent = "Please verify password";
                    return;
                    }else if (password != passwordV) {
                    $("#SignIn_error").textContent = "Passwords must be the same";
                    P = true;
                    CEonFail(U, P);
                    return;
                    }else{
                    $("#SignIn_error").textContent = "";
                    alert("signed in");
                    localStorage.setItem("Username", username)
                    localStorage.setItem("Signed In", "true");
                    document.location = "menu.html";
                        return;
                    }
            }
        })
    }
}
const SignIn = evt => {
    CheckAll();
};
document.addEventListener("DOMContentLoaded", () => {
        $("#CreateUser").addEventListener("click", SignIn);
        $("#Username").focus();
    });