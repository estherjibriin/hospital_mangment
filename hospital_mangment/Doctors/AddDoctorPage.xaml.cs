namespace hospital_mangment.Doctors;

public partial class AddDoctorPage : ContentPage
{
    bool check;
    doctor up;
    DataClasses1DataContext db;
    public AddDoctorPage(bool check,doctor up)
	{
        InitializeComponent();
        db = conn.connect();
        if (check)
        {
            PopulateDoctorData(up);
            AddDoctorButton.Text = "Update";
            
        }
        this.check = check;
        this.up = up;
		
	}
    private async void OnAddDoctorClicked(object sender, EventArgs e)
    {
     

     

        
        if (check)
        {
            Update();
            await DisplayAlert("Doctor updated", "The doctor has been updates successfully.", "OK");
        }
        else
        {
            doctor();
            await DisplayAlert("Doctor Added", "The doctor has been added successfully.", "OK");
        }
        // Navigate back to the previous page
        await Navigation.PopAsync();
    }

    private void Update()
    {
        var doctor = db.doctors.FirstOrDefault(doctor => doctor.id == this.up.id);
        if (doctor != null)
        {
            doctor newDoctor = new doctor();
            doctor.name = NameEntry.Text;
            doctor.specialty = SpecialtyEntry.Text;
            doctor.login = LoginEntry.Text;
            doctor.password = PasswordEntry.Text;
            doctor.id = int.Parse(IdEntry.Text);
            db.SubmitChanges();
        }
    }

    private void doctor()
    {
        if (IsValidForm())
        {
            doctor newDoctor = new doctor();
            newDoctor.name = NameEntry.Text;
            newDoctor.specialty = SpecialtyEntry.Text;
            newDoctor.login = LoginEntry.Text;
            newDoctor.password = PasswordEntry.Text;
            newDoctor.id = int.Parse(IdEntry.Text);
            db.doctors.InsertOnSubmit(newDoctor);
            db.SubmitChanges();
        }


    }
    private bool IsValidForm()
    {
        // Check if the name is not empty
        if (string.IsNullOrEmpty(NameEntry.Text))
        {
            DisplayAlert("Error", "Please enter a name.", "OK");
            return false;
        }

        // Check if the specialty is not empty
        if (string.IsNullOrEmpty(SpecialtyEntry.Text))
        {
            DisplayAlert("Error", "Please enter a specialty.", "OK");
            return false;
        }

        // Check if the login is not empty
        if (string.IsNullOrEmpty(LoginEntry.Text))
        {
            DisplayAlert("Error", "Please enter a login.", "OK");
            return false;
        }

        // Check if the password is not empty
        if (string.IsNullOrEmpty(PasswordEntry.Text))
        {
            DisplayAlert("Error", "Please enter a password.", "OK");
            return false;
        }

        return true;
    }
    public void PopulateDoctorData(doctor doctor)
    {
        IdEntry.Text = doctor.id.ToString();
        NameEntry.Text = doctor.name;
        SpecialtyEntry.Text = doctor.specialty;
        LoginEntry.Text = doctor.login;
        PasswordEntry.Text = doctor.password;
    }

}