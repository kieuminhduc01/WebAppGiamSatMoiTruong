using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppGiamSatMoiTruong.Models.CustomModels
{
    public class AccountPaging
    {
        public int draw { get; set; }
        public int recordsTotal { get; set; }
        public int recordsFiltered { get; set; }
        public List<AccountShow> data { get; set; }
    }
    public class AccountShow
    {
        public string UserName { get; set; }
        public string FullName { get; set; }
        public DateTime Dob { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Actions { get; set; }
    }

    public class Detail
    {
        public string UserName { get; set; }
        public string PassWord { get; set; }
        public string FullName { get; set; }
        public DateTime Dob { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public byte[] Active { get; set; }
        public string AccountRole { get; set; }
    }
}
