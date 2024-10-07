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
        characterRenderer = GetComponent<SpriteRenderer>();
        defaultMaterial = characterRenderer.material;
    }


    public void SetOutline()
    {
        if (characterRenderer != null && outlineMaterial != null)
        {
            characterRenderer.material = outlineMaterial;
            Debug.Log(gameObject.name + " outline applied.");
        }
    }

    public void ResetOutline()
    {
        if (characterRenderer != null && characterRenderer != null)
        {
            characterRenderer.material = defaultMaterial;
            Debug.Log(gameObject.name + " outline removed.");
        }
    }
}
