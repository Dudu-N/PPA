using PPASystem.Entities;

namespace PPASystem.DTOs
{
    public class EventDto
    {
        public string Code { get; set; }

        public string Name { get; set; }

        public DateTime Date { get; set; }

        public string StartVenue { get; set; }

        public string RouteDescription { get; set; }

        public decimal Distance { get; set; }

        public decimal WinningTime { get; set; }

        public decimal AdjustedWinningTime { get; set; }

        public EventFormat Format { get; set; }
    }
}
