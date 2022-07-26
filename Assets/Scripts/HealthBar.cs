using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private Player _player;
    [SerializeField] private float _speedHealthChange;

    private Coroutine _currentCoroutine;

    private void Start()
    {
        _slider.maxValue = _player.MaxHealth;
        _slider.value = _player.MaxHealth;
    }

    private void OnEnable()
    {
        _player.HealthDamage += OnHealthChange;
    }

    private void OnDisable()
    {
        _player.HealthDamage -= OnHealthChange;
    }
    
    private IEnumerator ChangingHealthSlider(float target)
    {
        while (_slider.value != target) 
        {
            _slider.value = Mathf.MoveTowards(_slider.value, target, _speedHealthChange * Time.deltaTime);
            yield return null;
        }        
    }

    private void OnHealthChange(float value)
    {
        if (_currentCoroutine != null)
        {
            StopCoroutine(_currentCoroutine);
        }

        _currentCoroutine = StartCoroutine(ChangingHealthSlider(value));
    }
}






