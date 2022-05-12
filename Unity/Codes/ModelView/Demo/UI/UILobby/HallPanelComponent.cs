namespace ET
{
    public class HallPanelComponent:Entity,IAwake
    {
        public HallPanel View
        {
            get => this.Parent.GetComponent<HallPanel>();
        }
    }
}