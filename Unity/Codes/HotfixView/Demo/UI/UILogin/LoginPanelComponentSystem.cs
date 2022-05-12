namespace ET
{
    public static class LoginPanelComponentSystem
    {
        public static void RegisterUIEvent(this LoginPanelComponent self)
        {
            self.View.LoginBtn_LoginBtn.AddListener(() =>
            {
                self.OnLogin();
            });
        }
        public static void OnLogin(this LoginPanelComponent self)
        {
            LoginHelper.Login(
                self.DomainScene(), 
                ConstValue.LoginAddress, 
                self.View.NameInput_NameInput.text, 
                self.View.PasswordInput_PasswordInput.text).Coroutine();
        }
    }
}