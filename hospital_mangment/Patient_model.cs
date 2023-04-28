using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hospital_mangment
{
    public class Patient_model
    {
        public ObservableCollection<Pateints> Patients { get; set; }
        DataClasses1DataContext db = conn.connect();

        public Patient_model()
        {
            Patients = new ObservableCollection<Pateints> { };
            var p = db.patients.ToList();
            foreach (patient pr in p)
            {

                Patients.Add(new Pateints(pr.id, pr.first_name, pr.date_of_birth, pr.gender, pr.address, pr.phone_number,
                    pr.email, pr.medical_history, pr.allergies));
            }



        }
    }
}
