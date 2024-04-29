const $ = selector => document.querySelector(selector);

async function DeleteUser() {
    const username = localStorage.getItem("Username");
    if (confirm("Are you sure you want to delete your account") == false) {
        return;
    }else{
        const fetchPromise = fetch("http://localhost:5132/players/" + username, { method: "Delete", mode: "cors", headers: { "Accept": "text/json", "Origin": "Menu.html" } });
        fetchPromise.then(response => {
            if (response.status != 200) {
                alert("Internal server error");
                return;
            } if (response.status == 200) {
                localStorage.setItem("Signed In", "flase");
                localStorage.removeItem("Username")
                document.location = "title.html";
                return;
            }
        })
    }
}
const Delete = evt => {
    DeleteUser();
};
document.addEventListener("DOMContentLoaded", () => {
    setInterval((check) => {
        if (localStorage.getItem("Signed In") == "false") {
            document.location = "title.html";
           clearInterval(check);
        }
    }, 1);
    $("#Welcome").textContent += localStorage.getItem("Username");
    $("#Sign_out").addEventListener("click", () => {
        localStorage.setItem("Signed In", "false");
        localStorage.removeItem("Username");
        document.location = "sign.html";
    })
    $("#delete").addEventListener("click", Delete)
    $("#Load").addEventListener("click", () => {
        alert("element currently does nothing");
    })
    $("#Start_new").addEventListener("click", () => {
        alert("element currently does nothing");
    })

})