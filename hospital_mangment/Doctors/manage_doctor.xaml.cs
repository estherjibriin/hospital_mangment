namespace hospital_mangment.Doctors;

public partial class manage_doctor : ContentPage
{
    public List<Doctor> Doctors { get; set; }
    DataClasses1DataContext db = conn.connect();
    Doctor selected_doctor;
    bool selected=false;
    public manage_doctor()
	{
		InitializeComponent();
        Doctors = (from doctor in db.doctors
                   select new Doctor
                   {
                       Id = doctor.id,
                       Name = doctor.name,
                       Specialty = doctor.specialty,
                       Login = doctor.login,
                       Password = doctor.password
                   }).ToList();

        BindingContext = this;
    }
    private void OnDoctorSelected(object sender, SelectedItemChangedEventArgs e)
    {

        if (e.SelectedItem == null)
        {
            return;
        }

        // Cast the selected item to Patient object
        selected_doctor = e.SelectedItem as Doctor;
        selected = true;

    }
    // Dummy function for adding a doctor
    private async void AddDoctor_Clicked(object sender, EventArgs e)
    {

        await Navigation.PushAsync(new AddDoctorPage(false,null));
       }


    

    // Dummy function for updating a doctor
    private async void UpdateDoctor_Clicked(object sender, EventArgs e)
    {
        if(selected)
        {
            await Navigation.PushAsync(new AddDoctorPage(selected, d_to_d(selected_doctor)));

        }
        else
        {
            DisplayAlert("Error", "Please select the doctor.", "OK");
        }
    }

    // Dummy function for removing a doctor
    private async void RemoveDoctor_Clicked(object sender, EventArgs e)
    {

        if (selected && selected_doctor != null)
        {
            DataClasses1DataContext db = conn.connect();
            d_to_d(selected_doctor);
            var doc = db.doctors.FirstOrDefault(doc => doc.id == d_to_d(selected_doctor).id);
            if (doc != null)
            {
                db.doctors.DeleteOnSubmit(doc);
                db.SubmitChanges();
                DisplayAlert("DOne", "Doctor Deleted Successfully", "OK");
                selected = false;
                var currentPage = Application.Current.MainPage.Navigation.NavigationStack.LastOrDefault();

// Remove the current page from the navigation stack
Application.Current.MainPage.Navigation.RemovePage(currentPage);

// Push a new instance of the same page
await Application.Current.MainPage.Navigation.PushAsync(new manage_doctor());
            }
        }
        else
        {
            DisplayAlert("Error", "PLease Select Doctor", "OK");

        }
    }


    private doctor d_to_d(Doctor doctor)
    {
        doctor doctor1 = new doctor();
        doctor1.id = doctor.Id;
        doctor1.name = doctor.Name;
        doctor1.password = doctor.Password;
        doctor1.login = doctor.Login;
        doctor1.specialty = doctor.Specialty;
        return doctor1;
    }
}