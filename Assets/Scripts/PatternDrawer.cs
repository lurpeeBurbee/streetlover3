using UnityEngine;
using System.Collections;

public class PatternDrawer : MonoBehaviour
{
    public int numberOfSides;
    public float polygonRadius;
    public Vector2 polygonCenter;
    public float cornerAngle;
    public Vector2 currentCorner;

    void Update()
    {
        DebugDrawPolygon(polygonCenter, polygonRadius, numberOfSides);
    }
    private IEnumerator Draw(Vector2 curCor, Vector2 perCor)
    {
        yield return new WaitForSeconds(0.2f);
        Debug.DrawLine(curCor, perCor);

    }
    // Draw a polygon in the XY plane with a specfied position, number of sides
    // and radius.
    void DebugDrawPolygon(Vector2 center, float radius, int numSides)
    {
        // The corner that is used to start the polygon (parallel to the X axis).
        Vector2 startCorner = new Vector2(radius, 0) + center;

        // The "previous" corner point, initialised to the starting corner.
        Vector2 previousCorner = startCorner;

        // For each corner after the starting corner...
        for (int i = 1; i < numSides; i++)
        {
            // Calculate the angle of the corner in radians.
            cornerAngle = 2f * Mathf.PI / numSides * i;

            // Get the X and Y coordinates of the corner point.
            currentCorner = new Vector2(Mathf.Cos(cornerAngle) * radius, Mathf.Sin(cornerAngle) * radius) + center;

            // Draw a side of the polygon by connecting the current corner to the previous one.

         

            // Having used the current corner, it now becomes the previous corner.
            previousCorner = currentCorner;
        }
   StartCoroutine(Draw(currentCorner, previousCorner));    

        // Draw the final side by connecting the last corner to the starting corner.
        Debug.DrawLine(startCorner, previousCorner);
    }
}