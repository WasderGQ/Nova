using UnityEngine;
using WasderGQ.Parkur._Scripts.Enums;

namespace WasderGQ.Parkur._Scripts.Player
{
    public class MainPlayer : MonoBehaviour
    {
        public PlayerStatu PlayerStatu { get ; private set; } 
        
        void Start()
        {
            OnstartSetPlayer();
        }
        
        private void OnstartSetPlayer()
        {
            PlayerStatu = PlayerStatu.playable;
        }
    
    
    
    }
}
