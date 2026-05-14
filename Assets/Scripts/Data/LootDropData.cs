using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class LootDropData : SerializedScriptableObject
{
    [SerializeField] public Dictionary<GameObject, float> PickupChanceMap;
    
    
}
