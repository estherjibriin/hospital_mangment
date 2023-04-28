using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hospital_mangment
{
    public class Pateints
    {
        private string first_name;
        private DateTime? date_of_birth;
        private string phone_number;
        private string medical_history;

        public Pateints()
        {
        }

        public Pateints(int id, string name, DateTime dateOfBirth, string gender, string address, string phoneNumber, string email, string medicalHistory, string allergies)
        {
            Id = id;
            Name = name;
            DateOfBirth = dateOfBirth;
            Gender = gender;
            Address = address;
            PhoneNumber = phoneNumber;
            Email = email;
            MedicalHistory = medicalHistory;
            Allergies = allergies;
        }

        public Pateints(int id, string first_name, DateTime? date_of_birth, string gender, string address, string phone_number, string email, string medical_history, string allergies)
        {
            Id = id;
            Name = first_name;
            this.date_of_birth = date_of_birth;
            Gender = gender;
            Address = address;
            PhoneNumber = phone_number;
            Email = email;
            this.medical_history = medical_history;
            Allergies = allergies;
        }

        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string MedicalHistory { get; set; }
        public string Allergies { get; set; }
        public int Id { get; internal set; }
    }
}