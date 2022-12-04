using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectCore.StateManager
{
    public class LoadSceneArgs : IStateArgs
    {
        public string SceneName { get; private set; }

        public LoadSceneArgs(string sceneName)
        {
            SceneName = sceneName;
        }
    }
}
