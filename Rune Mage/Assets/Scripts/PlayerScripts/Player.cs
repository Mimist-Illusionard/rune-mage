using UnityEngine;


public class Player : MonoBehaviour, IExecute
{
	[SerializeField] Transform _cameraHolder;
	[SerializeField] private float _walkSpeed, _sprintSpeed, _jumpForce, _gravityForce;
	[SerializeField] private float _staminaRegen;
	[SerializeField] private float _staminaSpent;

	private Stamina _stamina;
	private CharacterController _characterController;
	private Vector3 _velocity;

	private float _currentSpeed;

	public bool _canRun = true;

	private void Awake()
	{
		_characterController = GetComponent<CharacterController>();
	}

	private void Start()
	{
		_currentSpeed = _walkSpeed;

		GameManager.Singleton.AddExecuteObject(this);
		PlayerManager.Singleton.SetPlayer(this);

		_stamina = PlayerManager.Singleton.GetStamina();
	}

	public void Execute()
	{
		if (gameObject.GetComponent<Player>().enabled == true)
		{
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

	private void Move()
	{
		float x = Input.GetAxis("Horizontal");
		float z = Input.GetAxis("Vertical");

		Vector3 move = gameObject.transform.right * x + gameObject.transform.forward * z;
		_characterController.Move(move * _currentSpeed * Time.deltaTime);
	}

	private void Sprint()
	{
		if (_canRun)
		{
			if (Input.GetKey(KeyCode.LeftShift))
			{
				_stamina.SpentStamina(_staminaSpent);
				_currentSpeed = _sprintSpeed;
			}
			else
			{
				_stamina.Regen(_staminaRegen);
				_currentSpeed = _walkSpeed;
			}
		}
		else
		{
			_stamina.Regen(_staminaRegen);
			_currentSpeed = _walkSpeed;
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

    private void OnDestroy()
    {
		GameManager.Singleton.RemoveExecuteObject(this);
    }
}