using System;
using UnityEngine;

namespace UI.Models
{
    [Serializable]
    public enum TimeStateEnum
    {
        Day,
        Night
    }
    
    [Serializable]
    public class TimeStateModel
    {
        public TimeStateEnum timeState;
        public Sprite timeSprite;
        public float currentTime;
    }
}