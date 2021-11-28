using UnityEngine;
using DG.Tweening;


public class ExplodeZone : Interactable, IDamage, IInitialize
{
    [SerializeField] private Vector3 _scaleEndPosition;
    [SerializeField] private float _scaleTime;
    [SerializeField] private bool _isIgnorePlayer;

    public float Damage { get; set; }

    private void Start()
    {
        //transform.DOScale(_scaleEndPosition, _scaleTime).OnComplete(() => transform.DOScale(new Vector3(0f,0f,0f), 0.25f).OnComplete(() => Destroy(gameObject)));
    }

    protected override void OnEnter(Collider other)
    {
        if (!other.TryGetComponent<Health>(out var health)) return;
        if (_isIgnorePlayer && other.CompareTag("Player")) return;

        health.RemoveHealth(Damage);
    }

    protected override void OnExit(Collider other)
    {       
    }

    public void Initialize()
    {
    }
}
