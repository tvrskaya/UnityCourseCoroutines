using System;
using System.Collections;
using UnityEngine;

public class Counter : MonoBehaviour
{
    public event Action CounterUpdated;

    private readonly int _counterChange = 1;

    [SerializeField] private MouseProcessor _mouseProcessor;
    private float _counterUpdateDelay = 0.5f;
    private Coroutine _counterCoroutine = null;

    public int CounterValue { get; private set; }

    private void OnEnable()
    {
        _mouseProcessor.MouseButtonPressed += ProcessTrigger;
    }

    private void OnDisable()
    {
        _mouseProcessor.MouseButtonPressed -= ProcessTrigger;
    }

    private void ProcessTrigger()
    {
        if (_counterCoroutine == null)
        {
            _counterCoroutine = StartCoroutine(nameof(CounterRoutine));
        }
        else
        {
            StopCoroutine(_counterCoroutine);
            _counterCoroutine = null;
        }
    }

    private IEnumerator CounterRoutine()
    {
        var wait = new WaitForSeconds(_counterUpdateDelay);

        while (enabled)
        {
            CounterValue += _counterChange;
            CounterUpdated?.Invoke();
            yield return wait;
        }
    }
}
