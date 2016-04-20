﻿namespace RiskApplication.Domain.Models
{
    public class UnsettledBet
    {
        public int CustomerId { get; set; }
        public int Event { get; set; }
        public int Participant { get; set; }
        public int Stake { get; set; }
        public int ToWin { get; set; }
    }
}