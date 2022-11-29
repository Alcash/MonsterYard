using ProjectCore.InterfaceManger;
using ProjectCore.InterfaceManger.UIView;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectCore.StateManager
{
    public class GamePauseState : BaseState
    {
        private readonly string _interfaceKey = "Screen.GamePause";
        protected override string interfaceKey => _interfaceKey;

        private GamePauseView _view;
        public GamePauseState(GameManager manager, InterfaceManager interfaceManager) : base(manager, interfaceManager)
        {
        }

        public override void StateEnd()
        {
            interfaceManager.CloseLastView();
        }

        public override void StateInit()
        {
            if (LoadView(out _view))
            {
                _view.ButtonResume.onClick.AddListener(OnResumeCicked);
                _view.ButtonExit.onClick.AddListener(OnExitGameCicked);
            }
        }

        private void OnResumeCicked()
        {
            gameStateManager.StartState(typeof(GameState));
        }

        private void OnExitGameCicked()
        {
            gameStateManager.StartState(typeof(LoadingSceneState), new LoadSceneArgs("MenuScene"));
        }

        public override void StateStart(IStateArgs stateArgs = null)
        {
            interfaceManager.OpenView(interfaceKey);
        }
    }
}
