using UnityEngine;
using UnityEngine.UI;

namespace ProjectCore.InterfaceManger.UIView
{
    public class GamePauseView : MonoBehaviour
    {
        [SerializeField] private Button m_ButtonExit;
        public Button ButtonExit => m_ButtonExit;

        [SerializeField] private Button m_ButtonResume;
        public Button ButtonResume => m_ButtonResume;
    }
}
