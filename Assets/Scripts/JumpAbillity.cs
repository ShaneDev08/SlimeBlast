using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Jump Abillity 
// Can have jump count as upgrades etc
public class JumpAbillity : Abillity
{

    private int jumpCount { get; }


    public JumpAbillity(string name, bool enabled, int amount)
    {
        this.name = name;
        this.isEnabled = enabled;
        this.amountToBuy = amount;
    }

    public JumpAbillity(string name, bool enabled, int amount,int countJump)
    {
        this.name = name;
        this.isEnabled = enabled;
        this.amountToBuy = amount;
        this.jumpCount = countJump;
    }


}
