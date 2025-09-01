// See https://aka.ms/new-console-template for more information

Console.WriteLine("Hello, World!");

int Control(int altitude)
{
    int thruster = 0;

    if (altitude > 100)
    {
        thruster = 0; // Thruster OFF
    }
    else if (altitude > 0)
    {
        thruster = 1; // Thruster ON
    }
    else
    {
        thruster = 0; // Thruster OFF
    }

    return thruster;
}
void Test(int altitude)
{
    int thruster = Control(altitude);
    bool behaviorCorrect = (altitude > 100 && thruster == 0) ||
                           (altitude is <= 100 and > 0 && thruster == 1) ||
                           (altitude <= 0 && thruster == 0);
    var behaviorCorrectIcon = behaviorCorrect ? "✅" : "❌";
    Console.WriteLine($"For altitude {altitude}, your thruster is {thruster} |{behaviorCorrectIcon}|");
}

Test(150);
Test(100);
Test(50);
Test(0);
Test(-1);
