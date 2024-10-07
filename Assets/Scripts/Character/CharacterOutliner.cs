using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterOutliner : MonoBehaviour
{

    [SerializeField] private Material outlineMaterial;
    private Material defaultMaterial;
    private SpriteRenderer characterRenderer;

    private void Start()
    {
        characterRenderer = GetComponentInChildren<SpriteRenderer>();
        defaultMaterial = characterRenderer.material;
    }


    public void SetOutline()
    {
        if (characterRenderer != null && outlineMaterial != null && characterRenderer.material != outlineMaterial)
        {
            //Debug.LogWarning("Material has been set");
            characterRenderer.material = outlineMaterial;
        }
    }

    public void ResetOutline()
    {
        if (characterRenderer != null && defaultMaterial != null && characterRenderer.material != defaultMaterial)
        {
            characterRenderer.material = defaultMaterial;
        }
    }
}
