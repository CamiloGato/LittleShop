using System.Collections;
using Playable.Interactions;
using UI.Components;
using UnityEngine;

namespace Playable.Interact
{
    public class InteractableObject : MonoBehaviour, IInteractable
    {
        [SerializeField] private ObjectNotificationComponent objectNotificationComponent;
        [SerializeField] private string notificationText;
        [SerializeField] private Color hoverColor = Color.yellow;
        [SerializeField] private Color interactColor = Color.red;
        
        private Material _material;
        private Color _originalColor;
        private IInteractionEvent _interactionEvent;

        private void Awake()
        {
            _material = GetComponent<Renderer>().material;
            _interactionEvent = GetComponent<IInteractionEvent>();
            
            _originalColor = _material.GetColor("_Color");
        }

        public void OnClick(Player.Player player)
        {
            Debug.Log($"{gameObject.name} clicked!");
            _material.SetColor("_Color", interactColor);
            _interactionEvent.OnInteraction(player);
            StartCoroutine(WaitAndResetColor());
        }

        private IEnumerator WaitAndResetColor()
        {
            yield return new WaitForSeconds(0.5f);
            _material.SetColor("_Color", _originalColor);
        }

        public void OnHoverEnter()
        {
            Debug.Log($"{gameObject.name} hover enter!");
            objectNotificationComponent.Initialize();
            objectNotificationComponent.SetText(notificationText);
            _material.SetColor("_Color", hoverColor);
        }

        public void OnHoverExit()
        {
            Debug.Log($"{gameObject.name} hover exit!");
            objectNotificationComponent.Close();
            _material.SetColor("_Color", _originalColor);
        }
    }
}