using System;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TempoDetector : MonoBehaviour, IPointerClickHandler
{
    public float interval;
    public float averageInterval;
    public int clickCountReset = 8;

    private TextMeshProUGUI _detected;
    private float _lastClick;
    private int _clickCount;
    private float _accumaltiveInterval;
    private Color _initColor;
    private Image _clicker;

    void Start()
    {
        _clicker = this.Get<Image>();
        _initColor = _clicker.color;
        _detected = this.GetChild<TextMeshProUGUI>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        interval = Time.time - _lastClick;

        _accumaltiveInterval += interval;
        _clickCount++;

        averageInterval = _accumaltiveInterval / _clickCount;

        _detected.text = MathF.Round(60f / averageInterval, 2).ToString();

        _lastClick = Time.time;

        _clicker.DOColor(_initColor.Darken(0.2f), 0.1f).onComplete += () => _clicker.DOColor(_initColor, 0.1f);

        if (_clickCount > clickCountReset)
        {
            _clickCount = 0;
            _accumaltiveInterval = 0;
        }
    }
}
