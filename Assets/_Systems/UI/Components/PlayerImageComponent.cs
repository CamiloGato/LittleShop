using UI.Models;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Components
{
    public class PlayerImageComponent : BaseComponent
    {
        [Header("Images")]
        [SerializeField] private Image basePlayer;
        [SerializeField] private Image outPlayer;
        [SerializeField] private Image harPlayer;
        [SerializeField] private Image hatPlayer;
        
        [Header("Data")]
        [SerializeField] private PlayerImageModel playerImageModel;
        
        public override void Initialize() { }
        
        public override void Close() { }
        
        public void SetPlayerModel(PlayerImageModel playerModel)
        {
            playerImageModel = playerModel;
        }
        
        public void UpdatePlayerView(int index)
        {
            playerImageModel.CurrentLook = index;
            
            basePlayer.sprite = playerImageModel.BaseSprite;
            outPlayer.sprite = playerImageModel.OutSprite;
            harPlayer.sprite = playerImageModel.HarSprite;
            hatPlayer.sprite = playerImageModel.HatSprite;
        }

    }
}