using UnityEngine;

public class CounterView : MonoBehaviour
{
    [SerializeField] private Counter _counter;

    private void OnEnable()
    {
        _counter.CounterUpdated += DisplayCounterValue;
    }

    private void OnDisable()
    {
        _counter.CounterUpdated -= DisplayCounterValue;
    }

    private void DisplayCounterValue()
    {
        Debug.Log($"Counter value: {_counter.CounterValue}");
    }
}
