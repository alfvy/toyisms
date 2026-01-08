using UnityEngine;

public static class Util
{
    public static T Get<T>(this Component component) where T : Component
    {
        return component.GetComponent<T>();
    }

    public static T GetChild<T>(this Component component) where T : Component
    {
        return component.GetComponentInChildren<T>();
    }

    public static T GetParent<T>(this Component component) where T : Component
    {
        return component.GetComponentInParent<T>();
    }

    public static Color Darken(this Color color, float amount)
    {
        amount = Mathf.Clamp01(amount);

        return new Color(
            color.r * (1f - amount),
            color.g * (1f - amount),
            color.b * (1f - amount),
            color.a
        );
    }
}
