using UnityEngine;

public class CubeExploder : MonoBehaviour
{
    [SerializeField] private Camera _camera;

    private Ray _ray;
    private RaycastHit _hit;

    private void Update()
    {
        if (_camera != null)
            _ray = _camera.ScreenPointToRay(Input.mousePosition);

        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(_ray, out _hit, Mathf.Infinity))
            {
                if (_hit.collider.gameObject.GetComponent<Cube>() != null)
                    _hit.collider.gameObject.GetComponent<Cube>().CreateShards();
            }
        }
    }
}
