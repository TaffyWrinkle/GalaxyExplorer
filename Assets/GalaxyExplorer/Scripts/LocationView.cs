﻿// Copyright Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using UnityEngine;

namespace GalaxyExplorer
{
    public class LocationView : MonoBehaviour
    {
        [Header("Background Music")]
        [SerializeField]
        private string MusicEvent = "";

        [SerializeField]
        private float MusicDelayInSeconds = 1.0f;

        [Header("Voice Over")]
        [SerializeField]
        private VOManager.QueuedAudioClip VoiceOver = null;

        private bool playMusic = true;
        private float delayTimer = 0.0f;

    
        void Start()
        {
            delayTimer = MusicDelayInSeconds;
 
            if (GalaxyExplorerManager.Instance.VoManager && !GalaxyExplorerManager.Instance.TransitionManager.IsInIntroFlow)
            {
                GalaxyExplorerManager.Instance.VoManager.Stop(true);
                GalaxyExplorerManager.Instance.VoManager.PlayClip(VoiceOver);
            }
        }

        void Update()
        {
            if (playMusic && !GalaxyExplorerManager.Instance.TransitionManager.IsInIntroFlow)
            {
                delayTimer -= Time.deltaTime;
                if (delayTimer <= 0.0f)
                {
                    GalaxyExplorerManager.Instance.MusicManagerScript.FindSnapshotAndTransition(MusicEvent);
                    playMusic = false;
                }
            }
        }
    }
}
