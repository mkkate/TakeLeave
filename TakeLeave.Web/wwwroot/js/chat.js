"use strict";

$(function () {
    var url = '/Chat/GetUsers';
    $.get(url, function (data) {
        $("#userListContainer").html(data);
    });
});

var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

document.getElementById("sendButton").disabled = true;

//connection.on("ReceiveMessage", function (user, message) {
//    var li = document.createElement("li");
//    document.getElementById("messagesList").appendChild(li);
//    li.textContent = `${user} says ${message}`;
//});

connection.start().then(function () {
    document.getElementById("sendButton").disabled = false;
}).catch(function (err) {
    return console.error(err.toString());
});

document.getElementById("sendButton").addEventListener("click", function (event) {
    var user = document.getElementById("userInput").value;
    var message = document.getElementById("messageInput").value;
    connection.invoke("SendMessage", user, message).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});

connection.on("ReceiveMessage", function (senderId, senderFirstName, senderLastName, message) {
    var chatBox = $("#chatBox_" + senderId);
    if (chatBox.length === 0) {
        openChatBox(senderId, senderFirstName, senderLastName);
    }
    var messageElement = $('<div class="receiver-side"></div>').text(message);
    chatBox.find(".chat-box-body").append(messageElement);
});

$(document).on('click', '.user-item', function () {
    var userId = $(this).data('userid');
    var userFirstName = $(this).data('user-first-name');
    var userLastName = $(this).data('user-last-name');
    openChatBox(userId, userFirstName, userLastName);
});

function openChatBox(userId, userFirstName, userLastName) {
    var chatBox = $("#chatBox_" + userId);
    if (chatBox.length == 0) {
        chatBox = $('<div class="chat-box" id="chatBox_' + userId + '">' +
            `<div class="chat-box-header">${userFirstName} ${userLastName}` +
            `<span class="close-button" onclick="closeChatBox(${userId})">×</span>` +
            '</div>' +
            '<div class="chat-box-body">' +
            '</div>' +
            '<div class="chat-box-footer">' +
            '<input type="text" class="chat-input" />' +
            `<button onclick="sendMessage(${userId})">Send</button>` +
            '</div>' +
            '</div>');
        $('body').append(chatBox);
    }
    chatBox.show();
    selectUser(userId);
}

async function sendMessage(userId) {
    var message = $("#chatBox_" + userId + " .chat-input").val();
    if (connection.state === signalR.HubConnectionState.Connected) {
        try {
            await connection.invoke("SendMessage", userId.toString(), message).catch(function (err) {
                return console.error(err.toString());
            });
            selectUser(userId);
            $("#chatBox_" + userId + " .chat-input").val('');
        } catch (err) {
            console.error("Error sending message: ", err.toString());
        }
    } else {
        console.error("Connection is not in the 'Connected' state.");
    }
}

function selectUser(userId) {
    console.log("Receiver id = " + userId);
    // Load previous messages
    fetch(`/Chat/GetMessages?receiverId=${userId}`).then(response => response.json()).then(messages => {
        var chatBoxBody = $("#chatBox_" + userId + " .chat-box-body");
        chatBoxBody.empty();
        messages.forEach(message => {
            var userRole = message.senderId === userId ? "receiver-side" : "sender-side";
            console.log(userRole + ' ' + message.receiverId);
            const date = new Date(message.timestamp);
            const formattedDate = date.toLocaleDateString("en-UK", {
                day: '2-digit',
                month: '2-digit',
                year: '2-digit',
            }) + ' ' + date.toLocaleTimeString("en-UK", {
                hour: '2-digit',
                minute: '2-digit',
                hour12: false
            });
            var msg = $(`<div class="${userRole}">` +
                `<a data-toggle="tooltip" title="${formattedDate}">` +
                `${message.senderId}->${message.receiverId}: ${message.content}` +
                '</a></div>');
            chatBoxBody.append(msg);
        });

        chatBoxBody.find('[data-toggle="tooltip"]').tooltip();
    });
}

function closeChatBox(userId) {
    $("#chatBox_" + userId).remove();
}
