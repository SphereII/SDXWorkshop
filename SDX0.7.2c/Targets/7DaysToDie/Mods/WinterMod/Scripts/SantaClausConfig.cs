using UnityEngine;
using System.Collections;
using System.Linq;
// Script for Santa Claus asset by Oliver Wuensch
//this script manages parenting and visibility of Santa's props
//NAMESPACE is SantaClaus


	public class SantaClausConfig : MonoBehaviour
	{
    //public variables shown in inspector
		public bool CaneVisible = false;
		public bool CandyCaneVisible = true;
		public bool CaneAttachedToHand = true;
		public bool CandyCaneAttachedToHand = true;
		public bool SackVisible = true;
		public bool SackAttachedToHand = true;
		public bool GiftAttachedToHand = false;
    //objects connected as props to Santa in inspector
    public GameObject myCane;
    public GameObject myCandyCane ;
        public GameObject mySack;
		public GameObject myGift ;
        public GameObject myCanePlace ;
		public GameObject myCandyCanePlace ;
    public GameObject mySackPlace ;
    public GameObject myGiftPlace;
		//internal control variables to check for for changes during runtime
		private bool ctrl_CaneVisible = false;
		private bool ctrl_CandyCaneVisible = true;
		private bool ctrl_CaneAttachedToHand = true;
		private bool ctrl_CandyCaneAttachedToHand = true;
		private bool ctrl_SackVisible = true;
		private bool ctrl_SackAttachedToHand = true;
		private bool ctrl_GiftAttachedToHand = true;
		//store original position of gift to reset 
		private Vector3 myGiftOriPos;
		private Quaternion myGiftOriRot;

    private GameObject myGameObject; 
        public GameObject FindGameObject( string strObjectName )
    {
        Debug.Log(" Searching for " + strObjectName);

        foreach (Transform child in transform)
        { 
            Debug.Log("Foreach loop: " + child.ToString());
            Debug.Log(child.name.ToString());
            Debug.Log(child.gameObject.name.ToString());
        }
     
        return null;

    }
		// Use this for initialization
		public void Start ( GameObject gameObject )
		{

        myGameObject = gameObject;
        myCane = FindGameObject("Cane");
    myCandyCane = FindGameObject("CandyCane");
   mySack = FindGameObject("Sack_closed");
   myGift = FindGameObject("GiftA");
    myCanePlace = FindGameObject("CanePositon");
   myCandyCanePlace = FindGameObject("CandyCanePosition");
   mySackPlace = FindGameObject("SackPosition");
    myGiftPlace = FindGameObject("GiftPosition");

        //store Position of Gift for reset
        //StoreGiftPosRot ();
        //interpret the public variables
        Initialize ();
			print ("Santa Claus wishes you a merry Christmas!");

		}
	
		// Update is called once per frame
		public void Update ()
		{
			//check if public variables have changed during runtime
			CheckControlVariables ();

		}

		void Initialize ()
		{

            Debug.Log("SantaClassConfig is initializing");
        //activate desired props according to boolean switches
        //make props child of positioned dummy object in hand and zero out local rotation and position
        try
        {
            Debug.Log("0");

            if (myCane)
            {
                Debug.Log("My Cane!");
                myCane.SetActive(CaneVisible);
            }
            Debug.Log("1");
            if ( myCandyCane )
                myCandyCane.SetActive(CandyCaneVisible);
            Debug.Log("2");
            if ( mySack )
                mySack.SetActive(SackVisible);
            Debug.Log("3");

            if (CaneAttachedToHand)
            {
                myCane.transform.parent = myCanePlace.transform;
                myCane.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, 0));
                myCane.transform.localPosition = new Vector3(0, 0, 0);
            }
            else
                myCane.transform.parent = null;

            if (CandyCaneAttachedToHand)
            {
                myCandyCane.transform.parent = myCandyCanePlace.transform;
                myCandyCane.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, 0));
                myCandyCane.transform.localPosition = new Vector3(0, 0, 0);
            }
            else
                myCandyCane.transform.parent = null;

            if (SackAttachedToHand)
            {
                mySack.transform.parent = mySackPlace.transform;
                mySack.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, 0));
                mySack.transform.localPosition = new Vector3(0, 0, 0);
            }
            else
                mySack.transform.parent = null;

            if (GiftAttachedToHand)
            {
                GiftInHand(true);
            }
            else
                GiftInHand(false);

            //set private variables to control changes at runtime
            SetControlVariables();
        }
        catch( System.Exception ex )
        {
            Debug.Log("Exception: " + ex.ToString());
        }

		}

		void SetControlVariables ()
		{
			//sets the control variables all at once 
			// these are for easy check if any bool has changed at runtime
			ctrl_CaneVisible = CaneVisible;
			ctrl_CandyCaneVisible = CandyCaneVisible;
			ctrl_CaneAttachedToHand = CaneAttachedToHand;
			ctrl_CandyCaneAttachedToHand = CandyCaneAttachedToHand;
			ctrl_SackVisible = SackVisible;
			ctrl_SackAttachedToHand = SackAttachedToHand;
			ctrl_GiftAttachedToHand = GiftAttachedToHand;
		}
	
		void CheckControlVariables ()
		{
			//Check if any public boolean has changed at runtime
			//if true, run Initialize to execute the changes
			if (ctrl_CaneVisible != CaneVisible 
				|| ctrl_CandyCaneVisible != CandyCaneVisible 
				|| ctrl_CaneAttachedToHand != CaneAttachedToHand
				|| ctrl_CandyCaneAttachedToHand != CandyCaneAttachedToHand 
				|| ctrl_SackVisible != SackVisible
				|| ctrl_GiftAttachedToHand != GiftAttachedToHand
				|| ctrl_SackAttachedToHand != SackAttachedToHand) {
				//apply changes
				Initialize ();
			}


		}

		public void  DropSack ()
		{
			//Santa unparents sack from hand
			//used by SantaClausEvents triggered by Events in mechanim Motion WalkToIdle.
			print ("Santa: Sack dropped (unparented)because of trigger event in motionfile WalkToIdle");
			SackAttachedToHand = false;
			mySack.transform.parent = null;

		
		}

		public void  GiftInHand (bool isGiftHand)
		{
			//manage gift in hand
			if (isGiftHand) {
				//gift is in hand, set position and rotation to hand dummy and zero out
				//StoreGiftPosRot();
				myGift.transform.parent = myGiftPlace.transform;
				myGift.transform.localRotation = Quaternion.Euler (new Vector3 (0, 0, 0));
				myGift.transform.localPosition = new Vector3 (0, 0, 0);
			} else
				//gift not in hand, reset position
				ResetGiftPosRot ();

			
		}

		public void  StoreGiftPosRot ()
		{ 
			//store position of gift for reset

			myGiftOriPos = myGift.transform.position;
			myGiftOriRot = myGift.transform.rotation;

		}

		public void  ResetGiftPosRot ()
		{
			//reset position of gift
			myGift.transform.parent = null;
			myGift.transform.position = myGiftOriPos;	
			myGift.transform.rotation = myGiftOriRot;

		}


	}



