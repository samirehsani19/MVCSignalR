var EslSignalR = {};
(function (eslSignalR) {
    ///NotificationHub
    const connection = new signalR.HubConnectionBuilder()
        .withUrl("/NotificationHub")
        .configureLogging(signalR.LogLevel.Information)
        .withAutomaticReconnect()
        .build();

    eslSignalR.StartAsync = async function () {
        //start connection
        try {
            await connection.start().then(() => {
                console.log('Connection started');
                eslSignalR.GetConnectedResponse();
            });
            return connection;
        } catch (err) {
            alert('failed');
            console.log(`Failed to connect Error = ${err}. Trying to reconnect`);
            setTimeout(async () => await EslSignalR.StartAsync());
        }
    }

    // onclose try to connect again
    connection.onclose(async () => {
        console.log(`SignalR connection is closed. Trying to start connection`);
        await eslSignalR.StartAsync();
    });

    console.log('connection = ' +  connection);
    //On reconnecting
    connection.onreconnecting(error => {
        console.log(`SignalR is trying to reconnect ${error}`);
    });

    //On connected
    connection.onreconnected(connectionId => {
        console.log(`SignalR is connected again`);
    });

    //Subscribe to category
    eslSignalR.SubscribeToCategory = function (categoryName) {
        console.log(`a client joined category ${categoryName}`);
        connection.invoke("SubscribeToCategory", categoryName).catch(function (err) {
            return console.error(err.toString());
        });
    }

    //Get connectedResponse from HUB
    eslSignalR.GetConnectedResponse = function () {
        connection.on("GetConnectedResponse", connectionId => {
            console.log(`ConnectionResponse received: ConnectionID=  ${connectionId}`);
            eslSignalR.SubscribeToCategory("samir");
        });
    }

}(EslSignalR));

