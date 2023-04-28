namespace hospital_mangment.Appointment;

public partial class doc_App : ContentPage
{ DataClasses1DataContext db=conn.connect();
	public doc_App()
	{
		InitializeComponent();
	}
    protected override void OnAppearing()
    {
        base.OnAppearing();

        // Get the current date
        DateTime currentDate = DateTime.Today;

        // Get the doctor's appointments for the current date
        List<appointment> appointments = db.appointments.ToList();

        // Clear the appointments layout
        appointmentsLayout.Children.Clear();

        // Add the appointment items
        foreach (appointment appointment in appointments)
        {
            StackLayout appointmentItem = new StackLayout();

            Label patientLabel = new Label();
            patientLabel.Text = appointment.patient.first_name;
            appointmentItem.Children.Add(patientLabel);

            Label timeLabel = new Label();
            timeLabel.Text = appointment.appointment_date.ToString();
            appointmentItem.Children.Add(timeLabel);

            CheckBox completedCheckBox = new CheckBox();
            if(appointment.is_missing!=null)
            completedCheckBox.IsChecked = (bool)appointment.is_missing;
            appointmentItem.Children.Add(completedCheckBox);

            appointmentsLayout.Children.Add(appointmentItem);
        }
    }
    private async void OnSaveClicked(object sender, System.EventArgs e)
    {
       
    }
}