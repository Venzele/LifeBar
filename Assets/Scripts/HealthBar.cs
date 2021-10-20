using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private float _maxHealth;
    [SerializeField] private float _health;
    [SerializeField] private float _step;
    [SerializeField] private float _speed;

    private float _minHealth = 0;
    private float _floatHealth;
    private string _infoHealth;

    public float FloatHealth => _floatHealth;
    public float MaxHealth => _maxHealth;
    public string InfoHealth => _infoHealth;

    public void Start()
    {
        _floatHealth = _health;
    }

    public void OnValidate()
    {
        if (_maxHealth <= _minHealth)
            _maxHealth = _minHealth + 1;

        if (_health > _maxHealth)
            _health = _maxHealth;
        else if (_health < _minHealth)
            _health = _minHealth;
    }

    public void ChangeHealth(int direction)
    {
        float newValueHealth = _health + _step * direction;

        if(newValueHealth >= _minHealth && newValueHealth <= _maxHealth)
            _health = newValueHealth;
    }

    public void ChangeFloatHealth()
    {
        if(_floatHealth != _health)
            _floatHealth = Mathf.MoveTowards(_floatHealth, _health, _speed * Time.deltaTime);
            _infoHealth = _health.ToString() + "/" + _maxHealth.ToString();
    }
}
