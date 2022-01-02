using UnityEngine;


public class ShopItem : MonoBehaviour
{
    [SerializeField] private float _cost;

    public void BuyItem()
    {
        PlayerManager.Singleton.GetCurrency().RemoveCurrency(_cost);
    }
}
