using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUIMobileStarterKit.Models.Service
{
    public class Topography
    {
        public int Id { get; set; }
        public int CanyonId { get; set; }
        public ObstacleTypeEnum TypeObstacle { get; set; }
        public string TailleObstacle { get; set; }
        public PositionPoint PositionPoint { get; set; }
        public DangerTypeEnum TypeDanger { get; set; }
        public string TopoComment { get; set; }
        public string ImageObstacle { get; set; }
        public string ImageDanger { get; set; }
        public Boolean IsValidTopo { get; set; }
        public Boolean IsAuthorize { get; set; }
        public int Order { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ValidationDate { get; set; }
        public string UserName { get; set; }
        public virtual Canyon Canyon { get; set; }
    }
    public enum PositionPoint
    {
        RiveGauche,
        RiveDroite,
        None
    }
    public enum DangerTypeEnum
    {
        RopeFriction,
        RopeBlocking,
        Syphon,
        Drossage,
        Slippery,
        RockFall,
        None

    }

    public enum ObstacleTypeEnum
    {
        Danger,
        Waterfall,
        Toboggan,
        Walking,
        Escape,
        // Affluent
        Tributary,
        Siphon,
        Tunnel,
        Road,
        Trees,
        RocksChaos,
        RunningHand,
        Barrage,
        swimming,
        jump,
        relais,
        monopoint,
        Exit,
        Bridge,
        None
    }
}
