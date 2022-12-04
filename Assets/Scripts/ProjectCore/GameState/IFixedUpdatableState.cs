using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectCore.StateManager
{
    public interface IFixedUpdatableState
    {
        void StateFixedUpdate(float delta);
    }
}
