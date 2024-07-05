using System.Collections.Generic;
using UI.Models;
using UnityEngine;
using UnityEngine.Events;
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

        private int _playerLook;
        
        public override void Initialize() { }

        public override void Close() { }

        public void SetPlayerCloth(List<ClothModelSo> playerClothesModelSo)
        {
            foreach (ClothModelSo cloth in playerClothesModelSo)
            {
                UpdatePlayerCloth(cloth);
            }
        }
        
        public void UpdatePlayerView(int viewLook)
        {
            _playerLook = viewLook;
        }
        
        public void UpdatePlayerCloth(ClothModelSo cloth)
        {
            switch (cloth.type)
            {
                case ClothType.Base:
                    basePlayer.sprite = cloth[_playerLook];
                    break;
                case ClothType.Out:
                    outPlayer.sprite = cloth[_playerLook];
                    break;
                case ClothType.Har:
                    harPlayer.sprite = cloth[_playerLook];
                    break;
                case ClothType.Hat:
                    hatPlayer.sprite = cloth[_playerLook];
                    break;
            }
        }
        
        public void UpdatePlayerItem(ItemModelSo model)
        {
            itemPlayer.sprite = model.icon;
        }

    }
}