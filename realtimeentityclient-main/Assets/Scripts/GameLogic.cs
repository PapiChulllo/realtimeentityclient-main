using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
    private List<GameObject> balloons = new List<GameObject>();
    private Sprite circleTexture;

    void Start()
    {
        NetworkClientProcessing.SetGameLogic(this);
    }

    public void SpawnNewBalloon(Vector2 screenPosition)
    {
        if (circleTexture == null)
            circleTexture = Resources.Load<Sprite>("Circle");

        GameObject balloon = new GameObject("Balloon");
        balloon.AddComponent<SpriteRenderer>();
        balloon.GetComponent<SpriteRenderer>().sprite = circleTexture;
        balloon.AddComponent<CircleClick>();
        balloon.AddComponent<CircleCollider2D>();

        Vector3 pos = Camera.main.ScreenToWorldPoint(new Vector3(screenPosition.x, screenPosition.y, 0));
        pos.z = 0;
        balloon.transform.position = pos;
        balloons.Add(balloon);
    }

    public void RemoveBalloon(int balloonIndex)
    {
        if (balloonIndex < 0 || balloonIndex >= balloons.Count) return;

        Destroy(balloons[balloonIndex]);
        balloons.RemoveAt(balloonIndex);
    }

    public int GetBalloonIndex(GameObject balloon)
    {
        return balloons.IndexOf(balloon);
    }
}
