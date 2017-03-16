/*==============================================================================
Copyright (c) 2010-2014 Qualcomm Connected Experiences, Inc.
All Rights Reserved.
Confidential and Proprietary - Protected under copyright and other laws.
==============================================================================*/

using UnityEngine;

namespace Vuforia
{
    /// <summary>
    /// A custom handler that implements the ITrackableEventHandler interface.
    /// </summary>
    public class CustomTrackableEventHandler : MonoBehaviour, ITrackableEventHandler {

        public GameObject uiGameObject;
        public bool isMainImgTarget = false;

        private TrackableBehaviour mTrackableBehaviour;

        void Start()
        {
            if(uiGameObject == null)
                Debug.LogError("ERROR uigameobject for " + this.gameObject.name + " is null");
            mTrackableBehaviour = GetComponent<TrackableBehaviour>();
            if (mTrackableBehaviour)
            {
                mTrackableBehaviour.RegisterTrackableEventHandler(this);
            }
        }



        /// <summary>
        /// Implementation of the ITrackableEventHandler function called when the
        /// tracking state changes.
        /// </summary>
        public void OnTrackableStateChanged(
                                        TrackableBehaviour.Status previousStatus,
                                        TrackableBehaviour.Status newStatus) {
            if (newStatus == TrackableBehaviour.Status.DETECTED ||
                newStatus == TrackableBehaviour.Status.TRACKED ||
                newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED) {
                OnTrackingFound();
            } else {
                OnTrackingLost();
            }
        }

        private void OnTrackingFound() {
            uiGameObject.SetActive(true);
            if(isMainImgTarget)
                ImageTargetManager.Instance.SetCurrentMainTarget(this.gameObject);

            Renderer[] rendererComponents = GetComponentsInChildren<Renderer>(true);
            Collider[] colliderComponents = GetComponentsInChildren<Collider>(true);

            // Enable rendering:
            foreach (Renderer component in rendererComponents) {
                component.enabled = true;
            }

            // Enable colliders:
            foreach (Collider component in colliderComponents) {
                component.enabled = true;
            }

            Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " found");
        }


        private void OnTrackingLost() {
            if(uiGameObject)
                uiGameObject.SetActive(false);

            Renderer[] rendererComponents = GetComponentsInChildren<Renderer>(true);
            Collider[] colliderComponents = GetComponentsInChildren<Collider>(true);

            // Disable rendering:
            foreach (Renderer component in rendererComponents) {
                component.enabled = false;
            }

            // Disable colliders:
            foreach (Collider component in colliderComponents) {
                component.enabled = false;
            }
            Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " lost");
        }
    }
}
