/*
  Created by:
  Juan Sebastian Munoz Arango
  naruse@gmail.com
  all rights reserved

  simple singleton class that minimizes the usage of materials in the scene by using same 
  colored materials.
 */

using System;
using System.Collections.Generic;
using UnityEngine;

public class MaterialManager {

    private static MaterialManager instance;
    public static MaterialManager Instance {
        get {
            if (instance == null)
                instance = new MaterialManager();
            return instance;
        }
    }

    private Dictionary<Color, Material> materials;

    private MaterialManager() {
        materials = new Dictionary<Color, Material>();
    }

    public Material GetMaterial(Color c) {
        if(!materials.ContainsKey(c)) {
            Material generatedMat = new Material(Shader.Find("Standard"));
            generatedMat.color = c;
            materials.Add(c, generatedMat);
        }

        return materials[c];
    }


}