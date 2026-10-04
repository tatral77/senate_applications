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
        public static double CalculateAsStateGuest(DAMember member, LocationCategoriesRates locationCategoryRates,DADetails dADetails)
        {
            double DaCalculation = 0;
            if (member.CategoryId == 1)
            {
                if (member.IsChairman == 1)
                {
                    DaCalculation = (2000 + locationCategoryRates.CatTwoRate * 0.3) * dADetails.NoOfNights;
                }
                else
                {
                    DaCalculation = (locationCategoryRates.CatTwoRate * 0.3) * dADetails.NoOfNights;
                }
            }
            else if (member.CategoryId == 2)
            {
                DaCalculation = (locationCategoryRates.CatTwoRate * 0.3) * dADetails.NoOfNights;
            }
            else if (member.CategoryId == 3)
            {
                DaCalculation = (locationCategoryRates.CatThreeRate * 0.3) * dADetails.NoOfNights;
            }
            else if (member.CategoryId == 4)
            {
                DaCalculation = (locationCategoryRates.CatFourRate * 0.3) * dADetails.NoOfNights;
            }
            return DaCalculation;
        }

        public static double CalculateAsOwnArrangement(DAMember member, LocationCategoriesRates locationCategoryRates, DADetails dADetails)
        {
            double DaCalculation = 0;
            if (member.CategoryId == 1)
            {
                if (member.IsChairman == 1)
                {
                    DaCalculation = (2000 + locationCategoryRates.CatOneRate + locationCategoryRates.CatTwoRate + locationCategoryRates.CatTwoRate * 0.15) * dADetails.NoOfNights;
                }
                else
                {
                    DaCalculation = (locationCategoryRates.CatOneRate + locationCategoryRates.CatTwoRate + locationCategoryRates.CatTwoRate * 0.15) * dADetails.NoOfNights;
                }
            }
            else if (member.CategoryId == 2)
            {
                DaCalculation = (locationCategoryRates.CatTwoRate + locationCategoryRates.CatTwoRate * 0.15) * dADetails.NoOfNights;
            }
            else if (member.CategoryId == 3)
            {
                DaCalculation = (locationCategoryRates.CatThreeRate + locationCategoryRates.CatThreeRate * 0.15) * dADetails.NoOfNights;
            }
            else if (member.CategoryId == 4)
            {
                DaCalculation = (locationCategoryRates.CatFourRate + locationCategoryRates.CatFourRate * 0.15) * dADetails.NoOfNights;
            }
            return DaCalculation;
        }

        public static double CalculateAsPartialArrangement(DAMember member, LocationCategoriesRates locationCategoryRates, DADetails dADetails)
        {
            double DaCalculation = 0;
            if (member.CategoryId == 1) // if Board/Lodge then 30% of AC or if Lodge then 50% of AC
            {
                if (dADetails.FacilityId == 1)
                {
                    if (member.IsChairman == 1)
                    {
                        DaCalculation = (2000 + locationCategoryRates.CatTwoRate * 0.3) * dADetails.NoOfNights;
                    }
                    else
                    {
                        DaCalculation = (locationCategoryRates.CatTwoRate * 0.3) * dADetails.NoOfNights;
                    }
                }
                else if (dADetails.FacilityId == 9)
                {
                    if (member.IsChairman == 1)
                    {
                        DaCalculation = (2000 + locationCategoryRates.CatTwoRate * 0.5) * dADetails.NoOfNights;
                    }
                    else
                    {
                        DaCalculation = (locationCategoryRates.CatTwoRate * 0.5) * dADetails.NoOfNights;
                    }
                }

            }
            else if (member.CategoryId == 2)
            {
                if (dADetails.FacilityId == 1)
                {
                    DaCalculation = (locationCategoryRates.CatTwoRate * 0.3) * dADetails.NoOfNights;
                }
                else if (dADetails.FacilityId == 9)
                {
                    DaCalculation = (locationCategoryRates.CatTwoRate * 0.5) * dADetails.NoOfNights;
                }
            }
            else if (member.CategoryId == 3)
            {
                if (dADetails.FacilityId == 1)
                {
                    DaCalculation = (locationCategoryRates.CatThreeRate * 0.3) * dADetails.NoOfNights;
                }
                else if (dADetails.FacilityId == 9)
                {
                    DaCalculation = (locationCategoryRates.CatThreeRate * 0.5) * dADetails.NoOfNights;
                }
            }
            else if (member.CategoryId == 4)
            {
                if (dADetails.FacilityId == 1)
                {
                    DaCalculation = (locationCategoryRates.CatFourRate * 0.3) * dADetails.NoOfNights;
                }
                else if (dADetails.FacilityId == 9)
                {
                    DaCalculation = (locationCategoryRates.CatFourRate * 0.5) * dADetails.NoOfNights;
                }
            }
            return DaCalculation;
        }

        public static double CalculateAsTransit(DAMember member, LocationCategoriesRates locationCategoryRates, DADetails dADetails)
        {
            double DaCalculation = 0;
            if (member.CategoryId == 1)
            {
                if (member.IsChairman == 1)
                {
                    DaCalculation = (2000 + locationCategoryRates.CatTwoRate * 0.3) * dADetails.NoOfNights;
                }
                else
                {
                    DaCalculation = (locationCategoryRates.CatTwoRate * 0.3) * dADetails.NoOfNights;
                }
            }
            else if (member.CategoryId == 2)
            {
                DaCalculation = (locationCategoryRates.CatTwoRate * 0.3) * dADetails.NoOfNights;
            }
            else if (member.CategoryId == 3)
            {
                DaCalculation = (locationCategoryRates.CatThreeRate * 0.3) * dADetails.NoOfNights;
            }
            else if (member.CategoryId == 4)
            {
                DaCalculation = (locationCategoryRates.CatFourRate * 0.3) * dADetails.NoOfNights;
            }
            return DaCalculation;
        }
        
    }
}
