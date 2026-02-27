using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Day : MonoBehaviour
{
    public static Day instance;
    public static float intensity => instance.sun.intensity;
    public static int Hour;

    public AnimationCurve cycle;
    public Gradient sunColor;

    public float duration = 60f;

    Light2D sun;
    float currentTime;

    void Start()
    {
        sun = GetComponent<Light2D>();
    }

    void Update()
    {
        currentTime = (currentTime + Time.deltaTime) % duration;
        
        Hour = Mathf.FloorToInt(currentTime / duration * 24f);

        float t = currentTime / duration;

        sun.intensity = cycle.Evaluate(t);
        sun.color = sunColor.Evaluate(t);
    }
}
