using System;



    public abstract class BaseEntity
    {
        
        public DateTime CreatedAt { get; set; }= DateTime.Now;

        public string CreatedBy { get; set; }= string.Empty;

        public DateTime? UpdatedAt { get; set; }

        public string UpdatedBy { get; set; }=string.Empty;
    }

