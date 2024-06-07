"use strict";

$(function () {
    var url = '/Chat/GetUsers';
    $.get(url, function (data) {
        $("#userListContainer").html(data);
    });
});

var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

connection.start().then().catch(function (err) {
    return console.error(err.toString());
});

connection.on("ReceiveMessage", function (senderId, senderFirstName, senderLastName, message) {
    var chatBox = $("#chatBox_" + senderId);
    if (chatBox.length === 0) {
        openChatBox(senderId, senderFirstName, senderLastName);
    }
    var messageElement = $('<div class="receiver-side"></div>').text(message);
    chatBox.find(".chat-box-body").append(messageElement);
    scrollToLatestMessage(senderId);
});

$(document).on('click', '.user-item', function () {
    var userId = $(this).data('userid');
    var userFirstName = $(this).data('user-first-name');
    var userLastName = $(this).data('user-last-name');
    openChatBox(userId, userFirstName, userLastName);
});

function openChatBox(receiverId, receiverFirstName, receiverLastName) {
    var chatBox = $("#chatBox_" + receiverId);
    if (chatBox.length == 0) {
        chatBox = $('<div class="chat-box" id="chatBox_' + receiverId + '">' +
            `<div class="chat-box-header">${receiverFirstName} ${receiverLastName}` +
            `<span class="close-button" onclick="closeChatBox(${receiverId})">×</span>` +
            '</div>' +
            '<div class="chat-box-body">' +
            '</div>' +
            '<div class="chat-box-footer">' +
            '<input type="text" class="chat-input" />' +
            `<button onclick="sendMessage(${receiverId})">Send</button>` +
            '</div>' +
            '</div>');
        $('body').append(chatBox);
    }
    chatBox.show();
    selectUser(receiverId);
}

async function sendMessage(receiverId) {
    var message = $("#chatBox_" + receiverId + " .chat-input").val();
    if (connection.state === signalR.HubConnectionState.Connected) {
        try {
            await connection.invoke("SendMessage", receiverId.toString(), message).catch(function (err) {
                return console.error(err.toString());
            });
            selectUser(receiverId);
            $("#chatBox_" + receiverId + " .chat-input").val('');
        } catch (err) {
            console.error("Error sending message: ", err.toString());
        }
    } else {
        console.error("Connection is not in the 'Connected' state.");
    }
}

function selectUser(receiverId) {
    // Load previous messages
    fetch(`/Chat/GetMessages?receiverId=${receiverId}`).then(response => response.json()).then(messages => {
        var chatBoxBody = $("#chatBox_" + receiverId + " .chat-box-body");
        chatBoxBody.empty();
        messages.forEach(message => {
            var userRole = message.senderId === receiverId ? "receiver-side" : "sender-side";
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
                `${message.content}` +
                '</a></div>');
            chatBoxBody.append(msg);
        });

        chatBoxBody.find('[data-toggle="tooltip"]').tooltip();
        scrollToLatestMessage(receiverId);
    });
}

function closeChatBox(userId) {
    $("#chatBox_" + userId).remove();
}

function scrollToLatestMessage(userId) {
    var chatBoxBody = $("#chatBox_" + userId + " .chat-box-body");
    chatBoxBody.scrollTop(chatBoxBody.prop("scrollHeight"));
}
