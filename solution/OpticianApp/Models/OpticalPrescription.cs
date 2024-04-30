using System;
using System.ComponentModel.DataAnnotations;

namespace OpticianApp.Models;

public class OpticalPrescription
{
    public int ID { get; set; }
    public int CustomerId { get; set; }

     [DataType(DataType.Date)]
    public DateTime PrescriptionDate { get; set; }
    public decimal RightEyeCorrection { get; set; }
    public decimal LeftEyeCorrection { get; set; }

    // Navigation property
    public Customer? Customer { get; set; }
}
