using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class ColorChanger : MonoBehaviour
{
    private MeshRenderer _meshRenderer;

    private void Awake()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
    }

    public void ChangeColor()
    {
        float minHue = 0, maxHue = 1;
        float minSaturation = 0, maxSaturation = 1;
        float minValue = 0, maxValue = 1;

        _meshRenderer.material.color = Random.ColorHSV(minHue, maxHue, minSaturation, maxSaturation, minValue, maxValue);
    }
}
