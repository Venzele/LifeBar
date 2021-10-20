using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeHealth : MonoBehaviour
{
    [SerializeField] HealthBar _health;
    [SerializeField] int _direction;

    public void GiveValueHealth()
    {
        _health.ChangeHealth(_direction);
    }
}
