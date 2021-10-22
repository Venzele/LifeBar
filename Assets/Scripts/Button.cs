using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    [SerializeField] private Character _character;
    [SerializeField] private float _step;

    public void ChangeValueHealth(int direction)
    {
        _character.ChangeHealth(_step * direction);
    }
}
