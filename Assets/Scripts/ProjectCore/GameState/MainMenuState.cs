using ProjectCore.InterfaceManger.UIView;
using ProjectCore.InterfaceManger;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectCore.StateManager
{
    public class MainMenuState : BaseState
    {     
        private readonly string _interfaceKey = "Screen.MainMenu";
        protected override string interfaceKey => _interfaceKey;
        private MainMenuView _view;

        public MainMenuState(GameManager manager, InterfaceManager interfaceManager) : base(manager, interfaceManager)
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
                _view.SettingButton.onClick.AddListener(OnOptionsButton);
                _view.StartGameButton.onClick.AddListener(OnStartButton);
                _view.ExitGameButton.onClick.AddListener(OnExitButton);
            }
        }

        private void OnOptionsButton()
        {
            gameStateManager.StartState(typeof(OptionsMainMenuState));
        }

        private void OnStartButton()
        {
            gameStateManager.StartState(typeof(LoadingSceneState), new LoadSceneArgs("GameScene"));
        }

        private void OnExitButton()
        {
#if !UNITY_EDITOR
            Application.Quit();
#else
            UnityEditor.EditorApplication.isPlaying = false;
#endif
        }

        public override void StateStart(IStateArgs stateArgs = null)
        {
            interfaceManager.OpenView(_interfaceKey);
        }      
    }
}
