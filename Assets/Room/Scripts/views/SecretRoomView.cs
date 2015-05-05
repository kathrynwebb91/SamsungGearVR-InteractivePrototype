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
		expander = GameObject.Find("SecretRoom Wall").GetComponent<ExpandRoom>();
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
                roll.roll(new Vector3(0, 100, 0));
				break;
			case TouchEvent.SwipeRight:
                roll.roll(new Vector3(100, 0, 0));
				break;
			case TouchEvent.SwipeUp:
                roll.roll(new Vector3(0, 0, 100));
				break;
			case TouchEvent.SwipeDown:

				break;
			}
		}
	}

}

}