namespace rrp3CW1RapidBrowser
{
    public interface IDisplay <T>
    {
        string HTMLDisplay(T obj);
        string HttpDisplay(T obj);
        string TitleDisplay(T obj);
    }
}