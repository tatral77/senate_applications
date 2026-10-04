using IPRBIZ;
using IPRENITITIES;
using IPRENTITIES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
{
    public static class DACalculations
    {
        public static double CalculateAsStateGuest(DAMember member, LocationCategoriesRates locationCategoryRates, DADetails dADetails)
        {
            double DaCalculation = 0;
            if (member.CategoryId == 1)
            {
                DaCalculation = (locationCategoryRates.CatTwoRate * 0.3) * dADetails.NoOfNights;
                member.Formula += $"{(locationCategoryRates.CatTwoRate*0.3)}*{dADetails.NoOfNights}";
                member.DaRemarks += "Since the hosts are extending local hospitality, therefore only 30% of Category-II D.A is being paid";
            }
            else if (member.CategoryId == 2)
            {
                DaCalculation = (locationCategoryRates.CatTwoRate * 0.3) * dADetails.NoOfNights;
                member.Formula += $"{(locationCategoryRates.CatTwoRate*0.3)}*{dADetails.NoOfNights}";
                member.DaRemarks += "Since the hosts are extending local hospitality, therefore only 30% of " + member.Category + " D.A is being paid";
            }
            else if (member.CategoryId == 3)
            {
                DaCalculation = (locationCategoryRates.CatThreeRate * 0.3) * dADetails.NoOfNights;
                member.Formula += $"{(locationCategoryRates.CatThreeRate*0.3)}*{dADetails.NoOfNights}";
                member.DaRemarks += "Since the hosts are extending local hospitality, therefore only 30% of " + member.Category + " D.A is being paid";
            }
            else if (member.CategoryId == 4)
            {
                DaCalculation = (locationCategoryRates.CatFourRate * 0.3) * dADetails.NoOfNights;
                member.Formula += $"{(locationCategoryRates.CatFourRate * 0.3)}*{dADetails.NoOfNights}";
                member.DaRemarks += "Since the hosts are extending local hospitality, therefore only 30% of " + member.Category + " D.A is being paid";
            }
            return DaCalculation;
        }

        public static double CalculateAsOwnArrangement(DAMember member, LocationCategoriesRates locationCategoryRates, DADetails dADetails)
        {
            double DaCalculation = 0;
            double HotelHigherSide = dADetails.HotelCharges;
            var OutgoingVisit = new IPRBiz().GetOutgoingVisit(dADetails.VisitId);

            if (HotelHigherSide > 0)
            {
                if (member.CategoryId == 1)
                {
                    if (HotelHigherSide > (locationCategoryRates.CatTwoRate * 0.75))
                    {
                        DaCalculation = (HotelHigherSide + locationCategoryRates.CatTwoRate * 0.5) * dADetails.NoOfNights;
                        member.Formula += $"{(HotelHigherSide)}+{(locationCategoryRates.CatTwoRate * 0.5)}";
                        member.DaRemarks = "The US$ " + HotelHigherSide.ToString() + " is being paid on account of actual charges for hotel in lieu of Cat-II for their stay in " + dADetails.Location.ToString() + " from " + dADetails.FromDate.ToShortDateString() + " to " + dADetails.FromDate.ToShortDateString() + " Finance Division’s O.M. No F-1(10) –R.2006-259 dated 2 August 2023, as Parep " + dADetails.Location.ToString() + " has informed that the hotel rates where booking has been made is US$ ";
                        member.DaRemarks += HotelHigherSide.ToString() + " which is higher than the entitlement i.e. US $ " + locationCategoryRates.CatTwoRate.ToString();
                    }
                    else
                    {
                        if (OutgoingVisit.TransportCharges > 0)
                        {
                            DaCalculation = (locationCategoryRates.CatOneRate + locationCategoryRates.CatTwoRate) * dADetails.NoOfNights;
                            member.Formula += $"{locationCategoryRates.CatOneRate}+{locationCategoryRates.CatTwoRate}*{dADetails.NoOfNights}";
                        }
                        else
                        {
                            DaCalculation = (locationCategoryRates.CatOneRate + locationCategoryRates.CatTwoRate + locationCategoryRates.CatTwoRate * 0.15) * dADetails.NoOfNights;
                            member.Formula += $"{locationCategoryRates.CatOneRate}+{locationCategoryRates.CatTwoRate}+{(locationCategoryRates.CatTwoRate * 0.15)}*{dADetails.NoOfNights}";
                        }
                    }
                }
                else if (member.CategoryId == 2)
                {
                    if (HotelHigherSide > (locationCategoryRates.CatTwoRate * 0.75))
                    {
                        DaCalculation = (HotelHigherSide + locationCategoryRates.CatTwoRate * 0.5) * dADetails.NoOfNights;
                        member.Formula += $"{HotelHigherSide}+{(locationCategoryRates.CatTwoRate * 0.5)}";
                        member.DaRemarks = "The US$ " + HotelHigherSide.ToString() + " is being paid on account of actual charges for hotel in lieu of Cat-II for their stay in " + dADetails.Location.ToString() + " from " + dADetails.FromDate.ToShortDateString() + " to " + dADetails.FromDate.ToShortDateString() + " Finance Division’s O.M. No F-1(10) –R.2006-259 dated 2 August 2023, as Parep " + dADetails.Location.ToString() + " has informed that the hotel rates where booking has been made is US$ ";
                        member.DaRemarks += HotelHigherSide.ToString() + " which is higher than the entitlement i.e. US $ " + locationCategoryRates.CatTwoRate.ToString();
                    }
                    else
                    {
                        if (OutgoingVisit.TransportCharges > 0)
                        {
                            DaCalculation = (locationCategoryRates.CatTwoRate) * dADetails.NoOfNights;
                            member.Formula += $"{locationCategoryRates.CatTwoRate}*{dADetails.NoOfNights} ";
                        }
                        else
                        {
                            DaCalculation = (locationCategoryRates.CatTwoRate + locationCategoryRates.CatTwoRate * 0.15) * dADetails.NoOfNights;
                            member.Formula += $"{locationCategoryRates.CatTwoRate}+{(locationCategoryRates.CatTwoRate * 0.15)}*{dADetails.NoOfNights} ";
                        }
                    }
                }
                else if (member.CategoryId == 3)
                {
                    if (HotelHigherSide > (locationCategoryRates.CatThreeRate * 0.75))
                    {
                        DaCalculation = (HotelHigherSide + locationCategoryRates.CatThreeRate * 0.5) * dADetails.NoOfNights;
                        member.Formula += $"{HotelHigherSide}+{(locationCategoryRates.CatThreeRate * 0.5)}";
                        member.DaRemarks = "The US$ " + HotelHigherSide.ToString() + " is being paid on account of actual charges for hotel in lieu of Cat-II for their stay in " + dADetails.Location.ToString() + " from " + dADetails.FromDate.ToShortDateString() + " to " + dADetails.FromDate.ToShortDateString() + " Finance Division’s O.M. No F-1(10) –R.2006-259 dated 2 August 2023, as Parep " + dADetails.Location.ToString() + " has informed that the hotel rates where booking has been made is US$ ";
                        member.DaRemarks += HotelHigherSide.ToString() + " which is higher than the entitlement i.e. US $ " + locationCategoryRates.CatThreeRate.ToString();
                    }
                    else
                    {
                        if (OutgoingVisit.TransportCharges > 0)
                        {
                            DaCalculation = (locationCategoryRates.CatThreeRate) * dADetails.NoOfNights;
                            member.Formula += $"{locationCategoryRates.CatThreeRate}*{dADetails.NoOfNights}";
                        }
                        else
                        {
                            DaCalculation = (locationCategoryRates.CatThreeRate + locationCategoryRates.CatThreeRate * 0.15) * dADetails.NoOfNights;
                            member.Formula += $"{locationCategoryRates.CatThreeRate}+{locationCategoryRates.CatThreeRate * 0.15}*{dADetails.NoOfNights}";
                        }
                    }
                }
                else if (member.CategoryId == 4)
                {
                    if (HotelHigherSide > (locationCategoryRates.CatFourRate * 0.75))
                    {
                        DaCalculation = (HotelHigherSide + locationCategoryRates.CatFourRate * 0.5) * dADetails.NoOfNights;
                        member.Formula += $"{HotelHigherSide}+{(locationCategoryRates.CatFourRate*0.5)}";
                        member.DaRemarks = "The US$ " + HotelHigherSide.ToString() + " is being paid on account of actual charges for hotel in lieu of Cat-II for their stay in " + dADetails.Location.ToString() + " from " + dADetails.FromDate.ToShortDateString() + " to " + dADetails.FromDate.ToShortDateString() + " Finance Division’s O.M. No F-1(10) –R.2006-259 dated 2 August 2023, as Parep " + dADetails.Location.ToString() + " has informed that the hotel rates where booking has been made is US$ ";
                        member.DaRemarks += HotelHigherSide.ToString() + " which is higher than the entitlement i.e. US $ " + locationCategoryRates.CatFourRate.ToString();
                    }
                    else
                    {
                        if (OutgoingVisit.TransportCharges > 0)
                        {
                            DaCalculation = (locationCategoryRates.CatFourRate) * dADetails.NoOfNights;
                            member.Formula += $"{locationCategoryRates.CatFourRate}*{dADetails.NoOfNights}";
                        }
                        else
                        {
                            DaCalculation = (locationCategoryRates.CatFourRate + locationCategoryRates.CatFourRate * 0.15) * dADetails.NoOfNights;
                            member.Formula += $"{locationCategoryRates.CatFourRate}+{locationCategoryRates.CatFourRate * 0.15}*{dADetails.NoOfNights}";
                        }
                    }
                }
            }
            else
            {
                if (OutgoingVisit.TransportCharges > 0)
                {
                    if (member.CategoryId == 1)
                    {
                        DaCalculation = (locationCategoryRates.CatOneRate + locationCategoryRates.CatTwoRate) * dADetails.NoOfNights;
                        member.Formula += $"{locationCategoryRates.CatOneRate}+{locationCategoryRates.CatTwoRate}*{dADetails.NoOfNights}";

                    }
                    else if (member.CategoryId == 2)
                    {
                        DaCalculation = (locationCategoryRates.CatTwoRate) * dADetails.NoOfNights;
                        member.Formula += $"{locationCategoryRates.CatTwoRate}*{dADetails.NoOfNights}";
                    }
                    else if (member.CategoryId == 3)
                    {
                        DaCalculation = (locationCategoryRates.CatThreeRate) * dADetails.NoOfNights;
                        member.Formula += $"{locationCategoryRates.CatThreeRate}*{dADetails.NoOfNights}";
                    }
                    else if (member.CategoryId == 4)
                    {
                        DaCalculation = (locationCategoryRates.CatFourRate) * dADetails.NoOfNights;
                        member.Formula += $"{locationCategoryRates.CatFourRate}*{dADetails.NoOfNights}";
                    }
                }
                else
                {
                    if (member.CategoryId == 1)
                    {
                        DaCalculation = (locationCategoryRates.CatOneRate + locationCategoryRates.CatTwoRate + locationCategoryRates.CatTwoRate * 0.15) * dADetails.NoOfNights;
                        member.Formula += $"{locationCategoryRates.CatOneRate}+{locationCategoryRates.CatTwoRate}+{locationCategoryRates.CatTwoRate * 0.15}*{dADetails.NoOfNights}";

                    }
                    else if (member.CategoryId == 2)
                    {
                        DaCalculation = (locationCategoryRates.CatTwoRate + locationCategoryRates.CatTwoRate * 0.15) * dADetails.NoOfNights;
                        member.Formula += $"{locationCategoryRates.CatTwoRate}+{locationCategoryRates.CatTwoRate * 0.15}*{dADetails.NoOfNights}";
                    }
                    else if (member.CategoryId == 3)
                    {
                        DaCalculation = (locationCategoryRates.CatThreeRate + locationCategoryRates.CatThreeRate * 0.15) * dADetails.NoOfNights;
                        member.Formula += $"{locationCategoryRates.CatThreeRate}+{locationCategoryRates.CatThreeRate * 0.15}*{dADetails.NoOfNights}";
                    }
                    else if (member.CategoryId == 4)
                    {
                        DaCalculation = (locationCategoryRates.CatFourRate + locationCategoryRates.CatFourRate * 0.15) * dADetails.NoOfNights;
                        member.Formula += $"{locationCategoryRates.CatFourRate}+{locationCategoryRates.CatFourRate * 0.15}*{dADetails.NoOfNights}";
                    }
                }
            }
            return DaCalculation;
        }

        public static double CalculateAsPartialArrangement(DAMember member, LocationCategoriesRates locationCategoryRates, DADetails dADetails)
        {
            double DaCalculation = 0;
            if (member.CategoryId == 1) 
            {
                if (dADetails.FacilityId == 1) // if Board/Lodge then 30% of AC or if Lodge then 50% of AC
                {
                    DaCalculation = (locationCategoryRates.CatTwoRate * 0.3) * dADetails.NoOfNights;
                    member.Formula += $"{(locationCategoryRates.CatTwoRate * 0.3)}*{dADetails.NoOfNights}";
                }
                else if (dADetails.FacilityId == 9)
                {
                    DaCalculation = (locationCategoryRates.CatTwoRate * 0.5) * dADetails.NoOfNights;
                    member.Formula += $"{(locationCategoryRates.CatTwoRate * 0.5)}*{dADetails.NoOfNights}";
                }

            }
            else if (member.CategoryId == 2)
            {
                if (dADetails.FacilityId == 1)
                {
                    DaCalculation = (locationCategoryRates.CatTwoRate * 0.3) * dADetails.NoOfNights;
                    member.Formula += $"{(locationCategoryRates.CatTwoRate * 0.3)}*{dADetails.NoOfNights}";
                }
                else if (dADetails.FacilityId == 9)
                {
                    DaCalculation = (locationCategoryRates.CatTwoRate * 0.5) * dADetails.NoOfNights;
                    member.Formula += $"{(locationCategoryRates.CatTwoRate * 0.5)}*{dADetails.NoOfNights}";
                }
            }
            else if (member.CategoryId == 3)
            {
                if (dADetails.FacilityId == 1)
                {
                    DaCalculation = (locationCategoryRates.CatThreeRate * 0.3) * dADetails.NoOfNights;
                    member.Formula += $"{(locationCategoryRates.CatThreeRate * 0.3)}*{dADetails.NoOfNights}";
                }
                else if (dADetails.FacilityId == 9)
                {
                    DaCalculation = (locationCategoryRates.CatThreeRate * 0.5) * dADetails.NoOfNights;
                    member.Formula += $"{(locationCategoryRates.CatThreeRate * 0.5)}*{dADetails.NoOfNights}";
                }
            }
            else if (member.CategoryId == 4)
            {
                if (dADetails.FacilityId == 1)
                {
                    DaCalculation = (locationCategoryRates.CatFourRate * 0.3) * dADetails.NoOfNights;
                    member.Formula += $"{(locationCategoryRates.CatFourRate * 0.3)} * {dADetails.NoOfNights}";
                }
                else if (dADetails.FacilityId == 9)
                {
                    DaCalculation = (locationCategoryRates.CatFourRate * 0.5) * dADetails.NoOfNights;
                    member.Formula += $"{(locationCategoryRates.CatFourRate * 0.5)} * {dADetails.NoOfNights}";
                }
            }
            return DaCalculation;
        }

        public static double CalculateAsTransit(DAMember member, LocationCategoriesRates locationCategoryRates, DADetails dADetails)
        {
            double DaCalculation = 0;
            if (member.CategoryId == 1)
            {
                DaCalculation = (locationCategoryRates.CatTwoRate * 0.3) * dADetails.NoOfNights;
                member.Formula += $"{(locationCategoryRates.CatTwoRate * 0.3)} * {dADetails.NoOfNights}";
                member.DaRemarks += "For the journey from " + dADetails.Location;
            }
            else if (member.CategoryId == 2)
            {
                DaCalculation = (locationCategoryRates.CatTwoRate * 0.3) * dADetails.NoOfNights;
                member.Formula += $"{(locationCategoryRates.CatTwoRate * 0.3)} * {dADetails.NoOfNights}";
                member.DaRemarks += "For the journey from " + dADetails.Location;
            }
            else if (member.CategoryId == 3)
            {
                DaCalculation = (locationCategoryRates.CatThreeRate * 0.3) * dADetails.NoOfNights;
                member.Formula += $"{(locationCategoryRates.CatThreeRate * 0.3)} * {dADetails.NoOfNights}";
                member.DaRemarks += "For the journey from " + dADetails.Location;
            }
            else if (member.CategoryId == 4)
            {
                DaCalculation = (locationCategoryRates.CatFourRate * 0.3) * dADetails.NoOfNights;
                member.Formula += $"{(locationCategoryRates.CatFourRate * 0.3)} * {dADetails.NoOfNights}";
                member.DaRemarks += "For the journey from " + dADetails.Location;
            }
            return DaCalculation;
        }
        
        public static double CalculateEarlyCheckInLateCheckOut(DAMember member, LocationCategoriesRates locationCategoryRates, DADetails dADetails)
        {
            double DaCalculaion = 0;
            if (dADetails.EarlyCheckinCharges > 0)
            {
                if(dADetails.LatecheckOutCharges > 0)
                {
                    DaCalculaion = dADetails.EarlyCheckinCharges + dADetails.LatecheckOutCharges;
                    member.Formula += $"{dADetails.EarlyCheckinCharges} + {dADetails.LatecheckOutCharges}";
                }
                else
                {
                    DaCalculaion = dADetails.EarlyCheckinCharges;
                    member.Formula += $"{dADetails.EarlyCheckinCharges}";
                }
            }
            else
            {
                if (dADetails.LatecheckOutCharges > 0)
                {
                    DaCalculaion = dADetails.LatecheckOutCharges;
                    member.Formula += $"{dADetails.LatecheckOutCharges}";
                }
                else
                {
                    DaCalculaion = 0;
                    member.Formula += "0";
                }
            }
            return DaCalculaion;
        }

        private static string[] ones = {"zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
        private static string[] tens = { "zero", "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };
        private static string[] thous = { "hundred", "thousand", "million", "billion", "trillion", "quadrillion" };

        //private static string fmt_negative = "negative {0}";
        private static string fmt_dollars_and_cents = "{0} only";
        //private static string fmt_dollars_and_cents = "{0} rupees and {1} paisa only";
        private static string fmt_tens_ones = "{0}-{1}"; // e.g. for twenty-one, thirty-two etc. You might want to use an en-dash or em-dash instead of a hyphen.
        private static string fmt_large_small = "{0} {1}"; // stitches together the large and small part of a number, like "{three thousand} {five hundred forty two}"
        private static string fmt_amount_scale = "{0} {1}"; // adds the scale to the number, e.g. "{three} {million}";

        public static string ToWords(decimal number)
        {
            //if (number < 0)
                //return string.format(fmt_negative, ToWords(Math.Abs(number)));

            int intPortion = (int)number;
            int decPortion = (int)((number - intPortion) * (decimal)100);

            return string.Format(fmt_dollars_and_cents, ToWords(intPortion), ToWords(decPortion));
        }

        private static string ToWords(int number, string appendScale = "")
        {
            string numString = "";
            // if the number is less than one hundred, then we're mostly just pulling out constants from the ones and tens dictionaries
            if (number < 100)
            {
                if (number < 20)
                    numString = ones[number];
                else
                {
                    numString = tens[number / 10];
                    if ((number % 10) > 0)
                        numString = string.Format(fmt_tens_ones, numString, ones[number % 10]);
                }
            }
            else
            {
                int pow = 0; // we'll divide the number by pow to figure out the next chunk
                string powStr = ""; // powStr will be the scale that we append to the string e.g. "hundred", "thousand", etc.

                if (number < 1000)
                { // number is between 100 and 1000
                    pow = 100; // so we'll be dividing by one hundred
                    powStr = thous[0]; // and appending the string "hundred"
                }
                else
                { // find the scale of the number
                  // log will be 1, 2, 3 for 1_000, 1_000_000, 1_000_000_000, etc.
                    int log = (int)Math.Log(number, 1000);
                    // pow will be 1_000, 1_000_000, 1_000_000_000 etc.
                    pow = (int)Math.Pow(1000, log);
                    // powStr will be thousand, million, billion etc.
                    powStr = thous[log];
                }

                // we take the quotient and the remainder after dividing by pow, and call ToWords on each to handle cases like "{five thousand} {thirty two}" (curly brackets added for emphasis)
                numString = string.Format(fmt_large_small, ToWords(number / pow, powStr), ToWords(number % pow)).Trim();
            }

            // and after all of this, if we were passed in a scale from above, we append it to the current number "{five} {thousand}"
            return string.Format(fmt_amount_scale, numString, appendScale).Trim();
        }

    }
}
