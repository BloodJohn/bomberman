using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField] private float Health = 100;
    [SerializeField] private TextMesh HpText;

    private void Start()
    {
        UpdateHp();
    }


    private void UpdateHp()
    {
        HpText.text = $"{Health} hp";
    }

    public void AddDamage(float power)
    {
        Health -= power;

        if (Health <= 0f)
        {
            Destroy(gameObject, 1f);
            HpText.text = $"dead %(";
        }
        else
        {
            UpdateHp();
        }
    }
}
