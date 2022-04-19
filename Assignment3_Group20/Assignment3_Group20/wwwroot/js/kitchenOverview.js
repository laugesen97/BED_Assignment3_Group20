

var connection = new signalR.HubConnectionBuilder().withUrl("/kitchenOverviewHub").build();

connection.on("update", function () {
    window.location().reload();
});