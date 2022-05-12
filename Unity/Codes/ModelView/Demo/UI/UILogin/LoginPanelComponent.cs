namespace ET
{
    public class LoginPanelComponent :Entity,IAwake
    {
        public LoginPanel View
        {
            get => this.Parent.GetComponent<LoginPanel>();
        }
    }
}