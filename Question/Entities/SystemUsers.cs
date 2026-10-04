using System;

namespace Entities
{
    public class SystemUsers
    {
        public int SystemUsersId { get; set; }
        public string FName { get; set; }
        public string MName { get; set; }
        public string LName { get; set; }
        public int GenderId { get; set; }
        public string Gender { get; set; }
        public int IsActive { get; set; }
        public int AssembliesId { get; set; }
        public string Title { get; set; }
        public int SeatTypesId { get; set; }
        public string SeatType { get; set; }
        public string Email { get; set; }
        public int ElectionProvinceId { get; set; }
        public string ElectionProvince { get; set; }
        public int PoliticalPartyId { get; set; }
        public string PoliticalParty { get; set; }
        public int MemberPartyId { get; set; }
        public string MemberParty { get; set; }
        public int MemberStatusId { get; set; }
        public string MemberStatus { get; set; }
        public int ConstituenciesId { get; set; }
        public string Constituency { get; set; }
        public int PolAffilliationId { get; set; }
        public string PolAffilliation { get; set; }
        public int HouseAffilliationsId { get; set; }
        public string HouseAffilliation { get; set; }
        public int MemElectTypesId { get; set; }
        public string MemElectType { get; set; }
        public int ElectionTypesId { get; set; }
        public string ElectionType { get; set; }
        public int PartyDesignationsId { get; set; }
        public string PartyDesignation { get; set; }
        public DateTime TenureFrom { get; set; }
        public DateTime TenureTo { get; set; }
        public int MemTenuresId { get; set; }
        public string MemTenure { get; set; }


    }
}
