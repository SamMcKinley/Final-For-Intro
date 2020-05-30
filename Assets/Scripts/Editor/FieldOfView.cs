using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
[CustomEditor((typeof(Enemy)))]
public class FieldOfView : Editor
{
   void OnSceneGUI()
    {
        Enemy enemy = (Enemy)target;
        //Show the view radius in the editor
        Handles.color = Color.cyan;
        Handles.DrawWireArc(enemy.transform.position, Vector3.forward, Vector3.right, 360, enemy.ViewRadius);

        //Show the view angle
        Handles.color = Color.cyan;
        Vector3 Angle1 = enemy.AngleToTarget(-enemy.fieldOfView / 2, false);
        Vector3 Angle2 = enemy.AngleToTarget(enemy.fieldOfView / 2, false);
        Handles.DrawLine(enemy.transform.position, enemy.transform.position + Angle1 * enemy.fieldOfView);
        Handles.DrawLine(enemy.transform.position, enemy.transform.position + Angle2 * enemy.fieldOfView);

        //Draw the Raycast line

        if (enemy.visibleTarget != null)
        {
            Handles.color = Color.cyan;
            Handles.DrawLine(enemy.transform.position, enemy.visibleTarget.position); 
        }
    }
   
}
