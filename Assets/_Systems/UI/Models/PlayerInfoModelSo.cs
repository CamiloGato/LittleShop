using UnityEngine;
using UnityEngine.Events;

namespace UI.Models
{
    [CreateAssetMenu(menuName = "Player/Create Player Info", fileName = "PlayerInfoModelSo", order = 0)]
    public class PlayerInfoModelSo : ScriptableObject
    {
        public UnityEvent<string> onPlayerNameChanged;
        
        public PlayerWalletModelSo playerWalletModel;
        public PlayerInventoryModelSo playerInventoryModel;
        
        [SerializeField] private string playerName;
        
        public string PlayerName
        {
            get => playerName;
            set
            {
                playerName = value;
                onPlayerNameChanged?.Invoke(playerName);
            }
        }
        
        #if UNITY_EDITOR

        public void OnValidate()
        {
            onPlayerNameChanged.Invoke(playerName);
        }

#endif
    }
}