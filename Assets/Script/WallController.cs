using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallController : MonoBehaviour
{
    public void AddDamage(float power)
    {
        Destroy(gameObject, 2f);
    }
}
