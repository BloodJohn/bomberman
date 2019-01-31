using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class LevelController : MonoBehaviour
{
    [SerializeField] private GameObject BombPrefab;
    [SerializeField] private GameObject CharacterPrefab;
    [SerializeField] private Vector3 maxPos = new Vector3(5f, 0f, 5f);

    private const float delayDropBomb = 2f;
    private float timer;

    void Start()
    {
        Random.InitState(DateTime.Now.Second);
        CreateCharacter();
    }

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
            maxPos.y,
            Random.Range(-maxPos.z, maxPos.z));

        var newItem = Instantiate(BombPrefab, transform);

        newItem.transform.position = pos;

        return newItem.GetComponent<BombController>();
    }

    private CharacterController CreateCharacter()
    {
        var pos = Vector3.up;

        var newItem = Instantiate(CharacterPrefab, transform);

        newItem.transform.position = pos;

        return newItem.GetComponent<CharacterController>();
    }
}
