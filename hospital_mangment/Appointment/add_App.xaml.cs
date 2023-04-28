namespace hospital_mangment.Appointment;
using hospital_mangment.Doctors;
using System;

public partial class add_App : ContentPage
{
    DataClasses1DataContext db;
	public add_App()
	{
        db = conn.connect();
		InitializeComponent();
       foreach(Pateints p in pateints_List())
        {
            PatientPicker.Items.Add(p.Id.ToString());

        }
        foreach (Doctor doc in doclist())
        {
            DoctorPicker.Items.Add(doc.Id.ToString());
        }

    }
    private void OnPatientSelectionChanged(object sender, System.EventArgs e)
    {
        // Get selected patient
        int selectedPatientId = int.Parse(PatientPicker.SelectedItem.ToString());
        Pateints selectedPatient = pateints_List().Find(selectedPatient => selectedPatient.Id== selectedPatientId);

        // Display patient details
        PatientNameLabel.Text = selectedPatient.Name;
        PatientDetailsLabel.Text = $"Age: {selectedPatient.DateOfBirth}\nGender: {selectedPatient.Gender}";

       
        
    }

    private void OnDoctorSelectionChanged(object sender, System.EventArgs e)
    {
        // Get selected doctor
        int selectedDoctorId = int.Parse(DoctorPicker.SelectedItem.ToString());
        Doctor selectedDoctor = doclist().Find(Doctor => Doctor.Id == selectedDoctorId);

        // Display doctor details
        DoctorNameLabel.Text = selectedDoctor.Name;
        DoctorSpecialtyLabel.Text = selectedDoctor.Specialty;
        
    }   private async void OnSubmitClicked(object sender, System.EventArgs e)
    {
        Random random = new Random();
        appointment ap= new appointment();
        ap.id= random.Next(1, 1000001);
        ap.patient_id= int.Parse(PatientPicker.SelectedItem.ToString());
        ap.doctor_id=int.Parse(DoctorPicker.SelectedItem.ToString());
        ap.appointment_date = DatePicker.Date;
        ap.appointment_type = "Regular";
        ap.notes = "ghgjhj";
        ap.is_missing = false;
        db.appointments.InsertOnSubmit(ap);
        db.SubmitChanges();
        DisplayAlert("Appointment add", "Pres ok to Continue", "ok");
        var currentPage = Application.Current.MainPage.Navigation.NavigationStack.LastOrDefault();

        // Remove the current page from the navigation stack
        Application.Current.MainPage.Navigation.RemovePage(currentPage);

        // Push a new instance of the same page
        await Application.Current.MainPage.Navigation.PushAsync(new manage_doctor());
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
    public List<Pateints> pateints_List()
    {
        List<Pateints> Patients=new List<Pateints>();   
        var p = db.patients.ToList();
        foreach (patient pr in p)
        {

            Patients.Add(new Pateints(pr.id, pr.first_name, pr.date_of_birth, pr.gender, pr.address, pr.phone_number,
                pr.email, pr.medical_history, pr.allergies));
        }
        return Patients;
    } public void OnSaveClicked()
    {
        
    }
}