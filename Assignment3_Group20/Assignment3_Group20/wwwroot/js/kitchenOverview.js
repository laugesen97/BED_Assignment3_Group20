

var connection = new signalR.HubConnectionBuilder().withUrl("/kitchenOverviewHub").build();

connection.on("Update", function () {
    console.log("on");
    window.location().reload();
});

connection.start().then(function() {
    console.log("connected");
});