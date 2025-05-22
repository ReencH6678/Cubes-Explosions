using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CubeExploder))]
public class Spawner : MonoBehaviour
{
    [SerializeField] private float _explosionsForce;
    [SerializeField] private float _explosionsRadius;

    [SerializeField] private CubeExploder _exploder;

    private int _maxShardsCount = 6;
    private int _minShardsCount = 2;

    private float _scaleDivisor = 2;

    private void OnEnable()
    {
        _exploder.Exloded += CreateShards;
    }

    private void OnDisable()
    {
        _exploder.Exloded -= CreateShards;
    }

    public void CreateShards(Cube cube)
    {
        List<GameObject> createdShards = new();
        int shardsCount = Random.Range(_minShardsCount, _maxShardsCount + 1);

        BoxCollider collider = cube.GetComponent<BoxCollider>();

        if (cube.IsCracked())
        {
            for (int i = 0; i < shardsCount; i++)
            {
                GameObject shard = Instantiate(cube.gameObject, GetRandomPointInsideCube(collider), Quaternion.identity);

                shard.transform.localScale /= _scaleDivisor;

                shard.GetComponent<Cube>().ChangeColor();
                shard.GetComponent<Cube>().ReduceCrackCance();
            }
        }

        Destroy(cube.gameObject);

        foreach (GameObject shard in createdShards)
        {
            shard.GetComponent<Rigidbody>().AddExplosionForce(_explosionsForce, transform.position, _explosionsRadius);
            shard.GetComponent<Cube>().ChangeColor();
        }
    }

    private Vector3 GetRandomPointInsideCube(BoxCollider collider)
    {
        Bounds bounds = collider.bounds;

        return new Vector3(Random.Range(bounds.min.x, bounds.max.x), Random.Range(bounds.min.y, bounds.max.y), Random.Range(bounds.min.z, bounds.max.z));
    }
}
