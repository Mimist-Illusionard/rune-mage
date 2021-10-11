using UnityEngine;


public class Player : MonoBehaviour, IExecute
{
	[SerializeField] Transform _cameraHolder;
	[SerializeField] private float _mouseSensitivity, _walkSpeed, _sprintSpeed, _jumpForce, _smoothTime, _gravityForce;
	[SerializeField] private float _staminaRegen;
	[SerializeField] private float _staminaSpent;

	private CharacterController _characterController;

	private Vector3 _velocity;
	private RaycastHit _hit;

	private float _playerSpeed;
	private float _verticalVelocity;
	private float _verticalLookRotation;

	public bool _canRun = true;

	private void Awake()
	{
		_characterController = GetComponent<CharacterController>();
	}

	private void Start()
	{
		Cursor.visible = false;
		Cursor.lockState = CursorLockMode.Locked;
		SwitchCursorMode();

		_playerSpeed = _walkSpeed;

		GameManager.Singleton.SetNewExecuteObject(this);
		PlayerManager.Singleton.SetPlayer(this);
	}

	public void Execute()
	{
		if (gameObject.GetComponent<Player>().enabled == true)
		{
			Look();
			Sprint();
			Move();
			GameGravity();
			Jump();
		}
	}

	private void OnControllerColliderHit(ControllerColliderHit hit)
	{
		float pushPower = 2;
		Rigidbody body = hit.collider.attachedRigidbody;
		Vector3 force;

		if (body == null || body.isKinematic) { return; }
		force = hit.controller.velocity * pushPower;
		body.AddForceAtPosition(force, hit.point);

	}

	private void Look()
	{
		transform.Rotate(Vector3.up * Input.GetAxisRaw("Mouse X") * _mouseSensitivity);

		_verticalLookRotation += Input.GetAxisRaw("Mouse Y") * _mouseSensitivity;
		_verticalLookRotation = Mathf.Clamp(_verticalLookRotation, -90f, 90f);

		_cameraHolder.localEulerAngles = Vector3.left * _verticalLookRotation;
	}

	private void Move()
	{
		float x = Input.GetAxis("Horizontal");
		float z = Input.GetAxis("Vertical");

		Vector3 move = gameObject.transform.right * x + gameObject.transform.forward * z;
		_characterController.Move(move * _playerSpeed * Time.deltaTime);
	}

	private void Sprint()
	{
		if (_canRun)
		{
			if (Input.GetKey(KeyCode.LeftShift))
			{
				PlayerManager.Singleton.StaminaManager(_staminaSpent);
				_playerSpeed = _sprintSpeed;
			}
			else
			{
				PlayerManager.Singleton.StaminaManager(_staminaRegen);
				_playerSpeed = _walkSpeed;
			}
		}
		else
		{
			PlayerManager.Singleton.StaminaManager(_staminaRegen);
			_playerSpeed = _walkSpeed;
		}
	}

	private void GameGravity()
	{
		_velocity.y = _gravityForce;

		_characterController.Move(_velocity * Time.deltaTime);

		if (!_characterController.isGrounded)
			_gravityForce -= 20f * Time.deltaTime;
		else _gravityForce = -1f;		
	}

	private void Jump()
    {
		if (Input.GetKeyDown(KeyCode.Space) && _characterController.isGrounded) _gravityForce = _jumpForce;
	}

	public void SwitchCursorMode()
	{
		Cursor.visible = false;
		Cursor.lockState = CursorLockMode.Locked;
	}
}