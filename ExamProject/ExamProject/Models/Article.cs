//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ExamProject.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Article
    {
        public int articleID { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public int userID { get; set; }
        public string question1 { get; set; }
        public string question1_choice { get; set; }
        public string question1_A { get; set; }
        public string question1_B { get; set; }
        public string question1_C { get; set; }
        public string question1_D { get; set; }
        public string question2 { get; set; }
        public string question2_choice { get; set; }
        public string question2_A { get; set; }
        public string question2_B { get; set; }
        public string question2_C { get; set; }
        public string question2_D { get; set; }
        public string question3 { get; set; }
        public string question3_choice { get; set; }
        public string question3_A { get; set; }
        public string question3_B { get; set; }
        public string question3_C { get; set; }
        public string question3_D { get; set; }
        public string question4 { get; set; }
        public string question4_choice { get; set; }
        public string question4_A { get; set; }
        public string question4_B { get; set; }
        public string question4_C { get; set; }
        public string question4_D { get; set; }
        public string creationDate { get; set; }
    
        public virtual User User { get; set; }
    }
}