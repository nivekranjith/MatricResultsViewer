using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MatricResultsReporting.DataModels
{
    public class MatricResultsHistory
    {
        private long emis;
        private long centerNo;
        private string nameOfSchool;

        private int wrote2014;
        private int passed2014;
        private double passRate2014;

        private int wrote2015;
        private int passed2015;
        private double passRate2015;

        private int wrote2016;
        private int passed2016;
        private double passRate2016;

        public MatricResultsHistory()
        {
            this.wrote2014 = 0;
            this.wrote2015 = 0;
            this.wrote2016 = 0;

            this.passed2014 = 0;
            this.passed2015 = 0;
            this.passed2016 = 0;

            this.passRate2014 = 0;
            this.passRate2015 = 0;
            this.passRate2016 = 0;

        }

        public long Emis
        {
            get
            {
                return emis;
            }

            set
            {
                emis = value;
            }
        }

        public long CenterNo
        {
            get
            {
                return centerNo;
            }

            set
            {
                centerNo = value;
            }
        }

        public string NameOfSchool
        {
            get
            {
                return nameOfSchool;
            }

            set
            {
                nameOfSchool = value;
            }
        }

        public int Wrote2014
        {
            get
            {
                return wrote2014;
            }

            set
            {
                wrote2014 = value;
            }
        }

        public int Passed2014
        {
            get
            {
                return passed2014;
            }

            set
            {
                passed2014 = value;
            }
        }

        public double PassRate2014
        {
            get
            {
                if(passRate2014 == 0 && wrote2014 > 0)
                {
                    passRate2014 = Math.Round((double) passed2014 / wrote2014 * 100,2);
                }

                return passRate2014;
            }

            set
            {
                passRate2014 = value;
            }
        }

        public int Wrote2015
        {
            get
            {
                return wrote2015;
            }

            set
            {
                wrote2015 = value;
            }
        }

        public int Passed2015
        {
            get
            {
                return passed2015;
            }

            set
            {
                passed2015 = value;
            }
        }

        public double PassRate2015
        {
            get
            {
                if (passRate2015 == 0 && wrote2015 > 0)
                {
                    passRate2015 = Math.Round((double)passed2015 / wrote2015 * 100, 2);
                }

                return passRate2015;
            }

            set
            {
                passRate2015 = value;
            }
        }

        public int Wrote2016
        {
            get
            {
                return wrote2016;
            }

            set
            {
                wrote2016 = value;
            }
        }

        public int Passed2016
        {
            get
            {
                return passed2016;
            }

            set
            {
                passed2016 = value;
            }
        }

        public double PassRate2016
        {
            get
            {
                if (passRate2016 == 0 && wrote2016 > 0)
                {
                    passRate2016 = Math.Round((double)passed2016 / wrote2016 * 100, 2);
                }

                return passRate2016;
            }

            set
            {
                passRate2016 = value;
            }
        }
    }
}