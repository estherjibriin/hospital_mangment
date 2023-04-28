using System.Text.RegularExpressions;

namespace hospital_mangment;

public partial class AddPatientPopup : ContentPage
{ private bool check;
    private patient p;
    DataClasses1DataContext db;
    public AddPatientPopup(bool check,patient p)
	{ this.check = check;
        this.p = p;
        db = conn.connect();
        InitializeComponent();
        if (check)
        {
            SaveButton.Text = "Update";
            add_data();
        }
	}

    private void add_data()
    {
        IdEntry.Text = p.id.ToString();
        NameEntry.Text = p.first_name;
        datePicker.Date = (DateTime)p.date_of_birth;
        GenderEntry.Text = p.gender;
        AddressEntry.Text = p.address;
        PhoneNumberEntry.Text = p.phone_number;
        EmailEntry.Text = p.email;
        MedicalHistoryEntry.Text = p.medical_history;
        AllergiesEntry.Text = p.allergies;

    }

    private async void SaveButton_Clicked(object sender, EventArgs e)
    {
        // Perform save operation here
        if (!check)
        {
            save_patient();
            await DisplayAlert("Success", "Patient added successfully", "OK");
        }
        else
        {
            update();
            await DisplayAlert("Success", "Patient updated successfully", "OK");
        }

        await Navigation.PopToRootAsync();
    }

    private void update()
    {
        var patient = db.patients.FirstOrDefault(patient => patient.id== this.p.id);  
        if (patient!=null)
        {
            patient.id = int.Parse(IdEntry.Text);
            patient.first_name = NameEntry.Text;
            patient.date_of_birth = datePicker.Date;
            patient.gender = GenderEntry.Text;
            patient.address = AddressEntry.Text;
            patient.phone_number = PhoneNumberEntry.Text;
            patient.email = EmailEntry.Text;
            patient.medical_history = MedicalHistoryEntry.Text;
            patient.allergies = AllergiesEntry.Text;
            db.SubmitChanges();
        }
    }

    private void save_patient()
    {
        if (ValidateEntries())
        {
            patient patient = new patient();
            patient.id = int.Parse(IdEntry.Text);
            patient.first_name = NameEntry.Text;
            patient.date_of_birth = datePicker.Date;
            patient.gender = GenderEntry.Text;
            patient.address = AddressEntry.Text;
            patient.phone_number = PhoneNumberEntry.Text;
            patient.email = EmailEntry.Text;
            patient.medical_history = MedicalHistoryEntry.Text;
            patient.allergies = AllergiesEntry.Text;

            db.patients.InsertOnSubmit(patient);
            db.SubmitChanges();
        }

    }

    private async void CancelButton_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopToRootAsync();
    }
    private bool ValidateEntries()
    {
        // Check if ID is a valid integer
        if (!int.TryParse(IdEntry.Text, out _))
        {
            DisplayAlert("Error", "Please enter a valid ID.", "OK");
            return false;
        }

        // Check if Name is not empty
        if (string.IsNullOrWhiteSpace(NameEntry.Text))
        {
            DisplayAlert("Error", "Please enter a name.", "OK");
            return false;
        }

        // Check if Date of Birth is not null or empty
        if (datePicker.Date == null || datePicker.Date == DateTime.MinValue)
        {
            DisplayAlert("Error", "Please enter a valid date of birth.", "OK");
            return false;
        }

        // Check if Gender is not empty
        if (string.IsNullOrWhiteSpace(GenderEntry.Text))
        {
            DisplayAlert("Error", "Please enter a gender.", "OK");
            return false;
        }

        // Check if Address is not empty
        if (string.IsNullOrWhiteSpace(AddressEntry.Text))
        {
            DisplayAlert("Error", "Please enter an address.", "OK");
            return false;
        }

        // Check if Phone Number is a valid integer
        if (!int.TryParse(PhoneNumberEntry.Text, out _))
        {
            DisplayAlert("Error", "Please enter a valid phone number.", "OK");
            return false;
        }

        // Check if Email is a valid email address
        if (!Regex.IsMatch(EmailEntry.Text, @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$"))
        {
            DisplayAlert("Error", "Please enter a valid email address.", "OK");
            return false;
        }

        // All entries are valid
        return true;
    }

}