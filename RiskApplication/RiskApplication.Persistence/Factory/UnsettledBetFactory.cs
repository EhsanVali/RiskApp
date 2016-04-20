using CsvHelper;
using RiskApplication.Domain.Models;

namespace RiskApplication.Persistence.Factory
{
    public class UnsettledBetFactory : IBetFactory<UnsettledBet>
    {
        public UnsettledBet CreateBet(ICsvReader csvReader)
        {
            var customerId = csvReader.GetField<int>("Customer");
            var eventId = csvReader.GetField<int>("Event");
            var participantId = csvReader.GetField<int>("Participant");
            var stake = csvReader.GetField<int>("Stake");
            var toWin = csvReader.GetField<int>("ToWin");

            var unsettledBet = new UnsettledBet
            {
                CustomerId = customerId,
                Event = eventId,
                Participant = participantId,
                Stake = stake,
                ToWin = toWin
            };

            return unsettledBet;
        }
    }
}