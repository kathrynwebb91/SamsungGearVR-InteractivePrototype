using UnityEngine;
using System;
using System.Reflection;

using strange.extensions.mediation.impl;
using strange.extensions.signal.impl;
using strange.extensions.context.impl;

namespace Demo { 
    public class PortalMenuMediator : Mediator
    {

        [Inject]
        public TouchpadInputSignal<string> touchInputSignal { get; set; }

        [Inject]
        public PortalMenuView portalView { get; set; }


	    // Use this for initialization
        public override void OnRegister()
        {
            print("Registered portalmenu mediator");
            touchInputSignal.AddListener(InputHandler);
        }

        protected void InputHandler(String inputType){
            print("Input handler recieved " + inputType);

            switch (inputType)
            {
                case "tap":
                    portalView.tapped();
                break;
                case "left":
                    portalView.swipedLeft();
                break;
                case "right":
                    portalView.swipedRight();
                break;
                case "up":
                    portalView.swipedUp();
                break;
                case "down":
                    portalView.swipedDown();
                break;
            }
            
        }
	
    }
}

