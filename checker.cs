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
        bool battery_status = ValidateTemperature(temperature) ? ValidateStateOfCharge(state_of_charge) ? ValidateChargeRate(chargeRate) ? true:false:false:false;
        return battery_status;
        /*if(!ValidateTemperate(temperature)) 
        {
            Console.WriteLine("Temperature is out of range!");
            return false;
        } 
        else if(!ValidateStateOfCharge(state_of_charge)) 
        {
            Console.WriteLine("State of Charge is out of range!");
            return false;
        }
        else if(!ValidateChargeRate(chargeRate)) 
        {
            Console.WriteLine("Charge Rate is out of range!");
            return false;
        }
        return true;
        */
    }
    
    //Validate System Temperature
    static bool ValidateTemperature(float temperature_data)
    {            
        system_output = temperature_data < temp_min || temperature_data > temp_max ? false : true;      
        if(!system_output)
        {
            Console.WriteLine("Temperature is out of range!");
        }
        return system_output;
    }
    
    //Validate System State of Charge
    static bool ValidateStateOfCharge(float soc_input)
    {                 
        system_output = soc_input < soc_min || soc_input > soc_max ? false : true;
        if(!system_output)
        {
            Console.WriteLine("State of Charge is out of range!");
        }
       return system_output;
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
        ExpectFalse(BatteryIsOk(50, 85, 0.0f));
        Console.WriteLine("All ok");
        return 0;
    }
}
