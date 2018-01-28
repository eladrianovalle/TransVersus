using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets._2D
{
    [RequireComponent(typeof (PlatformerCharacter2D))]
    public class Platformer2DUserControl : MonoBehaviour
    {
        private PlatformerCharacter2D m_Character;
        private bool m_Jump;

		private Player m_Player;

        private void Awake()
        {
            m_Character = GetComponent<PlatformerCharacter2D>();
			m_Player = GetComponent<Player> ();
        }


        private void Update()
        {
            if (!m_Jump)
            {
                // Read the jump input in Update so button presses aren't missed.
				m_Jump = m_Player.isJumping;
//					CrossPlatformInputManager.GetButtonDown("Jump");
            }
        }


        private void FixedUpdate()
        {
            // Read the inputs.
//            bool crouch = Input.GetKey(KeyCode.LeftControl);
			float h = m_Player.playerMovement;
//				CrossPlatformInputManager.GetAxis("Horizontal");
			m_Jump = m_Player.isJumping;

            // Pass all parameters to the character control script.
            m_Character.Move(h, m_Jump);
            m_Jump = false;
        }
    }
}
