var restTest = document.querySelector(".rest");
var graphTest = document.querySelector(".graph");
var restAPI = "https://localhost:5021/account";
var graphAPI = "https://localhost:5031/api/accounts";
var accountIdInput = document.querySelector("#accountId");
function requestGraphApi() {
    var accountId = parseInt(accountIdInput.value);
    var query = {
        query: "query accounts ($id:ULong!) {\n    account (id: $id) {\n      id,\n      accountName,\n      users  {\n        id\n        firstName\n        lastName\n      }\n    }\n  }",
        variables: {
            id: accountId
        }
    };
    var queryBody = JSON.stringify(query);
    var queryStr = queryBody.replace(/\\n/g, "\n").replace(/\\r/g, "\r");
    showQuery(queryStr, graphTest);
    fetch(graphAPI, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: queryBody
    })
        .then(function (response) { return response.json(); })
        .then(function (data) {
        displayOutput(data, graphTest);
    })["catch"](function (error) {
        console.error('Error:', error);
    });
}
function requestRestApi() {
    var accountId = parseInt(accountIdInput.value);
    var query = restAPI + "/" + accountId + "/with-users";
    showQuery(query, restTest);
    fetch(query)
        .then(function (response) { return response.json(); })
        .then(function (data) {
        displayOutput(data, restTest);
    })["catch"](function (error) {
        console.error('Error:', error);
    });
}
function displayOutput(data, test) {
    test.querySelector(".output").innerHTML = JSON.stringify(data, null, 2);
}
function showQuery(content, test) {
    test.querySelector(".query").innerHTML = content;
}
graphTest.querySelector("button").onclick = function () {
    requestGraphApi();
};
restTest.querySelector("button").onclick = function () {
    requestRestApi();
};
