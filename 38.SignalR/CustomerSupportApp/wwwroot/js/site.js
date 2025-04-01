const connection = new signalR.HubConnectionBuilder()
    .withUrl("/chatHub")
    .build();

connection.start().catch(err => console.error("Connection failed: " + err.toString()));

connection.on("ReceiveMessage", (user, message) => {
    const username = user.split('@')[0];
    const li = document.createElement("li");
    li.classList.add("chat-bubble");
    li.innerHTML = `<strong>${username}:</strong> <span>${message}</span>`;

    document.getElementById("messagesList").appendChild(li);
    li.classList.add("fade-in");
    document.getElementById("messagesList").scrollTop = document.getElementById("messagesList").scrollHeight;
});

function sendMessage() {
    const messageInput = document.getElementById("messageInput");
    const message = messageInput.value.trim();

    if (message === "") {
        messageInput.classList.add("shake");
        setTimeout(() => messageInput.classList.remove("shake"), 300);
        return;
    }

    connection.invoke("SendMessage", message).catch(err => console.error(err.toString()));
    messageInput.value = "";
}