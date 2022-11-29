using ProjectCore.InterfaceManger;
using ProjectCore.InterfaceManger.UIView;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ProjectCore.StateManager
{
    public class LoadingGameState : BaseState, IState, IFixedUpdatableState
    {      
        private readonly string _interfaceKey = "Screen.Loading";
        protected override string interfaceKey => _interfaceKey;
        private LoadingSceneView _loadingSceneView;

        private float loading = 0;
        private float loadingTime = 2;     

        public LoadingGameState(GameManager manager, InterfaceManager interfaceManager) : base(manager, interfaceManager)
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
                gameStateManager.StartState(typeof(MainMenuState));
            }
        }

        public override void StateInit()
        {
            LoadView(out _loadingSceneView);
        }        

        public override void StateStart(IStateArgs stateArgs = null)
        {                        
            interfaceManager.OpenView(_interfaceKey);               
        }      
    }
}
