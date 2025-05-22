using UnityEngine;

[RequireComponent(typeof(MeshRenderer), typeof(BoxCollider))]

public class Cube : MonoBehaviour
{
    private float _crackChance = 100;

    private float _maxCrackChance = 100;
    private float _minCrackCance = 0;

    private float _chanceDivisor = 2;

    public BoxCollider Collider { get; private set; }

    private void Awake()
    {
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
}