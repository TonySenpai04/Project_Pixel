using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D.Animation;

public class ChangeSkinPet : MonoBehaviour
{
    [SerializeField] public SpriteLibraryAsset[] SkinData;

    private SpriteLibrary spriteLibrary;
    // Start is called before the first frame update
    private void Awake()
    {
        spriteLibrary = GetComponent<SpriteLibrary>();
    }

    public void ChangePetSkin(SpriteLibraryAsset newSkin)
    {
        if(spriteLibrary)
        {
            spriteLibrary.spriteLibraryAsset = newSkin;
        }
    }
}
