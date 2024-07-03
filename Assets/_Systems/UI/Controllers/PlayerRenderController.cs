using UI.Views;

namespace UI.Controllers
{
    public class PlayerRenderController : BaseController<PlayerRenderView>
    {
        public override void Initialize()
        {
            base.Initialize();
            baseView.leftButtonEvent.AddListener(NextView);
            baseView.rightButtonEvent.AddListener(PrevView);
        }
        
        public override void Close()
        {
            base.Close();
            baseView.leftButtonEvent.RemoveAllListeners();
            baseView.rightButtonEvent.RemoveAllListeners();
        }

        #region Change Sprites Methods
        private void PrevView()
        {
            // TODO: Change Sprites for next
        }

        private void NextView()
        {
            // TODO: Change Sprites for next
        }
        #endregion
    }
}