using Shop.Trade;
using UI.Models;
using UnityEngine;

namespace Playable.Player
{
    public class Player : TradeEntity
    {
        public CartModelSo cartModel;
        public PlayerClothesModelSo playerClothesModel;

        [Header("Clothes Renderers")]
        public SpriteRenderer baseRenderer;
        public SpriteRenderer outRenderer;
        public SpriteRenderer hairRenderer;
        public SpriteRenderer hatRenderer;

        private void OnEnable()
        {
            playerClothesModel.onClothesChanged.AddListener(UpdateClothes);
            UpdateAllClothes();
        }

        private void OnDisable()
        {
            playerClothesModel.onClothesChanged.RemoveListener(UpdateClothes);
        }

        private void UpdateAllClothes()
        {
            UpdateClothes(playerClothesModel.clothes.baseCloth);
            UpdateClothes(playerClothesModel.clothes.outCloth);
            UpdateClothes(playerClothesModel.clothes.harCloth);
            UpdateClothes(playerClothesModel.clothes.hatCloth);
        }

        private void UpdateClothes(ClothModelSo clothModel)
        {
            switch(clothModel.type)
            {
                case ClothType.Base:
                    break;
                case ClothType.Out:
                    outRenderer.sprite = clothModel[0];
                    break;
                case ClothType.Har:
                    hairRenderer.sprite = clothModel[0];
                    break;
                case ClothType.Hat:
                    hatRenderer.sprite = clothModel[0];
                    break;
            }
        }
    }
}