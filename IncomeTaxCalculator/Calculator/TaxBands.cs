namespace IncomeTaxCalculator.Calculator
{
    public interface ITaxBands
    {
        IEnumerable<TaxBand> Items {get;}
    }

    public class TaxBand
    {
        public int LowerSalary { get; set; }
        public int UpperSalary { get; set; }
        public int TaxRate { get; set; }
    }

    public class TaxBands_UK : ITaxBands
    {
        public IEnumerable<TaxBand> Items { get; }

        public TaxBands_UK()
        {
            Items = new List<TaxBand>
            {
                new TaxBand { LowerSalary = 0,      UpperSalary = 5000, TaxRate = 0 },
                new TaxBand { LowerSalary = 5000,   UpperSalary = 20000, TaxRate = 20 },
                new TaxBand { LowerSalary = 20000,  UpperSalary = int.MaxValue, TaxRate = 40 }
            };
        }
    }
}