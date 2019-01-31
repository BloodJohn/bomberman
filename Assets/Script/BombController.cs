using UnityEngine;

public class BombController : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log($"OnCollision {collision.collider.name}");

        Destroy(gameObject, 1f);
    }
}
