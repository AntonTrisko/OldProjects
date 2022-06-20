using com;
using UnityEngine;

public class CoinsManager : MonoBehaviour
{
    private int _coins;

    private void Awake()
    {
        DatabaseManager.GetUser(Constants.NICKNAME, user =>
        {
            _coins = user.coins;
        });
    }

    private void Start()
    {
        EventManager.AddListener(EventManager.ADDCOIN, AddCoin);
        EventManager.AddListener(EventManager.SPENDCOINS, SpendCoins);
        EventManager.AddListener(EventManager.ADVERTISMENT, OnAdWatched);
    }

    private void AddCoin(EventData eventData)
    {
        _coins++;
        DatabaseManager.SetCoins(_coins);
    }

    private void SpendCoins(EventData eventData)
    {
        if (_coins >= 100)
        {
            Debug.Log("CoinsSpent");
            _coins -= 100;
            DatabaseManager.SetCoins(_coins);
            EventManager.DispatchEvent(EventManager.SUCCESS, null);
        }
        else
        {
            Debug.Log("Not Enough Gold!");
        }
    }

    private void OnAdWatched(EventData eventData)
    {
        _coins += 20;
        DatabaseManager.SetCoins(_coins);
    }
}