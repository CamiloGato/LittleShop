using UnityEngine;
using UnityEngine.Events;

namespace UI.Models
{
    [CreateAssetMenu(menuName = "Player/Create Player Info", fileName = "PlayerInfoModelSo", order = 0)]
    public class PlayerInfoModelSo : ScriptableObject
    {
        public UnityEvent<string, int> onPlayerInfoChanged;
        
        [SerializeField] private string playerName;
        [SerializeField] private int playerMoney;
        
        public string PlayerName
        {
            get => playerName;
            set
            {
                playerName = value;
                onPlayerInfoChanged?.Invoke(playerName, playerMoney);
            }
        }

        public int PlayerMoney
        {
            get => playerMoney;
            set
            {
                playerMoney = value;
                onPlayerInfoChanged?.Invoke(playerName, playerMoney);
            }
        }
    }
}