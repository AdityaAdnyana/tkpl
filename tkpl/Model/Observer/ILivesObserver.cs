namespace tkpl.Model.Observer
{
    /// <summary>
    /// Observer (Subscriber) interface untuk Observer Pattern.
    /// Mendeklarasikan method notifikasi yang dipanggil oleh publisher
    /// saat terjadi perubahan pada state nyawa.
    /// Ref: https://refactoring.guru/design-patterns/observer
    /// </summary>
    public interface ILivesObserver
    {
        void Update(int currentLives);
    }
}
