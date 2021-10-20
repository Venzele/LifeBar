using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowChangeHealth : MonoBehaviour
{
    [SerializeField] Slider _slider;
    [SerializeField] HealthBar _health;
    [SerializeField] Text _text;

    private void Update()
    {
        _health.ChangeFloatHealth();
        _text.text = _health.InfoHealth;

        _slider.value = _health.FloatHealth / _health.MaxHealth;
    }
}
