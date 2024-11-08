function Redirect() {
    window.location = window.location.hostname + "/login";
}
function AppendChat(text, role) {

    if (role == "user") {
        var target = document.querySelector("#chat");
        target.innerHTML += "<article class=\"transparent \"><header><button class=\"circle transparent\"><h3>👨🏻</h3></button></header><p>"+text+"</p></article >";
    }
    else if (role == "jabir") {
        var target = document.querySelector("#chat");
        target.innerHTML += "<article class=\"transparent \"><header><button class=\"circle transparent\"><h3>Σ</h3></button></header><p>" + text + "</p></article >";

    }
    else {

    }
}
function LockChat() {
    document.querySelector("#btn_submit").disabled = true;
    document.querySelector("#add_button").disabled = true;
}

function UnLockChat() {
    document.querySelector("#btn_submit").disabled = false;
    document.querySelector("#add_button").disabled = false;
}

function CleanChat() {
    var target = document.querySelector("#chat");
    target.innerHTML = "";
}
//Test Only Functions
function Chat() {
    LockChat();
    AppendChat("Lorem ipsum dolor sit amet consectetur adipisicing elit. Dolorum est quia dolor necessitatibus facilis totam temporibus, repellendus culpa nihil reiciendis. Facilis accusamus laudantium qui amet sunt eligendi, consequuntur error sit.", "user");
    AppendChat("Lorem ipsum dolor sit amet consectetur adipisicing elit. Dolorum est quia dolor necessitatibus facilis totam temporibus, repellendus culpa nihil reiciendis. Facilis accusamus laudantium qui amet sunt eligendi, consequuntur error sit.", "jabir");
    UnLockChat();
}

