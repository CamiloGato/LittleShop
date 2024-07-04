using UI.Controllers;
using UnityEngine;

namespace UI
{
    public class UIFacade : MonoBehaviour
    {
        [Header("Controllers")]
        [SerializeField] private PlayerRenderController playerRenderController;
        [SerializeField] private ShopItemsController shopItemsController;
        [SerializeField] private ShopTransactionController shopTransactionController;
        
        [Header("Data")]
        [SerializeField] private string playerRenderView;
        
        public void Initialize()
        {
            playerRenderController.Initialize();
            shopItemsController.Initialize();
            shopTransactionController.Initialize();
        }

        public void Close()
        {
            playerRenderController.Close();
            shopItemsController.Close();
            shopTransactionController.Close();
        }
        
        
        
    }
}