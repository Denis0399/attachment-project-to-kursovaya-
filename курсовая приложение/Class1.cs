using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace курсовая_приложение
{
    public partial class patients
    {
        public patients(string FIO, DateTime birthdate, DateTime admissiondate, string diagnosis, string medicine)
        {
            this.FIO = FIO;
            this.birthdate = birthdate;
            this.admissiondate = admissiondate;
            this.diagnosis = diagnosis;
            this.medicine = medicine;
            OnCreated();
        }
        public override string ToString()
        {
            return $" {this.id}. {FIO}   {birthdate}   {admissiondate}  {diagnosis}  {medicine}  \r\n";
        }


    }
    public partial class dischargedpatient
    {
        public dischargedpatient(string FIO, DateTime birthdate, DateTime admissiondate, DateTime dischargedate, string diagnosis, string medicine)
        {
            this.FIO = FIO;
            this.birthdate = birthdate;
            this.admissiondate = admissiondate;
            this.dischargedate = dischargedate;
            this.diagnosis = diagnosis;
            this.medicine = medicine;
            OnCreated();
        }
        public override string ToString()
        {
            return $" {this.id}. {FIO}   {birthdate}   {admissiondate}  {dischargedate} {diagnosis}  {medicine}  \r\n";
        }


    }
    public partial class analysises
    {
        public analysises(string FIO, string diagnosis, string analysis)
        {
            this.FIO = FIO;


            this.diagnosis = diagnosis;
            this.analysis = analysis;

            OnCreated();
        }
        public override string ToString()
        {
            return $" {this.id}. {FIO}     {diagnosis}  {analysis}   \r\n";
        }


    }
}
