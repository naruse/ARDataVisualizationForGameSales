/*
  Created by:
  Juan Sebastian Munoz Arango
  naruse@gmail.com
  all rights reserved

  This class gives checks on the detected image target and keeps track of it.
 */

using UnityEngine;


public sealed class ImageTargetManager : MonoBehaviour {

    public GameObject testImgTarget;

    private static ImageTargetManager instance;

    public static ImageTargetManager Instance {
        get {
            if(instance == null)
                instance = new GameObject("ImageTargetManagerSingleton").AddComponent<ImageTargetManager>();
            return instance;
        }
    }
    void Awake() {
        instance = this;
    }

    public GameObject GetCurrentTarget() {
        return testImgTarget;
    }
}