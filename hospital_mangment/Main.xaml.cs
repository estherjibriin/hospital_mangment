using hospital_mangment.Appointment;
using hospital_mangment.Doctors;
using hospital_mangment.Doctor_Manager;
namespace hospital_mangment;

public partial class NewPage1 : ContentPage
{
	public NewPage1()
	{
		InitializeComponent();

	}
    private async void GO_to_patient(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Patient());


    } 
    private async void GO_to_doctor(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new manage_doctor());


    } private async void GO_to_app(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new add_App());


    } private async void Login(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Doctor_login());


    }
}
