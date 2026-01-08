using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class Sequence : MonoBehaviour
{
    public AudioClip sample;
    public List<Beater> beaters;
    public Color activeColor;

    private AudioSource _source;

    void Start()
    {
        _source = this.Get<AudioSource>();
        _source.clip = sample;
        StartCoroutine(Routine());
    }

    IEnumerator Routine()
    {
        while (true)
        {
            foreach (var beater in beaters)
            {
                var ms = 60000f / Tempo.Value;

                beater.Activate(activeColor);

                if (sample != null && beater.active) _source.Play();

                print($"will wait {ms} ms");
                yield return new WaitForSeconds((float)(ms / 1000));
            }
        }
    }
}

#if UNITY_EDITOR

[UnityEditor.CustomEditor(typeof(Sequence))]
public class SequenceEditor : UnityEditor.Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        if (GUILayout.Button("Get beaters"))
        {
            var seq = target as Sequence;

            var children = seq.GetComponentsInChildren<Beater>();
            seq.beaters.Clear();
            seq.beaters.AddRange(children);
        }
    }
}

#endif
