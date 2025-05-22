using UnityEngine;
using UnityEngine.Events;

public class ClickHandler : MonoBehaviour
{
    public event UnityAction<Cube> Clicked;
    
    [SerializeField] private Camera _camera;

    private Ray _ray;
    private RaycastHit _hit;

    private void Update()
    {
        _ray = _camera.ScreenPointToRay(Input.mousePosition);

        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(_ray, out _hit, Mathf.Infinity))
            {
                Cube cube = _hit.collider.gameObject.GetComponent<Cube>();

                if (cube != null)
                {
                    Clicked.Invoke(cube);
                }
            }
        }
    }
}
