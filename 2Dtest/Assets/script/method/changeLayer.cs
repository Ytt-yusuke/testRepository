using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class changeLayer
{
    public static void SetLayerRecursively(
       this GameObject self,
       int layer
   )
    {
        self.layer = layer;

        foreach (Transform n in self.transform)
        {
            SetLayerRecursively(n.gameObject, layer);
        }
    }
}
