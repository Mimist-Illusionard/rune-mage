using UnityEngine;


public class PlayerManager : BaseSingleton<PlayerManager>, IExecute
{
    private Player _player;
	private MainCamera _camera;

	private Health _health;
	private Mana _mana => GetComponent<Mana>();
	private Stamina _stamina => GetComponent<Stamina>();
	private Currency _currency => GetComponent<Currency>();

    private void Start()
	{ 
		GameManager.Singleton.AddExecuteObject(this);
	}

	public void Execute()
	{
		if(_player != null)
			_player._canRun = _stamina.CanRun();
	}

	public void SetPlayer(Player player)
    {
		_player = player;

		_health = _player.GetComponent<Health>();
		_camera = _player.gameObject.GetComponentInObject<MainCamera>();
	}

	public RaycastHit Raycast()
    {
		RaycastHit hitInfo;
		Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hitInfo);
		return hitInfo;
	}

	public Player GetPlayer()
    {
		return _player;
    }

	public Mana GetMana()
    {
		return _mana;
    }

	public Stamina GetStamina()
    {
		return _stamina;
    }

	public Currency GetCurrency()
    {
		return _currency;
    }

	public Health GetHealth()
    {
		return _health;
    }

	public MainCamera GetCamera()
    {
		return _camera;
    }
}