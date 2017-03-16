/*
  Created by:
  Juan Sebastian Munoz Arango
  naruse@gmail.com
  all rights reserved

  This class gives checks on the detected image target and keeps track of it.
 */

using UnityEngine;


public sealed class ImageTargetManager : MonoBehaviour {

    //the main target are the sheets themselves.
    private GameObject currentMainImgTarget;
    //secondary image targets draw the menus on the right
    private GameObject currentSecondaryImgTarget;



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

    public GameObject GetCurrentMainTarget() {
        return currentMainImgTarget;
    }

    public void SetCurrentMainTarget(GameObject g) {
        currentMainImgTarget = g;
    }
}