using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Character : MonoBehaviour
{
    [SerializeField] private float _maxHealth;
    [SerializeField] private float _health;
    [SerializeField] private UnityEvent _changedHealth;

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

    public void TakeHeal(float heal)
    {
        float newValueHealth = _health + heal;

        if(newValueHealth <= _maxHealth)
        {
            _health = newValueHealth;
            _changedHealth?.Invoke();
        }
    }

    public void TakeDamage(float damage)
    {
        float newValueHealth = _health - damage;

        if (newValueHealth >= _minHealth)
        {
            _health = newValueHealth;
            _changedHealth?.Invoke();
        }
    }
}
