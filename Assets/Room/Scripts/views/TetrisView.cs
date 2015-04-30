using UnityEngine;
using System.Collections;

using strange.extensions.mediation.impl;
using strange.extensions.signal.impl;

namespace Demo {

	public class TetrisView : View {

		private ChangeColour frameColour;
		private GameObject frame;
		private int numberOfBlocks = 1;
		private GameObject currentBlock;
		private ArrayList placedBlocks = new ArrayList();
		private BlockState blockState;

		override protected void Awake()
		{
			base.Awake();
			frameColour = gameObject.GetComponentInChildren<ChangeColour>();
			frame = gameObject.transform.FindChild("TetrisFrame").gameObject;
			currentBlock = generateNewBlock ();
			currentBlock.AddComponent<BlockState> ();
			blockState =  currentBlock.GetComponent<BlockState>();
		}

		void moveBlock(GameObject block){
			iTween.MoveBy (block, new Vector3 (0, -5, 0), 0.1F);
		}

		void addBlock(){
			currentBlock = generateNewBlock ();
		}

		GameObject generateNewBlock(){
			int typenum = Random.Range(0, ((int)BlockState.BlockType.NumberOfTypes - 1));
			string blockType = ((BlockState.BlockType)typenum).ToString ();
			GameObject newBlock = (GameObject)Instantiate(Resources.Load("Prefabs/" + blockType+"Block", typeof(GameObject)),transform.position, transform.rotation);
			newBlock.transform.parent = this.gameObject.transform;
			float ydisp = 84 - 12.5F;
			float xdisp = 7.5F; 
			newBlock.transform.localPosition = new Vector3(0,ydisp,xdisp);
			return newBlock;
		}


		public void receivedInteraction(TouchEvent evt)
		{
			//if(state.hit || state.selected)
			//{
				switch (evt)
				{
				case TouchEvent.Tap:

					break;
				case TouchEvent.SwipeLeft:

					break;
				case TouchEvent.SwipeRight:

					break;
				case TouchEvent.SwipeUp:

					break;
				case TouchEvent.SwipeDown:

					break;
				}
			//}
		}

		void Update(){
			if (currentBlock) {
				//if(){
					moveBlock (currentBlock);
				//}
			}
		}

	}
}