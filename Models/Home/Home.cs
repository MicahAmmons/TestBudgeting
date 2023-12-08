namespace TestBudgeting.Models.Weather;


public class Home
    {
        public Weather1 Weather1Var { get; set; }
        public IEnumerable<Weather1> Weather1VarCollection { get; set; }
        public Weather2 Weather2Var { get; set; }
        public IEnumerable<Weather2> Weather2VarCollection { get; set; }
        public Time Time { get; set; }

    }

