using UnityEngine;

using DG.Tweening;


public class CameraImpactController : MonoBehaviour, IExecute
{
    [SerializeField] private Transform _camera;

    [Header("Spell Impact Settings")]
    [SerializeField] private float _strength = 1;
    [SerializeField] private int _vibration = 10;
    [SerializeField] private float _randomness = 90;
    [SerializeField] private float _duration;

    [Header("Movement Impact Settings")]
    [SerializeField] private float _bigVectorValue;
    [SerializeField] private float _smallVectorValue;
    [SerializeField] private float _blendTime;

    private void Start()
    {
        SpellsSystem.Singleton.OnSpellCasted += SpellImpact;

        GameManager.Singleton.AddExecuteObject(this);
    }

    public void Execute()
    {
        var horizontalInput = Input.GetAxis("Horizontal");
        var verticalInput = Input.GetAxis("Vertical");

        MovementImpact(horizontalInput, verticalInput);
    }

    private void SpellImpact()
    {
        transform.GetComponent<Camera>().DOShakePosition(_duration, _strength, _vibration, _randomness, true);
    }

    private void MovementImpact(float horizontalInput, float verticalInput)
    {
        if (horizontalInput >= 0.5f) //Player going to right
        {
            _camera.transform.DOLocalRotate(new Vector3(_camera.transform.position.x, _camera.transform.position.y, -_bigVectorValue), _blendTime);
        }

        if (horizontalInput <= -0.5f) //Player going to left
        {
            _camera.transform.DOLocalRotate(new Vector3(_camera.transform.position.x, _camera.transform.position.y, _bigVectorValue), _blendTime);
        }

        if (horizontalInput >= -0.1f && horizontalInput <= 0.1f)
        {
            _camera.transform.DOLocalRotate(new Vector3(_camera.transform.position.x, _camera.transform.position.y, 0), _blendTime);
        }

        if (verticalInput >= 0.5f) //Player going forward
        {
            _camera.transform.DOLocalRotate(new Vector3(_camera.transform.position.x, _camera.transform.position.y, 0), _blendTime);
        }

        if (verticalInput <= -0.5f) //Player going backwards
        {
            _camera.transform.DOLocalRotate(new Vector3(_camera.transform.position.x, _camera.transform.position.y, 0), _blendTime);
        }

        if (horizontalInput >= 0.5f && verticalInput >= 0.5f) //Going to right-upper angle
        {
            _camera.transform.DOLocalRotate(new Vector3(_camera.transform.position.x, _camera.transform.position.y, -_smallVectorValue), _blendTime);
        }

        if (horizontalInput <= -0.5f && verticalInput >= 0.5f) //Going to left-upper angle
        {
            _camera.transform.DOLocalRotate(new Vector3(_camera.transform.position.x, _camera.transform.position.y, _smallVectorValue), _blendTime);
        }

        if (horizontalInput >= 0.5f && verticalInput <= -0.5f) //Going to right-down angle
        {
            _camera.transform.DOLocalRotate(new Vector3(_camera.transform.position.x, _camera.transform.position.y, -_smallVectorValue), _blendTime);
        }

        if (horizontalInput <= -0.5f && verticalInput <= -0.5f) //Going to left-down angle
        {
            _camera.transform.DOLocalRotate(new Vector3(_camera.transform.position.x, _camera.transform.position.y, _smallVectorValue), _blendTime);
        }
    }

    private void OnDestroy()
    {
        GameManager.Singleton.RemoveExecuteObject(this);
    }
}
