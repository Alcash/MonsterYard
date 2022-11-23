using ProjectCore.InterfaceManger;
using ProjectCore.InterfaceManger.UIView;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectCore.StateManager
{
    public class LoadingGameState : IState
    {
        private readonly GameManager _gamePlayManager;
        private readonly InterfaceManager _interfaceManager;
        private readonly string _interfaceKey = "Screen.Loading";
        private InterfaceWindow _loadingWindow;
        private LoadingSceneView _loadingSceneView;
        private float loading = 0;
        private float loadingTime = 2;

        public LoadingGameState(GameManager manager , InterfaceManager interfaceManager)
        {
            _gamePlayManager  = manager;
            _interfaceManager = interfaceManager;
        }

        public void StateEnd()
        {
            _interfaceManager.CloseLastView();
        }

        public void StateInit()
        {
            if (_interfaceManager.LoadView(_interfaceKey, out _loadingWindow))
            {
                _loadingSceneView = _loadingWindow.GetComponent<LoadingSceneView>();
            }
        }

        public void StateStart()
        {            
            _interfaceManager.OpenView(_interfaceKey);
        }

        public void StateUpdate(float delta)
        {
            loading += delta;

            _loadingSceneView.SliderStatus.value = loading;
            _loadingSceneView.TextStatus.text = $"{(int)((loading/ loadingTime) * 100)}%";

            if (loading >= loadingTime)
            {
                _gamePlayManager.StartState(typeof(MainMenuState));
            }
        }


    }
}
