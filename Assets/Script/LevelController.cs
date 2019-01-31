using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class LevelController : MonoBehaviour
{
    public GameObject BombPrefab;
    private const float heightDropBomb = 5f;
    private readonly Vector3 maxPos = new Vector3(5f, 0f, 5f);

    private const float delayDropBomb = 2f;
    private float timer;

    void Start()
    {
        Random.InitState(DateTime.Now.Second);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > delayDropBomb)
        {
            timer = 0f;
            CreateBomb();
        }
    }


    private BombController CreateBomb()
    {
        var pos = new Vector3(
            Random.Range(-maxPos.x, maxPos.x),
            heightDropBomb,
            Random.Range(-maxPos.y, maxPos.y));

        var newItem = Instantiate(BombPrefab, transform);

        newItem.transform.position = pos;

        return newItem.GetComponent<BombController>();
    }
}
