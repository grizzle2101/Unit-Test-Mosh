using System;

namespace TestNinja.Fundamentals
{
    //Section 4 - Tutorial 3 - DermitCalculator
    //We provide the  Speed, and get how many penalty point they should recieve.
    //For every 5k over the speedlimit 65, they get 1 penalty point.
    //-Over the Speed Limit
    //-Under the Speed Limit
    //-Same as SpeedLimit
    //Exception Handling - Speed of over 300

    public class DemeritPointsCalculator
    {
        private const int SpeedLimit = 65;
        private const int MaxSpeed = 300;
        
        public int CalculateDemeritPoints(int speed)
        {
            if (speed < 0 || speed > MaxSpeed) 
                throw new ArgumentOutOfRangeException();
            
            if (speed <= SpeedLimit) return 0; 
            
            const int kmPerDemeritPoint = 5;
            var demeritPoints = (speed - SpeedLimit)/kmPerDemeritPoint;

            return demeritPoints;
        }        
    }
}