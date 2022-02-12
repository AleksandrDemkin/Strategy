using UnityEngine;

namespace Assets.Scripts.Abstractions
{
    public interface ISelectable
    {
        float Health { get; }
        float MaxHealth { get; }
        Sprite Icon { get; }
        
        Color OutlineColor { get; }
        float OutlineWidth { get; }
        
        Material ShaderMaterial { get; }
    }
}
