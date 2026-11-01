using System;
using System.Collections;
using UnityEngine;

public class Counter : MonoBehaviour
{
    public event Action CounterUpdated;
        
    public int CounterValue { get; private set; }

    private float _counterUpdateDelay = 0.5f;

    private Coroutine _counterCoroutine = null;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
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
    }

    private IEnumerator CounterRoutine()
    {
        var wait = new WaitForSeconds(_counterUpdateDelay);

        while (true)
        {
            CounterValue += 1;
            CounterUpdated?.Invoke();
            yield return wait;
        }
    }
}
