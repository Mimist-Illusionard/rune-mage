using UnityEngine;


public class EscapeMenu : MonoBehaviour, IExecute
{
    [SerializeField] private GameObject _escapeMenu;

    private void Start()
    {
        GameManager.Singleton.AddExecuteObject(this);
    }

    public void Execute()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PlayerManager.Singleton.GetCamera().SwitchCursorMode(_escapeMenu.activeSelf);
            _escapeMenu.SetActive(!_escapeMenu.activeSelf);
        }
    }

    private void OnDestroy()
    {
        GameManager.Singleton.RemoveExecuteObject(this);
    }
}
