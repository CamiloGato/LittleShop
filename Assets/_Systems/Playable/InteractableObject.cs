using UI.Components;
using UnityEngine;

namespace Playable
{
    public class InteractableObject : MonoBehaviour, IInteractable
    {
        [SerializeField] private ObjectNotificationComponent objectNotificationComponent;
        [SerializeField] private string notificationText;
        [SerializeField] private Color hoverColor = Color.yellow;
        [SerializeField] private Color interactColor = Color.red;
         
            
        private Material _material;
        private Color _originalColor;

        private void Awake()
        {
            _material = GetComponent<Renderer>().material;
            _originalColor = _material.GetColor("_Color"); // Assuming the property is called "_Color"
        }

        public void OnClick()
        {
            Debug.Log($"{gameObject.name} clicked!");
            _material.SetColor("_Color", interactColor);
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