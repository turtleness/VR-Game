using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

namespace Valve.VR
{
    public class Movement : MonoBehaviour
    {

        private SteamVR_ActionSet[] actionSets;
        private SteamVR_ActionSet set;
        private SteamVR_Action action;
        private SteamVR_Action tpad;

        private SteamVR_Input_Sources[] sources;
        private SteamVR_Input_Sources source;
        private SteamVR_Action_Boolean actionBoolean;
        private SteamVR_Action_Vector2 actionVector2;

        private bool click;
        private float tpad_x;
        private float tpad_y;

        public GameObject player;
        private Vector3 playerPos;

        public float movesp = 10f;

       

        // Use this for initialization
        void Start()
        {
            sources = SteamVR_Input_Source.GetUpdateSources();
            source = sources[1];//righthand

            if (actionSets == null)
            {
                actionSets = SteamVR_Input_References.instance.actionSetObjects;
            }
            set = actionSets[0];//default
            action = set.allActions[1];//teleport click
            tpad = set.allActions[8];//tpad

            actionBoolean = (SteamVR_Action_Boolean)action;
            actionVector2 = (SteamVR_Action_Vector2)tpad;
        }

        // Update is called once per frame
        void Update()
        {
            click = actionBoolean.GetState(source);
            tpad_x = actionVector2.GetAxis(source).x;
            tpad_y = actionVector2.GetAxis(source).y;

            if (Input.GetKey(KeyCode.W) || (click && tpad_y > 0 && tpad_x < 0.7f && tpad_x > -0.7f))
            {
                player.transform.position = new Vector3(player.transform.position.x, 0f, transform.position.z + movesp);
            }
            if (Input.GetKey(KeyCode.A) || (click && tpad_x < 0 && tpad_y < 0.7f && tpad_y > -0.7f)) //rotat
            {
                player.transform.position = new Vector3(player.transform.position.x - movesp, 0f, transform.position.z);
            }
            if (Input.GetKey(KeyCode.S) || (click && tpad_y < 0 && tpad_x < 0.7f && tpad_x > -0.7f))
            {
                player.transform.position = new Vector3(player.transform.position.x, 0f, transform.position.z - movesp);
            }
            if (Input.GetKey(KeyCode.D) || (click && tpad_x > 0 && tpad_y < 0.7f && tpad_y > -0.7f)) //rotate right
            {
                player.transform.position = new Vector3(player.transform.position.x + movesp, 0f, transform.position.z);
            }
        }
    }
}
