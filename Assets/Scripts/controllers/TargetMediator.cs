using UnityEngine;
using System;
using System.Reflection;

using strange.extensions.mediation.impl;
using strange.extensions.signal.impl;
using strange.extensions.context.impl;

namespace Demo { 
    public class TargetMediator : Mediator
    {

        [Inject]
        public TouchpadInputSignal<string> touchInputSignal { get; set; }

        [Inject]
        public TargetView targetView { get; set; }


	    // Use this for initialization
        public override void OnRegister()
        {
            print("Registered target mediator");
            touchInputSignal.AddListener(InputHandler);
        }

        protected void InputHandler(String inputType){
            print("Input handler recieved " + inputType);

            switch (inputType)
            {
                case "tap":
                    targetView.tapped();
                break;
                case "left":
                    targetView.swipedLeft();
                break;
                case "right":
                    targetView.swipedRight();
                break;
                case "up":
                    targetView.swipedUp();
                break;
                case "down":
                    targetView.swipedDown();
                break;
            }
            
        }
	
    }
}

