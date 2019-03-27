using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "AvatarData")]
public class AvatarData : ScriptableObject {
    public Sprite headSprite;
    public Sprite chestSprite;
    public Sprite RArmSprite;

    public string[] attributes;

}
