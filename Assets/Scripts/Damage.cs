using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    [SerializeField] int damage = 10;

    public int GetDamage() => damage;

    public void Hit() => Destroy(gameObject);

}
