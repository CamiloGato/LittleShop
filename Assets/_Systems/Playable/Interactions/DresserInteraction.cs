using Shop;
using UI;
using UI.Models;
using UnityEngine;

namespace Playable.Interactions
{
    public class DresserInteraction : MonoBehaviour, IInteractionEvent
    {
        private UIFacade _uiFacade;
        
        private Player.Player _player;
        private PlayerClothesModelSo _playerClothesModel;
        
        private PlayerClothesList _selectedClothes;
        private ItemModelSo _selectedItem;
        
        public void OnInteraction(Player.Player player)
        {
            _player = player;
            _playerClothesModel = player.playerClothesModel;
            _selectedClothes = new PlayerClothesList(_playerClothesModel.clothes);
            
            _uiFacade = ServiceLocator.Instance.Get<UIFacade>();
            
            _uiFacade.OpenShop(
                "Dresser", "Save",
                _player.playerInfoModel.playerInventoryModel.Items,
                OnShop, OnClose, OnUse
            );
        }

        private void OnUse()
        {
            _playerClothesModel.ChangeCloth(_selectedClothes);
            _uiFacade.ShowPopUp("Clothes Saved", "Your clothes saved", "good");
        }

        private void OnClose()
        {
            _uiFacade.ShowPopUp("Looks Good!", "Ulala you look so good", "sexy");
        }

        private void OnShop(ItemModelSo item)
        {
            if (item is ClothModelSo cloth)
            {
                ClothType type = cloth.type;
                ClothModelSo newCloth = _selectedClothes[type] == cloth 
                    ? _playerClothesModel.clothes[type]
                    : cloth;
                
                _selectedClothes.ChangeLook(newCloth);
            }
            else
            {
                ItemModelSo newItem = _selectedItem == item 
                    ? _player.playerInfoModel.playerInventoryModel.Items[0]
                    : item;
                
                _selectedItem = newItem;
            }
        }
    }
}
