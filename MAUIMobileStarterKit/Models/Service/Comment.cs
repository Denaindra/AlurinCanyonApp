using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUIMobileStarterKit.Models.Service
{
    public class Comment
    {
        public int Id { get; set; }
        public int CanyonId { get; set; }
        public string UserName { get; set; }
        public string Useremail { get; set; }
        public DateTime CreationDate { get; set; }
        public string DoneOrView { get; set; }
        public DebitEnum Debit { get; set; }
        public float TempWater { get; set; }
        public float TempAir { get; set; }
        public string UserComment { get; set; }
        public WaterFeeling WaterFeeling { get; set; }
        public AirFeeling AirFeeling { get; set; }
        public virtual Canyon Canyon { get; set; }
    }


    public enum DebitEnum
    {
        TooMuchwater,
        VeryBigFlow,
        BigFlow,
        GoodFlow,
        FewWater,
        NoWater

    }
    public enum WaterFeeling
    {
        Hot,
        Good,
        Cold,
        VeryCold,
        Ice

    }
    public enum AirFeeling
    {
        VeryHot,
        Hot,
        Good,
        Cold,
        VeryCold

    }
}
