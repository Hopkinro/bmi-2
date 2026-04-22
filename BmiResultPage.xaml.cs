using BMICalculatorNavigationApp.Models;

namespace BMICalculatorNavigationApp.Pages;

public partial class BmiResultPage : ContentPage
{
    private readonly BmiUserData userData;

    public BmiResultPage(BmiUserData data)
    {
        InitializeComponent();
        userData = data;
        LoadData();
    }

    private void LoadData()
    {
        GenderLabel.Text = $"Gender: {userData.Gender}";
        WeightLabel.Text = $"Weight: {userData.Weight} lbs";
        HeightLabel.Text = $"Height: {userData.Height} in";
        BmiLabel.Text = $"BMI: {userData.BMI:F1}";
        CategoryLabel.Text = $"Category: {userData.Category}";
    }

    private async void OnRecommendationsClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new RecommendationsPage(userData));
    }

    private async void OnBackToInputClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}