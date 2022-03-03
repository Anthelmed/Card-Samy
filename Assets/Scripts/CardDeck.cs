using System.Collections.Generic;
using System.Linq;
using Random = Unity.Mathematics.Random;

public static class CardDeck
{
    private static readonly CardProperties[] UnlockedCards = { // Load from the player store
        new ("Card 1", "#8cbeb2"),
        new ("Card 2", "#f2ebbf"),
        new ("Card 3", "#f3b562"),
        new ("Card 4", "#f06060"),
        new ("Card 5", "#8cbeb2"),
        new ("Card 6", "#f2ebbf"),
        new ("Card 7", "#f3b562"),
        new ("Card 8", "#f06060")
    };
    
    private static Stack<CardProperties> _cards = new (UnlockedCards);
    private static Random _random = new ((uint)UnityEngine.Random.Range(1, 100000));

    public static CardProperties GetRandomCard()
    {
        ShuffleCards();

        return _cards.Pop();
    }

    private static void ShuffleCards()
    {
        var randomizedCards = _cards.OrderBy(_ => _random.NextInt());
        _cards = new Stack<CardProperties>(randomizedCards);
    }
}
