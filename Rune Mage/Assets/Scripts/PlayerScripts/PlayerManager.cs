using UnityEngine;


public class PlayerManager : MonoBehaviour, IExecute
{
    private Player _player;

	private Health _health;
	private Mana _mana => GetComponent<Mana>();
	private Stamina _stamina => GetComponent<Stamina>();

    public static PlayerManager Singleton { get; private set; }

	private void Awake()
	{
		Singleton = this;
	}

    private void Start()
	{ 
		GameManager.Singleton.AddExecuteObject(this);
	}

	public void Execute()
	{
		_player._canRun = _stamina.CanRun();
	}

	public void SetPlayer(Player player)
    {
		_player = player;

		_health = _player.GetComponent<Health>();
	}

	public RaycastHit Raycast()
    {
		RaycastHit hitInfo;
		Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hitInfo);
		return hitInfo;
	}

	public Mana GetMana()
    {
		return _mana;
    }

	public Stamina GetStamina()
    {
		return _stamina;
    }

	public Health GetHealth()
    {
		return _health;
    }
}