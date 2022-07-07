using System;
using System.Diagnostics;

class Checker
{
    //System Parameter  boundary values
    const float temp_min= 0;
    const float temp_max=45;
    const float soc_min=20;
    const float soc_max=70;
    const float charge_rate=0.8f;
    static bool system_output=false;
    
    static bool BatteryIsOk(float temperature, float state_of_charge, float chargeRate) 
    {        
        bool battery_status = ValidateTemperatureAndStateOfCharge(temperature,state_of_charge) ? (ValidateChargeRate(chargeRate) ? true:false):false;            
        return battery_status;       
    }    
    
    //Validate System Temperature and System of Charge
     static bool ValidateTemperatureAndStateOfCharge(float temperature_data, float soc)
    {            
            if (!ValidateData(temperature_data,temp_min,temp_max))
            {
                Console.WriteLine("Temperature is out of range!");
                return false;
            }
            else
            {
                if (!ValidateData(soc,soc_min,soc_max))
                {
                    Console.WriteLine("State of Charge is out of range!");
                    return false;
                }
                else
                {
                    return true;
                }
            }      
     }       

    //Validate Charge Rate
    static bool ValidateChargeRate(float charge_state_data)
    {            
        system_output = charge_state_data > charge_rate ? false : true;
        if(!system_output)
        {
            Console.WriteLine("Charge Rate is out of range!");
        }
        return system_output;
    }
    
    //Validate System Parameters
    static bool ValidateData(float input, float minimum_data,float maximum_data)
        {
            system_output = input < minimum_data || input > maximum_data ? false : true;
            return system_output;
        }
        
    static void ExpectTrue(bool expression) 
    {
        if(!expression) 
        {
            Console.WriteLine("Expected true, but got false");
            Environment.Exit(1);
        }
    }
    static void ExpectFalse(bool expression) 
    {
        if(expression) 
        {
            Console.WriteLine("Expected false, but got true");
            Environment.Exit(1);
        }
    }
    static int Main() 
    {
        ExpectTrue(BatteryIsOk(25, 70, 0.7f));
        ExpectTrue(BatteryIsOk(45,55,0.5f));
        ExpectTrue(BatteryIsOk(0,70,0.5f));
        ExpectTrue(BatteryIsOk(30,70,-0.5f));
        ExpectTrue(BatteryIsOk(30,20,0.25f));
                 
        ExpectFalse(BatteryIsOk(50, 85, 0.0f));
        ExpectFalse(BatteryIsOk(-2, 85, 0.0f));
        ExpectFalse(BatteryIsOk(30, 80, 0.0f));
        ExpectFalse(BatteryIsOk(30, 10, 0.0f));
        ExpectFalse(BatteryIsOk(30, 10, 10.0f));
        Console.WriteLine("All ok");
        return 0;
    }
}
