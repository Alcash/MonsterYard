using System;
using System.Collections.Generic;
using UnityEngine;
using ProjectCore.InterfaceManger;

namespace ProjectCore.StateManager
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private InterfaceManager _interfaceManger;
        private Dictionary<Type,IState> _states;
        private IUpdatableState _updatableState;
        private IFixedUpdatableState _fixedUpdatableState;
        private IState _currentState;
        private Camera _camera;

        private void Awake()
        {
            DontDestroyOnLoad(this);
        }
        private void Start()
        {
            _camera = Camera.main;
            _states = new Dictionary<Type,IState>();
            AddState(new LoadingGameState(this, _interfaceManger));
            AddState(new LoadingSceneState(this, _interfaceManger));

            AddState(new MainMenuState(this, _interfaceManger));
            AddState(new OptionsMainMenuState(this, _interfaceManger));
            AddState(new GameState(this, _interfaceManger));
            AddState(new GamePauseState(this, _interfaceManger));

            foreach (var state in _states)
            {    
                state.Value.StateInit();
            }
            StartState(typeof(LoadingGameState));
        }

        private void AddState(IState state)
        {
            _states.Add(state.GetType(), state);
        }

        private void Update()
        {
            _updatableState?.StateUpdate(Time.deltaTime);
        }

        private void FixedUpdate()
        {
            _fixedUpdatableState?.StateFixedUpdate(Time.fixedDeltaTime);
        }

        public void StartState(Type stateName, IStateArgs stateArgs = null)
        {
            _currentState?.StateEnd();
            _currentState = _states[stateName];

            if (_currentState is IUpdatableState updatableState)
            {
                _updatableState = updatableState;
            }
            else
            {
                _updatableState = null;
            }

            if (_currentState is IFixedUpdatableState fixedUpdatableState)
            {
                _fixedUpdatableState = fixedUpdatableState;
            }
            else
            {
                _fixedUpdatableState = null;
            }

            _currentState.StateStart(stateArgs);
        }
    }
}