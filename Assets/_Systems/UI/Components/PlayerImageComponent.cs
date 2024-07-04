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
        [SerializeField] private Image itemPlayer;
        
        [Header("Data")]
        [SerializeField] private PlayerImageModel playerImageModel;

        public override void Initialize() { }

        public override void Close()
        {
            playerImageModel.CurrentLook = 0;
            
            basePlayer.sprite = null;
            outPlayer.sprite = null;
            harPlayer.sprite = null;
            hatPlayer.sprite = null;
            itemPlayer.sprite = null;
        }
        
        public void SetPlayerModel(PlayerImageModel playerModel)
        {
            playerImageModel = playerModel;
        }
        
        public void UpdatePlayerView(int index)
        {
            playerImageModel.CurrentLook = index;
            
            basePlayer.sprite = playerImageModel[ClothImageType.Base];
            outPlayer.sprite = playerImageModel[ClothImageType.Out];
            harPlayer.sprite = playerImageModel[ClothImageType.Har];
            hatPlayer.sprite = playerImageModel[ClothImageType.Hat];
        }
        
        public void UpdatePlayerItemView(ItemModel itemModel)
        {
            itemPlayer.sprite = itemModel.icon;
        }
        
        public void UpdatePlayerClothView(ClothModel clothModel)
        {
            playerImageModel.ChangeClothLook(clothModel.clothImagePosture);
            UpdatePlayerView(playerImageModel.CurrentLook);
        }

    }
}