using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityManipulator : MonoBehaviour
{
    [ContextMenu("Gravity Up")]
    private void GravityUp(){
        Physics.gravity = new Vector3(0f, 9.81f, 0f);
    }
    [ContextMenu("Gravity Down")]
    private void GravityDown(){
        Physics.gravity = new Vector3(0f, -9.81f, 0f);
    }
}
