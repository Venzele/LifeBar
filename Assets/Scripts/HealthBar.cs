using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Character _character;
    [SerializeField] private Slider _slider;
    [SerializeField] private float _speed;
    [SerializeField] private Text _text;

    private float _floatHealth;
    private string _infoHealth;

    private void Start()
    {
        _floatHealth = _character.Health;
    }

    private void Update()
    {
        ShowHealth();
        _slider.value = _floatHealth / _character.MaxHealth;
    }

    public void ShowHealth()
    {
        _floatHealth = Mathf.MoveTowards(_floatHealth, _character.Health, _speed * Time.deltaTime);
        _infoHealth = _character.Health.ToString() + "/" + _character.MaxHealth.ToString();
        _text.text = _infoHealth;
    }
}