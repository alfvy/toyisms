using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Beater : MonoBehaviour, IPointerClickHandler
{
    public bool active = false;

    private Image _image;
    private Color _initColor;

    void Start()
    {
        _image = this.Get<Image>();
        active = false;
        _initColor = _image.color;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        active = !active;
    }

    public void Activate(Color activeColor)
    {
        var col = active ? activeColor : Color.grey;
        _image.DOColor(col, 0.1f).onComplete += () => _image.DOColor(_initColor, 0.1f);
    }
}
