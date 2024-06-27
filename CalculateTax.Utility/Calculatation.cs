namespace CalculateTax.Utility
{
    public class Calculatation
    {
        private decimal _income;
        private string _filingStatus;
        private decimal _tax = 0;
        private decimal SD = 0;

        private const decimal SD_Single = 14600;
        private const decimal SD_MarriedFilingJointly = 29200;
        private const decimal SD_MarriedFilingSeparately = 14600;
        private const decimal SD_HeadOfHousehold = 21900;


        public decimal GetSD()
        {
            return SD;
        }


        public Calculatation(decimal income, string filingStatus)
        {
            _income = income;
            _filingStatus = filingStatus;
        }

        public decimal CalculateTax()
        {
            if (_filingStatus == "Single")
            {
                _income -= SD_Single;
                SD = SD_Single;
                if (_income <= 11600)
                {
                    _tax = _income * 0.10m;
                }
                else if (_income <= 47150)
                {
                    _tax = 1160 + (_income - 11600) * 0.12m;
                }
                else if (_income <= 100525)
                {
                    _tax = 5426 + (_income - 47150) * 0.22m;
                }
                else if (_income <= 191950)
                {
                    _tax = 17168.5m + (_income - 100525) * 0.24m;
                }
                else if (_income <= 243725)
                {
                    _tax = 39110.5m + (_income - 191950) * 0.32m;
                }
                else if (_income <= 609350)
                {
                    _tax = 183647.25m + (_income - 243725) * 0.35m;
                }
                else
                {
                    _tax = 183648 + (_income - 609350) * 0.37m;
                }
            }
            else if (_filingStatus == "MarriedFilingJointly")
            {
                _income -= SD_MarriedFilingJointly;
                SD = SD_MarriedFilingJointly;
                if (_income <= 23200)
                {
                    _tax = _income * 0.10m;
                }
                else if (_income <= 94300)
                {
                    _tax = 2320 + (_income - 23200) * 0.12m;
                }
                else if (_income <= 201050)
                {
                    _tax = 10852 + (_income - 94300) * 0.22m;
                }
                else if (_income <= 383900)
                {
                    _tax = 34337 + (_income - 201050) * 0.24m;
                }
                else if (_income <= 487450)
                {
                    _tax = 78221 + (_income - 383900) * 0.32m;
                }
                else if (_income <= 731200)
                {
                    _tax = 111357 + (_income - 487450) * 0.35m;
                }
                else
                {
                    _tax = 196669.5m + (_income - 731200) * 0.37m;
                }
            }
            else if (_filingStatus == "MarriedFilingSeparately")
            {
                _income -= SD_MarriedFilingSeparately;
                SD = SD_MarriedFilingSeparately;
                if (_income <= 11600)
                {
                    _tax = _income * 0.10m;
                }
                else if (_income <= 47150)
                {
                    _tax = 1160 + (_income - 11600) * 0.12m;
                }
                else if (_income <= 100525)
                {
                    _tax = 5426 + (_income - 47150) * 0.22m;
                }
                else if (_income <= 191950)
                {
                    _tax = 17168.5m + (_income - 100525) * 0.24m;
                }
                else if (_income <= 243725)
                {
                    _tax = 39110.5m + (_income - 191950) * 0.32m;
                }
                else if (_income <= 365600)
                {
                    _tax = 55678.5m + (_income - 243725) * 0.35m;
                }
                else
                {
                    _tax = 98334.75m + (_income - 365600) * 0.37m;
                }
            }
            else if (_filingStatus == "HeadOfHousehold")
            {
                _income -= SD_HeadOfHousehold;
                SD = SD_HeadOfHousehold;
                if (_income <= 16550)
                {
                    _tax = _income * 0.10m;
                }
                else if (_income <= 63100)
                {
                    _tax = 1655 + (_income - 16550) * 0.12m;
                }
                else if (_income <= 100500)
                {
                    _tax = 7241 + (_income - 63100) * 0.22m;
                }
                else if (_income <= 191950)
                {
                    _tax = 15469 + (_income - 100500) * 0.24m;
                }
                else if (_income <= 243700)
                {
                    _tax = 37417 + (_income - 191950) * 0.32m;
                }
                else if (_income <= 609350)
                {
                    _tax = 53977 + (_income - 243700) * 0.35m;
                }
                else
                {
                    _tax = 181954.5m + (_income - 609350) * 0.37m;
                }
            }

            return _tax;
        }
    }
}
