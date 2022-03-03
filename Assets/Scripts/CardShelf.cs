using Unity.Mathematics;
using UnityEngine;

public static class CardShelf
{
    private static readonly Vector2 Margins = new (2, 1);
    private static readonly Vector2 MinMaxAngles = new (15, -15);

    public static void UpdateCardsPositions()
    {
        for (var index = 0; index < CardSpawner.ActiveCards.Count; index++)
        {
            var card = CardSpawner.ActiveCards[index];

            var position = card.Size + Margins;
            position.x *= index;
            position.x += card.Size.x / 2f;
            position.x -= Margins.x / 2f * (CardSpawner.ActiveCards.Count / 2f + 1);

            card.transform.position = position;
        }
    }

    public static void SetCardsLookAtPosition(Vector3 point)
    {
        foreach (var card in CardSpawner.ActiveCards)
        {
            var angle = math.degrees(math.atan2(card.transform.position.x, point.x));
            angle = math.clamp(math.remap(40, 50, MinMaxAngles.x, MinMaxAngles.y, angle), MinMaxAngles.y, MinMaxAngles.x);

            var rotation = Quaternion.AngleAxis(angle, Vector3.up);
            card.targetRotation = rotation;
        }
    }

    public static void ResetCardsRotations()
    {
        foreach (var card in CardSpawner.ActiveCards)
            card.targetRotation = Quaternion.identity;
    }
}
