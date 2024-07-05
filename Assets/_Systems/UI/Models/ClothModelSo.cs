using _Tools;
using UnityEngine;

namespace UI.Models
{
    public enum ClothType
    {
        Base,
        Out,
        Har,
        Hat
    }
    
    [CreateAssetMenu(menuName = "Item/Create Cloth", fileName = "ClothModelSo", order = 0)]
    public class ClothModelSo : ItemModelSo
    {
        [Header("Cloth")]
        public ClothType type;
        public Sprite down;
        public Sprite up;
        public Sprite left;
        public Sprite right;

        public Sprite this[int index] => index switch
        {
            0 => down,
            1 => left,
            2 => up,
            3 => right,
            _ => null
        };

        public void ChangeLook(ClothModelSo clothModel)
        {
            if (type != clothModel.type) return;
            
            down = clothModel.down;
            up = clothModel.up;
            left = clothModel.left;
            right = clothModel.right;
        }

        #if UNITY_EDITOR
        [Header("Tool")]
        [SerializeField] private string path;
        [SerializeField] private string fileName;
        
        [ContextMenu("Load")]
        private void Load()
        {
            down = SpriteLoader.LoadSprite(path, fileName, 0);
            up = SpriteLoader.LoadSprite(path, fileName, 8);
            left = SpriteLoader.LoadSprite(path, fileName, 24);
            right = SpriteLoader.LoadSprite(path, fileName, 16);

            itemName = $"Cloth-{name}";
            value = Random.Range(200, 1000);
            icon = down;
            description = $"Cloth description for {name}";
        }
        #endif
        
    }
}