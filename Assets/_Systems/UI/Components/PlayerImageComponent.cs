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
        private PlayerClothesList _playerClothes;
        private ItemModelSo _playerItem;
        
        private PlayerClothesList _currentPlayerClothes;
        private ItemModelSo _currentPlayerItem;
        
        public override void Initialize() { }

        public override void Close() { }

        public void SetUpPlayer(PlayerClothesList playerClothesList, ItemModelSo itemModelSo)
        {
            _playerClothes = playerClothesList;
            _playerItem = itemModelSo;
            
            _currentPlayerClothes = new PlayerClothesList(playerClothesList);
            _currentPlayerItem = itemModelSo;
            
            UpdatePlayerItem(itemModelSo);
            UpdatePlayerView(_playerLook);
        }
        
        public void UpdatePlayerView(int viewLook)
        {
            _playerLook = viewLook;;
            UpdatePlayerSprites();
        }
        
        public void UpdatePlayerCloth(ClothModelSo cloth)
        {
            ClothModelSo newCloth = _currentPlayerClothes[cloth.type] == cloth 
                    ? _playerClothes[cloth.type] 
                    : cloth;
            
            _currentPlayerClothes.ChangeLook(newCloth);
            
            UpdatePlayerSprites();
        }

        private void UpdatePlayerSprites()
        {
            basePlayer.sprite = _currentPlayerClothes[ClothType.Base][_playerLook];
            outPlayer.sprite = _currentPlayerClothes[ClothType.Out][_playerLook];
            harPlayer.sprite = _currentPlayerClothes[ClothType.Har][_playerLook];
            hatPlayer.sprite = _currentPlayerClothes[ClothType.Hat][_playerLook];
        }

        public void UpdatePlayerItem(ItemModelSo model)
        {
            ItemModelSo newItemModel = _currentPlayerItem == model 
                ? _playerItem
                : model;
            _currentPlayerItem = newItemModel;
            
            UpdateItemSprite();
        }

        private void UpdateItemSprite()
        {
            itemPlayer.sprite = _currentPlayerItem.icon;
        }

    }
}