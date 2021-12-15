"use strict";


var connection = new signalR.HubConnectionBuilder().withUrl("/messagesPlane").build();
var connectionFlight = new signalR.HubConnectionBuilder().withUrl("/FlightHub").build();

connection.start().then(function () {
    console.log("signalR connect");
}).catch(function (err) {
    return console.error(err.toString());
});

connection.on("onMessageReceived", function (event) {
    console.log(event);
});



connectionFlight.start().then(function () {
    console.log("flights connect");
}).catch(function (err) {
    return console.error(err.toString());
});

connectionFlight.on("onFlightReceived", function (event) {

    let myList = document.querySelectorAll(".btn");
    let t = ", Flight number: "
    for (let i = 0; i < myList.length; i++){
        let j = i + 1;
        myList[i].textContent = "Leg number: " + j + t + event[i].flightNumber;
    }
});