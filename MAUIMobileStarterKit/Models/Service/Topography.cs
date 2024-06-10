using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MAUIMobileStarterKit.Models.Service
{
    public class Topography: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public int Id { get; set; }
        public int CanyonId { get; set; }
        public ObstacleTypeEnum TypeObstacle { get; set; }
        public string TailleObstacle { get; set; }
        public PositionPoint PositionPoint { get; set; }
        public DangerTypeEnum TypeDanger { get; set; }
        public string TopoComment { get; set; }
        public string ImageObstacle { get; set; }
        public string ImageDanger { get; set; }

        private Boolean isValidTopo;

        public Boolean IsValidTopo
        {
            get { return isValidTopo; }
            set { isValidTopo = value;
                NotifyPropertyChanged(nameof(IsValidTopo));
            }
        }


        public Boolean IsAuthorize { get; set; }
        public int Order { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ValidationDate { get; set; }
        public string UserName { get; set; }
        public virtual Canyon Canyon { get; set; }

        public void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
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
