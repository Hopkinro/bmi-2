using BMICalculatorNavigationApp.Models;

namespace BMICalculatorNavigationApp.Pages;

public partial class RecommendationsPage : ContentPage
{
    private readonly BmiUserData userData;

    public RecommendationsPage(BmiUserData data)
    {
        InitializeComponent();
        userData = data;
        LoadRecommendations();
    }

    private void LoadRecommendations()
    {
        SummaryLabel.Text = $"{userData.Gender} - {userData.Category} (BMI: {userData.BMI:F1})";
        RecommendationLabel.Text = GetRecommendation(userData.Category, userData.Gender);
    }

    private string GetRecommendation(string category, string gender)
    {
        if (gender == "Male")
        {
            return category switch
            {
                "Underweight" => "You may need to increase your calorie intake with balanced meals, more protein, and strength training. Consider talking to a doctor or nutritionist if needed.",
                "Normal weight" => "You are in a healthy range. Keep doing regular exercise, eat balanced meals, stay hydrated, and maintain a good sleep schedule.",
                "Overweight" => "Focus on portion control, regular cardio, strength training, and reducing processed foods. Try to stay active throughout the week.",
                "Obese" => "It may help to start with a structured workout routine, healthier food choices, and support from a medical professional. Small consistent changes matter a lot.",
                _ => "Keep working toward a healthy lifestyle with better eating habits and regular activity."
            };
        }
        else
        {
            return category switch
            {
                "Underweight" => "You may benefit from nutrient-dense meals, healthy snacks, and strength-building exercise. A healthcare provider can help if weight gain is difficult.",
                "Normal weight" => "You are in a healthy range. Keep up balanced nutrition, regular workouts, hydration, and enough rest each day.",
                "Overweight" => "Try building a routine with walking, cardio, and strength work while improving meal quality and reducing sugary foods or drinks.",
                "Obese" => "A step-by-step health plan with exercise, better nutrition, and medical guidance can help a lot. Start small and stay consistent.",
                _ => "Keep working toward a healthy lifestyle with better eating habits and regular activity."
            };
        }
    }

    private async void OnBackToResultClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }

    private async void OnBackToInputClicked(object sender, EventArgs e)
    {
        await Navigation.PopToRootAsync();
    }
}