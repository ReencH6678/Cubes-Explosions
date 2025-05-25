using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(BoxCollider), typeof(ColorChanger))]

public class Cube : MonoBehaviour
{
    private float _crackChance = 100;

    private float _maxCrackChance = 100;
    private float _minCrackCance = 0;

    private float _chanceDivisor = 2;

    public BoxCollider Collider { get; private set; }
    public Rigidbody Rigidbody { get; private set; }
    public ColorChanger ColorChanger { get; private set; }

    private void Awake()
    {
        Collider = GetComponent<BoxCollider>();
        Rigidbody = GetComponent<Rigidbody>();
        ColorChanger = GetComponent<ColorChanger>();
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