using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ClickHandler))]
public class Spawner : MonoBehaviour
{
    [SerializeField] private ClickHandler _clickHandler;
    [SerializeField] private Exploder _exploder;

    private int _maxShardsCount = 6;
    private int _minShardsCount = 2;

    private float _scaleDivisor = 2;

    private void OnEnable()
    {
        _clickHandler.Clicked += CreateShards;
    }

    private void OnDisable()
    {
        _clickHandler.Clicked -= CreateShards;
    }

    public void CreateShards(Cube cube)
    {
        List<Rigidbody> createdShards = new();
        int shardsCount = Random.Range(_minShardsCount, _maxShardsCount + 1);

        BoxCollider collider = cube.GetComponent<BoxCollider>();

        if (cube.IsCracked())
        {
            for (int i = 0; i < shardsCount; i++)
            {
                Instantiate(cube, GetRandomPointInsideCube(collider), Quaternion.identity).TryGetComponent<Cube>(out Cube shard);

                shard.transform.localScale /= _scaleDivisor;

                shard.ReduceCrackCance();
                shard.ColorChanger.ChangeColor();
                createdShards.Add(shard.Rigidbody);
            }
        }
        else
        {
            _exploder.Explode(cube.transform.position);
        }

        _exploder.ShakeShards(createdShards, cube.transform.position);

        Destroy(cube.gameObject);
    }

    private Vector3 GetRandomPointInsideCube(BoxCollider collider)
    {
        Bounds bounds = collider.bounds;

        return new Vector3(Random.Range(bounds.min.x, bounds.max.x), Random.Range(bounds.min.y, bounds.max.y), Random.Range(bounds.min.z, bounds.max.z));
    }
}
