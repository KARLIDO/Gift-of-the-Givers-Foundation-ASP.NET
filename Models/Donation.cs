﻿namespace Gift_of_the_Givers_Foundation.Models
{
    public class Donation
    {
        public int Id { get; set; }
        public string ResourceName { get; set; }
        public string ResourceType { get; set; }
        public int Quantity { get; set; }
        public string DonorName { get; set; }
        public string DonorContact { get; set; }
    }

}