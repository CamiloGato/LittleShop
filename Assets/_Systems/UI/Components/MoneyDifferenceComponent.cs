using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace UI.Components
{
    public class MoneyDifferenceComponent : BaseComponent
    {
        [Header("Money Difference")]
        [SerializeField] private TMP_Text playerMoneyText;
        [SerializeField] private Color positiveMoneyColor = Color.green;
        [SerializeField] private Color negativeMoneyColor = Color.red;
        
        private UnityEvent<MoneyDifferenceComponent> _callback;
        
        public override void Initialize() { }

        public override void Close()
        {
            playerMoneyText.text = "";
            playerMoneyText.color = Color.white;
            
            _callback = null;
        }
        
        public void SetCallback(UnityEvent<MoneyDifferenceComponent> callback)
        {
            _callback = callback;
        }

        public void SetDifference(int difference)
        {
            Color color = difference > 0 ? positiveMoneyColor : negativeMoneyColor;
            string sign = difference > 0 ? "+" : "-";
            
            playerMoneyText.text = $"{sign}{difference}";
            playerMoneyText.color = color;
        }
        
        #region Animation Methods
        
        public void TurnOff()
        {
            _callback?.Invoke(this);
        }

        #endregion
        
    }
}