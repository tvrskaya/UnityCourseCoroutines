using System;
using UnityEngine;

public class MouseProcessor : MonoBehaviour
{
    public event Action MouseButtonPressed;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            MouseButtonPressed?.Invoke();
        }
    }
}
