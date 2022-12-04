using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectCore.InterfaceManger
{
    [CreateAssetMenu(fileName ="interface data", menuName ="ProjectCore/InterfaceData")]
    public class InterfaceData : ScriptableObject
    {
        [SerializeField] private InterfaceWindow[] m_InterfaceWindows;
        public InterfaceWindow[] InterfaceWindows => m_InterfaceWindows;
    }
}
