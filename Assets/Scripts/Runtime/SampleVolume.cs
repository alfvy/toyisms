using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SampleVolume : MonoBehaviour
{
    public TextMeshProUGUI sampleNameTextMesh;
    public Image indicator;

    private ValueSlider _value;
    private AudioSource _source;

    void Start()
    {
        _value = this.Get<ValueSlider>();
        _source = this.GetParent<AudioSource>();

        _value.OnValueChange += (value) =>
        {
            _source.volume = value;
            sampleNameTextMesh.color = Color.Lerp(Color.white, Color.black, value);
            indicator.fillAmount = value;
        };
    }
}
