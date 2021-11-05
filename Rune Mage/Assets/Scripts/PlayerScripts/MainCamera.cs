using UnityEngine;
using UnityEngine.EventSystems;


public class MainCamera : MonoBehaviour, IExecute
{
    [SerializeField] Transform _body;
    [SerializeField] Transform _cameraHolder;
    [SerializeField] private float _mouseSensitivity;

    private float _verticalLookRotation;
    private bool _isLocked;

    private void Start()
    {
        SwitchCursorMode(true);

        GameManager.Singleton.AddExecuteObject(this);
    }

    public void Execute()
    {
        Look();
        Raycast();
    }

    private void Look()
    {
        if (!_isLocked) return;

        _body.Rotate(Vector3.up * Input.GetAxisRaw("Mouse X") * _mouseSensitivity);

        _verticalLookRotation += Input.GetAxisRaw("Mouse Y") * _mouseSensitivity;
        _verticalLookRotation = Mathf.Clamp(_verticalLookRotation, -90f, 90f);

        _cameraHolder.localEulerAngles = Vector3.left * _verticalLookRotation;
    }

    private void Raycast()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 2))
            {
                IPointerClickHandler clickHandler = hit.collider.gameObject.GetComponent<IPointerClickHandler>();
                if (clickHandler != null)
                {                   
                    PointerEventData pointerEventData = new PointerEventData(EventSystem.current);
                    clickHandler.OnPointerClick(pointerEventData);
                }
            }
        }
    }

    public void SwitchCursorMode(bool isCursorLocked)
    {
        Cursor.visible = !Cursor.visible;
        if (isCursorLocked)
        {
            Cursor.lockState = CursorLockMode.Locked;
            _isLocked = true;
        } else
        {
            Cursor.lockState = CursorLockMode.Confined;
            _isLocked = false;
        }
    }

    private void OnDestroy()
    {
        GameManager.Singleton.RemoveExecuteObject(this);
    }
}
