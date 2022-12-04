using ProjectCore.InterfaceManger;
using ProjectCore.InterfaceManger.UIView;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ProjectCore.StateManager
{
    public class LoadingSceneState : BaseState, IFixedUpdatableState
    {
        private readonly string _interfaceKey = "Screen.Loading.Scene";
        protected override string interfaceKey => _interfaceKey;
        private readonly string _loadingSceneName = "LoadingScene";

        private LoadingSceneView _loadingSceneView;
        private float loading = 0;
        private float loadingTime = 2;
        private LoadSceneArgs loadSceneArgs;
        private bool isTargetSceneLoaded;

        public LoadingSceneState(GameManager manager, InterfaceManager interfaceManager) : base(manager, interfaceManager)
        {
        }      

        public override void StateEnd()
        {
            interfaceManager.CloseLastView();
        }

        public void StateFixedUpdate(float delta)
        {
            loading += delta;
            if (loading > loadingTime) loading = loadingTime;
            var loadingValue = loading / loadingTime;
            _loadingSceneView.SliderStatus.value = loadingValue;
            _loadingSceneView.TextStatus.text = $"{(int)(loadingValue * 100)}%";

            if (loading >= loadingTime)
            {
                gameStateManager.StartState(typeof(GameState));
            }
        }     

        public override void StateInit()
        {
            LoadView(out _loadingSceneView);
            SceneManager.sceneLoaded += OnLoadedScene;
            SceneManager.activeSceneChanged += SceneManager_activeSceneChanged;
        }

        private void SceneManager_activeSceneChanged(Scene current, Scene next)
        {           
            if(current.name == _loadingSceneName)
            {
                isTargetSceneLoaded = true;                
            }
        }

        public override void StateStart(IStateArgs stateArgs = null)
        {
            if (stateArgs is LoadSceneArgs loadArgs)
            {
                loading = 0;
                loadSceneArgs = loadArgs;
                interfaceManager.OpenView(_interfaceKey);
                SceneManager.LoadScene(_loadingSceneName);
                return;
            }           
            StateEnd();
           
        }

        private void OnLoadedScene(Scene scene, LoadSceneMode mode)
        {            
            if (scene.name == _loadingSceneName)
            {
                SceneManager.LoadScene(loadSceneArgs.SceneName);
            }
        }
    }
}
