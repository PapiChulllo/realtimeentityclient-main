using UnityEngine;

public class CircleClick : MonoBehaviour
{
    void OnMouseDown()
    {
        int balloonIndex = FindObjectOfType<GameLogic>().GetBalloonIndex(gameObject);
        if (balloonIndex >= 0)
        {
            NetworkClientProcessing.SendMessageToServer($"{ClientToServerSignifiers.BalloonPopped},{balloonIndex}", TransportPipeline.ReliableAndInOrder);
            Destroy(gameObject);
        }
    }
}
