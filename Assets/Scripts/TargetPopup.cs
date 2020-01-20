using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetPopup : MonoBehaviour
{
    [Header("Targets")]
    [SerializeField] private GameObject target1;
    [SerializeField] private GameObject target2;
    [SerializeField] private GameObject target3;

    //Back row spawnpoints
    [Header("Back Row")]
    [SerializeField] private Transform leftBack;
    [SerializeField] private Transform midBack;
    [SerializeField] private Transform rightBack;

    //Middle row spawnpoints
    [Header("Middle Row")]
    [SerializeField] private Transform leftMid;
    [SerializeField] private Transform midMid;
    [SerializeField] private Transform rightMid;

    //front row spawnpoint
    [Header("Front Row")]
    [SerializeField] private Transform midFront;
    

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(target1, midFront.transform.position, transform.rotation);

        Instantiate(target3, leftBack.transform.position, transform.rotation);
        Instantiate(target3, midBack.transform.position, transform.rotation);
        Instantiate(target3, rightBack.transform.position, transform.rotation);

        Instantiate(target2, leftMid.transform.position, transform.rotation);
        Instantiate(target2, midMid.transform.position, transform.rotation);
        Instantiate(target2, rightMid.transform.position, transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
