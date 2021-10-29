using UnityEngine;


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
    }

    private void Look()
    {
        if (!_isLocked) return;

        _body.Rotate(Vector3.up * Input.GetAxisRaw("Mouse X") * _mouseSensitivity);

        _verticalLookRotation += Input.GetAxisRaw("Mouse Y") * _mouseSensitivity;
        _verticalLookRotation = Mathf.Clamp(_verticalLookRotation, -90f, 90f);

        _cameraHolder.localEulerAngles = Vector3.left * _verticalLookRotation;
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
