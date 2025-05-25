using System.Collections.Generic;
using UnityEngine;

public class Exploder : MonoBehaviour
{
    [SerializeField] private float _explosionsForce;
    [SerializeField] private float _explosionForceCoefficient;
    [SerializeField] private float _explosionsRadius;

    public void Explode(Vector3 explodePosition)
    {
        foreach (Rigidbody explodepleObject in GetExplodapleObjects(explodePosition))
        {
            float currentExplosionsForce = (_explosionsForce / explodepleObject.transform.localScale.x) / Vector3.Distance(transform.position, explodepleObject.position) * _explosionForceCoefficient;
            float currentExplosionsRadius = _explosionsRadius / explodepleObject.transform.localScale.x;

            explodepleObject.AddExplosionForce(currentExplosionsForce, explodePosition, _explosionsRadius);
        }
    }

    public void ShakeShards(List<Rigidbody> explodeObjects, Vector3 explosionPosition)
    {
        foreach (Rigidbody obj in explodeObjects)
        {
            obj.AddExplosionForce(_explosionsForce, explosionPosition, _explosionsRadius);
        }
    }
    
    private List<Rigidbody> GetExplodapleObjects(Vector3 explodePosition)
    {
        Collider[] hits = Physics.OverlapSphere(explodePosition, _explosionsRadius);
        List<Rigidbody> explodepleObjects = new();

        foreach (Collider hit in hits)
        {
            if (hit.attachedRigidbody != null)
                explodepleObjects.Add(hit.attachedRigidbody);
        }

        return explodepleObjects;
    }
}
