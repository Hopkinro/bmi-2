namespace BMICalculatorNavigationApp.Models;

public class BmiUserData
{
    public double Weight { get; set; }
    public double Height { get; set; }
    public string Gender { get; set; } = "Male";
    public double BMI { get; set; }
    public string Category { get; set; } = string.Empty;
}