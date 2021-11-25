using UnityEngine;

using DG.Tweening;

using TMPro;


public class DamagePopUp : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private Transform _worldCanvas;
    [SerializeField] private float _scaleValue;
    [SerializeField] private float _randomScaleValue;
    [SerializeField] private float _scaleDuration;
    [SerializeField] private float _randomPositionValue;

    private void Start()
    {
        var health = GetComponent<Health>();
        health.OnValueGetted += CreatePopUp;
    }

    private void CreatePopUp(float currentHealth)
    {
        var popUp = Instantiate(_prefab, _worldCanvas);
        popUp.GetComponent<TextMeshProUGUI>().text = currentHealth.ToString();

        popUp.transform.position = new Vector3(popUp.transform.position.x + RandomNumber(-_randomPositionValue, _randomPositionValue), popUp.transform.position.y + RandomNumber(-_randomPositionValue, _randomPositionValue), popUp.transform.position.z);

        popUp.transform.DOScale(_scaleValue + RandomNumber(0, _randomScaleValue), _scaleDuration).OnComplete(() => Destroy(popUp));
    }

    private float RandomNumber(float min, float max)
    {    
        return Random.Range(min, max);
    }
}
