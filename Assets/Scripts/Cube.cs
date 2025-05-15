using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{   
    [SerializeField] private float _explosionsForce;
    [SerializeField] private float _explosionsRadius;

    [SerializeField] private float _crackChance = 100;

    private const string StandartShader = nameof(StandartShader);

    private float _maxCrackChance = 100;
    private float _minCrackCance = 0;

    private MeshRenderer _meshRenderer;

    private float _chanceDivisor = 2;
    private float _scaleDivisor = 2;

    private int _maxShardsCount = 6;
    private int _minShardsCount = 2;

    private BoxCollider _collider;

    private void Start()
    {
        _collider = GetComponent<BoxCollider>();
        _meshRenderer = GetComponent<MeshRenderer>();
    }

    public void CreateShards()
    {
        float minHue = 0, maxHue = 1;
        float minSaturation = 0, maxSaturation = 1;
        float minValue = 0, maxValue = 1;

        List<Rigidbody> createdShards = new();

        if (Random.Range(_minCrackCance, _maxCrackChance + 1) <= _crackChance)
        {
            transform.localScale = transform.localScale / _scaleDivisor;
            _crackChance /= _chanceDivisor;

            for (int i = 0; i < Random.Range(_minShardsCount, _maxShardsCount + 1); i++)
            {
                Material material = new Material(Shader.Find("Standard"));
                material.color = Random.ColorHSV(minHue, maxHue, minSaturation, maxSaturation, minValue, maxValue);

                _meshRenderer.material = material;

                Instantiate(gameObject, GetPointInsideCube(), Quaternion.identity);
            }
        }

        foreach (Rigidbody cube in createdShards)
            cube.AddExplosionForce(_explosionsForce, transform.position, _explosionsRadius);

        Destroy(gameObject);
    }

    private Vector3 GetPointInsideCube()
    {
        Bounds bounds = _collider.bounds;

        return new Vector3(Random.Range(bounds.min.x, bounds.max.x), Random.Range(bounds.min.y, bounds.max.y), Random.Range(bounds.min.z, bounds.max.z));
    }
}
