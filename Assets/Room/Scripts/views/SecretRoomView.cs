using UnityEngine;
using System;
using System.Reflection;

using strange.extensions.mediation.impl;
using strange.extensions.signal.impl;

namespace Demo{

public class SecretRoomView : View
{

	public ObjectState     	state;
    private Roll            roll;
	private Drop			drop;
	private ExpandRoom		expander;
	
	void Awake()
	{
		state = this.GetComponent<ObjectState>();
		drop = this.GetComponent<Drop>();
        roll = this.GetComponent<Roll>();
		expander = GameObject.Find("Wall - 1").GetComponent<ExpandRoom>();
	}
	
	public void receivedInteraction(TouchEvent evt)
	{
		if(state.hit || state.selected)
		{
			switch (evt)
			{
			case TouchEvent.Tap:
				if(!drop.dropped){
					drop.drop();
					expander.pushWall();
				}
				break;
			case TouchEvent.SwipeLeft:
                roll.roll();
				break;
			case TouchEvent.SwipeRight:
				

				break;
			case TouchEvent.SwipeUp:

				break;
			case TouchEvent.SwipeDown:

				break;
			}
		}
	}

}

}