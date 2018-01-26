using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockadeRelease : MonoBehaviour {

    public void Release() {
        this.gameObject.SetActive(false);
    }
}
