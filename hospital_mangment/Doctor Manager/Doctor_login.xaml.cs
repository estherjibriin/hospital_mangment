using Azure.Identity;
using hospital_mangment.Appointment;
using hospital_mangment.Doctors;

namespace hospital_mangment.Doctor_Manager;

public partial class Doctor_login : ContentPage
{ DataClasses1DataContext db=conn.connect();
	public Doctor_login()
	{
		InitializeComponent();
	}
    private async void OnLoginClicked(object sender, System.EventArgs e)
    {
        string id = UsernameEntry.Text;
        string pass=PasswordEntry.Text; 
        foreach(Doctor doc in doclist())
        {
            if(doc.Password == pass &&doc.Login==id)
            {
                DisplayAlert("Login Success", "Pres ok to Continue", "ok");
                await Navigation.PushAsync(new doc_App());
                return;

            }

        }
        DisplayAlert("Login Failure", "Pres ok to Continue", "ok");


    }
    public List<Doctor> doclist()
    {
        List<Doctor> Doctors = new List<Doctor>();
        Doctors = (from doctor in db.doctors
                   select new Doctor
                   {
                       Id = doctor.id,
                       Name = doctor.name,
                       Specialty = doctor.specialty,
                       Login = doctor.login,
                       Password = doctor.password
                   }).ToList();
        return Doctors;
    }
}