const restTest = document.querySelector(".rest");
const graphTest = document.querySelector(".graph");
const restAPI = "https://localhost:5021/account";
const graphAPI = "https://localhost:5031/api/accounts";
const accountIdInput = document.querySelector("#accountId") as HTMLInputElement;

function requestGraphApi() {
    const accountId = parseInt(accountIdInput.value);

    const query = {
        query: `query accounts ($id:ULong!) {
    account (id: $id) {
      id,
      accountName,
      users  {
        id
        firstName
        lastName
      }
    }
  }`, variables: {
            id: accountId
        }
    };

    const queryBody = JSON.stringify(query)
    const queryStr = queryBody.replace(/\\n/g, "\n").replace(/\\r/g, "\r");
    showQuery(queryStr, graphTest);

    fetch(graphAPI, {
        method: 'POST', // or 'PUT'
        headers: {
            'Content-Type': 'application/json',
        },
        body: queryBody,
    })
        .then(response => response.json())
        .then(data => {
            displayOutput(data, graphTest);
        })
        .catch((error) => {
            console.error('Error:', error);
        });
}


function requestRestApi() {
    const accountId = parseInt(accountIdInput.value);
    const query = `${restAPI}/${accountId}/with-users`;
    showQuery(query, restTest);

    fetch(query)
        .then(response => response.json())
        .then(data => {
            displayOutput(data, restTest);
        })
        .catch((error) => {
            console.error('Error:', error);
        });
}


function displayOutput(data: any, test: Element) {
    test.querySelector(".output").innerHTML = JSON.stringify(data, null, 2);
}

function showQuery(content: string, test: Element) {
    test.querySelector(".query").innerHTML = content;
}

graphTest.querySelector("button").onclick = () => {
    requestGraphApi();
};


restTest.querySelector("button").onclick = () => {
    requestRestApi();
};
