using UnityEngine;

[RequireComponent(typeof(MeshRenderer), typeof(BoxCollider))]

public class Cube : MonoBehaviour
{
    private float _crackChance = 100;

    private float _maxCrackChance = 100;
    private float _minCrackCance = 0;

    private float _chanceDivisor = 2;

    private MeshRenderer _meshRenderer;

    public BoxCollider Collider { get; private set; }

    private void Awake()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
        Collider = GetComponent<BoxCollider>();
    }

    public bool IsCracked()
    {
        return Random.Range(_minCrackCance, _maxCrackChance + 1) <= _crackChance;
    }

    public void ReduceCrackCance()
    {
        _crackChance /= _chanceDivisor;
    }

    public void ChangeColor()
    {
        float minHue = 0, maxHue = 1;
        float minSaturation = 0, maxSaturation = 1;
        float minValue = 0, maxValue = 1;

        _meshRenderer.material.color = Random.ColorHSV(minHue, maxHue, minSaturation, maxSaturation, minValue, maxValue);
    }
}