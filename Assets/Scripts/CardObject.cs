using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardObject : MonoBehaviour, IPointerMoveHandler, IPointerExitHandler
{
    [HideInInspector] public Quaternion targetRotation = Quaternion.identity;
    
    [SerializeField] private MeshRenderer meshRenderer;
    [SerializeField] private TextMeshPro name;
    [SerializeField] private Vector2 size;
    [SerializeField] private float rotationSpeed;

    private Material _material;
    private CardProperties _properties;
    private static readonly int BorderColor = Shader.PropertyToID("_BorderColor");

    public CardProperties Properties => _properties;

    public event Action<Vector3> OnPointerMoveEvent;
    public event Action OnPointerExitEvent;

    public Vector2 Size => size;
    
    private void Update()
    {
        UpdateRotation();
    }
    
    private void UpdateRotation()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
    }
    
    public void SetProperties(CardProperties cardProperties)
    {
        _properties = cardProperties;
        
        meshRenderer.material.SetColor(BorderColor, _properties.color);
        name.text = _properties.name;
    }

    public void OnPointerMove(PointerEventData eventData)
    {
        OnPointerMoveEvent?.Invoke(eventData.pointerCurrentRaycast.worldPosition);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        OnPointerExitEvent?.Invoke();
    }
    
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(transform.position, size);
    }
}
