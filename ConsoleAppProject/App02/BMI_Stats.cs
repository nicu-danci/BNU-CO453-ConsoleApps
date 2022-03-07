using System;
using System.ComponentModel.DataAnnotations;

namespace ConsoleAppProject.App02
{
    /// <summary>
    /// A list of WHO Weight Status 
    /// </summary>
    /// 
    /// <author>
    /// Nicoara Danci 07/03/2022
    /// </author>
    public enum BMI_Status
    {
        None,
        [Display(Name = "Underweight")]
        UnderWeight,
        [Display(Name = "Normal weight")]
        NormalWeight,
        [Display(Name = "Overweight")]
        OverWeight,
        [Display(Name = "Obese Class I")]
        ObeseI,
        [Display(Name = "Obese Class II")]
        ObeseII,
        [Display(Name = "Obese Class III")]
        ObeseIII
    }
}