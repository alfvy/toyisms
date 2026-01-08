using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class ValueSlider : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public float value;
    [Range(0, 1)] public float speed;
    public float min, max;
    public int round;
    public Action<float> OnValueChange;

    private bool _down;
    private Vector2 _downMousePos;
    private float _prevDist;

    void OnValidate()
    {
        round = Mathf.Clamp(round, 0, int.MaxValue);
        max = Mathf.Clamp(max, min, float.MaxValue);
    }

    void Update()
    {
        if (!_down) return;

        var currentMousePos = Pointer.current.position.ReadValue();
        if (Mathf.Abs(_downMousePos.y - currentMousePos.y) < 1) return;

        var dist = _downMousePos.y - currentMousePos.y;

        if (dist <= 0)
        {
            value += Mathf.Abs(_prevDist * 0.01f) * speed;
        }
        else
        {
            value -= Mathf.Abs(_prevDist * 0.01f) * speed;
        }

        if (round > 0)
        {
            value = MathF.Round(Mathf.Clamp(value, min, max), round);
        }
        else
        {
            value = Mathf.Clamp(value, min, max);
        }

        _downMousePos = currentMousePos;
        _prevDist = dist;

        OnValueChange?.Invoke(value);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _down = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _down = false;
    }
}