namespace Playable.Interact
{
    public interface IInteractable
    {
        void OnClick(Player.Player player);
        void OnHoverEnter();
        void OnHoverExit();
    }
}