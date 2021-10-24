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

    private string _infoHealth;
    private Coroutine _changeHealth;

    private void OnEnable()
    {
        _character.ChangedHealth += ShowChangeHealth;
    }

    private void OnDisable()
    {
        _character.ChangedHealth -= ShowChangeHealth;  
    }

    private void Start()
    {
        _slider.maxValue = _character.MaxHealth;
        _slider.value = _character.Health;
        _infoHealth = _character.Health.ToString() + "/" + _character.MaxHealth.ToString();
        _text.text = _infoHealth;
    }

    private IEnumerator ChangeSmoothlyHealth()
    {
        while (_slider.value != _character.Health)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, _character.Health, _speed * Time.deltaTime);
            yield return null;
        }
    }

    private void StopChangeHealth()
    {
        if(_changeHealth != null)
        {
            StopCoroutine(_changeHealth);
            _changeHealth = null;
        }
    }

    public void ShowChangeHealth()
    {
        StopChangeHealth();

        if (_changeHealth == null)
            _changeHealth = StartCoroutine(ChangeSmoothlyHealth());
        
        _infoHealth = _character.Health.ToString() + "/" + _character.MaxHealth.ToString();
        _text.text = _infoHealth;
    }
}