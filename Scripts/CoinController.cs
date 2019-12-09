using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    private float speed = 123.4f;

    private GameObject coin;
    private void Start()
    {
        coin = this.gameObject;
    }

    void Update()
    {
        float f = Time.deltaTime * speed;
        coin.transform.Rotate(0, f, 0, Space.World);
        coin.transform.Translate(0, Mathf.Sin(Time.realtimeSinceStartup * 5) * 0.02f, 0, Space.World);
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.name.Equals("Paper_Boat_01"))
        {
            ScoreCounter.score++;
            Destroy(coin);
        }
    }
}
