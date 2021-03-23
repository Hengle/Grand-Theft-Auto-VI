using System;
using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;
using UnityEngine.AI;

public class Fighter : NetworkBehaviour
{
    [SerializeField] private Vector3 movement = new Vector3();


    [Client]
    private void Update()
    {
        if (!hasAuthority) return;
        
        if (!Input.GetKeyDown(KeyCode.Space)) return;
        CmdMove();
       // transform.Translate(movement);
    }

    [Command]
    private void CmdMove()
    {
        RpcMove();
    }

    [ClientRpc]
    private void RpcMove() => transform.Translate(movement);
}
