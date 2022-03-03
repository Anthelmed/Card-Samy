using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public static class CardSpawner
{
    private static CardObject _cardPrefab;

    private static ObjectPool<CardObject> _cardPool;
    private static List<CardObject> _activeCards = new ();

    public static ObjectPool<CardObject> CardPool => _cardPool;
    public static List<CardObject> ActiveCards => _activeCards;
    
    public static void InitializeCardPool(CardObject cardPrefab)
    {
        _cardPrefab = cardPrefab;
        _cardPool = new ObjectPool<CardObject>(CreatePooledItem, OnTakeFromPool, OnReturnedToPool, 
            OnDestroyPoolObject, true, 5, 10);
    }
    
    private static CardObject CreatePooledItem()
    {
        var card = Object.Instantiate(_cardPrefab);
        card.gameObject.SetActive(false);
        
        return card;
    }
    
    private static void OnReturnedToPool(CardObject card)
    {
        card.gameObject.SetActive(false);

        _activeCards.Remove(card);
    }
    
    private static void OnTakeFromPool(CardObject card)
    {
        card.gameObject.SetActive(true);
        
        _activeCards.Add(card);
    }
    
    private static void OnDestroyPoolObject(CardObject card)
    {
        Object.Destroy(card.gameObject);
    }
}
