$(function () {
    // Declare a proxy to reference the hub.
    var chat = $.connection.chatHub;
    console.log(chat);

    // Create a function that the hub can call to broadcast messages.
    chat.client.broadcastMessage = function (name, message) {
        console.log(name);
        // Html encode display name and message.
        var encodedName = $('<div />').text(name).html();
        var encodedMsg = $('<div />').text(message).html();
        // Add the message to the page.
        $('#thread').append('<p><strong>' + encodedName
        + '</strong>:&nbsp;&nbsp;' + encodedMsg + '</p>');
    };
    // Get the user name and store it to prepend to messages.
    $('#displayname').text(prompt('Enter your name:', ''));

    $('#thread').append('<p><strong> Hi! ' + $('#displayname').text()
    + '</strong></p>');

    // Set initial focus to message input box.
    $('#message').focus();
    // Start the connection.
    $.connection.hub.start().done(function () {
        $("#message").keypress(function (e) {
            var code = (e.keyCode ? e.keyCode : e.which);
            if (code == 13) {
                // Call the Send method on the hub.
                chat.server.send($('#displayname').text(), $('#message').val());
                // Clear text box and reset focus for next comment.
                $('#message').val('').focus();
            }
        });
    });



});