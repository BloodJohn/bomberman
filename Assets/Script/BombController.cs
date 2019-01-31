using UnityEngine;

public class BombController : MonoBehaviour
{
    [SerializeField] private float Power = 10f;

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log($"OnCollision {collision.collider.gameObject.name}");

        var hitObject = collision.collider.gameObject;

        var character = hitObject.GetComponent<CharacterController>();
        if (character != null)
        {
            character.AddDamage(Power);
        }


        Destroy(gameObject, 1f);
    }
}
