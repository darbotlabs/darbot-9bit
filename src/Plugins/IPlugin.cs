namespace Plugins
{
    public interface IPlugin
    {
        void Initialize();
        void Update();
        void Render();
    }
}
