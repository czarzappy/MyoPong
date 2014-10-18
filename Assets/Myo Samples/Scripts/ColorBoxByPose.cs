using UnityEngine;
using System.Collections;

using Pose = Thalmic.Myo.Pose;
using VibrationType = Thalmic.Myo.VibrationType;

// Change the material when certain poses are made with the Myo armband.
// Vibrate the Myo armband when a fist pose is made.
public class ColorBoxByPose : MonoBehaviour
{
    // Myo game object to connect with.
    // This object must have a ThalmicMyo script attached.
    public GameObject myo = null;

    // Materials to change to when poses are made.
    public Material waveInMaterial;
    public Material waveOutMaterial;
    public Material thumbToPinkyMaterial;

    // The pose from the last update. This is used to determine if the pose has changed
    // so that actions are only performed upon making them rather than every frame during
    // which they are active.
    private Pose _lastPose = Pose.Unknown;
	private float initT = 0f;
	private float deltaT = 0f;

    // Update is called once per frame.
    void FixedUpdate ()
    {
        // Access the ThalmicMyo component attached to the Myo game object.
		ThalmicMyo thalmicMyo = myo.GetComponent<ThalmicMyo> ();
		GameObject surface = GameObject.Find("Surface");

		float box_horizontal_pos = this.transform.position.x;
		float box_vertical_pos = this.transform.position.y;
		
		// update x and y of shield pos rel to box s.t. shield moves w/ box
		surface.transform.position = new Vector3(box_horizontal_pos, box_vertical_pos, surface.transform.position.z);

        // Check if the pose has changed since last update.
        // The ThalmicMyo component of a Myo game object has a pose property that is set to the
        // currently detected pose (e.g. Pose.Fist for the user making a fist). If no pose is currently
        // detected, pose will be set to Pose.Rest. If pose detection is unavailable, e.g. because Myo
        // is not on a user's arm, pose will be set to Pose.Unknown.
        if (thalmicMyo.pose != _lastPose) {
            _lastPose = thalmicMyo.pose;

            // Vibrate the Myo armband when a fist is made.
			if (thalmicMyo.pose == Pose.FingersSpread) {
				//deltaT = 0;
				//GameObject cube = GameObject.Find("");
				// turn on the shields
				surface.renderer.enabled = true;

				//surface.transform.position = Vector3.zero;
				thalmicMyo.Vibrate (VibrationType.Medium);
			}


            else {
				Debug.Log("Else"); 
				// by default, we want the shields to be turned off unless the user clenches their
				// fist...but only if they clenched it for more than 1 sec continuously
				//deltaT += Time.deltaTime;
				//Debug.Log (deltaT);
				//if(deltaT > 1)
				//{
					surface.renderer.enabled = false;
				//}
				//GameObject.Find("Surface").transform.parent = null;
			}

			// Change material when wave in, wave out or thumb to pinky poses are made.
			/*} else if (thalmicMyo.pose == Pose.WaveIn) {
                renderer.material = waveInMaterial;
            } else if (thalmicMyo.pose == Pose.WaveOut) {
                renderer.material = waveOutMaterial;*/
			/*else if (thalmicMyo.pose == Pose.ThumbToPinky) {
                renderer.material = thumbToPinkyMaterial;
            }*/
        }
    }
}
	