using System;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    [SerializeField] private int defaultCardsCount = 4;
    [SerializeField] private CardObject cardPrefab;
    [SerializeField] private Transform cardParent;
    
    private void Start()
    {
        InitializeCards();
    }

    private void InitializeCards()
    {
        CardSpawner.InitializeCardPool(cardPrefab);
        
        for (var index = 0; index < defaultCardsCount; index++)
        {
            var cardObject = CardSpawner.CardPool.Get();
            cardObject.transform.SetParent(cardParent);

            var cardProperty = CardDeck.GetRandomCard();
            cardObject.SetProperties(cardProperty);
            
            cardObject.OnPointerMoveEvent += OnPointerMoveCard; // Need to unsubscribe when the card is removed
            cardObject.OnPointerExitEvent += OnPointerExitCard; // Need to unsubscribe when the card is removed
        }
        
        CardShelf.UpdateCardsPositions();
    }

    private void OnPointerMoveCard(Vector3 position)
    {
        CardShelf.SetCardsLookAtPosition(position);
    }

    private void OnPointerExitCard()
    {
        CardShelf.ResetCardsRotations();
    }
}