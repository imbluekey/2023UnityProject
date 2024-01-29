using System.Collections;
using System.Collections.Generic;

public class ObjectNameDetection
{
    static public bool HasString(string testStr, string target)
    //If the target is in the testStr, it returns true. If not returns false.
    //For example, if the testStr is "slimeRigidBody" and target is "RigidBody", it returns true.
    //This function is made to detect object for ArrowControl which has to stop Arrow only for particular objects.
    { 
        if(testStr.Contains(target)) return true;
        return false;
    }
}
