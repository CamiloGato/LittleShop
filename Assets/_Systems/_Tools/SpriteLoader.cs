using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace _Tools
{
    public static class SpriteLoader
    {
        public static Sprite LoadSprite(string path, string fileName, int startIndex = 0)
        {
            var sprites = Resources.LoadAll<Sprite>(path + fileName);
            Debug.Log($"Loading Sprite Path: {path + fileName}");
            if (sprites.Length == 0)
            {
                throw new System.Exception("Sprite not found");
            }
            return sprites[startIndex];
        }
        
        public static List<Sprite> LoadSprites(string path, string fileName,int amount, int startIndex = 0)
        {
            var sprites = Resources.LoadAll<Sprite>(path + fileName);
            Debug.Log($"Loading Sprite Path: {path + fileName}");
            if (sprites.Length == 0)
            {
                throw new System.Exception("Sprite not found");
            }
            return sprites[startIndex..(startIndex + amount)].ToList();
        }
    }
}