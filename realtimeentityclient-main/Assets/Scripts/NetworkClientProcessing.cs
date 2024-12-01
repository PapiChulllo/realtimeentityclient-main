using UnityEngine;

static public class NetworkClientProcessing
{
    static NetworkClient networkClient;
    static GameLogic gameLogic;

    static public void ReceivedMessageFromServer(string msg, TransportPipeline pipeline)
    {
        string[] csv = msg.Split(',');
        int signifier = int.Parse(csv[0]);

        if (signifier == ServerToClientSignifiers.SpawnBalloon)
        {
            float x = float.Parse(csv[1]);
            float y = float.Parse(csv[2]);
            gameLogic.SpawnNewBalloon(new Vector2(x, y));
        }
        else if (signifier == ServerToClientSignifiers.BalloonPopped)
        {
            int balloonIndex = int.Parse(csv[1]);
            gameLogic.RemoveBalloon(balloonIndex);
        }
    }

    static public void SendMessageToServer(string msg, TransportPipeline pipeline)
    {
        networkClient.SendMessageToServer(msg, pipeline);
    }

    static public void ConnectionEvent()
    {
        UnityEngine.Debug.Log("Network Connection Event!");
    }

    static public void DisconnectionEvent()
    {
        UnityEngine.Debug.Log("Network Disconnection Event!");
    }

    static public NetworkClient GetNetworkedClient()
    {
        return networkClient;
    }

    static public void SetNetworkedClient(NetworkClient NetworkClient)
    {
        networkClient = NetworkClient;
    }

    static public void SetGameLogic(GameLogic GameLogic)
    {
        gameLogic = GameLogic;
    }
}

public enum TransportPipeline
{
    NotIdentified,
    ReliableAndInOrder,
    FireAndForget
}

static public class ClientToServerSignifiers
{
    public const int BalloonPopped = 1;
}

static public class ServerToClientSignifiers
{
    public const int SpawnBalloon = 1;
    public const int BalloonPopped = 2;
}
