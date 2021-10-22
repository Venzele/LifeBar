using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private float _maxHealth;
    [SerializeField] private float _health;

    private float _minHealth = 0;

    public float MaxHealth => _maxHealth;
    public float Health => _health;

    private void OnValidate()
    {
        if (_maxHealth <= _minHealth)
            _maxHealth = _minHealth + 1;

        if (_health > _maxHealth)
            _health = _maxHealth;
        else if (_health < _minHealth)
            _health = _minHealth;
    }

    public void ChangeHealth(float value)
    {
        float newValueHealth = _health + value;

        if(newValueHealth >= _minHealth && newValueHealth <= _maxHealth)
            _health = newValueHealth;
    }
}
