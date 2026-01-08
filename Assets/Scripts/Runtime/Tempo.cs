using TMPro;

public class Tempo : MonoSingleton<Tempo>
{
    public static double Value;

    public double tempo;

    private ValueSliderDouble _value;
    private TextMeshProUGUI _tempoText;

    void Awake()
    {
        Value = tempo;
    }

    void Start()
    {
        _tempoText = this.Get<TextMeshProUGUI>();
        _value = this.Get<ValueSliderDouble>();
        _value.value = tempo;
        _tempoText.text = _value.value.ToString();
        _value.OnValueChange += (value) =>
        {
            Value = value;
            tempo = value;
            _tempoText.text = value.ToString();
        };
    }
}
