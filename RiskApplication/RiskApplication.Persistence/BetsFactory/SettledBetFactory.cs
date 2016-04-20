using CsvHelper;
using RiskApplication.Domain.Models;

namespace RiskApplication.Persistence.BetsFactory
{
    public class SettledBetFactory : IBetFactory<SettledBet>
    {
        public SettledBet CreateBet(ICsvReader csvReader)
        {
            var customerId = csvReader.GetField<int>("Customer");
            var eventId = csvReader.GetField<int>("Event");
            var participantId = csvReader.GetField<int>("Participant");
            var stake = csvReader.GetField<int>("Stake");
            var win = csvReader.GetField<int>("Win");

            var settledBet = new SettledBet
            {
                CustomerId = customerId,
                Event = eventId,
                Participant = participantId,
                Stake = stake,
                Win = win
            };

            return settledBet;
        }
    }
}