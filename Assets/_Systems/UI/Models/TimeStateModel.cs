using System;
using System.Collections.Generic;
using UnityEngine;

namespace UI.Models
{
    [Serializable]
    public class TimeSkySunModel
    {
        public int hourRise;
        public Sprite skySprite;
        public Sprite sunSprite;
    }
    
    [Serializable]
    public class TimeImageModel
    {
        public List<TimeSkySunModel> timeSkySunModels;

        public void Initialize()
        {
            timeSkySunModels.Sort((x, y) => x.hourRise.CompareTo(y.hourRise));
        }
        
        public (Sprite, Sprite) GetTimeSkySun(int hour)
        {
            int count = timeSkySunModels.Count;
            if (count == 0) return (null, null);

            for (int i = 0; i < count; i++)
            {
                TimeSkySunModel currentModel = timeSkySunModels[i];
                TimeSkySunModel nextModel = timeSkySunModels[(i + 1) % count];

                int currentHourRise = currentModel.hourRise;
                int nextHourRise = nextModel.hourRise;
                
                if (
                    (currentHourRise <= hour && hour < nextHourRise)
                    || (currentHourRise <= hour && nextHourRise == 0)
                    || (currentHourRise > nextHourRise && (hour >= currentHourRise || hour < nextHourRise))
                    )
                {
                    return (currentModel.skySprite, currentModel.sunSprite);
                }
            }
            
            throw new Exception("Invalid Hour unexpected");

        }
    }
}