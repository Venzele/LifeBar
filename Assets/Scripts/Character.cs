using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Character : MonoBehaviour
{
    [SerializeField] private float _maxHealth;
    [SerializeField] private float _health;

    private float _minHealth = 0;

    public float MaxHealth => _maxHealth;
    public float Health => _health;

    public event UnityAction ChangedHealth;

    private void OnValidate()
    {
        if (_maxHealth <= _minHealth)
            _maxHealth = _minHealth + 1;

        _health = Mathf.Clamp(_health, _minHealth, _maxHealth);
    }

    public void TakeHeal(float heal)
    {
        if (heal > 0)
        {
            _health = Mathf.Clamp(_health + heal, _minHealth, _maxHealth);
            ChangedHealth?.Invoke();
        }
    }

    public void TakeDamage(float damage)
    {
        if (damage > 0)
        {
            _health = Mathf.Clamp(_health - damage, _minHealth, _maxHealth);
            ChangedHealth?.Invoke();
        }
    }
}
