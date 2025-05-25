using System.Collections.Generic;
using UnityEngine;

public class Exploder : MonoBehaviour
{
    [SerializeField] private float _explosionsForce;
    [SerializeField] private float _explosionsRadius;

    public void Explode(List<Rigidbody> explodeObjects, Vector3 explosionPosition)
    {
        foreach (Rigidbody obj in explodeObjects)
        {
            obj.AddExplosionForce(_explosionsForce, explosionPosition, _explosionsRadius);
        }
    }    
}
