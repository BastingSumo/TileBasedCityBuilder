using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MaterialTools
{
    public static void AssignMaterial(Material material, GameObject gameObject)
    {
        MeshRenderer meshRenderer = gameObject.GetComponentInChildren<MeshRenderer>();
        Material[] oldMaterials = meshRenderer.materials;
        List<Material> newMaterials = new List<Material>();
        for (int i = 0; i < oldMaterials.Length; i++)
        {
            newMaterials.Add(material);
        }
        meshRenderer.materials = newMaterials.ToArray();
    }
}
