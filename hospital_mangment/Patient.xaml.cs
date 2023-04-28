using System.Collections.ObjectModel;

namespace hospital_mangment;

public partial class Patient : ContentPage
{


    bool select = false;
    Pateints selectedPatient;
    public Patient()
    {
        InitializeComponent();
        var viewModel = new Patient_model();
        BindingContext = viewModel;
    }

   

   

        private async void AddPatient_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AddPatientPopup(false,null));

    }

    private async void UpdatePatient_Clicked(object sender, EventArgs e)
    {
        if (select&&selectedPatient!=null)
        {
            await Navigation.PushAsync(new AddPatientPopup(select, convert_p_to_p(selectedPatient)));
            select = false;
        }
        else
        {
            DisplayAlert("Error", "PLease Select Patient", "OK");
        }
    }

    private void RemovePatient_Clicked(object sender, EventArgs e)
    {
        if (select&&selectedPatient!=null)
        {
            DataClasses1DataContext db = conn.connect();
            convert_p_to_p(selectedPatient);
            var patient = db.patients.FirstOrDefault(patient => patient.id == convert_p_to_p(selectedPatient).id);
            if(patient!=null)
            {
                db.patients.DeleteOnSubmit(patient);
                db.SubmitChanges();
                DisplayAlert("DOne", "PAtient Deleted Successfully", "OK");
                select = false;
                var viewModel = new Patient_model();
                BindingContext = viewModel;
            }
        }
        else
        {
            DisplayAlert("Error", "PLease Select Patient", "OK");
            
        }
    }
    private void OnPatientSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem == null)
        {
            return;
        }

        // Cast the selected item to Patient object
         selectedPatient = e.SelectedItem as Pateints;
        if (selectedPatient != null)
        {
            select = true;
        }

        //((ListView)sender).SelectedItem = null;
    }
    private patient convert_p_to_p(Pateints p)
    {
        patient patient = new patient();
        patient.id = p.Id;
        patient.first_name = p.Name;
        patient.date_of_birth = p.DateOfBirth;
        patient.gender = p.Gender;
        patient.address = p.Address;
        patient.phone_number = p.PhoneNumber;
        patient.email = p.Email;
        patient.medical_history = p.MedicalHistory;
        patient.allergies = p.Allergies;
        return patient;
    }

}
