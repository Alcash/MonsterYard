using UnityEngine;
using UnityEngine.UI;

namespace ProjectCore.InterfaceManger.UIView
{
    public class GameStateView : MonoBehaviour
    {
        [SerializeField] private Button m_ButtonPause;
        public Button ButtonPause => m_ButtonPause;
       
    }
}
