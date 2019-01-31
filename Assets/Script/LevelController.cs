using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class LevelController : MonoBehaviour
{
    [SerializeField] private GameObject[] BombPrefabList;
    [SerializeField] private GameObject CharacterPrefab;
    [SerializeField] private GameObject WallPrefab;
    [SerializeField] private Vector3 MaxPos = new Vector3(5f, 10f, 5f);
    [SerializeField] private Vector3 MaxSize = new Vector3(1f, 1f, 1f);

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
            CreateWall();
        }
    }


    private BombController CreateBomb()
    {
        var pos = new Vector3(
            Random.Range(-MaxPos.x, MaxPos.x),
            MaxPos.y,
            Random.Range(-MaxPos.z, MaxPos.z));

        var prefab = BombPrefabList[Random.Range(0, BombPrefabList.Length)];

        var newItem = Instantiate(prefab, transform);
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

    private WallController CreateWall()
    {
        var pos = new Vector3(
            Random.Range(-MaxPos.x, MaxPos.x),
            Random.Range(MaxSize.y, MaxPos.y/2f),
            Random.Range(-MaxPos.z, MaxPos.z));

        var size = new Vector3(
            Random.Range(0.1f, MaxSize.x),
            Random.Range(0.1f, MaxSize.y),
            Random.Range(0.1f, MaxSize.z));

        var rot = Random.insideUnitSphere * 3f;

        var newItem = Instantiate(WallPrefab, transform);
        newItem.transform.position = pos;
        newItem.transform.localScale = size;

        newItem.transform.Rotate(rot);

        return newItem.GetComponent<WallController>();
    }
}
